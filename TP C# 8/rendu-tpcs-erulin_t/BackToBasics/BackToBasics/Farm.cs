using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackToBasics
{
    class Farm : building
    {
        public int balance;
        public string name;
        private int size;

        public Farm(string name, int gold, int size)
            : base(name, gold) 
        {
            this.size = size;
        }

        public void display()
        {
            if (ponies.Count != 0)
                foreach (Pony p in ponies)
                {
                    Console.Write(new string(' ', r.Next(15)));
                    p.display();
                }
            else
                Console.Write("such a depressing empty field: no poneys");
        }
    }
}
