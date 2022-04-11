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
            this.tabMain = new RSBot.Theme.Controls.TabControl();
            this.tabCurrentParty = new System.Windows.Forms.TabPage();
            this.listParty = new System.Windows.Forms.ListView();
            this.colMemberName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLevel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colGuild = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colMasteries = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLocation = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextParty = new System.Windows.Forms.ContextMenu();
            this.menuBanish = new System.Windows.Forms.MenuItem();
            this.menuLeave = new System.Windows.Forms.MenuItem();
            this.menuItemAddToBuffing = new System.Windows.Forms.MenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnLeaveParty = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblLeader = new System.Windows.Forms.Label();
            this.grpPartySettings = new System.Windows.Forms.GroupBox();
            this.checkCurrentAllowInvitations = new System.Windows.Forms.CheckBox();
            this.checkCurrentAutoShareItems = new System.Windows.Forms.CheckBox();
            this.checkCurrentAutoShareEXP = new System.Windows.Forms.CheckBox();
            this.tpAutoParty = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.listAutoParty = new System.Windows.Forms.ListBox();
            this.btnRemoveFromAutoParty = new System.Windows.Forms.Button();
            this.btnAddToAutoParty = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkAcceptIfBotStopped = new System.Windows.Forms.CheckBox();
            this.checkAcceptAtTrainingPlace = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.checkInviteFromList = new System.Windows.Forms.CheckBox();
            this.checkInviteAll = new System.Windows.Forms.CheckBox();
            this.checkAcceptFromList = new System.Windows.Forms.CheckBox();
            this.checkAcceptAll = new System.Windows.Forms.CheckBox();
            this.grbAutoPartySettings = new System.Windows.Forms.GroupBox();
            this.checkAutoAllowInvitations = new System.Windows.Forms.CheckBox();
            this.checkAutoItemAutoShare = new System.Windows.Forms.CheckBox();
            this.checkAutoExpAutoShare = new System.Windows.Forms.CheckBox();
            this.tpPartyMatching = new System.Windows.Forms.TabPage();
            this.lvPartyMatching = new System.Windows.Forms.ListView();
            this.chPartyMatchNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chPartyMatchRace = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chPartyMatchName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chPartyMatchTitle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chPartyMatchPurporse = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chPartyMatchMember = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chPartyMatchRange = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.topPartyPanel = new System.Windows.Forms.Panel();
            this.btnPartyRefresh = new System.Windows.Forms.Button();
            this.btnPartySearch = new System.Windows.Forms.Button();
            this.nudPartySearchMax = new System.Windows.Forms.NumericUpDown();
            this.nudPartySearchMin = new System.Windows.Forms.NumericUpDown();
            this.cbPartySearchPurpose = new System.Windows.Forms.ComboBox();
            this.tbPartySearchName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.bottomPartyPanel = new System.Windows.Forms.Panel();
            this.btnPartyMatchDeleteEntry = new System.Windows.Forms.Button();
            this.btnPartyMatchChangeEntry = new System.Windows.Forms.Button();
            this.btnPartyMatchForm = new System.Windows.Forms.Button();
            this.btnAutoMatchParty = new System.Windows.Forms.Button();
            this.btnWhisperPartyMaster = new System.Windows.Forms.Button();
            this.btnJoinFormedParty = new System.Windows.Forms.Button();
            this.btnPrev = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.lbl_partyPageRange = new System.Windows.Forms.Label();
            this.tpPartyBuffing = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnAddBuffToMember = new System.Windows.Forms.Button();
            this.buttonRemoveCharFromBuffing = new System.Windows.Forms.Button();
            this.btnRemoveBuffFromMember = new System.Windows.Forms.Button();
            this.listViewPartyMembers = new System.Windows.Forms.ListView();
            this.chPlayerName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chPlayerLevel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.buttonAddGroup = new System.Windows.Forms.Button();
            this.buttonRemoveGroup = new System.Windows.Forms.Button();
            this.listViewGroups = new System.Windows.Forms.ListView();
            this.columnHeaderGroupName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderMembersCount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.selectedMemberBuffs = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listPartyBuffSkills = new System.Windows.Forms.ListView();
            this.columnName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnLimit = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.checkHideLowerLevelSkills = new System.Windows.Forms.CheckBox();
            this.tabMain.SuspendLayout();
            this.tabCurrentParty.SuspendLayout();
            this.panel1.SuspendLayout();
            this.grpPartySettings.SuspendLayout();
            this.tpAutoParty.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
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
            this.SuspendLayout();
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabCurrentParty);
            this.tabMain.Controls.Add(this.tpAutoParty);
            this.tabMain.Controls.Add(this.tpPartyMatching);
            this.tabMain.Controls.Add(this.tpPartyBuffing);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Location = new System.Drawing.Point(6, 6);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(742, 455);
            this.tabMain.TabIndex = 0;
            this.tabMain.SelectedIndexChanged += new System.EventHandler(this.tabMain_SelectedIndexChanged);
            // 
            // tabCurrentParty
            // 
            this.tabCurrentParty.BackColor = System.Drawing.Color.Transparent;
            this.tabCurrentParty.Controls.Add(this.listParty);
            this.tabCurrentParty.Controls.Add(this.panel1);
            this.tabCurrentParty.Controls.Add(this.grpPartySettings);
            this.tabCurrentParty.Location = new System.Drawing.Point(4, 25);
            this.tabCurrentParty.Name = "tabCurrentParty";
            this.tabCurrentParty.Padding = new System.Windows.Forms.Padding(3);
            this.tabCurrentParty.Size = new System.Drawing.Size(734, 426);
            this.tabCurrentParty.TabIndex = 0;
            this.tabCurrentParty.Text = "Party";
            // 
            // listParty
            // 
            this.listParty.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colMemberName,
            this.colLevel,
            this.colGuild,
            this.colMasteries,
            this.colLocation});
            this.listParty.ContextMenu = this.contextParty;
            this.listParty.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listParty.FullRowSelect = true;
            this.listParty.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listParty.HideSelection = false;
            this.listParty.Location = new System.Drawing.Point(3, 74);
            this.listParty.MultiSelect = false;
            this.listParty.Name = "listParty";
            this.listParty.Size = new System.Drawing.Size(728, 317);
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
            this.contextParty.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuBanish,
            this.menuLeave,
            this.menuItemAddToBuffing});
            // 
            // menuBanish
            // 
            this.menuBanish.Enabled = false;
            this.menuBanish.Index = 0;
            this.menuBanish.Text = "Banish";
            this.menuBanish.Click += new System.EventHandler(this.menuBanish_Click);
            // 
            // menuLeave
            // 
            this.menuLeave.Enabled = false;
            this.menuLeave.Index = 1;
            this.menuLeave.Text = "Leave";
            this.menuLeave.Click += new System.EventHandler(this.btnLeaveParty_Click);
            // 
            // menuItemAddToBuffing
            // 
            this.menuItemAddToBuffing.Index = 2;
            this.menuItemAddToBuffing.Text = "Add to buffing";
            this.menuItemAddToBuffing.Click += new System.EventHandler(this.menuItemAddToBuffing_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnLeaveParty);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lblLeader);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(3, 391);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(728, 32);
            this.panel1.TabIndex = 8;
            // 
            // btnLeaveParty
            // 
            this.btnLeaveParty.Enabled = false;
            this.btnLeaveParty.Location = new System.Drawing.Point(626, 4);
            this.btnLeaveParty.Name = "btnLeaveParty";
            this.btnLeaveParty.Size = new System.Drawing.Size(90, 23);
            this.btnLeaveParty.TabIndex = 2;
            this.btnLeaveParty.Text = "Leave party";
            this.btnLeaveParty.UseVisualStyleBackColor = true;
            this.btnLeaveParty.Click += new System.EventHandler(this.btnLeaveParty_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Leader:";
            // 
            // lblLeader
            // 
            this.lblLeader.AutoSize = true;
            this.lblLeader.Location = new System.Drawing.Point(52, 8);
            this.lblLeader.Name = "lblLeader";
            this.lblLeader.Size = new System.Drawing.Size(82, 13);
            this.lblLeader.TabIndex = 1;
            this.lblLeader.Text = "<Not in a party>";
            // 
            // grpPartySettings
            // 
            this.grpPartySettings.Controls.Add(this.checkCurrentAllowInvitations);
            this.grpPartySettings.Controls.Add(this.checkCurrentAutoShareItems);
            this.grpPartySettings.Controls.Add(this.checkCurrentAutoShareEXP);
            this.grpPartySettings.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpPartySettings.Enabled = false;
            this.grpPartySettings.Location = new System.Drawing.Point(3, 3);
            this.grpPartySettings.Name = "grpPartySettings";
            this.grpPartySettings.Size = new System.Drawing.Size(728, 71);
            this.grpPartySettings.TabIndex = 7;
            this.grpPartySettings.TabStop = false;
            this.grpPartySettings.Text = "Party settings";
            // 
            // checkCurrentAllowInvitations
            // 
            this.checkCurrentAllowInvitations.AutoSize = true;
            this.checkCurrentAllowInvitations.Enabled = false;
            this.checkCurrentAllowInvitations.Location = new System.Drawing.Point(143, 22);
            this.checkCurrentAllowInvitations.Name = "checkCurrentAllowInvitations";
            this.checkCurrentAllowInvitations.Size = new System.Drawing.Size(101, 17);
            this.checkCurrentAllowInvitations.TabIndex = 6;
            this.checkCurrentAllowInvitations.Text = "Allow invitations";
            this.checkCurrentAllowInvitations.UseVisualStyleBackColor = true;
            // 
            // checkCurrentAutoShareItems
            // 
            this.checkCurrentAutoShareItems.AutoSize = true;
            this.checkCurrentAutoShareItems.Enabled = false;
            this.checkCurrentAutoShareItems.Location = new System.Drawing.Point(13, 47);
            this.checkCurrentAutoShareItems.Name = "checkCurrentAutoShareItems";
            this.checkCurrentAutoShareItems.Size = new System.Drawing.Size(99, 17);
            this.checkCurrentAutoShareItems.TabIndex = 5;
            this.checkCurrentAutoShareItems.Text = "Item auto share";
            this.checkCurrentAutoShareItems.UseVisualStyleBackColor = true;
            // 
            // checkCurrentAutoShareEXP
            // 
            this.checkCurrentAutoShareEXP.AutoSize = true;
            this.checkCurrentAutoShareEXP.Enabled = false;
            this.checkCurrentAutoShareEXP.Location = new System.Drawing.Point(13, 22);
            this.checkCurrentAutoShareEXP.Name = "checkCurrentAutoShareEXP";
            this.checkCurrentAutoShareEXP.Size = new System.Drawing.Size(101, 17);
            this.checkCurrentAutoShareEXP.TabIndex = 5;
            this.checkCurrentAutoShareEXP.Text = "EXP Auto share";
            this.checkCurrentAutoShareEXP.UseVisualStyleBackColor = true;
            // 
            // tpAutoParty
            // 
            this.tpAutoParty.BackColor = System.Drawing.Color.Transparent;
            this.tpAutoParty.Controls.Add(this.groupBox3);
            this.tpAutoParty.Controls.Add(this.groupBox2);
            this.tpAutoParty.Controls.Add(this.grbAutoPartySettings);
            this.tpAutoParty.Location = new System.Drawing.Point(4, 25);
            this.tpAutoParty.Name = "tpAutoParty";
            this.tpAutoParty.Padding = new System.Windows.Forms.Padding(3);
            this.tpAutoParty.Size = new System.Drawing.Size(734, 426);
            this.tpAutoParty.TabIndex = 1;
            this.tpAutoParty.Text = "Auto Party";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.listAutoParty);
            this.groupBox3.Controls.Add(this.btnRemoveFromAutoParty);
            this.groupBox3.Controls.Add(this.btnAddToAutoParty);
            this.groupBox3.Location = new System.Drawing.Point(6, 83);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(181, 337);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Auto party players";
            // 
            // listAutoParty
            // 
            this.listAutoParty.FormattingEnabled = true;
            this.listAutoParty.Location = new System.Drawing.Point(8, 22);
            this.listAutoParty.Name = "listAutoParty";
            this.listAutoParty.Size = new System.Drawing.Size(166, 264);
            this.listAutoParty.TabIndex = 9;
            // 
            // btnRemoveFromAutoParty
            // 
            this.btnRemoveFromAutoParty.Location = new System.Drawing.Point(8, 304);
            this.btnRemoveFromAutoParty.Name = "btnRemoveFromAutoParty";
            this.btnRemoveFromAutoParty.Size = new System.Drawing.Size(78, 23);
            this.btnRemoveFromAutoParty.TabIndex = 10;
            this.btnRemoveFromAutoParty.Text = "Remove";
            this.btnRemoveFromAutoParty.UseVisualStyleBackColor = true;
            this.btnRemoveFromAutoParty.Click += new System.EventHandler(this.btnRemoveFromAutoParty_Click);
            // 
            // btnAddToAutoParty
            // 
            this.btnAddToAutoParty.Location = new System.Drawing.Point(92, 304);
            this.btnAddToAutoParty.Name = "btnAddToAutoParty";
            this.btnAddToAutoParty.Size = new System.Drawing.Size(82, 23);
            this.btnAddToAutoParty.TabIndex = 10;
            this.btnAddToAutoParty.Text = "Add";
            this.btnAddToAutoParty.UseVisualStyleBackColor = true;
            this.btnAddToAutoParty.Click += new System.EventHandler(this.btnAddToAutoParty_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkAcceptIfBotStopped);
            this.groupBox2.Controls.Add(this.checkAcceptAtTrainingPlace);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.checkInviteFromList);
            this.groupBox2.Controls.Add(this.checkInviteAll);
            this.groupBox2.Controls.Add(this.checkAcceptFromList);
            this.groupBox2.Controls.Add(this.checkAcceptAll);
            this.groupBox2.Location = new System.Drawing.Point(193, 83);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(539, 199);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Auto party settings";
            // 
            // checkAcceptIfBotStopped
            // 
            this.checkAcceptIfBotStopped.AutoSize = true;
            this.checkAcceptIfBotStopped.Location = new System.Drawing.Point(20, 144);
            this.checkAcceptIfBotStopped.Name = "checkAcceptIfBotStopped";
            this.checkAcceptIfBotStopped.Size = new System.Drawing.Size(155, 17);
            this.checkAcceptIfBotStopped.TabIndex = 12;
            this.checkAcceptIfBotStopped.Text = "Accept if the bot is stopped";
            this.checkAcceptIfBotStopped.UseVisualStyleBackColor = true;
            this.checkAcceptIfBotStopped.CheckedChanged += new System.EventHandler(this.checkAutoPartySetting_CheckedChanged);
            // 
            // checkAcceptAtTrainingPlace
            // 
            this.checkAcceptAtTrainingPlace.AutoSize = true;
            this.checkAcceptAtTrainingPlace.Location = new System.Drawing.Point(20, 121);
            this.checkAcceptAtTrainingPlace.Name = "checkAcceptAtTrainingPlace";
            this.checkAcceptAtTrainingPlace.Size = new System.Drawing.Size(191, 17);
            this.checkAcceptAtTrainingPlace.TabIndex = 10;
            this.checkAcceptAtTrainingPlace.Text = "Accept/Invite only at training place";
            this.checkAcceptAtTrainingPlace.UseVisualStyleBackColor = true;
            this.checkAcceptAtTrainingPlace.CheckedChanged += new System.EventHandler(this.checkAutoPartySetting_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(238, 173);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(150, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "* If party settings filter matches";
            // 
            // checkInviteFromList
            // 
            this.checkInviteFromList.AutoSize = true;
            this.checkInviteFromList.Location = new System.Drawing.Point(20, 98);
            this.checkInviteFromList.Name = "checkInviteFromList";
            this.checkInviteFromList.Size = new System.Drawing.Size(194, 17);
            this.checkInviteFromList.TabIndex = 9;
            this.checkInviteFromList.Text = "Auto invite all players from player list";
            this.checkInviteFromList.UseVisualStyleBackColor = true;
            this.checkInviteFromList.CheckedChanged += new System.EventHandler(this.checkAutoPartySetting_CheckedChanged);
            // 
            // checkInviteAll
            // 
            this.checkInviteAll.AutoSize = true;
            this.checkInviteAll.Location = new System.Drawing.Point(20, 75);
            this.checkInviteAll.Name = "checkInviteAll";
            this.checkInviteAll.Size = new System.Drawing.Size(125, 17);
            this.checkInviteAll.TabIndex = 8;
            this.checkInviteAll.Text = "Auto invite all players";
            this.checkInviteAll.UseVisualStyleBackColor = true;
            this.checkInviteAll.CheckedChanged += new System.EventHandler(this.checkAutoPartySetting_CheckedChanged);
            // 
            // checkAcceptFromList
            // 
            this.checkAcceptFromList.AutoSize = true;
            this.checkAcceptFromList.Location = new System.Drawing.Point(20, 52);
            this.checkAcceptFromList.Name = "checkAcceptFromList";
            this.checkAcceptFromList.Size = new System.Drawing.Size(179, 17);
            this.checkAcceptFromList.TabIndex = 7;
            this.checkAcceptFromList.Text = "Accept invitations from player list";
            this.checkAcceptFromList.UseVisualStyleBackColor = true;
            this.checkAcceptFromList.CheckedChanged += new System.EventHandler(this.checkAutoPartySetting_CheckedChanged);
            // 
            // checkAcceptAll
            // 
            this.checkAcceptAll.AutoSize = true;
            this.checkAcceptAll.Location = new System.Drawing.Point(20, 29);
            this.checkAcceptAll.Name = "checkAcceptAll";
            this.checkAcceptAll.Size = new System.Drawing.Size(127, 17);
            this.checkAcceptAll.TabIndex = 6;
            this.checkAcceptAll.Text = "Accept all invitations*";
            this.checkAcceptAll.UseVisualStyleBackColor = true;
            this.checkAcceptAll.CheckedChanged += new System.EventHandler(this.checkAutoPartySetting_CheckedChanged);
            // 
            // grbAutoPartySettings
            // 
            this.grbAutoPartySettings.Controls.Add(this.checkAutoAllowInvitations);
            this.grbAutoPartySettings.Controls.Add(this.checkAutoItemAutoShare);
            this.grbAutoPartySettings.Controls.Add(this.checkAutoExpAutoShare);
            this.grbAutoPartySettings.Dock = System.Windows.Forms.DockStyle.Top;
            this.grbAutoPartySettings.Location = new System.Drawing.Point(3, 3);
            this.grbAutoPartySettings.Name = "grbAutoPartySettings";
            this.grbAutoPartySettings.Size = new System.Drawing.Size(728, 71);
            this.grbAutoPartySettings.TabIndex = 8;
            this.grbAutoPartySettings.TabStop = false;
            this.grbAutoPartySettings.Text = "Party settings";
            // 
            // checkAutoAllowInvitations
            // 
            this.checkAutoAllowInvitations.AutoSize = true;
            this.checkAutoAllowInvitations.Checked = true;
            this.checkAutoAllowInvitations.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkAutoAllowInvitations.Location = new System.Drawing.Point(143, 22);
            this.checkAutoAllowInvitations.Name = "checkAutoAllowInvitations";
            this.checkAutoAllowInvitations.Size = new System.Drawing.Size(101, 17);
            this.checkAutoAllowInvitations.TabIndex = 6;
            this.checkAutoAllowInvitations.Text = "Allow invitations";
            this.checkAutoAllowInvitations.UseVisualStyleBackColor = true;
            this.checkAutoAllowInvitations.CheckedChanged += new System.EventHandler(this.checkSettings_CheckedChanged);
            // 
            // checkAutoItemAutoShare
            // 
            this.checkAutoItemAutoShare.AutoSize = true;
            this.checkAutoItemAutoShare.Location = new System.Drawing.Point(13, 47);
            this.checkAutoItemAutoShare.Name = "checkAutoItemAutoShare";
            this.checkAutoItemAutoShare.Size = new System.Drawing.Size(99, 17);
            this.checkAutoItemAutoShare.TabIndex = 5;
            this.checkAutoItemAutoShare.Text = "Item auto share";
            this.checkAutoItemAutoShare.UseVisualStyleBackColor = true;
            this.checkAutoItemAutoShare.CheckedChanged += new System.EventHandler(this.checkSettings_CheckedChanged);
            // 
            // checkAutoExpAutoShare
            // 
            this.checkAutoExpAutoShare.AutoSize = true;
            this.checkAutoExpAutoShare.Checked = true;
            this.checkAutoExpAutoShare.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkAutoExpAutoShare.Location = new System.Drawing.Point(13, 22);
            this.checkAutoExpAutoShare.Name = "checkAutoExpAutoShare";
            this.checkAutoExpAutoShare.Size = new System.Drawing.Size(101, 17);
            this.checkAutoExpAutoShare.TabIndex = 5;
            this.checkAutoExpAutoShare.Text = "EXP Auto share";
            this.checkAutoExpAutoShare.UseVisualStyleBackColor = true;
            this.checkAutoExpAutoShare.CheckedChanged += new System.EventHandler(this.checkSettings_CheckedChanged);
            // 
            // tpPartyMatching
            // 
            this.tpPartyMatching.BackColor = System.Drawing.Color.Transparent;
            this.tpPartyMatching.Controls.Add(this.lvPartyMatching);
            this.tpPartyMatching.Controls.Add(this.topPartyPanel);
            this.tpPartyMatching.Controls.Add(this.bottomPartyPanel);
            this.tpPartyMatching.Location = new System.Drawing.Point(4, 25);
            this.tpPartyMatching.Name = "tpPartyMatching";
            this.tpPartyMatching.Padding = new System.Windows.Forms.Padding(3);
            this.tpPartyMatching.Size = new System.Drawing.Size(734, 426);
            this.tpPartyMatching.TabIndex = 2;
            this.tpPartyMatching.Text = "Party Matching";
            // 
            // lvPartyMatching
            // 
            this.lvPartyMatching.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chPartyMatchNo,
            this.chPartyMatchRace,
            this.chPartyMatchName,
            this.chPartyMatchTitle,
            this.chPartyMatchPurporse,
            this.chPartyMatchMember,
            this.chPartyMatchRange});
            this.lvPartyMatching.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvPartyMatching.FullRowSelect = true;
            this.lvPartyMatching.HideSelection = false;
            this.lvPartyMatching.Location = new System.Drawing.Point(3, 51);
            this.lvPartyMatching.MultiSelect = false;
            this.lvPartyMatching.Name = "lvPartyMatching";
            this.lvPartyMatching.ShowItemToolTips = true;
            this.lvPartyMatching.Size = new System.Drawing.Size(728, 321);
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
            this.topPartyPanel.Size = new System.Drawing.Size(728, 48);
            this.topPartyPanel.TabIndex = 16;
            // 
            // btnPartyRefresh
            // 
            this.btnPartyRefresh.Location = new System.Drawing.Point(608, 13);
            this.btnPartyRefresh.Name = "btnPartyRefresh";
            this.btnPartyRefresh.Size = new System.Drawing.Size(78, 21);
            this.btnPartyRefresh.TabIndex = 4;
            this.btnPartyRefresh.Text = "Refresh";
            this.btnPartyRefresh.UseVisualStyleBackColor = true;
            this.btnPartyRefresh.Click += new System.EventHandler(this.btnPartyRefresh_Click);
            // 
            // btnPartySearch
            // 
            this.btnPartySearch.Location = new System.Drawing.Point(515, 13);
            this.btnPartySearch.Name = "btnPartySearch";
            this.btnPartySearch.Size = new System.Drawing.Size(77, 21);
            this.btnPartySearch.TabIndex = 4;
            this.btnPartySearch.Text = "Search";
            this.btnPartySearch.UseVisualStyleBackColor = true;
            this.btnPartySearch.Click += new System.EventHandler(this.btnPartySearch_Click);
            // 
            // nudPartySearchMax
            // 
            this.nudPartySearchMax.Location = new System.Drawing.Point(438, 13);
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
            this.nudPartySearchMax.Size = new System.Drawing.Size(41, 20);
            this.nudPartySearchMax.TabIndex = 3;
            this.nudPartySearchMax.Value = new decimal(new int[] {
            140,
            0,
            0,
            0});
            // 
            // nudPartySearchMin
            // 
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
            this.nudPartySearchMin.Size = new System.Drawing.Size(41, 20);
            this.nudPartySearchMin.TabIndex = 3;
            this.nudPartySearchMin.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // cbPartySearchPurpose
            // 
            this.cbPartySearchPurpose.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPartySearchPurpose.FormattingEnabled = true;
            this.cbPartySearchPurpose.Items.AddRange(new object[] {
            "All",
            "Hunting",
            "Quest",
            "Thief Union",
            "Trade Union"});
            this.cbPartySearchPurpose.Location = new System.Drawing.Point(222, 13);
            this.cbPartySearchPurpose.Name = "cbPartySearchPurpose";
            this.cbPartySearchPurpose.Size = new System.Drawing.Size(108, 21);
            this.cbPartySearchPurpose.TabIndex = 2;
            // 
            // tbPartySearchName
            // 
            this.tbPartySearchName.Location = new System.Drawing.Point(60, 13);
            this.tbPartySearchName.Name = "tbPartySearchName";
            this.tbPartySearchName.Size = new System.Drawing.Size(100, 20);
            this.tbPartySearchName.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(419, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(14, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "~";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(336, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Level";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(166, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Purpose";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Name";
            // 
            // bottomPartyPanel
            // 
            this.bottomPartyPanel.BackColor = System.Drawing.SystemColors.Control;
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
            this.bottomPartyPanel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bottomPartyPanel.Location = new System.Drawing.Point(3, 372);
            this.bottomPartyPanel.Name = "bottomPartyPanel";
            this.bottomPartyPanel.Size = new System.Drawing.Size(728, 51);
            this.bottomPartyPanel.TabIndex = 14;
            // 
            // btnPartyMatchDeleteEntry
            // 
            this.btnPartyMatchDeleteEntry.Enabled = false;
            this.btnPartyMatchDeleteEntry.Location = new System.Drawing.Point(635, 14);
            this.btnPartyMatchDeleteEntry.Name = "btnPartyMatchDeleteEntry";
            this.btnPartyMatchDeleteEntry.Size = new System.Drawing.Size(87, 23);
            this.btnPartyMatchDeleteEntry.TabIndex = 16;
            this.btnPartyMatchDeleteEntry.Text = "Delete Entry";
            this.btnPartyMatchDeleteEntry.UseVisualStyleBackColor = true;
            this.btnPartyMatchDeleteEntry.Click += new System.EventHandler(this.btnPartyMatchDeleteEntry_Click);
            // 
            // btnPartyMatchChangeEntry
            // 
            this.btnPartyMatchChangeEntry.Enabled = false;
            this.btnPartyMatchChangeEntry.Location = new System.Drawing.Point(542, 14);
            this.btnPartyMatchChangeEntry.Name = "btnPartyMatchChangeEntry";
            this.btnPartyMatchChangeEntry.Size = new System.Drawing.Size(87, 23);
            this.btnPartyMatchChangeEntry.TabIndex = 15;
            this.btnPartyMatchChangeEntry.Text = "Change Entry";
            this.btnPartyMatchChangeEntry.UseVisualStyleBackColor = true;
            this.btnPartyMatchChangeEntry.Click += new System.EventHandler(this.btnPartyMatchForm_Click);
            // 
            // btnPartyMatchForm
            // 
            this.btnPartyMatchForm.Location = new System.Drawing.Point(446, 14);
            this.btnPartyMatchForm.Name = "btnPartyMatchForm";
            this.btnPartyMatchForm.Size = new System.Drawing.Size(90, 23);
            this.btnPartyMatchForm.TabIndex = 14;
            this.btnPartyMatchForm.Text = "Form Party";
            this.btnPartyMatchForm.UseVisualStyleBackColor = true;
            this.btnPartyMatchForm.Click += new System.EventHandler(this.btnPartyMatchForm_Click);
            // 
            // btnAutoMatchParty
            // 
            this.btnAutoMatchParty.Enabled = false;
            this.btnAutoMatchParty.Location = new System.Drawing.Point(180, 14);
            this.btnAutoMatchParty.Name = "btnAutoMatchParty";
            this.btnAutoMatchParty.Size = new System.Drawing.Size(96, 23);
            this.btnAutoMatchParty.TabIndex = 10;
            this.btnAutoMatchParty.Text = "Auto Match";
            this.btnAutoMatchParty.UseVisualStyleBackColor = true;
            // 
            // btnWhisperPartyMaster
            // 
            this.btnWhisperPartyMaster.Enabled = false;
            this.btnWhisperPartyMaster.Location = new System.Drawing.Point(99, 14);
            this.btnWhisperPartyMaster.Name = "btnWhisperPartyMaster";
            this.btnWhisperPartyMaster.Size = new System.Drawing.Size(75, 23);
            this.btnWhisperPartyMaster.TabIndex = 9;
            this.btnWhisperPartyMaster.Text = "Whisper";
            this.btnWhisperPartyMaster.UseVisualStyleBackColor = true;
            // 
            // btnJoinFormedParty
            // 
            this.btnJoinFormedParty.Location = new System.Drawing.Point(18, 14);
            this.btnJoinFormedParty.Name = "btnJoinFormedParty";
            this.btnJoinFormedParty.Size = new System.Drawing.Size(75, 23);
            this.btnJoinFormedParty.TabIndex = 8;
            this.btnJoinFormedParty.Text = "Join Party";
            this.btnJoinFormedParty.UseVisualStyleBackColor = true;
            this.btnJoinFormedParty.Click += new System.EventHandler(this.btnJoinFormedParty_Click);
            // 
            // btnPrev
            // 
            this.btnPrev.Enabled = false;
            this.btnPrev.Font = new System.Drawing.Font("Arial", 11.25F);
            this.btnPrev.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnPrev.Location = new System.Drawing.Point(315, 14);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(23, 23);
            this.btnPrev.TabIndex = 11;
            this.btnPrev.Text = "◀";
            this.btnPrev.UseVisualStyleBackColor = true;
            this.btnPrev.Click += new System.EventHandler(this.PageNatigateBtn_Click);
            // 
            // btnNext
            // 
            this.btnNext.Enabled = false;
            this.btnNext.Font = new System.Drawing.Font("Arial", 11.25F);
            this.btnNext.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnNext.Location = new System.Drawing.Point(387, 14);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(23, 23);
            this.btnNext.TabIndex = 12;
            this.btnNext.Text = "▶";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.PageNatigateBtn_Click);
            // 
            // lbl_partyPageRange
            // 
            this.lbl_partyPageRange.AutoSize = true;
            this.lbl_partyPageRange.BackColor = System.Drawing.Color.Transparent;
            this.lbl_partyPageRange.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_partyPageRange.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbl_partyPageRange.Location = new System.Drawing.Point(344, 15);
            this.lbl_partyPageRange.Name = "lbl_partyPageRange";
            this.lbl_partyPageRange.Size = new System.Drawing.Size(39, 19);
            this.lbl_partyPageRange.TabIndex = 13;
            this.lbl_partyPageRange.Text = "0 / 0";
            // 
            // tpPartyBuffing
            // 
            this.tpPartyBuffing.Controls.Add(this.groupBox4);
            this.tpPartyBuffing.Controls.Add(this.groupBox6);
            this.tpPartyBuffing.Controls.Add(this.groupBox5);
            this.tpPartyBuffing.Controls.Add(this.groupBox1);
            this.tpPartyBuffing.Location = new System.Drawing.Point(4, 25);
            this.tpPartyBuffing.Name = "tpPartyBuffing";
            this.tpPartyBuffing.Padding = new System.Windows.Forms.Padding(6);
            this.tpPartyBuffing.Size = new System.Drawing.Size(734, 426);
            this.tpPartyBuffing.TabIndex = 3;
            this.tpPartyBuffing.Text = "Buffing";
            this.tpPartyBuffing.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnAddBuffToMember);
            this.groupBox4.Controls.Add(this.buttonRemoveCharFromBuffing);
            this.groupBox4.Controls.Add(this.btnRemoveBuffFromMember);
            this.groupBox4.Controls.Add(this.listViewPartyMembers);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(273, 175);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(210, 245);
            this.groupBox4.TabIndex = 11;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Party Members";
            // 
            // btnAddBuffToMember
            // 
            this.btnAddBuffToMember.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddBuffToMember.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddBuffToMember.Location = new System.Drawing.Point(6, 216);
            this.btnAddBuffToMember.Name = "btnAddBuffToMember";
            this.btnAddBuffToMember.Size = new System.Drawing.Size(86, 21);
            this.btnAddBuffToMember.TabIndex = 11;
            this.btnAddBuffToMember.Text = "Add Buff";
            this.btnAddBuffToMember.UseVisualStyleBackColor = true;
            this.btnAddBuffToMember.Click += new System.EventHandler(this.btnAddBuffToMember_Click);
            // 
            // buttonRemoveCharFromBuffing
            // 
            this.buttonRemoveCharFromBuffing.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRemoveCharFromBuffing.Font = new System.Drawing.Font("Webdings", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.buttonRemoveCharFromBuffing.ForeColor = System.Drawing.Color.Transparent;
            this.buttonRemoveCharFromBuffing.Location = new System.Drawing.Point(179, 187);
            this.buttonRemoveCharFromBuffing.Name = "buttonRemoveCharFromBuffing";
            this.buttonRemoveCharFromBuffing.Size = new System.Drawing.Size(22, 19);
            this.buttonRemoveCharFromBuffing.TabIndex = 12;
            this.buttonRemoveCharFromBuffing.Text = "r";
            this.buttonRemoveCharFromBuffing.UseVisualStyleBackColor = true;
            this.buttonRemoveCharFromBuffing.Click += new System.EventHandler(this.buttonRemoveCharFromBuffing_Click);
            // 
            // btnRemoveBuffFromMember
            // 
            this.btnRemoveBuffFromMember.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveBuffFromMember.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveBuffFromMember.Location = new System.Drawing.Point(118, 216);
            this.btnRemoveBuffFromMember.Name = "btnRemoveBuffFromMember";
            this.btnRemoveBuffFromMember.Size = new System.Drawing.Size(86, 21);
            this.btnRemoveBuffFromMember.TabIndex = 12;
            this.btnRemoveBuffFromMember.Text = "Remove Buff";
            this.btnRemoveBuffFromMember.UseVisualStyleBackColor = true;
            this.btnRemoveBuffFromMember.Click += new System.EventHandler(this.btnRemoveBuffFromMember_Click);
            // 
            // listViewPartyMembers
            // 
            this.listViewPartyMembers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chPlayerName,
            this.chPlayerLevel});
            this.listViewPartyMembers.Dock = System.Windows.Forms.DockStyle.Top;
            this.listViewPartyMembers.FullRowSelect = true;
            this.listViewPartyMembers.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listViewPartyMembers.HideSelection = false;
            this.listViewPartyMembers.Location = new System.Drawing.Point(3, 16);
            this.listViewPartyMembers.MultiSelect = false;
            this.listViewPartyMembers.Name = "listViewPartyMembers";
            this.listViewPartyMembers.Size = new System.Drawing.Size(204, 197);
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
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.buttonAddGroup);
            this.groupBox6.Controls.Add(this.buttonRemoveGroup);
            this.groupBox6.Controls.Add(this.listViewGroups);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox6.Location = new System.Drawing.Point(273, 6);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(210, 169);
            this.groupBox6.TabIndex = 14;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Groups";
            // 
            // buttonAddGroup
            // 
            this.buttonAddGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonAddGroup.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAddGroup.Location = new System.Drawing.Point(6, 140);
            this.buttonAddGroup.Name = "buttonAddGroup";
            this.buttonAddGroup.Size = new System.Drawing.Size(63, 21);
            this.buttonAddGroup.TabIndex = 0;
            this.buttonAddGroup.Text = "Create";
            this.buttonAddGroup.UseVisualStyleBackColor = true;
            this.buttonAddGroup.Click += new System.EventHandler(this.buttonAddGroup_Click);
            // 
            // buttonRemoveGroup
            // 
            this.buttonRemoveGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRemoveGroup.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRemoveGroup.Location = new System.Drawing.Point(129, 140);
            this.buttonRemoveGroup.Name = "buttonRemoveGroup";
            this.buttonRemoveGroup.Size = new System.Drawing.Size(72, 21);
            this.buttonRemoveGroup.TabIndex = 0;
            this.buttonRemoveGroup.Text = "Remove";
            this.buttonRemoveGroup.UseVisualStyleBackColor = true;
            this.buttonRemoveGroup.Click += new System.EventHandler(this.buttonRemoveGroup_Click);
            // 
            // listViewGroups
            // 
            this.listViewGroups.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderGroupName,
            this.columnHeaderMembersCount});
            this.listViewGroups.Dock = System.Windows.Forms.DockStyle.Top;
            this.listViewGroups.FullRowSelect = true;
            this.listViewGroups.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listViewGroups.HideSelection = false;
            this.listViewGroups.Location = new System.Drawing.Point(3, 16);
            this.listViewGroups.MultiSelect = false;
            this.listViewGroups.Name = "listViewGroups";
            this.listViewGroups.Size = new System.Drawing.Size(204, 118);
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
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.selectedMemberBuffs);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox5.Location = new System.Drawing.Point(483, 6);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(245, 414);
            this.groupBox5.TabIndex = 12;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Member Buffs";
            // 
            // selectedMemberBuffs
            // 
            this.selectedMemberBuffs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.selectedMemberBuffs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.selectedMemberBuffs.FullRowSelect = true;
            this.selectedMemberBuffs.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.selectedMemberBuffs.HideSelection = false;
            this.selectedMemberBuffs.Location = new System.Drawing.Point(3, 16);
            this.selectedMemberBuffs.Name = "selectedMemberBuffs";
            this.selectedMemberBuffs.Size = new System.Drawing.Size(239, 395);
            this.selectedMemberBuffs.TabIndex = 9;
            this.selectedMemberBuffs.UseCompatibleStateImageBehavior = false;
            this.selectedMemberBuffs.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 220;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listPartyBuffSkills);
            this.groupBox1.Controls.Add(this.checkHideLowerLevelSkills);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(267, 414);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Buffs";
            // 
            // listPartyBuffSkills
            // 
            this.listPartyBuffSkills.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnName,
            this.columnLimit});
            this.listPartyBuffSkills.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listPartyBuffSkills.FullRowSelect = true;
            this.listPartyBuffSkills.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listPartyBuffSkills.HideSelection = false;
            this.listPartyBuffSkills.Location = new System.Drawing.Point(3, 16);
            this.listPartyBuffSkills.Name = "listPartyBuffSkills";
            this.listPartyBuffSkills.Size = new System.Drawing.Size(261, 378);
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
            // checkHideLowerLevelSkills
            // 
            this.checkHideLowerLevelSkills.AutoSize = true;
            this.checkHideLowerLevelSkills.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.checkHideLowerLevelSkills.Location = new System.Drawing.Point(3, 394);
            this.checkHideLowerLevelSkills.Name = "checkHideLowerLevelSkills";
            this.checkHideLowerLevelSkills.Size = new System.Drawing.Size(261, 17);
            this.checkHideLowerLevelSkills.TabIndex = 10;
            this.checkHideLowerLevelSkills.Text = "Hide lower level skills";
            this.checkHideLowerLevelSkills.UseVisualStyleBackColor = true;
            this.checkHideLowerLevelSkills.Visible = false;
            this.checkHideLowerLevelSkills.CheckedChanged += new System.EventHandler(this.checkHideLowerLevelSkills_CheckedChanged);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.tabMain);
            this.Name = "Main";
            this.Padding = new System.Windows.Forms.Padding(6);
            this.Size = new System.Drawing.Size(754, 467);
            this.tabMain.ResumeLayout(false);
            this.tabCurrentParty.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.grpPartySettings.ResumeLayout(false);
            this.grpPartySettings.PerformLayout();
            this.tpAutoParty.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.grbAutoPartySettings.ResumeLayout(false);
            this.grbAutoPartySettings.PerformLayout();
            this.tpPartyMatching.ResumeLayout(false);
            this.topPartyPanel.ResumeLayout(false);
            this.topPartyPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPartySearchMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPartySearchMin)).EndInit();
            this.bottomPartyPanel.ResumeLayout(false);
            this.bottomPartyPanel.PerformLayout();
            this.tpPartyBuffing.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private RSBot.Theme.Controls.TabControl tabMain;
        private System.Windows.Forms.TabPage tabCurrentParty;
        private System.Windows.Forms.ListView listParty;
        private System.Windows.Forms.ColumnHeader colMemberName;
        private System.Windows.Forms.ColumnHeader colLevel;
        private System.Windows.Forms.ColumnHeader colGuild;
        private System.Windows.Forms.ColumnHeader colMasteries;
        private System.Windows.Forms.Label lblLeader;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLeaveParty;
        private System.Windows.Forms.CheckBox checkCurrentAutoShareItems;
        private System.Windows.Forms.CheckBox checkCurrentAutoShareEXP;
        private System.Windows.Forms.CheckBox checkCurrentAllowInvitations;
        private System.Windows.Forms.GroupBox grpPartySettings;
        private System.Windows.Forms.ContextMenu contextParty;
        private System.Windows.Forms.MenuItem menuBanish;
        private System.Windows.Forms.MenuItem menuLeave;
        private System.Windows.Forms.TabPage tpAutoParty;
        private System.Windows.Forms.TabPage tpPartyMatching;
        private System.Windows.Forms.GroupBox grbAutoPartySettings;
        private System.Windows.Forms.CheckBox checkAutoAllowInvitations;
        private System.Windows.Forms.CheckBox checkAutoItemAutoShare;
        private System.Windows.Forms.CheckBox checkAutoExpAutoShare;
        private System.Windows.Forms.ListBox listAutoParty;
        private System.Windows.Forms.Button btnAddToAutoParty;
        private System.Windows.Forms.Button btnRemoveFromAutoParty;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox checkInviteFromList;
        private System.Windows.Forms.CheckBox checkInviteAll;
        private System.Windows.Forms.CheckBox checkAcceptFromList;
        private System.Windows.Forms.CheckBox checkAcceptAll;
        private System.Windows.Forms.CheckBox checkAcceptAtTrainingPlace;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Panel bottomPartyPanel;
        private System.Windows.Forms.Button btnPartyMatchDeleteEntry;
        private System.Windows.Forms.Button btnPartyMatchChangeEntry;
        private System.Windows.Forms.Button btnPartyMatchForm;
        private System.Windows.Forms.Button btnAutoMatchParty;
        private System.Windows.Forms.Button btnWhisperPartyMaster;
        private System.Windows.Forms.Button btnJoinFormedParty;
        public System.Windows.Forms.Button btnPrev;
        public System.Windows.Forms.Button btnNext;
        public System.Windows.Forms.ListView lvPartyMatching;
        private System.Windows.Forms.ColumnHeader chPartyMatchNo;
        private System.Windows.Forms.ColumnHeader chPartyMatchRace;
        private System.Windows.Forms.ColumnHeader chPartyMatchName;
        private System.Windows.Forms.ColumnHeader chPartyMatchTitle;
        private System.Windows.Forms.ColumnHeader chPartyMatchPurporse;
        private System.Windows.Forms.ColumnHeader chPartyMatchMember;
        private System.Windows.Forms.ColumnHeader chPartyMatchRange;
        private System.Windows.Forms.Label lbl_partyPageRange;
        private System.Windows.Forms.Panel topPartyPanel;
        private System.Windows.Forms.ComboBox cbPartySearchPurpose;
        private System.Windows.Forms.TextBox tbPartySearchName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnPartyRefresh;
        private System.Windows.Forms.Button btnPartySearch;
        private System.Windows.Forms.NumericUpDown nudPartySearchMax;
        private System.Windows.Forms.NumericUpDown nudPartySearchMin;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox checkAcceptIfBotStopped;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ColumnHeader colLocation;
        private System.Windows.Forms.TabPage tpPartyBuffing;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView listPartyBuffSkills;
        private System.Windows.Forms.ColumnHeader columnName;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.ListView selectedMemberBuffs;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.CheckBox checkHideLowerLevelSkills;
        private System.Windows.Forms.ColumnHeader columnLimit;
        private System.Windows.Forms.ListView listViewPartyMembers;
        private System.Windows.Forms.ColumnHeader chPlayerName;
        private System.Windows.Forms.ColumnHeader chPlayerLevel;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button buttonAddGroup;
        private System.Windows.Forms.Button buttonRemoveGroup;
        private System.Windows.Forms.ListView listViewGroups;
        private System.Windows.Forms.ColumnHeader columnHeaderGroupName;
        private System.Windows.Forms.ColumnHeader columnHeaderMembersCount;
        private System.Windows.Forms.Button btnAddBuffToMember;
        private System.Windows.Forms.Button btnRemoveBuffFromMember;
        private System.Windows.Forms.MenuItem menuItemAddToBuffing;
        private System.Windows.Forms.Button buttonRemoveCharFromBuffing;
    }
}
