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
    public partial class RBCP_Setup : Form
    {
        public RBCP_Setup()
        {
            InitializeComponent();
            pbxLogo.Image = Properties.Resources.RBCPlusBanner4;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to exit the Setup?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        private void trbLogAccuracy_Scroll(object sender, EventArgs e)
        {
            switch(trbLogAccuracy.Value)
            {
                case 0: lblLogAccuracy.Text = "Very Low: Only log\r\ncritical events"; break;
                case 1: lblLogAccuracy.Text = "Low: Only log critical\r\nevents and warnings"; break;
                case 2: lblLogAccuracy.Text = "Medium: Log only\r\nsystem informations"; break;
                case 3: lblLogAccuracy.Text = "High: Log system\r\ninformations and\r\nuser access"; break;
                default:lblLogAccuracy.Text = "Very High: Log all system\r\ninformation, user\r\naccess and file traffic"; break;
            }
        }

        private void btnMainStorageDriveBrowse_Click(object sender, EventArgs e)
        {
            fbdMainStorageDriveBrowser.ShowDialog();
        }

        private void btnBackupDriveBrowse_Click(object sender, EventArgs e)
        {
            fbdBackupStorageBrowser.ShowDialog();
        }

        private void btnCacheDriveBrowse_Click(object sender, EventArgs e)
        {
            fbdCacheDriveBrowser.ShowDialog();
        }
    }
}
