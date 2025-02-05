namespace RSBot.General.Views
{
    partial class AccountsWindow
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
            textBoxSecondaryPassword = new System.Windows.Forms.TextBox();
            comboBoxChannel = new System.Windows.Forms.ComboBox();
            buttonRemove = new System.Windows.Forms.Button();
            listAccounts = new System.Windows.Forms.ListBox();
            label2 = new System.Windows.Forms.Label();
            txtUsername = new System.Windows.Forms.TextBox();
            label3 = new System.Windows.Forms.Label();
            txtPassword = new System.Windows.Forms.TextBox();
            label5 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            txtServername = new System.Windows.Forms.TextBox();
            btnSave = new System.Windows.Forms.Button();
            btnAdd = new System.Windows.Forms.Button();
            linkLabelPwShowHide = new System.Windows.Forms.LinkLabel();
            linkLabelSecondaryPassword = new System.Windows.Forms.LinkLabel();
            label1 = new System.Windows.Forms.Label();
            btnOK = new System.Windows.Forms.Button();
            btnCancel = new System.Windows.Forms.Button();
            panel1 = new System.Windows.Forms.Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // textBoxSecondaryPassword
            // 
            textBoxSecondaryPassword.Location = new System.Drawing.Point(246, 158);
            textBoxSecondaryPassword.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            textBoxSecondaryPassword.Name = "textBoxSecondaryPassword";
            textBoxSecondaryPassword.Size = new System.Drawing.Size(148, 27);
            textBoxSecondaryPassword.TabIndex = 2;
            textBoxSecondaryPassword.UseSystemPasswordChar = true;
            // 
            // comboBoxChannel
            // 
            comboBoxChannel.DropDownHeight = 100;
            comboBoxChannel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBoxChannel.FormattingEnabled = true;
            comboBoxChannel.IntegralHeight = false;
            comboBoxChannel.ItemHeight = 20;
            comboBoxChannel.Items.AddRange(new object[] { "Joymax", "JCPlanet" });
            comboBoxChannel.Location = new System.Drawing.Point(400, 158);
            comboBoxChannel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            comboBoxChannel.Name = "comboBoxChannel";
            comboBoxChannel.Size = new System.Drawing.Size(92, 28);
            comboBoxChannel.TabIndex = 11;
            // 
            // buttonRemove
            // 
            buttonRemove.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            buttonRemove.Location = new System.Drawing.Point(244, 259);
            buttonRemove.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            buttonRemove.Name = "buttonRemove";
            buttonRemove.Size = new System.Drawing.Size(90, 26);
            buttonRemove.TabIndex = 10;
            buttonRemove.Text = "Remove";
            buttonRemove.UseVisualStyleBackColor = true;
            buttonRemove.Click += buttonRemove_Click;
            // 
            // listAccounts
            // 
            listAccounts.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            listAccounts.Location = new System.Drawing.Point(10, 15);
            listAccounts.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            listAccounts.Name = "listAccounts";
            listAccounts.Size = new System.Drawing.Size(222, 262);
            listAccounts.TabIndex = 18;
            listAccounts.SelectedIndexChanged += listAccounts_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(242, 15);
            label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(78, 20);
            label2.TabIndex = 7;
            label2.Text = "Username:";
            // 
            // txtUsername
            // 
            txtUsername.Location = new System.Drawing.Point(246, 36);
            txtUsername.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new System.Drawing.Size(245, 27);
            txtUsername.TabIndex = 0;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(242, 75);
            label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(73, 20);
            label3.TabIndex = 6;
            label3.Text = "Password:";
            // 
            // txtPassword
            // 
            txtPassword.Location = new System.Drawing.Point(246, 96);
            txtPassword.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new System.Drawing.Size(245, 27);
            txtPassword.TabIndex = 1;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(240, 136);
            label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(204, 20);
            label5.TabIndex = 6;
            label5.Text = "Secondary Password: (Global)";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(240, 201);
            label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(94, 20);
            label4.TabIndex = 5;
            label4.Text = "Server name:";
            // 
            // txtServername
            // 
            txtServername.Location = new System.Drawing.Point(244, 222);
            txtServername.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            txtServername.Name = "txtServername";
            txtServername.Size = new System.Drawing.Size(248, 27);
            txtServername.TabIndex = 3;
            // 
            // btnSave
            // 
            btnSave.AutoSize = true;
            btnSave.Enabled = false;
            btnSave.Location = new System.Drawing.Point(402, 259);
            btnSave.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            btnSave.Name = "btnSave";
            btnSave.Size = new System.Drawing.Size(90, 30);
            btnSave.TabIndex = 5;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnAdd
            // 
            btnAdd.AutoSize = true;
            btnAdd.Font = new System.Drawing.Font("Segoe UI", 9F);
            btnAdd.Location = new System.Drawing.Point(244, 259);
            btnAdd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new System.Drawing.Size(90, 30);
            btnAdd.TabIndex = 4;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // linkLabelPwShowHide
            // 
            linkLabelPwShowHide.AutoSize = true;
            linkLabelPwShowHide.LinkColor = System.Drawing.SystemColors.ActiveCaptionText;
            linkLabelPwShowHide.Location = new System.Drawing.Point(442, 100);
            linkLabelPwShowHide.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            linkLabelPwShowHide.Name = "linkLabelPwShowHide";
            linkLabelPwShowHide.Size = new System.Drawing.Size(45, 20);
            linkLabelPwShowHide.TabIndex = 9;
            linkLabelPwShowHide.TabStop = true;
            linkLabelPwShowHide.Text = "Show";
            linkLabelPwShowHide.LinkClicked += linkLabelPwShowHide_LinkClicked;
            // 
            // linkLabelSecondaryPassword
            // 
            linkLabelSecondaryPassword.AutoSize = true;
            linkLabelSecondaryPassword.LinkColor = System.Drawing.Color.White;
            linkLabelSecondaryPassword.Location = new System.Drawing.Point(345, 161);
            linkLabelSecondaryPassword.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            linkLabelSecondaryPassword.Name = "linkLabelSecondaryPassword";
            linkLabelSecondaryPassword.Size = new System.Drawing.Size(45, 20);
            linkLabelSecondaryPassword.TabIndex = 9;
            linkLabelSecondaryPassword.TabStop = true;
            linkLabelSecondaryPassword.Text = "Show";
            linkLabelSecondaryPassword.LinkClicked += linkLabelSecondaryPassword_LinkClicked;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(0, 0);
            label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(0, 20);
            label1.TabIndex = 1;
            // 
            // btnOK
            // 
            btnOK.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            btnOK.AutoSize = true;
            btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            btnOK.Location = new System.Drawing.Point(13, 13);
            btnOK.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            btnOK.Name = "btnOK";
            btnOK.Size = new System.Drawing.Size(76, 30);
            btnOK.TabIndex = 6;
            btnOK.Text = "OK";
            btnOK.UseVisualStyleBackColor = true;
            btnOK.Click += btnOK_Click;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btnCancel.AutoSize = true;
            btnCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            btnCancel.Location = new System.Drawing.Point(434, 13);
            btnCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new System.Drawing.Size(63, 30);
            btnCancel.TabIndex = 7;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnCancel);
            panel1.Controls.Add(btnOK);
            panel1.Controls.Add(label1);
            panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            panel1.Location = new System.Drawing.Point(0, 303);
            panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(510, 56);
            panel1.TabIndex = 7;
            // 
            // AccountsWindow
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            BackColor = System.Drawing.Color.White;
            ClientSize = new System.Drawing.Size(510, 359);
            ControlBox = false;
            Controls.Add(listAccounts);
            Controls.Add(linkLabelSecondaryPassword);
            Controls.Add(linkLabelPwShowHide);
            Controls.Add(btnAdd);
            Controls.Add(btnSave);
            Controls.Add(txtServername);
            Controls.Add(label4);
            Controls.Add(label5);
            Controls.Add(txtPassword);
            Controls.Add(label3);
            Controls.Add(txtUsername);
            Controls.Add(label2);
            Controls.Add(panel1);
            Controls.Add(buttonRemove);
            Controls.Add(comboBoxChannel);
            Controls.Add(textBoxSecondaryPassword);
            Font = new System.Drawing.Font("Segoe UI", 9F);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            MinimumSize = new System.Drawing.Size(511, 365);
            Name = "AccountsWindow";
            ShowIcon = false;
            SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Load += Accounts_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox textBoxSecondaryPassword;
        private System.Windows.Forms.ComboBox comboBoxChannel;
        private System.Windows.Forms.Button buttonRemove;
        private System.Windows.Forms.ListBox listAccounts;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtServername;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.LinkLabel linkLabelPwShowHide;
        private System.Windows.Forms.LinkLabel linkLabelSecondaryPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel panel1;
    }
}