using DnD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
namespace DnD.Data
{
    public static class Utility
    {
        public static void StartGame()
        {
            PhaseTyper("WELCOME TO DRAGONS WORLD!");
            PhaseTyper("To Built the fantasy world type START here: ");
            string start = Console.ReadLine().ToLower();
            var cnxt = new DnDContext();

            if (start.Equals("start") && cnxt.Heroes.Count().Equals(0))
            {
                cnxt.Database.Initialize(true);

                var heroesList = new List<Hero>()
            {
                new Hero { Name = "Even", Description = "Human", AttackPower = 30, DeffencePower = 30, Health = 100 },
                new Hero { Name = "Analdbar", Description = "Dwalf", AttackPower = 20, DeffencePower = 40, Health = 90 },
                new Hero { Name = "Enfangriel", Description = "Elf", AttackPower = 20, DeffencePower = 40, Health = 90 },
                new Hero { Name = "Theonanthok", Description = "Berbarian", AttackPower = 35, DeffencePower = 25, Health = 110 },
                new Hero { Name = "Nealetha", Description = "Wizzard", AttackPower = 35, DeffencePower = 25, Health = 110 }
            };
                cnxt.Heroes.AddRange(heroesList);
                cnxt.SaveChanges();

                var dragonsList = new List<Dragon>()
           {
                new Dragon { Name = "Grombuztan", Description = "Big red Dragon", AttackPower = 50, DeffencePower = 10, Health = 100, Level = 1 },
                new Dragon { Name = "Gruntselga", Description = "Black Dragon", AttackPower = 50, DeffencePower = 10, Health = 100, Level = 1 },
                new Dragon { Name = "Murzgarbuckbuck", Description = "Dragon Queen", AttackPower = 70, DeffencePower = 20, Health = 120, Level = 2 },
                new Dragon { Name = "Gulbolg-rogg", Description = "Dragon King", AttackPower = 80, DeffencePower = 30, Health = 130, Level = 2 }
           };
                cnxt.Dragons.AddRange(dragonsList);
                cnxt.SaveChanges();

                var specialAbilitiesList = new List<SpecialAbility>()
            {
                new SpecialAbility {Name = "Abyss", Description="Increase the attack power", AblityType = SpecialAbilityType.Attack, Power = 20 },
                new SpecialAbility {Name = "Heavens Shield", Description="Increase the defence power", AblityType = SpecialAbilityType.Deffence, Power = 30 }
            };
                cnxt.SpecialAbilities.AddRange(specialAbilitiesList);
                cnxt.SaveChanges();

                PhaseTyper("Ready!");
            }
            else
            {
                PhaseTyper("Ready!");
            }

            //PhaseTyper("Choose your hero!");
            //foreach (Hero hero in cnxt.Heroes)
            //{
            //    PhaseTyper($"NAME: {hero.Name}, Description: {hero.Description}");
            //}
        }
        public static void PhaseTyper(string text)
        {

            foreach (char c in text)
            {
                Console.Write(c);
                Thread.Sleep(50);
            }
            Console.WriteLine();
        }

        public static void ChooseHero(DnDContext context)
        {
            Console.WindowHeight = 17;
            Console.BufferHeight = 17;
            Console.WindowWidth = 50;
            Console.BufferWidth = 50;
            Console.Clear();
            PhaseTyper("Choose your hero!");
            foreach (Hero hero in context.Heroes)
            {
                PhaseTyper($"NAME: {hero.Name}, Description: {hero.Description}");
            }

            var heroes = context.Heroes.ToList();
            int pageSize = heroes.Count();
            int pointer =1;
            
            while (true)
            {
                
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;

                Console.Clear();
                Console.WriteLine("Choose your hero!");
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
                        Console.Clear();
                        var currentHero = heroes.Skip(pointer - 1).First();
                        Console.WriteLine($"Hero {currentHero.Name} chosen" );
                       
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
