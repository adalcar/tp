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
    class Client
    {
        # region Attributes
        public string login;
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
            
            connected = this.connect();
        }
        # endregion

        # region Methodes
        public bool connect()
        {
            try
            {
                this.c = new TcpClient();
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
                return Bytes_to_string(ans).Substring(0, ans_size);
            }
            else
                return "";
        } 
        public bool process(ExX ex)
        {
            if (connected)
            {
                string demande = login + "|" + ex.name + ":";
                Console.WriteLine("=> " + demande);
                send(demande);

                string reponse = receive();
                Console.WriteLine("<= " + reponse);
                Console.WriteLine();
                string answer = ex.solve(reponse.Substring(3));
                send(demande + answer);
                Console.WriteLine("=> " + demande + answer);

                string response = receive();
                Console.WriteLine("<= " + response);
                Console.WriteLine();
                return response.Substring(0, 2) == "OK";
            }
            else
                return false;
            
        }
        public bool process(List<ExX> exs)
        {
            bool result = true;
            foreach (ExX e in exs)
            {
                result = result && process(e);
                Console.WriteLine();
            }
            return result;
            /* FIXME : Solve all the exercises */
            /* return true : All the answers are correct */
            /* false : One of the answers is wrong */
        }
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
