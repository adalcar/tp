using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace strtok
{
    abstract class ExX
    {
        #region attributes
        public string name { public get; private set; }
        #endregion

        #region Constructors
        public ExX(string name)
        {
            this.name = name;
        }
        #endregion

        #region methods
        public abstract string solve(string question);
        #endregion
    }
}
