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
            btnUniqueInRange = new System.Windows.Forms.Button();
            chkUniqueAppearedGeneral = new SDUI.Controls.CheckBox();
            btnUniqueAppearedGeneral = new System.Windows.Forms.Button();
            txtRegex = new System.Windows.Forms.TextBox();
            lblRegex = new SDUI.Controls.Label();
            txtUniqueAppearedGeneral = new System.Windows.Forms.TextBox();
            txtUniqueInRange = new System.Windows.Forms.TextBox();
            chkTigerGirl = new SDUI.Controls.CheckBox();
            chkIvy = new SDUI.Controls.CheckBox();
            chkUruchi = new SDUI.Controls.CheckBox();
            chkCerberus = new SDUI.Controls.CheckBox();
            chkIsyutaru = new SDUI.Controls.CheckBox();
            chkLordYarkan = new SDUI.Controls.CheckBox();
            chkDemonChaitan = new SDUI.Controls.CheckBox();
            txtTigerGirl = new System.Windows.Forms.TextBox();
            txtCerberus = new System.Windows.Forms.TextBox();
            txtIvy = new System.Windows.Forms.TextBox();
            txtUruchi = new System.Windows.Forms.TextBox();
            txtIsyutaru = new System.Windows.Forms.TextBox();
            txtLordYarkan = new System.Windows.Forms.TextBox();
            txtDemonChaitan = new System.Windows.Forms.TextBox();
            btnTigerGirl = new System.Windows.Forms.Button();
            btnCerberus = new System.Windows.Forms.Button();
            btnIvy = new System.Windows.Forms.Button();
            btnUruchi = new System.Windows.Forms.Button();
            btnIsyutaru = new System.Windows.Forms.Button();
            btnLordYarkan = new System.Windows.Forms.Button();
            btnDemonChaitan = new System.Windows.Forms.Button();
            lblPlayerMustBeLoggedIn = new System.Windows.Forms.Label();
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
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(0, 15);
            label1.TabIndex = 1;
            // 
            // btnOK
            // 
            btnOK.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            btnOK.Color = System.Drawing.Color.Transparent;
            btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            btnOK.Enabled = false;
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
            btnCancel.Location = new System.Drawing.Point(367, 12);
            btnCancel.Name = "btnCancel";
            btnCancel.Radius = 6;
            btnCancel.ShadowDepth = 4F;
            btnCancel.Size = new System.Drawing.Size(72, 21);
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
            panel1.Location = new System.Drawing.Point(0, 393);
            panel1.Name = "panel1";
            panel1.Radius = 0;
            panel1.ShadowDepth = 4F;
            panel1.Size = new System.Drawing.Size(447, 45);
            panel1.TabIndex = 7;
            // 
            // chkUniqueInRange
            // 
            chkUniqueInRange.AutoSize = true;
            chkUniqueInRange.Depth = 0;
            chkUniqueInRange.Enabled = false;
            chkUniqueInRange.Location = new System.Drawing.Point(10, 312);
            chkUniqueInRange.Margin = new System.Windows.Forms.Padding(0);
            chkUniqueInRange.MouseLocation = new System.Drawing.Point(-1, -1);
            chkUniqueInRange.Name = "chkUniqueInRange";
            chkUniqueInRange.Ripple = true;
            chkUniqueInRange.Size = new System.Drawing.Size(120, 30);
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
            btnUniqueInRange.Enabled = false;
            btnUniqueInRange.Location = new System.Drawing.Point(372, 316);
            btnUniqueInRange.Name = "btnUniqueInRange";
            btnUniqueInRange.Size = new System.Drawing.Size(42, 23);
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
            chkUniqueAppearedGeneral.Location = new System.Drawing.Point(13, 32);
            chkUniqueAppearedGeneral.Margin = new System.Windows.Forms.Padding(0);
            chkUniqueAppearedGeneral.MouseLocation = new System.Drawing.Point(-1, -1);
            chkUniqueAppearedGeneral.Name = "chkUniqueAppearedGeneral";
            chkUniqueAppearedGeneral.Ripple = true;
            chkUniqueAppearedGeneral.Size = new System.Drawing.Size(126, 30);
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
            btnUniqueAppearedGeneral.DialogResult = System.Windows.Forms.DialogResult.None;
            btnUniqueAppearedGeneral.Enabled = false;
            btnUniqueAppearedGeneral.Image = null;
            btnUniqueAppearedGeneral.Location = new System.Drawing.Point(372, 36);
            btnUniqueAppearedGeneral.Name = "btnUniqueAppearedGeneral";
            btnUniqueAppearedGeneral.Size = new System.Drawing.Size(42, 23);
            btnUniqueAppearedGeneral.TabIndex = 12;
            btnUniqueAppearedGeneral.Text = "...";
            btnUniqueAppearedGeneral.UseVisualStyleBackColor = true;
            btnUniqueAppearedGeneral.Click += btnUniqueAppearedGeneral_Click;
            // 
            // txtRegex
            // 
            txtRegex.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtRegex.Enabled = false;
            txtRegex.Location = new System.Drawing.Point(146, 65);
            txtRegex.Name = "txtRegex";
            txtRegex.Size = new System.Drawing.Size(220, 23);
            txtRegex.TabIndex = 13;
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
            lblRegex.Location = new System.Drawing.Point(53, 68);
            lblRegex.Name = "lblRegex";
            lblRegex.Size = new System.Drawing.Size(87, 15);
            lblRegex.TabIndex = 14;
            lblRegex.Text = "Match (Regex):";
            // 
            // txtUniqueAppearedGeneral
            // 
            txtUniqueAppearedGeneral.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtUniqueAppearedGeneral.Enabled = false;
            txtUniqueAppearedGeneral.Location = new System.Drawing.Point(146, 36);
            txtUniqueAppearedGeneral.Name = "txtUniqueAppearedGeneral";
            txtUniqueAppearedGeneral.ReadOnly = true;
            txtUniqueAppearedGeneral.Size = new System.Drawing.Size(220, 23);
            txtUniqueAppearedGeneral.TabIndex = 15;
            // 
            // txtUniqueInRange
            // 
            txtUniqueInRange.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtUniqueInRange.Enabled = false;
            txtUniqueInRange.Location = new System.Drawing.Point(146, 316);
            txtUniqueInRange.Name = "txtUniqueInRange";
            txtUniqueInRange.ReadOnly = true;
            txtUniqueInRange.Size = new System.Drawing.Size(220, 23);
            txtUniqueInRange.TabIndex = 16;
            // 
            // chkTigerGirl
            // 
            chkTigerGirl.AutoSize = true;
            chkTigerGirl.Depth = 0;
            chkTigerGirl.Enabled = false;
            chkTigerGirl.Location = new System.Drawing.Point(10, 97);
            chkTigerGirl.Margin = new System.Windows.Forms.Padding(0);
            chkTigerGirl.MouseLocation = new System.Drawing.Point(-1, -1);
            chkTigerGirl.Name = "chkTigerGirl";
            chkTigerGirl.Ripple = true;
            chkTigerGirl.Size = new System.Drawing.Size(86, 30);
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
            chkIvy.Location = new System.Drawing.Point(10, 155);
            chkIvy.Margin = new System.Windows.Forms.Padding(0);
            chkIvy.MouseLocation = new System.Drawing.Point(-1, -1);
            chkIvy.Name = "chkIvy";
            chkIvy.Ripple = true;
            chkIvy.Size = new System.Drawing.Size(95, 30);
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
            chkUruchi.Location = new System.Drawing.Point(10, 183);
            chkUruchi.Margin = new System.Windows.Forms.Padding(0);
            chkUruchi.MouseLocation = new System.Drawing.Point(-1, -1);
            chkUruchi.Name = "chkUruchi";
            chkUruchi.Ripple = true;
            chkUruchi.Size = new System.Drawing.Size(71, 30);
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
            chkCerberus.Location = new System.Drawing.Point(10, 126);
            chkCerberus.Margin = new System.Windows.Forms.Padding(0);
            chkCerberus.MouseLocation = new System.Drawing.Point(-1, -1);
            chkCerberus.Name = "chkCerberus";
            chkCerberus.Ripple = true;
            chkCerberus.Size = new System.Drawing.Size(83, 30);
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
            chkIsyutaru.Location = new System.Drawing.Point(10, 213);
            chkIsyutaru.Margin = new System.Windows.Forms.Padding(0);
            chkIsyutaru.MouseLocation = new System.Drawing.Point(-1, -1);
            chkIsyutaru.Name = "chkIsyutaru";
            chkIsyutaru.Ripple = true;
            chkIsyutaru.Size = new System.Drawing.Size(78, 30);
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
            chkLordYarkan.Location = new System.Drawing.Point(10, 242);
            chkLordYarkan.Margin = new System.Windows.Forms.Padding(0);
            chkLordYarkan.MouseLocation = new System.Drawing.Point(-1, -1);
            chkLordYarkan.Name = "chkLordYarkan";
            chkLordYarkan.Ripple = true;
            chkLordYarkan.Size = new System.Drawing.Size(98, 30);
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
            chkDemonChaitan.Location = new System.Drawing.Point(10, 271);
            chkDemonChaitan.Margin = new System.Windows.Forms.Padding(0);
            chkDemonChaitan.MouseLocation = new System.Drawing.Point(-1, -1);
            chkDemonChaitan.Name = "chkDemonChaitan";
            chkDemonChaitan.Ripple = true;
            chkDemonChaitan.Size = new System.Drawing.Size(117, 30);
            chkDemonChaitan.TabIndex = 23;
            chkDemonChaitan.Text = "Demon Shaitan:";
            chkDemonChaitan.UseVisualStyleBackColor = true;
            chkDemonChaitan.CheckedChanged += Checkbox_CheckedChanged;
            // 
            // txtTigerGirl
            // 
            txtTigerGirl.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtTigerGirl.Enabled = false;
            txtTigerGirl.Location = new System.Drawing.Point(146, 101);
            txtTigerGirl.Name = "txtTigerGirl";
            txtTigerGirl.ReadOnly = true;
            txtTigerGirl.Size = new System.Drawing.Size(220, 23);
            txtTigerGirl.TabIndex = 24;
            // 
            // txtCerberus
            // 
            txtCerberus.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtCerberus.Enabled = false;
            txtCerberus.Location = new System.Drawing.Point(146, 130);
            txtCerberus.Name = "txtCerberus";
            txtCerberus.ReadOnly = true;
            txtCerberus.Size = new System.Drawing.Size(220, 23);
            txtCerberus.TabIndex = 25;
            // 
            // txtIvy
            // 
            txtIvy.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtIvy.Enabled = false;
            txtIvy.Location = new System.Drawing.Point(146, 159);
            txtIvy.Name = "txtIvy";
            txtIvy.ReadOnly = true;
            txtIvy.Size = new System.Drawing.Size(220, 23);
            txtIvy.TabIndex = 26;
            // 
            // txtUruchi
            // 
            txtUruchi.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtUruchi.Enabled = false;
            txtUruchi.Location = new System.Drawing.Point(146, 188);
            txtUruchi.Name = "txtUruchi";
            txtUruchi.ReadOnly = true;
            txtUruchi.Size = new System.Drawing.Size(220, 23);
            txtUruchi.TabIndex = 27;
            // 
            // txtIsyutaru
            // 
            txtIsyutaru.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtIsyutaru.Enabled = false;
            txtIsyutaru.Location = new System.Drawing.Point(146, 217);
            txtIsyutaru.Name = "txtIsyutaru";
            txtIsyutaru.ReadOnly = true;
            txtIsyutaru.Size = new System.Drawing.Size(220, 23);
            txtIsyutaru.TabIndex = 28;
            // 
            // txtLordYarkan
            // 
            txtLordYarkan.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtLordYarkan.Enabled = false;
            txtLordYarkan.Location = new System.Drawing.Point(146, 246);
            txtLordYarkan.Name = "txtLordYarkan";
            txtLordYarkan.ReadOnly = true;
            txtLordYarkan.Size = new System.Drawing.Size(220, 23);
            txtLordYarkan.TabIndex = 29;
            // 
            // txtDemonChaitan
            // 
            txtDemonChaitan.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtDemonChaitan.Enabled = false;
            txtDemonChaitan.Location = new System.Drawing.Point(146, 275);
            txtDemonChaitan.Name = "txtDemonChaitan";
            txtDemonChaitan.ReadOnly = true;
            txtDemonChaitan.Size = new System.Drawing.Size(220, 23);
            txtDemonChaitan.TabIndex = 30;
            // 
            // btnTigerGirl
            // 
            btnTigerGirl.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnTigerGirl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            btnTigerGirl.BackColor = System.Drawing.Color.Transparent;
            btnTigerGirl.Enabled = false;
            btnTigerGirl.Location = new System.Drawing.Point(372, 101);
            btnTigerGirl.Name = "btnTigerGirl";
            btnTigerGirl.Size = new System.Drawing.Size(42, 23);
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
            btnCerberus.Enabled = false;
            btnCerberus.Location = new System.Drawing.Point(372, 130);
            btnCerberus.Name = "btnCerberus";
            btnCerberus.Size = new System.Drawing.Size(42, 23);
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
            btnIvy.Enabled = false;
            btnIvy.Location = new System.Drawing.Point(372, 159);
            btnIvy.Name = "btnIvy";
            btnIvy.Size = new System.Drawing.Size(42, 23);
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
            btnUruchi.Enabled = false;
            btnUruchi.Location = new System.Drawing.Point(372, 188);
            btnUruchi.Name = "btnUruchi";
            btnUruchi.Size = new System.Drawing.Size(42, 23);
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
            btnIsyutaru.Enabled = false;
            btnIsyutaru.Location = new System.Drawing.Point(372, 217);
            btnIsyutaru.Name = "btnIsyutaru";
            btnIsyutaru.Size = new System.Drawing.Size(42, 23);
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
            btnLordYarkan.Enabled = false;
            btnLordYarkan.Location = new System.Drawing.Point(372, 246);
            btnLordYarkan.Name = "btnLordYarkan";
            btnLordYarkan.Size = new System.Drawing.Size(42, 23);
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
            btnDemonChaitan.Enabled = false;
            btnDemonChaitan.Location = new System.Drawing.Point(372, 275);
            btnDemonChaitan.Name = "btnDemonChaitan";
            btnDemonChaitan.Size = new System.Drawing.Size(42, 23);
            btnDemonChaitan.TabIndex = 37;
            btnDemonChaitan.Text = "...";
            btnDemonChaitan.UseVisualStyleBackColor = true;
            btnDemonChaitan.Click += btnDemonChaitan_Click;
            // 
            // lblPlayerMustBeLoggedIn
            // 
            lblPlayerMustBeLoggedIn.AutoSize = true;
            lblPlayerMustBeLoggedIn.ForeColor = System.Drawing.Color.Red;
            lblPlayerMustBeLoggedIn.Location = new System.Drawing.Point(13, 352);
            lblPlayerMustBeLoggedIn.Name = "lblPlayerMustBeLoggedIn";
            lblPlayerMustBeLoggedIn.Size = new System.Drawing.Size(141, 15);
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
            gbxUnique.Location = new System.Drawing.Point(6, 6);
            gbxUnique.Name = "gbxUnique";
            gbxUnique.Padding = new System.Windows.Forms.Padding(3, 8, 3, 3);
            gbxUnique.Radius = 10;
            gbxUnique.ShadowDepth = 4;
            gbxUnique.Size = new System.Drawing.Size(434, 383);
            gbxUnique.TabIndex = 39;
            gbxUnique.TabStop = false;
            gbxUnique.Text = "Unique";
            // 
            // SoundNotificationWindow
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            BackColor = System.Drawing.Color.White;
            ClientSize = new System.Drawing.Size(447, 438);
            ControlBox = false;
            Controls.Add(gbxUnique);
            Controls.Add(panel1);
            Font = new System.Drawing.Font("Segoe UI", 9F);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            Location = new System.Drawing.Point(0, 0);
            MaximumSize = new System.Drawing.Size(453, 444);
            MinimumSize = new System.Drawing.Size(453, 444);
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

        private System.Windows.Forms.Label lblPlayerMustBeLoggedIn;
        private SDUI.Controls.Label label1;
        private SDUI.Controls.Button btnOK;
        private SDUI.Controls.Button btnCancel;
        private SDUI.Controls.Panel panel1;
        private SDUI.Controls.CheckBox chkUniqueInRange;
        private System.Windows.Forms.Button btnUniqueInRange;
        private SDUI.Controls.CheckBox chkUniqueAppearedGeneral;
        private System.Windows.Forms.Button btnUniqueAppearedGeneral;
        private System.Windows.Forms.TextBox txtRegex;
        private SDUI.Controls.Label lblRegex;
        private System.Windows.Forms.TextBox txtUniqueAppearedGeneral;
        private System.Windows.Forms.TextBox txtUniqueInRange;
        private SDUI.Controls.CheckBox chkTigerGirl;
        private SDUI.Controls.CheckBox chkIvy;
        private SDUI.Controls.CheckBox chkUruchi;
        private SDUI.Controls.CheckBox chkCerberus;
        private SDUI.Controls.CheckBox chkIsyutaru;
        private SDUI.Controls.CheckBox chkLordYarkan;
        private SDUI.Controls.CheckBox chkDemonChaitan;
        private System.Windows.Forms.TextBox txtTigerGirl;
        private System.Windows.Forms.TextBox txtCerberus;
        private System.Windows.Forms.TextBox txtIvy;
        private System.Windows.Forms.TextBox txtUruchi;
        private System.Windows.Forms.TextBox txtIsyutaru;
        private System.Windows.Forms.TextBox txtLordYarkan;
        private System.Windows.Forms.TextBox txtDemonChaitan;
        private System.Windows.Forms.Button btnTigerGirl;
        private System.Windows.Forms.Button btnCerberus;
        private System.Windows.Forms.Button btnIvy;
        private System.Windows.Forms.Button btnUruchi;
        private System.Windows.Forms.Button btnIsyutaru;
        private System.Windows.Forms.Button btnLordYarkan;
        private System.Windows.Forms.Button btnDemonChaitan;
        private SDUI.Controls.GroupBox gbxUnique;
    }
}