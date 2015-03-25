using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tiny42sh
{
    enum Keyword
    {
        ls,
        cd,
        cat,
        touch,
        rm,
        rmdir,
        mkdir,
        pwd,
        clear,
        whoami,
        unknown,
        crash,
    }


    static class Interpreter
    {
        public static string[][] parse_input(string input)
        {
            string[][] ret;
            if (input[input.Length - 1] != ';')
            {
                Console.WriteLine("Error: invalid input: must end with ';'");
                ret = new string[1][];
                ret[0] = new string[1] { "crash" };
                return ret;
            }
            int a = 0;
            int b = 0;
            int c = 0;
            #region initA

            for (int k = 0; k < input.Length; k++)
            {
                if (input[k] == ' ' && c != 0)
                {
                        c = 0;
                        b++;
                }
                if (input[k] == ';' && (b != 0 || c != 0))
                {
                    a++;
                    b = 0;
                    c = 0;
                }
                
                if(input[k] != ';' && input[k] != ' ')
                    c++;

            }
            #endregion
            ret = new string[a][];

            #region initB
            b = 0;
            a = 0;
            c = 0;
            for (int k = 0; k < input.Length; k++)
            {
                if (c != 0)
                {
                    if (input[k] == ' ')
                    {
                        c = 0;
                        b++;
                    }
                    if (input[k] == ';' && (c != 0 || b != 0))
                    {
                        ret[a++] = new string[++b];
                        b = 0;
                        c = 0;
                    }
                }
                if (input[k] != ';' && input[k] != ' ')
                    c++;
            }
            #endregion

            #region fillRet

            a = 0; 
            b = 0;
            string s = "";
            
            for (int k = 0; k < input.Length; k++)
            {
                if (s != "")
                {
                    if (input[k] == ' ')
                    {
                        ret[a][b] = s;
                        s = "";
                        b++;
                    }
                    if (input[k] == ';' && (b != 0 || s != ""))
                    {
                        ret[a][b] = s;
                        a++;
                        b = 0;
                        s = "";
                    }
                }
                if (input[k] != ';' && input[k] != ' ')
                    s += input[k];
            }
            #endregion
            return ret;
        }

        public static Keyword is_keyword(string word)
        {
            try
            {
                return (Keyword)(Enum.Parse(typeof(Keyword), word));
            }
            catch
            {
                return Keyword.unknown;
            }
        }
    }
}
