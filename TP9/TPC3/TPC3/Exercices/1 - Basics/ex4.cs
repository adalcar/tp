using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPC3.Exercices._1___Basics
{
    static class ex4
    {
        /// <summary>
        /// affecte a a la valeur a*(2^b) si b est pair, a*b sinon
        /// </summary>
        public static unsafe void run()
        {
            int a = 3;
            int b = 4;
            utils.fex4(&a, &b);
            b = 3;
            utils.fex4(&a, &b);
            Console.WriteLine("Function ex3 terminated.");
        }
    }
}
