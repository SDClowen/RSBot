namespace RSBot.General.Views
{
    partial class Accounts
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
            this.textBoxSecondaryPassword = new SDUI.Controls.TextBox();
            this.comboBoxChannel = new SDUI.Controls.ComboBox();
            this.buttonRemove = new SDUI.Controls.Button();
            this.listAccounts = new System.Windows.Forms.ListBox();
            this.label2 = new SDUI.Controls.Label();
            this.txtUsername = new SDUI.Controls.TextBox();
            this.label3 = new SDUI.Controls.Label();
            this.txtPassword = new SDUI.Controls.TextBox();
            this.label5 = new SDUI.Controls.Label();
            this.label4 = new SDUI.Controls.Label();
            this.txtServername = new SDUI.Controls.TextBox();
            this.btnSave = new SDUI.Controls.Button();
            this.btnAdd = new SDUI.Controls.Button();
            this.linkLabelPwShowHide = new System.Windows.Forms.LinkLabel();
            this.linkLabelSecondaryPassword = new System.Windows.Forms.LinkLabel();
            this.label1 = new SDUI.Controls.Label();
            this.btnOK = new SDUI.Controls.Button();
            this.btnCancel = new SDUI.Controls.Button();
            this.panel1 = new SDUI.Controls.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxSecondaryPassword
            // 
            this.textBoxSecondaryPassword.Location = new System.Drawing.Point(197, 126);
            this.textBoxSecondaryPassword.MaxLength = 32767;
            this.textBoxSecondaryPassword.MultiLine = false;
            this.textBoxSecondaryPassword.Name = "textBoxSecondaryPassword";
            this.textBoxSecondaryPassword.Size = new System.Drawing.Size(119, 21);
            this.textBoxSecondaryPassword.TabIndex = 2;
            this.textBoxSecondaryPassword.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.textBoxSecondaryPassword.UseSystemPasswordChar = true;
            // 
            // comboBoxChannel
            // 
            this.comboBoxChannel.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBoxChannel.DropDownHeight = 100;
            this.comboBoxChannel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxChannel.FormattingEnabled = true;
            this.comboBoxChannel.IntegralHeight = false;
            this.comboBoxChannel.ItemHeight = 17;
            this.comboBoxChannel.Items.AddRange(new object[] {
            "Joymax",
            "JCPlanet"});
            this.comboBoxChannel.Location = new System.Drawing.Point(320, 126);
            this.comboBoxChannel.Name = "comboBoxChannel";
            this.comboBoxChannel.Size = new System.Drawing.Size(74, 23);
            this.comboBoxChannel.TabIndex = 11;
            // 
            // buttonRemove
            // 
            this.buttonRemove.Color = System.Drawing.Color.DarkRed;
            this.buttonRemove.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonRemove.ForeColor = System.Drawing.Color.White;
            this.buttonRemove.Location = new System.Drawing.Point(195, 207);
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Radius = 2;
            this.buttonRemove.Size = new System.Drawing.Size(72, 21);
            this.buttonRemove.TabIndex = 10;
            this.buttonRemove.Text = "Remove";
            this.buttonRemove.UseVisualStyleBackColor = true;
            this.buttonRemove.Click += new System.EventHandler(this.buttonRemove_Click);
            // 
            // listAccounts
            // 
            this.listAccounts.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listAccounts.ItemHeight = 15;
            this.listAccounts.Location = new System.Drawing.Point(8, 12);
            this.listAccounts.Name = "listAccounts";
            this.listAccounts.Size = new System.Drawing.Size(178, 212);
            this.listAccounts.TabIndex = 18;
            this.listAccounts.SelectedIndexChanged += new System.EventHandler(this.listAccounts_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(194, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "Username:";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(197, 29);
            this.txtUsername.MaxLength = 32767;
            this.txtUsername.MultiLine = false;
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(197, 21);
            this.txtUsername.TabIndex = 0;
            this.txtUsername.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtUsername.UseSystemPasswordChar = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(194, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "Password:";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(197, 77);
            this.txtPassword.MaxLength = 32767;
            this.txtPassword.MultiLine = false;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(197, 21);
            this.txtPassword.TabIndex = 1;
            this.txtPassword.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label5.Location = new System.Drawing.Point(192, 109);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(163, 15);
            this.label5.TabIndex = 6;
            this.label5.Text = "Secondary Password: (Global)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label4.Location = new System.Drawing.Point(192, 161);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 15);
            this.label4.TabIndex = 5;
            this.label4.Text = "Server name:";
            // 
            // txtServername
            // 
            this.txtServername.Location = new System.Drawing.Point(195, 178);
            this.txtServername.MaxLength = 32767;
            this.txtServername.MultiLine = false;
            this.txtServername.Name = "txtServername";
            this.txtServername.Size = new System.Drawing.Size(199, 21);
            this.txtServername.TabIndex = 3;
            this.txtServername.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtServername.UseSystemPasswordChar = false;
            // 
            // btnSave
            // 
            this.btnSave.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSave.Color = System.Drawing.Color.Transparent;
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(322, 207);
            this.btnSave.Name = "btnSave";
            this.btnSave.Radius = 2;
            this.btnSave.Size = new System.Drawing.Size(72, 21);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Color = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(195, 207);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Radius = 2;
            this.btnAdd.Size = new System.Drawing.Size(72, 21);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // linkLabelPwShowHide
            // 
            this.linkLabelPwShowHide.AutoSize = true;
            this.linkLabelPwShowHide.BackColor = System.Drawing.Color.DimGray;
            this.linkLabelPwShowHide.ForeColor = System.Drawing.Color.White;
            this.linkLabelPwShowHide.LinkColor = System.Drawing.Color.White;
            this.linkLabelPwShowHide.Location = new System.Drawing.Point(354, 80);
            this.linkLabelPwShowHide.Name = "linkLabelPwShowHide";
            this.linkLabelPwShowHide.Size = new System.Drawing.Size(36, 15);
            this.linkLabelPwShowHide.TabIndex = 9;
            this.linkLabelPwShowHide.TabStop = true;
            this.linkLabelPwShowHide.Text = "Show";
            this.linkLabelPwShowHide.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelPwShowHide_LinkClicked);
            // 
            // linkLabelSecondaryPassword
            // 
            this.linkLabelSecondaryPassword.AutoSize = true;
            this.linkLabelSecondaryPassword.BackColor = System.Drawing.Color.DimGray;
            this.linkLabelSecondaryPassword.ForeColor = System.Drawing.Color.White;
            this.linkLabelSecondaryPassword.LinkColor = System.Drawing.Color.White;
            this.linkLabelSecondaryPassword.Location = new System.Drawing.Point(276, 129);
            this.linkLabelSecondaryPassword.Name = "linkLabelSecondaryPassword";
            this.linkLabelSecondaryPassword.Size = new System.Drawing.Size(36, 15);
            this.linkLabelSecondaryPassword.TabIndex = 9;
            this.linkLabelSecondaryPassword.TabStop = true;
            this.linkLabelSecondaryPassword.Text = "Show";
            this.linkLabelSecondaryPassword.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelSecondaryPassword_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 15);
            this.label1.TabIndex = 1;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOK.Color = System.Drawing.Color.Transparent;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(12, 12);
            this.btnOK.Name = "btnOK";
            this.btnOK.Radius = 2;
            this.btnOK.Size = new System.Drawing.Size(72, 21);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Color = System.Drawing.Color.Transparent;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(328, 12);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Radius = 2;
            this.btnCancel.Size = new System.Drawing.Size(72, 21);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Border = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.panel1.BorderColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnOK);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 238);
            this.panel1.Name = "panel1";
            this.panel1.Radius = 0;
            this.panel1.Size = new System.Drawing.Size(408, 45);
            this.panel1.TabIndex = 7;
            // 
            // Accounts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(408, 283);
            this.Controls.Add(this.listAccounts);
            this.Controls.Add(this.linkLabelSecondaryPassword);
            this.Controls.Add(this.linkLabelPwShowHide);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtServername);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.buttonRemove);
            this.Controls.Add(this.comboBoxChannel);
            this.Controls.Add(this.textBoxSecondaryPassword);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(410, 293);
            this.Name = "Accounts";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.Accounts_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SDUI.Controls.TextBox textBoxSecondaryPassword;
        private SDUI.Controls.ComboBox comboBoxChannel;
        private SDUI.Controls.Button buttonRemove;
        private System.Windows.Forms.ListBox listAccounts;
        private SDUI.Controls.Label label2;
        private SDUI.Controls.TextBox txtUsername;
        private SDUI.Controls.Label label3;
        private SDUI.Controls.TextBox txtPassword;
        private SDUI.Controls.Label label5;
        private SDUI.Controls.Label label4;
        private SDUI.Controls.TextBox txtServername;
        private SDUI.Controls.Button btnSave;
        private SDUI.Controls.Button btnAdd;
        private System.Windows.Forms.LinkLabel linkLabelPwShowHide;
        private System.Windows.Forms.LinkLabel linkLabelSecondaryPassword;
        private SDUI.Controls.Label label1;
        private SDUI.Controls.Button btnOK;
        private SDUI.Controls.Button btnCancel;
        private SDUI.Controls.Panel panel1;
    }
}