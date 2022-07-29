namespace RSBot.Party.Views
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
            this.tabMain = new SDUI.Controls.TabControl();
            this.tabCurrentParty = new System.Windows.Forms.TabPage();
            this.listParty = new SDUI.Controls.ListView();
            this.colMemberName = new System.Windows.Forms.ColumnHeader();
            this.colLevel = new System.Windows.Forms.ColumnHeader();
            this.colGuild = new System.Windows.Forms.ColumnHeader();
            this.colMasteries = new System.Windows.Forms.ColumnHeader();
            this.colLocation = new System.Windows.Forms.ColumnHeader();
            this.contextParty = new SDUI.Controls.ContextMenuStrip();
            this.menuBanish = new System.Windows.Forms.ToolStripMenuItem();
            this.menuLeave = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemAddToBuffing = new System.Windows.Forms.ToolStripMenuItem();
            this.separator3 = new SDUI.Controls.Separator();
            this.panel1 = new SDUI.Controls.Panel();
            this.btnLeaveParty = new SDUI.Controls.Button();
            this.label1 = new SDUI.Controls.Label();
            this.lblLeader = new SDUI.Controls.Label();
            this.grpPartySettings = new SDUI.Controls.GroupBox();
            this.checkCurrentAllowInvitations = new SDUI.Controls.CheckBox();
            this.checkCurrentAutoShareItems = new SDUI.Controls.CheckBox();
            this.checkCurrentAutoShareEXP = new SDUI.Controls.CheckBox();
            this.tpAutoParty = new System.Windows.Forms.TabPage();
            this.groupBox2 = new SDUI.Controls.GroupBox();
            this.labelCommandsInfo = new SDUI.Controls.Label();
            this.separator2 = new SDUI.Controls.Separator();
            this.separator1 = new SDUI.Controls.Separator();
            this.textBoxLeaveIfMasterNotName = new SDUI.Controls.TextBox();
            this.checkBoxListenCommandsOnlyList = new SDUI.Controls.CheckBox();
            this.checkBoxListenMasterCommands = new SDUI.Controls.CheckBox();
            this.checkBoxLeaveIfMasterNot = new SDUI.Controls.CheckBox();
            this.checkAcceptIfBotStopped = new SDUI.Controls.CheckBox();
            this.checkAcceptAtTrainingPlace = new SDUI.Controls.CheckBox();
            this.label2 = new SDUI.Controls.Label();
            this.checkInviteFromList = new SDUI.Controls.CheckBox();
            this.checkInviteAll = new SDUI.Controls.CheckBox();
            this.checkAcceptFromList = new SDUI.Controls.CheckBox();
            this.checkAcceptAll = new SDUI.Controls.CheckBox();
            this.separator6 = new SDUI.Controls.Separator();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox7 = new SDUI.Controls.GroupBox();
            this.listCommandPlayers = new SDUI.Controls.ListView();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.panel4 = new SDUI.Controls.Panel();
            this.buttonCommandPlayerAdd = new SDUI.Controls.Button();
            this.buttonCommandPlayerRemove = new SDUI.Controls.Button();
            this.separator4 = new SDUI.Controls.Separator();
            this.groupBox3 = new SDUI.Controls.GroupBox();
            this.listAutoParty = new SDUI.Controls.ListView();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.panel3 = new SDUI.Controls.Panel();
            this.btnAddToAutoParty = new SDUI.Controls.Button();
            this.btnRemoveFromAutoParty = new SDUI.Controls.Button();
            this.separator5 = new SDUI.Controls.Separator();
            this.grbAutoPartySettings = new SDUI.Controls.GroupBox();
            this.checkAutoAllowInvitations = new SDUI.Controls.CheckBox();
            this.checkAutoItemAutoShare = new SDUI.Controls.CheckBox();
            this.checkAutoExpAutoShare = new SDUI.Controls.CheckBox();
            this.tpPartyMatching = new System.Windows.Forms.TabPage();
            this.lvPartyMatching = new SDUI.Controls.ListView();
            this.chPartyMatchNo = new System.Windows.Forms.ColumnHeader();
            this.chPartyMatchRace = new System.Windows.Forms.ColumnHeader();
            this.chPartyMatchName = new System.Windows.Forms.ColumnHeader();
            this.chPartyMatchTitle = new System.Windows.Forms.ColumnHeader();
            this.chPartyMatchPurporse = new System.Windows.Forms.ColumnHeader();
            this.chPartyMatchMember = new System.Windows.Forms.ColumnHeader();
            this.chPartyMatchRange = new System.Windows.Forms.ColumnHeader();
            this.topPartyPanel = new SDUI.Controls.Panel();
            this.btnPartyRefresh = new SDUI.Controls.Button();
            this.btnPartySearch = new SDUI.Controls.Button();
            this.nudPartySearchMax = new SDUI.Controls.NumUpDown();
            this.nudPartySearchMin = new SDUI.Controls.NumUpDown();
            this.cbPartySearchPurpose = new SDUI.Controls.ComboBox();
            this.tbPartySearchName = new SDUI.Controls.TextBox();
            this.label6 = new SDUI.Controls.Label();
            this.label5 = new SDUI.Controls.Label();
            this.label4 = new SDUI.Controls.Label();
            this.label3 = new SDUI.Controls.Label();
            this.bottomPartyPanel = new SDUI.Controls.Panel();
            this.btnPartyMatchDeleteEntry = new SDUI.Controls.Button();
            this.btnPartyMatchChangeEntry = new SDUI.Controls.Button();
            this.btnPartyMatchForm = new SDUI.Controls.Button();
            this.btnAutoMatchParty = new SDUI.Controls.Button();
            this.btnWhisperPartyMaster = new SDUI.Controls.Button();
            this.btnJoinFormedParty = new SDUI.Controls.Button();
            this.btnPrev = new SDUI.Controls.Button();
            this.btnNext = new SDUI.Controls.Button();
            this.lbl_partyPageRange = new SDUI.Controls.Label();
            this.tpPartyBuffing = new System.Windows.Forms.TabPage();
            this.groupBox4 = new SDUI.Controls.GroupBox();
            this.btnAddBuffToMember = new SDUI.Controls.Button();
            this.buttonRemoveCharFromBuffing = new SDUI.Controls.Button();
            this.btnRemoveBuffFromMember = new SDUI.Controls.Button();
            this.listViewPartyMembers = new SDUI.Controls.ListView();
            this.chPlayerName = new System.Windows.Forms.ColumnHeader();
            this.chPlayerLevel = new System.Windows.Forms.ColumnHeader();
            this.separator9 = new SDUI.Controls.Separator();
            this.groupBox6 = new SDUI.Controls.GroupBox();
            this.buttonAddGroup = new SDUI.Controls.Button();
            this.buttonRemoveGroup = new SDUI.Controls.Button();
            this.listViewGroups = new SDUI.Controls.ListView();
            this.columnHeaderGroupName = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderMembersCount = new System.Windows.Forms.ColumnHeader();
            this.separator8 = new SDUI.Controls.Separator();
            this.groupBox5 = new SDUI.Controls.GroupBox();
            this.selectedMemberBuffs = new SDUI.Controls.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.separator7 = new SDUI.Controls.Separator();
            this.groupBox1 = new SDUI.Controls.GroupBox();
            this.listPartyBuffSkills = new SDUI.Controls.ListView();
            this.columnName = new System.Windows.Forms.ColumnHeader();
            this.columnLimit = new System.Windows.Forms.ColumnHeader();
            this.panel5 = new SDUI.Controls.Panel();
            this.checkHideLowerLevelSkills = new SDUI.Controls.CheckBox();
            this.tabMain.SuspendLayout();
            this.tabCurrentParty.SuspendLayout();
            this.contextParty.SuspendLayout();
            this.panel1.SuspendLayout();
            this.grpPartySettings.SuspendLayout();
            this.tpAutoParty.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.panel4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel3.SuspendLayout();
            this.grbAutoPartySettings.SuspendLayout();
            this.tpPartyMatching.SuspendLayout();
            this.topPartyPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPartySearchMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPartySearchMin)).BeginInit();
            this.bottomPartyPanel.SuspendLayout();
            this.tpPartyBuffing.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabMain
            // 
            this.tabMain.Border = new System.Windows.Forms.Padding(1);
            this.tabMain.Controls.Add(this.tabCurrentParty);
            this.tabMain.Controls.Add(this.tpAutoParty);
            this.tabMain.Controls.Add(this.tpPartyMatching);
            this.tabMain.Controls.Add(this.tpPartyBuffing);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.HideTabArea = false;
            this.tabMain.Location = new System.Drawing.Point(0, 0);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(754, 467);
            this.tabMain.TabIndex = 0;
            this.tabMain.SelectedIndexChanged += new System.EventHandler(this.tabMain_SelectedIndexChanged);
            // 
            // tabCurrentParty
            // 
            this.tabCurrentParty.BackColor = System.Drawing.Color.White;
            this.tabCurrentParty.Controls.Add(this.listParty);
            this.tabCurrentParty.Controls.Add(this.separator3);
            this.tabCurrentParty.Controls.Add(this.panel1);
            this.tabCurrentParty.Controls.Add(this.grpPartySettings);
            this.tabCurrentParty.Location = new System.Drawing.Point(4, 24);
            this.tabCurrentParty.Name = "tabCurrentParty";
            this.tabCurrentParty.Padding = new System.Windows.Forms.Padding(3);
            this.tabCurrentParty.Size = new System.Drawing.Size(746, 439);
            this.tabCurrentParty.TabIndex = 0;
            this.tabCurrentParty.Text = "Party";
            // 
            // listParty
            // 
            this.listParty.BackColor = System.Drawing.Color.White;
            this.listParty.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listParty.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colMemberName,
            this.colLevel,
            this.colGuild,
            this.colMasteries,
            this.colLocation});
            this.listParty.ContextMenuStrip = this.contextParty;
            this.listParty.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listParty.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.listParty.FullRowSelect = true;
            this.listParty.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listParty.Location = new System.Drawing.Point(3, 93);
            this.listParty.MultiSelect = false;
            this.listParty.Name = "listParty";
            this.listParty.Size = new System.Drawing.Size(740, 311);
            this.listParty.TabIndex = 0;
            this.listParty.UseCompatibleStateImageBehavior = false;
            this.listParty.View = System.Windows.Forms.View.Details;
            // 
            // colMemberName
            // 
            this.colMemberName.Text = "Name";
            this.colMemberName.Width = 158;
            // 
            // colLevel
            // 
            this.colLevel.Text = "Level";
            this.colLevel.Width = 47;
            // 
            // colGuild
            // 
            this.colGuild.Text = "Guild";
            this.colGuild.Width = 145;
            // 
            // colMasteries
            // 
            this.colMasteries.Text = "Masteries";
            this.colMasteries.Width = 208;
            // 
            // colLocation
            // 
            this.colLocation.Text = "Location";
            // 
            // contextParty
            // 
            this.contextParty.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuBanish,
            this.menuLeave,
            this.menuItemAddToBuffing});
            this.contextParty.Name = "contextParty";
            this.contextParty.Size = new System.Drawing.Size(153, 70);
            // 
            // menuBanish
            // 
            this.menuBanish.Enabled = false;
            this.menuBanish.Name = "menuBanish";
            this.menuBanish.Size = new System.Drawing.Size(152, 22);
            this.menuBanish.Text = "Banish";
            this.menuBanish.Click += new System.EventHandler(this.menuBanish_Click);
            // 
            // menuLeave
            // 
            this.menuLeave.Enabled = false;
            this.menuLeave.Name = "menuLeave";
            this.menuLeave.Size = new System.Drawing.Size(152, 22);
            this.menuLeave.Text = "Leave";
            this.menuLeave.Click += new System.EventHandler(this.btnLeaveParty_Click);
            // 
            // menuItemAddToBuffing
            // 
            this.menuItemAddToBuffing.Name = "menuItemAddToBuffing";
            this.menuItemAddToBuffing.Size = new System.Drawing.Size(152, 22);
            this.menuItemAddToBuffing.Text = "Add to buffing";
            this.menuItemAddToBuffing.Click += new System.EventHandler(this.menuItemAddToBuffing_Click);
            // 
            // separator3
            // 
            this.separator3.Dock = System.Windows.Forms.DockStyle.Top;
            this.separator3.IsVertical = false;
            this.separator3.Location = new System.Drawing.Point(3, 83);
            this.separator3.Name = "separator3";
            this.separator3.Size = new System.Drawing.Size(740, 10);
            this.separator3.TabIndex = 9;
            this.separator3.Text = "separator3";
            // 
            // panel1
            // 
            this.panel1.Border = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.panel1.BorderColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.btnLeaveParty);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lblLeader);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(3, 404);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(6);
            this.panel1.Radius = 0;
            this.panel1.Size = new System.Drawing.Size(740, 32);
            this.panel1.TabIndex = 8;
            // 
            // btnLeaveParty
            // 
            this.btnLeaveParty.Color = System.Drawing.Color.IndianRed;
            this.btnLeaveParty.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnLeaveParty.Enabled = false;
            this.btnLeaveParty.ForeColor = System.Drawing.Color.White;
            this.btnLeaveParty.Location = new System.Drawing.Point(637, 6);
            this.btnLeaveParty.Name = "btnLeaveParty";
            this.btnLeaveParty.Radius = 2;
            this.btnLeaveParty.Size = new System.Drawing.Size(97, 20);
            this.btnLeaveParty.TabIndex = 2;
            this.btnLeaveParty.Text = "Leave party";
            this.btnLeaveParty.Click += new System.EventHandler(this.btnLeaveParty_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(3, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Leader:";
            // 
            // lblLeader
            // 
            this.lblLeader.BackColor = System.Drawing.Color.Transparent;
            this.lblLeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblLeader.Location = new System.Drawing.Point(70, 9);
            this.lblLeader.Name = "lblLeader";
            this.lblLeader.Size = new System.Drawing.Size(143, 14);
            this.lblLeader.TabIndex = 1;
            this.lblLeader.Text = "<Not in a party>";
            // 
            // grpPartySettings
            // 
            this.grpPartySettings.BackColor = System.Drawing.Color.Transparent;
            this.grpPartySettings.Controls.Add(this.checkCurrentAllowInvitations);
            this.grpPartySettings.Controls.Add(this.checkCurrentAutoShareItems);
            this.grpPartySettings.Controls.Add(this.checkCurrentAutoShareEXP);
            this.grpPartySettings.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpPartySettings.Enabled = false;
            this.grpPartySettings.Location = new System.Drawing.Point(3, 3);
            this.grpPartySettings.Name = "grpPartySettings";
            this.grpPartySettings.Padding = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.grpPartySettings.Radius = 2;
            this.grpPartySettings.Size = new System.Drawing.Size(740, 80);
            this.grpPartySettings.TabIndex = 7;
            this.grpPartySettings.TabStop = false;
            this.grpPartySettings.Text = "Party settings";
            // 
            // checkCurrentAllowInvitations
            // 
            this.checkCurrentAllowInvitations.AutoSize = true;
            this.checkCurrentAllowInvitations.BackColor = System.Drawing.Color.Transparent;
            this.checkCurrentAllowInvitations.Checked = false;
            this.checkCurrentAllowInvitations.Enabled = false;
            this.checkCurrentAllowInvitations.Location = new System.Drawing.Point(143, 31);
            this.checkCurrentAllowInvitations.Name = "checkCurrentAllowInvitations";
            this.checkCurrentAllowInvitations.Size = new System.Drawing.Size(111, 15);
            this.checkCurrentAllowInvitations.TabIndex = 6;
            this.checkCurrentAllowInvitations.Text = "Allow invitations";
            // 
            // checkCurrentAutoShareItems
            // 
            this.checkCurrentAutoShareItems.AutoSize = true;
            this.checkCurrentAutoShareItems.BackColor = System.Drawing.Color.Transparent;
            this.checkCurrentAutoShareItems.Checked = false;
            this.checkCurrentAutoShareItems.Enabled = false;
            this.checkCurrentAutoShareItems.Location = new System.Drawing.Point(13, 54);
            this.checkCurrentAutoShareItems.Name = "checkCurrentAutoShareItems";
            this.checkCurrentAutoShareItems.Size = new System.Drawing.Size(105, 15);
            this.checkCurrentAutoShareItems.TabIndex = 5;
            this.checkCurrentAutoShareItems.Text = "Item auto share";
            // 
            // checkCurrentAutoShareEXP
            // 
            this.checkCurrentAutoShareEXP.AutoSize = true;
            this.checkCurrentAutoShareEXP.BackColor = System.Drawing.Color.Transparent;
            this.checkCurrentAutoShareEXP.Checked = false;
            this.checkCurrentAutoShareEXP.Enabled = false;
            this.checkCurrentAutoShareEXP.Location = new System.Drawing.Point(13, 31);
            this.checkCurrentAutoShareEXP.Name = "checkCurrentAutoShareEXP";
            this.checkCurrentAutoShareEXP.Size = new System.Drawing.Size(103, 15);
            this.checkCurrentAutoShareEXP.TabIndex = 5;
            this.checkCurrentAutoShareEXP.Text = "EXP Auto share";
            // 
            // tpAutoParty
            // 
            this.tpAutoParty.BackColor = System.Drawing.Color.White;
            this.tpAutoParty.Controls.Add(this.groupBox2);
            this.tpAutoParty.Controls.Add(this.separator6);
            this.tpAutoParty.Controls.Add(this.panel2);
            this.tpAutoParty.Controls.Add(this.separator5);
            this.tpAutoParty.Controls.Add(this.grbAutoPartySettings);
            this.tpAutoParty.Location = new System.Drawing.Point(4, 24);
            this.tpAutoParty.Name = "tpAutoParty";
            this.tpAutoParty.Padding = new System.Windows.Forms.Padding(3);
            this.tpAutoParty.Size = new System.Drawing.Size(746, 439);
            this.tpAutoParty.TabIndex = 1;
            this.tpAutoParty.Text = "Auto Party";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.labelCommandsInfo);
            this.groupBox2.Controls.Add(this.separator2);
            this.groupBox2.Controls.Add(this.separator1);
            this.groupBox2.Controls.Add(this.textBoxLeaveIfMasterNotName);
            this.groupBox2.Controls.Add(this.checkBoxListenCommandsOnlyList);
            this.groupBox2.Controls.Add(this.checkBoxListenMasterCommands);
            this.groupBox2.Controls.Add(this.checkBoxLeaveIfMasterNot);
            this.groupBox2.Controls.Add(this.checkAcceptIfBotStopped);
            this.groupBox2.Controls.Add(this.checkAcceptAtTrainingPlace);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.checkInviteFromList);
            this.groupBox2.Controls.Add(this.checkInviteAll);
            this.groupBox2.Controls.Add(this.checkAcceptFromList);
            this.groupBox2.Controls.Add(this.checkAcceptAll);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(234, 93);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.groupBox2.Radius = 2;
            this.groupBox2.Size = new System.Drawing.Size(509, 343);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Auto party settings";
            // 
            // labelCommandsInfo
            // 
            this.labelCommandsInfo.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelCommandsInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelCommandsInfo.Location = new System.Drawing.Point(212, 253);
            this.labelCommandsInfo.Name = "labelCommandsInfo";
            this.labelCommandsInfo.Size = new System.Drawing.Size(285, 77);
            this.labelCommandsInfo.TabIndex = 16;
            this.labelCommandsInfo.Text = "Commands only using in the game chat window! \r\n\r\ntraceme: Send follow me request " +
    "to players \r\nsitdown: Send sitdown request to players";
            // 
            // separator2
            // 
            this.separator2.IsVertical = false;
            this.separator2.Location = new System.Drawing.Point(20, 214);
            this.separator2.Name = "separator2";
            this.separator2.Size = new System.Drawing.Size(464, 11);
            this.separator2.TabIndex = 15;
            this.separator2.Text = "separator1";
            // 
            // separator1
            // 
            this.separator1.IsVertical = false;
            this.separator1.Location = new System.Drawing.Point(20, 167);
            this.separator1.Name = "separator1";
            this.separator1.Size = new System.Drawing.Size(464, 11);
            this.separator1.TabIndex = 15;
            this.separator1.Text = "separator1";
            // 
            // textBoxLeaveIfMasterNotName
            // 
            this.textBoxLeaveIfMasterNotName.Location = new System.Drawing.Point(175, 188);
            this.textBoxLeaveIfMasterNotName.MaxLength = 32767;
            this.textBoxLeaveIfMasterNotName.MultiLine = false;
            this.textBoxLeaveIfMasterNotName.Name = "textBoxLeaveIfMasterNotName";
            this.textBoxLeaveIfMasterNotName.Size = new System.Drawing.Size(85, 21);
            this.textBoxLeaveIfMasterNotName.TabIndex = 14;
            this.textBoxLeaveIfMasterNotName.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.textBoxLeaveIfMasterNotName.UseSystemPasswordChar = false;
            // 
            // checkBoxListenCommandsOnlyList
            // 
            this.checkBoxListenCommandsOnlyList.AutoSize = true;
            this.checkBoxListenCommandsOnlyList.BackColor = System.Drawing.Color.Transparent;
            this.checkBoxListenCommandsOnlyList.Checked = false;
            this.checkBoxListenCommandsOnlyList.Location = new System.Drawing.Point(20, 253);
            this.checkBoxListenCommandsOnlyList.Name = "checkBoxListenCommandsOnlyList";
            this.checkBoxListenCommandsOnlyList.Size = new System.Drawing.Size(148, 15);
            this.checkBoxListenCommandsOnlyList.TabIndex = 13;
            this.checkBoxListenCommandsOnlyList.Text = "Listen commands in list";
            this.checkBoxListenCommandsOnlyList.CheckedChanged += new System.EventHandler(this.checkAutoPartySetting_CheckedChanged);
            // 
            // checkBoxListenMasterCommands
            // 
            this.checkBoxListenMasterCommands.AutoSize = true;
            this.checkBoxListenMasterCommands.BackColor = System.Drawing.Color.Transparent;
            this.checkBoxListenMasterCommands.Checked = false;
            this.checkBoxListenMasterCommands.Location = new System.Drawing.Point(20, 231);
            this.checkBoxListenMasterCommands.Name = "checkBoxListenMasterCommands";
            this.checkBoxListenMasterCommands.Size = new System.Drawing.Size(186, 15);
            this.checkBoxListenMasterCommands.TabIndex = 13;
            this.checkBoxListenMasterCommands.Text = "Listen party master commands";
            this.checkBoxListenMasterCommands.CheckedChanged += new System.EventHandler(this.checkAutoPartySetting_CheckedChanged);
            // 
            // checkBoxLeaveIfMasterNot
            // 
            this.checkBoxLeaveIfMasterNot.AutoSize = true;
            this.checkBoxLeaveIfMasterNot.BackColor = System.Drawing.Color.Transparent;
            this.checkBoxLeaveIfMasterNot.Checked = false;
            this.checkBoxLeaveIfMasterNot.Location = new System.Drawing.Point(20, 190);
            this.checkBoxLeaveIfMasterNot.Name = "checkBoxLeaveIfMasterNot";
            this.checkBoxLeaveIfMasterNot.Size = new System.Drawing.Size(129, 15);
            this.checkBoxLeaveIfMasterNot.TabIndex = 13;
            this.checkBoxLeaveIfMasterNot.Text = "Leave, if master not:";
            this.checkBoxLeaveIfMasterNot.CheckedChanged += new System.EventHandler(this.checkAutoPartySetting_CheckedChanged);
            // 
            // checkAcceptIfBotStopped
            // 
            this.checkAcceptIfBotStopped.AutoSize = true;
            this.checkAcceptIfBotStopped.BackColor = System.Drawing.Color.Transparent;
            this.checkAcceptIfBotStopped.Checked = false;
            this.checkAcceptIfBotStopped.Location = new System.Drawing.Point(20, 144);
            this.checkAcceptIfBotStopped.Name = "checkAcceptIfBotStopped";
            this.checkAcceptIfBotStopped.Size = new System.Drawing.Size(168, 15);
            this.checkAcceptIfBotStopped.TabIndex = 12;
            this.checkAcceptIfBotStopped.Text = "Accept if the bot is stopped";
            this.checkAcceptIfBotStopped.CheckedChanged += new System.EventHandler(this.checkAutoPartySetting_CheckedChanged);
            // 
            // checkAcceptAtTrainingPlace
            // 
            this.checkAcceptAtTrainingPlace.AutoSize = true;
            this.checkAcceptAtTrainingPlace.BackColor = System.Drawing.Color.Transparent;
            this.checkAcceptAtTrainingPlace.Checked = false;
            this.checkAcceptAtTrainingPlace.Location = new System.Drawing.Point(20, 121);
            this.checkAcceptAtTrainingPlace.Name = "checkAcceptAtTrainingPlace";
            this.checkAcceptAtTrainingPlace.Size = new System.Drawing.Size(208, 15);
            this.checkAcceptAtTrainingPlace.TabIndex = 10;
            this.checkAcceptAtTrainingPlace.Text = "Accept/Invite only at training place";
            this.checkAcceptAtTrainingPlace.CheckedChanged += new System.EventHandler(this.checkAutoPartySetting_CheckedChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(17, 312);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(189, 18);
            this.label2.TabIndex = 11;
            this.label2.Text = "* If party settings filter matches";
            // 
            // checkInviteFromList
            // 
            this.checkInviteFromList.AutoSize = true;
            this.checkInviteFromList.BackColor = System.Drawing.Color.Transparent;
            this.checkInviteFromList.Checked = false;
            this.checkInviteFromList.Location = new System.Drawing.Point(20, 98);
            this.checkInviteFromList.Name = "checkInviteFromList";
            this.checkInviteFromList.Size = new System.Drawing.Size(218, 15);
            this.checkInviteFromList.TabIndex = 9;
            this.checkInviteFromList.Text = "Auto invite all players from player list";
            this.checkInviteFromList.CheckedChanged += new System.EventHandler(this.checkAutoPartySetting_CheckedChanged);
            // 
            // checkInviteAll
            // 
            this.checkInviteAll.AutoSize = true;
            this.checkInviteAll.BackColor = System.Drawing.Color.Transparent;
            this.checkInviteAll.Checked = false;
            this.checkInviteAll.Location = new System.Drawing.Point(20, 75);
            this.checkInviteAll.Name = "checkInviteAll";
            this.checkInviteAll.Size = new System.Drawing.Size(136, 15);
            this.checkInviteAll.TabIndex = 8;
            this.checkInviteAll.Text = "Auto invite all players";
            this.checkInviteAll.CheckedChanged += new System.EventHandler(this.checkAutoPartySetting_CheckedChanged);
            // 
            // checkAcceptFromList
            // 
            this.checkAcceptFromList.AutoSize = true;
            this.checkAcceptFromList.BackColor = System.Drawing.Color.Transparent;
            this.checkAcceptFromList.Checked = false;
            this.checkAcceptFromList.Location = new System.Drawing.Point(20, 52);
            this.checkAcceptFromList.Name = "checkAcceptFromList";
            this.checkAcceptFromList.Size = new System.Drawing.Size(200, 15);
            this.checkAcceptFromList.TabIndex = 7;
            this.checkAcceptFromList.Text = "Accept invitations from player list";
            this.checkAcceptFromList.CheckedChanged += new System.EventHandler(this.checkAutoPartySetting_CheckedChanged);
            // 
            // checkAcceptAll
            // 
            this.checkAcceptAll.AutoSize = true;
            this.checkAcceptAll.BackColor = System.Drawing.Color.Transparent;
            this.checkAcceptAll.Checked = false;
            this.checkAcceptAll.Location = new System.Drawing.Point(20, 29);
            this.checkAcceptAll.Name = "checkAcceptAll";
            this.checkAcceptAll.Size = new System.Drawing.Size(138, 15);
            this.checkAcceptAll.TabIndex = 6;
            this.checkAcceptAll.Text = "Accept all invitations*";
            this.checkAcceptAll.CheckedChanged += new System.EventHandler(this.checkAutoPartySetting_CheckedChanged);
            // 
            // separator6
            // 
            this.separator6.Dock = System.Windows.Forms.DockStyle.Left;
            this.separator6.IsVertical = true;
            this.separator6.Location = new System.Drawing.Point(224, 93);
            this.separator6.Name = "separator6";
            this.separator6.Size = new System.Drawing.Size(10, 343);
            this.separator6.TabIndex = 16;
            this.separator6.Text = "separator6";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox7);
            this.panel2.Controls.Add(this.separator4);
            this.panel2.Controls.Add(this.groupBox3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(3, 93);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(221, 343);
            this.panel2.TabIndex = 14;
            // 
            // groupBox7
            // 
            this.groupBox7.BackColor = System.Drawing.Color.Transparent;
            this.groupBox7.Controls.Add(this.listCommandPlayers);
            this.groupBox7.Controls.Add(this.panel4);
            this.groupBox7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox7.Location = new System.Drawing.Point(0, 189);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Padding = new System.Windows.Forms.Padding(1, 8, 1, 1);
            this.groupBox7.Radius = 2;
            this.groupBox7.Size = new System.Drawing.Size(221, 154);
            this.groupBox7.TabIndex = 13;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Their commands will be listened to";
            // 
            // listCommandPlayers
            // 
            this.listCommandPlayers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listCommandPlayers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3});
            this.listCommandPlayers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listCommandPlayers.FullRowSelect = true;
            this.listCommandPlayers.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listCommandPlayers.Location = new System.Drawing.Point(1, 24);
            this.listCommandPlayers.MultiSelect = false;
            this.listCommandPlayers.Name = "listCommandPlayers";
            this.listCommandPlayers.Size = new System.Drawing.Size(219, 96);
            this.listCommandPlayers.TabIndex = 18;
            this.listCommandPlayers.UseCompatibleStateImageBehavior = false;
            this.listCommandPlayers.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Width = 206;
            // 
            // panel4
            // 
            this.panel4.Border = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.panel4.BorderColor = System.Drawing.Color.Transparent;
            this.panel4.Controls.Add(this.buttonCommandPlayerAdd);
            this.panel4.Controls.Add(this.buttonCommandPlayerRemove);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(1, 120);
            this.panel4.Name = "panel4";
            this.panel4.Radius = 1;
            this.panel4.Size = new System.Drawing.Size(219, 33);
            this.panel4.TabIndex = 10;
            // 
            // buttonCommandPlayerAdd
            // 
            this.buttonCommandPlayerAdd.Color = System.Drawing.Color.Transparent;
            this.buttonCommandPlayerAdd.Location = new System.Drawing.Point(5, 5);
            this.buttonCommandPlayerAdd.Name = "buttonCommandPlayerAdd";
            this.buttonCommandPlayerAdd.Radius = 2;
            this.buttonCommandPlayerAdd.Size = new System.Drawing.Size(82, 23);
            this.buttonCommandPlayerAdd.TabIndex = 10;
            this.buttonCommandPlayerAdd.Text = "Add";
            this.buttonCommandPlayerAdd.Click += new System.EventHandler(this.buttonCommandPlayerAdd_Click);
            // 
            // buttonCommandPlayerRemove
            // 
            this.buttonCommandPlayerRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCommandPlayerRemove.Color = System.Drawing.Color.Transparent;
            this.buttonCommandPlayerRemove.Location = new System.Drawing.Point(137, 5);
            this.buttonCommandPlayerRemove.Name = "buttonCommandPlayerRemove";
            this.buttonCommandPlayerRemove.Radius = 2;
            this.buttonCommandPlayerRemove.Size = new System.Drawing.Size(78, 23);
            this.buttonCommandPlayerRemove.TabIndex = 10;
            this.buttonCommandPlayerRemove.Text = "Remove";
            this.buttonCommandPlayerRemove.Click += new System.EventHandler(this.buttonCommandPlayerRemove_Click);
            // 
            // separator4
            // 
            this.separator4.Dock = System.Windows.Forms.DockStyle.Top;
            this.separator4.IsVertical = false;
            this.separator4.Location = new System.Drawing.Point(0, 179);
            this.separator4.Name = "separator4";
            this.separator4.Size = new System.Drawing.Size(221, 10);
            this.separator4.TabIndex = 13;
            this.separator4.Text = "separator4";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.listAutoParty);
            this.groupBox3.Controls.Add(this.panel3);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(1, 8, 1, 1);
            this.groupBox3.Radius = 2;
            this.groupBox3.Size = new System.Drawing.Size(221, 179);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Auto party players";
            // 
            // listAutoParty
            // 
            this.listAutoParty.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listAutoParty.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2});
            this.listAutoParty.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listAutoParty.FullRowSelect = true;
            this.listAutoParty.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listAutoParty.Location = new System.Drawing.Point(1, 24);
            this.listAutoParty.MultiSelect = false;
            this.listAutoParty.Name = "listAutoParty";
            this.listAutoParty.Size = new System.Drawing.Size(219, 121);
            this.listAutoParty.TabIndex = 17;
            this.listAutoParty.UseCompatibleStateImageBehavior = false;
            this.listAutoParty.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Width = 206;
            // 
            // panel3
            // 
            this.panel3.Border = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.panel3.BorderColor = System.Drawing.Color.Transparent;
            this.panel3.Controls.Add(this.btnAddToAutoParty);
            this.panel3.Controls.Add(this.btnRemoveFromAutoParty);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(1, 145);
            this.panel3.Name = "panel3";
            this.panel3.Radius = 0;
            this.panel3.Size = new System.Drawing.Size(219, 33);
            this.panel3.TabIndex = 17;
            // 
            // btnAddToAutoParty
            // 
            this.btnAddToAutoParty.Color = System.Drawing.Color.Transparent;
            this.btnAddToAutoParty.Location = new System.Drawing.Point(5, 4);
            this.btnAddToAutoParty.Name = "btnAddToAutoParty";
            this.btnAddToAutoParty.Radius = 2;
            this.btnAddToAutoParty.Size = new System.Drawing.Size(82, 23);
            this.btnAddToAutoParty.TabIndex = 10;
            this.btnAddToAutoParty.Text = "Add";
            this.btnAddToAutoParty.Click += new System.EventHandler(this.btnAddToAutoParty_Click);
            // 
            // btnRemoveFromAutoParty
            // 
            this.btnRemoveFromAutoParty.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveFromAutoParty.Color = System.Drawing.Color.Transparent;
            this.btnRemoveFromAutoParty.Location = new System.Drawing.Point(138, 4);
            this.btnRemoveFromAutoParty.Name = "btnRemoveFromAutoParty";
            this.btnRemoveFromAutoParty.Radius = 2;
            this.btnRemoveFromAutoParty.Size = new System.Drawing.Size(78, 23);
            this.btnRemoveFromAutoParty.TabIndex = 10;
            this.btnRemoveFromAutoParty.Text = "Remove";
            this.btnRemoveFromAutoParty.Click += new System.EventHandler(this.btnRemoveFromAutoParty_Click);
            // 
            // separator5
            // 
            this.separator5.Dock = System.Windows.Forms.DockStyle.Top;
            this.separator5.IsVertical = false;
            this.separator5.Location = new System.Drawing.Point(3, 83);
            this.separator5.Name = "separator5";
            this.separator5.Size = new System.Drawing.Size(740, 10);
            this.separator5.TabIndex = 15;
            this.separator5.Text = "separator5";
            // 
            // grbAutoPartySettings
            // 
            this.grbAutoPartySettings.BackColor = System.Drawing.Color.Transparent;
            this.grbAutoPartySettings.Controls.Add(this.checkAutoAllowInvitations);
            this.grbAutoPartySettings.Controls.Add(this.checkAutoItemAutoShare);
            this.grbAutoPartySettings.Controls.Add(this.checkAutoExpAutoShare);
            this.grbAutoPartySettings.Dock = System.Windows.Forms.DockStyle.Top;
            this.grbAutoPartySettings.Location = new System.Drawing.Point(3, 3);
            this.grbAutoPartySettings.Name = "grbAutoPartySettings";
            this.grbAutoPartySettings.Padding = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.grbAutoPartySettings.Radius = 2;
            this.grbAutoPartySettings.Size = new System.Drawing.Size(740, 80);
            this.grbAutoPartySettings.TabIndex = 8;
            this.grbAutoPartySettings.TabStop = false;
            this.grbAutoPartySettings.Text = "Party settings";
            // 
            // checkAutoAllowInvitations
            // 
            this.checkAutoAllowInvitations.AutoSize = true;
            this.checkAutoAllowInvitations.BackColor = System.Drawing.Color.Transparent;
            this.checkAutoAllowInvitations.Checked = true;
            this.checkAutoAllowInvitations.Location = new System.Drawing.Point(143, 31);
            this.checkAutoAllowInvitations.Name = "checkAutoAllowInvitations";
            this.checkAutoAllowInvitations.Size = new System.Drawing.Size(111, 15);
            this.checkAutoAllowInvitations.TabIndex = 6;
            this.checkAutoAllowInvitations.Text = "Allow invitations";
            this.checkAutoAllowInvitations.CheckedChanged += new System.EventHandler(this.checkSettings_CheckedChanged);
            // 
            // checkAutoItemAutoShare
            // 
            this.checkAutoItemAutoShare.AutoSize = true;
            this.checkAutoItemAutoShare.BackColor = System.Drawing.Color.Transparent;
            this.checkAutoItemAutoShare.Checked = false;
            this.checkAutoItemAutoShare.Location = new System.Drawing.Point(13, 54);
            this.checkAutoItemAutoShare.Name = "checkAutoItemAutoShare";
            this.checkAutoItemAutoShare.Size = new System.Drawing.Size(105, 15);
            this.checkAutoItemAutoShare.TabIndex = 5;
            this.checkAutoItemAutoShare.Text = "Item auto share";
            this.checkAutoItemAutoShare.CheckedChanged += new System.EventHandler(this.checkSettings_CheckedChanged);
            // 
            // checkAutoExpAutoShare
            // 
            this.checkAutoExpAutoShare.AutoSize = true;
            this.checkAutoExpAutoShare.BackColor = System.Drawing.Color.Transparent;
            this.checkAutoExpAutoShare.Checked = true;
            this.checkAutoExpAutoShare.Location = new System.Drawing.Point(13, 31);
            this.checkAutoExpAutoShare.Name = "checkAutoExpAutoShare";
            this.checkAutoExpAutoShare.Size = new System.Drawing.Size(103, 15);
            this.checkAutoExpAutoShare.TabIndex = 5;
            this.checkAutoExpAutoShare.Text = "EXP Auto share";
            this.checkAutoExpAutoShare.CheckedChanged += new System.EventHandler(this.checkSettings_CheckedChanged);
            // 
            // tpPartyMatching
            // 
            this.tpPartyMatching.BackColor = System.Drawing.Color.White;
            this.tpPartyMatching.Controls.Add(this.lvPartyMatching);
            this.tpPartyMatching.Controls.Add(this.topPartyPanel);
            this.tpPartyMatching.Controls.Add(this.bottomPartyPanel);
            this.tpPartyMatching.Location = new System.Drawing.Point(4, 25);
            this.tpPartyMatching.Name = "tpPartyMatching";
            this.tpPartyMatching.Padding = new System.Windows.Forms.Padding(3);
            this.tpPartyMatching.Size = new System.Drawing.Size(746, 438);
            this.tpPartyMatching.TabIndex = 2;
            this.tpPartyMatching.Text = "Party Matching";
            // 
            // lvPartyMatching
            // 
            this.lvPartyMatching.BackColor = System.Drawing.Color.White;
            this.lvPartyMatching.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvPartyMatching.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chPartyMatchNo,
            this.chPartyMatchRace,
            this.chPartyMatchName,
            this.chPartyMatchTitle,
            this.chPartyMatchPurporse,
            this.chPartyMatchMember,
            this.chPartyMatchRange});
            this.lvPartyMatching.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvPartyMatching.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lvPartyMatching.FullRowSelect = true;
            this.lvPartyMatching.Location = new System.Drawing.Point(3, 51);
            this.lvPartyMatching.MultiSelect = false;
            this.lvPartyMatching.Name = "lvPartyMatching";
            this.lvPartyMatching.ShowItemToolTips = true;
            this.lvPartyMatching.Size = new System.Drawing.Size(740, 333);
            this.lvPartyMatching.TabIndex = 15;
            this.lvPartyMatching.UseCompatibleStateImageBehavior = false;
            this.lvPartyMatching.View = System.Windows.Forms.View.Details;
            // 
            // chPartyMatchNo
            // 
            this.chPartyMatchNo.Text = "No";
            this.chPartyMatchNo.Width = 47;
            // 
            // chPartyMatchRace
            // 
            this.chPartyMatchRace.Text = "Race";
            this.chPartyMatchRace.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.chPartyMatchRace.Width = 64;
            // 
            // chPartyMatchName
            // 
            this.chPartyMatchName.Text = "Name";
            this.chPartyMatchName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.chPartyMatchName.Width = 100;
            // 
            // chPartyMatchTitle
            // 
            this.chPartyMatchTitle.Text = "Title";
            this.chPartyMatchTitle.Width = 321;
            // 
            // chPartyMatchPurporse
            // 
            this.chPartyMatchPurporse.Text = "Purpose";
            // 
            // chPartyMatchMember
            // 
            this.chPartyMatchMember.Text = "Member";
            // 
            // chPartyMatchRange
            // 
            this.chPartyMatchRange.Text = "Range";
            this.chPartyMatchRange.Width = 56;
            // 
            // topPartyPanel
            // 
            this.topPartyPanel.Border = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.topPartyPanel.BorderColor = System.Drawing.Color.Transparent;
            this.topPartyPanel.Controls.Add(this.btnPartyRefresh);
            this.topPartyPanel.Controls.Add(this.btnPartySearch);
            this.topPartyPanel.Controls.Add(this.nudPartySearchMax);
            this.topPartyPanel.Controls.Add(this.nudPartySearchMin);
            this.topPartyPanel.Controls.Add(this.cbPartySearchPurpose);
            this.topPartyPanel.Controls.Add(this.tbPartySearchName);
            this.topPartyPanel.Controls.Add(this.label6);
            this.topPartyPanel.Controls.Add(this.label5);
            this.topPartyPanel.Controls.Add(this.label4);
            this.topPartyPanel.Controls.Add(this.label3);
            this.topPartyPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPartyPanel.Location = new System.Drawing.Point(3, 3);
            this.topPartyPanel.Name = "topPartyPanel";
            this.topPartyPanel.Radius = 0;
            this.topPartyPanel.Size = new System.Drawing.Size(740, 48);
            this.topPartyPanel.TabIndex = 16;
            // 
            // btnPartyRefresh
            // 
            this.btnPartyRefresh.Color = System.Drawing.Color.Transparent;
            this.btnPartyRefresh.Location = new System.Drawing.Point(621, 12);
            this.btnPartyRefresh.Name = "btnPartyRefresh";
            this.btnPartyRefresh.Radius = 2;
            this.btnPartyRefresh.Size = new System.Drawing.Size(85, 21);
            this.btnPartyRefresh.TabIndex = 4;
            this.btnPartyRefresh.Text = "Refresh";
            this.btnPartyRefresh.Click += new System.EventHandler(this.btnPartyRefresh_Click);
            // 
            // btnPartySearch
            // 
            this.btnPartySearch.Color = System.Drawing.Color.Transparent;
            this.btnPartySearch.Location = new System.Drawing.Point(515, 13);
            this.btnPartySearch.Name = "btnPartySearch";
            this.btnPartySearch.Radius = 2;
            this.btnPartySearch.Size = new System.Drawing.Size(87, 21);
            this.btnPartySearch.TabIndex = 4;
            this.btnPartySearch.Text = "Search";
            this.btnPartySearch.Click += new System.EventHandler(this.btnPartySearch_Click);
            // 
            // nudPartySearchMax
            // 
            this.nudPartySearchMax.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.nudPartySearchMax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nudPartySearchMax.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.nudPartySearchMax.Location = new System.Drawing.Point(437, 13);
            this.nudPartySearchMax.Maximum = new decimal(new int[] {
            140,
            0,
            0,
            0});
            this.nudPartySearchMax.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudPartySearchMax.Name = "nudPartySearchMax";
            this.nudPartySearchMax.Size = new System.Drawing.Size(41, 23);
            this.nudPartySearchMax.TabIndex = 3;
            this.nudPartySearchMax.Value = new decimal(new int[] {
            140,
            0,
            0,
            0});
            // 
            // nudPartySearchMin
            // 
            this.nudPartySearchMin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.nudPartySearchMin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nudPartySearchMin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.nudPartySearchMin.Location = new System.Drawing.Point(376, 13);
            this.nudPartySearchMin.Maximum = new decimal(new int[] {
            140,
            0,
            0,
            0});
            this.nudPartySearchMin.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudPartySearchMin.Name = "nudPartySearchMin";
            this.nudPartySearchMin.Size = new System.Drawing.Size(41, 23);
            this.nudPartySearchMin.TabIndex = 3;
            this.nudPartySearchMin.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // cbPartySearchPurpose
            // 
            this.cbPartySearchPurpose.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbPartySearchPurpose.DropDownHeight = 100;
            this.cbPartySearchPurpose.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPartySearchPurpose.FormattingEnabled = true;
            this.cbPartySearchPurpose.IntegralHeight = false;
            this.cbPartySearchPurpose.ItemHeight = 17;
            this.cbPartySearchPurpose.Items.AddRange(new object[] {
            "All",
            "Hunting",
            "Quest",
            "Thief Union",
            "Trade Union"});
            this.cbPartySearchPurpose.Location = new System.Drawing.Point(222, 13);
            this.cbPartySearchPurpose.Name = "cbPartySearchPurpose";
            this.cbPartySearchPurpose.Size = new System.Drawing.Size(108, 23);
            this.cbPartySearchPurpose.TabIndex = 2;
            // 
            // tbPartySearchName
            // 
            this.tbPartySearchName.Location = new System.Drawing.Point(60, 13);
            this.tbPartySearchName.MaxLength = 32767;
            this.tbPartySearchName.MultiLine = false;
            this.tbPartySearchName.Name = "tbPartySearchName";
            this.tbPartySearchName.Size = new System.Drawing.Size(100, 21);
            this.tbPartySearchName.TabIndex = 1;
            this.tbPartySearchName.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.tbPartySearchName.UseSystemPasswordChar = false;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label6.Location = new System.Drawing.Point(419, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(22, 18);
            this.label6.TabIndex = 0;
            this.label6.Text = "~";
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label5.Location = new System.Drawing.Point(336, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 18);
            this.label5.TabIndex = 0;
            this.label5.Text = "Level";
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label4.Location = new System.Drawing.Point(166, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Purpose";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(15, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Name";
            // 
            // bottomPartyPanel
            // 
            this.bottomPartyPanel.BackColor = System.Drawing.Color.Transparent;
            this.bottomPartyPanel.Border = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.bottomPartyPanel.BorderColor = System.Drawing.Color.Transparent;
            this.bottomPartyPanel.Controls.Add(this.btnPartyMatchDeleteEntry);
            this.bottomPartyPanel.Controls.Add(this.btnPartyMatchChangeEntry);
            this.bottomPartyPanel.Controls.Add(this.btnPartyMatchForm);
            this.bottomPartyPanel.Controls.Add(this.btnAutoMatchParty);
            this.bottomPartyPanel.Controls.Add(this.btnWhisperPartyMaster);
            this.bottomPartyPanel.Controls.Add(this.btnJoinFormedParty);
            this.bottomPartyPanel.Controls.Add(this.btnPrev);
            this.bottomPartyPanel.Controls.Add(this.btnNext);
            this.bottomPartyPanel.Controls.Add(this.lbl_partyPageRange);
            this.bottomPartyPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomPartyPanel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.bottomPartyPanel.Location = new System.Drawing.Point(3, 384);
            this.bottomPartyPanel.Name = "bottomPartyPanel";
            this.bottomPartyPanel.Radius = 0;
            this.bottomPartyPanel.Size = new System.Drawing.Size(740, 51);
            this.bottomPartyPanel.TabIndex = 14;
            // 
            // btnPartyMatchDeleteEntry
            // 
            this.btnPartyMatchDeleteEntry.Color = System.Drawing.Color.Transparent;
            this.btnPartyMatchDeleteEntry.Enabled = false;
            this.btnPartyMatchDeleteEntry.Location = new System.Drawing.Point(635, 14);
            this.btnPartyMatchDeleteEntry.Name = "btnPartyMatchDeleteEntry";
            this.btnPartyMatchDeleteEntry.Radius = 2;
            this.btnPartyMatchDeleteEntry.Size = new System.Drawing.Size(87, 23);
            this.btnPartyMatchDeleteEntry.TabIndex = 16;
            this.btnPartyMatchDeleteEntry.Text = "Delete Entry";
            this.btnPartyMatchDeleteEntry.Click += new System.EventHandler(this.btnPartyMatchDeleteEntry_Click);
            // 
            // btnPartyMatchChangeEntry
            // 
            this.btnPartyMatchChangeEntry.Color = System.Drawing.Color.Transparent;
            this.btnPartyMatchChangeEntry.Enabled = false;
            this.btnPartyMatchChangeEntry.Location = new System.Drawing.Point(542, 14);
            this.btnPartyMatchChangeEntry.Name = "btnPartyMatchChangeEntry";
            this.btnPartyMatchChangeEntry.Radius = 2;
            this.btnPartyMatchChangeEntry.Size = new System.Drawing.Size(87, 23);
            this.btnPartyMatchChangeEntry.TabIndex = 15;
            this.btnPartyMatchChangeEntry.Text = "Change Entry";
            this.btnPartyMatchChangeEntry.Click += new System.EventHandler(this.btnPartyMatchForm_Click);
            // 
            // btnPartyMatchForm
            // 
            this.btnPartyMatchForm.Color = System.Drawing.Color.Transparent;
            this.btnPartyMatchForm.Location = new System.Drawing.Point(445, 14);
            this.btnPartyMatchForm.Name = "btnPartyMatchForm";
            this.btnPartyMatchForm.Radius = 2;
            this.btnPartyMatchForm.Size = new System.Drawing.Size(90, 23);
            this.btnPartyMatchForm.TabIndex = 14;
            this.btnPartyMatchForm.Text = "Form Party";
            this.btnPartyMatchForm.Click += new System.EventHandler(this.btnPartyMatchForm_Click);
            // 
            // btnAutoMatchParty
            // 
            this.btnAutoMatchParty.Color = System.Drawing.Color.Transparent;
            this.btnAutoMatchParty.Enabled = false;
            this.btnAutoMatchParty.Location = new System.Drawing.Point(180, 14);
            this.btnAutoMatchParty.Name = "btnAutoMatchParty";
            this.btnAutoMatchParty.Radius = 2;
            this.btnAutoMatchParty.Size = new System.Drawing.Size(96, 23);
            this.btnAutoMatchParty.TabIndex = 10;
            this.btnAutoMatchParty.Text = "Auto Match";
            // 
            // btnWhisperPartyMaster
            // 
            this.btnWhisperPartyMaster.Color = System.Drawing.Color.Transparent;
            this.btnWhisperPartyMaster.Enabled = false;
            this.btnWhisperPartyMaster.Location = new System.Drawing.Point(99, 14);
            this.btnWhisperPartyMaster.Name = "btnWhisperPartyMaster";
            this.btnWhisperPartyMaster.Radius = 2;
            this.btnWhisperPartyMaster.Size = new System.Drawing.Size(75, 23);
            this.btnWhisperPartyMaster.TabIndex = 9;
            this.btnWhisperPartyMaster.Text = "Whisper";
            // 
            // btnJoinFormedParty
            // 
            this.btnJoinFormedParty.Color = System.Drawing.Color.Transparent;
            this.btnJoinFormedParty.Location = new System.Drawing.Point(18, 14);
            this.btnJoinFormedParty.Name = "btnJoinFormedParty";
            this.btnJoinFormedParty.Radius = 2;
            this.btnJoinFormedParty.Size = new System.Drawing.Size(75, 23);
            this.btnJoinFormedParty.TabIndex = 8;
            this.btnJoinFormedParty.Text = "Join Party";
            this.btnJoinFormedParty.Click += new System.EventHandler(this.btnJoinFormedParty_Click);
            // 
            // btnPrev
            // 
            this.btnPrev.Color = System.Drawing.Color.Transparent;
            this.btnPrev.Enabled = false;
            this.btnPrev.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnPrev.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnPrev.Location = new System.Drawing.Point(315, 14);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Radius = 2;
            this.btnPrev.Size = new System.Drawing.Size(23, 23);
            this.btnPrev.TabIndex = 11;
            this.btnPrev.Text = "◀";
            this.btnPrev.Click += new System.EventHandler(this.PageNatigateBtn_Click);
            // 
            // btnNext
            // 
            this.btnNext.Color = System.Drawing.Color.Transparent;
            this.btnNext.Enabled = false;
            this.btnNext.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnNext.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnNext.Location = new System.Drawing.Point(387, 14);
            this.btnNext.Name = "btnNext";
            this.btnNext.Radius = 2;
            this.btnNext.Size = new System.Drawing.Size(23, 23);
            this.btnNext.TabIndex = 12;
            this.btnNext.Text = "▶";
            this.btnNext.Click += new System.EventHandler(this.PageNatigateBtn_Click);
            // 
            // lbl_partyPageRange
            // 
            this.lbl_partyPageRange.BackColor = System.Drawing.Color.Transparent;
            this.lbl_partyPageRange.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbl_partyPageRange.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbl_partyPageRange.Location = new System.Drawing.Point(344, 15);
            this.lbl_partyPageRange.Name = "lbl_partyPageRange";
            this.lbl_partyPageRange.Size = new System.Drawing.Size(39, 19);
            this.lbl_partyPageRange.TabIndex = 13;
            this.lbl_partyPageRange.Text = "0 / 0";
            // 
            // tpPartyBuffing
            // 
            this.tpPartyBuffing.BackColor = System.Drawing.Color.White;
            this.tpPartyBuffing.Controls.Add(this.groupBox4);
            this.tpPartyBuffing.Controls.Add(this.separator9);
            this.tpPartyBuffing.Controls.Add(this.groupBox6);
            this.tpPartyBuffing.Controls.Add(this.separator8);
            this.tpPartyBuffing.Controls.Add(this.groupBox5);
            this.tpPartyBuffing.Controls.Add(this.separator7);
            this.tpPartyBuffing.Controls.Add(this.groupBox1);
            this.tpPartyBuffing.Location = new System.Drawing.Point(4, 25);
            this.tpPartyBuffing.Name = "tpPartyBuffing";
            this.tpPartyBuffing.Padding = new System.Windows.Forms.Padding(6);
            this.tpPartyBuffing.Size = new System.Drawing.Size(746, 438);
            this.tpPartyBuffing.TabIndex = 3;
            this.tpPartyBuffing.Text = "Buffing";
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.Transparent;
            this.groupBox4.Controls.Add(this.btnAddBuffToMember);
            this.groupBox4.Controls.Add(this.buttonRemoveCharFromBuffing);
            this.groupBox4.Controls.Add(this.btnRemoveBuffFromMember);
            this.groupBox4.Controls.Add(this.listViewPartyMembers);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(283, 191);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(1, 8, 1, 1);
            this.groupBox4.Radius = 2;
            this.groupBox4.Size = new System.Drawing.Size(214, 241);
            this.groupBox4.TabIndex = 11;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Party Members";
            // 
            // btnAddBuffToMember
            // 
            this.btnAddBuffToMember.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddBuffToMember.Color = System.Drawing.Color.Transparent;
            this.btnAddBuffToMember.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnAddBuffToMember.Location = new System.Drawing.Point(4, 213);
            this.btnAddBuffToMember.Name = "btnAddBuffToMember";
            this.btnAddBuffToMember.Radius = 2;
            this.btnAddBuffToMember.Size = new System.Drawing.Size(75, 21);
            this.btnAddBuffToMember.TabIndex = 11;
            this.btnAddBuffToMember.Text = "Add Buff";
            this.btnAddBuffToMember.Click += new System.EventHandler(this.btnAddBuffToMember_Click);
            // 
            // buttonRemoveCharFromBuffing
            // 
            this.buttonRemoveCharFromBuffing.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRemoveCharFromBuffing.Color = System.Drawing.Color.IndianRed;
            this.buttonRemoveCharFromBuffing.Font = new System.Drawing.Font("Webdings", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonRemoveCharFromBuffing.ForeColor = System.Drawing.Color.White;
            this.buttonRemoveCharFromBuffing.Location = new System.Drawing.Point(184, 173);
            this.buttonRemoveCharFromBuffing.Name = "buttonRemoveCharFromBuffing";
            this.buttonRemoveCharFromBuffing.Radius = 2;
            this.buttonRemoveCharFromBuffing.Size = new System.Drawing.Size(23, 23);
            this.buttonRemoveCharFromBuffing.TabIndex = 12;
            this.buttonRemoveCharFromBuffing.Text = "r";
            this.buttonRemoveCharFromBuffing.Click += new System.EventHandler(this.buttonRemoveCharFromBuffing_Click);
            // 
            // btnRemoveBuffFromMember
            // 
            this.btnRemoveBuffFromMember.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveBuffFromMember.Color = System.Drawing.Color.Transparent;
            this.btnRemoveBuffFromMember.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnRemoveBuffFromMember.Location = new System.Drawing.Point(121, 213);
            this.btnRemoveBuffFromMember.Name = "btnRemoveBuffFromMember";
            this.btnRemoveBuffFromMember.Radius = 2;
            this.btnRemoveBuffFromMember.Size = new System.Drawing.Size(86, 21);
            this.btnRemoveBuffFromMember.TabIndex = 12;
            this.btnRemoveBuffFromMember.Text = "Remove Buff";
            this.btnRemoveBuffFromMember.Click += new System.EventHandler(this.btnRemoveBuffFromMember_Click);
            // 
            // listViewPartyMembers
            // 
            this.listViewPartyMembers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listViewPartyMembers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chPlayerName,
            this.chPlayerLevel});
            this.listViewPartyMembers.Dock = System.Windows.Forms.DockStyle.Top;
            this.listViewPartyMembers.FullRowSelect = true;
            this.listViewPartyMembers.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listViewPartyMembers.Location = new System.Drawing.Point(1, 24);
            this.listViewPartyMembers.MultiSelect = false;
            this.listViewPartyMembers.Name = "listViewPartyMembers";
            this.listViewPartyMembers.Size = new System.Drawing.Size(212, 181);
            this.listViewPartyMembers.TabIndex = 10;
            this.listViewPartyMembers.UseCompatibleStateImageBehavior = false;
            this.listViewPartyMembers.View = System.Windows.Forms.View.Details;
            this.listViewPartyMembers.SelectedIndexChanged += new System.EventHandler(this.listViewPartyMembers_SelectedIndexChanged);
            // 
            // chPlayerName
            // 
            this.chPlayerName.Text = "Name";
            this.chPlayerName.Width = 140;
            // 
            // chPlayerLevel
            // 
            this.chPlayerLevel.Text = "Level";
            this.chPlayerLevel.Width = 50;
            // 
            // separator9
            // 
            this.separator9.Dock = System.Windows.Forms.DockStyle.Top;
            this.separator9.IsVertical = false;
            this.separator9.Location = new System.Drawing.Point(283, 181);
            this.separator9.Name = "separator9";
            this.separator9.Size = new System.Drawing.Size(214, 10);
            this.separator9.TabIndex = 17;
            this.separator9.Text = "separator9";
            // 
            // groupBox6
            // 
            this.groupBox6.BackColor = System.Drawing.Color.Transparent;
            this.groupBox6.Controls.Add(this.buttonAddGroup);
            this.groupBox6.Controls.Add(this.buttonRemoveGroup);
            this.groupBox6.Controls.Add(this.listViewGroups);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox6.Location = new System.Drawing.Point(283, 6);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Padding = new System.Windows.Forms.Padding(1, 8, 1, 1);
            this.groupBox6.Radius = 2;
            this.groupBox6.Size = new System.Drawing.Size(214, 175);
            this.groupBox6.TabIndex = 14;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Groups";
            // 
            // buttonAddGroup
            // 
            this.buttonAddGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonAddGroup.Color = System.Drawing.Color.Transparent;
            this.buttonAddGroup.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonAddGroup.Location = new System.Drawing.Point(5, 147);
            this.buttonAddGroup.Name = "buttonAddGroup";
            this.buttonAddGroup.Radius = 2;
            this.buttonAddGroup.Size = new System.Drawing.Size(63, 21);
            this.buttonAddGroup.TabIndex = 0;
            this.buttonAddGroup.Text = "Create";
            this.buttonAddGroup.Click += new System.EventHandler(this.buttonAddGroup_Click);
            // 
            // buttonRemoveGroup
            // 
            this.buttonRemoveGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRemoveGroup.Color = System.Drawing.Color.Transparent;
            this.buttonRemoveGroup.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonRemoveGroup.Location = new System.Drawing.Point(137, 147);
            this.buttonRemoveGroup.Name = "buttonRemoveGroup";
            this.buttonRemoveGroup.Radius = 2;
            this.buttonRemoveGroup.Size = new System.Drawing.Size(72, 21);
            this.buttonRemoveGroup.TabIndex = 0;
            this.buttonRemoveGroup.Text = "Remove";
            this.buttonRemoveGroup.Click += new System.EventHandler(this.buttonRemoveGroup_Click);
            // 
            // listViewGroups
            // 
            this.listViewGroups.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listViewGroups.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderGroupName,
            this.columnHeaderMembersCount});
            this.listViewGroups.Dock = System.Windows.Forms.DockStyle.Top;
            this.listViewGroups.FullRowSelect = true;
            this.listViewGroups.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listViewGroups.Location = new System.Drawing.Point(1, 24);
            this.listViewGroups.MultiSelect = false;
            this.listViewGroups.Name = "listViewGroups";
            this.listViewGroups.Size = new System.Drawing.Size(212, 118);
            this.listViewGroups.TabIndex = 1;
            this.listViewGroups.UseCompatibleStateImageBehavior = false;
            this.listViewGroups.View = System.Windows.Forms.View.Details;
            this.listViewGroups.SelectedIndexChanged += new System.EventHandler(this.listViewGroups_SelectedIndexChanged);
            // 
            // columnHeaderGroupName
            // 
            this.columnHeaderGroupName.Text = "Group Name";
            this.columnHeaderGroupName.Width = 135;
            // 
            // columnHeaderMembersCount
            // 
            this.columnHeaderMembersCount.Text = "Members";
            // 
            // separator8
            // 
            this.separator8.Dock = System.Windows.Forms.DockStyle.Right;
            this.separator8.IsVertical = true;
            this.separator8.Location = new System.Drawing.Point(497, 6);
            this.separator8.Name = "separator8";
            this.separator8.Size = new System.Drawing.Size(10, 426);
            this.separator8.TabIndex = 16;
            this.separator8.Text = "separator8";
            // 
            // groupBox5
            // 
            this.groupBox5.BackColor = System.Drawing.Color.Transparent;
            this.groupBox5.Controls.Add(this.selectedMemberBuffs);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox5.Location = new System.Drawing.Point(507, 6);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(1, 8, 1, 1);
            this.groupBox5.Radius = 2;
            this.groupBox5.Size = new System.Drawing.Size(233, 426);
            this.groupBox5.TabIndex = 12;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Member Buffs";
            // 
            // selectedMemberBuffs
            // 
            this.selectedMemberBuffs.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.selectedMemberBuffs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.selectedMemberBuffs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.selectedMemberBuffs.FullRowSelect = true;
            this.selectedMemberBuffs.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.selectedMemberBuffs.Location = new System.Drawing.Point(1, 24);
            this.selectedMemberBuffs.Name = "selectedMemberBuffs";
            this.selectedMemberBuffs.Size = new System.Drawing.Size(231, 401);
            this.selectedMemberBuffs.TabIndex = 9;
            this.selectedMemberBuffs.UseCompatibleStateImageBehavior = false;
            this.selectedMemberBuffs.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 220;
            // 
            // separator7
            // 
            this.separator7.Dock = System.Windows.Forms.DockStyle.Left;
            this.separator7.IsVertical = true;
            this.separator7.Location = new System.Drawing.Point(273, 6);
            this.separator7.Name = "separator7";
            this.separator7.Size = new System.Drawing.Size(10, 426);
            this.separator7.TabIndex = 15;
            this.separator7.Text = "separator7";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.listPartyBuffSkills);
            this.groupBox1.Controls.Add(this.panel5);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(1, 8, 1, 1);
            this.groupBox1.Radius = 2;
            this.groupBox1.Size = new System.Drawing.Size(267, 426);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Buffs";
            // 
            // listPartyBuffSkills
            // 
            this.listPartyBuffSkills.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listPartyBuffSkills.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnName,
            this.columnLimit});
            this.listPartyBuffSkills.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listPartyBuffSkills.FullRowSelect = true;
            this.listPartyBuffSkills.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listPartyBuffSkills.Location = new System.Drawing.Point(1, 24);
            this.listPartyBuffSkills.Name = "listPartyBuffSkills";
            this.listPartyBuffSkills.Size = new System.Drawing.Size(265, 375);
            this.listPartyBuffSkills.TabIndex = 9;
            this.listPartyBuffSkills.UseCompatibleStateImageBehavior = false;
            this.listPartyBuffSkills.View = System.Windows.Forms.View.Details;
            // 
            // columnName
            // 
            this.columnName.Text = "Name";
            this.columnName.Width = 160;
            // 
            // columnLimit
            // 
            this.columnLimit.Text = "Limit";
            this.columnLimit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnLimit.Width = 80;
            // 
            // panel5
            // 
            this.panel5.Border = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.panel5.BorderColor = System.Drawing.Color.Transparent;
            this.panel5.Controls.Add(this.checkHideLowerLevelSkills);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(1, 399);
            this.panel5.Name = "panel5";
            this.panel5.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.panel5.Radius = 1;
            this.panel5.Size = new System.Drawing.Size(265, 26);
            this.panel5.TabIndex = 11;
            // 
            // checkHideLowerLevelSkills
            // 
            this.checkHideLowerLevelSkills.AutoSize = true;
            this.checkHideLowerLevelSkills.BackColor = System.Drawing.Color.Transparent;
            this.checkHideLowerLevelSkills.Checked = false;
            this.checkHideLowerLevelSkills.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkHideLowerLevelSkills.Location = new System.Drawing.Point(10, 0);
            this.checkHideLowerLevelSkills.Name = "checkHideLowerLevelSkills";
            this.checkHideLowerLevelSkills.Size = new System.Drawing.Size(135, 15);
            this.checkHideLowerLevelSkills.TabIndex = 10;
            this.checkHideLowerLevelSkills.Text = "Hide lower level skills";
            this.checkHideLowerLevelSkills.Visible = false;
            this.checkHideLowerLevelSkills.CheckedChanged += new System.EventHandler(this.checkHideLowerLevelSkills_CheckedChanged);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.tabMain);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Name = "Main";
            this.Size = new System.Drawing.Size(754, 467);
            this.tabMain.ResumeLayout(false);
            this.tabCurrentParty.ResumeLayout(false);
            this.contextParty.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.grpPartySettings.ResumeLayout(false);
            this.grpPartySettings.PerformLayout();
            this.tpAutoParty.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.grbAutoPartySettings.ResumeLayout(false);
            this.grbAutoPartySettings.PerformLayout();
            this.tpPartyMatching.ResumeLayout(false);
            this.topPartyPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudPartySearchMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPartySearchMin)).EndInit();
            this.bottomPartyPanel.ResumeLayout(false);
            this.tpPartyBuffing.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabPage tabCurrentParty;
        private SDUI.Controls.ListView listParty;
        private System.Windows.Forms.ColumnHeader colMemberName;
        private System.Windows.Forms.ColumnHeader colLevel;
        private System.Windows.Forms.ColumnHeader colGuild;
        private System.Windows.Forms.ColumnHeader colMasteries;
        private SDUI.Controls.Label lblLeader;
        private SDUI.Controls.Label label1;
        private SDUI.Controls.Button btnLeaveParty;
        private SDUI.Controls.CheckBox checkCurrentAutoShareItems;
        private SDUI.Controls.CheckBox checkCurrentAutoShareEXP;
        private SDUI.Controls.CheckBox checkCurrentAllowInvitations;
        private SDUI.Controls.GroupBox grpPartySettings;
        private SDUI.Controls.ContextMenuStrip contextParty;
        private System.Windows.Forms.ToolStripMenuItem menuBanish;
        private System.Windows.Forms.ToolStripMenuItem menuLeave;
        private System.Windows.Forms.TabPage tpAutoParty;
        private System.Windows.Forms.TabPage tpPartyMatching;
        private SDUI.Controls.GroupBox grbAutoPartySettings;
        private SDUI.Controls.CheckBox checkAutoAllowInvitations;
        private SDUI.Controls.CheckBox checkAutoItemAutoShare;
        private SDUI.Controls.CheckBox checkAutoExpAutoShare;
        private SDUI.Controls.Button btnAddToAutoParty;
        private SDUI.Controls.Button btnRemoveFromAutoParty;
        private SDUI.Controls.GroupBox groupBox2;
        private SDUI.Controls.CheckBox checkInviteFromList;
        private SDUI.Controls.CheckBox checkInviteAll;
        private SDUI.Controls.CheckBox checkAcceptFromList;
        private SDUI.Controls.CheckBox checkAcceptAll;
        private SDUI.Controls.CheckBox checkAcceptAtTrainingPlace;
        private SDUI.Controls.Label label2;
        private SDUI.Controls.GroupBox groupBox3;
        private SDUI.Controls.Panel bottomPartyPanel;
        private SDUI.Controls.Button btnPartyMatchDeleteEntry;
        private SDUI.Controls.Button btnPartyMatchChangeEntry;
        private SDUI.Controls.Button btnPartyMatchForm;
        private SDUI.Controls.Button btnAutoMatchParty;
        private SDUI.Controls.Button btnWhisperPartyMaster;
        private SDUI.Controls.Button btnJoinFormedParty;
        public SDUI.Controls.Button btnPrev;
        public SDUI.Controls.Button btnNext;
        public SDUI.Controls.ListView lvPartyMatching;
        private System.Windows.Forms.ColumnHeader chPartyMatchNo;
        private System.Windows.Forms.ColumnHeader chPartyMatchRace;
        private System.Windows.Forms.ColumnHeader chPartyMatchName;
        private System.Windows.Forms.ColumnHeader chPartyMatchTitle;
        private System.Windows.Forms.ColumnHeader chPartyMatchPurporse;
        private System.Windows.Forms.ColumnHeader chPartyMatchMember;
        private System.Windows.Forms.ColumnHeader chPartyMatchRange;
        private SDUI.Controls.Label lbl_partyPageRange;
        private SDUI.Controls.Panel topPartyPanel;
        private SDUI.Controls.ComboBox cbPartySearchPurpose;
        private SDUI.Controls.TextBox tbPartySearchName;
        private SDUI.Controls.Label label4;
        private SDUI.Controls.Label label3;
        private SDUI.Controls.Button btnPartyRefresh;
        private SDUI.Controls.Button btnPartySearch;
        private SDUI.Controls.NumUpDown nudPartySearchMax;
        private SDUI.Controls.NumUpDown nudPartySearchMin;
        private SDUI.Controls.Label label6;
        private SDUI.Controls.Label label5;
        private SDUI.Controls.CheckBox checkAcceptIfBotStopped;
        private SDUI.Controls.Panel panel1;
        private System.Windows.Forms.ColumnHeader colLocation;
        private System.Windows.Forms.TabPage tpPartyBuffing;
        private SDUI.Controls.GroupBox groupBox1;
        private SDUI.Controls.ListView listPartyBuffSkills;
        private System.Windows.Forms.ColumnHeader columnName;
        private SDUI.Controls.GroupBox groupBox4;
        private SDUI.Controls.GroupBox groupBox5;
        private SDUI.Controls.ListView selectedMemberBuffs;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private SDUI.Controls.CheckBox checkHideLowerLevelSkills;
        private System.Windows.Forms.ColumnHeader columnLimit;
        private SDUI.Controls.ListView listViewPartyMembers;
        private System.Windows.Forms.ColumnHeader chPlayerName;
        private System.Windows.Forms.ColumnHeader chPlayerLevel;
        private SDUI.Controls.GroupBox groupBox6;
        private SDUI.Controls.Button buttonAddGroup;
        private SDUI.Controls.Button buttonRemoveGroup;
        private SDUI.Controls.ListView listViewGroups;
        private System.Windows.Forms.ColumnHeader columnHeaderGroupName;
        private System.Windows.Forms.ColumnHeader columnHeaderMembersCount;
        private SDUI.Controls.Button btnAddBuffToMember;
        private SDUI.Controls.Button btnRemoveBuffFromMember;
        private System.Windows.Forms.ToolStripMenuItem menuItemAddToBuffing;
        private SDUI.Controls.Button buttonRemoveCharFromBuffing;
        private SDUI.Controls.TextBox textBoxLeaveIfMasterNotName;
        private SDUI.Controls.CheckBox checkBoxLeaveIfMasterNot;
        private SDUI.Controls.Separator separator1;
        private SDUI.Controls.CheckBox checkBoxListenCommandsOnlyList;
        private SDUI.Controls.CheckBox checkBoxListenMasterCommands;
        private SDUI.Controls.GroupBox groupBox7;
        private SDUI.Controls.Button buttonCommandPlayerRemove;
        private SDUI.Controls.Button buttonCommandPlayerAdd;
        private SDUI.Controls.Label labelCommandsInfo;
        private SDUI.Controls.Separator separator2;
        private SDUI.Controls.Panel panel3;
        private SDUI.Controls.Panel panel4;
        private SDUI.Controls.TabControl tabMain;
        private SDUI.Controls.Separator separator3;
        private SDUI.Controls.Separator separator6;
        private System.Windows.Forms.Panel panel2;
        private SDUI.Controls.Separator separator4;
        private SDUI.Controls.Separator separator5;
        private SDUI.Controls.Panel panel5;
        private SDUI.Controls.Separator separator9;
        private SDUI.Controls.Separator separator8;
        private SDUI.Controls.Separator separator7;
        private SDUI.Controls.ListView listCommandPlayers;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private SDUI.Controls.ListView listAutoParty;
        private System.Windows.Forms.ColumnHeader columnHeader2;
    }
}
