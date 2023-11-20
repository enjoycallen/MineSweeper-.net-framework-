using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper
{
    public static class Algorithm
    {
        public static void Swap<T>(ref T a, ref T b)
        {
            (a, b) = (b, a);
        }

        public static void RandomShuffle<T>(T[] a)
        {
            Random rand = new Random();
            for (int i = 0; i < a.Length; ++i)
            {
                int j = rand.Next(i + 1);
                Swap(ref a[i], ref a[j]);
            }
        }

        public static int StringToInt(string str)
        {
            return str == "" ? 0 : int.Parse(str);
        }

        public static Shape MatrixShape<T>(T[,] matrix)
        {
            return new Shape(matrix.GetLength(0), matrix.GetLength(1));
        }

        public static bool InMatrix<T>(T[,] matrix, Position position)
        {
            var shape = MatrixShape(matrix);
            return position.row >= 0 && position.row < shape.row && position.col >= 0 && position.col < shape.col;
        }

        public static List<T> MatrixNeightbour<T>(T[,] matrix, Position position)
        {
            int[] dx = { -1, -1, -1, 0, 0, 1, 1, 1 }, dy = { -1, 0, 1, -1, 1, -1, 0, 1 };
            var list = new List<T>();
            for (int i = 0; i < 8; ++i)
            {
                var pos = new Position(position.row + dx[i], position.col + dy[i]);
                if (InMatrix(matrix, pos))
                {
                    list.Add(matrix[pos.row, pos.col]);
                }
            }
            return list;
        }
    }
}
