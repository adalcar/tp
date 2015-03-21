using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TPC3.Exercices
{
    class Happy
    {
        public static void checkHappy()
        {
            int n = 1;
            while (n != 0)
            {
                n = readInt("enter an integer (0 to stop): ");
                if (n != 0)
                {
                    if (isHappy(n))
                        Console.Write("{0} is happy! \n", n);
                    else
                        Console.Write("{0} is not happy...\n", n);
                }

            }
        }
        public static int readInt(string prompt)
        {
            int n;
            do
                Console.Write(prompt);
            while (!(int.TryParse(Console.ReadLine(), out n)));
            return n;
        }
        public static int sumOfSquareDigits(int n)
        {
            int sum = 0;
            while (n > 0)
            {
                sum += (n % 10) * (n %10);
                n /= 10;
            }
            return sum;
        }
        
        public static bool isHappy(int n)
        {
            // j'aurais pu tester n avec tous les nombres de la liste des malheureux
            // mais cela ferait 9 tests par iterations, au lieu de 2, 
            // avec au maximum 7 iterations de trop 
            //(et en plus c'est beaucoups plus complique a implementer)

            while (n != 1 && n != 4) 
            {
                n = sumOfSquareDigits(n);                
            }
            return (n == 1);
        }

    }
}
