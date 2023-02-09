using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;


namespace RPG_Game
{
    public class DungeonRoom : Utilities
    { 
        Player player = Player.getInstance();
      
        public DungeonRoom()
        {
            Random r = new Random();   
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
            }

            void TreasureRoom()
            {
               new TreasureRoom(player);
            }
        }
      
    }
}
