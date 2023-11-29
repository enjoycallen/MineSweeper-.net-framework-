using System;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace MineSweeper.Dialogs
{
    public partial class ResultDialog : Form
    {
        public enum Mode
        {
            Lose = 0,
            Win = 1,
            Record = 2
        }

        public ResultDialog()
        {
            InitializeComponent();
        }

        public Record ShowDialog(Mode mode, int timing)
        {
            var date = DateTime.Now;
            Text = mode == Mode.Lose ? "游戏失败" : "游戏胜利";
            messageLabel.Text = mode == Mode.Lose ? "不好意思，您输了。下次走运！" : "恭喜！您赢了！";
            timingLabel.Text = timing.ToString();
            dateLabel.Text = date.ToString();
            playerNameLabel.Visible = playerNameTextBox.Visible = mode == Mode.Record;
            base.ShowDialog();
            return mode == Mode.Record ? new Record(playerNameTextBox.Text, timing, date) : null;
        }

        private void exitButtonClick(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void replayButtonClick(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void resultDialogFormClosing(object sender, FormClosingEventArgs e)
        {
            if (playerNameTextBox.Visible && playerNameTextBox.Text == "")
            {
                MessageBox.Show("玩家名称不能为空！", "扫雷", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Cancel = true;
            }
        }
    }
}
