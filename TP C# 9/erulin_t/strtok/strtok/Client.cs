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
    class Client
    {
        # region Attributes
        string login;
        TcpClient c;
        IPEndPoint i;
        bool connected;
        NetworkStream ns;
        /* ... */
        # endregion
        # region Constructor
        public Client(string adress, int port, string log)
        {
            
            this.login = log;
            this.i = new IPEndPoint(IPAddress.Parse(adress), port);
            this.c = new TcpClient(i);
            connected = this.connect();
        }
        # endregion

        # region Methodes
        public bool connect()
        {
            try
            {
                c.Connect(i);
                ns = c.GetStream();
                return true;
            }
            catch
            {
                Console.WriteLine("Connexion failed!");
                return false;
            }
        }

        public void send(string msg)
        {
            if (connected)
            {
                ns.Write(String_to_bytes(msg),0,msg.Length);
                ns.Flush();
            }
            else
            {
                Console.WriteLine("Not connected!");
            }
        }

        public String receive()
        {
            if (connected)
            {
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
                return Bytes_to_string(ans).Trim();
            }
            else
                return "";
        }
        public bool process(ExX ex)
        {
            string demande = login + "|" + ex.name + ":";
            Console.WriteLine("=> " + demande);
            send(demande);

            string reponse = receive();
            Console.WriteLine(reponse);

            string answer = ex.solve(reponse.Substring(3));

            send(demande + answer);
            Console.WriteLine("<= ");
            
            /* FIXME : Solve the exercise */
            /* return true or false , according to the result */
            /* given by the server */
            /* return true : The answer is correct */
            /* false : The answer is wrong */
        }
        //public bool process(List<ExX> exs)
        //{
        //    /* FIXME : Solve all the exercises */
        //    /* return true : All the answers are correct */
        //    /* false : One of the answers is wrong */
        //}
        public string Bytes_to_string (byte[] msg)
        {
            StringBuilder s = new StringBuilder();
            foreach (byte b in msg)
                s.Append((char)b);
            return s.ToString();
        }
        public byte[] String_to_bytes (string msg)
        {
            byte[] b = new byte[msg.Length];
            for (int i = 0; i < msg.Length; i++)
            {
                b[i] = (byte)msg[i];
            }
            return b;
        }
        # endregion
    }
}
