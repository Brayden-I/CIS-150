using Newtonsoft.Json;
using System;

namespace People
{
    internal class Program
    {
        public class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public string Email { get; set; }
            public bool IsStudent { get; set; }
        }

        static void Main(string[] args)
        {
            try { 
                // Create a list of Person objects
                List<Person> people = new List<Person>
                {
                    new Person { Name = "John Doe", Age = 30, Email = "john.doe@example.com", IsStudent = false },
                    new Person { Name = "Jane Smith", Age = 25, Email = "jane.smith@example.com", IsStudent = true }
                };

                // Serialize the list to JSON
                string json = JsonConvert.SerializeObject(people, Formatting.Indented);
                Console.WriteLine("Serialized JSON:\n" + json);

                // Deserialize the JSON back to a list of Person objects
                List<Person> deserializedPeople = JsonConvert.DeserializeObject<List<Person>>(json);

                Console.WriteLine("\nDeserialized People:");
                foreach (var person in deserializedPeople)
                {
                    Console.WriteLine($"Name: {person.Name}, Age: {person.Age}, Email: {person.Email}, IsStudent: {person.IsStudent}");
                }
            }
            //Exceptions
            catch (JsonSerializationException ex)
            {
                Console.WriteLine("\nError: Invalid JSON format.");
                Console.WriteLine("Details: " + ex.Message);
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine("\nError: JSON string is null or empty.");
                Console.WriteLine("Details: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nAn unexpected error occurred.");
                Console.WriteLine("Details: " + ex.Message);
            }
        }
    }
}
