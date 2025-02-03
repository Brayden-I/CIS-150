using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EmployeeApp;

namespace EmployeeApp
{
    public class Contractor : Employee
    {
        //FIELDS
        public DateTime ContractExpiryDate { get; set; }

        //CONSTRUCTOR
        public Contractor(int id, string name, string department, decimal baseSalary, DateTime contractExpiryDate) : base(id, name, department, baseSalary)
        {
            ContractExpiryDate = contractExpiryDate;
        }

        //METHODS
        public override decimal CalculatePay()
        {
            return BaseSalary;
        }

        public override string ToString()
        {
            return base.ToString() + $", Contracty Expiry Date: {ContractExpiryDate:yyyy-MM-dd}, Total Pay: {CalculatePay():C}";
        }
    }
}
