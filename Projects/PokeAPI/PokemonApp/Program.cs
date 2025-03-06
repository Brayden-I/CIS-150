using Newtonsoft.Json;
using System.Net.Http;
using System;
using System.Threading.Tasks;

namespace PokemonApp
{
    internal class Program
    {
        public class Pokemon
        {
            public string Name { get; set; }
            public int Height { get; set; }
            public int Weight { get; set; }
        }
        static async Task Main(string[] args)
        {
            //PUBLIC VARIABLES
            string UserInput = "";
            string pokeRequest = "";
            string apiURL = "";
         

            //LISTS
            List<Pokemon> Requested = new List<Pokemon>();

            //USER INTERFACE
            Console.WriteLine("Welcome to the pokemon search program\nPlease enter the ID or Name of the pokemon you'd like to search");

            while (true) //Repeats screen until closed
            {
                try
                {
                    Console.Write("Enter: ");

                    UserInput = Console.ReadLine();

                    if (UserInput == null || UserInput == "") //Checks whether input is empty or null
                    {
                        continue; //Ends and asks the User again
                    }
                    else
                    {
                        pokeRequest = UserInput.ToLower(); //Userinput is validated and is now the requested pokemon
                    }

                    //GET API
                    apiURL = $"https://pokeapi.co/api/v2/pokemon/{pokeRequest}";

                    Console.WriteLine("Searching..");

                        //SEARCH VALIDATION
                    using HttpClient client = new HttpClient();

                    HttpResponseMessage response = await client.GetAsync(apiURL); //Sending GET request
                    if (!response.IsSuccessStatusCode)
                    {
                        Console.WriteLine("No pokemon found");
                    }
                    response.EnsureSuccessStatusCode(); //Ensures valid response

                        //RESULTS
                    string content = await response.Content.ReadAsStringAsync();
                    Pokemon data = JsonConvert.DeserializeObject<Pokemon>(content);

                    //DISPLAY
                    Console.WriteLine($"Results:\nName:{data.Name}\nHeight: {data.Height} decimeters\nWeight: {data.Weight} hectograms");
                }
                catch(Exception ex)
                {

                }
                



            }
        }
    }
}
