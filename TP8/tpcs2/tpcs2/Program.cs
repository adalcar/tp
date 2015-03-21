using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Synthesis;


namespace tpcs2
{

    class Program
    {
        
        static Random rand = new Random();
        static SpeechSynthesizer speech = new SpeechSynthesizer();

        static void Main(string[] args)
        {
            move_vader();
            Console.Read();
        }
         // Exercice 0
        static void who_are_you()
        {
            Console.Write("Please, enter your name \n");
            Console.Write("Hi " + Console.ReadLine() + "!");
            Console.Read();
        }
        static void even_or_odd()
        {
            Console.Write("What is your number? \n");
            int i = Convert.ToInt32(Console.ReadLine());
            if (i % 2 == 0)
                Console.Write("Your number is even");
            else
                Console.Write("Your number is odd");
            Console.Read();
        }

        // Exercice 1
        static void greater_or_lower(int sup)
        {
            int number = rand.Next(sup);
            int tries = 1;
            bool faux = true;
            Console.Write("You have to find a number between 0 and " + sup +"\n");
            Console.Write("You think that number is...? \n");
            while (faux)
            {
                int input = Convert.ToInt32(Console.ReadLine());
                if (input == number)
                    faux = false;
                else
                {
                    if (input < number)
                        Console.Write(" Greater! \n");
                    else
                        Console.Write(" Smaller! \n");
                    tries++;
                }
            }
            Console.Write("Congratulations! The secret number is " + number
                        + " (found after " + tries + " attempts)");
            Console.Read();
        }

        // Exercice 2
        static int my_multiplication( int a, int b)
        {
            int acc = 0;
            for (int i = 1; i <= b; i++)
                acc += a;
            return acc;
        }
        static int my_eucl_div(int a, int b)
        {
            if (b == 0)
                throw new DivideByZeroException();
            int q = 0;
            while (b <= a)
            {
                q++;
                a -= b;
            }
            return q;
        }
        static long my_pow(int n, int pow)
        {
            int acc = 1;
            for (int i = 1; i <= pow; i++)
                acc = my_multiplication(acc, n);
            return acc;
        }
        static float my_abs(float n)
        {
            if (n < 0)
                return -n;
            else
                return n;
        }
        static float my_sqrt(int n)
        {
            if (n == 0)
                return 0;
            float x = 1;
            bool root = false;
            while (!root)
            {
                x = (x + n / x ) / 2;
                root = (my_abs((x*x) - n) <= 0.00001);
            }
                
            return x;
        }
        static long my_fibo_iter(int n)
        {
            int fib1 = 1;
            int fib2 = 1;
            for (int i = 2; i <= n; i++)
            {
                int a = fib1;
                fib1 = fib2;
                fib2 += a;
            }
            return fib2;
        }
        static void jedi_or_sith()
        {
            Console.Write("What is thine name? \n");
            string name = Console.ReadLine();
            if (is_prime(name.Length))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("There is no emotion, there is peace.\n" +
                              "There is no ignorance, there is knowledge.\n" +
                              "There is no passion, there is serenity.\n" +
                              "There is no chaos, there is harmony.\n" +
                              "There is no death, there is the Force.\n \n \n" +
                              "Welcome to the jedi order \n");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Peace is a lie, there is only passion.\n" +
                              "Through passion, I gain strength.\n" +
                              "Through strength, I gain power.\n" +
                              "Through power, I gain victory.\n" +
                              "Through victory, my chains are broken.\n" +
                              "The Force shall free me. \n \n \n" +
                              "Welcome to the dark side of the force");
            }
            Console.Read();
                


        }
        //Exercice 2.boni
        static bool is_prime(int num)
        {
            for (int k = 2; k <= my_sqrt(num); k++)
            {
                if (num % k == 0)
                    return false;
            }
            return true;
        }
        static string my_rotn(int rank, string str)
        {
            string acc = "";
            foreach (char c in str)
            {
                int val = c;
                if (val <= 'Z' && val >= 'A')
                    val = ((val + rank + 26 - 'A') % 26) + 'A';
                else
                    if (val <= 'z' && val >= 'a')
                        val = ((val + rank + 26 - 'a') % 26) + 'a';
                acc += ((char)val).ToString();
            }
            return acc;
        }

        //Exercice 3
        static void print_alpha()
        {
             
            for (int  a = 97; a <= 103; a++)
            {
                string s = ((char)a).ToString();
                
                Console.BackgroundColor += 1;
                Console.ForegroundColor += 1;
                Console.Write(s);
                speech.Speak(s);
            }
            Console.ResetColor();
            Console.Write("\nJe connais mon alphabet");
            speech.Speak("I know my alphabet");
        }

        static void print_vader(string space)
        {
            string[] darth_vader = new string[14] 
            {
                @"         _.-'~~~~~~`-._         ",
                @"        /      ||      \        ",
                @"       /       ||       \       ",
                @"      |        ||        |      ",
                @"      | _______||_______ |      ",
                @"      |/ ----- \/ ----- \|      ",
                @"     /  (     )  (     )  \     ",
                @"    / \  ----- () -----  / \    ",
                @"   /   \      /||\      /   \   ",
                @"  /     \    /||||\    /     \  ",
                @" /       \  /||||||\  /       \ ",
                @"/_        \o========o/        _\",
                @"  `--...__|`-._  _.-'|__...--'  ",
                @"          |    `'    |          ",
            };
            foreach (string s in darth_vader)
            {
                Console.Write(space + s + "\n");
            }
        }
        static void move_up(int x, int y)
        {
            Console.Clear();
            for (int i = 0; i < y - 1; i++)
                Console.Write("\n");
            string s = "";
            for (int i = 0; i < x; i++)
                s += " ";
            print_vader(s);
        }
        static void move_down(int x, int y)
        {
            Console.Clear();
            for (int i = 0; i < y + 1; i++)
                Console.Write("\n");
            string s = "";
            for (int i = 0; i < x; i++)
                s += " ";
            print_vader(s);
        }
        static void move_right(int x, int y)
        {
            Console.Clear();
            for (int i = 0; i < y; i++)
                Console.Write("\n");
            string s = "";
            for (int i = 0; i < x + 1; i++)
                s += " ";
            print_vader(s);
        }
        static void move_left(int x, int y)
        {

            Console.Clear();
            for (int i = 0; i < y; i++)
                Console.Write("\n");
            string s = "";
            for (int i = 0; i < x - 1; i++)
                s += " ";
            print_vader(s);
        }
        
        static void move_vader()
        {
            print_vader("");
            int x = 0;
            int y = 0;
            while (true)
            {
                switch (Console.ReadKey().KeyChar)
                {
                    case 'w':
                        if (y != 0)
                        {
                            move_up(x,y);
                            y--;
                        }
                        else
                            move_down(x, y - 1);
                        break;
                    case 'a' :
                        if (x != 0)
                        {
                            move_left(x, y);
                            x--;
                        }
                        else
                            move_down(x, y - 1);
                        break;
                    case 's':
                        if (y + 14 != Console.WindowHeight)
                        {
                            move_down(x, y);
                            y++;
                        }
                        else
                            move_down(x, y - 1);
                        break;
                    case 'd':
                        if (x + 33 != Console.WindowWidth)
                        {
                            move_right(x, y);
                            x++;
                        }
                        else
                            move_down(x, y - 1);
                        break;
                    default:
                        move_down(x, y - 1);
                        break;


                }
            }


        }




    }
}
