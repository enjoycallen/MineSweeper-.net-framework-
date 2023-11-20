using MineSweeper.Dialogs;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace MineSweeper
{
    public partial class MainForm : Form
    {
        public Setting setting;
        public Game game;

        public MainForm()
        {
            InitializeComponent();
        }

        public void NewGame()
        {
            if(game != null)
            {
                game.terminate();
            }
            game = new Game(setting);
            Size = game.Size + new Size(100, 100);
            Controls.Add(game);
        }

        public void win()
        {
            using (var windialog = new WinDialog(game.time))
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
            using (var losedialog = new LoseDialog(game.time))
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

        private void LoadGame()
        {
            using (Reader reader = new Reader())
            {
                for (int i = 0; i < 3; ++i)
                {
                    reader.ReadRanking();
                }
                game = reader.ReadGame();
                setting = game.setting;
            }
            
            game.Disposed += Terminate;
            Size = game.Size + new Size(100, 100);
            Controls.Add(game);
        }

        private void Terminate(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (File.Exists(Properties.Resources.ArchiveFile))
            {
                LoadGame();
            }
            else
            {
                setting = new Setting(Setting.Level.Basic, new Shape(9, 9), 10);
                NewGame();
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
