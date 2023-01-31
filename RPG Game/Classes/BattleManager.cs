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
                //if (enemy.health <= 0)
                //{
                //    isBattling = false;
                //}

                //char input = char.Parse(Console.ReadLine().ToLower());
                //switch (input)
                //{
                //    case 'a':   // Player Attack
                //        Console.WriteLine($"enemy Health {enemy.health}");
                //       enemy.TakeDamage(player.AttackDamage());
                //        Console.WriteLine($"enemy Health {enemy.health}");
                //        break;
                //    default: Console.WriteLine("Invalid Input");
                //        return;
                //}

            }
        }
        public void Battle(Enemy enemy, Player player)
        {
            Console.Clear();
           // Console.ForegroundColor = ConsoleColor.Yellow;
            Frame($"Your Health: {Player.playerInfo.health}");
          //  Console.ResetColor();

           // Console.ForegroundColor = ConsoleColor.Yellow;
            Frame($"{enemy.raceE} Health: {enemy.health}");
           // Console.ResetColor();

            if (enemy.health <= 0)
            {
                isBattling = false;
                player.GiveXP(enemy.xpOnDeath);
                Console.WriteLine("You Won Monster Has Been Defeated");          
                System.Threading.Thread.Sleep(2000);
            }

            Console.WriteLine("[A]ttack || [H]eal || [S]kip Turn");
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
                case ConsoleKey.S:
                    break;
                default:
                    Console.WriteLine("Invalid Input");
                    Battle(enemy, player);
                    return;
            }

            if (enemy.health <= 0)
            {
                isBattling = false;
                player.GiveXP(enemy.xpOnDeath);
                Console.WriteLine("You Won Monster Has Been Defeated");
                System.Threading.Thread.Sleep(2000);
            }

            Random random = new Random();
            switch (random.Next(1,3))
            {
                case 1:
                         
                    player.TakeDamge(enemy.Attack(Player.playerInfo.defense));
                    Console.WriteLine($"The {enemy.raceE} Attacked You ");
                    return;

                case 2:
                       
                    return;
                default:
                    Console.WriteLine($"The {enemy.raceE} Did Nothing");
                    return;
            }
            //if (enemy.health <= 0)
            //{
            //    isBattling = false;
            //    Console.WriteLine("You Won Monster Has Been Defeated");
            //}
        
        }
    }
}
