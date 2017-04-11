using System;
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
            Console.WindowHeight = 17;
            Console.BufferHeight = 17;
            Console.WindowWidth = 50;
            Console.BufferWidth = 50;

            DnDContext context = new DnDContext();
            Utility.ChooseHero(context);
            //Prosto e izvaden Hero v sledvashtiq method sled kraq na igrata shte tryabva da se dropne, za da ne se dublirat
            Utility.Next();
           
           
           

        }

       
    }
}
