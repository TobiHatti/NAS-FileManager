namespace RBCPlus_Host
{
    partial class RBCP_Menu
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RBCP_Menu));
            this.btnStartSystem = new System.Windows.Forms.Button();
            this.pbxLogo = new System.Windows.Forms.PictureBox();
            this.gbxOperations = new System.Windows.Forms.GroupBox();
            this.btnStopSystem = new System.Windows.Forms.Button();
            this.gbxMonitoring = new System.Windows.Forms.GroupBox();
            this.btnSystemMonitor = new System.Windows.Forms.Button();
            this.gbxConfiguration = new System.Windows.Forms.GroupBox();
            this.btnSystemSetup = new System.Windows.Forms.Button();
            this.btnSystemSettings = new System.Windows.Forms.Button();
            this.txbStatusOutput = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLogo)).BeginInit();
            this.gbxOperations.SuspendLayout();
            this.gbxMonitoring.SuspendLayout();
            this.gbxConfiguration.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStartSystem
            // 
            this.btnStartSystem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(255)))), ((int)(((byte)(202)))));
            resources.ApplyResources(this.btnStartSystem, "btnStartSystem");
            this.btnStartSystem.Name = "btnStartSystem";
            this.btnStartSystem.UseVisualStyleBackColor = false;
            // 
            // pbxLogo
            // 
            resources.ApplyResources(this.pbxLogo, "pbxLogo");
            this.pbxLogo.Name = "pbxLogo";
            this.pbxLogo.TabStop = false;
            // 
            // gbxOperations
            // 
            this.gbxOperations.Controls.Add(this.btnStopSystem);
            this.gbxOperations.Controls.Add(this.btnStartSystem);
            resources.ApplyResources(this.gbxOperations, "gbxOperations");
            this.gbxOperations.Name = "gbxOperations";
            this.gbxOperations.TabStop = false;
            // 
            // btnStopSystem
            // 
            this.btnStopSystem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            resources.ApplyResources(this.btnStopSystem, "btnStopSystem");
            this.btnStopSystem.Name = "btnStopSystem";
            this.btnStopSystem.UseVisualStyleBackColor = false;
            // 
            // gbxMonitoring
            // 
            this.gbxMonitoring.Controls.Add(this.btnSystemMonitor);
            resources.ApplyResources(this.gbxMonitoring, "gbxMonitoring");
            this.gbxMonitoring.Name = "gbxMonitoring";
            this.gbxMonitoring.TabStop = false;
            // 
            // btnSystemMonitor
            // 
            resources.ApplyResources(this.btnSystemMonitor, "btnSystemMonitor");
            this.btnSystemMonitor.Name = "btnSystemMonitor";
            this.btnSystemMonitor.UseVisualStyleBackColor = true;
            // 
            // gbxConfiguration
            // 
            this.gbxConfiguration.Controls.Add(this.btnSystemSetup);
            this.gbxConfiguration.Controls.Add(this.btnSystemSettings);
            resources.ApplyResources(this.gbxConfiguration, "gbxConfiguration");
            this.gbxConfiguration.Name = "gbxConfiguration";
            this.gbxConfiguration.TabStop = false;
            // 
            // btnSystemSetup
            // 
            resources.ApplyResources(this.btnSystemSetup, "btnSystemSetup");
            this.btnSystemSetup.Name = "btnSystemSetup";
            this.btnSystemSetup.UseVisualStyleBackColor = true;
            this.btnSystemSetup.Click += new System.EventHandler(this.btnSystemSetup_Click);
            // 
            // btnSystemSettings
            // 
            resources.ApplyResources(this.btnSystemSettings, "btnSystemSettings");
            this.btnSystemSettings.Name = "btnSystemSettings";
            this.btnSystemSettings.UseVisualStyleBackColor = true;
            // 
            // txbStatusOutput
            // 
            resources.ApplyResources(this.txbStatusOutput, "txbStatusOutput");
            this.txbStatusOutput.Name = "txbStatusOutput";
            this.txbStatusOutput.ReadOnly = true;
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // RBCP_Menu
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txbStatusOutput);
            this.Controls.Add(this.gbxConfiguration);
            this.Controls.Add(this.gbxMonitoring);
            this.Controls.Add(this.gbxOperations);
            this.Controls.Add(this.pbxLogo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "RBCP_Menu";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            ((System.ComponentModel.ISupportInitialize)(this.pbxLogo)).EndInit();
            this.gbxOperations.ResumeLayout(false);
            this.gbxMonitoring.ResumeLayout(false);
            this.gbxConfiguration.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStartSystem;
        private System.Windows.Forms.PictureBox pbxLogo;
        private System.Windows.Forms.GroupBox gbxOperations;
        private System.Windows.Forms.GroupBox gbxMonitoring;
        private System.Windows.Forms.GroupBox gbxConfiguration;
        private System.Windows.Forms.Button btnStopSystem;
        private System.Windows.Forms.Button btnSystemMonitor;
        private System.Windows.Forms.Button btnSystemSettings;
        private System.Windows.Forms.TextBox txbStatusOutput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSystemSetup;
    }
}

