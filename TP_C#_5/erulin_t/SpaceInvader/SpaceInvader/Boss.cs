using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvader
{
    class Boss : Enemy
    {
        private int dir;
        public Boss() : base("[\\/^\\_/^\\/]",(Console.BufferWidth - 12)/ 2, 1, 100)
        {
            dir = -1;
            life = 300;
        }

        public void shoot()
        {
            Shot s = new Shot("o", x + 3, 2, 1);
            Shot s1 = new Shot("o", x + 7, 2, 1);
            shots.Add(s);
            shots.Add(s1);

        }
        new public void update(int time, Player p)
        {
            this.time = time;
            for (int i = shots.Count - 1; i >= 0; i--)
            {
                shots[i].update(time);
                delete_shot(shots[i], p);
            }
            if (time % 400 == 0)
                shoot();
            if (time % speed == 0)
            {
                move();
                print();
            }

        }
        new protected void delete_shot(Shot shot, Player player)
        {
            if (shot.y == player.y && shot.x >= player.x
                && shot.x <= player.x + player.length)
            {
                shot.collision = true;
                player.life -= 20;
                player.stun(400);
                shots.Remove(shot);
            }
            else
                if ((shot.y < 1 && shot.direction == -1)
                    || (shot.y > Console.BufferHeight - 2 && shot.direction == 1))
                {
                    Console.SetCursorPosition(shot.x, shot.y);
                    Console.Write(" ");
                    shots.Remove(shot);
                }
        }
        new public void move()
        {
            if (dir == -1 && x <= 1)
                dir = 1;
            if (dir == 1 && x >= Console.BufferWidth - length - 9)
                dir = -1;
            x += dir;
            
        }
        new public void print()
        {
            Console.SetCursorPosition(x - 1, y);
            Console.Write(" {0} ", design);
        }
        
    }
}
