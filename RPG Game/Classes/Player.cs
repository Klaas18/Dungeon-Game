using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace RPG_Game
{

    public class Player : Utilities
    {
        private static Player instance = null;
        // public Utilities utilities = Utilities.Instance;

        private Dictionary<string, int> playerStats = new Dictionary<string, int>();
        // private string filePath = @"C:\..\klaas\Desktop\School\C#\RPG Game\RPG Game\RPG Game\jsonFiles\PlayerSaveData.json";
        private string filePath = @"..\..\..\jsonFiles\PlayerSaveData.json";
        public static Player getInstance()
        {
            if (instance == null)
            {
                instance = new Player();
            }
            return instance;


        }
        public Player()
        {
           // LoadGame();
            
            if (File.Exists(filePath))
            {
                LoadGame();
            } else
            {
                Welcome();
                Race race = new Race();
                TypeWriter("", ConsoleColor.Red);

                TypeWriter("What Is Your Name Warrior?", ConsoleColor.DarkYellow);
                string playerName = Console.ReadLine();
                playerInfo.name = playerName;
                SaveGame();
               //playerInfo.gameFileExists = true;
                //playerInfo.name = Console.ReadLine();
            }
        }

        public static PlayerStats playerInfo = new PlayerStats();

        public int AttackDamage()
        {
           float damage = playerInfo.playerWeapon.damage * playerInfo.strenght / 1.5f;
            return (Int32)damage;
            
        }

        public int MageAttack()
        {
            float mageDamage = 4 * playerInfo.mageDamge / 1.5f;
            return (Int32)mageDamage;
        }
   
        public void TakeDamge(int damgeTaken)
        {
           // damgeTaken 
           playerInfo.health -= damgeTaken / playerInfo.defense; 
        }
        public void ShowStats()
        {
            Frame($"Health: {playerInfo.health} Level :{playerInfo.level} Money: {playerInfo.money} Strenght: {playerInfo.strenght} Defence: {playerInfo.defense} Potion Amount: {playerInfo.potionInventory.Count} Your Weapon: {playerInfo.playerWeapon.name}");

        }
        public void Heal()
        {
            Console.WriteLine(playerInfo.health);
            try
            {
                if (playerInfo.potionInventory != null)
                {
                    playerInfo.potionInventory.RemoveAt(playerInfo.potionInventory.Count - 1);
                    new Poition(15);
                }
                else { Console.WriteLine("No Potions Left"); }
            }
            catch { Console.WriteLine("No Potions Left"); }
            
        }
        public void GiveXP(int enemyXp)
        {
            playerInfo.currentXP += enemyXp;
          if(playerInfo.currentXP >= playerInfo.xpNeeded)
            {
                playerInfo.level += 1;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("You Leveled Up");
                Console.ResetColor();
                LevelUpStats();
                playerInfo.xpNeeded *= 5 /2;
                playerInfo.currentXP = 0;
            }
            

        }
        public void Shop()
        {
            Console.Clear();
          
                Console.WriteLine("What Do You Wan't To Do?\n[B]uy Potions - [G]o Back");
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.B:
                        if (playerInfo.money >= 60)
                        {
                            playerInfo.potionInventory.Add(new Poition());
                            playerInfo.money -= 60;
                        }
                        else { Console.WriteLine("You Dont Have Enough Money");  System.Threading.Thread.Sleep(1500); }
                        return;
                    case ConsoleKey.G:
                        Program.isInShop = false;
                        return;
                    default:
                        Console.Clear();
                        Console.WriteLine("Invalid Input");
                    System.Threading.Thread.Sleep(1500);
                    Shop();
                        return;
                }
            
        }
        public void Welcome()
        {
            TypeWriter("You Woke Up In A Underground Pet Sematary.\n You don't know how you got here or what happend to you", ConsoleColor.Cyan);
          //  Race.SetStats();
        }

        public void SaveGame()
        {
            Console.WriteLine(filePath);
            if (File.Exists(filePath))
            {
                string jsonText = JsonConvert.SerializeObject(playerInfo); //Writes the class in json format to a string
                File.WriteAllText(filePath, jsonText); // Opens the json file and writes the string with the class data to it
            }
            else
            {
                Console.WriteLine("Creating Save File...");
                using (StreamWriter writer = new StreamWriter(File.Create(filePath)))
                {
                    //File.Create(filePath);
                    //System.Threading.Thread.Sleep(50);
                    writer.Close();
                }
                    string jsonText = JsonConvert.SerializeObject(playerInfo); //Writes the class in json format to a string
                    File.WriteAllText(filePath, jsonText); // Opens the json file and writes the string with the class data to it
            }
         //   SaveGame();
        }

        public void LoadGame()
        {  
                if (File.Exists(filePath))
                {
                    playerInfo = JsonConvert.DeserializeObject<PlayerStats>(File.ReadAllText(filePath)); // Reads all the data out of json file and saves it 
                }
                else
                {
                    Console.WriteLine("No Game File To Load");
                }
        } 

        public void LevelUpStats()
        {
            Random random = new Random();

            playerInfo.speed += random.Next(2, 6);
            playerInfo.strenght += random.Next(2, 6);
            playerInfo.luck += random.Next(2, 6);
            playerInfo.defense += random.Next(2, 6);
            playerInfo.stealth += random.Next(2, 6);
            playerInfo.mageDamge += random.Next(2, 6);
          
        }
    }

    public class PlayerStats
    {

        public string name { get; set; }
        public int level { get; set; }
        public int money { get; set; }
        public int currentXP { get; set; }
        public int xpNeeded { get; set; }
        public int health { get; set; }
        public int speed { get; set; }
        public int strenght { get; set; }
        public int luck { get; set; }
        public int defense { get; set; }
        public int lockPicking { get; set; }
        public int stealth { get; set; }
        public int mageDamge { get; set; }
        public bool canUseMagic { get; set; }
        public List<Poition> potionInventory { get; set; }
        public race race1 { get; set; }
        public klassen klassen1 {get; set;}
        public  Weapon  playerWeapon { get; set; }

    }
}

