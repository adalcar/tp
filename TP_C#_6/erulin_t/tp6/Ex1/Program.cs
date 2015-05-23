using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Ex1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] strs = new string[2] { "lol", "je m'aime" };
            BMPReader b = new BMPReader("Artzwerk.bmp");
            Console.Read();

        }
        static string read_file(string filename)
        {
            StreamReader s = new StreamReader(filename);
            string str = s.ReadLine();
            s.Close();
            return str;
        }
        static void write_to_file(string filename, string[] lines)
        {
            StreamWriter s = new StreamWriter(filename);
            
            foreach (string str in lines) 
                s.WriteLine(str);
            s.Close();
            
           
        }
    }
}
