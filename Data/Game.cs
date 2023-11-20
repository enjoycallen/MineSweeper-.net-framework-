using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MineSweeper
{
    public partial class Game
    {
        public Setting setting;
        public Grid[,] plane;
        public bool started;
        public int time;

        public Grid focus_grid;
        public MouseButtons mouse_state = MouseButtons.None;
        public PictureBox clock_pictureBox, mine_pictureBox;
        public Label clock_status, mine_status;
        public Timer timer;
    }
}
