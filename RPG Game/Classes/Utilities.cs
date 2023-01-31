using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace RPG_Game
{
    public class Utilities
    {
        //private static Utilities _instance = new Utilities();


        //  public static Utilities Instance{  get { return _instance; }}
        public static void Frame(string input)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            for (int i = 0; i < input.Length +2; i++)
            {
                Console.Write("*");
            }
            Console.WriteLine();
            Console.WriteLine("*" + input + "*");
            for (int i = 0; i < input.Length + 2; i++)
            {
                Console.Write("*");
            }
            Console.WriteLine();
            Console.ResetColor();
        }

        public static void StringFramed(string x)
        {
            string[] a = x.Split(' ');
            string b = a.OrderByDescending(s => s.Length).First();
            string n = "";
            Console.BackgroundColor = ConsoleColor.Red;
            for (int i = 0; i < b.Count() + 2; i++)
            {
                n += "*";
            }
            Console.WriteLine(n);
            foreach (string s in a)
            {
                string space = "";
                if (s.Count() < b.Count())
                {

                    for (int i = 0; i < b.Count() - s.Count(); i++)
                    {
                        space += " ";
                    }
                }
                Console.WriteLine("*" + s + space + "*");
            }
            Console.WriteLine(n);
            Console.ResetColor();
        }
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
