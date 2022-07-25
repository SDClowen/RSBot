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
            this.btnAccept = new SDUI.Controls.Button();
            this.btnCancel = new SDUI.Controls.Button();
            this.gbObjective = new SDUI.Controls.GroupBox();
            this.rbtn_Thief = new SDUI.Controls.Radio();
            this.rbtn_Trade = new SDUI.Controls.Radio();
            this.rbtn_Quest = new SDUI.Controls.Radio();
            this.rbtn_Hunting = new SDUI.Controls.Radio();
            this.groupBox2 = new SDUI.Controls.GroupBox();
            this.label2 = new SDUI.Controls.Label();
            this.label1 = new SDUI.Controls.Label();
            this.max_level = new SDUI.Controls.NumUpDown();
            this.min_level = new SDUI.Controls.NumUpDown();
            this.groupBox3 = new SDUI.Controls.GroupBox();
            this.label_partytype2 = new SDUI.Controls.Label();
            this.label5 = new SDUI.Controls.Label();
            this.label_partytype = new SDUI.Controls.Label();
            this.label3 = new SDUI.Controls.Label();
            this.groupBox4 = new SDUI.Controls.GroupBox();
            this.tb_Title = new SDUI.Controls.TextBox();
            this.groupBox5 = new SDUI.Controls.GroupBox();
            this.cb_AutoReform = new SDUI.Controls.CheckBox();
            this.cb_AutoAccept = new SDUI.Controls.CheckBox();
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
            this.btnAccept.Color = System.Drawing.Color.Transparent;
            this.btnAccept.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAccept.Location = new System.Drawing.Point(12, 323);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Radius = 2;
            this.btnAccept.Size = new System.Drawing.Size(75, 23);
            this.btnAccept.TabIndex = 0;
            this.btnAccept.Text = "Accept";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Color = System.Drawing.Color.Transparent;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(271, 323);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Radius = 2;
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // gbObjective
            // 
            this.gbObjective.BackColor = System.Drawing.Color.Transparent;
            this.gbObjective.Controls.Add(this.rbtn_Thief);
            this.gbObjective.Controls.Add(this.rbtn_Trade);
            this.gbObjective.Controls.Add(this.rbtn_Quest);
            this.gbObjective.Controls.Add(this.rbtn_Hunting);
            this.gbObjective.Location = new System.Drawing.Point(12, 12);
            this.gbObjective.Name = "gbObjective";
            this.gbObjective.Padding = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.gbObjective.Radius = 2;
            this.gbObjective.Size = new System.Drawing.Size(334, 52);
            this.gbObjective.TabIndex = 2;
            this.gbObjective.TabStop = false;
            this.gbObjective.Text = "Party Objective";
            // 
            // rbtn_Thief
            // 
            this.rbtn_Thief.AutoSize = true;
            this.rbtn_Thief.Checked = false;
            this.rbtn_Thief.Enabled = false;
            this.rbtn_Thief.Location = new System.Drawing.Point(238, 31);
            this.rbtn_Thief.Name = "rbtn_Thief";
            this.rbtn_Thief.Size = new System.Drawing.Size(93, 15);
            this.rbtn_Thief.TabIndex = 0;
            this.rbtn_Thief.TabStop = true;
            this.rbtn_Thief.Tag = "4";
            this.rbtn_Thief.Text = "Thief Union";
            this.rbtn_Thief.CheckedChanged += new System.EventHandler(this.radioCheckedChanged);
            // 
            // rbtn_Trade
            // 
            this.rbtn_Trade.AutoSize = true;
            this.rbtn_Trade.Checked = false;
            this.rbtn_Trade.Enabled = false;
            this.rbtn_Trade.Location = new System.Drawing.Point(149, 31);
            this.rbtn_Trade.Name = "rbtn_Trade";
            this.rbtn_Trade.Size = new System.Drawing.Size(95, 15);
            this.rbtn_Trade.TabIndex = 0;
            this.rbtn_Trade.TabStop = true;
            this.rbtn_Trade.Tag = "3";
            this.rbtn_Trade.Text = "Trade Union";
            this.rbtn_Trade.CheckedChanged += new System.EventHandler(this.radioCheckedChanged);
            // 
            // rbtn_Quest
            // 
            this.rbtn_Quest.AutoSize = true;
            this.rbtn_Quest.Checked = false;
            this.rbtn_Quest.Location = new System.Drawing.Point(87, 31);
            this.rbtn_Quest.Name = "rbtn_Quest";
            this.rbtn_Quest.Size = new System.Drawing.Size(63, 15);
            this.rbtn_Quest.TabIndex = 0;
            this.rbtn_Quest.TabStop = true;
            this.rbtn_Quest.Tag = "2";
            this.rbtn_Quest.Text = "Quest";
            this.rbtn_Quest.CheckedChanged += new System.EventHandler(this.radioCheckedChanged);
            // 
            // rbtn_Hunting
            // 
            this.rbtn_Hunting.AutoSize = true;
            this.rbtn_Hunting.Checked = false;
            this.rbtn_Hunting.Location = new System.Drawing.Point(12, 31);
            this.rbtn_Hunting.Name = "rbtn_Hunting";
            this.rbtn_Hunting.Size = new System.Drawing.Size(76, 15);
            this.rbtn_Hunting.TabIndex = 0;
            this.rbtn_Hunting.TabStop = true;
            this.rbtn_Hunting.Tag = "1";
            this.rbtn_Hunting.Text = "Hunting";
            this.rbtn_Hunting.CheckedChanged += new System.EventHandler(this.radioCheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.max_level);
            this.groupBox2.Controls.Add(this.min_level);
            this.groupBox2.Location = new System.Drawing.Point(12, 70);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.groupBox2.Radius = 2;
            this.groupBox2.Size = new System.Drawing.Size(334, 63);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Level Restrict";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(172, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Max.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(26, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Min.";
            // 
            // max_level
            // 
            this.max_level.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.max_level.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.max_level.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.max_level.Location = new System.Drawing.Point(209, 32);
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
            this.min_level.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.min_level.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.min_level.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.min_level.Location = new System.Drawing.Point(63, 32);
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
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.label_partytype2);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label_partytype);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Location = new System.Drawing.Point(12, 139);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.groupBox3.Radius = 2;
            this.groupBox3.Size = new System.Drawing.Size(334, 57);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Party Type";
            // 
            // label_partytype2
            // 
            this.label_partytype2.AutoSize = true;
            this.label_partytype2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label_partytype2.Location = new System.Drawing.Point(206, 32);
            this.label_partytype2.Name = "label_partytype2";
            this.label_partytype2.Size = new System.Drawing.Size(92, 15);
            this.label_partytype2.TabIndex = 1;
            this.label_partytype2.Text = "Item Auto Share";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label5.Location = new System.Drawing.Point(181, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(19, 21);
            this.label5.TabIndex = 0;
            this.label5.Text = "◊";
            // 
            // label_partytype
            // 
            this.label_partytype.AutoSize = true;
            this.label_partytype.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label_partytype.Location = new System.Drawing.Point(63, 32);
            this.label_partytype.Name = "label_partytype";
            this.label_partytype.Size = new System.Drawing.Size(87, 15);
            this.label_partytype.TabIndex = 1;
            this.label_partytype.Text = "Exp Auto Share";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(40, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(19, 21);
            this.label3.TabIndex = 0;
            this.label3.Text = "◊";
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.Transparent;
            this.groupBox4.Controls.Add(this.tb_Title);
            this.groupBox4.Location = new System.Drawing.Point(12, 202);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.groupBox4.Radius = 2;
            this.groupBox4.Size = new System.Drawing.Size(334, 55);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Title";
            // 
            // tb_Title
            // 
            this.tb_Title.Location = new System.Drawing.Point(12, 28);
            this.tb_Title.MaxLength = 32767;
            this.tb_Title.MultiLine = false;
            this.tb_Title.Name = "tb_Title";
            this.tb_Title.Size = new System.Drawing.Size(312, 21);
            this.tb_Title.TabIndex = 0;
            this.tb_Title.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.tb_Title.UseSystemPasswordChar = false;
            // 
            // groupBox5
            // 
            this.groupBox5.BackColor = System.Drawing.Color.Transparent;
            this.groupBox5.Controls.Add(this.cb_AutoReform);
            this.groupBox5.Controls.Add(this.cb_AutoAccept);
            this.groupBox5.Location = new System.Drawing.Point(12, 263);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.groupBox5.Radius = 2;
            this.groupBox5.Size = new System.Drawing.Size(334, 54);
            this.groupBox5.TabIndex = 3;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Config";
            // 
            // cb_AutoReform
            // 
            this.cb_AutoReform.AutoSize = true;
            this.cb_AutoReform.BackColor = System.Drawing.Color.Transparent;
            this.cb_AutoReform.Checked = false;
            this.cb_AutoReform.Location = new System.Drawing.Point(12, 32);
            this.cb_AutoReform.Name = "cb_AutoReform";
            this.cb_AutoReform.Size = new System.Drawing.Size(91, 15);
            this.cb_AutoReform.TabIndex = 0;
            this.cb_AutoReform.Text = "Auto Reform";
            this.cb_AutoReform.CheckedChanged += new System.EventHandler(this.cb_AutoReform_CheckedChanged);
            // 
            // cb_AutoAccept
            // 
            this.cb_AutoAccept.AutoSize = true;
            this.cb_AutoAccept.BackColor = System.Drawing.Color.Transparent;
            this.cb_AutoAccept.Checked = false;
            this.cb_AutoAccept.Location = new System.Drawing.Point(232, 32);
            this.cb_AutoAccept.Name = "cb_AutoAccept";
            this.cb_AutoAccept.Size = new System.Drawing.Size(89, 15);
            this.cb_AutoAccept.TabIndex = 0;
            this.cb_AutoAccept.Text = "Auto Accept";
            this.cb_AutoAccept.CheckedChanged += new System.EventHandler(this.cb_AutoAccept_CheckedChanged);
            // 
            // AutoFormParty
            // 
            this.AcceptButton = this.btnAccept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(360, 355);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.gbObjective);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAccept);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(360, 355);
            this.Name = "AutoFormParty";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Party Matching";
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
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private SDUI.Controls.Button btnAccept;
        private SDUI.Controls.Button btnCancel;
        private SDUI.Controls.GroupBox gbObjective;
        private SDUI.Controls.Radio rbtn_Quest;
        private SDUI.Controls.Radio rbtn_Hunting;
        private SDUI.Controls.Radio rbtn_Trade;
        private SDUI.Controls.Radio rbtn_Thief;
        private SDUI.Controls.GroupBox groupBox2;
        private SDUI.Controls.Label label2;
        private SDUI.Controls.Label label1;
        private SDUI.Controls.NumUpDown max_level;
        private SDUI.Controls.NumUpDown min_level;
        private SDUI.Controls.GroupBox groupBox3;
        private SDUI.Controls.Label label_partytype2;
        private SDUI.Controls.Label label5;
        private SDUI.Controls.Label label_partytype;
        private SDUI.Controls.Label label3;
        private SDUI.Controls.GroupBox groupBox4;
        private SDUI.Controls.TextBox tb_Title;
        private SDUI.Controls.GroupBox groupBox5;
        private SDUI.Controls.CheckBox cb_AutoReform;
        private SDUI.Controls.CheckBox cb_AutoAccept;
    }
}