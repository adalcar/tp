using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace printMe
{
    class Program
    {
        
        public static Random r = new Random();
        public static string[] rooftab = new string[7] 

        {
                            "         $  ",
                            "     /\\  _  ",
                            "    /  \\| | ",
                            "   /    \\ | ",
                            "  /  _   \\| ",
                            " /  /O\\   \\ ",
                            "/__________\\" 
        };
        public static string[] floor1tab = new string[4] 
        {
                            "|  _______ |",
                            "|  |-|-|-| |",
                            "|  ------- |",
                            "|__________|",
        };
        public static string[] floor2tab = new string[4] 
        {
                            "|  _    _  |",
                            "| /0\\  /0\\ |",
                            "|  -    -  |",
                            "|__________|",
        };
        public static string[] floor3tab = new string[4]
        {
                            "|  _    _  |",
                            "| |+|  |+| |",
                            "|  -    -  |",
                            "|__________|",
        };
        public static string[] groundtab = new string[3]
        {
                            "|   _      |",
                            "|  | |     |",
                            "|__|-|_____|",
        };


        static void Main(string[] args)
        {
            upgradedstreet();
        }
         
        static void basicstreet(int length, int heigth)
        {
            foreach (string s in rooftab)
            {
                for (int i = 1; i <= length; i++)
                    Console.Write(s);
                Console.Write("\n");
            }
            for (int c = 1; c <= heigth; c++)
            {
                switch (r.Next(3))
                {
                    case 0:
                        foreach (string s in floor1tab)
                        {
                            for (int i = 1; i <= length; i++)
                                Console.Write(s);
                            Console.Write("\n");
                        }
                        break;
                    case 1:
                        foreach (string s in floor2tab)
                        {
                            for (int i = 1; i <= length; i++)
                                Console.Write(s);
                            Console.Write("\n");
                        }

                        break;
                    case 2:
                        foreach (string s in floor3tab)
                        {
                            for (int i = 1; i <= length; i++)
                                Console.Write(s);
                            Console.Write("\n");
                        }

                        break;
                }
            }

            foreach (string s in groundtab)
            {
                for (int i = 1; i <= length; i++)
                    Console.Write(s);
                Console.Write("\n");
            }

        }
        static void upgradedstreet()
        {
            Console.Write("how long is the street? \n");
            int length = Convert.ToInt32(Console.ReadLine());
            Console.Write("how high can it get? \n");
            int heigth = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            upgradedstreetbuilder(length, heigth);
            Console.Read();

        }
        static void upgradedstreetbuilder(int length, int max_heigth)
        {
            Console.WindowWidth = 12 * length +1;
            Console.WindowHeight = max_heigth * 4 + 11;
            house[] street = new house[length];

            for (int n = 0; n < length; n++)
                street[n] = new house(max_heigth, n+1);

            int index = 0;
            foreach(string s in street[1].building)
            {
                for (int n = 0; n < length; n++)
                    Console.Write(street[n].building[index]);
                Console.Write("\n");
                index++;
            }
        }
        public static void roof()
        {
            foreach (string r in rooftab)
            {
                Console.Write(r + "\n");
            }
            
        }
        public static void floor()
        {
            switch (r.Next(3))
            {

                case 0 :
                    foreach (string s in floor1tab)
                        Console.Write(s + "\n");
                    break;
                case 1 :
                    foreach (string s in floor2tab)
                        Console.Write(s + "\n");
                    break;
                case 2 :
                    foreach (string s in floor3tab)
                        Console.Write(s + "\n");
                    break;
            }
        }
        public static void ground()
        {
            foreach (string s in groundtab)
                Console.Write(s + "\n");
        }
        public static void house()
        {
            roof();
            floor();
            ground();
        }
        public static void custom(int nb_floor)
        {
            roof();
            for (int i = 1; i <= nb_floor; i++)
                floor();
            ground();
        }
            
    }
}
