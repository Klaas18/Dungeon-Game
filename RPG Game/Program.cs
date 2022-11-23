using System;


namespace RPG_Game
{
    class Program
    {
        public Utilities utilities = Utilities.Instance;
        static void Main(string[] args)
        {
            Player player = new Player();
           
           if(player.playerInfo.name != null)
            { 
          
            }
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
            
            Console.WriteLine(player.playerInfo.level +" "+ player.playerInfo.name);
        }
        
        public void StartMessage()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            utilities.TypeWriter("Welcome Back", ConsoleColor.DarkBlue);
        }
    }
}
