namespace RSBot.CommandCenter.Views
{
    partial class Main
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

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.checkEnable = new SDUI.Controls.CheckBox();
            this.btnResetToDefaults = new SDUI.Controls.Button();
            this.tabControl1 = new SDUI.Controls.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panelActions = new SDUI.Controls.Panel();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lblChatCommandDescriptions = new System.Windows.Forms.TextBox();
            this.label1 = new SDUI.Controls.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label2 = new SDUI.Controls.Label();
            this.btnSave = new SDUI.Controls.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkEnable
            // 
            this.checkEnable.AutoSize = true;
            this.checkEnable.BackColor = System.Drawing.Color.Transparent;
            this.checkEnable.Location = new System.Drawing.Point(132, 374);
            this.checkEnable.Name = "checkEnable";
            this.checkEnable.ShadowDepth = 1;
            this.checkEnable.Size = new System.Drawing.Size(152, 15);
            this.checkEnable.TabIndex = 0;
            this.checkEnable.Text = "Enable command center";
            this.checkEnable.UseVisualStyleBackColor = false;
            this.checkEnable.CheckedChanged += new System.EventHandler(this.checkEnable_CheckedChanged);
            // 
            // btnResetToDefaults
            // 
            this.btnResetToDefaults.Color = System.Drawing.Color.Transparent;
            this.btnResetToDefaults.Location = new System.Drawing.Point(8, 369);
            this.btnResetToDefaults.Name = "btnResetToDefaults";
            this.btnResetToDefaults.Radius = 6;
            this.btnResetToDefaults.ShadowDepth = 4F;
            this.btnResetToDefaults.Size = new System.Drawing.Size(118, 23);
            this.btnResetToDefaults.TabIndex = 3;
            this.btnResetToDefaults.Text = "Reset to defaults";
            this.btnResetToDefaults.UseVisualStyleBackColor = true;
            this.btnResetToDefaults.Click += new System.EventHandler(this.btnResetToDefaults_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Border = new System.Windows.Forms.Padding(1);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.HideTabArea = false;
            this.tabControl1.Location = new System.Drawing.Point(8, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(385, 359);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.White;
            this.tabPage1.Controls.Add(this.panelActions);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(377, 330);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Emote commands";
            // 
            // panelActions
            // 
            this.panelActions.AutoScroll = true;
            this.panelActions.AutoScrollMargin = new System.Drawing.Size(4, 4);
            this.panelActions.BackColor = System.Drawing.Color.Transparent;
            this.panelActions.Border = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.panelActions.BorderColor = System.Drawing.Color.Transparent;
            this.panelActions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelActions.Location = new System.Drawing.Point(3, 3);
            this.panelActions.Name = "panelActions";
            this.panelActions.Radius = 10;
            this.panelActions.ShadowDepth = 4F;
            this.panelActions.Size = new System.Drawing.Size(371, 324);
            this.panelActions.TabIndex = 1;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.White;
            this.tabPage2.Controls.Add(this.lblChatCommandDescriptions);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(377, 330);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Chat commands";
            // 
            // lblChatCommandDescriptions
            // 
            this.lblChatCommandDescriptions.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lblChatCommandDescriptions.Location = new System.Drawing.Point(21, 47);
            this.lblChatCommandDescriptions.Multiline = true;
            this.lblChatCommandDescriptions.Name = "lblChatCommandDescriptions";
            this.lblChatCommandDescriptions.ReadOnly = true;
            this.lblChatCommandDescriptions.Size = new System.Drawing.Size(335, 277);
            this.lblChatCommandDescriptions.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(16, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(281, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Type the following commands into the game chat";
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.White;
            this.tabPage3.Controls.Add(this.label2);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(377, 330);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Notifications";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(134, 157);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "<coming soon>";
            // 
            // btnSave
            // 
            this.btnSave.Color = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(155)))), ((int)(((byte)(90)))));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(318, 369);
            this.btnSave.Name = "btnSave";
            this.btnSave.Radius = 6;
            this.btnSave.ShadowDepth = 4F;
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnResetToDefaults);
            this.Controls.Add(this.checkEnable);
            this.Name = "Main";
            this.Size = new System.Drawing.Size(400, 405);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SDUI.Controls.CheckBox checkEnable;
        private SDUI.Controls.Button btnResetToDefaults;
        private SDUI.Controls.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private SDUI.Controls.Panel panelActions;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private SDUI.Controls.Label label1;
        private System.Windows.Forms.TextBox lblChatCommandDescriptions;
        private SDUI.Controls.Label label2;
        private SDUI.Controls.Button btnSave;
    }
}
