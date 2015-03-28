using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Diagnostics;

namespace CTF
{
    class Program
    {
        public static void Main()
        {
            //Client c = new Client("91.121.83.195", 4242, "erulin_t");
            Client c = new Client("80.236.44.146", 6969, "erulin_t");
            List<ExX> exlist = new List<ExX> { new Ex7("Ex9"), new ExA(), new ExB(c) };
            c.connect();
            if (c.process(exlist))
                Console.WriteLine("Test Successful!");
            else
                Console.WriteLine("Test Failed!");
            Console.Read();
        }

        public static string some_function_you_have_to_code(byte[] msg)
        {
            StringBuilder s = new StringBuilder();
            foreach (byte b in msg)
                s.Append((char)b);
            return s.ToString();
        }
        public static byte[] some_function_you_have_to_code(string msg)
        {
            byte[] b = new byte[msg.Length];
            for (int i = 0; i < msg.Length; i++)
            {
                b[i] = (byte) msg[i];
            }
            return b;
        }

    }
}
