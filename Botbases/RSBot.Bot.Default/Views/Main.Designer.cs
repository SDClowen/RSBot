namespace RSBot.Bot.Default.Views
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
            System.Windows.Forms.ListViewGroup listViewGroup4 = new System.Windows.Forms.ListViewGroup("Avoid", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup5 = new System.Windows.Forms.ListViewGroup("Prefer", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup6 = new System.Windows.Forms.ListViewGroup("No custom behavior", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewItem listViewItem10 = new System.Windows.Forms.ListViewItem("General");
            System.Windows.Forms.ListViewItem listViewItem11 = new System.Windows.Forms.ListViewItem("Champion");
            System.Windows.Forms.ListViewItem listViewItem12 = new System.Windows.Forms.ListViewItem("Giant");
            System.Windows.Forms.ListViewItem listViewItem13 = new System.Windows.Forms.ListViewItem("General (party)");
            System.Windows.Forms.ListViewItem listViewItem14 = new System.Windows.Forms.ListViewItem("Champion (party)");
            System.Windows.Forms.ListViewItem listViewItem15 = new System.Windows.Forms.ListViewItem("Giant (party)");
            System.Windows.Forms.ListViewItem listViewItem16 = new System.Windows.Forms.ListViewItem("Unique");
            System.Windows.Forms.ListViewItem listViewItem17 = new System.Windows.Forms.ListViewItem("Strong");
            System.Windows.Forms.ListViewItem listViewItem18 = new System.Windows.Forms.ListViewItem("Elite");
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.radioWalkAround = new System.Windows.Forms.RadioButton();
            this.radioCenter = new System.Windows.Forms.RadioButton();
            this.btnGetCurrent = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtRadius = new System.Windows.Forms.TextBox();
            this.txtYCoord = new System.Windows.Forms.TextBox();
            this.txtXCoord = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lvAvoidance = new System.Windows.Forms.ListView();
            this.ctxAvoidance = new System.Windows.Forms.ContextMenuStrip();
            this.btnAvoid = new System.Windows.Forms.ToolStripMenuItem();
            this.btnPrefer = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnNoCustomBehavior = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.checkUseSpeedDrug = new System.Windows.Forms.CheckBox();
            this.checkCastBuffs = new System.Windows.Forms.CheckBox();
            this.checkUseMount = new System.Windows.Forms.CheckBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtWalkscript = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.checkBerzerkWhenFull = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.numBerzerkMonsterAmount = new System.Windows.Forms.NumericUpDown();
            this.checkBerzerkAvoidance = new System.Windows.Forms.CheckBox();
            this.checkBerzerkMonsterAmount = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.ctxAvoidance.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numBerzerkMonsterAmount)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.radioWalkAround);
            this.groupBox1.Controls.Add(this.radioCenter);
            this.groupBox1.Controls.Add(this.btnGetCurrent);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtRadius);
            this.groupBox1.Controls.Add(this.txtYCoord);
            this.groupBox1.Controls.Add(this.txtXCoord);
            this.groupBox1.Location = new System.Drawing.Point(23, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(221, 228);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Area";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 156);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(143, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "If there is no enemy nearby...";
            // 
            // label5
            // 
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label5.Location = new System.Drawing.Point(11, 142);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(200, 2);
            this.label5.TabIndex = 6;
            // 
            // radioWalkAround
            // 
            this.radioWalkAround.AutoSize = true;
            this.radioWalkAround.Location = new System.Drawing.Point(35, 199);
            this.radioWalkAround.Name = "radioWalkAround";
            this.radioWalkAround.Size = new System.Drawing.Size(86, 17);
            this.radioWalkAround.TabIndex = 5;
            this.radioWalkAround.TabStop = true;
            this.radioWalkAround.Text = "Walk around";
            this.radioWalkAround.UseVisualStyleBackColor = true;
            this.radioWalkAround.CheckedChanged += new System.EventHandler(this.radioWalkAround_CheckedChanged);
            // 
            // radioCenter
            // 
            this.radioCenter.AutoSize = true;
            this.radioCenter.Checked = true;
            this.radioCenter.Location = new System.Drawing.Point(35, 176);
            this.radioCenter.Name = "radioCenter";
            this.radioCenter.Size = new System.Drawing.Size(111, 17);
            this.radioCenter.TabIndex = 4;
            this.radioCenter.TabStop = true;
            this.radioCenter.Text = "Go back to center";
            this.radioCenter.UseVisualStyleBackColor = true;
            this.radioCenter.CheckedChanged += new System.EventHandler(this.radioCenter_CheckedChanged);
            // 
            // btnGetCurrent
            // 
            this.btnGetCurrent.Location = new System.Drawing.Point(76, 103);
            this.btnGetCurrent.Name = "btnGetCurrent";
            this.btnGetCurrent.Size = new System.Drawing.Size(97, 23);
            this.btnGetCurrent.TabIndex = 3;
            this.btnGetCurrent.Text = "Current";
            this.btnGetCurrent.UseVisualStyleBackColor = true;
            this.btnGetCurrent.Click += new System.EventHandler(this.btnGetCurrent_Click);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(11, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Radius:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(53, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Y:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(53, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "X:";
            // 
            // txtRadius
            // 
            this.txtRadius.Location = new System.Drawing.Point(76, 77);
            this.txtRadius.Name = "txtRadius";
            this.txtRadius.Size = new System.Drawing.Size(97, 20);
            this.txtRadius.TabIndex = 0;
            this.txtRadius.Text = "50";
            this.txtRadius.TextChanged += new System.EventHandler(this.txtRadius_TextChanged);
            // 
            // txtYCoord
            // 
            this.txtYCoord.Location = new System.Drawing.Point(76, 51);
            this.txtYCoord.Name = "txtYCoord";
            this.txtYCoord.Size = new System.Drawing.Size(97, 20);
            this.txtYCoord.TabIndex = 0;
            this.txtYCoord.TextChanged += new System.EventHandler(this.txtYCoord_TextChanged);
            // 
            // txtXCoord
            // 
            this.txtXCoord.Location = new System.Drawing.Point(76, 25);
            this.txtXCoord.Name = "txtXCoord";
            this.txtXCoord.Size = new System.Drawing.Size(97, 20);
            this.txtXCoord.TabIndex = 0;
            this.txtXCoord.TextChanged += new System.EventHandler(this.txtXCoord_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lvAvoidance);
            this.groupBox2.Location = new System.Drawing.Point(23, 250);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(221, 214);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Avoidance";
            // 
            // lvAvoidance
            // 
            this.lvAvoidance.ContextMenuStrip = this.ctxAvoidance;
            this.lvAvoidance.FullRowSelect = true;
            listViewGroup4.Header = "Avoid";
            listViewGroup4.Name = "grpAvoid";
            listViewGroup5.Header = "Prefer";
            listViewGroup5.Name = "grpPrefer";
            listViewGroup6.Header = "No custom behavior";
            listViewGroup6.Name = "grpNone";
            this.lvAvoidance.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup4,
            listViewGroup5,
            listViewGroup6});
            this.lvAvoidance.HideSelection = false;
            listViewItem10.Group = listViewGroup6;
            listViewItem11.Group = listViewGroup6;
            listViewItem12.Group = listViewGroup6;
            listViewItem13.Group = listViewGroup6;
            listViewItem14.Group = listViewGroup6;
            listViewItem15.Group = listViewGroup6;
            listViewItem16.Group = listViewGroup6;
            listViewItem17.Group = listViewGroup6;
            listViewItem18.Group = listViewGroup6;
            this.lvAvoidance.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem10,
            listViewItem11,
            listViewItem12,
            listViewItem13,
            listViewItem14,
            listViewItem15,
            listViewItem16,
            listViewItem17,
            listViewItem18});
            this.lvAvoidance.Location = new System.Drawing.Point(11, 19);
            this.lvAvoidance.Name = "lvAvoidance";
            this.lvAvoidance.Size = new System.Drawing.Size(200, 189);
            this.lvAvoidance.TabIndex = 5;
            this.lvAvoidance.TileSize = new System.Drawing.Size(168, 16);
            this.lvAvoidance.UseCompatibleStateImageBehavior = false;
            this.lvAvoidance.View = System.Windows.Forms.View.Tile;
            // 
            // ctxAvoidance
            // 
            this.ctxAvoidance.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAvoid,
            this.btnPrefer,
            this.toolStripSeparator1,
            this.btnNoCustomBehavior});
            this.ctxAvoidance.Name = "ctxAvoidance";
            this.ctxAvoidance.Size = new System.Drawing.Size(183, 76);
            // 
            // btnAvoid
            // 
            this.btnAvoid.Name = "btnAvoid";
            this.btnAvoid.Size = new System.Drawing.Size(182, 22);
            this.btnAvoid.Text = "Avoid";
            this.btnAvoid.Click += new System.EventHandler(this.btnAvoid_Click);
            // 
            // btnPrefer
            // 
            this.btnPrefer.Name = "btnPrefer";
            this.btnPrefer.Size = new System.Drawing.Size(182, 22);
            this.btnPrefer.Text = "Prefer";
            this.btnPrefer.Click += new System.EventHandler(this.btnPrefer_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(179, 6);
            // 
            // btnNoCustomBehavior
            // 
            this.btnNoCustomBehavior.Name = "btnNoCustomBehavior";
            this.btnNoCustomBehavior.Size = new System.Drawing.Size(182, 22);
            this.btnNoCustomBehavior.Text = "No custom behavior";
            this.btnNoCustomBehavior.Click += new System.EventHandler(this.btnNoCustomBehavior_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.checkUseSpeedDrug);
            this.groupBox3.Controls.Add(this.checkCastBuffs);
            this.groupBox3.Controls.Add(this.checkUseMount);
            this.groupBox3.Controls.Add(this.btnBrowse);
            this.groupBox3.Controls.Add(this.txtWalkscript);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Location = new System.Drawing.Point(250, 16);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(512, 157);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Back to training";
            // 
            // checkUseSpeedDrug
            // 
            this.checkUseSpeedDrug.AutoSize = true;
            this.checkUseSpeedDrug.Location = new System.Drawing.Point(34, 127);
            this.checkUseSpeedDrug.Name = "checkUseSpeedDrug";
            this.checkUseSpeedDrug.Size = new System.Drawing.Size(101, 17);
            this.checkUseSpeedDrug.TabIndex = 7;
            this.checkUseSpeedDrug.Text = "Use speed drug";
            this.checkUseSpeedDrug.UseVisualStyleBackColor = true;
            this.checkUseSpeedDrug.CheckedChanged += new System.EventHandler(this.checkUseSpeedDrug_CheckedChanged);
            // 
            // checkCastBuffs
            // 
            this.checkCastBuffs.AutoSize = true;
            this.checkCastBuffs.Location = new System.Drawing.Point(34, 104);
            this.checkCastBuffs.Name = "checkCastBuffs";
            this.checkCastBuffs.Size = new System.Drawing.Size(74, 17);
            this.checkCastBuffs.TabIndex = 6;
            this.checkCastBuffs.Text = "Cast Buffs";
            this.checkCastBuffs.UseVisualStyleBackColor = true;
            this.checkCastBuffs.CheckedChanged += new System.EventHandler(this.checkCastBuffs_CheckedChanged);
            // 
            // checkUseMount
            // 
            this.checkUseMount.AutoSize = true;
            this.checkUseMount.Location = new System.Drawing.Point(34, 80);
            this.checkUseMount.Name = "checkUseMount";
            this.checkUseMount.Size = new System.Drawing.Size(130, 17);
            this.checkUseMount.TabIndex = 3;
            this.checkUseMount.Text = "Use mount if available";
            this.checkUseMount.UseVisualStyleBackColor = true;
            this.checkUseMount.CheckedChanged += new System.EventHandler(this.checkUseMount_CheckedChanged);
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(439, 47);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(57, 21);
            this.btnBrowse.TabIndex = 3;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txtWalkscript
            // 
            this.txtWalkscript.BackColor = System.Drawing.Color.White;
            this.txtWalkscript.Location = new System.Drawing.Point(21, 47);
            this.txtWalkscript.Name = "txtWalkscript";
            this.txtWalkscript.ReadOnly = true;
            this.txtWalkscript.Size = new System.Drawing.Size(412, 20);
            this.txtWalkscript.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Walkscript:";
            // 
            // checkBerzerkWhenFull
            // 
            this.checkBerzerkWhenFull.AutoSize = true;
            this.checkBerzerkWhenFull.Location = new System.Drawing.Point(21, 27);
            this.checkBerzerkWhenFull.Name = "checkBerzerkWhenFull";
            this.checkBerzerkWhenFull.Size = new System.Drawing.Size(163, 17);
            this.checkBerzerkWhenFull.TabIndex = 4;
            this.checkBerzerkWhenFull.Text = "Enter berzerk mode when full";
            this.checkBerzerkWhenFull.UseVisualStyleBackColor = true;
            this.checkBerzerkWhenFull.CheckedChanged += new System.EventHandler(this.checkBerzerkWhenFull_CheckedChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.numBerzerkMonsterAmount);
            this.groupBox4.Controls.Add(this.checkBerzerkAvoidance);
            this.groupBox4.Controls.Add(this.checkBerzerkMonsterAmount);
            this.groupBox4.Controls.Add(this.checkBerzerkWhenFull);
            this.groupBox4.Location = new System.Drawing.Point(250, 179);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(512, 100);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Berzerk";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(236, 50);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "monsters";
            // 
            // numBerzerkMonsterAmount
            // 
            this.numBerzerkMonsterAmount.Location = new System.Drawing.Point(193, 47);
            this.numBerzerkMonsterAmount.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numBerzerkMonsterAmount.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numBerzerkMonsterAmount.Name = "numBerzerkMonsterAmount";
            this.numBerzerkMonsterAmount.Size = new System.Drawing.Size(37, 20);
            this.numBerzerkMonsterAmount.TabIndex = 6;
            this.numBerzerkMonsterAmount.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numBerzerkMonsterAmount.ValueChanged += new System.EventHandler(this.numBerzerkMonsterAmount_ValueChanged);
            // 
            // checkBerzerkAvoidance
            // 
            this.checkBerzerkAvoidance.AutoSize = true;
            this.checkBerzerkAvoidance.Location = new System.Drawing.Point(21, 71);
            this.checkBerzerkAvoidance.Name = "checkBerzerkAvoidance";
            this.checkBerzerkAvoidance.Size = new System.Drawing.Size(303, 17);
            this.checkBerzerkAvoidance.TabIndex = 5;
            this.checkBerzerkAvoidance.Text = "If being attacked by a monster type that should be avoided";
            this.checkBerzerkAvoidance.UseVisualStyleBackColor = true;
            this.checkBerzerkAvoidance.CheckedChanged += new System.EventHandler(this.checkBerzerkAvoidance_CheckedChanged);
            // 
            // checkBerzerkMonsterAmount
            // 
            this.checkBerzerkMonsterAmount.AutoSize = true;
            this.checkBerzerkMonsterAmount.Location = new System.Drawing.Point(21, 48);
            this.checkBerzerkMonsterAmount.Name = "checkBerzerkMonsterAmount";
            this.checkBerzerkMonsterAmount.Size = new System.Drawing.Size(162, 17);
            this.checkBerzerkMonsterAmount.TabIndex = 4;
            this.checkBerzerkMonsterAmount.Text = "Being attacked by more than";
            this.checkBerzerkMonsterAmount.UseVisualStyleBackColor = true;
            this.checkBerzerkMonsterAmount.CheckedChanged += new System.EventHandler(this.checkBerzerkMonsterAmount_CheckedChanged);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox4);
            this.Name = "Main";
            this.Size = new System.Drawing.Size(765, 467);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ctxAvoidance.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numBerzerkMonsterAmount)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRadius;
        private System.Windows.Forms.TextBox txtYCoord;
        private System.Windows.Forms.TextBox txtXCoord;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnGetCurrent;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox txtWalkscript;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkUseMount;
        private System.Windows.Forms.RadioButton radioWalkAround;
        private System.Windows.Forms.RadioButton radioCenter;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox checkUseSpeedDrug;
        private System.Windows.Forms.CheckBox checkCastBuffs;
        private System.Windows.Forms.CheckBox checkBerzerkWhenFull;
        private System.Windows.Forms.ListView lvAvoidance;
        private System.Windows.Forms.ContextMenuStrip ctxAvoidance;
        private System.Windows.Forms.ToolStripMenuItem btnAvoid;
        private System.Windows.Forms.ToolStripMenuItem btnPrefer;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem btnNoCustomBehavior;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.NumericUpDown numBerzerkMonsterAmount;
        private System.Windows.Forms.CheckBox checkBerzerkAvoidance;
        private System.Windows.Forms.CheckBox checkBerzerkMonsterAmount;
        private System.Windows.Forms.Label label7;
    }
}
