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
            checkEnable = new System.Windows.Forms.CheckBox();
            btnResetToDefaults = new System.Windows.Forms.Button();
            tabControl1 = new System.Windows.Forms.TabControl();
            tabPage1 = new System.Windows.Forms.TabPage();
            panelActions = new System.Windows.Forms.Panel();
            tabPage2 = new System.Windows.Forms.TabPage();
            lblChatCommandDescriptions = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            tabPage3 = new System.Windows.Forms.TabPage();
            label2 = new System.Windows.Forms.Label();
            btnSave = new System.Windows.Forms.Button();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            tabPage3.SuspendLayout();
            SuspendLayout();
            // 
            // checkEnable
            // 
            checkEnable.AutoSize = true;
            checkEnable.Location = new System.Drawing.Point(162, 467);
            checkEnable.Margin = new System.Windows.Forms.Padding(0);
            checkEnable.Name = "checkEnable";
            checkEnable.Size = new System.Drawing.Size(192, 24);
            checkEnable.TabIndex = 0;
            checkEnable.Text = "Enable command center";
            checkEnable.UseVisualStyleBackColor = false;
            checkEnable.CheckedChanged += checkEnable_CheckedChanged;
            // 
            // btnResetToDefaults
            // 
            btnResetToDefaults.Location = new System.Drawing.Point(10, 464);
            btnResetToDefaults.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            btnResetToDefaults.Name = "btnResetToDefaults";
            btnResetToDefaults.Size = new System.Drawing.Size(148, 29);
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
            tabControl1.Location = new System.Drawing.Point(10, 5);
            tabControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new System.Drawing.Size(481, 449);
            tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(panelActions);
            tabPage1.Location = new System.Drawing.Point(4, 28);
            tabPage1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            tabPage1.Size = new System.Drawing.Size(473, 417);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Emote commands";
            // 
            // panelActions
            // 
            panelActions.AutoScroll = true;
            panelActions.AutoScrollMargin = new System.Drawing.Size(4, 4);
            panelActions.Dock = System.Windows.Forms.DockStyle.Fill;
            panelActions.Location = new System.Drawing.Point(4, 4);
            panelActions.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            panelActions.Name = "panelActions";
            panelActions.Size = new System.Drawing.Size(465, 409);
            panelActions.TabIndex = 1;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(lblChatCommandDescriptions);
            tabPage2.Controls.Add(label1);
            tabPage2.Location = new System.Drawing.Point(4, 28);
            tabPage2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            tabPage2.Size = new System.Drawing.Size(473, 417);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Chat commands";
            // 
            // lblChatCommandDescriptions
            // 
            lblChatCommandDescriptions.BorderStyle = System.Windows.Forms.BorderStyle.None;
            lblChatCommandDescriptions.Location = new System.Drawing.Point(26, 59);
            lblChatCommandDescriptions.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            lblChatCommandDescriptions.Multiline = true;
            lblChatCommandDescriptions.Name = "lblChatCommandDescriptions";
            lblChatCommandDescriptions.ReadOnly = true;
            lblChatCommandDescriptions.Size = new System.Drawing.Size(419, 346);
            lblChatCommandDescriptions.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            label1.Location = new System.Drawing.Point(20, 19);
            label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(356, 20);
            label1.TabIndex = 0;
            label1.Text = "Type the following commands into the game chat";
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(label2);
            tabPage3.Location = new System.Drawing.Point(4, 28);
            tabPage3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            tabPage3.Size = new System.Drawing.Size(473, 417);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Notifications";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(168, 196);
            label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(115, 20);
            label2.TabIndex = 0;
            label2.Text = "<coming soon>";
            // 
            // btnSave
            // 
            btnSave.Location = new System.Drawing.Point(389, 464);
            btnSave.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            btnSave.Name = "btnSave";
            btnSave.Size = new System.Drawing.Size(94, 29);
            btnSave.TabIndex = 4;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // Main
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            Controls.Add(btnSave);
            Controls.Add(tabControl1);
            Controls.Add(btnResetToDefaults);
            Controls.Add(checkEnable);
            Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            Name = "Main";
            Size = new System.Drawing.Size(500, 506);
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

        private System.Windows.Forms.CheckBox checkEnable;
        private System.Windows.Forms.Button btnResetToDefaults;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Panel panelActions;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox lblChatCommandDescriptions;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSave;
    }
}
