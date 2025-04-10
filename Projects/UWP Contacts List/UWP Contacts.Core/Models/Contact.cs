using System;
using System.Collections.Generic;
using System.Text;

namespace UWP_Contacts.Core.Models
{
    public class Contact
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string ImagePath { get; set; }

        public Contact (string name, string phoneNumber, string imagePath)
        {
            Name = name;
            PhoneNumber = phoneNumber;
            ImagePath = imagePath;
        }

        public override string ToString()
        {
            return $"{Name} - {PhoneNumber}";
        }
    }
}
