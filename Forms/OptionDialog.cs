using System;
using System.Windows.Forms;

namespace MineSweeper
{
    public partial class OptionDialog : Form
    {
        public Setting setting;

        public OptionDialog(Setting setting)
        {
            InitializeComponent();
            this.setting = setting;
            if (setting.level == Setting.Level.Basic)
            {
                basic_radioButton.Checked = true;
            }
            else if (setting.level == Setting.Level.Intermidiate)
            {
                intermediate_radioButton.Checked = true;
            }
            else if (setting.level == Setting.Level.Advanced)
            {
                advanced_radioButton.Checked = true;
            }
            else
            {
                player_defined_radioButton.Checked = true;
                height_textBox.Text = setting.shape.row.ToString();
                width_textBox.Text = setting.shape.col.ToString();
                mine_count_textBox.Text = setting.mineCount.ToString();
            }
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

        public void OptionForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.Cancel)
            {
                return;
            }
            if (basic_radioButton.Checked)
            {
                setting = new Setting(Setting.Level.Basic, new Shape(9, 9), 10);
            }
            else if (intermediate_radioButton.Checked)
            {
                setting = new Setting(Setting.Level.Intermidiate, new Shape(16, 16), 40);
            }
            else if (advanced_radioButton.Checked)
            {
                setting = new Setting(Setting.Level.Advanced, new Shape(16, 30), 99);
            }
            else
            {
                int row = Algorithm.StringToInt(height_textBox.Text);
                int col = Algorithm.StringToInt(width_textBox.Text);
                int mine_count = Algorithm.StringToInt(mine_count_textBox.Text);
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
                else if (mine_count < 10 || mine_count > 0.85 * row * col)
                {
                    MessageBox.Show("雷数必须在10-" + (int)(0.85 * row * col) + "之间！", "扫雷-选项", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    e.Cancel = true;
                }
                else
                {
                    setting = new Setting(Setting.Level.PlayerDefined, new Shape(row, col), mine_count);
                }
            }
        }

        private void user_defined_radioButton_CheckedChanged(object sender, EventArgs e)
        {
            height_textBox.Enabled = width_textBox.Enabled = mine_count_textBox.Enabled = player_defined_radioButton.Checked;
        }
    }
}
