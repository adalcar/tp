using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvader
{
    class Character
    {
        private int cannon;
        protected Random r;
        public int nb_shots;
        protected string design;
        protected int last_shot_time;
        public string refresh_str;
        public int length;
        public int life;
        public int x;
        public int y;
        protected List<Shot> shots;
        public int time;

        public Character(string design, int x, int y)
        {
            this.x = x;
            this.y = y;
            this.design = design;
            time = 0;
            length = design.Length;
            
            refresh_str = fill_refresh_str();
            shots = new List<Shot> { };
            cannon = getcannon(design);
            nb_shots = 0;
        }

       

        public void shoot(string design, int direction, int speed)
        {
            if (time - last_shot_time > speed)
            {
                Shot s = new Shot(design, x + cannon, y + direction, direction);
                shots.Add(s);
                last_shot_time = time;
                nb_shots++;
            }

        }
        public string fill_refresh_str()
        {
            return new string(' ',length);
        }
        public void clear_shots()
        {
            foreach (Shot s in shots)
            {
                Console.SetCursorPosition(s.x, s.y);
                Console.Write(' ');
            }
        }
        protected void delete_shot(Shot shot, List<Enemy> enemies)
        {
            for (int i = 0; i < enemies.Count; ++i)
                if (shot.y == enemies[i].y && shot.x >= enemies[i].x &&
                    shot.x <= enemies[i].x + enemies[i].length)
                {
                    shot.collision = true;
                    enemies[i].life -= 10;
                }
            if ((shot.y < 1 && shot.direction == -1)
                || shot.collision)
            {
                Console.SetCursorPosition(shot.x, shot.y);
                Console.Write(" ");
                shots.Remove(shot);
            }

        }
        protected void delete_shot(Shot shot, Player player)
        {
            if (shot.y == player.y && shot.x >= player.x 
                && shot.x <= player.x + player.length)
            {
                shot.collision = true;
                player.life -= 10;
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
        private int getcannon(string design)
        {
            return design.Length / 2;
        }
    }
}
