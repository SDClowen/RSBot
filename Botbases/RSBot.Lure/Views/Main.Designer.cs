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
            this.groupBox1 = new SDUI.Controls.GroupBox();
            this.label5 = new SDUI.Controls.Label();
            this.btnBrowseWalkscript = new SDUI.Controls.Button();
            this.txtWalkbackScript = new SDUI.Controls.TextBox();
            this.radioStayAtCenter = new SDUI.Controls.Radio();
            this.separator4 = new SDUI.Controls.Separator();
            this.label7 = new SDUI.Controls.Label();
            this.numStayAtCenterSeconds = new SDUI.Controls.NumUpDown();
            this.checkStayAtCenter = new SDUI.Controls.CheckBox();
            this.btnBrowse = new SDUI.Controls.Button();
            this.radioUseScript = new SDUI.Controls.Radio();
            this.radioWalkRandomly = new SDUI.Controls.Radio();
            this.linkRecord = new System.Windows.Forms.LinkLabel();
            this.txtScriptPath = new SDUI.Controls.TextBox();
            this.panel1 = new SDUI.Controls.Panel();
            this.btnSetCenter = new SDUI.Controls.Button();
            this.lblX = new SDUI.Controls.Label();
            this.lblY = new SDUI.Controls.Label();
            this.numRadius = new SDUI.Controls.NumUpDown();
            this.label1 = new SDUI.Controls.Label();
            this.label3 = new SDUI.Controls.Label();
            this.label2 = new SDUI.Controls.Label();
            this.checkUseNormalAttack = new SDUI.Controls.CheckBox();
            this.checkUseHowlingShout = new SDUI.Controls.CheckBox();
            this.groupBox3 = new SDUI.Controls.GroupBox();
            this.label4 = new SDUI.Controls.Label();
            this.checkUseAttackingSkills = new SDUI.Controls.CheckBox();
            this.checkNoHowlingAtCenter = new SDUI.Controls.CheckBox();
            this.separator1 = new SDUI.Controls.Separator();
            this.separator2 = new SDUI.Controls.Separator();
            this.numPartyMember = new SDUI.Controls.NumUpDown();
            this.checkStopPartyMember = new SDUI.Controls.CheckBox();
            this.label6 = new SDUI.Controls.Label();
            this.comboMonsterType = new SDUI.Controls.ComboBox();
            this.numMonsterType = new SDUI.Controls.NumUpDown();
            this.checkStopMonsterType = new SDUI.Controls.CheckBox();
            this.numPartyMemberDead = new SDUI.Controls.NumUpDown();
            this.checkStopPartyMemberDead = new SDUI.Controls.CheckBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numStayAtCenterSeconds)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numRadius)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPartyMember)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMonsterType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPartyMemberDead)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.btnBrowseWalkscript);
            this.groupBox1.Controls.Add(this.txtWalkbackScript);
            this.groupBox1.Controls.Add(this.radioStayAtCenter);
            this.groupBox1.Controls.Add(this.separator4);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.numStayAtCenterSeconds);
            this.groupBox1.Controls.Add(this.checkStayAtCenter);
            this.groupBox1.Controls.Add(this.btnBrowse);
            this.groupBox1.Controls.Add(this.radioUseScript);
            this.groupBox1.Controls.Add(this.radioWalkRandomly);
            this.groupBox1.Controls.Add(this.linkRecord);
            this.groupBox1.Controls.Add(this.txtScriptPath);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Location = new System.Drawing.Point(13, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 8, 3, 3);
            this.groupBox1.Radius = 10;
            this.groupBox1.ShadowDepth = 4;
            this.groupBox1.Size = new System.Drawing.Size(332, 429);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Location";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label5.Location = new System.Drawing.Point(18, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 15);
            this.label5.TabIndex = 29;
            this.label5.Text = "Script to location:";
            // 
            // btnBrowseWalkscript
            // 
            this.btnBrowseWalkscript.Color = System.Drawing.Color.Transparent;
            this.btnBrowseWalkscript.Location = new System.Drawing.Point(279, 52);
            this.btnBrowseWalkscript.Name = "btnBrowseWalkscript";
            this.btnBrowseWalkscript.Radius = 6;
            this.btnBrowseWalkscript.ShadowDepth = 4F;
            this.btnBrowseWalkscript.Size = new System.Drawing.Size(43, 23);
            this.btnBrowseWalkscript.TabIndex = 28;
            this.btnBrowseWalkscript.Text = "...";
            this.btnBrowseWalkscript.UseVisualStyleBackColor = true;
            this.btnBrowseWalkscript.Click += new System.EventHandler(this.btnBrowseWalkscript_Click);
            // 
            // txtWalkbackScript
            // 
            this.txtWalkbackScript.Location = new System.Drawing.Point(18, 54);
            this.txtWalkbackScript.MaxLength = 32767;
            this.txtWalkbackScript.MultiLine = false;
            this.txtWalkbackScript.Name = "txtWalkbackScript";
            this.txtWalkbackScript.Radius = 2;
            this.txtWalkbackScript.Size = new System.Drawing.Size(259, 21);
            this.txtWalkbackScript.TabIndex = 27;
            this.txtWalkbackScript.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtWalkbackScript.UseSystemPasswordChar = false;
            // 
            // radioStayAtCenter
            // 
            this.radioStayAtCenter.AutoSize = true;
            this.radioStayAtCenter.Location = new System.Drawing.Point(18, 256);
            this.radioStayAtCenter.Name = "radioStayAtCenter";
            this.radioStayAtCenter.ShadowDepth = 0;
            this.radioStayAtCenter.Size = new System.Drawing.Size(103, 15);
            this.radioStayAtCenter.TabIndex = 25;
            this.radioStayAtCenter.Text = "Stay at center";
            this.radioStayAtCenter.UseVisualStyleBackColor = true;
            this.radioStayAtCenter.CheckedChanged += new System.EventHandler(this.OnSettingsChanged);
            // 
            // separator4
            // 
            this.separator4.IsVertical = false;
            this.separator4.Location = new System.Drawing.Point(2, 337);
            this.separator4.Name = "separator4";
            this.separator4.Size = new System.Drawing.Size(328, 10);
            this.separator4.TabIndex = 15;
            this.separator4.Text = "separator4";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label7.Location = new System.Drawing.Point(266, 357);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 15);
            this.label7.TabIndex = 24;
            this.label7.Text = "second(s)";
            // 
            // numStayAtCenterSeconds
            // 
            this.numStayAtCenterSeconds.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.numStayAtCenterSeconds.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numStayAtCenterSeconds.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.numStayAtCenterSeconds.Location = new System.Drawing.Point(205, 355);
            this.numStayAtCenterSeconds.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numStayAtCenterSeconds.Name = "numStayAtCenterSeconds";
            this.numStayAtCenterSeconds.Size = new System.Drawing.Size(55, 23);
            this.numStayAtCenterSeconds.TabIndex = 23;
            this.numStayAtCenterSeconds.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numStayAtCenterSeconds.ValueChanged += new System.EventHandler(this.OnSettingsChanged);
            // 
            // checkStayAtCenter
            // 
            this.checkStayAtCenter.AutoSize = true;
            this.checkStayAtCenter.BackColor = System.Drawing.Color.Transparent;
            this.checkStayAtCenter.Location = new System.Drawing.Point(18, 358);
            this.checkStayAtCenter.Name = "checkStayAtCenter";
            this.checkStayAtCenter.ShadowDepth = 1;
            this.checkStayAtCenter.Size = new System.Drawing.Size(112, 15);
            this.checkStayAtCenter.TabIndex = 22;
            this.checkStayAtCenter.Text = "Stay at center for";
            this.checkStayAtCenter.UseVisualStyleBackColor = false;
            this.checkStayAtCenter.CheckedChanged += new System.EventHandler(this.OnSettingsChanged);
            // 
            // btnBrowse
            // 
            this.btnBrowse.Color = System.Drawing.Color.Transparent;
            this.btnBrowse.Location = new System.Drawing.Point(279, 304);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Radius = 6;
            this.btnBrowse.ShadowDepth = 4F;
            this.btnBrowse.Size = new System.Drawing.Size(43, 23);
            this.btnBrowse.TabIndex = 4;
            this.btnBrowse.Text = "...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // radioUseScript
            // 
            this.radioUseScript.AutoSize = true;
            this.radioUseScript.Location = new System.Drawing.Point(18, 280);
            this.radioUseScript.Name = "radioUseScript";
            this.radioUseScript.ShadowDepth = 0;
            this.radioUseScript.Size = new System.Drawing.Size(115, 15);
            this.radioUseScript.TabIndex = 2;
            this.radioUseScript.Text = "Use a lure script";
            this.radioUseScript.UseVisualStyleBackColor = true;
            this.radioUseScript.CheckedChanged += new System.EventHandler(this.OnSettingsChanged);
            // 
            // radioWalkRandomly
            // 
            this.radioWalkRandomly.AutoSize = true;
            this.radioWalkRandomly.Checked = true;
            this.radioWalkRandomly.Location = new System.Drawing.Point(18, 232);
            this.radioWalkRandomly.Name = "radioWalkRandomly";
            this.radioWalkRandomly.ShadowDepth = 0;
            this.radioWalkRandomly.Size = new System.Drawing.Size(112, 15);
            this.radioWalkRandomly.TabIndex = 1;
            this.radioWalkRandomly.TabStop = true;
            this.radioWalkRandomly.Text = "Walk randomly";
            this.radioWalkRandomly.UseVisualStyleBackColor = true;
            this.radioWalkRandomly.CheckedChanged += new System.EventHandler(this.OnSettingsChanged);
            // 
            // linkRecord
            // 
            this.linkRecord.AutoSize = true;
            this.linkRecord.Location = new System.Drawing.Point(224, 288);
            this.linkRecord.Name = "linkRecord";
            this.linkRecord.Size = new System.Drawing.Size(52, 15);
            this.linkRecord.TabIndex = 5;
            this.linkRecord.TabStop = true;
            this.linkRecord.Text = "[Record]";
            this.linkRecord.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkRecord_LinkClicked);
            // 
            // txtScriptPath
            // 
            this.txtScriptPath.Location = new System.Drawing.Point(18, 306);
            this.txtScriptPath.MaxLength = 32767;
            this.txtScriptPath.MultiLine = false;
            this.txtScriptPath.Name = "txtScriptPath";
            this.txtScriptPath.Radius = 2;
            this.txtScriptPath.Size = new System.Drawing.Size(259, 21);
            this.txtScriptPath.TabIndex = 3;
            this.txtScriptPath.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtScriptPath.UseSystemPasswordChar = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Border = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.panel1.BorderColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.btnSetCenter);
            this.panel1.Controls.Add(this.lblX);
            this.panel1.Controls.Add(this.lblY);
            this.panel1.Controls.Add(this.numRadius);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(-2, 91);
            this.panel1.Name = "panel1";
            this.panel1.Radius = 10;
            this.panel1.ShadowDepth = 4F;
            this.panel1.Size = new System.Drawing.Size(336, 121);
            this.panel1.TabIndex = 30;
            // 
            // btnSetCenter
            // 
            this.btnSetCenter.Color = System.Drawing.Color.Transparent;
            this.btnSetCenter.Location = new System.Drawing.Point(135, 83);
            this.btnSetCenter.Name = "btnSetCenter";
            this.btnSetCenter.Radius = 6;
            this.btnSetCenter.ShadowDepth = 4F;
            this.btnSetCenter.Size = new System.Drawing.Size(85, 23);
            this.btnSetCenter.TabIndex = 10;
            this.btnSetCenter.Text = "Set center";
            this.btnSetCenter.UseVisualStyleBackColor = true;
            this.btnSetCenter.Click += new System.EventHandler(this.btnSetCenter_Click);
            // 
            // lblX
            // 
            this.lblX.AutoSize = true;
            this.lblX.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblX.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblX.Location = new System.Drawing.Point(135, 15);
            this.lblX.Name = "lblX";
            this.lblX.Size = new System.Drawing.Size(14, 15);
            this.lblX.TabIndex = 12;
            this.lblX.Text = "0";
            // 
            // lblY
            // 
            this.lblY.AutoSize = true;
            this.lblY.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblY.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblY.Location = new System.Drawing.Point(135, 34);
            this.lblY.Name = "lblY";
            this.lblY.Size = new System.Drawing.Size(14, 15);
            this.lblY.TabIndex = 11;
            this.lblY.Text = "0";
            // 
            // numRadius
            // 
            this.numRadius.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.numRadius.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numRadius.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.numRadius.Location = new System.Drawing.Point(135, 57);
            this.numRadius.Name = "numRadius";
            this.numRadius.Size = new System.Drawing.Size(85, 23);
            this.numRadius.TabIndex = 13;
            this.numRadius.ValueChanged += new System.EventHandler(this.OnSettingsChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(112, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 15);
            this.label1.TabIndex = 9;
            this.label1.Text = "X:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(84, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "Radius:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(112, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 15);
            this.label2.TabIndex = 8;
            this.label2.Text = "Y:";
            // 
            // checkUseNormalAttack
            // 
            this.checkUseNormalAttack.AutoSize = true;
            this.checkUseNormalAttack.BackColor = System.Drawing.Color.Transparent;
            this.checkUseNormalAttack.Location = new System.Drawing.Point(26, 90);
            this.checkUseNormalAttack.Name = "checkUseNormalAttack";
            this.checkUseNormalAttack.ShadowDepth = 1;
            this.checkUseNormalAttack.Size = new System.Drawing.Size(217, 15);
            this.checkUseNormalAttack.TabIndex = 1;
            this.checkUseNormalAttack.Text = "Use normal attack and switch target*";
            this.checkUseNormalAttack.UseVisualStyleBackColor = false;
            this.checkUseNormalAttack.CheckedChanged += new System.EventHandler(this.OnSettingsChanged);
            // 
            // checkUseHowlingShout
            // 
            this.checkUseHowlingShout.AutoSize = true;
            this.checkUseHowlingShout.BackColor = System.Drawing.Color.Transparent;
            this.checkUseHowlingShout.Location = new System.Drawing.Point(26, 40);
            this.checkUseHowlingShout.Name = "checkUseHowlingShout";
            this.checkUseHowlingShout.ShadowDepth = 1;
            this.checkUseHowlingShout.Size = new System.Drawing.Size(176, 15);
            this.checkUseHowlingShout.TabIndex = 0;
            this.checkUseHowlingShout.Text = "Cast howling shout (only EU)";
            this.checkUseHowlingShout.UseVisualStyleBackColor = false;
            this.checkUseHowlingShout.CheckedChanged += new System.EventHandler(this.OnSettingsChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.checkUseAttackingSkills);
            this.groupBox3.Controls.Add(this.checkNoHowlingAtCenter);
            this.groupBox3.Controls.Add(this.separator1);
            this.groupBox3.Controls.Add(this.checkUseNormalAttack);
            this.groupBox3.Controls.Add(this.checkUseHowlingShout);
            this.groupBox3.Controls.Add(this.separator2);
            this.groupBox3.Controls.Add(this.numPartyMember);
            this.groupBox3.Controls.Add(this.checkStopPartyMember);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.comboMonsterType);
            this.groupBox3.Controls.Add(this.numMonsterType);
            this.groupBox3.Controls.Add(this.checkStopMonsterType);
            this.groupBox3.Controls.Add(this.numPartyMemberDead);
            this.groupBox3.Controls.Add(this.checkStopPartyMemberDead);
            this.groupBox3.Location = new System.Drawing.Point(359, 11);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 8, 3, 3);
            this.groupBox3.Radius = 10;
            this.groupBox3.ShadowDepth = 4;
            this.groupBox3.Size = new System.Drawing.Size(391, 344);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Settings";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label4.Location = new System.Drawing.Point(26, 315);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(304, 15);
            this.label4.TabIndex = 26;
            this.label4.Text = "* not available for scripts. Record skills in the script itself.";
            // 
            // checkUseAttackingSkills
            // 
            this.checkUseAttackingSkills.AutoSize = true;
            this.checkUseAttackingSkills.BackColor = System.Drawing.Color.Transparent;
            this.checkUseAttackingSkills.Location = new System.Drawing.Point(26, 113);
            this.checkUseAttackingSkills.Name = "checkUseAttackingSkills";
            this.checkUseAttackingSkills.ShadowDepth = 1;
            this.checkUseAttackingSkills.Size = new System.Drawing.Size(216, 15);
            this.checkUseAttackingSkills.TabIndex = 27;
            this.checkUseAttackingSkills.Text = "Use attacking skill and switch target*";
            this.checkUseAttackingSkills.UseVisualStyleBackColor = false;
            this.checkUseAttackingSkills.CheckedChanged += new System.EventHandler(this.OnSettingsChanged);
            // 
            // checkNoHowlingAtCenter
            // 
            this.checkNoHowlingAtCenter.AutoSize = true;
            this.checkNoHowlingAtCenter.BackColor = System.Drawing.Color.Transparent;
            this.checkNoHowlingAtCenter.Location = new System.Drawing.Point(45, 61);
            this.checkNoHowlingAtCenter.Name = "checkNoHowlingAtCenter";
            this.checkNoHowlingAtCenter.ShadowDepth = 1;
            this.checkNoHowlingAtCenter.Size = new System.Drawing.Size(138, 15);
            this.checkNoHowlingAtCenter.TabIndex = 26;
            this.checkNoHowlingAtCenter.Text = "Don\'t cast near center";
            this.checkNoHowlingAtCenter.UseVisualStyleBackColor = false;
            this.checkNoHowlingAtCenter.CheckedChanged += new System.EventHandler(this.OnSettingsChanged);
            // 
            // separator1
            // 
            this.separator1.IsVertical = false;
            this.separator1.Location = new System.Drawing.Point(0, 135);
            this.separator1.Name = "separator1";
            this.separator1.Size = new System.Drawing.Size(392, 10);
            this.separator1.TabIndex = 25;
            this.separator1.Text = "separator1";
            // 
            // separator2
            // 
            this.separator2.IsVertical = false;
            this.separator2.Location = new System.Drawing.Point(2, 277);
            this.separator2.Name = "separator2";
            this.separator2.Size = new System.Drawing.Size(392, 10);
            this.separator2.TabIndex = 21;
            this.separator2.Text = "separator2";
            // 
            // numPartyMember
            // 
            this.numPartyMember.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.numPartyMember.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numPartyMember.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.numPartyMember.Location = new System.Drawing.Point(220, 185);
            this.numPartyMember.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.numPartyMember.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numPartyMember.Name = "numPartyMember";
            this.numPartyMember.Size = new System.Drawing.Size(55, 23);
            this.numPartyMember.TabIndex = 20;
            this.numPartyMember.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numPartyMember.ValueChanged += new System.EventHandler(this.OnSettingsChanged);
            // 
            // checkStopPartyMember
            // 
            this.checkStopPartyMember.AutoSize = true;
            this.checkStopPartyMember.BackColor = System.Drawing.Color.Transparent;
            this.checkStopPartyMember.Location = new System.Drawing.Point(26, 188);
            this.checkStopPartyMember.Name = "checkStopPartyMember";
            this.checkStopPartyMember.ShadowDepth = 1;
            this.checkStopPartyMember.Size = new System.Drawing.Size(177, 15);
            this.checkStopPartyMember.TabIndex = 19;
            this.checkStopPartyMember.Text = "Stop num party members <=";
            this.checkStopPartyMember.UseVisualStyleBackColor = false;
            this.checkStopPartyMember.CheckedChanged += new System.EventHandler(this.OnSettingsChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label6.Location = new System.Drawing.Point(191, 247);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(23, 15);
            this.label6.TabIndex = 18;
            this.label6.Text = ">=";
            // 
            // comboMonsterType
            // 
            this.comboMonsterType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboMonsterType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboMonsterType.FormattingEnabled = true;
            this.comboMonsterType.Items.AddRange(new object[] {
            "General (Default)",
            "Champion",
            "Giant",
            "General (Party)",
            "Champion (Party)",
            "Giant (Party)",
            "Elite",
            "Strong",
            "Unique",
            "Event"});
            this.comboMonsterType.Location = new System.Drawing.Point(45, 244);
            this.comboMonsterType.Name = "comboMonsterType";
            this.comboMonsterType.Radius = 5;
            this.comboMonsterType.ShadowDepth = 4F;
            this.comboMonsterType.Size = new System.Drawing.Size(140, 24);
            this.comboMonsterType.TabIndex = 17;
            this.comboMonsterType.SelectedIndexChanged += new System.EventHandler(this.comboMonsterType_SelectedIndexChanged);
            // 
            // numMonsterType
            // 
            this.numMonsterType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.numMonsterType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numMonsterType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.numMonsterType.Location = new System.Drawing.Point(220, 245);
            this.numMonsterType.Name = "numMonsterType";
            this.numMonsterType.Size = new System.Drawing.Size(55, 23);
            this.numMonsterType.TabIndex = 16;
            this.numMonsterType.ValueChanged += new System.EventHandler(this.OnSettingsChanged);
            // 
            // checkStopMonsterType
            // 
            this.checkStopMonsterType.AutoSize = true;
            this.checkStopMonsterType.BackColor = System.Drawing.Color.Transparent;
            this.checkStopMonsterType.Location = new System.Drawing.Point(26, 218);
            this.checkStopMonsterType.Name = "checkStopMonsterType";
            this.checkStopMonsterType.ShadowDepth = 1;
            this.checkStopMonsterType.Size = new System.Drawing.Size(172, 15);
            this.checkStopMonsterType.TabIndex = 15;
            this.checkStopMonsterType.Text = "Stop if num monster of type";
            this.checkStopMonsterType.UseVisualStyleBackColor = false;
            this.checkStopMonsterType.CheckedChanged += new System.EventHandler(this.OnSettingsChanged);
            // 
            // numPartyMemberDead
            // 
            this.numPartyMemberDead.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.numPartyMemberDead.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numPartyMemberDead.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.numPartyMemberDead.Location = new System.Drawing.Point(220, 154);
            this.numPartyMemberDead.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.numPartyMemberDead.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numPartyMemberDead.Name = "numPartyMemberDead";
            this.numPartyMemberDead.Size = new System.Drawing.Size(55, 23);
            this.numPartyMemberDead.TabIndex = 14;
            this.numPartyMemberDead.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numPartyMemberDead.ValueChanged += new System.EventHandler(this.OnSettingsChanged);
            // 
            // checkStopPartyMemberDead
            // 
            this.checkStopPartyMemberDead.AutoSize = true;
            this.checkStopPartyMemberDead.BackColor = System.Drawing.Color.Transparent;
            this.checkStopPartyMemberDead.Location = new System.Drawing.Point(26, 157);
            this.checkStopPartyMemberDead.Name = "checkStopPartyMemberDead";
            this.checkStopPartyMemberDead.ShadowDepth = 1;
            this.checkStopPartyMemberDead.Size = new System.Drawing.Size(188, 15);
            this.checkStopPartyMemberDead.TabIndex = 6;
            this.checkStopPartyMemberDead.Text = "Stop if dead party members >=";
            this.checkStopPartyMemberDead.UseVisualStyleBackColor = false;
            this.checkStopPartyMemberDead.CheckedChanged += new System.EventHandler(this.OnSettingsChanged);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Name = "Main";
            this.Size = new System.Drawing.Size(824, 515);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numStayAtCenterSeconds)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numRadius)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPartyMember)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMonsterType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPartyMemberDead)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private SDUI.Controls.GroupBox groupBox1;
        private SDUI.Controls.Button btnSetCenter;
        private SDUI.Controls.Label label3;
        private SDUI.Controls.Label label2;
        private SDUI.Controls.Label label1;
        private SDUI.Controls.Label lblY;
        private SDUI.Controls.Label lblX;
        private SDUI.Controls.NumUpDown numRadius;
        private SDUI.Controls.GroupBox groupBox3;
        private SDUI.Controls.Button btnBrowse;
        private SDUI.Controls.TextBox txtScriptPath;
        private SDUI.Controls.Radio radioUseScript;
        private SDUI.Controls.Radio radioWalkRandomly;
        private System.Windows.Forms.LinkLabel linkRecord;
        private SDUI.Controls.Label label6;
        private SDUI.Controls.ComboBox comboMonsterType;
        private SDUI.Controls.NumUpDown numMonsterType;
        private SDUI.Controls.CheckBox checkStopMonsterType;
        private SDUI.Controls.NumUpDown numPartyMemberDead;
        private SDUI.Controls.CheckBox checkStopPartyMemberDead;
        private SDUI.Controls.CheckBox checkUseNormalAttack;
        private SDUI.Controls.CheckBox checkUseHowlingShout;
        private SDUI.Controls.NumUpDown numPartyMember;
        private SDUI.Controls.CheckBox checkStopPartyMember;
        private SDUI.Controls.Label label7;
        private SDUI.Controls.NumUpDown numStayAtCenterSeconds;
        private SDUI.Controls.CheckBox checkStayAtCenter;
        private SDUI.Controls.Separator separator2;
        private SDUI.Controls.Separator separator1;
        private SDUI.Controls.Separator separator4;
        private SDUI.Controls.Radio radioStayAtCenter;
        private SDUI.Controls.CheckBox checkNoHowlingAtCenter;
        private SDUI.Controls.CheckBox checkUseAttackingSkills;
        private SDUI.Controls.Label label4;
        private SDUI.Controls.Label label5;
        private SDUI.Controls.Button btnBrowseWalkscript;
        private SDUI.Controls.TextBox txtWalkbackScript;
        private SDUI.Controls.Panel panel1;
    }
}
