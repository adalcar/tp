using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTF
{
    class Ex6 : ExX
    {
        #region attributes
        int[] liste;
        #endregion
        #region constructor
        public Ex6()
            : base("Ex6")
        {

        }
        #endregion

        #region methods
        public override string solve(string question)
        {
            char delim = question[0];
            int size = 0;
            for (int i = 0; i < question.Length; i++)
                if (question[i] == delim)
                    size++;
            liste = new int[size];
            int pos = 0;
            int k = 0;

            for (int i = 1; i < question.Length; i++ )
            {
                if (i == question.Length - 1 || question[i + 1] == delim)
                {
                    liste[pos++] = (k * 10 + (question[i] - 48));
                    k = 0;
                }
                else
                    if (question[i] != delim)
                        k = k * 10 + (question[i] - 48);
            }
            sort();
            string ans = "";
            foreach (int i in liste)
                ans += (delim + i.ToString());
            return ans;
        }

        public void sort()
        {
            for (int i = 0; i < liste.Length; i++)
            {
                int s = liste[i];
                int k = i;
                while (k != 0 && liste[k - 1] > s)
                    swap(k, --k);
            }
        }
        public void swap(int a, int b)
        {
            int c = liste[a];
            liste[a] = liste[b];
            liste[b] = c;
        }
        #endregion
    }
}
