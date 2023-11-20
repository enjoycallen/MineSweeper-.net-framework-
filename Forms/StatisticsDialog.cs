﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MineSweeper.Dialogs
{
    public partial class StatisticsDialog : Form
    {
        public Ranking basic, intermidiate, advanced;

        public StatisticsDialog()
        {
            InitializeComponent();
        }

        private void level_listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            rank_label.Text = "排名\t玩家名称\t用时(秒)\t日期\n";
            if (level_listBox.SelectedIndex == 0 && basic != null)
            {
                rank_label.Text += basic.ToString();
            }
            else if (level_listBox.SelectedIndex == 1 && intermidiate != null)
            {
                rank_label.Text += intermidiate.ToString();
            }
            else if (level_listBox.SelectedIndex == 2 && advanced != null)
            {
                rank_label.Text += advanced.ToString();
            }
        }

        private void StatisticsDialog_Load(object sender, EventArgs e)
        {
            if (File.Exists(Properties.Resources.ArchiveFile))
            {
                using (Reader reader = new Reader())
                {
                    basic = reader.ReadRanking();
                    intermidiate = reader.ReadRanking();
                    advanced = reader.ReadRanking();
                }
            }
        }
    }
}