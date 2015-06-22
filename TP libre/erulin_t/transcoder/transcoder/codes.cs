using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace transcoder
{

    class codes
    {
        public static char decalage(char c, int decal)
        {
            if (decal < 0)
                decal = (decal % 26) + 26;
            char ret = ' ';
            if (c < 91 && c > 64)
                ret = (char)((c - 65 + decal) % 26 + 65);
            else
                if (c >= 97 && c < 123)
                ret = (char)((c - 97 + decal) % 26 + 97);
            else ret = c;
            return ret;
        }
        public static int toNum(char c, int decal)
        {
            int ret = 0;
            if (c < 91 && c > 64)
                ret = (c - 65 + decal) % 26;
            else
            if (c >= 97 && c < 123)
                ret = (c - 97 + decal) % 26;
            else ret = c;
            return ret;
        }
        public static string vigenere(string key, string text)
        {
            string output = "";
            int pos = 0;
            foreach(char c in text)
            {
                if (c < 91 && c > 64 || c > 96 && c < 123)
                {
                    output += (char)((charindex(c) - charindex(key[pos % key.Length]) + 26) % 26 + 97);
                    pos++;
                }

                else
                    output += c;
            }
            return output;
        }
        public static Dictionary<char, string> morse = new Dictionary<char, string>
        {
            {'a',".-"   },
            {'b',"-..." },
            {'c',".-.-" },
            {'d',"-.."  },
            {'e',"."    },
            {'f',"..-." },
            {'g',"--."  },
            {'h',"...." },
            {'i',".."   },
            {'j',".---" },
            {'k',"-.-"  },
            {'l',".-.." },
            {'m',"--"   },
            {'n',"-."   },
            {'o',"---"  },
            {'p',".--." },
            {'q',"--.-" },
            {'r',".-."  },
            {'s',"..."  },
            {'t',"-"    },
            {'u',"..-"  },
            {'v',"...-" },
            {'w',".--"  },
            {'x',"-..-" },
            {'y',"-.--" },
            {'z',"--.." },
            {'1',".----"},
            {'2',"..---"},
            {'3',"...--"},
            {'4',"....-"},
            {'5',"....."},
            {'6',"-...."},
            {'7',"--..."},
            {'8',"---.."},
            {'9',"----."},
            {'0',"-----"},
            {' ',""     },
            {'.',""     },
        };
        static int charindex(char c)
        {
            if (c > 64 && c < 91)
                return c - 65;
            if (c > 96 && c < 123)
                return c - 97;
            return c;
        }
    }
}
