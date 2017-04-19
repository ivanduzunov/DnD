using DnD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Data;
using DnD.Data.Screans;

namespace DnD.Data
{
    public static class Utility
    {
        public static void StartGame()
        {
            PhaseTyper("WELCOME TO DRAGONS AND DUNGEONS");
            PhaseTyper("To Built the fantasy world type START here: ");
            string start = Console.ReadLine().ToLower();
            var cnxt = new DnDContext();

            if (start.Equals("start") && cnxt.Heroes.Count().Equals(0))
            {
               
                cnxt.Database.Initialize(true);

                var heroesList = new List<Hero>()
            {
                new Hero { Name = "Even", Description = "Human", AttackPower = 150, DeffencePower = 30, Health = 100 },
                new Hero { Name = "Grorsis", Description = "Dwarf", AttackPower = 20, DeffencePower = 40, Health = 90 },
                new Hero { Name = "Enfangriel", Description = "Elf", AttackPower = 20, DeffencePower = 40, Health = 90 },
                new Hero { Name = "Theonanthok", Description = "Berbarian", AttackPower = 35, DeffencePower = 25, Health = 110 },
                new Hero { Name = "Nealetha", Description = "Wizzard", AttackPower = 35, DeffencePower = 25, Health = 110 },
                new Hero { Name = "Redania", Description = "Amazon", AttackPower = 40, DeffencePower = 25, Health = 110 },
                new Hero { Name = "Rori", Description = "Archer", AttackPower = 50, DeffencePower = 25, Health = 80 },
            };
                cnxt.Heroes.AddRange(heroesList);
                cnxt.SaveChanges();

                var roomsList = new List<Room>()
            {
                new Room { Description = "---{{{  You have entered the first room in the dungeon. In  it, you will find your first challenge.  }}}---"},
                new Room { Description = "---{{{  As you advance trough the dungeon the enemies get stronger. Prepare yourself the next dragon awaits!   }}}---" },
                new Room { Description = "---{{{  You are infront of Dark Kingdoms Gates! Get ready because you will face the strongest Dragons! }}}---" },
                new Room { Description = "---{{{  Your final challenge is here! You got to kill the Dark Dragon Lord - The Destroyer of Life !   }}}---" }

            };
                cnxt.Rooms.AddRange(roomsList);
                cnxt.SaveChanges();


                var dragonsList = new List<Dragon>()
           {
                new Dragon { Name = "Grombuztan", Description = "Protector Of The Sky", AttackPower = 50, DeffencePower = 10, Health = 100, RoomId = 1 },
                new Dragon { Name = "Gruntselga", Description = "The Mysterious", AttackPower = 50, DeffencePower = 10, Health = 100, RoomId = 1 },
                new Dragon { Name = "Murzgarbuckbuck", Description = "The Insane", AttackPower = 70, DeffencePower = 20, Health = 120, RoomId = 2 },
                new Dragon { Name = "Gulbolg-rogg", Description = "The Voiceless", AttackPower = 80, DeffencePower = 30, Health = 130, RoomId = 2 },
                new Dragon { Name = "Issuth", Description = "The Dark", AttackPower = 100 , DeffencePower = 40 , Health = 150 , RoomId = 3 },
                new Dragon { Name = "Ygyssoa", Description = "The Stubborn", AttackPower = 110 , DeffencePower = 50, Health = 160 , RoomId =3 },
                new Dragon { Name = "Sille", Description = "Destroyer Of Life", AttackPower =120, DeffencePower = 60 , Health = 160 , RoomId =4 }
           };
                cnxt.Dragons.AddRange(dragonsList);
                cnxt.SaveChanges();

                var specialAbilitiesList = new List<SpecialAbility>()
            {
                new SpecialAbility { Name = "Dragon Hunter Axe", Description="Increase the attack power", AblityType = SpecialAbilityType.Attack, Power = 20 },
                new SpecialAbility { Name = "Heavens Shield", Description="Increase the defence power", AblityType = SpecialAbilityType.Deffence, Power = 10 },
                new SpecialAbility { Name = "Sword Of Balance", Description= "You become balanced", AblityType = SpecialAbilityType.Attack, Power = 15 },
                new SpecialAbility { Name = "Dragon's Tooth Sword", Description= "The dragon's bane", AblityType = SpecialAbilityType.Attack, Power = 20 },
                new SpecialAbility { Name = "A Bucket Helmet", Description = "Best armor in the game", AblityType = SpecialAbilityType.Deffence , Power = 20 },
                new SpecialAbility { Name = "The One Ring", Description = "It glows in the dark", AblityType = SpecialAbilityType.Deffence , Power = 15  },
                new SpecialAbility { Name = "Lightsaber", Description = "Original idea", AblityType = SpecialAbilityType.Attack , Power = 15  },
            };
                cnxt.SpecialAbilities.AddRange(specialAbilitiesList);
                cnxt.SaveChanges();

                PhaseTyper("Ready!");
            }
            else
            {
                PhaseTyper("Ready!");
            }

            
        }
        public static void PhaseTyper(string text)
        {

            foreach (char c in text)
            {
                Console.Write(c);
                Thread.Sleep(25);
            }
            Console.WriteLine();
        }
        public static void Battle(Hero hero, DnDContext context, int roomId)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Clear();
            Console.WindowHeight = 50;
            Console.BufferHeight = 50;
            Console.WindowWidth = 160;
            Console.BufferWidth = 160;
            Random randDragon = new Random();
            var dragonList = context.Dragons.Where(d => d.Room.Id == roomId && d.Killers.Count == 0).ToList();
            int randomInt = randDragon.Next(0, dragonList.Count - 1);
            var dragon = dragonList[randomInt];
            PhaseTyper($"You face a Dragon - {dragon.Name.ToUpper()}, <<{dragon.Description}>>");
            PhaseTyper($"Your Health: {hero.Health}");
            PhaseTyper($"Dragon's Health: {dragon.Health}");
            Console.WriteLine();
            PhaseTyper("Press any key to enter battle! ");
            Console.ReadKey();
            string secondLine = "LEFT";
            string thirdLine = "RIGHT";
            List<string> lines = new List<string>();
            lines.Add(secondLine); lines.Add(thirdLine);

            int pointer = 1;
            int pageSize = 2;

            while (hero.Health > 0 && dragon.Health > 0)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Clear();
                Console.WriteLine($"Choose hitting direction, {hero.Name}'s Attack Power is {hero.AttackPower}!");
                Console.WriteLine();
                int current = 1;

                foreach (var line in lines)
                {
                    if (current == pointer)
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    Console.WriteLine(line);

                    current++;
                }

                var key = Console.ReadKey();

                switch (key.Key.ToString())
                {
                    case "Enter":

                        string heroHit = null;
                        if (pointer == 1)
                        {
                            heroHit = "left";
                        }
                        else
                        {
                            heroHit = "right";
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.Red;
                        }

                        Random randDirection = new Random();

                        List<string> dragonDefList = new List<string>() { "left", "right" };
                        string dragonDef = dragonDefList[randDirection.Next(0, 2)];

                        if (!heroHit.Equals(dragonDef))
                        {
                            Console.Clear();
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.Red;
                            dragon.Health -= hero.AttackPower;
                            if (dragon.Health <= 0)
                            {
                                break;
                            }
                            PhaseTyper($"You hit the dragon successfully! {dragon.Name}'s remaining health {dragon.Health}");
                            PhaseTyper("press any key to continue.");
                            Console.ReadKey();
                            Console.Clear();

                        }
                        else
                        {
                            if (hero.AttackPower > dragon.DeffencePower)
                            {
                                dragon.Health -= (hero.AttackPower - dragon.DeffencePower);
                                if (dragon.Health <= 0)
                                {
                                    break;
                                }
                                Console.Clear();
                                PhaseTyper($"The Dragon blocked your hit, but you still deal damage. {dragon.Name}'s remaining health: {dragon.Health}");
                                Console.WriteLine();
                                PhaseTyper("press any key to continue.");
                                Console.ReadKey();
                                Console.Clear();
                            }
                            else
                            {
                                Console.Clear();
                                PhaseTyper($"{dragon.Name} blocked your hit!");
                                Console.WriteLine();
                                PhaseTyper("press any key to continue.");
                                Console.ReadKey();
                                Console.Clear();
                            }
                        }
                        if (dragon.Health > 0)
                        {
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Clear();
                            Random randDefHero = new Random();
                            Random randHitDragon = new Random();
                            int defHero = randDefHero.Next(1, 3);
                            int hitDragon = randHitDragon.Next(1, 3);
                            if (defHero != hitDragon)
                            {
                                hero.Health -= hitDragon;
                                if (hero.Health <= 0)
                                {
                                    break;
                                }
                                PhaseTyper($"{dragon.Name} hit you!");
                                PhaseTyper($"Remaining Health: {hero.Health}");
                                Console.WriteLine();
                                PhaseTyper("press any key to continue.");
                                Console.ReadKey();
                                Console.Clear();

                            }
                            else
                            {
                                if (dragon.AttackPower > hero.DeffencePower)
                                {
                                    hero.Health -= (dragon.AttackPower - hero.DeffencePower);
                                    if (hero.Health <= 0)
                                    {
                                        break;
                                    }
                                    Console.Clear();
                                    PhaseTyper($"You blocked {dragon.Name}'s hit, but he is too powerful and deals damage!");
                                    PhaseTyper($"Remaining health: {hero.Health}");
                                    Console.WriteLine();
                                    PhaseTyper("press any key to continue.");
                                    Console.ReadKey();
                                    Console.Clear();
                                }
                                else
                                {
                                    Console.Clear();
                                    PhaseTyper($"You blocked {dragon.Name}'s hit!");
                                    Console.WriteLine();
                                    PhaseTyper("press any key to continue.");
                                    Console.ReadKey();
                                    Console.Clear();
                                }
                            }

                        }
                        break;


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
                    case "Escape":
                        MainMenu.Show(hero);
                        break;

                    default:
                        break;

                }
            }
            
            if (hero.Health > 0)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Clear();
                PhaseTyper($"YOU KILLED {dragon.Name.ToUpper()} !!!");
                hero.KilledDragons.Add(dragon);
                hero.Health = 100;
                context.SaveChanges();
                Console.WriteLine();
                PhaseTyper("When you kill a dragon you receive free Special Ability! You can choose it from the Main Menu");
                Console.ReadKey();
                Console.WriteLine();
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Clear();
                PhaseTyper($"{dragon.Name.ToUpper()} KILLED YOU!!! YOU LOST THE GAME");
                PhaseTyper("Try again later !");
                FinalScrean.Show(hero);


                Console.WriteLine();
                Console.ReadLine();
                Utility.StartGame();
            }
        }
    }
}
      
         


