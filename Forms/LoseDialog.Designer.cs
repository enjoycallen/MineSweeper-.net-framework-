namespace MineSweeper.Dialogs
{
    partial class LoseDialog
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.exit_button = new System.Windows.Forms.Button();
            this.replay_button = new System.Windows.Forms.Button();
            this.time_label = new System.Windows.Forms.Label();
            this.date_label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(100, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(173, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "不好意思，您输了。下次走运！";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(50, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "用时：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(50, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "日期：";
            // 
            // exit_button
            // 
            this.exit_button.Location = new System.Drawing.Point(28, 160);
            this.exit_button.Name = "exit_button";
            this.exit_button.Size = new System.Drawing.Size(130, 30);
            this.exit_button.TabIndex = 3;
            this.exit_button.Text = "退出(&X)";
            this.exit_button.UseVisualStyleBackColor = true;
            this.exit_button.Click += new System.EventHandler(this.exit_button_Click);
            // 
            // replay_button
            // 
            this.replay_button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.replay_button.Location = new System.Drawing.Point(195, 160);
            this.replay_button.Name = "replay_button";
            this.replay_button.Size = new System.Drawing.Size(130, 30);
            this.replay_button.TabIndex = 3;
            this.replay_button.Text = "再玩一局(&P)";
            this.replay_button.UseVisualStyleBackColor = true;
            this.replay_button.Click += new System.EventHandler(this.replay_button_Click);
            // 
            // time_label
            // 
            this.time_label.AutoSize = true;
            this.time_label.Location = new System.Drawing.Point(100, 80);
            this.time_label.Name = "time_label";
            this.time_label.Size = new System.Drawing.Size(0, 12);
            this.time_label.TabIndex = 4;
            // 
            // date_label
            // 
            this.date_label.AutoSize = true;
            this.date_label.Location = new System.Drawing.Point(100, 120);
            this.date_label.Name = "date_label";
            this.date_label.Size = new System.Drawing.Size(0, 12);
            this.date_label.TabIndex = 4;
            // 
            // LoseDialog
            // 
            this.AcceptButton = this.replay_button;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.replay_button;
            this.ClientSize = new System.Drawing.Size(358, 211);
            this.Controls.Add(this.date_label);
            this.Controls.Add(this.time_label);
            this.Controls.Add(this.replay_button);
            this.Controls.Add(this.exit_button);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoseDialog";
            this.Text = "游戏失败";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button exit_button;
        private System.Windows.Forms.Button replay_button;
        private System.Windows.Forms.Label time_label;
        private System.Windows.Forms.Label date_label;
    }
}