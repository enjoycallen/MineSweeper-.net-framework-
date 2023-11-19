using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MineSweeper
{
    public partial class OptionForm : Form
    {
        public enum GameMode
        {
            Basic = 1,
            Intermidiate = 2,
            Advanced = 4,
            UserDefined = 8
        }

        public GameMode mode;
        public int row, col, mine;

        public OptionForm()
        {
            InitializeComponent();
        }

        private void user_defined_radioButton_CheckedChanged(object sender, EventArgs e)
        {
            mode = GameMode.UserDefined;
            height_textBox.Enabled = width_textBox.Enabled = mine_textBox.Enabled = user_defined_radioButton.Checked;
        }

        private void cancel_button_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void confirm_button_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || e.KeyChar == 8)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void basic_radioButton_CheckedChanged(object sender, EventArgs e)
        {
            mode = GameMode.Basic;
        }

        private void OptionForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (mode == GameMode.Basic)
            {
                row = col = 9;
                mine = 10;
            }
            else if (mode == GameMode.Intermidiate)
            {
                row = col = 16;
                mine = 40;
            }
            else if (mode == GameMode.Advanced)
            {
                row = 16;
                col = 30;
                mine = 99;
            }
            else
            {
                Algorithm algorithm = new Algorithm();
                row = algorithm.StringToInt(height_textBox.Text);
                col = algorithm.StringToInt(width_textBox.Text);
                mine = algorithm.StringToInt(mine_textBox.Text);
                if (row < 9 || row > 24)
                {
                    MessageBox.Show("高度必须在9-24之间！", "扫雷-选项", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    e.Cancel = true;
                }
                else if (col < 9 || col > 30)
                {
                    MessageBox.Show("宽度必须在9-24之间！", "扫雷-选项", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    e.Cancel = true;
                }
                else if (mine < 10 || mine > 0.8 * row * col)
                {
                    MessageBox.Show("雷数必须在10-" + (int)(0.8 * row * col) + "之间！", "扫雷-选项", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    e.Cancel = true;
                }
            }
        }

        private void intermediate_radioButton_CheckedChanged(object sender, EventArgs e)
        {
            mode = GameMode.Intermidiate;
        }

        private void advanced_radioButton_CheckedChanged(object sender, EventArgs e)
        {
            mode = GameMode.Advanced;
        }
    }
}
