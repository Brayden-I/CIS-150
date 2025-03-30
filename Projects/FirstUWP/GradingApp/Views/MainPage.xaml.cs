using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.Generic;

using GradingApp.Core.Models;

using Windows.UI.Xaml.Controls;
using Windows.Storage.Pickers;
using System.Threading.Tasks;
using Windows.Storage;

namespace GradingApp.Views
{
    public sealed partial class MainPage : Page, INotifyPropertyChanged
    {
        //Lists
        private List<Student> students = new List<Student>();

        public MainPage()
        {
            InitializeComponent();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void Set<T>(ref T storage, T value, [CallerMemberName]string propertyName = null)
        {
            if (Equals(storage, value))
            {
                return;
            }

            storage = value;
            OnPropertyChanged(propertyName);
        }

        private void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        private void btnAddStudent_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtID.Text) ||
                    string.IsNullOrEmpty(txtFirstName.Text) ||
                    string.IsNullOrEmpty(txtLastName.Text) ||
                    string.IsNullOrEmpty(txtCourse.Text) ||
                    string.IsNullOrEmpty(txtGrade.Text))
                {
                    throw new Exception("All fields are required.");
                }

                Student student = new Student(
                    txtID.Text, txtFirstName.Text,
                    txtLastName.Text,
                    txtCourse.Text,
                    txtGrade.Text.ToUpper()
                    );

                //Add student to list
                students.Add(student);
                listStudents.Items.Add(student.ToString());

                //Clear textboxes
                txtID.Text = "";
                txtFirstName.Text = "";
                txtLastName.Text = "";
                txtCourse.Text = "";
                txtGrade.Text = "";

                //set header back to normal (if was previously marked as required)
                txtID.Header = "ID number";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                txtID.Header = $"ID number *{ex.Message}";

                var dialog = new ContentDialog()
                {
                    Title = "Error",
                    Content = ex.Message,
                    CloseButtonText = "Ok"
                };
            }
        }

        private async void btnLoad_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            try
            {
                var openPicker = new FileOpenPicker(); // Create a new file picker for opening files
                openPicker.SuggestedStartLocation = PickerLocationId.DocumentsLibrary;
                openPicker.FileTypeFilter.Add(".csv");

                var file = await openPicker.PickSingleFileAsync(); // Show the file picker

                if (file != null)
                {
                    var lines = await FileIO.ReadLinesAsync(file); // Read the lines from the file
                    students.Clear(); // Clear the list of students
                    listStudents.Items.Clear(); // Clear the list of students in the UI

                    foreach (var line in lines)
                    {
                        var parts = line.Split(','); // Split the line by commas
                        if (parts.Length == 5)
                        {
                            var student = new Student(parts[0], parts[1], parts[2], parts[3], parts[4]); // Create a new student object
                            students.Add(student); // Add the student to the list
                            listStudents.Items.Add(student.ToString()); // Add the student to the list in the UI
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                var dialog = new ContentDialog()
                {
                    Title = "Error",
                    Content = ex.Message,
                    CloseButtonText = "Ok"
                };
                await dialog.ShowAsync();
            }
        }

        //Save student grades to a CSV file in a location of the user's choice
        private async void btnSaveGrades_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            try
            {
                if (students.Count == 0)
                {
                    throw new Exception("No students to save.");
                }

                var savePicker = new Windows.Storage.Pickers.FileSavePicker(); //Create a new file picker for saving files
                savePicker.SuggestedStartLocation = PickerLocationId.DocumentsLibrary; //Set the start location to the documents library
                savePicker.FileTypeChoices.Add("CSV File", new List<string>() { ".csv" }); //Add the file type choices
                savePicker.SuggestedFileName = "StudentGrades"; //Set the suggested file name

                var file = await savePicker.PickSaveFileAsync(); //Show the file picker

                if (file != null)
                {
                    var lines = new List<string>();
                    foreach (var student in students)
                    {
                        lines.Add($"{student.Id},{student.FirstName},{student.LastName},{student.Class},{student.Grade}");
                    }

                    await FileIO.WriteLinesAsync(file, lines);
                }
            }
            catch (Exception ex)
            {
                var dialog = new ContentDialog()
                {
                    Title = "Error",
                    Content = ex.Message,
                    CloseButtonText = "Ok"
                };
            }
        }
    }
}
