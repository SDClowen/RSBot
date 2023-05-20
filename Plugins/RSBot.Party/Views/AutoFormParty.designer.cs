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
            btnAccept = new SDUI.Controls.Button();
            btnCancel = new SDUI.Controls.Button();
            gbObjective = new SDUI.Controls.GroupBox();
            rbtn_Thief = new SDUI.Controls.Radio();
            rbtn_Trade = new SDUI.Controls.Radio();
            rbtn_Quest = new SDUI.Controls.Radio();
            rbtn_Hunting = new SDUI.Controls.Radio();
            groupBox2 = new SDUI.Controls.GroupBox();
            label2 = new SDUI.Controls.Label();
            label1 = new SDUI.Controls.Label();
            max_level = new SDUI.Controls.NumUpDown();
            min_level = new SDUI.Controls.NumUpDown();
            groupBox3 = new SDUI.Controls.GroupBox();
            label_partytype2 = new SDUI.Controls.Label();
            label5 = new SDUI.Controls.Label();
            label_partytype = new SDUI.Controls.Label();
            label3 = new SDUI.Controls.Label();
            groupBox4 = new SDUI.Controls.GroupBox();
            tb_Title = new SDUI.Controls.TextBox();
            groupBox5 = new SDUI.Controls.GroupBox();
            cb_AutoReform = new SDUI.Controls.CheckBox();
            cb_AutoAccept = new SDUI.Controls.CheckBox();
            gbObjective.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            groupBox5.SuspendLayout();
            SuspendLayout();
            // 
            // btnAccept
            // 
            btnAccept.Color = System.Drawing.Color.Transparent;
            btnAccept.DialogResult = System.Windows.Forms.DialogResult.OK;
            btnAccept.Location = new System.Drawing.Point(12, 323);
            btnAccept.Name = "btnAccept";
            btnAccept.Radius = 6;
            btnAccept.ShadowDepth = 4F;
            btnAccept.Size = new System.Drawing.Size(75, 23);
            btnAccept.TabIndex = 0;
            btnAccept.Text = "Accept";
            btnAccept.UseVisualStyleBackColor = true;
            btnAccept.Click += btnAccept_Click;
            // 
            // btnCancel
            // 
            btnCancel.Color = System.Drawing.Color.Transparent;
            btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            btnCancel.Location = new System.Drawing.Point(271, 323);
            btnCancel.Name = "btnCancel";
            btnCancel.Radius = 6;
            btnCancel.ShadowDepth = 4F;
            btnCancel.Size = new System.Drawing.Size(75, 23);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // gbObjective
            // 
            gbObjective.BackColor = System.Drawing.Color.Transparent;
            gbObjective.Controls.Add(rbtn_Thief);
            gbObjective.Controls.Add(rbtn_Trade);
            gbObjective.Controls.Add(rbtn_Quest);
            gbObjective.Controls.Add(rbtn_Hunting);
            gbObjective.Location = new System.Drawing.Point(12, 12);
            gbObjective.Name = "gbObjective";
            gbObjective.Padding = new System.Windows.Forms.Padding(3, 10, 3, 3);
            gbObjective.Radius = 10;
            gbObjective.ShadowDepth = 4;
            gbObjective.Size = new System.Drawing.Size(334, 52);
            gbObjective.TabIndex = 2;
            gbObjective.TabStop = false;
            gbObjective.Text = "Party Objective";
            // 
            // rbtn_Thief
            // 
            rbtn_Thief.Enabled = false;
            rbtn_Thief.Location = new System.Drawing.Point(238, 31);
            rbtn_Thief.Margin = new System.Windows.Forms.Padding(0);
            rbtn_Thief.Name = "rbtn_Thief";
            rbtn_Thief.Ripple = true;
            rbtn_Thief.Size = new System.Drawing.Size(93, 15);
            rbtn_Thief.TabIndex = 0;
            rbtn_Thief.TabStop = true;
            rbtn_Thief.Tag = "4";
            rbtn_Thief.Text = "Thief Union";
            rbtn_Thief.CheckedChanged += radioCheckedChanged;
            // 
            // rbtn_Trade
            // 
            rbtn_Trade.Enabled = false;
            rbtn_Trade.Location = new System.Drawing.Point(149, 31);
            rbtn_Trade.Margin = new System.Windows.Forms.Padding(0);
            rbtn_Trade.Name = "rbtn_Trade";
            rbtn_Trade.Ripple = true;
            rbtn_Trade.Size = new System.Drawing.Size(95, 15);
            rbtn_Trade.TabIndex = 0;
            rbtn_Trade.TabStop = true;
            rbtn_Trade.Tag = "3";
            rbtn_Trade.Text = "Trade Union";
            rbtn_Trade.CheckedChanged += radioCheckedChanged;
            // 
            // rbtn_Quest
            // 
            rbtn_Quest.Location = new System.Drawing.Point(87, 31);
            rbtn_Quest.Margin = new System.Windows.Forms.Padding(0);
            rbtn_Quest.Name = "rbtn_Quest";
            rbtn_Quest.Ripple = true;
            rbtn_Quest.Size = new System.Drawing.Size(63, 15);
            rbtn_Quest.TabIndex = 0;
            rbtn_Quest.TabStop = true;
            rbtn_Quest.Tag = "2";
            rbtn_Quest.Text = "Quest";
            rbtn_Quest.CheckedChanged += radioCheckedChanged;
            // 
            // rbtn_Hunting
            // 
            rbtn_Hunting.Location = new System.Drawing.Point(12, 31);
            rbtn_Hunting.Margin = new System.Windows.Forms.Padding(0);
            rbtn_Hunting.Name = "rbtn_Hunting";
            rbtn_Hunting.Ripple = true;
            rbtn_Hunting.Size = new System.Drawing.Size(76, 15);
            rbtn_Hunting.TabIndex = 0;
            rbtn_Hunting.TabStop = true;
            rbtn_Hunting.Tag = "1";
            rbtn_Hunting.Text = "Hunting";
            rbtn_Hunting.CheckedChanged += radioCheckedChanged;
            // 
            // groupBox2
            // 
            groupBox2.BackColor = System.Drawing.Color.Transparent;
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(max_level);
            groupBox2.Controls.Add(min_level);
            groupBox2.Location = new System.Drawing.Point(12, 70);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new System.Windows.Forms.Padding(3, 10, 3, 3);
            groupBox2.Radius = 10;
            groupBox2.ShadowDepth = 4;
            groupBox2.Size = new System.Drawing.Size(334, 63);
            groupBox2.TabIndex = 3;
            groupBox2.TabStop = false;
            groupBox2.Text = "Level Restrict";
            // 
            // label2
            // 
            label2.ApplyGradient = false;
            label2.AutoSize = true;
            label2.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            label2.Gradient = (new System.Drawing.Color[] { System.Drawing.Color.Gray, System.Drawing.Color.Black });
            label2.Location = new System.Drawing.Point(172, 35);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(33, 15);
            label2.TabIndex = 1;
            label2.Text = "Max.";
            // 
            // label1
            // 
            label1.ApplyGradient = false;
            label1.AutoSize = true;
            label1.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            label1.Gradient = (new System.Drawing.Color[] { System.Drawing.Color.Gray, System.Drawing.Color.Black });
            label1.Location = new System.Drawing.Point(26, 35);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(31, 15);
            label1.TabIndex = 1;
            label1.Text = "Min.";
            // 
            // max_level
            // 
            max_level.BackColor = System.Drawing.Color.FromArgb(238, 238, 238);
            max_level.Font = new System.Drawing.Font("Segoe UI", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            max_level.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            max_level.Location = new System.Drawing.Point(209, 32);
            max_level.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            max_level.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            max_level.MinimumSize = new System.Drawing.Size(80, 25);
            max_level.Name = "max_level";
            max_level.Size = new System.Drawing.Size(96, 25);
            max_level.TabIndex = 0;
            max_level.Value = new decimal(new int[] { 140, 0, 0, 0 });
            // 
            // min_level
            // 
            min_level.BackColor = System.Drawing.Color.FromArgb(238, 238, 238);
            min_level.Font = new System.Drawing.Font("Segoe UI", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            min_level.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            min_level.Location = new System.Drawing.Point(63, 32);
            min_level.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            min_level.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            min_level.MinimumSize = new System.Drawing.Size(80, 25);
            min_level.Name = "min_level";
            min_level.Size = new System.Drawing.Size(96, 25);
            min_level.TabIndex = 0;
            min_level.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // groupBox3
            // 
            groupBox3.BackColor = System.Drawing.Color.Transparent;
            groupBox3.Controls.Add(label_partytype2);
            groupBox3.Controls.Add(label5);
            groupBox3.Controls.Add(label_partytype);
            groupBox3.Controls.Add(label3);
            groupBox3.Location = new System.Drawing.Point(12, 139);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new System.Windows.Forms.Padding(3, 10, 3, 3);
            groupBox3.Radius = 10;
            groupBox3.ShadowDepth = 4;
            groupBox3.Size = new System.Drawing.Size(334, 57);
            groupBox3.TabIndex = 3;
            groupBox3.TabStop = false;
            groupBox3.Text = "Party Type";
            // 
            // label_partytype2
            // 
            label_partytype2.ApplyGradient = false;
            label_partytype2.AutoSize = true;
            label_partytype2.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            label_partytype2.Gradient = (new System.Drawing.Color[] { System.Drawing.Color.Gray, System.Drawing.Color.Black });
            label_partytype2.Location = new System.Drawing.Point(206, 32);
            label_partytype2.Name = "label_partytype2";
            label_partytype2.Size = new System.Drawing.Size(92, 15);
            label_partytype2.TabIndex = 1;
            label_partytype2.Text = "Item Auto Share";
            // 
            // label5
            // 
            label5.ApplyGradient = false;
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label5.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            label5.Gradient = (new System.Drawing.Color[] { System.Drawing.Color.Gray, System.Drawing.Color.Black });
            label5.Location = new System.Drawing.Point(181, 27);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(19, 21);
            label5.TabIndex = 0;
            label5.Text = "◊";
            // 
            // label_partytype
            // 
            label_partytype.ApplyGradient = false;
            label_partytype.AutoSize = true;
            label_partytype.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            label_partytype.Gradient = (new System.Drawing.Color[] { System.Drawing.Color.Gray, System.Drawing.Color.Black });
            label_partytype.Location = new System.Drawing.Point(63, 32);
            label_partytype.Name = "label_partytype";
            label_partytype.Size = new System.Drawing.Size(87, 15);
            label_partytype.TabIndex = 1;
            label_partytype.Text = "Exp Auto Share";
            // 
            // label3
            // 
            label3.ApplyGradient = false;
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label3.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            label3.Gradient = (new System.Drawing.Color[] { System.Drawing.Color.Gray, System.Drawing.Color.Black });
            label3.Location = new System.Drawing.Point(40, 27);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(19, 21);
            label3.TabIndex = 0;
            label3.Text = "◊";
            // 
            // groupBox4
            // 
            groupBox4.BackColor = System.Drawing.Color.Transparent;
            groupBox4.Controls.Add(tb_Title);
            groupBox4.Location = new System.Drawing.Point(12, 202);
            groupBox4.Name = "groupBox4";
            groupBox4.Padding = new System.Windows.Forms.Padding(3, 10, 3, 3);
            groupBox4.Radius = 10;
            groupBox4.ShadowDepth = 4;
            groupBox4.Size = new System.Drawing.Size(334, 55);
            groupBox4.TabIndex = 3;
            groupBox4.TabStop = false;
            groupBox4.Text = "Title";
            // 
            // tb_Title
            // 
            tb_Title.Location = new System.Drawing.Point(12, 28);
            tb_Title.MaxLength = 32767;
            tb_Title.MultiLine = false;
            tb_Title.Name = "tb_Title";
            tb_Title.PassFocusShow = false;
            tb_Title.Radius = 2;
            tb_Title.Size = new System.Drawing.Size(312, 21);
            tb_Title.TabIndex = 0;
            tb_Title.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            tb_Title.UseSystemPasswordChar = false;
            // 
            // groupBox5
            // 
            groupBox5.BackColor = System.Drawing.Color.Transparent;
            groupBox5.Controls.Add(cb_AutoReform);
            groupBox5.Controls.Add(cb_AutoAccept);
            groupBox5.Location = new System.Drawing.Point(12, 263);
            groupBox5.Name = "groupBox5";
            groupBox5.Padding = new System.Windows.Forms.Padding(3, 10, 3, 3);
            groupBox5.Radius = 10;
            groupBox5.ShadowDepth = 4;
            groupBox5.Size = new System.Drawing.Size(334, 54);
            groupBox5.TabIndex = 3;
            groupBox5.TabStop = false;
            groupBox5.Text = "Config";
            // 
            // cb_AutoReform
            // 
            cb_AutoReform.BackColor = System.Drawing.Color.Transparent;
            cb_AutoReform.Depth = 0;
            cb_AutoReform.Location = new System.Drawing.Point(12, 32);
            cb_AutoReform.Margin = new System.Windows.Forms.Padding(0);
            cb_AutoReform.MouseLocation = new System.Drawing.Point(-1, -1);
            cb_AutoReform.Name = "cb_AutoReform";
            cb_AutoReform.Ripple = true;
            cb_AutoReform.Size = new System.Drawing.Size(91, 15);
            cb_AutoReform.TabIndex = 0;
            cb_AutoReform.Text = "Auto Reform";
            cb_AutoReform.UseVisualStyleBackColor = false;
            cb_AutoReform.CheckedChanged += cb_AutoReform_CheckedChanged;
            // 
            // cb_AutoAccept
            // 
            cb_AutoAccept.BackColor = System.Drawing.Color.Transparent;
            cb_AutoAccept.Depth = 0;
            cb_AutoAccept.Location = new System.Drawing.Point(232, 32);
            cb_AutoAccept.Margin = new System.Windows.Forms.Padding(0);
            cb_AutoAccept.MouseLocation = new System.Drawing.Point(-1, -1);
            cb_AutoAccept.Name = "cb_AutoAccept";
            cb_AutoAccept.Ripple = true;
            cb_AutoAccept.Size = new System.Drawing.Size(89, 15);
            cb_AutoAccept.TabIndex = 0;
            cb_AutoAccept.Text = "Auto Accept";
            cb_AutoAccept.UseVisualStyleBackColor = false;
            cb_AutoAccept.CheckedChanged += cb_AutoAccept_CheckedChanged;
            // 
            // AutoFormParty
            // 
            AcceptButton = btnAccept;
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(251, 251, 251);
            CancelButton = btnCancel;
            ClientSize = new System.Drawing.Size(360, 355);
            Controls.Add(groupBox5);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(gbObjective);
            Controls.Add(btnCancel);
            Controls.Add(btnAccept);
            Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            MinimumSize = new System.Drawing.Size(360, 355);
            Name = "AutoFormParty";
            ShowIcon = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "Party Matching";
            Load += AutoFormParty_Load;
            gbObjective.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox5.ResumeLayout(false);
            ResumeLayout(false);
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