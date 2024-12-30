using RSBot.Views.Controls;
using System.Windows.Forms;

namespace RSBot.Views
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            stripStatus = new StatusStrip();
            lblIngameStatus = new ToolStripStatusLabel();
            menuCurrentProfile = new ToolStripMenuItem();
            cosController = new RSBot.Views.Controls.Cos.CosController();
            bottomPanel = new SDUI.Controls.Panel();
            buttonConfig = new SDUI.Controls.Button();
            comboServer = new SDUI.Controls.ComboBox();
            comboDivision = new SDUI.Controls.ComboBox();
            btnSave = new SDUI.Controls.Button();
            btnStartStop = new SDUI.Controls.Button();
            pSidebar = new SDUI.Controls.Panel();
            pSidebarCustom = new SDUI.Controls.Panel();
            entity1 = new Entity();
            botbase1ToolStripMenuItem1 = new ToolStripMenuItem();
            botbase1ToolStripMenuItem = new ToolStripMenuItem();
            notifyIcon = new NotifyIcon(components);
            fileToolStripMenuItem = new ToolStripMenuItem();
            menuSelectProfile = new ToolStripMenuItem();
            networkConfigToolStripMenuItem = new ToolStripMenuItem();
            menuItemExit = new ToolStripMenuItem();
            viewToolStripMenuItem = new ToolStripMenuItem();
            menuSidebar = new ToolStripMenuItem();
            toolsToolStripMenuItem = new ToolStripMenuItem();
            menuScriptRecorder = new ToolStripMenuItem();
            menuPlugins = new ToolStripMenuItem();
            aboutToolStripMenuItem = new ToolStripMenuItem();
            thisToolStripMenuItem = new ToolStripMenuItem();
            menuStrip = new SDUI.Controls.ContextMenuStrip();
            botsToolStripMenuItem = new ToolStripMenuItem();
            languageToolStripMenuItem = new ToolStripMenuItem();
            themeToolStripMenuItem = new ToolStripMenuItem();
            darkToolStripMenuItem = new ToolStripMenuItem();
            lightToolStripMenuItem = new ToolStripMenuItem();
            autoToolStripMenuItem = new ToolStripMenuItem();
            coloredToolStripMenuItem = new ToolStripMenuItem();
            topCharacter = new Character();
            windowPageControl = new SDUI.Controls.WindowPageControl();
            stripStatus.SuspendLayout();
            bottomPanel.SuspendLayout();
            pSidebar.SuspendLayout();
            menuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // stripStatus
            // 
            stripStatus.BackColor = System.Drawing.Color.FromArgb(33, 150, 243);
            stripStatus.GripMargin = new Padding(2, 2, 0, 2);
            stripStatus.ImageScalingSize = new System.Drawing.Size(17, 17);
            stripStatus.Items.AddRange(new ToolStripItem[] { lblIngameStatus, menuCurrentProfile });
            stripStatus.LayoutStyle = ToolStripLayoutStyle.HorizontalStackWithOverflow;
            stripStatus.Location = new System.Drawing.Point(0, 806);
            stripStatus.Name = "stripStatus";
            stripStatus.Padding = new Padding(1, 0, 18, 0);
            stripStatus.Size = new System.Drawing.Size(1255, 26);
            stripStatus.SizingGrip = false;
            stripStatus.TabIndex = 0;
            stripStatus.Tag = "private";
            // 
            // lblIngameStatus
            // 
            lblIngameStatus.BackColor = System.Drawing.Color.Transparent;
            lblIngameStatus.ForeColor = System.Drawing.Color.White;
            lblIngameStatus.Name = "lblIngameStatus";
            lblIngameStatus.Size = new System.Drawing.Size(92, 20);
            lblIngameStatus.Text = "Not in game";
            // 
            // menuCurrentProfile
            // 
            menuCurrentProfile.Alignment = ToolStripItemAlignment.Right;
            menuCurrentProfile.ForeColor = System.Drawing.Color.White;
            menuCurrentProfile.Name = "menuCurrentProfile";
            menuCurrentProfile.Size = new System.Drawing.Size(122, 26);
            menuCurrentProfile.Text = "Profile: Default";
            menuCurrentProfile.Click += menuSelectProfile_Click;
            // 
            // cosController
            // 
            cosController.AutoSize = true;
            cosController.Dock = DockStyle.Top;
            cosController.Location = new System.Drawing.Point(0, 0);
            cosController.Margin = new Padding(5, 5, 5, 5);
            cosController.Name = "cosController";
            cosController.Padding = new Padding(4, 4, 4, 4);
            cosController.Size = new System.Drawing.Size(312, 88);
            cosController.TabIndex = 9;
            cosController.Visible = false;
            // 
            // bottomPanel
            // 
            bottomPanel.BackColor = System.Drawing.Color.Transparent;
            bottomPanel.Border = new Padding(0, 1, 0, 0);
            bottomPanel.BorderColor = System.Drawing.Color.Transparent;
            bottomPanel.Controls.Add(buttonConfig);
            bottomPanel.Controls.Add(comboServer);
            bottomPanel.Controls.Add(comboDivision);
            bottomPanel.Controls.Add(btnSave);
            bottomPanel.Controls.Add(btnStartStop);
            bottomPanel.Dock = DockStyle.Bottom;
            bottomPanel.Location = new System.Drawing.Point(0, 741);
            bottomPanel.Margin = new Padding(4, 4, 4, 4);
            bottomPanel.Name = "bottomPanel";
            bottomPanel.Radius = 0;
            bottomPanel.ShadowDepth = 8F;
            bottomPanel.Size = new System.Drawing.Size(1255, 65);
            bottomPanel.TabIndex = 2;
            // 
            // buttonConfig
            // 
            buttonConfig.AutoSize = true;
            buttonConfig.Color = System.Drawing.Color.Transparent;
            buttonConfig.Font = new System.Drawing.Font("Segoe UI", 9F);
            buttonConfig.Location = new System.Drawing.Point(311, 19);
            buttonConfig.Margin = new Padding(4, 4, 4, 4);
            buttonConfig.Name = "buttonConfig";
            buttonConfig.Radius = 6;
            buttonConfig.ShadowDepth = 4F;
            buttonConfig.Size = new System.Drawing.Size(89, 29);
            buttonConfig.TabIndex = 12;
            buttonConfig.Text = "IP Bind";
            buttonConfig.UseVisualStyleBackColor = true;
            buttonConfig.Click += buttonConfig_Click;
            // 
            // comboServer
            // 
            comboServer.DrawMode = DrawMode.OwnerDrawFixed;
            comboServer.DropDownHeight = 100;
            comboServer.DropDownStyle = ComboBoxStyle.DropDownList;
            comboServer.FormattingEnabled = true;
            comboServer.ItemHeight = 17;
            comboServer.Location = new System.Drawing.Point(139, 19);
            comboServer.Margin = new Padding(4, 4, 4, 4);
            comboServer.Name = "comboServer";
            comboServer.Radius = 5;
            comboServer.ShadowDepth = 4F;
            comboServer.Size = new System.Drawing.Size(164, 23);
            comboServer.TabIndex = 11;
            comboServer.SelectedIndexChanged += comboServer_SelectedIndexChanged;
            // 
            // comboDivision
            // 
            comboDivision.DrawMode = DrawMode.OwnerDrawFixed;
            comboDivision.DropDownHeight = 100;
            comboDivision.DropDownStyle = ComboBoxStyle.DropDownList;
            comboDivision.FormattingEnabled = true;
            comboDivision.IntegralHeight = false;
            comboDivision.ItemHeight = 17;
            comboDivision.Location = new System.Drawing.Point(18, 19);
            comboDivision.Margin = new Padding(4, 4, 4, 4);
            comboDivision.Name = "comboDivision";
            comboDivision.Radius = 5;
            comboDivision.ShadowDepth = 4F;
            comboDivision.Size = new System.Drawing.Size(113, 23);
            comboDivision.TabIndex = 10;
            comboDivision.SelectedIndexChanged += comboDivision_SelectedIndexChanged;
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSave.Color = System.Drawing.Color.FromArgb(56, 155, 90);
            btnSave.Font = new System.Drawing.Font("Segoe UI Semibold", 9.25F, System.Drawing.FontStyle.Bold);
            btnSave.ForeColor = System.Drawing.Color.White;
            btnSave.Location = new System.Drawing.Point(978, 15);
            btnSave.Margin = new Padding(4, 4, 4, 4);
            btnSave.Name = "btnSave";
            btnSave.Radius = 6;
            btnSave.ShadowDepth = 4F;
            btnSave.Size = new System.Drawing.Size(125, 34);
            btnSave.TabIndex = 1;
            btnSave.TabStop = false;
            btnSave.Tag = "private";
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnStartStop
            // 
            btnStartStop.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnStartStop.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnStartStop.BackColor = System.Drawing.Color.DodgerBlue;
            btnStartStop.Color = System.Drawing.Color.FromArgb(33, 150, 243);
            btnStartStop.Font = new System.Drawing.Font("Segoe UI Semibold", 9.25F, System.Drawing.FontStyle.Bold);
            btnStartStop.ForeColor = System.Drawing.Color.White;
            btnStartStop.Location = new System.Drawing.Point(1110, 15);
            btnStartStop.Margin = new Padding(4, 4, 4, 4);
            btnStartStop.Name = "btnStartStop";
            btnStartStop.Radius = 6;
            btnStartStop.ShadowDepth = 4F;
            btnStartStop.Size = new System.Drawing.Size(125, 34);
            btnStartStop.TabIndex = 0;
            btnStartStop.TabStop = false;
            btnStartStop.Tag = "private";
            btnStartStop.Text = "START BOT";
            btnStartStop.UseVisualStyleBackColor = false;
            btnStartStop.Click += btnStartStop_Click;
            // 
            // pSidebar
            // 
            pSidebar.BackColor = System.Drawing.Color.Transparent;
            pSidebar.Border = new Padding(1, 0, 0, 0);
            pSidebar.BorderColor = System.Drawing.Color.Transparent;
            pSidebar.Controls.Add(pSidebarCustom);
            pSidebar.Controls.Add(entity1);
            pSidebar.Controls.Add(cosController);
            pSidebar.Dock = DockStyle.Right;
            pSidebar.Location = new System.Drawing.Point(943, 40);
            pSidebar.Margin = new Padding(4, 4, 4, 4);
            pSidebar.Name = "pSidebar";
            pSidebar.Radius = 0;
            pSidebar.ShadowDepth = 0F;
            pSidebar.Size = new System.Drawing.Size(312, 701);
            pSidebar.TabIndex = 6;
            // 
            // pSidebarCustom
            // 
            pSidebarCustom.Dock = DockStyle.Fill;
            pSidebarCustom.Location = new System.Drawing.Point(0, 192);
            pSidebarCustom.Margin = new Padding(4, 38, 4, 4);
            pSidebarCustom.Name = "pSidebarCustom";
            pSidebarCustom.Padding = new Padding(0, 20, 0, 0);
            pSidebarCustom.Size = new System.Drawing.Size(312, 509);
            pSidebarCustom.TabIndex = 14;
            pSidebarCustom.ShadowDepth = 0;
            pSidebarCustom.Radius = 0;
            // 
            // entity1
            // 
            entity1.Dock = DockStyle.Top;
            entity1.Location = new System.Drawing.Point(0, 88);
            entity1.Margin = new Padding(5, 5, 5, 5);
            entity1.MinimumSize = new System.Drawing.Size(312, 95);
            entity1.Name = "entity1";
            entity1.Size = new System.Drawing.Size(312, 104);
            entity1.TabIndex = 10;
            // 
            // botbase1ToolStripMenuItem1
            // 
            botbase1ToolStripMenuItem1.Name = "botbase1ToolStripMenuItem1";
            botbase1ToolStripMenuItem1.Size = new System.Drawing.Size(132, 22);
            botbase1ToolStripMenuItem1.Text = "Botbase #2";
            // 
            // botbase1ToolStripMenuItem
            // 
            botbase1ToolStripMenuItem.Name = "botbase1ToolStripMenuItem";
            botbase1ToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            botbase1ToolStripMenuItem.Text = "Botbase #1";
            // 
            // notifyIcon
            // 
            notifyIcon.BalloonTipIcon = ToolTipIcon.Info;
            notifyIcon.BalloonTipText = "RSBot is currently running in the system tray.";
            notifyIcon.BalloonTipTitle = "RSBot";
            notifyIcon.Icon = (System.Drawing.Icon)resources.GetObject("notifyIcon.Icon");
            notifyIcon.Text = "RSBot";
            notifyIcon.Visible = true;
            notifyIcon.Click += notifyIcon_Click;
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { menuSelectProfile, networkConfigToolStripMenuItem, menuItemExit });
            fileToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new System.Drawing.Size(148, 26);
            fileToolStripMenuItem.Text = "File";
            // 
            // menuSelectProfile
            // 
            menuSelectProfile.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            menuSelectProfile.Name = "menuSelectProfile";
            menuSelectProfile.Size = new System.Drawing.Size(193, 26);
            menuSelectProfile.Text = "Select Profile...";
            menuSelectProfile.Click += menuSelectProfile_Click;
            // 
            // networkConfigToolStripMenuItem
            // 
            networkConfigToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            networkConfigToolStripMenuItem.Name = "networkConfigToolStripMenuItem";
            networkConfigToolStripMenuItem.Size = new System.Drawing.Size(193, 26);
            networkConfigToolStripMenuItem.Text = "Proxy Config";
            networkConfigToolStripMenuItem.Click += networkConfigToolStripMenuItem_Click;
            // 
            // menuItemExit
            // 
            menuItemExit.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            menuItemExit.Name = "menuItemExit";
            menuItemExit.Size = new System.Drawing.Size(193, 26);
            menuItemExit.Text = "Exit";
            menuItemExit.Click += menuItemExit_Click;
            // 
            // viewToolStripMenuItem
            // 
            viewToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { menuSidebar });
            viewToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            viewToolStripMenuItem.Size = new System.Drawing.Size(148, 26);
            viewToolStripMenuItem.Text = "View";
            // 
            // menuSidebar
            // 
            menuSidebar.Name = "menuSidebar";
            menuSidebar.Size = new System.Drawing.Size(147, 26);
            menuSidebar.Text = "Sidebar";
            menuSidebar.Click += menuSidebar_Click;
            // 
            // toolsToolStripMenuItem
            // 
            toolsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { menuScriptRecorder });
            toolsToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            toolsToolStripMenuItem.Size = new System.Drawing.Size(148, 26);
            toolsToolStripMenuItem.Text = "Tools";
            // 
            // menuScriptRecorder
            // 
            menuScriptRecorder.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            menuScriptRecorder.Name = "menuScriptRecorder";
            menuScriptRecorder.Size = new System.Drawing.Size(201, 26);
            menuScriptRecorder.Text = "Script Recorder";
            menuScriptRecorder.Click += menuScriptRecorder_Click;
            // 
            // menuPlugins
            // 
            menuPlugins.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            menuPlugins.Name = "menuPlugins";
            menuPlugins.Size = new System.Drawing.Size(148, 26);
            menuPlugins.Text = "Plugins";
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { thisToolStripMenuItem });
            aboutToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new System.Drawing.Size(148, 26);
            aboutToolStripMenuItem.Text = "About";
            // 
            // thisToolStripMenuItem
            // 
            thisToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            thisToolStripMenuItem.Name = "thisToolStripMenuItem";
            thisToolStripMenuItem.Size = new System.Drawing.Size(122, 26);
            thisToolStripMenuItem.Text = "This";
            thisToolStripMenuItem.Click += menuItemThis_Click;
            // 
            // menuStrip
            // 
            menuStrip.BackColor = System.Drawing.Color.FromArgb(0, 0, 0, 0);
            menuStrip.Font = new System.Drawing.Font("Segoe UI", 9.25F);
            menuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            menuStrip.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, viewToolStripMenuItem, toolsToolStripMenuItem, menuPlugins, botsToolStripMenuItem, languageToolStripMenuItem, themeToolStripMenuItem, aboutToolStripMenuItem });
            menuStrip.Name = "menuStrip";
            menuStrip.Size = new System.Drawing.Size(149, 212);
            // 
            // botsToolStripMenuItem
            // 
            botsToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            botsToolStripMenuItem.Name = "botsToolStripMenuItem";
            botsToolStripMenuItem.Size = new System.Drawing.Size(148, 26);
            botsToolStripMenuItem.Text = "Bots";
            // 
            // languageToolStripMenuItem
            // 
            languageToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            languageToolStripMenuItem.Name = "languageToolStripMenuItem";
            languageToolStripMenuItem.Size = new System.Drawing.Size(148, 26);
            languageToolStripMenuItem.Text = "Language";
            // 
            // themeToolStripMenuItem
            // 
            themeToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { darkToolStripMenuItem, lightToolStripMenuItem, autoToolStripMenuItem, coloredToolStripMenuItem });
            themeToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            themeToolStripMenuItem.Name = "themeToolStripMenuItem";
            themeToolStripMenuItem.Size = new System.Drawing.Size(148, 26);
            themeToolStripMenuItem.Text = "Theme";
            // 
            // darkToolStripMenuItem
            // 
            darkToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            darkToolStripMenuItem.Name = "darkToolStripMenuItem";
            darkToolStripMenuItem.Size = new System.Drawing.Size(197, 26);
            darkToolStripMenuItem.Text = "Dark";
            darkToolStripMenuItem.Click += darkToolStripMenuItem_Click;
            // 
            // lightToolStripMenuItem
            // 
            lightToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            lightToolStripMenuItem.Name = "lightToolStripMenuItem";
            lightToolStripMenuItem.Size = new System.Drawing.Size(197, 26);
            lightToolStripMenuItem.Text = "Light";
            lightToolStripMenuItem.Click += lightToolStripMenuItem_Click;
            // 
            // autoToolStripMenuItem
            // 
            autoToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            autoToolStripMenuItem.Name = "autoToolStripMenuItem";
            autoToolStripMenuItem.Size = new System.Drawing.Size(197, 26);
            autoToolStripMenuItem.Text = "Auto";
            autoToolStripMenuItem.Click += autoToolStripMenuItem_Click;
            // 
            // coloredToolStripMenuItem
            // 
            coloredToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            coloredToolStripMenuItem.Name = "coloredToolStripMenuItem";
            coloredToolStripMenuItem.Size = new System.Drawing.Size(197, 26);
            coloredToolStripMenuItem.Text = "Choose a color";
            coloredToolStripMenuItem.Click += coloredToolStripMenuItem_Click;
            // 
            // topCharacter
            // 
            topCharacter.BackColor = System.Drawing.Color.Transparent;
            topCharacter.Dock = DockStyle.Top;
            topCharacter.Font = new System.Drawing.Font("Segoe UI", 9.25F);
            topCharacter.Location = new System.Drawing.Point(0, 40);
            topCharacter.Margin = new Padding(5, 5, 5, 5);
            topCharacter.Name = "topCharacter";
            topCharacter.Size = new System.Drawing.Size(943, 92);
            topCharacter.TabIndex = 7;
            // 
            // windowPageControl
            // 
            windowPageControl.AutoScroll = true;
            windowPageControl.Dock = DockStyle.Fill;
            windowPageControl.Location = new System.Drawing.Point(0, 132);
            windowPageControl.Margin = new Padding(4, 4, 4, 4);
            windowPageControl.Name = "windowPageControl";
            windowPageControl.SelectedIndex = -1;
            windowPageControl.Size = new System.Drawing.Size(943, 609);
            windowPageControl.TabIndex = 13;
            // 
            // Main
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new System.Drawing.Size(1255, 832);
            ControlBox = false;
            Controls.Add(windowPageControl);
            Controls.Add(topCharacter);
            Controls.Add(pSidebar);
            Controls.Add(bottomPanel);
            Controls.Add(stripStatus);
            DwmMargin = 0;
            ExtendBox = true;
            ExtendMenu = menuStrip;
            Hatch = System.Drawing.Drawing2D.HatchStyle.Percent20;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Location = new System.Drawing.Point(0, 0);
            Margin = new Padding(4, 4, 4, 4);
            Name = "Main";
            StartPosition = FormStartPosition.CenterScreen;
            Tag = "";
            WindowPageControl = windowPageControl;
            FormClosing += Main_FormClosing;
            Load += Main_Load;
            Resize += Main_Resize;
            stripStatus.ResumeLayout(false);
            stripStatus.PerformLayout();
            bottomPanel.ResumeLayout(false);
            bottomPanel.PerformLayout();
            pSidebar.ResumeLayout(false);
            pSidebar.PerformLayout();
            menuStrip.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.StatusStrip stripStatus;
        private SDUI.Controls.Panel bottomPanel;
        private SDUI.Controls.Panel pSidebar;
        private System.Windows.Forms.ToolStripStatusLabel lblIngameStatus;
        private SDUI.Controls.Button btnStartStop;
        private SDUI.Controls.Button btnSave;
        private Controls.Character topCharacter;
        private Controls.Cos.CosController cosController;
        private SDUI.Controls.ComboBox comboServer;
        private SDUI.Controls.ComboBox comboDivision;
        private System.Windows.Forms.ToolStripMenuItem botbase1ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem botbase1ToolStripMenuItem;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuItemExit;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuSidebar;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuScriptRecorder;
        private System.Windows.Forms.ToolStripMenuItem menuPlugins;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thisToolStripMenuItem;
        private SDUI.Controls.ContextMenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem themeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem darkToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lightToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem coloredToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem languageToolStripMenuItem;
        private ToolStripMenuItem menuSelectProfile;
        private ToolStripMenuItem botsToolStripMenuItem;
        private ToolStripMenuItem autoToolStripMenuItem;
        private SDUI.Controls.Button buttonConfig;
        private ToolStripMenuItem networkConfigToolStripMenuItem;
        private ToolStripMenuItem menuCurrentProfile;
        private SDUI.Controls.WindowPageControl windowPageControl;
        private Entity entity1;
        private SDUI.Controls.Panel pSidebarCustom;
    }
}

