using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lipogramme
{
    class Program
    {
        static int i;

        static void Main(string[] args)
        {
            System.Console.Write("what do you want to test? \n");
            string test = System.Console.ReadLine();
            System.Console.Write(lipogramme(test));
            Console.Read();
        }
        
        static bool lipogramme(string str)
        {
            int lettre = increment();
            if (lettre == str.Length)
            {
                return true;
            }
            else
            {
                if ((str[lettre] == 'e') || (str[lettre] == 'E'))
                {   
                    return false;
                }
                else
                {
                    return lipogramme(str);
                }
            }  
        }

        static int increment()
        {
            return i++;
        }        

        
    }
}
