using System;
using System.Collections.ObjectModel;

using Microsoft.Toolkit.Mvvm.ComponentModel;

using UWP_Contacts.Core.Models;

namespace UWP_Contacts.ViewModels
{
    public class MainViewModel : ObservableObject
    {
        public ObservableCollection<Contact> ContactList { get; set; }
        public MainViewModel()
        {
            ContactList = new ObservableCollection<Contact>
            {// Initialize the contact list with some sample data
                new Contact("John Doe", "417-123-1234", "/Assets/ContactImgs/Default.jpg"),
                new Contact("Jane Smith", "417-555-5555", "/Assets/ContactImgs/Default.jpg")
            };
        }
    }
}
