using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    class Sudoku
    {
        int[,] grid = new int[9,9];
        Random rand = new Random();
        public Sudoku(bool GetfromUser = false)
        {
            if (GetfromUser)
                IO.LoadFile(grid);
            else
            {
                Init(0);
                RandomlyFill(20);
            }
        }

        public bool save()
        {
            ConsoleKeyInfo k;
            do
            {
                Console.WriteLine("do you want to save your grid? (y/n)");

                do
                {
                    k = Console.ReadKey(true);
                }
                while (k.KeyChar != 'y' && k.KeyChar != 'n');
            }
            while (k.KeyChar == 'y' && !IO.SaveFile(grid));
            return k.KeyChar == 'y';
        }
        public void Init(int init)
        {
            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                    grid[i, j] = init;
        }
        public void Print()
        {
            Console.Clear();
            Console.WriteLine("+-----------------------+");
            for (int i = 0; i < 9; i++ )
            {
                if (i == 3 || i == 6)
                    Console.WriteLine("+-------+-------+-------+");
                Console.Write("| ");
                for(int j = 0; j < 9; j++ )
                {
                    if (j == 3 || j == 6)
                        Console.Write("| ");
                    Console.Write(grid[i,j] + " ");
                }
                Console.Write("|\n");
            }
            Console.WriteLine("+-----------------------+");
        }
        private void RandomlyFill(int nb)
        {
            while (nb != 0)
            {
                int x = rand.Next(9);
                int y = rand.Next(9);
                if (grid[y,x] == 0)
                {
                    List<int> possibleints = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
                    GetLinePossibleNumbers(ref possibleints, y);
                    GetColumnPossibleNumbers(ref possibleints, x);
                    GetRegionPossibleNumbers(ref possibleints, y, x);
                    if (possibleints.Count != 0)
                    {
                        int num = rand.Next(possibleints.Count);
                        grid[y, x] = possibleints[num];
                        nb--;
                    }
                }
            }
        }

        void GetLinePossibleNumbers(ref List<int> numlist, int line)
        {
            for (int k = 0; k < 9; k++)
            {
                if (numlist.Contains(grid[line, k]))
                    numlist.Remove(grid[line, k]);
            }
        }
        void GetColumnPossibleNumbers(ref List<int> numlist, int column)
        {
            for (int k = 0; k < 9; k++)
            {
                if (numlist.Contains(grid[k, column]))
                    numlist.Remove(grid[k, column]);
            }
        }
        void GetRegionPossibleNumbers(ref List<int> numlist, int line, int column)
        {
            int baseY = line / 3 * 3;
            int baseX = column / 3 * 3;
            for (int k = 0; k < 9; k++)
            {
                if (numlist.Contains(grid[baseY + k / 3, baseX + k % 3]))
                    numlist.Remove(grid[baseY + k / 3, baseX + k % 3]);
            }
        }
        void GetMinList(ref List<int> minList, ref int xIndex, ref int yIndex)
        {
            int minsize = 9;
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (grid[i, j] == 0)
                    {
                        List<int> l = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
                        GetLinePossibleNumbers(ref l, i);
                        GetColumnPossibleNumbers(ref l, j);
                        GetRegionPossibleNumbers(ref l, i, j);
                        if (minsize > l.Count)
                        {
                            xIndex = j;
                            yIndex = i;
                            minsize = l.Count;
                            minList = l;
                        }
                    }
                }
            }
        }
        bool isFinished()
        {
            bool finished = true;
            
            for (int x = 0; x < 9; x++ )
            {
                List<int> tests = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
                GetLinePossibleNumbers(ref tests, x);
                finished = finished && tests.Count == 0;
            }
            for (int x = 0; x < 9; x++)
            {
                List<int> tests = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
                GetColumnPossibleNumbers(ref tests, x);
                finished = finished && tests.Count == 0;
            }
            for (int x = 0; x < 9; x++)
            {
                List<int> tests = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
                GetRegionPossibleNumbers(ref tests, (x / 3) * 3, (x % 3) * 3);
                finished = finished && tests.Count == 0;
            }
            return finished;
        }
        
        public bool solve()
        {
            if (isFinished())
                return true;
            List<int> l = new List<int>();
            int x = 0;
            int y = 0;
            bool b;
            do
            {
                x = 0;
                y = 0;
                l = new List<int>();
                GetMinList(ref l, ref x, ref y);
                b = l.Count == 1;
                if (b)
                    grid[y,x] = l[0];
                Print();
            }
            while (b);
            int[,] backup = grid;

            foreach (int i in l)
            {
                grid[y, x] = i;
                Print();
                if (solve())
                    return true;
            }
            grid = backup;
            return false;
            

        }
    }
}
