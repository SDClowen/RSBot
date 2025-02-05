namespace RSBot.Lure.Views
{
    partial class Main
    {
        /// <summary> 
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            groupBox1 = new System.Windows.Forms.GroupBox();
            label5 = new System.Windows.Forms.Label();
            btnBrowseWalkscript = new System.Windows.Forms.Button();
            txtWalkbackScript = new System.Windows.Forms.TextBox();
            radioStayAtCenter = new System.Windows.Forms.RadioButton();
            separator4 = new System.Windows.Forms.Panel();
            label7 = new System.Windows.Forms.Label();
            numStayAtCenterSeconds = new System.Windows.Forms.NumericUpDown();
            checkStayAtCenter = new System.Windows.Forms.CheckBox();
            btnBrowse = new System.Windows.Forms.Button();
            radioUseScript = new System.Windows.Forms.RadioButton();
            radioWalkRandomly = new System.Windows.Forms.RadioButton();
            linkRecord = new System.Windows.Forms.LinkLabel();
            txtScriptPath = new System.Windows.Forms.TextBox();
            panel1 = new System.Windows.Forms.Panel();
            btnSetCenter = new System.Windows.Forms.Button();
            lblX = new System.Windows.Forms.Label();
            lblY = new System.Windows.Forms.Label();
            numRadius = new System.Windows.Forms.NumericUpDown();
            label1 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            checkUseNormalAttack = new System.Windows.Forms.CheckBox();
            checkUseHowlingShout = new System.Windows.Forms.CheckBox();
            groupBox3 = new System.Windows.Forms.GroupBox();
            label4 = new System.Windows.Forms.Label();
            checkUseAttackingSkills = new System.Windows.Forms.CheckBox();
            checkNoHowlingAtCenter = new System.Windows.Forms.CheckBox();
            separator1 = new System.Windows.Forms.Panel();
            separator2 = new System.Windows.Forms.Panel();
            numPartyMember = new System.Windows.Forms.NumericUpDown();
            checkStopPartyMember = new System.Windows.Forms.CheckBox();
            label6 = new System.Windows.Forms.Label();
            comboMonsterType = new System.Windows.Forms.ComboBox();
            numMonsterType = new System.Windows.Forms.NumericUpDown();
            checkStopMonsterType = new System.Windows.Forms.CheckBox();
            numPartyMemberDead = new System.Windows.Forms.NumericUpDown();
            checkStopPartyMemberDead = new System.Windows.Forms.CheckBox();
            groupBox1.SuspendLayout();
            panel1.SuspendLayout();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(btnBrowseWalkscript);
            groupBox1.Controls.Add(txtWalkbackScript);
            groupBox1.Controls.Add(radioStayAtCenter);
            groupBox1.Controls.Add(separator4);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(numStayAtCenterSeconds);
            groupBox1.Controls.Add(checkStayAtCenter);
            groupBox1.Controls.Add(btnBrowse);
            groupBox1.Controls.Add(radioUseScript);
            groupBox1.Controls.Add(radioWalkRandomly);
            groupBox1.Controls.Add(linkRecord);
            groupBox1.Controls.Add(txtScriptPath);
            groupBox1.Controls.Add(panel1);
            groupBox1.Location = new System.Drawing.Point(13, 11);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new System.Windows.Forms.Padding(3, 8, 3, 3);
            
            
            groupBox1.Size = new System.Drawing.Size(332, 429);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Location";
            // 
            // label5
            // 
            
            label5.AutoSize = true;
            
            
            
            label5.Location = new System.Drawing.Point(18, 31);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(100, 15);
            label5.TabIndex = 29;
            label5.Text = "Script to location:";
            // 
            // btnBrowseWalkscript
            // 
            
            btnBrowseWalkscript.Location = new System.Drawing.Point(279, 52);
            btnBrowseWalkscript.Name = "btnBrowseWalkscript";
            
            
            btnBrowseWalkscript.Size = new System.Drawing.Size(43, 23);
            btnBrowseWalkscript.TabIndex = 28;
            btnBrowseWalkscript.Text = "...";
            btnBrowseWalkscript.UseVisualStyleBackColor = true;
            btnBrowseWalkscript.Click += btnBrowseWalkscript_Click;
            // 
            // txtWalkbackScript
            // 
            txtWalkbackScript.Location = new System.Drawing.Point(18, 54);
            txtWalkbackScript.MaxLength = 32767;
            txtWalkbackScript.Multiline = false;
            txtWalkbackScript.Name = "txtWalkbackScript";
            
            
            txtWalkbackScript.Size = new System.Drawing.Size(259, 21);
            txtWalkbackScript.TabIndex = 27;
            
            txtWalkbackScript.UseSystemPasswordChar = false;
            // 
            // radioStayAtCenter
            // 
            radioStayAtCenter.AutoSize = true;
            radioStayAtCenter.Location = new System.Drawing.Point(18, 254);
            radioStayAtCenter.Margin = new System.Windows.Forms.Padding(0);
            radioStayAtCenter.Name = "radioStayAtCenter";
            
            radioStayAtCenter.Size = new System.Drawing.Size(105, 30);
            radioStayAtCenter.TabIndex = 25;
            radioStayAtCenter.Text = "Stay at center";
            radioStayAtCenter.UseVisualStyleBackColor = true;
            radioStayAtCenter.CheckedChanged += OnSettingsChanged;
            // 
            // separator4
            // 
            separator4.Location = new System.Drawing.Point(2, 348);
            separator4.Name = "separator4";
            separator4.Size = new System.Drawing.Size(328, 10);
            separator4.TabIndex = 15;
            separator4.Text = "separator4";
            // 
            // label7
            // 
            
            label7.AutoSize = true;
            
            
            
            label7.Location = new System.Drawing.Point(255, 374);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(58, 15);
            label7.TabIndex = 24;
            label7.Text = "second(s)";
            // 
            // numStayAtCenterSeconds
            // 
            
            numStayAtCenterSeconds.Font = new System.Drawing.Font("Segoe UI", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            
            numStayAtCenterSeconds.Location = new System.Drawing.Point(169, 368);
            numStayAtCenterSeconds.Maximum = new decimal(new int[] { 100, 0, 0, 0 });
            numStayAtCenterSeconds.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numStayAtCenterSeconds.MinimumSize = new System.Drawing.Size(80, 25);
            numStayAtCenterSeconds.Name = "numStayAtCenterSeconds";
            numStayAtCenterSeconds.Size = new System.Drawing.Size(80, 25);
            numStayAtCenterSeconds.TabIndex = 23;
            numStayAtCenterSeconds.Value = new decimal(new int[] { 1, 0, 0, 0 });
            numStayAtCenterSeconds.ValueChanged += OnSettingsChanged;
            // 
            // checkStayAtCenter
            // 
            checkStayAtCenter.AutoSize = true;
            
            
            checkStayAtCenter.Location = new System.Drawing.Point(18, 367);
            checkStayAtCenter.Margin = new System.Windows.Forms.Padding(0);
            
            checkStayAtCenter.Name = "checkStayAtCenter";
            
            checkStayAtCenter.Size = new System.Drawing.Size(123, 30);
            checkStayAtCenter.TabIndex = 22;
            checkStayAtCenter.Text = "Stay at center for";
            checkStayAtCenter.UseVisualStyleBackColor = false;
            checkStayAtCenter.CheckedChanged += OnSettingsChanged;
            // 
            // btnBrowse
            // 
            
            btnBrowse.Location = new System.Drawing.Point(279, 315);
            btnBrowse.Name = "btnBrowse";
            
            
            btnBrowse.Size = new System.Drawing.Size(43, 23);
            btnBrowse.TabIndex = 4;
            btnBrowse.Text = "...";
            btnBrowse.UseVisualStyleBackColor = true;
            btnBrowse.Click += btnBrowse_Click;
            // 
            // radioUseScript
            // 
            radioUseScript.AutoSize = true;
            radioUseScript.Location = new System.Drawing.Point(18, 282);
            radioUseScript.Margin = new System.Windows.Forms.Padding(0);
            radioUseScript.Name = "radioUseScript";
            
            radioUseScript.Size = new System.Drawing.Size(118, 30);
            radioUseScript.TabIndex = 2;
            radioUseScript.Text = "Use a lure script";
            radioUseScript.UseVisualStyleBackColor = true;
            radioUseScript.CheckedChanged += OnSettingsChanged;
            // 
            // radioWalkRandomly
            // 
            radioWalkRandomly.AutoSize = true;
            radioWalkRandomly.Checked = true;
            radioWalkRandomly.Location = new System.Drawing.Point(18, 226);
            radioWalkRandomly.Margin = new System.Windows.Forms.Padding(0);
            radioWalkRandomly.Name = "radioWalkRandomly";
            
            radioWalkRandomly.Size = new System.Drawing.Size(113, 30);
            radioWalkRandomly.TabIndex = 1;
            radioWalkRandomly.TabStop = true;
            radioWalkRandomly.Text = "Walk randomly";
            radioWalkRandomly.UseVisualStyleBackColor = true;
            radioWalkRandomly.CheckedChanged += OnSettingsChanged;
            // 
            // linkRecord
            // 
            linkRecord.AutoSize = true;
            linkRecord.Location = new System.Drawing.Point(224, 298);
            linkRecord.Name = "linkRecord";
            linkRecord.Size = new System.Drawing.Size(52, 15);
            linkRecord.TabIndex = 5;
            linkRecord.TabStop = true;
            linkRecord.Text = "[Record]";
            linkRecord.LinkClicked += linkRecord_LinkClicked;
            // 
            // txtScriptPath
            // 
            txtScriptPath.Location = new System.Drawing.Point(18, 316);
            txtScriptPath.MaxLength = 32767;
            txtScriptPath.Multiline = false;
            txtScriptPath.Name = "txtScriptPath";
            
            
            txtScriptPath.Size = new System.Drawing.Size(259, 21);
            txtScriptPath.TabIndex = 3;
            
            txtScriptPath.UseSystemPasswordChar = false;
            // 
            // panel1
            // 
            
            
            
            panel1.Controls.Add(btnSetCenter);
            panel1.Controls.Add(lblX);
            panel1.Controls.Add(lblY);
            panel1.Controls.Add(numRadius);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Location = new System.Drawing.Point(-2, 91);
            panel1.Name = "panel1";
            
            
            panel1.Size = new System.Drawing.Size(336, 121);
            panel1.TabIndex = 30;
            // 
            // btnSetCenter
            // 
            
            btnSetCenter.Location = new System.Drawing.Point(135, 84);
            btnSetCenter.Name = "btnSetCenter";
            
            
            btnSetCenter.Size = new System.Drawing.Size(85, 23);
            btnSetCenter.TabIndex = 10;
            btnSetCenter.Text = "Set center";
            btnSetCenter.UseVisualStyleBackColor = true;
            btnSetCenter.Click += btnSetCenter_Click;
            // 
            // lblX
            // 
            
            lblX.AutoSize = true;
            lblX.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            
            
            
            lblX.Location = new System.Drawing.Point(135, 15);
            lblX.Name = "lblX";
            lblX.Size = new System.Drawing.Size(14, 15);
            lblX.TabIndex = 12;
            lblX.Text = "0";
            // 
            // lblY
            // 
            
            lblY.AutoSize = true;
            lblY.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            
            
            
            lblY.Location = new System.Drawing.Point(135, 34);
            lblY.Name = "lblY";
            lblY.Size = new System.Drawing.Size(14, 15);
            lblY.TabIndex = 11;
            lblY.Text = "0";
            // 
            // numRadius
            // 
            
            numRadius.Font = new System.Drawing.Font("Segoe UI", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            
            numRadius.Location = new System.Drawing.Point(135, 53);
            numRadius.Maximum = new decimal(new int[] { 100, 0, 0, 0 });
            numRadius.Minimum = new decimal(new int[] { 0, 0, 0, 0 });
            numRadius.MinimumSize = new System.Drawing.Size(80, 25);
            numRadius.Name = "numRadius";
            numRadius.Size = new System.Drawing.Size(85, 25);
            numRadius.TabIndex = 13;
            numRadius.Value = new decimal(new int[] { 0, 0, 0, 0 });
            numRadius.ValueChanged += OnSettingsChanged;
            // 
            // label1
            // 
            
            label1.AutoSize = true;
            
            
            
            label1.Location = new System.Drawing.Point(112, 15);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(17, 15);
            label1.TabIndex = 9;
            label1.Text = "X:";
            // 
            // label3
            // 
            
            label3.AutoSize = true;
            
            
            
            label3.Location = new System.Drawing.Point(84, 59);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(45, 15);
            label3.TabIndex = 7;
            label3.Text = "Radius:";
            // 
            // label2
            // 
            
            label2.AutoSize = true;
            
            
            
            label2.Location = new System.Drawing.Point(112, 34);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(17, 15);
            label2.TabIndex = 8;
            label2.Text = "Y:";
            // 
            // checkUseNormalAttack
            // 
            checkUseNormalAttack.AutoSize = true;
            
            
            checkUseNormalAttack.Location = new System.Drawing.Point(26, 87);
            checkUseNormalAttack.Margin = new System.Windows.Forms.Padding(0);
            
            checkUseNormalAttack.Name = "checkUseNormalAttack";
            
            checkUseNormalAttack.Size = new System.Drawing.Size(230, 30);
            checkUseNormalAttack.TabIndex = 1;
            checkUseNormalAttack.Text = "Use normal attack and switch target*";
            checkUseNormalAttack.UseVisualStyleBackColor = false;
            checkUseNormalAttack.CheckedChanged += OnSettingsChanged;
            // 
            // checkUseHowlingShout
            // 
            checkUseHowlingShout.AutoSize = true;
            
            
            checkUseHowlingShout.Location = new System.Drawing.Point(26, 36);
            checkUseHowlingShout.Margin = new System.Windows.Forms.Padding(0);
            
            checkUseHowlingShout.Name = "checkUseHowlingShout";
            
            checkUseHowlingShout.Size = new System.Drawing.Size(186, 30);
            checkUseHowlingShout.TabIndex = 0;
            checkUseHowlingShout.Text = "Cast howling shout (only EU)";
            checkUseHowlingShout.UseVisualStyleBackColor = false;
            checkUseHowlingShout.CheckedChanged += OnSettingsChanged;
            // 
            // groupBox3
            // 
            
            groupBox3.Controls.Add(label4);
            groupBox3.Controls.Add(checkUseAttackingSkills);
            groupBox3.Controls.Add(checkNoHowlingAtCenter);
            groupBox3.Controls.Add(separator1);
            groupBox3.Controls.Add(checkUseNormalAttack);
            groupBox3.Controls.Add(checkUseHowlingShout);
            groupBox3.Controls.Add(separator2);
            groupBox3.Controls.Add(numPartyMember);
            groupBox3.Controls.Add(checkStopPartyMember);
            groupBox3.Controls.Add(label6);
            groupBox3.Controls.Add(comboMonsterType);
            groupBox3.Controls.Add(numMonsterType);
            groupBox3.Controls.Add(checkStopMonsterType);
            groupBox3.Controls.Add(numPartyMemberDead);
            groupBox3.Controls.Add(checkStopPartyMemberDead);
            groupBox3.Location = new System.Drawing.Point(359, 11);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new System.Windows.Forms.Padding(3, 8, 3, 3);
            
            
            groupBox3.Size = new System.Drawing.Size(391, 344);
            groupBox3.TabIndex = 2;
            groupBox3.TabStop = false;
            groupBox3.Text = "Settings";
            // 
            // label4
            // 
            
            label4.AutoSize = true;
            
            
            
            label4.Location = new System.Drawing.Point(26, 315);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(304, 15);
            label4.TabIndex = 26;
            label4.Text = "* not available for scripts. Record skills in the script itself.";
            // 
            // checkUseAttackingSkills
            // 
            checkUseAttackingSkills.AutoSize = true;
            
            
            checkUseAttackingSkills.Location = new System.Drawing.Point(26, 113);
            checkUseAttackingSkills.Margin = new System.Windows.Forms.Padding(0);
            
            checkUseAttackingSkills.Name = "checkUseAttackingSkills";
            
            checkUseAttackingSkills.Size = new System.Drawing.Size(230, 30);
            checkUseAttackingSkills.TabIndex = 27;
            checkUseAttackingSkills.Text = "Use attacking skill and switch target*";
            checkUseAttackingSkills.UseVisualStyleBackColor = false;
            checkUseAttackingSkills.CheckedChanged += OnSettingsChanged;
            // 
            // checkNoHowlingAtCenter
            // 
            checkNoHowlingAtCenter.AutoSize = true;
            
            
            checkNoHowlingAtCenter.Location = new System.Drawing.Point(45, 58);
            checkNoHowlingAtCenter.Margin = new System.Windows.Forms.Padding(0);
            
            checkNoHowlingAtCenter.Name = "checkNoHowlingAtCenter";
            
            checkNoHowlingAtCenter.Size = new System.Drawing.Size(149, 30);
            checkNoHowlingAtCenter.TabIndex = 26;
            checkNoHowlingAtCenter.Text = "Don't cast near center";
            checkNoHowlingAtCenter.UseVisualStyleBackColor = false;
            checkNoHowlingAtCenter.CheckedChanged += OnSettingsChanged;
            // 
            // separator1
            // 
            separator1.Location = new System.Drawing.Point(0, 142);
            separator1.Name = "separator1";
            separator1.Size = new System.Drawing.Size(392, 10);
            separator1.TabIndex = 25;
            separator1.Text = "separator1";
            // 
            // separator2
            // 
            separator2.Location = new System.Drawing.Point(2, 277);
            separator2.Name = "separator2";
            separator2.Size = new System.Drawing.Size(392, 10);
            separator2.TabIndex = 21;
            separator2.Text = "separator2";
            // 
            // numPartyMember
            // 
            
            numPartyMember.Font = new System.Drawing.Font("Segoe UI", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            
            numPartyMember.Location = new System.Drawing.Point(225, 193);
            numPartyMember.Maximum = new decimal(new int[] { 8, 0, 0, 0 });
            numPartyMember.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numPartyMember.MinimumSize = new System.Drawing.Size(80, 25);
            numPartyMember.Name = "numPartyMember";
            numPartyMember.Size = new System.Drawing.Size(80, 25);
            numPartyMember.TabIndex = 20;
            numPartyMember.Value = new decimal(new int[] { 1, 0, 0, 0 });
            numPartyMember.ValueChanged += OnSettingsChanged;
            // 
            // checkStopPartyMember
            // 
            checkStopPartyMember.AutoSize = true;
            
            
            checkStopPartyMember.Location = new System.Drawing.Point(26, 191);
            checkStopPartyMember.Margin = new System.Windows.Forms.Padding(0);
            
            checkStopPartyMember.Name = "checkStopPartyMember";
            
            checkStopPartyMember.Size = new System.Drawing.Size(189, 30);
            checkStopPartyMember.TabIndex = 19;
            checkStopPartyMember.Text = "Stop num party members <=";
            checkStopPartyMember.UseVisualStyleBackColor = false;
            checkStopPartyMember.CheckedChanged += OnSettingsChanged;
            // 
            // label6
            // 
            
            label6.AutoSize = true;
            
            
            
            label6.Location = new System.Drawing.Point(191, 253);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(23, 15);
            label6.TabIndex = 18;
            label6.Text = ">=";
            // 
            // comboMonsterType
            // 
            comboMonsterType.DrawMode = System.Windows.Forms.DrawMode.Normal;
            comboMonsterType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboMonsterType.FormattingEnabled = true;
            comboMonsterType.Items.AddRange(new object[] { "General (Default)", "Champion", "Giant", "General (Party)", "Champion (Party)", "Giant (Party)", "Elite", "Strong", "Unique", "Event" });
            comboMonsterType.Location = new System.Drawing.Point(45, 250);
            comboMonsterType.Name = "comboMonsterType";
            
            
            comboMonsterType.Size = new System.Drawing.Size(140, 24);
            comboMonsterType.TabIndex = 17;
            comboMonsterType.SelectedIndexChanged += comboMonsterType_SelectedIndexChanged;
            // 
            // numMonsterType
            // 
            
            numMonsterType.Font = new System.Drawing.Font("Segoe UI", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            
            numMonsterType.Location = new System.Drawing.Point(225, 246);
            numMonsterType.Maximum = new decimal(new int[] { 100, 0, 0, 0 });
            numMonsterType.Minimum = new decimal(new int[] { 0, 0, 0, 0 });
            numMonsterType.MinimumSize = new System.Drawing.Size(80, 25);
            numMonsterType.Name = "numMonsterType";
            numMonsterType.Size = new System.Drawing.Size(80, 25);
            numMonsterType.TabIndex = 16;
            numMonsterType.Value = new decimal(new int[] { 0, 0, 0, 0 });
            numMonsterType.ValueChanged += OnSettingsChanged;
            // 
            // checkStopMonsterType
            // 
            checkStopMonsterType.AutoSize = true;
            
            
            checkStopMonsterType.Location = new System.Drawing.Point(26, 221);
            checkStopMonsterType.Margin = new System.Windows.Forms.Padding(0);
            
            checkStopMonsterType.Name = "checkStopMonsterType";
            
            checkStopMonsterType.Size = new System.Drawing.Size(183, 30);
            checkStopMonsterType.TabIndex = 15;
            checkStopMonsterType.Text = "Stop if num monster of type";
            checkStopMonsterType.UseVisualStyleBackColor = false;
            checkStopMonsterType.CheckedChanged += OnSettingsChanged;
            // 
            // numPartyMemberDead
            // 
            
            numPartyMemberDead.Font = new System.Drawing.Font("Segoe UI", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            
            numPartyMemberDead.Location = new System.Drawing.Point(225, 161);
            numPartyMemberDead.Maximum = new decimal(new int[] { 8, 0, 0, 0 });
            numPartyMemberDead.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numPartyMemberDead.MinimumSize = new System.Drawing.Size(80, 25);
            numPartyMemberDead.Name = "numPartyMemberDead";
            numPartyMemberDead.Size = new System.Drawing.Size(80, 25);
            numPartyMemberDead.TabIndex = 14;
            numPartyMemberDead.Value = new decimal(new int[] { 1, 0, 0, 0 });
            numPartyMemberDead.ValueChanged += OnSettingsChanged;
            // 
            // checkStopPartyMemberDead
            // 
            checkStopPartyMemberDead.AutoSize = true;
            
            
            checkStopPartyMemberDead.Location = new System.Drawing.Point(26, 160);
            checkStopPartyMemberDead.Margin = new System.Windows.Forms.Padding(0);
            
            checkStopPartyMemberDead.Name = "checkStopPartyMemberDead";
            
            checkStopPartyMemberDead.Size = new System.Drawing.Size(202, 30);
            checkStopPartyMemberDead.TabIndex = 6;
            checkStopPartyMemberDead.Text = "Stop if dead party members >=";
            checkStopPartyMemberDead.UseVisualStyleBackColor = false;
            checkStopPartyMemberDead.CheckedChanged += OnSettingsChanged;
            // 
            // Main
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(groupBox3);
            Controls.Add(groupBox1);
            Name = "Main";
            Size = new System.Drawing.Size(824, 515);
            Load += Main_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSetCenter;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblY;
        private System.Windows.Forms.Label lblX;
        private System.Windows.Forms.NumericUpDown numRadius;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox txtScriptPath;
        private System.Windows.Forms.RadioButton radioUseScript;
        private System.Windows.Forms.RadioButton radioWalkRandomly;
        private System.Windows.Forms.LinkLabel linkRecord;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboMonsterType;
        private System.Windows.Forms.NumericUpDown numMonsterType;
        private System.Windows.Forms.CheckBox checkStopMonsterType;
        private System.Windows.Forms.NumericUpDown numPartyMemberDead;
        private System.Windows.Forms.CheckBox checkStopPartyMemberDead;
        private System.Windows.Forms.CheckBox checkUseNormalAttack;
        private System.Windows.Forms.CheckBox checkUseHowlingShout;
        private System.Windows.Forms.NumericUpDown numPartyMember;
        private System.Windows.Forms.CheckBox checkStopPartyMember;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numStayAtCenterSeconds;
        private System.Windows.Forms.CheckBox checkStayAtCenter;
        private System.Windows.Forms.Panel separator2;
        private System.Windows.Forms.Panel separator1;
        private System.Windows.Forms.Panel separator4;
        private System.Windows.Forms.RadioButton radioStayAtCenter;
        private System.Windows.Forms.CheckBox checkNoHowlingAtCenter;
        private System.Windows.Forms.CheckBox checkUseAttackingSkills;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnBrowseWalkscript;
        private System.Windows.Forms.TextBox txtWalkbackScript;
        private System.Windows.Forms.Panel panel1;
    }
}
