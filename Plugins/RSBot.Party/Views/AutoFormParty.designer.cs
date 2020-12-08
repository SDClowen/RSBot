namespace RSBot.Party.Views
{
    partial class AutoFormParty
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
            this.btnAccept = new Theme.Material.Button();
            this.btnCancel = new Theme.Material.Button();
            this.gbObjective = new System.Windows.Forms.GroupBox();
            this.rbtn_Thief = new System.Windows.Forms.RadioButton();
            this.rbtn_Trade = new System.Windows.Forms.RadioButton();
            this.rbtn_Quest = new System.Windows.Forms.RadioButton();
            this.rbtn_Hunting = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.max_level = new System.Windows.Forms.NumericUpDown();
            this.min_level = new System.Windows.Forms.NumericUpDown();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label_partytype2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label_partytype = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.tb_Title = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.cb_AutoReform = new System.Windows.Forms.CheckBox();
            this.cb_AutoAccept = new System.Windows.Forms.CheckBox();
            this.gbObjective.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.max_level)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.min_level)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAccept
            // 
            this.btnAccept.Depth = 0;
            this.btnAccept.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAccept.Icon = null;
            this.btnAccept.Location = new System.Drawing.Point(12, 292);
            this.btnAccept.MouseState = Theme.IMatMouseState.HOVER;
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Primary = true;
            this.btnAccept.Raised = true;
            this.btnAccept.Size = new System.Drawing.Size(75, 23);
            this.btnAccept.TabIndex = 0;
            this.btnAccept.Text = "Accept";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Depth = 0;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Icon = null;
            this.btnCancel.Location = new System.Drawing.Point(271, 292);
            this.btnCancel.MouseState = Theme.IMatMouseState.HOVER;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Primary = false;
            this.btnCancel.Raised = false;
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // gbObjective
            // 
            this.gbObjective.Controls.Add(this.rbtn_Thief);
            this.gbObjective.Controls.Add(this.rbtn_Trade);
            this.gbObjective.Controls.Add(this.rbtn_Quest);
            this.gbObjective.Controls.Add(this.rbtn_Hunting);
            this.gbObjective.Location = new System.Drawing.Point(12, 12);
            this.gbObjective.Name = "gbObjective";
            this.gbObjective.Size = new System.Drawing.Size(334, 46);
            this.gbObjective.TabIndex = 2;
            this.gbObjective.TabStop = false;
            this.gbObjective.Text = "Party Objective";
            // 
            // rbtn_Thief
            // 
            this.rbtn_Thief.AutoSize = true;
            this.rbtn_Thief.Enabled = false;
            this.rbtn_Thief.Location = new System.Drawing.Point(232, 22);
            this.rbtn_Thief.Name = "rbtn_Thief";
            this.rbtn_Thief.Size = new System.Drawing.Size(87, 19);
            this.rbtn_Thief.TabIndex = 0;
            this.rbtn_Thief.TabStop = true;
            this.rbtn_Thief.Tag = "4";
            this.rbtn_Thief.Text = "Thief Union";
            this.rbtn_Thief.UseVisualStyleBackColor = true;
            this.rbtn_Thief.CheckedChanged += new System.EventHandler(this.radioCheckedChanged);
            // 
            // rbtn_Trade
            // 
            this.rbtn_Trade.AutoSize = true;
            this.rbtn_Trade.Enabled = false;
            this.rbtn_Trade.Location = new System.Drawing.Point(143, 22);
            this.rbtn_Trade.Name = "rbtn_Trade";
            this.rbtn_Trade.Size = new System.Drawing.Size(89, 19);
            this.rbtn_Trade.TabIndex = 0;
            this.rbtn_Trade.TabStop = true;
            this.rbtn_Trade.Tag = "3";
            this.rbtn_Trade.Text = "Trade Union";
            this.rbtn_Trade.UseVisualStyleBackColor = true;
            this.rbtn_Trade.CheckedChanged += new System.EventHandler(this.radioCheckedChanged);
            // 
            // rbtn_Quest
            // 
            this.rbtn_Quest.AutoSize = true;
            this.rbtn_Quest.Location = new System.Drawing.Point(81, 22);
            this.rbtn_Quest.Name = "rbtn_Quest";
            this.rbtn_Quest.Size = new System.Drawing.Size(56, 19);
            this.rbtn_Quest.TabIndex = 0;
            this.rbtn_Quest.TabStop = true;
            this.rbtn_Quest.Tag = "2";
            this.rbtn_Quest.Text = "Quest";
            this.rbtn_Quest.UseVisualStyleBackColor = true;
            this.rbtn_Quest.CheckedChanged += new System.EventHandler(this.radioCheckedChanged);
            // 
            // rbtn_Hunting
            // 
            this.rbtn_Hunting.AutoSize = true;
            this.rbtn_Hunting.Location = new System.Drawing.Point(6, 22);
            this.rbtn_Hunting.Name = "rbtn_Hunting";
            this.rbtn_Hunting.Size = new System.Drawing.Size(69, 19);
            this.rbtn_Hunting.TabIndex = 0;
            this.rbtn_Hunting.TabStop = true;
            this.rbtn_Hunting.Tag = "1";
            this.rbtn_Hunting.Text = "Hunting";
            this.rbtn_Hunting.UseVisualStyleBackColor = true;
            this.rbtn_Hunting.CheckedChanged += new System.EventHandler(this.radioCheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.max_level);
            this.groupBox2.Controls.Add(this.min_level);
            this.groupBox2.Location = new System.Drawing.Point(12, 64);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(334, 45);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Level Restrict";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(174, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Max.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Min.";
            // 
            // max_level
            // 
            this.max_level.Location = new System.Drawing.Point(211, 16);
            this.max_level.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.max_level.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.max_level.Name = "max_level";
            this.max_level.Size = new System.Drawing.Size(96, 23);
            this.max_level.TabIndex = 0;
            this.max_level.Value = new decimal(new int[] {
            140,
            0,
            0,
            0});
            // 
            // min_level
            // 
            this.min_level.Location = new System.Drawing.Point(65, 16);
            this.min_level.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.min_level.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.min_level.Name = "min_level";
            this.min_level.Size = new System.Drawing.Size(96, 23);
            this.min_level.TabIndex = 0;
            this.min_level.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label_partytype2);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label_partytype);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Location = new System.Drawing.Point(12, 115);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(334, 45);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Party Type";
            // 
            // label_partytype2
            // 
            this.label_partytype2.AutoSize = true;
            this.label_partytype2.Location = new System.Drawing.Point(208, 22);
            this.label_partytype2.Name = "label_partytype2";
            this.label_partytype2.Size = new System.Drawing.Size(92, 15);
            this.label_partytype2.TabIndex = 1;
            this.label_partytype2.Text = "Item Auto Share";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label5.Location = new System.Drawing.Point(181, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(24, 21);
            this.label5.TabIndex = 0;
            this.label5.Text = "🟆";
            // 
            // label_partytype
            // 
            this.label_partytype.AutoSize = true;
            this.label_partytype.Location = new System.Drawing.Point(62, 22);
            this.label_partytype.Name = "label_partytype";
            this.label_partytype.Size = new System.Drawing.Size(86, 15);
            this.label_partytype.TabIndex = 1;
            this.label_partytype.Text = "Exp Auto Share";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(35, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 21);
            this.label3.TabIndex = 0;
            this.label3.Text = "🟆";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.tb_Title);
            this.groupBox4.Location = new System.Drawing.Point(12, 166);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(334, 55);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Title";
            // 
            // tb_Title
            // 
            this.tb_Title.Location = new System.Drawing.Point(12, 22);
            this.tb_Title.Name = "tb_Title";
            this.tb_Title.Size = new System.Drawing.Size(312, 23);
            this.tb_Title.TabIndex = 0;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.cb_AutoReform);
            this.groupBox5.Controls.Add(this.cb_AutoAccept);
            this.groupBox5.Location = new System.Drawing.Point(12, 227);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(334, 55);
            this.groupBox5.TabIndex = 3;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Config";
            // 
            // cb_AutoReform
            // 
            this.cb_AutoReform.AutoSize = true;
            this.cb_AutoReform.Location = new System.Drawing.Point(12, 22);
            this.cb_AutoReform.Name = "cb_AutoReform";
            this.cb_AutoReform.Size = new System.Drawing.Size(94, 19);
            this.cb_AutoReform.TabIndex = 0;
            this.cb_AutoReform.Text = "Auto Reform";
            this.cb_AutoReform.UseVisualStyleBackColor = true;
            this.cb_AutoReform.CheckedChanged += new System.EventHandler(this.cb_AutoReform_CheckedChanged);
            // 
            // cb_AutoAccept
            // 
            this.cb_AutoAccept.AutoSize = true;
            this.cb_AutoAccept.Location = new System.Drawing.Point(232, 22);
            this.cb_AutoAccept.Name = "cb_AutoAccept";
            this.cb_AutoAccept.Size = new System.Drawing.Size(92, 19);
            this.cb_AutoAccept.TabIndex = 0;
            this.cb_AutoAccept.Text = "Auto Accept";
            this.cb_AutoAccept.UseVisualStyleBackColor = true;
            this.cb_AutoAccept.CheckedChanged += new System.EventHandler(this.cb_AutoAccept_CheckedChanged);
            // 
            // AutoFormParty
            // 
            this.AcceptButton = this.btnAccept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(361, 327);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.gbObjective);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAccept);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(377, 362);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(377, 362);
            this.Name = "AutoFormParty";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "  ";
            this.Load += new System.EventHandler(this.AutoFormParty_Load);
            this.gbObjective.ResumeLayout(false);
            this.gbObjective.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.max_level)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.min_level)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Theme.Material.Button btnAccept;
        private Theme.Material.Button btnCancel;
        private System.Windows.Forms.GroupBox gbObjective;
        private System.Windows.Forms.RadioButton rbtn_Quest;
        private System.Windows.Forms.RadioButton rbtn_Hunting;
        private System.Windows.Forms.RadioButton rbtn_Trade;
        private System.Windows.Forms.RadioButton rbtn_Thief;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown max_level;
        private System.Windows.Forms.NumericUpDown min_level;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label_partytype2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label_partytype;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox tb_Title;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.CheckBox cb_AutoReform;
        private System.Windows.Forms.CheckBox cb_AutoAccept;
    }
}