using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = -25;
            int b = -24;
            int c = -350;
            int d = -2;
            bool res = Stuff.TimeAfterTime(ref d, ref b, ref a, ref c);

            Console.WriteLine(res + "\ndays: " + d + "\nhours: " + b + "\nmins: " + a + "\nsecs: " + c);
            Console.Read();
        }
    }
}
