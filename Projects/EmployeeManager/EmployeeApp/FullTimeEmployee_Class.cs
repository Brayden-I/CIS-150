using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EmployeeApp;

namespace EmployeeApp
{
    public class FullTimeEmployee : Employee
    {
        //FIELDS
        public decimal AnnualBonus { get; set; }

        //CONSTRUCTOR
        public FullTimeEmployee(int id, string name, string department, decimal baseSalary, decimal annualBonus) : base(id, name, department, baseSalary) 
        {
            this.AnnualBonus = annualBonus;
        }

        //METHODS
        public override decimal CalculatePay()
        {
            return BaseSalary + AnnualBonus;
        }

        public override string ToString()
        {
            return base.ToString() + $", Annual Bonus: {AnnualBonus:C}, Total Pay: {CalculatePay():C}";
        }

    }
}
