using MineSweeper.Dialogs;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace MineSweeper
{
    public partial class MainForm : Form
    {
        public int row, col, mine;
        public Plane plane;

        public MainForm()
        {
            InitializeComponent();
        }

        public void NewGame()
        {
            if(plane != null)
            {
                plane.Dispose();
            }
            plane = new Plane(row, col, mine);
            Size = plane.Size + new Size(100, 100);
            plane.Name = "plane1";
            plane.Location = new Point(40, 50);
            Controls.Add(plane);
        }

        public void win()
        {
            using (var windialog = new WinDialog(plane.time))
            {
                if (windialog.ShowDialog() == DialogResult.Cancel)
                {
                    Close();
                }
            }
            NewGame();
        }

        public void lose()
        {
            using (var losedialog = new LoseDialog(plane.time))
            {
                if (losedialog.ShowDialog() == DialogResult.Cancel)
                {
                    Close();
                }
            }
            NewGame();
        }

        public void 新游戏NToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewGame();
        }

        private void 退出XToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void 查看帮助ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", Properties.Resources.HelpPage);
        }

        private void 关于AToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var about = new AboutDialog())
            {
                about.ShowDialog();
            }
        }

        private void 统计信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var statistics = new StatisticsDialog())
            {
                statistics.ShowDialog();
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            row = col = 9;
            mine = 10;
            新游戏NToolStripMenuItem_Click(sender, e);
        }

        private void 选项OToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var option = new OptionDialog())
            {
                if (option.ShowDialog() == DialogResult.OK)
                {
                    row = option.row;
                    col = option.col;
                    mine = option.mine;
                }
            }
            新游戏NToolStripMenuItem_Click(sender, e);
        }
    }
}
