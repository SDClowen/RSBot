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
            this.contextMenuRouteList = new SDUI.Controls.ContextMenuStrip();
            this.addScriptToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuRecordScript = new System.Windows.Forms.ToolStripMenuItem();
            this.menuChooseScript = new System.Windows.Forms.ToolStripMenuItem();
            this.menuRemoveScript = new System.Windows.Forms.ToolStripMenuItem();
            this.lblHint = new SDUI.Controls.Label();
            this.tabControl1 = new SDUI.Controls.TabControl();
            this.tabPageRoute = new System.Windows.Forms.TabPage();
            this.txtTracePlayerName = new SDUI.Controls.TextBox();
            this.radioUseRouteList = new SDUI.Controls.Radio();
            this.radioTracePlayer = new SDUI.Controls.Radio();
            this.buttonDeleteList = new SDUI.Controls.Button();
            this.buttonCreateList = new SDUI.Controls.Button();
            this.comboRouteList = new SDUI.Controls.ComboBox();
            this.linkRecord = new System.Windows.Forms.LinkLabel();
            this.lvRouteList = new SDUI.Controls.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.panel1 = new SDUI.Controls.Panel();
            this.checkWaitForHunter = new SDUI.Controls.CheckBox();
            this.checkRunTownscript = new SDUI.Controls.CheckBox();
            this.tabPageSettings = new System.Windows.Forms.TabPage();
            this.groupBox1 = new SDUI.Controls.GroupBox();
            this.checkSellGoods = new SDUI.Controls.CheckBox();
            this.separator2 = new SDUI.Controls.Separator();
            this.lblNumGoodsDesc = new SDUI.Controls.Label();
            this.lblGoods = new SDUI.Controls.Label();
            this.numAmountGoods = new SDUI.Controls.NumUpDown();
            this.checkBuyGoods = new SDUI.Controls.CheckBox();
            this.groupBox2 = new SDUI.Controls.GroupBox();
            this.checkProtectTransport = new SDUI.Controls.CheckBox();
            this.checkCastBuffsWhileFighting = new SDUI.Controls.CheckBox();
            this.checkCastBuffsWhileWalking = new SDUI.Controls.CheckBox();
            this.separator1 = new SDUI.Controls.Separator();
            this.checkCounterAttack = new SDUI.Controls.CheckBox();
            this.checkAttackThiefNpc = new SDUI.Controls.CheckBox();
            this.checkAttackThiefPlayers = new SDUI.Controls.CheckBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lblJobExp = new SDUI.Controls.Label();
            this.lblJobLevel = new SDUI.Controls.Label();
            this.lblJobAlias = new SDUI.Controls.Label();
            this.label9 = new SDUI.Controls.Label();
            this.label8 = new SDUI.Controls.Label();
            this.label7 = new SDUI.Controls.Label();
            this.separator3 = new SDUI.Controls.Separator();
            this.label6 = new SDUI.Controls.Label();
            this.label5 = new SDUI.Controls.Label();
            this.label4 = new SDUI.Controls.Label();
            this.lblTradeScale = new SDUI.Controls.Label();
            this.label2 = new SDUI.Controls.Label();
            this.label1 = new SDUI.Controls.Label();
            this.contextMenuRouteList.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPageRoute.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabPageSettings.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAmountGoods)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuRouteList
            // 
            this.contextMenuRouteList.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuRouteList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addScriptToolStripMenuItem,
            this.menuRemoveScript});
            this.contextMenuRouteList.Name = "contextMenuStrip1";
            this.contextMenuRouteList.Size = new System.Drawing.Size(129, 48);
            // 
            // addScriptToolStripMenuItem
            // 
            this.addScriptToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuRecordScript,
            this.menuChooseScript});
            this.addScriptToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.addScriptToolStripMenuItem.Name = "addScriptToolStripMenuItem";
            this.addScriptToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.addScriptToolStripMenuItem.Text = "Add script";
            // 
            // menuRecordScript
            // 
            this.menuRecordScript.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.menuRecordScript.Name = "menuRecordScript";
            this.menuRecordScript.Size = new System.Drawing.Size(142, 22);
            this.menuRecordScript.Text = "Record";
            // 
            // menuChooseScript
            // 
            this.menuChooseScript.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.menuChooseScript.Name = "menuChooseScript";
            this.menuChooseScript.Size = new System.Drawing.Size(142, 22);
            this.menuChooseScript.Text = "Choose file...";
            this.menuChooseScript.Click += new System.EventHandler(this.menuChooseScript_Click);
            // 
            // menuRemoveScript
            // 
            this.menuRemoveScript.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.menuRemoveScript.Name = "menuRemoveScript";
            this.menuRemoveScript.Size = new System.Drawing.Size(128, 22);
            this.menuRemoveScript.Text = "Remove";
            this.menuRemoveScript.Click += new System.EventHandler(this.menuRemoveScript_Click);
            // 
            // lblHint
            // 
            this.lblHint.AutoSize = true;
            this.lblHint.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.lblHint.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblHint.Location = new System.Drawing.Point(2, 374);
            this.lblHint.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblHint.Name = "lblHint";
            this.lblHint.Size = new System.Drawing.Size(321, 15);
            this.lblHint.TabIndex = 7;
            this.lblHint.Text = "Hint: Automatic teleportation is not supported in trace mode";
            // 
            // tabControl1
            // 
            this.tabControl1.Border = new System.Windows.Forms.Padding(1);
            this.tabControl1.Controls.Add(this.tabPageRoute);
            this.tabControl1.Controls.Add(this.tabPageSettings);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.HideTabArea = false;
            this.tabControl1.Location = new System.Drawing.Point(2, 2);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(787, 370);
            this.tabControl1.TabIndex = 8;
            // 
            // tabPageRoute
            // 
            this.tabPageRoute.BackColor = System.Drawing.Color.White;
            this.tabPageRoute.Controls.Add(this.txtTracePlayerName);
            this.tabPageRoute.Controls.Add(this.radioUseRouteList);
            this.tabPageRoute.Controls.Add(this.radioTracePlayer);
            this.tabPageRoute.Controls.Add(this.buttonDeleteList);
            this.tabPageRoute.Controls.Add(this.buttonCreateList);
            this.tabPageRoute.Controls.Add(this.comboRouteList);
            this.tabPageRoute.Controls.Add(this.linkRecord);
            this.tabPageRoute.Controls.Add(this.lvRouteList);
            this.tabPageRoute.Controls.Add(this.panel1);
            this.tabPageRoute.Location = new System.Drawing.Point(4, 25);
            this.tabPageRoute.Margin = new System.Windows.Forms.Padding(2);
            this.tabPageRoute.Name = "tabPageRoute";
            this.tabPageRoute.Padding = new System.Windows.Forms.Padding(2);
            this.tabPageRoute.Size = new System.Drawing.Size(779, 341);
            this.tabPageRoute.TabIndex = 0;
            this.tabPageRoute.Text = "Route";
            // 
            // txtTracePlayerName
            // 
            this.txtTracePlayerName.Location = new System.Drawing.Point(109, 14);
            this.txtTracePlayerName.Margin = new System.Windows.Forms.Padding(2);
            this.txtTracePlayerName.MaxLength = 32767;
            this.txtTracePlayerName.MultiLine = false;
            this.txtTracePlayerName.Name = "txtTracePlayerName";
            this.txtTracePlayerName.Radius = 2;
            this.txtTracePlayerName.Size = new System.Drawing.Size(121, 21);
            this.txtTracePlayerName.TabIndex = 24;
            this.txtTracePlayerName.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtTracePlayerName.UseSystemPasswordChar = false;
            this.txtTracePlayerName.TextChanged += new System.EventHandler(this.txtTracePlayerName_TextChanged);
            // 
            // radioUseRouteList
            // 
            this.radioUseRouteList.AutoSize = true;
            this.radioUseRouteList.Checked = true;
            this.radioUseRouteList.Location = new System.Drawing.Point(9, 46);
            this.radioUseRouteList.Margin = new System.Windows.Forms.Padding(2);
            this.radioUseRouteList.Name = "radioUseRouteList";
            this.radioUseRouteList.ShadowDepth = 0;
            this.radioUseRouteList.Size = new System.Drawing.Size(100, 15);
            this.radioUseRouteList.TabIndex = 23;
            this.radioUseRouteList.TabStop = true;
            this.radioUseRouteList.Text = "Use route list";
            this.radioUseRouteList.UseVisualStyleBackColor = true;
            this.radioUseRouteList.CheckedChanged += new System.EventHandler(this.radioSetting_CheckedChanged);
            // 
            // radioTracePlayer
            // 
            this.radioTracePlayer.AutoSize = true;
            this.radioTracePlayer.Location = new System.Drawing.Point(9, 14);
            this.radioTracePlayer.Margin = new System.Windows.Forms.Padding(2);
            this.radioTracePlayer.Name = "radioTracePlayer";
            this.radioTracePlayer.ShadowDepth = 0;
            this.radioTracePlayer.Size = new System.Drawing.Size(94, 15);
            this.radioTracePlayer.TabIndex = 22;
            this.radioTracePlayer.Text = "Trace player";
            this.radioTracePlayer.UseVisualStyleBackColor = true;
            this.radioTracePlayer.CheckedChanged += new System.EventHandler(this.radioSetting_CheckedChanged);
            // 
            // buttonDeleteList
            // 
            this.buttonDeleteList.Color = System.Drawing.Color.IndianRed;
            this.buttonDeleteList.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonDeleteList.ForeColor = System.Drawing.Color.White;
            this.buttonDeleteList.Location = new System.Drawing.Point(234, 42);
            this.buttonDeleteList.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.buttonDeleteList.Name = "buttonDeleteList";
            this.buttonDeleteList.Radius = 6;
            this.buttonDeleteList.ShadowDepth = 4F;
            this.buttonDeleteList.Size = new System.Drawing.Size(22, 26);
            this.buttonDeleteList.TabIndex = 20;
            this.buttonDeleteList.Text = "x";
            this.buttonDeleteList.UseVisualStyleBackColor = true;
            this.buttonDeleteList.Click += new System.EventHandler(this.buttonDeleteList_Click);
            // 
            // buttonCreateList
            // 
            this.buttonCreateList.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.buttonCreateList.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonCreateList.ForeColor = System.Drawing.Color.White;
            this.buttonCreateList.Location = new System.Drawing.Point(257, 42);
            this.buttonCreateList.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.buttonCreateList.Name = "buttonCreateList";
            this.buttonCreateList.Radius = 6;
            this.buttonCreateList.ShadowDepth = 4F;
            this.buttonCreateList.Size = new System.Drawing.Size(22, 26);
            this.buttonCreateList.TabIndex = 21;
            this.buttonCreateList.Text = "+";
            this.buttonCreateList.UseVisualStyleBackColor = true;
            this.buttonCreateList.Click += new System.EventHandler(this.buttonCreateList_Click);
            // 
            // comboRouteList
            // 
            this.comboRouteList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboRouteList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboRouteList.FormattingEnabled = true;
            this.comboRouteList.Items.AddRange(new object[] {
            "Default"});
            this.comboRouteList.Location = new System.Drawing.Point(108, 43);
            this.comboRouteList.Margin = new System.Windows.Forms.Padding(2);
            this.comboRouteList.Name = "comboRouteList";
            this.comboRouteList.Radius = 5;
            this.comboRouteList.ShadowDepth = 4F;
            this.comboRouteList.Size = new System.Drawing.Size(122, 24);
            this.comboRouteList.TabIndex = 19;
            this.comboRouteList.SelectedIndexChanged += new System.EventHandler(this.comboRouteList_SelectedIndexChanged);
            // 
            // linkRecord
            // 
            this.linkRecord.AutoSize = true;
            this.linkRecord.Location = new System.Drawing.Point(718, 46);
            this.linkRecord.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.linkRecord.Name = "linkRecord";
            this.linkRecord.Size = new System.Drawing.Size(52, 15);
            this.linkRecord.TabIndex = 16;
            this.linkRecord.TabStop = true;
            this.linkRecord.Text = "[Record]";
            // 
            // lvRouteList
            // 
            this.lvRouteList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader4,
            this.columnHeader3});
            this.lvRouteList.ContextMenuStrip = this.contextMenuRouteList;
            this.lvRouteList.FullRowSelect = true;
            this.lvRouteList.Location = new System.Drawing.Point(9, 84);
            this.lvRouteList.Margin = new System.Windows.Forms.Padding(2);
            this.lvRouteList.Name = "lvRouteList";
            this.lvRouteList.Size = new System.Drawing.Size(762, 207);
            this.lvRouteList.TabIndex = 1;
            this.lvRouteList.UseCompatibleStateImageBehavior = false;
            this.lvRouteList.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 150;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Start region";
            this.columnHeader2.Width = 200;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "End region";
            this.columnHeader4.Width = 200;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Num. Steps";
            this.columnHeader3.Width = 150;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Border = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.panel1.BorderColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.checkWaitForHunter);
            this.panel1.Controls.Add(this.checkRunTownscript);
            this.panel1.Location = new System.Drawing.Point(7, 285);
            this.panel1.Name = "panel1";
            this.panel1.Radius = 10;
            this.panel1.ShadowDepth = 4F;
            this.panel1.Size = new System.Drawing.Size(766, 42);
            this.panel1.TabIndex = 29;
            // 
            // checkWaitForHunter
            // 
            this.checkWaitForHunter.AutoSize = true;
            this.checkWaitForHunter.BackColor = System.Drawing.Color.Transparent;
            this.checkWaitForHunter.Location = new System.Drawing.Point(263, 15);
            this.checkWaitForHunter.Margin = new System.Windows.Forms.Padding(2);
            this.checkWaitForHunter.Name = "checkWaitForHunter";
            this.checkWaitForHunter.ShadowDepth = 1;
            this.checkWaitForHunter.Size = new System.Drawing.Size(151, 15);
            this.checkWaitForHunter.TabIndex = 28;
            this.checkWaitForHunter.Text = "Wait for a hunter nearby";
            this.checkWaitForHunter.UseVisualStyleBackColor = false;
            this.checkWaitForHunter.CheckedChanged += new System.EventHandler(this.checkBoxSetting_CheckedChanged);
            // 
            // checkRunTownscript
            // 
            this.checkRunTownscript.AutoSize = true;
            this.checkRunTownscript.BackColor = System.Drawing.Color.Transparent;
            this.checkRunTownscript.Location = new System.Drawing.Point(17, 15);
            this.checkRunTownscript.Margin = new System.Windows.Forms.Padding(2);
            this.checkRunTownscript.Name = "checkRunTownscript";
            this.checkRunTownscript.ShadowDepth = 1;
            this.checkRunTownscript.Size = new System.Drawing.Size(206, 15);
            this.checkRunTownscript.TabIndex = 27;
            this.checkRunTownscript.Text = "Run townscript after route finished";
            this.checkRunTownscript.UseVisualStyleBackColor = false;
            this.checkRunTownscript.CheckedChanged += new System.EventHandler(this.checkBoxSetting_CheckedChanged);
            // 
            // tabPageSettings
            // 
            this.tabPageSettings.BackColor = System.Drawing.Color.White;
            this.tabPageSettings.Controls.Add(this.groupBox1);
            this.tabPageSettings.Controls.Add(this.groupBox2);
            this.tabPageSettings.Location = new System.Drawing.Point(4, 25);
            this.tabPageSettings.Margin = new System.Windows.Forms.Padding(2);
            this.tabPageSettings.Name = "tabPageSettings";
            this.tabPageSettings.Padding = new System.Windows.Forms.Padding(2);
            this.tabPageSettings.Size = new System.Drawing.Size(779, 341);
            this.tabPageSettings.TabIndex = 1;
            this.tabPageSettings.Text = "Settings";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.checkSellGoods);
            this.groupBox1.Controls.Add(this.separator2);
            this.groupBox1.Controls.Add(this.lblNumGoodsDesc);
            this.groupBox1.Controls.Add(this.lblGoods);
            this.groupBox1.Controls.Add(this.numAmountGoods);
            this.groupBox1.Controls.Add(this.checkBuyGoods);
            this.groupBox1.Location = new System.Drawing.Point(305, 14);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 8, 3, 3);
            this.groupBox1.Radius = 10;
            this.groupBox1.ShadowDepth = 4;
            this.groupBox1.Size = new System.Drawing.Size(304, 140);
            this.groupBox1.TabIndex = 28;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Buy / Sell";
            // 
            // checkSellGoods
            // 
            this.checkSellGoods.AutoSize = true;
            this.checkSellGoods.BackColor = System.Drawing.Color.Transparent;
            this.checkSellGoods.Location = new System.Drawing.Point(15, 105);
            this.checkSellGoods.Name = "checkSellGoods";
            this.checkSellGoods.ShadowDepth = 1;
            this.checkSellGoods.Size = new System.Drawing.Size(77, 15);
            this.checkSellGoods.TabIndex = 5;
            this.checkSellGoods.Text = "Sell goods";
            this.checkSellGoods.UseVisualStyleBackColor = false;
            this.checkSellGoods.CheckedChanged += new System.EventHandler(this.checkBoxSetting_CheckedChanged);
            // 
            // separator2
            // 
            this.separator2.IsVertical = false;
            this.separator2.Location = new System.Drawing.Point(15, 84);
            this.separator2.Margin = new System.Windows.Forms.Padding(2);
            this.separator2.Name = "separator2";
            this.separator2.Size = new System.Drawing.Size(234, 12);
            this.separator2.TabIndex = 4;
            this.separator2.Text = "separator2";
            // 
            // lblNumGoodsDesc
            // 
            this.lblNumGoodsDesc.AutoSize = true;
            this.lblNumGoodsDesc.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblNumGoodsDesc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblNumGoodsDesc.Location = new System.Drawing.Point(66, 61);
            this.lblNumGoodsDesc.Name = "lblNumGoodsDesc";
            this.lblNumGoodsDesc.Size = new System.Drawing.Size(96, 13);
            this.lblNumGoodsDesc.TabIndex = 3;
            this.lblNumGoodsDesc.Text = "0 = max. possible";
            // 
            // lblGoods
            // 
            this.lblGoods.AutoSize = true;
            this.lblGoods.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblGoods.Location = new System.Drawing.Point(193, 37);
            this.lblGoods.Name = "lblGoods";
            this.lblGoods.Size = new System.Drawing.Size(103, 15);
            this.lblGoods.TabIndex = 2;
            this.lblGoods.Text = "x Speciality Goods";
            // 
            // numAmountGoods
            // 
            this.numAmountGoods.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.numAmountGoods.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numAmountGoods.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.numAmountGoods.Location = new System.Drawing.Point(67, 34);
            this.numAmountGoods.Name = "numAmountGoods";
            this.numAmountGoods.Size = new System.Drawing.Size(120, 23);
            this.numAmountGoods.TabIndex = 1;
            this.numAmountGoods.ValueChanged += new System.EventHandler(this.numAmountGoods_ValueChanged);
            // 
            // checkBuyGoods
            // 
            this.checkBuyGoods.AutoSize = true;
            this.checkBuyGoods.BackColor = System.Drawing.Color.Transparent;
            this.checkBuyGoods.Location = new System.Drawing.Point(15, 37);
            this.checkBuyGoods.Name = "checkBuyGoods";
            this.checkBuyGoods.ShadowDepth = 1;
            this.checkBuyGoods.Size = new System.Drawing.Size(46, 15);
            this.checkBuyGoods.TabIndex = 0;
            this.checkBuyGoods.Text = "Buy ";
            this.checkBuyGoods.UseVisualStyleBackColor = false;
            this.checkBuyGoods.CheckedChanged += new System.EventHandler(this.checkBoxSetting_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.checkProtectTransport);
            this.groupBox2.Controls.Add(this.checkCastBuffsWhileFighting);
            this.groupBox2.Controls.Add(this.checkCastBuffsWhileWalking);
            this.groupBox2.Controls.Add(this.separator1);
            this.groupBox2.Controls.Add(this.checkCounterAttack);
            this.groupBox2.Controls.Add(this.checkAttackThiefNpc);
            this.groupBox2.Controls.Add(this.checkAttackThiefPlayers);
            this.groupBox2.Location = new System.Drawing.Point(13, 14);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2, 6, 2, 2);
            this.groupBox2.Radius = 10;
            this.groupBox2.ShadowDepth = 4;
            this.groupBox2.Size = new System.Drawing.Size(246, 214);
            this.groupBox2.TabIndex = 27;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Attacking / buffing";
            // 
            // checkProtectTransport
            // 
            this.checkProtectTransport.AutoSize = true;
            this.checkProtectTransport.BackColor = System.Drawing.Color.Transparent;
            this.checkProtectTransport.Location = new System.Drawing.Point(15, 105);
            this.checkProtectTransport.Margin = new System.Windows.Forms.Padding(2);
            this.checkProtectTransport.Name = "checkProtectTransport";
            this.checkProtectTransport.ShadowDepth = 1;
            this.checkProtectTransport.Size = new System.Drawing.Size(112, 15);
            this.checkProtectTransport.TabIndex = 6;
            this.checkProtectTransport.Text = "Protect transport";
            this.checkProtectTransport.UseVisualStyleBackColor = false;
            this.checkProtectTransport.CheckedChanged += new System.EventHandler(this.checkBoxSetting_CheckedChanged);
            // 
            // checkCastBuffsWhileFighting
            // 
            this.checkCastBuffsWhileFighting.AutoSize = true;
            this.checkCastBuffsWhileFighting.BackColor = System.Drawing.Color.Transparent;
            this.checkCastBuffsWhileFighting.Location = new System.Drawing.Point(15, 169);
            this.checkCastBuffsWhileFighting.Margin = new System.Windows.Forms.Padding(2);
            this.checkCastBuffsWhileFighting.Name = "checkCastBuffsWhileFighting";
            this.checkCastBuffsWhileFighting.ShadowDepth = 1;
            this.checkCastBuffsWhileFighting.Size = new System.Drawing.Size(152, 15);
            this.checkCastBuffsWhileFighting.TabIndex = 5;
            this.checkCastBuffsWhileFighting.Text = "Cast buffs while fighting";
            this.checkCastBuffsWhileFighting.UseVisualStyleBackColor = false;
            this.checkCastBuffsWhileFighting.CheckedChanged += new System.EventHandler(this.checkBoxSetting_CheckedChanged);
            // 
            // checkCastBuffsWhileWalking
            // 
            this.checkCastBuffsWhileWalking.AutoSize = true;
            this.checkCastBuffsWhileWalking.BackColor = System.Drawing.Color.Transparent;
            this.checkCastBuffsWhileWalking.Location = new System.Drawing.Point(15, 147);
            this.checkCastBuffsWhileWalking.Margin = new System.Windows.Forms.Padding(2);
            this.checkCastBuffsWhileWalking.Name = "checkCastBuffsWhileWalking";
            this.checkCastBuffsWhileWalking.ShadowDepth = 1;
            this.checkCastBuffsWhileWalking.Size = new System.Drawing.Size(151, 15);
            this.checkCastBuffsWhileWalking.TabIndex = 4;
            this.checkCastBuffsWhileWalking.Text = "Cast buffs while walking";
            this.checkCastBuffsWhileWalking.UseVisualStyleBackColor = false;
            this.checkCastBuffsWhileWalking.CheckedChanged += new System.EventHandler(this.checkBoxSetting_CheckedChanged);
            // 
            // separator1
            // 
            this.separator1.IsVertical = false;
            this.separator1.Location = new System.Drawing.Point(6, 128);
            this.separator1.Margin = new System.Windows.Forms.Padding(2);
            this.separator1.Name = "separator1";
            this.separator1.Size = new System.Drawing.Size(234, 12);
            this.separator1.TabIndex = 3;
            this.separator1.Text = "separator1";
            // 
            // checkCounterAttack
            // 
            this.checkCounterAttack.AutoSize = true;
            this.checkCounterAttack.BackColor = System.Drawing.Color.Transparent;
            this.checkCounterAttack.Location = new System.Drawing.Point(15, 81);
            this.checkCounterAttack.Margin = new System.Windows.Forms.Padding(2);
            this.checkCounterAttack.Name = "checkCounterAttack";
            this.checkCounterAttack.ShadowDepth = 1;
            this.checkCounterAttack.Size = new System.Drawing.Size(101, 15);
            this.checkCounterAttack.TabIndex = 2;
            this.checkCounterAttack.Text = "Counter attack";
            this.checkCounterAttack.UseVisualStyleBackColor = false;
            this.checkCounterAttack.CheckedChanged += new System.EventHandler(this.checkBoxSetting_CheckedChanged);
            // 
            // checkAttackThiefNpc
            // 
            this.checkAttackThiefNpc.AutoSize = true;
            this.checkAttackThiefNpc.BackColor = System.Drawing.Color.Transparent;
            this.checkAttackThiefNpc.Location = new System.Drawing.Point(15, 58);
            this.checkAttackThiefNpc.Margin = new System.Windows.Forms.Padding(2);
            this.checkAttackThiefNpc.Name = "checkAttackThiefNpc";
            this.checkAttackThiefNpc.ShadowDepth = 1;
            this.checkAttackThiefNpc.Size = new System.Drawing.Size(116, 15);
            this.checkAttackThiefNpc.TabIndex = 1;
            this.checkAttackThiefNpc.Text = "Attack thief NPCs";
            this.checkAttackThiefNpc.UseVisualStyleBackColor = false;
            this.checkAttackThiefNpc.CheckedChanged += new System.EventHandler(this.checkBoxSetting_CheckedChanged);
            // 
            // checkAttackThiefPlayers
            // 
            this.checkAttackThiefPlayers.AutoSize = true;
            this.checkAttackThiefPlayers.BackColor = System.Drawing.Color.Transparent;
            this.checkAttackThiefPlayers.Location = new System.Drawing.Point(15, 36);
            this.checkAttackThiefPlayers.Margin = new System.Windows.Forms.Padding(2);
            this.checkAttackThiefPlayers.Name = "checkAttackThiefPlayers";
            this.checkAttackThiefPlayers.ShadowDepth = 1;
            this.checkAttackThiefPlayers.Size = new System.Drawing.Size(124, 15);
            this.checkAttackThiefPlayers.TabIndex = 0;
            this.checkAttackThiefPlayers.Text = "Attack thief players";
            this.checkAttackThiefPlayers.UseVisualStyleBackColor = false;
            this.checkAttackThiefPlayers.CheckedChanged += new System.EventHandler(this.checkBoxSetting_CheckedChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.White;
            this.tabPage1.Controls.Add(this.lblJobExp);
            this.tabPage1.Controls.Add(this.lblJobLevel);
            this.tabPage1.Controls.Add(this.lblJobAlias);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.separator3);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.lblTradeScale);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(779, 341);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "Trade overview";
            // 
            // lblJobExp
            // 
            this.lblJobExp.AutoSize = true;
            this.lblJobExp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblJobExp.Location = new System.Drawing.Point(144, 245);
            this.lblJobExp.Name = "lblJobExp";
            this.lblJobExp.Size = new System.Drawing.Size(13, 15);
            this.lblJobExp.TabIndex = 11;
            this.lblJobExp.Text = "0";
            // 
            // lblJobLevel
            // 
            this.lblJobLevel.AutoSize = true;
            this.lblJobLevel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblJobLevel.Location = new System.Drawing.Point(144, 209);
            this.lblJobLevel.Name = "lblJobLevel";
            this.lblJobLevel.Size = new System.Drawing.Size(13, 15);
            this.lblJobLevel.TabIndex = 10;
            this.lblJobLevel.Text = "0";
            // 
            // lblJobAlias
            // 
            this.lblJobAlias.AutoSize = true;
            this.lblJobAlias.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblJobAlias.Location = new System.Drawing.Point(144, 172);
            this.lblJobAlias.Name = "lblJobAlias";
            this.lblJobAlias.Size = new System.Drawing.Size(50, 15);
            this.lblJobAlias.TabIndex = 9;
            this.lblJobAlias.Text = "<none>";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label9.Location = new System.Drawing.Point(108, 245);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(30, 15);
            this.label9.TabIndex = 8;
            this.label9.Text = "EXP:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label8.Location = new System.Drawing.Point(84, 172);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 15);
            this.label8.TabIndex = 7;
            this.label8.Text = "Job alias:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label7.Location = new System.Drawing.Point(101, 209);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 15);
            this.label7.TabIndex = 7;
            this.label7.Text = "Level:";
            // 
            // separator3
            // 
            this.separator3.IsVertical = false;
            this.separator3.Location = new System.Drawing.Point(35, 149);
            this.separator3.Name = "separator3";
            this.separator3.Size = new System.Drawing.Size(365, 10);
            this.separator3.TabIndex = 6;
            this.separator3.Text = "separator3";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label6.Location = new System.Drawing.Point(144, 104);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(13, 15);
            this.label6.TabIndex = 5;
            this.label6.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label5.Location = new System.Drawing.Point(57, 104);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 15);
            this.label5.TabIndex = 4;
            this.label5.Text = "Current value:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label4.Location = new System.Drawing.Point(144, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(13, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "0";
            // 
            // lblTradeScale
            // 
            this.lblTradeScale.AutoSize = true;
            this.lblTradeScale.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTradeScale.Location = new System.Drawing.Point(144, 37);
            this.lblTradeScale.Name = "lblTradeScale";
            this.lblTradeScale.Size = new System.Drawing.Size(57, 15);
            this.lblTradeScale.TabIndex = 2;
            this.lblTradeScale.Text = "■■■■■";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(50, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Trade difficulty:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(35, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Trades completed:";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.lblHint);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Main";
            this.Size = new System.Drawing.Size(790, 408);
            this.contextMenuRouteList.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPageRoute.ResumeLayout(false);
            this.tabPageRoute.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabPageSettings.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAmountGoods)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private SDUI.Controls.CheckBox checkCastBuffsWhileFighting;
        private SDUI.Controls.CheckBox checkCastBuffsWhileWalking;
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
        private SDUI.Controls.Label label6;
        private SDUI.Controls.Label label5;
        private SDUI.Controls.Label label4;
        private SDUI.Controls.Label lblTradeScale;
        private SDUI.Controls.Label label2;
        private SDUI.Controls.Label label1;
        private SDUI.Controls.Separator separator3;
        private SDUI.Controls.Label label9;
        private SDUI.Controls.Label label8;
        private SDUI.Controls.Label label7;
        private SDUI.Controls.Label lblJobExp;
        private SDUI.Controls.Label lblJobLevel;
        private SDUI.Controls.Label lblJobAlias;
    }
}
