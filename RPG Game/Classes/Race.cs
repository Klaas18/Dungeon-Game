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
        Warrior, Mage, Thief
    }
    public class Race : Utilities
    {
        public string name { get; set; }
        public int level { get; set; }
        public int health { get; set; }
        public int speed { get; set; }
        public int strenght { get; set; }
        public int luck { get; set; }
        public int defense { get; set; }
        public int lockPicking { get; set; }
        public int stealth { get; set; }
        public int mana { get; set; }

        public Dictionary<race, string> raceInfo = new Dictionary<race, string>();
        public klassen klassenEnum;
        public race raceEnum;
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


            SetRace_Class();

            SetStats();
            Console.WriteLine($"Health: ({health})\n Speed: ({speed}) \n Strength: ({strenght}) \n Luck: ({luck}) \n Defense: ({defense}) \n " +
                $"LockPicking: ({lockPicking}) \n Stealth: ({stealth}) \n Mana: ({mana})");

           
             void SetStats()
             {             

               switch(raceEnum)
                {
                    case race.Goblin:
                        health += 7;
                        speed += 8;
                        strenght += 5;
                        luck += 6;
                        defense += 4;
                        lockPicking += 8;
                        stealth += 8;
                        mana += 2;
                        break;
                    case race.Human:
                        health += 8;
                        speed += 6;
                        strenght += 7;
                        luck += 7;
                        defense += 6;
                        lockPicking += 5;
                        stealth += 5;
                        mana += 2;
                        break;
                    case race.Ork:
                        health += 8;
                        speed += 5;
                        strenght += 10;
                        luck += 4;
                        defense += 7;
                        lockPicking += 2;
                        stealth += 2;
                        mana += 2;
                        break;
                    case race.Undead:
                        health += 7;
                        speed += 7;
                        strenght += 6;
                        luck += 5;
                        defense += 6;
                        lockPicking += 5;
                        stealth += 5;
                        mana += 6;
                        break;

                }

                switch(klassenEnum)
                {
                    case klassen.Warrior:
                        health += 4;
                        speed += 1;
                        strenght += 4;
                        luck += 1;
                        defense += 3;
                        lockPicking += 0;
                        stealth += 0;
                        mana += 0;
                        break;
                    case klassen.Mage:
                        health += 1;
                        speed += 3;
                        strenght += 0;
                        luck += 3;
                        defense += 1;
                        lockPicking += 2;
                        stealth += 2;
                        mana += 10;
                        break;
                    case klassen.Thief:
                        health += 2;
                        speed += 4;
                        strenght += 1;
                        luck += 3;
                        defense += 0;
                        lockPicking += 9;
                        stealth += 7;
                        mana += 2;
                        break;

                }
             }

            void SetRace_Class()
            {
                Console.Clear();
                //TypeWriter("Would you like to see some info about the races \n (Y)es or (N)o", ConsoleColor.Cyan);
                //switch(Console.ReadKey().Key)
                //{
                //    case 
                //}

               foreach(KeyValuePair<race,string> r in raceInfo)
                {
                    Console.WriteLine($"{r.Key}: \n {r.Value}\n");
                }
                TypeWriter("Please Select Your Race \nGoblin(1) | Human(2) | Ork(3) | Undead(4)",ConsoleColor.Cyan);
                switch(Console.ReadKey().Key)
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
                    default: TypeWriter("Please Enter A Valid Option",ConsoleColor.Red);
                        SetRace_Class();
                        break;
                }
                Console.Clear();

                TypeWriter("Please Select Your Class \nMage(1) | Thief(2) | Warrior(3)", ConsoleColor.Cyan);
                switch(Console.ReadKey().Key)
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

}
