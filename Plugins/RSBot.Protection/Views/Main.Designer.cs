﻿namespace RSBot.Protection.Views
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
            label17 = new SDUI.Controls.Label();
            groupBackTown.SuspendLayout();
            groupBadStatus.SuspendLayout();
            groupHPMP.SuspendLayout();
            groupPet.SuspendLayout();
            groupStatPoints.SuspendLayout();
            SuspendLayout();
            // 
            // label22
            // 
            label22.ApplyGradient = false;
            label22.AutoSize = true;
            label22.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            label22.Gradient = (new System.Drawing.Color[] { System.Drawing.Color.Gray, System.Drawing.Color.Black });
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
            groupBackTown.Size = new System.Drawing.Size(254, 266);
            groupBackTown.TabIndex = 17;
            groupBackTown.TabStop = false;
            groupBackTown.Text = "Back to town";
            // 
            // checkStopBotOnReturnToTown
            // 
            checkStopBotOnReturnToTown.AutoSize = true;
            checkStopBotOnReturnToTown.BackColor = System.Drawing.Color.Transparent;
            checkStopBotOnReturnToTown.Depth = 0;
            checkStopBotOnReturnToTown.Location = new System.Drawing.Point(12, 63);
            checkStopBotOnReturnToTown.Margin = new System.Windows.Forms.Padding(0);
            checkStopBotOnReturnToTown.MouseLocation = new System.Drawing.Point(-1, -1);
            checkStopBotOnReturnToTown.Name = "checkStopBotOnReturnToTown";
            checkStopBotOnReturnToTown.Ripple = true;
            checkStopBotOnReturnToTown.Size = new System.Drawing.Size(183, 30);
            checkStopBotOnReturnToTown.TabIndex = 11;
            checkStopBotOnReturnToTown.Text = "Stop bot when back in town";
            checkStopBotOnReturnToTown.UseVisualStyleBackColor = false;
            checkStopBotOnReturnToTown.CheckedChanged += settings_CheckedChanged;
            // 
            // label21
            // 
            label21.ApplyGradient = false;
            label21.AutoSize = true;
            label21.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            label21.Gradient = (new System.Drawing.Color[] { System.Drawing.Color.Gray, System.Drawing.Color.Black });
            label21.Location = new System.Drawing.Point(235, 41);
            label21.Name = "label21";
            label21.Size = new System.Drawing.Size(17, 15);
            label21.TabIndex = 10;
            label21.Text = "/s";
            // 
            // numDeadTimeout
            // 
            numDeadTimeout.BackColor = System.Drawing.Color.FromArgb(238, 238, 238);
            numDeadTimeout.Font = new System.Drawing.Font("Segoe UI", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            numDeadTimeout.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            numDeadTimeout.Location = new System.Drawing.Point(153, 37);
            numDeadTimeout.Maximum = new decimal(new int[] { 100, 0, 0, 0 });
            numDeadTimeout.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numDeadTimeout.MinimumSize = new System.Drawing.Size(80, 25);
            numDeadTimeout.Name = "numDeadTimeout";
            numDeadTimeout.Size = new System.Drawing.Size(80, 25);
            numDeadTimeout.TabIndex = 9;
            numDeadTimeout.Value = new decimal(new int[] { 30, 0, 0, 0 });
            numDeadTimeout.ValueChanged += numSettings_ValueChanged;
            // 
            // checkLevelUp
            // 
            checkLevelUp.AutoSize = true;
            checkLevelUp.BackColor = System.Drawing.Color.Transparent;
            checkLevelUp.Depth = 0;
            checkLevelUp.Location = new System.Drawing.Point(12, 231);
            checkLevelUp.Margin = new System.Windows.Forms.Padding(0);
            checkLevelUp.MouseLocation = new System.Drawing.Point(-1, -1);
            checkLevelUp.Name = "checkLevelUp";
            checkLevelUp.Ripple = true;
            checkLevelUp.Size = new System.Drawing.Size(75, 30);
            checkLevelUp.TabIndex = 8;
            checkLevelUp.Text = "Level up";
            checkLevelUp.UseVisualStyleBackColor = false;
            checkLevelUp.CheckedChanged += settings_CheckedChanged;
            // 
            // checkFullPetInventory
            // 
            checkFullPetInventory.AutoSize = true;
            checkFullPetInventory.BackColor = System.Drawing.Color.Transparent;
            checkFullPetInventory.Depth = 0;
            checkFullPetInventory.Location = new System.Drawing.Point(12, 135);
            checkFullPetInventory.Margin = new System.Windows.Forms.Padding(0);
            checkFullPetInventory.MouseLocation = new System.Drawing.Point(-1, -1);
            checkFullPetInventory.Name = "checkFullPetInventory";
            checkFullPetInventory.Ripple = true;
            checkFullPetInventory.Size = new System.Drawing.Size(124, 30);
            checkFullPetInventory.TabIndex = 7;
            checkFullPetInventory.Text = "Full pet inventory";
            checkFullPetInventory.UseVisualStyleBackColor = false;
            checkFullPetInventory.CheckedChanged += settings_CheckedChanged;
            // 
            // checkNoMPPotions
            // 
            checkNoMPPotions.AutoSize = true;
            checkNoMPPotions.BackColor = System.Drawing.Color.Transparent;
            checkNoMPPotions.Depth = 0;
            checkNoMPPotions.Location = new System.Drawing.Point(12, 183);
            checkNoMPPotions.Margin = new System.Windows.Forms.Padding(0);
            checkNoMPPotions.MouseLocation = new System.Drawing.Point(-1, -1);
            checkNoMPPotions.Name = "checkNoMPPotions";
            checkNoMPPotions.Ripple = true;
            checkNoMPPotions.Size = new System.Drawing.Size(133, 30);
            checkNoMPPotions.TabIndex = 6;
            checkNoMPPotions.Text = "No MP Potions left";
            checkNoMPPotions.UseVisualStyleBackColor = false;
            checkNoMPPotions.CheckedChanged += settings_CheckedChanged;
            // 
            // checkNoHPPotions
            // 
            checkNoHPPotions.AutoSize = true;
            checkNoHPPotions.BackColor = System.Drawing.Color.Transparent;
            checkNoHPPotions.Depth = 0;
            checkNoHPPotions.Location = new System.Drawing.Point(12, 159);
            checkNoHPPotions.Margin = new System.Windows.Forms.Padding(0);
            checkNoHPPotions.MouseLocation = new System.Drawing.Point(-1, -1);
            checkNoHPPotions.Name = "checkNoHPPotions";
            checkNoHPPotions.Ripple = true;
            checkNoHPPotions.Size = new System.Drawing.Size(130, 30);
            checkNoHPPotions.TabIndex = 5;
            checkNoHPPotions.Text = "No HP Potions left";
            checkNoHPPotions.UseVisualStyleBackColor = false;
            checkNoHPPotions.CheckedChanged += settings_CheckedChanged;
            // 
            // checkDurability
            // 
            checkDurability.AutoSize = true;
            checkDurability.BackColor = System.Drawing.Color.Transparent;
            checkDurability.Depth = 0;
            checkDurability.Location = new System.Drawing.Point(12, 207);
            checkDurability.Margin = new System.Windows.Forms.Padding(0);
            checkDurability.MouseLocation = new System.Drawing.Point(-1, -1);
            checkDurability.Name = "checkDurability";
            checkDurability.Ripple = true;
            checkDurability.Size = new System.Drawing.Size(166, 30);
            checkDurability.TabIndex = 4;
            checkDurability.Text = "Equipment durability low";
            checkDurability.UseVisualStyleBackColor = false;
            checkDurability.CheckedChanged += settings_CheckedChanged;
            // 
            // checkDead
            // 
            checkDead.AutoSize = true;
            checkDead.BackColor = System.Drawing.Color.Transparent;
            checkDead.Depth = 0;
            checkDead.Location = new System.Drawing.Point(12, 36);
            checkDead.Margin = new System.Windows.Forms.Padding(0);
            checkDead.MouseLocation = new System.Drawing.Point(-1, -1);
            checkDead.Name = "checkDead";
            checkDead.Ripple = true;
            checkDead.Size = new System.Drawing.Size(132, 30);
            checkDead.TabIndex = 3;
            checkDead.Text = "Dead with delay of ";
            checkDead.UseVisualStyleBackColor = false;
            checkDead.CheckedChanged += settings_CheckedChanged;
            // 
            // checkInventory
            // 
            checkInventory.AutoSize = true;
            checkInventory.BackColor = System.Drawing.Color.Transparent;
            checkInventory.Depth = 0;
            checkInventory.Location = new System.Drawing.Point(12, 111);
            checkInventory.Margin = new System.Windows.Forms.Padding(0);
            checkInventory.MouseLocation = new System.Drawing.Point(-1, -1);
            checkInventory.Name = "checkInventory";
            checkInventory.Ripple = true;
            checkInventory.Size = new System.Drawing.Size(103, 30);
            checkInventory.TabIndex = 4;
            checkInventory.Text = "Full inventory";
            checkInventory.UseVisualStyleBackColor = false;
            checkInventory.CheckedChanged += settings_CheckedChanged;
            // 
            // checkNoArrows
            // 
            checkNoArrows.AutoSize = true;
            checkNoArrows.BackColor = System.Drawing.Color.Transparent;
            checkNoArrows.Depth = 0;
            checkNoArrows.Location = new System.Drawing.Point(12, 87);
            checkNoArrows.Margin = new System.Windows.Forms.Padding(0);
            checkNoArrows.MouseLocation = new System.Drawing.Point(-1, -1);
            checkNoArrows.Name = "checkNoArrows";
            checkNoArrows.Ripple = true;
            checkNoArrows.Size = new System.Drawing.Size(145, 30);
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
            groupBadStatus.Location = new System.Drawing.Point(15, 226);
            groupBadStatus.Name = "groupBadStatus";
            groupBadStatus.Padding = new System.Windows.Forms.Padding(3, 10, 3, 3);
            groupBadStatus.Radius = 10;
            groupBadStatus.ShadowDepth = 4;
            groupBadStatus.Size = new System.Drawing.Size(468, 93);
            groupBadStatus.TabIndex = 6;
            groupBadStatus.TabStop = false;
            groupBadStatus.Text = "Bad status";
            // 
            // label18
            // 
            label18.ApplyGradient = false;
            label18.AutoSize = true;
            label18.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            label18.Gradient = (new System.Drawing.Color[] { System.Drawing.Color.Gray, System.Drawing.Color.Black });
            label18.Location = new System.Drawing.Point(316, 42);
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
            comboSkillBadStatus.Location = new System.Drawing.Point(318, 59);
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
            checkUseBadStatusSkill.Depth = 0;
            checkUseBadStatusSkill.Location = new System.Drawing.Point(11, 56);
            checkUseBadStatusSkill.Margin = new System.Windows.Forms.Padding(0);
            checkUseBadStatusSkill.MouseLocation = new System.Drawing.Point(-1, -1);
            checkUseBadStatusSkill.Name = "checkUseBadStatusSkill";
            checkUseBadStatusSkill.Ripple = true;
            checkUseBadStatusSkill.Size = new System.Drawing.Size(75, 30);
            checkUseBadStatusSkill.TabIndex = 5;
            checkUseBadStatusSkill.Text = "Use Skill";
            checkUseBadStatusSkill.UseVisualStyleBackColor = false;
            checkUseBadStatusSkill.CheckedChanged += settings_CheckedChanged;
            // 
            // checkUseUniversalPills
            // 
            checkUseUniversalPills.AutoSize = true;
            checkUseUniversalPills.BackColor = System.Drawing.Color.Transparent;
            checkUseUniversalPills.Depth = 0;
            checkUseUniversalPills.Location = new System.Drawing.Point(11, 29);
            checkUseUniversalPills.Margin = new System.Windows.Forms.Padding(0);
            checkUseUniversalPills.MouseLocation = new System.Drawing.Point(-1, -1);
            checkUseUniversalPills.Name = "checkUseUniversalPills";
            checkUseUniversalPills.Ripple = true;
            checkUseUniversalPills.Size = new System.Drawing.Size(136, 30);
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
            groupHPMP.Size = new System.Drawing.Size(468, 213);
            groupHPMP.TabIndex = 5;
            groupHPMP.TabStop = false;
            groupHPMP.Text = "Health / Mana recovery";
            // 
            // comboSkillPlayerMP
            // 
            comboSkillPlayerMP.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            comboSkillPlayerMP.DropDownHeight = 100;
            comboSkillPlayerMP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboSkillPlayerMP.FormattingEnabled = true;
            comboSkillPlayerMP.IntegralHeight = false;
            comboSkillPlayerMP.ItemHeight = 17;
            comboSkillPlayerMP.Location = new System.Drawing.Point(332, 179);
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
            comboSkillPlayerHP.Location = new System.Drawing.Point(332, 152);
            comboSkillPlayerHP.Name = "comboSkillPlayerHP";
            comboSkillPlayerHP.Radius = 5;
            comboSkillPlayerHP.ShadowDepth = 4F;
            comboSkillPlayerHP.Size = new System.Drawing.Size(121, 23);
            comboSkillPlayerHP.TabIndex = 7;
            comboSkillPlayerHP.SelectedIndexChanged += comboSkill_SelectedIndexChanged;
            // 
            // label11
            // 
            label11.ApplyGradient = false;
            label11.AutoSize = true;
            label11.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            label11.Gradient = (new System.Drawing.Color[] { System.Drawing.Color.Gray, System.Drawing.Color.Black });
            label11.Location = new System.Drawing.Point(301, 183);
            label11.Name = "label11";
            label11.Size = new System.Drawing.Size(17, 15);
            label11.TabIndex = 24;
            label11.Text = "%";
            // 
            // numPlayerSkillMPMin
            // 
            numPlayerSkillMPMin.BackColor = System.Drawing.Color.FromArgb(238, 238, 238);
            numPlayerSkillMPMin.Font = new System.Drawing.Font("Segoe UI", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            numPlayerSkillMPMin.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            numPlayerSkillMPMin.Location = new System.Drawing.Point(220, 179);
            numPlayerSkillMPMin.Maximum = new decimal(new int[] { 100, 0, 0, 0 });
            numPlayerSkillMPMin.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numPlayerSkillMPMin.MinimumSize = new System.Drawing.Size(80, 25);
            numPlayerSkillMPMin.Name = "numPlayerSkillMPMin";
            numPlayerSkillMPMin.Size = new System.Drawing.Size(80, 25);
            numPlayerSkillMPMin.TabIndex = 23;
            numPlayerSkillMPMin.Value = new decimal(new int[] { 50, 0, 0, 0 });
            numPlayerSkillMPMin.ValueChanged += numSettings_ValueChanged;
            // 
            // label12
            // 
            label12.ApplyGradient = false;
            label12.AutoSize = true;
            label12.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            label12.Gradient = (new System.Drawing.Color[] { System.Drawing.Color.Gray, System.Drawing.Color.Black });
            label12.Location = new System.Drawing.Point(201, 182);
            label12.Name = "label12";
            label12.Size = new System.Drawing.Size(15, 15);
            label12.TabIndex = 22;
            label12.Text = "<";
            // 
            // label9
            // 
            label9.ApplyGradient = false;
            label9.AutoSize = true;
            label9.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            label9.Gradient = (new System.Drawing.Color[] { System.Drawing.Color.Gray, System.Drawing.Color.Black });
            label9.Location = new System.Drawing.Point(302, 156);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(17, 15);
            label9.TabIndex = 21;
            label9.Text = "%";
            // 
            // numPlayerSkillHPMin
            // 
            numPlayerSkillHPMin.BackColor = System.Drawing.Color.FromArgb(238, 238, 238);
            numPlayerSkillHPMin.Font = new System.Drawing.Font("Segoe UI", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            numPlayerSkillHPMin.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            numPlayerSkillHPMin.Location = new System.Drawing.Point(220, 152);
            numPlayerSkillHPMin.Maximum = new decimal(new int[] { 100, 0, 0, 0 });
            numPlayerSkillHPMin.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numPlayerSkillHPMin.MinimumSize = new System.Drawing.Size(80, 25);
            numPlayerSkillHPMin.Name = "numPlayerSkillHPMin";
            numPlayerSkillHPMin.Size = new System.Drawing.Size(80, 25);
            numPlayerSkillHPMin.TabIndex = 20;
            numPlayerSkillHPMin.Value = new decimal(new int[] { 50, 0, 0, 0 });
            numPlayerSkillHPMin.ValueChanged += numSettings_ValueChanged;
            // 
            // label10
            // 
            label10.ApplyGradient = false;
            label10.AutoSize = true;
            label10.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            label10.Gradient = (new System.Drawing.Color[] { System.Drawing.Color.Gray, System.Drawing.Color.Black });
            label10.Location = new System.Drawing.Point(201, 155);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(15, 15);
            label10.TabIndex = 19;
            label10.Text = "<";
            // 
            // label7
            // 
            label7.ApplyGradient = false;
            label7.AutoSize = true;
            label7.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            label7.Gradient = (new System.Drawing.Color[] { System.Drawing.Color.Gray, System.Drawing.Color.Black });
            label7.Location = new System.Drawing.Point(302, 123);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(17, 15);
            label7.TabIndex = 18;
            label7.Text = "%";
            // 
            // numPlayerMPVigorPotionMin
            // 
            numPlayerMPVigorPotionMin.BackColor = System.Drawing.Color.FromArgb(238, 238, 238);
            numPlayerMPVigorPotionMin.Font = new System.Drawing.Font("Segoe UI", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            numPlayerMPVigorPotionMin.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            numPlayerMPVigorPotionMin.Location = new System.Drawing.Point(220, 118);
            numPlayerMPVigorPotionMin.Maximum = new decimal(new int[] { 100, 0, 0, 0 });
            numPlayerMPVigorPotionMin.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numPlayerMPVigorPotionMin.MinimumSize = new System.Drawing.Size(80, 25);
            numPlayerMPVigorPotionMin.Name = "numPlayerMPVigorPotionMin";
            numPlayerMPVigorPotionMin.Size = new System.Drawing.Size(80, 25);
            numPlayerMPVigorPotionMin.TabIndex = 17;
            numPlayerMPVigorPotionMin.Value = new decimal(new int[] { 50, 0, 0, 0 });
            numPlayerMPVigorPotionMin.ValueChanged += numSettings_ValueChanged;
            // 
            // label8
            // 
            label8.ApplyGradient = false;
            label8.AutoSize = true;
            label8.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            label8.Gradient = (new System.Drawing.Color[] { System.Drawing.Color.Gray, System.Drawing.Color.Black });
            label8.Location = new System.Drawing.Point(201, 122);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(15, 15);
            label8.TabIndex = 16;
            label8.Text = "<";
            // 
            // label5
            // 
            label5.ApplyGradient = false;
            label5.AutoSize = true;
            label5.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            label5.Gradient = (new System.Drawing.Color[] { System.Drawing.Color.Gray, System.Drawing.Color.Black });
            label5.Location = new System.Drawing.Point(302, 96);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(17, 15);
            label5.TabIndex = 15;
            label5.Text = "%";
            // 
            // numPlayerHPVigorPotionMin
            // 
            numPlayerHPVigorPotionMin.BackColor = System.Drawing.Color.FromArgb(238, 238, 238);
            numPlayerHPVigorPotionMin.Font = new System.Drawing.Font("Segoe UI", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            numPlayerHPVigorPotionMin.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            numPlayerHPVigorPotionMin.Location = new System.Drawing.Point(220, 91);
            numPlayerHPVigorPotionMin.Maximum = new decimal(new int[] { 100, 0, 0, 0 });
            numPlayerHPVigorPotionMin.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numPlayerHPVigorPotionMin.MinimumSize = new System.Drawing.Size(80, 25);
            numPlayerHPVigorPotionMin.Name = "numPlayerHPVigorPotionMin";
            numPlayerHPVigorPotionMin.Size = new System.Drawing.Size(80, 25);
            numPlayerHPVigorPotionMin.TabIndex = 14;
            numPlayerHPVigorPotionMin.Value = new decimal(new int[] { 50, 0, 0, 0 });
            numPlayerHPVigorPotionMin.ValueChanged += numSettings_ValueChanged;
            // 
            // label6
            // 
            label6.ApplyGradient = false;
            label6.AutoSize = true;
            label6.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            label6.Gradient = (new System.Drawing.Color[] { System.Drawing.Color.Gray, System.Drawing.Color.Black });
            label6.Location = new System.Drawing.Point(201, 95);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(15, 15);
            label6.TabIndex = 13;
            label6.Text = "<";
            // 
            // label3
            // 
            label3.ApplyGradient = false;
            label3.AutoSize = true;
            label3.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            label3.Gradient = (new System.Drawing.Color[] { System.Drawing.Color.Gray, System.Drawing.Color.Black });
            label3.Location = new System.Drawing.Point(306, 64);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(17, 15);
            label3.TabIndex = 12;
            label3.Text = "%";
            // 
            // numPlayerMPPotionMin
            // 
            numPlayerMPPotionMin.BackColor = System.Drawing.Color.FromArgb(238, 238, 238);
            numPlayerMPPotionMin.Font = new System.Drawing.Font("Segoe UI", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            numPlayerMPPotionMin.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            numPlayerMPPotionMin.Location = new System.Drawing.Point(220, 60);
            numPlayerMPPotionMin.Maximum = new decimal(new int[] { 100, 0, 0, 0 });
            numPlayerMPPotionMin.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numPlayerMPPotionMin.MinimumSize = new System.Drawing.Size(80, 25);
            numPlayerMPPotionMin.Name = "numPlayerMPPotionMin";
            numPlayerMPPotionMin.Size = new System.Drawing.Size(80, 25);
            numPlayerMPPotionMin.TabIndex = 11;
            numPlayerMPPotionMin.Value = new decimal(new int[] { 50, 0, 0, 0 });
            numPlayerMPPotionMin.ValueChanged += numSettings_ValueChanged;
            // 
            // label4
            // 
            label4.ApplyGradient = false;
            label4.AutoSize = true;
            label4.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            label4.Gradient = (new System.Drawing.Color[] { System.Drawing.Color.Gray, System.Drawing.Color.Black });
            label4.Location = new System.Drawing.Point(201, 64);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(15, 15);
            label4.TabIndex = 10;
            label4.Text = "<";
            // 
            // label2
            // 
            label2.ApplyGradient = false;
            label2.AutoSize = true;
            label2.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            label2.Gradient = (new System.Drawing.Color[] { System.Drawing.Color.Gray, System.Drawing.Color.Black });
            label2.Location = new System.Drawing.Point(306, 37);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(17, 15);
            label2.TabIndex = 9;
            label2.Text = "%";
            // 
            // numPlayerHPPotionMin
            // 
            numPlayerHPPotionMin.BackColor = System.Drawing.Color.FromArgb(238, 238, 238);
            numPlayerHPPotionMin.Font = new System.Drawing.Font("Segoe UI", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            numPlayerHPPotionMin.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            numPlayerHPPotionMin.Location = new System.Drawing.Point(220, 33);
            numPlayerHPPotionMin.Maximum = new decimal(new int[] { 100, 0, 0, 0 });
            numPlayerHPPotionMin.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numPlayerHPPotionMin.MinimumSize = new System.Drawing.Size(80, 25);
            numPlayerHPPotionMin.Name = "numPlayerHPPotionMin";
            numPlayerHPPotionMin.Size = new System.Drawing.Size(80, 25);
            numPlayerHPPotionMin.TabIndex = 8;
            numPlayerHPPotionMin.Value = new decimal(new int[] { 50, 0, 0, 0 });
            numPlayerHPPotionMin.ValueChanged += numSettings_ValueChanged;
            // 
            // label1
            // 
            label1.ApplyGradient = false;
            label1.AutoSize = true;
            label1.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            label1.Gradient = (new System.Drawing.Color[] { System.Drawing.Color.Gray, System.Drawing.Color.Black });
            label1.Location = new System.Drawing.Point(201, 37);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(15, 15);
            label1.TabIndex = 7;
            label1.Text = "<";
            // 
            // checkUseSkillHP
            // 
            checkUseSkillHP.AutoSize = true;
            checkUseSkillHP.BackColor = System.Drawing.Color.Transparent;
            checkUseSkillHP.Depth = 0;
            checkUseSkillHP.Location = new System.Drawing.Point(11, 149);
            checkUseSkillHP.Margin = new System.Windows.Forms.Padding(0);
            checkUseSkillHP.MouseLocation = new System.Drawing.Point(-1, -1);
            checkUseSkillHP.Name = "checkUseSkillHP";
            checkUseSkillHP.Ripple = true;
            checkUseSkillHP.Size = new System.Drawing.Size(103, 30);
            checkUseSkillHP.TabIndex = 4;
            checkUseSkillHP.Text = "Use skill if HP";
            checkUseSkillHP.UseVisualStyleBackColor = false;
            checkUseSkillHP.CheckedChanged += settings_CheckedChanged;
            // 
            // checkUseSkillMP
            // 
            checkUseSkillMP.AutoSize = true;
            checkUseSkillMP.BackColor = System.Drawing.Color.Transparent;
            checkUseSkillMP.Depth = 0;
            checkUseSkillMP.Location = new System.Drawing.Point(9, 175);
            checkUseSkillMP.Margin = new System.Windows.Forms.Padding(0);
            checkUseSkillMP.MouseLocation = new System.Drawing.Point(-1, -1);
            checkUseSkillMP.Name = "checkUseSkillMP";
            checkUseSkillMP.Ripple = true;
            checkUseSkillMP.Size = new System.Drawing.Size(105, 30);
            checkUseSkillMP.TabIndex = 5;
            checkUseSkillMP.Text = "Use skill if MP";
            checkUseSkillMP.UseVisualStyleBackColor = false;
            checkUseSkillMP.CheckedChanged += settings_CheckedChanged;
            // 
            // checkUseHPPotionsPlayer
            // 
            checkUseHPPotionsPlayer.AutoSize = true;
            checkUseHPPotionsPlayer.BackColor = System.Drawing.Color.Transparent;
            checkUseHPPotionsPlayer.Depth = 0;
            checkUseHPPotionsPlayer.Location = new System.Drawing.Point(11, 29);
            checkUseHPPotionsPlayer.Margin = new System.Windows.Forms.Padding(0);
            checkUseHPPotionsPlayer.MouseLocation = new System.Drawing.Point(-1, -1);
            checkUseHPPotionsPlayer.Name = "checkUseHPPotionsPlayer";
            checkUseHPPotionsPlayer.Ripple = true;
            checkUseHPPotionsPlayer.Size = new System.Drawing.Size(151, 30);
            checkUseHPPotionsPlayer.TabIndex = 0;
            checkUseHPPotionsPlayer.Text = "Use HP potions if HP *";
            checkUseHPPotionsPlayer.UseVisualStyleBackColor = false;
            checkUseHPPotionsPlayer.CheckedChanged += settings_CheckedChanged;
            // 
            // checkUseVigorMP
            // 
            checkUseVigorMP.AutoSize = true;
            checkUseVigorMP.BackColor = System.Drawing.Color.Transparent;
            checkUseVigorMP.Depth = 0;
            checkUseVigorMP.Location = new System.Drawing.Point(11, 113);
            checkUseVigorMP.Margin = new System.Windows.Forms.Padding(0);
            checkUseVigorMP.MouseLocation = new System.Drawing.Point(-1, -1);
            checkUseVigorMP.Name = "checkUseVigorMP";
            checkUseVigorMP.Ripple = true;
            checkUseVigorMP.Size = new System.Drawing.Size(158, 30);
            checkUseVigorMP.TabIndex = 3;
            checkUseVigorMP.Text = "Use Vigor Potions if MP";
            checkUseVigorMP.UseVisualStyleBackColor = false;
            checkUseVigorMP.CheckedChanged += settings_CheckedChanged;
            // 
            // checkUseMPPotionsPlayer
            // 
            checkUseMPPotionsPlayer.AutoSize = true;
            checkUseMPPotionsPlayer.BackColor = System.Drawing.Color.Transparent;
            checkUseMPPotionsPlayer.Depth = 0;
            checkUseMPPotionsPlayer.Location = new System.Drawing.Point(11, 56);
            checkUseMPPotionsPlayer.Margin = new System.Windows.Forms.Padding(0);
            checkUseMPPotionsPlayer.MouseLocation = new System.Drawing.Point(-1, -1);
            checkUseMPPotionsPlayer.Name = "checkUseMPPotionsPlayer";
            checkUseMPPotionsPlayer.Ripple = true;
            checkUseMPPotionsPlayer.Size = new System.Drawing.Size(156, 30);
            checkUseMPPotionsPlayer.TabIndex = 1;
            checkUseMPPotionsPlayer.Text = "Use MP potions if MP *";
            checkUseMPPotionsPlayer.UseVisualStyleBackColor = false;
            checkUseMPPotionsPlayer.CheckedChanged += settings_CheckedChanged;
            // 
            // checkUseVigorHP
            // 
            checkUseVigorHP.AutoSize = true;
            checkUseVigorHP.BackColor = System.Drawing.Color.Transparent;
            checkUseVigorHP.Depth = 0;
            checkUseVigorHP.Location = new System.Drawing.Point(11, 87);
            checkUseVigorHP.Margin = new System.Windows.Forms.Padding(0);
            checkUseVigorHP.MouseLocation = new System.Drawing.Point(-1, -1);
            checkUseVigorHP.Name = "checkUseVigorHP";
            checkUseVigorHP.Ripple = true;
            checkUseVigorHP.Size = new System.Drawing.Size(156, 30);
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
            groupPet.Location = new System.Drawing.Point(15, 325);
            groupPet.Name = "groupPet";
            groupPet.Padding = new System.Windows.Forms.Padding(3, 10, 3, 3);
            groupPet.Radius = 10;
            groupPet.ShadowDepth = 4;
            groupPet.Size = new System.Drawing.Size(468, 160);
            groupPet.TabIndex = 1;
            groupPet.TabStop = false;
            groupPet.Text = "Recovery - Pet";
            // 
            // checkAutoSummonAttackPet
            // 
            checkAutoSummonAttackPet.AutoSize = true;
            checkAutoSummonAttackPet.BackColor = System.Drawing.Color.Transparent;
            checkAutoSummonAttackPet.Depth = 0;
            checkAutoSummonAttackPet.Location = new System.Drawing.Point(11, 129);
            checkAutoSummonAttackPet.Margin = new System.Windows.Forms.Padding(0);
            checkAutoSummonAttackPet.MouseLocation = new System.Drawing.Point(-1, -1);
            checkAutoSummonAttackPet.Name = "checkAutoSummonAttackPet";
            checkAutoSummonAttackPet.Ripple = true;
            checkAutoSummonAttackPet.Size = new System.Drawing.Size(215, 30);
            checkAutoSummonAttackPet.TabIndex = 27;
            checkAutoSummonAttackPet.Text = "Auto summon growth / fellow pet";
            checkAutoSummonAttackPet.UseVisualStyleBackColor = false;
            checkAutoSummonAttackPet.CheckedChanged += settings_CheckedChanged;
            // 
            // checkUseAbnormalStatePotion
            // 
            checkUseAbnormalStatePotion.AutoSize = true;
            checkUseAbnormalStatePotion.BackColor = System.Drawing.Color.Transparent;
            checkUseAbnormalStatePotion.Depth = 0;
            checkUseAbnormalStatePotion.Location = new System.Drawing.Point(11, 82);
            checkUseAbnormalStatePotion.Margin = new System.Windows.Forms.Padding(0);
            checkUseAbnormalStatePotion.MouseLocation = new System.Drawing.Point(-1, -1);
            checkUseAbnormalStatePotion.Name = "checkUseAbnormalStatePotion";
            checkUseAbnormalStatePotion.Ripple = true;
            checkUseAbnormalStatePotion.Size = new System.Drawing.Size(238, 30);
            checkUseAbnormalStatePotion.TabIndex = 26;
            checkUseAbnormalStatePotion.Text = "Use abnormal state recovery potions *";
            checkUseAbnormalStatePotion.UseVisualStyleBackColor = false;
            checkUseAbnormalStatePotion.CheckedChanged += settings_CheckedChanged;
            // 
            // checkReviveAttackPet
            // 
            checkReviveAttackPet.AutoSize = true;
            checkReviveAttackPet.BackColor = System.Drawing.Color.Transparent;
            checkReviveAttackPet.Depth = 0;
            checkReviveAttackPet.Location = new System.Drawing.Point(11, 105);
            checkReviveAttackPet.Margin = new System.Windows.Forms.Padding(0);
            checkReviveAttackPet.MouseLocation = new System.Drawing.Point(-1, -1);
            checkReviveAttackPet.Name = "checkReviveAttackPet";
            checkReviveAttackPet.Ripple = true;
            checkReviveAttackPet.Size = new System.Drawing.Size(172, 30);
            checkReviveAttackPet.TabIndex = 25;
            checkReviveAttackPet.Text = "Revive growth / fellow pet";
            checkReviveAttackPet.UseVisualStyleBackColor = false;
            checkReviveAttackPet.CheckedChanged += settings_CheckedChanged;
            // 
            // label13
            // 
            label13.ApplyGradient = false;
            label13.AutoSize = true;
            label13.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            label13.Gradient = (new System.Drawing.Color[] { System.Drawing.Color.Gray, System.Drawing.Color.Black });
            label13.Location = new System.Drawing.Point(353, 64);
            label13.Name = "label13";
            label13.Size = new System.Drawing.Size(17, 15);
            label13.TabIndex = 20;
            label13.Text = "%";
            // 
            // numPetMinHGP
            // 
            numPetMinHGP.BackColor = System.Drawing.Color.FromArgb(238, 238, 238);
            numPetMinHGP.Font = new System.Drawing.Font("Segoe UI", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            numPetMinHGP.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            numPetMinHGP.Location = new System.Drawing.Point(267, 59);
            numPetMinHGP.Maximum = new decimal(new int[] { 100, 0, 0, 0 });
            numPetMinHGP.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numPetMinHGP.MinimumSize = new System.Drawing.Size(80, 25);
            numPetMinHGP.Name = "numPetMinHGP";
            numPetMinHGP.Size = new System.Drawing.Size(80, 25);
            numPetMinHGP.TabIndex = 19;
            numPetMinHGP.Value = new decimal(new int[] { 50, 0, 0, 0 });
            numPetMinHGP.ValueChanged += numSettings_ValueChanged;
            // 
            // label14
            // 
            label14.ApplyGradient = false;
            label14.AutoSize = true;
            label14.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            label14.Gradient = (new System.Drawing.Color[] { System.Drawing.Color.Gray, System.Drawing.Color.Black });
            label14.Location = new System.Drawing.Point(246, 64);
            label14.Name = "label14";
            label14.Size = new System.Drawing.Size(15, 15);
            label14.TabIndex = 18;
            label14.Text = "<";
            // 
            // label15
            // 
            label15.ApplyGradient = false;
            label15.AutoSize = true;
            label15.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            label15.Gradient = (new System.Drawing.Color[] { System.Drawing.Color.Gray, System.Drawing.Color.Black });
            label15.Location = new System.Drawing.Point(353, 36);
            label15.Name = "label15";
            label15.Size = new System.Drawing.Size(17, 15);
            label15.TabIndex = 17;
            label15.Text = "%";
            // 
            // numPetMinHP
            // 
            numPetMinHP.BackColor = System.Drawing.Color.FromArgb(238, 238, 238);
            numPetMinHP.Font = new System.Drawing.Font("Segoe UI", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            numPetMinHP.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            numPetMinHP.Location = new System.Drawing.Point(267, 31);
            numPetMinHP.Maximum = new decimal(new int[] { 100, 0, 0, 0 });
            numPetMinHP.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numPetMinHP.MinimumSize = new System.Drawing.Size(80, 25);
            numPetMinHP.Name = "numPetMinHP";
            numPetMinHP.Size = new System.Drawing.Size(80, 25);
            numPetMinHP.TabIndex = 16;
            numPetMinHP.Value = new decimal(new int[] { 50, 0, 0, 0 });
            numPetMinHP.ValueChanged += numSettings_ValueChanged;
            // 
            // label16
            // 
            label16.ApplyGradient = false;
            label16.AutoSize = true;
            label16.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            label16.Gradient = (new System.Drawing.Color[] { System.Drawing.Color.Gray, System.Drawing.Color.Black });
            label16.Location = new System.Drawing.Point(246, 37);
            label16.Name = "label16";
            label16.Size = new System.Drawing.Size(15, 15);
            label16.TabIndex = 15;
            label16.Text = "<";
            // 
            // checkUsePetHP
            // 
            checkUsePetHP.AutoSize = true;
            checkUsePetHP.BackColor = System.Drawing.Color.Transparent;
            checkUsePetHP.Depth = 0;
            checkUsePetHP.Location = new System.Drawing.Point(11, 30);
            checkUsePetHP.Margin = new System.Windows.Forms.Padding(0);
            checkUsePetHP.MouseLocation = new System.Drawing.Point(-1, -1);
            checkUsePetHP.Name = "checkUsePetHP";
            checkUsePetHP.Ripple = true;
            checkUsePetHP.Size = new System.Drawing.Size(151, 30);
            checkUsePetHP.TabIndex = 13;
            checkUsePetHP.Text = "Use HP potions if HP *";
            checkUsePetHP.UseVisualStyleBackColor = false;
            checkUsePetHP.CheckedChanged += settings_CheckedChanged;
            // 
            // checkUseHGP
            // 
            checkUseHGP.AutoSize = true;
            checkUseHGP.BackColor = System.Drawing.Color.Transparent;
            checkUseHGP.Depth = 0;
            checkUseHGP.Location = new System.Drawing.Point(11, 57);
            checkUseHGP.Margin = new System.Windows.Forms.Padding(0);
            checkUseHGP.MouseLocation = new System.Drawing.Point(-1, -1);
            checkUseHGP.Name = "checkUseHGP";
            checkUseHGP.Ripple = true;
            checkUseHGP.Size = new System.Drawing.Size(227, 30);
            checkUseHGP.TabIndex = 14;
            checkUseHGP.Text = "Use HGP / Saiety potions if hunger *";
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
            groupStatPoints.Location = new System.Drawing.Point(500, 277);
            groupStatPoints.Name = "groupStatPoints";
            groupStatPoints.Padding = new System.Windows.Forms.Padding(3, 10, 3, 3);
            groupStatPoints.Radius = 10;
            groupStatPoints.ShadowDepth = 4;
            groupStatPoints.Size = new System.Drawing.Size(254, 169);
            groupStatPoints.TabIndex = 18;
            groupStatPoints.TabStop = false;
            groupStatPoints.Text = "Stat points";
            // 
            // buttonRun
            // 
            buttonRun.Color = System.Drawing.Color.Transparent;
            buttonRun.Location = new System.Drawing.Point(63, 137);
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
            checkIncBotStopped.Depth = 0;
            checkIncBotStopped.Location = new System.Drawing.Point(18, 104);
            checkIncBotStopped.Margin = new System.Windows.Forms.Padding(0);
            checkIncBotStopped.MouseLocation = new System.Drawing.Point(-1, -1);
            checkIncBotStopped.Name = "checkIncBotStopped";
            checkIncBotStopped.Ripple = true;
            checkIncBotStopped.Size = new System.Drawing.Size(165, 30);
            checkIncBotStopped.TabIndex = 24;
            checkIncBotStopped.Text = "Enabled if bot is stopped";
            checkIncBotStopped.UseVisualStyleBackColor = false;
            checkIncBotStopped.CheckedChanged += settings_CheckedChanged;
            // 
            // numIncStr
            // 
            numIncStr.BackColor = System.Drawing.Color.FromArgb(238, 238, 238);
            numIncStr.Font = new System.Drawing.Font("Segoe UI", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            numIncStr.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            numIncStr.Location = new System.Drawing.Point(133, 76);
            numIncStr.Maximum = new decimal(new int[] { 3, 0, 0, 0 });
            numIncStr.Minimum = new decimal(new int[] { 0, 0, 0, 0 });
            numIncStr.MinimumSize = new System.Drawing.Size(80, 25);
            numIncStr.Name = "numIncStr";
            numIncStr.Size = new System.Drawing.Size(80, 25);
            numIncStr.TabIndex = 22;
            numIncStr.Value = new decimal(new int[] { 0, 0, 0, 0 });
            numIncStr.ValueChanged += numIncStr_ValueChanged;
            // 
            // numIncInt
            // 
            numIncInt.BackColor = System.Drawing.Color.FromArgb(238, 238, 238);
            numIncInt.Font = new System.Drawing.Font("Segoe UI", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            numIncInt.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            numIncInt.Location = new System.Drawing.Point(133, 45);
            numIncInt.Maximum = new decimal(new int[] { 3, 0, 0, 0 });
            numIncInt.Minimum = new decimal(new int[] { 0, 0, 0, 0 });
            numIncInt.MinimumSize = new System.Drawing.Size(80, 25);
            numIncInt.Name = "numIncInt";
            numIncInt.Size = new System.Drawing.Size(80, 25);
            numIncInt.TabIndex = 21;
            numIncInt.Value = new decimal(new int[] { 0, 0, 0, 0 });
            numIncInt.ValueChanged += numIncInt_ValueChanged;
            // 
            // checkIncStr
            // 
            checkIncStr.AutoSize = true;
            checkIncStr.BackColor = System.Drawing.Color.Transparent;
            checkIncStr.Depth = 0;
            checkIncStr.Location = new System.Drawing.Point(18, 74);
            checkIncStr.Margin = new System.Windows.Forms.Padding(0);
            checkIncStr.MouseLocation = new System.Drawing.Point(-1, -1);
            checkIncStr.Name = "checkIncStr";
            checkIncStr.Ripple = true;
            checkIncStr.Size = new System.Drawing.Size(98, 30);
            checkIncStr.TabIndex = 20;
            checkIncStr.Text = "Increase STR";
            checkIncStr.UseVisualStyleBackColor = false;
            checkIncStr.CheckedChanged += settings_CheckedChanged;
            // 
            // checkIncInt
            // 
            checkIncInt.AutoSize = true;
            checkIncInt.BackColor = System.Drawing.Color.Transparent;
            checkIncInt.Depth = 0;
            checkIncInt.Location = new System.Drawing.Point(18, 43);
            checkIncInt.Margin = new System.Windows.Forms.Padding(0);
            checkIncInt.MouseLocation = new System.Drawing.Point(-1, -1);
            checkIncInt.Name = "checkIncInt";
            checkIncInt.Ripple = true;
            checkIncInt.Size = new System.Drawing.Size(97, 30);
            checkIncInt.TabIndex = 19;
            checkIncInt.Text = "Increase INT";
            checkIncInt.UseVisualStyleBackColor = false;
            checkIncInt.CheckedChanged += settings_CheckedChanged;
            // 
            // label17
            // 
            label17.ApplyGradient = false;
            label17.AutoSize = true;
            label17.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            label17.Gradient = (new System.Drawing.Color[] { System.Drawing.Color.Gray, System.Drawing.Color.Black });
            label17.Location = new System.Drawing.Point(332, 134);
            label17.Name = "label17";
            label17.Size = new System.Drawing.Size(31, 15);
            label17.TabIndex = 26;
            label17.Text = "Skill:";
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
            Size = new System.Drawing.Size(776, 497);
            groupBackTown.ResumeLayout(false);
            groupBackTown.PerformLayout();
            groupBadStatus.ResumeLayout(false);
            groupBadStatus.PerformLayout();
            groupHPMP.ResumeLayout(false);
            groupHPMP.PerformLayout();
            groupPet.ResumeLayout(false);
            groupPet.PerformLayout();
            groupStatPoints.ResumeLayout(false);
            groupStatPoints.PerformLayout();
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
        private SDUI.Controls.Label label17;
    }
}
