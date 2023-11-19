using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper
{
    public class Config
    {
        public enum Mode
        {
            Basic = 1,
            Intermidiate = 2,
            Advanced = 4,
            UserDefined = 8
        }

        public Mode mode;
        public int row, col;
        
    }
}
