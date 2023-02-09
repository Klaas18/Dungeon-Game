using System;
using System.Collections.Generic;
using System.Text;

namespace RPG_Game
{
    public enum race
    { 
       Human, Ork, Goblin, Undead, Monster
    }
    public enum klassen 
    { 
        Warrior, Mage, Thief, Unknown
    }
    public class Race : Utilities
    {
        public static Dictionary<race, string> raceInfo = new Dictionary<race, string>();
        public static Dictionary<klassen, string> klassenInfo = new Dictionary<klassen, string>();
        public static klassen klassenEnum;
        public static race raceEnum;
        public static Weapon weapon = new Weapon();
        public Race()
        {
            raceInfo.Add(race.Human, "Humans have average physical attributes, but make up for it with their strong intellect and resourcefulness. \n " +
                "They possess a diverse set of skills and abilities, allowing them to excel in any profession, including warrior, wizard, priest, or any other class. \n " +
                "They are also known for their ambition and determination, making them a force to be reckoned with in battles and quests.");

            raceInfo.Add(race.Goblin, "They are known for their stealth and thievery skills, They possess quick reflexes and agility, making them great at dodging and evading attacks.");

            raceInfo.Add(race.Ork, "Orks are a fierce and brutish race. \n" +
                "They are known for their physical strength and toughness, making them formidable melee fighters. \n" +
                "They possess high hit points and melee attack damage, and have strong resistance to physical damage.\n" +
                " They are often portrayed as barbaric and savage, with little regard for strategy or tactics.");

            raceInfo.Add(race.Undead, "Undead are often portrayed as powerful and relentless, with abilities that reflect their status as the risen dead. \n" +
                " They may have special abilities like resistance or immunity to certain types of damage and status effects, and may also be able to drain life from their enemies.");
            raceInfo.Add(race.Monster, "Unlisted");

            klassenInfo.Add(klassen.Mage, "A Mage Will Use There Magical To Attack Monsters and Health Potions give you more health");
            klassenInfo.Add(klassen.Thief, "A Thief Has The Ability To Try And Sneak Past Enemy's And Has A Higher Chance To Lockpick A Chest");
            klassenInfo.Add(klassen.Warrior, "Warriors Have A Higher Bas Defence And Attack Then The Other Classes But Can't Do Any Of The Things Other Classes Can Do");

            SetRace_Class();

            SetStats();
            Console.WriteLine($"Health: ({Player.playerInfo.health})\n Speed: ({Player.playerInfo.speed}) \n Strength: ({Player.playerInfo.strenght}) \n Luck: ({Player.playerInfo.luck}) \n Defense: ({Player.playerInfo.defense}) \n " +
                $"LockPicking: ({Player.playerInfo.lockPicking}) \n Stealth: ({Player.playerInfo.stealth}) \n Mana: ({Player.playerInfo.mageDamge})");

        }
       public static void SetStats()
        {
            Player.playerInfo.level = 1;
            Player.playerInfo.race1 = raceEnum;
            Player.playerInfo.klassen1 = klassenEnum;
            Player.playerInfo.playerWeapon = new Weapon();
            Player.playerInfo.weaponInventory = new List<Weapon>();
            Player.playerInfo.weaponInventory.Add(new Weapon());
            Player.playerInfo.weaponInventory.Add(new Weapon());
            Player.playerInfo.weaponInventory.Add(new Weapon());
            Player.playerInfo.potionInventory = new List<Poition>();
            Player.playerInfo.xpNeeded += 25;
            for (int i = 0; i < 4; i++)
            {
            Player.playerInfo.potionInventory.Add( new Poition());
            }
            switch (raceEnum)
            {
                case race.Goblin:
                    Player.playerInfo.health += 7;
                    Player.playerInfo.speed += 8;
                    Player.playerInfo.strenght += 5;
                    Player.playerInfo.luck += 6;
                    Player.playerInfo.defense += 4;
                    Player.playerInfo.lockPicking += 8;
                    Player.playerInfo.stealth += 8;
                    Player.playerInfo.mageDamge += 2;
                  //  Player.playerInfo.playerWeapon.name = Race.weapon.weaponName[0];
                  //  Player.playerInfo.playerWeapon.GiveStats();
                    break;
                case race.Human:
                    Player.playerInfo.health += 8;
                    Player.playerInfo.speed += 6;
                    Player.playerInfo.strenght += 7;
                    Player.playerInfo.luck += 7;
                    Player.playerInfo.defense += 6;
                    Player.playerInfo.lockPicking += 5;
                    Player.playerInfo.stealth += 5;
                    Player.playerInfo.mageDamge += 2;
                  //  Player.playerInfo.playerWeapon.name = Race.weapon.weaponName[1];
                   // Player.playerInfo.playerWeapon.GiveStats();
                    break;
                case race.Ork:
                    Player.playerInfo.health += 8;
                    Player.playerInfo.speed += 5;
                    Player.playerInfo.strenght += 10;
                    Player.playerInfo.luck += 4;
                    Player.playerInfo.defense += 7;
                    Player.playerInfo.lockPicking += 2;
                    Player.playerInfo.stealth += 2;
                    Player.playerInfo.mageDamge += 2;
                  //  Weapon weapon = new Weapon();
                //    Player.playerInfo.playerWeapon.name = Race.weapon.weaponName[2];
                 //   Player.playerInfo.playerWeapon.GiveStats();
                    break;
                case race.Undead:
                    Player.playerInfo.health += 7;
                    Player.playerInfo.speed += 7;
                    Player.playerInfo.strenght += 6;
                    Player.playerInfo.luck += 5;
                    Player.playerInfo.defense += 6;
                    Player.playerInfo.lockPicking += 5;
                    Player.playerInfo.stealth += 5;
                    Player.playerInfo.mageDamge += 6;
                   // Player.playerInfo.playerWeapon.name = Race.weapon.weaponName[3];
                   // Player.playerInfo.playerWeapon.GiveStats();
                    break;

            }

            switch (klassenEnum)
            {
                case klassen.Warrior:
                    Player.playerInfo.health += 4;
                    Player.playerInfo.speed += 1;
                    Player.playerInfo.strenght += 4;
                    Player.playerInfo.luck += 1;
                    Player.playerInfo.defense += 3;
                    Player.playerInfo.lockPicking += 0;
                    Player.playerInfo.stealth += 0;
                    Player.playerInfo.mageDamge += 0;
                    Player.playerInfo.canUseMagic = false;
                    break;
                case klassen.Mage:
                    Player.playerInfo.health += 1;
                    Player.playerInfo.speed += 3;
                    Player.playerInfo.strenght += 0;
                    Player.playerInfo.luck += 3;
                    Player.playerInfo.defense += 1;
                    Player.playerInfo.lockPicking += 2;
                    Player.playerInfo.stealth += 2;
                    Player.playerInfo.mageDamge += 10;
                    Player.playerInfo.canUseMagic = true;
                    break;
                case klassen.Thief:
                    Player.playerInfo.health += 2;
                    Player.playerInfo.speed += 4;
                    Player.playerInfo.strenght += 1;
                    Player.playerInfo.luck += 3;
                    Player.playerInfo.defense += 0;
                    Player.playerInfo.lockPicking += 9;
                    Player.playerInfo.stealth += 7;
                    Player.playerInfo.mageDamge += 2;
                    Player.playerInfo.canUseMagic = false;
                    break;

            }
            
          
        }
        public static void SetRace_Class()
        {
            Console.Clear();
            //TypeWriter("Would you like to see some info about the races \n (Y)es or (N)o", ConsoleColor.Cyan);
            //switch(Console.ReadKey().Key)
            //{
            //    case 
            //}

            foreach (KeyValuePair<race, string> r in raceInfo)
            {
                Console.WriteLine($"{r.Key}: \n {r.Value}\n");
            }
            TypeWriter("Please Select Your Race \nGoblin(1) | Human(2) | Ork(3) | Undead(4)", ConsoleColor.Cyan);
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.D1:
                    raceEnum = race.Goblin;
                    break;
                case ConsoleKey.D2:
                    raceEnum = race.Human;
                    break;
                case ConsoleKey.D3:
                    raceEnum = race.Ork;
                    break;
                case ConsoleKey.D4:
                    raceEnum = race.Undead;
                    break;
                default:
                    TypeWriter("Please Enter A Valid Option", ConsoleColor.Red);
                    SetRace_Class();
                    break;
            }
            Console.Clear();

            
            foreach(KeyValuePair<klassen,string> r in klassenInfo)
            {
                Console.WriteLine($"{r.Key}: \n {r.Value}\n");
            }
            TypeWriter("Please Select Your Class \nMage(1) | Thief(2) | Warrior(3)", ConsoleColor.Cyan);
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.D1:
                    klassenEnum = klassen.Mage;
                    break;
                case ConsoleKey.D2:
                    klassenEnum = klassen.Thief;
                    break;
                case ConsoleKey.D3:
                    klassenEnum = klassen.Warrior;
                    break;
                default:
                    TypeWriter("Please Enter A Valid Option", ConsoleColor.Red);
                   
                    SetRace_Class();
                    break;
            }
            Console.Clear();
        }

    }

}
