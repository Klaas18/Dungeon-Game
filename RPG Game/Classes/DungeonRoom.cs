using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using RPG_Game.DungeonStuff;

namespace RPG_Game
{

    public class DungeonRoom : Utilities
    {
      

        public const int SizeX = 32;
        public const int SizeY = 32;

        
      
        public DungeonRoom()
        {
            Random r = new Random();
            bool hasTreasure = false;
            int generateChance = r.Next(1, 101);
            
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
                
            }

            void TreasureRoom()
            {
                
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
