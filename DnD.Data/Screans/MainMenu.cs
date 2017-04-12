using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD.Data.Screans
{
   public class MainMenu
    {
        public static void Show()
        {
            //proba
            Console.Clear();
            Console.WindowHeight = 30;
            Console.BufferHeight = 30;
            Console.WindowWidth = 60;
            Console.BufferWidth = 60;
            List<string> lines = new List<string>();
            string firstLine = "Continue";
            string secondLine = "How to play";
            string thirdLine = "SpecialAbilities";
            string fourthLine = "Exit";
            lines.Add(firstLine);lines.Add(secondLine);lines.Add(thirdLine);lines.Add(fourthLine);
            int pointer = 1;
            int pageSize = 4;
            while (true)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Clear();
                Console.WriteLine("Welcome to the main meny of the game");
                Console.WriteLine();
                int current = 1;
               foreach(var line in lines) 
                {
                    {
                        if (current == pointer)
                        {
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.ForegroundColor = ConsoleColor.Black;
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        Console.WriteLine(line);

                        current++;
                    }
                }

                var key = Console.ReadKey();

                switch (key.Key.ToString())
                {
                    case "Enter":
                        if (pointer==1)
                        {
                            Utility.Next();
                            return;
                        }
                        
                        return;

                    case "UpArrow":
                        if (pointer > 1)
                        {
                            pointer--;
                        }

                        break;
                    case "DownArrow":
                        if (pointer < pageSize)
                        {
                            pointer++;
                        }

                        break;
                    default:
                        break;
                }
            }
        }
    }
}
