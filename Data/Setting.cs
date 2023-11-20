using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper
{
    public class Setting
    {
        public enum Level
        {
            Basic = 1,
            Intermidiate = 2,
            Advanced = 3,
            PlayerDefined = 4
        }

        public Level level;
        public Shape shape;
        public int mine_count;

        public Setting(Level level, Shape shape, int mine_count)
        {
            this.level = level;
            this.shape = shape;
            this.mine_count = mine_count;
        }
    }
}
