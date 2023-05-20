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
            checkEnable = new SDUI.Controls.CheckBox();
            btnResetToDefaults = new SDUI.Controls.Button();
            tabControl1 = new SDUI.Controls.TabControl();
            tabPage1 = new System.Windows.Forms.TabPage();
            panelActions = new SDUI.Controls.Panel();
            tabPage2 = new System.Windows.Forms.TabPage();
            lblChatCommandDescriptions = new System.Windows.Forms.TextBox();
            label1 = new SDUI.Controls.Label();
            tabPage3 = new System.Windows.Forms.TabPage();
            label2 = new SDUI.Controls.Label();
            btnSave = new SDUI.Controls.Button();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            tabPage3.SuspendLayout();
            SuspendLayout();
            // 
            // checkEnable
            // 
            checkEnable.AutoSize = true;
            checkEnable.BackColor = System.Drawing.Color.Transparent;
            checkEnable.Depth = 0;
            checkEnable.Location = new System.Drawing.Point(132, 368);
            checkEnable.Margin = new System.Windows.Forms.Padding(0);
            checkEnable.MouseLocation = new System.Drawing.Point(-1, -1);
            checkEnable.Name = "checkEnable";
            checkEnable.Ripple = true;
            checkEnable.Size = new System.Drawing.Size(161, 30);
            checkEnable.TabIndex = 0;
            checkEnable.Text = "Enable command center";
            checkEnable.UseVisualStyleBackColor = false;
            checkEnable.CheckedChanged += checkEnable_CheckedChanged;
            // 
            // btnResetToDefaults
            // 
            btnResetToDefaults.Color = System.Drawing.Color.Transparent;
            btnResetToDefaults.Location = new System.Drawing.Point(8, 371);
            btnResetToDefaults.Name = "btnResetToDefaults";
            btnResetToDefaults.Radius = 6;
            btnResetToDefaults.ShadowDepth = 4F;
            btnResetToDefaults.Size = new System.Drawing.Size(118, 23);
            btnResetToDefaults.TabIndex = 3;
            btnResetToDefaults.Text = "Reset to defaults";
            btnResetToDefaults.UseVisualStyleBackColor = true;
            btnResetToDefaults.Click += btnResetToDefaults_Click;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.ItemSize = new System.Drawing.Size(80, 24);
            tabControl1.Location = new System.Drawing.Point(8, 4);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new System.Drawing.Size(385, 359);
            tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            tabPage1.BackColor = System.Drawing.Color.White;
            tabPage1.Controls.Add(panelActions);
            tabPage1.Location = new System.Drawing.Point(4, 28);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new System.Windows.Forms.Padding(3);
            tabPage1.Size = new System.Drawing.Size(377, 327);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Emote commands";
            // 
            // panelActions
            // 
            panelActions.AutoScroll = true;
            panelActions.AutoScrollMargin = new System.Drawing.Size(4, 4);
            panelActions.BackColor = System.Drawing.Color.Transparent;
            panelActions.Border = new System.Windows.Forms.Padding(0, 0, 0, 0);
            panelActions.BorderColor = System.Drawing.Color.Transparent;
            panelActions.Dock = System.Windows.Forms.DockStyle.Fill;
            panelActions.Location = new System.Drawing.Point(3, 3);
            panelActions.Name = "panelActions";
            panelActions.Radius = 10;
            panelActions.ShadowDepth = 4F;
            panelActions.Size = new System.Drawing.Size(371, 321);
            panelActions.TabIndex = 1;
            // 
            // tabPage2
            // 
            tabPage2.BackColor = System.Drawing.Color.White;
            tabPage2.Controls.Add(lblChatCommandDescriptions);
            tabPage2.Controls.Add(label1);
            tabPage2.Location = new System.Drawing.Point(4, 28);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new System.Windows.Forms.Padding(3);
            tabPage2.Size = new System.Drawing.Size(377, 327);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Chat commands";
            // 
            // lblChatCommandDescriptions
            // 
            lblChatCommandDescriptions.BorderStyle = System.Windows.Forms.BorderStyle.None;
            lblChatCommandDescriptions.Location = new System.Drawing.Point(21, 47);
            lblChatCommandDescriptions.Multiline = true;
            lblChatCommandDescriptions.Name = "lblChatCommandDescriptions";
            lblChatCommandDescriptions.ReadOnly = true;
            lblChatCommandDescriptions.Size = new System.Drawing.Size(335, 277);
            lblChatCommandDescriptions.TabIndex = 1;
            // 
            // label1
            // 
            label1.ApplyGradient = false;
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label1.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            label1.Gradient = (new System.Drawing.Color[] { System.Drawing.Color.Gray, System.Drawing.Color.Black });
            label1.Location = new System.Drawing.Point(16, 15);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(281, 15);
            label1.TabIndex = 0;
            label1.Text = "Type the following commands into the game chat";
            // 
            // tabPage3
            // 
            tabPage3.BackColor = System.Drawing.Color.White;
            tabPage3.Controls.Add(label2);
            tabPage3.Location = new System.Drawing.Point(4, 28);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new System.Windows.Forms.Padding(3);
            tabPage3.Size = new System.Drawing.Size(377, 327);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Notifications";
            // 
            // label2
            // 
            label2.ApplyGradient = false;
            label2.AutoSize = true;
            label2.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            label2.Gradient = (new System.Drawing.Color[] { System.Drawing.Color.Gray, System.Drawing.Color.Black });
            label2.Location = new System.Drawing.Point(134, 157);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(93, 15);
            label2.TabIndex = 0;
            label2.Text = "<coming soon>";
            // 
            // btnSave
            // 
            btnSave.Color = System.Drawing.Color.FromArgb(56, 155, 90);
            btnSave.ForeColor = System.Drawing.Color.White;
            btnSave.Location = new System.Drawing.Point(311, 371);
            btnSave.Name = "btnSave";
            btnSave.Radius = 6;
            btnSave.ShadowDepth = 4F;
            btnSave.Size = new System.Drawing.Size(75, 23);
            btnSave.TabIndex = 4;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // Main
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            Controls.Add(btnSave);
            Controls.Add(tabControl1);
            Controls.Add(btnResetToDefaults);
            Controls.Add(checkEnable);
            Name = "Main";
            Size = new System.Drawing.Size(400, 405);
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            tabPage3.ResumeLayout(false);
            tabPage3.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
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
