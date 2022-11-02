﻿namespace RSBot.General.Views
{
    partial class Main
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
            this.label1 = new SDUI.Controls.Label();
            this.lblVersion = new SDUI.Controls.Label();
            this.comboBoxClientType = new SDUI.Controls.ComboBox();
            this.groupBox4 = new SDUI.Controls.GroupBox();
            this.label8 = new SDUI.Controls.Label();
            this.checkBoxBotTrayMinimized = new SDUI.Controls.CheckBox();
            this.groupBox3 = new SDUI.Controls.GroupBox();
            this.label2 = new SDUI.Controls.Label();
            this.checkStayConnected = new SDUI.Controls.CheckBox();
            this.groupBox2 = new SDUI.Controls.GroupBox();
            this.btnClientHideShow = new SDUI.Controls.Button();
            this.btnStartClient = new SDUI.Controls.Button();
            this.btnStartClientless = new SDUI.Controls.Button();
            this.btnGoClientless = new SDUI.Controls.Button();
            this.groupBox1 = new SDUI.Controls.GroupBox();
            this.separator1 = new SDUI.Controls.Separator();
            this.panel3 = new System.Windows.Forms.Panel();
            this.radioAutoSelectHigher = new SDUI.Controls.Radio();
            this.radioAutoSelectFirst = new SDUI.Controls.Radio();
            this.checkCharAutoSelect = new SDUI.Controls.CheckBox();
            this.checkHideClient = new SDUI.Controls.CheckBox();
            this.lblLoginDelaySeconds = new SDUI.Controls.Label();
            this.numLoginDelay = new SDUI.Controls.NumUpDown();
            this.checkEnableLoginDelay = new SDUI.Controls.CheckBox();
            this.checkStartBot = new SDUI.Controls.CheckBox();
            this.checkUseReturnScroll = new SDUI.Controls.CheckBox();
            this.captchaPanel = new System.Windows.Forms.Panel();
            this.separator2 = new SDUI.Controls.Separator();
            this.label6 = new SDUI.Controls.Label();
            this.label5 = new SDUI.Controls.Label();
            this.txtStaticCaptcha = new SDUI.Controls.TextBox();
            this.checkEnableStaticCaptcha = new SDUI.Controls.CheckBox();
            this.autoLoginTopPanel = new System.Windows.Forms.Panel();
            this.comboAccounts = new SDUI.Controls.ComboBox();
            this.label7 = new SDUI.Controls.Label();
            this.label4 = new SDUI.Controls.Label();
            this.checkEnableAutoLogin = new SDUI.Controls.CheckBox();
            this.comboCharacter = new SDUI.Controls.ComboBox();
            this.btnAutoLoginSettings = new SDUI.Controls.Button();
            this.btnBrowseSilkroadPath = new SDUI.Controls.Button();
            this.txtSilkroadPath = new SDUI.Controls.TextBox();
            this.groupBox5 = new SDUI.Controls.GroupBox();
            this.checkEnableQueueLogs = new SDUI.Controls.CheckBox();
            this.label3 = new SDUI.Controls.Label();
            this.numQueueLeft = new SDUI.Controls.NumUpDown();
            this.checkAutoHidePendingWindow = new SDUI.Controls.CheckBox();
            this.checkEnableQueueNotification = new SDUI.Controls.CheckBox();
            this.btnShowPending = new SDUI.Controls.Button();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numLoginDelay)).BeginInit();
            this.captchaPanel.SuspendLayout();
            this.autoLoginTopPanel.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQueueLeft)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(16, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Silkroad executable path:";
            // 
            // lblVersion
            // 
            this.lblVersion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblVersion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblVersion.Location = new System.Drawing.Point(707, 11);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(40, 15);
            this.lblVersion.TabIndex = 3;
            this.lblVersion.Text = "v1.000";
            // 
            // comboBoxClientType
            // 
            this.comboBoxClientType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBoxClientType.DropDownHeight = 100;
            this.comboBoxClientType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxClientType.FormattingEnabled = true;
            this.comboBoxClientType.IntegralHeight = false;
            this.comboBoxClientType.ItemHeight = 17;
            this.comboBoxClientType.Location = new System.Drawing.Point(595, 29);
            this.comboBoxClientType.Name = "comboBoxClientType";
            this.comboBoxClientType.Radius = 5;
            this.comboBoxClientType.ShadowDepth = 4F;
            this.comboBoxClientType.Size = new System.Drawing.Size(115, 23);
            this.comboBoxClientType.TabIndex = 18;
            this.comboBoxClientType.SelectedIndexChanged += new System.EventHandler(this.comboBoxClientType_SelectedIndexChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.Transparent;
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.checkBoxBotTrayMinimized);
            this.groupBox4.Location = new System.Drawing.Point(389, 172);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.groupBox4.Radius = 10;
            this.groupBox4.ShadowDepth = 4;
            this.groupBox4.Size = new System.Drawing.Size(359, 98);
            this.groupBox4.TabIndex = 17;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Bot Settings";
            // 
            // label8
            // 
            this.label8.Enabled = false;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label8.Location = new System.Drawing.Point(6, 60);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(347, 35);
            this.label8.TabIndex = 22;
            this.label8.Text = "If activated, when the bot is minimized, the bot will \r\nautomatically switch to t" +
    "ray mode and continue to run there.";
            // 
            // checkBoxBotTrayMinimized
            // 
            this.checkBoxBotTrayMinimized.AutoSize = true;
            this.checkBoxBotTrayMinimized.BackColor = System.Drawing.Color.Transparent;
            this.checkBoxBotTrayMinimized.Location = new System.Drawing.Point(19, 36);
            this.checkBoxBotTrayMinimized.Name = "checkBoxBotTrayMinimized";
            this.checkBoxBotTrayMinimized.ShadowDepth = 1;
            this.checkBoxBotTrayMinimized.Size = new System.Drawing.Size(242, 15);
            this.checkBoxBotTrayMinimized.TabIndex = 0;
            this.checkBoxBotTrayMinimized.Text = "Move bot to system tray when minimized";
            this.checkBoxBotTrayMinimized.UseVisualStyleBackColor = false;
            this.checkBoxBotTrayMinimized.CheckedChanged += new System.EventHandler(this.checkBoxBotTrayMinimized_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.checkStayConnected);
            this.groupBox3.Location = new System.Drawing.Point(389, 60);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.groupBox3.Radius = 10;
            this.groupBox3.ShadowDepth = 4;
            this.groupBox3.Size = new System.Drawing.Size(359, 105);
            this.groupBox3.TabIndex = 16;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Client settings";
            // 
            // label2
            // 
            this.label2.Enabled = false;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(6, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(347, 37);
            this.label2.TabIndex = 22;
            this.label2.Text = "If the client exits due to a crash, the bot will automatically switch\r\n to client" +
    "less mode and continue its tasks";
            // 
            // checkStayConnected
            // 
            this.checkStayConnected.AutoSize = true;
            this.checkStayConnected.BackColor = System.Drawing.Color.Transparent;
            this.checkStayConnected.Location = new System.Drawing.Point(20, 36);
            this.checkStayConnected.Name = "checkStayConnected";
            this.checkStayConnected.ShadowDepth = 1;
            this.checkStayConnected.Size = new System.Drawing.Size(247, 15);
            this.checkStayConnected.TabIndex = 17;
            this.checkStayConnected.Text = "Stay connected if client exits unexpectedly";
            this.checkStayConnected.UseVisualStyleBackColor = false;
            this.checkStayConnected.CheckedChanged += new System.EventHandler(this.checkStayConnected_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.btnClientHideShow);
            this.groupBox2.Controls.Add(this.btnStartClient);
            this.groupBox2.Controls.Add(this.btnStartClientless);
            this.groupBox2.Controls.Add(this.btnGoClientless);
            this.groupBox2.Location = new System.Drawing.Point(19, 60);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.groupBox2.Radius = 10;
            this.groupBox2.ShadowDepth = 4;
            this.groupBox2.Size = new System.Drawing.Size(355, 105);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Start game";
            // 
            // btnClientHideShow
            // 
            this.btnClientHideShow.Color = System.Drawing.Color.Transparent;
            this.btnClientHideShow.Enabled = false;
            this.btnClientHideShow.Location = new System.Drawing.Point(18, 68);
            this.btnClientHideShow.Name = "btnClientHideShow";
            this.btnClientHideShow.Radius = 6;
            this.btnClientHideShow.ShadowDepth = 4F;
            this.btnClientHideShow.Size = new System.Drawing.Size(125, 21);
            this.btnClientHideShow.TabIndex = 19;
            this.btnClientHideShow.Text = "Client Visibility";
            this.btnClientHideShow.UseVisualStyleBackColor = true;
            this.btnClientHideShow.Click += new System.EventHandler(this.btnClientHideShow_Click);
            // 
            // btnStartClient
            // 
            this.btnStartClient.Color = System.Drawing.Color.Transparent;
            this.btnStartClient.Location = new System.Drawing.Point(18, 36);
            this.btnStartClient.Name = "btnStartClient";
            this.btnStartClient.Radius = 6;
            this.btnStartClient.ShadowDepth = 4F;
            this.btnStartClient.Size = new System.Drawing.Size(125, 21);
            this.btnStartClient.TabIndex = 16;
            this.btnStartClient.Text = "Start Client";
            this.btnStartClient.UseVisualStyleBackColor = true;
            this.btnStartClient.Click += new System.EventHandler(this.btnStartClient_Click);
            // 
            // btnStartClientless
            // 
            this.btnStartClientless.Color = System.Drawing.Color.Transparent;
            this.btnStartClientless.Location = new System.Drawing.Point(212, 36);
            this.btnStartClientless.Name = "btnStartClientless";
            this.btnStartClientless.Radius = 6;
            this.btnStartClientless.ShadowDepth = 4F;
            this.btnStartClientless.Size = new System.Drawing.Size(125, 21);
            this.btnStartClientless.TabIndex = 18;
            this.btnStartClientless.Text = "Start Clientless";
            this.btnStartClientless.UseVisualStyleBackColor = false;
            this.btnStartClientless.Click += new System.EventHandler(this.btnStartClientless_Click);
            // 
            // btnGoClientless
            // 
            this.btnGoClientless.Color = System.Drawing.Color.Transparent;
            this.btnGoClientless.Enabled = false;
            this.btnGoClientless.Location = new System.Drawing.Point(212, 68);
            this.btnGoClientless.Name = "btnGoClientless";
            this.btnGoClientless.Radius = 6;
            this.btnGoClientless.ShadowDepth = 4F;
            this.btnGoClientless.Size = new System.Drawing.Size(125, 21);
            this.btnGoClientless.TabIndex = 17;
            this.btnGoClientless.Text = "Go Clientless";
            this.btnGoClientless.UseVisualStyleBackColor = true;
            this.btnGoClientless.Click += new System.EventHandler(this.btnGoClientless_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.separator1);
            this.groupBox1.Controls.Add(this.panel3);
            this.groupBox1.Controls.Add(this.captchaPanel);
            this.groupBox1.Controls.Add(this.autoLoginTopPanel);
            this.groupBox1.Location = new System.Drawing.Point(19, 172);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.groupBox1.Radius = 10;
            this.groupBox1.ShadowDepth = 4;
            this.groupBox1.Size = new System.Drawing.Size(355, 317);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Automated login";
            // 
            // separator1
            // 
            this.separator1.Dock = System.Windows.Forms.DockStyle.Top;
            this.separator1.IsVertical = false;
            this.separator1.Location = new System.Drawing.Point(3, 203);
            this.separator1.Name = "separator1";
            this.separator1.Size = new System.Drawing.Size(349, 2);
            this.separator1.TabIndex = 19;
            this.separator1.Text = "separator1";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.radioAutoSelectHigher);
            this.panel3.Controls.Add(this.radioAutoSelectFirst);
            this.panel3.Controls.Add(this.checkCharAutoSelect);
            this.panel3.Controls.Add(this.checkHideClient);
            this.panel3.Controls.Add(this.lblLoginDelaySeconds);
            this.panel3.Controls.Add(this.numLoginDelay);
            this.panel3.Controls.Add(this.checkEnableLoginDelay);
            this.panel3.Controls.Add(this.checkStartBot);
            this.panel3.Controls.Add(this.checkUseReturnScroll);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 203);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(349, 111);
            this.panel3.TabIndex = 1;
            // 
            // radioAutoSelectHigher
            // 
            this.radioAutoSelectHigher.AutoSize = true;
            this.radioAutoSelectHigher.Enabled = false;
            this.radioAutoSelectHigher.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.radioAutoSelectHigher.Location = new System.Drawing.Point(198, 87);
            this.radioAutoSelectHigher.Name = "radioAutoSelectHigher";
            this.radioAutoSelectHigher.ShadowDepth = 0;
            this.radioAutoSelectHigher.Size = new System.Drawing.Size(139, 15);
            this.radioAutoSelectHigher.TabIndex = 38;
            this.radioAutoSelectHigher.Text = "Auto Select (Higher)";
            this.radioAutoSelectHigher.UseVisualStyleBackColor = true;
            this.radioAutoSelectHigher.CheckedChanged += new System.EventHandler(this.radioAutoSelectHigher_CheckedChanged);
            // 
            // radioAutoSelectFirst
            // 
            this.radioAutoSelectFirst.AutoSize = true;
            this.radioAutoSelectFirst.Checked = true;
            this.radioAutoSelectFirst.Enabled = false;
            this.radioAutoSelectFirst.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.radioAutoSelectFirst.Location = new System.Drawing.Point(66, 87);
            this.radioAutoSelectFirst.Name = "radioAutoSelectFirst";
            this.radioAutoSelectFirst.ShadowDepth = 0;
            this.radioAutoSelectFirst.Size = new System.Drawing.Size(125, 15);
            this.radioAutoSelectFirst.TabIndex = 37;
            this.radioAutoSelectFirst.TabStop = true;
            this.radioAutoSelectFirst.Text = "Auto Select (First)";
            this.radioAutoSelectFirst.UseVisualStyleBackColor = true;
            this.radioAutoSelectFirst.CheckedChanged += new System.EventHandler(this.radioAutoSelectFirst_CheckedChanged);
            // 
            // checkCharAutoSelect
            // 
            this.checkCharAutoSelect.AutoSize = true;
            this.checkCharAutoSelect.BackColor = System.Drawing.Color.Transparent;
            this.checkCharAutoSelect.Enabled = false;
            this.checkCharAutoSelect.Location = new System.Drawing.Point(66, 64);
            this.checkCharAutoSelect.Name = "checkCharAutoSelect";
            this.checkCharAutoSelect.ShadowDepth = 1;
            this.checkCharAutoSelect.Size = new System.Drawing.Size(111, 15);
            this.checkCharAutoSelect.TabIndex = 36;
            this.checkCharAutoSelect.Text = "Auto Char Select";
            this.checkCharAutoSelect.UseVisualStyleBackColor = false;
            this.checkCharAutoSelect.CheckedChanged += new System.EventHandler(this.checkCharAutoSelect_CheckedChanged);
            // 
            // checkHideClient
            // 
            this.checkHideClient.AutoSize = true;
            this.checkHideClient.BackColor = System.Drawing.Color.Transparent;
            this.checkHideClient.Location = new System.Drawing.Point(198, 64);
            this.checkHideClient.Name = "checkHideClient";
            this.checkHideClient.ShadowDepth = 1;
            this.checkHideClient.Size = new System.Drawing.Size(111, 15);
            this.checkHideClient.TabIndex = 31;
            this.checkHideClient.Text = "Auto Hide Client";
            this.checkHideClient.UseVisualStyleBackColor = false;
            this.checkHideClient.CheckedChanged += new System.EventHandler(this.checkHideClient_CheckedChanged);
            // 
            // lblLoginDelaySeconds
            // 
            this.lblLoginDelaySeconds.AutoSize = true;
            this.lblLoginDelaySeconds.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblLoginDelaySeconds.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblLoginDelaySeconds.Location = new System.Drawing.Point(259, 12);
            this.lblLoginDelaySeconds.Name = "lblLoginDelaySeconds";
            this.lblLoginDelaySeconds.Size = new System.Drawing.Size(49, 13);
            this.lblLoginDelaySeconds.TabIndex = 22;
            this.lblLoginDelaySeconds.Text = "seconds";
            // 
            // numLoginDelay
            // 
            this.numLoginDelay.AutoSize = true;
            this.numLoginDelay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.numLoginDelay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numLoginDelay.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numLoginDelay.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.numLoginDelay.Location = new System.Drawing.Point(198, 9);
            this.numLoginDelay.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.numLoginDelay.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numLoginDelay.Name = "numLoginDelay";
            this.numLoginDelay.Size = new System.Drawing.Size(54, 22);
            this.numLoginDelay.TabIndex = 30;
            this.numLoginDelay.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numLoginDelay.ValueChanged += new System.EventHandler(this.numLoginDelay_ValueChanged);
            // 
            // checkEnableLoginDelay
            // 
            this.checkEnableLoginDelay.AutoSize = true;
            this.checkEnableLoginDelay.BackColor = System.Drawing.Color.Transparent;
            this.checkEnableLoginDelay.Location = new System.Drawing.Point(66, 12);
            this.checkEnableLoginDelay.Name = "checkEnableLoginDelay";
            this.checkEnableLoginDelay.ShadowDepth = 1;
            this.checkEnableLoginDelay.Size = new System.Drawing.Size(119, 15);
            this.checkEnableLoginDelay.TabIndex = 25;
            this.checkEnableLoginDelay.Text = "Enable login delay";
            this.checkEnableLoginDelay.UseVisualStyleBackColor = false;
            this.checkEnableLoginDelay.CheckedChanged += new System.EventHandler(this.checkEnableLoginDelay_CheckedChanged);
            // 
            // checkStartBot
            // 
            this.checkStartBot.AutoSize = true;
            this.checkStartBot.BackColor = System.Drawing.Color.Transparent;
            this.checkStartBot.Location = new System.Drawing.Point(66, 40);
            this.checkStartBot.Name = "checkStartBot";
            this.checkStartBot.ShadowDepth = 1;
            this.checkStartBot.Size = new System.Drawing.Size(96, 15);
            this.checkStartBot.TabIndex = 24;
            this.checkStartBot.Text = "Auto start bot";
            this.checkStartBot.UseVisualStyleBackColor = false;
            this.checkStartBot.CheckedChanged += new System.EventHandler(this.checkAutoStartBot_CheckedChanged);
            // 
            // checkUseReturnScroll
            // 
            this.checkUseReturnScroll.AutoSize = true;
            this.checkUseReturnScroll.BackColor = System.Drawing.Color.Transparent;
            this.checkUseReturnScroll.Location = new System.Drawing.Point(198, 40);
            this.checkUseReturnScroll.Name = "checkUseReturnScroll";
            this.checkUseReturnScroll.ShadowDepth = 1;
            this.checkUseReturnScroll.Size = new System.Drawing.Size(108, 15);
            this.checkUseReturnScroll.TabIndex = 16;
            this.checkUseReturnScroll.Text = "Use return scroll";
            this.checkUseReturnScroll.UseVisualStyleBackColor = false;
            this.checkUseReturnScroll.CheckedChanged += new System.EventHandler(this.checkUseReturnScroll_CheckedChanged);
            // 
            // captchaPanel
            // 
            this.captchaPanel.Controls.Add(this.separator2);
            this.captchaPanel.Controls.Add(this.label6);
            this.captchaPanel.Controls.Add(this.label5);
            this.captchaPanel.Controls.Add(this.txtStaticCaptcha);
            this.captchaPanel.Controls.Add(this.checkEnableStaticCaptcha);
            this.captchaPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.captchaPanel.Location = new System.Drawing.Point(3, 120);
            this.captchaPanel.Name = "captchaPanel";
            this.captchaPanel.Size = new System.Drawing.Size(349, 83);
            this.captchaPanel.TabIndex = 0;
            this.captchaPanel.Visible = false;
            // 
            // separator2
            // 
            this.separator2.Dock = System.Windows.Forms.DockStyle.Top;
            this.separator2.IsVertical = false;
            this.separator2.Location = new System.Drawing.Point(0, 0);
            this.separator2.Name = "separator2";
            this.separator2.Size = new System.Drawing.Size(349, 2);
            this.separator2.TabIndex = 29;
            this.separator2.Text = "separator2";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Enabled = false;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label6.Location = new System.Drawing.Point(63, 60);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(260, 13);
            this.label6.TabIndex = 21;
            this.label6.Text = "Please use this only if the captcha never changes.";
            // 
            // label5
            // 
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label5.Location = new System.Drawing.Point(9, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 18);
            this.label5.TabIndex = 18;
            this.label5.Text = "Captcha:";
            // 
            // txtStaticCaptcha
            // 
            this.txtStaticCaptcha.Location = new System.Drawing.Point(66, 11);
            this.txtStaticCaptcha.MaxLength = 32767;
            this.txtStaticCaptcha.MultiLine = false;
            this.txtStaticCaptcha.Name = "txtStaticCaptcha";
            this.txtStaticCaptcha.Radius = 2;
            this.txtStaticCaptcha.Size = new System.Drawing.Size(268, 21);
            this.txtStaticCaptcha.TabIndex = 3;
            this.txtStaticCaptcha.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtStaticCaptcha.UseSystemPasswordChar = false;
            this.txtStaticCaptcha.TextChanged += new System.EventHandler(this.txtStaticCaptcha_TextChanged);
            // 
            // checkEnableStaticCaptcha
            // 
            this.checkEnableStaticCaptcha.AutoSize = true;
            this.checkEnableStaticCaptcha.BackColor = System.Drawing.Color.Transparent;
            this.checkEnableStaticCaptcha.Location = new System.Drawing.Point(66, 37);
            this.checkEnableStaticCaptcha.Name = "checkEnableStaticCaptcha";
            this.checkEnableStaticCaptcha.ShadowDepth = 1;
            this.checkEnableStaticCaptcha.Size = new System.Drawing.Size(164, 15);
            this.checkEnableStaticCaptcha.TabIndex = 4;
            this.checkEnableStaticCaptcha.Text = "Enable static captcha solve";
            this.checkEnableStaticCaptcha.UseVisualStyleBackColor = false;
            this.checkEnableStaticCaptcha.CheckedChanged += new System.EventHandler(this.checkEnableStaticCaptcha_CheckedChanged);
            // 
            // autoLoginTopPanel
            // 
            this.autoLoginTopPanel.BackColor = System.Drawing.Color.Transparent;
            this.autoLoginTopPanel.Controls.Add(this.comboAccounts);
            this.autoLoginTopPanel.Controls.Add(this.label7);
            this.autoLoginTopPanel.Controls.Add(this.label4);
            this.autoLoginTopPanel.Controls.Add(this.checkEnableAutoLogin);
            this.autoLoginTopPanel.Controls.Add(this.comboCharacter);
            this.autoLoginTopPanel.Controls.Add(this.btnAutoLoginSettings);
            this.autoLoginTopPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.autoLoginTopPanel.Location = new System.Drawing.Point(3, 26);
            this.autoLoginTopPanel.Name = "autoLoginTopPanel";
            this.autoLoginTopPanel.Size = new System.Drawing.Size(349, 94);
            this.autoLoginTopPanel.TabIndex = 28;
            // 
            // comboAccounts
            // 
            this.comboAccounts.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboAccounts.DropDownHeight = 100;
            this.comboAccounts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboAccounts.FormattingEnabled = true;
            this.comboAccounts.IntegralHeight = false;
            this.comboAccounts.ItemHeight = 17;
            this.comboAccounts.Location = new System.Drawing.Point(66, 10);
            this.comboAccounts.Name = "comboAccounts";
            this.comboAccounts.Radius = 5;
            this.comboAccounts.ShadowDepth = 4F;
            this.comboAccounts.Size = new System.Drawing.Size(268, 23);
            this.comboAccounts.TabIndex = 0;
            this.comboAccounts.SelectedIndexChanged += new System.EventHandler(this.comboAccounts_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label7.Location = new System.Drawing.Point(20, 37);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 16);
            this.label7.TabIndex = 23;
            this.label7.Text = "Player:";
            // 
            // label4
            // 
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label4.Location = new System.Drawing.Point(9, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Account:";
            // 
            // checkEnableAutoLogin
            // 
            this.checkEnableAutoLogin.AutoSize = true;
            this.checkEnableAutoLogin.BackColor = System.Drawing.Color.Transparent;
            this.checkEnableAutoLogin.Location = new System.Drawing.Point(66, 65);
            this.checkEnableAutoLogin.Name = "checkEnableAutoLogin";
            this.checkEnableAutoLogin.ShadowDepth = 1;
            this.checkEnableAutoLogin.Size = new System.Drawing.Size(149, 15);
            this.checkEnableAutoLogin.TabIndex = 1;
            this.checkEnableAutoLogin.Text = "Enable automated login";
            this.checkEnableAutoLogin.UseVisualStyleBackColor = false;
            this.checkEnableAutoLogin.CheckedChanged += new System.EventHandler(this.checkEnableAutoLogin_CheckedChanged);
            // 
            // comboCharacter
            // 
            this.comboCharacter.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboCharacter.DropDownHeight = 100;
            this.comboCharacter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboCharacter.FormattingEnabled = true;
            this.comboCharacter.IntegralHeight = false;
            this.comboCharacter.ItemHeight = 17;
            this.comboCharacter.Items.AddRange(new object[] {
            "No Selected"});
            this.comboCharacter.Location = new System.Drawing.Point(66, 34);
            this.comboCharacter.Name = "comboCharacter";
            this.comboCharacter.Radius = 5;
            this.comboCharacter.ShadowDepth = 4F;
            this.comboCharacter.Size = new System.Drawing.Size(268, 23);
            this.comboCharacter.TabIndex = 22;
            this.comboCharacter.SelectedIndexChanged += new System.EventHandler(this.comboCharacter_SelectedIndexChanged);
            // 
            // btnAutoLoginSettings
            // 
            this.btnAutoLoginSettings.Color = System.Drawing.Color.Transparent;
            this.btnAutoLoginSettings.Location = new System.Drawing.Point(259, 60);
            this.btnAutoLoginSettings.Name = "btnAutoLoginSettings";
            this.btnAutoLoginSettings.Radius = 6;
            this.btnAutoLoginSettings.ShadowDepth = 4F;
            this.btnAutoLoginSettings.Size = new System.Drawing.Size(75, 23);
            this.btnAutoLoginSettings.TabIndex = 2;
            this.btnAutoLoginSettings.Text = "Setup";
            this.btnAutoLoginSettings.UseVisualStyleBackColor = true;
            this.btnAutoLoginSettings.Click += new System.EventHandler(this.btnAutoLoginSettings_Click);
            // 
            // btnBrowseSilkroadPath
            // 
            this.btnBrowseSilkroadPath.Color = System.Drawing.Color.Transparent;
            this.btnBrowseSilkroadPath.Location = new System.Drawing.Point(715, 30);
            this.btnBrowseSilkroadPath.Name = "btnBrowseSilkroadPath";
            this.btnBrowseSilkroadPath.Radius = 6;
            this.btnBrowseSilkroadPath.ShadowDepth = 4F;
            this.btnBrowseSilkroadPath.Size = new System.Drawing.Size(32, 21);
            this.btnBrowseSilkroadPath.TabIndex = 2;
            this.btnBrowseSilkroadPath.Text = "...";
            this.btnBrowseSilkroadPath.UseVisualStyleBackColor = true;
            this.btnBrowseSilkroadPath.Click += new System.EventHandler(this.btnBrowseSilkroadPath_Click);
            // 
            // txtSilkroadPath
            // 
            this.txtSilkroadPath.Location = new System.Drawing.Point(19, 30);
            this.txtSilkroadPath.MaxLength = 32767;
            this.txtSilkroadPath.MultiLine = false;
            this.txtSilkroadPath.Name = "txtSilkroadPath";
            this.txtSilkroadPath.Radius = 2;
            this.txtSilkroadPath.Size = new System.Drawing.Size(570, 21);
            this.txtSilkroadPath.TabIndex = 1;
            this.txtSilkroadPath.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtSilkroadPath.UseSystemPasswordChar = false;
            // 
            // groupBox5
            // 
            this.groupBox5.BackColor = System.Drawing.Color.Transparent;
            this.groupBox5.Controls.Add(this.checkEnableQueueLogs);
            this.groupBox5.Controls.Add(this.label3);
            this.groupBox5.Controls.Add(this.numQueueLeft);
            this.groupBox5.Controls.Add(this.checkAutoHidePendingWindow);
            this.groupBox5.Controls.Add(this.checkEnableQueueNotification);
            this.groupBox5.Controls.Add(this.btnShowPending);
            this.groupBox5.Location = new System.Drawing.Point(389, 278);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.groupBox5.Radius = 10;
            this.groupBox5.ShadowDepth = 4;
            this.groupBox5.Size = new System.Drawing.Size(359, 130);
            this.groupBox5.TabIndex = 24;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Server Pending";
            // 
            // checkEnableQueueLogs
            // 
            this.checkEnableQueueLogs.AutoSize = true;
            this.checkEnableQueueLogs.BackColor = System.Drawing.Color.Transparent;
            this.checkEnableQueueLogs.Location = new System.Drawing.Point(20, 53);
            this.checkEnableQueueLogs.Name = "checkEnableQueueLogs";
            this.checkEnableQueueLogs.ShadowDepth = 1;
            this.checkEnableQueueLogs.Size = new System.Drawing.Size(166, 15);
            this.checkEnableQueueLogs.TabIndex = 42;
            this.checkEnableQueueLogs.Text = "Enable pending queue logs";
            this.checkEnableQueueLogs.UseVisualStyleBackColor = false;
            this.checkEnableQueueLogs.CheckedChanged += new System.EventHandler(this.checkEnableQueueLogs_CheckedChanged);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(264, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 18);
            this.label3.TabIndex = 39;
            this.label3.Text = "people left";
            // 
            // numQueueLeft
            // 
            this.numQueueLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.numQueueLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numQueueLeft.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.numQueueLeft.Location = new System.Drawing.Point(204, 72);
            this.numQueueLeft.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numQueueLeft.Name = "numQueueLeft";
            this.numQueueLeft.Size = new System.Drawing.Size(54, 23);
            this.numQueueLeft.TabIndex = 39;
            this.numQueueLeft.ValueChanged += new System.EventHandler(this.numQueueLeft_ValueChanged);
            // 
            // checkDontShowPendingOnStartClient
            // 
            this.checkAutoHidePendingWindow.AutoSize = true;
            this.checkAutoHidePendingWindow.BackColor = System.Drawing.Color.Transparent;
            this.checkAutoHidePendingWindow.Location = new System.Drawing.Point(20, 32);
            this.checkAutoHidePendingWindow.Name = "checkDontShowPendingOnStartClient";
            this.checkAutoHidePendingWindow.ShadowDepth = 1;
            this.checkAutoHidePendingWindow.Size = new System.Drawing.Size(187, 15);
            this.checkAutoHidePendingWindow.TabIndex = 41;
            this.checkAutoHidePendingWindow.Text = "Auto hide the pending window";
            this.checkAutoHidePendingWindow.UseVisualStyleBackColor = false;
            this.checkAutoHidePendingWindow.CheckedChanged += new System.EventHandler(this.checkDontShowPendingOnStartClient_CheckedChanged);
            // 
            // checkEnableQueueNotification
            // 
            this.checkEnableQueueNotification.AutoSize = true;
            this.checkEnableQueueNotification.BackColor = System.Drawing.Color.Transparent;
            this.checkEnableQueueNotification.Location = new System.Drawing.Point(20, 75);
            this.checkEnableQueueNotification.Name = "checkEnableQueueNotification";
            this.checkEnableQueueNotification.ShadowDepth = 1;
            this.checkEnableQueueNotification.Size = new System.Drawing.Size(178, 15);
            this.checkEnableQueueNotification.TabIndex = 40;
            this.checkEnableQueueNotification.Text = "Enable queue notification on ";
            this.checkEnableQueueNotification.UseVisualStyleBackColor = false;
            this.checkEnableQueueNotification.CheckedChanged += new System.EventHandler(this.checkEnableQueueNotification_CheckedChanged);
            // 
            // btnShowPending
            // 
            this.btnShowPending.Color = System.Drawing.Color.Transparent;
            this.btnShowPending.Location = new System.Drawing.Point(20, 99);
            this.btnShowPending.Name = "btnShowPending";
            this.btnShowPending.Radius = 6;
            this.btnShowPending.ShadowDepth = 4F;
            this.btnShowPending.Size = new System.Drawing.Size(145, 23);
            this.btnShowPending.TabIndex = 24;
            this.btnShowPending.Text = "Toggle Pending Window";
            this.btnShowPending.UseVisualStyleBackColor = true;
            this.btnShowPending.Click += new System.EventHandler(this.btnShowPending_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.comboBoxClientType);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.btnBrowseSilkroadPath);
            this.Controls.Add(this.txtSilkroadPath);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Name = "Main";
            this.Size = new System.Drawing.Size(765, 496);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numLoginDelay)).EndInit();
            this.captchaPanel.ResumeLayout(false);
            this.captchaPanel.PerformLayout();
            this.autoLoginTopPanel.ResumeLayout(false);
            this.autoLoginTopPanel.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQueueLeft)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SDUI.Controls.Label label1;
        private SDUI.Controls.TextBox txtSilkroadPath;
        private SDUI.Controls.Button btnBrowseSilkroadPath;
        private SDUI.Controls.Label lblVersion;
        private SDUI.Controls.GroupBox groupBox1;
        private SDUI.Controls.Label label4;
        private SDUI.Controls.ComboBox comboAccounts;
        private SDUI.Controls.CheckBox checkEnableAutoLogin;
        private SDUI.Controls.Button btnAutoLoginSettings;
        private SDUI.Controls.TextBox txtStaticCaptcha;
        private SDUI.Controls.Label label5;
        private SDUI.Controls.CheckBox checkEnableStaticCaptcha;
        private SDUI.Controls.Label label6;
        private SDUI.Controls.Label label7;
        private SDUI.Controls.ComboBox comboCharacter;
        private SDUI.Controls.GroupBox groupBox2;
        private SDUI.Controls.Button btnGoClientless;
        private SDUI.Controls.Button btnStartClientless;
        private SDUI.Controls.Button btnStartClient;
        private SDUI.Controls.CheckBox checkUseReturnScroll;
        private SDUI.Controls.CheckBox checkStartBot;
        private SDUI.Controls.GroupBox groupBox3;
        private SDUI.Controls.CheckBox checkStayConnected;
        private SDUI.Controls.Label label2;
        private SDUI.Controls.Button btnClientHideShow;
        private SDUI.Controls.GroupBox groupBox4;
        private SDUI.Controls.Label label8;
        private SDUI.Controls.CheckBox checkBoxBotTrayMinimized;
        private SDUI.Controls.ComboBox comboBoxClientType;
        private System.Windows.Forms.Panel captchaPanel;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel autoLoginTopPanel;
        private SDUI.Controls.Separator separator2;
        private SDUI.Controls.Separator separator1;
        private SDUI.Controls.Label lblLoginDelaySeconds;
        private SDUI.Controls.NumUpDown numLoginDelay;
        private SDUI.Controls.CheckBox checkEnableLoginDelay;
        private SDUI.Controls.CheckBox checkHideClient;
        private SDUI.Controls.Radio radioAutoSelectHigher;
        private SDUI.Controls.Radio radioAutoSelectFirst;
        private SDUI.Controls.CheckBox checkCharAutoSelect;
        private SDUI.Controls.GroupBox groupBox5;
        private SDUI.Controls.Button btnShowPending;
        private SDUI.Controls.CheckBox checkEnableQueueNotification;
        private SDUI.Controls.NumUpDown numQueueLeft;
        private SDUI.Controls.CheckBox checkAutoHidePendingWindow;
        private SDUI.Controls.Label label3;
        private SDUI.Controls.CheckBox checkEnableQueueLogs;
    }
}
