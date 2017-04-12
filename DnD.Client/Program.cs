using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DnD.Data;
using DnD.Models;
using System.ComponentModel;
using DnD.Data.Screans;

namespace DnD.Client
{
    public class Program
    {
        public static void Main(string[] args)
        {
<<<<<<< HEAD

            //test1234567789


           // Utility.StartGame();
=======
            Utility.StartGame();
            DnDContext context = new DnDContext();

>>>>>>> 20a9c55a70183385b46e8c22b98c0f513718134e
            Console.WindowHeight = 30;
            Console.BufferHeight = 30;
            Console.WindowWidth = 60;
            Console.BufferWidth = 60;

<<<<<<< HEAD
            DnDContext context = new DnDContext();
          //  Utility.ChooseHero(context);
=======
           
           HeroSelection.Show(context);
            MainMenu.Show();
>>>>>>> 20a9c55a70183385b46e8c22b98c0f513718134e

           

            //Prosto e izvaden Hero v sledvashtiq method sled kraq na igrata shte tryabva da se dropne, za da ne se dublirat
            
        }
        
    }
}
