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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProfileSelectionDialog));
            comboProfiles = new SDUI.Controls.ComboBox();
            label1 = new SDUI.Controls.Label();
            panel1 = new SDUI.Controls.Panel();
            btnCancel = new SDUI.Controls.Button();
            btnOK = new SDUI.Controls.Button();
            checkSaveSelection = new SDUI.Controls.CheckBox();
            buttonCreateProfile = new SDUI.Controls.Button();
            buttonDeleteProfile = new SDUI.Controls.Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // comboProfiles
            // 
            comboProfiles.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            comboProfiles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboProfiles.FormattingEnabled = true;
            comboProfiles.Location = new System.Drawing.Point(112, 12);
            comboProfiles.Name = "comboProfiles";
            comboProfiles.Radius = 5;
            comboProfiles.ShadowDepth = 4F;
            comboProfiles.Size = new System.Drawing.Size(191, 24);
            comboProfiles.TabIndex = 1;
            comboProfiles.SelectedIndexChanged += comboProfiles_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.ApplyGradient = false;
            label1.AutoSize = true;
            label1.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            label1.Gradient = (new System.Drawing.Color[] { System.Drawing.Color.Gray, System.Drawing.Color.Black });
            label1.Location = new System.Drawing.Point(19, 15);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(87, 15);
            label1.TabIndex = 2;
            label1.Text = "Select a profile:";
            // 
            // panel1
            // 
            panel1.BackColor = System.Drawing.Color.Transparent;
            panel1.Border = new System.Windows.Forms.Padding(0, 1, 0, 0);
            panel1.BorderColor = System.Drawing.Color.Transparent;
            panel1.Controls.Add(btnCancel);
            panel1.Controls.Add(btnOK);
            panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            panel1.Location = new System.Drawing.Point(0, 71);
            panel1.Name = "panel1";
            panel1.Radius = 0;
            panel1.ShadowDepth = 0F;
            panel1.Size = new System.Drawing.Size(369, 39);
            panel1.TabIndex = 3;
            // 
            // btnCancel
            // 
            btnCancel.Color = System.Drawing.Color.Transparent;
            btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            btnCancel.Location = new System.Drawing.Point(279, 8);
            btnCancel.Name = "btnCancel";
            btnCancel.Radius = 2;
            btnCancel.ShadowDepth = 4F;
            btnCancel.Size = new System.Drawing.Size(75, 23);
            btnCancel.TabIndex = 5;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            btnOK.Color = System.Drawing.Color.Transparent;
            btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            btnOK.Location = new System.Drawing.Point(198, 8);
            btnOK.Name = "btnOK";
            btnOK.Radius = 2;
            btnOK.ShadowDepth = 4F;
            btnOK.Size = new System.Drawing.Size(75, 23);
            btnOK.TabIndex = 4;
            btnOK.Text = "Select";
            btnOK.UseVisualStyleBackColor = true;
            // 
            // checkSaveSelection
            // 
            checkSaveSelection.BackColor = System.Drawing.Color.Transparent;
            checkSaveSelection.Depth = 0;
            checkSaveSelection.Location = new System.Drawing.Point(112, 44);
            checkSaveSelection.Margin = new System.Windows.Forms.Padding(0);
            checkSaveSelection.MouseLocation = new System.Drawing.Point(-1, -1);
            checkSaveSelection.Name = "checkSaveSelection";
            checkSaveSelection.Ripple = true;
            checkSaveSelection.Size = new System.Drawing.Size(97, 15);
            checkSaveSelection.TabIndex = 6;
            checkSaveSelection.Text = "Save selection";
            checkSaveSelection.UseVisualStyleBackColor = false;
            checkSaveSelection.CheckedChanged += checkSaveSelection_CheckedChanged;
            // 
            // buttonCreateProfile
            // 
            buttonCreateProfile.Color = System.Drawing.Color.FromArgb(0, 192, 0);
            buttonCreateProfile.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            buttonCreateProfile.ForeColor = System.Drawing.Color.White;
            buttonCreateProfile.Location = new System.Drawing.Point(330, 12);
            buttonCreateProfile.Name = "buttonCreateProfile";
            buttonCreateProfile.Radius = 6;
            buttonCreateProfile.ShadowDepth = 4F;
            buttonCreateProfile.Size = new System.Drawing.Size(24, 24);
            buttonCreateProfile.TabIndex = 8;
            buttonCreateProfile.Text = "+";
            buttonCreateProfile.UseVisualStyleBackColor = true;
            buttonCreateProfile.Click += buttonCreateProfile_Click;
            // 
            // buttonDeleteProfile
            // 
            buttonDeleteProfile.Color = System.Drawing.Color.IndianRed;
            buttonDeleteProfile.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            buttonDeleteProfile.ForeColor = System.Drawing.Color.White;
            buttonDeleteProfile.Location = new System.Drawing.Point(305, 12);
            buttonDeleteProfile.Name = "buttonDeleteProfile";
            buttonDeleteProfile.Radius = 6;
            buttonDeleteProfile.ShadowDepth = 4F;
            buttonDeleteProfile.Size = new System.Drawing.Size(24, 24);
            buttonDeleteProfile.TabIndex = 8;
            buttonDeleteProfile.Text = "x";
            buttonDeleteProfile.UseVisualStyleBackColor = true;
            buttonDeleteProfile.Click += buttonDeleteProfile_Click;
            // 
            // ProfileSelectionDialog
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(369, 110);
            Controls.Add(buttonDeleteProfile);
            Controls.Add(buttonCreateProfile);
            Controls.Add(checkSaveSelection);
            Controls.Add(panel1);
            Controls.Add(label1);
            Controls.Add(comboProfiles);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ProfileSelectionDialog";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "RSBot - Profile";
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private SDUI.Controls.ComboBox comboProfiles;
        private SDUI.Controls.Label label1;
        private SDUI.Controls.Panel panel1;
        private SDUI.Controls.Button btnCancel;
        private SDUI.Controls.Button btnOK;
        private SDUI.Controls.CheckBox checkSaveSelection;
        private SDUI.Controls.Button buttonCreateProfile;
        private SDUI.Controls.Button buttonDeleteProfile;
    }
}