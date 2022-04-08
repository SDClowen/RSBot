namespace RSBot.Skills.Views
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listAttackingSkills = new System.Windows.Forms.ListView();
            this.columnName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnLevel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label2 = new System.Windows.Forms.Label();
            this.comboMonsterType = new System.Windows.Forms.ComboBox();
            this.btnMoveAttackSkillDown = new System.Windows.Forms.Button();
            this.btnMoveAttackSkillUp = new System.Windows.Forms.Button();
            this.btnRemoveAttackSkill = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.listBuffs = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnMoveBuffSkillDown = new System.Windows.Forms.Button();
            this.comboImbue = new System.Windows.Forms.ComboBox();
            this.btnMoveBuffSkillUp = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRemoveBuffSkill = new System.Windows.Forms.Button();
            this.tabControl1 = new RSBot.Theme.Controls.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.comboResurrectionSkill = new System.Windows.Forms.ComboBox();
            this.checkAcceptResurrection = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.checkResurrectParty = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.checkCastBuffsDuringWalkBack = new System.Windows.Forms.CheckBox();
            this.checkCastBuffsInTowns = new System.Windows.Forms.CheckBox();
            this.tabControl2 = new RSBot.Theme.Controls.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.listSkills = new System.Windows.Forms.ListView();
            this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLevel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.checkHideLowerLevelSkills = new System.Windows.Forms.CheckBox();
            this.checkShowAttacks = new System.Windows.Forms.CheckBox();
            this.checkShowBuffs = new System.Windows.Forms.CheckBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.listActiveBuffs = new System.Windows.Forms.ListView();
            this.colActiveName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colActiveLevel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.skillContextMenu = new System.Windows.Forms.ContextMenu();
            this.skillContextMenuAddAttackSkill = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.skillContextMenuAddBuffSkill = new System.Windows.Forms.MenuItem();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listAttackingSkills);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.comboMonsterType);
            this.groupBox1.Controls.Add(this.btnMoveAttackSkillDown);
            this.groupBox1.Controls.Add(this.btnMoveAttackSkillUp);
            this.groupBox1.Controls.Add(this.btnRemoveAttackSkill);
            this.groupBox1.Location = new System.Drawing.Point(14, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(357, 198);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Attacking skills";
            // 
            // listAttackingSkills
            // 
            this.listAttackingSkills.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnName,
            this.columnLevel});
            this.listAttackingSkills.FullRowSelect = true;
            this.listAttackingSkills.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listAttackingSkills.HideSelection = false;
            this.listAttackingSkills.Location = new System.Drawing.Point(6, 19);
            this.listAttackingSkills.Name = "listAttackingSkills";
            this.listAttackingSkills.Size = new System.Drawing.Size(315, 146);
            this.listAttackingSkills.TabIndex = 8;
            this.listAttackingSkills.UseCompatibleStateImageBehavior = false;
            this.listAttackingSkills.View = System.Windows.Forms.View.Details;
            // 
            // columnName
            // 
            this.columnName.Text = "Name";
            this.columnName.Width = 248;
            // 
            // columnLevel
            // 
            this.columnLevel.Text = "Level";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 174);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Type:";
            // 
            // comboMonsterType
            // 
            this.comboMonsterType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboMonsterType.FormattingEnabled = true;
            this.comboMonsterType.Items.AddRange(new object[] {
            "General (Default)",
            "Champion",
            "Giant",
            "General (Party)",
            "Champion (Party)",
            "Giant (Party)",
            "Elite",
            "Strong",
            "Unique"});
            this.comboMonsterType.Location = new System.Drawing.Point(54, 171);
            this.comboMonsterType.Name = "comboMonsterType";
            this.comboMonsterType.Size = new System.Drawing.Size(267, 21);
            this.comboMonsterType.TabIndex = 2;
            this.comboMonsterType.SelectedIndexChanged += new System.EventHandler(this.comboMonsterType_SelectedIndexChanged);
            // 
            // btnMoveAttackSkillDown
            // 
            this.btnMoveAttackSkillDown.Font = new System.Drawing.Font("Webdings", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.btnMoveAttackSkillDown.Location = new System.Drawing.Point(327, 79);
            this.btnMoveAttackSkillDown.Name = "btnMoveAttackSkillDown";
            this.btnMoveAttackSkillDown.Size = new System.Drawing.Size(24, 24);
            this.btnMoveAttackSkillDown.TabIndex = 1;
            this.btnMoveAttackSkillDown.Text = "6";
            this.btnMoveAttackSkillDown.UseVisualStyleBackColor = true;
            this.btnMoveAttackSkillDown.Click += new System.EventHandler(this.btnMoveAttackSkillDown_Click);
            // 
            // btnMoveAttackSkillUp
            // 
            this.btnMoveAttackSkillUp.Font = new System.Drawing.Font("Webdings", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.btnMoveAttackSkillUp.Location = new System.Drawing.Point(327, 49);
            this.btnMoveAttackSkillUp.Name = "btnMoveAttackSkillUp";
            this.btnMoveAttackSkillUp.Size = new System.Drawing.Size(24, 24);
            this.btnMoveAttackSkillUp.TabIndex = 1;
            this.btnMoveAttackSkillUp.Text = "5";
            this.btnMoveAttackSkillUp.UseVisualStyleBackColor = true;
            this.btnMoveAttackSkillUp.Click += new System.EventHandler(this.btnMoveAttackSkillUp_Click);
            // 
            // btnRemoveAttackSkill
            // 
            this.btnRemoveAttackSkill.Font = new System.Drawing.Font("Webdings", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.btnRemoveAttackSkill.Location = new System.Drawing.Point(327, 19);
            this.btnRemoveAttackSkill.Name = "btnRemoveAttackSkill";
            this.btnRemoveAttackSkill.Size = new System.Drawing.Size(24, 24);
            this.btnRemoveAttackSkill.TabIndex = 1;
            this.btnRemoveAttackSkill.Text = "r";
            this.btnRemoveAttackSkill.UseVisualStyleBackColor = true;
            this.btnRemoveAttackSkill.Click += new System.EventHandler(this.btnRemoveAttackSkill_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.listBuffs);
            this.groupBox2.Controls.Add(this.btnMoveBuffSkillDown);
            this.groupBox2.Controls.Add(this.comboImbue);
            this.groupBox2.Controls.Add(this.btnMoveBuffSkillUp);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.btnRemoveBuffSkill);
            this.groupBox2.Location = new System.Drawing.Point(14, 216);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(357, 198);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Buffing skills";
            // 
            // listBuffs
            // 
            this.listBuffs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listBuffs.FullRowSelect = true;
            this.listBuffs.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listBuffs.HideSelection = false;
            this.listBuffs.Location = new System.Drawing.Point(6, 19);
            this.listBuffs.Name = "listBuffs";
            this.listBuffs.Size = new System.Drawing.Size(315, 146);
            this.listBuffs.TabIndex = 8;
            this.listBuffs.UseCompatibleStateImageBehavior = false;
            this.listBuffs.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 248;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Level";
            // 
            // btnMoveBuffSkillDown
            // 
            this.btnMoveBuffSkillDown.Font = new System.Drawing.Font("Webdings", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.btnMoveBuffSkillDown.Location = new System.Drawing.Point(327, 79);
            this.btnMoveBuffSkillDown.Name = "btnMoveBuffSkillDown";
            this.btnMoveBuffSkillDown.Size = new System.Drawing.Size(24, 24);
            this.btnMoveBuffSkillDown.TabIndex = 8;
            this.btnMoveBuffSkillDown.Text = "6";
            this.btnMoveBuffSkillDown.UseVisualStyleBackColor = true;
            this.btnMoveBuffSkillDown.Click += new System.EventHandler(this.btnMoveBuffSkillDown_Click);
            // 
            // comboImbue
            // 
            this.comboImbue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboImbue.FormattingEnabled = true;
            this.comboImbue.Location = new System.Drawing.Point(54, 171);
            this.comboImbue.Name = "comboImbue";
            this.comboImbue.Size = new System.Drawing.Size(267, 21);
            this.comboImbue.TabIndex = 7;
            this.comboImbue.SelectedIndexChanged += new System.EventHandler(this.comboImbue_SelectedIndexChanged);
            // 
            // btnMoveBuffSkillUp
            // 
            this.btnMoveBuffSkillUp.Font = new System.Drawing.Font("Webdings", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.btnMoveBuffSkillUp.Location = new System.Drawing.Point(327, 49);
            this.btnMoveBuffSkillUp.Name = "btnMoveBuffSkillUp";
            this.btnMoveBuffSkillUp.Size = new System.Drawing.Size(24, 24);
            this.btnMoveBuffSkillUp.TabIndex = 9;
            this.btnMoveBuffSkillUp.Text = "5";
            this.btnMoveBuffSkillUp.UseVisualStyleBackColor = true;
            this.btnMoveBuffSkillUp.Click += new System.EventHandler(this.btnMoveBuffSkillUp_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 174);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Imbue:";
            // 
            // btnRemoveBuffSkill
            // 
            this.btnRemoveBuffSkill.Font = new System.Drawing.Font("Webdings", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.btnRemoveBuffSkill.Location = new System.Drawing.Point(327, 19);
            this.btnRemoveBuffSkill.Name = "btnRemoveBuffSkill";
            this.btnRemoveBuffSkill.Size = new System.Drawing.Size(24, 24);
            this.btnRemoveBuffSkill.TabIndex = 5;
            this.btnRemoveBuffSkill.Text = "r";
            this.btnRemoveBuffSkill.UseVisualStyleBackColor = true;
            this.btnRemoveBuffSkill.Click += new System.EventHandler(this.btnRemoveBuffSkill_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Right;
            this.tabControl1.Location = new System.Drawing.Point(356, 6);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(392, 455);
            this.tabControl1.TabIndex = 5;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(384, 426);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "General setup";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.Transparent;
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Controls.Add(this.groupBox4);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(384, 426);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Advanced setup";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.comboResurrectionSkill);
            this.groupBox3.Controls.Add(this.checkAcceptResurrection);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.checkResurrectParty);
            this.groupBox3.Location = new System.Drawing.Point(8, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(367, 105);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Automated resurrection";
            // 
            // comboResurrectionSkill
            // 
            this.comboResurrectionSkill.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboResurrectionSkill.FormattingEnabled = true;
            this.comboResurrectionSkill.Location = new System.Drawing.Point(86, 22);
            this.comboResurrectionSkill.Name = "comboResurrectionSkill";
            this.comboResurrectionSkill.Size = new System.Drawing.Size(255, 21);
            this.comboResurrectionSkill.TabIndex = 8;
            this.comboResurrectionSkill.SelectedIndexChanged += new System.EventHandler(this.comboResurrectionSkill_SelectedIndexChanged);
            // 
            // checkAcceptResurrection
            // 
            this.checkAcceptResurrection.AutoSize = true;
            this.checkAcceptResurrection.Location = new System.Drawing.Point(86, 76);
            this.checkAcceptResurrection.Name = "checkAcceptResurrection";
            this.checkAcceptResurrection.Size = new System.Drawing.Size(142, 17);
            this.checkAcceptResurrection.TabIndex = 9;
            this.checkAcceptResurrection.Text = "Auto accept resurrection";
            this.checkAcceptResurrection.UseVisualStyleBackColor = true;
            this.checkAcceptResurrection.CheckedChanged += new System.EventHandler(this.checkAcceptResurrection_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Res. skill:";
            // 
            // checkResurrectParty
            // 
            this.checkResurrectParty.AutoSize = true;
            this.checkResurrectParty.Location = new System.Drawing.Point(86, 51);
            this.checkResurrectParty.Name = "checkResurrectParty";
            this.checkResurrectParty.Size = new System.Drawing.Size(163, 17);
            this.checkResurrectParty.TabIndex = 6;
            this.checkResurrectParty.Text = "Auto resurrect party members";
            this.checkResurrectParty.UseVisualStyleBackColor = true;
            this.checkResurrectParty.CheckedChanged += new System.EventHandler(this.checkResurrectParty_CheckedChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.checkCastBuffsDuringWalkBack);
            this.groupBox4.Controls.Add(this.checkCastBuffsInTowns);
            this.groupBox4.Location = new System.Drawing.Point(8, 117);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(367, 89);
            this.groupBox4.TabIndex = 12;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Advanced buff configuration";
            // 
            // checkCastBuffsDuringWalkBack
            // 
            this.checkCastBuffsDuringWalkBack.AutoSize = true;
            this.checkCastBuffsDuringWalkBack.Location = new System.Drawing.Point(86, 47);
            this.checkCastBuffsDuringWalkBack.Name = "checkCastBuffsDuringWalkBack";
            this.checkCastBuffsDuringWalkBack.Size = new System.Drawing.Size(152, 17);
            this.checkCastBuffsDuringWalkBack.TabIndex = 10;
            this.checkCastBuffsDuringWalkBack.Text = "Cast buffs while walk-back";
            this.checkCastBuffsDuringWalkBack.UseVisualStyleBackColor = true;
            this.checkCastBuffsDuringWalkBack.CheckedChanged += new System.EventHandler(this.checkCastBuffsWhenWalkBack_CheckedChanged);
            // 
            // checkCastBuffsInTowns
            // 
            this.checkCastBuffsInTowns.AutoSize = true;
            this.checkCastBuffsInTowns.Location = new System.Drawing.Point(86, 22);
            this.checkCastBuffsInTowns.Name = "checkCastBuffsInTowns";
            this.checkCastBuffsInTowns.Size = new System.Drawing.Size(115, 17);
            this.checkCastBuffsInTowns.TabIndex = 10;
            this.checkCastBuffsInTowns.Text = "Cast buffs in towns";
            this.checkCastBuffsInTowns.UseVisualStyleBackColor = true;
            this.checkCastBuffsInTowns.CheckedChanged += new System.EventHandler(this.checkCastBuffsInTowns_CheckedChanged);
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage3);
            this.tabControl2.Controls.Add(this.tabPage4);
            this.tabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl2.Location = new System.Drawing.Point(6, 6);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(350, 455);
            this.tabControl2.TabIndex = 6;
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.Transparent;
            this.tabPage3.Controls.Add(this.listSkills);
            this.tabPage3.Controls.Add(this.panel1);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(342, 426);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "Player skills";
            // 
            // listSkills
            // 
            this.listSkills.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listSkills.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colName,
            this.colLevel});
            this.listSkills.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listSkills.FullRowSelect = true;
            this.listSkills.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listSkills.HideSelection = false;
            this.listSkills.Location = new System.Drawing.Point(3, 3);
            this.listSkills.Name = "listSkills";
            this.listSkills.Size = new System.Drawing.Size(336, 391);
            this.listSkills.TabIndex = 5;
            this.listSkills.UseCompatibleStateImageBehavior = false;
            this.listSkills.View = System.Windows.Forms.View.Details;
            // 
            // colName
            // 
            this.colName.Text = "Name";
            this.colName.Width = 226;
            // 
            // colLevel
            // 
            this.colLevel.Text = "";
            this.colLevel.Width = 69;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.checkHideLowerLevelSkills);
            this.panel1.Controls.Add(this.checkShowAttacks);
            this.panel1.Controls.Add(this.checkShowBuffs);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(3, 394);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(336, 29);
            this.panel1.TabIndex = 9;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(336, 1);
            this.panel2.TabIndex = 9;
            // 
            // checkHideLowerLevelSkills
            // 
            this.checkHideLowerLevelSkills.AutoSize = true;
            this.checkHideLowerLevelSkills.Location = new System.Drawing.Point(207, 6);
            this.checkHideLowerLevelSkills.Name = "checkHideLowerLevelSkills";
            this.checkHideLowerLevelSkills.Size = new System.Drawing.Size(126, 17);
            this.checkHideLowerLevelSkills.TabIndex = 6;
            this.checkHideLowerLevelSkills.Text = "Hide lower level skills";
            this.checkHideLowerLevelSkills.UseVisualStyleBackColor = true;
            this.checkHideLowerLevelSkills.CheckedChanged += new System.EventHandler(this.Filter_CheckedChanged);
            // 
            // checkShowAttacks
            // 
            this.checkShowAttacks.AutoSize = true;
            this.checkShowAttacks.Checked = true;
            this.checkShowAttacks.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkShowAttacks.Location = new System.Drawing.Point(8, 6);
            this.checkShowAttacks.Name = "checkShowAttacks";
            this.checkShowAttacks.Size = new System.Drawing.Size(62, 17);
            this.checkShowAttacks.TabIndex = 7;
            this.checkShowAttacks.Text = "Attacks";
            this.checkShowAttacks.UseVisualStyleBackColor = true;
            this.checkShowAttacks.CheckedChanged += new System.EventHandler(this.Filter_CheckedChanged);
            // 
            // checkShowBuffs
            // 
            this.checkShowBuffs.AutoSize = true;
            this.checkShowBuffs.Checked = true;
            this.checkShowBuffs.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkShowBuffs.Location = new System.Drawing.Point(79, 6);
            this.checkShowBuffs.Name = "checkShowBuffs";
            this.checkShowBuffs.Size = new System.Drawing.Size(50, 17);
            this.checkShowBuffs.TabIndex = 8;
            this.checkShowBuffs.Text = "Buffs";
            this.checkShowBuffs.UseVisualStyleBackColor = true;
            this.checkShowBuffs.CheckedChanged += new System.EventHandler(this.Filter_CheckedChanged);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.listActiveBuffs);
            this.tabPage4.Location = new System.Drawing.Point(4, 25);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(342, 426);
            this.tabPage4.TabIndex = 1;
            this.tabPage4.Text = "Active buffs";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // listActiveBuffs
            // 
            this.listActiveBuffs.BackColor = System.Drawing.Color.White;
            this.listActiveBuffs.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listActiveBuffs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colActiveName,
            this.colActiveLevel});
            this.listActiveBuffs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listActiveBuffs.FullRowSelect = true;
            this.listActiveBuffs.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listActiveBuffs.HideSelection = false;
            this.listActiveBuffs.Location = new System.Drawing.Point(3, 3);
            this.listActiveBuffs.Name = "listActiveBuffs";
            this.listActiveBuffs.Size = new System.Drawing.Size(336, 420);
            this.listActiveBuffs.TabIndex = 6;
            this.listActiveBuffs.UseCompatibleStateImageBehavior = false;
            this.listActiveBuffs.View = System.Windows.Forms.View.Details;
            // 
            // colActiveName
            // 
            this.colActiveName.Text = "Name";
            this.colActiveName.Width = 226;
            // 
            // colActiveLevel
            // 
            this.colActiveLevel.Text = "";
            this.colActiveLevel.Width = 69;
            // 
            // skillContextMenu
            // 
            this.skillContextMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.skillContextMenuAddAttackSkill,
            this.menuItem2,
            this.skillContextMenuAddBuffSkill});
            // 
            // skillContextMenuAddAttackSkill
            // 
            this.skillContextMenuAddAttackSkill.Index = 0;
            this.skillContextMenuAddAttackSkill.Text = "Add To Attacks";
            this.skillContextMenuAddAttackSkill.Click += new System.EventHandler(this.menuAddAttack_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 1;
            this.menuItem2.Text = "-";
            // 
            // skillContextMenuAddBuffSkill
            // 
            this.skillContextMenuAddBuffSkill.Index = 2;
            this.skillContextMenuAddBuffSkill.Text = "Add To Buffs";
            this.skillContextMenuAddBuffSkill.Click += new System.EventHandler(this.menuAddBuff_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.tabControl2);
            this.Controls.Add(this.tabControl1);
            this.Name = "Main";
            this.Padding = new System.Windows.Forms.Padding(6);
            this.Size = new System.Drawing.Size(754, 467);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.tabControl2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnRemoveAttackSkill;
        private System.Windows.Forms.Button btnMoveAttackSkillDown;
        private System.Windows.Forms.Button btnMoveAttackSkillUp;
        private System.Windows.Forms.ComboBox comboImbue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRemoveBuffSkill;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboMonsterType;
        private RSBot.Theme.Controls.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ComboBox comboResurrectionSkill;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkResurrectParty;
        private System.Windows.Forms.CheckBox checkAcceptResurrection;
        private System.Windows.Forms.CheckBox checkCastBuffsInTowns;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox checkCastBuffsDuringWalkBack;
        private RSBot.Theme.Controls.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.CheckBox checkShowAttacks;
        private System.Windows.Forms.CheckBox checkShowBuffs;
        private System.Windows.Forms.CheckBox checkHideLowerLevelSkills;
        private System.Windows.Forms.ListView listSkills;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colLevel;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.ListView listActiveBuffs;
        private System.Windows.Forms.ColumnHeader colActiveName;
        private System.Windows.Forms.ColumnHeader colActiveLevel;
        private System.Windows.Forms.Button btnMoveBuffSkillDown;
        private System.Windows.Forms.Button btnMoveBuffSkillUp;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListView listAttackingSkills;
        private System.Windows.Forms.ColumnHeader columnName;
        private System.Windows.Forms.ColumnHeader columnLevel;
        private System.Windows.Forms.ListView listBuffs;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ContextMenu skillContextMenu;
        private System.Windows.Forms.MenuItem menuItem2;
        private System.Windows.Forms.MenuItem skillContextMenuAddBuffSkill;
        private System.Windows.Forms.MenuItem skillContextMenuAddAttackSkill;
    }
}
