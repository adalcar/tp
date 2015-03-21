using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvader
{
    class Player : Character
    {
        public bool stunned;
        private int stuntime;
        public Player(string design, int x, int y) : base(design, x, y)
        {
            life = 1000;
        }
        public void update(int time, List<Enemy> characs)
        {
            this.time = time;
            print();
            for (int i = shots.Count - 1; i >= 0; i--)
            {
                shots[i].update(time);
                delete_shot(shots[i], characs);
            }
            if (time == stuntime)
                stunned = false;

                
        }

        public void print()
        {
            Console.SetCursorPosition(x - 1, y);
            Console.Write(refresh_str);
            Console.SetCursorPosition(x + 1, y);
            Console.Write(refresh_str);
            if (this.stunned)
            {
                Console.SetCursorPosition(x - 1, y);
                Console.Write("{"+design+"}");
            }
            else
            {
                Console.SetCursorPosition(x, y);
                Console.Write(design);
            }
            
        }
        public void stun(int power)
        {
            stuntime = time + power;
            stunned = true;
        }
    }
}
