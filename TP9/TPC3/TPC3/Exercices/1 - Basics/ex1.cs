using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPC3.Exercices._1___Basics
{
    class ex1
    {
        /// <summary>
        /// cette fonction incremente de 1 la variable my_nbr
        /// </summary>
        public static unsafe void run()
        {
            int my_nbr = 41;
            utils.fex1(&my_nbr);
            Console.WriteLine("Function ex1 terminated.");
        }
    }
}
