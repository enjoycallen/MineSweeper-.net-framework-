using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper
{
    public class Algorithm
    {
        public void swap<T>(ref T a, ref T b)
        {
            (a, b) = (b, a);
        }

        public void random_shuffle<T>(T[] a)
        {
            Random rand = new Random();
            for (int i = 0; i < a.Length; ++i)
            {
                int j = rand.Next(i + 1);
                swap(ref a[i], ref a[j]);
            }
        }

        public T[,] transform1Dto2D<T>(T[] a, int seg)
        {
            T[,] b = new T[a.Length / seg, seg];
            for (int i = 0; i < a.Length; ++i)
            {
                b[i / seg, i % seg] = a[i];
            }
            return b;
        }

        public int StringToInt(string s)
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
    }
}
