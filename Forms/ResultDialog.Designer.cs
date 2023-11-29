namespace MineSweeper.Dialogs
{
    partial class ResultDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dateLabel = new System.Windows.Forms.Label();
            this.timingLabel = new System.Windows.Forms.Label();
            this.replayButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.playerNameTextBox = new System.Windows.Forms.TextBox();
            this.playerNameLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.messageLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // dateLabel
            // 
            this.dateLabel.AutoSize = true;
            this.dateLabel.Location = new System.Drawing.Point(104, 121);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new System.Drawing.Size(0, 12);
            this.dateLabel.TabIndex = 12;
            // 
            // timingLabel
            // 
            this.timingLabel.AutoSize = true;
            this.timingLabel.Location = new System.Drawing.Point(104, 81);
            this.timingLabel.Name = "timingLabel";
            this.timingLabel.Size = new System.Drawing.Size(0, 12);
            this.timingLabel.TabIndex = 13;
            // 
            // replayButton
            // 
            this.replayButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.replayButton.Location = new System.Drawing.Point(199, 209);
            this.replayButton.Name = "replayButton";
            this.replayButton.Size = new System.Drawing.Size(130, 30);
            this.replayButton.TabIndex = 10;
            this.replayButton.Text = "再玩一局(&P)";
            this.replayButton.UseVisualStyleBackColor = true;
            this.replayButton.Click += new System.EventHandler(this.replayButtonClick);
            // 
            // exitButton
            // 
            this.exitButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.exitButton.Location = new System.Drawing.Point(32, 209);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(130, 30);
            this.exitButton.TabIndex = 11;
            this.exitButton.Text = "退出(&X)";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButtonClick);
            // 
            // playerNameTextBox
            // 
            this.playerNameTextBox.Location = new System.Drawing.Point(106, 158);
            this.playerNameTextBox.MaxLength = 16;
            this.playerNameTextBox.Name = "playerNameTextBox";
            this.playerNameTextBox.Size = new System.Drawing.Size(223, 21);
            this.playerNameTextBox.TabIndex = 9;
            // 
            // playerNameLabel
            // 
            this.playerNameLabel.AutoSize = true;
            this.playerNameLabel.Location = new System.Drawing.Point(30, 161);
            this.playerNameLabel.Name = "playerNameLabel";
            this.playerNameLabel.Size = new System.Drawing.Size(65, 12);
            this.playerNameLabel.TabIndex = 6;
            this.playerNameLabel.Text = "玩家名称：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(54, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "日期：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(54, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "用时：";
            // 
            // messageLabel
            // 
            this.messageLabel.AutoSize = true;
            this.messageLabel.Location = new System.Drawing.Point(140, 31);
            this.messageLabel.Name = "messageLabel";
            this.messageLabel.Size = new System.Drawing.Size(89, 12);
            this.messageLabel.TabIndex = 5;
            this.messageLabel.Text = "恭喜！您赢了！";
            // 
            // ResultDialog
            // 
            this.AcceptButton = this.replayButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.replayButton;
            this.ClientSize = new System.Drawing.Size(358, 260);
            this.Controls.Add(this.dateLabel);
            this.Controls.Add(this.timingLabel);
            this.Controls.Add(this.replayButton);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.playerNameTextBox);
            this.Controls.Add(this.playerNameLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.messageLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ResultDialog";
            this.Text = "游戏胜利";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.resultDialogFormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label dateLabel;
        private System.Windows.Forms.Label timingLabel;
        private System.Windows.Forms.Button replayButton;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.TextBox playerNameTextBox;
        private System.Windows.Forms.Label playerNameLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label messageLabel;
    }
}