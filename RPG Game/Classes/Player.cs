using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace RPG_Game
{

    public class Player
    {
        public Utilities utilities = Utilities.Instance;
        
        private string filePath = @"C:\Users\klaas\Desktop\School\C#\RPG Game\RPG Game\RPG Game\jsonFiles\PlayerSaveData.json";
        protected bool gameFileExists = true;
        public Player()
        {
            if(gameFileExists)
            {
                LoadGame();
            } else
            {
                SaveGame();
                utilities.TypeWriter("What Is Your Name Warrior?", ConsoleColor.DarkYellow);
                playerInfo.name = Console.ReadLine();
            }
        }

        public PlayerInfo playerInfo = new PlayerInfo();

        public void SaveGame()
        {
            if (File.Exists(filePath))
            {
                string jsonText = JsonConvert.SerializeObject(playerInfo); //Writes the class in json format to a string
                File.WriteAllText(filePath, jsonText); // Opens the json file and writes the string with the class data to it
            } else
            {
                Console.WriteLine("Creating Save File...");
                File.Create(filePath);
            }
        }

        public void LoadGame()
        {  
                if (File.Exists(filePath))
                {
                    playerInfo = JsonConvert.DeserializeObject<PlayerInfo>(File.ReadAllText(filePath)); // Reads all the data out of json file and saves it 
                }
                else
                {
                    Console.WriteLine("No Game File To Load");
                }
        } 
    }
    public class PlayerInfo
    {
        public string name { get; set; }
        public int level { get; set; }
        public int luck { get; set; }
        public int strenght { get; set; }
    }
}

