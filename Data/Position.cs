using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper
{
    public class Position
    {
        public int row, col;

        public Position() { }

        public Position(int row, int col)
        {
            this.row = row;
            this.col = col;
        }
    }
}
