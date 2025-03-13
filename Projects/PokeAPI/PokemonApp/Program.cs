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
            while (true) //Repeats screen until closed
            {
                Console.WriteLine("Welcome to the pokemon search program\nPlease enter the ID or Name of the pokemon you'd like to search\nEnter 'History' if you'd like to view your past searches");
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
                        switch (UserInput)
                        {
                            case "History": //Search history selection
                                if (Requested.Count() > 0) //Checks whether user has previously searched
                                {
                                    for (int i_ = 0; i_ < Requested.Count; i_++)
                                    {
                                        Console.WriteLine($"{i_}:\nName:{Requested[i_].Name}");
                                    }

                                    UserInput = Console.ReadLine();

                                    if (Int32.TryParse(UserInput, out int i)) //Tries and Displays the selection for the History
                                    {
                                        Console.WriteLine($"Results:\nName:{Requested[i].Name}\nHeight: {Requested[i].Height} decimeters\nWeight: {Requested[i].Weight} hectograms");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Selection must be within range");
                                    }
                                    Console.ReadLine(); //Holds screen until a key is pressed
                                    continue;
                                }
                                else
                                {
                                    Console.WriteLine("You have no search history");
                                    Console.ReadLine();
                                    continue; //Refreshes screen
                                }
                                break;

                            default: //Pokemon selection
                                pokeRequest = UserInput.ToLower(); //Userinput is validated and is now the requested pokemon
                                break;
                        }
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

                    Requested.Add(data); //Hold the pokemon data in cache

                    //DISPLAY
                    Console.WriteLine($"Results:\nName:{data.Name}\nHeight: {data.Height} decimeters\nWeight: {data.Weight} hectograms");

                    data = null; //Clears data cache
                    Console.ReadLine();
                    Console.Clear(); //Clear screen
                }
                catch(Exception ex)
                {

                }
                



            }
        }
    }
}
