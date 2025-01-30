using System.Runtime.Intrinsics.X86;
using System;
using System.Collections.Generic;

namespace PlayerHighScores
{
    internal class Program
    {

        public class Player
        {
            private string _initials;
            private int _score;

            public Player(string initials, int score) //CALL THIS ANYWHERE. It uses them
            {
                _initials = initials;
                _score = score;
            }
            public string Initials { get { return _initials; } set { _initials = value; } } //USE THIS TO USE THEM ANYWHERE
            public int Score { get { return _score; } set { _score = value; } }
        }

        static void Main(string[] args)
        {
            
            //Create player list
            List<Player> listPlayers = new List<Player>();

            //MENU
            do
            {
                Console.WriteLine("YOU DIDN'T WIN ANYTHING! ENTER YOUR CREDENTIALS ANYWAYSS!!");
                Console.WriteLine("1. To write your score.\n2. To view the scores\n3. leave");
                Console.WriteLine();

                switch(Convert.ToInt32(Console.ReadLine()))
                {
                    case 1:
                        Console.Write("Enter your Initials: ");
                        string Initials = Console.ReadLine();

                        Console.Write("Enter your Score: ");
                        int Score = Convert.ToInt32(Console.ReadLine());

                        //by adding this operator their initials default to IDK when they are null lol
                        listPlayers.Add(new Player(Initials ??= "IDK", Score));

                        break;
                    case 2:
                        foreach(Player _player in listPlayers)
                        {
                            Console.WriteLine($"{_player.Initials} SCORE {_player.Score}");
                        }
                        break;

                    //Case 3? leave? nah lol

                    default:
                        Console.WriteLine("THATS NOT A CHOICE.");
                        break;
                } 
            }
            while (true);
        }
    }
}
