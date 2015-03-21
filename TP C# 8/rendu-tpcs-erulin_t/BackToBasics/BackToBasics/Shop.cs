using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackToBasics
{
    class PonyShop : building
    {

        public PonyShop(string name, int gold)
            : base(name, gold)
        {

        }
        public void display()
        {
            if (ponies.Count != 0)
                foreach (Pony p in ponies)
                {
                    p.display();
                    Console.Write(" | ");
                }
            else
                Console.Write("nothing today");
        }

        public Pony get_poney()
        {
            if (ponies.Count != 0)
                return ponies.Last();
            else 
                return null;
        }
    }
    class FarmShop : building
    {
        private List<Farm> catalog;
        public FarmShop(string name, int gold)
            : base(name, gold)
        {
            catalog
        }
    }
}
