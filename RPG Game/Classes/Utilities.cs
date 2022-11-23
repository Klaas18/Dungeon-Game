using System;
using System.Collections.Generic;
using System.Text;

namespace RPG_Game
{
    public class Utilities
    {
        private static Utilities _instance = new Utilities();

        private Utilities() { }
        public static Utilities Instance{  get { return _instance; }}

        public void TypeWriter(string text, ConsoleColor color)
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

        public void ChangeColor(ConsoleColor color)
        {
            Console.ForegroundColor = color;
        }

}
}
