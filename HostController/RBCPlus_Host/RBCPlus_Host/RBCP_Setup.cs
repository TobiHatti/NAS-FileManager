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

            LoadComboBoxes();
            LoadValues();
            SetLogLabel();
            SetDriveLabels();
        }

        private DataRow CreateCBXRow(DataTable dt, string text, string value)
        {
            DataRow dr = dt.NewRow();
            dr["Text"] = text;
            dr["Value"] = value;
            return dr;
        }

        private DataTable CreateCBXData(string[,] data)
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("Text", typeof(string));
            dt.Columns.Add("Value", typeof(string));

            for (int i = 0; i < (data.Length/data.Rank); i++)  dt.Rows.Add(CreateCBXRow(dt, data[i,0], data[i,1]));

            return dt;
        }

        private void LoadComboBoxes()
        {
            cbxRaidType.DisplayMember = "Text";
            cbxRaidType.ValueMember = "Value";
            cbxRaidType.DataSource = CreateCBXData(new string[,] {
                { "No RAID" , "NONE" },
                { "RAID 0" , "RAID0" },
                { "RAID 1" , "RAID1" },
                { "RAID 5" , "RAID5" },
                { "RAID 6" , "RAID6" },
                { "RAID 10" , "RAID10" }
            });

            cbxSyncFrequency.DisplayMember = "Text";
            cbxSyncFrequency.ValueMember = "Value";
            cbxSyncFrequency.DataSource = CreateCBXData(new string[,] {
                { "Instant" , "SYNINST" },
                { "Every Minute" , "SYN1M" },
                { "Every Hour" , "SYN1H" },
                { "Every 3 Hours" , "SYN3H" },
                { "Every 6 Hours" , "SYN6H" },
                { "Every 12 Hours" , "SYN12H" },
                { "Every Day" , "SYN1D" },
                { "Every 2 Days" , "SYN2D" },
                { "Every 5 Days" , "SYN5D" },
                { "Every Week" , "SYN1W" }
            });

            cbxSyncStrategy.DisplayMember = "Text";
            cbxSyncStrategy.ValueMember = "Value";
            cbxSyncStrategy.DataSource = CreateCBXData(new string[,] {
                { "Sync every change" , "SYNALL" },
                { "Sync only differences" , "SYNDIF" }
            });

            cbxSendLog.DisplayMember = "Text";
            cbxSendLog.ValueMember = "Value";
            cbxSendLog.DataSource = CreateCBXData(new string[,] {
                { "Never" , "NONE" },
                { "Every Day" , "LOG1D" },
                { "Every 3 Days" , "LOG3D" },
                { "Every Week" , "LOG1W" },
                { "Every Month" , "LOG1L" }
            });

            cbxBackupFrequency.DisplayMember = "Text";
            cbxBackupFrequency.ValueMember = "Value";
            cbxBackupFrequency.DataSource = CreateCBXData(new string[,] {
                { "Never" , "NONE" },
                { "Every Day" , "BUP1D" },
                { "Every 3 Days" , "BUP3D" },
                { "Every Week" , "BUP1W" },
                { "Every Month" , "BUP1L" }
            });

            cbxBackupFormat.DisplayMember = "Text";
            cbxBackupFormat.ValueMember = "Value";
            cbxBackupFormat.DataSource = CreateCBXData(new string[,] {
                { "ZIP" , "BUFZIP" },
                { "ISO" , "BUFISO" },
                { "TAR" , "BUFTAR" },
                { "GZ" , "BUFGZ" },
                { "TAR-GZ Package" , "BUFPAK" }
            });

            cbxCacheSizeUnit.DisplayMember = "Text";
            cbxCacheSizeUnit.ValueMember = "Value";
            cbxCacheSizeUnit.DataSource = CreateCBXData(new string[,] {
                { "KB" , "CSKB" },
                { "MB" , "CSMB" },
                { "GB" , "CSGB" },
                { "TB" , "CSTB" }
            });

            cbxFileRequestDuration.DisplayMember = "Text";
            cbxFileRequestDuration.ValueMember = "Value";
            cbxFileRequestDuration.DataSource = CreateCBXData(new string[,] {
                { "Ask every time" , "RDAA" },
                { "15 Minutes" , "RD15M" },
                { "30 Minutes" , "RD30M" },
                { "1 Hour" , "RD1H" },
                { "2 Hours" , "RD2H" },
                { "6 Hours" , "RD6H" },
                { "12 Hours" , "RD12H" },
                { "1 Day" , "RD1D" },
                { "2 Days" , "RD2D" },
                { "5 Days" , "RD5D" },
                { "1 Week" , "RD1W" },
                { "2 Weeks" , "RD2W" },
                { "1 Month" , "RD1L" }
            });

            cbxRequestSizeUnit.DisplayMember = "Text";
            cbxRequestSizeUnit.ValueMember = "Value";
            cbxRequestSizeUnit.DataSource = CreateCBXData(new string[,] {
                { "KB" , "RSKB" },
                { "MB" , "RSMB" },
                { "GB" , "RSGB" },
                { "TB" , "RSTB" }
            });

        }

        private void LoadValues()
        {
            txbNasName.Text = (string)RBCP_Config.Get(Config.NAS_NAME);
            txbNasDescription.Text = (string)RBCP_Config.Get(Config.NAS_DESCRIPTION);

            numNasSize.Value = decimal.Parse((string)RBCP_Config.Get(Config.NAS_SIZE));
            cbxRaidType.SelectedValue = (string)RBCP_Config.Get(Config.RAID_TYPE);
            cbxSyncFrequency.SelectedValue = (string)RBCP_Config.Get(Config.SYNC_FREQUENCY);
            cbxSyncStrategy.SelectedValue = (string)RBCP_Config.Get(Config.SYNC_STRATEGY);

            trbLogAccuracy.Value = int.Parse((string)RBCP_Config.Get(Config.LOG_ACCURACY));
            cbxSendLog.SelectedValue = (string)RBCP_Config.Get(Config.LOG_MAIL_NOTIFY);
            txbLogEmail.Text = (string)RBCP_Config.Get(Config.LOG_EMAIL_ADDRESS);

            fbdMainStorageDriveBrowser.SelectedPath = (string)RBCP_Config.Get(Config.MAIN_DRIVE);
            chbAllowDirectAccess.Checked = bool.Parse((string)RBCP_Config.Get(Config.ALLOW_DIRECT_ACCESS));

            chbDirectAccesByAdmin.Checked = bool.Parse((string)RBCP_Config.Get(Config.ADMIN_ACCESS_ONLY));
            chbEnableBackup.Checked = bool.Parse((string)RBCP_Config.Get(Config.ENABLE_BACKUP));
            cbxBackupFrequency.SelectedValue = (string)RBCP_Config.Get(Config.BACKUP_FREQUENCY);
            cbxBackupFormat.SelectedValue = (string)RBCP_Config.Get(Config.BACKUP_FORMAT);
            rbnBackupLocal.Checked = bool.Parse((string)RBCP_Config.Get(Config.ENABLE_LOCAL_BACKUP));
            rbnBackupFTP.Checked = bool.Parse((string)RBCP_Config.Get(Config.ENABLE_FTP_BACKUP));
            fbdBackupStorageBrowser.SelectedPath = (string)RBCP_Config.Get(Config.BACKUP_DRIVE);

            chbEnableCaching.Checked = bool.Parse((string)RBCP_Config.Get(Config.ENABLE_CACHING));
            fbdCacheDriveBrowser.SelectedPath = (string)RBCP_Config.Get(Config.CACHING_DRIVE);

            numCacheSize.Value = decimal.Parse((string)RBCP_Config.Get(Config.MAX_CACHABLE_SIZE));
            cbxCacheSizeUnit.SelectedValue = (string)RBCP_Config.Get(Config.MAX_CACHABLE_SIZE_UNIT);

            lbxPermaCacheFolders.Text = (string)RBCP_Config.Get(Config.PERMA_CACHE);

            chbEnableFileRequesting.Checked = bool.Parse((string)RBCP_Config.Get(Config.ENABLE_REQUESTING));
            cbxFileRequestDuration.SelectedValue = (string)RBCP_Config.Get(Config.REQUEST_CACHE_DURATION);
            chbAllowRequestCanceling.Checked = bool.Parse((string)RBCP_Config.Get(Config.ALLOW_REQUEST_CANCELING));
            chbAllowRequestExtension.Checked = bool.Parse((string)RBCP_Config.Get(Config.ALLOW_REQUEST_EXTENSION));
            numRequestSize.Value = decimal.Parse((string)RBCP_Config.Get(Config.MAX_REQUEST_SIZE));
            cbxRequestSizeUnit.SelectedValue = (string)RBCP_Config.Get(Config.MAX_REQUEST_SIZE_UNIT);

            chbEnableWebInterface.Checked = bool.Parse((string)RBCP_Config.Get(Config.ENABLE_WEB_INTERFACE));
            chbEnableWebManagement.Checked = bool.Parse((string)RBCP_Config.Get(Config.ENABLE_WEB_MANAGEMENT));

            txbWebAddress.Text = (string)RBCP_Config.Get(Config.WEB_ADDRESS);
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
            config.WriteLine("ALLOW_DIRECT_ACCESS=" + chbAllowDirectAccess.Checked);
            config.WriteLine("ADMIN_ACCESS_ONLY=" + chbDirectAccesByAdmin.Checked);
            config.WriteLine("ENABLE_BACKUP=" + chbEnableBackup.Checked);
            config.WriteLine("BACKUP_FREQUENCY=" + cbxBackupFrequency.SelectedValue);
            config.WriteLine("BACKUP_FORMAT=" + cbxBackupFormat.SelectedValue);
            config.WriteLine("ENABLE_LOCAL_BACKUP=" + rbnBackupLocal.Checked);
            config.WriteLine("ENABLE_FTP_BACKUP=" + rbnBackupFTP.Checked);
            config.WriteLine("BACKUP_DRIVE=" + fbdBackupStorageBrowser.SelectedPath);
            config.WriteLine("FTP_CONFIG=" + "FTP_CONFIG_NOT_SET");

            // Menu-Point: File Caching
            config.WriteLine("[FILE-CACHING]");

            config.WriteLine("ENABLE_CACHING=" + chbEnableCaching.Checked);
            config.WriteLine("CACHING_DRIVE=" + fbdCacheDriveBrowser.SelectedPath);
            config.WriteLine("MAX_CACHABLE_SIZE=" + numCacheSize.Value);
            config.WriteLine("MAX_CACHABLE_SIZE_UNIT=" + cbxCacheSizeUnit.SelectedValue);
            config.WriteLine("PERMA_CACHE=" + lbxPermaCacheFolders.Text);

            // Menu-Point: File Requesting
            config.WriteLine("[FILE-REQUESTING]");

            config.WriteLine("ENABLE_REQUESTING=" + chbEnableFileRequesting.Checked);
            config.WriteLine("REQUEST_CACHE_DURATION=" + cbxFileRequestDuration.SelectedValue);
            config.WriteLine("ALLOW_REQUEST_CANCELING=" + chbAllowRequestCanceling.Checked);
            config.WriteLine("ALLOW_REQUEST_EXTENSION=" + chbAllowRequestExtension.Checked);
            config.WriteLine("MAX_REQUEST_SIZE=" + numRequestSize.Value);
            config.WriteLine("MAX_REQUEST_SIZE_UNIT=" + cbxRequestSizeUnit.SelectedValue);

            // Menu-Point: Web Access
            config.WriteLine("[WEB-ACCESS]");

            config.WriteLine("ENABLE_WEB_INTERFACE=" + chbEnableWebInterface.Checked);
            config.WriteLine("ENABLE_WEB_MANAGEMENT=" + chbEnableWebManagement.Checked);
            config.WriteLine("WEB_ADDRESS=" + txbWebAddress.Text);

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

        private void SetDriveLabels()
        {
            lblMainDrive.Text = "Current Drive: " + fbdMainStorageDriveBrowser.SelectedPath;
            lblCacheDrive.Text = "Current Drive: " + fbdCacheDriveBrowser.SelectedPath;
            lblBackupDrive.Text = "Current Drive: " + fbdBackupStorageBrowser.SelectedPath;
        }

        private void SetLogLabel()
        {
            switch (trbLogAccuracy.Value)
            {
                case 0: lblLogAccuracy.Text = "Very Low: Only log\r\ncritical events"; break;
                case 1: lblLogAccuracy.Text = "Low: Only log critical\r\nevents and warnings"; break;
                case 2: lblLogAccuracy.Text = "Medium: Log only\r\nsystem informations"; break;
                case 3: lblLogAccuracy.Text = "High: Log system\r\ninformations and\r\nuser access"; break;
                default: lblLogAccuracy.Text = "Very High: Log all system\r\ninformation, user\r\naccess and file traffic"; break;
            }
        }

        private void trbLogAccuracy_Scroll(object sender, EventArgs e)
        {
            SetLogLabel();
        }

        private void btnMainStorageDriveBrowse_Click(object sender, EventArgs e)
        {
            fbdMainStorageDriveBrowser.ShowDialog();
            SetDriveLabels();
        }

        private void btnBackupDriveBrowse_Click(object sender, EventArgs e)
        {
            fbdBackupStorageBrowser.ShowDialog();
            SetDriveLabels();
        }

        private void btnCacheDriveBrowse_Click(object sender, EventArgs e)
        {
            fbdCacheDriveBrowser.ShowDialog();
            SetDriveLabels();
        }
    }
}
