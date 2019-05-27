using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RBCPlus_Host
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            pbxLogo.Image = Properties.Resources.RBCPlusBanner2;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                //this.Hide();
                //e.Cancel = true;
            }
        }
    }
}
