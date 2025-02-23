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
            panel1 = new SDUI.Controls.Panel();
            btnCancel = new SDUI.Controls.Button();
            btnConfirm = new SDUI.Controls.Button();
            textBoxProxyIp = new SDUI.Controls.TextBox();
            label1 = new SDUI.Controls.Label();
            label2 = new SDUI.Controls.Label();
            label3 = new SDUI.Controls.Label();
            comboBoxProxyVersion = new SDUI.Controls.ComboBox();
            textBoxId = new SDUI.Controls.TextBox();
            label4 = new SDUI.Controls.Label();
            checkBoxOnOf = new SDUI.Controls.CheckBox();
            textBoxPw = new SDUI.Controls.TextBox();
            label6 = new SDUI.Controls.Label();
            label7 = new SDUI.Controls.Label();
            label8 = new SDUI.Controls.Label();
            textBoxPort = new SDUI.Controls.TextBox();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = System.Drawing.Color.Transparent;
            panel1.Border = new System.Windows.Forms.Padding(0, 1, 0, 0);
            panel1.BorderColor = System.Drawing.Color.Transparent;
            panel1.Controls.Add(btnCancel);
            panel1.Controls.Add(btnConfirm);
            panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            panel1.Location = new System.Drawing.Point(0, 314);
            panel1.Name = "panel1";
            panel1.Radius = 0;
            panel1.ShadowDepth = 4F;
            panel1.Size = new System.Drawing.Size(327, 49);
            panel1.TabIndex = 1;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnCancel.Color = System.Drawing.Color.Transparent;
            btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            btnCancel.Location = new System.Drawing.Point(236, 14);
            btnCancel.Name = "btnCancel";
            btnCancel.Radius = 6;
            btnCancel.ShadowDepth = 4F;
            btnCancel.Size = new System.Drawing.Size(75, 23);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnConfirm
            // 
            btnConfirm.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            btnConfirm.Color = System.Drawing.Color.Transparent;
            btnConfirm.DialogResult = System.Windows.Forms.DialogResult.OK;
            btnConfirm.Location = new System.Drawing.Point(12, 14);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Radius = 6;
            btnConfirm.ShadowDepth = 4F;
            btnConfirm.Size = new System.Drawing.Size(75, 23);
            btnConfirm.TabIndex = 0;
            btnConfirm.Text = "Confirm";
            btnConfirm.UseVisualStyleBackColor = true;
            btnConfirm.Click += btnConfirm_Click;
            // 
            // textBoxProxyIp
            // 
            textBoxProxyIp.Location = new System.Drawing.Point(12, 72);
            textBoxProxyIp.MaxLength = 32767;
            textBoxProxyIp.MultiLine = false;
            textBoxProxyIp.Name = "textBoxProxyIp";
            textBoxProxyIp.PassFocusShow = false;
            textBoxProxyIp.Radius = 2;
            textBoxProxyIp.Size = new System.Drawing.Size(220, 21);
            textBoxProxyIp.TabIndex = 2;
            textBoxProxyIp.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            textBoxProxyIp.UseSystemPasswordChar = false;
            // 
            // label1
            // 
            label1.ApplyGradient = false;
            label1.AutoSize = true;
            label1.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            label1.Gradient = new System.Drawing.Color[]
    {
    System.Drawing.Color.Gray,
    System.Drawing.Color.Black
    };
            label1.GradientAnimation = false;
            label1.Location = new System.Drawing.Point(12, 54);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(53, 15);
            label1.TabIndex = 3;
            label1.Text = "Proxy IP:";
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
            label2.Location = new System.Drawing.Point(240, 54);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(65, 15);
            label2.TabIndex = 3;
            label2.Text = "Proxy Port:";
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
            label3.Location = new System.Drawing.Point(14, 247);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(67, 15);
            label3.TabIndex = 3;
            label3.Text = "Proxy Type:";
            // 
            // comboBoxProxyVersion
            // 
            comboBoxProxyVersion.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            comboBoxProxyVersion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBoxProxyVersion.FormattingEnabled = true;
            comboBoxProxyVersion.Items.AddRange(new object[] { "Socks4", "Socks5" });
            comboBoxProxyVersion.Location = new System.Drawing.Point(14, 265);
            comboBoxProxyVersion.Name = "comboBoxProxyVersion";
            comboBoxProxyVersion.Radius = 5;
            comboBoxProxyVersion.ShadowDepth = 4F;
            comboBoxProxyVersion.Size = new System.Drawing.Size(301, 24);
            comboBoxProxyVersion.TabIndex = 5;
            // 
            // textBoxId
            // 
            textBoxId.Location = new System.Drawing.Point(14, 147);
            textBoxId.MaxLength = 32767;
            textBoxId.MultiLine = false;
            textBoxId.Name = "textBoxId";
            textBoxId.PassFocusShow = false;
            textBoxId.Radius = 2;
            textBoxId.Size = new System.Drawing.Size(301, 21);
            textBoxId.TabIndex = 2;
            textBoxId.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            textBoxId.UseSystemPasswordChar = false;
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
            label4.Location = new System.Drawing.Point(14, 110);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(96, 15);
            label4.TabIndex = 3;
            label4.Text = "Proxy Username:";
            // 
            // checkBoxOnOf
            // 
            checkBoxOnOf.AutoSize = true;
            checkBoxOnOf.BackColor = System.Drawing.Color.Transparent;
            checkBoxOnOf.Depth = 0;
            checkBoxOnOf.Location = new System.Drawing.Point(12, 9);
            checkBoxOnOf.Margin = new System.Windows.Forms.Padding(0);
            checkBoxOnOf.MouseLocation = new System.Drawing.Point(-1, -1);
            checkBoxOnOf.Name = "checkBoxOnOf";
            checkBoxOnOf.Ripple = true;
            checkBoxOnOf.Size = new System.Drawing.Size(73, 30);
            checkBoxOnOf.TabIndex = 8;
            checkBoxOnOf.Text = "Activate";
            checkBoxOnOf.UseVisualStyleBackColor = false;
            // 
            // textBoxPw
            // 
            textBoxPw.Location = new System.Drawing.Point(14, 213);
            textBoxPw.MaxLength = 32767;
            textBoxPw.MultiLine = false;
            textBoxPw.Name = "textBoxPw";
            textBoxPw.PassFocusShow = false;
            textBoxPw.Radius = 2;
            textBoxPw.Size = new System.Drawing.Size(301, 21);
            textBoxPw.TabIndex = 2;
            textBoxPw.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            textBoxPw.UseSystemPasswordChar = false;
            // 
            // label6
            // 
            label6.ApplyGradient = false;
            label6.AutoSize = true;
            label6.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            label6.Gradient = new System.Drawing.Color[]
    {
    System.Drawing.Color.Gray,
    System.Drawing.Color.Black
    };
            label6.GradientAnimation = false;
            label6.Location = new System.Drawing.Point(14, 181);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(93, 15);
            label6.TabIndex = 3;
            label6.Text = "Proxy password:";
            // 
            // label7
            // 
            label7.ApplyGradient = false;
            label7.AutoSize = true;
            label7.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            label7.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            label7.Gradient = new System.Drawing.Color[]
    {
    System.Drawing.Color.Gray,
    System.Drawing.Color.Black
    };
            label7.GradientAnimation = false;
            label7.Location = new System.Drawing.Point(14, 127);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(238, 13);
            label7.TabIndex = 3;
            label7.Text = "If you don't want to use it, you can leave it blank.";
            // 
            // label8
            // 
            label8.ApplyGradient = false;
            label8.AutoSize = true;
            label8.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            label8.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            label8.Gradient = new System.Drawing.Color[]
    {
    System.Drawing.Color.Gray,
    System.Drawing.Color.Black
    };
            label8.GradientAnimation = false;
            label8.Location = new System.Drawing.Point(16, 197);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(238, 13);
            label8.TabIndex = 3;
            label8.Text = "If you don't want to use it, you can leave it blank.";
            // 
            // textBoxPort
            // 
            textBoxPort.Location = new System.Drawing.Point(238, 72);
            textBoxPort.MaxLength = 32767;
            textBoxPort.MultiLine = false;
            textBoxPort.Name = "textBoxPort";
            textBoxPort.PassFocusShow = false;
            textBoxPort.Radius = 2;
            textBoxPort.Size = new System.Drawing.Size(75, 21);
            textBoxPort.TabIndex = 10;
            textBoxPort.Text = "0";
            textBoxPort.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            textBoxPort.UseSystemPasswordChar = false;
            // 
            // ConfigDialog
            // 
            AcceptButton = btnConfirm;
            AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            BackColor = System.Drawing.Color.White;
            CancelButton = btnCancel;
            ClientSize = new System.Drawing.Size(327, 363);
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
            Controls.Add(label1);
            Controls.Add(textBoxId);
            Controls.Add(textBoxProxyIp);
            Controls.Add(panel1);
            DwmMargin = -1;
            ForeColor = System.Drawing.Color.Black;
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
        private SDUI.Controls.Panel panel1;
        private SDUI.Controls.Button btnCancel;
        private SDUI.Controls.Button btnConfirm;
        private SDUI.Controls.TextBox textBoxProxyIp;
        private SDUI.Controls.Label label1;
        private SDUI.Controls.Label label2;
        private SDUI.Controls.Label label3;
        private SDUI.Controls.ComboBox comboBoxProxyVersion;
        private SDUI.Controls.TextBox textBoxId;
        private SDUI.Controls.Label label4;
        private SDUI.Controls.CheckBox checkBoxOnOf;
        private SDUI.Controls.TextBox textBoxPw;
        private SDUI.Controls.Label label6;
        private SDUI.Controls.Label label7;
        private SDUI.Controls.Label label8;
        private SDUI.Controls.TextBox textBoxPort;
    }
}