using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace RPG_Game
{
    public class Enemy : Utilities
    {
        public string name;
        public int health;
        public int level;
        public bool isAlive = true;
        public race raceE;
        public klassen klassenE;
        public int xpOnDeath;
        public int moneyDrop;
        protected int strength;
        protected int defence;
        public bool hasBeenStolenFrom = false;

        private float minValue = 1;
        private float maxValue = 2;
        public Enemy(int playerLevel)
        {
            SetEnemyStats(playerLevel);
        }


     
        public int Attack(int playerDefence)
        {
            Random random = new Random();
            int attackDamge =  random.Next(1,6) +playerDefence - strength;
            return attackDamge;
        }

        public void TakeDamage(int damageTaken)
        {
            health -= damageTaken - defence /3 ;
        }

        public void SetEnemyStats(int playerLevel)
        {
            Random random = new Random();
            maxValue = playerLevel * 5f;
            minValue = playerLevel * 2f;

            klassenE = SetClass();
            raceE = SetRace();

            level = random.Next(Convert.ToInt32(playerLevel), playerLevel + 4);
            xpOnDeath = random.Next((Int32)minValue, (Int32)maxValue + 20);
            moneyDrop = random.Next((Int32)minValue, (Int32)maxValue + 15);
            health = random.Next((Int32)minValue, (Int32)maxValue) + 20;
            strength = random.Next((Int32)minValue, (Int32)maxValue);
            defence = random.Next((Int32)minValue, (Int32)maxValue) -2;

        }

        public klassen SetClass()
        {
            Random random = new Random();
            klassen tempClass = default;
            switch (random.Next(1, 4))
            {
                case 1: return tempClass = klassen.Mage;
                case 2: return tempClass = klassen.Thief;
                case 3: return tempClass = klassen.Warrior;
                    //  default: return tempClass = klassen.Unknown;
            }
            return tempClass;
        }

        public race SetRace()
        {
            Random random = new Random();
            race tempRace = default;
            switch(random.Next(1,6))
            {
                case 1: return tempRace = race.Goblin;
                case 2: return tempRace = race.Human;
                case 3: return tempRace = race.Monster;
                case 4: return tempRace = race.Ork;
                case 5: return tempRace = race.Undead;
            }
            return tempRace;
        }

}
}
