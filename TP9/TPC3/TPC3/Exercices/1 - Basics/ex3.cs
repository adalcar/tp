using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPC3.Exercices._1___Basics
{
    class ex3
    {
        /// <summary>
        /// cette fonction echange les valeurs des deux variables
        /// </summary>
        public static unsafe void run()
        {
            int a = 37;
            int b = 13;
            utils.fex3(&a, &b);
            Console.WriteLine("Function ex3 terminated.");
        }
    }
}
