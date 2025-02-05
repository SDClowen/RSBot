
using ComboBox = System.Windows.Forms.ComboBox;
using GroupBox = System.Windows.Forms.GroupBox;
using Label = System.Windows.Forms.Label;
using ListView = System.Windows.Forms.ListView;
using TabControl = System.Windows.Forms.TabControl;
using Panel = System.Windows.Forms.Panel;
using RadioButton = System.Windows.Forms.RadioButton;
using CheckBox = System.Windows.Forms.CheckBox;

namespace RSBot.Alchemy.Views.Settings
{
    partial class EnhanceSettingsView
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
            this.lblMaxOptLevel = new System.Windows.Forms.Label();
            this.numMaxEnhancement = new System.Windows.Forms.NumericUpDown();
            this.lblPlus = new System.Windows.Forms.Label();
            this.checkUseLuckyStones = new System.Windows.Forms.CheckBox();
            this.checkUseImmortalStones = new System.Windows.Forms.CheckBox();
            this.lblElixir = new System.Windows.Forms.Label();
            this.comboElixir = new System.Windows.Forms.ComboBox();
            this.linkRefreshItemList = new System.Windows.Forms.Label();
            this.checkUseAstralStones = new System.Windows.Forms.CheckBox();
            this.lblLuckyCount = new System.Windows.Forms.Label();
            this.lblImmortalCount = new System.Windows.Forms.Label();
            this.lblAstralCount = new System.Windows.Forms.Label();
            this.checkUseSteadyStones = new System.Windows.Forms.CheckBox();
            this.lblSteadyStonesCount = new System.Windows.Forms.Label();
            this.lblLuckyPowderCount = new System.Windows.Forms.Label();
            this.checkStopLuckyPowder = new System.Windows.Forms.CheckBox();
            this.lblCurrentOptLevel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblMaxOptLevel
            // 
            this.lblMaxOptLevel.AutoSize = true;

            this.lblMaxOptLevel.Location = new System.Drawing.Point(13, 34);
            this.lblMaxOptLevel.Name = "lblMaxOptLevel";
            this.lblMaxOptLevel.Size = new System.Drawing.Size(109, 15);
            this.lblMaxOptLevel.TabIndex = 0;
            this.lblMaxOptLevel.Text = "Max enhancement:";
            // 
            // numMaxEnhancement
            // 


            this.numMaxEnhancement.Location = new System.Drawing.Point(140, 32);
            this.numMaxEnhancement.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numMaxEnhancement.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numMaxEnhancement.Name = "numMaxEnhancement";
            this.numMaxEnhancement.Size = new System.Drawing.Size(54, 23);
            this.numMaxEnhancement.TabIndex = 1;
            this.numMaxEnhancement.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numMaxEnhancement.ValueChanged += new System.EventHandler(this.config_CheckedChange);
            this.numMaxEnhancement.Validated += new System.EventHandler(this.config_CheckedChange);
            // 
            // lblPlus
            // 
            this.lblPlus.AutoSize = true;

            this.lblPlus.Location = new System.Drawing.Point(119, 34);
            this.lblPlus.Name = "lblPlus";
            this.lblPlus.Size = new System.Drawing.Size(15, 15);
            this.lblPlus.TabIndex = 2;
            this.lblPlus.Text = "+";
            // 
            // checkUseLuckyStones
            // 
            this.checkUseLuckyStones.AutoSize = true;

            this.checkUseLuckyStones.Location = new System.Drawing.Point(141, 130);
            this.checkUseLuckyStones.Name = "checkUseLuckyStones";
            this.checkUseLuckyStones.Size = new System.Drawing.Size(110, 15);
            this.checkUseLuckyStones.TabIndex = 3;
            this.checkUseLuckyStones.Text = "Use lucky stones";
            this.checkUseLuckyStones.UseVisualStyleBackColor = false;
            this.checkUseLuckyStones.CheckedChanged += new System.EventHandler(this.config_CheckedChange);
            // 
            // checkUseImmortalStones
            // 
            this.checkUseImmortalStones.AutoSize = true;

            this.checkUseImmortalStones.Location = new System.Drawing.Point(141, 153);
            this.checkUseImmortalStones.Name = "checkUseImmortalStones";
            this.checkUseImmortalStones.Size = new System.Drawing.Size(131, 15);
            this.checkUseImmortalStones.TabIndex = 4;
            this.checkUseImmortalStones.Text = "Use immortal stones";
            this.checkUseImmortalStones.UseVisualStyleBackColor = false;
            this.checkUseImmortalStones.CheckedChanged += new System.EventHandler(this.config_CheckedChange);
            // 
            // lblElixir
            // 
            this.lblElixir.AutoSize = true;

            this.lblElixir.Location = new System.Drawing.Point(83, 70);
            this.lblElixir.Name = "lblElixir";
            this.lblElixir.Size = new System.Drawing.Size(35, 15);
            this.lblElixir.TabIndex = 5;
            this.lblElixir.Text = "Elixir:";
            // 
            // comboElixir
            // 

            this.comboElixir.DrawMode = System.Windows.Forms.DrawMode.Normal;
            this.comboElixir.DropDownHeight = 100;
            this.comboElixir.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboElixir.FormattingEnabled = true;
            this.comboElixir.IntegralHeight = false;
            this.comboElixir.ItemHeight = 17;
            this.comboElixir.Location = new System.Drawing.Point(140, 67);
            this.comboElixir.Name = "comboElixir";
            this.comboElixir.Size = new System.Drawing.Size(193, 23);
            this.comboElixir.TabIndex = 6;
            this.comboElixir.SelectedIndexChanged += new System.EventHandler(this.config_CheckedChange);
            // 
            // linkRefreshItemList
            // 
            this.linkRefreshItemList.AutoSize = true;
            this.linkRefreshItemList.Cursor = System.Windows.Forms.Cursors.Hand;
            this.linkRefreshItemList.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);

            this.linkRefreshItemList.Location = new System.Drawing.Point(328, 60);
            this.linkRefreshItemList.Name = "linkRefreshItemList";
            this.linkRefreshItemList.Size = new System.Drawing.Size(34, 30);
            this.linkRefreshItemList.TabIndex = 7;
            this.linkRefreshItemList.Text = "🗘";
            this.linkRefreshItemList.Click += new System.EventHandler(this.linkRefreshItemList_Click);
            // 
            // checkUseAstralStones
            // 
            this.checkUseAstralStones.AutoSize = true;

            this.checkUseAstralStones.Location = new System.Drawing.Point(141, 176);
            this.checkUseAstralStones.Name = "checkUseAstralStones";
            this.checkUseAstralStones.Size = new System.Drawing.Size(110, 15);
            this.checkUseAstralStones.TabIndex = 8;
            this.checkUseAstralStones.Text = "Use astral stones";
            this.checkUseAstralStones.UseVisualStyleBackColor = false;
            this.checkUseAstralStones.CheckedChanged += new System.EventHandler(this.config_CheckedChange);
            // 
            // lblLuckyCount
            // 
            this.lblLuckyCount.AutoSize = true;

            this.lblLuckyCount.Location = new System.Drawing.Point(314, 130);
            this.lblLuckyCount.Name = "lblLuckyCount";
            this.lblLuckyCount.Size = new System.Drawing.Size(19, 15);
            this.lblLuckyCount.TabIndex = 9;
            this.lblLuckyCount.Text = "x0";
            // 
            // lblImmortalCount
            // 
            this.lblImmortalCount.AutoSize = true;

            this.lblImmortalCount.Location = new System.Drawing.Point(314, 153);
            this.lblImmortalCount.Name = "lblImmortalCount";
            this.lblImmortalCount.Size = new System.Drawing.Size(19, 15);
            this.lblImmortalCount.TabIndex = 9;
            this.lblImmortalCount.Text = "x0";
            // 
            // lblAstralCount
            // 
            this.lblAstralCount.AutoSize = true;

            this.lblAstralCount.Location = new System.Drawing.Point(314, 176);
            this.lblAstralCount.Name = "lblAstralCount";
            this.lblAstralCount.Size = new System.Drawing.Size(19, 15);
            this.lblAstralCount.TabIndex = 9;
            this.lblAstralCount.Text = "x0";
            // 
            // checkUseSteadyStones
            // 
            this.checkUseSteadyStones.AutoSize = true;

            this.checkUseSteadyStones.Location = new System.Drawing.Point(141, 199);
            this.checkUseSteadyStones.Name = "checkUseSteadyStones";
            this.checkUseSteadyStones.Size = new System.Drawing.Size(116, 15);
            this.checkUseSteadyStones.TabIndex = 8;
            this.checkUseSteadyStones.Text = "Use steady stones";
            this.checkUseSteadyStones.UseVisualStyleBackColor = false;
            this.checkUseSteadyStones.CheckedChanged += new System.EventHandler(this.config_CheckedChange);
            // 
            // lblSteadyStonesCount
            // 
            this.lblSteadyStonesCount.AutoSize = true;

            this.lblSteadyStonesCount.Location = new System.Drawing.Point(314, 199);
            this.lblSteadyStonesCount.Name = "lblSteadyStonesCount";
            this.lblSteadyStonesCount.Size = new System.Drawing.Size(19, 15);
            this.lblSteadyStonesCount.TabIndex = 9;
            this.lblSteadyStonesCount.Text = "x0";
            // 
            // lblLuckyPowderCount
            // 
            this.lblLuckyPowderCount.AutoSize = true;

            this.lblLuckyPowderCount.Location = new System.Drawing.Point(314, 107);
            this.lblLuckyPowderCount.Name = "lblLuckyPowderCount";
            this.lblLuckyPowderCount.Size = new System.Drawing.Size(19, 15);
            this.lblLuckyPowderCount.TabIndex = 11;
            this.lblLuckyPowderCount.Text = "x0";
            // 
            // checkStopLuckyPowder
            // 
            this.checkStopLuckyPowder.AutoSize = true;

            this.checkStopLuckyPowder.Checked = true;
            this.checkStopLuckyPowder.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkStopLuckyPowder.Location = new System.Drawing.Point(141, 107);
            this.checkStopLuckyPowder.Name = "checkStopLuckyPowder";
            this.checkStopLuckyPowder.Size = new System.Drawing.Size(140, 15);
            this.checkStopLuckyPowder.TabIndex = 10;
            this.checkStopLuckyPowder.Text = "Stop if 0 lucky powder";
            this.checkStopLuckyPowder.UseVisualStyleBackColor = false;
            this.checkStopLuckyPowder.CheckedChanged += new System.EventHandler(this.config_CheckedChange);
            // 
            // lblCurrentOptLevel
            // 
            this.lblCurrentOptLevel.AutoSize = true;

            this.lblCurrentOptLevel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCurrentOptLevel.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);

            this.lblCurrentOptLevel.Location = new System.Drawing.Point(200, 32);
            this.lblCurrentOptLevel.Name = "lblCurrentOptLevel";
            this.lblCurrentOptLevel.Size = new System.Drawing.Size(31, 22);
            this.lblCurrentOptLevel.TabIndex = 12;
            this.lblCurrentOptLevel.Text = "+0";
            // 
            // EnhanceSettingsView
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.lblLuckyPowderCount);
            this.Controls.Add(this.checkStopLuckyPowder);
            this.Controls.Add(this.lblSteadyStonesCount);
            this.Controls.Add(this.lblAstralCount);
            this.Controls.Add(this.lblImmortalCount);
            this.Controls.Add(this.lblLuckyCount);
            this.Controls.Add(this.checkUseSteadyStones);
            this.Controls.Add(this.checkUseAstralStones);
            this.Controls.Add(this.comboElixir);
            this.Controls.Add(this.lblElixir);
            this.Controls.Add(this.checkUseImmortalStones);
            this.Controls.Add(this.checkUseLuckyStones);
            this.Controls.Add(this.lblPlus);
            this.Controls.Add(this.numMaxEnhancement);
            this.Controls.Add(this.lblMaxOptLevel);
            this.Controls.Add(this.linkRefreshItemList);
            this.Controls.Add(this.lblCurrentOptLevel);
            this.Enabled = false;
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Name = "EnhanceSettingsView";
            this.Size = new System.Drawing.Size(438, 306);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lblMaxOptLevel;
        private Label lblPlus;
        private CheckBox checkUseLuckyStones;
        private CheckBox checkUseImmortalStones;
        private Label lblElixir;
        private ComboBox comboElixir;
        private Label linkRefreshItemList;
        private CheckBox checkUseAstralStones;
        private Label lblLuckyCount;
        private Label lblImmortalCount;
        private Label lblAstralCount;
        private CheckBox checkUseSteadyStones;
        private Label lblSteadyStonesCount;
        private Label lblLuckyPowderCount;
        private CheckBox checkStopLuckyPowder;
        private Label lblCurrentOptLevel;
        private System.Windows.Forms.NumericUpDown numMaxEnhancement;
    }
}
