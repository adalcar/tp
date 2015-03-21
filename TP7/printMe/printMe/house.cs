using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace printMe
{
    class house 
    {
        private int floors;
        private int total_size;
        private int heigth;
        private int empty_space;
        public string[] building;

        public house(int max_size, int numero)
        {
            
            floors = Program.r.Next(max_size + 1);
            total_size = max_size * 4 + 10;
            heigth = floors * 4 + 10;
            empty_space = total_size - heigth;
            building = new string[total_size];

            int h = 0;
            while (h < empty_space) 
            {
                building[h] = "            ";
                h++;
            }
                
            foreach (string s in Program.rooftab)
            {
                building[h] = s;
                h++;
            }
            for (int a = 0; a < floors; a++)
            {
                foreach (string s in get_floor())
                {
                    building[h] = s;
                    h++;
                }
            }
            if (numero<10)
                building[h] = "|   _ " + numero.ToString() + "    |";
            else
                building[h] = "|   _ " + numero.ToString() + "   |";
            building[h + 1] = "|  |-|     |";
            building[h + 2] = "|__|-|_____|"; 
        }
        public static string[] get_floor()
        {
            switch (Program.r.Next(3))
            {
                case 0:
                    return Program.floor1tab;
                case 1:
                    return Program.floor2tab;
                case 2:
                    return Program.floor3tab;
                default:
                    return new string[1];

            }

        }
        

    }
}
