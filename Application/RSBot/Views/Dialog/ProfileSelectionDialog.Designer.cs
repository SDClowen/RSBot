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
            comboProfiles = new SDUI.Controls.ComboBox();
            label1 = new SDUI.Controls.Label();
            btnOK = new SDUI.Controls.Button();
            checkSaveSelection = new SDUI.Controls.CheckBox();
            buttonCreateProfile = new SDUI.Controls.Button();
            buttonDeleteProfile = new SDUI.Controls.Button();
            SuspendLayout();
            // 
            // comboProfiles
            // 
            comboProfiles.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            comboProfiles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboProfiles.FormattingEnabled = true;
            comboProfiles.Location = new System.Drawing.Point(122, 15);
            comboProfiles.Name = "comboProfiles";
            comboProfiles.Radius = 5;
            comboProfiles.ShadowDepth = 4F;
            comboProfiles.Size = new System.Drawing.Size(191, 26);
            comboProfiles.TabIndex = 1;
            comboProfiles.SelectedIndexChanged += comboProfiles_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.ApplyGradient = false;
            label1.AutoSize = true;
            label1.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            label1.Gradient = new System.Drawing.Color[] { System.Drawing.Color.Gray, System.Drawing.Color.Black };
            label1.GradientAnimation = false;
            label1.Location = new System.Drawing.Point(19, 19);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(98, 17);
            label1.TabIndex = 2;
            label1.Text = "Select a profile:";
            // 
            // btnOK
            // 
            btnOK.Color = System.Drawing.Color.DodgerBlue;
            btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            btnOK.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnOK.ForeColor = System.Drawing.Color.White;
            btnOK.Location = new System.Drawing.Point(134, 95);
            btnOK.Name = "btnOK";
            btnOK.Radius = 8;
            btnOK.ShadowDepth = 4F;
            btnOK.Size = new System.Drawing.Size(136, 41);
            btnOK.TabIndex = 4;
            btnOK.Text = "CONTINUE";
            btnOK.UseVisualStyleBackColor = true;
            // 
            // checkSaveSelection
            // 
            checkSaveSelection.AutoSize = true;
            checkSaveSelection.BackColor = System.Drawing.Color.Transparent;
            checkSaveSelection.Depth = 0;
            checkSaveSelection.Location = new System.Drawing.Point(122, 42);
            checkSaveSelection.Margin = new System.Windows.Forms.Padding(0);
            checkSaveSelection.MouseLocation = new System.Drawing.Point(-1, -1);
            checkSaveSelection.Name = "checkSaveSelection";
            checkSaveSelection.Ripple = true;
            checkSaveSelection.Size = new System.Drawing.Size(113, 30);
            checkSaveSelection.TabIndex = 6;
            checkSaveSelection.Text = "Save selection";
            checkSaveSelection.UseVisualStyleBackColor = false;
            checkSaveSelection.CheckedChanged += checkSaveSelection_CheckedChanged;
            // 
            // buttonCreateProfile
            // 
            buttonCreateProfile.Color = System.Drawing.Color.Green;
            buttonCreateProfile.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            buttonCreateProfile.ForeColor = System.Drawing.Color.White;
            buttonCreateProfile.Location = new System.Drawing.Point(315, 14);
            buttonCreateProfile.Name = "buttonCreateProfile";
            buttonCreateProfile.Radius = 6;
            buttonCreateProfile.ShadowDepth = 4F;
            buttonCreateProfile.Size = new System.Drawing.Size(28, 27);
            buttonCreateProfile.TabIndex = 8;
            buttonCreateProfile.Text = "+";
            buttonCreateProfile.UseVisualStyleBackColor = true;
            buttonCreateProfile.Click += buttonCreateProfile_Click;
            // 
            // buttonDeleteProfile
            // 
            buttonDeleteProfile.Color = System.Drawing.Color.IndianRed;
            buttonDeleteProfile.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            buttonDeleteProfile.ForeColor = System.Drawing.Color.White;
            buttonDeleteProfile.Location = new System.Drawing.Point(344, 14);
            buttonDeleteProfile.Name = "buttonDeleteProfile";
            buttonDeleteProfile.Radius = 6;
            buttonDeleteProfile.ShadowDepth = 4F;
            buttonDeleteProfile.Size = new System.Drawing.Size(28, 27);
            buttonDeleteProfile.TabIndex = 8;
            buttonDeleteProfile.Text = "x";
            buttonDeleteProfile.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            buttonDeleteProfile.UseVisualStyleBackColor = true;
            buttonDeleteProfile.Click += buttonDeleteProfile_Click;
            // 
            // ProfileSelectionDialog
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(392, 147);
            Controls.Add(btnOK);
            Controls.Add(buttonDeleteProfile);
            Controls.Add(buttonCreateProfile);
            Controls.Add(checkSaveSelection);
            Controls.Add(label1);
            Controls.Add(comboProfiles);
            Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MaximumSize = new System.Drawing.Size(392, 147);
            MinimizeBox = false;
            Name = "ProfileSelectionDialog";
            ShowIcon = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "RSBot - Profile";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private SDUI.Controls.ComboBox comboProfiles;
        private SDUI.Controls.Label label1;
        private SDUI.Controls.Button btnOK;
        private SDUI.Controls.CheckBox checkSaveSelection;
        private SDUI.Controls.Button buttonCreateProfile;
        private SDUI.Controls.Button buttonDeleteProfile;
    }
}