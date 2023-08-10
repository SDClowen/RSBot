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
            cosController = new Controls.Cos.CosController();
            bottomPanel = new SDUI.Controls.Panel();
            buttonConfig = new SDUI.Controls.Button();
            comboServer = new SDUI.Controls.ComboBox();
            comboDivision = new SDUI.Controls.ComboBox();
            btnSave = new SDUI.Controls.Button();
            btnStartStop = new SDUI.Controls.Button();
            pSidebar = new SDUI.Controls.Panel();
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
            menuStrip = new SDUI.Controls.MenuStrip();
            toolStripMenuItem1 = new ToolStripMenuItem();
            closeToolStripMenuItem = new ToolStripMenuItem();
            minimizeToolStripMenuItem = new ToolStripMenuItem();
            mainMenuList = new ToolStripMenuItem();
            botsToolStripMenuItem = new ToolStripMenuItem();
            languageToolStripMenuItem = new ToolStripMenuItem();
            themeToolStripMenuItem = new ToolStripMenuItem();
            darkToolStripMenuItem = new ToolStripMenuItem();
            lightToolStripMenuItem = new ToolStripMenuItem();
            autoToolStripMenuItem = new ToolStripMenuItem();
            coloredToolStripMenuItem = new ToolStripMenuItem();
            donateButton = new ToolStripMenuItem();
            toolStripMenuItemTitle = new ToolStripMenuItem();
            tabMain = new SDUI.Controls.TabControl();
            separator = new SDUI.Controls.Separator();
            topCharacter = new Character();
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
            stripStatus.Location = new System.Drawing.Point(1, 747);
            stripStatus.Name = "stripStatus";
            stripStatus.Size = new System.Drawing.Size(1042, 22);
            stripStatus.SizingGrip = false;
            stripStatus.TabIndex = 0;
            stripStatus.Tag = "private";
            // 
            // lblIngameStatus
            // 
            lblIngameStatus.BackColor = System.Drawing.Color.Transparent;
            lblIngameStatus.ForeColor = System.Drawing.Color.White;
            lblIngameStatus.Name = "lblIngameStatus";
            lblIngameStatus.Size = new System.Drawing.Size(73, 17);
            lblIngameStatus.Text = "Not in game";
            // 
            // menuCurrentProfile
            // 
            menuCurrentProfile.Alignment = ToolStripItemAlignment.Right;
            menuCurrentProfile.ForeColor = System.Drawing.Color.White;
            menuCurrentProfile.Name = "menuCurrentProfile";
            menuCurrentProfile.Size = new System.Drawing.Size(97, 22);
            menuCurrentProfile.Text = "Profile: Default";
            menuCurrentProfile.Click += menuSelectProfile_Click;
            // 
            // cosController
            // 
            cosController.AutoSize = true;
            cosController.Dock = DockStyle.Top;
            cosController.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            cosController.Location = new System.Drawing.Point(0, 0);
            cosController.Name = "cosController";
            cosController.Padding = new Padding(3);
            cosController.Size = new System.Drawing.Size(250, 70);
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
            bottomPanel.Location = new System.Drawing.Point(1, 695);
            bottomPanel.Name = "bottomPanel";
            bottomPanel.Radius = 0;
            bottomPanel.ShadowDepth = 4F;
            bottomPanel.Size = new System.Drawing.Size(1042, 52);
            bottomPanel.TabIndex = 2;
            // 
            // buttonConfig
            // 
            buttonConfig.Color = System.Drawing.Color.Transparent;
            buttonConfig.Font = new System.Drawing.Font("Webdings", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            buttonConfig.Location = new System.Drawing.Point(249, 15);
            buttonConfig.Name = "buttonConfig";
            buttonConfig.Radius = 6;
            buttonConfig.ShadowDepth = 4F;
            buttonConfig.Size = new System.Drawing.Size(25, 23);
            buttonConfig.TabIndex = 12;
            buttonConfig.Text = "@";
            buttonConfig.UseVisualStyleBackColor = true;
            buttonConfig.Click += buttonConfig_Click;
            // 
            // comboServer
            // 
            comboServer.DrawMode = DrawMode.OwnerDrawFixed;
            comboServer.DropDownHeight = 100;
            comboServer.DropDownStyle = ComboBoxStyle.DropDownList;
            comboServer.FormattingEnabled = true;
            comboServer.IntegralHeight = false;
            comboServer.ItemHeight = 17;
            comboServer.Location = new System.Drawing.Point(111, 15);
            comboServer.Name = "comboServer";
            comboServer.Radius = 5;
            comboServer.ShadowDepth = 4F;
            comboServer.Size = new System.Drawing.Size(132, 23);
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
            comboDivision.Location = new System.Drawing.Point(14, 15);
            comboDivision.Name = "comboDivision";
            comboDivision.Radius = 5;
            comboDivision.ShadowDepth = 4F;
            comboDivision.Size = new System.Drawing.Size(91, 23);
            comboDivision.TabIndex = 10;
            comboDivision.SelectedIndexChanged += comboDivision_SelectedIndexChanged;
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSave.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnSave.Color = System.Drawing.Color.FromArgb(56, 155, 90);
            btnSave.Font = new System.Drawing.Font("Segoe UI Semibold", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnSave.ForeColor = System.Drawing.Color.White;
            btnSave.Location = new System.Drawing.Point(834, 12);
            btnSave.Name = "btnSave";
            btnSave.Radius = 6;
            btnSave.ShadowDepth = 4F;
            btnSave.Size = new System.Drawing.Size(95, 27);
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
            btnStartStop.BackColor = System.Drawing.Color.Transparent;
            btnStartStop.Color = System.Drawing.Color.FromArgb(33, 150, 243);
            btnStartStop.Font = new System.Drawing.Font("Segoe UI Semibold", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnStartStop.ForeColor = System.Drawing.Color.White;
            btnStartStop.Location = new System.Drawing.Point(935, 12);
            btnStartStop.Name = "btnStartStop";
            btnStartStop.Radius = 6;
            btnStartStop.ShadowDepth = 4F;
            btnStartStop.Size = new System.Drawing.Size(95, 27);
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
            pSidebar.Border = new Padding(1, 0, 0, 1);
            pSidebar.BorderColor = System.Drawing.Color.Transparent;
            pSidebar.Controls.Add(entity1);
            pSidebar.Controls.Add(cosController);
            pSidebar.Dock = DockStyle.Right;
            pSidebar.Location = new System.Drawing.Point(793, 33);
            pSidebar.Name = "pSidebar";
            pSidebar.Radius = 0;
            pSidebar.ShadowDepth = 0F;
            pSidebar.Size = new System.Drawing.Size(250, 662);
            pSidebar.TabIndex = 6;
            // 
            // entity1
            // 
            entity1.BackColor = System.Drawing.Color.Transparent;
            entity1.Dock = DockStyle.Top;
            entity1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            entity1.Location = new System.Drawing.Point(0, 70);
            entity1.Margin = new Padding(4);
            entity1.MinimumSize = new System.Drawing.Size(250, 76);
            entity1.Name = "entity1";
            entity1.Size = new System.Drawing.Size(250, 76);
            entity1.TabIndex = 2;
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
            fileToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            fileToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            fileToolStripMenuItem.Text = "File";
            // 
            // menuSelectProfile
            // 
            menuSelectProfile.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            menuSelectProfile.Name = "menuSelectProfile";
            menuSelectProfile.Size = new System.Drawing.Size(160, 22);
            menuSelectProfile.Text = "Select Profile...";
            menuSelectProfile.Click += menuSelectProfile_Click;
            // 
            // networkConfigToolStripMenuItem
            // 
            networkConfigToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            networkConfigToolStripMenuItem.Name = "networkConfigToolStripMenuItem";
            networkConfigToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            networkConfigToolStripMenuItem.Text = "Proxy Config";
            networkConfigToolStripMenuItem.Click += networkConfigToolStripMenuItem_Click;
            // 
            // menuItemExit
            // 
            menuItemExit.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            menuItemExit.Name = "menuItemExit";
            menuItemExit.Size = new System.Drawing.Size(160, 22);
            menuItemExit.Text = "Exit";
            menuItemExit.Click += menuItemExit_Click;
            // 
            // viewToolStripMenuItem
            // 
            viewToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { menuSidebar });
            viewToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            viewToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            viewToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            viewToolStripMenuItem.Text = "View";
            // 
            // menuSidebar
            // 
            menuSidebar.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            menuSidebar.Name = "menuSidebar";
            menuSidebar.Size = new System.Drawing.Size(121, 22);
            menuSidebar.Text = "Sidebar";
            menuSidebar.Click += menuSidebar_Click;
            // 
            // toolsToolStripMenuItem
            // 
            toolsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { menuScriptRecorder });
            toolsToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            toolsToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            toolsToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            toolsToolStripMenuItem.Text = "Tools";
            // 
            // menuScriptRecorder
            // 
            menuScriptRecorder.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            menuScriptRecorder.Name = "menuScriptRecorder";
            menuScriptRecorder.Size = new System.Drawing.Size(167, 22);
            menuScriptRecorder.Text = "Script Recorder";
            menuScriptRecorder.Click += menuScriptRecorder_Click;
            // 
            // menuPlugins
            // 
            menuPlugins.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            menuPlugins.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            menuPlugins.Name = "menuPlugins";
            menuPlugins.Size = new System.Drawing.Size(134, 22);
            menuPlugins.Text = "Plugins";
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { thisToolStripMenuItem });
            aboutToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            aboutToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            aboutToolStripMenuItem.Text = "About";
            // 
            // thisToolStripMenuItem
            // 
            thisToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            thisToolStripMenuItem.Name = "thisToolStripMenuItem";
            thisToolStripMenuItem.Size = new System.Drawing.Size(99, 22);
            thisToolStripMenuItem.Text = "This";
            thisToolStripMenuItem.Click += menuItemThis_Click;
            // 
            // menuStrip
            // 
            menuStrip.BackColor = System.Drawing.Color.FromArgb(0, 0, 0, 0);
            menuStrip.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            menuStrip.Items.AddRange(new ToolStripItem[] { toolStripMenuItem1, closeToolStripMenuItem, minimizeToolStripMenuItem, mainMenuList, donateButton, toolStripMenuItemTitle });
            menuStrip.Location = new System.Drawing.Point(1, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Padding = new Padding(6, 4, 6, 4);
            menuStrip.Size = new System.Drawing.Size(1042, 32);
            menuStrip.TabIndex = 10;
            menuStrip.MouseDown += menuStrip_MouseDown;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripMenuItem1.Image = Properties.Resources.app;
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new System.Drawing.Size(32, 24);
            // 
            // closeToolStripMenuItem
            // 
            closeToolStripMenuItem.Alignment = ToolStripItemAlignment.Right;
            closeToolStripMenuItem.Font = new System.Drawing.Font("Webdings", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            closeToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            closeToolStripMenuItem.Size = new System.Drawing.Size(33, 24);
            closeToolStripMenuItem.Tag = "";
            closeToolStripMenuItem.Text = "r";
            closeToolStripMenuItem.Click += closeToolStripMenuItem_Click;
            // 
            // minimizeToolStripMenuItem
            // 
            minimizeToolStripMenuItem.Alignment = ToolStripItemAlignment.Right;
            minimizeToolStripMenuItem.Font = new System.Drawing.Font("Webdings", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            minimizeToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            minimizeToolStripMenuItem.Name = "minimizeToolStripMenuItem";
            minimizeToolStripMenuItem.Size = new System.Drawing.Size(33, 24);
            minimizeToolStripMenuItem.Text = "0";
            minimizeToolStripMenuItem.Click += minimizeToolStripMenuItem_Click;
            // 
            // mainMenuList
            // 
            mainMenuList.Alignment = ToolStripItemAlignment.Right;
            mainMenuList.DropDownItems.AddRange(new ToolStripItem[] { fileToolStripMenuItem, viewToolStripMenuItem, toolsToolStripMenuItem, menuPlugins, botsToolStripMenuItem, languageToolStripMenuItem, themeToolStripMenuItem, aboutToolStripMenuItem });
            mainMenuList.Font = new System.Drawing.Font("Webdings", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            mainMenuList.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            mainMenuList.Name = "mainMenuList";
            mainMenuList.Size = new System.Drawing.Size(37, 24);
            mainMenuList.Text = "6";
            // 
            // botsToolStripMenuItem
            // 
            botsToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            botsToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            botsToolStripMenuItem.Name = "botsToolStripMenuItem";
            botsToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            botsToolStripMenuItem.Text = "Bots";
            // 
            // languageToolStripMenuItem
            // 
            languageToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            languageToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            languageToolStripMenuItem.Name = "languageToolStripMenuItem";
            languageToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            languageToolStripMenuItem.Text = "Language";
            // 
            // themeToolStripMenuItem
            // 
            themeToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { darkToolStripMenuItem, lightToolStripMenuItem, autoToolStripMenuItem, coloredToolStripMenuItem });
            themeToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            themeToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            themeToolStripMenuItem.Name = "themeToolStripMenuItem";
            themeToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            themeToolStripMenuItem.Text = "Theme";
            // 
            // darkToolStripMenuItem
            // 
            darkToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            darkToolStripMenuItem.Name = "darkToolStripMenuItem";
            darkToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            darkToolStripMenuItem.Text = "Dark";
            darkToolStripMenuItem.Click += darkToolStripMenuItem_Click;
            // 
            // lightToolStripMenuItem
            // 
            lightToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            lightToolStripMenuItem.Name = "lightToolStripMenuItem";
            lightToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            lightToolStripMenuItem.Text = "Light";
            lightToolStripMenuItem.Click += lightToolStripMenuItem_Click;
            // 
            // autoToolStripMenuItem
            // 
            autoToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            autoToolStripMenuItem.Name = "autoToolStripMenuItem";
            autoToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            autoToolStripMenuItem.Text = "Auto";
            autoToolStripMenuItem.Click += autoToolStripMenuItem_Click;
            // 
            // coloredToolStripMenuItem
            // 
            coloredToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            coloredToolStripMenuItem.Name = "coloredToolStripMenuItem";
            coloredToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            coloredToolStripMenuItem.Text = "Choose a color";
            coloredToolStripMenuItem.Click += coloredToolStripMenuItem_Click;
            // 
            // donateButton
            // 
            donateButton.Alignment = ToolStripItemAlignment.Right;
            donateButton.BackColor = System.Drawing.Color.Goldenrod;
            donateButton.Font = new System.Drawing.Font("Segoe UI Semibold", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            donateButton.ForeColor = System.Drawing.Color.White;
            donateButton.Name = "donateButton";
            donateButton.Size = new System.Drawing.Size(64, 24);
            donateButton.Tag = "private";
            donateButton.Text = "Donate";
            donateButton.Click += donateButton_Click;
            // 
            // toolStripMenuItemTitle
            // 
            toolStripMenuItemTitle.Enabled = false;
            toolStripMenuItemTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            toolStripMenuItemTitle.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            toolStripMenuItemTitle.Name = "toolStripMenuItemTitle";
            toolStripMenuItemTitle.Size = new System.Drawing.Size(56, 24);
            toolStripMenuItemTitle.Text = "RSBot";
            // 
            // tabMain
            // 
            tabMain.Dock = DockStyle.Fill;
            tabMain.DrawMode = TabDrawMode.OwnerDrawFixed;
            tabMain.ItemSize = new System.Drawing.Size(80, 24);
            tabMain.Location = new System.Drawing.Point(1, 112);
            tabMain.Name = "tabMain";
            tabMain.Radius = new Padding(4, 4, 0, 0);
            tabMain.SelectedIndex = 0;
            tabMain.Size = new System.Drawing.Size(792, 583);
            tabMain.TabIndex = 3;
            tabMain.Selecting += tabMain_Selecting;
            // 
            // separator
            // 
            separator.Dock = DockStyle.Top;
            separator.IsVertical = false;
            separator.Location = new System.Drawing.Point(1, 32);
            separator.Name = "separator";
            separator.Size = new System.Drawing.Size(1042, 1);
            separator.TabIndex = 11;
            // 
            // topCharacter
            // 
            topCharacter.BackColor = System.Drawing.Color.Transparent;
            topCharacter.Dock = DockStyle.Top;
            topCharacter.Font = new System.Drawing.Font("Segoe UI", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            topCharacter.Location = new System.Drawing.Point(1, 33);
            topCharacter.Margin = new Padding(4);
            topCharacter.Name = "topCharacter";
            topCharacter.Size = new System.Drawing.Size(792, 79);
            topCharacter.TabIndex = 7;
            // 
            // Main
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = System.Drawing.Color.FromArgb(249, 249, 249);
            ClientSize = new System.Drawing.Size(1044, 770);
            Controls.Add(tabMain);
            Controls.Add(topCharacter);
            Controls.Add(pSidebar);
            Controls.Add(bottomPanel);
            Controls.Add(separator);
            Controls.Add(menuStrip);
            Controls.Add(stripStatus);
            Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            ForeColor = System.Drawing.Color.Black;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Location = new System.Drawing.Point(0, 0);
            MainMenuStrip = menuStrip;
            MaximizeBox = false;
            MaximumSize = new System.Drawing.Size(1048, 770);
            MinimumSize = new System.Drawing.Size(1022, 726);
            Name = "Main";
            Padding = new Padding(1, 0, 1, 1);
            ShowTitle = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "RSBot";
            FormClosing += Main_FormClosing;
            Load += Main_Load;
            Resize += Main_Resize;
            stripStatus.ResumeLayout(false);
            stripStatus.PerformLayout();
            bottomPanel.ResumeLayout(false);
            pSidebar.ResumeLayout(false);
            pSidebar.PerformLayout();
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private StatusStrip stripStatus;
        private SDUI.Controls.Panel bottomPanel;
        private SDUI.Controls.Panel pSidebar;
        private ToolStripStatusLabel lblIngameStatus;
        private SDUI.Controls.Button btnStartStop;
        private SDUI.Controls.Button btnSave;
        private Controls.Character topCharacter;
        private Controls.Cos.CosController cosController;
        private Entity entity1;
        private SDUI.Controls.ComboBox comboServer;
        private SDUI.Controls.ComboBox comboDivision;
        private ToolStripMenuItem botbase1ToolStripMenuItem1;
        private ToolStripMenuItem botbase1ToolStripMenuItem;
        private NotifyIcon notifyIcon;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem menuItemExit;
        private ToolStripMenuItem viewToolStripMenuItem;
        private ToolStripMenuItem menuSidebar;
        private ToolStripMenuItem toolsToolStripMenuItem;
        private ToolStripMenuItem menuScriptRecorder;
        private ToolStripMenuItem menuPlugins;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private ToolStripMenuItem thisToolStripMenuItem;
        private SDUI.Controls.MenuStrip menuStrip;
        private SDUI.Controls.TabControl tabMain;
        private ToolStripMenuItem closeToolStripMenuItem;
        private ToolStripMenuItem minimizeToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem themeToolStripMenuItem;
        private ToolStripMenuItem darkToolStripMenuItem;
        private ToolStripMenuItem lightToolStripMenuItem;
        private ToolStripMenuItem coloredToolStripMenuItem;
        private ToolStripMenuItem languageToolStripMenuItem;
        private SDUI.Controls.Separator separator;
        private ToolStripMenuItem menuSelectProfile;
        private ToolStripMenuItem menuCurrentProfile;
        private ToolStripMenuItem botsToolStripMenuItem;
        private ToolStripMenuItem autoToolStripMenuItem;
        private SDUI.Controls.Button buttonConfig;
        private ToolStripMenuItem networkConfigToolStripMenuItem;
        private ToolStripMenuItem donateButton;
        private ToolStripMenuItem mainMenuList;
        private ToolStripMenuItem toolStripMenuItemTitle;
    }
}

