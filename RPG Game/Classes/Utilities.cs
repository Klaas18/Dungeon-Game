using System;
using System.Collections.Generic;
using System.Text;

namespace RPG_Game
{
    public class Utilities
    {
        //private static Utilities _instance = new Utilities();

       
      //  public static Utilities Instance{  get { return _instance; }}

        public static void TypeWriter(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            for (int i = 0; i < text.Length; i++)
            {
                Console.Write(text[i]);
                System.Threading.Thread.Sleep(60);
            }
            Console.ResetColor();
            Console.Write("\n");
        }
        public static void TypeWriter(string text, ConsoleColor color, int j)
        {
            Console.ForegroundColor = color;
            for (int i = 0; i < text.Length; i++)
            {
                Console.Write(text[i]);
                System.Threading.Thread.Sleep(j);
            }
            Console.ResetColor();
            Console.Write("\n");
        }
    }
}
