using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Sudoku
{
    static class IO
    {
        private static bool FileToTab(string filename, int[,] tab)
        {
            try
            {
                StreamReader s = new StreamReader(filename);
                int i = 0;
                string input = s.ReadToEnd();
                s.Close();
                int pos = 0;
                while (pos != input.Length)
                {
                    if (input[pos] >= 48 && input[pos] < 58)
                    {
                        tab[i / 9, i % 9] = input[pos] - 48;
                        i++;
                    }
                    pos++;
                }
                return i == 81;
            }
            catch { return false; }
        }
        public static void LoadFile(int[,] tab)
        {
            Console.WriteLine("Input file name");
            while (!FileToTab(Console.ReadLine(), tab))
                Console.WriteLine("invalid input! please choose another file!");
        }
        public static bool SaveFile(int[,] tab)
        {
            Console.WriteLine("Choose file name");
            string file = Console.ReadLine();
            if (File.Exists(file))
            {
                Console.WriteLine("Do you want to overwrite this file? (y/n)");
                ConsoleKeyInfo k;
                do
                {
                    k = Console.ReadKey(true);
                }
                while (k.KeyChar != 'y' && k.KeyChar != 'n');
                if (k.KeyChar == 'y')
                    try
                    {
                        StreamWriter s = new StreamWriter(file, false);
                        foreach (int i in tab)
                            s.Write(i + " ");
                        s.Close();
                        return true;
                    }
                    catch
                    {
                        return false;
                    }
                else
                    return false;
            }
            else
            {
                StreamWriter s = new StreamWriter(file, true);
                foreach (int i in tab)
                    s.Write(i + " ");
                s.Close();
                return true;
            }
        }

    }
}
