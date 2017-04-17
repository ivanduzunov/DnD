using DnD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DnD.Data.Screans
{
    public class HowToPlay
    {
        public static void Show(Hero hero)
        {
            Console.Clear();
            Console.WriteLine("How to play"); Console.WriteLine();
            PhaseTyper(@"Dragons And Dungeons is a turn based RPG.You start by selecting your hero which you are going to us untill the end of the game. 
After that your job is to kill the dragons that are harassing the kingdome and finally their leader The Destroyer Of Life. 
When you face an enemy dragon you have 3 options to atack. From the left , right , and top direction.The demage that you are going to deal is equal to your attack power, and the demage you recieve is equal to the dragon's attack power.
However there is a chance thar you are going to choose the same direction to atack like the dragon, and you are going to block some demage equal to your defence power(the dragon will block some demage too).
After killing a dragon you will need to choose between a few special abilities that will help you to defeat the next enemy you face as they get stronger when you advanced.
                ");
            Console.WriteLine();
            PhaseTyper("Now go and defend your honor!");
            Console.WriteLine();
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("Back to Main Menu");
            var key = Console.ReadKey();
            switch (key.Key.ToString())
            {
                case "Enter":
                    MainMenu.Show(hero); break;
            }
        }
        public static void PhaseTyper(string text)
        {

            foreach (char c in text)
            {
                Console.Write(c);
                Thread.Sleep(15);
            }
            Console.WriteLine();
        }
    }
}
