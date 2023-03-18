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
            groupBox1 = new SDUI.Controls.GroupBox();
            checkUseSkillsInOrder = new SDUI.Controls.CheckBox();
            checkBoxNoAttack = new SDUI.Controls.CheckBox();
            listAttackingSkills = new SDUI.Controls.ListView();
            columnName = new System.Windows.Forms.ColumnHeader();
            columnLevel = new System.Windows.Forms.ColumnHeader();
            label2 = new SDUI.Controls.Label();
            comboMonsterType = new SDUI.Controls.ComboBox();
            btnMoveAttackSkillDown = new SDUI.Controls.Button();
            btnMoveAttackSkillUp = new SDUI.Controls.Button();
            btnRemoveAttackSkill = new SDUI.Controls.Button();
            groupBox2 = new SDUI.Controls.GroupBox();
            listBuffs = new SDUI.Controls.ListView();
            columnHeader1 = new System.Windows.Forms.ColumnHeader();
            columnHeader2 = new System.Windows.Forms.ColumnHeader();
            btnMoveBuffSkillDown = new SDUI.Controls.Button();
            comboImbue = new SDUI.Controls.ComboBox();
            btnMoveBuffSkillUp = new SDUI.Controls.Button();
            label1 = new SDUI.Controls.Label();
            btnRemoveBuffSkill = new SDUI.Controls.Button();
            tabControl1 = new SDUI.Controls.TabControl();
            tabPage1 = new System.Windows.Forms.TabPage();
            tabPage2 = new System.Windows.Forms.TabPage();
            groupWarlockMode = new SDUI.Controls.GroupBox();
            comboTeleportSkill = new SDUI.Controls.ComboBox();
            checkUseTeleportSkill = new SDUI.Controls.CheckBox();
            checkUseDefaultAttack = new SDUI.Controls.CheckBox();
            checkWarlockMode = new SDUI.Controls.CheckBox();
            grpMasteryLearn = new SDUI.Controls.GroupBox();
            checkLearnMasteryBotStopped = new SDUI.Controls.CheckBox();
            label4 = new SDUI.Controls.Label();
            numMasteryGap = new SDUI.Controls.NumUpDown();
            comboLearnMastery = new SDUI.Controls.ComboBox();
            checkLearnMastery = new SDUI.Controls.CheckBox();
            groupBox3 = new SDUI.Controls.GroupBox();
            comboResurrectionSkill = new SDUI.Controls.ComboBox();
            checkAcceptResurrection = new SDUI.Controls.CheckBox();
            label3 = new SDUI.Controls.Label();
            checkResurrectParty = new SDUI.Controls.CheckBox();
            groupBox4 = new SDUI.Controls.GroupBox();
            checkCastBuffsDuringWalkBack = new SDUI.Controls.CheckBox();
            checkCastBuffsInTowns = new SDUI.Controls.CheckBox();
            tabControl2 = new SDUI.Controls.TabControl();
            tabPage3 = new System.Windows.Forms.TabPage();
            listSkills = new SDUI.Controls.ListView();
            colName = new System.Windows.Forms.ColumnHeader();
            colLevel = new System.Windows.Forms.ColumnHeader();
            skillContextMenu = new SDUI.Controls.ContextMenuStrip();
            skillContextMenuAddAttackSkill = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            skillContextMenuAddBuffSkill = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            useToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            useToPartyMemberToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            panel1 = new SDUI.Controls.Panel();
            panel2 = new SDUI.Controls.Panel();
            checkHideLowerLevelSkills = new SDUI.Controls.CheckBox();
            checkShowAttacks = new SDUI.Controls.CheckBox();
            checkShowBuffs = new SDUI.Controls.CheckBox();
            tabPage4 = new System.Windows.Forms.TabPage();
            listActiveBuffs = new SDUI.Controls.ListView();
            colActiveName = new System.Windows.Forms.ColumnHeader();
            colActiveLevel = new System.Windows.Forms.ColumnHeader();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            groupWarlockMode.SuspendLayout();
            grpMasteryLearn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numMasteryGap).BeginInit();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            tabControl2.SuspendLayout();
            tabPage3.SuspendLayout();
            skillContextMenu.SuspendLayout();
            panel1.SuspendLayout();
            tabPage4.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.BackColor = System.Drawing.Color.Transparent;
            groupBox1.Controls.Add(checkUseSkillsInOrder);
            groupBox1.Controls.Add(checkBoxNoAttack);
            groupBox1.Controls.Add(listAttackingSkills);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(comboMonsterType);
            groupBox1.Controls.Add(btnMoveAttackSkillDown);
            groupBox1.Controls.Add(btnMoveAttackSkillUp);
            groupBox1.Controls.Add(btnRemoveAttackSkill);
            groupBox1.Location = new System.Drawing.Point(14, 5);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new System.Windows.Forms.Padding(3, 10, 3, 3);
            groupBox1.Radius = 10;
            groupBox1.ShadowDepth = 4;
            groupBox1.Size = new System.Drawing.Size(357, 213);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Attacking skills";
            // 
            // checkUseSkillsInOrder
            // 
            checkUseSkillsInOrder.AutoSize = true;
            checkUseSkillsInOrder.BackColor = System.Drawing.Color.Transparent;
            checkUseSkillsInOrder.Location = new System.Drawing.Point(231, 192);
            checkUseSkillsInOrder.Name = "checkUseSkillsInOrder";
            checkUseSkillsInOrder.ShadowDepth = 1;
            checkUseSkillsInOrder.Size = new System.Drawing.Size(86, 15);
            checkUseSkillsInOrder.TabIndex = 10;
            checkUseSkillsInOrder.Text = "Use in order";
            checkUseSkillsInOrder.UseVisualStyleBackColor = false;
            checkUseSkillsInOrder.CheckedChanged += checkUseSkillsInOrder_CheckedChanged;
            // 
            // checkBoxNoAttack
            // 
            checkBoxNoAttack.AutoSize = true;
            checkBoxNoAttack.BackColor = System.Drawing.Color.Transparent;
            checkBoxNoAttack.Location = new System.Drawing.Point(231, 177);
            checkBoxNoAttack.Name = "checkBoxNoAttack";
            checkBoxNoAttack.ShadowDepth = 1;
            checkBoxNoAttack.Size = new System.Drawing.Size(76, 15);
            checkBoxNoAttack.TabIndex = 9;
            checkBoxNoAttack.Text = "No Attack";
            checkBoxNoAttack.UseVisualStyleBackColor = false;
            checkBoxNoAttack.CheckedChanged += checkBoxNoAttack_CheckedChanged;
            // 
            // listAttackingSkills
            // 
            listAttackingSkills.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { columnName, columnLevel });
            listAttackingSkills.FullRowSelect = true;
            listAttackingSkills.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            listAttackingSkills.Location = new System.Drawing.Point(6, 25);
            listAttackingSkills.Name = "listAttackingSkills";
            listAttackingSkills.Size = new System.Drawing.Size(315, 146);
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
            label2.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            label2.Location = new System.Drawing.Point(9, 183);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(34, 15);
            label2.TabIndex = 7;
            label2.Text = "Type:";
            // 
            // comboMonsterType
            // 
            comboMonsterType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            comboMonsterType.DropDownHeight = 100;
            comboMonsterType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboMonsterType.FormattingEnabled = true;
            comboMonsterType.IntegralHeight = false;
            comboMonsterType.ItemHeight = 17;
            comboMonsterType.Items.AddRange(new object[] { "General (Default)", "Champion", "Giant", "General (Party)", "Champion (Party)", "Giant (Party)", "Elite", "Strong", "Unique", "Event" });
            comboMonsterType.Location = new System.Drawing.Point(54, 180);
            comboMonsterType.Name = "comboMonsterType";
            comboMonsterType.Radius = 5;
            comboMonsterType.ShadowDepth = 4F;
            comboMonsterType.Size = new System.Drawing.Size(171, 23);
            comboMonsterType.TabIndex = 2;
            comboMonsterType.SelectedIndexChanged += comboMonsterType_SelectedIndexChanged;
            // 
            // btnMoveAttackSkillDown
            // 
            btnMoveAttackSkillDown.Color = System.Drawing.Color.Transparent;
            btnMoveAttackSkillDown.Font = new System.Drawing.Font("Webdings", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            btnMoveAttackSkillDown.Location = new System.Drawing.Point(327, 85);
            btnMoveAttackSkillDown.Name = "btnMoveAttackSkillDown";
            btnMoveAttackSkillDown.Radius = 6;
            btnMoveAttackSkillDown.ShadowDepth = 4F;
            btnMoveAttackSkillDown.Size = new System.Drawing.Size(24, 24);
            btnMoveAttackSkillDown.TabIndex = 1;
            btnMoveAttackSkillDown.Text = "6";
            btnMoveAttackSkillDown.UseVisualStyleBackColor = true;
            btnMoveAttackSkillDown.Click += btnMoveAttackSkillDown_Click;
            // 
            // btnMoveAttackSkillUp
            // 
            btnMoveAttackSkillUp.Color = System.Drawing.Color.Transparent;
            btnMoveAttackSkillUp.Font = new System.Drawing.Font("Webdings", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            btnMoveAttackSkillUp.Location = new System.Drawing.Point(327, 55);
            btnMoveAttackSkillUp.Name = "btnMoveAttackSkillUp";
            btnMoveAttackSkillUp.Radius = 6;
            btnMoveAttackSkillUp.ShadowDepth = 4F;
            btnMoveAttackSkillUp.Size = new System.Drawing.Size(24, 24);
            btnMoveAttackSkillUp.TabIndex = 1;
            btnMoveAttackSkillUp.Text = "5";
            btnMoveAttackSkillUp.UseVisualStyleBackColor = true;
            btnMoveAttackSkillUp.Click += btnMoveAttackSkillUp_Click;
            // 
            // btnRemoveAttackSkill
            // 
            btnRemoveAttackSkill.Color = System.Drawing.Color.Transparent;
            btnRemoveAttackSkill.Font = new System.Drawing.Font("Webdings", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            btnRemoveAttackSkill.Location = new System.Drawing.Point(327, 25);
            btnRemoveAttackSkill.Name = "btnRemoveAttackSkill";
            btnRemoveAttackSkill.Radius = 6;
            btnRemoveAttackSkill.ShadowDepth = 4F;
            btnRemoveAttackSkill.Size = new System.Drawing.Size(24, 22);
            btnRemoveAttackSkill.TabIndex = 1;
            btnRemoveAttackSkill.Text = "r";
            btnRemoveAttackSkill.UseVisualStyleBackColor = true;
            btnRemoveAttackSkill.Click += btnRemoveAttackSkill_Click;
            // 
            // groupBox2
            // 
            groupBox2.BackColor = System.Drawing.Color.Transparent;
            groupBox2.Controls.Add(listBuffs);
            groupBox2.Controls.Add(btnMoveBuffSkillDown);
            groupBox2.Controls.Add(comboImbue);
            groupBox2.Controls.Add(btnMoveBuffSkillUp);
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(btnRemoveBuffSkill);
            groupBox2.Location = new System.Drawing.Point(14, 224);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new System.Windows.Forms.Padding(3, 10, 3, 3);
            groupBox2.Radius = 10;
            groupBox2.ShadowDepth = 4;
            groupBox2.Size = new System.Drawing.Size(357, 198);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "Buffing skills";
            // 
            // listBuffs
            // 
            listBuffs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { columnHeader1, columnHeader2 });
            listBuffs.FullRowSelect = true;
            listBuffs.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            listBuffs.Location = new System.Drawing.Point(6, 27);
            listBuffs.Name = "listBuffs";
            listBuffs.Size = new System.Drawing.Size(315, 138);
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
            btnMoveBuffSkillDown.Color = System.Drawing.Color.Transparent;
            btnMoveBuffSkillDown.Font = new System.Drawing.Font("Webdings", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            btnMoveBuffSkillDown.Location = new System.Drawing.Point(327, 87);
            btnMoveBuffSkillDown.Name = "btnMoveBuffSkillDown";
            btnMoveBuffSkillDown.Radius = 6;
            btnMoveBuffSkillDown.ShadowDepth = 4F;
            btnMoveBuffSkillDown.Size = new System.Drawing.Size(24, 24);
            btnMoveBuffSkillDown.TabIndex = 8;
            btnMoveBuffSkillDown.Text = "6";
            btnMoveBuffSkillDown.UseVisualStyleBackColor = true;
            btnMoveBuffSkillDown.Click += btnMoveBuffSkillDown_Click;
            // 
            // comboImbue
            // 
            comboImbue.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            comboImbue.DropDownHeight = 100;
            comboImbue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboImbue.FormattingEnabled = true;
            comboImbue.IntegralHeight = false;
            comboImbue.ItemHeight = 17;
            comboImbue.Location = new System.Drawing.Point(54, 171);
            comboImbue.Name = "comboImbue";
            comboImbue.Radius = 5;
            comboImbue.ShadowDepth = 4F;
            comboImbue.Size = new System.Drawing.Size(267, 23);
            comboImbue.TabIndex = 7;
            comboImbue.SelectedIndexChanged += comboImbue_SelectedIndexChanged;
            // 
            // btnMoveBuffSkillUp
            // 
            btnMoveBuffSkillUp.Color = System.Drawing.Color.Transparent;
            btnMoveBuffSkillUp.Font = new System.Drawing.Font("Webdings", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            btnMoveBuffSkillUp.Location = new System.Drawing.Point(327, 57);
            btnMoveBuffSkillUp.Name = "btnMoveBuffSkillUp";
            btnMoveBuffSkillUp.Radius = 6;
            btnMoveBuffSkillUp.ShadowDepth = 4F;
            btnMoveBuffSkillUp.Size = new System.Drawing.Size(24, 24);
            btnMoveBuffSkillUp.TabIndex = 9;
            btnMoveBuffSkillUp.Text = "5";
            btnMoveBuffSkillUp.UseVisualStyleBackColor = true;
            btnMoveBuffSkillUp.Click += btnMoveBuffSkillUp_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            label1.Location = new System.Drawing.Point(9, 174);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(44, 15);
            label1.TabIndex = 6;
            label1.Text = "Imbue:";
            // 
            // btnRemoveBuffSkill
            // 
            btnRemoveBuffSkill.Color = System.Drawing.Color.Transparent;
            btnRemoveBuffSkill.Font = new System.Drawing.Font("Webdings", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            btnRemoveBuffSkill.Location = new System.Drawing.Point(327, 27);
            btnRemoveBuffSkill.Name = "btnRemoveBuffSkill";
            btnRemoveBuffSkill.Radius = 6;
            btnRemoveBuffSkill.ShadowDepth = 4F;
            btnRemoveBuffSkill.Size = new System.Drawing.Size(24, 24);
            btnRemoveBuffSkill.TabIndex = 5;
            btnRemoveBuffSkill.Text = "r";
            btnRemoveBuffSkill.UseVisualStyleBackColor = true;
            btnRemoveBuffSkill.Click += btnRemoveBuffSkill_Click;
            // 
            // tabControl1
            // 
            tabControl1.Border = new System.Windows.Forms.Padding(1);
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Dock = System.Windows.Forms.DockStyle.Right;
            tabControl1.HideTabArea = false;
            tabControl1.Location = new System.Drawing.Point(362, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new System.Drawing.Size(392, 467);
            tabControl1.TabIndex = 5;
            // 
            // tabPage1
            // 
            tabPage1.BackColor = System.Drawing.Color.White;
            tabPage1.Controls.Add(groupBox1);
            tabPage1.Controls.Add(groupBox2);
            tabPage1.Location = new System.Drawing.Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new System.Windows.Forms.Padding(3);
            tabPage1.Size = new System.Drawing.Size(384, 439);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "General setup";
            // 
            // tabPage2
            // 
            tabPage2.BackColor = System.Drawing.Color.White;
            tabPage2.Controls.Add(groupWarlockMode);
            tabPage2.Controls.Add(grpMasteryLearn);
            tabPage2.Controls.Add(groupBox3);
            tabPage2.Controls.Add(groupBox4);
            tabPage2.Location = new System.Drawing.Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new System.Windows.Forms.Padding(3);
            tabPage2.Size = new System.Drawing.Size(384, 439);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Advanced setup";
            // 
            // groupWarlockMode
            // 
            groupWarlockMode.BackColor = System.Drawing.Color.Transparent;
            groupWarlockMode.Controls.Add(comboTeleportSkill);
            groupWarlockMode.Controls.Add(checkUseTeleportSkill);
            groupWarlockMode.Controls.Add(checkUseDefaultAttack);
            groupWarlockMode.Controls.Add(checkWarlockMode);
            groupWarlockMode.Location = new System.Drawing.Point(8, 313);
            groupWarlockMode.Name = "groupWarlockMode";
            groupWarlockMode.Padding = new System.Windows.Forms.Padding(3, 10, 3, 3);
            groupWarlockMode.Radius = 10;
            groupWarlockMode.ShadowDepth = 4;
            groupWarlockMode.Size = new System.Drawing.Size(367, 123);
            groupWarlockMode.TabIndex = 14;
            groupWarlockMode.TabStop = false;
            groupWarlockMode.Text = "Advanced setup";
            // 
            // comboTeleportSkill
            // 
            comboTeleportSkill.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            comboTeleportSkill.DropDownHeight = 100;
            comboTeleportSkill.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboTeleportSkill.FormattingEnabled = true;
            comboTeleportSkill.IntegralHeight = false;
            comboTeleportSkill.ItemHeight = 17;
            comboTeleportSkill.Location = new System.Drawing.Point(133, 83);
            comboTeleportSkill.Name = "comboTeleportSkill";
            comboTeleportSkill.Radius = 5;
            comboTeleportSkill.ShadowDepth = 4F;
            comboTeleportSkill.Size = new System.Drawing.Size(208, 23);
            comboTeleportSkill.TabIndex = 9;
            comboTeleportSkill.SelectedIndexChanged += comboTeleportSkill_SelectedIndexChanged;
            // 
            // checkUseTeleportSkill
            // 
            checkUseTeleportSkill.AutoSize = true;
            checkUseTeleportSkill.BackColor = System.Drawing.Color.Transparent;
            checkUseTeleportSkill.Location = new System.Drawing.Point(15, 87);
            checkUseTeleportSkill.Name = "checkUseTeleportSkill";
            checkUseTeleportSkill.ShadowDepth = 1;
            checkUseTeleportSkill.Size = new System.Drawing.Size(112, 15);
            checkUseTeleportSkill.TabIndex = 2;
            checkUseTeleportSkill.Text = "Use teleport skill:";
            checkUseTeleportSkill.UseVisualStyleBackColor = false;
            checkUseTeleportSkill.CheckedChanged += checkUseTeleportSkill_CheckedChanged;
            // 
            // checkUseDefaultAttack
            // 
            checkUseDefaultAttack.AutoSize = true;
            checkUseDefaultAttack.BackColor = System.Drawing.Color.Transparent;
            checkUseDefaultAttack.Location = new System.Drawing.Point(15, 61);
            checkUseDefaultAttack.Name = "checkUseDefaultAttack";
            checkUseDefaultAttack.ShadowDepth = 1;
            checkUseDefaultAttack.Size = new System.Drawing.Size(228, 15);
            checkUseDefaultAttack.TabIndex = 1;
            checkUseDefaultAttack.Text = "Use normal attack if no skill is available";
            checkUseDefaultAttack.UseVisualStyleBackColor = false;
            checkUseDefaultAttack.CheckedChanged += checkUseDefaultAttack_CheckedChanged;
            // 
            // checkWarlockMode
            // 
            checkWarlockMode.AutoSize = true;
            checkWarlockMode.BackColor = System.Drawing.Color.Transparent;
            checkWarlockMode.Location = new System.Drawing.Point(15, 37);
            checkWarlockMode.Name = "checkWarlockMode";
            checkWarlockMode.ShadowDepth = 1;
            checkWarlockMode.Size = new System.Drawing.Size(162, 15);
            checkWarlockMode.TabIndex = 0;
            checkWarlockMode.Text = "Change target after 2 DoTs";
            checkWarlockMode.UseVisualStyleBackColor = false;
            checkWarlockMode.CheckedChanged += checkWarlockMode_CheckedChanged;
            // 
            // grpMasteryLearn
            // 
            grpMasteryLearn.BackColor = System.Drawing.Color.Transparent;
            grpMasteryLearn.Controls.Add(checkLearnMasteryBotStopped);
            grpMasteryLearn.Controls.Add(label4);
            grpMasteryLearn.Controls.Add(numMasteryGap);
            grpMasteryLearn.Controls.Add(comboLearnMastery);
            grpMasteryLearn.Controls.Add(checkLearnMastery);
            grpMasteryLearn.Location = new System.Drawing.Point(8, 218);
            grpMasteryLearn.Name = "grpMasteryLearn";
            grpMasteryLearn.Padding = new System.Windows.Forms.Padding(3, 10, 3, 3);
            grpMasteryLearn.Radius = 10;
            grpMasteryLearn.ShadowDepth = 4;
            grpMasteryLearn.Size = new System.Drawing.Size(367, 89);
            grpMasteryLearn.TabIndex = 13;
            grpMasteryLearn.TabStop = false;
            grpMasteryLearn.Text = "Mastery update";
            // 
            // checkLearnMasteryBotStopped
            // 
            checkLearnMasteryBotStopped.AutoSize = true;
            checkLearnMasteryBotStopped.BackColor = System.Drawing.Color.Transparent;
            checkLearnMasteryBotStopped.Location = new System.Drawing.Point(15, 61);
            checkLearnMasteryBotStopped.Name = "checkLearnMasteryBotStopped";
            checkLearnMasteryBotStopped.ShadowDepth = 1;
            checkLearnMasteryBotStopped.Size = new System.Drawing.Size(153, 15);
            checkLearnMasteryBotStopped.TabIndex = 25;
            checkLearnMasteryBotStopped.Text = "Enabled if bot is stopped";
            checkLearnMasteryBotStopped.UseVisualStyleBackColor = false;
            checkLearnMasteryBotStopped.CheckedChanged += checkLearnMasteryBotStopped_CheckedChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            label4.Location = new System.Drawing.Point(252, 32);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(28, 15);
            label4.TabIndex = 3;
            label4.Text = "Gap";
            // 
            // numMasteryGap
            // 
            numMasteryGap.BackColor = System.Drawing.Color.FromArgb(238, 238, 238);
            numMasteryGap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            numMasteryGap.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            numMasteryGap.Location = new System.Drawing.Point(286, 29);
            numMasteryGap.Maximum = new decimal(new int[] { 9, 0, 0, 0 });
            numMasteryGap.Name = "numMasteryGap";
            numMasteryGap.Size = new System.Drawing.Size(64, 23);
            numMasteryGap.TabIndex = 2;
            numMasteryGap.ValueChanged += numMasteryGap_ValueChanged;
            // 
            // comboLearnMastery
            // 
            comboLearnMastery.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            comboLearnMastery.DropDownHeight = 100;
            comboLearnMastery.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboLearnMastery.FormattingEnabled = true;
            comboLearnMastery.IntegralHeight = false;
            comboLearnMastery.ItemHeight = 17;
            comboLearnMastery.Location = new System.Drawing.Point(88, 29);
            comboLearnMastery.Name = "comboLearnMastery";
            comboLearnMastery.Radius = 5;
            comboLearnMastery.ShadowDepth = 4F;
            comboLearnMastery.Size = new System.Drawing.Size(151, 23);
            comboLearnMastery.TabIndex = 1;
            comboLearnMastery.SelectedIndexChanged += comboLearnMastery_SelectedIndexChanged;
            // 
            // checkLearnMastery
            // 
            checkLearnMastery.AutoSize = true;
            checkLearnMastery.BackColor = System.Drawing.Color.Transparent;
            checkLearnMastery.Location = new System.Drawing.Point(15, 32);
            checkLearnMastery.Name = "checkLearnMastery";
            checkLearnMastery.ShadowDepth = 1;
            checkLearnMastery.Size = new System.Drawing.Size(65, 15);
            checkLearnMastery.TabIndex = 0;
            checkLearnMastery.Text = "Mastery";
            checkLearnMastery.UseVisualStyleBackColor = false;
            checkLearnMastery.CheckedChanged += checkLearnMastery_CheckedChanged;
            // 
            // groupBox3
            // 
            groupBox3.BackColor = System.Drawing.Color.Transparent;
            groupBox3.Controls.Add(comboResurrectionSkill);
            groupBox3.Controls.Add(checkAcceptResurrection);
            groupBox3.Controls.Add(label3);
            groupBox3.Controls.Add(checkResurrectParty);
            groupBox3.Location = new System.Drawing.Point(8, 6);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new System.Windows.Forms.Padding(3, 10, 3, 3);
            groupBox3.Radius = 10;
            groupBox3.ShadowDepth = 4;
            groupBox3.Size = new System.Drawing.Size(367, 119);
            groupBox3.TabIndex = 11;
            groupBox3.TabStop = false;
            groupBox3.Text = "Automated resurrection";
            // 
            // comboResurrectionSkill
            // 
            comboResurrectionSkill.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            comboResurrectionSkill.DropDownHeight = 100;
            comboResurrectionSkill.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboResurrectionSkill.FormattingEnabled = true;
            comboResurrectionSkill.IntegralHeight = false;
            comboResurrectionSkill.ItemHeight = 17;
            comboResurrectionSkill.Location = new System.Drawing.Point(86, 32);
            comboResurrectionSkill.Name = "comboResurrectionSkill";
            comboResurrectionSkill.Radius = 5;
            comboResurrectionSkill.ShadowDepth = 4F;
            comboResurrectionSkill.Size = new System.Drawing.Size(255, 23);
            comboResurrectionSkill.TabIndex = 8;
            comboResurrectionSkill.SelectedIndexChanged += comboResurrectionSkill_SelectedIndexChanged;
            // 
            // checkAcceptResurrection
            // 
            checkAcceptResurrection.AutoSize = true;
            checkAcceptResurrection.BackColor = System.Drawing.Color.Transparent;
            checkAcceptResurrection.Location = new System.Drawing.Point(86, 90);
            checkAcceptResurrection.Name = "checkAcceptResurrection";
            checkAcceptResurrection.ShadowDepth = 1;
            checkAcceptResurrection.Size = new System.Drawing.Size(153, 15);
            checkAcceptResurrection.TabIndex = 9;
            checkAcceptResurrection.Text = "Auto accept resurrection";
            checkAcceptResurrection.UseVisualStyleBackColor = false;
            checkAcceptResurrection.CheckedChanged += checkAcceptResurrection_CheckedChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            label3.Location = new System.Drawing.Point(26, 35);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(54, 15);
            label3.TabIndex = 0;
            label3.Text = "Res. skill:";
            // 
            // checkResurrectParty
            // 
            checkResurrectParty.AutoSize = true;
            checkResurrectParty.BackColor = System.Drawing.Color.Transparent;
            checkResurrectParty.Location = new System.Drawing.Point(86, 65);
            checkResurrectParty.Name = "checkResurrectParty";
            checkResurrectParty.ShadowDepth = 1;
            checkResurrectParty.Size = new System.Drawing.Size(181, 15);
            checkResurrectParty.TabIndex = 6;
            checkResurrectParty.Text = "Auto resurrect party members";
            checkResurrectParty.UseVisualStyleBackColor = false;
            checkResurrectParty.CheckedChanged += checkResurrectParty_CheckedChanged;
            // 
            // groupBox4
            // 
            groupBox4.BackColor = System.Drawing.Color.Transparent;
            groupBox4.Controls.Add(checkCastBuffsDuringWalkBack);
            groupBox4.Controls.Add(checkCastBuffsInTowns);
            groupBox4.Location = new System.Drawing.Point(8, 131);
            groupBox4.Name = "groupBox4";
            groupBox4.Padding = new System.Windows.Forms.Padding(3, 10, 3, 3);
            groupBox4.Radius = 10;
            groupBox4.ShadowDepth = 4;
            groupBox4.Size = new System.Drawing.Size(367, 81);
            groupBox4.TabIndex = 12;
            groupBox4.TabStop = false;
            groupBox4.Text = "Advanced buff configuration";
            // 
            // checkCastBuffsDuringWalkBack
            // 
            checkCastBuffsDuringWalkBack.AutoSize = true;
            checkCastBuffsDuringWalkBack.BackColor = System.Drawing.Color.Transparent;
            checkCastBuffsDuringWalkBack.Location = new System.Drawing.Point(15, 56);
            checkCastBuffsDuringWalkBack.Name = "checkCastBuffsDuringWalkBack";
            checkCastBuffsDuringWalkBack.ShadowDepth = 1;
            checkCastBuffsDuringWalkBack.Size = new System.Drawing.Size(164, 15);
            checkCastBuffsDuringWalkBack.TabIndex = 10;
            checkCastBuffsDuringWalkBack.Text = "Cast buffs while walk-back";
            checkCastBuffsDuringWalkBack.UseVisualStyleBackColor = false;
            checkCastBuffsDuringWalkBack.CheckedChanged += checkCastBuffsWhenWalkBack_CheckedChanged;
            // 
            // checkCastBuffsInTowns
            // 
            checkCastBuffsInTowns.AutoSize = true;
            checkCastBuffsInTowns.BackColor = System.Drawing.Color.Transparent;
            checkCastBuffsInTowns.Location = new System.Drawing.Point(15, 29);
            checkCastBuffsInTowns.Name = "checkCastBuffsInTowns";
            checkCastBuffsInTowns.ShadowDepth = 1;
            checkCastBuffsInTowns.Size = new System.Drawing.Size(124, 15);
            checkCastBuffsInTowns.TabIndex = 10;
            checkCastBuffsInTowns.Text = "Cast buffs in towns";
            checkCastBuffsInTowns.UseVisualStyleBackColor = false;
            checkCastBuffsInTowns.CheckedChanged += checkCastBuffsInTowns_CheckedChanged;
            // 
            // tabControl2
            // 
            tabControl2.Border = new System.Windows.Forms.Padding(1);
            tabControl2.Controls.Add(tabPage3);
            tabControl2.Controls.Add(tabPage4);
            tabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            tabControl2.HideTabArea = false;
            tabControl2.Location = new System.Drawing.Point(0, 0);
            tabControl2.Name = "tabControl2";
            tabControl2.SelectedIndex = 0;
            tabControl2.Size = new System.Drawing.Size(362, 467);
            tabControl2.TabIndex = 6;
            // 
            // tabPage3
            // 
            tabPage3.BackColor = System.Drawing.Color.White;
            tabPage3.Controls.Add(listSkills);
            tabPage3.Controls.Add(panel1);
            tabPage3.Location = new System.Drawing.Point(4, 24);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new System.Windows.Forms.Padding(3);
            tabPage3.Size = new System.Drawing.Size(354, 439);
            tabPage3.TabIndex = 0;
            tabPage3.Text = "Player skills";
            // 
            // listSkills
            // 
            listSkills.BackColor = System.Drawing.Color.White;
            listSkills.BorderStyle = System.Windows.Forms.BorderStyle.None;
            listSkills.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { colName, colLevel });
            listSkills.ContextMenuStrip = skillContextMenu;
            listSkills.Dock = System.Windows.Forms.DockStyle.Fill;
            listSkills.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            listSkills.FullRowSelect = true;
            listSkills.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            listSkills.Location = new System.Drawing.Point(3, 3);
            listSkills.Name = "listSkills";
            listSkills.Size = new System.Drawing.Size(348, 404);
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
            skillContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { skillContextMenuAddAttackSkill, toolStripSeparator1, skillContextMenuAddBuffSkill, toolStripSeparator2, useToolStripMenuItem, useToPartyMemberToolStripMenuItem });
            skillContextMenu.Name = "skillContextMenu";
            skillContextMenu.Size = new System.Drawing.Size(186, 104);
            skillContextMenu.Opening += skillContextMenu_Opening;
            // 
            // skillContextMenuAddAttackSkill
            // 
            skillContextMenuAddAttackSkill.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            skillContextMenuAddAttackSkill.Name = "skillContextMenuAddAttackSkill";
            skillContextMenuAddAttackSkill.Size = new System.Drawing.Size(185, 22);
            skillContextMenuAddAttackSkill.Text = "Add To Attacks";
            skillContextMenuAddAttackSkill.Click += menuAddAttack_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new System.Drawing.Size(182, 6);
            // 
            // skillContextMenuAddBuffSkill
            // 
            skillContextMenuAddBuffSkill.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            skillContextMenuAddBuffSkill.Name = "skillContextMenuAddBuffSkill";
            skillContextMenuAddBuffSkill.Size = new System.Drawing.Size(185, 22);
            skillContextMenuAddBuffSkill.Text = "Add To Buffs";
            skillContextMenuAddBuffSkill.Click += menuAddBuff_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new System.Drawing.Size(182, 6);
            // 
            // useToolStripMenuItem
            // 
            useToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            useToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            useToolStripMenuItem.Name = "useToolStripMenuItem";
            useToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            useToolStripMenuItem.Text = "Use";
            useToolStripMenuItem.Click += useToolStripMenuItem_Click;
            // 
            // useToPartyMemberToolStripMenuItem
            // 
            useToPartyMemberToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            useToPartyMemberToolStripMenuItem.Name = "useToPartyMemberToolStripMenuItem";
            useToPartyMemberToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            useToPartyMemberToolStripMenuItem.Text = "Use to party member";
            // 
            // panel1
            // 
            panel1.BackColor = System.Drawing.Color.Transparent;
            panel1.Border = new System.Windows.Forms.Padding(0, 1, 0, 0);
            panel1.BorderColor = System.Drawing.Color.Transparent;
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(checkHideLowerLevelSkills);
            panel1.Controls.Add(checkShowAttacks);
            panel1.Controls.Add(checkShowBuffs);
            panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            panel1.Location = new System.Drawing.Point(3, 407);
            panel1.Name = "panel1";
            panel1.Radius = 0;
            panel1.ShadowDepth = 4F;
            panel1.Size = new System.Drawing.Size(348, 29);
            panel1.TabIndex = 9;
            // 
            // panel2
            // 
            panel2.BackColor = System.Drawing.Color.Transparent;
            panel2.Border = new System.Windows.Forms.Padding(0, 0, 0, 0);
            panel2.BorderColor = System.Drawing.Color.Transparent;
            panel2.Dock = System.Windows.Forms.DockStyle.Top;
            panel2.Location = new System.Drawing.Point(0, 0);
            panel2.Name = "panel2";
            panel2.Radius = 1;
            panel2.ShadowDepth = 4F;
            panel2.Size = new System.Drawing.Size(348, 1);
            panel2.TabIndex = 9;
            // 
            // checkHideLowerLevelSkills
            // 
            checkHideLowerLevelSkills.AutoSize = true;
            checkHideLowerLevelSkills.BackColor = System.Drawing.Color.Transparent;
            checkHideLowerLevelSkills.Location = new System.Drawing.Point(207, 6);
            checkHideLowerLevelSkills.Name = "checkHideLowerLevelSkills";
            checkHideLowerLevelSkills.ShadowDepth = 1;
            checkHideLowerLevelSkills.Size = new System.Drawing.Size(135, 15);
            checkHideLowerLevelSkills.TabIndex = 6;
            checkHideLowerLevelSkills.Text = "Hide lower level skills";
            checkHideLowerLevelSkills.UseVisualStyleBackColor = false;
            checkHideLowerLevelSkills.CheckedChanged += Filter_CheckedChanged;
            // 
            // checkShowAttacks
            // 
            checkShowAttacks.AutoSize = true;
            checkShowAttacks.BackColor = System.Drawing.Color.Transparent;
            checkShowAttacks.Checked = true;
            checkShowAttacks.CheckState = System.Windows.Forms.CheckState.Checked;
            checkShowAttacks.Location = new System.Drawing.Point(8, 6);
            checkShowAttacks.Name = "checkShowAttacks";
            checkShowAttacks.ShadowDepth = 1;
            checkShowAttacks.Size = new System.Drawing.Size(62, 15);
            checkShowAttacks.TabIndex = 7;
            checkShowAttacks.Text = "Attacks";
            checkShowAttacks.UseVisualStyleBackColor = false;
            checkShowAttacks.CheckedChanged += Filter_CheckedChanged;
            // 
            // checkShowBuffs
            // 
            checkShowBuffs.AutoSize = true;
            checkShowBuffs.BackColor = System.Drawing.Color.Transparent;
            checkShowBuffs.Checked = true;
            checkShowBuffs.CheckState = System.Windows.Forms.CheckState.Checked;
            checkShowBuffs.Location = new System.Drawing.Point(79, 6);
            checkShowBuffs.Name = "checkShowBuffs";
            checkShowBuffs.ShadowDepth = 1;
            checkShowBuffs.Size = new System.Drawing.Size(50, 15);
            checkShowBuffs.TabIndex = 8;
            checkShowBuffs.Text = "Buffs";
            checkShowBuffs.UseVisualStyleBackColor = false;
            checkShowBuffs.CheckedChanged += Filter_CheckedChanged;
            // 
            // tabPage4
            // 
            tabPage4.BackColor = System.Drawing.Color.White;
            tabPage4.Controls.Add(listActiveBuffs);
            tabPage4.Location = new System.Drawing.Point(4, 25);
            tabPage4.Name = "tabPage4";
            tabPage4.Padding = new System.Windows.Forms.Padding(3);
            tabPage4.Size = new System.Drawing.Size(354, 438);
            tabPage4.TabIndex = 1;
            tabPage4.Text = "Active buffs";
            // 
            // listActiveBuffs
            // 
            listActiveBuffs.BackColor = System.Drawing.Color.White;
            listActiveBuffs.BorderStyle = System.Windows.Forms.BorderStyle.None;
            listActiveBuffs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { colActiveName, colActiveLevel });
            listActiveBuffs.Dock = System.Windows.Forms.DockStyle.Fill;
            listActiveBuffs.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            listActiveBuffs.FullRowSelect = true;
            listActiveBuffs.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            listActiveBuffs.Location = new System.Drawing.Point(3, 3);
            listActiveBuffs.Name = "listActiveBuffs";
            listActiveBuffs.Size = new System.Drawing.Size(348, 432);
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
            AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            Controls.Add(tabControl2);
            Controls.Add(tabControl1);
            Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            Name = "Main";
            Size = new System.Drawing.Size(754, 467);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            groupWarlockMode.ResumeLayout(false);
            groupWarlockMode.PerformLayout();
            grpMasteryLearn.ResumeLayout(false);
            grpMasteryLearn.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numMasteryGap).EndInit();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            tabControl2.ResumeLayout(false);
            tabPage3.ResumeLayout(false);
            skillContextMenu.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            tabPage4.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private SDUI.Controls.GroupBox groupBox1;
        private SDUI.Controls.GroupBox groupBox2;
        private SDUI.Controls.Button btnRemoveAttackSkill;
        private SDUI.Controls.Button btnMoveAttackSkillDown;
        private SDUI.Controls.Button btnMoveAttackSkillUp;
        private SDUI.Controls.ComboBox comboImbue;
        private SDUI.Controls.Label label1;
        private SDUI.Controls.Button btnRemoveBuffSkill;
        private SDUI.Controls.Label label2;
        private SDUI.Controls.ComboBox comboMonsterType;
        private SDUI.Controls.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private SDUI.Controls.ComboBox comboResurrectionSkill;
        private SDUI.Controls.Label label3;
        private SDUI.Controls.CheckBox checkResurrectParty;
        private SDUI.Controls.CheckBox checkAcceptResurrection;
        private SDUI.Controls.CheckBox checkCastBuffsInTowns;
        private SDUI.Controls.GroupBox groupBox3;
        private SDUI.Controls.GroupBox groupBox4;
        private SDUI.Controls.CheckBox checkCastBuffsDuringWalkBack;
        private SDUI.Controls.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage3;
        private SDUI.Controls.CheckBox checkShowAttacks;
        private SDUI.Controls.CheckBox checkShowBuffs;
        private SDUI.Controls.CheckBox checkHideLowerLevelSkills;
        private SDUI.Controls.ListView listSkills;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colLevel;
        private System.Windows.Forms.TabPage tabPage4;
        private SDUI.Controls.ListView listActiveBuffs;
        private System.Windows.Forms.ColumnHeader colActiveName;
        private System.Windows.Forms.ColumnHeader colActiveLevel;
        private SDUI.Controls.Button btnMoveBuffSkillDown;
        private SDUI.Controls.Button btnMoveBuffSkillUp;
        private SDUI.Controls.Panel panel1;
        private SDUI.Controls.Panel panel2;
        private SDUI.Controls.ListView listAttackingSkills;
        private System.Windows.Forms.ColumnHeader columnName;
        private System.Windows.Forms.ColumnHeader columnLevel;
        private SDUI.Controls.ListView listBuffs;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private SDUI.Controls.ContextMenuStrip skillContextMenu;
        private SDUI.Controls.CheckBox checkBoxNoAttack;
        private System.Windows.Forms.ToolStripMenuItem skillContextMenuAddBuffSkill;
        private System.Windows.Forms.ToolStripMenuItem skillContextMenuAddAttackSkill;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private SDUI.Controls.GroupBox grpMasteryLearn;
        private SDUI.Controls.Label label4;
        private SDUI.Controls.NumUpDown numMasteryGap;
        private SDUI.Controls.ComboBox comboLearnMastery;
        private SDUI.Controls.CheckBox checkLearnMastery;
        private SDUI.Controls.CheckBox checkLearnMasteryBotStopped;
        private SDUI.Controls.GroupBox groupWarlockMode;
        private SDUI.Controls.CheckBox checkWarlockMode;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem useToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem useToPartyMemberToolStripMenuItem;
        private SDUI.Controls.CheckBox checkUseDefaultAttack;
        private SDUI.Controls.CheckBox checkUseSkillsInOrder;
        private SDUI.Controls.ComboBox comboTeleportSkill;
        private SDUI.Controls.CheckBox checkUseTeleportSkill;
    }
}
