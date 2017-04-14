using DnD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD.Data.Screans
{
   public  class HeroSelection
    {
        public static void Show(DnDContext context)
        {
            Console.WindowHeight = 50;
            Console.BufferHeight = 50;
            Console.WindowWidth = 160;
            Console.BufferWidth = 160;
            Console.Clear();
            Utility.PhaseTyper("First you need to choose your hero!");
            foreach (Hero hero in context.Heroes)
            {
                Utility.PhaseTyper($"NAME: {hero.Name}, Description: {hero.Description}");
            }

            var heroes = context.Heroes.ToList();
            int pageSize = heroes.Count();
            
            int pointer = 1;

            while (true)
            {

                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;

                Console.Clear();
                Console.WriteLine("First you need to choose your hero!");

                int current = 1;
                foreach (var hero in context.Heroes)
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

                    Console.WriteLine($"NAME: {hero.Name}, Description: {hero.Description}");
                    current++;
                }
                var key = Console.ReadKey();

                switch (key.Key.ToString())
                {

                    case "Enter":
                        var currentHero = heroes.Skip(pointer - 1).First();                     
                        Utility.FirstRoom(currentHero, context);
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
