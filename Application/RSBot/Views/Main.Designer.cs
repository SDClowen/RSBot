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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.stripStatus = new System.Windows.Forms.StatusStrip();
            this.menuBotbase = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblIngameStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.cosController = new RSBot.Views.Controls.Cos.CosController();
            this.bottomPanel = new SDUI.Controls.Panel();
            this.comboServer = new SDUI.Controls.ComboBox();
            this.comboDivision = new SDUI.Controls.ComboBox();
            this.btnSave = new SDUI.Controls.Button();
            this.btnStartStop = new SDUI.Controls.Button();
            this.pSidebar = new SDUI.Controls.Panel();
            this.entity1 = new RSBot.Views.Controls.Entity();
            this.botbase1ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.botbase1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSelectProfile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSidebar = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuScriptRecorder = new System.Windows.Forms.ToolStripMenuItem();
            this.menuPlugins = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip = new SDUI.Controls.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.languageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.themeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.darkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lightToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.coloredToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.minimizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabMain = new SDUI.Controls.TabControl();
            this.separator = new SDUI.Controls.Separator();
            this.separator1 = new SDUI.Controls.Separator();
            this.topCharacter = new RSBot.Views.Controls.Character();
            this.menuCurrentProfile = new System.Windows.Forms.ToolStripMenuItem();
            this.stripStatus.SuspendLayout();
            this.bottomPanel.SuspendLayout();
            this.pSidebar.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // stripStatus
            // 
            this.stripStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.stripStatus.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.stripStatus.ImageScalingSize = new System.Drawing.Size(17, 17);
            this.stripStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuBotbase,
            this.toolStripStatusLabel1,
            this.lblIngameStatus});
            this.stripStatus.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.stripStatus.Location = new System.Drawing.Point(1, 662);
            this.stripStatus.Name = "stripStatus";
            this.stripStatus.Size = new System.Drawing.Size(1030, 22);
            this.stripStatus.SizingGrip = false;
            this.stripStatus.TabIndex = 0;
            this.stripStatus.Tag = "private";
            // 
            // menuBotbase
            // 
            this.menuBotbase.ForeColor = System.Drawing.Color.White;
            this.menuBotbase.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menuBotbase.Name = "menuBotbase";
            this.menuBotbase.ShowDropDownArrow = false;
            this.menuBotbase.Size = new System.Drawing.Size(107, 20);
            this.menuBotbase.Text = "No botbase found";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.BackColor = System.Drawing.Color.Transparent;
            this.toolStripStatusLabel1.ForeColor = System.Drawing.Color.White;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(16, 17);
            this.toolStripStatusLabel1.Text = " | ";
            // 
            // lblIngameStatus
            // 
            this.lblIngameStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblIngameStatus.ForeColor = System.Drawing.Color.White;
            this.lblIngameStatus.Name = "lblIngameStatus";
            this.lblIngameStatus.Size = new System.Drawing.Size(73, 17);
            this.lblIngameStatus.Text = "Not in game";
            // 
            // cosController
            // 
            this.cosController.AutoSize = true;
            this.cosController.Dock = System.Windows.Forms.DockStyle.Top;
            this.cosController.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cosController.Location = new System.Drawing.Point(0, 0);
            this.cosController.Name = "cosController";
            this.cosController.Padding = new System.Windows.Forms.Padding(3);
            this.cosController.Size = new System.Drawing.Size(250, 70);
            this.cosController.TabIndex = 9;
            this.cosController.Visible = false;
            // 
            // bottomPanel
            // 
            this.bottomPanel.BackColor = System.Drawing.Color.Transparent;
            this.bottomPanel.Border = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.bottomPanel.BorderColor = System.Drawing.Color.Transparent;
            this.bottomPanel.Controls.Add(this.comboServer);
            this.bottomPanel.Controls.Add(this.comboDivision);
            this.bottomPanel.Controls.Add(this.btnSave);
            this.bottomPanel.Controls.Add(this.btnStartStop);
            this.bottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomPanel.Location = new System.Drawing.Point(1, 610);
            this.bottomPanel.Name = "bottomPanel";
            this.bottomPanel.Radius = 0;
            this.bottomPanel.Size = new System.Drawing.Size(1030, 52);
            this.bottomPanel.TabIndex = 2;
            // 
            // comboServer
            // 
            this.comboServer.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboServer.DropDownHeight = 100;
            this.comboServer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboServer.FormattingEnabled = true;
            this.comboServer.IntegralHeight = false;
            this.comboServer.ItemHeight = 17;
            this.comboServer.Location = new System.Drawing.Point(109, 18);
            this.comboServer.Name = "comboServer";
            this.comboServer.Size = new System.Drawing.Size(132, 23);
            this.comboServer.TabIndex = 11;
            this.comboServer.SelectedIndexChanged += new System.EventHandler(this.comboServer_SelectedIndexChanged);
            // 
            // comboDivision
            // 
            this.comboDivision.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboDivision.DropDownHeight = 100;
            this.comboDivision.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboDivision.FormattingEnabled = true;
            this.comboDivision.IntegralHeight = false;
            this.comboDivision.ItemHeight = 17;
            this.comboDivision.Location = new System.Drawing.Point(12, 18);
            this.comboDivision.Name = "comboDivision";
            this.comboDivision.Size = new System.Drawing.Size(91, 23);
            this.comboDivision.TabIndex = 10;
            this.comboDivision.SelectedIndexChanged += new System.EventHandler(this.comboDivision_SelectedIndexChanged);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSave.Color = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(155)))), ((int)(((byte)(90)))));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(822, 16);
            this.btnSave.Name = "btnSave";
            this.btnSave.Radius = 2;
            this.btnSave.Size = new System.Drawing.Size(95, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.TabStop = false;
            this.btnSave.Tag = "private";
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnStartStop
            // 
            this.btnStartStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStartStop.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnStartStop.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnStartStop.Color = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.btnStartStop.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnStartStop.ForeColor = System.Drawing.Color.White;
            this.btnStartStop.Location = new System.Drawing.Point(923, 16);
            this.btnStartStop.Name = "btnStartStop";
            this.btnStartStop.Radius = 2;
            this.btnStartStop.Size = new System.Drawing.Size(95, 23);
            this.btnStartStop.TabIndex = 0;
            this.btnStartStop.TabStop = false;
            this.btnStartStop.Tag = "private";
            this.btnStartStop.Text = "START BOT";
            this.btnStartStop.UseVisualStyleBackColor = false;
            this.btnStartStop.Click += new System.EventHandler(this.btnStartStop_Click);
            // 
            // pSidebar
            // 
            this.pSidebar.BackColor = System.Drawing.Color.Transparent;
            this.pSidebar.Border = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.pSidebar.BorderColor = System.Drawing.Color.Transparent;
            this.pSidebar.Controls.Add(this.entity1);
            this.pSidebar.Controls.Add(this.cosController);
            this.pSidebar.Dock = System.Windows.Forms.DockStyle.Right;
            this.pSidebar.Location = new System.Drawing.Point(781, 32);
            this.pSidebar.Name = "pSidebar";
            this.pSidebar.Radius = 0;
            this.pSidebar.Size = new System.Drawing.Size(250, 578);
            this.pSidebar.TabIndex = 6;
            // 
            // entity1
            // 
            this.entity1.BackColor = System.Drawing.Color.Transparent;
            this.entity1.Dock = System.Windows.Forms.DockStyle.Top;
            this.entity1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.entity1.Location = new System.Drawing.Point(0, 70);
            this.entity1.Margin = new System.Windows.Forms.Padding(4);
            this.entity1.MinimumSize = new System.Drawing.Size(250, 76);
            this.entity1.Name = "entity1";
            this.entity1.Size = new System.Drawing.Size(250, 76);
            this.entity1.TabIndex = 2;
            // 
            // botbase1ToolStripMenuItem1
            // 
            this.botbase1ToolStripMenuItem1.Name = "botbase1ToolStripMenuItem1";
            this.botbase1ToolStripMenuItem1.Size = new System.Drawing.Size(132, 22);
            this.botbase1ToolStripMenuItem1.Text = "Botbase #2";
            // 
            // botbase1ToolStripMenuItem
            // 
            this.botbase1ToolStripMenuItem.Name = "botbase1ToolStripMenuItem";
            this.botbase1ToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.botbase1ToolStripMenuItem.Text = "Botbase #1";
            // 
            // notifyIcon
            // 
            this.notifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon.BalloonTipText = "RSBot is currently running in the system tray.";
            this.notifyIcon.BalloonTipTitle = "RSBot";
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "RSBot";
            this.notifyIcon.Visible = true;
            this.notifyIcon.Click += new System.EventHandler(this.notifyIcon_Click);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuSelectProfile,
            this.menuItemExit});
            this.fileToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 22);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // menuSelectProfile
            // 
            this.menuSelectProfile.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.menuSelectProfile.Name = "menuSelectProfile";
            this.menuSelectProfile.Size = new System.Drawing.Size(151, 22);
            this.menuSelectProfile.Text = "Select Profile...";
            this.menuSelectProfile.Click += new System.EventHandler(this.menuSelectProfile_Click);
            // 
            // menuItemExit
            // 
            this.menuItemExit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.menuItemExit.Name = "menuItemExit";
            this.menuItemExit.Size = new System.Drawing.Size(151, 22);
            this.menuItemExit.Text = "Exit";
            this.menuItemExit.Click += new System.EventHandler(this.menuItemExit_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuSidebar});
            this.viewToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 22);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // menuSidebar
            // 
            this.menuSidebar.Name = "menuSidebar";
            this.menuSidebar.Size = new System.Drawing.Size(113, 22);
            this.menuSidebar.Text = "Sidebar";
            this.menuSidebar.Click += new System.EventHandler(this.menuSidebar_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuScriptRecorder});
            this.toolsToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(46, 22);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // menuScriptRecorder
            // 
            this.menuScriptRecorder.Name = "menuScriptRecorder";
            this.menuScriptRecorder.Size = new System.Drawing.Size(142, 22);
            this.menuScriptRecorder.Text = "File Recorder";
            this.menuScriptRecorder.Click += new System.EventHandler(this.menuScriptRecorder_Click);
            // 
            // menuPlugins
            // 
            this.menuPlugins.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.menuPlugins.Name = "menuPlugins";
            this.menuPlugins.Size = new System.Drawing.Size(58, 22);
            this.menuPlugins.Text = "Plugins";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thisToolStripMenuItem});
            this.aboutToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 22);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // thisToolStripMenuItem
            // 
            this.thisToolStripMenuItem.Name = "thisToolStripMenuItem";
            this.thisToolStripMenuItem.Size = new System.Drawing.Size(95, 22);
            this.thisToolStripMenuItem.Text = "This";
            this.thisToolStripMenuItem.Click += new System.EventHandler(this.menuItemThis_Click);
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.menuStrip.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.menuPlugins,
            this.languageToolStripMenuItem,
            this.themeToolStripMenuItem,
            this.aboutToolStripMenuItem,
            this.closeToolStripMenuItem,
            this.minimizeToolStripMenuItem,
            this.menuCurrentProfile});
            this.menuStrip.Location = new System.Drawing.Point(1, 1);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.menuStrip.Size = new System.Drawing.Size(1030, 30);
            this.menuStrip.TabIndex = 10;
            this.menuStrip.MouseDown += new System.Windows.Forms.MouseEventHandler(this.menuStrip_MouseDown);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripMenuItem1.Image = global::RSBot.Properties.Resources.shark;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(28, 22);
            // 
            // languageToolStripMenuItem
            // 
            this.languageToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.languageToolStripMenuItem.Name = "languageToolStripMenuItem";
            this.languageToolStripMenuItem.Size = new System.Drawing.Size(71, 22);
            this.languageToolStripMenuItem.Text = "Language";
            // 
            // themeToolStripMenuItem
            // 
            this.themeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.darkToolStripMenuItem,
            this.lightToolStripMenuItem,
            this.coloredToolStripMenuItem});
            this.themeToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.themeToolStripMenuItem.Name = "themeToolStripMenuItem";
            this.themeToolStripMenuItem.Size = new System.Drawing.Size(55, 22);
            this.themeToolStripMenuItem.Text = "Theme";
            // 
            // darkToolStripMenuItem
            // 
            this.darkToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.darkToolStripMenuItem.Name = "darkToolStripMenuItem";
            this.darkToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.darkToolStripMenuItem.Text = "Dark";
            this.darkToolStripMenuItem.Click += new System.EventHandler(this.darkToolStripMenuItem_Click);
            // 
            // lightToolStripMenuItem
            // 
            this.lightToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lightToolStripMenuItem.Name = "lightToolStripMenuItem";
            this.lightToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.lightToolStripMenuItem.Text = "Light";
            this.lightToolStripMenuItem.Click += new System.EventHandler(this.lightToolStripMenuItem_Click);
            // 
            // coloredToolStripMenuItem
            // 
            this.coloredToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.coloredToolStripMenuItem.Name = "coloredToolStripMenuItem";
            this.coloredToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.coloredToolStripMenuItem.Text = "Choose a color";
            this.coloredToolStripMenuItem.Click += new System.EventHandler(this.coloredToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.closeToolStripMenuItem.Font = new System.Drawing.Font("Webdings", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.closeToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(33, 22);
            this.closeToolStripMenuItem.Text = "r";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // minimizeToolStripMenuItem
            // 
            this.minimizeToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.minimizeToolStripMenuItem.Font = new System.Drawing.Font("Webdings", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.minimizeToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.minimizeToolStripMenuItem.Name = "minimizeToolStripMenuItem";
            this.minimizeToolStripMenuItem.Size = new System.Drawing.Size(33, 22);
            this.minimizeToolStripMenuItem.Text = "0";
            this.minimizeToolStripMenuItem.Click += new System.EventHandler(this.minimizeToolStripMenuItem_Click);
            // 
            // tabMain
            // 
            this.tabMain.Border = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabMain.HideTabArea = false;
            this.tabMain.ItemSize = new System.Drawing.Size(0, 23);
            this.tabMain.Location = new System.Drawing.Point(1, 121);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(780, 489);
            this.tabMain.TabIndex = 3;
            // 
            // separator
            // 
            this.separator.Dock = System.Windows.Forms.DockStyle.Top;
            this.separator.IsVertical = false;
            this.separator.Location = new System.Drawing.Point(1, 31);
            this.separator.Name = "separator";
            this.separator.Size = new System.Drawing.Size(1030, 1);
            this.separator.TabIndex = 11;
            // 
            // separator1
            // 
            this.separator1.Dock = System.Windows.Forms.DockStyle.Top;
            this.separator1.IsVertical = false;
            this.separator1.Location = new System.Drawing.Point(1, 111);
            this.separator1.Name = "separator1";
            this.separator1.Size = new System.Drawing.Size(780, 10);
            this.separator1.TabIndex = 12;
            this.separator1.Text = "separator1";
            // 
            // topCharacter
            // 
            this.topCharacter.BackColor = System.Drawing.Color.Transparent;
            this.topCharacter.Dock = System.Windows.Forms.DockStyle.Top;
            this.topCharacter.Location = new System.Drawing.Point(1, 32);
            this.topCharacter.Margin = new System.Windows.Forms.Padding(4);
            this.topCharacter.Name = "topCharacter";
            this.topCharacter.Size = new System.Drawing.Size(780, 79);
            this.topCharacter.TabIndex = 7;
            // 
            // menuCurrentProfile
            // 
            this.menuCurrentProfile.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.menuCurrentProfile.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.menuCurrentProfile.Name = "menuCurrentProfile";
            this.menuCurrentProfile.Size = new System.Drawing.Size(97, 22);
            this.menuCurrentProfile.Text = "Profile: Default";
            this.menuCurrentProfile.Click += new System.EventHandler(this.menuSelectProfile_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.ClientSize = new System.Drawing.Size(1032, 685);
            this.Controls.Add(this.tabMain);
            this.Controls.Add(this.separator1);
            this.Controls.Add(this.topCharacter);
            this.Controls.Add(this.pSidebar);
            this.Controls.Add(this.bottomPanel);
            this.Controls.Add(this.separator);
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.stripStatus);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1048, 724);
            this.MinimumSize = new System.Drawing.Size(1048, 724);
            this.Name = "Main";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RSBot";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            this.Resize += new System.EventHandler(this.Main_Resize);
            this.stripStatus.ResumeLayout(false);
            this.stripStatus.PerformLayout();
            this.bottomPanel.ResumeLayout(false);
            this.pSidebar.ResumeLayout(false);
            this.pSidebar.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private Entity entity1;
        private SDUI.Controls.ComboBox comboServer;
        private SDUI.Controls.ComboBox comboDivision;
        private System.Windows.Forms.ToolStripDropDownButton menuBotbase;
        private System.Windows.Forms.ToolStripMenuItem botbase1ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem botbase1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
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
        private SDUI.Controls.MenuStrip menuStrip;
        private SDUI.Controls.TabControl tabMain;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem minimizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem themeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem darkToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lightToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem coloredToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem languageToolStripMenuItem;
        private SDUI.Controls.Separator separator;
        private SDUI.Controls.Separator separator1;
        private ToolStripMenuItem menuSelectProfile;
        private ToolStripMenuItem menuCurrentProfile;
    }
}

