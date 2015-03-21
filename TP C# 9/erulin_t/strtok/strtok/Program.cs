using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Diagnostics;

namespace strtok
{
    class Program
    {
        public static void Main()
        {
            TcpClient tcpClient = new TcpClient();
            IPEndPoint serverAddress = new IPEndPoint(IPAddress.Parse("80.236.44.146"), 6969);

            tcpClient.Connect(serverAddress);

            byte[] msg = some_function_you_have_to_code("My string message ");
            NetworkStream ns = tcpClient.GetStream();
            ns.Write(msg, 0, msg.Length);
            ns.Flush();

            Stopwatch clock = new Stopwatch();
            clock.Start();
            byte[] ans = new byte[4096];
            int ans_size = 0;

            while (clock.ElapsedMilliseconds < 5000)
            {
                if (ns.DataAvailable)
                {
                    ans_size = ns.Read(ans, 0, 4096);

                    break;
                }
            }
            Console.WriteLine(some_function_you_have_to_code(ans));
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
