using System;
using System.Collections.Generic;
using System.Text;

namespace GradingApp.Core.Models
{
    public class Student
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Class { get; set; }
        public string Grade { get; set; }

        //Constructor
        public Student(string id, string firstName, string lastName, string className, string grade) {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Class = className;
            Grade = grade;
        }

        //ToString Method
        public override string ToString()
        {
            return $"{Id} - {FirstName}, {LastName} - {Class} - Grade: {Grade}";
        }
    }
}
