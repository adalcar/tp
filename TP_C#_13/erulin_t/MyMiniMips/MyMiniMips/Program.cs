using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMiniMips
{
    class Program
    {
        static void Main(string[] args)
        {
            CPU c = new CPU("fibo.s");
            ALU a = new ALU(c);
            a.run();
            Console.Read();
        }
    }
}
