using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvader
{
    class Enemy : Character
    {
        public int speed;

        public Enemy(string design, int x, int y, int speed)
            : base(design, x, y)
        {
            this.speed = speed; 
            this.life = 20;
            r = new Random();
        }
        public void update(int time, Player p)
        {
            this.time = time;
            for (int i = shots.Count - 1; i >= 0; i--)
            {
                shots[i].update(time);
                delete_shot(shots[i], p);
            }
            shoot(".", 1, 2*speed);
            print();
            if (time % speed == 0)
                move();
        }
        public bool arrived()
        {
            return (y == Console.BufferHeight - 1);
        }

        public void move()
        {
            int dir = r.Next(3) - 1;
            if (!(dir == -1 && x <= length + 1)&&
                !(dir == 1 && x >= Console.BufferWidth - length - 9))
                x += dir * length;
            y += 1;
        }
        public void print()
        {
            if (x + length + 9 < Console.BufferWidth)
            {
                Console.SetCursorPosition(x + length, y - 1);
                Console.Write(refresh_str);
            }
            if (x - length > 0)
            {
                Console.SetCursorPosition(x - length , y - 1);
                Console.Write(refresh_str);
            }
            
            Console.SetCursorPosition(x, y - 1);
            Console.Write(refresh_str);
            Console.SetCursorPosition(x, y);
            Console.Write(design);
        }
    }
}
