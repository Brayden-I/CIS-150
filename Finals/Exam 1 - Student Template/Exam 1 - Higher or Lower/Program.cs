using System.Globalization;
using System.Collections.Generic;

namespace LargestNumberFinder
{
    public class NumberProgram
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Exam");
            Console.WriteLine("You entered:");

            string input = Console.ReadLine() ?? "0";
            int Largest = 0;
            Console.WriteLine(ProcessInput(input, ref Largest));

            Console.ReadLine();
        }

        public static int ProcessInput(string input, ref int largest)
        {
            string[] numbers = input.Split(" ");
            int _int = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                try
                {
                    _int = Convert.ToInt32(numbers[i]);
                }
                catch
                {
                    Console.WriteLine("Your numbers must be integars and greater than 0");
                }

                if (_int > largest)
                {
                    largest = _int;
                }
            }
            return largest;
        }
    }
}
