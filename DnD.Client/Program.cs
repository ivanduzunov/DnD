﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DnD.Data;
using DnD.Models;
using System.ComponentModel;



namespace DnD.Client
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Utility.StartGame();
            Console.WindowHeight = 30;
            Console.BufferHeight = 30;
            Console.WindowWidth = 60;
            Console.BufferWidth = 60;

            DnDContext context = new DnDContext();
            Utility.ChooseHero(context);
            Utility.Next();
        }

       
    }
}
