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
        public static void Show(Hero hero)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            Console.WriteLine("Choose Special Ability!"); Console.WriteLine();
            Console.WriteLine("Press ESCAPE to go back to the Main Menu.");
            Console.WriteLine("To apply the ability press ENTER.");
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
                Console.WriteLine("After each killed Dragon, You can choose one of these Special Abilities:"); Console.WriteLine();
                Console.WriteLine("Press ENTER to select the Ability.");
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
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                        if (pointer == 1)
                        {
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Clear();
                            
                            var ability = context.SpecialAbilities.FirstOrDefault(c => c.Name == "Abyss");
                            ApplySpecialAbility(hero, ability);
                            return;

                        }
                        if (pointer == 2)
                        {
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Clear();
                           
                            var ability = context.SpecialAbilities.FirstOrDefault(c => c.Name == "Heavens Shield");
                            ApplySpecialAbility(hero, ability);
                            return;


                        }
                        if (pointer == 3)
                        {
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Clear();
                           
                            var ability = context.SpecialAbilities.FirstOrDefault(c => c.Name == "Fireball");
                            ApplySpecialAbility(hero, ability);
                            return;
                        }
                        if (pointer == 4)
                        {
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Clear();
                            
                            var ability = context.SpecialAbilities.FirstOrDefault(c => c.Name == "Frostball");
                            ApplySpecialAbility(hero, ability);
                            return;
                        }
                        if (pointer == 5)
                        {
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Clear();
                            
                            var ability = context.SpecialAbilities.FirstOrDefault(c => c.Name == "Heal");
                            ApplySpecialAbility(hero, ability);
                            return;
                        }
                        break;
                }
            }
        }
        public static void ApplySpecialAbility(Hero hero, SpecialAbility ability)
        {
            if (ability.AblityType == SpecialAbilityType.Attack)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                hero.AttackPower += ability.Power;
                Utility.PhaseTyper($"Your Attack power increased by {ability.Power}");
                Utility.PhaseTyper($"Total Attack Power: {hero.AttackPower}");
                Console.WriteLine();
                Utility.PhaseTyper("Press any key to continue...");
                Console.ReadKey();
            }
            else if (ability.AblityType == SpecialAbilityType.Deffence)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                hero.DeffencePower += ability.Power;
                Utility.PhaseTyper($"Your Deffence power increased by {ability.Power}");
                Utility.PhaseTyper($"Total Attack Power: {hero.DeffencePower}");
                Console.WriteLine();
                Utility.PhaseTyper("Press any key to continue...");
                Console.ReadKey();
            }

        }
    }

    }


