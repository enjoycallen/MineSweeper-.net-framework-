namespace MineSweeper
{
    partial class OptionDialog
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.mine_textBox = new System.Windows.Forms.TextBox();
            this.width_textBox = new System.Windows.Forms.TextBox();
            this.height_textBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.user_defined_radioButton = new System.Windows.Forms.RadioButton();
            this.advanced_radioButton = new System.Windows.Forms.RadioButton();
            this.intermediate_radioButton = new System.Windows.Forms.RadioButton();
            this.basic_radioButton = new System.Windows.Forms.RadioButton();
            this.confirm_button = new System.Windows.Forms.Button();
            this.cancel_button = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.mine_textBox);
            this.groupBox1.Controls.Add(this.width_textBox);
            this.groupBox1.Controls.Add(this.height_textBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.user_defined_radioButton);
            this.groupBox1.Controls.Add(this.advanced_radioButton);
            this.groupBox1.Controls.Add(this.intermediate_radioButton);
            this.groupBox1.Controls.Add(this.basic_radioButton);
            this.groupBox1.Location = new System.Drawing.Point(20, 20);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(377, 206);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "难度";
            // 
            // mine_textBox
            // 
            this.mine_textBox.Enabled = false;
            this.mine_textBox.Location = new System.Drawing.Point(288, 143);
            this.mine_textBox.MaxLength = 3;
            this.mine_textBox.Name = "mine_textBox";
            this.mine_textBox.Size = new System.Drawing.Size(69, 21);
            this.mine_textBox.TabIndex = 10;
            this.mine_textBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress);
            // 
            // width_textBox
            // 
            this.width_textBox.Enabled = false;
            this.width_textBox.Location = new System.Drawing.Point(288, 105);
            this.width_textBox.MaxLength = 2;
            this.width_textBox.Name = "width_textBox";
            this.width_textBox.Size = new System.Drawing.Size(69, 21);
            this.width_textBox.TabIndex = 8;
            this.width_textBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress);
            // 
            // height_textBox
            // 
            this.height_textBox.Enabled = false;
            this.height_textBox.Location = new System.Drawing.Point(288, 67);
            this.height_textBox.MaxLength = 2;
            this.height_textBox.Name = "height_textBox";
            this.height_textBox.Size = new System.Drawing.Size(69, 21);
            this.height_textBox.TabIndex = 6;
            this.height_textBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(181, 146);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "雷数(10-)(&M):";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(181, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "宽度(9-30)(&W):";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(181, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "高度(9-24)(&H):";
            // 
            // user_defined_radioButton
            // 
            this.user_defined_radioButton.AutoSize = true;
            this.user_defined_radioButton.Location = new System.Drawing.Point(184, 35);
            this.user_defined_radioButton.Name = "user_defined_radioButton";
            this.user_defined_radioButton.Size = new System.Drawing.Size(77, 16);
            this.user_defined_radioButton.TabIndex = 4;
            this.user_defined_radioButton.TabStop = true;
            this.user_defined_radioButton.Text = "自定义(&U)";
            this.user_defined_radioButton.UseVisualStyleBackColor = true;
            this.user_defined_radioButton.CheckedChanged += new System.EventHandler(this.user_defined_radioButton_CheckedChanged);
            // 
            // advanced_radioButton
            // 
            this.advanced_radioButton.AutoSize = true;
            this.advanced_radioButton.Location = new System.Drawing.Point(15, 143);
            this.advanced_radioButton.Name = "advanced_radioButton";
            this.advanced_radioButton.Size = new System.Drawing.Size(107, 40);
            this.advanced_radioButton.TabIndex = 3;
            this.advanced_radioButton.TabStop = true;
            this.advanced_radioButton.Text = "高级(&V)\r\n99个雷\r\n16×30平铺网格";
            this.advanced_radioButton.UseVisualStyleBackColor = true;
            this.advanced_radioButton.CheckedChanged += new System.EventHandler(this.advanced_radioButton_CheckedChanged);
            // 
            // intermediate_radioButton
            // 
            this.intermediate_radioButton.AutoSize = true;
            this.intermediate_radioButton.Location = new System.Drawing.Point(15, 89);
            this.intermediate_radioButton.Name = "intermediate_radioButton";
            this.intermediate_radioButton.Size = new System.Drawing.Size(107, 40);
            this.intermediate_radioButton.TabIndex = 2;
            this.intermediate_radioButton.TabStop = true;
            this.intermediate_radioButton.Text = "中级(&I)\r\n40个雷\r\n16×16平铺网格";
            this.intermediate_radioButton.UseVisualStyleBackColor = true;
            this.intermediate_radioButton.CheckedChanged += new System.EventHandler(this.intermediate_radioButton_CheckedChanged);
            // 
            // basic_radioButton
            // 
            this.basic_radioButton.AutoSize = true;
            this.basic_radioButton.Location = new System.Drawing.Point(15, 35);
            this.basic_radioButton.Name = "basic_radioButton";
            this.basic_radioButton.Size = new System.Drawing.Size(95, 40);
            this.basic_radioButton.TabIndex = 1;
            this.basic_radioButton.TabStop = true;
            this.basic_radioButton.Text = "初级(&B)\r\n10个雷\r\n9×9平铺网格";
            this.basic_radioButton.UseVisualStyleBackColor = true;
            this.basic_radioButton.CheckedChanged += new System.EventHandler(this.basic_radioButton_CheckedChanged);
            // 
            // confirm_button
            // 
            this.confirm_button.Location = new System.Drawing.Point(156, 244);
            this.confirm_button.Name = "confirm_button";
            this.confirm_button.Size = new System.Drawing.Size(109, 35);
            this.confirm_button.TabIndex = 11;
            this.confirm_button.Text = "确定";
            this.confirm_button.UseVisualStyleBackColor = true;
            this.confirm_button.Click += new System.EventHandler(this.confirm_button_Click);
            // 
            // cancel_button
            // 
            this.cancel_button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancel_button.Location = new System.Drawing.Point(288, 244);
            this.cancel_button.Name = "cancel_button";
            this.cancel_button.Size = new System.Drawing.Size(109, 35);
            this.cancel_button.TabIndex = 12;
            this.cancel_button.Text = "取消";
            this.cancel_button.UseVisualStyleBackColor = true;
            this.cancel_button.Click += new System.EventHandler(this.cancel_button_Click);
            // 
            // OptionDialog
            // 
            this.AcceptButton = this.confirm_button;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancel_button;
            this.ClientSize = new System.Drawing.Size(418, 296);
            this.Controls.Add(this.cancel_button);
            this.Controls.Add(this.confirm_button);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OptionDialog";
            this.Text = "选项";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OptionForm_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton advanced_radioButton;
        private System.Windows.Forms.RadioButton intermediate_radioButton;
        private System.Windows.Forms.RadioButton basic_radioButton;
        private System.Windows.Forms.RadioButton user_defined_radioButton;
        private System.Windows.Forms.TextBox mine_textBox;
        private System.Windows.Forms.TextBox width_textBox;
        private System.Windows.Forms.TextBox height_textBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button confirm_button;
        private System.Windows.Forms.Button cancel_button;
    }
}