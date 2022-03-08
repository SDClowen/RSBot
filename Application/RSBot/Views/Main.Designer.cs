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
            this.menuMain = new System.Windows.Forms.MainMenu(this.components);
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.topmenuItemExit = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.menuSidebar = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.menuScriptRecorder = new System.Windows.Forms.MenuItem();
            this.menuPlugins = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.stripStatus = new System.Windows.Forms.StatusStrip();
            this.menuBotbase = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblIngameStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelBeta = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.comboServer = new System.Windows.Forms.ComboBox();
            this.comboDivision = new System.Windows.Forms.ComboBox();
            this.btnSave = new RSBot.Theme.Material.Button();
            this.btnStartStop = new RSBot.Theme.Material.Button();
            this.panel7 = new System.Windows.Forms.Panel();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pSidebar = new System.Windows.Forms.Panel();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.entity1 = new RSBot.Views.Controls.Entity();
            this.pet1 = new RSBot.Views.Controls.Pet();
            this.panel8 = new System.Windows.Forms.Panel();
            this.linkHideSidebar = new System.Windows.Forms.LinkLabel();
            this.botbase1ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.botbase1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.centerPanel = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.topCharacter = new RSBot.Views.Controls.Character();
            this.menuItemThis = new System.Windows.Forms.MenuItem();
            this.stripStatus.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pSidebar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.panel8.SuspendLayout();
            this.centerPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuMain
            // 
            this.menuMain.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem1,
            this.menuItem2,
            this.menuItem4,
            this.menuPlugins,
            this.menuItem3});
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 0;
            this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.topmenuItemExit});
            this.menuItem1.Text = "File";
            // 
            // topmenuItemExit
            // 
            this.topmenuItemExit.Index = 0;
            this.topmenuItemExit.Text = "Exit";
            this.topmenuItemExit.Click += new System.EventHandler(this.menuItemExit_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 1;
            this.menuItem2.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuSidebar});
            this.menuItem2.Text = "View";
            // 
            // menuSidebar
            // 
            this.menuSidebar.Checked = true;
            this.menuSidebar.Index = 0;
            this.menuSidebar.Text = "Sidebar";
            this.menuSidebar.Click += new System.EventHandler(this.menuSidebar_Click);
            // 
            // menuItem4
            // 
            this.menuItem4.Index = 2;
            this.menuItem4.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuScriptRecorder});
            this.menuItem4.Text = "Tools";
            // 
            // menuScriptRecorder
            // 
            this.menuScriptRecorder.Index = 0;
            this.menuScriptRecorder.Text = "Script Recorder";
            this.menuScriptRecorder.Click += new System.EventHandler(this.menuScriptRecorder_Click);
            // 
            // menuPlugins
            // 
            this.menuPlugins.Index = 3;
            this.menuPlugins.Text = "Plugins";
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 4;
            this.menuItem3.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemThis});
            this.menuItem3.Text = "About";
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
            this.stripStatus.Location = new System.Drawing.Point(0, 578);
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
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.panel1.Controls.Add(this.comboServer);
            this.panel1.Controls.Add(this.comboDivision);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.btnStartStop);
            this.panel1.Controls.Add(this.panel7);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 526);
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
            this.comboServer.Size = new System.Drawing.Size(132, 21);
            this.comboServer.TabIndex = 11;
            this.comboServer.SelectedIndexChanged += new System.EventHandler(this.comboServer_SelectedIndexChanged);
            // 
            // comboDivision
            // 
            this.comboDivision.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboDivision.FormattingEnabled = true;
            this.comboDivision.Location = new System.Drawing.Point(12, 18);
            this.comboDivision.Name = "comboDivision";
            this.comboDivision.Size = new System.Drawing.Size(91, 21);
            this.comboDivision.TabIndex = 10;
            this.comboDivision.SelectedIndexChanged += new System.EventHandler(this.comboDivision_SelectedIndexChanged);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.btnSave.Depth = 0;
            this.btnSave.Icon = null;
            this.btnSave.Location = new System.Drawing.Point(824, 16);
            this.btnSave.MouseState = RSBot.Theme.IMatMouseState.HOVER;
            this.btnSave.Name = "btnSave";
            this.btnSave.Primary = false;
            this.btnSave.Raised = false;
            this.btnSave.SingleColor = System.Drawing.Color.Empty;
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
            this.btnStartStop.Depth = 0;
            this.btnStartStop.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnStartStop.Icon = null;
            this.btnStartStop.Location = new System.Drawing.Point(925, 16);
            this.btnStartStop.MouseState = RSBot.Theme.IMatMouseState.HOVER;
            this.btnStartStop.Name = "btnStartStop";
            this.btnStartStop.Primary = true;
            this.btnStartStop.Raised = true;
            this.btnStartStop.SingleColor = System.Drawing.Color.Empty;
            this.btnStartStop.Size = new System.Drawing.Size(95, 23);
            this.btnStartStop.TabIndex = 0;
            this.btnStartStop.TabStop = false;
            this.btnStartStop.Text = "START BOT";
            this.btnStartStop.UseVisualStyleBackColor = false;
            this.btnStartStop.Click += new System.EventHandler(this.btnStartStop_Click);
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(1032, 2);
            this.panel7.TabIndex = 7;
            // 
            // tabMain
            // 
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.ItemSize = new System.Drawing.Size(0, 23);
            this.tabMain.Location = new System.Drawing.Point(6, 3);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(773, 437);
            this.tabMain.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 81);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1032, 2);
            this.panel2.TabIndex = 4;
            // 
            // pSidebar
            // 
            this.pSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.pSidebar.Controls.Add(this.picLogo);
            this.pSidebar.Controls.Add(this.entity1);
            this.pSidebar.Controls.Add(this.pet1);
            this.pSidebar.Controls.Add(this.panel8);
            this.pSidebar.Dock = System.Windows.Forms.DockStyle.Right;
            this.pSidebar.Location = new System.Drawing.Point(782, 83);
            this.pSidebar.Name = "pSidebar";
            this.pSidebar.Size = new System.Drawing.Size(250, 443);
            this.pSidebar.TabIndex = 6;
            // 
            // picLogo
            // 
            this.picLogo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picLogo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.picLogo.Image = ((System.Drawing.Image)(resources.GetObject("picLogo.Image")));
            this.picLogo.Location = new System.Drawing.Point(0, 349);
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
            this.linkHideSidebar.Location = new System.Drawing.Point(169, 2);
            this.linkHideSidebar.Name = "linkHideSidebar";
            this.linkHideSidebar.Size = new System.Drawing.Size(72, 13);
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
            // centerPanel
            // 
            this.centerPanel.Controls.Add(this.tabMain);
            this.centerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.centerPanel.Location = new System.Drawing.Point(0, 83);
            this.centerPanel.Name = "centerPanel";
            this.centerPanel.Padding = new System.Windows.Forms.Padding(6, 3, 3, 3);
            this.centerPanel.Size = new System.Drawing.Size(782, 443);
            this.centerPanel.TabIndex = 9;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1032, 2);
            this.panel3.TabIndex = 10;
            this.panel3.Visible = false;
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
            // topCharacter
            // 
            this.topCharacter.Dock = System.Windows.Forms.DockStyle.Top;
            this.topCharacter.Location = new System.Drawing.Point(0, 2);
            this.topCharacter.Margin = new System.Windows.Forms.Padding(4);
            this.topCharacter.Name = "topCharacter";
            this.topCharacter.Size = new System.Drawing.Size(1032, 79);
            this.topCharacter.TabIndex = 7;
            // 
            // menuItemThis
            // 
            this.menuItemThis.Index = 0;
            this.menuItemThis.Text = "This";
            this.menuItemThis.Click += new System.EventHandler(this.menuItemThis_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1032, 601);
            this.Controls.Add(this.centerPanel);
            this.Controls.Add(this.pSidebar);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.topCharacter);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.stripStatus);
            this.Controls.Add(this.panel3);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1048, 724);
            this.Menu = this.menuMain;
            this.Name = "Main";
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
            this.centerPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MainMenu menuMain;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem menuItem2;
        private System.Windows.Forms.MenuItem menuItem3;
        private System.Windows.Forms.StatusStrip stripStatus;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel pSidebar;
        private System.Windows.Forms.ToolStripStatusLabel lblIngameStatus;
        private Theme.Material.Button btnStartStop;
        private Theme.Material.Button btnSave;
        private Controls.Character topCharacter;
        private Controls.Pet pet1;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.LinkLabel linkHideSidebar;
        private Entity entity1;
        private System.Windows.Forms.MenuItem menuSidebar;
        private System.Windows.Forms.ComboBox comboServer;
        private System.Windows.Forms.ComboBox comboDivision;
        private System.Windows.Forms.ToolStripDropDownButton menuBotbase;
        private System.Windows.Forms.ToolStripMenuItem botbase1ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem botbase1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.MenuItem menuItem4;
        private System.Windows.Forms.MenuItem menuScriptRecorder;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.MenuItem menuPlugins;
        private System.Windows.Forms.Panel centerPanel;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelBeta;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.MenuItem topmenuItemExit;
        private System.Windows.Forms.MenuItem menuItemThis;
    }
}

