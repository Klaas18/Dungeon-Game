using System;
using RPG_Game;

namespace RPG_Game
{
    class Program : Utilities
    {
        //public Utilities utilities = Utilities.Instance;
        static void Main(string[] args)
        {
          
            Player player = new Player();
            Race race = new Race();
            // DungeonRoom dungeonRoom = new DungeonRoom();
            new DungeonRoom();

          
            char input = char.Parse(Console.ReadLine().ToLower());
            if (input == 's')
            {
                player.SaveGame();
            }
            if (input == 'l')
            {
                player.LoadGame();
            }
           // player.WriteData();
            
           // Console.WriteLine(player.playerInfo.level +" "+ player.playerInfo.name);
        }
        
        public void StartMessage()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            TypeWriter("Welcome Back", ConsoleColor.DarkBlue);
        }
    }
}
