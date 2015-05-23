using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTF
{
    class Ex2 : ExX
    {
        #region constructor
        public Ex2()
            : base("Ex2")
        {

        }
        #endregion

        #region methods
        public override string solve(string question)
        {
            char delim = question[0];
            bool firstcolon = false;
            int p = 0;
            int l = 0;
            string str = "";
            for (int i = 1; i < question.Length; i++)
            {
                if (question[i] == delim)
                {
                    if (firstcolon)
                        str = question.Substring(p, l);
                    else
                    {
                        firstcolon = true;
                        p = i + 1;
                    }
                }
                else
                    if (firstcolon)
                        l++;
                        
            }
            return str;
        }
        #endregion
    }
}
