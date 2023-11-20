using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        public static int StringToInt(string s)
        {
            string str = "";
            foreach(char c in s)
            {
                if (!char.IsDigit(c))
                {
                    break;
                }
                str += c;
            }
            if (str == "")
            {
                return 0;
            }
            return int.Parse(str);
        }

        public static List<T> MatrixNeightbour<T>(T[,] a, int r, int c)
        {
            int[] dx = { -1, -1, -1, 0, 0, 1, 1, 1 }, dy = { -1, 0, 1, -1, 1, -1, 0, 1 };
            int row = a.GetLength(0), col = a.GetLength(1);
            var list = new List<T>();
            for (int i = 0; i < 8; ++i)
            {
                int x = r + dx[i], y = c + dy[i];
                if (x >= 0 && x < row && y >= 0 && y < col)
                {
                    list.Add(a[x, y]);
                }
            }
            return list;
        }
    }
}
