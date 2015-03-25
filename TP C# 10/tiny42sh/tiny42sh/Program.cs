using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tiny42sh
{
    class Program
    {
        static void Main(string[] args)
        {
            //foreach (string[] ls in Interpreter.parse_input(Console.ReadLine()))
            //{
            //    foreach (string s in ls)
            //        Console.Write(s + " ");
            //    Console.WriteLine("\n**************");
            //}
            while (true)
            {
                Console.Write("tiny42sh$ ");
                Execution.execute_input(Interpreter.parse_input(Console.ReadLine()));
            }
            
        }
    }
}
