namespace RSBot.Views
{
    partial class ConfigDialog
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
            panel1 = new System.Windows.Forms.Panel();
            btnCancel = new System.Windows.Forms.Button();
            btnConfirm = new System.Windows.Forms.Button();
            textBoxProxyIp = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            comboBoxProxyVersion = new System.Windows.Forms.ComboBox();
            textBoxId = new System.Windows.Forms.TextBox();
            label4 = new System.Windows.Forms.Label();
            checkBoxOnOf = new System.Windows.Forms.CheckBox();
            textBoxPw = new System.Windows.Forms.TextBox();
            label6 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            textBoxPort = new System.Windows.Forms.TextBox();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            
            panel1.Controls.Add(btnCancel);
            panel1.Controls.Add(btnConfirm);
            panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            panel1.Location = new System.Drawing.Point(0, 393);
            panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(409, 61);
            panel1.TabIndex = 1;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            btnCancel.Location = new System.Drawing.Point(295, 18);
            btnCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new System.Drawing.Size(94, 29);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnConfirm
            // 
            btnConfirm.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            btnConfirm.DialogResult = System.Windows.Forms.DialogResult.OK;
            btnConfirm.Location = new System.Drawing.Point(15, 18);
            btnConfirm.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new System.Drawing.Size(94, 29);
            btnConfirm.TabIndex = 0;
            btnConfirm.Text = "Confirm";
            btnConfirm.UseVisualStyleBackColor = true;
            btnConfirm.Click += btnConfirm_Click;
            // 
            // textBoxProxyIp
            // 
            textBoxProxyIp.Location = new System.Drawing.Point(15, 90);
            textBoxProxyIp.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            textBoxProxyIp.Name = "textBoxProxyIp";
            textBoxProxyIp.Size = new System.Drawing.Size(274, 27);
            textBoxProxyIp.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            label1.Location = new System.Drawing.Point(15, 68);
            label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(65, 20);
            label1.TabIndex = 3;
            label1.Text = "Proxy Ip:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            label2.Location = new System.Drawing.Point(300, 68);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(78, 20);
            label2.TabIndex = 3;
            label2.Text = "Proxy Port:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            label3.Location = new System.Drawing.Point(18, 309);
            label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            
            label3.Size = new System.Drawing.Size(83, 20);
            label3.TabIndex = 3;
            label3.Text = "Proxy Type:";
            // 
            // comboBoxProxyVersion
            // 
            comboBoxProxyVersion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBoxProxyVersion.FormattingEnabled = true;
            comboBoxProxyVersion.Items.AddRange(new object[] { "Socks4", "Socks5" });
            comboBoxProxyVersion.Location = new System.Drawing.Point(18, 331);
            comboBoxProxyVersion.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            
            comboBoxProxyVersion.Size = new System.Drawing.Size(375, 28);
            comboBoxProxyVersion.TabIndex = 5;
            // 
            // textBoxId
            // 
            textBoxId.Location = new System.Drawing.Point(18, 184);
            textBoxId.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            textBoxId.Name = "textBoxId";
            textBoxId.Size = new System.Drawing.Size(375, 27);
            textBoxId.TabIndex = 2;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            label4.Location = new System.Drawing.Point(18, 138);
            label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(118, 20);
            label4.TabIndex = 3;
            label4.Text = "Proxy Username:";
            // 
            // checkBoxOnOf
            // 
            checkBoxOnOf.AutoSize = true;
            checkBoxOnOf.BackColor = System.Drawing.SystemColors.Control;
            checkBoxOnOf.Location = new System.Drawing.Point(15, 11);
            checkBoxOnOf.Margin = new System.Windows.Forms.Padding(0);
            checkBoxOnOf.Name = "checkBoxOnOf";
            checkBoxOnOf.Size = new System.Drawing.Size(85, 24);
            checkBoxOnOf.TabIndex = 8;
            checkBoxOnOf.Text = "Activate";
            checkBoxOnOf.UseVisualStyleBackColor = false;
            // 
            // textBoxPw
            // 
            textBoxPw.Location = new System.Drawing.Point(18, 266);
            textBoxPw.Name = "textBoxPw";
            textBoxPw.Size = new System.Drawing.Size(375, 27);
            textBoxPw.TabIndex = 2;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            label6.Location = new System.Drawing.Point(18, 226);
            label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            
            label6.Size = new System.Drawing.Size(115, 20);
            label6.TabIndex = 3;
            label6.Text = "Proxy password:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Italic);
            label7.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            label7.Location = new System.Drawing.Point(18, 159);
            label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(318, 19);
            label7.TabIndex = 3;
            label7.Text = "If you don't want to use it, you can leave it blank.";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Italic);
            label8.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            label8.Location = new System.Drawing.Point(20, 246);
            label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(318, 19);
            label8.TabIndex = 3;
            label8.Text = "If you don't want to use it, you can leave it blank.";
            // 
            
            // 
            textBoxPort.Location = new System.Drawing.Point(298, 90);
            textBoxPort.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            textBoxPort.Name = "textBoxPort";
            textBoxPort.Size = new System.Drawing.Size(93, 27);
            textBoxPort.TabIndex = 10;
            textBoxPort.Text = "0";
            // 
            // ConfigDialog
            // 
            AcceptButton = btnConfirm;
            AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            
            CancelButton = btnCancel;
            ClientSize = new System.Drawing.Size(409, 454);
            Controls.Add(textBoxPort);
            Controls.Add(checkBoxOnOf);
            Controls.Add(comboBoxProxyVersion);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label6);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label4);
            Controls.Add(textBoxPw);
            
            Controls.Add(textBoxId);
            Controls.Add(textBoxProxyIp);
            Controls.Add(panel1);
            ForeColor = System.Drawing.Color.Black;
            Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ConfigDialog";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "Proxy Config";
            FormClosing += ConfigDialog_FormClosing;
            Load += ExitDialog_Load;
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.TextBox textBoxProxyIp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxProxyVersion;
        private System.Windows.Forms.TextBox textBoxId;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkBoxOnOf;
        private System.Windows.Forms.TextBox textBoxPw;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxPort;
    }
}