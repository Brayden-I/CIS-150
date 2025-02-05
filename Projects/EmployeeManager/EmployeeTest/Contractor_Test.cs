using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

using EmployeeApp;

namespace EmployeeTest
{
    [TestClass]
    public sealed class ContractorTest
    {
        //Initialize
        private Employee _employee;
        [TestInitialize] public void Init() 
        {
            _employee = new Contractor(3, "Charlie Brown", "Finance", 60000, new DateTime(2025, 12, 31));
        }
        //CalculatePay
        [TestMethod]
        public void CalculatePay_ShouldReturnCorrectAmountForContractor()
        {
            var result = _employee.CalculatePay(); Assert.AreEqual(60000, result);
        }
        [TestMethod]
        public void CalculatePay_ShouldHandleNegativeValuesGracefully()
        {
            _employee = new Contractor(3, "Charlie Brown", "Finance", -60000, new DateTime(2025, 12, 31));
            var result = _employee.CalculatePay(); Assert.IsTrue(result >= 0);
        }
        //ToString
        [TestMethod]
        public void ToString_ShouldIncludeContractExpiryDate()
        {
            var result = _employee.ToString(); Assert.AreEqual("ID: 3, Name: Charlie Brown, Department: Finance, Base Salary: $60,000.00, Contracty Expiry Date: 2025-12-31, Total Pay: $60,000.00", result);
        }
    }
}
