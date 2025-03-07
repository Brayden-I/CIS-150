using System;

namespace Program
{
    //Exceptions
    public class InvalidUsernameException : Exception
    {
        public InvalidUsernameException(string message) : base(message) { }
    }

    public class InvalidPasswordException : Exception
    {
        public InvalidPasswordException(string message) : base(message) { }
    }

    //Input Validator
    public class UserInputValidator
    {
        //Username Validator
        public static string EnterUsername(string Username)
        {

            if (Username == null)//Ensures that Username is not Null
            {
                throw new InvalidUsernameException("Username cannot be blank");
            }
            if (Username.Any(Char.IsSeparator)) //Ensures that there are no spaces in the username
            {
                throw new InvalidUsernameException("Username cannot have spaces");
            }
            if (Username.Length < 5) //Validates username length
            {
                throw new InvalidUsernameException("Username must be at least 5 characters long");
            }

            return Username;
        }

        //Password Validator
        public static string EnterPassword(string Password)
        {
      
            

            if (Password == null) //Ensures the password is not blank
            {
                throw new InvalidPasswordException("Password cannot be blank");
            }
            if (Password.Length < 8) //Ensures password is atleast 8 characters long
            {
                throw new InvalidPasswordException("Your password must be 8 characters long");
            }
            if (!Password.Any(Char.IsDigit)) //This checks every character making sure there is Any Character that is at least a Digit (any integar)
            {
                throw new InvalidPasswordException("Your password must contain at least 1 digit");
            }
            if (!Password.Any(Char.IsLetter))
            {
                throw new InvalidPasswordException("Your password must contain at least 1 letter");
            }

            return Password;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            String Username;
            String Password;
            
            int attempts = 0;

            while (attempts != 3)
            {
                attempts++;
                try
                {
                    Console.WriteLine("Please enter your username");
                    Username = UserInputValidator.EnterUsername(Console.ReadLine());
                    Console.WriteLine("Please enter your password");
                    Password = UserInputValidator.EnterPassword(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                    Console.ReadLine();
                    Console.Clear();
                    continue;
                }

                Console.WriteLine("Login accepted");
                break;
            }
        }
    }
}
