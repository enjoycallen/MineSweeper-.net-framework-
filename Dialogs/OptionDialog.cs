using System;
using System.Windows.Forms;

namespace MineSweeper
{
    public partial class OptionDialog : Form
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

        public OptionDialog()
        {
            InitializeComponent();
        }

        public void user_defined_radioButton_CheckedChanged(object sender, EventArgs e)
        {
            mode = GameMode.UserDefined;
            height_textBox.Enabled = width_textBox.Enabled = mine_textBox.Enabled = user_defined_radioButton.Checked;
            
        }

        public void cancel_button_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        public void confirm_button_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        public void textBox_KeyPress(object sender, KeyPressEventArgs e)
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

        public void basic_radioButton_CheckedChanged(object sender, EventArgs e)
        {
            mode = GameMode.Basic;
        }

        public void OptionForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.Cancel)
            {
                return;
            }
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
                row = Algorithm.StringToInt(height_textBox.Text);
                col = Algorithm.StringToInt(width_textBox.Text);
                mine = Algorithm.StringToInt(mine_textBox.Text);
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
                else if (mine < 10 || mine > 0.35 * row * col)
                {
                    MessageBox.Show("雷数必须在10-" + (int)(0.35 * row * col) + "之间！", "扫雷-选项", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    e.Cancel = true;
                }
            }
        }

        public void intermediate_radioButton_CheckedChanged(object sender, EventArgs e)
        {
            mode = GameMode.Intermidiate;
        }

        public void advanced_radioButton_CheckedChanged(object sender, EventArgs e)
        {
            mode = GameMode.Advanced;
        }
    }
}
