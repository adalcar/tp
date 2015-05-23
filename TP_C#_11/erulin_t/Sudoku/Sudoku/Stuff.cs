using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    static class Stuff
    {
        public static bool TimeAfterTime(ref int days, ref int hours,
                                         ref int mins, ref int sec)
        {
            if (sec > 59 || sec < 0)
            {
                int c = sec % 60;
                if (c < 0)
                    c +=60;

                mins += (sec - c) / 60;
                sec = c;
            }
            if (mins > 59 || mins < 0)
            {
                int c = mins % 60;
                if (c < 0)
                    c += 60;
                hours += (mins - c) / 60;
                mins = c;
            }
            if (hours > 23 || hours < 0)
            {
                int c = hours % 24;
                if (c < 0)
                    c += 24;
                days += (hours - c) / 24;
                hours = c;
            }
            return (days > 0);
        }

        public static string Compression(string source)
        {
            List<string> dico = new List<string>();
            string a = "";
            string result = "";
            Predicate<string> p = s => s == a;
            for (int i = 0; i < source.Length; i++)
            {
                char c = source[i];
                if (c == ' ' || c == '\n')
                {
                    if (dico.Exists(p))
                    {
                        int ind = dico.FindIndex(s => s == a) + 1;
                        result += ind ;
                        result += c;
                    }

                    else
                    {
                        dico.Add(a);
                        result += a + c;
                    }
                    a = "";
                }
                else
                    a += c; 
                
            }
            if (dico.Exists(p))
            {
                int ind = dico.FindIndex(p) + 1;
                result += ind.ToString();
            }
            else
            {
                dico.Add(a);
                result += a;
            }
            return result;   
        }
        public static string Decompression(string source)
        {
            List<string> dico = new List<string>();
            string result = "";
            string a = "";
            Predicate<string> p = s => s == a;
            for (int i = 0; i < source.Length; i++)
            {
                char c = source[i];
                if (c == ' ' || c == '\n')
                {
                    if (a != "")
                    {
                        int k;
                        if (int.TryParse(a, out k))
                        {
                            if (k < dico.Count)
                                a = dico[k];
                        }
                        else
                            dico.Add(a);

                        result += a;
                        a = "";
                    }
                    result += c;
                }
                else
                    a += c;
            }
            if (a != "")
            {
                int k;
                if (int.TryParse(a, out k))
                {
                    if (k < dico.Count)
                        a = dico[k];
                }
                else
                    dico.Add(a);

                result += a;
                a = "";
            }
            return result;
        }
    }
}
