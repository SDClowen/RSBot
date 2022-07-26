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
            this.comboProfiles = new SDUI.Controls.ComboBox();
            this.label1 = new SDUI.Controls.Label();
            this.panel1 = new SDUI.Controls.Panel();
            this.btnCancel = new SDUI.Controls.Button();
            this.btnOK = new SDUI.Controls.Button();
            this.checkSaveSelection = new SDUI.Controls.CheckBox();
            this.buttonCreateProfile = new SDUI.Controls.Button();
            this.buttonDeleteProfile = new SDUI.Controls.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboProfiles
            // 
            this.comboProfiles.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboProfiles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboProfiles.FormattingEnabled = true;
            this.comboProfiles.Location = new System.Drawing.Point(112, 12);
            this.comboProfiles.Name = "comboProfiles";
            this.comboProfiles.Size = new System.Drawing.Size(191, 24);
            this.comboProfiles.TabIndex = 1;
            this.comboProfiles.SelectedIndexChanged += new System.EventHandler(this.comboProfiles_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(19, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Select a profile:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Border = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.panel1.BorderColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnOK);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 71);
            this.panel1.Name = "panel1";
            this.panel1.Radius = 1;
            this.panel1.Size = new System.Drawing.Size(369, 39);
            this.panel1.TabIndex = 3;
            // 
            // btnCancel
            // 
            this.btnCancel.Color = System.Drawing.Color.Transparent;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(279, 8);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Radius = 2;
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Color = System.Drawing.Color.Transparent;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(198, 8);
            this.btnOK.Name = "btnOK";
            this.btnOK.Radius = 2;
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "Select";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // checkSaveSelection
            // 
            this.checkSaveSelection.AutoSize = true;
            this.checkSaveSelection.BackColor = System.Drawing.Color.Transparent;
            this.checkSaveSelection.Checked = false;
            this.checkSaveSelection.Location = new System.Drawing.Point(112, 44);
            this.checkSaveSelection.Name = "checkSaveSelection";
            this.checkSaveSelection.Size = new System.Drawing.Size(97, 15);
            this.checkSaveSelection.TabIndex = 6;
            this.checkSaveSelection.Text = "Save selection";
            this.checkSaveSelection.CheckedChanged += new System.EventHandler(this.checkSaveSelection_CheckedChanged);
            // 
            // buttonCreateProfile
            // 
            this.buttonCreateProfile.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.buttonCreateProfile.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonCreateProfile.ForeColor = System.Drawing.Color.White;
            this.buttonCreateProfile.Location = new System.Drawing.Point(330, 12);
            this.buttonCreateProfile.Name = "buttonCreateProfile";
            this.buttonCreateProfile.Radius = 6;
            this.buttonCreateProfile.Size = new System.Drawing.Size(24, 24);
            this.buttonCreateProfile.TabIndex = 8;
            this.buttonCreateProfile.Text = "+";
            this.buttonCreateProfile.UseVisualStyleBackColor = true;
            this.buttonCreateProfile.Click += new System.EventHandler(this.buttonCreateProfile_Click);
            // 
            // buttonDeleteProfile
            // 
            this.buttonDeleteProfile.Color = System.Drawing.Color.IndianRed;
            this.buttonDeleteProfile.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonDeleteProfile.ForeColor = System.Drawing.Color.White;
            this.buttonDeleteProfile.Location = new System.Drawing.Point(305, 12);
            this.buttonDeleteProfile.Name = "buttonDeleteProfile";
            this.buttonDeleteProfile.Radius = 6;
            this.buttonDeleteProfile.Size = new System.Drawing.Size(24, 24);
            this.buttonDeleteProfile.TabIndex = 8;
            this.buttonDeleteProfile.Text = "x";
            this.buttonDeleteProfile.UseVisualStyleBackColor = true;
            this.buttonDeleteProfile.Click += new System.EventHandler(this.buttonDeleteProfile_Click);
            // 
            // ProfileSelectionDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(369, 110);
            this.Controls.Add(this.buttonDeleteProfile);
            this.Controls.Add(this.buttonCreateProfile);
            this.Controls.Add(this.checkSaveSelection);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboProfiles);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProfileSelectionDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RSBot - Profile";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

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