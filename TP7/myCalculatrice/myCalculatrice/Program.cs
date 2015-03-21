using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myCalculatrice
{
    class Program
    {
        static void Main(string[] args)
        {
            get_calcul();
        }


        static int my_pow(int x, int n)
        {
            int acc = 1;
            for (int i = 1; i <= n; i++ )
                acc *= x;

            return acc;
        }
        static int my_fact(int n)
        {
            int acc = 1;
            for (int i = n; i > 0; i--)
                acc *= i;
            return acc;
        }
        static int my_fibo (int n)
        {
            int prev = 1;
            int fib = 1;
            if (n <= 1)
                return 1;
            else
            {
                int acc = 1;
                while (acc < n)
                {
                    int a = prev;
                    prev = fib;
                    fib += a;
                    acc++;
                }
                return fib;
            }
        }
        static int my_pgcd(int a, int b)
        {
            if (b > a)
            {
                int d = a;
                a = b;
                b = d;
            }
            int c = a % b;
            if (c == 0)
                return b;
            else
                return my_pgcd(b, c);
        }
        static int ackermann (int m, int n)
        {
            if (m == 0)
                return (n + 1);
            else
            {
                if (n == 0)
                    return ackermann(m - 1, 1);
                else
                    return ackermann(m - 1, ackermann(m, n - 1));
            }
                
        }
        static void get_calcul()
        {
            switch (System.Console.ReadLine())
            {
                case "quit" :
                    break;
                case "my_pow" :
                    System.Console.WriteLine("x?");
                    int x = Convert.ToInt32(System.Console.ReadLine());
                    System.Console.WriteLine("n?");
                    int n = Convert.ToInt32(System.Console.ReadLine());
                    System.Console.WriteLine(my_pow(x,n));
                    get_calcul();
                    break;
                case "my_fact" :
                    System.Console.WriteLine("n?");
                    n = Convert.ToInt32(System.Console.ReadLine());
                    System.Console.WriteLine(my_fact(n));
                    get_calcul();
                    break;
                case "my_fibo" :
                    System.Console.WriteLine("n?");
                    n = Convert.ToInt32(System.Console.ReadLine());
                    System.Console.WriteLine(my_fibo(n));
                    get_calcul();
                    break;
                case "my_pgcd" :
                    System.Console.WriteLine("a?");
                    int a = Convert.ToInt32(System.Console.ReadLine());
                    System.Console.WriteLine("b?");
                    int b = Convert.ToInt32(System.Console.ReadLine());
                    System.Console.WriteLine(my_pgcd(a,b));
                    get_calcul();
                    break;
                case "ackermann" :
                    System.Console.WriteLine("m?");
                    int m = Convert.ToInt32(System.Console.ReadLine());
                    System.Console.WriteLine("n?");
                    n = Convert.ToInt32(System.Console.ReadLine());
                    System.Console.WriteLine(ackermann(m,n));
                    get_calcul();
                    break;
                default :
                    System.Console.WriteLine("mauvaise fonction, taper \"quit\" pour quitter");
                    get_calcul();
                    break;
            }
            Console.Read();
        }
    }
}
