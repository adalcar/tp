using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPC3.Exercices._1___Basics
{
    class ex2
    {
        /// <summary>
        /// cette fonctoin affecte a my_nbr la valeur 0
        /// </summary>
        public static unsafe void run()
        {
            int my_nbr = 42;
            utils.fex2(&my_nbr);
            Console.WriteLine("Function ex2 terminated.");
        }
    }
}
