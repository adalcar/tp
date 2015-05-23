using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTF
{
    class ExB : ExX
    {
        #region attributes
        Client c;
        #endregion
        #region constructor
        public ExB(Client c)
            : base("ExB")
        {
            this.c = c;
        }
        #endregion
        #region methods
        public override string solve(string question)
        {
            c.send(c.login + "|" + name + ":1000");
            int first = string_to_int(c.receive().Substring(3));
            c.send(c.login + "|" + name + ":1000");
            int second = string_to_int(c.receive().Substring(3));
            int last = second + (second - first);
            return last.ToString();
        }
        public int string_to_int(string s)
        {
            int i = 0;
            for (int k = 0; k < s.Length; k++)
                i = i * 10 + s[k] - 48;
            return i;
        }
        #endregion
    }
}
