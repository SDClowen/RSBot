
using ComboBox = SDUI.Controls.ComboBox;
using GroupBox = SDUI.Controls.GroupBox;
using Label = SDUI.Controls.Label;
using ListView = SDUI.Controls.ListView;
using TabControl = SDUI.Controls.TabControl;
using Panel = SDUI.Controls.Panel;
using RadioButton = SDUI.Controls.Radio;
using CheckBox = SDUI.Controls.CheckBox;

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
            lblMaxOptLevel = new Label();
            numMaxEnhancement = new SDUI.Controls.NumUpDown();
            lblPlus = new Label();
            checkUseLuckyStones = new CheckBox();
            checkUseImmortalStones = new CheckBox();
            lblElixir = new Label();
            comboElixir = new ComboBox();
            linkRefreshItemList = new Label();
            checkUseAstralStones = new CheckBox();
            lblLuckyCount = new Label();
            lblImmortalCount = new Label();
            lblAstralCount = new Label();
            checkUseSteadyStones = new CheckBox();
            lblSteadyStonesCount = new Label();
            lblLuckyPowderCount = new Label();
            checkStopLuckyPowder = new CheckBox();
            lblCurrentOptLevel = new Label();
            SuspendLayout();
            // 
            // lblMaxOptLevel
            // 
            lblMaxOptLevel.ApplyGradient = false;
            lblMaxOptLevel.AutoSize = true;
            lblMaxOptLevel.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            lblMaxOptLevel.Gradient = new System.Drawing.Color[]
    {
    System.Drawing.Color.Gray,
    System.Drawing.Color.Black
    };
            lblMaxOptLevel.GradientAnimation = false;
            lblMaxOptLevel.Location = new System.Drawing.Point(13, 34);
            lblMaxOptLevel.Name = "lblMaxOptLevel";
            lblMaxOptLevel.Size = new System.Drawing.Size(133, 20);
            lblMaxOptLevel.TabIndex = 0;
            lblMaxOptLevel.Text = "Max enhancement:";
            // 
            // numMaxEnhancement
            // 
            numMaxEnhancement.BackColor = System.Drawing.Color.Transparent;
            numMaxEnhancement.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            numMaxEnhancement.Location = new System.Drawing.Point(169, 32);
            numMaxEnhancement.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            numMaxEnhancement.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numMaxEnhancement.MinimumSize = new System.Drawing.Size(80, 25);
            numMaxEnhancement.Name = "numMaxEnhancement";
            numMaxEnhancement.Size = new System.Drawing.Size(80, 25);
            numMaxEnhancement.TabIndex = 1;
            numMaxEnhancement.Value = new decimal(new int[] { 1, 0, 0, 0 });
            numMaxEnhancement.ValueChanged += config_CheckedChange;
            numMaxEnhancement.Validated += config_CheckedChange;
            // 
            // lblPlus
            // 
            lblPlus.ApplyGradient = false;
            lblPlus.AutoSize = true;
            lblPlus.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            lblPlus.Gradient = new System.Drawing.Color[]
    {
    System.Drawing.Color.Gray,
    System.Drawing.Color.Black
    };
            lblPlus.GradientAnimation = false;
            lblPlus.Location = new System.Drawing.Point(152, 34);
            lblPlus.Name = "lblPlus";
            lblPlus.Size = new System.Drawing.Size(19, 20);
            lblPlus.TabIndex = 2;
            lblPlus.Text = "+";
            // 
            // checkUseLuckyStones
            // 
            checkUseLuckyStones.AutoSize = true;
            checkUseLuckyStones.BackColor = System.Drawing.Color.Transparent;
            checkUseLuckyStones.Depth = 0;
            checkUseLuckyStones.Location = new System.Drawing.Point(141, 130);
            checkUseLuckyStones.Margin = new System.Windows.Forms.Padding(0);
            checkUseLuckyStones.MouseLocation = new System.Drawing.Point(-1, -1);
            checkUseLuckyStones.Name = "checkUseLuckyStones";
            checkUseLuckyStones.Ripple = true;
            checkUseLuckyStones.Size = new System.Drawing.Size(142, 30);
            checkUseLuckyStones.TabIndex = 3;
            checkUseLuckyStones.Text = "Use lucky stones";
            checkUseLuckyStones.UseVisualStyleBackColor = false;
            checkUseLuckyStones.CheckedChanged += config_CheckedChange;
            // 
            // checkUseImmortalStones
            // 
            checkUseImmortalStones.AutoSize = true;
            checkUseImmortalStones.BackColor = System.Drawing.Color.Transparent;
            checkUseImmortalStones.Depth = 0;
            checkUseImmortalStones.Location = new System.Drawing.Point(141, 153);
            checkUseImmortalStones.Margin = new System.Windows.Forms.Padding(0);
            checkUseImmortalStones.MouseLocation = new System.Drawing.Point(-1, -1);
            checkUseImmortalStones.Name = "checkUseImmortalStones";
            checkUseImmortalStones.Ripple = true;
            checkUseImmortalStones.Size = new System.Drawing.Size(170, 30);
            checkUseImmortalStones.TabIndex = 4;
            checkUseImmortalStones.Text = "Use immortal stones";
            checkUseImmortalStones.UseVisualStyleBackColor = false;
            checkUseImmortalStones.CheckedChanged += config_CheckedChange;
            // 
            // lblElixir
            // 
            lblElixir.ApplyGradient = false;
            lblElixir.AutoSize = true;
            lblElixir.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            lblElixir.Gradient = new System.Drawing.Color[]
    {
    System.Drawing.Color.Gray,
    System.Drawing.Color.Black
    };
            lblElixir.GradientAnimation = false;
            lblElixir.Location = new System.Drawing.Point(83, 70);
            lblElixir.Name = "lblElixir";
            lblElixir.Size = new System.Drawing.Size(44, 20);
            lblElixir.TabIndex = 5;
            lblElixir.Text = "Elixir:";
            // 
            // comboElixir
            // 
            comboElixir.BackColor = System.Drawing.Color.Black;
            comboElixir.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            comboElixir.DropDownHeight = 100;
            comboElixir.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboElixir.FormattingEnabled = true;
            comboElixir.IntegralHeight = false;
            comboElixir.ItemHeight = 17;
            comboElixir.Location = new System.Drawing.Point(140, 67);
            comboElixir.Name = "comboElixir";
            comboElixir.Radius = 5;
            comboElixir.ShadowDepth = 4F;
            comboElixir.Size = new System.Drawing.Size(193, 23);
            comboElixir.TabIndex = 6;
            comboElixir.SelectedIndexChanged += config_CheckedChange;
            // 
            // linkRefreshItemList
            // 
            linkRefreshItemList.ApplyGradient = false;
            linkRefreshItemList.AutoSize = true;
            linkRefreshItemList.Cursor = System.Windows.Forms.Cursors.Hand;
            linkRefreshItemList.Font = new System.Drawing.Font("Segoe UI", 15.75F);
            linkRefreshItemList.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            linkRefreshItemList.Gradient = new System.Drawing.Color[]
    {
    System.Drawing.Color.Gray,
    System.Drawing.Color.Black
    };
            linkRefreshItemList.GradientAnimation = false;
            linkRefreshItemList.Location = new System.Drawing.Point(328, 60);
            linkRefreshItemList.Name = "linkRefreshItemList";
            linkRefreshItemList.Size = new System.Drawing.Size(44, 37);
            linkRefreshItemList.TabIndex = 7;
            linkRefreshItemList.Text = "🗘";
            linkRefreshItemList.Click += linkRefreshItemList_Click;
            // 
            // checkUseAstralStones
            // 
            checkUseAstralStones.AutoSize = true;
            checkUseAstralStones.BackColor = System.Drawing.Color.Transparent;
            checkUseAstralStones.Depth = 0;
            checkUseAstralStones.Location = new System.Drawing.Point(141, 176);
            checkUseAstralStones.Margin = new System.Windows.Forms.Padding(0);
            checkUseAstralStones.MouseLocation = new System.Drawing.Point(-1, -1);
            checkUseAstralStones.Name = "checkUseAstralStones";
            checkUseAstralStones.Ripple = true;
            checkUseAstralStones.Size = new System.Drawing.Size(145, 30);
            checkUseAstralStones.TabIndex = 8;
            checkUseAstralStones.Text = "Use astral stones";
            checkUseAstralStones.UseVisualStyleBackColor = false;
            checkUseAstralStones.CheckedChanged += config_CheckedChange;
            // 
            // lblLuckyCount
            // 
            lblLuckyCount.ApplyGradient = false;
            lblLuckyCount.AutoSize = true;
            lblLuckyCount.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            lblLuckyCount.Gradient = new System.Drawing.Color[]
    {
    System.Drawing.Color.Gray,
    System.Drawing.Color.Black
    };
            lblLuckyCount.GradientAnimation = false;
            lblLuckyCount.Location = new System.Drawing.Point(328, 134);
            lblLuckyCount.Name = "lblLuckyCount";
            lblLuckyCount.Size = new System.Drawing.Size(24, 20);
            lblLuckyCount.TabIndex = 9;
            lblLuckyCount.Text = "x0";
            // 
            // lblImmortalCount
            // 
            lblImmortalCount.ApplyGradient = false;
            lblImmortalCount.AutoSize = true;
            lblImmortalCount.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            lblImmortalCount.Gradient = new System.Drawing.Color[]
    {
    System.Drawing.Color.Gray,
    System.Drawing.Color.Black
    };
            lblImmortalCount.GradientAnimation = false;
            lblImmortalCount.Location = new System.Drawing.Point(328, 157);
            lblImmortalCount.Name = "lblImmortalCount";
            lblImmortalCount.Size = new System.Drawing.Size(24, 20);
            lblImmortalCount.TabIndex = 9;
            lblImmortalCount.Text = "x0";
            // 
            // lblAstralCount
            // 
            lblAstralCount.ApplyGradient = false;
            lblAstralCount.AutoSize = true;
            lblAstralCount.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            lblAstralCount.Gradient = new System.Drawing.Color[]
    {
    System.Drawing.Color.Gray,
    System.Drawing.Color.Black
    };
            lblAstralCount.GradientAnimation = false;
            lblAstralCount.Location = new System.Drawing.Point(328, 180);
            lblAstralCount.Name = "lblAstralCount";
            lblAstralCount.Size = new System.Drawing.Size(24, 20);
            lblAstralCount.TabIndex = 9;
            lblAstralCount.Text = "x0";
            // 
            // checkUseSteadyStones
            // 
            checkUseSteadyStones.AutoSize = true;
            checkUseSteadyStones.BackColor = System.Drawing.Color.Transparent;
            checkUseSteadyStones.Depth = 0;
            checkUseSteadyStones.Location = new System.Drawing.Point(141, 199);
            checkUseSteadyStones.Margin = new System.Windows.Forms.Padding(0);
            checkUseSteadyStones.MouseLocation = new System.Drawing.Point(-1, -1);
            checkUseSteadyStones.Name = "checkUseSteadyStones";
            checkUseSteadyStones.Ripple = true;
            checkUseSteadyStones.Size = new System.Drawing.Size(152, 30);
            checkUseSteadyStones.TabIndex = 8;
            checkUseSteadyStones.Text = "Use steady stones";
            checkUseSteadyStones.UseVisualStyleBackColor = false;
            checkUseSteadyStones.CheckedChanged += config_CheckedChange;
            // 
            // lblSteadyStonesCount
            // 
            lblSteadyStonesCount.ApplyGradient = false;
            lblSteadyStonesCount.AutoSize = true;
            lblSteadyStonesCount.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            lblSteadyStonesCount.Gradient = new System.Drawing.Color[]
    {
    System.Drawing.Color.Gray,
    System.Drawing.Color.Black
    };
            lblSteadyStonesCount.GradientAnimation = false;
            lblSteadyStonesCount.Location = new System.Drawing.Point(328, 203);
            lblSteadyStonesCount.Name = "lblSteadyStonesCount";
            lblSteadyStonesCount.Size = new System.Drawing.Size(24, 20);
            lblSteadyStonesCount.TabIndex = 9;
            lblSteadyStonesCount.Text = "x0";
            // 
            // lblLuckyPowderCount
            // 
            lblLuckyPowderCount.ApplyGradient = false;
            lblLuckyPowderCount.AutoSize = true;
            lblLuckyPowderCount.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            lblLuckyPowderCount.Gradient = new System.Drawing.Color[]
    {
    System.Drawing.Color.Gray,
    System.Drawing.Color.Black
    };
            lblLuckyPowderCount.GradientAnimation = false;
            lblLuckyPowderCount.Location = new System.Drawing.Point(328, 111);
            lblLuckyPowderCount.Name = "lblLuckyPowderCount";
            lblLuckyPowderCount.Size = new System.Drawing.Size(24, 20);
            lblLuckyPowderCount.TabIndex = 11;
            lblLuckyPowderCount.Text = "x0";
            // 
            // checkStopLuckyPowder
            // 
            checkStopLuckyPowder.AutoSize = true;
            checkStopLuckyPowder.BackColor = System.Drawing.Color.Transparent;
            checkStopLuckyPowder.Checked = true;
            checkStopLuckyPowder.CheckState = System.Windows.Forms.CheckState.Checked;
            checkStopLuckyPowder.Depth = 0;
            checkStopLuckyPowder.Location = new System.Drawing.Point(141, 107);
            checkStopLuckyPowder.Margin = new System.Windows.Forms.Padding(0);
            checkStopLuckyPowder.MouseLocation = new System.Drawing.Point(-1, -1);
            checkStopLuckyPowder.Name = "checkStopLuckyPowder";
            checkStopLuckyPowder.Ripple = true;
            checkStopLuckyPowder.Size = new System.Drawing.Size(183, 30);
            checkStopLuckyPowder.TabIndex = 10;
            checkStopLuckyPowder.Text = "Stop if 0 lucky powder";
            checkStopLuckyPowder.UseVisualStyleBackColor = false;
            checkStopLuckyPowder.CheckedChanged += config_CheckedChange;
            // 
            // lblCurrentOptLevel
            // 
            lblCurrentOptLevel.ApplyGradient = false;
            lblCurrentOptLevel.AutoSize = true;
            lblCurrentOptLevel.BackColor = System.Drawing.Color.Transparent;
            lblCurrentOptLevel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            lblCurrentOptLevel.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            lblCurrentOptLevel.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            lblCurrentOptLevel.Gradient = new System.Drawing.Color[]
    {
    System.Drawing.Color.Gray,
    System.Drawing.Color.Black
    };
            lblCurrentOptLevel.GradientAnimation = false;
            lblCurrentOptLevel.Location = new System.Drawing.Point(255, 30);
            lblCurrentOptLevel.Name = "lblCurrentOptLevel";
            lblCurrentOptLevel.Size = new System.Drawing.Size(38, 27);
            lblCurrentOptLevel.TabIndex = 12;
            lblCurrentOptLevel.Text = "+0";
            // 
            // EnhanceSettingsView
            // 
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            Controls.Add(numMaxEnhancement);
            Controls.Add(lblLuckyPowderCount);
            Controls.Add(checkStopLuckyPowder);
            Controls.Add(lblSteadyStonesCount);
            Controls.Add(lblAstralCount);
            Controls.Add(lblImmortalCount);
            Controls.Add(lblLuckyCount);
            Controls.Add(checkUseSteadyStones);
            Controls.Add(checkUseAstralStones);
            Controls.Add(comboElixir);
            Controls.Add(lblElixir);
            Controls.Add(checkUseImmortalStones);
            Controls.Add(checkUseLuckyStones);
            Controls.Add(lblPlus);
            Controls.Add(lblMaxOptLevel);
            Controls.Add(linkRefreshItemList);
            Controls.Add(lblCurrentOptLevel);
            Enabled = false;
            Font = new System.Drawing.Font("Segoe UI", 9F);
            Name = "EnhanceSettingsView";
            Size = new System.Drawing.Size(438, 306);
            ResumeLayout(false);
            PerformLayout();

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
        private SDUI.Controls.NumUpDown numMaxEnhancement;
    }
}
