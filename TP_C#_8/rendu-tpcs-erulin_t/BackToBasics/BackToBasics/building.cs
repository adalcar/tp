using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackToBasics
{
    class building
    {
        protected List<Pony> ponies;
        protected string name;
        protected int balance;
        protected Random r = new Random();
        public building(string name, int gold)
        {
            ponies = new List<Pony>();
            this.name = name;
            balance = gold;
        }
        public void add_gold(int nb)
        {
            balance += nb;
        }
        public abstract void display(int windowX, int windowY)
        {
            Console.Write(name);
        }
        public void add_poney(Pony p)
        {
            ponies.Add(p);
        }

    }
}
