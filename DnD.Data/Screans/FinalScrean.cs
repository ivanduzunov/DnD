using DnD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD.Data.Screans
{
    class FinalScrean
    {
        public static void Show(Hero hero)
        {
            Utility.PhaseTyper("Your game is over");
            Utility.PhaseTyper($"Your hero was {hero.Name}");
            Console.WriteLine(); Console.WriteLine();
            Utility.PhaseTyper("Killed Dragons"); Console.WriteLine();
            foreach (var item in hero.KilledDragons)
            {
                Utility.PhaseTyper($"{item.Name}, {item.Description}");
            }
            var context = new DnDContext();
            context.Database.Delete();
            Environment.Exit(0);
        }
    }
}
