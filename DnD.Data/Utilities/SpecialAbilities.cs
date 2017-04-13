using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD.Data.SpecialAbilities
{
   public class SpecialAbilities
    {
        public static void Use(string spell)
        {
            if (spell == "Abyss")
            {
                using (DnDContext context = new DnDContext())
                {
                  var  hero = context.Heroes.OrderByDescending(a => a.Id).First();
                  var  abyss = context.SpecialAbilities.FirstOrDefault(c => c.Name == "Abyss");
                    hero.AttackPower += abyss.Power;
                    context.SaveChanges();
                    Utility.PhaseTyper($"{hero.Name} increased his attack power by {abyss.Power}.....");

                    Console.WriteLine("Press any key to continue!");
                    Console.ReadLine();
                }
                
            }

            if (spell == "Heavens Shield")
            {
                using (DnDContext context = new DnDContext())
                {
                    var hero = context.Heroes.OrderByDescending(a => a.Id).First();
                    var heavensShield = context.SpecialAbilities.FirstOrDefault(c => c.Name == "Heavens Shield");
                    hero.DeffencePower += heavensShield.Power;
                    context.SaveChanges();
                    Utility.PhaseTyper($"{hero.Name} increased his defence power by {heavensShield.Power}.....");

                    Console.WriteLine("Press any key to continue!");
                    Console.ReadLine();
                }
             }
            if (spell== "Heal")
            {
                using (DnDContext context = new DnDContext())
                {
                    var hero = context.Heroes.OrderByDescending(a => a.Id).First();
                    var heal = context.SpecialAbilities.FirstOrDefault(c => c.Name == "Heal");
                    hero.Health += heal.Power;
                    context.SaveChanges();
                    Utility.PhaseTyper($"{hero.Name} increased his health by {heal.Power}.....");

                    Console.WriteLine("Press any key to continue!");
                    Console.ReadLine();
                }
            }

        }
    }
}
    