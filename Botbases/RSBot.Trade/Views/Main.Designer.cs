namespace RSBot.Trade.Views
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
            contextMenuRouteList = new System.Windows.Forms.ContextMenuStrip();
            addScriptToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            menuRecordScript = new System.Windows.Forms.ToolStripMenuItem();
            menuChooseScript = new System.Windows.Forms.ToolStripMenuItem();
            menuRemoveScript = new System.Windows.Forms.ToolStripMenuItem();
            lblHint = new System.Windows.Forms.Label();
            tabControl1 = new System.Windows.Forms.TabControl();
            tabPageRoute = new System.Windows.Forms.TabPage();
            txtTracePlayerName = new System.Windows.Forms.TextBox();
            radioUseRouteList = new System.Windows.Forms.RadioButton();
            radioTracePlayer = new System.Windows.Forms.RadioButton();
            buttonDeleteList = new System.Windows.Forms.Button();
            buttonCreateList = new System.Windows.Forms.Button();
            comboRouteList = new System.Windows.Forms.ComboBox();
            linkRecord = new System.Windows.Forms.LinkLabel();
            lvRouteList = new System.Windows.Forms.ListView();
            columnHeader1 = new System.Windows.Forms.ColumnHeader();
            columnHeader2 = new System.Windows.Forms.ColumnHeader();
            columnHeader4 = new System.Windows.Forms.ColumnHeader();
            columnHeader3 = new System.Windows.Forms.ColumnHeader();
            panel1 = new System.Windows.Forms.Panel();
            checkRunTownscript = new System.Windows.Forms.CheckBox();
            tabPageSettings = new System.Windows.Forms.TabPage();
            checkAttackThiefPlayers = new System.Windows.Forms.CheckBox();
            groupBox1 = new System.Windows.Forms.GroupBox();
            checkSellGoods = new System.Windows.Forms.CheckBox();
            lblNumGoodsDesc = new System.Windows.Forms.Label();
            checkBuyGoods = new System.Windows.Forms.CheckBox();
            numAmountGoods = new System.Windows.Forms.NumericUpDown();
            lblGoods = new System.Windows.Forms.Label();
            checkProtectTransport = new System.Windows.Forms.CheckBox();
            checkCounterAttack = new System.Windows.Forms.CheckBox();
            checkAttackThiefNpc = new System.Windows.Forms.CheckBox();
            groupBox2 = new System.Windows.Forms.GroupBox();
            separator2 = new System.Windows.Forms.Panel();
            checkCastBuffs = new System.Windows.Forms.CheckBox();
            checkWaitForHunter = new System.Windows.Forms.CheckBox();
            label3 = new System.Windows.Forms.Label();
            separator4 = new System.Windows.Forms.Panel();
            label1 = new System.Windows.Forms.Label();
            numMaxDistance = new System.Windows.Forms.NumericUpDown();
            checkMountTransport = new System.Windows.Forms.CheckBox();
            separator1 = new System.Windows.Forms.Panel();
            tabPage1 = new System.Windows.Forms.TabPage();
            lblJobExp = new System.Windows.Forms.Label();
            lblJobLevel = new System.Windows.Forms.Label();
            lblJobAlias = new System.Windows.Forms.Label();
            label9 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            separator3 = new System.Windows.Forms.Panel();
            lblTradeScale = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            contextMenuRouteList.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPageRoute.SuspendLayout();
            panel1.SuspendLayout();
            tabPageSettings.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            tabPage1.SuspendLayout();
            SuspendLayout();
            // 
            // contextMenuRouteList
            // 
            contextMenuRouteList.ImageScalingSize = new System.Drawing.Size(20, 20);
            contextMenuRouteList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { addScriptToolStripMenuItem, menuRemoveScript });
            contextMenuRouteList.Name = "contextMenuStrip1";
            contextMenuRouteList.Size = new System.Drawing.Size(129, 48);
            // 
            // addScriptToolStripMenuItem
            // 
            addScriptToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { menuRecordScript, menuChooseScript });
            
            addScriptToolStripMenuItem.Name = "addScriptToolStripMenuItem";
            addScriptToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            addScriptToolStripMenuItem.Text = "Add script";
            // 
            // menuRecordScript
            // 
            
            menuRecordScript.Name = "menuRecordScript";
            menuRecordScript.Size = new System.Drawing.Size(142, 22);
            menuRecordScript.Text = "Record";
            menuRecordScript.Click += menuRecordScript_Click;
            // 
            // menuChooseScript
            // 
            
            menuChooseScript.Name = "menuChooseScript";
            menuChooseScript.Size = new System.Drawing.Size(142, 22);
            menuChooseScript.Text = "Choose file...";
            menuChooseScript.Click += menuChooseScript_Click;
            // 
            // menuRemoveScript
            // 
            
            menuRemoveScript.Name = "menuRemoveScript";
            menuRemoveScript.Size = new System.Drawing.Size(128, 22);
            menuRemoveScript.Text = "Remove";
            menuRemoveScript.Click += menuRemoveScript_Click;
            // 
            // lblHint
            // 
            
            lblHint.AutoSize = true;
            lblHint.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            
            
            
            lblHint.Location = new System.Drawing.Point(7, 400);
            lblHint.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            lblHint.Name = "lblHint";
            lblHint.Size = new System.Drawing.Size(419, 15);
            lblHint.TabIndex = 7;
            lblHint.Text = "Hint: Automatic teleportation and town scripts are not supported in trace mode";
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPageRoute);
            tabControl1.Controls.Add(tabPageSettings);
            tabControl1.Controls.Add(tabPage1);
            tabControl1.ItemSize = new System.Drawing.Size(80, 24);
            tabControl1.Location = new System.Drawing.Point(2, 2);
            tabControl1.Margin = new System.Windows.Forms.Padding(2);
            tabControl1.Name = "tabControl1";
            
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new System.Drawing.Size(787, 388);
            tabControl1.TabIndex = 8;
            // 
            // tabPageRoute
            // 
            
            tabPageRoute.Controls.Add(txtTracePlayerName);
            tabPageRoute.Controls.Add(radioUseRouteList);
            tabPageRoute.Controls.Add(radioTracePlayer);
            tabPageRoute.Controls.Add(buttonDeleteList);
            tabPageRoute.Controls.Add(buttonCreateList);
            tabPageRoute.Controls.Add(comboRouteList);
            tabPageRoute.Controls.Add(linkRecord);
            tabPageRoute.Controls.Add(lvRouteList);
            tabPageRoute.Controls.Add(panel1);
            tabPageRoute.Location = new System.Drawing.Point(4, 28);
            tabPageRoute.Margin = new System.Windows.Forms.Padding(2);
            tabPageRoute.Name = "tabPageRoute";
            tabPageRoute.Padding = new System.Windows.Forms.Padding(2);
            tabPageRoute.Size = new System.Drawing.Size(779, 356);
            tabPageRoute.TabIndex = 0;
            tabPageRoute.Text = "Route";
            // 
            // txtTracePlayerName
            // 
            txtTracePlayerName.Location = new System.Drawing.Point(115, 16);
            txtTracePlayerName.Margin = new System.Windows.Forms.Padding(2);
            txtTracePlayerName.MaxLength = 32767;
            txtTracePlayerName.Multiline = false;
            txtTracePlayerName.Name = "txtTracePlayerName";
            
            
            txtTracePlayerName.Size = new System.Drawing.Size(121, 21);
            txtTracePlayerName.TabIndex = 24;
            
            txtTracePlayerName.UseSystemPasswordChar = false;
            txtTracePlayerName.TextChanged += txtTracePlayerName_TextChanged;
            // 
            // radioUseRouteList
            // 
            radioUseRouteList.AutoSize = true;
            radioUseRouteList.Checked = true;
            radioUseRouteList.Location = new System.Drawing.Point(9, 46);
            radioUseRouteList.Margin = new System.Windows.Forms.Padding(0);
            radioUseRouteList.Name = "radioUseRouteList";
            
            radioUseRouteList.Size = new System.Drawing.Size(102, 30);
            radioUseRouteList.TabIndex = 23;
            radioUseRouteList.TabStop = true;
            radioUseRouteList.Text = "Use route list";
            radioUseRouteList.UseVisualStyleBackColor = true;
            radioUseRouteList.CheckedChanged += radioSetting_CheckedChanged;
            // 
            // radioTracePlayer
            // 
            radioTracePlayer.AutoSize = true;
            radioTracePlayer.Location = new System.Drawing.Point(9, 14);
            radioTracePlayer.Margin = new System.Windows.Forms.Padding(0);
            radioTracePlayer.Name = "radioTracePlayer";
            
            radioTracePlayer.Size = new System.Drawing.Size(96, 30);
            radioTracePlayer.TabIndex = 22;
            radioTracePlayer.Text = "Trace player";
            radioTracePlayer.UseVisualStyleBackColor = true;
            radioTracePlayer.CheckedChanged += radioSetting_CheckedChanged;
            // 
            // buttonDeleteList
            // 
            
            buttonDeleteList.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            
            buttonDeleteList.Location = new System.Drawing.Point(243, 45);
            buttonDeleteList.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            buttonDeleteList.Name = "buttonDeleteList";
            
            
            buttonDeleteList.Size = new System.Drawing.Size(22, 26);
            buttonDeleteList.TabIndex = 20;
            buttonDeleteList.Text = "x";
            buttonDeleteList.UseVisualStyleBackColor = true;
            buttonDeleteList.Click += buttonDeleteList_Click;
            // 
            // buttonCreateList
            // 
            
            buttonCreateList.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            
            buttonCreateList.Location = new System.Drawing.Point(269, 46);
            buttonCreateList.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            buttonCreateList.Name = "buttonCreateList";
            
            
            buttonCreateList.Size = new System.Drawing.Size(22, 26);
            buttonCreateList.TabIndex = 21;
            buttonCreateList.Text = "+";
            buttonCreateList.UseVisualStyleBackColor = true;
            buttonCreateList.Click += buttonCreateList_Click;
            // 
            // comboRouteList
            // 
            comboRouteList.DrawMode = System.Windows.Forms.DrawMode.Normal;
            comboRouteList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboRouteList.FormattingEnabled = true;
            comboRouteList.Items.AddRange(new object[] { "Default" });
            comboRouteList.Location = new System.Drawing.Point(115, 47);
            comboRouteList.Margin = new System.Windows.Forms.Padding(2);
            comboRouteList.Name = "comboRouteList";
            
            
            comboRouteList.Size = new System.Drawing.Size(122, 24);
            comboRouteList.TabIndex = 19;
            comboRouteList.SelectedIndexChanged += comboRouteList_SelectedIndexChanged;
            // 
            // linkRecord
            // 
            linkRecord.AutoSize = true;
            linkRecord.Location = new System.Drawing.Point(718, 46);
            linkRecord.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            linkRecord.Name = "linkRecord";
            linkRecord.Size = new System.Drawing.Size(52, 15);
            linkRecord.TabIndex = 16;
            linkRecord.TabStop = true;
            linkRecord.Text = "[Record]";
            linkRecord.LinkClicked += linkRecord_LinkClicked;
            // 
            // lvRouteList
            // 
            
            lvRouteList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { columnHeader1, columnHeader2, columnHeader4, columnHeader3 });
            lvRouteList.ContextMenuStrip = contextMenuRouteList;
            
            lvRouteList.FullRowSelect = true;
            lvRouteList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            lvRouteList.Location = new System.Drawing.Point(9, 84);
            lvRouteList.Margin = new System.Windows.Forms.Padding(2);
            lvRouteList.MultiSelect = false;
            lvRouteList.Name = "lvRouteList";
            lvRouteList.Size = new System.Drawing.Size(762, 207);
            lvRouteList.TabIndex = 1;
            lvRouteList.UseCompatibleStateImageBehavior = false;
            lvRouteList.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Name";
            columnHeader1.Width = 150;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Start region";
            columnHeader2.Width = 200;
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "End region";
            columnHeader4.Width = 200;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Num. Steps";
            columnHeader3.Width = 150;
            // 
            // panel1
            // 
            
            
            
            panel1.Controls.Add(checkRunTownscript);
            panel1.Location = new System.Drawing.Point(7, 285);
            panel1.Name = "panel1";
            
            
            panel1.Size = new System.Drawing.Size(766, 42);
            panel1.TabIndex = 29;
            // 
            // checkRunTownscript
            // 
            checkRunTownscript.AutoSize = true;
            
            
            checkRunTownscript.Location = new System.Drawing.Point(2, 9);
            checkRunTownscript.Margin = new System.Windows.Forms.Padding(0);
            
            checkRunTownscript.Name = "checkRunTownscript";
            
            checkRunTownscript.Size = new System.Drawing.Size(219, 30);
            checkRunTownscript.TabIndex = 27;
            checkRunTownscript.Text = "Run townscript after route finished";
            checkRunTownscript.UseVisualStyleBackColor = false;
            checkRunTownscript.CheckedChanged += checkBoxSetting_CheckedChanged;
            // 
            // tabPageSettings
            // 
            
            tabPageSettings.Controls.Add(checkAttackThiefPlayers);
            tabPageSettings.Controls.Add(groupBox1);
            tabPageSettings.Controls.Add(checkProtectTransport);
            tabPageSettings.Controls.Add(checkCounterAttack);
            tabPageSettings.Controls.Add(checkAttackThiefNpc);
            tabPageSettings.Controls.Add(groupBox2);
            tabPageSettings.Location = new System.Drawing.Point(4, 28);
            tabPageSettings.Margin = new System.Windows.Forms.Padding(2);
            tabPageSettings.Name = "tabPageSettings";
            tabPageSettings.Padding = new System.Windows.Forms.Padding(2);
            tabPageSettings.Size = new System.Drawing.Size(779, 356);
            tabPageSettings.TabIndex = 1;
            tabPageSettings.Text = "Settings";
            // 
            // checkAttackThiefPlayers
            // 
            checkAttackThiefPlayers.AutoSize = true;
            
            
            checkAttackThiefPlayers.Location = new System.Drawing.Point(41, 45);
            checkAttackThiefPlayers.Margin = new System.Windows.Forms.Padding(0);
            
            checkAttackThiefPlayers.Name = "checkAttackThiefPlayers";
            
            checkAttackThiefPlayers.Size = new System.Drawing.Size(134, 30);
            checkAttackThiefPlayers.TabIndex = 0;
            checkAttackThiefPlayers.Text = "Attack thief players";
            checkAttackThiefPlayers.UseVisualStyleBackColor = false;
            checkAttackThiefPlayers.CheckedChanged += checkBoxSetting_CheckedChanged;
            // 
            // groupBox1
            // 
            
            groupBox1.Controls.Add(checkSellGoods);
            groupBox1.Controls.Add(lblNumGoodsDesc);
            groupBox1.Controls.Add(checkBuyGoods);
            groupBox1.Controls.Add(numAmountGoods);
            groupBox1.Controls.Add(lblGoods);
            groupBox1.Location = new System.Drawing.Point(316, 14);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new System.Windows.Forms.Padding(3, 8, 3, 3);
            
            
            groupBox1.Size = new System.Drawing.Size(311, 134);
            groupBox1.TabIndex = 28;
            groupBox1.TabStop = false;
            groupBox1.Text = "Buy / Sell";
            // 
            // checkSellGoods
            // 
            checkSellGoods.AutoSize = true;
            
            
            checkSellGoods.Location = new System.Drawing.Point(26, 35);
            checkSellGoods.Margin = new System.Windows.Forms.Padding(0);
            
            checkSellGoods.Name = "checkSellGoods";
            
            checkSellGoods.Size = new System.Drawing.Size(86, 30);
            checkSellGoods.TabIndex = 5;
            checkSellGoods.Text = "Sell goods";
            checkSellGoods.UseVisualStyleBackColor = false;
            checkSellGoods.CheckedChanged += checkBoxSetting_CheckedChanged;
            // 
            // lblNumGoodsDesc
            // 
            
            lblNumGoodsDesc.AutoSize = true;
            lblNumGoodsDesc.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            
            
            
            lblNumGoodsDesc.Location = new System.Drawing.Point(84, 95);
            lblNumGoodsDesc.Name = "lblNumGoodsDesc";
            lblNumGoodsDesc.Size = new System.Drawing.Size(96, 13);
            lblNumGoodsDesc.TabIndex = 3;
            lblNumGoodsDesc.Text = "0 = max. possible";
            // 
            // checkBuyGoods
            // 
            checkBuyGoods.AutoSize = true;
            
            
            checkBuyGoods.Location = new System.Drawing.Point(26, 65);
            checkBuyGoods.Margin = new System.Windows.Forms.Padding(0);
            
            checkBuyGoods.Name = "checkBuyGoods";
            
            checkBuyGoods.Size = new System.Drawing.Size(50, 30);
            checkBuyGoods.TabIndex = 0;
            checkBuyGoods.Text = "Buy ";
            checkBuyGoods.UseVisualStyleBackColor = false;
            checkBuyGoods.CheckedChanged += checkBoxSetting_CheckedChanged;
            // 
            // numAmountGoods
            // 
            
            numAmountGoods.Font = new System.Drawing.Font("Segoe UI", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            
            numAmountGoods.Location = new System.Drawing.Point(85, 68);
            numAmountGoods.Maximum = new decimal(new int[] { 999999, 0, 0, 0 });
            numAmountGoods.Minimum = new decimal(new int[] { 0, 0, 0, 0 });
            numAmountGoods.MinimumSize = new System.Drawing.Size(80, 25);
            numAmountGoods.Name = "numAmountGoods";
            numAmountGoods.Size = new System.Drawing.Size(95, 25);
            numAmountGoods.TabIndex = 1;
            numAmountGoods.Value = new decimal(new int[] { 0, 0, 0, 0 });
            numAmountGoods.ValueChanged += numSetting_ValueChanged;
            // 
            // lblGoods
            // 
            
            lblGoods.AutoSize = true;
            
            
            
            lblGoods.Location = new System.Drawing.Point(186, 70);
            lblGoods.Name = "lblGoods";
            lblGoods.Size = new System.Drawing.Size(90, 15);
            lblGoods.TabIndex = 2;
            lblGoods.Text = "x Special Goods";
            // 
            // checkProtectTransport
            // 
            checkProtectTransport.AutoSize = true;
            
            
            checkProtectTransport.Location = new System.Drawing.Point(41, 124);
            checkProtectTransport.Margin = new System.Windows.Forms.Padding(0);
            
            checkProtectTransport.Name = "checkProtectTransport";
            
            checkProtectTransport.Size = new System.Drawing.Size(122, 30);
            checkProtectTransport.TabIndex = 6;
            checkProtectTransport.Text = "Protect transport";
            checkProtectTransport.UseVisualStyleBackColor = false;
            checkProtectTransport.CheckedChanged += checkBoxSetting_CheckedChanged;
            // 
            // checkCounterAttack
            // 
            checkCounterAttack.AutoSize = true;
            
            
            checkCounterAttack.Location = new System.Drawing.Point(41, 96);
            checkCounterAttack.Margin = new System.Windows.Forms.Padding(0);
            
            checkCounterAttack.Name = "checkCounterAttack";
            
            checkCounterAttack.Size = new System.Drawing.Size(110, 30);
            checkCounterAttack.TabIndex = 2;
            checkCounterAttack.Text = "Counter attack";
            checkCounterAttack.UseVisualStyleBackColor = false;
            checkCounterAttack.CheckedChanged += checkBoxSetting_CheckedChanged;
            // 
            // checkAttackThiefNpc
            // 
            checkAttackThiefNpc.AutoSize = true;
            
            
            checkAttackThiefNpc.Location = new System.Drawing.Point(41, 71);
            checkAttackThiefNpc.Margin = new System.Windows.Forms.Padding(0);
            
            checkAttackThiefNpc.Name = "checkAttackThiefNpc";
            
            checkAttackThiefNpc.Size = new System.Drawing.Size(124, 30);
            checkAttackThiefNpc.TabIndex = 1;
            checkAttackThiefNpc.Text = "Attack thief NPCs";
            checkAttackThiefNpc.UseVisualStyleBackColor = false;
            checkAttackThiefNpc.CheckedChanged += checkBoxSetting_CheckedChanged;
            // 
            // groupBox2
            // 
            
            groupBox2.Controls.Add(separator2);
            groupBox2.Controls.Add(checkCastBuffs);
            groupBox2.Controls.Add(checkWaitForHunter);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(separator4);
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(numMaxDistance);
            groupBox2.Controls.Add(checkMountTransport);
            groupBox2.Controls.Add(separator1);
            groupBox2.Location = new System.Drawing.Point(13, 15);
            groupBox2.Margin = new System.Windows.Forms.Padding(2);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new System.Windows.Forms.Padding(2, 4, 2, 2);
            
            
            groupBox2.Size = new System.Drawing.Size(287, 324);
            groupBox2.TabIndex = 29;
            groupBox2.TabStop = false;
            groupBox2.Text = "Settings";
            // 
            // separator2
            // 
            separator2.Location = new System.Drawing.Point(2, 268);
            separator2.Margin = new System.Windows.Forms.Padding(2);
            separator2.Name = "separator2";
            separator2.Size = new System.Drawing.Size(282, 12);
            separator2.TabIndex = 31;
            separator2.Text = "separator2";
            // 
            // checkCastBuffs
            // 
            checkCastBuffs.AutoSize = true;
            
            
            checkCastBuffs.Location = new System.Drawing.Point(30, 148);
            checkCastBuffs.Margin = new System.Windows.Forms.Padding(0);
            
            checkCastBuffs.Name = "checkCastBuffs";
            
            checkCastBuffs.Size = new System.Drawing.Size(83, 30);
            checkCastBuffs.TabIndex = 4;
            checkCastBuffs.Text = "Cast buffs";
            checkCastBuffs.UseCompatibleTextRendering = true;
            checkCastBuffs.UseVisualStyleBackColor = false;
            checkCastBuffs.CheckedChanged += checkBoxSetting_CheckedChanged;
            // 
            // checkWaitForHunter
            // 
            checkWaitForHunter.AutoSize = true;
            
            
            checkWaitForHunter.Location = new System.Drawing.Point(28, 281);
            checkWaitForHunter.Margin = new System.Windows.Forms.Padding(0);
            
            checkWaitForHunter.Name = "checkWaitForHunter";
            
            checkWaitForHunter.Size = new System.Drawing.Size(163, 30);
            checkWaitForHunter.TabIndex = 30;
            checkWaitForHunter.Text = "Wait for a hunter nearby";
            checkWaitForHunter.UseVisualStyleBackColor = false;
            checkWaitForHunter.CheckedChanged += checkBoxSetting_CheckedChanged;
            // 
            // label3
            // 
            
            label3.AutoSize = true;
            
            
            
            label3.Location = new System.Drawing.Point(116, 235);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(43, 15);
            label3.TabIndex = 6;
            label3.Text = "meters";
            // 
            // separator4
            // 
            separator4.Location = new System.Drawing.Point(0, 176);
            separator4.Margin = new System.Windows.Forms.Padding(2);
            separator4.Name = "separator4";
            separator4.Size = new System.Drawing.Size(282, 12);
            separator4.TabIndex = 8;
            separator4.Text = "separator4";
            // 
            // label1
            // 
            
            label1.AutoSize = true;
            
            
            
            label1.Location = new System.Drawing.Point(28, 219);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(83, 15);
            label1.TabIndex = 5;
            label1.Text = "Max. distance:";
            // 
            // numMaxDistance
            // 
            
            numMaxDistance.Font = new System.Drawing.Font("Segoe UI", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            
            numMaxDistance.Location = new System.Drawing.Point(30, 237);
            numMaxDistance.Maximum = new decimal(new int[] { 100, 0, 0, 0 });
            numMaxDistance.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numMaxDistance.MinimumSize = new System.Drawing.Size(80, 25);
            numMaxDistance.Name = "numMaxDistance";
            numMaxDistance.Size = new System.Drawing.Size(80, 25);
            numMaxDistance.TabIndex = 4;
            numMaxDistance.Value = new decimal(new int[] { 1, 0, 0, 0 });
            numMaxDistance.ValueChanged += numSetting_ValueChanged;
            // 
            // checkMountTransport
            // 
            checkMountTransport.AutoSize = true;
            
            
            checkMountTransport.Location = new System.Drawing.Point(28, 186);
            checkMountTransport.Margin = new System.Windows.Forms.Padding(0);
            
            checkMountTransport.Name = "checkMountTransport";
            
            checkMountTransport.Size = new System.Drawing.Size(119, 30);
            checkMountTransport.TabIndex = 7;
            checkMountTransport.Text = "Mount transport";
            checkMountTransport.UseVisualStyleBackColor = false;
            checkMountTransport.CheckedChanged += checkBoxSetting_CheckedChanged;
            // 
            // separator1
            // 
            separator1.Location = new System.Drawing.Point(4, 137);
            separator1.Margin = new System.Windows.Forms.Padding(2);
            separator1.Name = "separator1";
            separator1.Size = new System.Drawing.Size(282, 12);
            separator1.TabIndex = 3;
            separator1.Text = "separator1";
            // 
            // tabPage1
            // 
            
            tabPage1.Controls.Add(lblJobExp);
            tabPage1.Controls.Add(lblJobLevel);
            tabPage1.Controls.Add(lblJobAlias);
            tabPage1.Controls.Add(label9);
            tabPage1.Controls.Add(label8);
            tabPage1.Controls.Add(label7);
            tabPage1.Controls.Add(separator3);
            tabPage1.Controls.Add(lblTradeScale);
            tabPage1.Controls.Add(label2);
            tabPage1.Location = new System.Drawing.Point(4, 28);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new System.Windows.Forms.Padding(3);
            tabPage1.Size = new System.Drawing.Size(779, 356);
            tabPage1.TabIndex = 2;
            tabPage1.Text = "Job overview";
            // 
            // lblJobExp
            // 
            
            lblJobExp.AutoSize = true;
            
            
            
            lblJobExp.Location = new System.Drawing.Point(129, 163);
            lblJobExp.Name = "lblJobExp";
            lblJobExp.Size = new System.Drawing.Size(13, 15);
            lblJobExp.TabIndex = 11;
            lblJobExp.Text = "0";
            // 
            // lblJobLevel
            // 
            
            lblJobLevel.AutoSize = true;
            
            
            
            lblJobLevel.Location = new System.Drawing.Point(129, 127);
            lblJobLevel.Name = "lblJobLevel";
            lblJobLevel.Size = new System.Drawing.Size(13, 15);
            lblJobLevel.TabIndex = 10;
            lblJobLevel.Text = "0";
            // 
            // lblJobAlias
            // 
            
            lblJobAlias.AutoSize = true;
            
            
            
            lblJobAlias.Location = new System.Drawing.Point(129, 90);
            lblJobAlias.Name = "lblJobAlias";
            lblJobAlias.Size = new System.Drawing.Size(50, 15);
            lblJobAlias.TabIndex = 9;
            lblJobAlias.Text = "<none>";
            // 
            // label9
            // 
            
            label9.AutoSize = true;
            
            
            
            label9.Location = new System.Drawing.Point(93, 163);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(30, 15);
            label9.TabIndex = 8;
            label9.Text = "EXP:";
            // 
            // label8
            // 
            
            label8.AutoSize = true;
            
            
            
            label8.Location = new System.Drawing.Point(69, 90);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(54, 15);
            label8.TabIndex = 7;
            label8.Text = "Job alias:";
            // 
            // label7
            // 
            
            label7.AutoSize = true;
            
            
            
            label7.Location = new System.Drawing.Point(86, 127);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(37, 15);
            label7.TabIndex = 7;
            label7.Text = "Level:";
            // 
            // separator3
            // 
            separator3.Location = new System.Drawing.Point(20, 67);
            separator3.Name = "separator3";
            separator3.Size = new System.Drawing.Size(365, 10);
            separator3.TabIndex = 6;
            separator3.Text = "separator3";
            // 
            // lblTradeScale
            // 
            
            lblTradeScale.AutoSize = true;
            
            
            
            lblTradeScale.Location = new System.Drawing.Point(144, 37);
            lblTradeScale.Name = "lblTradeScale";
            lblTradeScale.Size = new System.Drawing.Size(57, 15);
            lblTradeScale.TabIndex = 2;
            lblTradeScale.Text = "■■■■■";
            // 
            // label2
            // 
            
            label2.AutoSize = true;
            
            
            
            label2.Location = new System.Drawing.Point(50, 37);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(88, 15);
            label2.TabIndex = 1;
            label2.Text = "Trade difficulty:";
            // 
            // Main
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            Controls.Add(tabControl1);
            Controls.Add(lblHint);
            Margin = new System.Windows.Forms.Padding(2);
            Name = "Main";
            Size = new System.Drawing.Size(790, 442);
            Load += Main_Load;
            contextMenuRouteList.ResumeLayout(false);
            tabControl1.ResumeLayout(false);
            tabPageRoute.ResumeLayout(false);
            tabPageRoute.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            tabPageSettings.ResumeLayout(false);
            tabPageSettings.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip contextMenuRouteList;
        private System.Windows.Forms.ToolStripMenuItem addScriptToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuRemoveScript;
        private System.Windows.Forms.Label lblHint;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageRoute;
        private System.Windows.Forms.LinkLabel linkRecord;
        private System.Windows.Forms.ListView lvRouteList;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.TabPage tabPageSettings;
        private System.Windows.Forms.ComboBox comboRouteList;
        private System.Windows.Forms.Button buttonDeleteList;
        private System.Windows.Forms.Button buttonCreateList;
        private System.Windows.Forms.RadioButton radioUseRouteList;
        private System.Windows.Forms.RadioButton radioTracePlayer;
        private System.Windows.Forms.TextBox txtTracePlayerName;
        private System.Windows.Forms.CheckBox checkCastBuffs;
        private System.Windows.Forms.Panel separator1;
        private System.Windows.Forms.CheckBox checkCounterAttack;
        private System.Windows.Forms.CheckBox checkAttackThiefNpc;
        private System.Windows.Forms.CheckBox checkAttackThiefPlayers;
        private System.Windows.Forms.ToolStripMenuItem menuRecordScript;
        private System.Windows.Forms.ToolStripMenuItem menuChooseScript;
        private System.Windows.Forms.CheckBox checkRunTownscript;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox checkProtectTransport;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkBuyGoods;
        private System.Windows.Forms.Label lblGoods;
        private System.Windows.Forms.NumericUpDown numAmountGoods;
        private System.Windows.Forms.Label lblNumGoodsDesc;
        private System.Windows.Forms.CheckBox checkSellGoods;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblTradeScale;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel separator3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblJobExp;
        private System.Windows.Forms.Label lblJobLevel;
        private System.Windows.Forms.Label lblJobAlias;
        private System.Windows.Forms.CheckBox checkMountTransport;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numMaxDistance;
        private System.Windows.Forms.Panel separator4;
        private System.Windows.Forms.Panel separator2;
        private System.Windows.Forms.CheckBox checkWaitForHunter;
    }
}
