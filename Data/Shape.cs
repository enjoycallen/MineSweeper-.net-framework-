using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper
{
    public class Shape
    {
        public int row, col;

        public Shape() { }

        public Shape(int row, int col)
        {
            this.row = row;
            this.col = col;
        }
    }
}
