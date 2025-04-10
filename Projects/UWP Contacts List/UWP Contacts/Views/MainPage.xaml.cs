using System;

using UWP_Contacts.ViewModels;
using UWP_Contacts.Core.Models;

using Windows.UI.Xaml.Controls;
using System.Threading.Tasks;

namespace UWP_Contacts.Views
{
    public sealed partial class MainPage : Page
    {
        // Fields for the contact details
        private string imagePath = "/Assets/ContactImgs/Default.jpg";
        private string name;
        private string phoneNumber;

        public MainViewModel ViewModel { get; } = new MainViewModel();

        public MainPage()
        {
            InitializeComponent();
        }

        private void AddContactBtn_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ContactNameBox.Text) || string.IsNullOrWhiteSpace(PhoneNumberBox.Text))
            {
                ContactNameBox.BorderBrush = new Windows.UI.Xaml.Media.SolidColorBrush(Windows.UI.Colors.Red);
                PhoneNumberBox.BorderBrush = new Windows.UI.Xaml.Media.SolidColorBrush(Windows.UI.Colors.Red);

                ContactNameBox.PlaceholderText = "Credentials cannot be blank";
                PhoneNumberBox.PlaceholderText = "Credentials cannot be blank";

                return;
            }

            // If the user has not selected an image, use the default image
            name = ContactNameBox.Text;
            phoneNumber = PhoneNumberBox.Text;
            imagePath = imagePath ?? "/Assets/ContactImgs/Default.jpg";

            try
            {
                new Contact(ContactNameBox.Text, PhoneNumberBox.Text, imagePath);

                ViewModel.ContactList.Add(new Contact(name, phoneNumber, imagePath));

                // Clear the input fields after adding the contact
                ContactNameBox.Text = string.Empty;
                PhoneNumberBox.Text = string.Empty;

                ContactNameBox.BorderBrush = new Windows.UI.Xaml.Media.SolidColorBrush(Windows.UI.Colors.Transparent);
                PhoneNumberBox.BorderBrush = new Windows.UI.Xaml.Media.SolidColorBrush(Windows.UI.Colors.Transparent);

                ContactNameBox.PlaceholderText = "Enter contact name";
                PhoneNumberBox.PlaceholderText = "Enter phone number";
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Error adding contact: {ex.Message}");
            }
        }

        private void DeleteContactBtn_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            ViewModel.ContactList.Remove((Contact)ContactsList.SelectedItem);
        }
    }
}
