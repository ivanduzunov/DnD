using DnD.Data.Screans;
using DnD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD.Data
{
   public class Rooms
    {
        public static void FirstRoom(Hero hero, DnDContext context)
        {
            Screans.Introduction.Show(hero);
            Screans.MainMenu.Show(hero);
            var room = context.Rooms.Where(r => r.Id == 1).FirstOrDefault();
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Red;
            
            Utility.PhaseTyper(room.Description);
            Utility.PhaseTyper("Its time for battle!"); Console.WriteLine();
            Utility.PhaseTyper("Press any key to continue..");
            Console.ReadKey();
            

            Utility.Battle(hero, context, room.Id);
            ChooseItems.Show(hero,context);
            Screans.MainMenu.Show(hero);
            Utility.Battle(hero, context, room.Id);
            ChooseItems.Show(hero, context);
            Screans.MainMenu.Show(hero);
            SecondRoom(hero, context);
        }
        public static void SecondRoom(Hero hero, DnDContext context)
        {
            var room = context.Rooms.Where(r => r.Id == 2).FirstOrDefault();

            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Red;

            Utility.PhaseTyper("Congratulations! You proceed to the Second Dungeon!");
            Utility.PhaseTyper(room.Description);
            Utility.PhaseTyper($"{hero.Name}'s health: {hero.Health}");
            Utility.PhaseTyper("Its time for battle again!"); Console.WriteLine();
            Utility.PhaseTyper("Press any key to continue..");
            Console.ReadKey();

            Utility.Battle(hero, context, room.Id);
            ChooseItems.Show(hero, context);
            Screans.MainMenu.Show(hero);
            Utility.Battle(hero, context, room.Id);
            ChooseItems.Show(hero, context);
            Screans.MainMenu.Show(hero);
            ThirdRoom(hero, context);
        }
        public static void ThirdRoom(Hero hero, DnDContext context)
        {
            var room = context.Rooms.Where(r => r.Id == 3).FirstOrDefault();
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Red;

            Utility.PhaseTyper("Congratulations! You entered to the Final Dungeon!");
            Utility.PhaseTyper($"{hero.Name}'s health: {hero.Health}");
            Utility.PhaseTyper(room.Description);
            Utility.PhaseTyper("Fight! "); Console.WriteLine();
            Utility.PhaseTyper("Press any key to continue..");
            Console.ReadKey();

            Utility.Battle(hero, context, room.Id);
            ChooseItems.Show(hero, context);
            Screans.MainMenu.Show(hero);
            Utility.Battle(hero, context, room.Id);
            ChooseItems.Show(hero, context);
            Screans.MainMenu.Show(hero);
            FinalRoom(hero, context);
        }
        public static void FinalRoom(Hero hero , DnDContext context)
        {
            var room = context.Rooms.Where(r => r.Id == 4).FirstOrDefault();
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Red;

            Utility.PhaseTyper("Congratulations! You entered the castle!");
            Utility.PhaseTyper($"{hero.Name}'s health: {hero.Health}");
            Utility.PhaseTyper(room.Description);
            Utility.PhaseTyper("Fight! "); Console.WriteLine();
            Utility.PhaseTyper("Press any key to continue..");
            Console.ReadKey();

            Utility.Battle(hero, context, room.Id);
            FinalScrean.Show(hero);
        }
    }
}
