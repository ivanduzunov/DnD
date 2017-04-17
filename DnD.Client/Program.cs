using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DnD.Data;
using DnD.Models;
using System.ComponentModel;
using DnD.Data.Screans;
using DnD.Models;

namespace DnD.Client
{
    public class Program
    {
        public static void Main(string[] args)
        {
            DnDContext context = new DnDContext();
            Console.WindowHeight = 50;
            Console.BufferHeight = 50;
            Console.WindowWidth = 160;
            Console.BufferWidth = 160;
            Utility.StartGame();
            HeroSelection.Show(context);



        }

    }
}
