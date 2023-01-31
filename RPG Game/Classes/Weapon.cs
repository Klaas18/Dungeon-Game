using System;
using System.Collections.Generic;
using System.Text;

namespace RPG_Game
{
   public class Weapon
    {
        public string name;
        public  int damage = 0;
   

       public Weapon()
        {
         string[] weaponName = new string[] {"Bronze Axe"," Steel Sword","Wooden Mallet","Reaper Scythe","Rapier","Mage Staff", };
            Random rnd = new Random();
             name = weaponName[rnd.Next(0, weaponName.Length -1)];
            damage = rnd.Next(3, 10);
        }
        //public void GiveStats()
        //{
        //    Random rnd = new Random();
        //    name = weaponName[rnd.Next(0, weaponName.Length - 1)];
        //    damage = rnd.Next(3, 10);
        //}
    }
}
