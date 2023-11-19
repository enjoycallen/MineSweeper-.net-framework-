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

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
