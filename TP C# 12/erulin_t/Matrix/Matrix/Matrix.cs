using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    class Matrix<T> where T:new()
    {
        public T[,] table = new T[4, 4];

        public Matrix()
        {
            
        }

        public Matrix(T val)
        {
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    table[i, j] = val;
        }
        public static Matrix<T> operator -(Matrix<T> m1, Matrix<T> m2)
        {
            Matrix<T> result = new Matrix<T>();
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    result.table[i, j] = (dynamic)m1.table[i, j] - (dynamic)m2.table[i, j];
            return result;
        }
        public static Matrix<T> operator +(Matrix<T> m1, Matrix<T> m2)
        {
            Matrix<T> result = new Matrix<T>();
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    result.table[i, j] = (dynamic)m1.table[i, j] + (dynamic)m2.table[i, j];
            return result;
        }
        public static Matrix<T> operator -(Matrix<T> m)
        {
            Matrix<T> result = new Matrix<T>();
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    result.table[i, j] = - (dynamic)m.table[i, j];
            return result;
        }
        public static Matrix<T> operator *(Matrix<T> m1, Matrix<T> m2)
        {
            Matrix<T> result = new Matrix<T>();
            for(int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    for (int k = 0; k < 4; k++)
                        result.table[i, j] = (dynamic)result.table[i, j] + (dynamic)m1.table[i, k] * (dynamic)m2.table[k,j];
            return result;
        }
        public void print()
        {

            Console.Write("_________________\n");
            for (int i = 0; i < 4; i++)
            {
                Console.Write('|');
                for (int j = 0; j < 4; j++)
                    Console.Write(table[i, j].ToString() + " | ");
                Console.Write("\n-----------------\n");
            }
        }
    }
}
