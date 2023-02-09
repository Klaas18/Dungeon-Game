using System;
using System.Collections.Generic;
using System.Text;

namespace RPG_Game
{
   public class Weapon
    {
        public string name;
        public  int damage = 0;
        string[] weaponName = new string[] {"Bronze Axe"," Steel Sword","Wooden Mallet","Reaper Scythe","Rapier","Mage Staff","Jungle Sword","Jungle Mage Staff" };
       public bool isMageWeapon;

       public Weapon()
        {
            Random rnd = new Random();
             name = weaponName[rnd.Next(0, 5)];
            damage = rnd.Next(3, 10);
            if(name.Contains("Mage"))
            {
                isMageWeapon = true;
            } else { isMageWeapon = false; }
        }
        //public void GiveStats()
        //{
        //    Random rnd = new Random();
        //    name = weaponName[rnd.Next(0, weaponName.Length - 1)];
        //    damage = rnd.Next(3, 10);
        //}
    }
}
