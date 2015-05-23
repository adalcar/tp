using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvader
{
    class Shot
    {
        public string design;
        public int x;
        public int y;
        public int direction;
        public bool collision;

        public Shot(string design, int x, int y, int direction)
        {
            this.x = x;
            this.y = y;
            this.design = design;
            this.direction = direction;
            collision = false;
        }
        public void update(int time)
        {
            if (time % 10 == 0)
            {
                y += direction;
                print();
            }
        }
        public void print()
        {

            Console.SetCursorPosition(x, y);
            Console.Write(design);
            Console.SetCursorPosition(x, y - direction);
            Console.Write(' ');
        }
    }
}
