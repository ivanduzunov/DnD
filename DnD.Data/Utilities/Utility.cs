using DnD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Data;

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
                Console.WriteLine("Loading");
                cnxt.Database.Initialize(true);

                var heroesList = new List<Hero>()
            {
                new Hero { Name = "Even", Description = "Human", AttackPower = 30, DeffencePower = 30, Health = 100 },
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
                new SpecialAbility { Name = "Abyss", Description="Increase the attack power", AblityType = SpecialAbilityType.Attack, Power = 20 },
                new SpecialAbility { Name = "Heavens Shield", Description="Increase the defence power", AblityType = SpecialAbilityType.Deffence, Power = 30 },
                new SpecialAbility { Name = "Fireball", Description= "Shoot a fireball at your enemy", AblityType = SpecialAbilityType.Attack, Power = 80 },
                new SpecialAbility { Name = "Frostball", Description= "Deal small damage and make your opponent skip a turn", AblityType = SpecialAbilityType.Attack, Power = 30 },
                new SpecialAbility { Name = "Heal", Description = "Heal a small amount of your life", AblityType = SpecialAbilityType.Deffence , Power = 70  },
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
                Thread.Sleep(25);
            }
            Console.WriteLine();
        }
        public static void FirstRoom(Hero hero, DnDContext context)
        {
           
            Screans.Introduction.Show(hero);
            Screans.MainMenu.Show();
            var room = context.Rooms.Where(r => r.Id == 1).FirstOrDefault();
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Red;

            PhaseTyper("You just entered into the First Dungeon!");
            PhaseTyper(room.Description);
            PhaseTyper("Its time for battle!"); Console.WriteLine();
            PhaseTyper("Press any key to continue..");
            Console.ReadKey();




            Battle(hero, context, room.Id);
            ChooseSpecialAbility(hero);
            Screans.MainMenu.Show();
            Battle(hero, context, room.Id);
            ChooseSpecialAbility(hero);
            Screans.MainMenu.Show();
            SecondRoom(hero, context);

        }
        public static void SecondRoom(Hero hero, DnDContext context)
        {
            var room = context.Rooms.Where(r => r.Id == 2).FirstOrDefault();

            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Red;

            PhaseTyper("Congratulations! You proceed to the Second Dungeon!");
            PhaseTyper(room.Description);
            PhaseTyper($"{hero.Name}'s health: {hero.Health}");
            PhaseTyper("Its time for battle again!"); Console.WriteLine();
            PhaseTyper("Press any key to continue..");
            Console.ReadKey();

            Battle(hero, context, room.Id);
            ChooseSpecialAbility(hero);
            Screans.MainMenu.Show();
            Battle(hero, context, room.Id);
            ChooseSpecialAbility(hero);
            Screans.MainMenu.Show();
            ThirdRoom(hero, context);
        }
        public static void ThirdRoom(Hero hero, DnDContext context)
        {
            var room = context.Rooms.Where(r => r.Id == 3).FirstOrDefault();
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Red;

            PhaseTyper("Congratulations! You entered to the Final Dungeon!");
            PhaseTyper($"{hero.Name}'s health: {hero.Health}");
            PhaseTyper(room.Description);
            PhaseTyper("Fight! "); Console.WriteLine();
            PhaseTyper("Press any key to continue..");
            Console.ReadKey();

            Battle(hero, context, room.Id);
            ChooseSpecialAbility(hero);
            Screans.MainMenu.Show();
            Battle(hero, context, room.Id);
            ChooseSpecialAbility(hero);
            Screans.MainMenu.Show();
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
                        }

                        Random randDirection = new Random();
                        heroHit = "left";
                        List<string> dragonDefList = new List<string>() { "left", "right" };
                        string dragonDef = dragonDefList[randDirection.Next(0, 1) + 1];

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
                                PhaseTyper($"The Dragon blocked your hit, but you still take him dammage. {dragon.Name}'s remaining health: {dragon.Health}");
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
                            int defHero = randDefHero.Next(1, 2);
                            int hitDragon = randHitDragon.Next(1, 2);
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
                                    PhaseTyper($"You blocked {dragon.Name}'s hit, but he is too powerful and still take you dammage!");
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
                        Console.WriteLine("<PAUSE>");
                        PhaseTyper("Press any key to continue.");
                        Console.ReadKey();
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
                context.SaveChanges();
                PhaseTyper("To continue your quest in the First Dungeon press any key!");
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
                FinalScreen(hero);
                Console.WriteLine();
            }
        }
        public static void ChooseSpecialAbility(Hero hero)
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
                            Console.Clear();

                            var ability = context.SpecialAbilities.FirstOrDefault(c => c.Name == "Abyss");
                            ApplySpecialAbility(hero, ability);
                            return;

                        }
                        if (pointer == 2)
                        {
                            Console.Clear();

                            var ability = context.SpecialAbilities.FirstOrDefault(c => c.Name == "Heavens Shield");
                            ApplySpecialAbility(hero, ability);
                            return;


                        }
                        if (pointer == 3)
                        {
                            Console.Clear();

                            var ability = context.SpecialAbilities.FirstOrDefault(c => c.Name == "Fireball");
                            ApplySpecialAbility(hero, ability);
                            return;
                        }
                        if (pointer == 4)
                        {
                            Console.Clear();

                            var ability = context.SpecialAbilities.FirstOrDefault(c => c.Name == "Frostball");
                            ApplySpecialAbility(hero, ability);
                            return;
                        }
                        if (pointer == 5)
                        {

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
                PhaseTyper($"Your Attack power increased by {ability.Power}");
                PhaseTyper($"Total Attack Power: {hero.AttackPower}");
                Console.WriteLine();
                PhaseTyper("Press any key to continue...");
                Console.ReadKey();
            }
            else if (ability.AblityType == SpecialAbilityType.Deffence)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                hero.DeffencePower += ability.Power;
                PhaseTyper($"Your Deffence power increased by {ability.Power}");
                PhaseTyper($"Total Attack Power: {hero.DeffencePower}");
                Console.WriteLine();
                PhaseTyper("Press any key to continue...");
                Console.ReadKey();
            }

        }
        public static void FinalScreen(Hero hero)
        {
            PhaseTyper("Your game is over");
            PhaseTyper($"Your hero was {hero.Name}");
            Console.WriteLine(); Console.WriteLine();
            PhaseTyper("Killed Dragons"); Console.WriteLine();
            foreach (var item in hero.KilledDragons)
            {
                PhaseTyper($"{item.Name}, {item.Description}");
            }
            var context = new DnDContext();
            context.Database.Delete();
        }


    }

}


