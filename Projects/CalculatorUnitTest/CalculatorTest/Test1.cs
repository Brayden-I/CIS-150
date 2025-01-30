using Microsoft.VisualStudio.TestTools.UnitTesting;
using CalculatorApp;
using System;

namespace CalculatorTest
{
    [TestClass]
    public sealed class Test1
    {
        private Calculator _calculator;

        [TestInitialize]
        public void Setup()
        {
            _calculator = new Calculator(); //To use a calculator you *need* a calculator
        }

        [TestMethod]
        public void Add_ShouldReturnSum_GivenTwoPositiveNumbers()
        {
            var result = _calculator.Add(5, 7); Assert.AreEqual(12, result);
        }

        [TestMethod]
        public void Add_ShouldReturnSum_GivenNegativeAndPositiveNumber()
        {
            var result = _calculator.Add(5, -7); Assert.AreEqual(-2,result);
        }

        [TestMethod]
        public void Subtract_ShouldReturnDifference_GivenTwoPostiveNumbers()
        {
            var result = _calculator.Subtract(10, 7); Assert.AreEqual(result, 3);
        }

        [TestMethod]
        public void Subtract_ShouldReturnDifference_WhenResultIsNegative()
        {
            var result = _calculator.Subtract(7, 10); Assert.AreEqual(result, -3);
        }

        [TestMethod]
        public void Multiply_ShouldReturnProduct_GivenTwoPositiveNumbers()
        {
            var result = _calculator.Multiply(2, 5); Assert.AreEqual(result, 10);
        }
        [TestMethod]
        public void Multiply_ShouldReturnProduct_GivenNegativeAndPostiveNumber()
        {
            var result = _calculator.Multiply(-2, 5); Assert.AreEqual(result, -10);
        }
        [TestMethod]
        public void Divide_ShouldReturnQuotient_GivenTwoPositiveNumbers()
        {
            var result = _calculator.Divide(10, 2); Assert.AreEqual(result, 5);
        }
        [TestMethod]
        public void Divide_ShouldReturnNegativeQuotient_GivenNegativeAndPositiveNumber()
        {
            var result = _calculator.Divide(10, -2); Assert.AreEqual(result, -5, 0.0001); //Precision for doubles
        }
        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void Divide_ShouldThrowExecption_WhenDividingByZero()
        {
            var result = _calculator.Divide(10, 0);
        }
    }
}
