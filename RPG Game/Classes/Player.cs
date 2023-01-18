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
       // public Utilities utilities = Utilities.Instance;
        
        private Dictionary<string, int> playerStats = new Dictionary<string, int>();
        // private string filePath = @"C:\..\klaas\Desktop\School\C#\RPG Game\RPG Game\RPG Game\jsonFiles\PlayerSaveData.json";
        private string filePath = @"..\..\..\jsonFiles\PlayerSaveData.json";
        protected bool gameFileExists = false;
        public Player()
        {
            if(gameFileExists)
            {
                LoadGame();
            } else
            {
                TypeWriter("", ConsoleColor.Red);

                TypeWriter("What Is Your Name Warrior?", ConsoleColor.DarkYellow);
                string playerName = Console.ReadLine();
                playerInfo.name = playerName;
                SaveGame();
                //playerInfo.name = Console.ReadLine();
            }
        }

        public PlayerStats playerInfo = new PlayerStats();

        public void Welcome()
        {
            TypeWriter("You Woke Up In A Underground Pet Sematary.\n You don't know how you got here or what happend to you", ConsoleColor.Cyan);
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
                File.Create(filePath);
            }
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
    }
    public class PlayerStats
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


    }
}

