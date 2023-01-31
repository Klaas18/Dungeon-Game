using System;
using System.Collections.Generic;
using System.Text;

namespace RPG_Game
{
   public class TreasureRoom : Utilities
    {
        public static bool inRoom = true;
        public TreasureRoom(Player player)
        {
            inRoom = true;
            Console.Clear();
            Frame("You Found A Treasure Room With A Chest!");
            while (inRoom)
            {
                InRoom();
            }
           // Console.ReadLine();
        }

        public void InRoom()
        {
            Console.WriteLine("[O]pen Chest - [L]eave Room");
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.O:
                    OpenChest();
                    inRoom = false;
                    return;
                case ConsoleKey.L:
                    inRoom = false;
                    return;
                default:
                    Console.WriteLine("Invalid Input");
                    System.Threading.Thread.Sleep(1250);
                    InRoom();
                    return;
            }
        }
       public void OpenChest()
        {
            Console.Clear();
            Random random = new Random();
            Console.WriteLine("You're Lock Picking The Chest...");
            System.Threading.Thread.Sleep(1250);
            switch (random.Next(1,125 - Player.playerInfo.lockPicking))
            {
                case int i when i <= 30:
                    int MoneyFound = random.Next(30, 200 + Player.playerInfo.luck);
                     Player.playerInfo.money += MoneyFound;
                     Console.WriteLine($"You Opened The Chest And Found ${MoneyFound}");
                    break;
                   
                default:
                    Console.WriteLine("Lock Broke The Chest has Become Useless");
                    System.Threading.Thread.Sleep(1250);
                    break;
            }
           // Player.playerInfo.luck 

        }
    }

}
