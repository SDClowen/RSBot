namespace RSBot.Items.Views
{
    partial class Main
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("Potion trader", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("Stable keeper", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup3 = new System.Windows.Forms.ListViewGroup("Protector trader", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup4 = new System.Windows.Forms.ListViewGroup("Weapon trader", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup5 = new System.Windows.Forms.ListViewGroup("Accessory trader", System.Windows.Forms.HorizontalAlignment.Left);
            this.contextShoppingList = new SDUI.Controls.ContextMenuStrip();
            this.menuChangeAmount = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuRemoveItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextAvailableProducts = new SDUI.Controls.ContextMenuStrip();
            this.menuAddToShoppingList = new System.Windows.Forms.ToolStripMenuItem();
            this.tabMain = new SDUI.Controls.TabControl();
            this.tabBuyFilter = new System.Windows.Forms.TabPage();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.listAvailableProducts = new SDUI.Controls.ListView();
            this.colAvailableName = new System.Windows.Forms.ColumnHeader();
            this.panel1 = new SDUI.Controls.Panel();
            this.label6 = new SDUI.Controls.Label();
            this.checkShowEquipment = new SDUI.Controls.CheckBox();
            this.txtShopSearch = new SDUI.Controls.TextBox();
            this.comboStore = new SDUI.Controls.ComboBox();
            this.label1 = new SDUI.Controls.Label();
            this.listShoppingList = new SDUI.Controls.ListView();
            this.colName = new System.Windows.Forms.ColumnHeader();
            this.colAmount = new System.Windows.Forms.ColumnHeader();
            this.panel2 = new SDUI.Controls.Panel();
            this.separator5 = new SDUI.Controls.Separator();
            this.groupBox1 = new SDUI.Controls.GroupBox();
            this.checkSellItemsFromPet = new SDUI.Controls.CheckBox();
            this.checkStoreItemsFromPet = new SDUI.Controls.CheckBox();
            this.checkRepairGear = new SDUI.Controls.CheckBox();
            this.checkEnable = new SDUI.Controls.CheckBox();
            this.tabSellFilter = new System.Windows.Forms.TabPage();
            this.listFilter = new SDUI.Controls.ListView();
            this.colItemName = new System.Windows.Forms.ColumnHeader();
            this.colItemLevel = new System.Windows.Forms.ColumnHeader();
            this.colGender = new System.Windows.Forms.ColumnHeader();
            this.colPickup = new System.Windows.Forms.ColumnHeader();
            this.colSell = new System.Windows.Forms.ColumnHeader();
            this.collStore = new System.Windows.Forms.ColumnHeader();
            this.contextList = new SDUI.Controls.ContextMenuStrip();
            this.btnAddToSell = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAddToStore = new System.Windows.Forms.ToolStripMenuItem();
            this.btnPickup = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnDontSell = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDontStore = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDontPickup = new System.Windows.Forms.ToolStripMenuItem();
            this.searchImageList = new System.Windows.Forms.ImageList(this.components);
            this.filterPanel = new SDUI.Controls.Panel();
            this.groupOthers = new SDUI.Controls.GroupBox();
            this.checkAlchemy = new SDUI.Controls.CheckBox();
            this.checkQuest = new SDUI.Controls.CheckBox();
            this.checkAmmo = new SDUI.Controls.CheckBox();
            this.checkCoin = new SDUI.Controls.CheckBox();
            this.checkOther = new SDUI.Controls.CheckBox();
            this.separator1 = new SDUI.Controls.Separator();
            this.groupWeapons = new SDUI.Controls.GroupBox();
            this.checkAxe = new SDUI.Controls.CheckBox();
            this.checkHarp = new SDUI.Controls.CheckBox();
            this.checkDagger = new SDUI.Controls.CheckBox();
            this.checkXBow = new SDUI.Controls.CheckBox();
            this.checkWRod = new SDUI.Controls.CheckBox();
            this.checkShield = new SDUI.Controls.CheckBox();
            this.checkCRod = new SDUI.Controls.CheckBox();
            this.check2HSword = new SDUI.Controls.CheckBox();
            this.check1HSword = new SDUI.Controls.CheckBox();
            this.checkStaff = new SDUI.Controls.CheckBox();
            this.checkBow = new SDUI.Controls.CheckBox();
            this.checkSpear = new SDUI.Controls.CheckBox();
            this.checkGlave = new SDUI.Controls.CheckBox();
            this.checkSword = new SDUI.Controls.CheckBox();
            this.checkBlade = new SDUI.Controls.CheckBox();
            this.separator2 = new SDUI.Controls.Separator();
            this.groupAccessories = new SDUI.Controls.GroupBox();
            this.checkNecklace = new SDUI.Controls.CheckBox();
            this.checkEarring = new SDUI.Controls.CheckBox();
            this.checkRing = new SDUI.Controls.CheckBox();
            this.separator3 = new SDUI.Controls.Separator();
            this.groupClothes = new SDUI.Controls.GroupBox();
            this.checkHand = new SDUI.Controls.CheckBox();
            this.checkLegs = new SDUI.Controls.CheckBox();
            this.checkHeavy = new SDUI.Controls.CheckBox();
            this.checkLight = new SDUI.Controls.CheckBox();
            this.checkClothes = new SDUI.Controls.CheckBox();
            this.checkBoot = new SDUI.Controls.CheckBox();
            this.checkChest = new SDUI.Controls.CheckBox();
            this.checkShoulder = new SDUI.Controls.CheckBox();
            this.checkHead = new SDUI.Controls.CheckBox();
            this.separator4 = new SDUI.Controls.Separator();
            this.groupGender = new SDUI.Controls.GroupBox();
            this.checkEuropean = new SDUI.Controls.CheckBox();
            this.checkChinese = new SDUI.Controls.CheckBox();
            this.checkFemale = new SDUI.Controls.CheckBox();
            this.checkBoxRareItems = new SDUI.Controls.CheckBox();
            this.checkMale = new SDUI.Controls.CheckBox();
            this.label3 = new SDUI.Controls.Label();
            this.numDegreeFrom = new SDUI.Controls.NumUpDown();
            this.numDegreeTo = new SDUI.Controls.NumUpDown();
            this.label4 = new SDUI.Controls.Label();
            this.panel3 = new SDUI.Controls.Panel();
            this.panel7 = new SDUI.Controls.Panel();
            this.labelResult = new SDUI.Controls.Label();
            this.btnResetFilter = new SDUI.Controls.Button();
            this.btnSearch = new SDUI.Controls.Button();
            this.btnReload = new SDUI.Controls.Button();
            this.txtSellSearch = new SDUI.Controls.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox7 = new SDUI.Controls.GroupBox();
            this.cbDontPickupWhileBotting = new SDUI.Controls.CheckBox();
            this.cbJustpickmyitems = new SDUI.Controls.CheckBox();
            this.checkDontPickupInBerzerk = new SDUI.Controls.CheckBox();
            this.checkEnableAbilityPet = new SDUI.Controls.CheckBox();
            this.checkPickupBlue = new SDUI.Controls.CheckBox();
            this.checkPickupRare = new SDUI.Controls.CheckBox();
            this.checkPickupGold = new SDUI.Controls.CheckBox();
            this.contextShoppingList.SuspendLayout();
            this.contextAvailableProducts.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.tabBuyFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabSellFilter.SuspendLayout();
            this.contextList.SuspendLayout();
            this.filterPanel.SuspendLayout();
            this.groupOthers.SuspendLayout();
            this.groupWeapons.SuspendLayout();
            this.groupAccessories.SuspendLayout();
            this.groupClothes.SuspendLayout();
            this.groupGender.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDegreeFrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDegreeTo)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabPage1.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextShoppingList
            // 
            this.contextShoppingList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuChangeAmount,
            this.toolStripSeparator1,
            this.menuRemoveItem});
            this.contextShoppingList.Name = "contextShoppingList";
            this.contextShoppingList.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.contextShoppingList.ShowImageMargin = false;
            this.contextShoppingList.Size = new System.Drawing.Size(136, 54);
            // 
            // menuChangeAmount
            // 
            this.menuChangeAmount.Name = "menuChangeAmount";
            this.menuChangeAmount.Size = new System.Drawing.Size(135, 22);
            this.menuChangeAmount.Text = "Change amount";
            this.menuChangeAmount.Click += new System.EventHandler(this.menuChangeAmount_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(132, 6);
            // 
            // menuRemoveItem
            // 
            this.menuRemoveItem.Name = "menuRemoveItem";
            this.menuRemoveItem.Size = new System.Drawing.Size(135, 22);
            this.menuRemoveItem.Text = "Remove";
            this.menuRemoveItem.Click += new System.EventHandler(this.menuRemoveItem_Click);
            // 
            // contextAvailableProducts
            // 
            this.contextAvailableProducts.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuAddToShoppingList});
            this.contextAvailableProducts.Name = "contextAvailableProducts";
            this.contextAvailableProducts.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.contextAvailableProducts.ShowImageMargin = false;
            this.contextAvailableProducts.Size = new System.Drawing.Size(157, 26);
            // 
            // menuAddToShoppingList
            // 
            this.menuAddToShoppingList.Name = "menuAddToShoppingList";
            this.menuAddToShoppingList.Size = new System.Drawing.Size(156, 22);
            this.menuAddToShoppingList.Text = "Add to shopping list";
            this.menuAddToShoppingList.Click += new System.EventHandler(this.menuAddToShoppingList_Click);
            // 
            // tabMain
            // 
            this.tabMain.Border = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.tabMain.Controls.Add(this.tabBuyFilter);
            this.tabMain.Controls.Add(this.tabSellFilter);
            this.tabMain.Controls.Add(this.tabPage1);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.HideTabArea = false;
            this.tabMain.Location = new System.Drawing.Point(0, 0);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(754, 473);
            this.tabMain.TabIndex = 7;
            // 
            // tabBuyFilter
            // 
            this.tabBuyFilter.BackColor = System.Drawing.Color.White;
            this.tabBuyFilter.Controls.Add(this.splitContainer);
            this.tabBuyFilter.Controls.Add(this.separator5);
            this.tabBuyFilter.Controls.Add(this.groupBox1);
            this.tabBuyFilter.Location = new System.Drawing.Point(4, 24);
            this.tabBuyFilter.Name = "tabBuyFilter";
            this.tabBuyFilter.Padding = new System.Windows.Forms.Padding(8);
            this.tabBuyFilter.Size = new System.Drawing.Size(746, 445);
            this.tabBuyFilter.TabIndex = 0;
            this.tabBuyFilter.Text = "Shopping";
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(8, 8);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.listAvailableProducts);
            this.splitContainer.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.listShoppingList);
            this.splitContainer.Panel2.Controls.Add(this.panel2);
            this.splitContainer.Size = new System.Drawing.Size(730, 359);
            this.splitContainer.SplitterDistance = 336;
            this.splitContainer.SplitterWidth = 1;
            this.splitContainer.TabIndex = 6;
            // 
            // listAvailableProducts
            // 
            this.listAvailableProducts.BackColor = System.Drawing.Color.White;
            this.listAvailableProducts.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listAvailableProducts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colAvailableName});
            this.listAvailableProducts.ContextMenuStrip = this.contextAvailableProducts;
            this.listAvailableProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listAvailableProducts.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.listAvailableProducts.FullRowSelect = true;
            this.listAvailableProducts.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listAvailableProducts.Location = new System.Drawing.Point(0, 57);
            this.listAvailableProducts.Name = "listAvailableProducts";
            this.listAvailableProducts.Size = new System.Drawing.Size(336, 302);
            this.listAvailableProducts.TabIndex = 4;
            this.listAvailableProducts.UseCompatibleStateImageBehavior = false;
            this.listAvailableProducts.View = System.Windows.Forms.View.Details;
            // 
            // colAvailableName
            // 
            this.colAvailableName.Text = "Name";
            this.colAvailableName.Width = 261;
            // 
            // panel1
            // 
            this.panel1.Border = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.panel1.BorderColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.checkShowEquipment);
            this.panel1.Controls.Add(this.txtShopSearch);
            this.panel1.Controls.Add(this.comboStore);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Radius = 0;
            this.panel1.Size = new System.Drawing.Size(336, 57);
            this.panel1.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label6.Location = new System.Drawing.Point(5, 32);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 15);
            this.label6.TabIndex = 10;
            this.label6.Text = "Search:";
            // 
            // checkShowEquipment
            // 
            this.checkShowEquipment.AutoSize = true;
            this.checkShowEquipment.BackColor = System.Drawing.Color.Transparent;
            this.checkShowEquipment.Checked = false;
            this.checkShowEquipment.Location = new System.Drawing.Point(211, 21);
            this.checkShowEquipment.Name = "checkShowEquipment";
            this.checkShowEquipment.Size = new System.Drawing.Size(113, 15);
            this.checkShowEquipment.TabIndex = 9;
            this.checkShowEquipment.Text = "Show equipment";
            this.checkShowEquipment.CheckedChanged += new System.EventHandler(this.checkShowEquipment_CheckedChanged);
            // 
            // txtShopSearch
            // 
            this.txtShopSearch.Location = new System.Drawing.Point(61, 29);
            this.txtShopSearch.MaxLength = 32767;
            this.txtShopSearch.MultiLine = false;
            this.txtShopSearch.Name = "txtShopSearch";
            this.txtShopSearch.Size = new System.Drawing.Size(144, 21);
            this.txtShopSearch.TabIndex = 8;
            this.txtShopSearch.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtShopSearch.UseSystemPasswordChar = false;
            this.txtShopSearch.TextChanged += new System.EventHandler(this.txtShopSearch_TextChanged);
            // 
            // comboStore
            // 
            this.comboStore.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboStore.DropDownHeight = 100;
            this.comboStore.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboStore.FormattingEnabled = true;
            this.comboStore.IntegralHeight = false;
            this.comboStore.ItemHeight = 17;
            this.comboStore.Items.AddRange(new object[] {
            "Potion trader",
            "Stable keeper",
            "Protector trader",
            "Weapon trader",
            "Accessory trader"});
            this.comboStore.Location = new System.Drawing.Point(61, 4);
            this.comboStore.Name = "comboStore";
            this.comboStore.Size = new System.Drawing.Size(144, 23);
            this.comboStore.TabIndex = 2;
            this.comboStore.SelectedIndexChanged += new System.EventHandler(this.comboStore_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(12, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "Store:";
            // 
            // listShoppingList
            // 
            this.listShoppingList.BackColor = System.Drawing.Color.White;
            this.listShoppingList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listShoppingList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colName,
            this.colAmount});
            this.listShoppingList.ContextMenuStrip = this.contextShoppingList;
            this.listShoppingList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listShoppingList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.listShoppingList.FullRowSelect = true;
            listViewGroup1.Header = "Potion trader";
            listViewGroup1.Name = "groupPotion";
            listViewGroup2.Header = "Stable keeper";
            listViewGroup2.Name = "groupStable";
            listViewGroup3.Header = "Protector trader";
            listViewGroup3.Name = "groupProtector";
            listViewGroup4.Header = "Weapon trader";
            listViewGroup4.Name = "groupWeapon";
            listViewGroup5.Header = "Accessory trader";
            listViewGroup5.Name = "groupAccessory";
            this.listShoppingList.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2,
            listViewGroup3,
            listViewGroup4,
            listViewGroup5});
            this.listShoppingList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listShoppingList.Location = new System.Drawing.Point(0, 57);
            this.listShoppingList.Name = "listShoppingList";
            this.listShoppingList.Size = new System.Drawing.Size(393, 302);
            this.listShoppingList.TabIndex = 3;
            this.listShoppingList.UseCompatibleStateImageBehavior = false;
            this.listShoppingList.View = System.Windows.Forms.View.Details;
            // 
            // colName
            // 
            this.colName.Text = "Name";
            this.colName.Width = 273;
            // 
            // colAmount
            // 
            this.colAmount.Text = "Amount";
            this.colAmount.Width = 95;
            // 
            // panel2
            // 
            this.panel2.Border = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.panel2.BorderColor = System.Drawing.Color.Transparent;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Radius = 0;
            this.panel2.Size = new System.Drawing.Size(393, 57);
            this.panel2.TabIndex = 7;
            // 
            // separator5
            // 
            this.separator5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.separator5.IsVertical = false;
            this.separator5.Location = new System.Drawing.Point(8, 367);
            this.separator5.Name = "separator5";
            this.separator5.Size = new System.Drawing.Size(730, 10);
            this.separator5.TabIndex = 9;
            this.separator5.Text = "separator5";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.checkSellItemsFromPet);
            this.groupBox1.Controls.Add(this.checkStoreItemsFromPet);
            this.groupBox1.Controls.Add(this.checkRepairGear);
            this.groupBox1.Controls.Add(this.checkEnable);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(8, 377);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.groupBox1.Radius = 2;
            this.groupBox1.Size = new System.Drawing.Size(730, 60);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "General setup";
            // 
            // checkSellItemsFromPet
            // 
            this.checkSellItemsFromPet.AutoSize = true;
            this.checkSellItemsFromPet.BackColor = System.Drawing.Color.Transparent;
            this.checkSellItemsFromPet.Checked = true;
            this.checkSellItemsFromPet.Location = new System.Drawing.Point(425, 33);
            this.checkSellItemsFromPet.Name = "checkSellItemsFromPet";
            this.checkSellItemsFromPet.Size = new System.Drawing.Size(122, 15);
            this.checkSellItemsFromPet.TabIndex = 3;
            this.checkSellItemsFromPet.Text = "Sell items from pet";
            this.checkSellItemsFromPet.CheckedChanged += new System.EventHandler(this.checkSellItemsFromPet_CheckedChanged);
            // 
            // checkStoreItemsFromPet
            // 
            this.checkStoreItemsFromPet.AutoSize = true;
            this.checkStoreItemsFromPet.BackColor = System.Drawing.Color.Transparent;
            this.checkStoreItemsFromPet.Checked = true;
            this.checkStoreItemsFromPet.Location = new System.Drawing.Point(567, 33);
            this.checkStoreItemsFromPet.Name = "checkStoreItemsFromPet";
            this.checkStoreItemsFromPet.Size = new System.Drawing.Size(131, 15);
            this.checkStoreItemsFromPet.TabIndex = 4;
            this.checkStoreItemsFromPet.Text = "Store items from pet";
            this.checkStoreItemsFromPet.CheckedChanged += new System.EventHandler(this.checkStoreItemsFromPet_CheckedChanged);
            // 
            // checkRepairGear
            // 
            this.checkRepairGear.AutoSize = true;
            this.checkRepairGear.BackColor = System.Drawing.Color.Transparent;
            this.checkRepairGear.Checked = true;
            this.checkRepairGear.Location = new System.Drawing.Point(231, 33);
            this.checkRepairGear.Name = "checkRepairGear";
            this.checkRepairGear.Size = new System.Drawing.Size(168, 15);
            this.checkRepairGear.TabIndex = 1;
            this.checkRepairGear.Text = "Automaticaly repair all gear";
            this.checkRepairGear.CheckedChanged += new System.EventHandler(this.checkRepairGear_CheckedChanged);
            // 
            // checkEnable
            // 
            this.checkEnable.AutoSize = true;
            this.checkEnable.BackColor = System.Drawing.Color.Transparent;
            this.checkEnable.Checked = true;
            this.checkEnable.Location = new System.Drawing.Point(13, 33);
            this.checkEnable.Name = "checkEnable";
            this.checkEnable.Size = new System.Drawing.Size(190, 15);
            this.checkEnable.TabIndex = 0;
            this.checkEnable.Text = "Automaticaly run when in town";
            this.checkEnable.CheckedChanged += new System.EventHandler(this.checkEnable_CheckedChanged);
            // 
            // tabSellFilter
            // 
            this.tabSellFilter.BackColor = System.Drawing.Color.White;
            this.tabSellFilter.Controls.Add(this.listFilter);
            this.tabSellFilter.Controls.Add(this.filterPanel);
            this.tabSellFilter.Controls.Add(this.panel3);
            this.tabSellFilter.Controls.Add(this.pictureBox1);
            this.tabSellFilter.Location = new System.Drawing.Point(4, 24);
            this.tabSellFilter.Name = "tabSellFilter";
            this.tabSellFilter.Size = new System.Drawing.Size(746, 445);
            this.tabSellFilter.TabIndex = 1;
            this.tabSellFilter.Text = "Item filter";
            // 
            // listFilter
            // 
            this.listFilter.BackColor = System.Drawing.Color.White;
            this.listFilter.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listFilter.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colItemName,
            this.colItemLevel,
            this.colGender,
            this.colPickup,
            this.colSell,
            this.collStore});
            this.listFilter.ContextMenuStrip = this.contextList;
            this.listFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listFilter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.listFilter.FullRowSelect = true;
            this.listFilter.Location = new System.Drawing.Point(265, 0);
            this.listFilter.Name = "listFilter";
            this.listFilter.Size = new System.Drawing.Size(481, 409);
            this.listFilter.SmallImageList = this.searchImageList;
            this.listFilter.TabIndex = 5;
            this.listFilter.UseCompatibleStateImageBehavior = false;
            this.listFilter.View = System.Windows.Forms.View.Details;
            this.listFilter.VirtualListSize = 15000;
            // 
            // colItemName
            // 
            this.colItemName.Text = "Name";
            this.colItemName.Width = 150;
            // 
            // colItemLevel
            // 
            this.colItemLevel.Text = "Level";
            this.colItemLevel.Width = 59;
            // 
            // colGender
            // 
            this.colGender.Text = "Gender";
            this.colGender.Width = 73;
            // 
            // colPickup
            // 
            this.colPickup.Text = "Pickup";
            // 
            // colSell
            // 
            this.colSell.Text = "Sell";
            // 
            // collStore
            // 
            this.collStore.Text = "Store";
            // 
            // contextList
            // 
            this.contextList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAddToSell,
            this.btnAddToStore,
            this.btnPickup,
            this.toolStripSeparator2,
            this.btnDontSell,
            this.btnDontStore,
            this.btnDontPickup});
            this.contextList.Name = "contextSellList";
            this.contextList.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.contextList.ShowImageMargin = false;
            this.contextList.Size = new System.Drawing.Size(118, 142);
            // 
            // btnAddToSell
            // 
            this.btnAddToSell.Name = "btnAddToSell";
            this.btnAddToSell.Size = new System.Drawing.Size(117, 22);
            this.btnAddToSell.Text = "Sell";
            this.btnAddToSell.Click += new System.EventHandler(this.btnAddToSell_Click);
            // 
            // btnAddToStore
            // 
            this.btnAddToStore.Name = "btnAddToStore";
            this.btnAddToStore.Size = new System.Drawing.Size(117, 22);
            this.btnAddToStore.Text = "Store";
            this.btnAddToStore.Click += new System.EventHandler(this.btnAddToStore_Click);
            // 
            // btnPickup
            // 
            this.btnPickup.Name = "btnPickup";
            this.btnPickup.Size = new System.Drawing.Size(117, 22);
            this.btnPickup.Text = "Pickup";
            this.btnPickup.Click += new System.EventHandler(this.btnPickup_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(114, 6);
            // 
            // btnDontSell
            // 
            this.btnDontSell.Name = "btnDontSell";
            this.btnDontSell.Size = new System.Drawing.Size(117, 22);
            this.btnDontSell.Text = "Don\'t sell";
            this.btnDontSell.Click += new System.EventHandler(this.btnDontSell_Click);
            // 
            // btnDontStore
            // 
            this.btnDontStore.Name = "btnDontStore";
            this.btnDontStore.Size = new System.Drawing.Size(117, 22);
            this.btnDontStore.Text = "Don\'t store";
            this.btnDontStore.Click += new System.EventHandler(this.btnDontStore_Click);
            // 
            // btnDontPickup
            // 
            this.btnDontPickup.Name = "btnDontPickup";
            this.btnDontPickup.Size = new System.Drawing.Size(117, 22);
            this.btnDontPickup.Text = "Don\'t pickup";
            this.btnDontPickup.Click += new System.EventHandler(this.btnDontPickup_Click);
            // 
            // searchImageList
            // 
            this.searchImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.searchImageList.ImageSize = new System.Drawing.Size(16, 16);
            this.searchImageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // filterPanel
            // 
            this.filterPanel.AutoScroll = true;
            this.filterPanel.AutoScrollMargin = new System.Drawing.Size(0, 10);
            this.filterPanel.AutoScrollMinSize = new System.Drawing.Size(0, 720);
            this.filterPanel.Border = new System.Windows.Forms.Padding(0, 0, 1, 0);
            this.filterPanel.BorderColor = System.Drawing.Color.Transparent;
            this.filterPanel.Controls.Add(this.groupOthers);
            this.filterPanel.Controls.Add(this.separator1);
            this.filterPanel.Controls.Add(this.groupWeapons);
            this.filterPanel.Controls.Add(this.separator2);
            this.filterPanel.Controls.Add(this.groupAccessories);
            this.filterPanel.Controls.Add(this.separator3);
            this.filterPanel.Controls.Add(this.groupClothes);
            this.filterPanel.Controls.Add(this.separator4);
            this.filterPanel.Controls.Add(this.groupGender);
            this.filterPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.filterPanel.Location = new System.Drawing.Point(0, 0);
            this.filterPanel.Name = "filterPanel";
            this.filterPanel.Padding = new System.Windows.Forms.Padding(12);
            this.filterPanel.Radius = 0;
            this.filterPanel.Size = new System.Drawing.Size(265, 409);
            this.filterPanel.TabIndex = 20;
            // 
            // groupOthers
            // 
            this.groupOthers.BackColor = System.Drawing.Color.Transparent;
            this.groupOthers.Controls.Add(this.checkAlchemy);
            this.groupOthers.Controls.Add(this.checkQuest);
            this.groupOthers.Controls.Add(this.checkAmmo);
            this.groupOthers.Controls.Add(this.checkCoin);
            this.groupOthers.Controls.Add(this.checkOther);
            this.groupOthers.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupOthers.Location = new System.Drawing.Point(12, 590);
            this.groupOthers.Name = "groupOthers";
            this.groupOthers.Padding = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.groupOthers.Radius = 2;
            this.groupOthers.Size = new System.Drawing.Size(224, 106);
            this.groupOthers.TabIndex = 42;
            this.groupOthers.TabStop = false;
            this.groupOthers.Text = "Others";
            // 
            // checkAlchemy
            // 
            this.checkAlchemy.AutoSize = true;
            this.checkAlchemy.BackColor = System.Drawing.Color.Transparent;
            this.checkAlchemy.Checked = false;
            this.checkAlchemy.Location = new System.Drawing.Point(99, 56);
            this.checkAlchemy.Name = "checkAlchemy";
            this.checkAlchemy.Size = new System.Drawing.Size(70, 15);
            this.checkAlchemy.TabIndex = 19;
            this.checkAlchemy.Text = "Alchemy";
            // 
            // checkQuest
            // 
            this.checkQuest.AutoSize = true;
            this.checkQuest.BackColor = System.Drawing.Color.Transparent;
            this.checkQuest.Checked = false;
            this.checkQuest.Location = new System.Drawing.Point(11, 33);
            this.checkQuest.Name = "checkQuest";
            this.checkQuest.Size = new System.Drawing.Size(54, 15);
            this.checkQuest.TabIndex = 19;
            this.checkQuest.Text = "Quest";
            // 
            // checkAmmo
            // 
            this.checkAmmo.AutoSize = true;
            this.checkAmmo.BackColor = System.Drawing.Color.Transparent;
            this.checkAmmo.Checked = false;
            this.checkAmmo.Location = new System.Drawing.Point(11, 56);
            this.checkAmmo.Name = "checkAmmo";
            this.checkAmmo.Size = new System.Drawing.Size(60, 15);
            this.checkAmmo.TabIndex = 19;
            this.checkAmmo.Text = "Ammo";
            // 
            // checkCoin
            // 
            this.checkCoin.AutoSize = true;
            this.checkCoin.BackColor = System.Drawing.Color.Transparent;
            this.checkCoin.Checked = false;
            this.checkCoin.Location = new System.Drawing.Point(99, 33);
            this.checkCoin.Name = "checkCoin";
            this.checkCoin.Size = new System.Drawing.Size(48, 15);
            this.checkCoin.TabIndex = 19;
            this.checkCoin.Text = "Coin";
            // 
            // checkOther
            // 
            this.checkOther.AutoSize = true;
            this.checkOther.BackColor = System.Drawing.Color.Transparent;
            this.checkOther.Checked = false;
            this.checkOther.Location = new System.Drawing.Point(11, 79);
            this.checkOther.Name = "checkOther";
            this.checkOther.Size = new System.Drawing.Size(53, 15);
            this.checkOther.TabIndex = 19;
            this.checkOther.Text = "Other";
            // 
            // separator1
            // 
            this.separator1.Dock = System.Windows.Forms.DockStyle.Top;
            this.separator1.IsVertical = false;
            this.separator1.Location = new System.Drawing.Point(12, 580);
            this.separator1.Name = "separator1";
            this.separator1.Size = new System.Drawing.Size(224, 10);
            this.separator1.TabIndex = 5;
            this.separator1.Text = "separator1";
            // 
            // groupWeapons
            // 
            this.groupWeapons.BackColor = System.Drawing.Color.Transparent;
            this.groupWeapons.Controls.Add(this.checkAxe);
            this.groupWeapons.Controls.Add(this.checkHarp);
            this.groupWeapons.Controls.Add(this.checkDagger);
            this.groupWeapons.Controls.Add(this.checkXBow);
            this.groupWeapons.Controls.Add(this.checkWRod);
            this.groupWeapons.Controls.Add(this.checkShield);
            this.groupWeapons.Controls.Add(this.checkCRod);
            this.groupWeapons.Controls.Add(this.check2HSword);
            this.groupWeapons.Controls.Add(this.check1HSword);
            this.groupWeapons.Controls.Add(this.checkStaff);
            this.groupWeapons.Controls.Add(this.checkBow);
            this.groupWeapons.Controls.Add(this.checkSpear);
            this.groupWeapons.Controls.Add(this.checkGlave);
            this.groupWeapons.Controls.Add(this.checkSword);
            this.groupWeapons.Controls.Add(this.checkBlade);
            this.groupWeapons.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupWeapons.Location = new System.Drawing.Point(12, 373);
            this.groupWeapons.Margin = new System.Windows.Forms.Padding(6);
            this.groupWeapons.Name = "groupWeapons";
            this.groupWeapons.Padding = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.groupWeapons.Radius = 2;
            this.groupWeapons.Size = new System.Drawing.Size(224, 207);
            this.groupWeapons.TabIndex = 40;
            this.groupWeapons.TabStop = false;
            this.groupWeapons.Text = "Weapons";
            // 
            // checkAxe
            // 
            this.checkAxe.AutoSize = true;
            this.checkAxe.BackColor = System.Drawing.Color.Transparent;
            this.checkAxe.Checked = false;
            this.checkAxe.Location = new System.Drawing.Point(99, 180);
            this.checkAxe.Name = "checkAxe";
            this.checkAxe.Size = new System.Drawing.Size(43, 15);
            this.checkAxe.TabIndex = 10;
            this.checkAxe.Text = "Axe";
            // 
            // checkHarp
            // 
            this.checkHarp.AutoSize = true;
            this.checkHarp.BackColor = System.Drawing.Color.Transparent;
            this.checkHarp.Checked = false;
            this.checkHarp.Location = new System.Drawing.Point(11, 180);
            this.checkHarp.Name = "checkHarp";
            this.checkHarp.Size = new System.Drawing.Size(49, 15);
            this.checkHarp.TabIndex = 10;
            this.checkHarp.Text = "Harp";
            // 
            // checkDagger
            // 
            this.checkDagger.AutoSize = true;
            this.checkDagger.BackColor = System.Drawing.Color.Transparent;
            this.checkDagger.Checked = false;
            this.checkDagger.Location = new System.Drawing.Point(99, 155);
            this.checkDagger.Name = "checkDagger";
            this.checkDagger.Size = new System.Drawing.Size(61, 15);
            this.checkDagger.TabIndex = 9;
            this.checkDagger.Text = "Dagger";
            // 
            // checkXBow
            // 
            this.checkXBow.AutoSize = true;
            this.checkXBow.BackColor = System.Drawing.Color.Transparent;
            this.checkXBow.Checked = false;
            this.checkXBow.Location = new System.Drawing.Point(11, 155);
            this.checkXBow.Name = "checkXBow";
            this.checkXBow.Size = new System.Drawing.Size(58, 15);
            this.checkXBow.TabIndex = 9;
            this.checkXBow.Text = "X-Bow";
            // 
            // checkWRod
            // 
            this.checkWRod.AutoSize = true;
            this.checkWRod.BackColor = System.Drawing.Color.Transparent;
            this.checkWRod.Checked = false;
            this.checkWRod.Location = new System.Drawing.Point(99, 130);
            this.checkWRod.Name = "checkWRod";
            this.checkWRod.Size = new System.Drawing.Size(60, 15);
            this.checkWRod.TabIndex = 8;
            this.checkWRod.Text = "W-Rod";
            // 
            // checkShield
            // 
            this.checkShield.AutoSize = true;
            this.checkShield.BackColor = System.Drawing.Color.Transparent;
            this.checkShield.Checked = false;
            this.checkShield.Location = new System.Drawing.Point(161, 180);
            this.checkShield.Name = "checkShield";
            this.checkShield.Size = new System.Drawing.Size(55, 15);
            this.checkShield.TabIndex = 5;
            this.checkShield.Text = "Shield";
            // 
            // checkCRod
            // 
            this.checkCRod.AutoSize = true;
            this.checkCRod.BackColor = System.Drawing.Color.Transparent;
            this.checkCRod.Checked = false;
            this.checkCRod.Location = new System.Drawing.Point(11, 130);
            this.checkCRod.Name = "checkCRod";
            this.checkCRod.Size = new System.Drawing.Size(57, 15);
            this.checkCRod.TabIndex = 7;
            this.checkCRod.Text = "C-Rod";
            // 
            // check2HSword
            // 
            this.check2HSword.AutoSize = true;
            this.check2HSword.BackColor = System.Drawing.Color.Transparent;
            this.check2HSword.Checked = false;
            this.check2HSword.Location = new System.Drawing.Point(99, 105);
            this.check2HSword.Name = "check2HSword";
            this.check2HSword.Size = new System.Drawing.Size(74, 15);
            this.check2HSword.TabIndex = 6;
            this.check2HSword.Text = "2H Sword";
            // 
            // check1HSword
            // 
            this.check1HSword.AutoSize = true;
            this.check1HSword.BackColor = System.Drawing.Color.Transparent;
            this.check1HSword.Checked = false;
            this.check1HSword.Location = new System.Drawing.Point(11, 105);
            this.check1HSword.Name = "check1HSword";
            this.check1HSword.Size = new System.Drawing.Size(74, 15);
            this.check1HSword.TabIndex = 5;
            this.check1HSword.Text = "1H Sword";
            // 
            // checkStaff
            // 
            this.checkStaff.AutoSize = true;
            this.checkStaff.BackColor = System.Drawing.Color.Transparent;
            this.checkStaff.Checked = false;
            this.checkStaff.Location = new System.Drawing.Point(99, 80);
            this.checkStaff.Name = "checkStaff";
            this.checkStaff.Size = new System.Drawing.Size(47, 15);
            this.checkStaff.TabIndex = 5;
            this.checkStaff.Text = "Staff";
            // 
            // checkBow
            // 
            this.checkBow.AutoSize = true;
            this.checkBow.BackColor = System.Drawing.Color.Transparent;
            this.checkBow.Checked = false;
            this.checkBow.Location = new System.Drawing.Point(11, 80);
            this.checkBow.Name = "checkBow";
            this.checkBow.Size = new System.Drawing.Size(46, 15);
            this.checkBow.TabIndex = 4;
            this.checkBow.Text = "Bow";
            // 
            // checkSpear
            // 
            this.checkSpear.AutoSize = true;
            this.checkSpear.BackColor = System.Drawing.Color.Transparent;
            this.checkSpear.Checked = false;
            this.checkSpear.Location = new System.Drawing.Point(99, 55);
            this.checkSpear.Name = "checkSpear";
            this.checkSpear.Size = new System.Drawing.Size(52, 15);
            this.checkSpear.TabIndex = 3;
            this.checkSpear.Text = "Spear";
            // 
            // checkGlave
            // 
            this.checkGlave.AutoSize = true;
            this.checkGlave.BackColor = System.Drawing.Color.Transparent;
            this.checkGlave.Checked = false;
            this.checkGlave.Location = new System.Drawing.Point(11, 55);
            this.checkGlave.Name = "checkGlave";
            this.checkGlave.Size = new System.Drawing.Size(52, 15);
            this.checkGlave.TabIndex = 2;
            this.checkGlave.Text = "Glave";
            // 
            // checkSword
            // 
            this.checkSword.AutoSize = true;
            this.checkSword.BackColor = System.Drawing.Color.Transparent;
            this.checkSword.Checked = false;
            this.checkSword.Location = new System.Drawing.Point(99, 30);
            this.checkSword.Name = "checkSword";
            this.checkSword.Size = new System.Drawing.Size(56, 15);
            this.checkSword.TabIndex = 1;
            this.checkSword.Text = "Sword";
            // 
            // checkBlade
            // 
            this.checkBlade.AutoSize = true;
            this.checkBlade.BackColor = System.Drawing.Color.Transparent;
            this.checkBlade.Checked = false;
            this.checkBlade.Location = new System.Drawing.Point(11, 30);
            this.checkBlade.Name = "checkBlade";
            this.checkBlade.Size = new System.Drawing.Size(52, 15);
            this.checkBlade.TabIndex = 0;
            this.checkBlade.Text = "Blade";
            // 
            // separator2
            // 
            this.separator2.Dock = System.Windows.Forms.DockStyle.Top;
            this.separator2.IsVertical = false;
            this.separator2.Location = new System.Drawing.Point(12, 363);
            this.separator2.Name = "separator2";
            this.separator2.Size = new System.Drawing.Size(224, 10);
            this.separator2.TabIndex = 45;
            this.separator2.Text = "separator2";
            // 
            // groupAccessories
            // 
            this.groupAccessories.BackColor = System.Drawing.Color.Transparent;
            this.groupAccessories.Controls.Add(this.checkNecklace);
            this.groupAccessories.Controls.Add(this.checkEarring);
            this.groupAccessories.Controls.Add(this.checkRing);
            this.groupAccessories.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupAccessories.Location = new System.Drawing.Point(12, 305);
            this.groupAccessories.Name = "groupAccessories";
            this.groupAccessories.Padding = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.groupAccessories.Radius = 2;
            this.groupAccessories.Size = new System.Drawing.Size(224, 58);
            this.groupAccessories.TabIndex = 44;
            this.groupAccessories.TabStop = false;
            this.groupAccessories.Text = "Accessories";
            // 
            // checkNecklace
            // 
            this.checkNecklace.AutoSize = true;
            this.checkNecklace.BackColor = System.Drawing.Color.Transparent;
            this.checkNecklace.Checked = false;
            this.checkNecklace.Location = new System.Drawing.Point(71, 30);
            this.checkNecklace.Name = "checkNecklace";
            this.checkNecklace.Size = new System.Drawing.Size(71, 15);
            this.checkNecklace.TabIndex = 4;
            this.checkNecklace.Text = "Necklace";
            // 
            // checkEarring
            // 
            this.checkEarring.AutoSize = true;
            this.checkEarring.BackColor = System.Drawing.Color.Transparent;
            this.checkEarring.Checked = false;
            this.checkEarring.Location = new System.Drawing.Point(157, 30);
            this.checkEarring.Name = "checkEarring";
            this.checkEarring.Size = new System.Drawing.Size(60, 15);
            this.checkEarring.TabIndex = 3;
            this.checkEarring.Text = "Earring";
            // 
            // checkRing
            // 
            this.checkRing.AutoSize = true;
            this.checkRing.BackColor = System.Drawing.Color.Transparent;
            this.checkRing.Checked = false;
            this.checkRing.Location = new System.Drawing.Point(11, 30);
            this.checkRing.Name = "checkRing";
            this.checkRing.Size = new System.Drawing.Size(47, 15);
            this.checkRing.TabIndex = 2;
            this.checkRing.Text = "Ring";
            // 
            // separator3
            // 
            this.separator3.Dock = System.Windows.Forms.DockStyle.Top;
            this.separator3.IsVertical = false;
            this.separator3.Location = new System.Drawing.Point(12, 295);
            this.separator3.Name = "separator3";
            this.separator3.Size = new System.Drawing.Size(224, 10);
            this.separator3.TabIndex = 46;
            this.separator3.Text = "separator3";
            // 
            // groupClothes
            // 
            this.groupClothes.BackColor = System.Drawing.Color.Transparent;
            this.groupClothes.Controls.Add(this.checkHand);
            this.groupClothes.Controls.Add(this.checkLegs);
            this.groupClothes.Controls.Add(this.checkHeavy);
            this.groupClothes.Controls.Add(this.checkLight);
            this.groupClothes.Controls.Add(this.checkClothes);
            this.groupClothes.Controls.Add(this.checkBoot);
            this.groupClothes.Controls.Add(this.checkChest);
            this.groupClothes.Controls.Add(this.checkShoulder);
            this.groupClothes.Controls.Add(this.checkHead);
            this.groupClothes.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupClothes.Location = new System.Drawing.Point(12, 160);
            this.groupClothes.Name = "groupClothes";
            this.groupClothes.Padding = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.groupClothes.Radius = 2;
            this.groupClothes.Size = new System.Drawing.Size(224, 135);
            this.groupClothes.TabIndex = 41;
            this.groupClothes.TabStop = false;
            this.groupClothes.Text = "Clothes";
            // 
            // checkHand
            // 
            this.checkHand.AutoSize = true;
            this.checkHand.BackColor = System.Drawing.Color.Transparent;
            this.checkHand.Checked = false;
            this.checkHand.Location = new System.Drawing.Point(99, 108);
            this.checkHand.Name = "checkHand";
            this.checkHand.Size = new System.Drawing.Size(52, 15);
            this.checkHand.TabIndex = 8;
            this.checkHand.Text = "Hand";
            // 
            // checkLegs
            // 
            this.checkLegs.AutoSize = true;
            this.checkLegs.BackColor = System.Drawing.Color.Transparent;
            this.checkLegs.Checked = false;
            this.checkLegs.Location = new System.Drawing.Point(11, 108);
            this.checkLegs.Name = "checkLegs";
            this.checkLegs.Size = new System.Drawing.Size(42, 15);
            this.checkLegs.TabIndex = 7;
            this.checkLegs.Text = "Leg";
            // 
            // checkHeavy
            // 
            this.checkHeavy.AutoSize = true;
            this.checkHeavy.BackColor = System.Drawing.Color.Transparent;
            this.checkHeavy.Checked = false;
            this.checkHeavy.Location = new System.Drawing.Point(164, 30);
            this.checkHeavy.Name = "checkHeavy";
            this.checkHeavy.Size = new System.Drawing.Size(56, 15);
            this.checkHeavy.TabIndex = 6;
            this.checkHeavy.Text = "Heavy";
            // 
            // checkLight
            // 
            this.checkLight.AutoSize = true;
            this.checkLight.BackColor = System.Drawing.Color.Transparent;
            this.checkLight.Checked = false;
            this.checkLight.Location = new System.Drawing.Point(99, 30);
            this.checkLight.Name = "checkLight";
            this.checkLight.Size = new System.Drawing.Size(50, 15);
            this.checkLight.TabIndex = 6;
            this.checkLight.Text = "Light";
            // 
            // checkClothes
            // 
            this.checkClothes.AutoSize = true;
            this.checkClothes.BackColor = System.Drawing.Color.Transparent;
            this.checkClothes.Checked = false;
            this.checkClothes.Location = new System.Drawing.Point(11, 30);
            this.checkClothes.Name = "checkClothes";
            this.checkClothes.Size = new System.Drawing.Size(63, 15);
            this.checkClothes.TabIndex = 6;
            this.checkClothes.Text = "Clothes";
            // 
            // checkBoot
            // 
            this.checkBoot.AutoSize = true;
            this.checkBoot.BackColor = System.Drawing.Color.Transparent;
            this.checkBoot.Checked = false;
            this.checkBoot.Location = new System.Drawing.Point(99, 83);
            this.checkBoot.Name = "checkBoot";
            this.checkBoot.Size = new System.Drawing.Size(48, 15);
            this.checkBoot.TabIndex = 4;
            this.checkBoot.Text = "Boot";
            // 
            // checkChest
            // 
            this.checkChest.AutoSize = true;
            this.checkChest.BackColor = System.Drawing.Color.Transparent;
            this.checkChest.Checked = false;
            this.checkChest.Location = new System.Drawing.Point(11, 83);
            this.checkChest.Name = "checkChest";
            this.checkChest.Size = new System.Drawing.Size(53, 15);
            this.checkChest.TabIndex = 4;
            this.checkChest.Text = "Chest";
            // 
            // checkShoulder
            // 
            this.checkShoulder.AutoSize = true;
            this.checkShoulder.BackColor = System.Drawing.Color.Transparent;
            this.checkShoulder.Checked = false;
            this.checkShoulder.Location = new System.Drawing.Point(99, 58);
            this.checkShoulder.Name = "checkShoulder";
            this.checkShoulder.Size = new System.Drawing.Size(70, 15);
            this.checkShoulder.TabIndex = 4;
            this.checkShoulder.Text = "Shoulder";
            // 
            // checkHead
            // 
            this.checkHead.AutoSize = true;
            this.checkHead.BackColor = System.Drawing.Color.Transparent;
            this.checkHead.Checked = false;
            this.checkHead.Location = new System.Drawing.Point(11, 58);
            this.checkHead.Name = "checkHead";
            this.checkHead.Size = new System.Drawing.Size(51, 15);
            this.checkHead.TabIndex = 4;
            this.checkHead.Text = "Head";
            // 
            // separator4
            // 
            this.separator4.Dock = System.Windows.Forms.DockStyle.Top;
            this.separator4.IsVertical = false;
            this.separator4.Location = new System.Drawing.Point(12, 150);
            this.separator4.Name = "separator4";
            this.separator4.Size = new System.Drawing.Size(224, 10);
            this.separator4.TabIndex = 47;
            this.separator4.Text = "separator4";
            // 
            // groupGender
            // 
            this.groupGender.BackColor = System.Drawing.Color.Transparent;
            this.groupGender.Controls.Add(this.checkEuropean);
            this.groupGender.Controls.Add(this.checkChinese);
            this.groupGender.Controls.Add(this.checkFemale);
            this.groupGender.Controls.Add(this.checkBoxRareItems);
            this.groupGender.Controls.Add(this.checkMale);
            this.groupGender.Controls.Add(this.label3);
            this.groupGender.Controls.Add(this.numDegreeFrom);
            this.groupGender.Controls.Add(this.numDegreeTo);
            this.groupGender.Controls.Add(this.label4);
            this.groupGender.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupGender.Location = new System.Drawing.Point(12, 12);
            this.groupGender.Margin = new System.Windows.Forms.Padding(6);
            this.groupGender.Name = "groupGender";
            this.groupGender.Padding = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.groupGender.Radius = 2;
            this.groupGender.Size = new System.Drawing.Size(224, 138);
            this.groupGender.TabIndex = 44;
            this.groupGender.TabStop = false;
            this.groupGender.Text = "Gender and Degree";
            // 
            // checkEuropean
            // 
            this.checkEuropean.AutoSize = true;
            this.checkEuropean.BackColor = System.Drawing.Color.Transparent;
            this.checkEuropean.Checked = false;
            this.checkEuropean.Location = new System.Drawing.Point(99, 53);
            this.checkEuropean.Name = "checkEuropean";
            this.checkEuropean.Size = new System.Drawing.Size(73, 15);
            this.checkEuropean.TabIndex = 9;
            this.checkEuropean.Text = "European";
            // 
            // checkChinese
            // 
            this.checkChinese.AutoSize = true;
            this.checkChinese.BackColor = System.Drawing.Color.Transparent;
            this.checkChinese.Checked = false;
            this.checkChinese.Location = new System.Drawing.Point(16, 53);
            this.checkChinese.Name = "checkChinese";
            this.checkChinese.Size = new System.Drawing.Size(65, 15);
            this.checkChinese.TabIndex = 9;
            this.checkChinese.Text = "Chinese";
            // 
            // checkFemale
            // 
            this.checkFemale.AutoSize = true;
            this.checkFemale.BackColor = System.Drawing.Color.Transparent;
            this.checkFemale.Checked = false;
            this.checkFemale.Location = new System.Drawing.Point(99, 30);
            this.checkFemale.Name = "checkFemale";
            this.checkFemale.Size = new System.Drawing.Size(61, 15);
            this.checkFemale.TabIndex = 9;
            this.checkFemale.Text = "Female";
            // 
            // checkBoxRareItems
            // 
            this.checkBoxRareItems.AutoSize = true;
            this.checkBoxRareItems.BackColor = System.Drawing.Color.Transparent;
            this.checkBoxRareItems.Checked = false;
            this.checkBoxRareItems.Location = new System.Drawing.Point(16, 76);
            this.checkBoxRareItems.Name = "checkBoxRareItems";
            this.checkBoxRareItems.Size = new System.Drawing.Size(76, 15);
            this.checkBoxRareItems.TabIndex = 40;
            this.checkBoxRareItems.Text = "Rare (Sox)";
            // 
            // checkMale
            // 
            this.checkMale.AutoSize = true;
            this.checkMale.BackColor = System.Drawing.Color.Transparent;
            this.checkMale.Checked = false;
            this.checkMale.Location = new System.Drawing.Point(16, 30);
            this.checkMale.Name = "checkMale";
            this.checkMale.Size = new System.Drawing.Size(49, 15);
            this.checkMale.TabIndex = 9;
            this.checkMale.Text = "Male";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(16, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 15);
            this.label3.TabIndex = 31;
            this.label3.Text = "Degree:";
            // 
            // numDegreeFrom
            // 
            this.numDegreeFrom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.numDegreeFrom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numDegreeFrom.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.numDegreeFrom.Location = new System.Drawing.Point(72, 101);
            this.numDegreeFrom.Name = "numDegreeFrom";
            this.numDegreeFrom.Size = new System.Drawing.Size(39, 23);
            this.numDegreeFrom.TabIndex = 32;
            // 
            // numDegreeTo
            // 
            this.numDegreeTo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.numDegreeTo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numDegreeTo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.numDegreeTo.Location = new System.Drawing.Point(140, 101);
            this.numDegreeTo.Name = "numDegreeTo";
            this.numDegreeTo.Size = new System.Drawing.Size(39, 23);
            this.numDegreeTo.TabIndex = 34;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label4.Location = new System.Drawing.Point(116, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(18, 19);
            this.label4.TabIndex = 33;
            this.label4.Text = "~";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.Border = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.panel3.BorderColor = System.Drawing.Color.Transparent;
            this.panel3.Controls.Add(this.panel7);
            this.panel3.Controls.Add(this.labelResult);
            this.panel3.Controls.Add(this.btnResetFilter);
            this.panel3.Controls.Add(this.btnSearch);
            this.panel3.Controls.Add(this.btnReload);
            this.panel3.Controls.Add(this.txtSellSearch);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 409);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Radius = 0;
            this.panel3.Size = new System.Drawing.Size(746, 36);
            this.panel3.TabIndex = 40;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.Transparent;
            this.panel7.Border = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.panel7.BorderColor = System.Drawing.Color.Transparent;
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Margin = new System.Windows.Forms.Padding(0);
            this.panel7.Name = "panel7";
            this.panel7.Radius = 1;
            this.panel7.Size = new System.Drawing.Size(746, 1);
            this.panel7.TabIndex = 41;
            // 
            // labelResult
            // 
            this.labelResult.AutoSize = true;
            this.labelResult.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelResult.Location = new System.Drawing.Point(280, 11);
            this.labelResult.Name = "labelResult";
            this.labelResult.Size = new System.Drawing.Size(0, 15);
            this.labelResult.TabIndex = 40;
            // 
            // btnResetFilter
            // 
            this.btnResetFilter.Color = System.Drawing.Color.Transparent;
            this.btnResetFilter.Location = new System.Drawing.Point(12, 7);
            this.btnResetFilter.Name = "btnResetFilter";
            this.btnResetFilter.Radius = 2;
            this.btnResetFilter.Size = new System.Drawing.Size(96, 23);
            this.btnResetFilter.TabIndex = 39;
            this.btnResetFilter.Text = "Reset";
            this.btnResetFilter.UseVisualStyleBackColor = true;
            this.btnResetFilter.Click += new System.EventHandler(this.btnResetFilter_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Color = System.Drawing.Color.DodgerBlue;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(667, 6);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Radius = 4;
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 21;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // btnReload
            // 
            this.btnReload.Color = System.Drawing.Color.Transparent;
            this.btnReload.Location = new System.Drawing.Point(112, 7);
            this.btnReload.Name = "btnReload";
            this.btnReload.Radius = 2;
            this.btnReload.Size = new System.Drawing.Size(137, 23);
            this.btnReload.TabIndex = 39;
            this.btnReload.Text = "Apply";
            this.btnReload.UseVisualStyleBackColor = true;
            this.btnReload.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // txtSellSearch
            // 
            this.txtSellSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSellSearch.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtSellSearch.Location = new System.Drawing.Point(442, 7);
            this.txtSellSearch.MaxLength = 32767;
            this.txtSellSearch.MultiLine = false;
            this.txtSellSearch.Name = "txtSellSearch";
            this.txtSellSearch.Size = new System.Drawing.Size(221, 21);
            this.txtSellSearch.TabIndex = 20;
            this.txtSellSearch.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtSellSearch.UseSystemPasswordChar = false;
            this.txtSellSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSellSearch_KeyDown);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::RSBot.Items.Properties.Resources.loading;
            this.pictureBox1.Location = new System.Drawing.Point(465, 149);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(121, 69);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 22;
            this.pictureBox1.TabStop = false;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.White;
            this.tabPage1.Controls.Add(this.groupBox7);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(746, 445);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "Pickup settings";
            // 
            // groupBox7
            // 
            this.groupBox7.BackColor = System.Drawing.Color.Transparent;
            this.groupBox7.Controls.Add(this.cbDontPickupWhileBotting);
            this.groupBox7.Controls.Add(this.cbJustpickmyitems);
            this.groupBox7.Controls.Add(this.checkDontPickupInBerzerk);
            this.groupBox7.Controls.Add(this.checkEnableAbilityPet);
            this.groupBox7.Controls.Add(this.checkPickupBlue);
            this.groupBox7.Controls.Add(this.checkPickupRare);
            this.groupBox7.Controls.Add(this.checkPickupGold);
            this.groupBox7.Location = new System.Drawing.Point(6, 6);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Padding = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.groupBox7.Radius = 2;
            this.groupBox7.Size = new System.Drawing.Size(734, 112);
            this.groupBox7.TabIndex = 0;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "General";
            // 
            // cbDontPickupWhileBotting
            // 
            this.cbDontPickupWhileBotting.AutoSize = true;
            this.cbDontPickupWhileBotting.BackColor = System.Drawing.Color.Transparent;
            this.cbDontPickupWhileBotting.Checked = false;
            this.cbDontPickupWhileBotting.Location = new System.Drawing.Point(495, 32);
            this.cbDontPickupWhileBotting.Name = "cbDontPickupWhileBotting";
            this.cbDontPickupWhileBotting.Size = new System.Drawing.Size(196, 15);
            this.cbDontPickupWhileBotting.TabIndex = 3;
            this.cbDontPickupWhileBotting.Text = "Don\'t pickup items while botting";
            this.cbDontPickupWhileBotting.CheckedChanged += new System.EventHandler(this.cbDontPickupWhileBotting_CheckedChanged);
            // 
            // cbJustpickmyitems
            // 
            this.cbJustpickmyitems.AutoSize = true;
            this.cbJustpickmyitems.BackColor = System.Drawing.Color.Transparent;
            this.cbJustpickmyitems.Checked = false;
            this.cbJustpickmyitems.Location = new System.Drawing.Point(232, 82);
            this.cbJustpickmyitems.Name = "cbJustpickmyitems";
            this.cbJustpickmyitems.Size = new System.Drawing.Size(120, 15);
            this.cbJustpickmyitems.TabIndex = 1;
            this.cbJustpickmyitems.Text = "Just pick my items";
            this.cbJustpickmyitems.CheckedChanged += new System.EventHandler(this.cbJustpickmyitems_CheckedChanged);
            // 
            // checkDontPickupInBerzerk
            // 
            this.checkDontPickupInBerzerk.AutoSize = true;
            this.checkDontPickupInBerzerk.BackColor = System.Drawing.Color.Transparent;
            this.checkDontPickupInBerzerk.Checked = false;
            this.checkDontPickupInBerzerk.Location = new System.Drawing.Point(232, 57);
            this.checkDontPickupInBerzerk.Name = "checkDontPickupInBerzerk";
            this.checkDontPickupInBerzerk.Size = new System.Drawing.Size(211, 15);
            this.checkDontPickupInBerzerk.TabIndex = 2;
            this.checkDontPickupInBerzerk.Text = "Don\'t pickup items in berzerk mode";
            this.checkDontPickupInBerzerk.CheckedChanged += new System.EventHandler(this.checkDontPickupInBerzerk_CheckedChanged);
            // 
            // checkEnableAbilityPet
            // 
            this.checkEnableAbilityPet.AutoSize = true;
            this.checkEnableAbilityPet.BackColor = System.Drawing.Color.Transparent;
            this.checkEnableAbilityPet.Checked = false;
            this.checkEnableAbilityPet.Location = new System.Drawing.Point(232, 32);
            this.checkEnableAbilityPet.Name = "checkEnableAbilityPet";
            this.checkEnableAbilityPet.Size = new System.Drawing.Size(185, 15);
            this.checkEnableAbilityPet.TabIndex = 1;
            this.checkEnableAbilityPet.Text = "Use ability pet to pickup items ";
            this.checkEnableAbilityPet.CheckedChanged += new System.EventHandler(this.checkEnableAbilityPet_CheckedChanged);
            // 
            // checkPickupBlue
            // 
            this.checkPickupBlue.AutoSize = true;
            this.checkPickupBlue.BackColor = System.Drawing.Color.Transparent;
            this.checkPickupBlue.Checked = false;
            this.checkPickupBlue.Location = new System.Drawing.Point(16, 82);
            this.checkPickupBlue.Name = "checkPickupBlue";
            this.checkPickupBlue.Size = new System.Drawing.Size(157, 15);
            this.checkPickupBlue.TabIndex = 1;
            this.checkPickupBlue.Text = "Always pickup blue items";
            this.checkPickupBlue.CheckedChanged += new System.EventHandler(this.checkPickupBlue_CheckedChanged);
            // 
            // checkPickupRare
            // 
            this.checkPickupRare.AutoSize = true;
            this.checkPickupRare.BackColor = System.Drawing.Color.Transparent;
            this.checkPickupRare.Checked = false;
            this.checkPickupRare.Location = new System.Drawing.Point(16, 57);
            this.checkPickupRare.Name = "checkPickupRare";
            this.checkPickupRare.Size = new System.Drawing.Size(154, 15);
            this.checkPickupRare.TabIndex = 1;
            this.checkPickupRare.Text = "Always pickup rare items";
            this.checkPickupRare.CheckedChanged += new System.EventHandler(this.checkPickupRare_CheckedChanged);
            // 
            // checkPickupGold
            // 
            this.checkPickupGold.AutoSize = true;
            this.checkPickupGold.BackColor = System.Drawing.Color.Transparent;
            this.checkPickupGold.Checked = false;
            this.checkPickupGold.Location = new System.Drawing.Point(16, 32);
            this.checkPickupGold.Name = "checkPickupGold";
            this.checkPickupGold.Size = new System.Drawing.Size(86, 15);
            this.checkPickupGold.TabIndex = 0;
            this.checkPickupGold.Text = "Pickup gold";
            this.checkPickupGold.CheckedChanged += new System.EventHandler(this.checkPickupGold_CheckedChanged);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.tabMain);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Name = "Main";
            this.Size = new System.Drawing.Size(754, 473);
            this.contextShoppingList.ResumeLayout(false);
            this.contextAvailableProducts.ResumeLayout(false);
            this.tabMain.ResumeLayout(false);
            this.tabBuyFilter.ResumeLayout(false);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabSellFilter.ResumeLayout(false);
            this.contextList.ResumeLayout(false);
            this.filterPanel.ResumeLayout(false);
            this.groupOthers.ResumeLayout(false);
            this.groupOthers.PerformLayout();
            this.groupWeapons.ResumeLayout(false);
            this.groupWeapons.PerformLayout();
            this.groupAccessories.ResumeLayout(false);
            this.groupAccessories.PerformLayout();
            this.groupClothes.ResumeLayout(false);
            this.groupClothes.PerformLayout();
            this.groupGender.ResumeLayout(false);
            this.groupGender.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDegreeFrom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDegreeTo)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private SDUI.Controls.ContextMenuStrip contextAvailableProducts;
        private System.Windows.Forms.ToolStripMenuItem menuAddToShoppingList;
        private SDUI.Controls.ContextMenuStrip contextShoppingList;
        private System.Windows.Forms.ToolStripMenuItem menuChangeAmount;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem menuRemoveItem;
        private SDUI.Controls.TabControl tabMain;
        private System.Windows.Forms.TabPage tabSellFilter;
        private SDUI.Controls.ListView listFilter;
        private System.Windows.Forms.ColumnHeader colItemName;
        private System.Windows.Forms.ColumnHeader colItemLevel;
        private System.Windows.Forms.ColumnHeader colSell;
        private System.Windows.Forms.ColumnHeader collStore;
        private SDUI.Controls.TextBox txtSellSearch;
        private System.Windows.Forms.ColumnHeader colGender;
        private SDUI.Controls.ContextMenuStrip contextList;
        private System.Windows.Forms.ToolStripMenuItem btnAddToSell;
        private System.Windows.Forms.ToolStripMenuItem btnAddToStore;
        private SDUI.Controls.Button btnSearch;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem btnDontSell;
        private System.Windows.Forms.ToolStripMenuItem btnDontStore;
        private SDUI.Controls.Panel filterPanel;
        private SDUI.Controls.GroupBox groupOthers;
        private SDUI.Controls.CheckBox checkAlchemy;
        private SDUI.Controls.CheckBox checkOther;
        private SDUI.Controls.GroupBox groupClothes;
        private SDUI.Controls.GroupBox groupWeapons;
        private SDUI.Controls.Button btnReload;
        private SDUI.Controls.CheckBox checkBlade;
        private SDUI.Controls.CheckBox checkSword;
        private SDUI.Controls.CheckBox checkSpear;
        private SDUI.Controls.CheckBox checkGlave;
        private SDUI.Controls.CheckBox checkBow;
        private SDUI.Controls.CheckBox check2HSword;
        private SDUI.Controls.CheckBox check1HSword;
        private SDUI.Controls.CheckBox checkStaff;
        private SDUI.Controls.CheckBox checkWRod;
        private SDUI.Controls.CheckBox checkCRod;
        private SDUI.Controls.CheckBox checkXBow;
        private SDUI.Controls.CheckBox checkHarp;
        private SDUI.Controls.CheckBox checkDagger;
        private SDUI.Controls.CheckBox checkHead;
        private SDUI.Controls.CheckBox checkBoot;
        private SDUI.Controls.CheckBox checkChest;
        private SDUI.Controls.CheckBox checkShoulder;
        private SDUI.Controls.CheckBox checkShield;
        private SDUI.Controls.GroupBox groupAccessories;
        private SDUI.Controls.CheckBox checkEarring;
        private SDUI.Controls.CheckBox checkRing;
        private SDUI.Controls.CheckBox checkNecklace;
        private SDUI.Controls.GroupBox groupGender;
        private SDUI.Controls.Label label3;
        private SDUI.Controls.NumUpDown numDegreeFrom;
        private SDUI.Controls.NumUpDown numDegreeTo;
        private SDUI.Controls.Label label4;
        private SDUI.Controls.CheckBox checkLight;
        private SDUI.Controls.CheckBox checkClothes;
        private SDUI.Controls.CheckBox checkHeavy;
        private SDUI.Controls.CheckBox checkAxe;
        private SDUI.Controls.CheckBox checkLegs;
        private SDUI.Controls.CheckBox checkHand;
        private System.Windows.Forms.ToolStripMenuItem btnPickup;
        private System.Windows.Forms.ToolStripMenuItem btnDontPickup;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TabPage tabPage1;
        private SDUI.Controls.GroupBox groupBox7;
        private SDUI.Controls.CheckBox checkPickupGold;
        private System.Windows.Forms.ColumnHeader colPickup;
        private SDUI.Controls.CheckBox checkPickupRare;
        private SDUI.Controls.CheckBox checkEnableAbilityPet;
        private SDUI.Controls.Button btnResetFilter;
        private SDUI.Controls.CheckBox checkDontPickupInBerzerk;
        private SDUI.Controls.CheckBox cbJustpickmyitems;
        private SDUI.Controls.CheckBox cbDontPickupWhileBotting;
        private SDUI.Controls.Panel panel3;
        private SDUI.Controls.Label labelResult;
        private SDUI.Controls.Panel panel7;
        private SDUI.Controls.CheckBox checkBoxRareItems;
        private System.Windows.Forms.ImageList searchImageList;
        private SDUI.Controls.CheckBox checkEuropean;
        private SDUI.Controls.CheckBox checkChinese;
        private SDUI.Controls.CheckBox checkFemale;
        private SDUI.Controls.CheckBox checkMale;
        private SDUI.Controls.CheckBox checkQuest;
        private SDUI.Controls.CheckBox checkCoin;
        private SDUI.Controls.CheckBox checkAmmo;
        private System.Windows.Forms.TabPage tabBuyFilter;
        private SDUI.Controls.GroupBox groupBox1;
        private SDUI.Controls.CheckBox checkSellItemsFromPet;
        private SDUI.Controls.CheckBox checkRepairGear;
        private SDUI.Controls.CheckBox checkEnable;
        private System.Windows.Forms.SplitContainer splitContainer;
        private SDUI.Controls.ListView listAvailableProducts;
        private System.Windows.Forms.ColumnHeader colAvailableName;
        private SDUI.Controls.Panel panel1;
        private SDUI.Controls.Label label6;
        private SDUI.Controls.CheckBox checkShowEquipment;
        private SDUI.Controls.TextBox txtShopSearch;
        private SDUI.Controls.ComboBox comboStore;
        private SDUI.Controls.Label label1;
        private SDUI.Controls.ListView listShoppingList;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colAmount;
        private SDUI.Controls.Panel panel2;
        private SDUI.Controls.Separator separator3;
        private SDUI.Controls.Separator separator4;
        private SDUI.Controls.Separator separator1;
        private SDUI.Controls.Separator separator2;
        private SDUI.Controls.Separator separator5;
        private SDUI.Controls.CheckBox checkStoreItemsFromPet;
        private SDUI.Controls.CheckBox checkPickupBlue;
    }
}
