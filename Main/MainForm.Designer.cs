namespace MineSweeper
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.TopMenu = new System.Windows.Forms.MenuStrip();
            this.游戏GToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.新游戏NToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.统计信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.选项OToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.退出XToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助HToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.查看帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.关于AToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TopMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // TopMenu
            // 
            this.TopMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.游戏GToolStripMenuItem,
            this.帮助HToolStripMenuItem});
            this.TopMenu.Location = new System.Drawing.Point(0, 0);
            this.TopMenu.Name = "TopMenu";
            this.TopMenu.Size = new System.Drawing.Size(357, 25);
            this.TopMenu.TabIndex = 1;
            this.TopMenu.Text = "menuStrip1";
            // 
            // 游戏GToolStripMenuItem
            // 
            this.游戏GToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.新游戏NToolStripMenuItem,
            this.toolStripMenuItem2,
            this.统计信息ToolStripMenuItem,
            this.选项OToolStripMenuItem,
            this.toolStripMenuItem3,
            this.退出XToolStripMenuItem});
            this.游戏GToolStripMenuItem.Name = "游戏GToolStripMenuItem";
            this.游戏GToolStripMenuItem.Size = new System.Drawing.Size(61, 21);
            this.游戏GToolStripMenuItem.Text = "游戏(&G)";
            // 
            // 新游戏NToolStripMenuItem
            // 
            this.新游戏NToolStripMenuItem.Name = "新游戏NToolStripMenuItem";
            this.新游戏NToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.新游戏NToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.新游戏NToolStripMenuItem.Text = "新游戏(&N)";
            this.新游戏NToolStripMenuItem.Click += new System.EventHandler(this.新游戏NToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(157, 6);
            // 
            // 统计信息ToolStripMenuItem
            // 
            this.统计信息ToolStripMenuItem.Name = "统计信息ToolStripMenuItem";
            this.统计信息ToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F4;
            this.统计信息ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.统计信息ToolStripMenuItem.Text = "统计信息(&S)";
            this.统计信息ToolStripMenuItem.Click += new System.EventHandler(this.统计信息ToolStripMenuItem_Click);
            // 
            // 选项OToolStripMenuItem
            // 
            this.选项OToolStripMenuItem.Name = "选项OToolStripMenuItem";
            this.选项OToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.选项OToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.选项OToolStripMenuItem.Text = "选项(&O)";
            this.选项OToolStripMenuItem.Click += new System.EventHandler(this.选项OToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(157, 6);
            // 
            // 退出XToolStripMenuItem
            // 
            this.退出XToolStripMenuItem.Name = "退出XToolStripMenuItem";
            this.退出XToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F7;
            this.退出XToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.退出XToolStripMenuItem.Text = "退出(&X)";
            this.退出XToolStripMenuItem.Click += new System.EventHandler(this.退出XToolStripMenuItem_Click);
            // 
            // 帮助HToolStripMenuItem
            // 
            this.帮助HToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.查看帮助ToolStripMenuItem,
            this.toolStripMenuItem4,
            this.关于AToolStripMenuItem});
            this.帮助HToolStripMenuItem.Name = "帮助HToolStripMenuItem";
            this.帮助HToolStripMenuItem.Size = new System.Drawing.Size(61, 21);
            this.帮助HToolStripMenuItem.Text = "帮助(&H)";
            // 
            // 查看帮助ToolStripMenuItem
            // 
            this.查看帮助ToolStripMenuItem.Name = "查看帮助ToolStripMenuItem";
            this.查看帮助ToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.查看帮助ToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.查看帮助ToolStripMenuItem.Text = "查看帮助(&V)";
            this.查看帮助ToolStripMenuItem.Click += new System.EventHandler(this.查看帮助ToolStripMenuItem_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(158, 6);
            // 
            // 关于AToolStripMenuItem
            // 
            this.关于AToolStripMenuItem.Name = "关于AToolStripMenuItem";
            this.关于AToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.关于AToolStripMenuItem.Text = "关于(&A)";
            this.关于AToolStripMenuItem.Click += new System.EventHandler(this.关于AToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(170)))), ((int)(((byte)(199)))));
            this.ClientSize = new System.Drawing.Size(357, 395);
            this.Controls.Add(this.TopMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "扫雷";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.TopMenu.ResumeLayout(false);
            this.TopMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip TopMenu;
        private System.Windows.Forms.ToolStripMenuItem 游戏GToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 新游戏NToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem 统计信息ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 选项OToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem 退出XToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助HToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 查看帮助ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem 关于AToolStripMenuItem;
    }
}