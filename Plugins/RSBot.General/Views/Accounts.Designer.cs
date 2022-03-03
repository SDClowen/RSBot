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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCancel = new RSBot.Theme.Material.Button();
            this.btnOK = new RSBot.Theme.Material.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.listAccounts = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtServername = new System.Windows.Forms.TextBox();
            this.linkLabelPwShowHide = new System.Windows.Forms.LinkLabel();
            this.btnAdd = new RSBot.Theme.Material.Button();
            this.btnSave = new RSBot.Theme.Material.Button();
            this.buttonRemove = new RSBot.Theme.Material.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxSecondaryPassword = new System.Windows.Forms.TextBox();
            this.linkLabelSecondaryPassword = new System.Windows.Forms.LinkLabel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnOK);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 269);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(394, 45);
            this.panel1.TabIndex = 7;
            // 
            // btnCancel
            // 
            this.btnCancel.Depth = 0;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Icon = null;
            this.btnCancel.Location = new System.Drawing.Point(313, 10);
            this.btnCancel.MouseState = RSBot.Theme.IMatMouseState.HOVER;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Primary = false;
            this.btnCancel.Raised = false;
            this.btnCancel.SingleColor = System.Drawing.Color.Empty;
            this.btnCancel.Size = new System.Drawing.Size(72, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Depth = 0;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Icon = null;
            this.btnOK.Location = new System.Drawing.Point(235, 10);
            this.btnOK.MouseState = RSBot.Theme.IMatMouseState.HOVER;
            this.btnOK.Name = "btnOK";
            this.btnOK.Primary = true;
            this.btnOK.Raised = true;
            this.btnOK.SingleColor = System.Drawing.Color.Empty;
            this.btnOK.Size = new System.Drawing.Size(72, 23);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(394, 2);
            this.label1.TabIndex = 1;
            // 
            // listAccounts
            // 
            this.listAccounts.FormattingEnabled = true;
            this.listAccounts.ItemHeight = 15;
            this.listAccounts.Location = new System.Drawing.Point(12, 12);
            this.listAccounts.Name = "listAccounts";
            this.listAccounts.Size = new System.Drawing.Size(176, 244);
            this.listAccounts.TabIndex = 8;
            this.listAccounts.SelectedIndexChanged += new System.EventHandler(this.listAccounts_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(194, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "Username:";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(197, 29);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(185, 23);
            this.txtUsername.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(194, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "Password:";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(197, 77);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(185, 23);
            this.txtPassword.TabIndex = 1;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(194, 158);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 15);
            this.label4.TabIndex = 5;
            this.label4.Text = "Server name:";
            // 
            // txtServername
            // 
            this.txtServername.Location = new System.Drawing.Point(197, 175);
            this.txtServername.Name = "txtServername";
            this.txtServername.Size = new System.Drawing.Size(185, 23);
            this.txtServername.TabIndex = 3;
            // 
            // linkLabelPwShowHide
            // 
            this.linkLabelPwShowHide.AutoSize = true;
            this.linkLabelPwShowHide.Location = new System.Drawing.Point(341, 80);
            this.linkLabelPwShowHide.Name = "linkLabelPwShowHide";
            this.linkLabelPwShowHide.Size = new System.Drawing.Size(36, 15);
            this.linkLabelPwShowHide.TabIndex = 9;
            this.linkLabelPwShowHide.TabStop = true;
            this.linkLabelPwShowHide.Text = "Show";
            this.linkLabelPwShowHide.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelPwShowHide_LinkClicked);
            // 
            // btnAdd
            // 
            this.btnAdd.Depth = 0;
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnAdd.Icon = null;
            this.btnAdd.Location = new System.Drawing.Point(197, 204);
            this.btnAdd.MouseState = RSBot.Theme.IMatMouseState.HOVER;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Primary = true;
            this.btnAdd.Raised = true;
            this.btnAdd.SingleColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(189)))), ((int)(((byte)(166)))));
            this.btnAdd.Size = new System.Drawing.Size(72, 23);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnSave
            // 
            this.btnSave.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSave.Depth = 0;
            this.btnSave.Enabled = false;
            this.btnSave.Icon = null;
            this.btnSave.Location = new System.Drawing.Point(310, 204);
            this.btnSave.MouseState = RSBot.Theme.IMatMouseState.HOVER;
            this.btnSave.Name = "btnSave";
            this.btnSave.Primary = false;
            this.btnSave.Raised = false;
            this.btnSave.SingleColor = System.Drawing.Color.Empty;
            this.btnSave.Size = new System.Drawing.Size(72, 23);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // buttonRemove
            // 
            this.buttonRemove.Depth = 0;
            this.buttonRemove.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonRemove.Icon = null;
            this.buttonRemove.Location = new System.Drawing.Point(197, 204);
            this.buttonRemove.MouseState = RSBot.Theme.IMatMouseState.HOVER;
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Primary = true;
            this.buttonRemove.Raised = true;
            this.buttonRemove.SingleColor = System.Drawing.Color.IndianRed;
            this.buttonRemove.Size = new System.Drawing.Size(72, 23);
            this.buttonRemove.TabIndex = 10;
            this.buttonRemove.Text = "Remove";
            this.buttonRemove.UseVisualStyleBackColor = true;
            this.buttonRemove.Click += new System.EventHandler(this.buttonRemove_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(192, 109);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(163, 15);
            this.label5.TabIndex = 6;
            this.label5.Text = "Secondary Password: (Global)";
            // 
            // textBoxSecondaryPassword
            // 
            this.textBoxSecondaryPassword.Location = new System.Drawing.Point(195, 126);
            this.textBoxSecondaryPassword.Name = "textBoxSecondaryPassword";
            this.textBoxSecondaryPassword.Size = new System.Drawing.Size(185, 23);
            this.textBoxSecondaryPassword.TabIndex = 2;
            this.textBoxSecondaryPassword.UseSystemPasswordChar = true;
            // 
            // linkLabelSecondaryPassword
            // 
            this.linkLabelSecondaryPassword.AutoSize = true;
            this.linkLabelSecondaryPassword.Location = new System.Drawing.Point(339, 129);
            this.linkLabelSecondaryPassword.Name = "linkLabelSecondaryPassword";
            this.linkLabelSecondaryPassword.Size = new System.Drawing.Size(36, 15);
            this.linkLabelSecondaryPassword.TabIndex = 9;
            this.linkLabelSecondaryPassword.TabStop = true;
            this.linkLabelSecondaryPassword.Text = "Show";
            this.linkLabelSecondaryPassword.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelSecondaryPassword_LinkClicked);
            // 
            // Accounts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(394, 314);
            this.Controls.Add(this.linkLabelSecondaryPassword);
            this.Controls.Add(this.linkLabelPwShowHide);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtServername);
            this.Controls.Add(this.textBoxSecondaryPassword);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listAccounts);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.buttonRemove);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Accounts";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Stored accounts";
            this.Load += new System.EventHandler(this.Accounts_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private Theme.Material.Button btnCancel;
        private Theme.Material.Button btnOK;
        private System.Windows.Forms.ListBox listAccounts;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtServername;
        private Theme.Material.Button btnSave;
        private Theme.Material.Button btnAdd;
        private System.Windows.Forms.LinkLabel linkLabelPwShowHide;
        private Theme.Material.Button buttonRemove;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxSecondaryPassword;
        private System.Windows.Forms.LinkLabel linkLabelSecondaryPassword;
    }
}