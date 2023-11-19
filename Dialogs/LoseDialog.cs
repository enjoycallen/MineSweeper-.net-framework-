using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MineSweeper.Dialogs
{
    public partial class LoseDialog : Form
    {
        public MainForm mainform;
        public LoseDialog(int time)
        {
            InitializeComponent();
            time_label.Text = time.ToString() + "秒";
            date_label.Text = DateTime.Now.ToString();
        }

        private void exit_button_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void replay_button_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void LoseDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (player_textBox.Text == "")
            {
                MessageBox.Show("玩家名称不能为空！", "扫雷", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Cancel = true;
                return;
            }

        }
    }
}
