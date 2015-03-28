using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTF
{
    class Ex5 : ExX
    {
        #region constructor
        public Ex5()
            : base("Ex5")
        {

        }
        #endregion

        #region methods
        public override string solve(string question)
        {
            string ans = "";
            int startpos = 0;
            int length = 0;
            for (int i = question.Length - 1; i > 0; i--)
            {
                if (question[i] == ' ')
                {
                    startpos = i + 1;
                    ans += question.Substring(startpos, length) + ' ';
                    length = 0;
                }
                else
                    length++;
            }
            return ans + question.Substring(0, length + 1);
        }
        #endregion


    }
}
