using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            Tree<int>.CompType comp = delegate(int x,int y){ return x - y;};
            Tree<int> t = new Tree<int>(comp, 4);
            t.add_left_son(5);
            t.add_right_son(6);
            t.node.Fils_gauche.add_left_son(7);
            Tree<int>.mapfunction map = delegate(ref int x) { Console.WriteLine(x); };

            t.depth_first_transversal(map);
            t.breadth_first_transversal(map);
            Console.Read();
        }
    }
}
