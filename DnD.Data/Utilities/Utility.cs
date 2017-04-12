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


                var dragonsList = new List<Dragon>()
           {
                new Dragon { Name = "Grombuztan", Description = "Protector Of The Sky", AttackPower = 50, DeffencePower = 10, Health = 100, Level = 1 },
                new Dragon { Name = "Gruntselga", Description = "The Mysterious", AttackPower = 50, DeffencePower = 10, Health = 100, Level = 1 },
                new Dragon { Name = "Murzgarbuckbuck", Description = "The Insane", AttackPower = 70, DeffencePower = 20, Health = 120, Level = 2 },
                new Dragon { Name = "Gulbolg-rogg", Description = "The Voiceless", AttackPower = 80, DeffencePower = 30, Health = 130, Level = 2 },
                new Dragon { Name = "Issuth", Description = "The Dark", AttackPower = 100 , DeffencePower = 40 , Health = 150 , Level = 3 },
                new Dragon { Name = "Ygyssoa", Description = "The Stubborn", AttackPower = 110 , DeffencePower = 50, Health = 160 , Level =3 },
                new Dragon { Name = "Sille", Description = "Destroyer Of Life", AttackPower =120, DeffencePower = 60 , Health = 160 , Level =3 }
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

                var roomsList = new List<Room>()
            {
                new Room { Description = "---{{{  You have entered the first room in the dungeon. In  it, you will find your first challenge.  }}}---"},
                new Room { Description = "---{{{  As you advance trough the duneon the enemies get stronger. Prepare yourself the next dragon awaits!   }}}---" }
            };
                cnxt.Rooms.AddRange(roomsList);
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




        public static void Next()
        {
            Console.Clear();
            var context = new DnDContext();
            List<Hero> heroesList = context.Heroes.ToList();
            Hero hero = null;
            for (int i = 0; i < heroesList.Count; i++)
            {
                if (i == heroesList.Count() - 1)
                {
                    hero = heroesList[i];
                }
            }

            //-----------------------
               var room = context.Rooms.Where(c => c.Id == 1).FirstOrDefault();

<<<<<<< HEAD:DnD.Data/Utility.cs
=======

            var room = context.Rooms.Where(c => c.Id == 1).FirstOrDefault();

>>>>>>> 20a9c55a70183385b46e8c22b98c0f513718134e:DnD.Data/Utilities/Utility.cs
            PhaseTyper(room.Description);


        }
    }
}

