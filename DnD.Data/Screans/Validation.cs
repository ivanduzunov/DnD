using DnD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD.Data.Screans
{
   public class Validation
    {
        public static void Show(SpecialAbility spell, Hero hero)
        {

            string seconLine = "Yes";
            string thirdLine = "No";

            List<string> list = new List<string>();
            list.Add(seconLine); list.Add(thirdLine);
            int pointer = 1;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            while (true)
            {
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine($"Are you sure you want to add {spell.Name} to your Hero");


                Console.WriteLine();
                int current = 1;
                foreach (var item in list)
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
                    Console.WriteLine(item);
                    current++;
                }


                var key = Console.ReadKey();
                switch (key.Key.ToString())
                {
                    case "DownArrow":
                        if (pointer < 2)
                        {
                            pointer++;
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        break;

                    case "UpArrow":
                        if (pointer > 1)
                        {
                            pointer--;
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        else if (pointer == 1 || pointer < 1)
                        {
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        break;

                    case "Escape":
                        SpecialAbilitiesMenu.Show(hero);
                        return;

                    case "Enter":
                        if (pointer == 1 )
                        {
                            hero.SpecialAbilities.Add(spell);
                            return;
                        }
                        if (pointer == 2)
                        {
                            SpecialAbilitiesMenu.Show(hero);
                            return;
                        }
                        break;
                }
            }
        }
    }
}
