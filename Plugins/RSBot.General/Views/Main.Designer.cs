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
            label1 = new SDUI.Controls.Label();
            lblVersion = new SDUI.Controls.Label();
            comboBoxClientType = new SDUI.Controls.ComboBox();
            groupBox4 = new SDUI.Controls.GroupBox();
            label8 = new SDUI.Controls.Label();
            checkBoxBotTrayMinimized = new SDUI.Controls.CheckBox();
            groupBox3 = new SDUI.Controls.GroupBox();
            label2 = new SDUI.Controls.Label();
            checkStayConnected = new SDUI.Controls.CheckBox();
            groupBox2 = new SDUI.Controls.GroupBox();
            btnClientHideShow = new SDUI.Controls.Button();
            btnStartClient = new SDUI.Controls.Button();
            btnStartClientless = new SDUI.Controls.Button();
            btnGoClientless = new SDUI.Controls.Button();
            groupBox1 = new SDUI.Controls.GroupBox();
            panel3 = new System.Windows.Forms.Panel();
            separator1 = new SDUI.Controls.Separator();
            radioAutoSelectHigher = new SDUI.Controls.Radio();
            radioAutoSelectFirst = new SDUI.Controls.Radio();
            checkCharAutoSelect = new SDUI.Controls.CheckBox();
            checkHideClient = new SDUI.Controls.CheckBox();
            lblLoginDelaySeconds = new SDUI.Controls.Label();
            numLoginDelay = new SDUI.Controls.NumUpDown();
            checkEnableLoginDelay = new SDUI.Controls.CheckBox();
            checkStartBot = new SDUI.Controls.CheckBox();
            checkUseReturnScroll = new SDUI.Controls.CheckBox();
            captchaPanel = new System.Windows.Forms.Panel();
            separator2 = new SDUI.Controls.Separator();
            label6 = new SDUI.Controls.Label();
            label5 = new SDUI.Controls.Label();
            txtStaticCaptcha = new SDUI.Controls.TextBox();
            checkEnableStaticCaptcha = new SDUI.Controls.CheckBox();
            autoLoginTopPanel = new System.Windows.Forms.Panel();
            comboAccounts = new SDUI.Controls.ComboBox();
            label7 = new SDUI.Controls.Label();
            label4 = new SDUI.Controls.Label();
            checkEnableAutoLogin = new SDUI.Controls.CheckBox();
            comboCharacter = new SDUI.Controls.ComboBox();
            btnAutoLoginSettings = new SDUI.Controls.Button();
            btnBrowseSilkroadPath = new SDUI.Controls.Button();
            txtSilkroadPath = new SDUI.Controls.TextBox();
            groupBox5 = new SDUI.Controls.GroupBox();
            checkEnableQueueLogs = new SDUI.Controls.CheckBox();
            label3 = new SDUI.Controls.Label();
            numQueueLeft = new SDUI.Controls.NumUpDown();
            checkAutoHidePendingWindow = new SDUI.Controls.CheckBox();
            checkEnableQueueNotification = new SDUI.Controls.CheckBox();
            btnShowPending = new SDUI.Controls.Button();
            groupBoxRuSroPin = new SDUI.Controls.GroupBox();
            textRuSroPin = new SDUI.Controls.TextBox();
            lblWaitAfterDC = new SDUI.Controls.Label();
            numWaitAfterDC = new SDUI.Controls.NumUpDown();
            checkWaitAfterDC = new SDUI.Controls.CheckBox();
            groupBox4.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            panel3.SuspendLayout();
            captchaPanel.SuspendLayout();
            autoLoginTopPanel.SuspendLayout();
            groupBox5.SuspendLayout();
            groupBoxRuSroPin.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.ApplyGradient = false;
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Segoe UI", 9F);
            label1.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            label1.Gradient = new System.Drawing.Color[]
    {
    System.Drawing.Color.Gray,
    System.Drawing.Color.Black
    };
            label1.GradientAnimation = false;
            label1.Location = new System.Drawing.Point(18, 15);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(180, 20);
            label1.TabIndex = 0;
            label1.Text = "Silkroad executable path: ";
            label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblVersion
            // 
            lblVersion.ApplyGradient = false;
            lblVersion.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblVersion.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            lblVersion.Gradient = new System.Drawing.Color[]
    {
    System.Drawing.Color.Gray,
    System.Drawing.Color.Black
    };
            lblVersion.GradientAnimation = false;
            lblVersion.Location = new System.Drawing.Point(808, 15);
            lblVersion.Name = "lblVersion";
            lblVersion.Size = new System.Drawing.Size(46, 20);
            lblVersion.TabIndex = 3;
            lblVersion.Text = "v1.000";
            // 
            // comboBoxClientType
            // 
            comboBoxClientType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            comboBoxClientType.DropDownHeight = 100;
            comboBoxClientType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBoxClientType.FormattingEnabled = true;
            comboBoxClientType.IntegralHeight = false;
            comboBoxClientType.ItemHeight = 18;
            comboBoxClientType.Location = new System.Drawing.Point(680, 39);
            comboBoxClientType.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            comboBoxClientType.Name = "comboBoxClientType";
            comboBoxClientType.Radius = 5;
            comboBoxClientType.ShadowDepth = 4F;
            comboBoxClientType.Size = new System.Drawing.Size(131, 24);
            comboBoxClientType.TabIndex = 18;
            comboBoxClientType.SelectedIndexChanged += comboBoxClientType_SelectedIndexChanged;
            // 
            // groupBox4
            // 
            groupBox4.BackColor = System.Drawing.Color.Transparent;
            groupBox4.Controls.Add(label8);
            groupBox4.Controls.Add(checkBoxBotTrayMinimized);
            groupBox4.Location = new System.Drawing.Point(445, 229);
            groupBox4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            groupBox4.Name = "groupBox4";
            groupBox4.Padding = new System.Windows.Forms.Padding(3, 13, 3, 4);
            groupBox4.Radius = 10;
            groupBox4.ShadowDepth = 4;
            groupBox4.Size = new System.Drawing.Size(410, 131);
            groupBox4.TabIndex = 17;
            groupBox4.TabStop = false;
            groupBox4.Text = "Bot Settings";
            // 
            // label8
            // 
            label8.ApplyGradient = false;
            label8.AutoSize = true;
            label8.Enabled = false;
            label8.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            label8.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            label8.Gradient = new System.Drawing.Color[]
    {
    System.Drawing.Color.Gray,
    System.Drawing.Color.Black
    };
            label8.GradientAnimation = false;
            label8.Location = new System.Drawing.Point(7, 80);
            label8.Name = "label8";
            label8.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            label8.Size = new System.Drawing.Size(387, 46);
            label8.TabIndex = 22;
            label8.Text = "If activated, when the bot is minimized, the bot will \r\nautomatically switch to tray mode and continue to run there.";
            // 
            // checkBoxBotTrayMinimized
            // 
            checkBoxBotTrayMinimized.AutoSize = true;
            checkBoxBotTrayMinimized.BackColor = System.Drawing.Color.Transparent;
            checkBoxBotTrayMinimized.Depth = 0;
            checkBoxBotTrayMinimized.Location = new System.Drawing.Point(22, 40);
            checkBoxBotTrayMinimized.Margin = new System.Windows.Forms.Padding(0);
            checkBoxBotTrayMinimized.MouseLocation = new System.Drawing.Point(-1, -1);
            checkBoxBotTrayMinimized.Name = "checkBoxBotTrayMinimized";
            checkBoxBotTrayMinimized.Ripple = true;
            checkBoxBotTrayMinimized.Size = new System.Drawing.Size(308, 30);
            checkBoxBotTrayMinimized.TabIndex = 0;
            checkBoxBotTrayMinimized.Text = "Move bot to system tray when minimized";
            checkBoxBotTrayMinimized.UseVisualStyleBackColor = false;
            checkBoxBotTrayMinimized.CheckedChanged += checkBoxBotTrayMinimized_CheckedChanged;
            // 
            // groupBox3
            // 
            groupBox3.BackColor = System.Drawing.Color.Transparent;
            groupBox3.Controls.Add(label2);
            groupBox3.Controls.Add(checkStayConnected);
            groupBox3.Location = new System.Drawing.Point(445, 80);
            groupBox3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new System.Windows.Forms.Padding(3, 13, 3, 4);
            groupBox3.Radius = 10;
            groupBox3.ShadowDepth = 4;
            groupBox3.Size = new System.Drawing.Size(410, 140);
            groupBox3.TabIndex = 16;
            groupBox3.TabStop = false;
            groupBox3.Text = "Client settings";
            // 
            // label2
            // 
            label2.ApplyGradient = false;
            label2.AutoSize = true;
            label2.Enabled = false;
            label2.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            label2.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            label2.Gradient = new System.Drawing.Color[]
    {
    System.Drawing.Color.Gray,
    System.Drawing.Color.Black
    };
            label2.GradientAnimation = false;
            label2.Location = new System.Drawing.Point(7, 79);
            label2.Name = "label2";
            label2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            label2.Size = new System.Drawing.Size(407, 46);
            label2.TabIndex = 22;
            label2.Text = "If the client exits due to a crash, the bot will automatically switch\r\n to clientless mode and continue its tasks";
            // 
            // checkStayConnected
            // 
            checkStayConnected.AutoSize = true;
            checkStayConnected.BackColor = System.Drawing.Color.Transparent;
            checkStayConnected.Depth = 0;
            checkStayConnected.Location = new System.Drawing.Point(23, 36);
            checkStayConnected.Margin = new System.Windows.Forms.Padding(0);
            checkStayConnected.MouseLocation = new System.Drawing.Point(-1, -1);
            checkStayConnected.Name = "checkStayConnected";
            checkStayConnected.Ripple = true;
            checkStayConnected.Size = new System.Drawing.Size(315, 30);
            checkStayConnected.TabIndex = 17;
            checkStayConnected.Text = "Stay connected if client exits unexpectedly";
            checkStayConnected.UseVisualStyleBackColor = false;
            checkStayConnected.CheckedChanged += checkStayConnected_CheckedChanged;
            // 
            // groupBox2
            // 
            groupBox2.BackColor = System.Drawing.Color.Transparent;
            groupBox2.Controls.Add(btnClientHideShow);
            groupBox2.Controls.Add(btnStartClient);
            groupBox2.Controls.Add(btnStartClientless);
            groupBox2.Controls.Add(btnGoClientless);
            groupBox2.Location = new System.Drawing.Point(22, 80);
            groupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new System.Windows.Forms.Padding(3, 13, 3, 4);
            groupBox2.Radius = 10;
            groupBox2.ShadowDepth = 4;
            groupBox2.Size = new System.Drawing.Size(406, 140);
            groupBox2.TabIndex = 15;
            groupBox2.TabStop = false;
            groupBox2.Text = "Start game";
            // 
            // btnClientHideShow
            // 
            btnClientHideShow.Color = System.Drawing.Color.Transparent;
            btnClientHideShow.Enabled = false;
            btnClientHideShow.Location = new System.Drawing.Point(21, 91);
            btnClientHideShow.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btnClientHideShow.Name = "btnClientHideShow";
            btnClientHideShow.Radius = 6;
            btnClientHideShow.ShadowDepth = 4F;
            btnClientHideShow.Size = new System.Drawing.Size(143, 28);
            btnClientHideShow.TabIndex = 19;
            btnClientHideShow.Text = "Client Visibility";
            btnClientHideShow.UseVisualStyleBackColor = true;
            btnClientHideShow.Click += btnClientHideShow_Click;
            // 
            // btnStartClient
            // 
            btnStartClient.Color = System.Drawing.Color.Transparent;
            btnStartClient.Location = new System.Drawing.Point(21, 48);
            btnStartClient.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btnStartClient.Name = "btnStartClient";
            btnStartClient.Radius = 6;
            btnStartClient.ShadowDepth = 4F;
            btnStartClient.Size = new System.Drawing.Size(143, 28);
            btnStartClient.TabIndex = 16;
            btnStartClient.Text = "Start Client";
            btnStartClient.UseVisualStyleBackColor = true;
            btnStartClient.Click += btnStartClient_Click;
            // 
            // btnStartClientless
            // 
            btnStartClientless.Color = System.Drawing.Color.Transparent;
            btnStartClientless.Location = new System.Drawing.Point(242, 48);
            btnStartClientless.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btnStartClientless.Name = "btnStartClientless";
            btnStartClientless.Radius = 6;
            btnStartClientless.ShadowDepth = 4F;
            btnStartClientless.Size = new System.Drawing.Size(143, 28);
            btnStartClientless.TabIndex = 18;
            btnStartClientless.Text = "Start Clientless";
            btnStartClientless.UseVisualStyleBackColor = false;
            btnStartClientless.Click += btnStartClientless_Click;
            // 
            // btnGoClientless
            // 
            btnGoClientless.Color = System.Drawing.Color.Transparent;
            btnGoClientless.Enabled = false;
            btnGoClientless.Location = new System.Drawing.Point(242, 91);
            btnGoClientless.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btnGoClientless.Name = "btnGoClientless";
            btnGoClientless.Radius = 6;
            btnGoClientless.ShadowDepth = 4F;
            btnGoClientless.Size = new System.Drawing.Size(143, 28);
            btnGoClientless.TabIndex = 17;
            btnGoClientless.Text = "Go Clientless";
            btnGoClientless.UseVisualStyleBackColor = true;
            btnGoClientless.Click += btnGoClientless_Click;
            // 
            // groupBox1
            // 
            groupBox1.AutoSize = true;
            groupBox1.BackColor = System.Drawing.Color.Transparent;
            groupBox1.Controls.Add(panel3);
            groupBox1.Controls.Add(captchaPanel);
            groupBox1.Controls.Add(autoLoginTopPanel);
            groupBox1.Location = new System.Drawing.Point(22, 229);
            groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new System.Windows.Forms.Padding(3, 13, 3, 4);
            groupBox1.Radius = 10;
            groupBox1.ShadowDepth = 4;
            groupBox1.Size = new System.Drawing.Size(417, 457);
            groupBox1.TabIndex = 14;
            groupBox1.TabStop = false;
            groupBox1.Text = "Automated login";
            // 
            // panel3
            // 
            panel3.Controls.Add(lblWaitAfterDC);
            panel3.Controls.Add(numWaitAfterDC);
            panel3.Controls.Add(checkWaitAfterDC);
            panel3.Controls.Add(separator1);
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
            panel3.Location = new System.Drawing.Point(3, 269);
            panel3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            panel3.Name = "panel3";
            panel3.Size = new System.Drawing.Size(411, 184);
            panel3.TabIndex = 1;
            // 
            // separator1
            // 
            separator1.Dock = System.Windows.Forms.DockStyle.Top;
            separator1.IsVertical = false;
            separator1.Location = new System.Drawing.Point(0, 0);
            separator1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            separator1.Name = "separator1";
            separator1.Size = new System.Drawing.Size(411, 3);
            separator1.TabIndex = 19;
            // 
            // radioAutoSelectHigher
            // 
            radioAutoSelectHigher.AutoSize = true;
            radioAutoSelectHigher.Enabled = false;
            radioAutoSelectHigher.Font = new System.Drawing.Font("Segoe UI", 9F);
            radioAutoSelectHigher.Location = new System.Drawing.Point(226, 151);
            radioAutoSelectHigher.Margin = new System.Windows.Forms.Padding(0);
            radioAutoSelectHigher.Name = "radioAutoSelectHigher";
            radioAutoSelectHigher.Ripple = true;
            radioAutoSelectHigher.Size = new System.Drawing.Size(169, 30);
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
            radioAutoSelectFirst.Location = new System.Drawing.Point(75, 151);
            radioAutoSelectFirst.Margin = new System.Windows.Forms.Padding(0);
            radioAutoSelectFirst.Name = "radioAutoSelectFirst";
            radioAutoSelectFirst.Ripple = true;
            radioAutoSelectFirst.Size = new System.Drawing.Size(151, 30);
            radioAutoSelectFirst.TabIndex = 37;
            radioAutoSelectFirst.TabStop = true;
            radioAutoSelectFirst.Text = "Auto Select (First)";
            radioAutoSelectFirst.UseVisualStyleBackColor = true;
            radioAutoSelectFirst.CheckedChanged += radioAutoSelectFirst_CheckedChanged;
            // 
            // checkCharAutoSelect
            // 
            checkCharAutoSelect.AutoSize = true;
            checkCharAutoSelect.BackColor = System.Drawing.Color.Transparent;
            checkCharAutoSelect.Depth = 0;
            checkCharAutoSelect.Enabled = false;
            checkCharAutoSelect.Location = new System.Drawing.Point(75, 120);
            checkCharAutoSelect.Margin = new System.Windows.Forms.Padding(0);
            checkCharAutoSelect.MouseLocation = new System.Drawing.Point(-1, -1);
            checkCharAutoSelect.Name = "checkCharAutoSelect";
            checkCharAutoSelect.Ripple = true;
            checkCharAutoSelect.Size = new System.Drawing.Size(145, 30);
            checkCharAutoSelect.TabIndex = 36;
            checkCharAutoSelect.Text = "Auto Char Select";
            checkCharAutoSelect.UseVisualStyleBackColor = false;
            checkCharAutoSelect.CheckedChanged += checkCharAutoSelect_CheckedChanged;
            // 
            // checkHideClient
            // 
            checkHideClient.AutoSize = true;
            checkHideClient.BackColor = System.Drawing.Color.Transparent;
            checkHideClient.Depth = 0;
            checkHideClient.Location = new System.Drawing.Point(226, 120);
            checkHideClient.Margin = new System.Windows.Forms.Padding(0);
            checkHideClient.MouseLocation = new System.Drawing.Point(-1, -1);
            checkHideClient.Name = "checkHideClient";
            checkHideClient.Ripple = true;
            checkHideClient.Size = new System.Drawing.Size(145, 30);
            checkHideClient.TabIndex = 31;
            checkHideClient.Text = "Auto Hide Client";
            checkHideClient.UseVisualStyleBackColor = false;
            checkHideClient.CheckedChanged += checkHideClient_CheckedChanged;
            // 
            // lblLoginDelaySeconds
            // 
            lblLoginDelaySeconds.ApplyGradient = false;
            lblLoginDelaySeconds.AutoSize = true;
            lblLoginDelaySeconds.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            lblLoginDelaySeconds.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            lblLoginDelaySeconds.Gradient = new System.Drawing.Color[]
    {
    System.Drawing.Color.Gray,
    System.Drawing.Color.Black
    };
            lblLoginDelaySeconds.GradientAnimation = false;
            lblLoginDelaySeconds.Location = new System.Drawing.Point(325, 21);
            lblLoginDelaySeconds.Name = "lblLoginDelaySeconds";
            lblLoginDelaySeconds.Size = new System.Drawing.Size(58, 19);
            lblLoginDelaySeconds.TabIndex = 22;
            lblLoginDelaySeconds.Text = "seconds";
            // 
            // numLoginDelay
            // 
            numLoginDelay.BackColor = System.Drawing.Color.Transparent;
            numLoginDelay.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            numLoginDelay.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            numLoginDelay.Location = new System.Drawing.Point(226, 15);
            numLoginDelay.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            numLoginDelay.Maximum = new decimal(new int[] { 60, 0, 0, 0 });
            numLoginDelay.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numLoginDelay.MinimumSize = new System.Drawing.Size(91, 33);
            numLoginDelay.Name = "numLoginDelay";
            numLoginDelay.Size = new System.Drawing.Size(91, 33);
            numLoginDelay.TabIndex = 30;
            numLoginDelay.Value = new decimal(new int[] { 3, 0, 0, 0 });
            numLoginDelay.ValueChanged += numLoginDelay_ValueChanged;
            // 
            // checkEnableLoginDelay
            // 
            checkEnableLoginDelay.AutoSize = true;
            checkEnableLoginDelay.BackColor = System.Drawing.Color.Transparent;
            checkEnableLoginDelay.Depth = 0;
            checkEnableLoginDelay.Location = new System.Drawing.Point(75, 13);
            checkEnableLoginDelay.Margin = new System.Windows.Forms.Padding(0);
            checkEnableLoginDelay.MouseLocation = new System.Drawing.Point(-1, -1);
            checkEnableLoginDelay.Name = "checkEnableLoginDelay";
            checkEnableLoginDelay.Ripple = true;
            checkEnableLoginDelay.Size = new System.Drawing.Size(158, 30);
            checkEnableLoginDelay.TabIndex = 25;
            checkEnableLoginDelay.Text = "Enable login delay";
            checkEnableLoginDelay.UseVisualStyleBackColor = false;
            checkEnableLoginDelay.CheckedChanged += checkEnableLoginDelay_CheckedChanged;
            // 
            // checkStartBot
            // 
            checkStartBot.AutoSize = true;
            checkStartBot.BackColor = System.Drawing.Color.Transparent;
            checkStartBot.Depth = 0;
            checkStartBot.Location = new System.Drawing.Point(75, 88);
            checkStartBot.Margin = new System.Windows.Forms.Padding(0);
            checkStartBot.MouseLocation = new System.Drawing.Point(-1, -1);
            checkStartBot.Name = "checkStartBot";
            checkStartBot.Ripple = true;
            checkStartBot.Size = new System.Drawing.Size(127, 30);
            checkStartBot.TabIndex = 24;
            checkStartBot.Text = "Auto start bot";
            checkStartBot.UseVisualStyleBackColor = false;
            checkStartBot.CheckedChanged += checkAutoStartBot_CheckedChanged;
            // 
            // checkUseReturnScroll
            // 
            checkUseReturnScroll.AutoSize = true;
            checkUseReturnScroll.BackColor = System.Drawing.Color.Transparent;
            checkUseReturnScroll.Depth = 0;
            checkUseReturnScroll.Location = new System.Drawing.Point(226, 88);
            checkUseReturnScroll.Margin = new System.Windows.Forms.Padding(0);
            checkUseReturnScroll.MouseLocation = new System.Drawing.Point(-1, -1);
            checkUseReturnScroll.Name = "checkUseReturnScroll";
            checkUseReturnScroll.Ripple = true;
            checkUseReturnScroll.Size = new System.Drawing.Size(141, 30);
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
            captchaPanel.Location = new System.Drawing.Point(3, 158);
            captchaPanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            captchaPanel.Name = "captchaPanel";
            captchaPanel.Size = new System.Drawing.Size(411, 111);
            captchaPanel.TabIndex = 0;
            captchaPanel.Visible = false;
            // 
            // separator2
            // 
            separator2.Dock = System.Windows.Forms.DockStyle.Top;
            separator2.IsVertical = false;
            separator2.Location = new System.Drawing.Point(0, 0);
            separator2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            separator2.Name = "separator2";
            separator2.Size = new System.Drawing.Size(411, 3);
            separator2.TabIndex = 29;
            // 
            // label6
            // 
            label6.ApplyGradient = false;
            label6.AutoSize = true;
            label6.Enabled = false;
            label6.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            label6.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            label6.Gradient = new System.Drawing.Color[]
    {
    System.Drawing.Color.Gray,
    System.Drawing.Color.Black
    };
            label6.GradientAnimation = false;
            label6.Location = new System.Drawing.Point(72, 81);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(309, 19);
            label6.TabIndex = 21;
            label6.Text = "Please use this only if the captcha never changes.";
            // 
            // label5
            // 
            label5.ApplyGradient = false;
            label5.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            label5.Gradient = new System.Drawing.Color[]
    {
    System.Drawing.Color.Gray,
    System.Drawing.Color.Black
    };
            label5.GradientAnimation = false;
            label5.Location = new System.Drawing.Point(10, 19);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(66, 24);
            label5.TabIndex = 18;
            label5.Text = "Captcha:";
            // 
            // txtStaticCaptcha
            // 
            txtStaticCaptcha.Location = new System.Drawing.Point(75, 15);
            txtStaticCaptcha.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            txtStaticCaptcha.MaxLength = 32767;
            txtStaticCaptcha.MultiLine = false;
            txtStaticCaptcha.Name = "txtStaticCaptcha";
            txtStaticCaptcha.PassFocusShow = false;
            txtStaticCaptcha.Radius = 2;
            txtStaticCaptcha.Size = new System.Drawing.Size(306, 25);
            txtStaticCaptcha.TabIndex = 3;
            txtStaticCaptcha.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            txtStaticCaptcha.UseSystemPasswordChar = false;
            txtStaticCaptcha.TextChanged += txtStaticCaptcha_TextChanged;
            // 
            // checkEnableStaticCaptcha
            // 
            checkEnableStaticCaptcha.AutoSize = true;
            checkEnableStaticCaptcha.BackColor = System.Drawing.Color.Transparent;
            checkEnableStaticCaptcha.Depth = 0;
            checkEnableStaticCaptcha.Location = new System.Drawing.Point(75, 47);
            checkEnableStaticCaptcha.Margin = new System.Windows.Forms.Padding(0);
            checkEnableStaticCaptcha.MouseLocation = new System.Drawing.Point(-1, -1);
            checkEnableStaticCaptcha.Name = "checkEnableStaticCaptcha";
            checkEnableStaticCaptcha.Ripple = true;
            checkEnableStaticCaptcha.Size = new System.Drawing.Size(213, 30);
            checkEnableStaticCaptcha.TabIndex = 4;
            checkEnableStaticCaptcha.Text = "Enable static captcha solve";
            checkEnableStaticCaptcha.UseVisualStyleBackColor = false;
            checkEnableStaticCaptcha.CheckedChanged += checkEnableStaticCaptcha_CheckedChanged;
            // 
            // autoLoginTopPanel
            // 
            autoLoginTopPanel.BackColor = System.Drawing.Color.Transparent;
            autoLoginTopPanel.Controls.Add(comboAccounts);
            autoLoginTopPanel.Controls.Add(label7);
            autoLoginTopPanel.Controls.Add(label4);
            autoLoginTopPanel.Controls.Add(checkEnableAutoLogin);
            autoLoginTopPanel.Controls.Add(comboCharacter);
            autoLoginTopPanel.Controls.Add(btnAutoLoginSettings);
            autoLoginTopPanel.Dock = System.Windows.Forms.DockStyle.Top;
            autoLoginTopPanel.Location = new System.Drawing.Point(3, 33);
            autoLoginTopPanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            autoLoginTopPanel.Name = "autoLoginTopPanel";
            autoLoginTopPanel.Size = new System.Drawing.Size(411, 125);
            autoLoginTopPanel.TabIndex = 28;
            // 
            // comboAccounts
            // 
            comboAccounts.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            comboAccounts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboAccounts.FormattingEnabled = true;
            comboAccounts.ItemHeight = 18;
            comboAccounts.Location = new System.Drawing.Point(75, 13);
            comboAccounts.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            comboAccounts.Name = "comboAccounts";
            comboAccounts.Radius = 5;
            comboAccounts.ShadowDepth = 4F;
            comboAccounts.Size = new System.Drawing.Size(306, 24);
            comboAccounts.TabIndex = 0;
            comboAccounts.SelectedIndexChanged += comboAccounts_SelectedIndexChanged;
            // 
            // label7
            // 
            label7.ApplyGradient = false;
            label7.AutoSize = true;
            label7.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            label7.Gradient = new System.Drawing.Color[]
    {
    System.Drawing.Color.Gray,
    System.Drawing.Color.Black
    };
            label7.GradientAnimation = false;
            label7.Location = new System.Drawing.Point(21, 49);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(52, 20);
            label7.TabIndex = 23;
            label7.Text = "Player:";
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
            label4.Location = new System.Drawing.Point(10, 19);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(66, 20);
            label4.TabIndex = 0;
            label4.Text = "Account:";
            // 
            // checkEnableAutoLogin
            // 
            checkEnableAutoLogin.AutoSize = true;
            checkEnableAutoLogin.BackColor = System.Drawing.Color.Transparent;
            checkEnableAutoLogin.Depth = 0;
            checkEnableAutoLogin.Location = new System.Drawing.Point(75, 80);
            checkEnableAutoLogin.Margin = new System.Windows.Forms.Padding(0);
            checkEnableAutoLogin.MouseLocation = new System.Drawing.Point(-1, -1);
            checkEnableAutoLogin.Name = "checkEnableAutoLogin";
            checkEnableAutoLogin.Ripple = true;
            checkEnableAutoLogin.Size = new System.Drawing.Size(195, 30);
            checkEnableAutoLogin.TabIndex = 1;
            checkEnableAutoLogin.Text = "Enable automated login";
            checkEnableAutoLogin.UseVisualStyleBackColor = false;
            checkEnableAutoLogin.CheckedChanged += checkEnableAutoLogin_CheckedChanged;
            // 
            // comboCharacter
            // 
            comboCharacter.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            comboCharacter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboCharacter.FormattingEnabled = true;
            comboCharacter.ItemHeight = 18;
            comboCharacter.Items.AddRange(new object[] { "Not Selected" });
            comboCharacter.Location = new System.Drawing.Point(75, 48);
            comboCharacter.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            comboCharacter.Name = "comboCharacter";
            comboCharacter.Radius = 5;
            comboCharacter.ShadowDepth = 4F;
            comboCharacter.Size = new System.Drawing.Size(306, 24);
            comboCharacter.TabIndex = 22;
            comboCharacter.SelectedIndexChanged += comboCharacter_SelectedIndexChanged;
            // 
            // btnAutoLoginSettings
            // 
            btnAutoLoginSettings.Color = System.Drawing.Color.Transparent;
            btnAutoLoginSettings.Location = new System.Drawing.Point(296, 87);
            btnAutoLoginSettings.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btnAutoLoginSettings.Name = "btnAutoLoginSettings";
            btnAutoLoginSettings.Radius = 6;
            btnAutoLoginSettings.ShadowDepth = 4F;
            btnAutoLoginSettings.Size = new System.Drawing.Size(86, 31);
            btnAutoLoginSettings.TabIndex = 2;
            btnAutoLoginSettings.Text = "Setup";
            btnAutoLoginSettings.UseVisualStyleBackColor = true;
            btnAutoLoginSettings.Click += btnAutoLoginSettings_Click;
            // 
            // btnBrowseSilkroadPath
            // 
            btnBrowseSilkroadPath.Color = System.Drawing.Color.Transparent;
            btnBrowseSilkroadPath.Location = new System.Drawing.Point(817, 40);
            btnBrowseSilkroadPath.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btnBrowseSilkroadPath.Name = "btnBrowseSilkroadPath";
            btnBrowseSilkroadPath.Radius = 6;
            btnBrowseSilkroadPath.ShadowDepth = 4F;
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
            txtSilkroadPath.MaxLength = 32767;
            txtSilkroadPath.MultiLine = false;
            txtSilkroadPath.Name = "txtSilkroadPath";
            txtSilkroadPath.PassFocusShow = false;
            txtSilkroadPath.Radius = 2;
            txtSilkroadPath.Size = new System.Drawing.Size(651, 25);
            txtSilkroadPath.TabIndex = 1;
            txtSilkroadPath.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            txtSilkroadPath.UseSystemPasswordChar = false;
            // 
            // groupBox5
            // 
            groupBox5.BackColor = System.Drawing.Color.Transparent;
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
            groupBox5.Radius = 10;
            groupBox5.ShadowDepth = 4;
            groupBox5.Size = new System.Drawing.Size(410, 197);
            groupBox5.TabIndex = 24;
            groupBox5.TabStop = false;
            groupBox5.Text = "Server Pending";
            // 
            // checkEnableQueueLogs
            // 
            checkEnableQueueLogs.AutoSize = true;
            checkEnableQueueLogs.BackColor = System.Drawing.Color.Transparent;
            checkEnableQueueLogs.Depth = 0;
            checkEnableQueueLogs.Location = new System.Drawing.Point(23, 71);
            checkEnableQueueLogs.Margin = new System.Windows.Forms.Padding(0);
            checkEnableQueueLogs.MouseLocation = new System.Drawing.Point(-1, -1);
            checkEnableQueueLogs.Name = "checkEnableQueueLogs";
            checkEnableQueueLogs.Ripple = true;
            checkEnableQueueLogs.Size = new System.Drawing.Size(216, 30);
            checkEnableQueueLogs.TabIndex = 42;
            checkEnableQueueLogs.Text = "Enable pending queue logs";
            checkEnableQueueLogs.UseVisualStyleBackColor = false;
            checkEnableQueueLogs.CheckedChanged += checkEnableQueueLogs_CheckedChanged;
            // 
            // label3
            // 
            label3.ApplyGradient = false;
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Segoe UI", 9F);
            label3.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            label3.Gradient = new System.Drawing.Color[]
    {
    System.Drawing.Color.Gray,
    System.Drawing.Color.Black
    };
            label3.GradientAnimation = false;
            label3.Location = new System.Drawing.Point(334, 108);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(82, 20);
            label3.TabIndex = 39;
            label3.Text = "people left";
            // 
            // numQueueLeft
            // 
            numQueueLeft.BackColor = System.Drawing.Color.Transparent;
            numQueueLeft.Font = new System.Drawing.Font("Segoe UI", 9.25F);
            numQueueLeft.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            numQueueLeft.Location = new System.Drawing.Point(235, 103);
            numQueueLeft.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            numQueueLeft.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
            numQueueLeft.Minimum = new decimal(new int[] { 0, 0, 0, 0 });
            numQueueLeft.MinimumSize = new System.Drawing.Size(91, 33);
            numQueueLeft.Name = "numQueueLeft";
            numQueueLeft.Size = new System.Drawing.Size(91, 33);
            numQueueLeft.TabIndex = 39;
            numQueueLeft.Value = new decimal(new int[] { 0, 0, 0, 0 });
            numQueueLeft.ValueChanged += numQueueLeft_ValueChanged;
            // 
            // checkAutoHidePendingWindow
            // 
            checkAutoHidePendingWindow.AutoSize = true;
            checkAutoHidePendingWindow.BackColor = System.Drawing.Color.Transparent;
            checkAutoHidePendingWindow.Depth = 0;
            checkAutoHidePendingWindow.Location = new System.Drawing.Point(23, 43);
            checkAutoHidePendingWindow.Margin = new System.Windows.Forms.Padding(0);
            checkAutoHidePendingWindow.MouseLocation = new System.Drawing.Point(-1, -1);
            checkAutoHidePendingWindow.Name = "checkAutoHidePendingWindow";
            checkAutoHidePendingWindow.Ripple = true;
            checkAutoHidePendingWindow.Size = new System.Drawing.Size(240, 30);
            checkAutoHidePendingWindow.TabIndex = 41;
            checkAutoHidePendingWindow.Text = "Auto hide the pending window";
            checkAutoHidePendingWindow.UseVisualStyleBackColor = false;
            checkAutoHidePendingWindow.CheckedChanged += checkDontShowPendingOnStartClient_CheckedChanged;
            // 
            // checkEnableQueueNotification
            // 
            checkEnableQueueNotification.AutoSize = true;
            checkEnableQueueNotification.BackColor = System.Drawing.Color.Transparent;
            checkEnableQueueNotification.Depth = 0;
            checkEnableQueueNotification.Location = new System.Drawing.Point(23, 100);
            checkEnableQueueNotification.Margin = new System.Windows.Forms.Padding(0);
            checkEnableQueueNotification.MouseLocation = new System.Drawing.Point(-1, -1);
            checkEnableQueueNotification.Name = "checkEnableQueueNotification";
            checkEnableQueueNotification.Ripple = true;
            checkEnableQueueNotification.Size = new System.Drawing.Size(230, 30);
            checkEnableQueueNotification.TabIndex = 40;
            checkEnableQueueNotification.Text = "Enable queue notification on ";
            checkEnableQueueNotification.UseVisualStyleBackColor = false;
            checkEnableQueueNotification.CheckedChanged += checkEnableQueueNotification_CheckedChanged;
            // 
            // btnShowPending
            // 
            btnShowPending.AutoSize = true;
            btnShowPending.Color = System.Drawing.Color.Transparent;
            btnShowPending.Location = new System.Drawing.Point(33, 149);
            btnShowPending.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btnShowPending.Name = "btnShowPending";
            btnShowPending.Radius = 6;
            btnShowPending.ShadowDepth = 4F;
            btnShowPending.Size = new System.Drawing.Size(187, 23);
            btnShowPending.TabIndex = 24;
            btnShowPending.Text = "Toggle Pending Window";
            btnShowPending.UseVisualStyleBackColor = true;
            btnShowPending.Click += btnShowPending_Click;
            // 
            // groupBoxRuSroPin
            // 
            groupBoxRuSroPin.BackColor = System.Drawing.Color.Transparent;
            groupBoxRuSroPin.Controls.Add(textRuSroPin);
            groupBoxRuSroPin.Location = new System.Drawing.Point(451, 576);
            groupBoxRuSroPin.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            groupBoxRuSroPin.Name = "groupBoxRuSroPin";
            groupBoxRuSroPin.Padding = new System.Windows.Forms.Padding(3, 11, 3, 4);
            groupBoxRuSroPin.Radius = 10;
            groupBoxRuSroPin.ShadowDepth = 4;
            groupBoxRuSroPin.Size = new System.Drawing.Size(403, 80);
            groupBoxRuSroPin.TabIndex = 30;
            groupBoxRuSroPin.TabStop = false;
            groupBoxRuSroPin.Text = "Email Pin";
            // 
            // textRuSroPin
            // 
            textRuSroPin.Font = new System.Drawing.Font("Segoe UI", 12F);
            textRuSroPin.Location = new System.Drawing.Point(26, 40);
            textRuSroPin.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            textRuSroPin.MaxLength = 32767;
            textRuSroPin.MultiLine = false;
            textRuSroPin.Name = "textRuSroPin";
            textRuSroPin.PassFocusShow = false;
            textRuSroPin.Radius = 2;
            textRuSroPin.Size = new System.Drawing.Size(321, 32);
            textRuSroPin.TabIndex = 1;
            textRuSroPin.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            textRuSroPin.UseSystemPasswordChar = false;
            textRuSroPin.TextChanged += textRuSroPin_TextChanged;
            // 
            // lblWaitAfterDC
            // 
            lblWaitAfterDC.ApplyGradient = false;
            lblWaitAfterDC.AutoSize = true;
            lblWaitAfterDC.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            lblWaitAfterDC.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            lblWaitAfterDC.Gradient = new System.Drawing.Color[]
    {
    System.Drawing.Color.Gray,
    System.Drawing.Color.Black
    };
            lblWaitAfterDC.GradientAnimation = false;
            lblWaitAfterDC.Location = new System.Drawing.Point(325, 60);
            lblWaitAfterDC.Name = "lblWaitAfterDC";
            lblWaitAfterDC.Size = new System.Drawing.Size(58, 19);
            lblWaitAfterDC.TabIndex = 39;
            lblWaitAfterDC.Text = "minutes";
            // 
            // numWaitAfterDC
            // 
            numWaitAfterDC.BackColor = System.Drawing.Color.Transparent;
            numWaitAfterDC.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            numWaitAfterDC.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            numWaitAfterDC.Location = new System.Drawing.Point(226, 54);
            numWaitAfterDC.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            numWaitAfterDC.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            numWaitAfterDC.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numWaitAfterDC.MinimumSize = new System.Drawing.Size(91, 33);
            numWaitAfterDC.Name = "numWaitAfterDC";
            numWaitAfterDC.Size = new System.Drawing.Size(91, 33);
            numWaitAfterDC.TabIndex = 41;
            numWaitAfterDC.Value = new decimal(new int[] { 3, 0, 0, 0 });
            numWaitAfterDC.ValueChanged += numWaitAfterDC_ValueChanged;
            // 
            // checkWaitAfterDC
            // 
            checkWaitAfterDC.AutoSize = true;
            checkWaitAfterDC.BackColor = System.Drawing.Color.Transparent;
            checkWaitAfterDC.Depth = 0;
            checkWaitAfterDC.Location = new System.Drawing.Point(75, 52);
            checkWaitAfterDC.Margin = new System.Windows.Forms.Padding(0);
            checkWaitAfterDC.MouseLocation = new System.Drawing.Point(-1, -1);
            checkWaitAfterDC.Name = "checkWaitAfterDC";
            checkWaitAfterDC.Ripple = true;
            checkWaitAfterDC.Size = new System.Drawing.Size(124, 30);
            checkWaitAfterDC.TabIndex = 40;
            checkWaitAfterDC.Text = "Wait after DC";
            checkWaitAfterDC.UseVisualStyleBackColor = false;
            checkWaitAfterDC.CheckedChanged += checkWaitAfterDC_CheckedChanged;
            // 
            // Main
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoScroll = true;
            Controls.Add(groupBoxRuSroPin);
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
            Font = new System.Drawing.Font("Segoe UI", 9F);
            Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            Name = "Main";
            Size = new System.Drawing.Size(832, 619);
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            captchaPanel.ResumeLayout(false);
            captchaPanel.PerformLayout();
            autoLoginTopPanel.ResumeLayout(false);
            autoLoginTopPanel.PerformLayout();
            groupBox5.ResumeLayout(false);
            groupBox5.PerformLayout();
            groupBoxRuSroPin.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
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
        private SDUI.Controls.GroupBox groupBoxRuSroPin;
        private SDUI.Controls.TextBox textRuSroPin;
        private SDUI.Controls.Label lblWaitAfterDC;
        private SDUI.Controls.NumUpDown numWaitAfterDC;
        private SDUI.Controls.CheckBox checkWaitAfterDC;
    }
}
