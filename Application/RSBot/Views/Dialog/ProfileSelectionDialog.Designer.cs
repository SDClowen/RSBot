namespace RSBot.Views.Dialog
{
    partial class ProfileSelectionDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            comboProfiles = new System.Windows.Forms.ComboBox();
            label1 = new System.Windows.Forms.Label();
            btnOK = new System.Windows.Forms.Button();
            checkSaveSelection = new System.Windows.Forms.CheckBox();
            buttonCreateProfile = new System.Windows.Forms.Button();
            buttonDeleteProfile = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // comboProfiles
            // 
            comboProfiles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboProfiles.FormattingEnabled = true;
            comboProfiles.Location = new System.Drawing.Point(152, 22);
            comboProfiles.Margin = new System.Windows.Forms.Padding(4);
            comboProfiles.Name = "comboProfiles";
            comboProfiles.Size = new System.Drawing.Size(238, 28);
            comboProfiles.TabIndex = 1;
            comboProfiles.SelectedIndexChanged += comboProfiles_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            label1.Location = new System.Drawing.Point(32, 25);
            label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(112, 20);
            label1.TabIndex = 9;
            label1.Text = "Select a profile:";
            // 
            // btnOK
            // 
            btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            btnOK.Location = new System.Drawing.Point(168, 105);
            btnOK.Margin = new System.Windows.Forms.Padding(4);
            btnOK.Name = "btnOK";
            btnOK.Size = new System.Drawing.Size(170, 45);
            btnOK.TabIndex = 4;
            btnOK.Text = "CONTINUE";
            btnOK.UseVisualStyleBackColor = true;
            // 
            // checkSaveSelection
            // 
            checkSaveSelection.AutoSize = true;
            checkSaveSelection.BackColor = System.Drawing.SystemColors.Control;
            checkSaveSelection.Location = new System.Drawing.Point(155, 55);
            checkSaveSelection.Margin = new System.Windows.Forms.Padding(0);
            checkSaveSelection.Name = "checkSaveSelection";
            checkSaveSelection.Size = new System.Drawing.Size(125, 24);
            checkSaveSelection.TabIndex = 6;
            checkSaveSelection.Text = "Save selection";
            checkSaveSelection.UseVisualStyleBackColor = false;
            checkSaveSelection.CheckedChanged += checkSaveSelection_CheckedChanged;
            // 
            // buttonCreateProfile
            // 
            buttonCreateProfile.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 162);
            buttonCreateProfile.Location = new System.Drawing.Point(395, 20);
            buttonCreateProfile.Margin = new System.Windows.Forms.Padding(4);
            buttonCreateProfile.Name = "buttonCreateProfile";
            buttonCreateProfile.Size = new System.Drawing.Size(32, 32);
            buttonCreateProfile.TabIndex = 8;
            buttonCreateProfile.Text = "";
            buttonCreateProfile.UseVisualStyleBackColor = true;
            buttonCreateProfile.Click += buttonCreateProfile_Click;
            // 
            // buttonDeleteProfile
            // 
            buttonDeleteProfile.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 162);
            buttonDeleteProfile.Location = new System.Drawing.Point(431, 20);
            buttonDeleteProfile.Margin = new System.Windows.Forms.Padding(0);
            buttonDeleteProfile.Name = "buttonDeleteProfile";
            buttonDeleteProfile.Size = new System.Drawing.Size(32, 32);
            buttonDeleteProfile.TabIndex = 5;
            buttonDeleteProfile.Text = "✕";
            buttonDeleteProfile.UseVisualStyleBackColor = true;
            buttonDeleteProfile.Click += buttonDeleteProfile_Click;
            // 
            // ProfileSelectionDialog
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            ClientSize = new System.Drawing.Size(493, 161);
            ControlBox = false;
            Controls.Add(btnOK);
            Controls.Add(buttonDeleteProfile);
            Controls.Add(buttonCreateProfile);
            Controls.Add(checkSaveSelection);
            Controls.Add(comboProfiles);
            Controls.Add(label1);
            Margin = new System.Windows.Forms.Padding(4);
            Name = "ProfileSelectionDialog";
            ShowIcon = false;
            SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.ComboBox comboProfiles;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.CheckBox checkSaveSelection;
        private System.Windows.Forms.Button buttonCreateProfile;
        private System.Windows.Forms.Button buttonDeleteProfile;
    }
}