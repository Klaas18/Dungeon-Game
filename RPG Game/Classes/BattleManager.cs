using System;
using System.Collections.Generic;
using System.Text;

namespace RPG_Game
{
    public class BattleManager : Utilities
    {
        static bool isBattling;

        public BattleManager(Enemy enemy, Player player)
        {
            isBattling = true;
            while(isBattling)
            {
                Battle(enemy, player);
            }
        }
        public void Battle(Enemy enemy, Player player)
        {
            Console.Clear();
        
            Frame($"Your Health: {Player.playerInfo.health}");

            Frame($"{enemy.raceE} Health: {enemy.health}");

            if (Player.playerInfo.health <= 0)
            {
                isBattling = false;
                player.OnPlayerDeath();
                return;
            }
            else
            { 
                Console.WriteLine("[A]ttack || [H]eal || [R]ob Enemy [S]kip Turn");
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.A:   // Player Attack

                        if (Player.playerInfo.klassen1 == klassen.Mage)
                        {
                            //   Console.WriteLine($"enemy Health {enemy.health}");
                            enemy.TakeDamage(player.AttackDamage());
                            // Console.WriteLine($"enemy Health {enemy.health}");
                        }
                        else
                        {
                            // Console.WriteLine($"enemy Health {enemy.health}");
                            enemy.TakeDamage(player.MageAttack());
                            // Console.WriteLine($"enemy Health {enemy.health}");
                        }
                        break;

                    case ConsoleKey.H:
                        player.Heal();
                        break;

                    case ConsoleKey.R:
                        Random random2 = new Random();
                        if (Player.playerInfo.stealth <= random2.Next(1, Player.playerInfo.stealth + 50) && !enemy.hasBeenStolenFrom)
                        {
                            int stolenMoney = enemy.moneyDrop / 2;
                            Player.playerInfo.money += stolenMoney;
                            Console.WriteLine($"You Stole ${stolenMoney}");
                            enemy.hasBeenStolenFrom = true;
                            System.Threading.Thread.Sleep(1500);
                        }
                        else { Console.WriteLine("Pickpocked Failed"); System.Threading.Thread.Sleep(1500); }

                        break;
                    case ConsoleKey.S:
                        break;
                    default:
                        Console.WriteLine("Invalid Input");
                        Battle(enemy, player);
                        return;
                }
            }
            if (enemy.health <= 0)
            {
                isBattling = false;
                player.GiveXP(enemy.xpOnDeath);
                player.GiveMoney(enemy.moneyDrop);
                Console.WriteLine("You Won Monster Has Been Defeated");          
                System.Threading.Thread.Sleep(2000);
            } else
            {
                Random random = new Random();
                switch (random.Next(1, 2))
                {
                    case 1:

                        player.TakeDamge(enemy.Attack(Player.playerInfo.defense));
                        Console.WriteLine($"The {enemy.raceE} Attacked You ");
                        System.Threading.Thread.Sleep(1250);
                        return;
                    default:
                        Console.WriteLine($"The {enemy.raceE} Did Nothing");
                        return;
                }
          

            }
       



            //if (enemy.health <= 0)
            //{
            //    isBattling = false;
            //    player.GiveXP(enemy.xpOnDeath);
            //    player.GiveMoney(enemy.moneyDrop);
            //    Console.WriteLine("You Won Monster Has Been Defeated");
            //    System.Threading.Thread.Sleep(2000);
            //}
            //else if (Player.playerInfo.health <= 0)
            //{
            //    isBattling = false;
            //    player.OnPlayerDeath();
            //}
            //else
            
            
            //if (enemy.health <= 0)
            //{
            //    isBattling = false;
            //    Console.WriteLine("You Won Monster Has Been Defeated");
            //}
        
        }
    }
}
