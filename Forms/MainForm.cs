using MineSweeper.Dialogs;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace MineSweeper
{
    public partial class MainForm : Form
    {
        public Setting setting { get; set; }
        public Game game { get; set; }
        public Ranking basicRanking { get; set; }
        public Ranking intermidiateRanking { get; set; }
        public Ranking advancedRanking { get; set; }
        
        public MainForm()
        {
            InitializeComponent();
        }
        private void LoadGame()
        {
            Size = game.Size + new Size(100, 100);
            Controls.Add(game);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Archive.Load(this);
            LoadGame();
        }


        public void NewGame()
        {
            if (game != null)
            {
                game.Dispose();
            }
            game = new Game(setting);
            LoadGame();
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

        private void 选项OToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var option = new OptionDialog(setting))
            {
                if (option.ShowDialog() == DialogResult.OK)
                {
                    setting = option.setting;
                    NewGame();
                }
            }
        }
    }
}
