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
            components = new System.ComponentModel.Container();
            groupBoxAttackingSkills = new System.Windows.Forms.GroupBox();
            checkUseSkillsInOrder = new System.Windows.Forms.CheckBox();
            checkBoxNoAttack = new System.Windows.Forms.CheckBox();
            listAttackingSkills = new System.Windows.Forms.ListView();
            columnName = new System.Windows.Forms.ColumnHeader();
            columnLevel = new System.Windows.Forms.ColumnHeader();
            label2 = new System.Windows.Forms.Label();
            comboMonsterType = new System.Windows.Forms.ComboBox();
            btnMoveAttackSkillDown = new System.Windows.Forms.Button();
            btnMoveAttackSkillUp = new System.Windows.Forms.Button();
            btnRemoveAttackSkill = new System.Windows.Forms.Button();
            groupBox2 = new System.Windows.Forms.GroupBox();
            listBuffs = new System.Windows.Forms.ListView();
            columnHeader1 = new System.Windows.Forms.ColumnHeader();
            columnHeader2 = new System.Windows.Forms.ColumnHeader();
            btnMoveBuffSkillDown = new System.Windows.Forms.Button();
            comboImbue = new System.Windows.Forms.ComboBox();
            btnMoveBuffSkillUp = new System.Windows.Forms.Button();
            label1 = new System.Windows.Forms.Label();
            btnRemoveBuffSkill = new System.Windows.Forms.Button();
            tabControl1 = new System.Windows.Forms.TabControl();
            tabPage1 = new System.Windows.Forms.TabPage();
            tabPage2 = new System.Windows.Forms.TabPage();
            groupAdvancedSetup = new System.Windows.Forms.GroupBox();
            comboTeleportSkill = new System.Windows.Forms.ComboBox();
            checkUseTeleportSkill = new System.Windows.Forms.CheckBox();
            checkUseDefaultAttack = new System.Windows.Forms.CheckBox();
            checkWarlockMode = new System.Windows.Forms.CheckBox();
            grpMasteryUpdate = new System.Windows.Forms.GroupBox();
            checkLearnMasteryBotStopped = new System.Windows.Forms.CheckBox();
            label4 = new System.Windows.Forms.Label();
            numMasteryGap = new System.Windows.Forms.NumericUpDown();
            comboLearnMastery = new System.Windows.Forms.ComboBox();
            checkLearnMastery = new System.Windows.Forms.CheckBox();
            groupBoxAutomatedResurrection = new System.Windows.Forms.GroupBox();
            comboResurrectionSkill = new System.Windows.Forms.ComboBox();
            checkAcceptResurrection = new System.Windows.Forms.CheckBox();
            label3 = new System.Windows.Forms.Label();
            checkResurrectParty = new System.Windows.Forms.CheckBox();
            groupBoxAdvancedBuff = new System.Windows.Forms.GroupBox();
            checkCastBuffsDuringWalkBack = new System.Windows.Forms.CheckBox();
            checkCastBuffsInTowns = new System.Windows.Forms.CheckBox();
            tabControl2 = new System.Windows.Forms.TabControl();
            tabPage3 = new System.Windows.Forms.TabPage();
            listSkills = new System.Windows.Forms.ListView();
            colName = new System.Windows.Forms.ColumnHeader();
            colLevel = new System.Windows.Forms.ColumnHeader();
            skillContextMenu = new System.Windows.Forms.ContextMenuStrip(components);
            skillContextMenuAddAttackSkill = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            skillContextMenuAddBuffSkill = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            useToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            useToPartyMemberToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            panelPlayerSkills = new System.Windows.Forms.Panel();
            panel2 = new System.Windows.Forms.Panel();
            checkHideLowerLevelSkills = new System.Windows.Forms.CheckBox();
            checkShowAttacks = new System.Windows.Forms.CheckBox();
            checkShowBuffs = new System.Windows.Forms.CheckBox();
            tabPage4 = new System.Windows.Forms.TabPage();
            listActiveBuffs = new System.Windows.Forms.ListView();
            colActiveName = new System.Windows.Forms.ColumnHeader();
            colActiveLevel = new System.Windows.Forms.ColumnHeader();
            groupBoxAttackingSkills.SuspendLayout();
            groupBox2.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            groupAdvancedSetup.SuspendLayout();
            grpMasteryUpdate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numMasteryGap).BeginInit();
            groupBoxAutomatedResurrection.SuspendLayout();
            groupBoxAdvancedBuff.SuspendLayout();
            tabControl2.SuspendLayout();
            tabPage3.SuspendLayout();
            skillContextMenu.SuspendLayout();
            panelPlayerSkills.SuspendLayout();
            tabPage4.SuspendLayout();
            SuspendLayout();
            // 
            // groupBoxAttackingSkills
            // 
            groupBoxAttackingSkills.Controls.Add(checkUseSkillsInOrder);
            groupBoxAttackingSkills.Controls.Add(checkBoxNoAttack);
            groupBoxAttackingSkills.Controls.Add(listAttackingSkills);
            groupBoxAttackingSkills.Controls.Add(label2);
            groupBoxAttackingSkills.Controls.Add(comboMonsterType);
            groupBoxAttackingSkills.Controls.Add(btnMoveAttackSkillDown);
            groupBoxAttackingSkills.Controls.Add(btnMoveAttackSkillUp);
            groupBoxAttackingSkills.Controls.Add(btnRemoveAttackSkill);
            groupBoxAttackingSkills.Location = new System.Drawing.Point(18, 6);
            groupBoxAttackingSkills.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            groupBoxAttackingSkills.Name = "groupBoxAttackingSkills";
            groupBoxAttackingSkills.Padding = new System.Windows.Forms.Padding(4, 12, 4, 4);
            groupBoxAttackingSkills.Size = new System.Drawing.Size(446, 266);
            groupBoxAttackingSkills.TabIndex = 1;
            groupBoxAttackingSkills.TabStop = false;
            groupBoxAttackingSkills.Text = "Attacking skills";
            // 
            // checkUseSkillsInOrder
            // 
            checkUseSkillsInOrder.AutoSize = true;
            checkUseSkillsInOrder.Location = new System.Drawing.Point(289, 232);
            checkUseSkillsInOrder.Margin = new System.Windows.Forms.Padding(0);
            checkUseSkillsInOrder.Name = "checkUseSkillsInOrder";
            checkUseSkillsInOrder.Size = new System.Drawing.Size(111, 24);
            checkUseSkillsInOrder.TabIndex = 10;
            checkUseSkillsInOrder.Text = "Use in order";
            checkUseSkillsInOrder.UseVisualStyleBackColor = false;
            checkUseSkillsInOrder.CheckedChanged += settings_CheckedChanged;
            // 
            // checkBoxNoAttack
            // 
            checkBoxNoAttack.AutoSize = true;
            checkBoxNoAttack.Location = new System.Drawing.Point(289, 208);
            checkBoxNoAttack.Margin = new System.Windows.Forms.Padding(0);
            checkBoxNoAttack.Name = "checkBoxNoAttack";
            checkBoxNoAttack.Size = new System.Drawing.Size(97, 24);
            checkBoxNoAttack.TabIndex = 9;
            checkBoxNoAttack.Text = "No Attack";
            checkBoxNoAttack.UseVisualStyleBackColor = true;
            checkBoxNoAttack.CheckedChanged += settings_CheckedChanged;
            // 
            // listAttackingSkills
            // 
            listAttackingSkills.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { columnName, columnLevel });
            listAttackingSkills.FullRowSelect = true;
            listAttackingSkills.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            listAttackingSkills.Location = new System.Drawing.Point(8, 22);
            listAttackingSkills.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            listAttackingSkills.Name = "listAttackingSkills";
            listAttackingSkills.Size = new System.Drawing.Size(393, 182);
            listAttackingSkills.TabIndex = 8;
            listAttackingSkills.UseCompatibleStateImageBehavior = false;
            listAttackingSkills.View = System.Windows.Forms.View.Details;
            // 
            // columnName
            // 
            columnName.Text = "Name";
            columnName.Width = 248;
            // 
            // columnLevel
            // 
            columnLevel.Text = "Level";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(22, 219);
            label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(43, 20);
            label2.TabIndex = 7;
            label2.Text = "Type:";
            // 
            // comboMonsterType
            // 
            comboMonsterType.DropDownHeight = 100;
            comboMonsterType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboMonsterType.FormattingEnabled = true;
            comboMonsterType.IntegralHeight = false;
            comboMonsterType.ItemHeight = 20;
            comboMonsterType.Items.AddRange(new object[] { "General (Default)", "Champion", "Giant", "General (Party)", "Champion (Party)", "Giant (Party)", "Elite", "Strong", "Unique", "Event" });
            comboMonsterType.Location = new System.Drawing.Point(72, 216);
            comboMonsterType.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            comboMonsterType.Name = "comboMonsterType";
            comboMonsterType.Size = new System.Drawing.Size(213, 28);
            comboMonsterType.TabIndex = 2;
            comboMonsterType.SelectedIndexChanged += comboMonsterType_SelectedIndexChanged;
            // 
            // btnMoveAttackSkillDown
            // 
            btnMoveAttackSkillDown.AutoSize = true;
            btnMoveAttackSkillDown.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            btnMoveAttackSkillDown.Font = new System.Drawing.Font("Webdings", 9.75F);
            btnMoveAttackSkillDown.Location = new System.Drawing.Point(402, 97);
            btnMoveAttackSkillDown.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            btnMoveAttackSkillDown.Name = "btnMoveAttackSkillDown";
            btnMoveAttackSkillDown.Size = new System.Drawing.Size(37, 32);
            btnMoveAttackSkillDown.TabIndex = 1;
            btnMoveAttackSkillDown.Text = "6";
            btnMoveAttackSkillDown.UseVisualStyleBackColor = true;
            btnMoveAttackSkillDown.Click += btnMoveAttackSkillDown_Click;
            // 
            // btnMoveAttackSkillUp
            // 
            btnMoveAttackSkillUp.AutoSize = true;
            btnMoveAttackSkillUp.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            btnMoveAttackSkillUp.Font = new System.Drawing.Font("Webdings", 9.75F);
            btnMoveAttackSkillUp.Location = new System.Drawing.Point(402, 60);
            btnMoveAttackSkillUp.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            btnMoveAttackSkillUp.Name = "btnMoveAttackSkillUp";
            btnMoveAttackSkillUp.Size = new System.Drawing.Size(37, 32);
            btnMoveAttackSkillUp.TabIndex = 1;
            btnMoveAttackSkillUp.Text = "5";
            btnMoveAttackSkillUp.UseVisualStyleBackColor = true;
            btnMoveAttackSkillUp.Click += btnMoveAttackSkillUp_Click;
            // 
            // btnRemoveAttackSkill
            // 
            btnRemoveAttackSkill.AutoSize = true;
            btnRemoveAttackSkill.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            btnRemoveAttackSkill.Font = new System.Drawing.Font("Webdings", 9.75F);
            btnRemoveAttackSkill.Location = new System.Drawing.Point(402, 22);
            btnRemoveAttackSkill.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            btnRemoveAttackSkill.Name = "btnRemoveAttackSkill";
            btnRemoveAttackSkill.Size = new System.Drawing.Size(37, 32);
            btnRemoveAttackSkill.TabIndex = 1;
            btnRemoveAttackSkill.Text = "r";
            btnRemoveAttackSkill.UseVisualStyleBackColor = true;
            btnRemoveAttackSkill.Click += btnRemoveAttackSkill_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(listBuffs);
            groupBox2.Controls.Add(btnMoveBuffSkillDown);
            groupBox2.Controls.Add(comboImbue);
            groupBox2.Controls.Add(btnMoveBuffSkillUp);
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(btnRemoveBuffSkill);
            groupBox2.Location = new System.Drawing.Point(18, 280);
            groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new System.Windows.Forms.Padding(4, 12, 4, 4);
            groupBox2.Size = new System.Drawing.Size(446, 248);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "Buffing skills";
            // 
            // listBuffs
            // 
            listBuffs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { columnHeader1, columnHeader2 });
            listBuffs.FullRowSelect = true;
            listBuffs.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            listBuffs.Location = new System.Drawing.Point(8, 34);
            listBuffs.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            listBuffs.Name = "listBuffs";
            listBuffs.Size = new System.Drawing.Size(393, 172);
            listBuffs.TabIndex = 8;
            listBuffs.UseCompatibleStateImageBehavior = false;
            listBuffs.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Name";
            columnHeader1.Width = 248;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Level";
            // 
            // btnMoveBuffSkillDown
            // 
            btnMoveBuffSkillDown.AutoSize = true;
            btnMoveBuffSkillDown.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            btnMoveBuffSkillDown.Font = new System.Drawing.Font("Webdings", 9.75F);
            btnMoveBuffSkillDown.Location = new System.Drawing.Point(402, 107);
            btnMoveBuffSkillDown.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            btnMoveBuffSkillDown.Name = "btnMoveBuffSkillDown";
            btnMoveBuffSkillDown.Size = new System.Drawing.Size(37, 32);
            btnMoveBuffSkillDown.TabIndex = 8;
            btnMoveBuffSkillDown.Text = "6";
            btnMoveBuffSkillDown.UseVisualStyleBackColor = true;
            btnMoveBuffSkillDown.Click += btnMoveBuffSkillDown_Click;
            // 
            // comboImbue
            // 
            comboImbue.DropDownHeight = 100;
            comboImbue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboImbue.FormattingEnabled = true;
            comboImbue.IntegralHeight = false;
            comboImbue.ItemHeight = 20;
            comboImbue.Location = new System.Drawing.Point(68, 214);
            comboImbue.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            comboImbue.Name = "comboImbue";
            comboImbue.Size = new System.Drawing.Size(333, 28);
            comboImbue.TabIndex = 7;
            comboImbue.SelectedIndexChanged += comboImbue_SelectedIndexChanged;
            // 
            // btnMoveBuffSkillUp
            // 
            btnMoveBuffSkillUp.AutoSize = true;
            btnMoveBuffSkillUp.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            btnMoveBuffSkillUp.Font = new System.Drawing.Font("Webdings", 9.75F);
            btnMoveBuffSkillUp.Location = new System.Drawing.Point(402, 71);
            btnMoveBuffSkillUp.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            btnMoveBuffSkillUp.Name = "btnMoveBuffSkillUp";
            btnMoveBuffSkillUp.Size = new System.Drawing.Size(37, 32);
            btnMoveBuffSkillUp.TabIndex = 9;
            btnMoveBuffSkillUp.Text = "5";
            btnMoveBuffSkillUp.UseVisualStyleBackColor = true;
            btnMoveBuffSkillUp.Click += btnMoveBuffSkillUp_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(11, 218);
            label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(54, 20);
            label1.TabIndex = 6;
            label1.Text = "Imbue:";
            // 
            // btnRemoveBuffSkill
            // 
            btnRemoveBuffSkill.AutoSize = true;
            btnRemoveBuffSkill.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            btnRemoveBuffSkill.Font = new System.Drawing.Font("Webdings", 9.75F);
            btnRemoveBuffSkill.Location = new System.Drawing.Point(402, 34);
            btnRemoveBuffSkill.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            btnRemoveBuffSkill.Name = "btnRemoveBuffSkill";
            btnRemoveBuffSkill.Size = new System.Drawing.Size(37, 32);
            btnRemoveBuffSkill.TabIndex = 5;
            btnRemoveBuffSkill.Text = "r";
            btnRemoveBuffSkill.UseVisualStyleBackColor = true;
            btnRemoveBuffSkill.Click += btnRemoveBuffSkill_Click;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Dock = System.Windows.Forms.DockStyle.Right;
            tabControl1.ItemSize = new System.Drawing.Size(80, 24);
            tabControl1.Location = new System.Drawing.Point(447, 5);
            tabControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new System.Drawing.Size(490, 574);
            tabControl1.TabIndex = 5;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(groupBoxAttackingSkills);
            tabPage1.Controls.Add(groupBox2);
            tabPage1.Location = new System.Drawing.Point(4, 28);
            tabPage1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            tabPage1.Size = new System.Drawing.Size(482, 542);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "General setup";
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(groupAdvancedSetup);
            tabPage2.Controls.Add(grpMasteryUpdate);
            tabPage2.Controls.Add(groupBoxAutomatedResurrection);
            tabPage2.Controls.Add(groupBoxAdvancedBuff);
            tabPage2.Location = new System.Drawing.Point(4, 28);
            tabPage2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            tabPage2.Size = new System.Drawing.Size(482, 542);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Advanced setup";
            // 
            // groupAdvancedSetup
            // 
            groupAdvancedSetup.Controls.Add(comboTeleportSkill);
            groupAdvancedSetup.Controls.Add(checkUseTeleportSkill);
            groupAdvancedSetup.Controls.Add(checkUseDefaultAttack);
            groupAdvancedSetup.Controls.Add(checkWarlockMode);
            groupAdvancedSetup.Location = new System.Drawing.Point(10, 382);
            groupAdvancedSetup.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            groupAdvancedSetup.Name = "groupAdvancedSetup";
            groupAdvancedSetup.Padding = new System.Windows.Forms.Padding(4, 12, 4, 4);
            groupAdvancedSetup.Size = new System.Drawing.Size(459, 154);
            groupAdvancedSetup.TabIndex = 14;
            groupAdvancedSetup.TabStop = false;
            groupAdvancedSetup.Text = "Advanced setup";
            // 
            // comboTeleportSkill
            // 
            comboTeleportSkill.DropDownHeight = 100;
            comboTeleportSkill.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboTeleportSkill.FormattingEnabled = true;
            comboTeleportSkill.IntegralHeight = false;
            comboTeleportSkill.ItemHeight = 20;
            comboTeleportSkill.Location = new System.Drawing.Point(167, 90);
            comboTeleportSkill.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            comboTeleportSkill.Name = "comboTeleportSkill";
            comboTeleportSkill.Size = new System.Drawing.Size(259, 28);
            comboTeleportSkill.TabIndex = 9;
            comboTeleportSkill.SelectedIndexChanged += comboTeleportSkill_SelectedIndexChanged;
            // 
            // checkUseTeleportSkill
            // 
            checkUseTeleportSkill.AutoSize = true;
            checkUseTeleportSkill.Location = new System.Drawing.Point(19, 90);
            checkUseTeleportSkill.Margin = new System.Windows.Forms.Padding(0);
            checkUseTeleportSkill.Name = "checkUseTeleportSkill";
            checkUseTeleportSkill.Size = new System.Drawing.Size(144, 24);
            checkUseTeleportSkill.TabIndex = 2;
            checkUseTeleportSkill.Text = "Use teleport skill:";
            checkUseTeleportSkill.UseVisualStyleBackColor = false;
            checkUseTeleportSkill.CheckedChanged += settings_CheckedChanged;
            // 
            // checkUseDefaultAttack
            // 
            checkUseDefaultAttack.AutoSize = true;
            checkUseDefaultAttack.Checked = true;
            checkUseDefaultAttack.CheckState = System.Windows.Forms.CheckState.Checked;
            checkUseDefaultAttack.Location = new System.Drawing.Point(19, 60);
            checkUseDefaultAttack.Margin = new System.Windows.Forms.Padding(0);
            checkUseDefaultAttack.Name = "checkUseDefaultAttack";
            checkUseDefaultAttack.Size = new System.Drawing.Size(291, 24);
            checkUseDefaultAttack.TabIndex = 1;
            checkUseDefaultAttack.Text = "Use normal attack if no skill is available";
            checkUseDefaultAttack.UseVisualStyleBackColor = false;
            checkUseDefaultAttack.CheckedChanged += settings_CheckedChanged;
            // 
            // checkWarlockMode
            // 
            checkWarlockMode.AutoSize = true;
            checkWarlockMode.Location = new System.Drawing.Point(19, 36);
            checkWarlockMode.Margin = new System.Windows.Forms.Padding(0);
            checkWarlockMode.Name = "checkWarlockMode";
            checkWarlockMode.Size = new System.Drawing.Size(209, 24);
            checkWarlockMode.TabIndex = 0;
            checkWarlockMode.Text = "Change target after 2 DoTs";
            checkWarlockMode.UseVisualStyleBackColor = false;
            checkWarlockMode.CheckedChanged += settings_CheckedChanged;
            // 
            // grpMasteryUpdate
            // 
            grpMasteryUpdate.Controls.Add(checkLearnMasteryBotStopped);
            grpMasteryUpdate.Controls.Add(label4);
            grpMasteryUpdate.Controls.Add(numMasteryGap);
            grpMasteryUpdate.Controls.Add(comboLearnMastery);
            grpMasteryUpdate.Controls.Add(checkLearnMastery);
            grpMasteryUpdate.Location = new System.Drawing.Point(10, 263);
            grpMasteryUpdate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            grpMasteryUpdate.Name = "grpMasteryUpdate";
            grpMasteryUpdate.Padding = new System.Windows.Forms.Padding(4, 12, 4, 4);
            grpMasteryUpdate.Size = new System.Drawing.Size(459, 111);
            grpMasteryUpdate.TabIndex = 13;
            grpMasteryUpdate.TabStop = false;
            grpMasteryUpdate.Text = "Mastery update";
            // 
            // checkLearnMasteryBotStopped
            // 
            checkLearnMasteryBotStopped.AutoSize = true;
            checkLearnMasteryBotStopped.Location = new System.Drawing.Point(19, 70);
            checkLearnMasteryBotStopped.Margin = new System.Windows.Forms.Padding(0);
            checkLearnMasteryBotStopped.Name = "checkLearnMasteryBotStopped";
            checkLearnMasteryBotStopped.Size = new System.Drawing.Size(198, 24);
            checkLearnMasteryBotStopped.TabIndex = 25;
            checkLearnMasteryBotStopped.Text = "Enabled if bot is stopped";
            checkLearnMasteryBotStopped.UseVisualStyleBackColor = false;
            checkLearnMasteryBotStopped.CheckedChanged += settings_CheckedChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(289, 37);
            label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(36, 20);
            label4.TabIndex = 3;
            label4.Text = "Gap";
            // 
            // numMasteryGap
            // 
            numMasteryGap.Location = new System.Drawing.Point(333, 35);
            numMasteryGap.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            numMasteryGap.Maximum = new decimal(new int[] { 9, 0, 0, 0 });
            numMasteryGap.Name = "numMasteryGap";
            numMasteryGap.Size = new System.Drawing.Size(54, 27);
            numMasteryGap.TabIndex = 2;
            numMasteryGap.ValueChanged += numSettings_ValueChanged;
            // 
            // comboLearnMastery
            // 
            comboLearnMastery.DropDownHeight = 100;
            comboLearnMastery.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboLearnMastery.FormattingEnabled = true;
            comboLearnMastery.IntegralHeight = false;
            comboLearnMastery.ItemHeight = 20;
            comboLearnMastery.Location = new System.Drawing.Point(106, 34);
            comboLearnMastery.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            comboLearnMastery.Name = "comboLearnMastery";
            comboLearnMastery.Size = new System.Drawing.Size(175, 28);
            comboLearnMastery.TabIndex = 1;
            comboLearnMastery.SelectedIndexChanged += comboLearnMastery_SelectedIndexChanged;
            // 
            // checkLearnMastery
            // 
            checkLearnMastery.AutoSize = true;
            checkLearnMastery.Location = new System.Drawing.Point(19, 36);
            checkLearnMastery.Margin = new System.Windows.Forms.Padding(0);
            checkLearnMastery.Name = "checkLearnMastery";
            checkLearnMastery.Size = new System.Drawing.Size(83, 24);
            checkLearnMastery.TabIndex = 0;
            checkLearnMastery.Text = "Mastery";
            checkLearnMastery.UseVisualStyleBackColor = false;
            checkLearnMastery.CheckedChanged += settings_CheckedChanged;
            // 
            // groupBoxAutomatedResurrection
            // 
            groupBoxAutomatedResurrection.Controls.Add(comboResurrectionSkill);
            groupBoxAutomatedResurrection.Controls.Add(checkAcceptResurrection);
            groupBoxAutomatedResurrection.Controls.Add(label3);
            groupBoxAutomatedResurrection.Controls.Add(checkResurrectParty);
            groupBoxAutomatedResurrection.Location = new System.Drawing.Point(10, 8);
            groupBoxAutomatedResurrection.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            groupBoxAutomatedResurrection.Name = "groupBoxAutomatedResurrection";
            groupBoxAutomatedResurrection.Padding = new System.Windows.Forms.Padding(4, 12, 4, 4);
            groupBoxAutomatedResurrection.Size = new System.Drawing.Size(459, 138);
            groupBoxAutomatedResurrection.TabIndex = 11;
            groupBoxAutomatedResurrection.TabStop = false;
            groupBoxAutomatedResurrection.Text = "Automated resurrection";
            // 
            // comboResurrectionSkill
            // 
            comboResurrectionSkill.DropDownHeight = 100;
            comboResurrectionSkill.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboResurrectionSkill.FormattingEnabled = true;
            comboResurrectionSkill.IntegralHeight = false;
            comboResurrectionSkill.ItemHeight = 20;
            comboResurrectionSkill.Location = new System.Drawing.Point(108, 36);
            comboResurrectionSkill.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            comboResurrectionSkill.Name = "comboResurrectionSkill";
            comboResurrectionSkill.Size = new System.Drawing.Size(318, 28);
            comboResurrectionSkill.TabIndex = 8;
            comboResurrectionSkill.SelectedIndexChanged += comboResurrectionSkill_SelectedIndexChanged;
            // 
            // checkAcceptResurrection
            // 
            checkAcceptResurrection.AutoSize = true;
            checkAcceptResurrection.Checked = true;
            checkAcceptResurrection.CheckState = System.Windows.Forms.CheckState.Checked;
            checkAcceptResurrection.Location = new System.Drawing.Point(108, 101);
            checkAcceptResurrection.Margin = new System.Windows.Forms.Padding(0);
            checkAcceptResurrection.Name = "checkAcceptResurrection";
            checkAcceptResurrection.Size = new System.Drawing.Size(193, 24);
            checkAcceptResurrection.TabIndex = 9;
            checkAcceptResurrection.Text = "Auto accept resurrection";
            checkAcceptResurrection.UseVisualStyleBackColor = false;
            checkAcceptResurrection.CheckedChanged += settings_CheckedChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(32, 40);
            label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(67, 20);
            label3.TabIndex = 0;
            label3.Text = "Res. skill:";
            // 
            // checkResurrectParty
            // 
            checkResurrectParty.AutoSize = true;
            checkResurrectParty.Location = new System.Drawing.Point(108, 70);
            checkResurrectParty.Margin = new System.Windows.Forms.Padding(0);
            checkResurrectParty.Name = "checkResurrectParty";
            checkResurrectParty.Size = new System.Drawing.Size(228, 24);
            checkResurrectParty.TabIndex = 6;
            checkResurrectParty.Text = "Auto resurrect party members";
            checkResurrectParty.UseVisualStyleBackColor = false;
            checkResurrectParty.CheckedChanged += settings_CheckedChanged;
            // 
            // groupBoxAdvancedBuff
            // 
            groupBoxAdvancedBuff.Controls.Add(checkCastBuffsDuringWalkBack);
            groupBoxAdvancedBuff.Controls.Add(checkCastBuffsInTowns);
            groupBoxAdvancedBuff.Location = new System.Drawing.Point(10, 154);
            groupBoxAdvancedBuff.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            groupBoxAdvancedBuff.Name = "groupBoxAdvancedBuff";
            groupBoxAdvancedBuff.Padding = new System.Windows.Forms.Padding(4, 12, 4, 4);
            groupBoxAdvancedBuff.Size = new System.Drawing.Size(459, 101);
            groupBoxAdvancedBuff.TabIndex = 12;
            groupBoxAdvancedBuff.TabStop = false;
            groupBoxAdvancedBuff.Text = "Advanced buff configuration";
            // 
            // checkCastBuffsDuringWalkBack
            // 
            checkCastBuffsDuringWalkBack.AutoSize = true;
            checkCastBuffsDuringWalkBack.Checked = true;
            checkCastBuffsDuringWalkBack.CheckState = System.Windows.Forms.CheckState.Checked;
            checkCastBuffsDuringWalkBack.Location = new System.Drawing.Point(19, 60);
            checkCastBuffsDuringWalkBack.Margin = new System.Windows.Forms.Padding(0);
            checkCastBuffsDuringWalkBack.Name = "checkCastBuffsDuringWalkBack";
            checkCastBuffsDuringWalkBack.Size = new System.Drawing.Size(206, 24);
            checkCastBuffsDuringWalkBack.TabIndex = 10;
            checkCastBuffsDuringWalkBack.Text = "Cast buffs while walk-back";
            checkCastBuffsDuringWalkBack.UseVisualStyleBackColor = false;
            checkCastBuffsDuringWalkBack.CheckedChanged += settings_CheckedChanged;
            // 
            // checkCastBuffsInTowns
            // 
            checkCastBuffsInTowns.AutoSize = true;
            checkCastBuffsInTowns.Location = new System.Drawing.Point(19, 32);
            checkCastBuffsInTowns.Margin = new System.Windows.Forms.Padding(0);
            checkCastBuffsInTowns.Name = "checkCastBuffsInTowns";
            checkCastBuffsInTowns.Size = new System.Drawing.Size(155, 24);
            checkCastBuffsInTowns.TabIndex = 10;
            checkCastBuffsInTowns.Text = "Cast buffs in towns";
            checkCastBuffsInTowns.UseVisualStyleBackColor = false;
            checkCastBuffsInTowns.CheckedChanged += settings_CheckedChanged;
            // 
            // tabControl2
            // 
            tabControl2.Controls.Add(tabPage3);
            tabControl2.Controls.Add(tabPage4);
            tabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            tabControl2.ItemSize = new System.Drawing.Size(80, 24);
            tabControl2.Location = new System.Drawing.Point(5, 5);
            tabControl2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            tabControl2.Name = "tabControl2";
            tabControl2.SelectedIndex = 0;
            tabControl2.Size = new System.Drawing.Size(442, 574);
            tabControl2.TabIndex = 6;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(listSkills);
            tabPage3.Controls.Add(panelPlayerSkills);
            tabPage3.Location = new System.Drawing.Point(4, 28);
            tabPage3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            tabPage3.Size = new System.Drawing.Size(434, 542);
            tabPage3.TabIndex = 0;
            tabPage3.Text = "Player skills";
            // 
            // listSkills
            // 
            listSkills.BorderStyle = System.Windows.Forms.BorderStyle.None;
            listSkills.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { colName, colLevel });
            listSkills.ContextMenuStrip = skillContextMenu;
            listSkills.Dock = System.Windows.Forms.DockStyle.Fill;
            listSkills.FullRowSelect = true;
            listSkills.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            listSkills.Location = new System.Drawing.Point(4, 4);
            listSkills.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            listSkills.Name = "listSkills";
            listSkills.Size = new System.Drawing.Size(426, 488);
            listSkills.TabIndex = 5;
            listSkills.UseCompatibleStateImageBehavior = false;
            listSkills.View = System.Windows.Forms.View.Details;
            listSkills.MouseDoubleClick += listSkills_MouseDoubleClick;
            // 
            // colName
            // 
            colName.Text = "Name";
            colName.Width = 226;
            // 
            // colLevel
            // 
            colLevel.Text = "";
            colLevel.Width = 69;
            // 
            // skillContextMenu
            // 
            skillContextMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            skillContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { skillContextMenuAddAttackSkill, toolStripSeparator1, skillContextMenuAddBuffSkill, toolStripSeparator2, useToolStripMenuItem, useToPartyMemberToolStripMenuItem });
            skillContextMenu.Name = "skillContextMenu";
            skillContextMenu.Size = new System.Drawing.Size(219, 112);
            skillContextMenu.Opening += skillContextMenu_Opening;
            // 
            // skillContextMenuAddAttackSkill
            // 
            skillContextMenuAddAttackSkill.Name = "skillContextMenuAddAttackSkill";
            skillContextMenuAddAttackSkill.Size = new System.Drawing.Size(218, 24);
            skillContextMenuAddAttackSkill.Text = "Add To Attacks";
            skillContextMenuAddAttackSkill.Click += menuAddAttack_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new System.Drawing.Size(215, 6);
            // 
            // skillContextMenuAddBuffSkill
            // 
            skillContextMenuAddBuffSkill.Name = "skillContextMenuAddBuffSkill";
            skillContextMenuAddBuffSkill.Size = new System.Drawing.Size(218, 24);
            skillContextMenuAddBuffSkill.Text = "Add To Buffs";
            skillContextMenuAddBuffSkill.Click += menuAddBuff_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new System.Drawing.Size(215, 6);
            // 
            // useToolStripMenuItem
            // 
            useToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            useToolStripMenuItem.Name = "useToolStripMenuItem";
            useToolStripMenuItem.Size = new System.Drawing.Size(218, 24);
            useToolStripMenuItem.Text = "Use";
            useToolStripMenuItem.Click += useToolStripMenuItem_Click;
            // 
            // useToPartyMemberToolStripMenuItem
            // 
            useToPartyMemberToolStripMenuItem.Name = "useToPartyMemberToolStripMenuItem";
            useToPartyMemberToolStripMenuItem.Size = new System.Drawing.Size(218, 24);
            useToPartyMemberToolStripMenuItem.Text = "Use to party member";
            // 
            // panelPlayerSkills
            // 
            panelPlayerSkills.Controls.Add(panel2);
            panelPlayerSkills.Controls.Add(checkHideLowerLevelSkills);
            panelPlayerSkills.Controls.Add(checkShowAttacks);
            panelPlayerSkills.Controls.Add(checkShowBuffs);
            panelPlayerSkills.Dock = System.Windows.Forms.DockStyle.Bottom;
            panelPlayerSkills.Location = new System.Drawing.Point(4, 492);
            panelPlayerSkills.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            panelPlayerSkills.Name = "panelPlayerSkills";
            panelPlayerSkills.Size = new System.Drawing.Size(426, 46);
            panelPlayerSkills.TabIndex = 9;
            // 
            // panel2
            // 
            panel2.Dock = System.Windows.Forms.DockStyle.Top;
            panel2.Location = new System.Drawing.Point(0, 0);
            panel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            panel2.Name = "panel2";
            panel2.Size = new System.Drawing.Size(426, 1);
            panel2.TabIndex = 9;
            // 
            // checkHideLowerLevelSkills
            // 
            checkHideLowerLevelSkills.AutoSize = true;
            checkHideLowerLevelSkills.Location = new System.Drawing.Point(242, 12);
            checkHideLowerLevelSkills.Margin = new System.Windows.Forms.Padding(0);
            checkHideLowerLevelSkills.Name = "checkHideLowerLevelSkills";
            checkHideLowerLevelSkills.Size = new System.Drawing.Size(174, 24);
            checkHideLowerLevelSkills.TabIndex = 6;
            checkHideLowerLevelSkills.Text = "Hide lower level skills";
            checkHideLowerLevelSkills.UseVisualStyleBackColor = false;
            checkHideLowerLevelSkills.CheckedChanged += Filter_CheckedChanged;
            // 
            // checkShowAttacks
            // 
            checkShowAttacks.AutoSize = true;
            checkShowAttacks.Checked = true;
            checkShowAttacks.CheckState = System.Windows.Forms.CheckState.Checked;
            checkShowAttacks.Location = new System.Drawing.Point(10, 12);
            checkShowAttacks.Margin = new System.Windows.Forms.Padding(0);
            checkShowAttacks.Name = "checkShowAttacks";
            checkShowAttacks.Size = new System.Drawing.Size(79, 24);
            checkShowAttacks.TabIndex = 7;
            checkShowAttacks.Text = "Attacks";
            checkShowAttacks.UseVisualStyleBackColor = false;
            checkShowAttacks.CheckedChanged += Filter_CheckedChanged;
            // 
            // checkShowBuffs
            // 
            checkShowBuffs.AutoSize = true;
            checkShowBuffs.Checked = true;
            checkShowBuffs.CheckState = System.Windows.Forms.CheckState.Checked;
            checkShowBuffs.Location = new System.Drawing.Point(89, 12);
            checkShowBuffs.Margin = new System.Windows.Forms.Padding(0);
            checkShowBuffs.Name = "checkShowBuffs";
            checkShowBuffs.Size = new System.Drawing.Size(64, 24);
            checkShowBuffs.TabIndex = 8;
            checkShowBuffs.Text = "Buffs";
            checkShowBuffs.UseVisualStyleBackColor = false;
            checkShowBuffs.CheckedChanged += Filter_CheckedChanged;
            // 
            // tabPage4
            // 
            tabPage4.Controls.Add(listActiveBuffs);
            tabPage4.Location = new System.Drawing.Point(4, 28);
            tabPage4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            tabPage4.Name = "tabPage4";
            tabPage4.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            tabPage4.Size = new System.Drawing.Size(434, 542);
            tabPage4.TabIndex = 1;
            tabPage4.Text = "Active buffs";
            // 
            // listActiveBuffs
            // 
            listActiveBuffs.BorderStyle = System.Windows.Forms.BorderStyle.None;
            listActiveBuffs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { colActiveName, colActiveLevel });
            listActiveBuffs.Dock = System.Windows.Forms.DockStyle.Fill;
            listActiveBuffs.FullRowSelect = true;
            listActiveBuffs.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            listActiveBuffs.Location = new System.Drawing.Point(4, 4);
            listActiveBuffs.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            listActiveBuffs.Name = "listActiveBuffs";
            listActiveBuffs.Size = new System.Drawing.Size(426, 534);
            listActiveBuffs.TabIndex = 6;
            listActiveBuffs.UseCompatibleStateImageBehavior = false;
            listActiveBuffs.View = System.Windows.Forms.View.Details;
            listActiveBuffs.MouseDoubleClick += listActiveBuffs_MouseDoubleClick;
            // 
            // colActiveName
            // 
            colActiveName.Text = "Name";
            colActiveName.Width = 226;
            // 
            // colActiveLevel
            // 
            colActiveLevel.Text = "";
            colActiveLevel.Width = 69;
            // 
            // Main
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            Controls.Add(tabControl2);
            Controls.Add(tabControl1);
            Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            Name = "Main";
            Padding = new System.Windows.Forms.Padding(5);
            Size = new System.Drawing.Size(942, 584);
            Load += Main_Load;
            groupBoxAttackingSkills.ResumeLayout(false);
            groupBoxAttackingSkills.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            groupAdvancedSetup.ResumeLayout(false);
            groupAdvancedSetup.PerformLayout();
            grpMasteryUpdate.ResumeLayout(false);
            grpMasteryUpdate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numMasteryGap).EndInit();
            groupBoxAutomatedResurrection.ResumeLayout(false);
            groupBoxAutomatedResurrection.PerformLayout();
            groupBoxAdvancedBuff.ResumeLayout(false);
            groupBoxAdvancedBuff.PerformLayout();
            tabControl2.ResumeLayout(false);
            tabPage3.ResumeLayout(false);
            skillContextMenu.ResumeLayout(false);
            panelPlayerSkills.ResumeLayout(false);
            panelPlayerSkills.PerformLayout();
            tabPage4.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.GroupBox groupBoxAttackingSkills;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnRemoveAttackSkill;
        private System.Windows.Forms.Button btnMoveAttackSkillDown;
        private System.Windows.Forms.Button btnMoveAttackSkillUp;
        private System.Windows.Forms.ComboBox comboImbue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRemoveBuffSkill;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboMonsterType;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ComboBox comboResurrectionSkill;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkResurrectParty;
        private System.Windows.Forms.CheckBox checkAcceptResurrection;
        private System.Windows.Forms.CheckBox checkCastBuffsInTowns;
        private System.Windows.Forms.GroupBox groupBoxAutomatedResurrection;
        private System.Windows.Forms.GroupBox groupBoxAdvancedBuff;
        private System.Windows.Forms.CheckBox checkCastBuffsDuringWalkBack;
        private System.Windows.Forms.TabControl tabControl2;
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
        private System.Windows.Forms.Panel panelPlayerSkills;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListView listAttackingSkills;
        private System.Windows.Forms.ColumnHeader columnName;
        private System.Windows.Forms.ColumnHeader columnLevel;
        private System.Windows.Forms.ListView listBuffs;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ContextMenuStrip skillContextMenu;
        private System.Windows.Forms.CheckBox checkBoxNoAttack;
        private System.Windows.Forms.ToolStripMenuItem skillContextMenuAddBuffSkill;
        private System.Windows.Forms.ToolStripMenuItem skillContextMenuAddAttackSkill;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.GroupBox grpMasteryUpdate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numMasteryGap;
        private System.Windows.Forms.ComboBox comboLearnMastery;
        private System.Windows.Forms.CheckBox checkLearnMastery;
        private System.Windows.Forms.CheckBox checkLearnMasteryBotStopped;
        private System.Windows.Forms.GroupBox groupAdvancedSetup;
        private System.Windows.Forms.CheckBox checkWarlockMode;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem useToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem useToPartyMemberToolStripMenuItem;
        private System.Windows.Forms.CheckBox checkUseDefaultAttack;
        private System.Windows.Forms.CheckBox checkUseSkillsInOrder;
        private System.Windows.Forms.ComboBox comboTeleportSkill;
        private System.Windows.Forms.CheckBox checkUseTeleportSkill;
    }
}
