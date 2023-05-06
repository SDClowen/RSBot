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
            label22 = new SDUI.Controls.Label();
            groupBackTown = new SDUI.Controls.GroupBox();
            checkStopBotOnReturnToTown = new SDUI.Controls.CheckBox();
            label21 = new SDUI.Controls.Label();
            numDeadTimeout = new SDUI.Controls.NumUpDown();
            checkLevelUp = new SDUI.Controls.CheckBox();
            checkFullPetInventory = new SDUI.Controls.CheckBox();
            checkNoMPPotions = new SDUI.Controls.CheckBox();
            checkNoHPPotions = new SDUI.Controls.CheckBox();
            checkDurability = new SDUI.Controls.CheckBox();
            checkDead = new SDUI.Controls.CheckBox();
            checkInventory = new SDUI.Controls.CheckBox();
            checkNoArrows = new SDUI.Controls.CheckBox();
            groupBadStatus = new SDUI.Controls.GroupBox();
            label18 = new SDUI.Controls.Label();
            comboSkillBadStatus = new SDUI.Controls.ComboBox();
            checkUseBadStatusSkill = new SDUI.Controls.CheckBox();
            checkUseUniversalPills = new SDUI.Controls.CheckBox();
            groupHPMP = new SDUI.Controls.GroupBox();
            label17 = new SDUI.Controls.Label();
            comboSkillPlayerMP = new SDUI.Controls.ComboBox();
            comboSkillPlayerHP = new SDUI.Controls.ComboBox();
            label11 = new SDUI.Controls.Label();
            numPlayerSkillMPMin = new SDUI.Controls.NumUpDown();
            label12 = new SDUI.Controls.Label();
            label9 = new SDUI.Controls.Label();
            numPlayerSkillHPMin = new SDUI.Controls.NumUpDown();
            label10 = new SDUI.Controls.Label();
            label7 = new SDUI.Controls.Label();
            numPlayerMPVigorPotionMin = new SDUI.Controls.NumUpDown();
            label8 = new SDUI.Controls.Label();
            label5 = new SDUI.Controls.Label();
            numPlayerHPVigorPotionMin = new SDUI.Controls.NumUpDown();
            label6 = new SDUI.Controls.Label();
            label3 = new SDUI.Controls.Label();
            numPlayerMPPotionMin = new SDUI.Controls.NumUpDown();
            label4 = new SDUI.Controls.Label();
            label2 = new SDUI.Controls.Label();
            numPlayerHPPotionMin = new SDUI.Controls.NumUpDown();
            label1 = new SDUI.Controls.Label();
            checkUseSkillHP = new SDUI.Controls.CheckBox();
            checkUseSkillMP = new SDUI.Controls.CheckBox();
            checkUseHPPotionsPlayer = new SDUI.Controls.CheckBox();
            checkUseVigorMP = new SDUI.Controls.CheckBox();
            checkUseMPPotionsPlayer = new SDUI.Controls.CheckBox();
            checkUseVigorHP = new SDUI.Controls.CheckBox();
            groupPet = new SDUI.Controls.GroupBox();
            checkAutoSummonAttackPet = new SDUI.Controls.CheckBox();
            checkUseAbnormalStatePotion = new SDUI.Controls.CheckBox();
            checkReviveAttackPet = new SDUI.Controls.CheckBox();
            label13 = new SDUI.Controls.Label();
            numPetMinHGP = new SDUI.Controls.NumUpDown();
            label14 = new SDUI.Controls.Label();
            label15 = new SDUI.Controls.Label();
            numPetMinHP = new SDUI.Controls.NumUpDown();
            label16 = new SDUI.Controls.Label();
            checkUsePetHP = new SDUI.Controls.CheckBox();
            checkUseHGP = new SDUI.Controls.CheckBox();
            groupStatPoints = new SDUI.Controls.GroupBox();
            buttonRun = new SDUI.Controls.Button();
            checkIncBotStopped = new SDUI.Controls.CheckBox();
            numIncStr = new SDUI.Controls.NumUpDown();
            numIncInt = new SDUI.Controls.NumUpDown();
            checkIncStr = new SDUI.Controls.CheckBox();
            checkIncInt = new SDUI.Controls.CheckBox();
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
            label22.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            label22.Location = new System.Drawing.Point(500, 449);
            label22.Name = "label22";
            label22.Size = new System.Drawing.Size(254, 15);
            label22.TabIndex = 16;
            label22.Text = "* Will also be executed, if the bot is not started.";
            // 
            // groupBackTown
            // 
            groupBackTown.BackColor = System.Drawing.Color.Transparent;
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
            groupBackTown.Location = new System.Drawing.Point(500, 7);
            groupBackTown.Name = "groupBackTown";
            groupBackTown.Padding = new System.Windows.Forms.Padding(3, 10, 3, 3);
            groupBackTown.Radius = 10;
            groupBackTown.ShadowDepth = 4;
            groupBackTown.Size = new System.Drawing.Size(238, 227);
            groupBackTown.TabIndex = 17;
            groupBackTown.TabStop = false;
            groupBackTown.Text = "Back to town";
            // 
            // checkStopBotOnReturnToTown
            // 
            checkStopBotOnReturnToTown.AutoSize = true;
            checkStopBotOnReturnToTown.BackColor = System.Drawing.Color.Transparent;
            checkStopBotOnReturnToTown.Location = new System.Drawing.Point(12, 57);
            checkStopBotOnReturnToTown.Name = "checkStopBotOnReturnToTown";
            checkStopBotOnReturnToTown.ShadowDepth = 1;
            checkStopBotOnReturnToTown.Size = new System.Drawing.Size(171, 15);
            checkStopBotOnReturnToTown.TabIndex = 11;
            checkStopBotOnReturnToTown.Text = "Stop bot when back in town";
            checkStopBotOnReturnToTown.UseVisualStyleBackColor = false;
            checkStopBotOnReturnToTown.CheckedChanged += settings_CheckedChanged;
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            label21.Location = new System.Drawing.Point(206, 35);
            label21.Name = "label21";
            label21.Size = new System.Drawing.Size(27, 15);
            label21.TabIndex = 10;
            label21.Text = "sec.";
            // 
            // numDeadTimeout
            // 
            numDeadTimeout.BackColor = System.Drawing.Color.FromArgb(238, 238, 238);
            numDeadTimeout.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            numDeadTimeout.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            numDeadTimeout.InterceptArrowKeys = false;
            numDeadTimeout.Location = new System.Drawing.Point(153, 32);
            numDeadTimeout.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numDeadTimeout.Name = "numDeadTimeout";
            numDeadTimeout.Size = new System.Drawing.Size(47, 23);
            numDeadTimeout.TabIndex = 9;
            numDeadTimeout.Value = new decimal(new int[] { 30, 0, 0, 0 });
            numDeadTimeout.ValueChanged += numSettings_ValueChanged;
            // 
            // checkLevelUp
            // 
            checkLevelUp.AutoSize = true;
            checkLevelUp.BackColor = System.Drawing.Color.Transparent;
            checkLevelUp.Location = new System.Drawing.Point(12, 204);
            checkLevelUp.Name = "checkLevelUp";
            checkLevelUp.ShadowDepth = 1;
            checkLevelUp.Size = new System.Drawing.Size(67, 15);
            checkLevelUp.TabIndex = 8;
            checkLevelUp.Text = "Level up";
            checkLevelUp.UseVisualStyleBackColor = false;
            checkLevelUp.CheckedChanged += settings_CheckedChanged;
            // 
            // checkFullPetInventory
            // 
            checkFullPetInventory.AutoSize = true;
            checkFullPetInventory.BackColor = System.Drawing.Color.Transparent;
            checkFullPetInventory.Location = new System.Drawing.Point(12, 120);
            checkFullPetInventory.Name = "checkFullPetInventory";
            checkFullPetInventory.ShadowDepth = 1;
            checkFullPetInventory.Size = new System.Drawing.Size(115, 15);
            checkFullPetInventory.TabIndex = 7;
            checkFullPetInventory.Text = "Full pet inventory";
            checkFullPetInventory.UseVisualStyleBackColor = false;
            checkFullPetInventory.CheckedChanged += settings_CheckedChanged;
            // 
            // checkNoMPPotions
            // 
            checkNoMPPotions.AutoSize = true;
            checkNoMPPotions.BackColor = System.Drawing.Color.Transparent;
            checkNoMPPotions.Location = new System.Drawing.Point(12, 162);
            checkNoMPPotions.Name = "checkNoMPPotions";
            checkNoMPPotions.ShadowDepth = 1;
            checkNoMPPotions.Size = new System.Drawing.Size(123, 15);
            checkNoMPPotions.TabIndex = 6;
            checkNoMPPotions.Text = "No MP Potions left";
            checkNoMPPotions.UseVisualStyleBackColor = false;
            checkNoMPPotions.CheckedChanged += settings_CheckedChanged;
            // 
            // checkNoHPPotions
            // 
            checkNoHPPotions.AutoSize = true;
            checkNoHPPotions.BackColor = System.Drawing.Color.Transparent;
            checkNoHPPotions.Location = new System.Drawing.Point(12, 141);
            checkNoHPPotions.Name = "checkNoHPPotions";
            checkNoHPPotions.ShadowDepth = 1;
            checkNoHPPotions.Size = new System.Drawing.Size(121, 15);
            checkNoHPPotions.TabIndex = 5;
            checkNoHPPotions.Text = "No HP Potions left";
            checkNoHPPotions.UseVisualStyleBackColor = false;
            checkNoHPPotions.CheckedChanged += settings_CheckedChanged;
            // 
            // checkDurability
            // 
            checkDurability.AutoSize = true;
            checkDurability.BackColor = System.Drawing.Color.Transparent;
            checkDurability.Location = new System.Drawing.Point(12, 183);
            checkDurability.Name = "checkDurability";
            checkDurability.ShadowDepth = 1;
            checkDurability.Size = new System.Drawing.Size(156, 15);
            checkDurability.TabIndex = 4;
            checkDurability.Text = "Equipment durability low";
            checkDurability.UseVisualStyleBackColor = false;
            checkDurability.CheckedChanged += settings_CheckedChanged;
            // 
            // checkDead
            // 
            checkDead.AutoSize = true;
            checkDead.BackColor = System.Drawing.Color.Transparent;
            checkDead.Location = new System.Drawing.Point(12, 36);
            checkDead.Name = "checkDead";
            checkDead.ShadowDepth = 1;
            checkDead.Size = new System.Drawing.Size(124, 15);
            checkDead.TabIndex = 3;
            checkDead.Text = "Dead with delay of ";
            checkDead.UseVisualStyleBackColor = false;
            checkDead.CheckedChanged += settings_CheckedChanged;
            // 
            // checkInventory
            // 
            checkInventory.AutoSize = true;
            checkInventory.BackColor = System.Drawing.Color.Transparent;
            checkInventory.Location = new System.Drawing.Point(12, 99);
            checkInventory.Name = "checkInventory";
            checkInventory.ShadowDepth = 1;
            checkInventory.Size = new System.Drawing.Size(95, 15);
            checkInventory.TabIndex = 4;
            checkInventory.Text = "Full inventory";
            checkInventory.UseVisualStyleBackColor = false;
            checkInventory.CheckedChanged += settings_CheckedChanged;
            // 
            // checkNoArrows
            // 
            checkNoArrows.AutoSize = true;
            checkNoArrows.BackColor = System.Drawing.Color.Transparent;
            checkNoArrows.Location = new System.Drawing.Point(12, 78);
            checkNoArrows.Name = "checkNoArrows";
            checkNoArrows.ShadowDepth = 1;
            checkNoArrows.Size = new System.Drawing.Size(134, 15);
            checkNoArrows.TabIndex = 4;
            checkNoArrows.Text = "No arrows / bolts left";
            checkNoArrows.UseVisualStyleBackColor = false;
            checkNoArrows.CheckedChanged += settings_CheckedChanged;
            // 
            // groupBadStatus
            // 
            groupBadStatus.BackColor = System.Drawing.Color.Transparent;
            groupBadStatus.Controls.Add(label18);
            groupBadStatus.Controls.Add(comboSkillBadStatus);
            groupBadStatus.Controls.Add(checkUseBadStatusSkill);
            groupBadStatus.Controls.Add(checkUseUniversalPills);
            groupBadStatus.Location = new System.Drawing.Point(15, 214);
            groupBadStatus.Name = "groupBadStatus";
            groupBadStatus.Padding = new System.Windows.Forms.Padding(3, 10, 3, 3);
            groupBadStatus.Radius = 10;
            groupBadStatus.ShadowDepth = 4;
            groupBadStatus.Size = new System.Drawing.Size(456, 80);
            groupBadStatus.TabIndex = 6;
            groupBadStatus.TabStop = false;
            groupBadStatus.Text = "Bad status";
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            label18.Location = new System.Drawing.Point(315, 33);
            label18.Name = "label18";
            label18.Size = new System.Drawing.Size(31, 15);
            label18.TabIndex = 27;
            label18.Text = "Skill:";
            // 
            // comboSkillBadStatus
            // 
            comboSkillBadStatus.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            comboSkillBadStatus.DropDownHeight = 100;
            comboSkillBadStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboSkillBadStatus.FormattingEnabled = true;
            comboSkillBadStatus.IntegralHeight = false;
            comboSkillBadStatus.ItemHeight = 17;
            comboSkillBadStatus.Location = new System.Drawing.Point(318, 50);
            comboSkillBadStatus.Name = "comboSkillBadStatus";
            comboSkillBadStatus.Radius = 5;
            comboSkillBadStatus.ShadowDepth = 4F;
            comboSkillBadStatus.Size = new System.Drawing.Size(121, 23);
            comboSkillBadStatus.TabIndex = 26;
            comboSkillBadStatus.SelectedIndexChanged += comboSkill_SelectedIndexChanged;
            // 
            // checkUseBadStatusSkill
            // 
            checkUseBadStatusSkill.AutoSize = true;
            checkUseBadStatusSkill.BackColor = System.Drawing.Color.Transparent;
            checkUseBadStatusSkill.Location = new System.Drawing.Point(11, 58);
            checkUseBadStatusSkill.Name = "checkUseBadStatusSkill";
            checkUseBadStatusSkill.ShadowDepth = 1;
            checkUseBadStatusSkill.Size = new System.Drawing.Size(66, 15);
            checkUseBadStatusSkill.TabIndex = 5;
            checkUseBadStatusSkill.Text = "Use Skill";
            checkUseBadStatusSkill.UseVisualStyleBackColor = false;
            checkUseBadStatusSkill.CheckedChanged += settings_CheckedChanged;
            // 
            // checkUseUniversalPills
            // 
            checkUseUniversalPills.AutoSize = true;
            checkUseUniversalPills.BackColor = System.Drawing.Color.Transparent;
            checkUseUniversalPills.Location = new System.Drawing.Point(11, 35);
            checkUseUniversalPills.Name = "checkUseUniversalPills";
            checkUseUniversalPills.ShadowDepth = 1;
            checkUseUniversalPills.Size = new System.Drawing.Size(125, 15);
            checkUseUniversalPills.TabIndex = 4;
            checkUseUniversalPills.Text = "Use Universal Pills *";
            checkUseUniversalPills.UseVisualStyleBackColor = false;
            checkUseUniversalPills.CheckedChanged += settings_CheckedChanged;
            // 
            // groupHPMP
            // 
            groupHPMP.BackColor = System.Drawing.Color.Transparent;
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
            groupHPMP.Location = new System.Drawing.Point(15, 7);
            groupHPMP.Name = "groupHPMP";
            groupHPMP.Padding = new System.Windows.Forms.Padding(3, 10, 3, 3);
            groupHPMP.Radius = 10;
            groupHPMP.ShadowDepth = 4;
            groupHPMP.Size = new System.Drawing.Size(456, 201);
            groupHPMP.TabIndex = 5;
            groupHPMP.TabStop = false;
            groupHPMP.Text = "Health / Mana recovery";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            label17.Location = new System.Drawing.Point(315, 128);
            label17.Name = "label17";
            label17.Size = new System.Drawing.Size(31, 15);
            label17.TabIndex = 26;
            label17.Text = "Skill:";
            // 
            // comboSkillPlayerMP
            // 
            comboSkillPlayerMP.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            comboSkillPlayerMP.DropDownHeight = 100;
            comboSkillPlayerMP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboSkillPlayerMP.FormattingEnabled = true;
            comboSkillPlayerMP.IntegralHeight = false;
            comboSkillPlayerMP.ItemHeight = 17;
            comboSkillPlayerMP.Location = new System.Drawing.Point(318, 170);
            comboSkillPlayerMP.Name = "comboSkillPlayerMP";
            comboSkillPlayerMP.Radius = 5;
            comboSkillPlayerMP.ShadowDepth = 4F;
            comboSkillPlayerMP.Size = new System.Drawing.Size(121, 23);
            comboSkillPlayerMP.TabIndex = 25;
            comboSkillPlayerMP.SelectedIndexChanged += comboSkill_SelectedIndexChanged;
            // 
            // comboSkillPlayerHP
            // 
            comboSkillPlayerHP.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            comboSkillPlayerHP.DropDownHeight = 100;
            comboSkillPlayerHP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboSkillPlayerHP.FormattingEnabled = true;
            comboSkillPlayerHP.IntegralHeight = false;
            comboSkillPlayerHP.ItemHeight = 17;
            comboSkillPlayerHP.Location = new System.Drawing.Point(318, 144);
            comboSkillPlayerHP.Name = "comboSkillPlayerHP";
            comboSkillPlayerHP.Radius = 5;
            comboSkillPlayerHP.ShadowDepth = 4F;
            comboSkillPlayerHP.Size = new System.Drawing.Size(121, 23);
            comboSkillPlayerHP.TabIndex = 7;
            comboSkillPlayerHP.SelectedIndexChanged += comboSkill_SelectedIndexChanged;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            label11.Location = new System.Drawing.Point(273, 176);
            label11.Name = "label11";
            label11.Size = new System.Drawing.Size(17, 15);
            label11.TabIndex = 24;
            label11.Text = "%";
            // 
            // numPlayerSkillMPMin
            // 
            numPlayerSkillMPMin.BackColor = System.Drawing.Color.FromArgb(238, 238, 238);
            numPlayerSkillMPMin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            numPlayerSkillMPMin.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            numPlayerSkillMPMin.InterceptArrowKeys = false;
            numPlayerSkillMPMin.Location = new System.Drawing.Point(220, 171);
            numPlayerSkillMPMin.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numPlayerSkillMPMin.Name = "numPlayerSkillMPMin";
            numPlayerSkillMPMin.Size = new System.Drawing.Size(47, 23);
            numPlayerSkillMPMin.TabIndex = 23;
            numPlayerSkillMPMin.Value = new decimal(new int[] { 50, 0, 0, 0 });
            numPlayerSkillMPMin.ValueChanged += numSettings_ValueChanged;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            label12.Location = new System.Drawing.Point(201, 173);
            label12.Name = "label12";
            label12.Size = new System.Drawing.Size(15, 15);
            label12.TabIndex = 22;
            label12.Text = "<";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            label9.Location = new System.Drawing.Point(273, 150);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(17, 15);
            label9.TabIndex = 21;
            label9.Text = "%";
            // 
            // numPlayerSkillHPMin
            // 
            numPlayerSkillHPMin.BackColor = System.Drawing.Color.FromArgb(238, 238, 238);
            numPlayerSkillHPMin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            numPlayerSkillHPMin.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            numPlayerSkillHPMin.InterceptArrowKeys = false;
            numPlayerSkillHPMin.Location = new System.Drawing.Point(220, 145);
            numPlayerSkillHPMin.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numPlayerSkillHPMin.Name = "numPlayerSkillHPMin";
            numPlayerSkillHPMin.Size = new System.Drawing.Size(47, 23);
            numPlayerSkillHPMin.TabIndex = 20;
            numPlayerSkillHPMin.Value = new decimal(new int[] { 50, 0, 0, 0 });
            numPlayerSkillHPMin.ValueChanged += numSettings_ValueChanged;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            label10.Location = new System.Drawing.Point(201, 147);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(15, 15);
            label10.TabIndex = 19;
            label10.Text = "<";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            label7.Location = new System.Drawing.Point(273, 122);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(17, 15);
            label7.TabIndex = 18;
            label7.Text = "%";
            // 
            // numPlayerMPVigorPotionMin
            // 
            numPlayerMPVigorPotionMin.BackColor = System.Drawing.Color.FromArgb(238, 238, 238);
            numPlayerMPVigorPotionMin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            numPlayerMPVigorPotionMin.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            numPlayerMPVigorPotionMin.InterceptArrowKeys = false;
            numPlayerMPVigorPotionMin.Location = new System.Drawing.Point(220, 117);
            numPlayerMPVigorPotionMin.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numPlayerMPVigorPotionMin.Name = "numPlayerMPVigorPotionMin";
            numPlayerMPVigorPotionMin.Size = new System.Drawing.Size(47, 23);
            numPlayerMPVigorPotionMin.TabIndex = 17;
            numPlayerMPVigorPotionMin.Value = new decimal(new int[] { 50, 0, 0, 0 });
            numPlayerMPVigorPotionMin.ValueChanged += numSettings_ValueChanged;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            label8.Location = new System.Drawing.Point(199, 121);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(15, 15);
            label8.TabIndex = 16;
            label8.Text = "<";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            label5.Location = new System.Drawing.Point(273, 96);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(17, 15);
            label5.TabIndex = 15;
            label5.Text = "%";
            // 
            // numPlayerHPVigorPotionMin
            // 
            numPlayerHPVigorPotionMin.BackColor = System.Drawing.Color.FromArgb(238, 238, 238);
            numPlayerHPVigorPotionMin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            numPlayerHPVigorPotionMin.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            numPlayerHPVigorPotionMin.InterceptArrowKeys = false;
            numPlayerHPVigorPotionMin.Location = new System.Drawing.Point(220, 91);
            numPlayerHPVigorPotionMin.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numPlayerHPVigorPotionMin.Name = "numPlayerHPVigorPotionMin";
            numPlayerHPVigorPotionMin.Size = new System.Drawing.Size(47, 23);
            numPlayerHPVigorPotionMin.TabIndex = 14;
            numPlayerHPVigorPotionMin.Value = new decimal(new int[] { 50, 0, 0, 0 });
            numPlayerHPVigorPotionMin.ValueChanged += numSettings_ValueChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            label6.Location = new System.Drawing.Point(201, 93);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(15, 15);
            label6.TabIndex = 13;
            label6.Text = "<";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            label3.Location = new System.Drawing.Point(273, 65);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(17, 15);
            label3.TabIndex = 12;
            label3.Text = "%";
            // 
            // numPlayerMPPotionMin
            // 
            numPlayerMPPotionMin.BackColor = System.Drawing.Color.FromArgb(238, 238, 238);
            numPlayerMPPotionMin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            numPlayerMPPotionMin.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            numPlayerMPPotionMin.InterceptArrowKeys = false;
            numPlayerMPPotionMin.Location = new System.Drawing.Point(220, 61);
            numPlayerMPPotionMin.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numPlayerMPPotionMin.Name = "numPlayerMPPotionMin";
            numPlayerMPPotionMin.Size = new System.Drawing.Size(47, 23);
            numPlayerMPPotionMin.TabIndex = 11;
            numPlayerMPPotionMin.Value = new decimal(new int[] { 50, 0, 0, 0 });
            numPlayerMPPotionMin.ValueChanged += numSettings_ValueChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            label4.Location = new System.Drawing.Point(201, 63);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(15, 15);
            label4.TabIndex = 10;
            label4.Text = "<";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            label2.Location = new System.Drawing.Point(273, 39);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(17, 15);
            label2.TabIndex = 9;
            label2.Text = "%";
            // 
            // numPlayerHPPotionMin
            // 
            numPlayerHPPotionMin.BackColor = System.Drawing.Color.FromArgb(238, 238, 238);
            numPlayerHPPotionMin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            numPlayerHPPotionMin.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            numPlayerHPPotionMin.InterceptArrowKeys = false;
            numPlayerHPPotionMin.Location = new System.Drawing.Point(220, 34);
            numPlayerHPPotionMin.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numPlayerHPPotionMin.Name = "numPlayerHPPotionMin";
            numPlayerHPPotionMin.Size = new System.Drawing.Size(47, 23);
            numPlayerHPPotionMin.TabIndex = 8;
            numPlayerHPPotionMin.Value = new decimal(new int[] { 50, 0, 0, 0 });
            numPlayerHPPotionMin.ValueChanged += numSettings_ValueChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            label1.Location = new System.Drawing.Point(201, 36);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(15, 15);
            label1.TabIndex = 7;
            label1.Text = "<";
            // 
            // checkUseSkillHP
            // 
            checkUseSkillHP.AutoSize = true;
            checkUseSkillHP.BackColor = System.Drawing.Color.Transparent;
            checkUseSkillHP.Location = new System.Drawing.Point(11, 146);
            checkUseSkillHP.Name = "checkUseSkillHP";
            checkUseSkillHP.ShadowDepth = 1;
            checkUseSkillHP.Size = new System.Drawing.Size(94, 15);
            checkUseSkillHP.TabIndex = 4;
            checkUseSkillHP.Text = "Use skill if HP";
            checkUseSkillHP.UseVisualStyleBackColor = false;
            checkUseSkillHP.CheckedChanged += settings_CheckedChanged;
            // 
            // checkUseSkillMP
            // 
            checkUseSkillMP.AutoSize = true;
            checkUseSkillMP.BackColor = System.Drawing.Color.Transparent;
            checkUseSkillMP.Location = new System.Drawing.Point(11, 172);
            checkUseSkillMP.Name = "checkUseSkillMP";
            checkUseSkillMP.ShadowDepth = 1;
            checkUseSkillMP.Size = new System.Drawing.Size(96, 15);
            checkUseSkillMP.TabIndex = 5;
            checkUseSkillMP.Text = "Use skill if MP";
            checkUseSkillMP.UseVisualStyleBackColor = false;
            checkUseSkillMP.CheckedChanged += settings_CheckedChanged;
            // 
            // checkUseHPPotionsPlayer
            // 
            checkUseHPPotionsPlayer.AutoSize = true;
            checkUseHPPotionsPlayer.BackColor = System.Drawing.Color.Transparent;
            checkUseHPPotionsPlayer.Location = new System.Drawing.Point(11, 36);
            checkUseHPPotionsPlayer.Name = "checkUseHPPotionsPlayer";
            checkUseHPPotionsPlayer.ShadowDepth = 1;
            checkUseHPPotionsPlayer.Size = new System.Drawing.Size(141, 15);
            checkUseHPPotionsPlayer.TabIndex = 0;
            checkUseHPPotionsPlayer.Text = "Use HP potions if HP *";
            checkUseHPPotionsPlayer.UseVisualStyleBackColor = false;
            checkUseHPPotionsPlayer.CheckedChanged += settings_CheckedChanged;
            // 
            // checkUseVigorMP
            // 
            checkUseVigorMP.AutoSize = true;
            checkUseVigorMP.BackColor = System.Drawing.Color.Transparent;
            checkUseVigorMP.Location = new System.Drawing.Point(11, 118);
            checkUseVigorMP.Name = "checkUseVigorMP";
            checkUseVigorMP.ShadowDepth = 1;
            checkUseVigorMP.Size = new System.Drawing.Size(147, 15);
            checkUseVigorMP.TabIndex = 3;
            checkUseVigorMP.Text = "Use Vigor Potions if MP";
            checkUseVigorMP.UseVisualStyleBackColor = false;
            checkUseVigorMP.CheckedChanged += settings_CheckedChanged;
            // 
            // checkUseMPPotionsPlayer
            // 
            checkUseMPPotionsPlayer.AutoSize = true;
            checkUseMPPotionsPlayer.BackColor = System.Drawing.Color.Transparent;
            checkUseMPPotionsPlayer.Location = new System.Drawing.Point(11, 62);
            checkUseMPPotionsPlayer.Name = "checkUseMPPotionsPlayer";
            checkUseMPPotionsPlayer.ShadowDepth = 1;
            checkUseMPPotionsPlayer.Size = new System.Drawing.Size(145, 15);
            checkUseMPPotionsPlayer.TabIndex = 1;
            checkUseMPPotionsPlayer.Text = "Use MP potions if MP *";
            checkUseMPPotionsPlayer.UseVisualStyleBackColor = false;
            checkUseMPPotionsPlayer.CheckedChanged += settings_CheckedChanged;
            // 
            // checkUseVigorHP
            // 
            checkUseVigorHP.AutoSize = true;
            checkUseVigorHP.BackColor = System.Drawing.Color.Transparent;
            checkUseVigorHP.Location = new System.Drawing.Point(11, 92);
            checkUseVigorHP.Name = "checkUseVigorHP";
            checkUseVigorHP.ShadowDepth = 1;
            checkUseVigorHP.Size = new System.Drawing.Size(145, 15);
            checkUseVigorHP.TabIndex = 2;
            checkUseVigorHP.Text = "Use Vigor Potions if HP";
            checkUseVigorHP.UseVisualStyleBackColor = false;
            checkUseVigorHP.CheckedChanged += settings_CheckedChanged;
            // 
            // groupPet
            // 
            groupPet.BackColor = System.Drawing.Color.Transparent;
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
            groupPet.Location = new System.Drawing.Point(15, 300);
            groupPet.Name = "groupPet";
            groupPet.Padding = new System.Windows.Forms.Padding(3, 10, 3, 3);
            groupPet.Radius = 10;
            groupPet.ShadowDepth = 4;
            groupPet.Size = new System.Drawing.Size(456, 164);
            groupPet.TabIndex = 1;
            groupPet.TabStop = false;
            groupPet.Text = "Recovery - Pet";
            // 
            // checkAutoSummonAttackPet
            // 
            checkAutoSummonAttackPet.AutoSize = true;
            checkAutoSummonAttackPet.BackColor = System.Drawing.Color.Transparent;
            checkAutoSummonAttackPet.Location = new System.Drawing.Point(11, 137);
            checkAutoSummonAttackPet.Name = "checkAutoSummonAttackPet";
            checkAutoSummonAttackPet.ShadowDepth = 1;
            checkAutoSummonAttackPet.Size = new System.Drawing.Size(209, 15);
            checkAutoSummonAttackPet.TabIndex = 27;
            checkAutoSummonAttackPet.Text = "Auto summon growth && fellow pet";
            checkAutoSummonAttackPet.UseVisualStyleBackColor = false;
            checkAutoSummonAttackPet.CheckedChanged += settings_CheckedChanged;
            // 
            // checkUseAbnormalStatePotion
            // 
            checkUseAbnormalStatePotion.AutoSize = true;
            checkUseAbnormalStatePotion.BackColor = System.Drawing.Color.Transparent;
            checkUseAbnormalStatePotion.Location = new System.Drawing.Point(11, 88);
            checkUseAbnormalStatePotion.Name = "checkUseAbnormalStatePotion";
            checkUseAbnormalStatePotion.ShadowDepth = 1;
            checkUseAbnormalStatePotion.Size = new System.Drawing.Size(223, 15);
            checkUseAbnormalStatePotion.TabIndex = 26;
            checkUseAbnormalStatePotion.Text = "Use abnormal state recovery potions *";
            checkUseAbnormalStatePotion.UseVisualStyleBackColor = false;
            checkUseAbnormalStatePotion.CheckedChanged += settings_CheckedChanged;
            // 
            // checkReviveAttackPet
            // 
            checkReviveAttackPet.AutoSize = true;
            checkReviveAttackPet.BackColor = System.Drawing.Color.Transparent;
            checkReviveAttackPet.Location = new System.Drawing.Point(11, 113);
            checkReviveAttackPet.Name = "checkReviveAttackPet";
            checkReviveAttackPet.ShadowDepth = 1;
            checkReviveAttackPet.Size = new System.Drawing.Size(166, 15);
            checkReviveAttackPet.TabIndex = 25;
            checkReviveAttackPet.Text = "Revive growth && fellow pet";
            checkReviveAttackPet.UseVisualStyleBackColor = false;
            checkReviveAttackPet.CheckedChanged += settings_CheckedChanged;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            label13.Location = new System.Drawing.Point(302, 65);
            label13.Name = "label13";
            label13.Size = new System.Drawing.Size(17, 15);
            label13.TabIndex = 20;
            label13.Text = "%";
            // 
            // numPetMinHGP
            // 
            numPetMinHGP.BackColor = System.Drawing.Color.FromArgb(238, 238, 238);
            numPetMinHGP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            numPetMinHGP.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            numPetMinHGP.InterceptArrowKeys = false;
            numPetMinHGP.Location = new System.Drawing.Point(249, 62);
            numPetMinHGP.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numPetMinHGP.Name = "numPetMinHGP";
            numPetMinHGP.Size = new System.Drawing.Size(47, 23);
            numPetMinHGP.TabIndex = 19;
            numPetMinHGP.Value = new decimal(new int[] { 50, 0, 0, 0 });
            numPetMinHGP.ValueChanged += numSettings_ValueChanged;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            label14.Location = new System.Drawing.Point(230, 64);
            label14.Name = "label14";
            label14.Size = new System.Drawing.Size(15, 15);
            label14.TabIndex = 18;
            label14.Text = "<";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            label15.Location = new System.Drawing.Point(302, 38);
            label15.Name = "label15";
            label15.Size = new System.Drawing.Size(17, 15);
            label15.TabIndex = 17;
            label15.Text = "%";
            // 
            // numPetMinHP
            // 
            numPetMinHP.BackColor = System.Drawing.Color.FromArgb(238, 238, 238);
            numPetMinHP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            numPetMinHP.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            numPetMinHP.InterceptArrowKeys = false;
            numPetMinHP.Location = new System.Drawing.Point(249, 35);
            numPetMinHP.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numPetMinHP.Name = "numPetMinHP";
            numPetMinHP.Size = new System.Drawing.Size(47, 23);
            numPetMinHP.TabIndex = 16;
            numPetMinHP.Value = new decimal(new int[] { 50, 0, 0, 0 });
            numPetMinHP.ValueChanged += numSettings_ValueChanged;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            label16.Location = new System.Drawing.Point(230, 37);
            label16.Name = "label16";
            label16.Size = new System.Drawing.Size(15, 15);
            label16.TabIndex = 15;
            label16.Text = "<";
            // 
            // checkUsePetHP
            // 
            checkUsePetHP.AutoSize = true;
            checkUsePetHP.BackColor = System.Drawing.Color.Transparent;
            checkUsePetHP.Location = new System.Drawing.Point(11, 37);
            checkUsePetHP.Name = "checkUsePetHP";
            checkUsePetHP.ShadowDepth = 1;
            checkUsePetHP.Size = new System.Drawing.Size(141, 15);
            checkUsePetHP.TabIndex = 13;
            checkUsePetHP.Text = "Use HP potions if HP *";
            checkUsePetHP.UseVisualStyleBackColor = false;
            checkUsePetHP.CheckedChanged += settings_CheckedChanged;
            // 
            // checkUseHGP
            // 
            checkUseHGP.AutoSize = true;
            checkUseHGP.BackColor = System.Drawing.Color.Transparent;
            checkUseHGP.Location = new System.Drawing.Point(11, 63);
            checkUseHGP.Name = "checkUseHGP";
            checkUseHGP.ShadowDepth = 1;
            checkUseHGP.Size = new System.Drawing.Size(218, 15);
            checkUseHGP.TabIndex = 14;
            checkUseHGP.Text = "Use HGP && Saiety potions if hunger *";
            checkUseHGP.UseVisualStyleBackColor = false;
            checkUseHGP.CheckedChanged += settings_CheckedChanged;
            // 
            // groupStatPoints
            // 
            groupStatPoints.BackColor = System.Drawing.Color.Transparent;
            groupStatPoints.Controls.Add(buttonRun);
            groupStatPoints.Controls.Add(checkIncBotStopped);
            groupStatPoints.Controls.Add(numIncStr);
            groupStatPoints.Controls.Add(numIncInt);
            groupStatPoints.Controls.Add(checkIncStr);
            groupStatPoints.Controls.Add(checkIncInt);
            groupStatPoints.Location = new System.Drawing.Point(500, 240);
            groupStatPoints.Name = "groupStatPoints";
            groupStatPoints.Padding = new System.Windows.Forms.Padding(3, 10, 3, 3);
            groupStatPoints.Radius = 10;
            groupStatPoints.ShadowDepth = 4;
            groupStatPoints.Size = new System.Drawing.Size(238, 162);
            groupStatPoints.TabIndex = 18;
            groupStatPoints.TabStop = false;
            groupStatPoints.Text = "Stat points";
            // 
            // buttonRun
            // 
            buttonRun.Color = System.Drawing.Color.Transparent;
            buttonRun.Location = new System.Drawing.Point(62, 133);
            buttonRun.Name = "buttonRun";
            buttonRun.Radius = 6;
            buttonRun.ShadowDepth = 4F;
            buttonRun.Size = new System.Drawing.Size(97, 23);
            buttonRun.TabIndex = 27;
            buttonRun.Text = "Run";
            buttonRun.UseVisualStyleBackColor = true;
            buttonRun.Click += buttonRun_Click;
            // 
            // checkIncBotStopped
            // 
            checkIncBotStopped.AutoSize = true;
            checkIncBotStopped.BackColor = System.Drawing.Color.Transparent;
            checkIncBotStopped.Location = new System.Drawing.Point(18, 106);
            checkIncBotStopped.Name = "checkIncBotStopped";
            checkIncBotStopped.ShadowDepth = 1;
            checkIncBotStopped.Size = new System.Drawing.Size(153, 15);
            checkIncBotStopped.TabIndex = 24;
            checkIncBotStopped.Text = "Enabled if bot is stopped";
            checkIncBotStopped.UseVisualStyleBackColor = false;
            checkIncBotStopped.CheckedChanged += settings_CheckedChanged;
            // 
            // numIncStr
            // 
            numIncStr.BackColor = System.Drawing.Color.FromArgb(238, 238, 238);
            numIncStr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            numIncStr.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            numIncStr.InterceptArrowKeys = false;
            numIncStr.Location = new System.Drawing.Point(121, 71);
            numIncStr.Maximum = new decimal(new int[] { 3, 0, 0, 0 });
            numIncStr.Name = "numIncStr";
            numIncStr.Size = new System.Drawing.Size(47, 23);
            numIncStr.TabIndex = 22;
            numIncStr.ValueChanged += numIncStr_ValueChanged;
            // 
            // numIncInt
            // 
            numIncInt.BackColor = System.Drawing.Color.FromArgb(238, 238, 238);
            numIncInt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            numIncInt.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            numIncInt.InterceptArrowKeys = false;
            numIncInt.Location = new System.Drawing.Point(121, 44);
            numIncInt.Maximum = new decimal(new int[] { 3, 0, 0, 0 });
            numIncInt.Name = "numIncInt";
            numIncInt.Size = new System.Drawing.Size(47, 23);
            numIncInt.TabIndex = 21;
            numIncInt.ValueChanged += numIncInt_ValueChanged;
            // 
            // checkIncStr
            // 
            checkIncStr.AutoSize = true;
            checkIncStr.BackColor = System.Drawing.Color.Transparent;
            checkIncStr.Location = new System.Drawing.Point(18, 75);
            checkIncStr.Name = "checkIncStr";
            checkIncStr.ShadowDepth = 1;
            checkIncStr.Size = new System.Drawing.Size(88, 15);
            checkIncStr.TabIndex = 20;
            checkIncStr.Text = "Increase STR";
            checkIncStr.UseVisualStyleBackColor = false;
            checkIncStr.CheckedChanged += settings_CheckedChanged;
            // 
            // checkIncInt
            // 
            checkIncInt.AutoSize = true;
            checkIncInt.BackColor = System.Drawing.Color.Transparent;
            checkIncInt.Location = new System.Drawing.Point(18, 46);
            checkIncInt.Name = "checkIncInt";
            checkIncInt.ShadowDepth = 1;
            checkIncInt.Size = new System.Drawing.Size(87, 15);
            checkIncInt.TabIndex = 19;
            checkIncInt.Text = "Increase INT";
            checkIncInt.UseVisualStyleBackColor = false;
            checkIncInt.CheckedChanged += settings_CheckedChanged;
            // 
            // Main
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            Controls.Add(groupStatPoints);
            Controls.Add(groupBackTown);
            Controls.Add(label22);
            Controls.Add(groupBadStatus);
            Controls.Add(groupHPMP);
            Controls.Add(groupPet);
            Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            Name = "Main";
            Size = new System.Drawing.Size(776, 479);
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
        private SDUI.Controls.GroupBox groupPet;
        private SDUI.Controls.CheckBox checkUseUniversalPills;
        private SDUI.Controls.GroupBox groupHPMP;
        private SDUI.Controls.CheckBox checkUseHPPotionsPlayer;
        private SDUI.Controls.CheckBox checkUseVigorMP;
        private SDUI.Controls.CheckBox checkUseMPPotionsPlayer;
        private SDUI.Controls.CheckBox checkUseVigorHP;
        private SDUI.Controls.GroupBox groupBadStatus;
        private SDUI.Controls.CheckBox checkUseSkillHP;
        private SDUI.Controls.CheckBox checkUseSkillMP;
        private SDUI.Controls.Label label11;
        private SDUI.Controls.NumUpDown numPlayerSkillMPMin;
        private SDUI.Controls.Label label12;
        private SDUI.Controls.Label label9;
        private SDUI.Controls.NumUpDown numPlayerSkillHPMin;
        private SDUI.Controls.Label label10;
        private SDUI.Controls.Label label7;
        private SDUI.Controls.NumUpDown numPlayerMPVigorPotionMin;
        private SDUI.Controls.Label label8;
        private SDUI.Controls.Label label5;
        private SDUI.Controls.NumUpDown numPlayerHPVigorPotionMin;
        private SDUI.Controls.Label label6;
        private SDUI.Controls.Label label3;
        private SDUI.Controls.NumUpDown numPlayerMPPotionMin;
        private SDUI.Controls.Label label4;
        private SDUI.Controls.Label label2;
        private SDUI.Controls.NumUpDown numPlayerHPPotionMin;
        private SDUI.Controls.Label label1;
        private SDUI.Controls.CheckBox checkUseBadStatusSkill;
        private SDUI.Controls.ComboBox comboSkillPlayerMP;
        private SDUI.Controls.ComboBox comboSkillPlayerHP;
        private SDUI.Controls.ComboBox comboSkillBadStatus;
        private SDUI.Controls.Label label13;
        private SDUI.Controls.NumUpDown numPetMinHGP;
        private SDUI.Controls.Label label14;
        private SDUI.Controls.Label label15;
        private SDUI.Controls.NumUpDown numPetMinHP;
        private SDUI.Controls.Label label16;
        private SDUI.Controls.CheckBox checkUsePetHP;
        private SDUI.Controls.CheckBox checkUseHGP;
        private SDUI.Controls.Label label17;
        private SDUI.Controls.Label label18;
        private SDUI.Controls.CheckBox checkUseAbnormalStatePotion;
        private SDUI.Controls.CheckBox checkReviveAttackPet;
        private SDUI.Controls.Label label19;
        private SDUI.Controls.NumUpDown numMountMinHP;
        private SDUI.Controls.Label label20;
        private SDUI.Controls.CheckBox checkUseMountHP;
        private SDUI.Controls.Label label22;
        private SDUI.Controls.CheckBox checkAutoSummonAttackPet;
        private SDUI.Controls.GroupBox groupBackTown;
        private SDUI.Controls.Label label21;
        private SDUI.Controls.NumUpDown numDeadTimeout;
        private SDUI.Controls.CheckBox checkLevelUp;
        private SDUI.Controls.CheckBox checkFullPetInventory;
        private SDUI.Controls.CheckBox checkNoMPPotions;
        private SDUI.Controls.CheckBox checkNoHPPotions;
        private SDUI.Controls.CheckBox checkDurability;
        private SDUI.Controls.CheckBox checkDead;
        private SDUI.Controls.CheckBox checkInventory;
        private SDUI.Controls.CheckBox checkNoArrows;
        private SDUI.Controls.GroupBox groupStatPoints;
        private SDUI.Controls.NumUpDown numIncStr;
        private SDUI.Controls.NumUpDown numIncInt;
        private SDUI.Controls.CheckBox checkIncStr;
        private SDUI.Controls.CheckBox checkIncInt;
        private SDUI.Controls.CheckBox checkIncBotStopped;
        private SDUI.Controls.Button buttonRun;
        private SDUI.Controls.CheckBox checkStopBotOnReturnToTown;
    }
}
