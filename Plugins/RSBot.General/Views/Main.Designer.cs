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
            this.label1 = new System.Windows.Forms.Label();
            this.txtSilkroadPath = new System.Windows.Forms.TextBox();
            this.btnBrowseSilkroadPath = new RSBot.Theme.Material.Button();
            this.lblVersion = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.checkUseReturnScroll = new System.Windows.Forms.CheckBox();
            this.checkStartBot = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.comboCharacter = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.checkEnableStaticCaptcha = new System.Windows.Forms.CheckBox();
            this.txtStaticCaptcha = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnAutoLoginSettings = new RSBot.Theme.Material.Button();
            this.checkEnableAutoLogin = new System.Windows.Forms.CheckBox();
            this.comboAccounts = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnClientHideShow = new RSBot.Theme.Material.Button();
            this.btnStartClient = new RSBot.Theme.Material.Button();
            this.btnStartClientless = new RSBot.Theme.Material.Button();
            this.btnGoClientless = new RSBot.Theme.Material.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.checkStayConnected = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.checkBoxBotTrayMinimized = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Silkroad executable path:";
            // 
            // txtSilkroadPath
            // 
            this.txtSilkroadPath.Location = new System.Drawing.Point(19, 30);
            this.txtSilkroadPath.Name = "txtSilkroadPath";
            this.txtSilkroadPath.Size = new System.Drawing.Size(683, 20);
            this.txtSilkroadPath.TabIndex = 1;
            // 
            // btnBrowseSilkroadPath
            // 
            this.btnBrowseSilkroadPath.Depth = 0;
            this.btnBrowseSilkroadPath.Icon = null;
            this.btnBrowseSilkroadPath.Location = new System.Drawing.Point(708, 29);
            this.btnBrowseSilkroadPath.MouseState = RSBot.Theme.IMatMouseState.HOVER;
            this.btnBrowseSilkroadPath.Name = "btnBrowseSilkroadPath";
            this.btnBrowseSilkroadPath.Primary = false;
            this.btnBrowseSilkroadPath.Raised = false;
            this.btnBrowseSilkroadPath.SingleColor = System.Drawing.Color.Empty;
            this.btnBrowseSilkroadPath.Size = new System.Drawing.Size(40, 23);
            this.btnBrowseSilkroadPath.TabIndex = 2;
            this.btnBrowseSilkroadPath.Text = "...";
            this.btnBrowseSilkroadPath.UseVisualStyleBackColor = true;
            this.btnBrowseSilkroadPath.Click += new System.EventHandler(this.btnBrowseSilkroadPath_Click);
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Location = new System.Drawing.Point(636, 14);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(63, 13);
            this.lblVersion.TabIndex = 3;
            this.lblVersion.Text = "Client v1.00";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.checkUseReturnScroll);
            this.groupBox1.Controls.Add(this.checkStartBot);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.comboCharacter);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.checkEnableStaticCaptcha);
            this.groupBox1.Controls.Add(this.txtStaticCaptcha);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.btnAutoLoginSettings);
            this.groupBox1.Controls.Add(this.checkEnableAutoLogin);
            this.groupBox1.Controls.Add(this.comboAccounts);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(19, 163);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(355, 284);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Automated login";
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Location = new System.Drawing.Point(54, 202);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(247, 2);
            this.label3.TabIndex = 26;
            // 
            // checkUseReturnScroll
            // 
            this.checkUseReturnScroll.AutoSize = true;
            this.checkUseReturnScroll.Location = new System.Drawing.Point(79, 246);
            this.checkUseReturnScroll.Name = "checkUseReturnScroll";
            this.checkUseReturnScroll.Size = new System.Drawing.Size(102, 17);
            this.checkUseReturnScroll.TabIndex = 16;
            this.checkUseReturnScroll.Text = "Use return scroll";
            this.checkUseReturnScroll.UseVisualStyleBackColor = true;
            this.checkUseReturnScroll.CheckedChanged += new System.EventHandler(this.checkUseReturnScroll_CheckedChanged);
            // 
            // checkStartBot
            // 
            this.checkStartBot.AutoSize = true;
            this.checkStartBot.Location = new System.Drawing.Point(79, 223);
            this.checkStartBot.Name = "checkStartBot";
            this.checkStartBot.Size = new System.Drawing.Size(89, 17);
            this.checkStartBot.TabIndex = 24;
            this.checkStartBot.Text = "Auto start bot";
            this.checkStartBot.UseVisualStyleBackColor = true;
            this.checkStartBot.CheckedChanged += new System.EventHandler(this.checkAutoStartBot_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(26, 55);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 13);
            this.label7.TabIndex = 23;
            this.label7.Text = "Player:";
            // 
            // comboCharacter
            // 
            this.comboCharacter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboCharacter.FormattingEnabled = true;
            this.comboCharacter.Items.AddRange(new object[] {
            "No Selected"});
            this.comboCharacter.Location = new System.Drawing.Point(79, 52);
            this.comboCharacter.Name = "comboCharacter";
            this.comboCharacter.Size = new System.Drawing.Size(258, 21);
            this.comboCharacter.TabIndex = 22;
            this.comboCharacter.SelectedIndexChanged += new System.EventHandler(this.comboCharacter_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(95, 171);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(236, 13);
            this.label6.TabIndex = 21;
            this.label6.Text = "Please use this only if the captcha never changes.";
            // 
            // checkEnableStaticCaptcha
            // 
            this.checkEnableStaticCaptcha.AutoSize = true;
            this.checkEnableStaticCaptcha.Location = new System.Drawing.Point(79, 151);
            this.checkEnableStaticCaptcha.Name = "checkEnableStaticCaptcha";
            this.checkEnableStaticCaptcha.Size = new System.Drawing.Size(157, 17);
            this.checkEnableStaticCaptcha.TabIndex = 4;
            this.checkEnableStaticCaptcha.Text = "Enable static captcha solve";
            this.checkEnableStaticCaptcha.UseVisualStyleBackColor = true;
            this.checkEnableStaticCaptcha.CheckedChanged += new System.EventHandler(this.checkEnableStaticCaptcha_CheckedChanged);
            // 
            // txtStaticCaptcha
            // 
            this.txtStaticCaptcha.Location = new System.Drawing.Point(79, 123);
            this.txtStaticCaptcha.Name = "txtStaticCaptcha";
            this.txtStaticCaptcha.Size = new System.Drawing.Size(258, 20);
            this.txtStaticCaptcha.TabIndex = 3;
            this.txtStaticCaptcha.TextChanged += new System.EventHandler(this.txtStaticCaptcha_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 126);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Captcha:";
            // 
            // btnAutoLoginSettings
            // 
            this.btnAutoLoginSettings.Depth = 0;
            this.btnAutoLoginSettings.Icon = null;
            this.btnAutoLoginSettings.Location = new System.Drawing.Point(262, 79);
            this.btnAutoLoginSettings.MouseState = RSBot.Theme.IMatMouseState.HOVER;
            this.btnAutoLoginSettings.Name = "btnAutoLoginSettings";
            this.btnAutoLoginSettings.Primary = false;
            this.btnAutoLoginSettings.Raised = false;
            this.btnAutoLoginSettings.SingleColor = System.Drawing.Color.Empty;
            this.btnAutoLoginSettings.Size = new System.Drawing.Size(75, 23);
            this.btnAutoLoginSettings.TabIndex = 2;
            this.btnAutoLoginSettings.Text = "Setup";
            this.btnAutoLoginSettings.UseVisualStyleBackColor = true;
            this.btnAutoLoginSettings.Click += new System.EventHandler(this.btnAutoLoginSettings_Click);
            // 
            // checkEnableAutoLogin
            // 
            this.checkEnableAutoLogin.AutoSize = true;
            this.checkEnableAutoLogin.Location = new System.Drawing.Point(79, 83);
            this.checkEnableAutoLogin.Name = "checkEnableAutoLogin";
            this.checkEnableAutoLogin.Size = new System.Drawing.Size(137, 17);
            this.checkEnableAutoLogin.TabIndex = 1;
            this.checkEnableAutoLogin.Text = "Enable automated login";
            this.checkEnableAutoLogin.UseVisualStyleBackColor = true;
            this.checkEnableAutoLogin.CheckedChanged += new System.EventHandler(this.checkEnableAutoLogin_CheckedChanged);
            // 
            // comboAccounts
            // 
            this.comboAccounts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboAccounts.FormattingEnabled = true;
            this.comboAccounts.Location = new System.Drawing.Point(79, 28);
            this.comboAccounts.Name = "comboAccounts";
            this.comboAccounts.Size = new System.Drawing.Size(258, 21);
            this.comboAccounts.TabIndex = 0;
            this.comboAccounts.SelectedIndexChanged += new System.EventHandler(this.comboAccounts_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Account:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnClientHideShow);
            this.groupBox2.Controls.Add(this.btnStartClient);
            this.groupBox2.Controls.Add(this.btnStartClientless);
            this.groupBox2.Controls.Add(this.btnGoClientless);
            this.groupBox2.Location = new System.Drawing.Point(19, 67);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(355, 84);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Start game";
            // 
            // btnClientHideShow
            // 
            this.btnClientHideShow.Depth = 0;
            this.btnClientHideShow.Enabled = false;
            this.btnClientHideShow.Icon = null;
            this.btnClientHideShow.Location = new System.Drawing.Point(18, 46);
            this.btnClientHideShow.MouseState = RSBot.Theme.IMatMouseState.HOVER;
            this.btnClientHideShow.Name = "btnClientHideShow";
            this.btnClientHideShow.Primary = false;
            this.btnClientHideShow.Raised = false;
            this.btnClientHideShow.SingleColor = System.Drawing.Color.Empty;
            this.btnClientHideShow.Size = new System.Drawing.Size(125, 23);
            this.btnClientHideShow.TabIndex = 19;
            this.btnClientHideShow.Text = "Client Visibility";
            this.btnClientHideShow.UseVisualStyleBackColor = true;
            this.btnClientHideShow.Click += new System.EventHandler(this.btnClientHideShow_Click);
            // 
            // btnStartClient
            // 
            this.btnStartClient.Depth = 0;
            this.btnStartClient.Icon = null;
            this.btnStartClient.Location = new System.Drawing.Point(18, 16);
            this.btnStartClient.MouseState = RSBot.Theme.IMatMouseState.HOVER;
            this.btnStartClient.Name = "btnStartClient";
            this.btnStartClient.Primary = true;
            this.btnStartClient.Raised = true;
            this.btnStartClient.SingleColor = System.Drawing.Color.Empty;
            this.btnStartClient.Size = new System.Drawing.Size(125, 23);
            this.btnStartClient.TabIndex = 16;
            this.btnStartClient.Text = "Start Client";
            this.btnStartClient.UseVisualStyleBackColor = true;
            this.btnStartClient.Click += new System.EventHandler(this.btnStartClient_Click);
            // 
            // btnStartClientless
            // 
            this.btnStartClientless.Depth = 0;
            this.btnStartClientless.Icon = null;
            this.btnStartClientless.Location = new System.Drawing.Point(212, 16);
            this.btnStartClientless.MouseState = RSBot.Theme.IMatMouseState.HOVER;
            this.btnStartClientless.Name = "btnStartClientless";
            this.btnStartClientless.Primary = false;
            this.btnStartClientless.Raised = false;
            this.btnStartClientless.SingleColor = System.Drawing.Color.Empty;
            this.btnStartClientless.Size = new System.Drawing.Size(125, 24);
            this.btnStartClientless.TabIndex = 18;
            this.btnStartClientless.Text = "Start Clientless";
            this.btnStartClientless.UseVisualStyleBackColor = false;
            this.btnStartClientless.Click += new System.EventHandler(this.btnStartClientless_Click);
            // 
            // btnGoClientless
            // 
            this.btnGoClientless.Depth = 0;
            this.btnGoClientless.Enabled = false;
            this.btnGoClientless.Icon = null;
            this.btnGoClientless.Location = new System.Drawing.Point(212, 46);
            this.btnGoClientless.MouseState = RSBot.Theme.IMatMouseState.HOVER;
            this.btnGoClientless.Name = "btnGoClientless";
            this.btnGoClientless.Primary = false;
            this.btnGoClientless.Raised = false;
            this.btnGoClientless.SingleColor = System.Drawing.Color.Empty;
            this.btnGoClientless.Size = new System.Drawing.Size(125, 24);
            this.btnGoClientless.TabIndex = 17;
            this.btnGoClientless.Text = "Go Clientless";
            this.btnGoClientless.UseVisualStyleBackColor = true;
            this.btnGoClientless.Click += new System.EventHandler(this.btnGoClientless_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.checkStayConnected);
            this.groupBox3.Location = new System.Drawing.Point(389, 67);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(359, 84);
            this.groupBox3.TabIndex = 16;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Client settings";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.label2.Location = new System.Drawing.Point(39, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(213, 39);
            this.label2.TabIndex = 22;
            this.label2.Text = "If the client exits due to a crash, the bot will \r\nautomatically switch to client" +
    "less mode and \r\ncontinue its tasks";
            // 
            // checkStayConnected
            // 
            this.checkStayConnected.AutoSize = true;
            this.checkStayConnected.Location = new System.Drawing.Point(20, 23);
            this.checkStayConnected.Name = "checkStayConnected";
            this.checkStayConnected.Size = new System.Drawing.Size(227, 17);
            this.checkStayConnected.TabIndex = 17;
            this.checkStayConnected.Text = "Stay connected if client exits unexpectedly";
            this.checkStayConnected.UseVisualStyleBackColor = true;
            this.checkStayConnected.CheckedChanged += new System.EventHandler(this.checkStayConnected_CheckedChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.checkBoxBotTrayMinimized);
            this.groupBox4.Location = new System.Drawing.Point(389, 166);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(359, 100);
            this.groupBox4.TabIndex = 17;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Bot Settings";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.label8.Location = new System.Drawing.Point(39, 43);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(218, 39);
            this.label8.TabIndex = 22;
            this.label8.Text = "If activated, when the bot is minimized, \r\nthe bot will automatically switch to t" +
    "ray mode \r\nand continue to run there.";
            // 
            // checkBoxBotTrayMinimized
            // 
            this.checkBoxBotTrayMinimized.AutoSize = true;
            this.checkBoxBotTrayMinimized.Location = new System.Drawing.Point(20, 23);
            this.checkBoxBotTrayMinimized.Name = "checkBoxBotTrayMinimized";
            this.checkBoxBotTrayMinimized.Size = new System.Drawing.Size(215, 17);
            this.checkBoxBotTrayMinimized.TabIndex = 0;
            this.checkBoxBotTrayMinimized.Text = "Move bot to system tray when minimized";
            this.checkBoxBotTrayMinimized.UseVisualStyleBackColor = true;
            this.checkBoxBotTrayMinimized.CheckedChanged += new System.EventHandler(this.checkBoxBotTrayMinimized_CheckedChanged);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.btnBrowseSilkroadPath);
            this.Controls.Add(this.txtSilkroadPath);
            this.Controls.Add(this.label1);
            this.Name = "Main";
            this.Size = new System.Drawing.Size(754, 467);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSilkroadPath;
        private Theme.Material.Button btnBrowseSilkroadPath;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboAccounts;
        private System.Windows.Forms.CheckBox checkEnableAutoLogin;
        private Theme.Material.Button btnAutoLoginSettings;
        private System.Windows.Forms.TextBox txtStaticCaptcha;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox checkEnableStaticCaptcha;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboCharacter;
        private System.Windows.Forms.GroupBox groupBox2;
        private Theme.Material.Button btnGoClientless;
        private Theme.Material.Button btnStartClientless;
        private Theme.Material.Button btnStartClient;
        private System.Windows.Forms.CheckBox checkUseReturnScroll;
        private System.Windows.Forms.CheckBox checkStartBot;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox checkStayConnected;
        private System.Windows.Forms.Label label2;
        private Theme.Material.Button btnClientHideShow;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox checkBoxBotTrayMinimized;
    }
}
