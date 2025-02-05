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
            label1 = new System.Windows.Forms.Label();
            lblVersion = new System.Windows.Forms.Label();
            comboBoxClientType = new System.Windows.Forms.ComboBox();
            groupBox4 = new System.Windows.Forms.GroupBox();
            label8 = new System.Windows.Forms.Label();
            checkBoxBotTrayMinimized = new System.Windows.Forms.CheckBox();
            groupBox3 = new System.Windows.Forms.GroupBox();
            label2 = new System.Windows.Forms.Label();
            checkStayConnected = new System.Windows.Forms.CheckBox();
            groupBox2 = new System.Windows.Forms.GroupBox();
            btnClientHideShow = new System.Windows.Forms.Button();
            btnStartClient = new System.Windows.Forms.Button();
            btnStartClientless = new System.Windows.Forms.Button();
            btnGoClientless = new System.Windows.Forms.Button();
            groupBox1 = new System.Windows.Forms.GroupBox();
            separator1 = new System.Windows.Forms.Panel();
            panel3 = new System.Windows.Forms.Panel();
            radioAutoSelectHigher = new System.Windows.Forms.RadioButton();
            radioAutoSelectFirst = new System.Windows.Forms.RadioButton();
            checkCharAutoSelect = new System.Windows.Forms.CheckBox();
            checkHideClient = new System.Windows.Forms.CheckBox();
            lblLoginDelaySeconds = new System.Windows.Forms.Label();
            numLoginDelay = new System.Windows.Forms.NumericUpDown();
            checkEnableLoginDelay = new System.Windows.Forms.CheckBox();
            checkStartBot = new System.Windows.Forms.CheckBox();
            checkUseReturnScroll = new System.Windows.Forms.CheckBox();
            captchaPanel = new System.Windows.Forms.Panel();
            separator2 = new System.Windows.Forms.Panel();
            label6 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            txtStaticCaptcha = new System.Windows.Forms.TextBox();
            checkEnableStaticCaptcha = new System.Windows.Forms.CheckBox();
            autoLoginTopPanel = new System.Windows.Forms.Panel();
            comboAccounts = new System.Windows.Forms.ComboBox();
            label7 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            checkEnableAutoLogin = new System.Windows.Forms.CheckBox();
            comboCharacter = new System.Windows.Forms.ComboBox();
            btnAutoLoginSettings = new System.Windows.Forms.Button();
            btnBrowseSilkroadPath = new System.Windows.Forms.Button();
            txtSilkroadPath = new System.Windows.Forms.TextBox();
            groupBox5 = new System.Windows.Forms.GroupBox();
            checkEnableQueueLogs = new System.Windows.Forms.CheckBox();
            label3 = new System.Windows.Forms.Label();
            numQueueLeft = new System.Windows.Forms.NumericUpDown();
            checkAutoHidePendingWindow = new System.Windows.Forms.CheckBox();
            checkEnableQueueNotification = new System.Windows.Forms.CheckBox();
            btnShowPending = new System.Windows.Forms.Button();
            groupBox4.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numLoginDelay).BeginInit();
            captchaPanel.SuspendLayout();
            autoLoginTopPanel.SuspendLayout();
            groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numQueueLeft).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Segoe UI", 9F);
            label1.Location = new System.Drawing.Point(22, 15);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(180, 20);
            label1.TabIndex = 0;
            label1.Text = "Silkroad executable path: ";
            label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblVersion
            // 
            lblVersion.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblVersion.Location = new System.Drawing.Point(808, 15);
            lblVersion.Name = "lblVersion";
            lblVersion.Size = new System.Drawing.Size(46, 20);
            lblVersion.TabIndex = 3;
            lblVersion.Text = "v1.000";
            // 
            // comboBoxClientType
            // 
            comboBoxClientType.DropDownHeight = 100;
            comboBoxClientType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBoxClientType.FormattingEnabled = true;
            comboBoxClientType.IntegralHeight = false;
            comboBoxClientType.ItemHeight = 20;
            comboBoxClientType.Location = new System.Drawing.Point(679, 40);
            comboBoxClientType.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            comboBoxClientType.Name = "comboBoxClientType";
            comboBoxClientType.Size = new System.Drawing.Size(131, 28);
            comboBoxClientType.TabIndex = 18;
            comboBoxClientType.SelectedIndexChanged += comboBoxClientType_SelectedIndexChanged;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(label8);
            groupBox4.Controls.Add(checkBoxBotTrayMinimized);
            groupBox4.Location = new System.Drawing.Point(445, 229);
            groupBox4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            groupBox4.Name = "groupBox4";
            groupBox4.Padding = new System.Windows.Forms.Padding(3, 13, 3, 4);
            groupBox4.Size = new System.Drawing.Size(410, 131);
            groupBox4.TabIndex = 17;
            groupBox4.TabStop = false;
            groupBox4.Text = "Bot Settings";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Enabled = false;
            label8.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            label8.Location = new System.Drawing.Point(7, 71);
            label8.Name = "label8";
            label8.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            label8.Size = new System.Drawing.Size(387, 46);
            label8.TabIndex = 22;
            label8.Text = "If activated, when the bot is minimized, the bot will \r\nautomatically switch to tray mode and continue to run there.";
            // 
            // checkBoxBotTrayMinimized
            // 
            checkBoxBotTrayMinimized.AutoSize = true;
            checkBoxBotTrayMinimized.Location = new System.Drawing.Point(22, 40);
            checkBoxBotTrayMinimized.Margin = new System.Windows.Forms.Padding(0);
            checkBoxBotTrayMinimized.Name = "checkBoxBotTrayMinimized";
            checkBoxBotTrayMinimized.Size = new System.Drawing.Size(304, 24);
            checkBoxBotTrayMinimized.TabIndex = 0;
            checkBoxBotTrayMinimized.Text = "Move bot to system tray when minimized";
            checkBoxBotTrayMinimized.UseVisualStyleBackColor = false;
            checkBoxBotTrayMinimized.CheckedChanged += checkBoxBotTrayMinimized_CheckedChanged;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(label2);
            groupBox3.Controls.Add(checkStayConnected);
            groupBox3.Location = new System.Drawing.Point(445, 80);
            groupBox3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new System.Windows.Forms.Padding(3, 13, 3, 4);
            groupBox3.Size = new System.Drawing.Size(410, 140);
            groupBox3.TabIndex = 16;
            groupBox3.TabStop = false;
            groupBox3.Text = "Client settings";
            // 
            // label2
            // 
            label2.Dock = System.Windows.Forms.DockStyle.Bottom;
            label2.Enabled = false;
            label2.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            label2.Location = new System.Drawing.Point(3, 62);
            label2.Name = "label2";
            label2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            label2.Size = new System.Drawing.Size(404, 74);
            label2.TabIndex = 22;
            label2.Text = "If the client exits due to a crash, the bot will automatically switch\r\n to clientless mode and continue its tasks";
            label2.UseCompatibleTextRendering = true;
            // 
            // checkStayConnected
            // 
            checkStayConnected.AutoSize = true;
            checkStayConnected.Location = new System.Drawing.Point(23, 36);
            checkStayConnected.Margin = new System.Windows.Forms.Padding(0);
            checkStayConnected.Name = "checkStayConnected";
            checkStayConnected.Size = new System.Drawing.Size(315, 26);
            checkStayConnected.TabIndex = 17;
            checkStayConnected.Text = "Stay connected if client exits unexpectedly";
            checkStayConnected.UseCompatibleTextRendering = true;
            checkStayConnected.UseVisualStyleBackColor = true;
            checkStayConnected.CheckedChanged += checkStayConnected_CheckedChanged;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnClientHideShow);
            groupBox2.Controls.Add(btnStartClient);
            groupBox2.Controls.Add(btnStartClientless);
            groupBox2.Controls.Add(btnGoClientless);
            groupBox2.Location = new System.Drawing.Point(22, 80);
            groupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new System.Windows.Forms.Padding(0);
            groupBox2.Size = new System.Drawing.Size(406, 114);
            groupBox2.TabIndex = 15;
            groupBox2.TabStop = false;
            groupBox2.Text = "Start game";
            // 
            // btnClientHideShow
            // 
            btnClientHideShow.AutoSize = true;
            btnClientHideShow.Enabled = false;
            btnClientHideShow.Location = new System.Drawing.Point(18, 73);
            btnClientHideShow.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btnClientHideShow.Name = "btnClientHideShow";
            btnClientHideShow.Size = new System.Drawing.Size(143, 30);
            btnClientHideShow.TabIndex = 19;
            btnClientHideShow.Text = "Client Visibility";
            btnClientHideShow.UseVisualStyleBackColor = true;
            btnClientHideShow.Click += btnClientHideShow_Click;
            // 
            // btnStartClient
            // 
            btnStartClient.AutoSize = true;
            btnStartClient.Location = new System.Drawing.Point(18, 35);
            btnStartClient.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btnStartClient.Name = "btnStartClient";
            btnStartClient.Size = new System.Drawing.Size(143, 30);
            btnStartClient.TabIndex = 16;
            btnStartClient.Text = "Start Client";
            btnStartClient.UseVisualStyleBackColor = true;
            btnStartClient.Click += btnStartClient_Click;
            // 
            // btnStartClientless
            // 
            btnStartClientless.AutoSize = true;
            btnStartClientless.Location = new System.Drawing.Point(239, 35);
            btnStartClientless.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btnStartClientless.Name = "btnStartClientless";
            btnStartClientless.Size = new System.Drawing.Size(143, 30);
            btnStartClientless.TabIndex = 18;
            btnStartClientless.Text = "Start Clientless";
            btnStartClientless.UseVisualStyleBackColor = true;
            btnStartClientless.Click += btnStartClientless_Click;
            // 
            // btnGoClientless
            // 
            btnGoClientless.AutoSize = true;
            btnGoClientless.Enabled = false;
            btnGoClientless.Location = new System.Drawing.Point(239, 73);
            btnGoClientless.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btnGoClientless.Name = "btnGoClientless";
            btnGoClientless.Size = new System.Drawing.Size(143, 30);
            btnGoClientless.TabIndex = 17;
            btnGoClientless.Text = "Go Clientless";
            btnGoClientless.UseVisualStyleBackColor = true;
            btnGoClientless.Click += btnGoClientless_Click;
            // 
            // groupBox1
            // 
            groupBox1.AutoSize = true;
            groupBox1.Controls.Add(separator1);
            groupBox1.Controls.Add(panel3);
            groupBox1.Controls.Add(captchaPanel);
            groupBox1.Controls.Add(autoLoginTopPanel);
            groupBox1.Location = new System.Drawing.Point(22, 202);
            groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new System.Windows.Forms.Padding(0);
            groupBox1.Size = new System.Drawing.Size(406, 432);
            groupBox1.TabIndex = 14;
            groupBox1.TabStop = false;
            groupBox1.Text = "Automated login";
            // 
            // separator1
            // 
            separator1.Dock = System.Windows.Forms.DockStyle.Top;
            separator1.Location = new System.Drawing.Point(0, 256);
            separator1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            separator1.Name = "separator1";
            separator1.Size = new System.Drawing.Size(406, 3);
            separator1.TabIndex = 19;
            // 
            // panel3
            // 
            panel3.Controls.Add(radioAutoSelectHigher);
            panel3.Controls.Add(radioAutoSelectFirst);
            panel3.Controls.Add(checkCharAutoSelect);
            panel3.Controls.Add(checkHideClient);
            panel3.Controls.Add(lblLoginDelaySeconds);
            panel3.Controls.Add(numLoginDelay);
            panel3.Controls.Add(checkEnableLoginDelay);
            panel3.Controls.Add(checkStartBot);
            panel3.Controls.Add(checkUseReturnScroll);
            panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            panel3.Location = new System.Drawing.Point(0, 256);
            panel3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            panel3.Name = "panel3";
            panel3.Size = new System.Drawing.Size(406, 176);
            panel3.TabIndex = 1;
            // 
            // radioAutoSelectHigher
            // 
            radioAutoSelectHigher.AutoSize = true;
            radioAutoSelectHigher.Enabled = false;
            radioAutoSelectHigher.Font = new System.Drawing.Font("Segoe UI", 9F);
            radioAutoSelectHigher.Location = new System.Drawing.Point(226, 109);
            radioAutoSelectHigher.Margin = new System.Windows.Forms.Padding(0);
            radioAutoSelectHigher.Name = "radioAutoSelectHigher";
            radioAutoSelectHigher.Size = new System.Drawing.Size(165, 24);
            radioAutoSelectHigher.TabIndex = 38;
            radioAutoSelectHigher.Text = "Auto Select (Higher)";
            radioAutoSelectHigher.UseVisualStyleBackColor = true;
            radioAutoSelectHigher.CheckedChanged += radioAutoSelectHigher_CheckedChanged;
            // 
            // radioAutoSelectFirst
            // 
            radioAutoSelectFirst.AutoSize = true;
            radioAutoSelectFirst.Checked = true;
            radioAutoSelectFirst.Enabled = false;
            radioAutoSelectFirst.Font = new System.Drawing.Font("Segoe UI", 9F);
            radioAutoSelectFirst.Location = new System.Drawing.Point(75, 109);
            radioAutoSelectFirst.Margin = new System.Windows.Forms.Padding(0);
            radioAutoSelectFirst.Name = "radioAutoSelectFirst";
            radioAutoSelectFirst.Size = new System.Drawing.Size(147, 24);
            radioAutoSelectFirst.TabIndex = 37;
            radioAutoSelectFirst.TabStop = true;
            radioAutoSelectFirst.Text = "Auto Select (First)";
            radioAutoSelectFirst.UseVisualStyleBackColor = true;
            radioAutoSelectFirst.CheckedChanged += radioAutoSelectFirst_CheckedChanged;
            // 
            // checkCharAutoSelect
            // 
            checkCharAutoSelect.AutoSize = true;
            checkCharAutoSelect.Enabled = false;
            checkCharAutoSelect.Location = new System.Drawing.Point(75, 78);
            checkCharAutoSelect.Margin = new System.Windows.Forms.Padding(0);
            checkCharAutoSelect.Name = "checkCharAutoSelect";
            checkCharAutoSelect.Size = new System.Drawing.Size(141, 24);
            checkCharAutoSelect.TabIndex = 36;
            checkCharAutoSelect.Text = "Auto Char Select";
            checkCharAutoSelect.UseVisualStyleBackColor = false;
            checkCharAutoSelect.CheckedChanged += checkCharAutoSelect_CheckedChanged;
            // 
            // checkHideClient
            // 
            checkHideClient.AutoSize = true;
            checkHideClient.Location = new System.Drawing.Point(226, 78);
            checkHideClient.Margin = new System.Windows.Forms.Padding(0);
            checkHideClient.Name = "checkHideClient";
            checkHideClient.Size = new System.Drawing.Size(141, 24);
            checkHideClient.TabIndex = 31;
            checkHideClient.Text = "Auto Hide Client";
            checkHideClient.UseVisualStyleBackColor = false;
            checkHideClient.CheckedChanged += checkHideClient_CheckedChanged;
            // 
            // lblLoginDelaySeconds
            // 
            lblLoginDelaySeconds.AutoSize = true;
            lblLoginDelaySeconds.Location = new System.Drawing.Point(305, 16);
            lblLoginDelaySeconds.Name = "lblLoginDelaySeconds";
            lblLoginDelaySeconds.Size = new System.Drawing.Size(62, 20);
            lblLoginDelaySeconds.TabIndex = 22;
            lblLoginDelaySeconds.Text = "seconds";
            // 
            // numLoginDelay
            // 
            numLoginDelay.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            numLoginDelay.InterceptArrowKeys = false;
            numLoginDelay.Location = new System.Drawing.Point(226, 15);
            numLoginDelay.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            numLoginDelay.Maximum = new decimal(new int[] { 60, 0, 0, 0 });
            numLoginDelay.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numLoginDelay.Name = "numLoginDelay";
            numLoginDelay.Size = new System.Drawing.Size(73, 26);
            numLoginDelay.TabIndex = 30;
            numLoginDelay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            numLoginDelay.Value = new decimal(new int[] { 10, 0, 0, 0 });
            numLoginDelay.ValueChanged += numLoginDelay_ValueChanged;
            // 
            // checkEnableLoginDelay
            // 
            checkEnableLoginDelay.AutoSize = true;
            checkEnableLoginDelay.Location = new System.Drawing.Point(75, 15);
            checkEnableLoginDelay.Margin = new System.Windows.Forms.Padding(0);
            checkEnableLoginDelay.Name = "checkEnableLoginDelay";
            checkEnableLoginDelay.Size = new System.Drawing.Size(154, 24);
            checkEnableLoginDelay.TabIndex = 25;
            checkEnableLoginDelay.Text = "Enable login delay";
            checkEnableLoginDelay.UseVisualStyleBackColor = false;
            checkEnableLoginDelay.CheckedChanged += checkEnableLoginDelay_CheckedChanged;
            // 
            // checkStartBot
            // 
            checkStartBot.AutoSize = true;
            checkStartBot.Location = new System.Drawing.Point(75, 46);
            checkStartBot.Margin = new System.Windows.Forms.Padding(0);
            checkStartBot.Name = "checkStartBot";
            checkStartBot.Size = new System.Drawing.Size(123, 24);
            checkStartBot.TabIndex = 24;
            checkStartBot.Text = "Auto start bot";
            checkStartBot.UseVisualStyleBackColor = false;
            checkStartBot.CheckedChanged += checkAutoStartBot_CheckedChanged;
            // 
            // checkUseReturnScroll
            // 
            checkUseReturnScroll.AutoSize = true;
            checkUseReturnScroll.Location = new System.Drawing.Point(226, 46);
            checkUseReturnScroll.Margin = new System.Windows.Forms.Padding(0);
            checkUseReturnScroll.Name = "checkUseReturnScroll";
            checkUseReturnScroll.Size = new System.Drawing.Size(137, 24);
            checkUseReturnScroll.TabIndex = 16;
            checkUseReturnScroll.Text = "Use return scroll";
            checkUseReturnScroll.UseVisualStyleBackColor = false;
            checkUseReturnScroll.CheckedChanged += checkUseReturnScroll_CheckedChanged;
            // 
            // captchaPanel
            // 
            captchaPanel.Controls.Add(separator2);
            captchaPanel.Controls.Add(label6);
            captchaPanel.Controls.Add(label5);
            captchaPanel.Controls.Add(txtStaticCaptcha);
            captchaPanel.Controls.Add(checkEnableStaticCaptcha);
            captchaPanel.Dock = System.Windows.Forms.DockStyle.Top;
            captchaPanel.Location = new System.Drawing.Point(0, 145);
            captchaPanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            captchaPanel.Name = "captchaPanel";
            captchaPanel.Size = new System.Drawing.Size(406, 111);
            captchaPanel.TabIndex = 0;
            captchaPanel.Visible = false;
            // 
            // separator2
            // 
            separator2.Dock = System.Windows.Forms.DockStyle.Top;
            separator2.Location = new System.Drawing.Point(0, 0);
            separator2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            separator2.Name = "separator2";
            separator2.Size = new System.Drawing.Size(406, 3);
            separator2.TabIndex = 29;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Enabled = false;
            label6.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            label6.Location = new System.Drawing.Point(72, 81);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(309, 19);
            label6.TabIndex = 21;
            label6.Text = "Please use this only if the captcha never changes.";
            // 
            // label5
            // 
            label5.Location = new System.Drawing.Point(7, 17);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(66, 24);
            label5.TabIndex = 18;
            label5.Text = "Captcha:";
            // 
            // txtStaticCaptcha
            // 
            txtStaticCaptcha.Location = new System.Drawing.Point(75, 16);
            txtStaticCaptcha.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            txtStaticCaptcha.Name = "txtStaticCaptcha";
            txtStaticCaptcha.Size = new System.Drawing.Size(306, 27);
            txtStaticCaptcha.TabIndex = 3;
            txtStaticCaptcha.TextChanged += txtStaticCaptcha_TextChanged;
            // 
            // checkEnableStaticCaptcha
            // 
            checkEnableStaticCaptcha.AutoSize = true;
            checkEnableStaticCaptcha.Location = new System.Drawing.Point(75, 47);
            checkEnableStaticCaptcha.Margin = new System.Windows.Forms.Padding(0);
            checkEnableStaticCaptcha.Name = "checkEnableStaticCaptcha";
            checkEnableStaticCaptcha.Size = new System.Drawing.Size(209, 24);
            checkEnableStaticCaptcha.TabIndex = 4;
            checkEnableStaticCaptcha.Text = "Enable static captcha solve";
            checkEnableStaticCaptcha.UseVisualStyleBackColor = false;
            checkEnableStaticCaptcha.CheckedChanged += checkEnableStaticCaptcha_CheckedChanged;
            // 
            // autoLoginTopPanel
            // 
            autoLoginTopPanel.Controls.Add(comboAccounts);
            autoLoginTopPanel.Controls.Add(label7);
            autoLoginTopPanel.Controls.Add(label4);
            autoLoginTopPanel.Controls.Add(checkEnableAutoLogin);
            autoLoginTopPanel.Controls.Add(comboCharacter);
            autoLoginTopPanel.Controls.Add(btnAutoLoginSettings);
            autoLoginTopPanel.Dock = System.Windows.Forms.DockStyle.Top;
            autoLoginTopPanel.Location = new System.Drawing.Point(0, 20);
            autoLoginTopPanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            autoLoginTopPanel.Name = "autoLoginTopPanel";
            autoLoginTopPanel.Size = new System.Drawing.Size(406, 125);
            autoLoginTopPanel.TabIndex = 28;
            // 
            // comboAccounts
            // 
            comboAccounts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboAccounts.FormattingEnabled = true;
            comboAccounts.ItemHeight = 20;
            comboAccounts.Location = new System.Drawing.Point(75, 16);
            comboAccounts.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            comboAccounts.Name = "comboAccounts";
            comboAccounts.Size = new System.Drawing.Size(306, 28);
            comboAccounts.TabIndex = 0;
            comboAccounts.SelectedIndexChanged += comboAccounts_SelectedIndexChanged;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(21, 49);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(52, 20);
            label7.TabIndex = 23;
            label7.Text = "Player:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(10, 19);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(66, 20);
            label4.TabIndex = 0;
            label4.Text = "Account:";
            // 
            // checkEnableAutoLogin
            // 
            checkEnableAutoLogin.AutoSize = true;
            checkEnableAutoLogin.Location = new System.Drawing.Point(75, 86);
            checkEnableAutoLogin.Margin = new System.Windows.Forms.Padding(0);
            checkEnableAutoLogin.Name = "checkEnableAutoLogin";
            checkEnableAutoLogin.Size = new System.Drawing.Size(191, 24);
            checkEnableAutoLogin.TabIndex = 1;
            checkEnableAutoLogin.Text = "Enable automated login";
            checkEnableAutoLogin.UseVisualStyleBackColor = false;
            checkEnableAutoLogin.CheckedChanged += checkEnableAutoLogin_CheckedChanged;
            // 
            // comboCharacter
            // 
            comboCharacter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboCharacter.FormattingEnabled = true;
            comboCharacter.ItemHeight = 20;
            comboCharacter.Items.AddRange(new object[] { "No Selected" });
            comboCharacter.Location = new System.Drawing.Point(75, 46);
            comboCharacter.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            comboCharacter.Name = "comboCharacter";
            comboCharacter.Size = new System.Drawing.Size(306, 28);
            comboCharacter.TabIndex = 22;
            comboCharacter.SelectedIndexChanged += comboCharacter_SelectedIndexChanged;
            // 
            // btnAutoLoginSettings
            // 
            btnAutoLoginSettings.Location = new System.Drawing.Point(295, 82);
            btnAutoLoginSettings.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btnAutoLoginSettings.Name = "btnAutoLoginSettings";
            btnAutoLoginSettings.Size = new System.Drawing.Size(86, 31);
            btnAutoLoginSettings.TabIndex = 2;
            btnAutoLoginSettings.Text = "Setup";
            btnAutoLoginSettings.UseVisualStyleBackColor = true;
            btnAutoLoginSettings.Click += btnAutoLoginSettings_Click;
            // 
            // btnBrowseSilkroadPath
            // 
            btnBrowseSilkroadPath.Location = new System.Drawing.Point(815, 40);
            btnBrowseSilkroadPath.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btnBrowseSilkroadPath.Name = "btnBrowseSilkroadPath";
            btnBrowseSilkroadPath.Size = new System.Drawing.Size(37, 28);
            btnBrowseSilkroadPath.TabIndex = 2;
            btnBrowseSilkroadPath.Text = "...";
            btnBrowseSilkroadPath.UseVisualStyleBackColor = true;
            btnBrowseSilkroadPath.Click += btnBrowseSilkroadPath_Click;
            // 
            // txtSilkroadPath
            // 
            txtSilkroadPath.Location = new System.Drawing.Point(22, 40);
            txtSilkroadPath.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            txtSilkroadPath.Name = "txtSilkroadPath";
            txtSilkroadPath.Size = new System.Drawing.Size(651, 27);
            txtSilkroadPath.TabIndex = 1;
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(checkEnableQueueLogs);
            groupBox5.Controls.Add(label3);
            groupBox5.Controls.Add(numQueueLeft);
            groupBox5.Controls.Add(checkAutoHidePendingWindow);
            groupBox5.Controls.Add(checkEnableQueueNotification);
            groupBox5.Controls.Add(btnShowPending);
            groupBox5.Location = new System.Drawing.Point(445, 371);
            groupBox5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            groupBox5.Name = "groupBox5";
            groupBox5.Padding = new System.Windows.Forms.Padding(3, 13, 3, 4);
            groupBox5.Size = new System.Drawing.Size(410, 168);
            groupBox5.TabIndex = 24;
            groupBox5.TabStop = false;
            groupBox5.Text = "Server Pending";
            // 
            // checkEnableQueueLogs
            // 
            checkEnableQueueLogs.AutoSize = true;
            checkEnableQueueLogs.Location = new System.Drawing.Point(22, 62);
            checkEnableQueueLogs.Margin = new System.Windows.Forms.Padding(0);
            checkEnableQueueLogs.Name = "checkEnableQueueLogs";
            checkEnableQueueLogs.Size = new System.Drawing.Size(212, 24);
            checkEnableQueueLogs.TabIndex = 42;
            checkEnableQueueLogs.Text = "Enable pending queue logs";
            checkEnableQueueLogs.UseVisualStyleBackColor = false;
            checkEnableQueueLogs.CheckedChanged += checkEnableQueueLogs_CheckedChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Segoe UI", 9F);
            label3.Location = new System.Drawing.Point(311, 92);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(82, 20);
            label3.TabIndex = 39;
            label3.Text = "people left";
            // 
            // numQueueLeft
            // 
            numQueueLeft.Font = new System.Drawing.Font("Segoe UI", 9.25F);
            numQueueLeft.Location = new System.Drawing.Point(246, 90);
            numQueueLeft.Margin = new System.Windows.Forms.Padding(0);
            numQueueLeft.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
            numQueueLeft.Name = "numQueueLeft";
            numQueueLeft.Size = new System.Drawing.Size(62, 28);
            numQueueLeft.TabIndex = 39;
            numQueueLeft.ValueChanged += numQueueLeft_ValueChanged;
            // 
            // checkAutoHidePendingWindow
            // 
            checkAutoHidePendingWindow.AutoSize = true;
            checkAutoHidePendingWindow.Location = new System.Drawing.Point(22, 34);
            checkAutoHidePendingWindow.Margin = new System.Windows.Forms.Padding(0);
            checkAutoHidePendingWindow.Name = "checkAutoHidePendingWindow";
            checkAutoHidePendingWindow.Size = new System.Drawing.Size(236, 24);
            checkAutoHidePendingWindow.TabIndex = 41;
            checkAutoHidePendingWindow.Text = "Auto hide the pending window";
            checkAutoHidePendingWindow.UseVisualStyleBackColor = false;
            checkAutoHidePendingWindow.CheckedChanged += checkDontShowPendingOnStartClient_CheckedChanged;
            // 
            // checkEnableQueueNotification
            // 
            checkEnableQueueNotification.AutoSize = true;
            checkEnableQueueNotification.Location = new System.Drawing.Point(22, 91);
            checkEnableQueueNotification.Margin = new System.Windows.Forms.Padding(0);
            checkEnableQueueNotification.Name = "checkEnableQueueNotification";
            checkEnableQueueNotification.Size = new System.Drawing.Size(226, 24);
            checkEnableQueueNotification.TabIndex = 40;
            checkEnableQueueNotification.Text = "Enable queue notification on ";
            checkEnableQueueNotification.UseVisualStyleBackColor = false;
            checkEnableQueueNotification.CheckedChanged += checkEnableQueueNotification_CheckedChanged;
            // 
            // btnShowPending
            // 
            btnShowPending.AutoSize = true;
            btnShowPending.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            btnShowPending.Location = new System.Drawing.Point(22, 121);
            btnShowPending.Margin = new System.Windows.Forms.Padding(0);
            btnShowPending.Name = "btnShowPending";
            btnShowPending.Size = new System.Drawing.Size(181, 30);
            btnShowPending.TabIndex = 24;
            btnShowPending.Text = "Toggle Pending Window";
            btnShowPending.UseVisualStyleBackColor = true;
            btnShowPending.Click += btnShowPending_Click;
            // 
            // Main
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            AutoScroll = true;
            AutoSize = true;
            AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            Controls.Add(groupBox5);
            Controls.Add(comboBoxClientType);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(lblVersion);
            Controls.Add(btnBrowseSilkroadPath);
            Controls.Add(txtSilkroadPath);
            Controls.Add(label1);
            Margin = new System.Windows.Forms.Padding(0);
            Name = "Main";
            Padding = new System.Windows.Forms.Padding(5);
            Size = new System.Drawing.Size(863, 643);
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox1.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numLoginDelay).EndInit();
            captchaPanel.ResumeLayout(false);
            captchaPanel.PerformLayout();
            autoLoginTopPanel.ResumeLayout(false);
            autoLoginTopPanel.PerformLayout();
            groupBox5.ResumeLayout(false);
            groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numQueueLeft).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSilkroadPath;
        private System.Windows.Forms.Button btnBrowseSilkroadPath;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboAccounts;
        private System.Windows.Forms.CheckBox checkEnableAutoLogin;
        private System.Windows.Forms.Button btnAutoLoginSettings;
        private System.Windows.Forms.TextBox txtStaticCaptcha;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox checkEnableStaticCaptcha;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboCharacter;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnGoClientless;
        private System.Windows.Forms.Button btnStartClientless;
        private System.Windows.Forms.Button btnStartClient;
        private System.Windows.Forms.CheckBox checkUseReturnScroll;
        private System.Windows.Forms.CheckBox checkStartBot;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox checkStayConnected;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnClientHideShow;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox checkBoxBotTrayMinimized;
        private System.Windows.Forms.ComboBox comboBoxClientType;
        private System.Windows.Forms.Panel captchaPanel;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel autoLoginTopPanel;
        private System.Windows.Forms.Panel separator2;
        private System.Windows.Forms.Panel separator1;
        private System.Windows.Forms.Label lblLoginDelaySeconds;
        private System.Windows.Forms.NumericUpDown numLoginDelay;
        private System.Windows.Forms.CheckBox checkEnableLoginDelay;
        private System.Windows.Forms.CheckBox checkHideClient;
        private System.Windows.Forms.RadioButton radioAutoSelectHigher;
        private System.Windows.Forms.RadioButton radioAutoSelectFirst;
        private System.Windows.Forms.CheckBox checkCharAutoSelect;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btnShowPending;
        private System.Windows.Forms.CheckBox checkEnableQueueNotification;
        private System.Windows.Forms.NumericUpDown numQueueLeft;
        private System.Windows.Forms.CheckBox checkAutoHidePendingWindow;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkEnableQueueLogs;
    }
}
