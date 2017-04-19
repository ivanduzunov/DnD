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
    public class ChooseSpecialAbility
    {
        public static void Show(Hero hero,DnDContext context)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            Console.WriteLine("Choose Special Ability!"); Console.WriteLine();
            Console.WriteLine("Press ESCAPE to go back to the Main Menu.");
            Console.WriteLine("To apply the ability press ENTER.");
            Console.WriteLine();
            
            int pointer = 1;
            var abilities = context.SpecialAbilities.ToList();
            foreach (var item in abilities)
            {
                Console.WriteLine($"Name: {item.Name}. This Ability would give you {item.Power} {item.AblityType}");
            }
            Console.WriteLine("Back to Main Menu");
            while (true)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;

                Console.Clear();
                Console.WriteLine("After each killed Dragon, You can choose one of these Special Abilities:"); Console.WriteLine();
                Console.WriteLine("Press ENTER to select the Ability.");
                Console.WriteLine();
                int current = 1;
                foreach (var item in abilities)
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
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();

                current++;
                Console.WriteLine();


                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;

                var key = Console.ReadKey();
                switch (key.Key.ToString())
                {
                    case "DownArrow":
                        if (pointer < 7)
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
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                        if (pointer == 1)
                        {
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Clear();
                            
                            var ability = context.SpecialAbilities.FirstOrDefault(c => c.Name == "Dragon Hunter Axe");
                            ApplySpecialAbility(hero, ability,context);
                            return;

                        }
                        if (pointer == 2)
                        {
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Clear();
                           
                            var ability = context.SpecialAbilities.FirstOrDefault(c => c.Name == "Heavens Shield");
                            ApplySpecialAbility(hero, ability,context);
                            return;


                        }
                        if (pointer == 3)
                        {
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Clear();
                           
                            var ability = context.SpecialAbilities.FirstOrDefault(c => c.Name == "Sword Of Balance");
                            ApplySpecialAbility(hero, ability,context);
                            return;
                        }
                        if (pointer == 4)
                        {
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Clear();
                            
                            var ability = context.SpecialAbilities.FirstOrDefault(c => c.Name == "Dragon's Tooth Sword");
                            ApplySpecialAbility(hero, ability,context);
                            return;
                        }
                        if (pointer == 5)
                        {
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Clear();
                            
                            var ability = context.SpecialAbilities.FirstOrDefault(c => c.Name == "A Bucket Helmet");
                            ApplySpecialAbility(hero, ability,context);
                            return;
                        }
                        if (pointer == 6)
                        {
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Clear();

                            var ability = context.SpecialAbilities.FirstOrDefault(c => c.Name == "The One Ring");
                            ApplySpecialAbility(hero, ability,context);
                            return;
                        }
                        if (pointer == 7)
                        {
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Clear();

                            var ability = context.SpecialAbilities.FirstOrDefault(c => c.Name == "Lightsaber");
                            ApplySpecialAbility(hero, ability,context);
                            return;
                        }
                        break;
                }
            }
        }
        public static void ApplySpecialAbility(Hero hero, SpecialAbility ability,DnDContext context)
        {
            if (ability.AblityType == SpecialAbilityType.Attack)
            {
                hero.SpecialAbilities.Add(ability);
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                hero.AttackPower += ability.Power;
                hero.SpecialAbilities.Add(ability);
               
                context.SaveChanges();
                Utility.PhaseTyper($"Your Attack power increased by {ability.Power}");
                Utility.PhaseTyper($"Total Attack Power: {hero.AttackPower}");
                Console.WriteLine();
                Utility.PhaseTyper("Press any key to continue...");
                Console.ReadKey();
            }
            else if (ability.AblityType == SpecialAbilityType.Deffence)
            {
                hero.SpecialAbilities.Add(ability);
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                hero.DeffencePower += ability.Power;
                hero.SpecialAbilities.Add(ability);
              
                context.SaveChanges();
                Utility.PhaseTyper($"Your Deffence power increased by {ability.Power}");
                Utility.PhaseTyper($"Total Defece Power: {hero.DeffencePower}");
                Console.WriteLine();
                Utility.PhaseTyper("Press any key to continue...");
                Console.ReadKey();
            }

        }
    }

    }


