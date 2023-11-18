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
        

        public MainForm()
        {
            InitializeComponent();
        }

        public void 新游戏NToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Plane plane = new Plane(16, 16, 40);
            Size = plane.Size + new Size(60, 100);
            plane.Name = "plane1";
            plane.Location = new Point(20, 40);
            plane.Parent = this;
        }

        private void 退出XToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            新游戏NToolStripMenuItem_Click(sender, e);
        }
    }
}
