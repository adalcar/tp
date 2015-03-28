using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTF
{
    class Ex4 : ExX
    {
        #region constructor
        public Ex4()
            : base("Ex4")
        {

        }
        #endregion

        #region methodes
        public override string solve(string question)
        {
            char op = question[0];
            bool n1 = true;
            int num1 = 0;
            int num2 = 0;
            for (int i = 1; i < question.Length; i++)
            {
                if (question[i] == op)
                    n1 = false;
                else
                {
                    if (n1)
                        num1 = num1 * 10 + (question[i] - 48);
                    else
                        num2 = num2 * 10 + (question[i] - 48);
                }
            }
            switch (op)
            {
                case '+':
                    return (num1 + num2).ToString();
                case '*':
                    return (num1 * num2).ToString();
                case '/':
                    return (num1 / num2).ToString();
                case '-':
                    return (num1 - num2).ToString();
                default:
                    return (num1 % num2).ToString();

            }
        }
        #endregion
    }

}
