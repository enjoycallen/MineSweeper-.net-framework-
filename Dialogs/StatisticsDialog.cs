using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MineSweeper.Dialogs
{
    public partial class StatisticsDialog : Form
    {
        public StatisticsDialog()
        {
            InitializeComponent();
        }

        private void level_listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(level_listBox.SelectedIndex == 0)
            {

            }
            else if(level_listBox.SelectedIndex == 1)
            {

            }
            else
            {

            }
        }
    }
}
