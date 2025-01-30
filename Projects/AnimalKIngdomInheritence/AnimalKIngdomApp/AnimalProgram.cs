using System.Globalization;

namespace AnimalKIngdomApp
{
    public class Animal
    {
        //FIELDS
        public string Name { get; set; }
        public int Age { get; set; }

        //CONSTRUCTOR
        public Animal(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        //METHODS
        public virtual void MakeSound()
        {
            Console.WriteLine($"{Name} makes a sound.");
        }

    }
    internal class AnimalProgram
    {
        static void Main(string[] args)
        {
            //Initialize Animals
            Bird parrot = new Bird("Parrot", 5);
            Fish goldfish = new Fish("Goldfish", 1);

            //Maksound
            parrot.MakeSound(); // Makes the parrot chirp
            goldfish.MakeSound(); // Makes the goldfish bubble

            //Show properties of Animals
            Console.WriteLine(parrot.Name); //Outputs Name of Bird: Parrot
            Console.WriteLine(goldfish.Age); //Outputs Age of Fish: 1
        }
    }
}
