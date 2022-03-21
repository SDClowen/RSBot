using RSBot.Views.Controls;

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
            this.toolStripStatusLabelBeta = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.comboServer = new System.Windows.Forms.ComboBox();
            this.comboDivision = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnStartStop = new System.Windows.Forms.Button();
            this.pSidebar = new System.Windows.Forms.Panel();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.entity1 = new RSBot.Views.Controls.Entity();
            this.pet1 = new RSBot.Views.Controls.Pet();
            this.panel8 = new System.Windows.Forms.Panel();
            this.linkHideSidebar = new System.Windows.Forms.LinkLabel();
            this.botbase1ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.botbase1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSidebar = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuScriptRecorder = new System.Windows.Forms.ToolStripMenuItem();
            this.menuPlugins = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.topCharacter = new RSBot.Views.Controls.Character();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.stripStatus.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pSidebar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.panel8.SuspendLayout();
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
            this.lblIngameStatus,
            this.toolStripStatusLabelBeta});
            this.stripStatus.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.stripStatus.Location = new System.Drawing.Point(0, 593);
            this.stripStatus.Name = "stripStatus";
            this.stripStatus.Size = new System.Drawing.Size(1032, 23);
            this.stripStatus.SizingGrip = false;
            this.stripStatus.TabIndex = 0;
            // 
            // menuBotbase
            // 
            this.menuBotbase.ForeColor = System.Drawing.Color.White;
            this.menuBotbase.Image = global::RSBot.Properties.Resources.botbase_error;
            this.menuBotbase.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menuBotbase.Name = "menuBotbase";
            this.menuBotbase.ShowDropDownArrow = false;
            this.menuBotbase.Size = new System.Drawing.Size(124, 21);
            this.menuBotbase.Text = "No botbase found";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.ForeColor = System.Drawing.Color.White;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(16, 18);
            this.toolStripStatusLabel1.Text = " | ";
            // 
            // lblIngameStatus
            // 
            this.lblIngameStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblIngameStatus.ForeColor = System.Drawing.Color.White;
            this.lblIngameStatus.Name = "lblIngameStatus";
            this.lblIngameStatus.Size = new System.Drawing.Size(73, 18);
            this.lblIngameStatus.Text = "Not in game";
            // 
            // toolStripStatusLabelBeta
            // 
            this.toolStripStatusLabelBeta.BackColor = System.Drawing.Color.Red;
            this.toolStripStatusLabelBeta.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabelBeta.ForeColor = System.Drawing.Color.White;
            this.toolStripStatusLabelBeta.Margin = new System.Windows.Forms.Padding(0);
            this.toolStripStatusLabelBeta.Name = "toolStripStatusLabelBeta";
            this.toolStripStatusLabelBeta.Size = new System.Drawing.Size(38, 23);
            this.toolStripStatusLabelBeta.Text = "BETA";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.comboServer);
            this.panel1.Controls.Add(this.comboDivision);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.btnStartStop);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 541);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1032, 52);
            this.panel1.TabIndex = 2;
            // 
            // comboServer
            // 
            this.comboServer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboServer.FormattingEnabled = true;
            this.comboServer.Location = new System.Drawing.Point(109, 18);
            this.comboServer.Name = "comboServer";
            this.comboServer.Size = new System.Drawing.Size(132, 23);
            this.comboServer.TabIndex = 11;
            this.comboServer.SelectedIndexChanged += new System.EventHandler(this.comboServer_SelectedIndexChanged);
            // 
            // comboDivision
            // 
            this.comboDivision.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboDivision.FormattingEnabled = true;
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
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.btnSave.Location = new System.Drawing.Point(824, 16);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(95, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.TabStop = false;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnStartStop
            // 
            this.btnStartStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStartStop.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnStartStop.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnStartStop.Location = new System.Drawing.Point(925, 16);
            this.btnStartStop.Name = "btnStartStop";
            this.btnStartStop.Size = new System.Drawing.Size(95, 23);
            this.btnStartStop.TabIndex = 0;
            this.btnStartStop.TabStop = false;
            this.btnStartStop.Text = "START BOT";
            this.btnStartStop.UseVisualStyleBackColor = false;
            this.btnStartStop.Click += new System.EventHandler(this.btnStartStop_Click);
            // 
            // pSidebar
            // 
            this.pSidebar.BackColor = System.Drawing.Color.Transparent;
            this.pSidebar.Controls.Add(this.picLogo);
            this.pSidebar.Controls.Add(this.entity1);
            this.pSidebar.Controls.Add(this.pet1);
            this.pSidebar.Controls.Add(this.panel8);
            this.pSidebar.Dock = System.Windows.Forms.DockStyle.Right;
            this.pSidebar.Location = new System.Drawing.Point(782, 0);
            this.pSidebar.Name = "pSidebar";
            this.pSidebar.Size = new System.Drawing.Size(250, 541);
            this.pSidebar.TabIndex = 6;
            // 
            // picLogo
            // 
            this.picLogo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picLogo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.picLogo.Image = ((System.Drawing.Image)(resources.GetObject("picLogo.Image")));
            this.picLogo.Location = new System.Drawing.Point(0, 447);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(250, 94);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picLogo.TabIndex = 8;
            this.picLogo.TabStop = false;
            this.picLogo.Click += new System.EventHandler(this.picLogo_Click);
            // 
            // entity1
            // 
            this.entity1.Dock = System.Windows.Forms.DockStyle.Top;
            this.entity1.Location = new System.Drawing.Point(0, 129);
            this.entity1.Margin = new System.Windows.Forms.Padding(4);
            this.entity1.Name = "entity1";
            this.entity1.Size = new System.Drawing.Size(250, 70);
            this.entity1.TabIndex = 2;
            // 
            // pet1
            // 
            this.pet1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pet1.Location = new System.Drawing.Point(0, 19);
            this.pet1.Margin = new System.Windows.Forms.Padding(4);
            this.pet1.Name = "pet1";
            this.pet1.Size = new System.Drawing.Size(250, 110);
            this.pet1.TabIndex = 0;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.linkHideSidebar);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel8.Location = new System.Drawing.Point(0, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(250, 19);
            this.panel8.TabIndex = 1;
            // 
            // linkHideSidebar
            // 
            this.linkHideSidebar.AutoSize = true;
            this.linkHideSidebar.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkHideSidebar.LinkColor = System.Drawing.Color.Blue;
            this.linkHideSidebar.Location = new System.Drawing.Point(169, 2);
            this.linkHideSidebar.Name = "linkHideSidebar";
            this.linkHideSidebar.Size = new System.Drawing.Size(73, 15);
            this.linkHideSidebar.TabIndex = 0;
            this.linkHideSidebar.TabStop = true;
            this.linkHideSidebar.Text = "Hide sidebar";
            this.linkHideSidebar.Click += new System.EventHandler(this.menuSidebar_Click);
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
            this.menuItemExit});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // menuItemExit
            // 
            this.menuItemExit.Name = "menuItemExit";
            this.menuItemExit.Size = new System.Drawing.Size(93, 22);
            this.menuItemExit.Text = "Exit";
            this.menuItemExit.Click += new System.EventHandler(this.menuItemExit_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuSidebar});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
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
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // menuScriptRecorder
            // 
            this.menuScriptRecorder.Name = "menuScriptRecorder";
            this.menuScriptRecorder.Size = new System.Drawing.Size(154, 22);
            this.menuScriptRecorder.Text = "Script Recorder";
            this.menuScriptRecorder.Click += new System.EventHandler(this.menuScriptRecorder_Click);
            // 
            // menuPlugins
            // 
            this.menuPlugins.Name = "menuPlugins";
            this.menuPlugins.Size = new System.Drawing.Size(58, 20);
            this.menuPlugins.Text = "Plugins";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thisToolStripMenuItem});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // thisToolStripMenuItem
            // 
            this.thisToolStripMenuItem.Name = "thisToolStripMenuItem";
            this.thisToolStripMenuItem.Size = new System.Drawing.Size(95, 22);
            this.thisToolStripMenuItem.Text = "This";
            this.thisToolStripMenuItem.Click += new System.EventHandler(this.menuItemThis_Click);
            // 
            // topCharacter
            // 
            this.topCharacter.BackColor = System.Drawing.Color.White;
            this.topCharacter.Dock = System.Windows.Forms.DockStyle.Top;
            this.topCharacter.Location = new System.Drawing.Point(0, 24);
            this.topCharacter.Margin = new System.Windows.Forms.Padding(4);
            this.topCharacter.Name = "topCharacter";
            this.topCharacter.Size = new System.Drawing.Size(782, 79);
            this.topCharacter.TabIndex = 7;
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.menuPlugins,
            this.aboutToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip.Size = new System.Drawing.Size(782, 24);
            this.menuStrip.TabIndex = 10;
            this.menuStrip.Text = "menuStrip1";
            // 
            // tabMain
            // 
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.ItemSize = new System.Drawing.Size(0, 23);
            this.tabMain.Location = new System.Drawing.Point(0, 103);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(782, 438);
            this.tabMain.TabIndex = 3;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1032, 616);
            this.Controls.Add(this.tabMain);
            this.Controls.Add(this.topCharacter);
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.pSidebar);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.stripStatus);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.MaximumSize = new System.Drawing.Size(1048, 724);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RSBot";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            this.Resize += new System.EventHandler(this.Main_Resize);
            this.stripStatus.ResumeLayout(false);
            this.stripStatus.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.pSidebar.ResumeLayout(false);
            this.pSidebar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.StatusStrip stripStatus;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pSidebar;
        private System.Windows.Forms.ToolStripStatusLabel lblIngameStatus;
        private System.Windows.Forms.Button btnStartStop;
        private System.Windows.Forms.Button btnSave;
        private Controls.Character topCharacter;
        private Controls.Pet pet1;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.LinkLabel linkHideSidebar;
        private Entity entity1;
        private System.Windows.Forms.ComboBox comboServer;
        private System.Windows.Forms.ComboBox comboDivision;
        private System.Windows.Forms.ToolStripDropDownButton menuBotbase;
        private System.Windows.Forms.ToolStripMenuItem botbase1ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem botbase1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelBeta;
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
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.TabControl tabMain;
    }
}

