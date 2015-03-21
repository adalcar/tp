using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TPC3.Exercices
{
    class pascalCalcs
    {
        public static void pascal(int n)
        {
            List<int> line0 = new List<int>();
            for (int i = 1; i <=n; i++)
            {
                line0 = nextLine(line0);
                foreach (int k in line0)
                {
                    Console.Write(k + " ");
                }
                Console.Write("\n");
            }
            Console.Read();

        }
        public static List<int> nextLine(List<int> line)
        {
            List<int> l = new List<int>();
            int prev = 0;
            foreach (int i in line)
            {
                l.Add(i + prev);
                prev = i;
            }
            l.Add(1);
            return l;
        }  
    }
}
