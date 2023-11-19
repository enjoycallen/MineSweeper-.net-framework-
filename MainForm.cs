using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MineSweeper
{
    public partial class MainForm : Form
    {
        private int row, col, mine;
        private Plane plane;

        public MainForm()
        {
            InitializeComponent();
        }

        public void 新游戏NToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (plane != null)
            {
                plane.Dispose();
            }
            Console.WriteLine(row + "," + col + "," + mine);
            plane = new Plane(row, col, mine);
            Size = plane.Size + new Size(60, 100);
            plane.Name = "plane1";
            plane.Location = new Point(20, 40);
            Controls.Add(plane);
        }

        private void 退出XToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            row = col = 9;
            mine = 10;
            新游戏NToolStripMenuItem_Click(sender, e);
        }

        private void 选项OToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OptionForm optionform = new OptionForm())
            {
                if(optionform.ShowDialog()==DialogResult.OK)
                {
                    row = optionform.row;
                    col = optionform.col;
                    mine = optionform.mine;
                }
            }
            新游戏NToolStripMenuItem_Click(sender, e);
        }
    }
}
