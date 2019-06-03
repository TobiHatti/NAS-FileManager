using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RBCPlus_Host
{
    public partial class RBCP_Menu : Form
    {
        public RBCP_Menu()
        {
            InitializeComponent();
            pbxLogo.Image = Properties.Resources.RBCPlusBanner2;

            // Init Test
            // Create Required Files

            txbStatusOutput.AppendText("[INFO]\tSearching for Config-Files...\r\n");

            if (!File.Exists(@"C:\RBCPlus\config\rbcplus.ini"))
            {
                btnStartSystem.Enabled = false;
                btnStopSystem.Enabled = false;
                btnSystemMonitor.Enabled = false;
                btnSystemSettings.Enabled = false;

                txbStatusOutput.AppendText("[ERROR]\tNo System Configurations Found!\r\n");
                txbStatusOutput.AppendText("\tConfigure the System by clicking on \r\n");
                txbStatusOutput.AppendText("\t[Setup]\r\n");

            }
            else
            {
                txbStatusOutput.AppendText("[INFO]\tConfig-File found!\r\n" +
                    "Loading config...\r\n");
            }
        }

        private void btnSystemSetup_Click(object sender, EventArgs e)
        {
            RBCP_Setup rbcp_setup = new RBCP_Setup();

            if(rbcp_setup.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("OK");
            }
            else
            {
                MessageBox.Show("Setup-Process has been aborted.", "Info", MessageBoxButtons.OK,MessageBoxIcon.Information);
                txbStatusOutput.AppendText("[INFO]\tSetup Aborted.\r\n");
            }

            
        }
    }
}
