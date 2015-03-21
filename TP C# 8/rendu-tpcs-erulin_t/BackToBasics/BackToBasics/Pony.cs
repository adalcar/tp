using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackToBasics
{
    class Pony
    {
        protected ConsoleColor color;
        public int size { get; private set; }
        protected Random r = new Random();

        public Pony(ConsoleColor couleur)
        {
            color = couleur;
            size = r.Next(2, 11);
        }
        public void display()
        {
            Console.ForegroundColor = color;
            Console.Write("." + new String('=', size) + ".°");
        }
    }
}
