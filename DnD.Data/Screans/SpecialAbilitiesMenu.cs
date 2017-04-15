using DnD.Data.SpecialAbilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DnD.Data;
using DnD.Models;

namespace DnD.Data.Screans
{
   public  class SpecialAbilitiesMenu
    {
        public static void Show(Hero hero)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            Console.WriteLine("After each killed Dragon, You can choose one between these Special Abilities:"); Console.WriteLine();
            Console.WriteLine("Press ESCAPE to go back to the Main Menu.");
            Console.WriteLine("Press ENTER to use the selected spell.");
            Console.WriteLine();
            var context = new DnDContext();
            int pointer = 1;
            foreach (var item in context.SpecialAbilities)
            {
                Console.WriteLine($"Name: {item.Name}. This Ability would give you {item.Power} {item.AblityType}");
            }
            Console.WriteLine("Back to Main Menu");
            while (true)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;

                Console.Clear();
                Console.WriteLine("After each killed Dragon, You can choose one between these Special Abilities:"); Console.WriteLine();
                Console.WriteLine("Press ESCAPE to go back to the Main Menu.");
                Console.WriteLine("Press ENTER to select the spell.");
                Console.WriteLine();
                int current = 1;
                foreach (var item in context.SpecialAbilities)
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

                    Console.WriteLine($"Name: {item.Name}. This Ability would give you {item.Power} {item.AblityType}");
                    current++;
                }
                Console.WriteLine();

                current++;
                Console.WriteLine();


                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;

                var key = Console.ReadKey();
                switch (key.Key.ToString())
                {
                    case "DownArrow":
                        if (pointer < 5)
                        {
                            pointer++;
                        }
                        break;

                    case "UpArrow":
                        if (pointer > 1)
                        {
                            pointer--;
                        }
                        break;

                    case "Enter":
                        if (pointer == 1)
                        {
                            using (DnDContext cntx = new DnDContext())
                            {
                                Validation.Show(cntx.SpecialAbilities.FirstOrDefault(c => c.Name == "Abyss"), hero);
                            }
                        }
                        if (pointer == 2)
                        {
                            using (DnDContext cntx = new DnDContext())
                            {
                                Validation.Show(cntx.SpecialAbilities.FirstOrDefault(c => c.Name == "Heavens Shield"), hero);
                            }
                        }
                        if (pointer ==5)
                        {
                            using (DnDContext cntx = new DnDContext())
                            {
                                Validation.Show(cntx.SpecialAbilities.FirstOrDefault(c => c.Name == "Heal"), hero);
                            }
                        }
                        break;
                    case "Escape":
                        MainMenu.Show(hero);
                        break;
                }
            }
        }
            
        }
    }

