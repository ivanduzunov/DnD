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

            //test1234567789


           // Utility.StartGame();
            Console.WindowHeight = 30;
            Console.BufferHeight = 30;
            Console.WindowWidth = 60;
            Console.BufferWidth = 60;

            DnDContext context = new DnDContext();
          //  Utility.ChooseHero(context);

            Utility.Next(); 

            //Prosto e izvaden Hero v sledvashtiq method sled kraq na igrata shte tryabva da se dropne, za da ne se dublirat
            
        }
        
    }
}
