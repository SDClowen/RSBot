using System.Reflection.PortableExecutable;

namespace RSBot.General.Views
{
    partial class SoundNotificationWindow
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
            label1 = new SDUI.Controls.Label();
            btnOK = new SDUI.Controls.Button();
            btnCancel = new SDUI.Controls.Button();
            panel1 = new SDUI.Controls.Panel();
            chkUniqueInRange = new SDUI.Controls.CheckBox();
            btnUniqueInRange = new SDUI.Controls.Button();
            chkUniqueAppearedGeneral = new SDUI.Controls.CheckBox();
            btnUniqueAppearedGeneral = new SDUI.Controls.Button();
            txtRegex = new SDUI.Controls.TextBox();
            lblRegex = new SDUI.Controls.Label();
            txtUniqueAppearedGeneral = new SDUI.Controls.TextBox();
            txtUniqueInRange = new SDUI.Controls.TextBox();
            chkTigerGirl = new SDUI.Controls.CheckBox();
            chkIvy = new SDUI.Controls.CheckBox();
            chkUruchi = new SDUI.Controls.CheckBox();
            chkCerberus = new SDUI.Controls.CheckBox();
            chkIsyutaru = new SDUI.Controls.CheckBox();
            chkLordYarkan = new SDUI.Controls.CheckBox();
            chkDemonChaitan = new SDUI.Controls.CheckBox();
            txtTigerGirl = new SDUI.Controls.TextBox();
            txtCerberus = new SDUI.Controls.TextBox();
            txtIvy = new SDUI.Controls.TextBox();
            txtUruchi = new SDUI.Controls.TextBox();
            txtIsyutaru = new SDUI.Controls.TextBox();
            txtLordYarkan = new SDUI.Controls.TextBox();
            txtDemonChaitan = new SDUI.Controls.TextBox();
            btnTigerGirl = new SDUI.Controls.Button();
            btnCerberus = new SDUI.Controls.Button();
            btnIvy = new SDUI.Controls.Button();
            btnUruchi = new SDUI.Controls.Button();
            btnIsyutaru = new SDUI.Controls.Button();
            btnLordYarkan = new SDUI.Controls.Button();
            btnDemonChaitan = new SDUI.Controls.Button();
            lblPlayerMustBeLoggedIn = new SDUI.Controls.Label();
            gbxUnique = new SDUI.Controls.GroupBox();
            panel1.SuspendLayout();
            gbxUnique.SuspendLayout();
            SuspendLayout();
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
            label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(0, 20);
            label1.TabIndex = 1;
            // 
            // btnOK
            // 
            btnOK.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            btnOK.Color = System.Drawing.Color.Transparent;
            btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            btnOK.Enabled = false;
            btnOK.Location = new System.Drawing.Point(15, 15);
            btnOK.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            btnOK.Name = "btnOK";
            btnOK.Radius = 6;
            btnOK.ShadowDepth = 4F;
            btnOK.Size = new System.Drawing.Size(90, 26);
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
            btnCancel.Location = new System.Drawing.Point(459, 15);
            btnCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            btnCancel.Name = "btnCancel";
            btnCancel.Radius = 6;
            btnCancel.ShadowDepth = 4F;
            btnCancel.Size = new System.Drawing.Size(90, 26);
            btnCancel.TabIndex = 7;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
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
            panel1.Location = new System.Drawing.Point(0, 492);
            panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            panel1.Name = "panel1";
            panel1.Radius = 0;
            panel1.ShadowDepth = 4F;
            panel1.Size = new System.Drawing.Size(559, 56);
            panel1.TabIndex = 7;
            // 
            // chkUniqueInRange
            // 
            chkUniqueInRange.AutoSize = true;
            chkUniqueInRange.Depth = 0;
            chkUniqueInRange.Enabled = false;
            chkUniqueInRange.Location = new System.Drawing.Point(12, 390);
            chkUniqueInRange.Margin = new System.Windows.Forms.Padding(0);
            chkUniqueInRange.MouseLocation = new System.Drawing.Point(-1, -1);
            chkUniqueInRange.Name = "chkUniqueInRange";
            chkUniqueInRange.Ripple = true;
            chkUniqueInRange.Size = new System.Drawing.Size(143, 30);
            chkUniqueInRange.TabIndex = 8;
            chkUniqueInRange.Text = "Unique in range:";
            chkUniqueInRange.UseVisualStyleBackColor = true;
            chkUniqueInRange.CheckedChanged += Checkbox_CheckedChanged;
            // 
            // btnUniqueInRange
            // 
            btnUniqueInRange.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnUniqueInRange.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            btnUniqueInRange.BackColor = System.Drawing.Color.Transparent;
            btnUniqueInRange.Color = System.Drawing.Color.Transparent;
            btnUniqueInRange.Enabled = false;
            btnUniqueInRange.Location = new System.Drawing.Point(465, 395);
            btnUniqueInRange.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            btnUniqueInRange.Name = "btnUniqueInRange";
            btnUniqueInRange.Radius = 6;
            btnUniqueInRange.ShadowDepth = 4F;
            btnUniqueInRange.Size = new System.Drawing.Size(52, 29);
            btnUniqueInRange.TabIndex = 9;
            btnUniqueInRange.Text = "...";
            btnUniqueInRange.UseVisualStyleBackColor = true;
            btnUniqueInRange.Click += btnUniqueInRange_Click;
            // 
            // chkUniqueAppearedGeneral
            // 
            chkUniqueAppearedGeneral.AutoSize = true;
            chkUniqueAppearedGeneral.Depth = 0;
            chkUniqueAppearedGeneral.Enabled = false;
            chkUniqueAppearedGeneral.Location = new System.Drawing.Point(16, 40);
            chkUniqueAppearedGeneral.Margin = new System.Windows.Forms.Padding(0);
            chkUniqueAppearedGeneral.MouseLocation = new System.Drawing.Point(-1, -1);
            chkUniqueAppearedGeneral.Name = "chkUniqueAppearedGeneral";
            chkUniqueAppearedGeneral.Ripple = true;
            chkUniqueAppearedGeneral.Size = new System.Drawing.Size(153, 30);
            chkUniqueAppearedGeneral.TabIndex = 10;
            chkUniqueAppearedGeneral.Text = "Unique appeared:";
            chkUniqueAppearedGeneral.UseVisualStyleBackColor = true;
            chkUniqueAppearedGeneral.CheckedChanged += Checkbox_CheckedChanged;
            // 
            // btnUniqueAppearedGeneral
            // 
            btnUniqueAppearedGeneral.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnUniqueAppearedGeneral.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            btnUniqueAppearedGeneral.BackColor = System.Drawing.Color.Transparent;
            btnUniqueAppearedGeneral.Color = System.Drawing.Color.Transparent;
            btnUniqueAppearedGeneral.Enabled = false;
            btnUniqueAppearedGeneral.Location = new System.Drawing.Point(465, 45);
            btnUniqueAppearedGeneral.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            btnUniqueAppearedGeneral.Name = "btnUniqueAppearedGeneral";
            btnUniqueAppearedGeneral.Radius = 6;
            btnUniqueAppearedGeneral.ShadowDepth = 4F;
            btnUniqueAppearedGeneral.Size = new System.Drawing.Size(52, 29);
            btnUniqueAppearedGeneral.TabIndex = 12;
            btnUniqueAppearedGeneral.Text = "...";
            btnUniqueAppearedGeneral.UseVisualStyleBackColor = true;
            btnUniqueAppearedGeneral.Click += btnUniqueAppearedGeneral_Click;
            // 
            // txtRegex
            // 
            txtRegex.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtRegex.Enabled = false;
            txtRegex.Location = new System.Drawing.Point(182, 81);
            txtRegex.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            txtRegex.MaxLength = 32767;
            txtRegex.MultiLine = false;
            txtRegex.Name = "txtRegex";
            txtRegex.PassFocusShow = false;
            txtRegex.Radius = 2;
            txtRegex.Size = new System.Drawing.Size(275, 25);
            txtRegex.TabIndex = 13;
            txtRegex.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            txtRegex.UseSystemPasswordChar = false;
            // 
            // lblRegex
            // 
            lblRegex.ApplyGradient = false;
            lblRegex.AutoSize = true;
            lblRegex.Enabled = false;
            lblRegex.Gradient = new System.Drawing.Color[]
    {
    System.Drawing.Color.Gray,
    System.Drawing.Color.Black
    };
            lblRegex.GradientAnimation = false;
            lblRegex.Location = new System.Drawing.Point(66, 85);
            lblRegex.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblRegex.Name = "lblRegex";
            lblRegex.Size = new System.Drawing.Size(108, 20);
            lblRegex.TabIndex = 14;
            lblRegex.Text = "Match (Regex):";
            // 
            // txtUniqueAppearedGeneral
            // 
            txtUniqueAppearedGeneral.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtUniqueAppearedGeneral.Enabled = false;
            txtUniqueAppearedGeneral.Location = new System.Drawing.Point(182, 45);
            txtUniqueAppearedGeneral.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            txtUniqueAppearedGeneral.MaxLength = 32767;
            txtUniqueAppearedGeneral.MultiLine = false;
            txtUniqueAppearedGeneral.Name = "txtUniqueAppearedGeneral";
            txtUniqueAppearedGeneral.PassFocusShow = false;
            txtUniqueAppearedGeneral.Radius = 2;
            txtUniqueAppearedGeneral.Size = new System.Drawing.Size(275, 25);
            txtUniqueAppearedGeneral.TabIndex = 15;
            txtUniqueAppearedGeneral.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            txtUniqueAppearedGeneral.UseSystemPasswordChar = false;
            // 
            // txtUniqueInRange
            // 
            txtUniqueInRange.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtUniqueInRange.Enabled = false;
            txtUniqueInRange.Location = new System.Drawing.Point(182, 395);
            txtUniqueInRange.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            txtUniqueInRange.MaxLength = 32767;
            txtUniqueInRange.MultiLine = false;
            txtUniqueInRange.Name = "txtUniqueInRange";
            txtUniqueInRange.PassFocusShow = false;
            txtUniqueInRange.Radius = 2;
            txtUniqueInRange.Size = new System.Drawing.Size(275, 25);
            txtUniqueInRange.TabIndex = 16;
            txtUniqueInRange.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            txtUniqueInRange.UseSystemPasswordChar = false;
            // 
            // chkTigerGirl
            // 
            chkTigerGirl.AutoSize = true;
            chkTigerGirl.Depth = 0;
            chkTigerGirl.Enabled = false;
            chkTigerGirl.Location = new System.Drawing.Point(12, 121);
            chkTigerGirl.Margin = new System.Windows.Forms.Padding(0);
            chkTigerGirl.MouseLocation = new System.Drawing.Point(-1, -1);
            chkTigerGirl.Name = "chkTigerGirl";
            chkTigerGirl.Ripple = true;
            chkTigerGirl.Size = new System.Drawing.Size(102, 30);
            chkTigerGirl.TabIndex = 17;
            chkTigerGirl.Text = "Tiger Girl::";
            chkTigerGirl.UseVisualStyleBackColor = true;
            chkTigerGirl.CheckedChanged += Checkbox_CheckedChanged;
            // 
            // chkIvy
            // 
            chkIvy.AutoSize = true;
            chkIvy.Depth = 0;
            chkIvy.Enabled = false;
            chkIvy.Location = new System.Drawing.Point(12, 194);
            chkIvy.Margin = new System.Windows.Forms.Padding(0);
            chkIvy.MouseLocation = new System.Drawing.Point(-1, -1);
            chkIvy.Name = "chkIvy";
            chkIvy.Ripple = true;
            chkIvy.Size = new System.Drawing.Size(111, 30);
            chkIvy.TabIndex = 18;
            chkIvy.Text = "Captain Ivy:";
            chkIvy.UseVisualStyleBackColor = true;
            chkIvy.CheckedChanged += Checkbox_CheckedChanged;
            // 
            // chkUruchi
            // 
            chkUruchi.AutoSize = true;
            chkUruchi.Depth = 0;
            chkUruchi.Enabled = false;
            chkUruchi.Location = new System.Drawing.Point(12, 229);
            chkUruchi.Margin = new System.Windows.Forms.Padding(0);
            chkUruchi.MouseLocation = new System.Drawing.Point(-1, -1);
            chkUruchi.Name = "chkUruchi";
            chkUruchi.Ripple = true;
            chkUruchi.Size = new System.Drawing.Size(80, 30);
            chkUruchi.TabIndex = 19;
            chkUruchi.Text = "Uruchi:";
            chkUruchi.UseVisualStyleBackColor = true;
            chkUruchi.CheckedChanged += Checkbox_CheckedChanged;
            // 
            // chkCerberus
            // 
            chkCerberus.AutoSize = true;
            chkCerberus.Depth = 0;
            chkCerberus.Enabled = false;
            chkCerberus.Location = new System.Drawing.Point(12, 158);
            chkCerberus.Margin = new System.Windows.Forms.Padding(0);
            chkCerberus.MouseLocation = new System.Drawing.Point(-1, -1);
            chkCerberus.Name = "chkCerberus";
            chkCerberus.Ripple = true;
            chkCerberus.Size = new System.Drawing.Size(96, 30);
            chkCerberus.TabIndex = 20;
            chkCerberus.Text = "Cerberus:";
            chkCerberus.UseVisualStyleBackColor = true;
            chkCerberus.CheckedChanged += Checkbox_CheckedChanged;
            // 
            // chkIsyutaru
            // 
            chkIsyutaru.AutoSize = true;
            chkIsyutaru.Depth = 0;
            chkIsyutaru.Enabled = false;
            chkIsyutaru.Location = new System.Drawing.Point(12, 266);
            chkIsyutaru.Margin = new System.Windows.Forms.Padding(0);
            chkIsyutaru.MouseLocation = new System.Drawing.Point(-1, -1);
            chkIsyutaru.Name = "chkIsyutaru";
            chkIsyutaru.Ripple = true;
            chkIsyutaru.Size = new System.Drawing.Size(89, 30);
            chkIsyutaru.TabIndex = 21;
            chkIsyutaru.Text = "Isyutaru:";
            chkIsyutaru.UseVisualStyleBackColor = true;
            chkIsyutaru.CheckedChanged += Checkbox_CheckedChanged;
            // 
            // chkLordYarkan
            // 
            chkLordYarkan.AutoSize = true;
            chkLordYarkan.Depth = 0;
            chkLordYarkan.Enabled = false;
            chkLordYarkan.Location = new System.Drawing.Point(12, 302);
            chkLordYarkan.Margin = new System.Windows.Forms.Padding(0);
            chkLordYarkan.MouseLocation = new System.Drawing.Point(-1, -1);
            chkLordYarkan.Name = "chkLordYarkan";
            chkLordYarkan.Ripple = true;
            chkLordYarkan.Size = new System.Drawing.Size(115, 30);
            chkLordYarkan.TabIndex = 22;
            chkLordYarkan.Text = "Lord Yarkan:";
            chkLordYarkan.UseVisualStyleBackColor = true;
            chkLordYarkan.CheckedChanged += Checkbox_CheckedChanged;
            // 
            // chkDemonChaitan
            // 
            chkDemonChaitan.AutoSize = true;
            chkDemonChaitan.Depth = 0;
            chkDemonChaitan.Enabled = false;
            chkDemonChaitan.Location = new System.Drawing.Point(12, 339);
            chkDemonChaitan.Margin = new System.Windows.Forms.Padding(0);
            chkDemonChaitan.MouseLocation = new System.Drawing.Point(-1, -1);
            chkDemonChaitan.Name = "chkDemonChaitan";
            chkDemonChaitan.Ripple = true;
            chkDemonChaitan.Size = new System.Drawing.Size(140, 30);
            chkDemonChaitan.TabIndex = 23;
            chkDemonChaitan.Text = "Demon Shaitan:";
            chkDemonChaitan.UseVisualStyleBackColor = true;
            chkDemonChaitan.CheckedChanged += Checkbox_CheckedChanged;
            // 
            // txtTigerGirl
            // 
            txtTigerGirl.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtTigerGirl.Enabled = false;
            txtTigerGirl.Location = new System.Drawing.Point(182, 126);
            txtTigerGirl.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            txtTigerGirl.MaxLength = 32767;
            txtTigerGirl.MultiLine = false;
            txtTigerGirl.Name = "txtTigerGirl";
            txtTigerGirl.PassFocusShow = false;
            txtTigerGirl.Radius = 2;
            txtTigerGirl.Size = new System.Drawing.Size(275, 25);
            txtTigerGirl.TabIndex = 24;
            txtTigerGirl.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            txtTigerGirl.UseSystemPasswordChar = false;
            // 
            // txtCerberus
            // 
            txtCerberus.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtCerberus.Enabled = false;
            txtCerberus.Location = new System.Drawing.Point(182, 162);
            txtCerberus.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            txtCerberus.MaxLength = 32767;
            txtCerberus.MultiLine = false;
            txtCerberus.Name = "txtCerberus";
            txtCerberus.PassFocusShow = false;
            txtCerberus.Radius = 2;
            txtCerberus.Size = new System.Drawing.Size(275, 25);
            txtCerberus.TabIndex = 25;
            txtCerberus.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            txtCerberus.UseSystemPasswordChar = false;
            // 
            // txtIvy
            // 
            txtIvy.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtIvy.Enabled = false;
            txtIvy.Location = new System.Drawing.Point(182, 199);
            txtIvy.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            txtIvy.MaxLength = 32767;
            txtIvy.MultiLine = false;
            txtIvy.Name = "txtIvy";
            txtIvy.PassFocusShow = false;
            txtIvy.Radius = 2;
            txtIvy.Size = new System.Drawing.Size(275, 25);
            txtIvy.TabIndex = 26;
            txtIvy.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            txtIvy.UseSystemPasswordChar = false;
            // 
            // txtUruchi
            // 
            txtUruchi.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtUruchi.Enabled = false;
            txtUruchi.Location = new System.Drawing.Point(182, 235);
            txtUruchi.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            txtUruchi.MaxLength = 32767;
            txtUruchi.MultiLine = false;
            txtUruchi.Name = "txtUruchi";
            txtUruchi.PassFocusShow = false;
            txtUruchi.Radius = 2;
            txtUruchi.Size = new System.Drawing.Size(275, 25);
            txtUruchi.TabIndex = 27;
            txtUruchi.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            txtUruchi.UseSystemPasswordChar = false;
            // 
            // txtIsyutaru
            // 
            txtIsyutaru.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtIsyutaru.Enabled = false;
            txtIsyutaru.Location = new System.Drawing.Point(182, 271);
            txtIsyutaru.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            txtIsyutaru.MaxLength = 32767;
            txtIsyutaru.MultiLine = false;
            txtIsyutaru.Name = "txtIsyutaru";
            txtIsyutaru.PassFocusShow = false;
            txtIsyutaru.Radius = 2;
            txtIsyutaru.Size = new System.Drawing.Size(275, 25);
            txtIsyutaru.TabIndex = 28;
            txtIsyutaru.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            txtIsyutaru.UseSystemPasswordChar = false;
            // 
            // txtLordYarkan
            // 
            txtLordYarkan.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtLordYarkan.Enabled = false;
            txtLordYarkan.Location = new System.Drawing.Point(182, 308);
            txtLordYarkan.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            txtLordYarkan.MaxLength = 32767;
            txtLordYarkan.MultiLine = false;
            txtLordYarkan.Name = "txtLordYarkan";
            txtLordYarkan.PassFocusShow = false;
            txtLordYarkan.Radius = 2;
            txtLordYarkan.Size = new System.Drawing.Size(275, 25);
            txtLordYarkan.TabIndex = 29;
            txtLordYarkan.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            txtLordYarkan.UseSystemPasswordChar = false;
            // 
            // txtDemonChaitan
            // 
            txtDemonChaitan.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtDemonChaitan.Enabled = false;
            txtDemonChaitan.Location = new System.Drawing.Point(182, 344);
            txtDemonChaitan.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            txtDemonChaitan.MaxLength = 32767;
            txtDemonChaitan.MultiLine = false;
            txtDemonChaitan.Name = "txtDemonChaitan";
            txtDemonChaitan.PassFocusShow = false;
            txtDemonChaitan.Radius = 2;
            txtDemonChaitan.Size = new System.Drawing.Size(275, 25);
            txtDemonChaitan.TabIndex = 30;
            txtDemonChaitan.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            txtDemonChaitan.UseSystemPasswordChar = false;
            // 
            // btnTigerGirl
            // 
            btnTigerGirl.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnTigerGirl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            btnTigerGirl.BackColor = System.Drawing.Color.Transparent;
            btnTigerGirl.Color = System.Drawing.Color.Transparent;
            btnTigerGirl.Enabled = false;
            btnTigerGirl.Location = new System.Drawing.Point(465, 126);
            btnTigerGirl.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            btnTigerGirl.Name = "btnTigerGirl";
            btnTigerGirl.Radius = 6;
            btnTigerGirl.ShadowDepth = 4F;
            btnTigerGirl.Size = new System.Drawing.Size(52, 29);
            btnTigerGirl.TabIndex = 31;
            btnTigerGirl.Text = "...";
            btnTigerGirl.UseVisualStyleBackColor = true;
            btnTigerGirl.Click += btnTigerGirl_Click;
            // 
            // btnCerberus
            // 
            btnCerberus.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnCerberus.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            btnCerberus.BackColor = System.Drawing.Color.Transparent;
            btnCerberus.Color = System.Drawing.Color.Transparent;
            btnCerberus.Enabled = false;
            btnCerberus.Location = new System.Drawing.Point(465, 162);
            btnCerberus.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            btnCerberus.Name = "btnCerberus";
            btnCerberus.Radius = 6;
            btnCerberus.ShadowDepth = 4F;
            btnCerberus.Size = new System.Drawing.Size(52, 29);
            btnCerberus.TabIndex = 32;
            btnCerberus.Text = "...";
            btnCerberus.UseVisualStyleBackColor = true;
            btnCerberus.Click += btnCerberus_Click;
            // 
            // btnIvy
            // 
            btnIvy.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnIvy.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            btnIvy.BackColor = System.Drawing.Color.Transparent;
            btnIvy.Color = System.Drawing.Color.Transparent;
            btnIvy.Enabled = false;
            btnIvy.Location = new System.Drawing.Point(465, 199);
            btnIvy.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            btnIvy.Name = "btnIvy";
            btnIvy.Radius = 6;
            btnIvy.ShadowDepth = 4F;
            btnIvy.Size = new System.Drawing.Size(52, 29);
            btnIvy.TabIndex = 33;
            btnIvy.Text = "...";
            btnIvy.UseVisualStyleBackColor = true;
            btnIvy.Click += btnIvy_Click;
            // 
            // btnUruchi
            // 
            btnUruchi.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnUruchi.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            btnUruchi.BackColor = System.Drawing.Color.Transparent;
            btnUruchi.Color = System.Drawing.Color.Transparent;
            btnUruchi.Enabled = false;
            btnUruchi.Location = new System.Drawing.Point(465, 235);
            btnUruchi.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            btnUruchi.Name = "btnUruchi";
            btnUruchi.Radius = 6;
            btnUruchi.ShadowDepth = 4F;
            btnUruchi.Size = new System.Drawing.Size(52, 29);
            btnUruchi.TabIndex = 34;
            btnUruchi.Text = "...";
            btnUruchi.UseVisualStyleBackColor = true;
            btnUruchi.Click += btnUruchi_Click;
            // 
            // btnIsyutaru
            // 
            btnIsyutaru.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnIsyutaru.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            btnIsyutaru.BackColor = System.Drawing.Color.Transparent;
            btnIsyutaru.Color = System.Drawing.Color.Transparent;
            btnIsyutaru.Enabled = false;
            btnIsyutaru.Location = new System.Drawing.Point(465, 271);
            btnIsyutaru.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            btnIsyutaru.Name = "btnIsyutaru";
            btnIsyutaru.Radius = 6;
            btnIsyutaru.ShadowDepth = 4F;
            btnIsyutaru.Size = new System.Drawing.Size(52, 29);
            btnIsyutaru.TabIndex = 35;
            btnIsyutaru.Text = "...";
            btnIsyutaru.UseVisualStyleBackColor = true;
            btnIsyutaru.Click += btnIsyutaru_Click;
            // 
            // btnLordYarkan
            // 
            btnLordYarkan.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnLordYarkan.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            btnLordYarkan.BackColor = System.Drawing.Color.Transparent;
            btnLordYarkan.Color = System.Drawing.Color.Transparent;
            btnLordYarkan.Enabled = false;
            btnLordYarkan.Location = new System.Drawing.Point(465, 308);
            btnLordYarkan.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            btnLordYarkan.Name = "btnLordYarkan";
            btnLordYarkan.Radius = 6;
            btnLordYarkan.ShadowDepth = 4F;
            btnLordYarkan.Size = new System.Drawing.Size(52, 29);
            btnLordYarkan.TabIndex = 36;
            btnLordYarkan.Text = "...";
            btnLordYarkan.UseVisualStyleBackColor = true;
            btnLordYarkan.Click += btnLordYarkan_Click;
            // 
            // btnDemonChaitan
            // 
            btnDemonChaitan.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnDemonChaitan.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            btnDemonChaitan.BackColor = System.Drawing.Color.Transparent;
            btnDemonChaitan.Color = System.Drawing.Color.Transparent;
            btnDemonChaitan.Enabled = false;
            btnDemonChaitan.Location = new System.Drawing.Point(465, 344);
            btnDemonChaitan.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            btnDemonChaitan.Name = "btnDemonChaitan";
            btnDemonChaitan.Radius = 6;
            btnDemonChaitan.ShadowDepth = 4F;
            btnDemonChaitan.Size = new System.Drawing.Size(52, 29);
            btnDemonChaitan.TabIndex = 37;
            btnDemonChaitan.Text = "...";
            btnDemonChaitan.UseVisualStyleBackColor = true;
            btnDemonChaitan.Click += btnDemonChaitan_Click;
            // 
            // lblPlayerMustBeLoggedIn
            // 
            lblPlayerMustBeLoggedIn.ApplyGradient = false;
            lblPlayerMustBeLoggedIn.AutoSize = true;
            lblPlayerMustBeLoggedIn.ForeColor = System.Drawing.Color.Red;
            lblPlayerMustBeLoggedIn.Gradient = new System.Drawing.Color[]
    {
    System.Drawing.Color.Gray,
    System.Drawing.Color.Black
    };
            lblPlayerMustBeLoggedIn.GradientAnimation = false;
            lblPlayerMustBeLoggedIn.Location = new System.Drawing.Point(16, 440);
            lblPlayerMustBeLoggedIn.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblPlayerMustBeLoggedIn.Name = "lblPlayerMustBeLoggedIn";
            lblPlayerMustBeLoggedIn.Size = new System.Drawing.Size(177, 20);
            lblPlayerMustBeLoggedIn.TabIndex = 38;
            lblPlayerMustBeLoggedIn.Text = "Player must be logged in.";
            // 
            // gbxUnique
            // 
            gbxUnique.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            gbxUnique.BackColor = System.Drawing.Color.Transparent;
            gbxUnique.Controls.Add(txtCerberus);
            gbxUnique.Controls.Add(lblPlayerMustBeLoggedIn);
            gbxUnique.Controls.Add(chkUniqueInRange);
            gbxUnique.Controls.Add(btnDemonChaitan);
            gbxUnique.Controls.Add(btnUniqueInRange);
            gbxUnique.Controls.Add(btnLordYarkan);
            gbxUnique.Controls.Add(chkUniqueAppearedGeneral);
            gbxUnique.Controls.Add(btnIsyutaru);
            gbxUnique.Controls.Add(btnUniqueAppearedGeneral);
            gbxUnique.Controls.Add(btnUruchi);
            gbxUnique.Controls.Add(txtRegex);
            gbxUnique.Controls.Add(btnIvy);
            gbxUnique.Controls.Add(lblRegex);
            gbxUnique.Controls.Add(btnCerberus);
            gbxUnique.Controls.Add(txtUniqueAppearedGeneral);
            gbxUnique.Controls.Add(btnTigerGirl);
            gbxUnique.Controls.Add(txtUniqueInRange);
            gbxUnique.Controls.Add(txtDemonChaitan);
            gbxUnique.Controls.Add(chkTigerGirl);
            gbxUnique.Controls.Add(txtLordYarkan);
            gbxUnique.Controls.Add(chkIvy);
            gbxUnique.Controls.Add(txtIsyutaru);
            gbxUnique.Controls.Add(chkUruchi);
            gbxUnique.Controls.Add(txtUruchi);
            gbxUnique.Controls.Add(chkCerberus);
            gbxUnique.Controls.Add(txtIvy);
            gbxUnique.Controls.Add(chkIsyutaru);
            gbxUnique.Controls.Add(chkLordYarkan);
            gbxUnique.Controls.Add(txtTigerGirl);
            gbxUnique.Controls.Add(chkDemonChaitan);
            gbxUnique.Location = new System.Drawing.Point(8, 8);
            gbxUnique.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            gbxUnique.Name = "gbxUnique";
            gbxUnique.Padding = new System.Windows.Forms.Padding(4, 10, 4, 4);
            gbxUnique.Radius = 10;
            gbxUnique.ShadowDepth = 4;
            gbxUnique.Size = new System.Drawing.Size(542, 479);
            gbxUnique.TabIndex = 39;
            gbxUnique.TabStop = false;
            gbxUnique.Text = "Unique";
            // 
            // SoundNotificationWindow
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            BackColor = System.Drawing.Color.White;
            ClientSize = new System.Drawing.Size(559, 548);
            ControlBox = false;
            Controls.Add(gbxUnique);
            Controls.Add(panel1);
            Font = new System.Drawing.Font("Segoe UI", 9F);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            Location = new System.Drawing.Point(0, 0);
            Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            MaximumSize = new System.Drawing.Size(565, 554);
            MinimumSize = new System.Drawing.Size(565, 554);
            Name = "SoundNotificationWindow";
            ShowIcon = false;
            SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Shown += SoundNotificationWindow_Shown;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            gbxUnique.ResumeLayout(false);
            gbxUnique.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private SDUI.Controls.Label lblPlayerMustBeLoggedIn;
        private SDUI.Controls.Label label1;
        private SDUI.Controls.Button btnOK;
        private SDUI.Controls.Button btnCancel;
        private SDUI.Controls.Panel panel1;
        private SDUI.Controls.CheckBox chkUniqueInRange;
        private SDUI.Controls.Button btnUniqueInRange;
        private SDUI.Controls.CheckBox chkUniqueAppearedGeneral;
        private SDUI.Controls.Button btnUniqueAppearedGeneral;
        private SDUI.Controls.TextBox txtRegex;
        private SDUI.Controls.Label lblRegex;
        private SDUI.Controls.TextBox txtUniqueAppearedGeneral;
        private SDUI.Controls.TextBox txtUniqueInRange;
        private SDUI.Controls.CheckBox chkTigerGirl;
        private SDUI.Controls.CheckBox chkIvy;
        private SDUI.Controls.CheckBox chkUruchi;
        private SDUI.Controls.CheckBox chkCerberus;
        private SDUI.Controls.CheckBox chkIsyutaru;
        private SDUI.Controls.CheckBox chkLordYarkan;
        private SDUI.Controls.CheckBox chkDemonChaitan;
        private SDUI.Controls.TextBox txtTigerGirl;
        private SDUI.Controls.TextBox txtCerberus;
        private SDUI.Controls.TextBox txtIvy;
        private SDUI.Controls.TextBox txtUruchi;
        private SDUI.Controls.TextBox txtIsyutaru;
        private SDUI.Controls.TextBox txtLordYarkan;
        private SDUI.Controls.TextBox txtDemonChaitan;
        private SDUI.Controls.Button btnTigerGirl;
        private SDUI.Controls.Button btnCerberus;
        private SDUI.Controls.Button btnIvy;
        private SDUI.Controls.Button btnUruchi;
        private SDUI.Controls.Button btnIsyutaru;
        private SDUI.Controls.Button btnLordYarkan;
        private SDUI.Controls.Button btnDemonChaitan;
        private SDUI.Controls.GroupBox gbxUnique;
    }
}
