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
            this.panel1 = new SDUI.Controls.Panel();
            this.btnCancel = new SDUI.Controls.Button();
            this.btnConfirm = new SDUI.Controls.Button();
            this.textBoxProxyIp = new SDUI.Controls.TextBox();
            this.label1 = new SDUI.Controls.Label();
            this.label2 = new SDUI.Controls.Label();
            this.numUpDownProxyPort = new SDUI.Controls.NumUpDown();
            this.label3 = new SDUI.Controls.Label();
            this.comboBoxProxyVersion = new SDUI.Controls.ComboBox();
            this.textBoxId = new SDUI.Controls.TextBox();
            this.label4 = new SDUI.Controls.Label();
            this.checkBoxOnOf = new SDUI.Controls.CheckBox();
            this.textBoxPw = new SDUI.Controls.TextBox();
            this.label6 = new SDUI.Controls.Label();
            this.label7 = new SDUI.Controls.Label();
            this.label8 = new SDUI.Controls.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownProxyPort)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Border = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.panel1.BorderColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnConfirm);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 333);
            this.panel1.Name = "panel1";
            this.panel1.Radius = 0;
            this.panel1.ShadowDepth = 4F;
            this.panel1.Size = new System.Drawing.Size(319, 49);
            this.panel1.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Color = System.Drawing.Color.Transparent;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(228, 14);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Radius = 6;
            this.btnCancel.ShadowDepth = 4F;
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnConfirm
            // 
            this.btnConfirm.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnConfirm.Color = System.Drawing.Color.Transparent;
            this.btnConfirm.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnConfirm.Location = new System.Drawing.Point(12, 14);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Radius = 6;
            this.btnConfirm.ShadowDepth = 4F;
            this.btnConfirm.Size = new System.Drawing.Size(75, 23);
            this.btnConfirm.TabIndex = 0;
            this.btnConfirm.Text = "Confirm";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // textBoxProxyIp
            // 
            this.textBoxProxyIp.Location = new System.Drawing.Point(10, 53);
            this.textBoxProxyIp.MaxLength = 32767;
            this.textBoxProxyIp.MultiLine = false;
            this.textBoxProxyIp.Name = "textBoxProxyIp";
            this.textBoxProxyIp.Radius = 2;
            this.textBoxProxyIp.Size = new System.Drawing.Size(301, 21);
            this.textBoxProxyIp.TabIndex = 2;
            this.textBoxProxyIp.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.textBoxProxyIp.UseSystemPasswordChar = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(10, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Proxy Ip:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(10, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Proxy Port:";
            // 
            // numUpDownProxyPort
            // 
            this.numUpDownProxyPort.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.numUpDownProxyPort.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numUpDownProxyPort.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.numUpDownProxyPort.Location = new System.Drawing.Point(10, 104);
            this.numUpDownProxyPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numUpDownProxyPort.Name = "numUpDownProxyPort";
            this.numUpDownProxyPort.Size = new System.Drawing.Size(301, 23);
            this.numUpDownProxyPort.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(10, 277);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "Proxy Type:";
            // 
            // comboBoxProxyVersion
            // 
            this.comboBoxProxyVersion.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBoxProxyVersion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxProxyVersion.FormattingEnabled = true;
            this.comboBoxProxyVersion.Items.AddRange(new object[] {
            "Socks4",
            "Socks5"});
            this.comboBoxProxyVersion.Location = new System.Drawing.Point(10, 295);
            this.comboBoxProxyVersion.Name = "comboBoxProxyVersion";
            this.comboBoxProxyVersion.Radius = 5;
            this.comboBoxProxyVersion.ShadowDepth = 4F;
            this.comboBoxProxyVersion.Size = new System.Drawing.Size(301, 24);
            this.comboBoxProxyVersion.TabIndex = 5;
            // 
            // textBoxId
            // 
            this.textBoxId.Location = new System.Drawing.Point(10, 177);
            this.textBoxId.MaxLength = 32767;
            this.textBoxId.MultiLine = false;
            this.textBoxId.Name = "textBoxId";
            this.textBoxId.Radius = 2;
            this.textBoxId.Size = new System.Drawing.Size(301, 21);
            this.textBoxId.TabIndex = 2;
            this.textBoxId.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.textBoxId.UseSystemPasswordChar = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label4.Location = new System.Drawing.Point(10, 140);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "Proxy Username:";
            // 
            // checkBoxOnOf
            // 
            this.checkBoxOnOf.AutoSize = true;
            this.checkBoxOnOf.BackColor = System.Drawing.Color.Transparent;
            this.checkBoxOnOf.Location = new System.Drawing.Point(12, 12);
            this.checkBoxOnOf.Name = "checkBoxOnOf";
            this.checkBoxOnOf.ShadowDepth = 1;
            this.checkBoxOnOf.Size = new System.Drawing.Size(179, 15);
            this.checkBoxOnOf.TabIndex = 8;
            this.checkBoxOnOf.Text = "Activate Proxy (Experimental)";
            this.checkBoxOnOf.UseVisualStyleBackColor = false;
            // 
            // textBoxPw
            // 
            this.textBoxPw.Location = new System.Drawing.Point(10, 243);
            this.textBoxPw.MaxLength = 32767;
            this.textBoxPw.MultiLine = false;
            this.textBoxPw.Name = "textBoxPw";
            this.textBoxPw.Radius = 2;
            this.textBoxPw.Size = new System.Drawing.Size(301, 21);
            this.textBoxPw.TabIndex = 2;
            this.textBoxPw.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.textBoxPw.UseSystemPasswordChar = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label6.Location = new System.Drawing.Point(10, 211);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 15);
            this.label6.TabIndex = 3;
            this.label6.Text = "Proxy password:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label7.Location = new System.Drawing.Point(10, 157);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(238, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "If you don\'t want to use it, you can leave it blank.";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label8.Location = new System.Drawing.Point(12, 227);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(238, 13);
            this.label8.TabIndex = 3;
            this.label8.Text = "If you don\'t want to use it, you can leave it blank.";
            // 
            // ConfigDialog
            // 
            this.AcceptButton = this.btnConfirm;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(319, 382);
            this.Controls.Add(this.checkBoxOnOf);
            this.Controls.Add(this.comboBoxProxyVersion);
            this.Controls.Add(this.numUpDownProxyPort);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxPw);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxId);
            this.Controls.Add(this.textBoxProxyIp);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConfigDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Proxy Config";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ConfigDialog_FormClosing);
            this.Load += new System.EventHandler(this.ExitDialog_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownProxyPort)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private SDUI.Controls.Panel panel1;
        private SDUI.Controls.Button btnCancel;
        private SDUI.Controls.Button btnConfirm;
        private SDUI.Controls.TextBox textBoxProxyIp;
        private SDUI.Controls.Label label1;
        private SDUI.Controls.Label label2;
        private SDUI.Controls.NumUpDown numUpDownProxyPort;
        private SDUI.Controls.Label label3;
        private SDUI.Controls.ComboBox comboBoxProxyVersion;
        private SDUI.Controls.TextBox textBoxId;
        private SDUI.Controls.Label label4;
        private SDUI.Controls.CheckBox checkBoxOnOf;
        private SDUI.Controls.TextBox textBoxPw;
        private SDUI.Controls.Label label6;
        private SDUI.Controls.Label label7;
        private SDUI.Controls.Label label8;
    }
}