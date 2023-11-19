using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace MineSweeper
{
    public partial class AboutDialog : Form
    {
        public AboutDialog()
        {
            InitializeComponent();
        }

        public void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("explorer.exe", linkLabel1.Text);
        }

        public void AboutDialog_Load(object sender, EventArgs e)
        {
            label1.Text = "NJUPT B20030919陈天 程序设计 扫雷\n\n版本：" + Properties.Resources.Version + "\n\n发布时间：" + Properties.Resources.PublishDate + "\n\n项目地址：";
        }
    }
}
