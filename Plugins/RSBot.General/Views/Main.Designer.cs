namespace RSBot.General.Views
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
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.captchaPanel.SuspendLayout();
            this.autoLoginTopPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(16, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Silkroad executable path:";
            // 
            // lblVersion
            // 
            this.lblVersion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.comboBoxClientType.Size = new System.Drawing.Size(115, 23);
            this.comboBoxClientType.TabIndex = 18;
            this.comboBoxClientType.SelectedIndexChanged += new System.EventHandler(this.comboBoxClientType_SelectedIndexChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.Transparent;
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.checkBoxBotTrayMinimized);
            this.groupBox4.Location = new System.Drawing.Point(389, 183);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.groupBox4.Radius = 2;
            this.groupBox4.Size = new System.Drawing.Size(359, 110);
            this.groupBox4.TabIndex = 17;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Bot Settings";
            // 
            // label8
            // 
            this.label8.Enabled = false;
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label8.Location = new System.Drawing.Point(6, 55);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(347, 52);
            this.label8.TabIndex = 22;
            this.label8.Text = "If activated, when the bot is minimized, the bot will \r\nautomatically switch to t" +
    "ray mode and continue to run there.";
            // 
            // checkBoxBotTrayMinimized
            // 
            this.checkBoxBotTrayMinimized.AutoSize = true;
            this.checkBoxBotTrayMinimized.BackColor = System.Drawing.Color.Transparent;
            this.checkBoxBotTrayMinimized.Checked = false;
            this.checkBoxBotTrayMinimized.Location = new System.Drawing.Point(20, 28);
            this.checkBoxBotTrayMinimized.Name = "checkBoxBotTrayMinimized";
            this.checkBoxBotTrayMinimized.Size = new System.Drawing.Size(242, 15);
            this.checkBoxBotTrayMinimized.TabIndex = 0;
            this.checkBoxBotTrayMinimized.Text = "Move bot to system tray when minimized";
            this.checkBoxBotTrayMinimized.CheckedChanged += new System.EventHandler(this.checkBoxBotTrayMinimized_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.checkStayConnected);
            this.groupBox3.Location = new System.Drawing.Point(389, 67);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.groupBox3.Radius = 2;
            this.groupBox3.Size = new System.Drawing.Size(359, 105);
            this.groupBox3.TabIndex = 16;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Client settings";
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(6, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(347, 50);
            this.label2.TabIndex = 22;
            this.label2.Text = "If the client exits due to a crash, the bot will automatically switch\r\n to client" +
    "less mode and continue its tasks";
            // 
            // checkStayConnected
            // 
            this.checkStayConnected.AutoSize = true;
            this.checkStayConnected.BackColor = System.Drawing.Color.Transparent;
            this.checkStayConnected.Checked = false;
            this.checkStayConnected.Location = new System.Drawing.Point(20, 27);
            this.checkStayConnected.Name = "checkStayConnected";
            this.checkStayConnected.Size = new System.Drawing.Size(247, 15);
            this.checkStayConnected.TabIndex = 17;
            this.checkStayConnected.Text = "Stay connected if client exits unexpectedly";
            this.checkStayConnected.CheckedChanged += new System.EventHandler(this.checkStayConnected_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.btnClientHideShow);
            this.groupBox2.Controls.Add(this.btnStartClient);
            this.groupBox2.Controls.Add(this.btnStartClientless);
            this.groupBox2.Controls.Add(this.btnGoClientless);
            this.groupBox2.Location = new System.Drawing.Point(19, 67);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.groupBox2.Radius = 2;
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
            this.btnClientHideShow.Radius = 2;
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
            this.btnStartClient.Radius = 2;
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
            this.btnStartClientless.Radius = 2;
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
            this.btnGoClientless.Radius = 2;
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
            this.groupBox1.Location = new System.Drawing.Point(19, 183);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.groupBox1.Radius = 2;
            this.groupBox1.Size = new System.Drawing.Size(355, 282);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Automated login";
            // 
            // separator1
            // 
            this.separator1.Dock = System.Windows.Forms.DockStyle.Top;
            this.separator1.IsVertical = false;
            this.separator1.Location = new System.Drawing.Point(3, 209);
            this.separator1.Name = "separator1";
            this.separator1.Size = new System.Drawing.Size(349, 2);
            this.separator1.TabIndex = 19;
            this.separator1.Text = "separator1";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.checkStartBot);
            this.panel3.Controls.Add(this.checkUseReturnScroll);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 209);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(349, 70);
            this.panel3.TabIndex = 1;
            // 
            // checkStartBot
            // 
            this.checkStartBot.AutoSize = true;
            this.checkStartBot.BackColor = System.Drawing.Color.Transparent;
            this.checkStartBot.Checked = false;
            this.checkStartBot.Location = new System.Drawing.Point(73, 21);
            this.checkStartBot.Name = "checkStartBot";
            this.checkStartBot.Size = new System.Drawing.Size(96, 15);
            this.checkStartBot.TabIndex = 24;
            this.checkStartBot.Text = "Auto start bot";
            this.checkStartBot.CheckedChanged += new System.EventHandler(this.checkAutoStartBot_CheckedChanged);
            // 
            // checkUseReturnScroll
            // 
            this.checkUseReturnScroll.AutoSize = true;
            this.checkUseReturnScroll.BackColor = System.Drawing.Color.Transparent;
            this.checkUseReturnScroll.Checked = false;
            this.checkUseReturnScroll.Location = new System.Drawing.Point(73, 44);
            this.checkUseReturnScroll.Name = "checkUseReturnScroll";
            this.checkUseReturnScroll.Size = new System.Drawing.Size(108, 15);
            this.checkUseReturnScroll.TabIndex = 16;
            this.checkUseReturnScroll.Text = "Use return scroll";
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
            this.captchaPanel.Location = new System.Drawing.Point(3, 126);
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
            this.label6.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label6.Location = new System.Drawing.Point(70, 60);
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
            this.txtStaticCaptcha.Location = new System.Drawing.Point(73, 11);
            this.txtStaticCaptcha.MaxLength = 32767;
            this.txtStaticCaptcha.MultiLine = false;
            this.txtStaticCaptcha.Name = "txtStaticCaptcha";
            this.txtStaticCaptcha.Size = new System.Drawing.Size(258, 21);
            this.txtStaticCaptcha.TabIndex = 3;
            this.txtStaticCaptcha.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtStaticCaptcha.UseSystemPasswordChar = false;
            this.txtStaticCaptcha.TextChanged += new System.EventHandler(this.txtStaticCaptcha_TextChanged);
            // 
            // checkEnableStaticCaptcha
            // 
            this.checkEnableStaticCaptcha.AutoSize = true;
            this.checkEnableStaticCaptcha.BackColor = System.Drawing.Color.Transparent;
            this.checkEnableStaticCaptcha.Checked = false;
            this.checkEnableStaticCaptcha.Location = new System.Drawing.Point(73, 37);
            this.checkEnableStaticCaptcha.Name = "checkEnableStaticCaptcha";
            this.checkEnableStaticCaptcha.Size = new System.Drawing.Size(164, 15);
            this.checkEnableStaticCaptcha.TabIndex = 4;
            this.checkEnableStaticCaptcha.Text = "Enable static captcha solve";
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
            this.autoLoginTopPanel.Size = new System.Drawing.Size(349, 100);
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
            this.comboAccounts.Location = new System.Drawing.Point(73, 10);
            this.comboAccounts.Name = "comboAccounts";
            this.comboAccounts.Size = new System.Drawing.Size(258, 23);
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
            this.checkEnableAutoLogin.Checked = false;
            this.checkEnableAutoLogin.Location = new System.Drawing.Point(73, 65);
            this.checkEnableAutoLogin.Name = "checkEnableAutoLogin";
            this.checkEnableAutoLogin.Size = new System.Drawing.Size(149, 15);
            this.checkEnableAutoLogin.TabIndex = 1;
            this.checkEnableAutoLogin.Text = "Enable automated login";
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
            this.comboCharacter.Location = new System.Drawing.Point(73, 34);
            this.comboCharacter.Name = "comboCharacter";
            this.comboCharacter.Size = new System.Drawing.Size(258, 23);
            this.comboCharacter.TabIndex = 22;
            this.comboCharacter.SelectedIndexChanged += new System.EventHandler(this.comboCharacter_SelectedIndexChanged);
            // 
            // btnAutoLoginSettings
            // 
            this.btnAutoLoginSettings.Color = System.Drawing.Color.Transparent;
            this.btnAutoLoginSettings.Location = new System.Drawing.Point(256, 61);
            this.btnAutoLoginSettings.Name = "btnAutoLoginSettings";
            this.btnAutoLoginSettings.Radius = 2;
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
            this.btnBrowseSilkroadPath.Radius = 2;
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
            this.txtSilkroadPath.Size = new System.Drawing.Size(570, 21);
            this.txtSilkroadPath.TabIndex = 1;
            this.txtSilkroadPath.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtSilkroadPath.UseSystemPasswordChar = false;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.comboBoxClientType);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.btnBrowseSilkroadPath);
            this.Controls.Add(this.txtSilkroadPath);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Main";
            this.Size = new System.Drawing.Size(765, 480);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.captchaPanel.ResumeLayout(false);
            this.captchaPanel.PerformLayout();
            this.autoLoginTopPanel.ResumeLayout(false);
            this.autoLoginTopPanel.PerformLayout();
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
    }
}
