namespace RSBot.Protection.Views
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label22 = new System.Windows.Forms.Label();
            groupBackTown = new System.Windows.Forms.GroupBox();
            checkStopBotOnReturnToTown = new System.Windows.Forms.CheckBox();
            label21 = new System.Windows.Forms.Label();
            numDeadTimeout = new System.Windows.Forms.NumericUpDown();
            checkLevelUp = new System.Windows.Forms.CheckBox();
            checkFullPetInventory = new System.Windows.Forms.CheckBox();
            checkNoMPPotions = new System.Windows.Forms.CheckBox();
            checkNoHPPotions = new System.Windows.Forms.CheckBox();
            checkDurability = new System.Windows.Forms.CheckBox();
            checkDead = new System.Windows.Forms.CheckBox();
            checkInventory = new System.Windows.Forms.CheckBox();
            checkNoArrows = new System.Windows.Forms.CheckBox();
            groupBadStatus = new System.Windows.Forms.GroupBox();
            label18 = new System.Windows.Forms.Label();
            comboSkillBadStatus = new System.Windows.Forms.ComboBox();
            checkUseBadStatusSkill = new System.Windows.Forms.CheckBox();
            checkUseUniversalPills = new System.Windows.Forms.CheckBox();
            groupHPMP = new System.Windows.Forms.GroupBox();
            label17 = new System.Windows.Forms.Label();
            comboSkillPlayerMP = new System.Windows.Forms.ComboBox();
            comboSkillPlayerHP = new System.Windows.Forms.ComboBox();
            label11 = new System.Windows.Forms.Label();
            numPlayerSkillMPMin = new System.Windows.Forms.NumericUpDown();
            label12 = new System.Windows.Forms.Label();
            label9 = new System.Windows.Forms.Label();
            numPlayerSkillHPMin = new System.Windows.Forms.NumericUpDown();
            label10 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            numPlayerMPVigorPotionMin = new System.Windows.Forms.NumericUpDown();
            label8 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            numPlayerHPVigorPotionMin = new System.Windows.Forms.NumericUpDown();
            label6 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            numPlayerMPPotionMin = new System.Windows.Forms.NumericUpDown();
            label4 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            numPlayerHPPotionMin = new System.Windows.Forms.NumericUpDown();
            label1 = new System.Windows.Forms.Label();
            checkUseSkillHP = new System.Windows.Forms.CheckBox();
            checkUseSkillMP = new System.Windows.Forms.CheckBox();
            checkUseHPPotionsPlayer = new System.Windows.Forms.CheckBox();
            checkUseVigorMP = new System.Windows.Forms.CheckBox();
            checkUseMPPotionsPlayer = new System.Windows.Forms.CheckBox();
            checkUseVigorHP = new System.Windows.Forms.CheckBox();
            groupPet = new System.Windows.Forms.GroupBox();
            checkAutoSummonAttackPet = new System.Windows.Forms.CheckBox();
            checkUseAbnormalStatePotion = new System.Windows.Forms.CheckBox();
            checkReviveAttackPet = new System.Windows.Forms.CheckBox();
            label13 = new System.Windows.Forms.Label();
            numPetMinHGP = new System.Windows.Forms.NumericUpDown();
            label14 = new System.Windows.Forms.Label();
            label15 = new System.Windows.Forms.Label();
            numPetMinHP = new System.Windows.Forms.NumericUpDown();
            label16 = new System.Windows.Forms.Label();
            checkUsePetHP = new System.Windows.Forms.CheckBox();
            checkUseHGP = new System.Windows.Forms.CheckBox();
            groupStatPoints = new System.Windows.Forms.GroupBox();
            buttonRun = new System.Windows.Forms.Button();
            checkIncBotStopped = new System.Windows.Forms.CheckBox();
            numIncStr = new System.Windows.Forms.NumericUpDown();
            numIncInt = new System.Windows.Forms.NumericUpDown();
            checkIncStr = new System.Windows.Forms.CheckBox();
            checkIncInt = new System.Windows.Forms.CheckBox();
            groupBackTown.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numDeadTimeout).BeginInit();
            groupBadStatus.SuspendLayout();
            groupHPMP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numPlayerSkillMPMin).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numPlayerSkillHPMin).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numPlayerMPVigorPotionMin).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numPlayerHPVigorPotionMin).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numPlayerMPPotionMin).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numPlayerHPPotionMin).BeginInit();
            groupPet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numPetMinHGP).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numPetMinHP).BeginInit();
            groupStatPoints.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numIncStr).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numIncInt).BeginInit();
            SuspendLayout();
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Location = new System.Drawing.Point(630, 566);
            label22.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label22.Name = "label22";
            label22.Size = new System.Drawing.Size(322, 20);
            label22.TabIndex = 16;
            label22.Text = "* Will also be executed, if the bot is not started.";
            // 
            // groupBackTown
            // 
            groupBackTown.Controls.Add(checkStopBotOnReturnToTown);
            groupBackTown.Controls.Add(label21);
            groupBackTown.Controls.Add(numDeadTimeout);
            groupBackTown.Controls.Add(checkLevelUp);
            groupBackTown.Controls.Add(checkFullPetInventory);
            groupBackTown.Controls.Add(checkNoMPPotions);
            groupBackTown.Controls.Add(checkNoHPPotions);
            groupBackTown.Controls.Add(checkDurability);
            groupBackTown.Controls.Add(checkDead);
            groupBackTown.Controls.Add(checkInventory);
            groupBackTown.Controls.Add(checkNoArrows);
            groupBackTown.Location = new System.Drawing.Point(625, 9);
            groupBackTown.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            groupBackTown.Name = "groupBackTown";
            groupBackTown.Padding = new System.Windows.Forms.Padding(4, 12, 4, 4);
            groupBackTown.Size = new System.Drawing.Size(318, 332);
            groupBackTown.TabIndex = 17;
            groupBackTown.TabStop = false;
            groupBackTown.Text = "Back to town";
            // 
            // checkStopBotOnReturnToTown
            // 
            checkStopBotOnReturnToTown.AutoSize = true;
            checkStopBotOnReturnToTown.Location = new System.Drawing.Point(15, 79);
            checkStopBotOnReturnToTown.Margin = new System.Windows.Forms.Padding(0);
            checkStopBotOnReturnToTown.Name = "checkStopBotOnReturnToTown";
            checkStopBotOnReturnToTown.Size = new System.Drawing.Size(216, 24);
            checkStopBotOnReturnToTown.TabIndex = 11;
            checkStopBotOnReturnToTown.Text = "Stop bot when back in town";
            checkStopBotOnReturnToTown.UseVisualStyleBackColor = false;
            checkStopBotOnReturnToTown.CheckedChanged += settings_CheckedChanged;
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Location = new System.Drawing.Point(270, 46);
            label21.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label21.Name = "label21";
            label21.Size = new System.Drawing.Size(21, 20);
            label21.TabIndex = 10;
            label21.Text = "/s";
            // 
            // numDeadTimeout
            // 
            numDeadTimeout.Location = new System.Drawing.Point(191, 44);
            numDeadTimeout.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            numDeadTimeout.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numDeadTimeout.Name = "numDeadTimeout";
            numDeadTimeout.Size = new System.Drawing.Size(75, 27);
            numDeadTimeout.TabIndex = 9;
            numDeadTimeout.Value = new decimal(new int[] { 30, 0, 0, 0 });
            numDeadTimeout.ValueChanged += numSettings_ValueChanged;
            // 
            // checkLevelUp
            // 
            checkLevelUp.AutoSize = true;
            checkLevelUp.Location = new System.Drawing.Point(15, 289);
            checkLevelUp.Margin = new System.Windows.Forms.Padding(0);
            checkLevelUp.Name = "checkLevelUp";
            checkLevelUp.Size = new System.Drawing.Size(86, 24);
            checkLevelUp.TabIndex = 8;
            checkLevelUp.Text = "Level up";
            checkLevelUp.UseVisualStyleBackColor = false;
            checkLevelUp.CheckedChanged += settings_CheckedChanged;
            // 
            // checkFullPetInventory
            // 
            checkFullPetInventory.AutoSize = true;
            checkFullPetInventory.Location = new System.Drawing.Point(15, 169);
            checkFullPetInventory.Margin = new System.Windows.Forms.Padding(0);
            checkFullPetInventory.Name = "checkFullPetInventory";
            checkFullPetInventory.Size = new System.Drawing.Size(145, 24);
            checkFullPetInventory.TabIndex = 7;
            checkFullPetInventory.Text = "Full pet inventory";
            checkFullPetInventory.UseVisualStyleBackColor = false;
            checkFullPetInventory.CheckedChanged += settings_CheckedChanged;
            // 
            // checkNoMPPotions
            // 
            checkNoMPPotions.AutoSize = true;
            checkNoMPPotions.Location = new System.Drawing.Point(15, 229);
            checkNoMPPotions.Margin = new System.Windows.Forms.Padding(0);
            checkNoMPPotions.Name = "checkNoMPPotions";
            checkNoMPPotions.Size = new System.Drawing.Size(154, 24);
            checkNoMPPotions.TabIndex = 6;
            checkNoMPPotions.Text = "No MP Potions left";
            checkNoMPPotions.UseVisualStyleBackColor = false;
            checkNoMPPotions.CheckedChanged += settings_CheckedChanged;
            // 
            // checkNoHPPotions
            // 
            checkNoHPPotions.AutoSize = true;
            checkNoHPPotions.Location = new System.Drawing.Point(15, 199);
            checkNoHPPotions.Margin = new System.Windows.Forms.Padding(0);
            checkNoHPPotions.Name = "checkNoHPPotions";
            checkNoHPPotions.Size = new System.Drawing.Size(152, 24);
            checkNoHPPotions.TabIndex = 5;
            checkNoHPPotions.Text = "No HP Potions left";
            checkNoHPPotions.UseVisualStyleBackColor = false;
            checkNoHPPotions.CheckedChanged += settings_CheckedChanged;
            // 
            // checkDurability
            // 
            checkDurability.AutoSize = true;
            checkDurability.Location = new System.Drawing.Point(15, 259);
            checkDurability.Margin = new System.Windows.Forms.Padding(0);
            checkDurability.Name = "checkDurability";
            checkDurability.Size = new System.Drawing.Size(198, 24);
            checkDurability.TabIndex = 4;
            checkDurability.Text = "Equipment durability low";
            checkDurability.UseVisualStyleBackColor = false;
            checkDurability.CheckedChanged += settings_CheckedChanged;
            // 
            // checkDead
            // 
            checkDead.AutoSize = true;
            checkDead.Location = new System.Drawing.Point(15, 45);
            checkDead.Margin = new System.Windows.Forms.Padding(0);
            checkDead.Name = "checkDead";
            checkDead.Size = new System.Drawing.Size(161, 24);
            checkDead.TabIndex = 3;
            checkDead.Text = "Dead with delay of ";
            checkDead.UseVisualStyleBackColor = false;
            checkDead.CheckedChanged += settings_CheckedChanged;
            // 
            // checkInventory
            // 
            checkInventory.AutoSize = true;
            checkInventory.Location = new System.Drawing.Point(15, 139);
            checkInventory.Margin = new System.Windows.Forms.Padding(0);
            checkInventory.Name = "checkInventory";
            checkInventory.Size = new System.Drawing.Size(119, 24);
            checkInventory.TabIndex = 4;
            checkInventory.Text = "Full inventory";
            checkInventory.UseVisualStyleBackColor = false;
            checkInventory.CheckedChanged += settings_CheckedChanged;
            // 
            // checkNoArrows
            // 
            checkNoArrows.AutoSize = true;
            checkNoArrows.Location = new System.Drawing.Point(15, 109);
            checkNoArrows.Margin = new System.Windows.Forms.Padding(0);
            checkNoArrows.Name = "checkNoArrows";
            checkNoArrows.Size = new System.Drawing.Size(172, 24);
            checkNoArrows.TabIndex = 4;
            checkNoArrows.Text = "No arrows / bolts left";
            checkNoArrows.UseVisualStyleBackColor = false;
            checkNoArrows.CheckedChanged += settings_CheckedChanged;
            // 
            // groupBadStatus
            // 
            groupBadStatus.Controls.Add(label18);
            groupBadStatus.Controls.Add(comboSkillBadStatus);
            groupBadStatus.Controls.Add(checkUseBadStatusSkill);
            groupBadStatus.Controls.Add(checkUseUniversalPills);
            groupBadStatus.Location = new System.Drawing.Point(19, 282);
            groupBadStatus.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            groupBadStatus.Name = "groupBadStatus";
            groupBadStatus.Padding = new System.Windows.Forms.Padding(4, 12, 4, 4);
            groupBadStatus.Size = new System.Drawing.Size(585, 116);
            groupBadStatus.TabIndex = 6;
            groupBadStatus.TabStop = false;
            groupBadStatus.Text = "Bad status";
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new System.Drawing.Point(272, 50);
            label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label18.Name = "label18";
            label18.Size = new System.Drawing.Size(39, 20);
            label18.TabIndex = 27;
            label18.Text = "Skill:";
            // 
            // comboSkillBadStatus
            // 
            comboSkillBadStatus.DropDownHeight = 100;
            comboSkillBadStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboSkillBadStatus.FormattingEnabled = true;
            comboSkillBadStatus.IntegralHeight = false;
            comboSkillBadStatus.ItemHeight = 20;
            comboSkillBadStatus.Location = new System.Drawing.Point(275, 72);
            comboSkillBadStatus.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            comboSkillBadStatus.Name = "comboSkillBadStatus";
            comboSkillBadStatus.Size = new System.Drawing.Size(150, 28);
            comboSkillBadStatus.TabIndex = 26;
            comboSkillBadStatus.SelectedIndexChanged += comboSkill_SelectedIndexChanged;
            // 
            // checkUseBadStatusSkill
            // 
            checkUseBadStatusSkill.AutoSize = true;
            checkUseBadStatusSkill.Location = new System.Drawing.Point(14, 74);
            checkUseBadStatusSkill.Margin = new System.Windows.Forms.Padding(0);
            checkUseBadStatusSkill.Name = "checkUseBadStatusSkill";
            checkUseBadStatusSkill.Size = new System.Drawing.Size(86, 24);
            checkUseBadStatusSkill.TabIndex = 5;
            checkUseBadStatusSkill.Text = "Use Skill";
            checkUseBadStatusSkill.UseVisualStyleBackColor = false;
            checkUseBadStatusSkill.CheckedChanged += settings_CheckedChanged;
            // 
            // checkUseUniversalPills
            // 
            checkUseUniversalPills.AutoSize = true;
            checkUseUniversalPills.Location = new System.Drawing.Point(14, 36);
            checkUseUniversalPills.Margin = new System.Windows.Forms.Padding(0);
            checkUseUniversalPills.Name = "checkUseUniversalPills";
            checkUseUniversalPills.Size = new System.Drawing.Size(159, 24);
            checkUseUniversalPills.TabIndex = 4;
            checkUseUniversalPills.Text = "Use Universal Pills *";
            checkUseUniversalPills.UseVisualStyleBackColor = false;
            checkUseUniversalPills.CheckedChanged += settings_CheckedChanged;
            // 
            // groupHPMP
            // 
            groupHPMP.Controls.Add(label17);
            groupHPMP.Controls.Add(comboSkillPlayerMP);
            groupHPMP.Controls.Add(comboSkillPlayerHP);
            groupHPMP.Controls.Add(label11);
            groupHPMP.Controls.Add(numPlayerSkillMPMin);
            groupHPMP.Controls.Add(label12);
            groupHPMP.Controls.Add(label9);
            groupHPMP.Controls.Add(numPlayerSkillHPMin);
            groupHPMP.Controls.Add(label10);
            groupHPMP.Controls.Add(label7);
            groupHPMP.Controls.Add(numPlayerMPVigorPotionMin);
            groupHPMP.Controls.Add(label8);
            groupHPMP.Controls.Add(label5);
            groupHPMP.Controls.Add(numPlayerHPVigorPotionMin);
            groupHPMP.Controls.Add(label6);
            groupHPMP.Controls.Add(label3);
            groupHPMP.Controls.Add(numPlayerMPPotionMin);
            groupHPMP.Controls.Add(label4);
            groupHPMP.Controls.Add(label2);
            groupHPMP.Controls.Add(numPlayerHPPotionMin);
            groupHPMP.Controls.Add(label1);
            groupHPMP.Controls.Add(checkUseSkillHP);
            groupHPMP.Controls.Add(checkUseSkillMP);
            groupHPMP.Controls.Add(checkUseHPPotionsPlayer);
            groupHPMP.Controls.Add(checkUseVigorMP);
            groupHPMP.Controls.Add(checkUseMPPotionsPlayer);
            groupHPMP.Controls.Add(checkUseVigorHP);
            groupHPMP.Location = new System.Drawing.Point(19, 9);
            groupHPMP.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            groupHPMP.Name = "groupHPMP";
            groupHPMP.Padding = new System.Windows.Forms.Padding(4, 12, 4, 4);
            groupHPMP.Size = new System.Drawing.Size(585, 266);
            groupHPMP.TabIndex = 5;
            groupHPMP.TabStop = false;
            groupHPMP.Text = "Health / Mana recovery";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new System.Drawing.Point(415, 168);
            label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label17.Name = "label17";
            label17.Size = new System.Drawing.Size(39, 20);
            label17.TabIndex = 26;
            label17.Text = "Skill:";
            // 
            // comboSkillPlayerMP
            // 
            comboSkillPlayerMP.DropDownHeight = 100;
            comboSkillPlayerMP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboSkillPlayerMP.FormattingEnabled = true;
            comboSkillPlayerMP.IntegralHeight = false;
            comboSkillPlayerMP.ItemHeight = 20;
            comboSkillPlayerMP.Location = new System.Drawing.Point(415, 224);
            comboSkillPlayerMP.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            comboSkillPlayerMP.Name = "comboSkillPlayerMP";
            comboSkillPlayerMP.Size = new System.Drawing.Size(150, 28);
            comboSkillPlayerMP.TabIndex = 25;
            comboSkillPlayerMP.SelectedIndexChanged += comboSkill_SelectedIndexChanged;
            // 
            // comboSkillPlayerHP
            // 
            comboSkillPlayerHP.DropDownHeight = 100;
            comboSkillPlayerHP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboSkillPlayerHP.FormattingEnabled = true;
            comboSkillPlayerHP.IntegralHeight = false;
            comboSkillPlayerHP.ItemHeight = 20;
            comboSkillPlayerHP.Location = new System.Drawing.Point(415, 190);
            comboSkillPlayerHP.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            comboSkillPlayerHP.Name = "comboSkillPlayerHP";
            comboSkillPlayerHP.Size = new System.Drawing.Size(150, 28);
            comboSkillPlayerHP.TabIndex = 7;
            comboSkillPlayerHP.SelectedIndexChanged += comboSkill_SelectedIndexChanged;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new System.Drawing.Point(382, 227);
            label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label11.Name = "label11";
            label11.Size = new System.Drawing.Size(21, 20);
            label11.TabIndex = 24;
            label11.Text = "%";
            // 
            // numPlayerSkillMPMin
            // 
            numPlayerSkillMPMin.Font = new System.Drawing.Font("Segoe UI", 9.25F);
            numPlayerSkillMPMin.Location = new System.Drawing.Point(275, 224);
            numPlayerSkillMPMin.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            numPlayerSkillMPMin.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numPlayerSkillMPMin.MinimumSize = new System.Drawing.Size(100, 0);
            numPlayerSkillMPMin.Name = "numPlayerSkillMPMin";
            numPlayerSkillMPMin.Size = new System.Drawing.Size(100, 28);
            numPlayerSkillMPMin.TabIndex = 23;
            numPlayerSkillMPMin.Value = new decimal(new int[] { 50, 0, 0, 0 });
            numPlayerSkillMPMin.ValueChanged += numSettings_ValueChanged;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new System.Drawing.Point(251, 228);
            label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label12.Name = "label12";
            label12.Size = new System.Drawing.Size(19, 20);
            label12.TabIndex = 22;
            label12.Text = "<";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new System.Drawing.Point(383, 192);
            label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(21, 20);
            label9.TabIndex = 21;
            label9.Text = "%";
            // 
            // numPlayerSkillHPMin
            // 
            numPlayerSkillHPMin.Font = new System.Drawing.Font("Segoe UI", 9.25F);
            numPlayerSkillHPMin.Location = new System.Drawing.Point(275, 190);
            numPlayerSkillHPMin.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            numPlayerSkillHPMin.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numPlayerSkillHPMin.MinimumSize = new System.Drawing.Size(100, 0);
            numPlayerSkillHPMin.Name = "numPlayerSkillHPMin";
            numPlayerSkillHPMin.Size = new System.Drawing.Size(100, 28);
            numPlayerSkillHPMin.TabIndex = 20;
            numPlayerSkillHPMin.Value = new decimal(new int[] { 50, 0, 0, 0 });
            numPlayerSkillHPMin.ValueChanged += numSettings_ValueChanged;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new System.Drawing.Point(251, 194);
            label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(19, 20);
            label10.TabIndex = 19;
            label10.Text = "<";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(382, 147);
            label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(21, 20);
            label7.TabIndex = 18;
            label7.Text = "%";
            // 
            // numPlayerMPVigorPotionMin
            // 
            numPlayerMPVigorPotionMin.Font = new System.Drawing.Font("Segoe UI", 9.25F);
            numPlayerMPVigorPotionMin.Location = new System.Drawing.Point(275, 143);
            numPlayerMPVigorPotionMin.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            numPlayerMPVigorPotionMin.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numPlayerMPVigorPotionMin.MinimumSize = new System.Drawing.Size(100, 0);
            numPlayerMPVigorPotionMin.Name = "numPlayerMPVigorPotionMin";
            numPlayerMPVigorPotionMin.Size = new System.Drawing.Size(100, 28);
            numPlayerMPVigorPotionMin.TabIndex = 17;
            numPlayerMPVigorPotionMin.Value = new decimal(new int[] { 50, 0, 0, 0 });
            numPlayerMPVigorPotionMin.ValueChanged += numSettings_ValueChanged;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new System.Drawing.Point(251, 147);
            label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(19, 20);
            label8.TabIndex = 16;
            label8.Text = "<";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(383, 112);
            label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(21, 20);
            label5.TabIndex = 15;
            label5.Text = "%";
            // 
            // numPlayerHPVigorPotionMin
            // 
            numPlayerHPVigorPotionMin.Font = new System.Drawing.Font("Segoe UI", 9.25F);
            numPlayerHPVigorPotionMin.Location = new System.Drawing.Point(275, 107);
            numPlayerHPVigorPotionMin.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            numPlayerHPVigorPotionMin.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numPlayerHPVigorPotionMin.MinimumSize = new System.Drawing.Size(100, 0);
            numPlayerHPVigorPotionMin.Name = "numPlayerHPVigorPotionMin";
            numPlayerHPVigorPotionMin.Size = new System.Drawing.Size(100, 28);
            numPlayerHPVigorPotionMin.TabIndex = 14;
            numPlayerHPVigorPotionMin.Value = new decimal(new int[] { 50, 0, 0, 0 });
            numPlayerHPVigorPotionMin.ValueChanged += numSettings_ValueChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(251, 112);
            label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(19, 20);
            label6.TabIndex = 13;
            label6.Text = "<";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(382, 73);
            label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(21, 20);
            label3.TabIndex = 12;
            label3.Text = "%";
            // 
            // numPlayerMPPotionMin
            // 
            numPlayerMPPotionMin.Font = new System.Drawing.Font("Segoe UI", 9.25F);
            numPlayerMPPotionMin.Location = new System.Drawing.Point(275, 71);
            numPlayerMPPotionMin.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            numPlayerMPPotionMin.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numPlayerMPPotionMin.MinimumSize = new System.Drawing.Size(100, 0);
            numPlayerMPPotionMin.Name = "numPlayerMPPotionMin";
            numPlayerMPPotionMin.Size = new System.Drawing.Size(100, 28);
            numPlayerMPPotionMin.TabIndex = 11;
            numPlayerMPPotionMin.Value = new decimal(new int[] { 50, 0, 0, 0 });
            numPlayerMPPotionMin.ValueChanged += numSettings_ValueChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(251, 76);
            label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(19, 20);
            label4.TabIndex = 10;
            label4.Text = "<";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(382, 39);
            label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(21, 20);
            label2.TabIndex = 9;
            label2.Text = "%";
            // 
            // numPlayerHPPotionMin
            // 
            numPlayerHPPotionMin.Font = new System.Drawing.Font("Segoe UI", 9.25F);
            numPlayerHPPotionMin.Location = new System.Drawing.Point(275, 35);
            numPlayerHPPotionMin.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            numPlayerHPPotionMin.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numPlayerHPPotionMin.MinimumSize = new System.Drawing.Size(100, 0);
            numPlayerHPPotionMin.Name = "numPlayerHPPotionMin";
            numPlayerHPPotionMin.Size = new System.Drawing.Size(100, 28);
            numPlayerHPPotionMin.TabIndex = 8;
            numPlayerHPPotionMin.Value = new decimal(new int[] { 50, 0, 0, 0 });
            numPlayerHPPotionMin.ValueChanged += numSettings_ValueChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(251, 39);
            label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(19, 20);
            label1.TabIndex = 7;
            label1.Text = "<";
            // 
            // checkUseSkillHP
            // 
            checkUseSkillHP.AutoSize = true;
            checkUseSkillHP.Location = new System.Drawing.Point(14, 191);
            checkUseSkillHP.Margin = new System.Windows.Forms.Padding(0);
            checkUseSkillHP.Name = "checkUseSkillHP";
            checkUseSkillHP.Size = new System.Drawing.Size(120, 24);
            checkUseSkillHP.TabIndex = 4;
            checkUseSkillHP.Text = "Use skill if HP";
            checkUseSkillHP.UseVisualStyleBackColor = false;
            checkUseSkillHP.CheckedChanged += settings_CheckedChanged;
            // 
            // checkUseSkillMP
            // 
            checkUseSkillMP.AutoSize = true;
            checkUseSkillMP.Location = new System.Drawing.Point(14, 226);
            checkUseSkillMP.Margin = new System.Windows.Forms.Padding(0);
            checkUseSkillMP.Name = "checkUseSkillMP";
            checkUseSkillMP.Size = new System.Drawing.Size(122, 24);
            checkUseSkillMP.TabIndex = 5;
            checkUseSkillMP.Text = "Use skill if MP";
            checkUseSkillMP.UseVisualStyleBackColor = false;
            checkUseSkillMP.CheckedChanged += settings_CheckedChanged;
            // 
            // checkUseHPPotionsPlayer
            // 
            checkUseHPPotionsPlayer.AutoSize = true;
            checkUseHPPotionsPlayer.Location = new System.Drawing.Point(14, 36);
            checkUseHPPotionsPlayer.Margin = new System.Windows.Forms.Padding(0);
            checkUseHPPotionsPlayer.Name = "checkUseHPPotionsPlayer";
            checkUseHPPotionsPlayer.Size = new System.Drawing.Size(178, 24);
            checkUseHPPotionsPlayer.TabIndex = 0;
            checkUseHPPotionsPlayer.Text = "Use HP potions if HP *";
            checkUseHPPotionsPlayer.UseVisualStyleBackColor = false;
            checkUseHPPotionsPlayer.CheckedChanged += settings_CheckedChanged;
            // 
            // checkUseVigorMP
            // 
            checkUseVigorMP.AutoSize = true;
            checkUseVigorMP.Location = new System.Drawing.Point(14, 141);
            checkUseVigorMP.Margin = new System.Windows.Forms.Padding(0);
            checkUseVigorMP.Name = "checkUseVigorMP";
            checkUseVigorMP.Size = new System.Drawing.Size(185, 24);
            checkUseVigorMP.TabIndex = 3;
            checkUseVigorMP.Text = "Use Vigor Potions if MP";
            checkUseVigorMP.UseVisualStyleBackColor = false;
            checkUseVigorMP.CheckedChanged += settings_CheckedChanged;
            // 
            // checkUseMPPotionsPlayer
            // 
            checkUseMPPotionsPlayer.AutoSize = true;
            checkUseMPPotionsPlayer.Location = new System.Drawing.Point(14, 75);
            checkUseMPPotionsPlayer.Margin = new System.Windows.Forms.Padding(0);
            checkUseMPPotionsPlayer.Name = "checkUseMPPotionsPlayer";
            checkUseMPPotionsPlayer.Size = new System.Drawing.Size(182, 24);
            checkUseMPPotionsPlayer.TabIndex = 1;
            checkUseMPPotionsPlayer.Text = "Use MP potions if MP *";
            checkUseMPPotionsPlayer.UseVisualStyleBackColor = false;
            checkUseMPPotionsPlayer.CheckedChanged += settings_CheckedChanged;
            // 
            // checkUseVigorHP
            // 
            checkUseVigorHP.AutoSize = true;
            checkUseVigorHP.Location = new System.Drawing.Point(14, 109);
            checkUseVigorHP.Margin = new System.Windows.Forms.Padding(0);
            checkUseVigorHP.Name = "checkUseVigorHP";
            checkUseVigorHP.Size = new System.Drawing.Size(183, 24);
            checkUseVigorHP.TabIndex = 2;
            checkUseVigorHP.Text = "Use Vigor Potions if HP";
            checkUseVigorHP.UseVisualStyleBackColor = false;
            checkUseVigorHP.CheckedChanged += settings_CheckedChanged;
            // 
            // groupPet
            // 
            groupPet.Controls.Add(checkAutoSummonAttackPet);
            groupPet.Controls.Add(checkUseAbnormalStatePotion);
            groupPet.Controls.Add(checkReviveAttackPet);
            groupPet.Controls.Add(label13);
            groupPet.Controls.Add(numPetMinHGP);
            groupPet.Controls.Add(label14);
            groupPet.Controls.Add(label15);
            groupPet.Controls.Add(numPetMinHP);
            groupPet.Controls.Add(label16);
            groupPet.Controls.Add(checkUsePetHP);
            groupPet.Controls.Add(checkUseHGP);
            groupPet.Location = new System.Drawing.Point(19, 406);
            groupPet.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            groupPet.Name = "groupPet";
            groupPet.Padding = new System.Windows.Forms.Padding(4, 12, 4, 4);
            groupPet.Size = new System.Drawing.Size(585, 200);
            groupPet.TabIndex = 1;
            groupPet.TabStop = false;
            groupPet.Text = "Recovery - Pet";
            // 
            // checkAutoSummonAttackPet
            // 
            checkAutoSummonAttackPet.AutoSize = true;
            checkAutoSummonAttackPet.Location = new System.Drawing.Point(14, 161);
            checkAutoSummonAttackPet.Margin = new System.Windows.Forms.Padding(0);
            checkAutoSummonAttackPet.Name = "checkAutoSummonAttackPet";
            checkAutoSummonAttackPet.Size = new System.Drawing.Size(256, 24);
            checkAutoSummonAttackPet.TabIndex = 27;
            checkAutoSummonAttackPet.Text = "Auto summon growth / fellow pet";
            checkAutoSummonAttackPet.UseVisualStyleBackColor = false;
            checkAutoSummonAttackPet.CheckedChanged += settings_CheckedChanged;
            // 
            // checkUseAbnormalStatePotion
            // 
            checkUseAbnormalStatePotion.AutoSize = true;
            checkUseAbnormalStatePotion.Location = new System.Drawing.Point(14, 102);
            checkUseAbnormalStatePotion.Margin = new System.Windows.Forms.Padding(0);
            checkUseAbnormalStatePotion.Name = "checkUseAbnormalStatePotion";
            checkUseAbnormalStatePotion.Size = new System.Drawing.Size(283, 24);
            checkUseAbnormalStatePotion.TabIndex = 26;
            checkUseAbnormalStatePotion.Text = "Use abnormal state recovery potions *";
            checkUseAbnormalStatePotion.UseVisualStyleBackColor = false;
            checkUseAbnormalStatePotion.CheckedChanged += settings_CheckedChanged;
            // 
            // checkReviveAttackPet
            // 
            checkReviveAttackPet.AutoSize = true;
            checkReviveAttackPet.Location = new System.Drawing.Point(14, 131);
            checkReviveAttackPet.Margin = new System.Windows.Forms.Padding(0);
            checkReviveAttackPet.Name = "checkReviveAttackPet";
            checkReviveAttackPet.Size = new System.Drawing.Size(206, 24);
            checkReviveAttackPet.TabIndex = 25;
            checkReviveAttackPet.Text = "Revive growth / fellow pet";
            checkReviveAttackPet.UseVisualStyleBackColor = false;
            checkReviveAttackPet.CheckedChanged += settings_CheckedChanged;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new System.Drawing.Point(441, 80);
            label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label13.Name = "label13";
            label13.Size = new System.Drawing.Size(21, 20);
            label13.TabIndex = 20;
            label13.Text = "%";
            // 
            // numPetMinHGP
            // 
            numPetMinHGP.Font = new System.Drawing.Font("Segoe UI", 9.25F);
            numPetMinHGP.Location = new System.Drawing.Point(334, 74);
            numPetMinHGP.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            numPetMinHGP.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numPetMinHGP.MinimumSize = new System.Drawing.Size(100, 0);
            numPetMinHGP.Name = "numPetMinHGP";
            numPetMinHGP.Size = new System.Drawing.Size(100, 28);
            numPetMinHGP.TabIndex = 19;
            numPetMinHGP.Value = new decimal(new int[] { 50, 0, 0, 0 });
            numPetMinHGP.ValueChanged += numSettings_ValueChanged;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new System.Drawing.Point(308, 80);
            label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label14.Name = "label14";
            label14.Size = new System.Drawing.Size(19, 20);
            label14.TabIndex = 18;
            label14.Text = "<";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new System.Drawing.Point(441, 45);
            label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label15.Name = "label15";
            label15.Size = new System.Drawing.Size(21, 20);
            label15.TabIndex = 17;
            label15.Text = "%";
            // 
            // numPetMinHP
            // 
            numPetMinHP.Font = new System.Drawing.Font("Segoe UI", 9.25F);
            numPetMinHP.Location = new System.Drawing.Point(334, 39);
            numPetMinHP.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            numPetMinHP.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numPetMinHP.MinimumSize = new System.Drawing.Size(100, 0);
            numPetMinHP.Name = "numPetMinHP";
            numPetMinHP.Size = new System.Drawing.Size(100, 28);
            numPetMinHP.TabIndex = 16;
            numPetMinHP.Value = new decimal(new int[] { 50, 0, 0, 0 });
            numPetMinHP.ValueChanged += numSettings_ValueChanged;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new System.Drawing.Point(308, 46);
            label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label16.Name = "label16";
            label16.Size = new System.Drawing.Size(19, 20);
            label16.TabIndex = 15;
            label16.Text = "<";
            // 
            // checkUsePetHP
            // 
            checkUsePetHP.AutoSize = true;
            checkUsePetHP.Location = new System.Drawing.Point(14, 38);
            checkUsePetHP.Margin = new System.Windows.Forms.Padding(0);
            checkUsePetHP.Name = "checkUsePetHP";
            checkUsePetHP.Size = new System.Drawing.Size(178, 24);
            checkUsePetHP.TabIndex = 13;
            checkUsePetHP.Text = "Use HP potions if HP *";
            checkUsePetHP.UseVisualStyleBackColor = false;
            checkUsePetHP.CheckedChanged += settings_CheckedChanged;
            // 
            // checkUseHGP
            // 
            checkUseHGP.AutoSize = true;
            checkUseHGP.Location = new System.Drawing.Point(14, 71);
            checkUseHGP.Margin = new System.Windows.Forms.Padding(0);
            checkUseHGP.Name = "checkUseHGP";
            checkUseHGP.Size = new System.Drawing.Size(269, 24);
            checkUseHGP.TabIndex = 14;
            checkUseHGP.Text = "Use HGP / Saiety potions if hunger *";
            checkUseHGP.UseVisualStyleBackColor = false;
            checkUseHGP.CheckedChanged += settings_CheckedChanged;
            // 
            // groupStatPoints
            // 
            groupStatPoints.Controls.Add(buttonRun);
            groupStatPoints.Controls.Add(checkIncBotStopped);
            groupStatPoints.Controls.Add(numIncStr);
            groupStatPoints.Controls.Add(numIncInt);
            groupStatPoints.Controls.Add(checkIncStr);
            groupStatPoints.Controls.Add(checkIncInt);
            groupStatPoints.Location = new System.Drawing.Point(625, 346);
            groupStatPoints.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            groupStatPoints.Name = "groupStatPoints";
            groupStatPoints.Padding = new System.Windows.Forms.Padding(4, 12, 4, 4);
            groupStatPoints.Size = new System.Drawing.Size(318, 211);
            groupStatPoints.TabIndex = 18;
            groupStatPoints.TabStop = false;
            groupStatPoints.Text = "Stat points";
            // 
            // buttonRun
            // 
            buttonRun.Location = new System.Drawing.Point(79, 171);
            buttonRun.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            buttonRun.Name = "buttonRun";
            buttonRun.Size = new System.Drawing.Size(121, 29);
            buttonRun.TabIndex = 27;
            buttonRun.Text = "Run";
            buttonRun.UseVisualStyleBackColor = true;
            buttonRun.Click += buttonRun_Click;
            // 
            // checkIncBotStopped
            // 
            checkIncBotStopped.AutoSize = true;
            checkIncBotStopped.Location = new System.Drawing.Point(22, 130);
            checkIncBotStopped.Margin = new System.Windows.Forms.Padding(0);
            checkIncBotStopped.Name = "checkIncBotStopped";
            checkIncBotStopped.Size = new System.Drawing.Size(198, 24);
            checkIncBotStopped.TabIndex = 24;
            checkIncBotStopped.Text = "Enabled if bot is stopped";
            checkIncBotStopped.UseVisualStyleBackColor = false;
            checkIncBotStopped.CheckedChanged += settings_CheckedChanged;
            // 
            // numIncStr
            // 
            numIncStr.Font = new System.Drawing.Font("Segoe UI", 9.25F);
            numIncStr.Location = new System.Drawing.Point(166, 95);
            numIncStr.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            numIncStr.Maximum = new decimal(new int[] { 3, 0, 0, 0 });
            numIncStr.MinimumSize = new System.Drawing.Size(100, 0);
            numIncStr.Name = "numIncStr";
            numIncStr.Size = new System.Drawing.Size(100, 28);
            numIncStr.TabIndex = 22;
            numIncStr.ValueChanged += numIncStr_ValueChanged;
            // 
            // numIncInt
            // 
            numIncInt.Font = new System.Drawing.Font("Segoe UI", 9.25F);
            numIncInt.Location = new System.Drawing.Point(166, 56);
            numIncInt.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            numIncInt.Maximum = new decimal(new int[] { 3, 0, 0, 0 });
            numIncInt.MinimumSize = new System.Drawing.Size(100, 0);
            numIncInt.Name = "numIncInt";
            numIncInt.Size = new System.Drawing.Size(100, 28);
            numIncInt.TabIndex = 21;
            numIncInt.ValueChanged += numIncInt_ValueChanged;
            // 
            // checkIncStr
            // 
            checkIncStr.AutoSize = true;
            checkIncStr.Location = new System.Drawing.Point(22, 92);
            checkIncStr.Margin = new System.Windows.Forms.Padding(0);
            checkIncStr.Name = "checkIncStr";
            checkIncStr.Size = new System.Drawing.Size(114, 24);
            checkIncStr.TabIndex = 20;
            checkIncStr.Text = "Increase STR";
            checkIncStr.UseVisualStyleBackColor = false;
            checkIncStr.CheckedChanged += settings_CheckedChanged;
            // 
            // checkIncInt
            // 
            checkIncInt.AutoSize = true;
            checkIncInt.Location = new System.Drawing.Point(22, 54);
            checkIncInt.Margin = new System.Windows.Forms.Padding(0);
            checkIncInt.Name = "checkIncInt";
            checkIncInt.Size = new System.Drawing.Size(112, 24);
            checkIncInt.TabIndex = 19;
            checkIncInt.Text = "Increase INT";
            checkIncInt.UseVisualStyleBackColor = false;
            checkIncInt.CheckedChanged += settings_CheckedChanged;
            // 
            // Main
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            AutoSize = true;
            Controls.Add(groupStatPoints);
            Controls.Add(groupBackTown);
            Controls.Add(label22);
            Controls.Add(groupBadStatus);
            Controls.Add(groupHPMP);
            Controls.Add(groupPet);
            Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            Name = "Main";
            Padding = new System.Windows.Forms.Padding(5);
            Size = new System.Drawing.Size(970, 621);
            Load += Main_Load;
            groupBackTown.ResumeLayout(false);
            groupBackTown.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numDeadTimeout).EndInit();
            groupBadStatus.ResumeLayout(false);
            groupBadStatus.PerformLayout();
            groupHPMP.ResumeLayout(false);
            groupHPMP.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numPlayerSkillMPMin).EndInit();
            ((System.ComponentModel.ISupportInitialize)numPlayerSkillHPMin).EndInit();
            ((System.ComponentModel.ISupportInitialize)numPlayerMPVigorPotionMin).EndInit();
            ((System.ComponentModel.ISupportInitialize)numPlayerHPVigorPotionMin).EndInit();
            ((System.ComponentModel.ISupportInitialize)numPlayerMPPotionMin).EndInit();
            ((System.ComponentModel.ISupportInitialize)numPlayerHPPotionMin).EndInit();
            groupPet.ResumeLayout(false);
            groupPet.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numPetMinHGP).EndInit();
            ((System.ComponentModel.ISupportInitialize)numPetMinHP).EndInit();
            groupStatPoints.ResumeLayout(false);
            groupStatPoints.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numIncStr).EndInit();
            ((System.ComponentModel.ISupportInitialize)numIncInt).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.GroupBox groupPet;
        private System.Windows.Forms.CheckBox checkUseUniversalPills;
        private System.Windows.Forms.GroupBox groupHPMP;
        private System.Windows.Forms.CheckBox checkUseHPPotionsPlayer;
        private System.Windows.Forms.CheckBox checkUseVigorMP;
        private System.Windows.Forms.CheckBox checkUseMPPotionsPlayer;
        private System.Windows.Forms.CheckBox checkUseVigorHP;
        private System.Windows.Forms.GroupBox groupBadStatus;
        private System.Windows.Forms.CheckBox checkUseSkillHP;
        private System.Windows.Forms.CheckBox checkUseSkillMP;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown numPlayerSkillMPMin;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown numPlayerSkillHPMin;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numPlayerMPVigorPotionMin;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numPlayerHPVigorPotionMin;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numPlayerMPPotionMin;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numPlayerHPPotionMin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkUseBadStatusSkill;
        private System.Windows.Forms.ComboBox comboSkillPlayerMP;
        private System.Windows.Forms.ComboBox comboSkillPlayerHP;
        private System.Windows.Forms.ComboBox comboSkillBadStatus;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.NumericUpDown numPetMinHGP;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.NumericUpDown numPetMinHP;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.CheckBox checkUsePetHP;
        private System.Windows.Forms.CheckBox checkUseHGP;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.CheckBox checkUseAbnormalStatePotion;
        private System.Windows.Forms.CheckBox checkReviveAttackPet;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.NumericUpDown numMountMinHP;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.CheckBox checkUseMountHP;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.CheckBox checkAutoSummonAttackPet;
        private System.Windows.Forms.GroupBox groupBackTown;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.NumericUpDown numDeadTimeout;
        private System.Windows.Forms.CheckBox checkLevelUp;
        private System.Windows.Forms.CheckBox checkFullPetInventory;
        private System.Windows.Forms.CheckBox checkNoMPPotions;
        private System.Windows.Forms.CheckBox checkNoHPPotions;
        private System.Windows.Forms.CheckBox checkDurability;
        private System.Windows.Forms.CheckBox checkDead;
        private System.Windows.Forms.CheckBox checkInventory;
        private System.Windows.Forms.CheckBox checkNoArrows;
        private System.Windows.Forms.GroupBox groupStatPoints;
        private System.Windows.Forms.NumericUpDown numIncStr;
        private System.Windows.Forms.NumericUpDown numIncInt;
        private System.Windows.Forms.CheckBox checkIncStr;
        private System.Windows.Forms.CheckBox checkIncInt;
        private System.Windows.Forms.CheckBox checkIncBotStopped;
        private System.Windows.Forms.Button buttonRun;
        private System.Windows.Forms.CheckBox checkStopBotOnReturnToTown;
        private System.Windows.Forms.Label label17;
    }
}
