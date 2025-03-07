using Microsoft.VisualStudio.TestTools.UnitTesting;
using Program;
using System;


namespace ValidatorTest
{
    [TestClass]
    public class UserInputValidatorTests
    {
        //USERNAME EXCEPTIONS
        [TestMethod]
        [ExpectedException(typeof(InvalidUsernameException))]
        public void EnterUsername_ShouldThrowException_WhenUsernameIsNull()
        {
            string result = UserInputValidator.EnterUsername(null);
        }
        [TestMethod]
        [ExpectedException(typeof(InvalidUsernameException))]
        public void EnterUsername_ShouldThrowException_WhenUsernameHasSpaces()
        {
            string result = UserInputValidator.EnterUsername("User name");
        }
        [TestMethod]
        [ExpectedException(typeof(InvalidUsernameException))]
        public void EnterUsername_ShouldThrowException_WhenUsernameTooShort()
        {
            string result = UserInputValidator.EnterUsername("name");
        }

        //PASSWORD EXCEPTIONS
        [TestMethod]
        [ExpectedException(typeof(InvalidPasswordException))]
        public void EnterPassword_ShouldThrowException_WhenPasswordIsNull()
        {
            string result = UserInputValidator.EnterPassword(null);
        }
        [TestMethod]
        [ExpectedException(typeof(InvalidPasswordException))]
        public void EnterPassword_ShouldThrowException_WhenPasswordTooShort()
        {
            string result = UserInputValidator.EnterPassword("pass");
        }
        [TestMethod]
        [ExpectedException(typeof(InvalidPasswordException))]
        public void EnterPassword_ShouldThrowException_WhenPasswordHasNoDigit()
        {
            string result = UserInputValidator.EnterPassword("password");
        }
        [TestMethod]
        [ExpectedException(typeof(InvalidPasswordException))]
        public void EnterPassword_ShouldThrowException_WhenPasswordHasNoLetter()
        {
            string result = UserInputValidator.EnterPassword("12345678");
        }

        //VALIDATOR
        [TestMethod]
        public void EnterUsernameAndPassword_ShouldNotThrowException_WhenValid()
        {
            string validUser = "ValidUser";
            string validPassword = "Valid123";

            string usernameResult = UserInputValidator.EnterUsername(validUser);
            string passwordResult = UserInputValidator.EnterPassword(validPassword);

            Assert.AreEqual(validUser, usernameResult);
            Assert.AreEqual(validPassword, passwordResult);
        }
    }
}
