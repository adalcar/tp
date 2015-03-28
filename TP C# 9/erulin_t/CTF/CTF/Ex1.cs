using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTF
{
    class Ex1 : ExX
    {
        #region constructor
        public Ex1()
            : base("Ex1")
        {

        }
        #endregion

        #region methods
        public override string solve(string question)
        {
            bool firstcolon = false;
            int p = 0;
            int l = 0;
            string str = "";
            for (int i = 0; i < question.Length; i++)
            {
                if (question[i] == ';')
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
