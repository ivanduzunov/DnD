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
    public class ItemsMenu
    {
        public static void Show(Hero hero)
        {
            Console.Clear();
            Console.WriteLine("Items:"); Console.WriteLine();
            Console.WriteLine("Press ESCAPE to go back to the Main Menu.");

            Console.WriteLine();
            var context = new DnDContext();
           var  abilities = hero.SpecialAbilities.ToList();

            foreach (var item in abilities)
            {
                Console.WriteLine($"Name: {item.Name}. This Ability would give you {item.Power} {item.AblityType}");
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Press any key to go back to battle mode");

            var key = Console.ReadKey();
                switch (key.Key.ToString())
                {
                   
                    case "Escape":
                        MainMenu.Show(hero);
                        break;
                }
            }
        }
            
        }
  

            

