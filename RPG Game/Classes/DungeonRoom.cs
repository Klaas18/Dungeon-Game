using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using RPG_Game.DungeonStuff;

namespace RPG_Game
{

    public class DungeonRoom : Utilities
    { 
        //private static bool isBattling = false;

        public const int SizeX = 32;
        public const int SizeY = 32;

        Player player = Player.getInstance();
      
        public DungeonRoom()
        {
            Random r = new Random();
          //  bool hasTreasure = false;
            int generateChance = r.Next(1, 100);
           Enemy tempEnemy = new Enemy(Player.playerInfo.level);
            GenarateRoom();

            void GenarateRoom()
            {
                switch(generateChance)
                {
                    case int i when i <= 90:    // MonsterRoom
                       TypeWriter("Monster Room", ConsoleColor.Gray);

                        MonsterRoom();
                        return;
                    case int i when i <= 100:   // Treasure Room
                        TypeWriter("Treasure Room", ConsoleColor.Gray);
                        TreasureRoom();
                        return;
                   

                    default:
                        TypeWriter("Something Went Wrong With Genarating The Room", ConsoleColor.Red);
                        return;
                }
            }

            void MonsterRoom()
            {
                Console.Clear();
                //isBattling = true;
              /// while (isBattling)
               // {
               if (Player.playerInfo.klassen1 == klassen.Thief)
                {
                   Frame($"You Encounterd A {tempEnemy.raceE} {tempEnemy.klassenE} Would You Like To Try And Sneak Passed It -[Y]es or [N]o ");
                    switch (Console.ReadKey().Key)
                    {
                        case ConsoleKey.Y:
                            Random random = new Random();
                            if(random.Next(1, 100 - Player.playerInfo.stealth) <= 10)
                            {
                                Console.WriteLine($"You Got Passed The {tempEnemy.raceE} {tempEnemy.klassenE} ");
                                System.Threading.Thread.Sleep(1250);
                            }
                            else 
                            {
                                Console.WriteLine($"The {tempEnemy.raceE} {tempEnemy.klassenE} Noticed You");
                                System.Threading.Thread.Sleep(1250);
                                new BattleManager(tempEnemy, player); 
                            }
                            return;
                        case ConsoleKey.N:
                            Console.WriteLine($"The {tempEnemy.raceE} {tempEnemy.klassenE} Noticed You");
                            System.Threading.Thread.Sleep(1250);
                            new BattleManager(tempEnemy, player);
                            return;
                        default:
                            Console.WriteLine("Invalid Input");
                            System.Threading.Thread.Sleep(1250);
                            MonsterRoom();
                            return;
                    }
                     
                }
                else 
                {
                   Frame($"You Encounterd A { tempEnemy.raceE} { tempEnemy.klassenE}");
                    System.Threading.Thread.Sleep(1250);
                    new BattleManager(tempEnemy, player);
                 }

               
              //      isBattling = false;
                //}
                    
            }

            void TreasureRoom()
            {
                TreasureRoom treasureRoom = new TreasureRoom(player);
            }
        }
        public static void Draw()
        {
            for (int y = SizeY - 1; y >= 0; y--)
            {
                for (int x = 0; x < SizeX; x++)
                {
                    Console.BackgroundColor = TileTypes.Stone.BackColor;
                    Console.ForegroundColor = TileTypes.Stone.ForeColor;
                    Console.Write(TileTypes.Stone.RenderString);
                    Console.BackgroundColor = ConsoleColor.Black;
                }

                Console.Write('\n');
            }

        }
    }
}
