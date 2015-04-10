using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    static class Stuff
    {
        public static bool TimeAfterTime(ref int days, ref int hours,
                                         ref int mins, ref int sec)
        {
            if (sec > 59 || sec < 0)
            {
                int c = sec % 60;
                if (c < 0)
                    c +=60;

                mins += (sec - c) / 60;
                sec = c;
            }
            if (mins > 59 || mins < 0)
            {
                int c = mins % 60;
                if (c < 0)
                    c += 60;
                hours += (mins - c) / 60;
                mins = c;
            }
            if (hours > 23 || hours < 0)
            {
                int c = hours % 24;
                if (c < 0)
                    c += 24;
                days += (hours - c) / 24;
                hours = c;
            }
            return (days > 0);
        }
    }
}
