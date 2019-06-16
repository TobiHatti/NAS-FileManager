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
    public partial class RBCP_Monitor : Form
    {
        public RBCP_Monitor()
        {
            InitializeComponent();
            pbxLogo.Image = Properties.Resources.RBCPlusBanner5;

            RBCP_Log.RichLog = rtbLogOutput;

            RBCP_Log.AddMessage(LogType.Info, "****** Monitoring Started ******");
        }

        private void btnCloseMonitor_Click(object sender, EventArgs e)
        {
            RBCP_Log.AddMessage(LogType.Info, "****** Monitoring Stopped ******");
            this.Close();
        }
    }
}
