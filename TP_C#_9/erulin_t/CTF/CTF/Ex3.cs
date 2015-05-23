using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTF
{
    class Ex3 : ExX
    {
        #region constructor
        public Ex3()
            : base("Ex3")
        {

        }
        #endregion

        #region methodes
        public override string solve(string question)
        {
            bool n1 = true;
            int num1 = 0;
            int num2 = 0;
            for (int i = 0; i < question.Length; i++ )
            {
                if (question[i] == '+')
                    n1 = false;
                else
                {
                    if (n1)
                        num1 = num1 * 10 + (question[i] - 48);
                    else
                        num2 = num2 * 10 + (question[i] - 48);
                }
            }
            return (num1 + num2).ToString();


        }
        #endregion
    }
}
