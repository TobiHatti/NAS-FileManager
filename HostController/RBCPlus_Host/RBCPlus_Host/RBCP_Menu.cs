using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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

            RBCP_Log.CompactLog = txbStatusOutput;

        }




        private void LoadConfig()
        {
            // Init Test
            // Create Required Files
            txbStatusOutput.AppendText("[INFO]\tSearching for Config-Files...\r\n");

            if (!File.Exists(@"C:\RBCPlus\config\rbcplus.ini"))
            {
                btnStartSystem.Enabled = false;
                btnStopSystem.Enabled = false;
                btnSystemMonitor.Enabled = false;
                btnSystemSettings.Enabled = false;

                RBCP_Log.AddMessage(LogType.Error, "No System Configurations Found!");
                RBCP_Log.AddMessage(LogType.Blank, "Configure the System by clicking on");
                RBCP_Log.AddMessage(LogType.Setup, "");

                Thread.Sleep(500);    
            }
            else
            {

                RBCP_Log.AddMessage(LogType.Info, "Config-File found!");
                RBCP_Log.AddMessage(LogType.Blank, "Loading config...");

                Thread.Sleep(500);

                StreamReader sr = new StreamReader(@"C:\RBCPlus\config\rbcplus.ini");
                string line;
                string[] dataParts = new string[2];

                while ((line = sr.ReadLine()) != null)
                {
                    if (line.StartsWith("[")) continue;

                    dataParts = line.Split('=');

                    RBCP_Config.Set((Config)Enum.Parse(typeof(Config), dataParts[0]), dataParts[1]);

                    RBCP_Log.AddMessage(LogType.Load, "Loading: " + dataParts[0]);

                    Thread.Sleep(5);
                }

                sr.Close();

                RBCP_Log.AddMessage(LogType.Info, "Load Completed!");
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

                RBCP_Log.AddMessage(LogType.Info, "Setup Aborted.");
            }

            
        }

        private void tmrLoadConfig_Tick(object sender, EventArgs e)
        {
            tmrLoadConfig.Stop();
            LoadConfig();
        }

        private void btnSystemMonitor_Click(object sender, EventArgs e)
        {
            RBCP_Monitor rbcp_monitor = new RBCP_Monitor();
            rbcp_monitor.Show();
        }
    }
}
