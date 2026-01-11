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
            textBoxSecondaryPassword = new SDUI.Controls.TextBox();
            comboBoxChannel = new SDUI.Controls.ComboBox();
            buttonRemove = new SDUI.Controls.Button();
            listAccounts = new SDUI.Controls.ListBox();
            label2 = new SDUI.Controls.Label();
            txtUsername = new SDUI.Controls.TextBox();
            label3 = new SDUI.Controls.Label();
            txtPassword = new SDUI.Controls.TextBox();
            label5 = new SDUI.Controls.Label();
            label4 = new SDUI.Controls.Label();
            txtServername = new SDUI.Controls.TextBox();
            btnSave = new SDUI.Controls.Button();
            btnAdd = new SDUI.Controls.Button();
            linkLabelPwShowHide = new SDUI.Controls.Label();
            linkLabelSecondaryPassword = new SDUI.Controls.Label();
            label1 = new SDUI.Controls.Label();
            btnOK = new SDUI.Controls.Button();
            btnCancel = new SDUI.Controls.Button();
            panel1 = new SDUI.Controls.Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // textBoxSecondaryPassword
            // 
            textBoxSecondaryPassword.Location = new System.Drawing.Point(197, 126);
            textBoxSecondaryPassword.MaxLength = 32767;
            textBoxSecondaryPassword.MultiLine = false;
            textBoxSecondaryPassword.Name = "textBoxSecondaryPassword";
            textBoxSecondaryPassword.PassFocusShow = false;
            textBoxSecondaryPassword.Radius = 2;
            textBoxSecondaryPassword.Size = new System.Drawing.Size(119, 21);
            textBoxSecondaryPassword.TabIndex = 2;
            textBoxSecondaryPassword.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            textBoxSecondaryPassword.UseSystemPasswordChar = true;
            // 
            // comboBoxChannel
            // 
            comboBoxChannel.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            comboBoxChannel.DropDownHeight = 100;
            comboBoxChannel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBoxChannel.FormattingEnabled = true;
            comboBoxChannel.IntegralHeight = false;
            comboBoxChannel.ItemHeight = 17;
            comboBoxChannel.Items.AddRange(new object[] { "Joymax", "JCPlanet" });
            comboBoxChannel.Location = new System.Drawing.Point(320, 126);
            comboBoxChannel.Name = "comboBoxChannel";
            comboBoxChannel.Radius = 5;
            comboBoxChannel.ShadowDepth = 4F;
            comboBoxChannel.Size = new System.Drawing.Size(74, 23);
            comboBoxChannel.TabIndex = 11;
            // 
            // buttonRemove
            // 
            buttonRemove.Color = System.Drawing.Color.DarkRed;
            buttonRemove.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            buttonRemove.ForeColor = System.Drawing.Color.White;
            buttonRemove.Location = new System.Drawing.Point(195, 207);
            buttonRemove.Name = "buttonRemove";
            buttonRemove.Radius = 6;
            buttonRemove.ShadowDepth = 4F;
            buttonRemove.Size = new System.Drawing.Size(72, 21);
            buttonRemove.TabIndex = 10;
            buttonRemove.Text = "Remove";
            buttonRemove.UseVisualStyleBackColor = true;
            buttonRemove.Click += buttonRemove_Click;
            // 
            // listAccounts
            // 
            listAccounts.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            listAccounts.ItemHeight = 15;
            listAccounts.Location = new System.Drawing.Point(8, 12);
            listAccounts.Name = "listAccounts";
            listAccounts.Size = new System.Drawing.Size(178, 212);
            listAccounts.TabIndex = 18;
            listAccounts.SelectedIndexChanged += listAccounts_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.ApplyGradient = false;
            label2.AutoSize = true;
            label2.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            label2.Gradient = new System.Drawing.Color[]
    {
    System.Drawing.Color.Gray,
    System.Drawing.Color.Black
    };
            label2.GradientAnimation = false;
            label2.Location = new System.Drawing.Point(194, 12);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(63, 15);
            label2.TabIndex = 7;
            label2.Text = "Username:";
            // 
            // txtUsername
            // 
            txtUsername.Location = new System.Drawing.Point(197, 29);
            txtUsername.MaxLength = 32767;
            txtUsername.MultiLine = false;
            txtUsername.Name = "txtUsername";
            txtUsername.PassFocusShow = false;
            txtUsername.Radius = 2;
            txtUsername.Size = new System.Drawing.Size(197, 21);
            txtUsername.TabIndex = 0;
            txtUsername.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            txtUsername.UseSystemPasswordChar = false;
            // 
            // label3
            // 
            label3.ApplyGradient = false;
            label3.AutoSize = true;
            label3.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            label3.Gradient = new System.Drawing.Color[]
    {
    System.Drawing.Color.Gray,
    System.Drawing.Color.Black
    };
            label3.GradientAnimation = false;
            label3.Location = new System.Drawing.Point(194, 60);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(60, 15);
            label3.TabIndex = 6;
            label3.Text = "Password:";
            // 
            // txtPassword
            // 
            txtPassword.Location = new System.Drawing.Point(197, 77);
            txtPassword.MaxLength = 32767;
            txtPassword.MultiLine = false;
            txtPassword.Name = "txtPassword";
            txtPassword.PassFocusShow = false;
            txtPassword.Radius = 2;
            txtPassword.Size = new System.Drawing.Size(197, 21);
            txtPassword.TabIndex = 1;
            txtPassword.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // label5
            // 
            label5.ApplyGradient = false;
            label5.AutoSize = true;
            label5.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            label5.Gradient = new System.Drawing.Color[]
    {
    System.Drawing.Color.Gray,
    System.Drawing.Color.Black
    };
            label5.GradientAnimation = false;
            label5.Location = new System.Drawing.Point(192, 109);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(163, 15);
            label5.TabIndex = 6;
            label5.Text = "Secondary Password: (Global)";
            // 
            // label4
            // 
            label4.ApplyGradient = false;
            label4.AutoSize = true;
            label4.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            label4.Gradient = new System.Drawing.Color[]
    {
    System.Drawing.Color.Gray,
    System.Drawing.Color.Black
    };
            label4.GradientAnimation = false;
            label4.Location = new System.Drawing.Point(192, 161);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(75, 15);
            label4.TabIndex = 5;
            label4.Text = "Server name:";
            // 
            // txtServername
            // 
            txtServername.Location = new System.Drawing.Point(195, 178);
            txtServername.MaxLength = 32767;
            txtServername.MultiLine = false;
            txtServername.Name = "txtServername";
            txtServername.PassFocusShow = false;
            txtServername.Radius = 2;
            txtServername.Size = new System.Drawing.Size(199, 21);
            txtServername.TabIndex = 3;
            txtServername.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            txtServername.UseSystemPasswordChar = false;
            // 
            // btnSave
            // 
            btnSave.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            btnSave.Color = System.Drawing.Color.Transparent;
            btnSave.Enabled = false;
            btnSave.Location = new System.Drawing.Point(322, 207);
            btnSave.Name = "btnSave";
            btnSave.Radius = 6;
            btnSave.ShadowDepth = 4F;
            btnSave.Size = new System.Drawing.Size(72, 21);
            btnSave.TabIndex = 5;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnAdd
            // 
            btnAdd.Color = System.Drawing.Color.FromArgb(33, 150, 243);
            btnAdd.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            btnAdd.ForeColor = System.Drawing.Color.White;
            btnAdd.Location = new System.Drawing.Point(195, 207);
            btnAdd.Name = "btnAdd";
            btnAdd.Radius = 6;
            btnAdd.ShadowDepth = 4F;
            btnAdd.Size = new System.Drawing.Size(72, 21);
            btnAdd.TabIndex = 4;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // linkLabelPwShowHide
            // 
            linkLabelPwShowHide.AutoSize = true;
            linkLabelPwShowHide.BackColor = System.Drawing.Color.DimGray;
            linkLabelPwShowHide.ForeColor = System.Drawing.Color.White;
            linkLabelPwShowHide.Location = new System.Drawing.Point(354, 80);
            linkLabelPwShowHide.Name = "linkLabelPwShowHide";
            linkLabelPwShowHide.Size = new System.Drawing.Size(36, 15);
            linkLabelPwShowHide.TabIndex = 9;
            linkLabelPwShowHide.TabStop = true;
            linkLabelPwShowHide.Text = "Show";
            linkLabelPwShowHide.Click += linkLabelPwShowHide_LinkClicked;
            // 
            // linkLabelSecondaryPassword
            // 
            linkLabelSecondaryPassword.AutoSize = true;
            linkLabelSecondaryPassword.BackColor = System.Drawing.Color.DimGray;
            linkLabelSecondaryPassword.ForeColor = System.Drawing.Color.White;
            linkLabelSecondaryPassword.Location = new System.Drawing.Point(276, 129);
            linkLabelSecondaryPassword.Name = "linkLabelSecondaryPassword";
            linkLabelSecondaryPassword.Size = new System.Drawing.Size(36, 15);
            linkLabelSecondaryPassword.TabIndex = 9;
            linkLabelSecondaryPassword.TabStop = true;
            linkLabelSecondaryPassword.Text = "Show";
            linkLabelSecondaryPassword.Click += linkLabelSecondaryPassword_LinkClicked;
            // 
            // label1
            // 
            label1.ApplyGradient = false;
            label1.AutoSize = true;
            label1.Gradient = new System.Drawing.Color[]
    {
    System.Drawing.Color.Gray,
    System.Drawing.Color.Black
    };
            label1.GradientAnimation = false;
            label1.Location = new System.Drawing.Point(0, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(0, 15);
            label1.TabIndex = 1;
            // 
            // btnOK
            // 
            btnOK.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            btnOK.Color = System.Drawing.Color.Transparent;
            btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            btnOK.Location = new System.Drawing.Point(12, 12);
            btnOK.Name = "btnOK";
            btnOK.Radius = 6;
            btnOK.ShadowDepth = 4F;
            btnOK.Size = new System.Drawing.Size(72, 21);
            btnOK.TabIndex = 6;
            btnOK.Text = "OK";
            btnOK.UseVisualStyleBackColor = true;
            btnOK.Click += btnOK_Click;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btnCancel.Color = System.Drawing.Color.Transparent;
            btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            btnCancel.Location = new System.Drawing.Point(328, 12);
            btnCancel.Name = "btnCancel";
            btnCancel.Radius = 6;
            btnCancel.ShadowDepth = 4F;
            btnCancel.Size = new System.Drawing.Size(72, 21);
            btnCancel.TabIndex = 7;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.BackColor = System.Drawing.Color.Transparent;
            panel1.Border = new System.Windows.Forms.Padding(0, 1, 0, 0);
            panel1.BorderColor = System.Drawing.Color.Transparent;
            panel1.Controls.Add(btnCancel);
            panel1.Controls.Add(btnOK);
            panel1.Controls.Add(label1);
            panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            panel1.Location = new System.Drawing.Point(0, 242);
            panel1.Name = "panel1";
            panel1.Radius = 0;
            panel1.ShadowDepth = 4F;
            panel1.Size = new System.Drawing.Size(408, 45);
            panel1.TabIndex = 7;
            // 
            // AccountsWindow
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            BackColor = System.Drawing.Color.White;
            ClientSize = new System.Drawing.Size(408, 283);
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
            Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            MinimumSize = new System.Drawing.Size(410, 293);
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

        private SDUI.Controls.TextBox textBoxSecondaryPassword;
        private SDUI.Controls.ComboBox comboBoxChannel;
        private SDUI.Controls.Button buttonRemove;
        private SDUI.Controls.ListBox listAccounts;
        private SDUI.Controls.Label label2;
        private SDUI.Controls.TextBox txtUsername;
        private SDUI.Controls.Label label3;
        private SDUI.Controls.TextBox txtPassword;
        private SDUI.Controls.Label label5;
        private SDUI.Controls.Label label4;
        private SDUI.Controls.TextBox txtServername;
        private SDUI.Controls.Button btnSave;
        private SDUI.Controls.Button btnAdd;
        private SDUI.Controls.Label linkLabelPwShowHide;
        private SDUI.Controls.Label linkLabelSecondaryPassword;
        private SDUI.Controls.Label label1;
        private SDUI.Controls.Button btnOK;
        private SDUI.Controls.Button btnCancel;
        private SDUI.Controls.Panel panel1;
    }
}
