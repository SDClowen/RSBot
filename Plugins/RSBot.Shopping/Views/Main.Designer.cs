namespace RSBot.Shopping.Views
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
            this.comboStore = new System.Windows.Forms.ComboBox();
            this.listShoppingList = new System.Windows.Forms.ListView();
            this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAmount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextShoppingList = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuChangeAmount = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuRemoveItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imgShoppingList = new System.Windows.Forms.ImageList(this.components);
            this.listAvailableProducts = new System.Windows.Forms.ListView();
            this.colAvailableName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextAvailableProducts = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuAddToShoppingList = new System.Windows.Forms.ToolStripMenuItem();
            this.imgShoppingListNPC = new System.Windows.Forms.ImageList(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.checkShowEquipment = new System.Windows.Forms.CheckBox();
            this.txtShopSearch = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tabMain = new RSBot.Theme.Controls.TabControl();
            this.tabBuyFilter = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkSellItemsFromPet = new System.Windows.Forms.CheckBox();
            this.checkRepairGear = new System.Windows.Forms.CheckBox();
            this.checkEnable = new System.Windows.Forms.CheckBox();
            this.tabSellFilter = new System.Windows.Forms.TabPage();
            this.listFilter = new System.Windows.Forms.ListView();
            this.colItemName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colItemLevel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colGender = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPickup = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSell = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.collStore = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextList = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnAddToSell = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAddToStore = new System.Windows.Forms.ToolStripMenuItem();
            this.btnPickup = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnDontSell = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDontStore = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDontPickup = new System.Windows.Forms.ToolStripMenuItem();
            this.searchImageList = new System.Windows.Forms.ImageList(this.components);
            this.filterPanel = new System.Windows.Forms.Panel();
            this.groupOthers = new System.Windows.Forms.GroupBox();
            this.checkAlchemy = new System.Windows.Forms.CheckBox();
            this.checkQuest = new System.Windows.Forms.CheckBox();
            this.checkAmmo = new System.Windows.Forms.CheckBox();
            this.checkCoin = new System.Windows.Forms.CheckBox();
            this.checkOther = new System.Windows.Forms.CheckBox();
            this.groupWeapons = new System.Windows.Forms.GroupBox();
            this.checkAxe = new System.Windows.Forms.CheckBox();
            this.checkHarp = new System.Windows.Forms.CheckBox();
            this.checkDagger = new System.Windows.Forms.CheckBox();
            this.checkXBow = new System.Windows.Forms.CheckBox();
            this.checkWRod = new System.Windows.Forms.CheckBox();
            this.checkShield = new System.Windows.Forms.CheckBox();
            this.checkCRod = new System.Windows.Forms.CheckBox();
            this.check2HSword = new System.Windows.Forms.CheckBox();
            this.check1HSword = new System.Windows.Forms.CheckBox();
            this.checkStaff = new System.Windows.Forms.CheckBox();
            this.checkBow = new System.Windows.Forms.CheckBox();
            this.checkSpear = new System.Windows.Forms.CheckBox();
            this.checkGlave = new System.Windows.Forms.CheckBox();
            this.checkSword = new System.Windows.Forms.CheckBox();
            this.checkBlade = new System.Windows.Forms.CheckBox();
            this.groupAccessories = new System.Windows.Forms.GroupBox();
            this.checkNecklace = new System.Windows.Forms.CheckBox();
            this.checkEarring = new System.Windows.Forms.CheckBox();
            this.checkRing = new System.Windows.Forms.CheckBox();
            this.groupClothes = new System.Windows.Forms.GroupBox();
            this.checkHand = new System.Windows.Forms.CheckBox();
            this.checkLegs = new System.Windows.Forms.CheckBox();
            this.checkHeavy = new System.Windows.Forms.CheckBox();
            this.checkLight = new System.Windows.Forms.CheckBox();
            this.checkClothes = new System.Windows.Forms.CheckBox();
            this.checkBoot = new System.Windows.Forms.CheckBox();
            this.checkChest = new System.Windows.Forms.CheckBox();
            this.checkShoulder = new System.Windows.Forms.CheckBox();
            this.checkHead = new System.Windows.Forms.CheckBox();
            this.groupGender = new System.Windows.Forms.GroupBox();
            this.checkEuropean = new System.Windows.Forms.CheckBox();
            this.checkChinese = new System.Windows.Forms.CheckBox();
            this.checkFemale = new System.Windows.Forms.CheckBox();
            this.checkBoxRareItems = new System.Windows.Forms.CheckBox();
            this.checkMale = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.numDegreeFrom = new System.Windows.Forms.NumericUpDown();
            this.numDegreeTo = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.labelResult = new System.Windows.Forms.Label();
            this.btnResetFilter = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnReload = new System.Windows.Forms.Button();
            this.txtSellSearch = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.cbDontPickupWhileBotting = new System.Windows.Forms.CheckBox();
            this.cbJustpickmyitems = new System.Windows.Forms.CheckBox();
            this.checkDontPickupInBerzerk = new System.Windows.Forms.CheckBox();
            this.checkEnableAbilityPet = new System.Windows.Forms.CheckBox();
            this.checkPickupRare = new System.Windows.Forms.CheckBox();
            this.checkPickupGold = new System.Windows.Forms.CheckBox();
            this.contextShoppingList.SuspendLayout();
            this.contextAvailableProducts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.tabBuyFilter.SuspendLayout();
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
            // comboStore
            // 
            this.comboStore.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboStore.FormattingEnabled = true;
            this.comboStore.Items.AddRange(new object[] {
            "Potion trader",
            "Stable keeper",
            "Protector trader",
            "Weapon trader",
            "Accessory trader"});
            this.comboStore.Location = new System.Drawing.Point(61, 4);
            this.comboStore.Name = "comboStore";
            this.comboStore.Size = new System.Drawing.Size(144, 21);
            this.comboStore.TabIndex = 2;
            this.comboStore.SelectedIndexChanged += new System.EventHandler(this.comboStore_SelectedIndexChanged);
            // 
            // listShoppingList
            // 
            this.listShoppingList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colName,
            this.colAmount});
            this.listShoppingList.ContextMenuStrip = this.contextShoppingList;
            this.listShoppingList.Dock = System.Windows.Forms.DockStyle.Fill;
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
            this.listShoppingList.HideSelection = false;
            this.listShoppingList.Location = new System.Drawing.Point(0, 57);
            this.listShoppingList.Name = "listShoppingList";
            this.listShoppingList.Size = new System.Drawing.Size(396, 309);
            this.listShoppingList.SmallImageList = this.imgShoppingList;
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
            // imgShoppingList
            // 
            this.imgShoppingList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imgShoppingList.ImageSize = new System.Drawing.Size(24, 24);
            this.imgShoppingList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // listAvailableProducts
            // 
            this.listAvailableProducts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colAvailableName});
            this.listAvailableProducts.ContextMenuStrip = this.contextAvailableProducts;
            this.listAvailableProducts.FullRowSelect = true;
            this.listAvailableProducts.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listAvailableProducts.HideSelection = false;
            this.listAvailableProducts.Location = new System.Drawing.Point(6, 57);
            this.listAvailableProducts.Margin = new System.Windows.Forms.Padding(8);
            this.listAvailableProducts.Name = "listAvailableProducts";
            this.listAvailableProducts.Size = new System.Drawing.Size(334, 309);
            this.listAvailableProducts.SmallImageList = this.imgShoppingListNPC;
            this.listAvailableProducts.TabIndex = 4;
            this.listAvailableProducts.UseCompatibleStateImageBehavior = false;
            this.listAvailableProducts.View = System.Windows.Forms.View.Details;
            // 
            // colAvailableName
            // 
            this.colAvailableName.Text = "Name";
            this.colAvailableName.Width = 261;
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
            // imgShoppingListNPC
            // 
            this.imgShoppingListNPC.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imgShoppingListNPC.ImageSize = new System.Drawing.Size(24, 24);
            this.imgShoppingListNPC.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Store:";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(-4, 4);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.listAvailableProducts);
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.listShoppingList);
            this.splitContainer1.Panel2.Controls.Add(this.panel2);
            this.splitContainer1.Size = new System.Drawing.Size(737, 366);
            this.splitContainer1.SplitterDistance = 340;
            this.splitContainer1.SplitterWidth = 1;
            this.splitContainer1.TabIndex = 6;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.checkShowEquipment);
            this.panel1.Controls.Add(this.txtShopSearch);
            this.panel1.Controls.Add(this.comboStore);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(340, 57);
            this.panel1.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(5, 32);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Search:";
            // 
            // checkShowEquipment
            // 
            this.checkShowEquipment.AutoSize = true;
            this.checkShowEquipment.Location = new System.Drawing.Point(211, 18);
            this.checkShowEquipment.Name = "checkShowEquipment";
            this.checkShowEquipment.Size = new System.Drawing.Size(114, 17);
            this.checkShowEquipment.TabIndex = 9;
            this.checkShowEquipment.Text = "Show equipment";
            this.checkShowEquipment.UseVisualStyleBackColor = true;
            this.checkShowEquipment.CheckedChanged += new System.EventHandler(this.checkShowEquipment_CheckedChanged);
            // 
            // txtShopSearch
            // 
            this.txtShopSearch.Location = new System.Drawing.Point(61, 29);
            this.txtShopSearch.Name = "txtShopSearch";
            this.txtShopSearch.Size = new System.Drawing.Size(144, 22);
            this.txtShopSearch.TabIndex = 8;
            this.txtShopSearch.TextChanged += new System.EventHandler(this.txtShopSearch_TextChanged);
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(396, 57);
            this.panel2.TabIndex = 7;
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabBuyFilter);
            this.tabMain.Controls.Add(this.tabSellFilter);
            this.tabMain.Controls.Add(this.tabPage1);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Location = new System.Drawing.Point(6, 6);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(742, 461);
            this.tabMain.TabIndex = 7;
            // 
            // tabBuyFilter
            // 
            this.tabBuyFilter.Controls.Add(this.groupBox1);
            this.tabBuyFilter.Controls.Add(this.splitContainer1);
            this.tabBuyFilter.Location = new System.Drawing.Point(4, 25);
            this.tabBuyFilter.Name = "tabBuyFilter";
            this.tabBuyFilter.Padding = new System.Windows.Forms.Padding(3);
            this.tabBuyFilter.Size = new System.Drawing.Size(734, 432);
            this.tabBuyFilter.TabIndex = 0;
            this.tabBuyFilter.Text = "Shopping";
            this.tabBuyFilter.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkSellItemsFromPet);
            this.groupBox1.Controls.Add(this.checkRepairGear);
            this.groupBox1.Controls.Add(this.checkEnable);
            this.groupBox1.Location = new System.Drawing.Point(1, 374);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(730, 52);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "General setup";
            // 
            // checkSellItemsFromPet
            // 
            this.checkSellItemsFromPet.AutoSize = true;
            this.checkSellItemsFromPet.Checked = true;
            this.checkSellItemsFromPet.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkSellItemsFromPet.Location = new System.Drawing.Point(425, 23);
            this.checkSellItemsFromPet.Name = "checkSellItemsFromPet";
            this.checkSellItemsFromPet.Size = new System.Drawing.Size(111, 17);
            this.checkSellItemsFromPet.TabIndex = 3;
            this.checkSellItemsFromPet.Text = "Sell items from pet";
            this.checkSellItemsFromPet.UseVisualStyleBackColor = true;
            this.checkSellItemsFromPet.CheckedChanged += new System.EventHandler(this.checkSellItemsFromPet_CheckedChanged);
            // 
            // checkRepairGear
            // 
            this.checkRepairGear.AutoSize = true;
            this.checkRepairGear.Checked = true;
            this.checkRepairGear.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkRepairGear.Location = new System.Drawing.Point(231, 23);
            this.checkRepairGear.Name = "checkRepairGear";
            this.checkRepairGear.Size = new System.Drawing.Size(152, 17);
            this.checkRepairGear.TabIndex = 1;
            this.checkRepairGear.Text = "Automaticaly repair all gear";
            this.checkRepairGear.UseVisualStyleBackColor = true;
            this.checkRepairGear.CheckedChanged += new System.EventHandler(this.checkRepairGear_CheckedChanged);
            // 
            // checkEnable
            // 
            this.checkEnable.AutoSize = true;
            this.checkEnable.Checked = true;
            this.checkEnable.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkEnable.Location = new System.Drawing.Point(13, 23);
            this.checkEnable.Name = "checkEnable";
            this.checkEnable.Size = new System.Drawing.Size(170, 17);
            this.checkEnable.TabIndex = 0;
            this.checkEnable.Text = "Automaticaly run when in town";
            this.checkEnable.UseVisualStyleBackColor = true;
            this.checkEnable.CheckedChanged += new System.EventHandler(this.checkEnable_CheckedChanged);
            // 
            // tabSellFilter
            // 
            this.tabSellFilter.Controls.Add(this.listFilter);
            this.tabSellFilter.Controls.Add(this.filterPanel);
            this.tabSellFilter.Controls.Add(this.panel3);
            this.tabSellFilter.Controls.Add(this.pictureBox1);
            this.tabSellFilter.Location = new System.Drawing.Point(4, 25);
            this.tabSellFilter.Name = "tabSellFilter";
            this.tabSellFilter.Size = new System.Drawing.Size(734, 432);
            this.tabSellFilter.TabIndex = 1;
            this.tabSellFilter.Text = "Item filter";
            this.tabSellFilter.UseVisualStyleBackColor = true;
            // 
            // listFilter
            // 
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
            this.listFilter.FullRowSelect = true;
            this.listFilter.HideSelection = false;
            this.listFilter.Location = new System.Drawing.Point(265, 0);
            this.listFilter.Name = "listFilter";
            this.listFilter.Size = new System.Drawing.Size(469, 396);
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
            this.filterPanel.Controls.Add(this.groupOthers);
            this.filterPanel.Controls.Add(this.groupWeapons);
            this.filterPanel.Controls.Add(this.groupAccessories);
            this.filterPanel.Controls.Add(this.groupClothes);
            this.filterPanel.Controls.Add(this.groupGender);
            this.filterPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.filterPanel.Location = new System.Drawing.Point(0, 0);
            this.filterPanel.Name = "filterPanel";
            this.filterPanel.Padding = new System.Windows.Forms.Padding(12);
            this.filterPanel.Size = new System.Drawing.Size(265, 396);
            this.filterPanel.TabIndex = 20;
            // 
            // groupOthers
            // 
            this.groupOthers.Controls.Add(this.checkAlchemy);
            this.groupOthers.Controls.Add(this.checkQuest);
            this.groupOthers.Controls.Add(this.checkAmmo);
            this.groupOthers.Controls.Add(this.checkCoin);
            this.groupOthers.Controls.Add(this.checkOther);
            this.groupOthers.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupOthers.Location = new System.Drawing.Point(12, 510);
            this.groupOthers.Name = "groupOthers";
            this.groupOthers.Size = new System.Drawing.Size(224, 95);
            this.groupOthers.TabIndex = 42;
            this.groupOthers.TabStop = false;
            this.groupOthers.Text = "Others";
            // 
            // checkAlchemy
            // 
            this.checkAlchemy.AutoSize = true;
            this.checkAlchemy.Location = new System.Drawing.Point(99, 47);
            this.checkAlchemy.Name = "checkAlchemy";
            this.checkAlchemy.Size = new System.Drawing.Size(66, 17);
            this.checkAlchemy.TabIndex = 19;
            this.checkAlchemy.Text = "Alchemy";
            this.checkAlchemy.UseVisualStyleBackColor = true;
            // 
            // checkQuest
            // 
            this.checkQuest.AutoSize = true;
            this.checkQuest.Location = new System.Drawing.Point(11, 24);
            this.checkQuest.Name = "checkQuest";
            this.checkQuest.Size = new System.Drawing.Size(54, 17);
            this.checkQuest.TabIndex = 19;
            this.checkQuest.Text = "Quest";
            this.checkQuest.UseVisualStyleBackColor = true;
            // 
            // checkAmmo
            // 
            this.checkAmmo.AutoSize = true;
            this.checkAmmo.Location = new System.Drawing.Point(11, 47);
            this.checkAmmo.Name = "checkAmmo";
            this.checkAmmo.Size = new System.Drawing.Size(55, 17);
            this.checkAmmo.TabIndex = 19;
            this.checkAmmo.Text = "Ammo";
            this.checkAmmo.UseVisualStyleBackColor = true;
            // 
            // checkCoin
            // 
            this.checkCoin.AutoSize = true;
            this.checkCoin.Location = new System.Drawing.Point(99, 24);
            this.checkCoin.Name = "checkCoin";
            this.checkCoin.Size = new System.Drawing.Size(47, 17);
            this.checkCoin.TabIndex = 19;
            this.checkCoin.Text = "Coin";
            this.checkCoin.UseVisualStyleBackColor = true;
            // 
            // checkOther
            // 
            this.checkOther.AutoSize = true;
            this.checkOther.Location = new System.Drawing.Point(11, 70);
            this.checkOther.Name = "checkOther";
            this.checkOther.Size = new System.Drawing.Size(52, 17);
            this.checkOther.TabIndex = 19;
            this.checkOther.Text = "Other";
            this.checkOther.UseVisualStyleBackColor = true;
            // 
            // groupWeapons
            // 
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
            this.groupWeapons.Location = new System.Drawing.Point(12, 313);
            this.groupWeapons.Margin = new System.Windows.Forms.Padding(6);
            this.groupWeapons.Name = "groupWeapons";
            this.groupWeapons.Size = new System.Drawing.Size(224, 197);
            this.groupWeapons.TabIndex = 40;
            this.groupWeapons.TabStop = false;
            this.groupWeapons.Text = "Weapons";
            // 
            // checkAxe
            // 
            this.checkAxe.AutoSize = true;
            this.checkAxe.Location = new System.Drawing.Point(99, 172);
            this.checkAxe.Name = "checkAxe";
            this.checkAxe.Size = new System.Drawing.Size(44, 17);
            this.checkAxe.TabIndex = 10;
            this.checkAxe.Text = "Axe";
            this.checkAxe.UseVisualStyleBackColor = true;
            // 
            // checkHarp
            // 
            this.checkHarp.AutoSize = true;
            this.checkHarp.Location = new System.Drawing.Point(11, 172);
            this.checkHarp.Name = "checkHarp";
            this.checkHarp.Size = new System.Drawing.Size(49, 17);
            this.checkHarp.TabIndex = 10;
            this.checkHarp.Text = "Harp";
            this.checkHarp.UseVisualStyleBackColor = true;
            // 
            // checkDagger
            // 
            this.checkDagger.AutoSize = true;
            this.checkDagger.Location = new System.Drawing.Point(99, 147);
            this.checkDagger.Name = "checkDagger";
            this.checkDagger.Size = new System.Drawing.Size(61, 17);
            this.checkDagger.TabIndex = 9;
            this.checkDagger.Text = "Dagger";
            this.checkDagger.UseVisualStyleBackColor = true;
            // 
            // checkXBow
            // 
            this.checkXBow.AutoSize = true;
            this.checkXBow.Location = new System.Drawing.Point(11, 147);
            this.checkXBow.Name = "checkXBow";
            this.checkXBow.Size = new System.Drawing.Size(57, 17);
            this.checkXBow.TabIndex = 9;
            this.checkXBow.Text = "X-Bow";
            this.checkXBow.UseVisualStyleBackColor = true;
            // 
            // checkWRod
            // 
            this.checkWRod.AutoSize = true;
            this.checkWRod.Location = new System.Drawing.Point(99, 122);
            this.checkWRod.Name = "checkWRod";
            this.checkWRod.Size = new System.Drawing.Size(60, 17);
            this.checkWRod.TabIndex = 8;
            this.checkWRod.Text = "W-Rod";
            this.checkWRod.UseVisualStyleBackColor = true;
            // 
            // checkShield
            // 
            this.checkShield.AutoSize = true;
            this.checkShield.Location = new System.Drawing.Point(161, 172);
            this.checkShield.Name = "checkShield";
            this.checkShield.Size = new System.Drawing.Size(55, 17);
            this.checkShield.TabIndex = 5;
            this.checkShield.Text = "Shield";
            this.checkShield.UseVisualStyleBackColor = true;
            // 
            // checkCRod
            // 
            this.checkCRod.AutoSize = true;
            this.checkCRod.Location = new System.Drawing.Point(11, 122);
            this.checkCRod.Name = "checkCRod";
            this.checkCRod.Size = new System.Drawing.Size(56, 17);
            this.checkCRod.TabIndex = 7;
            this.checkCRod.Text = "C-Rod";
            this.checkCRod.UseVisualStyleBackColor = true;
            // 
            // check2HSword
            // 
            this.check2HSword.AutoSize = true;
            this.check2HSword.Location = new System.Drawing.Point(99, 97);
            this.check2HSword.Name = "check2HSword";
            this.check2HSword.Size = new System.Drawing.Size(73, 17);
            this.check2HSword.TabIndex = 6;
            this.check2HSword.Text = "2H Sword";
            this.check2HSword.UseVisualStyleBackColor = true;
            // 
            // check1HSword
            // 
            this.check1HSword.AutoSize = true;
            this.check1HSword.Location = new System.Drawing.Point(11, 97);
            this.check1HSword.Name = "check1HSword";
            this.check1HSword.Size = new System.Drawing.Size(73, 17);
            this.check1HSword.TabIndex = 5;
            this.check1HSword.Text = "1H Sword";
            this.check1HSword.UseVisualStyleBackColor = true;
            // 
            // checkStaff
            // 
            this.checkStaff.AutoSize = true;
            this.checkStaff.Location = new System.Drawing.Point(99, 72);
            this.checkStaff.Name = "checkStaff";
            this.checkStaff.Size = new System.Drawing.Size(48, 17);
            this.checkStaff.TabIndex = 5;
            this.checkStaff.Text = "Staff";
            this.checkStaff.UseVisualStyleBackColor = true;
            // 
            // checkBow
            // 
            this.checkBow.AutoSize = true;
            this.checkBow.Location = new System.Drawing.Point(11, 72);
            this.checkBow.Name = "checkBow";
            this.checkBow.Size = new System.Drawing.Size(47, 17);
            this.checkBow.TabIndex = 4;
            this.checkBow.Text = "Bow";
            this.checkBow.UseVisualStyleBackColor = true;
            // 
            // checkSpear
            // 
            this.checkSpear.AutoSize = true;
            this.checkSpear.Location = new System.Drawing.Point(99, 47);
            this.checkSpear.Name = "checkSpear";
            this.checkSpear.Size = new System.Drawing.Size(54, 17);
            this.checkSpear.TabIndex = 3;
            this.checkSpear.Text = "Spear";
            this.checkSpear.UseVisualStyleBackColor = true;
            // 
            // checkGlave
            // 
            this.checkGlave.AutoSize = true;
            this.checkGlave.Location = new System.Drawing.Point(11, 47);
            this.checkGlave.Name = "checkGlave";
            this.checkGlave.Size = new System.Drawing.Size(54, 17);
            this.checkGlave.TabIndex = 2;
            this.checkGlave.Text = "Glave";
            this.checkGlave.UseVisualStyleBackColor = true;
            // 
            // checkSword
            // 
            this.checkSword.AutoSize = true;
            this.checkSword.Location = new System.Drawing.Point(99, 22);
            this.checkSword.Name = "checkSword";
            this.checkSword.Size = new System.Drawing.Size(56, 17);
            this.checkSword.TabIndex = 1;
            this.checkSword.Text = "Sword";
            this.checkSword.UseVisualStyleBackColor = true;
            // 
            // checkBlade
            // 
            this.checkBlade.AutoSize = true;
            this.checkBlade.Location = new System.Drawing.Point(11, 22);
            this.checkBlade.Name = "checkBlade";
            this.checkBlade.Size = new System.Drawing.Size(53, 17);
            this.checkBlade.TabIndex = 0;
            this.checkBlade.Text = "Blade";
            this.checkBlade.UseVisualStyleBackColor = true;
            // 
            // groupAccessories
            // 
            this.groupAccessories.Controls.Add(this.checkNecklace);
            this.groupAccessories.Controls.Add(this.checkEarring);
            this.groupAccessories.Controls.Add(this.checkRing);
            this.groupAccessories.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupAccessories.Location = new System.Drawing.Point(12, 265);
            this.groupAccessories.Name = "groupAccessories";
            this.groupAccessories.Size = new System.Drawing.Size(224, 48);
            this.groupAccessories.TabIndex = 44;
            this.groupAccessories.TabStop = false;
            this.groupAccessories.Text = "Accessories";
            // 
            // checkNecklace
            // 
            this.checkNecklace.AutoSize = true;
            this.checkNecklace.Location = new System.Drawing.Point(71, 22);
            this.checkNecklace.Name = "checkNecklace";
            this.checkNecklace.Size = new System.Drawing.Size(72, 17);
            this.checkNecklace.TabIndex = 4;
            this.checkNecklace.Text = "Necklace";
            this.checkNecklace.UseVisualStyleBackColor = true;
            // 
            // checkEarring
            // 
            this.checkEarring.AutoSize = true;
            this.checkEarring.Location = new System.Drawing.Point(157, 22);
            this.checkEarring.Name = "checkEarring";
            this.checkEarring.Size = new System.Drawing.Size(59, 17);
            this.checkEarring.TabIndex = 3;
            this.checkEarring.Text = "Earring";
            this.checkEarring.UseVisualStyleBackColor = true;
            // 
            // checkRing
            // 
            this.checkRing.AutoSize = true;
            this.checkRing.Location = new System.Drawing.Point(11, 22);
            this.checkRing.Name = "checkRing";
            this.checkRing.Size = new System.Drawing.Size(48, 17);
            this.checkRing.TabIndex = 2;
            this.checkRing.Text = "Ring";
            this.checkRing.UseVisualStyleBackColor = true;
            // 
            // groupClothes
            // 
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
            this.groupClothes.Location = new System.Drawing.Point(12, 140);
            this.groupClothes.Name = "groupClothes";
            this.groupClothes.Size = new System.Drawing.Size(224, 125);
            this.groupClothes.TabIndex = 41;
            this.groupClothes.TabStop = false;
            this.groupClothes.Text = "Clothes";
            // 
            // checkHand
            // 
            this.checkHand.AutoSize = true;
            this.checkHand.Location = new System.Drawing.Point(99, 100);
            this.checkHand.Name = "checkHand";
            this.checkHand.Size = new System.Drawing.Size(52, 17);
            this.checkHand.TabIndex = 8;
            this.checkHand.Text = "Hand";
            this.checkHand.UseVisualStyleBackColor = true;
            // 
            // checkLegs
            // 
            this.checkLegs.AutoSize = true;
            this.checkLegs.Location = new System.Drawing.Point(11, 100);
            this.checkLegs.Name = "checkLegs";
            this.checkLegs.Size = new System.Drawing.Size(44, 17);
            this.checkLegs.TabIndex = 7;
            this.checkLegs.Text = "Leg";
            this.checkLegs.UseVisualStyleBackColor = true;
            // 
            // checkHeavy
            // 
            this.checkHeavy.AutoSize = true;
            this.checkHeavy.Location = new System.Drawing.Point(164, 22);
            this.checkHeavy.Name = "checkHeavy";
            this.checkHeavy.Size = new System.Drawing.Size(57, 17);
            this.checkHeavy.TabIndex = 6;
            this.checkHeavy.Text = "Heavy";
            this.checkHeavy.UseVisualStyleBackColor = true;
            // 
            // checkLight
            // 
            this.checkLight.AutoSize = true;
            this.checkLight.Location = new System.Drawing.Point(99, 22);
            this.checkLight.Name = "checkLight";
            this.checkLight.Size = new System.Drawing.Size(49, 17);
            this.checkLight.TabIndex = 6;
            this.checkLight.Text = "Light";
            this.checkLight.UseVisualStyleBackColor = true;
            // 
            // checkClothes
            // 
            this.checkClothes.AutoSize = true;
            this.checkClothes.Location = new System.Drawing.Point(11, 22);
            this.checkClothes.Name = "checkClothes";
            this.checkClothes.Size = new System.Drawing.Size(61, 17);
            this.checkClothes.TabIndex = 6;
            this.checkClothes.Text = "Clothes";
            this.checkClothes.UseVisualStyleBackColor = true;
            // 
            // checkBoot
            // 
            this.checkBoot.AutoSize = true;
            this.checkBoot.Location = new System.Drawing.Point(99, 75);
            this.checkBoot.Name = "checkBoot";
            this.checkBoot.Size = new System.Drawing.Size(48, 17);
            this.checkBoot.TabIndex = 4;
            this.checkBoot.Text = "Boot";
            this.checkBoot.UseVisualStyleBackColor = true;
            // 
            // checkChest
            // 
            this.checkChest.AutoSize = true;
            this.checkChest.Location = new System.Drawing.Point(11, 75);
            this.checkChest.Name = "checkChest";
            this.checkChest.Size = new System.Drawing.Size(53, 17);
            this.checkChest.TabIndex = 4;
            this.checkChest.Text = "Chest";
            this.checkChest.UseVisualStyleBackColor = true;
            // 
            // checkShoulder
            // 
            this.checkShoulder.AutoSize = true;
            this.checkShoulder.Location = new System.Drawing.Point(99, 50);
            this.checkShoulder.Name = "checkShoulder";
            this.checkShoulder.Size = new System.Drawing.Size(68, 17);
            this.checkShoulder.TabIndex = 4;
            this.checkShoulder.Text = "Shoulder";
            this.checkShoulder.UseVisualStyleBackColor = true;
            // 
            // checkHead
            // 
            this.checkHead.AutoSize = true;
            this.checkHead.Location = new System.Drawing.Point(11, 50);
            this.checkHead.Name = "checkHead";
            this.checkHead.Size = new System.Drawing.Size(52, 17);
            this.checkHead.TabIndex = 4;
            this.checkHead.Text = "Head";
            this.checkHead.UseVisualStyleBackColor = true;
            // 
            // groupGender
            // 
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
            this.groupGender.Size = new System.Drawing.Size(224, 128);
            this.groupGender.TabIndex = 44;
            this.groupGender.TabStop = false;
            this.groupGender.Text = "Gender and Degree";
            // 
            // checkEuropean
            // 
            this.checkEuropean.AutoSize = true;
            this.checkEuropean.Location = new System.Drawing.Point(99, 46);
            this.checkEuropean.Name = "checkEuropean";
            this.checkEuropean.Size = new System.Drawing.Size(72, 17);
            this.checkEuropean.TabIndex = 9;
            this.checkEuropean.Text = "European";
            this.checkEuropean.UseVisualStyleBackColor = true;
            // 
            // checkChinese
            // 
            this.checkChinese.AutoSize = true;
            this.checkChinese.Location = new System.Drawing.Point(16, 46);
            this.checkChinese.Name = "checkChinese";
            this.checkChinese.Size = new System.Drawing.Size(64, 17);
            this.checkChinese.TabIndex = 9;
            this.checkChinese.Text = "Chinese";
            this.checkChinese.UseVisualStyleBackColor = true;
            // 
            // checkFemale
            // 
            this.checkFemale.AutoSize = true;
            this.checkFemale.Location = new System.Drawing.Point(99, 23);
            this.checkFemale.Name = "checkFemale";
            this.checkFemale.Size = new System.Drawing.Size(60, 17);
            this.checkFemale.TabIndex = 9;
            this.checkFemale.Text = "Female";
            this.checkFemale.UseVisualStyleBackColor = true;
            // 
            // checkBoxRareItems
            // 
            this.checkBoxRareItems.AutoSize = true;
            this.checkBoxRareItems.Location = new System.Drawing.Point(16, 69);
            this.checkBoxRareItems.Name = "checkBoxRareItems";
            this.checkBoxRareItems.Size = new System.Drawing.Size(76, 17);
            this.checkBoxRareItems.TabIndex = 40;
            this.checkBoxRareItems.Text = "Rare (Sox)";
            this.checkBoxRareItems.UseVisualStyleBackColor = true;
            // 
            // checkMale
            // 
            this.checkMale.AutoSize = true;
            this.checkMale.Location = new System.Drawing.Point(16, 23);
            this.checkMale.Name = "checkMale";
            this.checkMale.Size = new System.Drawing.Size(49, 17);
            this.checkMale.TabIndex = 9;
            this.checkMale.Text = "Male";
            this.checkMale.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 31;
            this.label3.Text = "Degree:";
            // 
            // numDegreeFrom
            // 
            this.numDegreeFrom.Location = new System.Drawing.Point(72, 94);
            this.numDegreeFrom.Name = "numDegreeFrom";
            this.numDegreeFrom.Size = new System.Drawing.Size(39, 20);
            this.numDegreeFrom.TabIndex = 32;
            // 
            // numDegreeTo
            // 
            this.numDegreeTo.Location = new System.Drawing.Point(140, 94);
            this.numDegreeTo.Name = "numDegreeTo";
            this.numDegreeTo.Size = new System.Drawing.Size(39, 20);
            this.numDegreeTo.TabIndex = 34;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.ForeColor = System.Drawing.Color.Gray;
            this.label4.Location = new System.Drawing.Point(116, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(18, 19);
            this.label4.TabIndex = 33;
            this.label4.Text = "~";
            this.label4.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(255)))));
            this.panel3.Controls.Add(this.panel7);
            this.panel3.Controls.Add(this.labelResult);
            this.panel3.Controls.Add(this.btnResetFilter);
            this.panel3.Controls.Add(this.btnSearch);
            this.panel3.Controls.Add(this.btnReload);
            this.panel3.Controls.Add(this.txtSellSearch);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 396);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(734, 36);
            this.panel3.TabIndex = 40;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Margin = new System.Windows.Forms.Padding(0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(734, 1);
            this.panel7.TabIndex = 41;
            // 
            // labelResult
            // 
            this.labelResult.AutoSize = true;
            this.labelResult.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelResult.Location = new System.Drawing.Point(280, 11);
            this.labelResult.Name = "labelResult";
            this.labelResult.Size = new System.Drawing.Size(0, 15);
            this.labelResult.TabIndex = 40;
            // 
            // btnResetFilter
            // 
            this.btnResetFilter.Location = new System.Drawing.Point(12, 7);
            this.btnResetFilter.Name = "btnResetFilter";
            this.btnResetFilter.Size = new System.Drawing.Size(96, 23);
            this.btnResetFilter.TabIndex = 39;
            this.btnResetFilter.Text = "Reset";
            this.btnResetFilter.UseVisualStyleBackColor = true;
            this.btnResetFilter.Click += new System.EventHandler(this.btnResetFilter_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSearch.Location = new System.Drawing.Point(655, 7);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 21;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // btnReload
            // 
            this.btnReload.Location = new System.Drawing.Point(112, 7);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(137, 23);
            this.btnReload.TabIndex = 39;
            this.btnReload.Text = "Apply";
            this.btnReload.UseVisualStyleBackColor = true;
            this.btnReload.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // txtSellSearch
            // 
            this.txtSellSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSellSearch.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtSellSearch.Location = new System.Drawing.Point(430, 7);
            this.txtSellSearch.Name = "txtSellSearch";
            this.txtSellSearch.Size = new System.Drawing.Size(221, 23);
            this.txtSellSearch.TabIndex = 20;
            this.txtSellSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSellSearch_KeyDown);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::RSBot.Shopping.Properties.Resources.loading;
            this.pictureBox1.Location = new System.Drawing.Point(465, 149);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(121, 69);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 22;
            this.pictureBox1.TabStop = false;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox7);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(734, 432);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "Pickup settings";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.cbDontPickupWhileBotting);
            this.groupBox7.Controls.Add(this.cbJustpickmyitems);
            this.groupBox7.Controls.Add(this.checkDontPickupInBerzerk);
            this.groupBox7.Controls.Add(this.checkEnableAbilityPet);
            this.groupBox7.Controls.Add(this.checkPickupRare);
            this.groupBox7.Controls.Add(this.checkPickupGold);
            this.groupBox7.Location = new System.Drawing.Point(6, 6);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(481, 99);
            this.groupBox7.TabIndex = 0;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "General";
            // 
            // cbDontPickupWhileBotting
            // 
            this.cbDontPickupWhileBotting.AutoSize = true;
            this.cbDontPickupWhileBotting.Location = new System.Drawing.Point(263, 72);
            this.cbDontPickupWhileBotting.Name = "cbDontPickupWhileBotting";
            this.cbDontPickupWhileBotting.Size = new System.Drawing.Size(175, 17);
            this.cbDontPickupWhileBotting.TabIndex = 3;
            this.cbDontPickupWhileBotting.Text = "Don\'t pickup items while botting";
            this.cbDontPickupWhileBotting.UseVisualStyleBackColor = true;
            this.cbDontPickupWhileBotting.CheckedChanged += new System.EventHandler(this.cbDontPickupWhileBotting_CheckedChanged);
            // 
            // cbJustpickmyitems
            // 
            this.cbJustpickmyitems.AutoSize = true;
            this.cbJustpickmyitems.Location = new System.Drawing.Point(263, 47);
            this.cbJustpickmyitems.Name = "cbJustpickmyitems";
            this.cbJustpickmyitems.Size = new System.Drawing.Size(111, 17);
            this.cbJustpickmyitems.TabIndex = 1;
            this.cbJustpickmyitems.Text = "Just pick my items";
            this.cbJustpickmyitems.UseVisualStyleBackColor = true;
            this.cbJustpickmyitems.CheckedChanged += new System.EventHandler(this.cbJustpickmyitems_CheckedChanged);
            // 
            // checkDontPickupInBerzerk
            // 
            this.checkDontPickupInBerzerk.AutoSize = true;
            this.checkDontPickupInBerzerk.Location = new System.Drawing.Point(263, 22);
            this.checkDontPickupInBerzerk.Name = "checkDontPickupInBerzerk";
            this.checkDontPickupInBerzerk.Size = new System.Drawing.Size(191, 17);
            this.checkDontPickupInBerzerk.TabIndex = 2;
            this.checkDontPickupInBerzerk.Text = "Don\'t pickup items in berzerk mode";
            this.checkDontPickupInBerzerk.UseVisualStyleBackColor = true;
            this.checkDontPickupInBerzerk.CheckedChanged += new System.EventHandler(this.checkDontPickupInBerzerk_CheckedChanged);
            // 
            // checkEnableAbilityPet
            // 
            this.checkEnableAbilityPet.AutoSize = true;
            this.checkEnableAbilityPet.Location = new System.Drawing.Point(15, 72);
            this.checkEnableAbilityPet.Name = "checkEnableAbilityPet";
            this.checkEnableAbilityPet.Size = new System.Drawing.Size(169, 17);
            this.checkEnableAbilityPet.TabIndex = 1;
            this.checkEnableAbilityPet.Text = "Use ability pet to pickup items ";
            this.checkEnableAbilityPet.UseVisualStyleBackColor = true;
            this.checkEnableAbilityPet.CheckedChanged += new System.EventHandler(this.checkEnableAbilityPet_CheckedChanged);
            // 
            // checkPickupRare
            // 
            this.checkPickupRare.AutoSize = true;
            this.checkPickupRare.Location = new System.Drawing.Point(15, 47);
            this.checkPickupRare.Name = "checkPickupRare";
            this.checkPickupRare.Size = new System.Drawing.Size(142, 17);
            this.checkPickupRare.TabIndex = 1;
            this.checkPickupRare.Text = "Always pickup rare items";
            this.checkPickupRare.UseVisualStyleBackColor = true;
            this.checkPickupRare.CheckedChanged += new System.EventHandler(this.checkPickupRare_CheckedChanged);
            // 
            // checkPickupGold
            // 
            this.checkPickupGold.AutoSize = true;
            this.checkPickupGold.Location = new System.Drawing.Point(15, 22);
            this.checkPickupGold.Name = "checkPickupGold";
            this.checkPickupGold.Size = new System.Drawing.Size(82, 17);
            this.checkPickupGold.TabIndex = 0;
            this.checkPickupGold.Text = "Pickup gold";
            this.checkPickupGold.UseVisualStyleBackColor = true;
            this.checkPickupGold.CheckedChanged += new System.EventHandler(this.checkPickupGold_CheckedChanged);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.tabMain);
            this.DoubleBuffered = true;
            this.Name = "Main";
            this.Padding = new System.Windows.Forms.Padding(6);
            this.Size = new System.Drawing.Size(754, 473);
            this.contextShoppingList.ResumeLayout(false);
            this.contextAvailableProducts.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabMain.ResumeLayout(false);
            this.tabBuyFilter.ResumeLayout(false);
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
        private System.Windows.Forms.ComboBox comboStore;
        private System.Windows.Forms.ListView listShoppingList;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colAmount;
        private System.Windows.Forms.ListView listAvailableProducts;
        private System.Windows.Forms.ColumnHeader colAvailableName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ContextMenuStrip contextAvailableProducts;
        private System.Windows.Forms.ToolStripMenuItem menuAddToShoppingList;
        private System.Windows.Forms.ContextMenuStrip contextShoppingList;
        private System.Windows.Forms.ToolStripMenuItem menuChangeAmount;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem menuRemoveItem;
        private RSBot.Theme.Controls.TabControl tabMain;
        private System.Windows.Forms.TabPage tabBuyFilter;
        private System.Windows.Forms.TabPage tabSellFilter;
        private System.Windows.Forms.TextBox txtShopSearch;
        private System.Windows.Forms.ListView listFilter;
        private System.Windows.Forms.ColumnHeader colItemName;
        private System.Windows.Forms.ColumnHeader colItemLevel;
        private System.Windows.Forms.ColumnHeader colSell;
        private System.Windows.Forms.ColumnHeader collStore;
        private System.Windows.Forms.TextBox txtSellSearch;
        private System.Windows.Forms.ColumnHeader colGender;
        private System.Windows.Forms.ContextMenuStrip contextList;
        private System.Windows.Forms.ToolStripMenuItem btnAddToSell;
        private System.Windows.Forms.ToolStripMenuItem btnAddToStore;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem btnDontSell;
        private System.Windows.Forms.ToolStripMenuItem btnDontStore;
        private System.Windows.Forms.Panel filterPanel;
        private System.Windows.Forms.GroupBox groupOthers;
        private System.Windows.Forms.CheckBox checkAlchemy;
        private System.Windows.Forms.CheckBox checkOther;
        private System.Windows.Forms.GroupBox groupClothes;
        private System.Windows.Forms.GroupBox groupWeapons;
        private System.Windows.Forms.Button btnReload;
        private System.Windows.Forms.CheckBox checkBlade;
        private System.Windows.Forms.CheckBox checkSword;
        private System.Windows.Forms.CheckBox checkSpear;
        private System.Windows.Forms.CheckBox checkGlave;
        private System.Windows.Forms.CheckBox checkBow;
        private System.Windows.Forms.CheckBox check2HSword;
        private System.Windows.Forms.CheckBox check1HSword;
        private System.Windows.Forms.CheckBox checkStaff;
        private System.Windows.Forms.CheckBox checkWRod;
        private System.Windows.Forms.CheckBox checkCRod;
        private System.Windows.Forms.CheckBox checkXBow;
        private System.Windows.Forms.CheckBox checkHarp;
        private System.Windows.Forms.CheckBox checkDagger;
        private System.Windows.Forms.CheckBox checkHead;
        private System.Windows.Forms.CheckBox checkBoot;
        private System.Windows.Forms.CheckBox checkChest;
        private System.Windows.Forms.CheckBox checkShoulder;
        private System.Windows.Forms.CheckBox checkShield;
        private System.Windows.Forms.GroupBox groupAccessories;
        private System.Windows.Forms.CheckBox checkEarring;
        private System.Windows.Forms.CheckBox checkRing;
        private System.Windows.Forms.CheckBox checkNecklace;
        private System.Windows.Forms.GroupBox groupGender;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numDegreeFrom;
        private System.Windows.Forms.NumericUpDown numDegreeTo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkLight;
        private System.Windows.Forms.CheckBox checkClothes;
        private System.Windows.Forms.CheckBox checkHeavy;
        private System.Windows.Forms.CheckBox checkAxe;
        private System.Windows.Forms.CheckBox checkLegs;
        private System.Windows.Forms.CheckBox checkHand;
        private System.Windows.Forms.ToolStripMenuItem btnPickup;
        private System.Windows.Forms.ToolStripMenuItem btnDontPickup;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.CheckBox checkPickupGold;
        private System.Windows.Forms.ColumnHeader colPickup;
        private System.Windows.Forms.CheckBox checkPickupRare;
        private System.Windows.Forms.CheckBox checkEnableAbilityPet;
        private System.Windows.Forms.Button btnResetFilter;
        private System.Windows.Forms.ImageList imgShoppingListNPC;
        private System.Windows.Forms.ImageList imgShoppingList;
        private System.Windows.Forms.CheckBox checkShowEquipment;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkSellItemsFromPet;
        private System.Windows.Forms.CheckBox checkRepairGear;
        private System.Windows.Forms.CheckBox checkEnable;
        private System.Windows.Forms.CheckBox checkDontPickupInBerzerk;
        private System.Windows.Forms.CheckBox cbJustpickmyitems;
        private System.Windows.Forms.CheckBox cbDontPickupWhileBotting;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label labelResult;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.CheckBox checkBoxRareItems;
        private System.Windows.Forms.ImageList searchImageList;
        private System.Windows.Forms.CheckBox checkEuropean;
        private System.Windows.Forms.CheckBox checkChinese;
        private System.Windows.Forms.CheckBox checkFemale;
        private System.Windows.Forms.CheckBox checkMale;
        private System.Windows.Forms.CheckBox checkQuest;
        private System.Windows.Forms.CheckBox checkCoin;
        private System.Windows.Forms.CheckBox checkAmmo;
    }
}
