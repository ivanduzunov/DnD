using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DnD.Models;


namespace DnD.Data.Screans
{
    public class MainMenu
    {
        public static void Show()
        {

            Console.Clear();
            Console.WindowHeight = 50;
            Console.BufferHeight = 50;
            Console.WindowWidth = 160;
            Console.BufferWidth = 160;
            List<string> lines = new List<string>();
            string firstLine = "Continue";
            string secondLine = "How to play";
            string thirdLine = "SpecialAbilities";
            string fourthLine = "Exit";
            lines.Add(firstLine); lines.Add(secondLine); lines.Add(thirdLine); lines.Add(fourthLine);
            int pointer = 1;
            int pageSize = 4;
            while (true)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Clear();
                Console.WriteLine("Welcome to the Main menu of the game");
                
                Console.WriteLine();
                int current = 1;
                foreach (var line in lines)
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
                        if (pointer == 1)
                        {
                            return;             
                        }
                        if (pointer == 2)
                        {
                            HowToPlayMenu();
                            return;
                        }
                        if (pointer == 3)
                        {
                            SpecialAbilitiesMenu.Show();
                            return;
                        }
                        if (pointer == 4)
                        {       
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Clear();                           
                            Console.WriteLine("Thank you for playing Dragons and Dungeons! Press any key to Exit the Game");
                            Console.ReadKey();
                            Console.Clear();
                            Environment.Exit(0);
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
        
        public static void HowToPlayMenu()
        {
            Console.Clear();
            Console.WriteLine("How to play"); Console.WriteLine();
            Utility.PhaseTyper("Something Here...");
            Console.WriteLine();
            Console.WriteLine("Press any key to back to Main Menu.");
            Console.ReadKey();
            MainMenu.Show();
        }
    }
}
