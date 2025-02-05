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
            btnAccept = new System.Windows.Forms.Button();
            btnCancel = new System.Windows.Forms.Button();
            gbObjective = new System.Windows.Forms.GroupBox();
            rbtn_Thief = new System.Windows.Forms.RadioButton();
            rbtn_Trade = new System.Windows.Forms.RadioButton();
            rbtn_Quest = new System.Windows.Forms.RadioButton();
            rbtn_Hunting = new System.Windows.Forms.RadioButton();
            groupBox2 = new System.Windows.Forms.GroupBox();
            label2 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            max_level = new System.Windows.Forms.NumericUpDown();
            min_level = new System.Windows.Forms.NumericUpDown();
            groupBox3 = new System.Windows.Forms.GroupBox();
            label_partytype2 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label_partytype = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            groupBox4 = new System.Windows.Forms.GroupBox();
            tb_Title = new System.Windows.Forms.TextBox();
            groupBox5 = new System.Windows.Forms.GroupBox();
            cb_AutoReform = new System.Windows.Forms.CheckBox();
            cb_AutoAccept = new System.Windows.Forms.CheckBox();
            gbObjective.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)max_level).BeginInit();
            ((System.ComponentModel.ISupportInitialize)min_level).BeginInit();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            groupBox5.SuspendLayout();
            SuspendLayout();
            // 
            // btnAccept
            // 
            btnAccept.AutoSize = true;
            btnAccept.DialogResult = System.Windows.Forms.DialogResult.OK;
            btnAccept.Location = new System.Drawing.Point(14, 431);
            btnAccept.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btnAccept.Name = "btnAccept";
            btnAccept.Size = new System.Drawing.Size(86, 31);
            btnAccept.TabIndex = 0;
            btnAccept.Text = "Accept";
            btnAccept.UseVisualStyleBackColor = true;
            btnAccept.Click += btnAccept_Click;
            // 
            // btnCancel
            // 
            btnCancel.AutoSize = true;
            btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            btnCancel.Location = new System.Drawing.Point(310, 431);
            btnCancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new System.Drawing.Size(86, 31);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // gbObjective
            // 
            gbObjective.Controls.Add(rbtn_Thief);
            gbObjective.Controls.Add(rbtn_Trade);
            gbObjective.Controls.Add(rbtn_Quest);
            gbObjective.Controls.Add(rbtn_Hunting);
            gbObjective.Location = new System.Drawing.Point(14, 16);
            gbObjective.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            gbObjective.Name = "gbObjective";
            gbObjective.Padding = new System.Windows.Forms.Padding(3, 13, 3, 4);
            gbObjective.Size = new System.Drawing.Size(382, 69);
            gbObjective.TabIndex = 2;
            gbObjective.TabStop = false;
            gbObjective.Text = "Party Objective";
            // 
            // rbtn_Thief
            // 
            rbtn_Thief.AutoSize = true;
            rbtn_Thief.BackColor = System.Drawing.Color.Transparent;
            rbtn_Thief.Enabled = false;
            rbtn_Thief.Location = new System.Drawing.Point(272, 28);
            rbtn_Thief.Margin = new System.Windows.Forms.Padding(0);
            rbtn_Thief.Name = "rbtn_Thief";
            rbtn_Thief.Size = new System.Drawing.Size(106, 24);
            rbtn_Thief.TabIndex = 0;
            rbtn_Thief.TabStop = true;
            rbtn_Thief.Tag = "4";
            rbtn_Thief.Text = "Thief Union";
            rbtn_Thief.UseVisualStyleBackColor = false;
            rbtn_Thief.CheckedChanged += radioCheckedChanged;
            // 
            // rbtn_Trade
            // 
            rbtn_Trade.AutoSize = true;
            rbtn_Trade.Enabled = false;
            rbtn_Trade.Location = new System.Drawing.Point(162, 28);
            rbtn_Trade.Margin = new System.Windows.Forms.Padding(0);
            rbtn_Trade.Name = "rbtn_Trade";
            rbtn_Trade.Size = new System.Drawing.Size(110, 24);
            rbtn_Trade.TabIndex = 0;
            rbtn_Trade.TabStop = true;
            rbtn_Trade.Tag = "3";
            rbtn_Trade.Text = "Trade Union";
            rbtn_Trade.CheckedChanged += radioCheckedChanged;
            // 
            // rbtn_Quest
            // 
            rbtn_Quest.AutoSize = true;
            rbtn_Quest.Location = new System.Drawing.Point(91, 28);
            rbtn_Quest.Margin = new System.Windows.Forms.Padding(0);
            rbtn_Quest.Name = "rbtn_Quest";
            rbtn_Quest.Size = new System.Drawing.Size(68, 24);
            rbtn_Quest.TabIndex = 0;
            rbtn_Quest.TabStop = true;
            rbtn_Quest.Tag = "2";
            rbtn_Quest.Text = "Quest";
            rbtn_Quest.CheckedChanged += radioCheckedChanged;
            // 
            // rbtn_Hunting
            // 
            rbtn_Hunting.AutoSize = true;
            rbtn_Hunting.Location = new System.Drawing.Point(8, 28);
            rbtn_Hunting.Margin = new System.Windows.Forms.Padding(0);
            rbtn_Hunting.Name = "rbtn_Hunting";
            rbtn_Hunting.Size = new System.Drawing.Size(83, 24);
            rbtn_Hunting.TabIndex = 0;
            rbtn_Hunting.TabStop = true;
            rbtn_Hunting.Tag = "1";
            rbtn_Hunting.Text = "Hunting";
            rbtn_Hunting.CheckedChanged += radioCheckedChanged;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(max_level);
            groupBox2.Controls.Add(min_level);
            groupBox2.Location = new System.Drawing.Point(14, 93);
            groupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new System.Windows.Forms.Padding(3, 13, 3, 4);
            groupBox2.Size = new System.Drawing.Size(382, 84);
            groupBox2.TabIndex = 3;
            groupBox2.TabStop = false;
            groupBox2.Text = "Level Restrict";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(194, 37);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(40, 20);
            label2.TabIndex = 1;
            label2.Text = "Max.";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(29, 37);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(37, 20);
            label1.TabIndex = 1;
            label1.Text = "Min.";
            // 
            // max_level
            // 
            max_level.Font = new System.Drawing.Font("Segoe UI", 9.25F);
            max_level.Location = new System.Drawing.Point(240, 35);
            max_level.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            max_level.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            max_level.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            max_level.MinimumSize = new System.Drawing.Size(91, 0);
            max_level.Name = "max_level";
            max_level.Size = new System.Drawing.Size(110, 28);
            max_level.TabIndex = 0;
            max_level.Value = new decimal(new int[] { 140, 0, 0, 0 });
            // 
            // min_level
            // 
            min_level.Font = new System.Drawing.Font("Segoe UI", 9.25F);
            min_level.Location = new System.Drawing.Point(72, 35);
            min_level.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            min_level.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            min_level.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            min_level.MinimumSize = new System.Drawing.Size(91, 0);
            min_level.Name = "min_level";
            min_level.Size = new System.Drawing.Size(110, 28);
            min_level.TabIndex = 0;
            min_level.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(label_partytype2);
            groupBox3.Controls.Add(label5);
            groupBox3.Controls.Add(label_partytype);
            groupBox3.Controls.Add(label3);
            groupBox3.Location = new System.Drawing.Point(14, 185);
            groupBox3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new System.Windows.Forms.Padding(3, 13, 3, 4);
            groupBox3.Size = new System.Drawing.Size(382, 76);
            groupBox3.TabIndex = 3;
            groupBox3.TabStop = false;
            groupBox3.Text = "Party Type";
            // 
            // label_partytype2
            // 
            label_partytype2.AutoSize = true;
            label_partytype2.Location = new System.Drawing.Point(222, 37);
            label_partytype2.Name = "label_partytype2";
            label_partytype2.Size = new System.Drawing.Size(116, 20);
            label_partytype2.TabIndex = 1;
            label_partytype2.Text = "Item Auto Share";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            label5.Location = new System.Drawing.Point(194, 30);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(24, 28);
            label5.TabIndex = 0;
            label5.Text = "◊";
            // 
            // label_partytype
            // 
            label_partytype.AutoSize = true;
            label_partytype.Location = new System.Drawing.Point(59, 37);
            label_partytype.Name = "label_partytype";
            label_partytype.Size = new System.Drawing.Size(110, 20);
            label_partytype.TabIndex = 1;
            label_partytype.Text = "Exp Auto Share";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            label3.Location = new System.Drawing.Point(33, 30);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(24, 28);
            label3.TabIndex = 0;
            label3.Text = "◊";
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(tb_Title);
            groupBox4.Location = new System.Drawing.Point(14, 270);
            groupBox4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            groupBox4.Name = "groupBox4";
            groupBox4.Padding = new System.Windows.Forms.Padding(3, 13, 3, 4);
            groupBox4.Size = new System.Drawing.Size(382, 73);
            groupBox4.TabIndex = 3;
            groupBox4.TabStop = false;
            groupBox4.Text = "Title";
            // 
            // tb_Title
            // 
            tb_Title.Location = new System.Drawing.Point(14, 29);
            tb_Title.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            tb_Title.Name = "tb_Title";
            tb_Title.Size = new System.Drawing.Size(356, 27);
            tb_Title.TabIndex = 0;
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(cb_AutoReform);
            groupBox5.Controls.Add(cb_AutoAccept);
            groupBox5.Location = new System.Drawing.Point(14, 351);
            groupBox5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            groupBox5.Name = "groupBox5";
            groupBox5.Padding = new System.Windows.Forms.Padding(3, 13, 3, 4);
            groupBox5.Size = new System.Drawing.Size(382, 72);
            groupBox5.TabIndex = 3;
            groupBox5.TabStop = false;
            groupBox5.Text = "Config";
            // 
            // cb_AutoReform
            // 
            cb_AutoReform.AutoSize = true;
            cb_AutoReform.Location = new System.Drawing.Point(14, 33);
            cb_AutoReform.Margin = new System.Windows.Forms.Padding(0);
            cb_AutoReform.Name = "cb_AutoReform";
            cb_AutoReform.Size = new System.Drawing.Size(116, 24);
            cb_AutoReform.TabIndex = 0;
            cb_AutoReform.Text = "Auto Reform";
            cb_AutoReform.UseVisualStyleBackColor = false;
            cb_AutoReform.CheckedChanged += cb_AutoReform_CheckedChanged;
            // 
            // cb_AutoAccept
            // 
            cb_AutoAccept.AutoSize = true;
            cb_AutoAccept.Location = new System.Drawing.Point(257, 33);
            cb_AutoAccept.Margin = new System.Windows.Forms.Padding(0);
            cb_AutoAccept.Name = "cb_AutoAccept";
            cb_AutoAccept.Size = new System.Drawing.Size(113, 24);
            cb_AutoAccept.TabIndex = 0;
            cb_AutoAccept.Text = "Auto Accept";
            cb_AutoAccept.UseVisualStyleBackColor = false;
            cb_AutoAccept.CheckedChanged += cb_AutoAccept_CheckedChanged;
            // 
            // AutoFormParty
            // 
            AcceptButton = btnAccept;
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new System.Drawing.Size(411, 473);
            Controls.Add(groupBox5);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(gbObjective);
            Controls.Add(btnCancel);
            Controls.Add(btnAccept);
            Font = new System.Drawing.Font("Segoe UI", 9F);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            MinimumSize = new System.Drawing.Size(409, 458);
            Name = "AutoFormParty";
            ShowIcon = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "Party Matching";
            Load += AutoFormParty_Load;
            gbObjective.ResumeLayout(false);
            gbObjective.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)max_level).EndInit();
            ((System.ComponentModel.ISupportInitialize)min_level).EndInit();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            groupBox5.ResumeLayout(false);
            groupBox5.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Button btnCancel;
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