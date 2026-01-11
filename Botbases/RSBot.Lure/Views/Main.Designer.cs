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
            groupBox1 = new SDUI.Controls.GroupBox();
            label5 = new SDUI.Controls.Label();
            btnBrowseWalkscript = new SDUI.Controls.Button();
            txtWalkbackScript = new SDUI.Controls.TextBox();
            radioStayAtCenter = new SDUI.Controls.Radio();
            separator4 = new SDUI.Controls.Separator();
            label7 = new SDUI.Controls.Label();
            numStayAtCenterSeconds = new SDUI.Controls.NumUpDown();
            checkStayAtCenter = new SDUI.Controls.CheckBox();
            btnBrowse = new SDUI.Controls.Button();
            radioUseScript = new SDUI.Controls.Radio();
            radioWalkRandomly = new SDUI.Controls.Radio();
            linkRecord = new SDUI.Controls.Button();
            txtScriptPath = new SDUI.Controls.TextBox();
            panel1 = new SDUI.Controls.Panel();
            btnSetCenter = new SDUI.Controls.Button();
            lblX = new SDUI.Controls.Label();
            lblY = new SDUI.Controls.Label();
            numRadius = new SDUI.Controls.NumUpDown();
            label1 = new SDUI.Controls.Label();
            label3 = new SDUI.Controls.Label();
            label2 = new SDUI.Controls.Label();
            checkUseNormalAttack = new SDUI.Controls.CheckBox();
            checkUseHowlingShout = new SDUI.Controls.CheckBox();
            groupBox3 = new SDUI.Controls.GroupBox();
            label4 = new SDUI.Controls.Label();
            checkUseAttackingSkills = new SDUI.Controls.CheckBox();
            checkNoHowlingAtCenter = new SDUI.Controls.CheckBox();
            separator1 = new SDUI.Controls.Separator();
            separator2 = new SDUI.Controls.Separator();
            numPartyMember = new SDUI.Controls.NumUpDown();
            checkStopPartyMember = new SDUI.Controls.CheckBox();
            label6 = new SDUI.Controls.Label();
            comboMonsterType = new SDUI.Controls.ComboBox();
            numMonsterType = new SDUI.Controls.NumUpDown();
            checkStopMonsterType = new SDUI.Controls.CheckBox();
            numPartyMemberDead = new SDUI.Controls.NumUpDown();
            checkStopPartyMemberDead = new SDUI.Controls.CheckBox();
            numPartyMembersOnSpot = new SDUI.Controls.NumUpDown();
            checkNumPartyMembersOnSpot = new SDUI.Controls.CheckBox();
            groupBox1.SuspendLayout();
            panel1.SuspendLayout();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.BackColor = System.Drawing.Color.Transparent;
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
            groupBox1.Location = new System.Drawing.Point(15, 15);
            groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new System.Windows.Forms.Padding(3, 11, 3, 4);
            groupBox1.Radius = 10;
            groupBox1.ShadowDepth = 4;
            groupBox1.Size = new System.Drawing.Size(379, 572);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Location";
            // 
            // label5
            // 
            label5.ApplyGradient = false;
            label5.AutoSize = true;
            label5.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            label5.Gradient = new System.Drawing.Color[]
    {
    System.Drawing.Color.Gray,
    System.Drawing.Color.Black
    };
            label5.GradientAnimation = false;
            label5.Location = new System.Drawing.Point(21, 41);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(126, 20);
            label5.TabIndex = 29;
            label5.Text = "Script to location:";
            // 
            // btnBrowseWalkscript
            // 
            btnBrowseWalkscript.Color = System.Drawing.Color.Transparent;
            btnBrowseWalkscript.Location = new System.Drawing.Point(319, 69);
            btnBrowseWalkscript.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btnBrowseWalkscript.Name = "btnBrowseWalkscript";
            btnBrowseWalkscript.Radius = 6;
            btnBrowseWalkscript.ShadowDepth = 4F;
            btnBrowseWalkscript.Size = new System.Drawing.Size(49, 31);
            btnBrowseWalkscript.TabIndex = 28;
            btnBrowseWalkscript.Text = "...";
            btnBrowseWalkscript.UseVisualStyleBackColor = true;
            btnBrowseWalkscript.Click += btnBrowseWalkscript_Click;
            // 
            // txtWalkbackScript
            // 
            txtWalkbackScript.Location = new System.Drawing.Point(21, 72);
            txtWalkbackScript.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            txtWalkbackScript.MaxLength = 32767;
            txtWalkbackScript.MultiLine = false;
            txtWalkbackScript.Name = "txtWalkbackScript";
            txtWalkbackScript.PassFocusShow = false;
            txtWalkbackScript.Radius = 2;
            txtWalkbackScript.Size = new System.Drawing.Size(296, 25);
            txtWalkbackScript.TabIndex = 27;
            txtWalkbackScript.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            txtWalkbackScript.UseSystemPasswordChar = false;
            // 
            // radioStayAtCenter
            // 
            radioStayAtCenter.AutoSize = true;
            radioStayAtCenter.Location = new System.Drawing.Point(21, 339);
            radioStayAtCenter.Margin = new System.Windows.Forms.Padding(0);
            radioStayAtCenter.Name = "radioStayAtCenter";
            radioStayAtCenter.Ripple = true;
            radioStayAtCenter.Size = new System.Drawing.Size(124, 30);
            radioStayAtCenter.TabIndex = 25;
            radioStayAtCenter.Text = "Stay at center";
            radioStayAtCenter.UseVisualStyleBackColor = true;
            radioStayAtCenter.CheckedChanged += OnSettingsChanged;
            // 
            // separator4
            // 
            separator4.IsVertical = false;
            separator4.Location = new System.Drawing.Point(2, 464);
            separator4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            separator4.Name = "separator4";
            separator4.Size = new System.Drawing.Size(375, 13);
            separator4.TabIndex = 15;
            // 
            // label7
            // 
            label7.ApplyGradient = false;
            label7.AutoSize = true;
            label7.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            label7.Gradient = new System.Drawing.Color[]
    {
    System.Drawing.Color.Gray,
    System.Drawing.Color.Black
    };
            label7.GradientAnimation = false;
            label7.Location = new System.Drawing.Point(291, 499);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(72, 20);
            label7.TabIndex = 24;
            label7.Text = "second(s)";
            // 
            // numStayAtCenterSeconds
            // 
            numStayAtCenterSeconds.BackColor = System.Drawing.Color.Transparent;
            numStayAtCenterSeconds.Font = new System.Drawing.Font("Segoe UI", 9.25F);
            numStayAtCenterSeconds.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            numStayAtCenterSeconds.Location = new System.Drawing.Point(193, 491);
            numStayAtCenterSeconds.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            numStayAtCenterSeconds.Maximum = new decimal(new int[] { 100, 0, 0, 0 });
            numStayAtCenterSeconds.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numStayAtCenterSeconds.MinimumSize = new System.Drawing.Size(91, 33);
            numStayAtCenterSeconds.Name = "numStayAtCenterSeconds";
            numStayAtCenterSeconds.Size = new System.Drawing.Size(91, 33);
            numStayAtCenterSeconds.TabIndex = 23;
            numStayAtCenterSeconds.Value = new decimal(new int[] { 1, 0, 0, 0 });
            numStayAtCenterSeconds.ValueChanged += OnSettingsChanged;
            // 
            // checkStayAtCenter
            // 
            checkStayAtCenter.AutoSize = true;
            checkStayAtCenter.BackColor = System.Drawing.Color.Transparent;
            checkStayAtCenter.Depth = 0;
            checkStayAtCenter.Location = new System.Drawing.Point(21, 489);
            checkStayAtCenter.Margin = new System.Windows.Forms.Padding(0);
            checkStayAtCenter.MouseLocation = new System.Drawing.Point(-1, -1);
            checkStayAtCenter.Name = "checkStayAtCenter";
            checkStayAtCenter.Ripple = true;
            checkStayAtCenter.Size = new System.Drawing.Size(148, 30);
            checkStayAtCenter.TabIndex = 22;
            checkStayAtCenter.Text = "Stay at center for";
            checkStayAtCenter.UseVisualStyleBackColor = false;
            checkStayAtCenter.CheckedChanged += OnSettingsChanged;
            // 
            // btnBrowse
            // 
            btnBrowse.Color = System.Drawing.Color.Transparent;
            btnBrowse.Location = new System.Drawing.Point(319, 420);
            btnBrowse.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btnBrowse.Name = "btnBrowse";
            btnBrowse.Radius = 6;
            btnBrowse.ShadowDepth = 4F;
            btnBrowse.Size = new System.Drawing.Size(49, 31);
            btnBrowse.TabIndex = 4;
            btnBrowse.Text = "...";
            btnBrowse.UseVisualStyleBackColor = true;
            btnBrowse.Click += btnBrowse_Click;
            // 
            // radioUseScript
            // 
            radioUseScript.AutoSize = true;
            radioUseScript.Location = new System.Drawing.Point(21, 376);
            radioUseScript.Margin = new System.Windows.Forms.Padding(0);
            radioUseScript.Name = "radioUseScript";
            radioUseScript.Ripple = true;
            radioUseScript.Size = new System.Drawing.Size(140, 30);
            radioUseScript.TabIndex = 2;
            radioUseScript.Text = "Use a lure script";
            radioUseScript.UseVisualStyleBackColor = true;
            radioUseScript.CheckedChanged += OnSettingsChanged;
            // 
            // radioWalkRandomly
            // 
            radioWalkRandomly.AutoSize = true;
            radioWalkRandomly.Checked = true;
            radioWalkRandomly.Location = new System.Drawing.Point(21, 301);
            radioWalkRandomly.Margin = new System.Windows.Forms.Padding(0);
            radioWalkRandomly.Name = "radioWalkRandomly";
            radioWalkRandomly.Ripple = true;
            radioWalkRandomly.Size = new System.Drawing.Size(134, 30);
            radioWalkRandomly.TabIndex = 1;
            radioWalkRandomly.TabStop = true;
            radioWalkRandomly.Text = "Walk randomly";
            radioWalkRandomly.UseVisualStyleBackColor = true;
            radioWalkRandomly.CheckedChanged += OnSettingsChanged;
            // 
            // linkRecord
            // 
            linkRecord.AutoSize = true;
            linkRecord.Location = new System.Drawing.Point(256, 397);
            linkRecord.Name = "linkRecord";
            linkRecord.Size = new System.Drawing.Size(66, 20);
            linkRecord.TabIndex = 5;
            linkRecord.TabStop = true;
            linkRecord.Text = "[Record]";
            linkRecord.Click += linkRecord_LinkClicked;
            // 
            // txtScriptPath
            // 
            txtScriptPath.Location = new System.Drawing.Point(21, 421);
            txtScriptPath.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            txtScriptPath.MaxLength = 32767;
            txtScriptPath.MultiLine = false;
            txtScriptPath.Name = "txtScriptPath";
            txtScriptPath.PassFocusShow = false;
            txtScriptPath.Radius = 2;
            txtScriptPath.Size = new System.Drawing.Size(296, 25);
            txtScriptPath.TabIndex = 3;
            txtScriptPath.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            txtScriptPath.UseSystemPasswordChar = false;
            // 
            // panel1
            // 
            panel1.BackColor = System.Drawing.Color.Transparent;
            panel1.Border = new System.Windows.Forms.Padding(0, 0, 0, 0);
            panel1.BorderColor = System.Drawing.Color.Transparent;
            panel1.Controls.Add(btnSetCenter);
            panel1.Controls.Add(lblX);
            panel1.Controls.Add(lblY);
            panel1.Controls.Add(numRadius);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Location = new System.Drawing.Point(-2, 121);
            panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Radius = 10;
            panel1.ShadowDepth = 4F;
            panel1.Size = new System.Drawing.Size(384, 161);
            panel1.TabIndex = 30;
            // 
            // btnSetCenter
            // 
            btnSetCenter.Color = System.Drawing.Color.Transparent;
            btnSetCenter.Location = new System.Drawing.Point(154, 112);
            btnSetCenter.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btnSetCenter.Name = "btnSetCenter";
            btnSetCenter.Radius = 6;
            btnSetCenter.ShadowDepth = 4F;
            btnSetCenter.Size = new System.Drawing.Size(97, 31);
            btnSetCenter.TabIndex = 10;
            btnSetCenter.Text = "Set center";
            btnSetCenter.UseVisualStyleBackColor = true;
            btnSetCenter.Click += btnSetCenter_Click;
            // 
            // lblX
            // 
            lblX.ApplyGradient = false;
            lblX.AutoSize = true;
            lblX.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            lblX.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            lblX.Gradient = new System.Drawing.Color[]
    {
    System.Drawing.Color.Gray,
    System.Drawing.Color.Black
    };
            lblX.GradientAnimation = false;
            lblX.Location = new System.Drawing.Point(154, 20);
            lblX.Name = "lblX";
            lblX.Size = new System.Drawing.Size(18, 20);
            lblX.TabIndex = 12;
            lblX.Text = "0";
            // 
            // lblY
            // 
            lblY.ApplyGradient = false;
            lblY.AutoSize = true;
            lblY.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            lblY.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            lblY.Gradient = new System.Drawing.Color[]
    {
    System.Drawing.Color.Gray,
    System.Drawing.Color.Black
    };
            lblY.GradientAnimation = false;
            lblY.Location = new System.Drawing.Point(154, 45);
            lblY.Name = "lblY";
            lblY.Size = new System.Drawing.Size(18, 20);
            lblY.TabIndex = 11;
            lblY.Text = "0";
            // 
            // numRadius
            // 
            numRadius.BackColor = System.Drawing.Color.Transparent;
            numRadius.Font = new System.Drawing.Font("Segoe UI", 9.25F);
            numRadius.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            numRadius.Location = new System.Drawing.Point(154, 71);
            numRadius.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            numRadius.Maximum = new decimal(new int[] { 100, 0, 0, 0 });
            numRadius.Minimum = new decimal(new int[] { 0, 0, 0, 0 });
            numRadius.MinimumSize = new System.Drawing.Size(91, 33);
            numRadius.Name = "numRadius";
            numRadius.Size = new System.Drawing.Size(97, 33);
            numRadius.TabIndex = 13;
            numRadius.Value = new decimal(new int[] { 0, 0, 0, 0 });
            numRadius.ValueChanged += OnSettingsChanged;
            // 
            // label1
            // 
            label1.ApplyGradient = false;
            label1.AutoSize = true;
            label1.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            label1.Gradient = new System.Drawing.Color[]
    {
    System.Drawing.Color.Gray,
    System.Drawing.Color.Black
    };
            label1.GradientAnimation = false;
            label1.Location = new System.Drawing.Point(128, 20);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(21, 20);
            label1.TabIndex = 9;
            label1.Text = "X:";
            // 
            // label3
            // 
            label3.ApplyGradient = false;
            label3.AutoSize = true;
            label3.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            label3.Gradient = new System.Drawing.Color[]
    {
    System.Drawing.Color.Gray,
    System.Drawing.Color.Black
    };
            label3.GradientAnimation = false;
            label3.Location = new System.Drawing.Point(96, 79);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(56, 20);
            label3.TabIndex = 7;
            label3.Text = "Radius:";
            // 
            // label2
            // 
            label2.ApplyGradient = false;
            label2.AutoSize = true;
            label2.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            label2.Gradient = new System.Drawing.Color[]
    {
    System.Drawing.Color.Gray,
    System.Drawing.Color.Black
    };
            label2.GradientAnimation = false;
            label2.Location = new System.Drawing.Point(128, 45);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(20, 20);
            label2.TabIndex = 8;
            label2.Text = "Y:";
            // 
            // checkUseNormalAttack
            // 
            checkUseNormalAttack.AutoSize = true;
            checkUseNormalAttack.BackColor = System.Drawing.Color.Transparent;
            checkUseNormalAttack.Depth = 0;
            checkUseNormalAttack.Location = new System.Drawing.Point(30, 116);
            checkUseNormalAttack.Margin = new System.Windows.Forms.Padding(0);
            checkUseNormalAttack.MouseLocation = new System.Drawing.Point(-1, -1);
            checkUseNormalAttack.Name = "checkUseNormalAttack";
            checkUseNormalAttack.Ripple = true;
            checkUseNormalAttack.Size = new System.Drawing.Size(278, 30);
            checkUseNormalAttack.TabIndex = 1;
            checkUseNormalAttack.Text = "Use normal attack and switch target*";
            checkUseNormalAttack.UseVisualStyleBackColor = false;
            checkUseNormalAttack.CheckedChanged += OnSettingsChanged;
            // 
            // checkUseHowlingShout
            // 
            checkUseHowlingShout.AutoSize = true;
            checkUseHowlingShout.BackColor = System.Drawing.Color.Transparent;
            checkUseHowlingShout.Depth = 0;
            checkUseHowlingShout.Location = new System.Drawing.Point(30, 48);
            checkUseHowlingShout.Margin = new System.Windows.Forms.Padding(0);
            checkUseHowlingShout.MouseLocation = new System.Drawing.Point(-1, -1);
            checkUseHowlingShout.Name = "checkUseHowlingShout";
            checkUseHowlingShout.Ripple = true;
            checkUseHowlingShout.Size = new System.Drawing.Size(224, 30);
            checkUseHowlingShout.TabIndex = 0;
            checkUseHowlingShout.Text = "Cast howling shout (only EU)";
            checkUseHowlingShout.UseVisualStyleBackColor = false;
            checkUseHowlingShout.CheckedChanged += OnSettingsChanged;
            // 
            // groupBox3
            // 
            groupBox3.BackColor = System.Drawing.Color.Transparent;
            groupBox3.Controls.Add(numPartyMembersOnSpot);
            groupBox3.Controls.Add(checkNumPartyMembersOnSpot);
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
            groupBox3.Location = new System.Drawing.Point(410, 15);
            groupBox3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new System.Windows.Forms.Padding(3, 11, 3, 4);
            groupBox3.Radius = 10;
            groupBox3.ShadowDepth = 4;
            groupBox3.Size = new System.Drawing.Size(447, 493);
            groupBox3.TabIndex = 2;
            groupBox3.TabStop = false;
            groupBox3.Text = "Settings";
            // 
            // label4
            // 
            label4.ApplyGradient = false;
            label4.AutoSize = true;
            label4.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            label4.Gradient = new System.Drawing.Color[]
    {
    System.Drawing.Color.Gray,
    System.Drawing.Color.Black
    };
            label4.GradientAnimation = false;
            label4.Location = new System.Drawing.Point(30, 431);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(383, 20);
            label4.TabIndex = 26;
            label4.Text = "* not available for scripts. Record skills in the script itself.";
            // 
            // checkUseAttackingSkills
            // 
            checkUseAttackingSkills.AutoSize = true;
            checkUseAttackingSkills.BackColor = System.Drawing.Color.Transparent;
            checkUseAttackingSkills.Depth = 0;
            checkUseAttackingSkills.Location = new System.Drawing.Point(30, 151);
            checkUseAttackingSkills.Margin = new System.Windows.Forms.Padding(0);
            checkUseAttackingSkills.MouseLocation = new System.Drawing.Point(-1, -1);
            checkUseAttackingSkills.Name = "checkUseAttackingSkills";
            checkUseAttackingSkills.Ripple = true;
            checkUseAttackingSkills.Size = new System.Drawing.Size(277, 30);
            checkUseAttackingSkills.TabIndex = 27;
            checkUseAttackingSkills.Text = "Use attacking skill and switch target*";
            checkUseAttackingSkills.UseVisualStyleBackColor = false;
            checkUseAttackingSkills.CheckedChanged += OnSettingsChanged;
            // 
            // checkNoHowlingAtCenter
            // 
            checkNoHowlingAtCenter.AutoSize = true;
            checkNoHowlingAtCenter.BackColor = System.Drawing.Color.Transparent;
            checkNoHowlingAtCenter.Depth = 0;
            checkNoHowlingAtCenter.Location = new System.Drawing.Point(51, 77);
            checkNoHowlingAtCenter.Margin = new System.Windows.Forms.Padding(0);
            checkNoHowlingAtCenter.MouseLocation = new System.Drawing.Point(-1, -1);
            checkNoHowlingAtCenter.Name = "checkNoHowlingAtCenter";
            checkNoHowlingAtCenter.Ripple = true;
            checkNoHowlingAtCenter.Size = new System.Drawing.Size(179, 30);
            checkNoHowlingAtCenter.TabIndex = 26;
            checkNoHowlingAtCenter.Text = "Don't cast near center";
            checkNoHowlingAtCenter.UseVisualStyleBackColor = false;
            checkNoHowlingAtCenter.CheckedChanged += OnSettingsChanged;
            // 
            // separator1
            // 
            separator1.IsVertical = false;
            separator1.Location = new System.Drawing.Point(0, 189);
            separator1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            separator1.Name = "separator1";
            separator1.Size = new System.Drawing.Size(448, 13);
            separator1.TabIndex = 25;
            // 
            // separator2
            // 
            separator2.IsVertical = false;
            separator2.Location = new System.Drawing.Point(0, 414);
            separator2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            separator2.Name = "separator2";
            separator2.Size = new System.Drawing.Size(448, 13);
            separator2.TabIndex = 21;
            // 
            // numPartyMember
            // 
            numPartyMember.BackColor = System.Drawing.Color.Transparent;
            numPartyMember.Font = new System.Drawing.Font("Segoe UI", 9.25F);
            numPartyMember.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            numPartyMember.Location = new System.Drawing.Point(257, 257);
            numPartyMember.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            numPartyMember.Maximum = new decimal(new int[] { 8, 0, 0, 0 });
            numPartyMember.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numPartyMember.MinimumSize = new System.Drawing.Size(91, 33);
            numPartyMember.Name = "numPartyMember";
            numPartyMember.Size = new System.Drawing.Size(91, 33);
            numPartyMember.TabIndex = 20;
            numPartyMember.Value = new decimal(new int[] { 1, 0, 0, 0 });
            numPartyMember.ValueChanged += OnSettingsChanged;
            // 
            // checkStopPartyMember
            // 
            checkStopPartyMember.AutoSize = true;
            checkStopPartyMember.BackColor = System.Drawing.Color.Transparent;
            checkStopPartyMember.Depth = 0;
            checkStopPartyMember.Location = new System.Drawing.Point(30, 255);
            checkStopPartyMember.Margin = new System.Windows.Forms.Padding(0);
            checkStopPartyMember.MouseLocation = new System.Drawing.Point(-1, -1);
            checkStopPartyMember.Name = "checkStopPartyMember";
            checkStopPartyMember.Ripple = true;
            checkStopPartyMember.Size = new System.Drawing.Size(227, 30);
            checkStopPartyMember.TabIndex = 19;
            checkStopPartyMember.Text = "Stop num party members <=";
            checkStopPartyMember.UseVisualStyleBackColor = false;
            checkStopPartyMember.CheckedChanged += OnSettingsChanged;
            // 
            // label6
            // 
            label6.ApplyGradient = false;
            label6.AutoSize = true;
            label6.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            label6.Gradient = new System.Drawing.Color[]
    {
    System.Drawing.Color.Gray,
    System.Drawing.Color.Black
    };
            label6.GradientAnimation = false;
            label6.Location = new System.Drawing.Point(218, 382);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(29, 20);
            label6.TabIndex = 18;
            label6.Text = ">=";
            // 
            // comboMonsterType
            // 
            comboMonsterType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            comboMonsterType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboMonsterType.FormattingEnabled = true;
            comboMonsterType.Items.AddRange(new object[] { "General (Default)", "Champion", "Giant", "General (Party)", "Champion (Party)", "Giant (Party)", "Elite", "Strong", "Unique", "Event" });
            comboMonsterType.Location = new System.Drawing.Point(51, 378);
            comboMonsterType.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            comboMonsterType.Name = "comboMonsterType";
            comboMonsterType.Radius = 5;
            comboMonsterType.ShadowDepth = 4F;
            comboMonsterType.Size = new System.Drawing.Size(159, 28);
            comboMonsterType.TabIndex = 17;
            comboMonsterType.SelectedIndexChanged += comboMonsterType_SelectedIndexChanged;
            // 
            // numMonsterType
            // 
            numMonsterType.BackColor = System.Drawing.Color.Transparent;
            numMonsterType.Font = new System.Drawing.Font("Segoe UI", 9.25F);
            numMonsterType.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            numMonsterType.Location = new System.Drawing.Point(257, 373);
            numMonsterType.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            numMonsterType.Maximum = new decimal(new int[] { 100, 0, 0, 0 });
            numMonsterType.Minimum = new decimal(new int[] { 0, 0, 0, 0 });
            numMonsterType.MinimumSize = new System.Drawing.Size(91, 33);
            numMonsterType.Name = "numMonsterType";
            numMonsterType.Size = new System.Drawing.Size(91, 33);
            numMonsterType.TabIndex = 16;
            numMonsterType.Value = new decimal(new int[] { 0, 0, 0, 0 });
            numMonsterType.ValueChanged += OnSettingsChanged;
            // 
            // checkStopMonsterType
            // 
            checkStopMonsterType.AutoSize = true;
            checkStopMonsterType.BackColor = System.Drawing.Color.Transparent;
            checkStopMonsterType.Depth = 0;
            checkStopMonsterType.Location = new System.Drawing.Point(30, 340);
            checkStopMonsterType.Margin = new System.Windows.Forms.Padding(0);
            checkStopMonsterType.MouseLocation = new System.Drawing.Point(-1, -1);
            checkStopMonsterType.Name = "checkStopMonsterType";
            checkStopMonsterType.Ripple = true;
            checkStopMonsterType.Size = new System.Drawing.Size(221, 30);
            checkStopMonsterType.TabIndex = 15;
            checkStopMonsterType.Text = "Stop if num monster of type";
            checkStopMonsterType.UseVisualStyleBackColor = false;
            checkStopMonsterType.CheckedChanged += OnSettingsChanged;
            // 
            // numPartyMemberDead
            // 
            numPartyMemberDead.BackColor = System.Drawing.Color.Transparent;
            numPartyMemberDead.Font = new System.Drawing.Font("Segoe UI", 9.25F);
            numPartyMemberDead.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            numPartyMemberDead.Location = new System.Drawing.Point(257, 215);
            numPartyMemberDead.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            numPartyMemberDead.Maximum = new decimal(new int[] { 8, 0, 0, 0 });
            numPartyMemberDead.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numPartyMemberDead.MinimumSize = new System.Drawing.Size(91, 33);
            numPartyMemberDead.Name = "numPartyMemberDead";
            numPartyMemberDead.Size = new System.Drawing.Size(91, 33);
            numPartyMemberDead.TabIndex = 14;
            numPartyMemberDead.Value = new decimal(new int[] { 1, 0, 0, 0 });
            numPartyMemberDead.ValueChanged += OnSettingsChanged;
            // 
            // checkStopPartyMemberDead
            // 
            checkStopPartyMemberDead.AutoSize = true;
            checkStopPartyMemberDead.BackColor = System.Drawing.Color.Transparent;
            checkStopPartyMemberDead.Depth = 0;
            checkStopPartyMemberDead.Location = new System.Drawing.Point(30, 213);
            checkStopPartyMemberDead.Margin = new System.Windows.Forms.Padding(0);
            checkStopPartyMemberDead.MouseLocation = new System.Drawing.Point(-1, -1);
            checkStopPartyMemberDead.Name = "checkStopPartyMemberDead";
            checkStopPartyMemberDead.Ripple = true;
            checkStopPartyMemberDead.Size = new System.Drawing.Size(245, 30);
            checkStopPartyMemberDead.TabIndex = 6;
            checkStopPartyMemberDead.Text = "Stop if dead party members >=";
            checkStopPartyMemberDead.UseVisualStyleBackColor = false;
            checkStopPartyMemberDead.CheckedChanged += OnSettingsChanged;
            // 
            // numPartyMembersOnSpot
            // 
            numPartyMembersOnSpot.BackColor = System.Drawing.Color.Transparent;
            numPartyMembersOnSpot.Font = new System.Drawing.Font("Segoe UI", 9.25F);
            numPartyMembersOnSpot.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            numPartyMembersOnSpot.Location = new System.Drawing.Point(257, 304);
            numPartyMembersOnSpot.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            numPartyMembersOnSpot.Maximum = new decimal(new int[] { 8, 0, 0, 0 });
            numPartyMembersOnSpot.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numPartyMembersOnSpot.MinimumSize = new System.Drawing.Size(91, 33);
            numPartyMembersOnSpot.Name = "numPartyMembersOnSpot";
            numPartyMembersOnSpot.Size = new System.Drawing.Size(91, 33);
            numPartyMembersOnSpot.TabIndex = 29;
            numPartyMembersOnSpot.Value = new decimal(new int[] { 7, 0, 0, 0 });
            numPartyMembersOnSpot.ValueChanged += OnSettingsChanged;
            // 
            // checkNumPartyMembersOnSpot
            // 
            checkNumPartyMembersOnSpot.AutoSize = true;
            checkNumPartyMembersOnSpot.BackColor = System.Drawing.Color.Transparent;
            checkNumPartyMembersOnSpot.Depth = 0;
            checkNumPartyMembersOnSpot.Location = new System.Drawing.Point(30, 302);
            checkNumPartyMembersOnSpot.Margin = new System.Windows.Forms.Padding(0);
            checkNumPartyMembersOnSpot.MouseLocation = new System.Drawing.Point(-1, -1);
            checkNumPartyMembersOnSpot.Name = "checkNumPartyMembersOnSpot";
            checkNumPartyMembersOnSpot.Ripple = true;
            checkNumPartyMembersOnSpot.Size = new System.Drawing.Size(228, 30);
            checkNumPartyMembersOnSpot.TabIndex = 28;
            checkNumPartyMembersOnSpot.Text = "Stop pt members on spot <=";
            checkNumPartyMembersOnSpot.UseVisualStyleBackColor = false;
            checkNumPartyMembersOnSpot.CheckedChanged += OnSettingsChanged;
            // 
            // Main
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(groupBox3);
            Controls.Add(groupBox1);
            Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            Name = "Main";
            Size = new System.Drawing.Size(942, 687);
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
        private SDUI.Controls.Button linkRecord;
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
        private SDUI.Controls.NumUpDown numPartyMembersOnSpot;
        private SDUI.Controls.CheckBox checkNumPartyMembersOnSpot;
    }
}
