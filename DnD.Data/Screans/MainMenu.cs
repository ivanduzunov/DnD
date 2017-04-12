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
            lines.Add(firstLine); lines.Add(secondLine); lines.Add(thirdLine); lines.Add(fourthLine);
            int pointer = 1;
            int pageSize = 4;
            while (true)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Clear();
                Console.WriteLine("Welcome to the main menu of the game");
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
                            Utility.Next();
                            return;
                        }
                        else if (pointer == 2)
                        {
                            HowToPlayMenu();
                            return;
                        }
                        else if (pointer == 3)
                        {
                            SpecialAbilitiesMenu();
                            return;
                        }
                        else if (pointer == 4)
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
        public static void SpecialAbilitiesMenu()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            Utility.PhaseTyper("After each killed Dragon, You can choose one between these Special Abilities:"); Console.WriteLine();

            var context = new DnDContext();

            foreach (var item in context.SpecialAbilities)
            {
                Utility.PhaseTyper($"Name: {item.Name}. This Ability would give you {item.Power} {item.AblityType}");
            }
            Console.WriteLine();


            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("Back to Main Menu");
            var key = Console.ReadKey();
            switch (key.Key.ToString())
            {
                case "Enter":
                    Show(); break;                 
            }
           
        }
        public static void HowToPlayMenu()
        {
            Console.Clear();
            Console.WriteLine("How to play"); Console.WriteLine();
            Utility.PhaseTyper("Something Here...");
            Console.WriteLine();

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("Back to Main Menu");
            var key = Console.ReadKey();
            switch (key.Key.ToString())
            {
                case "Enter":
                    Show(); break;
            }
        }
    }
}
