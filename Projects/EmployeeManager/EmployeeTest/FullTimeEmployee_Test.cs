using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

using EmployeeApp;

namespace EmployeeTest
{
    [TestClass]
    public sealed class FullTimeEmployeeTest
    {
        private Employee _employee;
        [TestInitialize] public void Init()
        {
            _employee = new FullTimeEmployee(1, "Alice Johnson", "HR", 50000, 5000);
        }
        
        [TestMethod]
        public void CalculatePay_ShouldReturnBaseSalaryPlusAnnualBonus()
        {
            var result = _employee.CalculatePay(); Assert.AreEqual(55000, result);
        }
        [TestMethod]
        public void CalculatePay_ShouldReturnOnlyBaseSalary_WhenAnnualIsZero()
        {
            _employee = new FullTimeEmployee(1, "Alice Johnson", "HR", 50000, 0);
            var result = _employee.CalculatePay(); Assert.AreEqual(50000, result);
        }
        [TestMethod]
        public void ToString_ShouldReturnCorrectFormat()
        {
            var result = _employee.ToString(); Assert.AreEqual("ID: 1, Name: Alice Johnson, Department: HR, Base Salary: $50,000.00, Annual Bonus: $5,000.00, Total Pay: $55,000.00", result);
        }
    }
}
