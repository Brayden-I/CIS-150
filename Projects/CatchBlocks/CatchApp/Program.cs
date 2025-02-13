namespace CatchApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = "49"; // or use "49" in a notebook
            try
            {
                int age = int.Parse(input);
                Console.WriteLine($"You are {age} years old.");
            }
            catch (FormatException)
            {
                Console.WriteLine("The age you have entered is not a valid format");
            }
            catch(Exception ex)
            {
                Console.WriteLine($"{ex.GetType()} says {ex.Message}");
            }
        }
    }
}
