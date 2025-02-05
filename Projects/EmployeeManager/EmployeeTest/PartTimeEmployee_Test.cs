using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

using EmployeeApp;

namespace EmployeeTest
{
    [TestClass]
    public sealed class PartTimeEmployeeTest
    {
        //Initialize
        private Employee _employee;
        [TestInitialize] public void Init()
        {
            _employee = new PartTimeEmployee(2, "Bob Smith", "IT", 0, 25, 120);
        }
         //CalculatePay
        [TestMethod]
        public void CalculatePay_ShouldReturnCorrectAmount_WhenGivenHourlyRateAndHours()
        {
            var result = _employee.CalculatePay(); Assert.AreEqual(3000, result);
        }
        [TestMethod]
        public void CalculatePay_ShouldReturnZero_WhenHoursWorkedIsZero()
        {
            _employee = new PartTimeEmployee(2, "Bob Smith", "IT", 0, 25, 0);
            var result = _employee.CalculatePay(); Assert.AreEqual(0, result);
        }
        //ToString
        [TestMethod]
        public void ToString_ShouldIncludeHourlyRateAndHoursWorked()
        {
            var result = _employee.ToString(); Assert.AreEqual("ID: 2, Name: Bob Smith, Department: IT, Base Salary: $0.00, Hourly Rate: $25.00, HoursWorked: $120.00",result);
        }
    }
}
