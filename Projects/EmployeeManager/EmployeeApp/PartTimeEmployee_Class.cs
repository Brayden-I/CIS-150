using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EmployeeApp;

namespace EmployeeApp
{
    public class PartTimeEmployee : Employee
    {
        //FIELDS
        public decimal HourlyRate { get; set; }
        public int HoursWorked { get; set; }

        //CONSTRUCTOR
        public PartTimeEmployee(int id, string name, string department, decimal baseSalary, decimal hourlyRate, int hoursWorked) : base(id, name, department, baseSalary)
        {
            this.HourlyRate = hourlyRate;
            this.HoursWorked = hoursWorked;
        }
        
        //METHODS
        public override decimal CalculatePay()
        {
            return HourlyRate * HoursWorked;
        }

        public override string ToString()
        {
            return base.ToString() + $", Hourly Rate: {HourlyRate:C}, HoursWorked: {HoursWorked:C}";
        }
    }
}
