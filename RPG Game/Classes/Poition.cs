using System;
using System.Collections.Generic;
using System.Text;

namespace RPG_Game
{
   
    public class Poition
    {
        public Poition() { }
        public Poition(int i) {  Heal(i); }

        public static void Heal(int i)
        {
            Console.WriteLine($"You Have Been Healed");
            Player.playerInfo.health += i;
            Console.WriteLine($"{Player.playerInfo.health}");
        }
    }
}
