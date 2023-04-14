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
            contextMenuRouteList = new SDUI.Controls.ContextMenuStrip();
            addScriptToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            menuRecordScript = new System.Windows.Forms.ToolStripMenuItem();
            menuChooseScript = new System.Windows.Forms.ToolStripMenuItem();
            menuRemoveScript = new System.Windows.Forms.ToolStripMenuItem();
            lblHint = new SDUI.Controls.Label();
            tabControl1 = new SDUI.Controls.TabControl();
            tabPageRoute = new System.Windows.Forms.TabPage();
            txtTracePlayerName = new SDUI.Controls.TextBox();
            radioUseRouteList = new SDUI.Controls.Radio();
            radioTracePlayer = new SDUI.Controls.Radio();
            buttonDeleteList = new SDUI.Controls.Button();
            buttonCreateList = new SDUI.Controls.Button();
            comboRouteList = new SDUI.Controls.ComboBox();
            linkRecord = new System.Windows.Forms.LinkLabel();
            lvRouteList = new SDUI.Controls.ListView();
            columnHeader1 = new System.Windows.Forms.ColumnHeader();
            columnHeader2 = new System.Windows.Forms.ColumnHeader();
            columnHeader4 = new System.Windows.Forms.ColumnHeader();
            columnHeader3 = new System.Windows.Forms.ColumnHeader();
            panel1 = new SDUI.Controls.Panel();
            checkRunTownscript = new SDUI.Controls.CheckBox();
            tabPageSettings = new System.Windows.Forms.TabPage();
            checkAttackThiefPlayers = new SDUI.Controls.CheckBox();
            checkCastBuffs = new SDUI.Controls.CheckBox();
            groupBox1 = new SDUI.Controls.GroupBox();
            checkSellGoods = new SDUI.Controls.CheckBox();
            lblNumGoodsDesc = new SDUI.Controls.Label();
            checkBuyGoods = new SDUI.Controls.CheckBox();
            numAmountGoods = new SDUI.Controls.NumUpDown();
            lblGoods = new SDUI.Controls.Label();
            checkProtectTransport = new SDUI.Controls.CheckBox();
            checkCounterAttack = new SDUI.Controls.CheckBox();
            checkAttackThiefNpc = new SDUI.Controls.CheckBox();
            groupBox2 = new SDUI.Controls.GroupBox();
            separator2 = new SDUI.Controls.Separator();
            checkWaitForHunter = new SDUI.Controls.CheckBox();
            label3 = new SDUI.Controls.Label();
            separator4 = new SDUI.Controls.Separator();
            label1 = new SDUI.Controls.Label();
            numMaxDistance = new SDUI.Controls.NumUpDown();
            checkMountTransport = new SDUI.Controls.CheckBox();
            separator1 = new SDUI.Controls.Separator();
            tabPage1 = new System.Windows.Forms.TabPage();
            lblJobExp = new SDUI.Controls.Label();
            lblJobLevel = new SDUI.Controls.Label();
            lblJobAlias = new SDUI.Controls.Label();
            label9 = new SDUI.Controls.Label();
            label8 = new SDUI.Controls.Label();
            label7 = new SDUI.Controls.Label();
            separator3 = new SDUI.Controls.Separator();
            lblTradeScale = new SDUI.Controls.Label();
            label2 = new SDUI.Controls.Label();
            contextMenuRouteList.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPageRoute.SuspendLayout();
            panel1.SuspendLayout();
            tabPageSettings.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numAmountGoods).BeginInit();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numMaxDistance).BeginInit();
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
            addScriptToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            addScriptToolStripMenuItem.Name = "addScriptToolStripMenuItem";
            addScriptToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            addScriptToolStripMenuItem.Text = "Add script";
            // 
            // menuRecordScript
            // 
            menuRecordScript.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            menuRecordScript.Name = "menuRecordScript";
            menuRecordScript.Size = new System.Drawing.Size(142, 22);
            menuRecordScript.Text = "Record";
            menuRecordScript.Click += menuRecordScript_Click;
            // 
            // menuChooseScript
            // 
            menuChooseScript.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            menuChooseScript.Name = "menuChooseScript";
            menuChooseScript.Size = new System.Drawing.Size(142, 22);
            menuChooseScript.Text = "Choose file...";
            menuChooseScript.Click += menuChooseScript_Click;
            // 
            // menuRemoveScript
            // 
            menuRemoveScript.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            menuRemoveScript.Name = "menuRemoveScript";
            menuRemoveScript.Size = new System.Drawing.Size(128, 22);
            menuRemoveScript.Text = "Remove";
            menuRemoveScript.Click += menuRemoveScript_Click;
            // 
            // lblHint
            // 
            lblHint.AutoSize = true;
            lblHint.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            lblHint.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            lblHint.Location = new System.Drawing.Point(15, 378);
            lblHint.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            lblHint.Name = "lblHint";
            lblHint.Size = new System.Drawing.Size(419, 15);
            lblHint.TabIndex = 7;
            lblHint.Text = "Hint: Automatic teleportation and town scripts are not supported in trace mode";
            // 
            // tabControl1
            // 
            tabControl1.Border = new System.Windows.Forms.Padding(1);
            tabControl1.Controls.Add(tabPageRoute);
            tabControl1.Controls.Add(tabPageSettings);
            tabControl1.Controls.Add(tabPage1);
            tabControl1.HideTabArea = false;
            tabControl1.Location = new System.Drawing.Point(2, 2);
            tabControl1.Margin = new System.Windows.Forms.Padding(2);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new System.Drawing.Size(787, 370);
            tabControl1.TabIndex = 8;
            // 
            // tabPageRoute
            // 
            tabPageRoute.BackColor = System.Drawing.Color.White;
            tabPageRoute.Controls.Add(txtTracePlayerName);
            tabPageRoute.Controls.Add(radioUseRouteList);
            tabPageRoute.Controls.Add(radioTracePlayer);
            tabPageRoute.Controls.Add(buttonDeleteList);
            tabPageRoute.Controls.Add(buttonCreateList);
            tabPageRoute.Controls.Add(comboRouteList);
            tabPageRoute.Controls.Add(linkRecord);
            tabPageRoute.Controls.Add(lvRouteList);
            tabPageRoute.Controls.Add(panel1);
            tabPageRoute.Location = new System.Drawing.Point(4, 25);
            tabPageRoute.Margin = new System.Windows.Forms.Padding(2);
            tabPageRoute.Name = "tabPageRoute";
            tabPageRoute.Padding = new System.Windows.Forms.Padding(2);
            tabPageRoute.Size = new System.Drawing.Size(779, 341);
            tabPageRoute.TabIndex = 0;
            tabPageRoute.Text = "Route";
            // 
            // txtTracePlayerName
            // 
            txtTracePlayerName.Location = new System.Drawing.Point(109, 14);
            txtTracePlayerName.Margin = new System.Windows.Forms.Padding(2);
            txtTracePlayerName.MaxLength = 32767;
            txtTracePlayerName.MultiLine = false;
            txtTracePlayerName.Name = "txtTracePlayerName";
            txtTracePlayerName.Radius = 2;
            txtTracePlayerName.Size = new System.Drawing.Size(121, 21);
            txtTracePlayerName.TabIndex = 24;
            txtTracePlayerName.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            txtTracePlayerName.UseSystemPasswordChar = false;
            txtTracePlayerName.TextChanged += txtTracePlayerName_TextChanged;
            // 
            // radioUseRouteList
            // 
            radioUseRouteList.AutoSize = true;
            radioUseRouteList.Checked = true;
            radioUseRouteList.Location = new System.Drawing.Point(9, 46);
            radioUseRouteList.Margin = new System.Windows.Forms.Padding(2);
            radioUseRouteList.Name = "radioUseRouteList";
            radioUseRouteList.ShadowDepth = 0;
            radioUseRouteList.Size = new System.Drawing.Size(100, 15);
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
            radioTracePlayer.Margin = new System.Windows.Forms.Padding(2);
            radioTracePlayer.Name = "radioTracePlayer";
            radioTracePlayer.ShadowDepth = 0;
            radioTracePlayer.Size = new System.Drawing.Size(94, 15);
            radioTracePlayer.TabIndex = 22;
            radioTracePlayer.Text = "Trace player";
            radioTracePlayer.UseVisualStyleBackColor = true;
            radioTracePlayer.CheckedChanged += radioSetting_CheckedChanged;
            // 
            // buttonDeleteList
            // 
            buttonDeleteList.Color = System.Drawing.Color.IndianRed;
            buttonDeleteList.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            buttonDeleteList.ForeColor = System.Drawing.Color.White;
            buttonDeleteList.Location = new System.Drawing.Point(234, 42);
            buttonDeleteList.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            buttonDeleteList.Name = "buttonDeleteList";
            buttonDeleteList.Radius = 6;
            buttonDeleteList.ShadowDepth = 4F;
            buttonDeleteList.Size = new System.Drawing.Size(22, 26);
            buttonDeleteList.TabIndex = 20;
            buttonDeleteList.Text = "x";
            buttonDeleteList.UseVisualStyleBackColor = true;
            buttonDeleteList.Click += buttonDeleteList_Click;
            // 
            // buttonCreateList
            // 
            buttonCreateList.Color = System.Drawing.Color.FromArgb(0, 192, 0);
            buttonCreateList.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            buttonCreateList.ForeColor = System.Drawing.Color.White;
            buttonCreateList.Location = new System.Drawing.Point(257, 42);
            buttonCreateList.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            buttonCreateList.Name = "buttonCreateList";
            buttonCreateList.Radius = 6;
            buttonCreateList.ShadowDepth = 4F;
            buttonCreateList.Size = new System.Drawing.Size(22, 26);
            buttonCreateList.TabIndex = 21;
            buttonCreateList.Text = "+";
            buttonCreateList.UseVisualStyleBackColor = true;
            buttonCreateList.Click += buttonCreateList_Click;
            // 
            // comboRouteList
            // 
            comboRouteList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            comboRouteList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboRouteList.FormattingEnabled = true;
            comboRouteList.Items.AddRange(new object[] { "Default" });
            comboRouteList.Location = new System.Drawing.Point(108, 43);
            comboRouteList.Margin = new System.Windows.Forms.Padding(2);
            comboRouteList.Name = "comboRouteList";
            comboRouteList.Radius = 5;
            comboRouteList.ShadowDepth = 4F;
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
            panel1.BackColor = System.Drawing.Color.Transparent;
            panel1.Border = new System.Windows.Forms.Padding(0, 0, 0, 0);
            panel1.BorderColor = System.Drawing.Color.Transparent;
            panel1.Controls.Add(checkRunTownscript);
            panel1.Location = new System.Drawing.Point(7, 285);
            panel1.Name = "panel1";
            panel1.Radius = 10;
            panel1.ShadowDepth = 4F;
            panel1.Size = new System.Drawing.Size(766, 42);
            panel1.TabIndex = 29;
            // 
            // checkRunTownscript
            // 
            checkRunTownscript.AutoSize = true;
            checkRunTownscript.BackColor = System.Drawing.Color.Transparent;
            checkRunTownscript.Location = new System.Drawing.Point(17, 15);
            checkRunTownscript.Margin = new System.Windows.Forms.Padding(2);
            checkRunTownscript.Name = "checkRunTownscript";
            checkRunTownscript.ShadowDepth = 1;
            checkRunTownscript.Size = new System.Drawing.Size(206, 15);
            checkRunTownscript.TabIndex = 27;
            checkRunTownscript.Text = "Run townscript after route finished";
            checkRunTownscript.UseVisualStyleBackColor = false;
            checkRunTownscript.CheckedChanged += checkBoxSetting_CheckedChanged;
            // 
            // tabPageSettings
            // 
            tabPageSettings.BackColor = System.Drawing.Color.White;
            tabPageSettings.Controls.Add(checkAttackThiefPlayers);
            tabPageSettings.Controls.Add(checkCastBuffs);
            tabPageSettings.Controls.Add(groupBox1);
            tabPageSettings.Controls.Add(checkProtectTransport);
            tabPageSettings.Controls.Add(checkCounterAttack);
            tabPageSettings.Controls.Add(checkAttackThiefNpc);
            tabPageSettings.Controls.Add(groupBox2);
            tabPageSettings.Location = new System.Drawing.Point(4, 25);
            tabPageSettings.Margin = new System.Windows.Forms.Padding(2);
            tabPageSettings.Name = "tabPageSettings";
            tabPageSettings.Padding = new System.Windows.Forms.Padding(2);
            tabPageSettings.Size = new System.Drawing.Size(779, 341);
            tabPageSettings.TabIndex = 1;
            tabPageSettings.Text = "Settings";
            // 
            // checkAttackThiefPlayers
            // 
            checkAttackThiefPlayers.AutoSize = true;
            checkAttackThiefPlayers.BackColor = System.Drawing.Color.Transparent;
            checkAttackThiefPlayers.Location = new System.Drawing.Point(41, 49);
            checkAttackThiefPlayers.Margin = new System.Windows.Forms.Padding(2);
            checkAttackThiefPlayers.Name = "checkAttackThiefPlayers";
            checkAttackThiefPlayers.ShadowDepth = 1;
            checkAttackThiefPlayers.Size = new System.Drawing.Size(124, 15);
            checkAttackThiefPlayers.TabIndex = 0;
            checkAttackThiefPlayers.Text = "Attack thief players";
            checkAttackThiefPlayers.UseVisualStyleBackColor = false;
            checkAttackThiefPlayers.CheckedChanged += checkBoxSetting_CheckedChanged;
            // 
            // checkCastBuffs
            // 
            checkCastBuffs.AutoSize = true;
            checkCastBuffs.BackColor = System.Drawing.Color.Transparent;
            checkCastBuffs.Location = new System.Drawing.Point(41, 159);
            checkCastBuffs.Margin = new System.Windows.Forms.Padding(2);
            checkCastBuffs.Name = "checkCastBuffs";
            checkCastBuffs.ShadowDepth = 1;
            checkCastBuffs.Size = new System.Drawing.Size(76, 15);
            checkCastBuffs.TabIndex = 4;
            checkCastBuffs.Text = "Cast buffs";
            checkCastBuffs.UseCompatibleTextRendering = true;
            checkCastBuffs.UseVisualStyleBackColor = false;
            checkCastBuffs.CheckedChanged += checkBoxSetting_CheckedChanged;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = System.Drawing.Color.Transparent;
            groupBox1.Controls.Add(checkSellGoods);
            groupBox1.Controls.Add(lblNumGoodsDesc);
            groupBox1.Controls.Add(checkBuyGoods);
            groupBox1.Controls.Add(numAmountGoods);
            groupBox1.Controls.Add(lblGoods);
            groupBox1.Location = new System.Drawing.Point(316, 14);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new System.Windows.Forms.Padding(3, 8, 3, 3);
            groupBox1.Radius = 10;
            groupBox1.ShadowDepth = 4;
            groupBox1.Size = new System.Drawing.Size(311, 134);
            groupBox1.TabIndex = 28;
            groupBox1.TabStop = false;
            groupBox1.Text = "Buy / Sell";
            // 
            // checkSellGoods
            // 
            checkSellGoods.AutoSize = true;
            checkSellGoods.BackColor = System.Drawing.Color.Transparent;
            checkSellGoods.Location = new System.Drawing.Point(26, 35);
            checkSellGoods.Name = "checkSellGoods";
            checkSellGoods.ShadowDepth = 1;
            checkSellGoods.Size = new System.Drawing.Size(77, 15);
            checkSellGoods.TabIndex = 5;
            checkSellGoods.Text = "Sell goods";
            checkSellGoods.UseVisualStyleBackColor = false;
            checkSellGoods.CheckedChanged += checkBoxSetting_CheckedChanged;
            // 
            // lblNumGoodsDesc
            // 
            lblNumGoodsDesc.AutoSize = true;
            lblNumGoodsDesc.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lblNumGoodsDesc.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            lblNumGoodsDesc.Location = new System.Drawing.Point(77, 82);
            lblNumGoodsDesc.Name = "lblNumGoodsDesc";
            lblNumGoodsDesc.Size = new System.Drawing.Size(96, 13);
            lblNumGoodsDesc.TabIndex = 3;
            lblNumGoodsDesc.Text = "0 = max. possible";
            // 
            // checkBuyGoods
            // 
            checkBuyGoods.AutoSize = true;
            checkBuyGoods.BackColor = System.Drawing.Color.Transparent;
            checkBuyGoods.Location = new System.Drawing.Point(26, 58);
            checkBuyGoods.Name = "checkBuyGoods";
            checkBuyGoods.ShadowDepth = 1;
            checkBuyGoods.Size = new System.Drawing.Size(46, 15);
            checkBuyGoods.TabIndex = 0;
            checkBuyGoods.Text = "Buy ";
            checkBuyGoods.UseVisualStyleBackColor = false;
            checkBuyGoods.CheckedChanged += checkBoxSetting_CheckedChanged;
            // 
            // numAmountGoods
            // 
            numAmountGoods.BackColor = System.Drawing.Color.FromArgb(238, 238, 238);
            numAmountGoods.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            numAmountGoods.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            numAmountGoods.Location = new System.Drawing.Point(78, 55);
            numAmountGoods.Maximum = new decimal(new int[] { 999999, 0, 0, 0 });
            numAmountGoods.Name = "numAmountGoods";
            numAmountGoods.Size = new System.Drawing.Size(95, 23);
            numAmountGoods.TabIndex = 1;
            numAmountGoods.ValueChanged += numSetting_ValueChanged;
            // 
            // lblGoods
            // 
            lblGoods.AutoSize = true;
            lblGoods.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            lblGoods.Location = new System.Drawing.Point(179, 57);
            lblGoods.Name = "lblGoods";
            lblGoods.Size = new System.Drawing.Size(90, 15);
            lblGoods.TabIndex = 2;
            lblGoods.Text = "x Special Goods";
            // 
            // checkProtectTransport
            // 
            checkProtectTransport.AutoSize = true;
            checkProtectTransport.BackColor = System.Drawing.Color.Transparent;
            checkProtectTransport.Location = new System.Drawing.Point(41, 118);
            checkProtectTransport.Margin = new System.Windows.Forms.Padding(2);
            checkProtectTransport.Name = "checkProtectTransport";
            checkProtectTransport.ShadowDepth = 1;
            checkProtectTransport.Size = new System.Drawing.Size(112, 15);
            checkProtectTransport.TabIndex = 6;
            checkProtectTransport.Text = "Protect transport";
            checkProtectTransport.UseVisualStyleBackColor = false;
            checkProtectTransport.CheckedChanged += checkBoxSetting_CheckedChanged;
            // 
            // checkCounterAttack
            // 
            checkCounterAttack.AutoSize = true;
            checkCounterAttack.BackColor = System.Drawing.Color.Transparent;
            checkCounterAttack.Location = new System.Drawing.Point(41, 96);
            checkCounterAttack.Margin = new System.Windows.Forms.Padding(2);
            checkCounterAttack.Name = "checkCounterAttack";
            checkCounterAttack.ShadowDepth = 1;
            checkCounterAttack.Size = new System.Drawing.Size(101, 15);
            checkCounterAttack.TabIndex = 2;
            checkCounterAttack.Text = "Counter attack";
            checkCounterAttack.UseVisualStyleBackColor = false;
            checkCounterAttack.CheckedChanged += checkBoxSetting_CheckedChanged;
            // 
            // checkAttackThiefNpc
            // 
            checkAttackThiefNpc.AutoSize = true;
            checkAttackThiefNpc.BackColor = System.Drawing.Color.Transparent;
            checkAttackThiefNpc.Location = new System.Drawing.Point(41, 72);
            checkAttackThiefNpc.Margin = new System.Windows.Forms.Padding(2);
            checkAttackThiefNpc.Name = "checkAttackThiefNpc";
            checkAttackThiefNpc.ShadowDepth = 1;
            checkAttackThiefNpc.Size = new System.Drawing.Size(116, 15);
            checkAttackThiefNpc.TabIndex = 1;
            checkAttackThiefNpc.Text = "Attack thief NPCs";
            checkAttackThiefNpc.UseVisualStyleBackColor = false;
            checkAttackThiefNpc.CheckedChanged += checkBoxSetting_CheckedChanged;
            // 
            // groupBox2
            // 
            groupBox2.BackColor = System.Drawing.Color.Transparent;
            groupBox2.Controls.Add(separator2);
            groupBox2.Controls.Add(checkWaitForHunter);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(separator4);
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(numMaxDistance);
            groupBox2.Controls.Add(checkMountTransport);
            groupBox2.Controls.Add(separator1);
            groupBox2.Location = new System.Drawing.Point(13, 14);
            groupBox2.Margin = new System.Windows.Forms.Padding(2);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new System.Windows.Forms.Padding(2, 4, 2, 2);
            groupBox2.Radius = 10;
            groupBox2.ShadowDepth = 4;
            groupBox2.Size = new System.Drawing.Size(287, 316);
            groupBox2.TabIndex = 29;
            groupBox2.TabStop = false;
            groupBox2.Text = "Settings";
            // 
            // separator2
            // 
            separator2.IsVertical = false;
            separator2.Location = new System.Drawing.Point(2, 258);
            separator2.Margin = new System.Windows.Forms.Padding(2);
            separator2.Name = "separator2";
            separator2.Size = new System.Drawing.Size(282, 12);
            separator2.TabIndex = 31;
            separator2.Text = "separator2";
            // 
            // checkWaitForHunter
            // 
            checkWaitForHunter.AutoSize = true;
            checkWaitForHunter.BackColor = System.Drawing.Color.Transparent;
            checkWaitForHunter.Location = new System.Drawing.Point(28, 281);
            checkWaitForHunter.Margin = new System.Windows.Forms.Padding(2);
            checkWaitForHunter.Name = "checkWaitForHunter";
            checkWaitForHunter.ShadowDepth = 1;
            checkWaitForHunter.Size = new System.Drawing.Size(151, 15);
            checkWaitForHunter.TabIndex = 30;
            checkWaitForHunter.Text = "Wait for a hunter nearby";
            checkWaitForHunter.UseVisualStyleBackColor = false;
            checkWaitForHunter.CheckedChanged += checkBoxSetting_CheckedChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            label3.Location = new System.Drawing.Point(91, 232);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(43, 15);
            label3.TabIndex = 6;
            label3.Text = "meters";
            // 
            // separator4
            // 
            separator4.IsVertical = false;
            separator4.Location = new System.Drawing.Point(1, 167);
            separator4.Margin = new System.Windows.Forms.Padding(2);
            separator4.Name = "separator4";
            separator4.Size = new System.Drawing.Size(282, 12);
            separator4.TabIndex = 8;
            separator4.Text = "separator4";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            label1.Location = new System.Drawing.Point(28, 211);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(83, 15);
            label1.TabIndex = 5;
            label1.Text = "Max. distance:";
            // 
            // numMaxDistance
            // 
            numMaxDistance.BackColor = System.Drawing.Color.FromArgb(238, 238, 238);
            numMaxDistance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            numMaxDistance.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            numMaxDistance.Location = new System.Drawing.Point(30, 230);
            numMaxDistance.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numMaxDistance.Name = "numMaxDistance";
            numMaxDistance.Size = new System.Drawing.Size(56, 23);
            numMaxDistance.TabIndex = 4;
            numMaxDistance.Value = new decimal(new int[] { 1, 0, 0, 0 });
            numMaxDistance.ValueChanged += numSetting_ValueChanged;
            // 
            // checkMountTransport
            // 
            checkMountTransport.AutoSize = true;
            checkMountTransport.BackColor = System.Drawing.Color.Transparent;
            checkMountTransport.Location = new System.Drawing.Point(28, 186);
            checkMountTransport.Margin = new System.Windows.Forms.Padding(2);
            checkMountTransport.Name = "checkMountTransport";
            checkMountTransport.ShadowDepth = 1;
            checkMountTransport.Size = new System.Drawing.Size(110, 15);
            checkMountTransport.TabIndex = 7;
            checkMountTransport.Text = "Mount transport";
            checkMountTransport.UseVisualStyleBackColor = false;
            checkMountTransport.CheckedChanged += checkBoxSetting_CheckedChanged;
            // 
            // separator1
            // 
            separator1.IsVertical = false;
            separator1.Location = new System.Drawing.Point(3, 122);
            separator1.Margin = new System.Windows.Forms.Padding(2);
            separator1.Name = "separator1";
            separator1.Size = new System.Drawing.Size(282, 12);
            separator1.TabIndex = 3;
            separator1.Text = "separator1";
            // 
            // tabPage1
            // 
            tabPage1.BackColor = System.Drawing.Color.White;
            tabPage1.Controls.Add(lblJobExp);
            tabPage1.Controls.Add(lblJobLevel);
            tabPage1.Controls.Add(lblJobAlias);
            tabPage1.Controls.Add(label9);
            tabPage1.Controls.Add(label8);
            tabPage1.Controls.Add(label7);
            tabPage1.Controls.Add(separator3);
            tabPage1.Controls.Add(lblTradeScale);
            tabPage1.Controls.Add(label2);
            tabPage1.Location = new System.Drawing.Point(4, 25);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new System.Windows.Forms.Padding(3);
            tabPage1.Size = new System.Drawing.Size(779, 341);
            tabPage1.TabIndex = 2;
            tabPage1.Text = "Job overview";
            // 
            // lblJobExp
            // 
            lblJobExp.AutoSize = true;
            lblJobExp.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            lblJobExp.Location = new System.Drawing.Point(129, 163);
            lblJobExp.Name = "lblJobExp";
            lblJobExp.Size = new System.Drawing.Size(13, 15);
            lblJobExp.TabIndex = 11;
            lblJobExp.Text = "0";
            // 
            // lblJobLevel
            // 
            lblJobLevel.AutoSize = true;
            lblJobLevel.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            lblJobLevel.Location = new System.Drawing.Point(129, 127);
            lblJobLevel.Name = "lblJobLevel";
            lblJobLevel.Size = new System.Drawing.Size(13, 15);
            lblJobLevel.TabIndex = 10;
            lblJobLevel.Text = "0";
            // 
            // lblJobAlias
            // 
            lblJobAlias.AutoSize = true;
            lblJobAlias.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            lblJobAlias.Location = new System.Drawing.Point(129, 90);
            lblJobAlias.Name = "lblJobAlias";
            lblJobAlias.Size = new System.Drawing.Size(50, 15);
            lblJobAlias.TabIndex = 9;
            lblJobAlias.Text = "<none>";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            label9.Location = new System.Drawing.Point(93, 163);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(30, 15);
            label9.TabIndex = 8;
            label9.Text = "EXP:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            label8.Location = new System.Drawing.Point(69, 90);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(54, 15);
            label8.TabIndex = 7;
            label8.Text = "Job alias:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            label7.Location = new System.Drawing.Point(86, 127);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(37, 15);
            label7.TabIndex = 7;
            label7.Text = "Level:";
            // 
            // separator3
            // 
            separator3.IsVertical = false;
            separator3.Location = new System.Drawing.Point(20, 67);
            separator3.Name = "separator3";
            separator3.Size = new System.Drawing.Size(365, 10);
            separator3.TabIndex = 6;
            separator3.Text = "separator3";
            // 
            // lblTradeScale
            // 
            lblTradeScale.AutoSize = true;
            lblTradeScale.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            lblTradeScale.Location = new System.Drawing.Point(144, 37);
            lblTradeScale.Name = "lblTradeScale";
            lblTradeScale.Size = new System.Drawing.Size(57, 15);
            lblTradeScale.TabIndex = 2;
            lblTradeScale.Text = "■■■■■";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
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
            Size = new System.Drawing.Size(790, 408);
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
            ((System.ComponentModel.ISupportInitialize)numAmountGoods).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numMaxDistance).EndInit();
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private SDUI.Controls.ContextMenuStrip contextMenuRouteList;
        private System.Windows.Forms.ToolStripMenuItem addScriptToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuRemoveScript;
        private SDUI.Controls.Label lblHint;
        private SDUI.Controls.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageRoute;
        private System.Windows.Forms.LinkLabel linkRecord;
        private SDUI.Controls.ListView lvRouteList;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.TabPage tabPageSettings;
        private SDUI.Controls.ComboBox comboRouteList;
        private SDUI.Controls.Button buttonDeleteList;
        private SDUI.Controls.Button buttonCreateList;
        private SDUI.Controls.Radio radioUseRouteList;
        private SDUI.Controls.Radio radioTracePlayer;
        private SDUI.Controls.TextBox txtTracePlayerName;
        private SDUI.Controls.CheckBox checkCastBuffs;
        private SDUI.Controls.Separator separator1;
        private SDUI.Controls.CheckBox checkCounterAttack;
        private SDUI.Controls.CheckBox checkAttackThiefNpc;
        private SDUI.Controls.CheckBox checkAttackThiefPlayers;
        private System.Windows.Forms.ToolStripMenuItem menuRecordScript;
        private System.Windows.Forms.ToolStripMenuItem menuChooseScript;
        private SDUI.Controls.CheckBox checkRunTownscript;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private SDUI.Controls.Panel panel1;
        private SDUI.Controls.CheckBox checkProtectTransport;
        private SDUI.Controls.GroupBox groupBox1;
        private SDUI.Controls.CheckBox checkBuyGoods;
        private SDUI.Controls.Label lblGoods;
        private SDUI.Controls.NumUpDown numAmountGoods;
        private SDUI.Controls.Label lblNumGoodsDesc;
        private SDUI.Controls.CheckBox checkSellGoods;
        private System.Windows.Forms.TabPage tabPage1;
        private SDUI.Controls.Label label4;
        private SDUI.Controls.Label lblTradeScale;
        private SDUI.Controls.Label label2;
        private SDUI.Controls.Separator separator3;
        private SDUI.Controls.Label label9;
        private SDUI.Controls.Label label8;
        private SDUI.Controls.Label label7;
        private SDUI.Controls.Label lblJobExp;
        private SDUI.Controls.Label lblJobLevel;
        private SDUI.Controls.Label lblJobAlias;
        private SDUI.Controls.CheckBox checkMountTransport;
        private SDUI.Controls.GroupBox groupBox2;
        private SDUI.Controls.Label label3;
        private SDUI.Controls.Label label1;
        private SDUI.Controls.NumUpDown numMaxDistance;
        private SDUI.Controls.Separator separator4;
        private SDUI.Controls.Separator separator2;
        private SDUI.Controls.CheckBox checkWaitForHunter;
    }
}
