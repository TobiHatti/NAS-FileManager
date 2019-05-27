namespace RBCPlus_Host
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnStartSystem = new System.Windows.Forms.Button();
            this.pbxLogo = new System.Windows.Forms.PictureBox();
            this.gbxOperations = new System.Windows.Forms.GroupBox();
            this.gbxMonitoring = new System.Windows.Forms.GroupBox();
            this.gbxConfiguration = new System.Windows.Forms.GroupBox();
            this.btnStopSystem = new System.Windows.Forms.Button();
            this.txbStatusOutput = new System.Windows.Forms.TextBox();
            this.btnSystemMonitor = new System.Windows.Forms.Button();
            this.btnSystemSettings = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSystemSetup = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLogo)).BeginInit();
            this.gbxOperations.SuspendLayout();
            this.gbxMonitoring.SuspendLayout();
            this.gbxConfiguration.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStartSystem
            // 
            resources.ApplyResources(this.btnStartSystem, "btnStartSystem");
            this.btnStartSystem.Name = "btnStartSystem";
            this.btnStartSystem.UseVisualStyleBackColor = true;
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
            // gbxMonitoring
            // 
            this.gbxMonitoring.Controls.Add(this.btnSystemMonitor);
            resources.ApplyResources(this.gbxMonitoring, "gbxMonitoring");
            this.gbxMonitoring.Name = "gbxMonitoring";
            this.gbxMonitoring.TabStop = false;
            // 
            // gbxConfiguration
            // 
            this.gbxConfiguration.Controls.Add(this.btnSystemSetup);
            this.gbxConfiguration.Controls.Add(this.btnSystemSettings);
            resources.ApplyResources(this.gbxConfiguration, "gbxConfiguration");
            this.gbxConfiguration.Name = "gbxConfiguration";
            this.gbxConfiguration.TabStop = false;
            // 
            // btnStopSystem
            // 
            resources.ApplyResources(this.btnStopSystem, "btnStopSystem");
            this.btnStopSystem.Name = "btnStopSystem";
            this.btnStopSystem.UseVisualStyleBackColor = true;
            // 
            // txbStatusOutput
            // 
            resources.ApplyResources(this.txbStatusOutput, "txbStatusOutput");
            this.txbStatusOutput.Name = "txbStatusOutput";
            // 
            // btnSystemMonitor
            // 
            resources.ApplyResources(this.btnSystemMonitor, "btnSystemMonitor");
            this.btnSystemMonitor.Name = "btnSystemMonitor";
            this.btnSystemMonitor.UseVisualStyleBackColor = true;
            // 
            // btnSystemSettings
            // 
            resources.ApplyResources(this.btnSystemSettings, "btnSystemSettings");
            this.btnSystemSettings.Name = "btnSystemSettings";
            this.btnSystemSettings.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // btnSystemSetup
            // 
            resources.ApplyResources(this.btnSystemSetup, "btnSystemSetup");
            this.btnSystemSetup.Name = "btnSystemSetup";
            this.btnSystemSetup.UseVisualStyleBackColor = true;
            // 
            // Form1
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
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
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

