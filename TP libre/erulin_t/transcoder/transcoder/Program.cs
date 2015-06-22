using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace transcoder
{
    class Program
    {
        static void Main(string[] args)
        {
            bool good = true;
            while (good)
            {
                Console.Clear();
                Console.WriteLine("Bienvenue sur le transcodeur 1.0 \n" +
                                  "Pour commencer,\nveuillez glisser un fichier sur la console,\npuis appuyer sur 'enter'");
                string input = Console.ReadLine().Trim('"');
                Console.WriteLine("entrez le nom du fichier de sortie");
                string output = Path.GetDirectoryName(input) +"\\" + Console.ReadLine() + ".txt";
                Console.Clear();
                traduction.translate(input, output);
                Console.WriteLine("Traduction terminee, autre chose? \n y/n");
                bool ok = false;
                while (!ok)
                {
                    char c = Console.ReadKey(true).KeyChar;
                    if (c == 'y')
                    {
                        ok = true;
                    }
                    if (c == 'n')
                    {
                        ok = true;
                        good = false;
                    }
                }
            }
            
        }
    }
}
