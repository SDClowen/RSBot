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
            separator1 = new SDUI.Controls.Separator();
            panel3 = new System.Windows.Forms.Panel();
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
            groupBox4.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            panel3.SuspendLayout();
            captchaPanel.SuspendLayout();
            autoLoginTopPanel.SuspendLayout();
            groupBox5.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.ApplyGradient = false;
            label1.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label1.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            label1.Gradient = new System.Drawing.Color[]
    {
    System.Drawing.Color.Gray,
    System.Drawing.Color.Black
    };
            label1.GradientAnimation = false;
            label1.Location = new System.Drawing.Point(16, 11);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(140, 15);
            label1.TabIndex = 0;
            label1.Text = "Silkroad executable path:";
            // 
            // lblVersion
            // 
            lblVersion.ApplyGradient = false;
            lblVersion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lblVersion.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            lblVersion.Gradient = new System.Drawing.Color[]
    {
    System.Drawing.Color.Gray,
    System.Drawing.Color.Black
    };
            lblVersion.GradientAnimation = false;
            lblVersion.Location = new System.Drawing.Point(707, 11);
            lblVersion.Name = "lblVersion";
            lblVersion.Size = new System.Drawing.Size(40, 15);
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
            comboBoxClientType.ItemHeight = 17;
            comboBoxClientType.Location = new System.Drawing.Point(595, 29);
            comboBoxClientType.Name = "comboBoxClientType";
            comboBoxClientType.Radius = 5;
            comboBoxClientType.ShadowDepth = 4F;
            comboBoxClientType.Size = new System.Drawing.Size(115, 23);
            comboBoxClientType.TabIndex = 18;
            comboBoxClientType.SelectedIndexChanged += comboBoxClientType_SelectedIndexChanged;
            // 
            // groupBox4
            // 
            groupBox4.BackColor = System.Drawing.Color.Transparent;
            groupBox4.Controls.Add(label8);
            groupBox4.Controls.Add(checkBoxBotTrayMinimized);
            groupBox4.Location = new System.Drawing.Point(389, 172);
            groupBox4.Name = "groupBox4";
            groupBox4.Padding = new System.Windows.Forms.Padding(3, 10, 3, 3);
            groupBox4.Radius = 10;
            groupBox4.ShadowDepth = 4;
            groupBox4.Size = new System.Drawing.Size(359, 98);
            groupBox4.TabIndex = 17;
            groupBox4.TabStop = false;
            groupBox4.Text = "Bot Settings";
            // 
            // label8
            // 
            label8.ApplyGradient = false;
            label8.Enabled = false;
            label8.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label8.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            label8.Gradient = new System.Drawing.Color[]
    {
    System.Drawing.Color.Gray,
    System.Drawing.Color.Black
    };
            label8.GradientAnimation = false;
            label8.Location = new System.Drawing.Point(6, 60);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(347, 35);
            label8.TabIndex = 22;
            label8.Text = "If activated, when the bot is minimized, the bot will \r\nautomatically switch to tray mode and continue to run there.";
            // 
            // checkBoxBotTrayMinimized
            // 
            checkBoxBotTrayMinimized.AutoSize = true;
            checkBoxBotTrayMinimized.BackColor = System.Drawing.Color.Transparent;
            checkBoxBotTrayMinimized.Depth = 0;
            checkBoxBotTrayMinimized.Location = new System.Drawing.Point(19, 31);
            checkBoxBotTrayMinimized.Margin = new System.Windows.Forms.Padding(0);
            checkBoxBotTrayMinimized.MouseLocation = new System.Drawing.Point(-1, -1);
            checkBoxBotTrayMinimized.Name = "checkBoxBotTrayMinimized";
            checkBoxBotTrayMinimized.Ripple = true;
            checkBoxBotTrayMinimized.Size = new System.Drawing.Size(306, 30);
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
            groupBox3.Location = new System.Drawing.Point(389, 60);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new System.Windows.Forms.Padding(3, 10, 3, 3);
            groupBox3.Radius = 10;
            groupBox3.ShadowDepth = 4;
            groupBox3.Size = new System.Drawing.Size(359, 105);
            groupBox3.TabIndex = 16;
            groupBox3.TabStop = false;
            groupBox3.Text = "Client settings";
            // 
            // label2
            // 
            label2.ApplyGradient = false;
            label2.Enabled = false;
            label2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label2.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            label2.Gradient = new System.Drawing.Color[]
    {
    System.Drawing.Color.Gray,
    System.Drawing.Color.Black
    };
            label2.GradientAnimation = false;
            label2.Location = new System.Drawing.Point(6, 59);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(347, 37);
            label2.TabIndex = 22;
            label2.Text = "If the client exits due to a crash, the bot will automatically switch\r\n to clientless mode and continue its tasks";
            // 
            // checkStayConnected
            // 
            checkStayConnected.AutoSize = true;
            checkStayConnected.BackColor = System.Drawing.Color.Transparent;
            checkStayConnected.Depth = 0;
            checkStayConnected.Location = new System.Drawing.Point(20, 28);
            checkStayConnected.Margin = new System.Windows.Forms.Padding(0);
            checkStayConnected.MouseLocation = new System.Drawing.Point(-1, -1);
            checkStayConnected.Name = "checkStayConnected";
            checkStayConnected.Ripple = true;
            checkStayConnected.Size = new System.Drawing.Size(313, 30);
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
            groupBox2.Location = new System.Drawing.Point(19, 60);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new System.Windows.Forms.Padding(3, 10, 3, 3);
            groupBox2.Radius = 10;
            groupBox2.ShadowDepth = 4;
            groupBox2.Size = new System.Drawing.Size(355, 105);
            groupBox2.TabIndex = 15;
            groupBox2.TabStop = false;
            groupBox2.Text = "Start game";
            // 
            // btnClientHideShow
            // 
            btnClientHideShow.Color = System.Drawing.Color.Transparent;
            btnClientHideShow.Enabled = false;
            btnClientHideShow.Location = new System.Drawing.Point(18, 68);
            btnClientHideShow.Name = "btnClientHideShow";
            btnClientHideShow.Radius = 6;
            btnClientHideShow.ShadowDepth = 4F;
            btnClientHideShow.Size = new System.Drawing.Size(125, 21);
            btnClientHideShow.TabIndex = 19;
            btnClientHideShow.Text = "Client Visibility";
            btnClientHideShow.UseVisualStyleBackColor = true;
            btnClientHideShow.Click += btnClientHideShow_Click;
            // 
            // btnStartClient
            // 
            btnStartClient.Color = System.Drawing.Color.Transparent;
            btnStartClient.Location = new System.Drawing.Point(18, 36);
            btnStartClient.Name = "btnStartClient";
            btnStartClient.Radius = 6;
            btnStartClient.ShadowDepth = 4F;
            btnStartClient.Size = new System.Drawing.Size(125, 21);
            btnStartClient.TabIndex = 16;
            btnStartClient.Text = "Start Client";
            btnStartClient.UseVisualStyleBackColor = true;
            btnStartClient.Click += btnStartClient_Click;
            // 
            // btnStartClientless
            // 
            btnStartClientless.Color = System.Drawing.Color.Transparent;
            btnStartClientless.Location = new System.Drawing.Point(212, 36);
            btnStartClientless.Name = "btnStartClientless";
            btnStartClientless.Radius = 6;
            btnStartClientless.ShadowDepth = 4F;
            btnStartClientless.Size = new System.Drawing.Size(125, 21);
            btnStartClientless.TabIndex = 18;
            btnStartClientless.Text = "Start Clientless";
            btnStartClientless.UseVisualStyleBackColor = false;
            btnStartClientless.Click += btnStartClientless_Click;
            // 
            // btnGoClientless
            // 
            btnGoClientless.Color = System.Drawing.Color.Transparent;
            btnGoClientless.Enabled = false;
            btnGoClientless.Location = new System.Drawing.Point(212, 68);
            btnGoClientless.Name = "btnGoClientless";
            btnGoClientless.Radius = 6;
            btnGoClientless.ShadowDepth = 4F;
            btnGoClientless.Size = new System.Drawing.Size(125, 21);
            btnGoClientless.TabIndex = 17;
            btnGoClientless.Text = "Go Clientless";
            btnGoClientless.UseVisualStyleBackColor = true;
            btnGoClientless.Click += btnGoClientless_Click;
            // 
            // groupBox1
            // 
            groupBox1.AutoSize = true;
            groupBox1.BackColor = System.Drawing.Color.Transparent;
            groupBox1.Controls.Add(separator1);
            groupBox1.Controls.Add(panel3);
            groupBox1.Controls.Add(captchaPanel);
            groupBox1.Controls.Add(autoLoginTopPanel);
            groupBox1.Location = new System.Drawing.Point(19, 172);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new System.Windows.Forms.Padding(3, 10, 3, 3);
            groupBox1.Radius = 10;
            groupBox1.ShadowDepth = 4;
            groupBox1.Size = new System.Drawing.Size(355, 317);
            groupBox1.TabIndex = 14;
            groupBox1.TabStop = false;
            groupBox1.Text = "Automated login";
            // 
            // separator1
            // 
            separator1.Dock = System.Windows.Forms.DockStyle.Top;
            separator1.IsVertical = false;
            separator1.Location = new System.Drawing.Point(3, 207);
            separator1.Name = "separator1";
            separator1.Size = new System.Drawing.Size(349, 2);
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
            panel3.Location = new System.Drawing.Point(3, 207);
            panel3.Name = "panel3";
            panel3.Size = new System.Drawing.Size(349, 107);
            panel3.TabIndex = 1;
            // 
            // radioAutoSelectHigher
            // 
            radioAutoSelectHigher.AutoSize = true;
            radioAutoSelectHigher.Enabled = false;
            radioAutoSelectHigher.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            radioAutoSelectHigher.Location = new System.Drawing.Point(198, 87);
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
            radioAutoSelectFirst.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            radioAutoSelectFirst.Location = new System.Drawing.Point(66, 87);
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
            checkCharAutoSelect.Location = new System.Drawing.Point(66, 64);
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
            checkHideClient.Location = new System.Drawing.Point(198, 64);
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
            lblLoginDelaySeconds.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lblLoginDelaySeconds.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            lblLoginDelaySeconds.Gradient = new System.Drawing.Color[]
    {
    System.Drawing.Color.Gray,
    System.Drawing.Color.Black
    };
            lblLoginDelaySeconds.GradientAnimation = false;
            lblLoginDelaySeconds.Location = new System.Drawing.Point(284, 16);
            lblLoginDelaySeconds.Name = "lblLoginDelaySeconds";
            lblLoginDelaySeconds.Size = new System.Drawing.Size(58, 19);
            lblLoginDelaySeconds.TabIndex = 22;
            lblLoginDelaySeconds.Text = "seconds";
            // 
            // numLoginDelay
            // 
            numLoginDelay.BackColor = System.Drawing.Color.Transparent;
            numLoginDelay.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            numLoginDelay.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            numLoginDelay.Location = new System.Drawing.Point(198, 11);
            numLoginDelay.Maximum = new decimal(new int[] { 60, 0, 0, 0 });
            numLoginDelay.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numLoginDelay.MinimumSize = new System.Drawing.Size(80, 25);
            numLoginDelay.Name = "numLoginDelay";
            numLoginDelay.Size = new System.Drawing.Size(80, 25);
            numLoginDelay.TabIndex = 30;
            numLoginDelay.Value = new decimal(new int[] { 10, 0, 0, 0 });
            numLoginDelay.ValueChanged += numLoginDelay_ValueChanged;
            // 
            // checkEnableLoginDelay
            // 
            checkEnableLoginDelay.AutoSize = true;
            checkEnableLoginDelay.BackColor = System.Drawing.Color.Transparent;
            checkEnableLoginDelay.Depth = 0;
            checkEnableLoginDelay.Location = new System.Drawing.Point(66, 10);
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
            checkStartBot.Location = new System.Drawing.Point(66, 40);
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
            checkUseReturnScroll.Location = new System.Drawing.Point(198, 40);
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
            captchaPanel.Location = new System.Drawing.Point(3, 124);
            captchaPanel.Name = "captchaPanel";
            captchaPanel.Size = new System.Drawing.Size(349, 83);
            captchaPanel.TabIndex = 0;
            captchaPanel.Visible = false;
            // 
            // separator2
            // 
            separator2.Dock = System.Windows.Forms.DockStyle.Top;
            separator2.IsVertical = false;
            separator2.Location = new System.Drawing.Point(0, 0);
            separator2.Name = "separator2";
            separator2.Size = new System.Drawing.Size(349, 2);
            separator2.TabIndex = 29;
            // 
            // label6
            // 
            label6.ApplyGradient = false;
            label6.AutoSize = true;
            label6.Enabled = false;
            label6.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label6.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            label6.Gradient = new System.Drawing.Color[]
    {
    System.Drawing.Color.Gray,
    System.Drawing.Color.Black
    };
            label6.GradientAnimation = false;
            label6.Location = new System.Drawing.Point(63, 60);
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
            label5.Location = new System.Drawing.Point(9, 14);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(58, 18);
            label5.TabIndex = 18;
            label5.Text = "Captcha:";
            // 
            // txtStaticCaptcha
            // 
            txtStaticCaptcha.Location = new System.Drawing.Point(66, 11);
            txtStaticCaptcha.MaxLength = 32767;
            txtStaticCaptcha.MultiLine = false;
            txtStaticCaptcha.Name = "txtStaticCaptcha";
            txtStaticCaptcha.PassFocusShow = false;
            txtStaticCaptcha.Radius = 2;
            txtStaticCaptcha.Size = new System.Drawing.Size(268, 25);
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
            checkEnableStaticCaptcha.Location = new System.Drawing.Point(66, 37);
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
            autoLoginTopPanel.Location = new System.Drawing.Point(3, 30);
            autoLoginTopPanel.Name = "autoLoginTopPanel";
            autoLoginTopPanel.Size = new System.Drawing.Size(349, 94);
            autoLoginTopPanel.TabIndex = 28;
            // 
            // comboAccounts
            // 
            comboAccounts.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            comboAccounts.DropDownHeight = 100;
            comboAccounts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboAccounts.FormattingEnabled = true;
            comboAccounts.IntegralHeight = false;
            comboAccounts.ItemHeight = 17;
            comboAccounts.Location = new System.Drawing.Point(66, 10);
            comboAccounts.Name = "comboAccounts";
            comboAccounts.Radius = 5;
            comboAccounts.ShadowDepth = 4F;
            comboAccounts.Size = new System.Drawing.Size(268, 23);
            comboAccounts.TabIndex = 0;
            comboAccounts.SelectedIndexChanged += comboAccounts_SelectedIndexChanged;
            // 
            // label7
            // 
            label7.ApplyGradient = false;
            label7.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            label7.Gradient = new System.Drawing.Color[]
    {
    System.Drawing.Color.Gray,
    System.Drawing.Color.Black
    };
            label7.GradientAnimation = false;
            label7.Location = new System.Drawing.Point(20, 37);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(47, 16);
            label7.TabIndex = 23;
            label7.Text = "Player:";
            // 
            // label4
            // 
            label4.ApplyGradient = false;
            label4.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            label4.Gradient = new System.Drawing.Color[]
    {
    System.Drawing.Color.Gray,
    System.Drawing.Color.Black
    };
            label4.GradientAnimation = false;
            label4.Location = new System.Drawing.Point(9, 13);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(66, 13);
            label4.TabIndex = 0;
            label4.Text = "Account:";
            // 
            // checkEnableAutoLogin
            // 
            checkEnableAutoLogin.AutoSize = true;
            checkEnableAutoLogin.BackColor = System.Drawing.Color.Transparent;
            checkEnableAutoLogin.Depth = 0;
            checkEnableAutoLogin.Location = new System.Drawing.Point(66, 65);
            checkEnableAutoLogin.Margin = new System.Windows.Forms.Padding(0);
            checkEnableAutoLogin.MouseLocation = new System.Drawing.Point(-1, -1);
            checkEnableAutoLogin.Name = "checkEnableAutoLogin";
            checkEnableAutoLogin.Ripple = true;
            checkEnableAutoLogin.Size = new System.Drawing.Size(193, 30);
            checkEnableAutoLogin.TabIndex = 1;
            checkEnableAutoLogin.Text = "Enable automated login";
            checkEnableAutoLogin.UseVisualStyleBackColor = false;
            checkEnableAutoLogin.CheckedChanged += checkEnableAutoLogin_CheckedChanged;
            // 
            // comboCharacter
            // 
            comboCharacter.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            comboCharacter.DropDownHeight = 100;
            comboCharacter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboCharacter.FormattingEnabled = true;
            comboCharacter.IntegralHeight = false;
            comboCharacter.ItemHeight = 17;
            comboCharacter.Items.AddRange(new object[] { "No Selected" });
            comboCharacter.Location = new System.Drawing.Point(66, 34);
            comboCharacter.Name = "comboCharacter";
            comboCharacter.Radius = 5;
            comboCharacter.ShadowDepth = 4F;
            comboCharacter.Size = new System.Drawing.Size(268, 23);
            comboCharacter.TabIndex = 22;
            comboCharacter.SelectedIndexChanged += comboCharacter_SelectedIndexChanged;
            // 
            // btnAutoLoginSettings
            // 
            btnAutoLoginSettings.Color = System.Drawing.Color.Transparent;
            btnAutoLoginSettings.Location = new System.Drawing.Point(259, 60);
            btnAutoLoginSettings.Name = "btnAutoLoginSettings";
            btnAutoLoginSettings.Radius = 6;
            btnAutoLoginSettings.ShadowDepth = 4F;
            btnAutoLoginSettings.Size = new System.Drawing.Size(75, 23);
            btnAutoLoginSettings.TabIndex = 2;
            btnAutoLoginSettings.Text = "Setup";
            btnAutoLoginSettings.UseVisualStyleBackColor = true;
            btnAutoLoginSettings.Click += btnAutoLoginSettings_Click;
            // 
            // btnBrowseSilkroadPath
            // 
            btnBrowseSilkroadPath.Color = System.Drawing.Color.Transparent;
            btnBrowseSilkroadPath.Location = new System.Drawing.Point(715, 30);
            btnBrowseSilkroadPath.Name = "btnBrowseSilkroadPath";
            btnBrowseSilkroadPath.Radius = 6;
            btnBrowseSilkroadPath.ShadowDepth = 4F;
            btnBrowseSilkroadPath.Size = new System.Drawing.Size(32, 21);
            btnBrowseSilkroadPath.TabIndex = 2;
            btnBrowseSilkroadPath.Text = "...";
            btnBrowseSilkroadPath.UseVisualStyleBackColor = true;
            btnBrowseSilkroadPath.Click += btnBrowseSilkroadPath_Click;
            // 
            // txtSilkroadPath
            // 
            txtSilkroadPath.Location = new System.Drawing.Point(19, 30);
            txtSilkroadPath.MaxLength = 32767;
            txtSilkroadPath.MultiLine = false;
            txtSilkroadPath.Name = "txtSilkroadPath";
            txtSilkroadPath.PassFocusShow = false;
            txtSilkroadPath.Radius = 2;
            txtSilkroadPath.Size = new System.Drawing.Size(570, 25);
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
            groupBox5.Location = new System.Drawing.Point(389, 278);
            groupBox5.Name = "groupBox5";
            groupBox5.Padding = new System.Windows.Forms.Padding(3, 10, 3, 3);
            groupBox5.Radius = 10;
            groupBox5.ShadowDepth = 4;
            groupBox5.Size = new System.Drawing.Size(359, 152);
            groupBox5.TabIndex = 24;
            groupBox5.TabStop = false;
            groupBox5.Text = "Server Pending";
            // 
            // checkEnableQueueLogs
            // 
            checkEnableQueueLogs.AutoSize = true;
            checkEnableQueueLogs.BackColor = System.Drawing.Color.Transparent;
            checkEnableQueueLogs.Depth = 0;
            checkEnableQueueLogs.Location = new System.Drawing.Point(20, 53);
            checkEnableQueueLogs.Margin = new System.Windows.Forms.Padding(0);
            checkEnableQueueLogs.MouseLocation = new System.Drawing.Point(-1, -1);
            checkEnableQueueLogs.Name = "checkEnableQueueLogs";
            checkEnableQueueLogs.Ripple = true;
            checkEnableQueueLogs.Size = new System.Drawing.Size(214, 30);
            checkEnableQueueLogs.TabIndex = 42;
            checkEnableQueueLogs.Text = "Enable pending queue logs";
            checkEnableQueueLogs.UseVisualStyleBackColor = false;
            checkEnableQueueLogs.CheckedChanged += checkEnableQueueLogs_CheckedChanged;
            // 
            // label3
            // 
            label3.ApplyGradient = false;
            label3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label3.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            label3.Gradient = new System.Drawing.Color[]
    {
    System.Drawing.Color.Gray,
    System.Drawing.Color.Black
    };
            label3.GradientAnimation = false;
            label3.Location = new System.Drawing.Point(292, 81);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(71, 18);
            label3.TabIndex = 39;
            label3.Text = "people left";
            // 
            // numQueueLeft
            // 
            numQueueLeft.BackColor = System.Drawing.Color.Transparent;
            numQueueLeft.Font = new System.Drawing.Font("Segoe UI", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            numQueueLeft.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            numQueueLeft.Location = new System.Drawing.Point(206, 76);
            numQueueLeft.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
            numQueueLeft.Minimum = new decimal(new int[] { 0, 0, 0, 0 });
            numQueueLeft.MinimumSize = new System.Drawing.Size(80, 25);
            numQueueLeft.Name = "numQueueLeft";
            numQueueLeft.Size = new System.Drawing.Size(80, 25);
            numQueueLeft.TabIndex = 39;
            numQueueLeft.Value = new decimal(new int[] { 0, 0, 0, 0 });
            numQueueLeft.ValueChanged += numQueueLeft_ValueChanged;
            // 
            // checkAutoHidePendingWindow
            // 
            checkAutoHidePendingWindow.AutoSize = true;
            checkAutoHidePendingWindow.BackColor = System.Drawing.Color.Transparent;
            checkAutoHidePendingWindow.Depth = 0;
            checkAutoHidePendingWindow.Location = new System.Drawing.Point(20, 32);
            checkAutoHidePendingWindow.Margin = new System.Windows.Forms.Padding(0);
            checkAutoHidePendingWindow.MouseLocation = new System.Drawing.Point(-1, -1);
            checkAutoHidePendingWindow.Name = "checkAutoHidePendingWindow";
            checkAutoHidePendingWindow.Ripple = true;
            checkAutoHidePendingWindow.Size = new System.Drawing.Size(238, 30);
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
            checkEnableQueueNotification.Location = new System.Drawing.Point(20, 75);
            checkEnableQueueNotification.Margin = new System.Windows.Forms.Padding(0);
            checkEnableQueueNotification.MouseLocation = new System.Drawing.Point(-1, -1);
            checkEnableQueueNotification.Name = "checkEnableQueueNotification";
            checkEnableQueueNotification.Ripple = true;
            checkEnableQueueNotification.Size = new System.Drawing.Size(228, 30);
            checkEnableQueueNotification.TabIndex = 40;
            checkEnableQueueNotification.Text = "Enable queue notification on ";
            checkEnableQueueNotification.UseVisualStyleBackColor = false;
            checkEnableQueueNotification.CheckedChanged += checkEnableQueueNotification_CheckedChanged;
            // 
            // btnShowPending
            // 
            btnShowPending.Color = System.Drawing.Color.Transparent;
            btnShowPending.Location = new System.Drawing.Point(29, 110);
            btnShowPending.Name = "btnShowPending";
            btnShowPending.Radius = 6;
            btnShowPending.ShadowDepth = 4F;
            btnShowPending.Size = new System.Drawing.Size(145, 23);
            btnShowPending.TabIndex = 24;
            btnShowPending.Text = "Toggle Pending Window";
            btnShowPending.UseVisualStyleBackColor = true;
            btnShowPending.Click += btnShowPending_Click;
            // 
            // Main
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
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
            Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            Name = "Main";
            Size = new System.Drawing.Size(765, 496);
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
    }
}
