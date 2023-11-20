namespace MineSweeper.Dialogs
{
    partial class WinDialog
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
            this.date_label = new System.Windows.Forms.Label();
            this.time_label = new System.Windows.Forms.Label();
            this.replay_button = new System.Windows.Forms.Button();
            this.exit_button = new System.Windows.Forms.Button();
            this.player_textBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // date_label
            // 
            this.date_label.AutoSize = true;
            this.date_label.Location = new System.Drawing.Point(104, 121);
            this.date_label.Name = "date_label";
            this.date_label.Size = new System.Drawing.Size(0, 12);
            this.date_label.TabIndex = 12;
            // 
            // time_label
            // 
            this.time_label.AutoSize = true;
            this.time_label.Location = new System.Drawing.Point(104, 81);
            this.time_label.Name = "time_label";
            this.time_label.Size = new System.Drawing.Size(0, 12);
            this.time_label.TabIndex = 13;
            // 
            // replay_button
            // 
            this.replay_button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.replay_button.Location = new System.Drawing.Point(199, 209);
            this.replay_button.Name = "replay_button";
            this.replay_button.Size = new System.Drawing.Size(130, 30);
            this.replay_button.TabIndex = 10;
            this.replay_button.Text = "再玩一局(&P)";
            this.replay_button.UseVisualStyleBackColor = true;
            this.replay_button.Click += new System.EventHandler(this.replay_button_Click);
            // 
            // exit_button
            // 
            this.exit_button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.exit_button.Location = new System.Drawing.Point(32, 209);
            this.exit_button.Name = "exit_button";
            this.exit_button.Size = new System.Drawing.Size(130, 30);
            this.exit_button.TabIndex = 11;
            this.exit_button.Text = "退出(&X)";
            this.exit_button.UseVisualStyleBackColor = true;
            this.exit_button.Click += new System.EventHandler(this.exit_button_Click);
            // 
            // player_textBox
            // 
            this.player_textBox.Location = new System.Drawing.Point(106, 158);
            this.player_textBox.MaxLength = 16;
            this.player_textBox.Name = "player_textBox";
            this.player_textBox.Size = new System.Drawing.Size(223, 21);
            this.player_textBox.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 161);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "玩家名称：";
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(140, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "恭喜！您赢了！";
            // 
            // WinDialog
            // 
            this.AcceptButton = this.replay_button;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.replay_button;
            this.ClientSize = new System.Drawing.Size(358, 271);
            this.Controls.Add(this.date_label);
            this.Controls.Add(this.time_label);
            this.Controls.Add(this.replay_button);
            this.Controls.Add(this.exit_button);
            this.Controls.Add(this.player_textBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WinDialog";
            this.Text = "游戏胜利";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WinDialog_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label date_label;
        private System.Windows.Forms.Label time_label;
        private System.Windows.Forms.Button replay_button;
        private System.Windows.Forms.Button exit_button;
        private System.Windows.Forms.TextBox player_textBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}