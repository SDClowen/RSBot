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
            executeHereToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            checkWaitForHunter = new SDUI.Controls.CheckBox();
            checkRunTownscript = new SDUI.Controls.CheckBox();
            tabPageSettings = new System.Windows.Forms.TabPage();
            groupBox1 = new SDUI.Controls.GroupBox();
            checkSellGoods = new SDUI.Controls.CheckBox();
            separator2 = new SDUI.Controls.Separator();
            lblNumGoodsDesc = new SDUI.Controls.Label();
            lblGoods = new SDUI.Controls.Label();
            numAmountGoods = new SDUI.Controls.NumUpDown();
            checkBuyGoods = new SDUI.Controls.CheckBox();
            groupBox2 = new SDUI.Controls.GroupBox();
            checkProtectTransport = new SDUI.Controls.CheckBox();
            checkCastBuffs = new SDUI.Controls.CheckBox();
            separator1 = new SDUI.Controls.Separator();
            checkCounterAttack = new SDUI.Controls.CheckBox();
            checkAttackThiefNpc = new SDUI.Controls.CheckBox();
            checkAttackThiefPlayers = new SDUI.Controls.CheckBox();
            tabPage1 = new System.Windows.Forms.TabPage();
            lblJobExp = new SDUI.Controls.Label();
            lblJobLevel = new SDUI.Controls.Label();
            lblJobAlias = new SDUI.Controls.Label();
            label9 = new SDUI.Controls.Label();
            label8 = new SDUI.Controls.Label();
            label7 = new SDUI.Controls.Label();
            separator3 = new SDUI.Controls.Separator();
            lblRevenue = new SDUI.Controls.Label();
            label5 = new SDUI.Controls.Label();
            label4 = new SDUI.Controls.Label();
            lblTradeScale = new SDUI.Controls.Label();
            label2 = new SDUI.Controls.Label();
            lblNumTradesCompleted = new SDUI.Controls.Label();
            contextMenuRouteList.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPageRoute.SuspendLayout();
            panel1.SuspendLayout();
            tabPageSettings.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numAmountGoods).BeginInit();
            groupBox2.SuspendLayout();
            tabPage1.SuspendLayout();
            SuspendLayout();
            // 
            // contextMenuRouteList
            // 
            contextMenuRouteList.ImageScalingSize = new System.Drawing.Size(20, 20);
            contextMenuRouteList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { addScriptToolStripMenuItem, menuRemoveScript, executeHereToolStripMenuItem });
            contextMenuRouteList.Name = "contextMenuStrip1";
            contextMenuRouteList.Size = new System.Drawing.Size(196, 118);
            // 
            // addScriptToolStripMenuItem
            // 
            addScriptToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { menuRecordScript, menuChooseScript });
            addScriptToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            addScriptToolStripMenuItem.Name = "addScriptToolStripMenuItem";
            addScriptToolStripMenuItem.Size = new System.Drawing.Size(195, 38);
            addScriptToolStripMenuItem.Text = "Add script";
            // 
            // menuRecordScript
            // 
            menuRecordScript.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            menuRecordScript.Name = "menuRecordScript";
            menuRecordScript.Size = new System.Drawing.Size(282, 44);
            menuRecordScript.Text = "Record";
            // 
            // menuChooseScript
            // 
            menuChooseScript.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            menuChooseScript.Name = "menuChooseScript";
            menuChooseScript.Size = new System.Drawing.Size(282, 44);
            menuChooseScript.Text = "Choose file...";
            menuChooseScript.Click += menuChooseScript_Click;
            // 
            // menuRemoveScript
            // 
            menuRemoveScript.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            menuRemoveScript.Name = "menuRemoveScript";
            menuRemoveScript.Size = new System.Drawing.Size(195, 38);
            menuRemoveScript.Text = "Remove";
            menuRemoveScript.Click += menuRemoveScript_Click;
            // 
            // executeHereToolStripMenuItem
            // 
            executeHereToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            executeHereToolStripMenuItem.Name = "executeHereToolStripMenuItem";
            executeHereToolStripMenuItem.Size = new System.Drawing.Size(195, 38);
            executeHereToolStripMenuItem.Text = "Start here";
            executeHereToolStripMenuItem.Click += executeHereToolStripMenuItem_Click;
            // 
            // lblHint
            // 
            lblHint.AutoSize = true;
            lblHint.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            lblHint.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            lblHint.Location = new System.Drawing.Point(4, 748);
            lblHint.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblHint.Name = "lblHint";
            lblHint.Size = new System.Drawing.Size(642, 32);
            lblHint.TabIndex = 7;
            lblHint.Text = "Hint: Automatic teleportation is not supported in trace mode";
            // 
            // tabControl1
            // 
            tabControl1.Border = new System.Windows.Forms.Padding(1);
            tabControl1.Controls.Add(tabPageRoute);
            tabControl1.Controls.Add(tabPageSettings);
            tabControl1.Controls.Add(tabPage1);
            tabControl1.HideTabArea = false;
            tabControl1.Location = new System.Drawing.Point(4, 4);
            tabControl1.Margin = new System.Windows.Forms.Padding(4);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new System.Drawing.Size(1574, 740);
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
            tabPageRoute.Location = new System.Drawing.Point(8, 30);
            tabPageRoute.Margin = new System.Windows.Forms.Padding(4);
            tabPageRoute.Name = "tabPageRoute";
            tabPageRoute.Padding = new System.Windows.Forms.Padding(4);
            tabPageRoute.Size = new System.Drawing.Size(1558, 702);
            tabPageRoute.TabIndex = 0;
            tabPageRoute.Text = "Route";
            // 
            // txtTracePlayerName
            // 
            txtTracePlayerName.Location = new System.Drawing.Point(218, 28);
            txtTracePlayerName.Margin = new System.Windows.Forms.Padding(4);
            txtTracePlayerName.MaxLength = 32767;
            txtTracePlayerName.MultiLine = false;
            txtTracePlayerName.Name = "txtTracePlayerName";
            txtTracePlayerName.Radius = 2;
            txtTracePlayerName.Size = new System.Drawing.Size(242, 37);
            txtTracePlayerName.TabIndex = 24;
            txtTracePlayerName.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            txtTracePlayerName.UseSystemPasswordChar = false;
            txtTracePlayerName.TextChanged += txtTracePlayerName_TextChanged;
            // 
            // radioUseRouteList
            // 
            radioUseRouteList.AutoSize = true;
            radioUseRouteList.Checked = true;
            radioUseRouteList.Location = new System.Drawing.Point(18, 92);
            radioUseRouteList.Margin = new System.Windows.Forms.Padding(4);
            radioUseRouteList.Name = "radioUseRouteList";
            radioUseRouteList.ShadowDepth = 0;
            radioUseRouteList.Size = new System.Drawing.Size(179, 32);
            radioUseRouteList.TabIndex = 23;
            radioUseRouteList.TabStop = true;
            radioUseRouteList.Text = "Use route list";
            radioUseRouteList.UseVisualStyleBackColor = true;
            radioUseRouteList.CheckedChanged += radioSetting_CheckedChanged;
            // 
            // radioTracePlayer
            // 
            radioTracePlayer.AutoSize = true;
            radioTracePlayer.Location = new System.Drawing.Point(18, 28);
            radioTracePlayer.Margin = new System.Windows.Forms.Padding(4);
            radioTracePlayer.Name = "radioTracePlayer";
            radioTracePlayer.ShadowDepth = 0;
            radioTracePlayer.Size = new System.Drawing.Size(166, 32);
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
            buttonDeleteList.Location = new System.Drawing.Point(468, 84);
            buttonDeleteList.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            buttonDeleteList.Name = "buttonDeleteList";
            buttonDeleteList.Radius = 6;
            buttonDeleteList.ShadowDepth = 4F;
            buttonDeleteList.Size = new System.Drawing.Size(44, 52);
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
            buttonCreateList.Location = new System.Drawing.Point(514, 84);
            buttonCreateList.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            buttonCreateList.Name = "buttonCreateList";
            buttonCreateList.Radius = 6;
            buttonCreateList.ShadowDepth = 4F;
            buttonCreateList.Size = new System.Drawing.Size(44, 52);
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
            comboRouteList.Location = new System.Drawing.Point(216, 86);
            comboRouteList.Margin = new System.Windows.Forms.Padding(4);
            comboRouteList.Name = "comboRouteList";
            comboRouteList.Radius = 5;
            comboRouteList.ShadowDepth = 4F;
            comboRouteList.Size = new System.Drawing.Size(240, 40);
            comboRouteList.TabIndex = 19;
            comboRouteList.SelectedIndexChanged += comboRouteList_SelectedIndexChanged;
            // 
            // linkRecord
            // 
            linkRecord.AutoSize = true;
            linkRecord.Location = new System.Drawing.Point(1436, 92);
            linkRecord.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            linkRecord.Name = "linkRecord";
            linkRecord.Size = new System.Drawing.Size(101, 32);
            linkRecord.TabIndex = 16;
            linkRecord.TabStop = true;
            linkRecord.Text = "[Record]";
            // 
            // lvRouteList
            // 
            lvRouteList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { columnHeader1, columnHeader2, columnHeader4, columnHeader3 });
            lvRouteList.ContextMenuStrip = contextMenuRouteList;
            lvRouteList.FullRowSelect = true;
            lvRouteList.Location = new System.Drawing.Point(18, 168);
            lvRouteList.Margin = new System.Windows.Forms.Padding(4);
            lvRouteList.Name = "lvRouteList";
            lvRouteList.Size = new System.Drawing.Size(1520, 410);
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
            panel1.Controls.Add(checkWaitForHunter);
            panel1.Controls.Add(checkRunTownscript);
            panel1.Location = new System.Drawing.Point(14, 570);
            panel1.Margin = new System.Windows.Forms.Padding(6);
            panel1.Name = "panel1";
            panel1.Radius = 10;
            panel1.ShadowDepth = 4F;
            panel1.Size = new System.Drawing.Size(1532, 84);
            panel1.TabIndex = 29;
            // 
            // checkWaitForHunter
            // 
            checkWaitForHunter.AutoSize = true;
            checkWaitForHunter.BackColor = System.Drawing.Color.Transparent;
            checkWaitForHunter.Location = new System.Drawing.Point(526, 30);
            checkWaitForHunter.Margin = new System.Windows.Forms.Padding(4);
            checkWaitForHunter.Name = "checkWaitForHunter";
            checkWaitForHunter.ShadowDepth = 1;
            checkWaitForHunter.Size = new System.Drawing.Size(291, 32);
            checkWaitForHunter.TabIndex = 28;
            checkWaitForHunter.Text = "Wait for a hunter nearby";
            checkWaitForHunter.UseVisualStyleBackColor = false;
            checkWaitForHunter.CheckedChanged += checkBoxSetting_CheckedChanged;
            // 
            // checkRunTownscript
            // 
            checkRunTownscript.AutoSize = true;
            checkRunTownscript.BackColor = System.Drawing.Color.Transparent;
            checkRunTownscript.Location = new System.Drawing.Point(34, 30);
            checkRunTownscript.Margin = new System.Windows.Forms.Padding(4);
            checkRunTownscript.Name = "checkRunTownscript";
            checkRunTownscript.ShadowDepth = 1;
            checkRunTownscript.Size = new System.Drawing.Size(401, 32);
            checkRunTownscript.TabIndex = 27;
            checkRunTownscript.Text = "Run townscript after route finished";
            checkRunTownscript.UseVisualStyleBackColor = false;
            checkRunTownscript.CheckedChanged += checkBoxSetting_CheckedChanged;
            // 
            // tabPageSettings
            // 
            tabPageSettings.BackColor = System.Drawing.Color.White;
            tabPageSettings.Controls.Add(groupBox1);
            tabPageSettings.Controls.Add(groupBox2);
            tabPageSettings.Location = new System.Drawing.Point(8, 30);
            tabPageSettings.Margin = new System.Windows.Forms.Padding(4);
            tabPageSettings.Name = "tabPageSettings";
            tabPageSettings.Padding = new System.Windows.Forms.Padding(4);
            tabPageSettings.Size = new System.Drawing.Size(1558, 702);
            tabPageSettings.TabIndex = 1;
            tabPageSettings.Text = "Settings";
            // 
            // groupBox1
            // 
            groupBox1.BackColor = System.Drawing.Color.Transparent;
            groupBox1.Controls.Add(checkSellGoods);
            groupBox1.Controls.Add(separator2);
            groupBox1.Controls.Add(lblNumGoodsDesc);
            groupBox1.Controls.Add(lblGoods);
            groupBox1.Controls.Add(numAmountGoods);
            groupBox1.Controls.Add(checkBuyGoods);
            groupBox1.Location = new System.Drawing.Point(610, 28);
            groupBox1.Margin = new System.Windows.Forms.Padding(6);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new System.Windows.Forms.Padding(6, 16, 6, 6);
            groupBox1.Radius = 10;
            groupBox1.ShadowDepth = 4;
            groupBox1.Size = new System.Drawing.Size(608, 276);
            groupBox1.TabIndex = 28;
            groupBox1.TabStop = false;
            groupBox1.Text = "Buy / Sell";
            // 
            // checkSellGoods
            // 
            checkSellGoods.AutoSize = true;
            checkSellGoods.BackColor = System.Drawing.Color.Transparent;
            checkSellGoods.Location = new System.Drawing.Point(30, 210);
            checkSellGoods.Margin = new System.Windows.Forms.Padding(6);
            checkSellGoods.Name = "checkSellGoods";
            checkSellGoods.ShadowDepth = 1;
            checkSellGoods.Size = new System.Drawing.Size(141, 32);
            checkSellGoods.TabIndex = 5;
            checkSellGoods.Text = "Sell goods";
            checkSellGoods.UseVisualStyleBackColor = false;
            checkSellGoods.CheckedChanged += checkBoxSetting_CheckedChanged;
            // 
            // separator2
            // 
            separator2.IsVertical = false;
            separator2.Location = new System.Drawing.Point(30, 168);
            separator2.Margin = new System.Windows.Forms.Padding(4);
            separator2.Name = "separator2";
            separator2.Size = new System.Drawing.Size(468, 24);
            separator2.TabIndex = 4;
            separator2.Text = "separator2";
            // 
            // lblNumGoodsDesc
            // 
            lblNumGoodsDesc.AutoSize = true;
            lblNumGoodsDesc.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lblNumGoodsDesc.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            lblNumGoodsDesc.Location = new System.Drawing.Point(132, 122);
            lblNumGoodsDesc.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            lblNumGoodsDesc.Name = "lblNumGoodsDesc";
            lblNumGoodsDesc.Size = new System.Drawing.Size(182, 30);
            lblNumGoodsDesc.TabIndex = 3;
            lblNumGoodsDesc.Text = "0 = max. possible";
            // 
            // lblGoods
            // 
            lblGoods.AutoSize = true;
            lblGoods.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            lblGoods.Location = new System.Drawing.Point(386, 74);
            lblGoods.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            lblGoods.Name = "lblGoods";
            lblGoods.Size = new System.Drawing.Size(208, 32);
            lblGoods.TabIndex = 2;
            lblGoods.Text = "x Speciality Goods";
            // 
            // numAmountGoods
            // 
            numAmountGoods.BackColor = System.Drawing.Color.FromArgb(238, 238, 238);
            numAmountGoods.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            numAmountGoods.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            numAmountGoods.Location = new System.Drawing.Point(134, 68);
            numAmountGoods.Margin = new System.Windows.Forms.Padding(6);
            numAmountGoods.Name = "numAmountGoods";
            numAmountGoods.Size = new System.Drawing.Size(240, 39);
            numAmountGoods.TabIndex = 1;
            numAmountGoods.ValueChanged += numAmountGoods_ValueChanged;
            // 
            // checkBuyGoods
            // 
            checkBuyGoods.AutoSize = true;
            checkBuyGoods.BackColor = System.Drawing.Color.Transparent;
            checkBuyGoods.Location = new System.Drawing.Point(30, 74);
            checkBuyGoods.Margin = new System.Windows.Forms.Padding(6);
            checkBuyGoods.Name = "checkBuyGoods";
            checkBuyGoods.ShadowDepth = 1;
            checkBuyGoods.Size = new System.Drawing.Size(77, 32);
            checkBuyGoods.TabIndex = 0;
            checkBuyGoods.Text = "Buy ";
            checkBuyGoods.UseVisualStyleBackColor = false;
            checkBuyGoods.CheckedChanged += checkBoxSetting_CheckedChanged;
            // 
            // groupBox2
            // 
            groupBox2.BackColor = System.Drawing.Color.Transparent;
            groupBox2.Controls.Add(checkProtectTransport);
            groupBox2.Controls.Add(checkCastBuffs);
            groupBox2.Controls.Add(separator1);
            groupBox2.Controls.Add(checkCounterAttack);
            groupBox2.Controls.Add(checkAttackThiefNpc);
            groupBox2.Controls.Add(checkAttackThiefPlayers);
            groupBox2.Location = new System.Drawing.Point(26, 28);
            groupBox2.Margin = new System.Windows.Forms.Padding(4);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new System.Windows.Forms.Padding(4, 12, 4, 4);
            groupBox2.Radius = 10;
            groupBox2.ShadowDepth = 4;
            groupBox2.Size = new System.Drawing.Size(492, 428);
            groupBox2.TabIndex = 27;
            groupBox2.TabStop = false;
            groupBox2.Text = "Attacking / buffing";
            // 
            // checkProtectTransport
            // 
            checkProtectTransport.AutoSize = true;
            checkProtectTransport.BackColor = System.Drawing.Color.Transparent;
            checkProtectTransport.Location = new System.Drawing.Point(30, 210);
            checkProtectTransport.Margin = new System.Windows.Forms.Padding(4);
            checkProtectTransport.Name = "checkProtectTransport";
            checkProtectTransport.ShadowDepth = 1;
            checkProtectTransport.Size = new System.Drawing.Size(208, 32);
            checkProtectTransport.TabIndex = 6;
            checkProtectTransport.Text = "Protect transport";
            checkProtectTransport.UseVisualStyleBackColor = false;
            checkProtectTransport.CheckedChanged += checkBoxSetting_CheckedChanged;
            // 
            // checkCastBuffs
            // 
            checkCastBuffs.AutoSize = true;
            checkCastBuffs.BackColor = System.Drawing.Color.Transparent;
            checkCastBuffs.Location = new System.Drawing.Point(30, 294);
            checkCastBuffs.Margin = new System.Windows.Forms.Padding(4);
            checkCastBuffs.Name = "checkCastBuffs";
            checkCastBuffs.ShadowDepth = 1;
            checkCastBuffs.Size = new System.Drawing.Size(136, 32);
            checkCastBuffs.TabIndex = 4;
            checkCastBuffs.Text = "Cast buffs";
            checkCastBuffs.UseCompatibleTextRendering = true;
            checkCastBuffs.UseVisualStyleBackColor = false;
            checkCastBuffs.CheckedChanged += checkBoxSetting_CheckedChanged;
            // 
            // separator1
            // 
            separator1.IsVertical = false;
            separator1.Location = new System.Drawing.Point(12, 256);
            separator1.Margin = new System.Windows.Forms.Padding(4);
            separator1.Name = "separator1";
            separator1.Size = new System.Drawing.Size(468, 24);
            separator1.TabIndex = 3;
            separator1.Text = "separator1";
            // 
            // checkCounterAttack
            // 
            checkCounterAttack.AutoSize = true;
            checkCounterAttack.BackColor = System.Drawing.Color.Transparent;
            checkCounterAttack.Location = new System.Drawing.Point(30, 162);
            checkCounterAttack.Margin = new System.Windows.Forms.Padding(4);
            checkCounterAttack.Name = "checkCounterAttack";
            checkCounterAttack.ShadowDepth = 1;
            checkCounterAttack.Size = new System.Drawing.Size(186, 32);
            checkCounterAttack.TabIndex = 2;
            checkCounterAttack.Text = "Counter attack";
            checkCounterAttack.UseVisualStyleBackColor = false;
            checkCounterAttack.CheckedChanged += checkBoxSetting_CheckedChanged;
            // 
            // checkAttackThiefNpc
            // 
            checkAttackThiefNpc.AutoSize = true;
            checkAttackThiefNpc.BackColor = System.Drawing.Color.Transparent;
            checkAttackThiefNpc.Location = new System.Drawing.Point(30, 116);
            checkAttackThiefNpc.Margin = new System.Windows.Forms.Padding(4);
            checkAttackThiefNpc.Name = "checkAttackThiefNpc";
            checkAttackThiefNpc.ShadowDepth = 1;
            checkAttackThiefNpc.Size = new System.Drawing.Size(215, 32);
            checkAttackThiefNpc.TabIndex = 1;
            checkAttackThiefNpc.Text = "Attack thief NPCs";
            checkAttackThiefNpc.UseVisualStyleBackColor = false;
            checkAttackThiefNpc.CheckedChanged += checkBoxSetting_CheckedChanged;
            // 
            // checkAttackThiefPlayers
            // 
            checkAttackThiefPlayers.AutoSize = true;
            checkAttackThiefPlayers.BackColor = System.Drawing.Color.Transparent;
            checkAttackThiefPlayers.Location = new System.Drawing.Point(30, 72);
            checkAttackThiefPlayers.Margin = new System.Windows.Forms.Padding(4);
            checkAttackThiefPlayers.Name = "checkAttackThiefPlayers";
            checkAttackThiefPlayers.ShadowDepth = 1;
            checkAttackThiefPlayers.Size = new System.Drawing.Size(234, 32);
            checkAttackThiefPlayers.TabIndex = 0;
            checkAttackThiefPlayers.Text = "Attack thief players";
            checkAttackThiefPlayers.UseVisualStyleBackColor = false;
            checkAttackThiefPlayers.CheckedChanged += checkBoxSetting_CheckedChanged;
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
            tabPage1.Controls.Add(lblRevenue);
            tabPage1.Controls.Add(label5);
            tabPage1.Controls.Add(label4);
            tabPage1.Controls.Add(lblTradeScale);
            tabPage1.Controls.Add(label2);
            tabPage1.Controls.Add(lblNumTradesCompleted);
            tabPage1.Location = new System.Drawing.Point(8, 30);
            tabPage1.Margin = new System.Windows.Forms.Padding(6);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new System.Windows.Forms.Padding(6);
            tabPage1.Size = new System.Drawing.Size(1558, 702);
            tabPage1.TabIndex = 2;
            tabPage1.Text = "Trade overview";
            // 
            // lblJobExp
            // 
            lblJobExp.AutoSize = true;
            lblJobExp.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            lblJobExp.Location = new System.Drawing.Point(288, 490);
            lblJobExp.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            lblJobExp.Name = "lblJobExp";
            lblJobExp.Size = new System.Drawing.Size(27, 32);
            lblJobExp.TabIndex = 11;
            lblJobExp.Text = "0";
            // 
            // lblJobLevel
            // 
            lblJobLevel.AutoSize = true;
            lblJobLevel.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            lblJobLevel.Location = new System.Drawing.Point(288, 418);
            lblJobLevel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            lblJobLevel.Name = "lblJobLevel";
            lblJobLevel.Size = new System.Drawing.Size(27, 32);
            lblJobLevel.TabIndex = 10;
            lblJobLevel.Text = "0";
            // 
            // lblJobAlias
            // 
            lblJobAlias.AutoSize = true;
            lblJobAlias.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            lblJobAlias.Location = new System.Drawing.Point(288, 344);
            lblJobAlias.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            lblJobAlias.Name = "lblJobAlias";
            lblJobAlias.Size = new System.Drawing.Size(101, 32);
            lblJobAlias.TabIndex = 9;
            lblJobAlias.Text = "<none>";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            label9.Location = new System.Drawing.Point(216, 490);
            label9.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(58, 32);
            label9.TabIndex = 8;
            label9.Text = "EXP:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            label8.Location = new System.Drawing.Point(168, 344);
            label8.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(109, 32);
            label8.TabIndex = 7;
            label8.Text = "Job alias:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            label7.Location = new System.Drawing.Point(202, 418);
            label7.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(74, 32);
            label7.TabIndex = 7;
            label7.Text = "Level:";
            // 
            // separator3
            // 
            separator3.IsVertical = false;
            separator3.Location = new System.Drawing.Point(70, 298);
            separator3.Margin = new System.Windows.Forms.Padding(6);
            separator3.Name = "separator3";
            separator3.Size = new System.Drawing.Size(730, 20);
            separator3.TabIndex = 6;
            separator3.Text = "separator3";
            // 
            // lblRevenue
            // 
            lblRevenue.AutoSize = true;
            lblRevenue.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            lblRevenue.Location = new System.Drawing.Point(288, 208);
            lblRevenue.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            lblRevenue.Name = "lblRevenue";
            lblRevenue.Size = new System.Drawing.Size(27, 32);
            lblRevenue.TabIndex = 5;
            lblRevenue.Text = "0";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            label5.Location = new System.Drawing.Point(114, 208);
            label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(164, 32);
            label5.TabIndex = 4;
            label5.Text = "Total revenue:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            label4.Location = new System.Drawing.Point(288, 142);
            label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(27, 32);
            label4.TabIndex = 3;
            label4.Text = "0";
            // 
            // lblTradeScale
            // 
            lblTradeScale.AutoSize = true;
            lblTradeScale.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            lblTradeScale.Location = new System.Drawing.Point(288, 74);
            lblTradeScale.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            lblTradeScale.Name = "lblTradeScale";
            lblTradeScale.Size = new System.Drawing.Size(119, 32);
            lblTradeScale.TabIndex = 2;
            lblTradeScale.Text = "■■■■■";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            label2.Location = new System.Drawing.Point(100, 74);
            label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(177, 32);
            label2.TabIndex = 1;
            label2.Text = "Trade difficulty:";
            // 
            // lblNumTradesCompleted
            // 
            lblNumTradesCompleted.AutoSize = true;
            lblNumTradesCompleted.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            lblNumTradesCompleted.Location = new System.Drawing.Point(70, 142);
            lblNumTradesCompleted.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            lblNumTradesCompleted.Name = "lblNumTradesCompleted";
            lblNumTradesCompleted.Size = new System.Drawing.Size(208, 32);
            lblNumTradesCompleted.TabIndex = 0;
            lblNumTradesCompleted.Text = "Trades completed:";
            // 
            // Main
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(192F, 192F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            Controls.Add(tabControl1);
            Controls.Add(lblHint);
            Margin = new System.Windows.Forms.Padding(4);
            Name = "Main";
            Size = new System.Drawing.Size(1580, 816);
            contextMenuRouteList.ResumeLayout(false);
            tabControl1.ResumeLayout(false);
            tabPageRoute.ResumeLayout(false);
            tabPageRoute.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            tabPageSettings.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numAmountGoods).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
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
        private SDUI.Controls.GroupBox groupBox2;
        private SDUI.Controls.CheckBox checkCastBuffs;
        private SDUI.Controls.Separator separator1;
        private SDUI.Controls.CheckBox checkCounterAttack;
        private SDUI.Controls.CheckBox checkAttackThiefNpc;
        private SDUI.Controls.CheckBox checkAttackThiefPlayers;
        private System.Windows.Forms.ToolStripMenuItem menuRecordScript;
        private System.Windows.Forms.ToolStripMenuItem menuChooseScript;
        private SDUI.Controls.CheckBox checkWaitForHunter;
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
        private SDUI.Controls.Separator separator2;
        private System.Windows.Forms.TabPage tabPage1;
        private SDUI.Controls.Label lblRevenue;
        private SDUI.Controls.Label label5;
        private SDUI.Controls.Label label4;
        private SDUI.Controls.Label lblTradeScale;
        private SDUI.Controls.Label label2;
        private SDUI.Controls.Label lblNumTradesCompleted;
        private SDUI.Controls.Separator separator3;
        private SDUI.Controls.Label label9;
        private SDUI.Controls.Label label8;
        private SDUI.Controls.Label label7;
        private SDUI.Controls.Label lblJobExp;
        private SDUI.Controls.Label lblJobLevel;
        private SDUI.Controls.Label lblJobAlias;
        private System.Windows.Forms.ToolStripMenuItem executeHereToolStripMenuItem;
    }
}
