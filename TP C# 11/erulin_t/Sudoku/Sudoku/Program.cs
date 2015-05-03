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
            int a = -10;
            int b = 0;
            int c = 6003;
            int d = 0;
            bool res = Stuff.TimeAfterTime(ref d, ref b, ref a, ref c);
            //string test = "le grand chien bleu hurle\nle ciel hurle avec le chien\ngrand bleu orageux";
            //string test2 = Stuff.Compression(test);
            ////Console.WriteLine(res + "\ndays: " + d + "\nhours: " + b + "\nmins: " + a + "\nsecs: " + c);
            //Console.WriteLine(test);
            //Console.WriteLine(test2);
            //Console.WriteLine(Stuff.Decompression(test));
            Sudoku s = new Sudoku();
            s.Print();
            Console.Read();
            Console.Clear();
            Console.WriteLine(s.solve());
            Console.Read();
            Console.Read();
        }
    }
}
