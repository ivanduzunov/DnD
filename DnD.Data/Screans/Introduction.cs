using DnD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD.Data.Screans
{
    public class Introduction
    {
        public static void Show(Hero ChosenHero)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Utility.PhaseTyper($"You choose {ChosenHero.Name.ToUpper()}!"); Console.WriteLine();
            Utility.PhaseTyper($"Description: {ChosenHero.Description}");
            Utility.PhaseTyper($"Attack Power: {ChosenHero.AttackPower}");
            Utility.PhaseTyper($"Defence Power: {ChosenHero.DeffencePower}");
            Utility.PhaseTyper($"Primary Health: {ChosenHero.Health}"); Console.WriteLine();
            Utility.PhaseTyper($"Let your adventure begin!"); Console.WriteLine();

            Console.WriteLine("Press any key to continue.");
            Console.ReadLine();
            Console.Clear();
            

        }
    }
}
