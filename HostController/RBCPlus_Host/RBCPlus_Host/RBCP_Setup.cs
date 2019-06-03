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
    public partial class RBCP_Setup : Form
    {
        public RBCP_Setup()
        {
            InitializeComponent();
            pbxLogo.Image = Properties.Resources.RBCPlusBanner4;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            // Creating File-Structure 
            if (!File.Exists(@"C:\RBCPlus\config\rbcplus.ini"))
            {
                // Main Directory
                Directory.CreateDirectory(@"C:\RBCPlus\");

                // Child-Directories
                Directory.CreateDirectory(@"C:\RBCPlus\config\");
            }

            // Creating/Writing config-file
            StreamWriter config = new StreamWriter(@"C:\RBCPlus\config\rbcplus.ini");

            // Menu-Point: Main Settings
            config.WriteLine("[MAIN-SETTINGS]");

            config.WriteLine("NAS_NAME=" + txbNasName.Text);
            config.WriteLine("NAS_DESCRIPTION=" + txbNasDescription.Text);

            config.WriteLine("NAS_SIZE=" + numNasSize.Text);
            config.WriteLine("RAID_TYPE=" + cbxRaidType.SelectedValue);

            config.WriteLine("SYNC_FREQUENCY=" + cbxSyncFrequency.SelectedValue);
            config.WriteLine("SYNC_STRATEGY=" + cbxSyncStrategy.SelectedValue);

            config.WriteLine("LOG_ACCURACY=" + trbLogAccuracy.Value);
            config.WriteLine("LOG_MAIL_NOTIFY=" + cbxSendLog.SelectedValue);
            config.WriteLine("LOG_EMAIL_ADDRESS=" + txbLogEmail.Text);

            // Menu-Point: Main Storage
            config.WriteLine("[MAIN-STORAGE]");

            config.WriteLine("MAIN_DRIVE=" + fbdMainStorageDriveBrowser.SelectedPath);

            // Menu-Point: File Caching
            config.WriteLine("[FILE-CACHING]");

            // Menu-Point: File Requesting
            config.WriteLine("[FILE-REQUESTING]");

            // Menu-Point: Web Access
            config.WriteLine("[WEB-ACCESS]");

            // Menu-Point: User Accounts / Shares
            config.WriteLine("[USER-ACCOUNTS-AND-SHARES]");

            config.Close();


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
