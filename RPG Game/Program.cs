using System;
using RPG_Game;

namespace RPG_Game
{
    class Program : Utilities
    {
        //public Utilities utilities = Utilities.Instance;
        public static bool isPlayingGame = true;
        public static bool isInShop = false;
        static void Main(string[] args)
        {         
            Player player = new Player();
            while(isPlayingGame)
            {
                Menu();
            }

        }
        
        public static void Menu()
        {
            Console.Clear();
            StartMessage();
            Player.getInstance().ShowStats();
            Console.WriteLine("[E]nter a Dongeon Room - [Q]uit Game - [S]hop - Save [G]ame - [D]elete Save File"); //- [I]nventory
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.E:
                    new DungeonRoom();
                    break;
                case ConsoleKey.Q:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"GoodBye {Player.playerInfo.name}");
                    isPlayingGame = false;
                    break;
                case ConsoleKey.S:
                    isInShop = true;
                    while (isInShop)
                    {
                        Player.getInstance().Shop();
                    }
                    break;
                case ConsoleKey.D:
                    Player.getInstance().OnPlayerDeath();
                    break;

                case ConsoleKey.G:
                    Player.getInstance().SaveGame();
                    break;
                default:
                    Console.WriteLine("Invalid Input");
                    break;
            }
        }

        public static void StartMessage()
        {
            Console.BackgroundColor = ConsoleColor.Red;
            TypeWriter("Welcome Back To Sematary Dungeon", ConsoleColor.DarkBlue);
            Console.WriteLine("\n");
        }
    }
}
