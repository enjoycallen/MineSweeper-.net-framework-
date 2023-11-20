namespace MineSweeper.Dialogs
{
    partial class StatisticsDialog
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
            this.level_listBox = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rank_label = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // level_listBox
            // 
            this.level_listBox.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.level_listBox.FormattingEnabled = true;
            this.level_listBox.ItemHeight = 14;
            this.level_listBox.Items.AddRange(new object[] {
            "初级",
            "中级",
            "高级"});
            this.level_listBox.Location = new System.Drawing.Point(27, 28);
            this.level_listBox.Name = "level_listBox";
            this.level_listBox.Size = new System.Drawing.Size(125, 74);
            this.level_listBox.TabIndex = 0;
            this.level_listBox.SelectedIndexChanged += new System.EventHandler(this.level_listBox_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rank_label);
            this.groupBox1.Location = new System.Drawing.Point(186, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(410, 117);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "排行榜";
            // 
            // rank_label
            // 
            this.rank_label.AutoSize = true;
            this.rank_label.Location = new System.Drawing.Point(22, 30);
            this.rank_label.Name = "rank_label";
            this.rank_label.Size = new System.Drawing.Size(11, 12);
            this.rank_label.TabIndex = 0;
            this.rank_label.Text = "排名\t玩家名称\t用时(秒)\t日期\n";
            // 
            // StatisticsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 161);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.level_listBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StatisticsDialog";
            this.Text = "统计信息";
            this.Load += new System.EventHandler(this.StatisticsDialog_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox level_listBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label rank_label;
    }
}