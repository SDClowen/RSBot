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
            this.listShoppingList = new Theme.Controls.ListView();
            this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAmount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextShoppingList = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuChangeAmount = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuRemoveItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imgShoppingList = new System.Windows.Forms.ImageList(this.components);
            this.listAvailableProducts = new Theme.Controls.ListView();
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
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabBuyFilter = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkSellItemsFromPet = new System.Windows.Forms.CheckBox();
            this.checkRepairGear = new System.Windows.Forms.CheckBox();
            this.checkEnable = new System.Windows.Forms.CheckBox();
            this.tabSellFilter = new System.Windows.Forms.TabPage();
            this.btnSearch = new Theme.Material.Button();
            this.txtSellSearch = new System.Windows.Forms.TextBox();
            this.listSellFilter = new Theme.Controls.ListView();
            this.colItemName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colItemLevel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colGender = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSell = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.collStore = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPickup = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextSellList = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnAddToSell = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAddToStore = new System.Windows.Forms.ToolStripMenuItem();
            this.btnPickup = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnDontSell = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDontStore = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDontPickup = new System.Windows.Forms.ToolStripMenuItem();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnResetFilter = new Theme.Material.Button();
            this.groupGender = new System.Windows.Forms.GroupBox();
            this.checkChinese = new System.Windows.Forms.CheckBox();
            this.checkEuropean = new System.Windows.Forms.CheckBox();
            this.checkMale = new System.Windows.Forms.CheckBox();
            this.checkFemale = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.numDegreeFrom = new System.Windows.Forms.NumericUpDown();
            this.numDegreeTo = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.groupAccessories = new System.Windows.Forms.GroupBox();
            this.checkNecklace = new System.Windows.Forms.CheckBox();
            this.checkEarring = new System.Windows.Forms.CheckBox();
            this.checkRing = new System.Windows.Forms.CheckBox();
            this.groupOthers = new System.Windows.Forms.GroupBox();
            this.checkAll = new System.Windows.Forms.CheckBox();
            this.checkAlchemy = new System.Windows.Forms.CheckBox();
            this.checkOthers = new System.Windows.Forms.CheckBox();
            this.groupEquipment = new System.Windows.Forms.GroupBox();
            this.checkHand = new System.Windows.Forms.CheckBox();
            this.checkLegs = new System.Windows.Forms.CheckBox();
            this.checkArmor = new System.Windows.Forms.CheckBox();
            this.checkProtector = new System.Windows.Forms.CheckBox();
            this.checkGarment = new System.Windows.Forms.CheckBox();
            this.checkShield = new System.Windows.Forms.CheckBox();
            this.checkBoot = new System.Windows.Forms.CheckBox();
            this.checkChest = new System.Windows.Forms.CheckBox();
            this.checkShoulder = new System.Windows.Forms.CheckBox();
            this.checkHead = new System.Windows.Forms.CheckBox();
            this.groupWeapons = new System.Windows.Forms.GroupBox();
            this.checkAxe = new System.Windows.Forms.CheckBox();
            this.checkHarp = new System.Windows.Forms.CheckBox();
            this.checkDagger = new System.Windows.Forms.CheckBox();
            this.checkXBow = new System.Windows.Forms.CheckBox();
            this.checkWRod = new System.Windows.Forms.CheckBox();
            this.checkCRod = new System.Windows.Forms.CheckBox();
            this.check2HSword = new System.Windows.Forms.CheckBox();
            this.check1HSword = new System.Windows.Forms.CheckBox();
            this.checkStaff = new System.Windows.Forms.CheckBox();
            this.checkBow = new System.Windows.Forms.CheckBox();
            this.checkSpear = new System.Windows.Forms.CheckBox();
            this.checkGlave = new System.Windows.Forms.CheckBox();
            this.checkSword = new System.Windows.Forms.CheckBox();
            this.checkBlade = new System.Windows.Forms.CheckBox();
            this.btnReload = new Theme.Material.Button();
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
            this.contextSellList.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupGender.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDegreeFrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDegreeTo)).BeginInit();
            this.groupAccessories.SuspendLayout();
            this.groupOthers.SuspendLayout();
            this.groupEquipment.SuspendLayout();
            this.groupWeapons.SuspendLayout();
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
            this.contextShoppingList.Size = new System.Drawing.Size(161, 54);
            // 
            // menuChangeAmount
            // 
            this.menuChangeAmount.Name = "menuChangeAmount";
            this.menuChangeAmount.Size = new System.Drawing.Size(160, 22);
            this.menuChangeAmount.Text = "Change amount";
            this.menuChangeAmount.Click += new System.EventHandler(this.menuChangeAmount_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(157, 6);
            // 
            // menuRemoveItem
            // 
            this.menuRemoveItem.Name = "menuRemoveItem";
            this.menuRemoveItem.Size = new System.Drawing.Size(160, 22);
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
            this.contextAvailableProducts.Size = new System.Drawing.Size(182, 26);
            // 
            // menuAddToShoppingList
            // 
            this.menuAddToShoppingList.Name = "menuAddToShoppingList";
            this.menuAddToShoppingList.Size = new System.Drawing.Size(181, 22);
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
            this.tabBuyFilter.Location = new System.Drawing.Point(4, 22);
            this.tabBuyFilter.Name = "tabBuyFilter";
            this.tabBuyFilter.Padding = new System.Windows.Forms.Padding(3);
            this.tabBuyFilter.Size = new System.Drawing.Size(734, 429);
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
            this.tabSellFilter.Controls.Add(this.btnSearch);
            this.tabSellFilter.Controls.Add(this.txtSellSearch);
            this.tabSellFilter.Controls.Add(this.listSellFilter);
            this.tabSellFilter.Controls.Add(this.panel3);
            this.tabSellFilter.Controls.Add(this.pictureBox1);
            this.tabSellFilter.Location = new System.Drawing.Point(4, 22);
            this.tabSellFilter.Name = "tabSellFilter";
            this.tabSellFilter.Padding = new System.Windows.Forms.Padding(3);
            this.tabSellFilter.Size = new System.Drawing.Size(734, 435);
            this.tabSellFilter.TabIndex = 1;
            this.tabSellFilter.Text = "Item filter";
            this.tabSellFilter.UseVisualStyleBackColor = true;
            // 
            // btnSearch
            // 
            this.btnSearch.Depth = 0;
            this.btnSearch.Icon = null;
            this.btnSearch.Location = new System.Drawing.Point(657, 406);
            this.btnSearch.MouseState = Theme.IMatMouseState.HOVER;
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Primary = false;
            this.btnSearch.Raised = false;
            this.btnSearch.SingleColor = System.Drawing.Color.Empty;
            this.btnSearch.Size = new System.Drawing.Size(75, 24);
            this.btnSearch.TabIndex = 21;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSellSearch
            // 
            this.txtSellSearch.Location = new System.Drawing.Point(423, 407);
            this.txtSellSearch.Name = "txtSellSearch";
            this.txtSellSearch.Size = new System.Drawing.Size(232, 20);
            this.txtSellSearch.TabIndex = 20;
            // 
            // listSellFilter
            // 
            this.listSellFilter.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colItemName,
            this.colItemLevel,
            this.colGender,
            this.colSell,
            this.collStore,
            this.colPickup});
            this.listSellFilter.ContextMenuStrip = this.contextSellList;
            this.listSellFilter.FullRowSelect = true;
            this.listSellFilter.Location = new System.Drawing.Point(290, 13);
            this.listSellFilter.Name = "listSellFilter";
            this.listSellFilter.Size = new System.Drawing.Size(442, 388);
            this.listSellFilter.TabIndex = 5;
            this.listSellFilter.UseCompatibleStateImageBehavior = false;
            this.listSellFilter.View = System.Windows.Forms.View.Details;
            // 
            // colItemName
            // 
            this.colItemName.Text = "Name";
            this.colItemName.Width = 119;
            // 
            // colItemLevel
            // 
            this.colItemLevel.Text = "Level";
            // 
            // colGender
            // 
            this.colGender.Text = "Gender";
            this.colGender.Width = 79;
            // 
            // colSell
            // 
            this.colSell.DisplayIndex = 4;
            this.colSell.Text = "Sell";
            // 
            // collStore
            // 
            this.collStore.DisplayIndex = 5;
            this.collStore.Text = "Store";
            // 
            // colPickup
            // 
            this.colPickup.DisplayIndex = 3;
            this.colPickup.Text = "Pickup";
            // 
            // contextSellList
            // 
            this.contextSellList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAddToSell,
            this.btnAddToStore,
            this.btnPickup,
            this.toolStripSeparator2,
            this.btnDontSell,
            this.btnDontStore,
            this.btnDontPickup});
            this.contextSellList.Name = "contextSellList";
            this.contextSellList.Size = new System.Drawing.Size(143, 142);
            // 
            // btnAddToSell
            // 
            this.btnAddToSell.Name = "btnAddToSell";
            this.btnAddToSell.Size = new System.Drawing.Size(142, 22);
            this.btnAddToSell.Text = "Sell";
            this.btnAddToSell.Click += new System.EventHandler(this.btnAddToSell_Click);
            // 
            // btnAddToStore
            // 
            this.btnAddToStore.Name = "btnAddToStore";
            this.btnAddToStore.Size = new System.Drawing.Size(142, 22);
            this.btnAddToStore.Text = "Store";
            this.btnAddToStore.Click += new System.EventHandler(this.btnAddToStore_Click);
            // 
            // btnPickup
            // 
            this.btnPickup.Name = "btnPickup";
            this.btnPickup.Size = new System.Drawing.Size(142, 22);
            this.btnPickup.Text = "Pickup";
            this.btnPickup.Click += new System.EventHandler(this.btnPickup_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(139, 6);
            // 
            // btnDontSell
            // 
            this.btnDontSell.Name = "btnDontSell";
            this.btnDontSell.Size = new System.Drawing.Size(142, 22);
            this.btnDontSell.Text = "Don\'t sell";
            this.btnDontSell.Click += new System.EventHandler(this.btnDontSell_Click);
            // 
            // btnDontStore
            // 
            this.btnDontStore.Name = "btnDontStore";
            this.btnDontStore.Size = new System.Drawing.Size(142, 22);
            this.btnDontStore.Text = "Don\'t store";
            this.btnDontStore.Click += new System.EventHandler(this.btnDontStore_Click);
            // 
            // btnDontPickup
            // 
            this.btnDontPickup.Name = "btnDontPickup";
            this.btnDontPickup.Size = new System.Drawing.Size(142, 22);
            this.btnDontPickup.Text = "Don\'t pickup";
            this.btnDontPickup.Click += new System.EventHandler(this.btnDontPickup_Click);
            // 
            // panel3
            // 
            this.panel3.AutoScroll = true;
            this.panel3.Controls.Add(this.btnResetFilter);
            this.panel3.Controls.Add(this.groupGender);
            this.panel3.Controls.Add(this.groupAccessories);
            this.panel3.Controls.Add(this.groupOthers);
            this.panel3.Controls.Add(this.groupEquipment);
            this.panel3.Controls.Add(this.groupWeapons);
            this.panel3.Controls.Add(this.btnReload);
            this.panel3.Location = new System.Drawing.Point(2, 6);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(282, 424);
            this.panel3.TabIndex = 20;
            // 
            // btnResetFilter
            // 
            this.btnResetFilter.Depth = 0;
            this.btnResetFilter.Icon = null;
            this.btnResetFilter.Location = new System.Drawing.Point(12, 675);
            this.btnResetFilter.MouseState = Theme.IMatMouseState.HOVER;
            this.btnResetFilter.Name = "btnResetFilter";
            this.btnResetFilter.Primary = false;
            this.btnResetFilter.Raised = false;
            this.btnResetFilter.SingleColor = System.Drawing.Color.Empty;
            this.btnResetFilter.Size = new System.Drawing.Size(75, 23);
            this.btnResetFilter.TabIndex = 39;
            this.btnResetFilter.Text = "Reset";
            this.btnResetFilter.UseVisualStyleBackColor = true;
            this.btnResetFilter.Click += new System.EventHandler(this.btnResetFilter_Click);
            // 
            // groupGender
            // 
            this.groupGender.Controls.Add(this.checkChinese);
            this.groupGender.Controls.Add(this.checkEuropean);
            this.groupGender.Controls.Add(this.checkMale);
            this.groupGender.Controls.Add(this.checkFemale);
            this.groupGender.Controls.Add(this.label3);
            this.groupGender.Controls.Add(this.numDegreeFrom);
            this.groupGender.Controls.Add(this.numDegreeTo);
            this.groupGender.Controls.Add(this.label4);
            this.groupGender.Location = new System.Drawing.Point(12, 3);
            this.groupGender.Name = "groupGender";
            this.groupGender.Size = new System.Drawing.Size(236, 112);
            this.groupGender.TabIndex = 44;
            this.groupGender.TabStop = false;
            this.groupGender.Text = "Gender and Degree";
            // 
            // checkChinese
            // 
            this.checkChinese.AutoSize = true;
            this.checkChinese.Location = new System.Drawing.Point(11, 43);
            this.checkChinese.Name = "checkChinese";
            this.checkChinese.Size = new System.Drawing.Size(64, 17);
            this.checkChinese.TabIndex = 38;
            this.checkChinese.Text = "Chinese";
            this.checkChinese.UseVisualStyleBackColor = true;
            // 
            // checkEuropean
            // 
            this.checkEuropean.AutoSize = true;
            this.checkEuropean.Location = new System.Drawing.Point(99, 43);
            this.checkEuropean.Name = "checkEuropean";
            this.checkEuropean.Size = new System.Drawing.Size(72, 17);
            this.checkEuropean.TabIndex = 37;
            this.checkEuropean.Text = "European";
            this.checkEuropean.UseVisualStyleBackColor = true;
            // 
            // checkMale
            // 
            this.checkMale.AutoSize = true;
            this.checkMale.Location = new System.Drawing.Point(11, 22);
            this.checkMale.Name = "checkMale";
            this.checkMale.Size = new System.Drawing.Size(49, 17);
            this.checkMale.TabIndex = 36;
            this.checkMale.Text = "Male";
            this.checkMale.UseVisualStyleBackColor = true;
            // 
            // checkFemale
            // 
            this.checkFemale.AutoSize = true;
            this.checkFemale.Location = new System.Drawing.Point(99, 22);
            this.checkFemale.Name = "checkFemale";
            this.checkFemale.Size = new System.Drawing.Size(60, 17);
            this.checkFemale.TabIndex = 35;
            this.checkFemale.Text = "Female";
            this.checkFemale.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 31;
            this.label3.Text = "Degree:";
            // 
            // numDegreeFrom
            // 
            this.numDegreeFrom.Location = new System.Drawing.Point(79, 77);
            this.numDegreeFrom.Name = "numDegreeFrom";
            this.numDegreeFrom.Size = new System.Drawing.Size(39, 20);
            this.numDegreeFrom.TabIndex = 32;
            // 
            // numDegreeTo
            // 
            this.numDegreeTo.Location = new System.Drawing.Point(148, 77);
            this.numDegreeTo.Name = "numDegreeTo";
            this.numDegreeTo.Size = new System.Drawing.Size(39, 20);
            this.numDegreeTo.TabIndex = 34;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(124, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(16, 13);
            this.label4.TabIndex = 33;
            this.label4.Text = "to";
            // 
            // groupAccessories
            // 
            this.groupAccessories.Controls.Add(this.checkNecklace);
            this.groupAccessories.Controls.Add(this.checkEarring);
            this.groupAccessories.Controls.Add(this.checkRing);
            this.groupAccessories.Location = new System.Drawing.Point(12, 486);
            this.groupAccessories.Name = "groupAccessories";
            this.groupAccessories.Size = new System.Drawing.Size(236, 76);
            this.groupAccessories.TabIndex = 44;
            this.groupAccessories.TabStop = false;
            this.groupAccessories.Text = "Accessories";
            // 
            // checkNecklace
            // 
            this.checkNecklace.AutoSize = true;
            this.checkNecklace.Location = new System.Drawing.Point(99, 22);
            this.checkNecklace.Name = "checkNecklace";
            this.checkNecklace.Size = new System.Drawing.Size(72, 17);
            this.checkNecklace.TabIndex = 4;
            this.checkNecklace.Text = "Necklace";
            this.checkNecklace.UseVisualStyleBackColor = true;
            // 
            // checkEarring
            // 
            this.checkEarring.AutoSize = true;
            this.checkEarring.Location = new System.Drawing.Point(11, 47);
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
            // groupOthers
            // 
            this.groupOthers.Controls.Add(this.checkAll);
            this.groupOthers.Controls.Add(this.checkAlchemy);
            this.groupOthers.Controls.Add(this.checkOthers);
            this.groupOthers.Location = new System.Drawing.Point(12, 567);
            this.groupOthers.Name = "groupOthers";
            this.groupOthers.Size = new System.Drawing.Size(236, 104);
            this.groupOthers.TabIndex = 42;
            this.groupOthers.TabStop = false;
            this.groupOthers.Text = "Others";
            // 
            // checkAll
            // 
            this.checkAll.AutoSize = true;
            this.checkAll.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkAll.Location = new System.Drawing.Point(11, 74);
            this.checkAll.Name = "checkAll";
            this.checkAll.Size = new System.Drawing.Size(205, 19);
            this.checkAll.TabIndex = 20;
            this.checkAll.Text = "All items (may take some seconds)";
            this.checkAll.UseVisualStyleBackColor = true;
            // 
            // checkAlchemy
            // 
            this.checkAlchemy.AutoSize = true;
            this.checkAlchemy.Location = new System.Drawing.Point(11, 24);
            this.checkAlchemy.Name = "checkAlchemy";
            this.checkAlchemy.Size = new System.Drawing.Size(66, 17);
            this.checkAlchemy.TabIndex = 19;
            this.checkAlchemy.Text = "Alchemy";
            this.checkAlchemy.UseVisualStyleBackColor = true;
            // 
            // checkOthers
            // 
            this.checkOthers.AutoSize = true;
            this.checkOthers.Location = new System.Drawing.Point(11, 49);
            this.checkOthers.Name = "checkOthers";
            this.checkOthers.Size = new System.Drawing.Size(98, 17);
            this.checkOthers.TabIndex = 19;
            this.checkOthers.Text = "Everything else";
            this.checkOthers.UseVisualStyleBackColor = true;
            // 
            // groupEquipment
            // 
            this.groupEquipment.Controls.Add(this.checkHand);
            this.groupEquipment.Controls.Add(this.checkLegs);
            this.groupEquipment.Controls.Add(this.checkArmor);
            this.groupEquipment.Controls.Add(this.checkProtector);
            this.groupEquipment.Controls.Add(this.checkGarment);
            this.groupEquipment.Controls.Add(this.checkShield);
            this.groupEquipment.Controls.Add(this.checkBoot);
            this.groupEquipment.Controls.Add(this.checkChest);
            this.groupEquipment.Controls.Add(this.checkShoulder);
            this.groupEquipment.Controls.Add(this.checkHead);
            this.groupEquipment.Location = new System.Drawing.Point(12, 327);
            this.groupEquipment.Name = "groupEquipment";
            this.groupEquipment.Size = new System.Drawing.Size(236, 154);
            this.groupEquipment.TabIndex = 41;
            this.groupEquipment.TabStop = false;
            this.groupEquipment.Text = "Equipment";
            // 
            // checkHand
            // 
            this.checkHand.AutoSize = true;
            this.checkHand.Location = new System.Drawing.Point(99, 107);
            this.checkHand.Name = "checkHand";
            this.checkHand.Size = new System.Drawing.Size(52, 17);
            this.checkHand.TabIndex = 8;
            this.checkHand.Text = "Hand";
            this.checkHand.UseVisualStyleBackColor = true;
            // 
            // checkLegs
            // 
            this.checkLegs.AutoSize = true;
            this.checkLegs.Location = new System.Drawing.Point(11, 107);
            this.checkLegs.Name = "checkLegs";
            this.checkLegs.Size = new System.Drawing.Size(44, 17);
            this.checkLegs.TabIndex = 7;
            this.checkLegs.Text = "Leg";
            this.checkLegs.UseVisualStyleBackColor = true;
            // 
            // checkArmor
            // 
            this.checkArmor.AutoSize = true;
            this.checkArmor.Location = new System.Drawing.Point(170, 22);
            this.checkArmor.Name = "checkArmor";
            this.checkArmor.Size = new System.Drawing.Size(53, 17);
            this.checkArmor.TabIndex = 6;
            this.checkArmor.Text = "Armor";
            this.checkArmor.UseVisualStyleBackColor = true;
            // 
            // checkProtector
            // 
            this.checkProtector.AutoSize = true;
            this.checkProtector.Location = new System.Drawing.Point(99, 22);
            this.checkProtector.Name = "checkProtector";
            this.checkProtector.Size = new System.Drawing.Size(48, 17);
            this.checkProtector.TabIndex = 6;
            this.checkProtector.Text = "Prot.";
            this.checkProtector.UseVisualStyleBackColor = true;
            // 
            // checkGarment
            // 
            this.checkGarment.AutoSize = true;
            this.checkGarment.Location = new System.Drawing.Point(11, 22);
            this.checkGarment.Name = "checkGarment";
            this.checkGarment.Size = new System.Drawing.Size(54, 17);
            this.checkGarment.TabIndex = 6;
            this.checkGarment.Text = "Garm.";
            this.checkGarment.UseVisualStyleBackColor = true;
            // 
            // checkShield
            // 
            this.checkShield.AutoSize = true;
            this.checkShield.Location = new System.Drawing.Point(11, 132);
            this.checkShield.Name = "checkShield";
            this.checkShield.Size = new System.Drawing.Size(55, 17);
            this.checkShield.TabIndex = 5;
            this.checkShield.Text = "Shield";
            this.checkShield.UseVisualStyleBackColor = true;
            // 
            // checkBoot
            // 
            this.checkBoot.AutoSize = true;
            this.checkBoot.Location = new System.Drawing.Point(99, 82);
            this.checkBoot.Name = "checkBoot";
            this.checkBoot.Size = new System.Drawing.Size(48, 17);
            this.checkBoot.TabIndex = 4;
            this.checkBoot.Text = "Boot";
            this.checkBoot.UseVisualStyleBackColor = true;
            // 
            // checkChest
            // 
            this.checkChest.AutoSize = true;
            this.checkChest.Location = new System.Drawing.Point(11, 82);
            this.checkChest.Name = "checkChest";
            this.checkChest.Size = new System.Drawing.Size(53, 17);
            this.checkChest.TabIndex = 4;
            this.checkChest.Text = "Chest";
            this.checkChest.UseVisualStyleBackColor = true;
            // 
            // checkShoulder
            // 
            this.checkShoulder.AutoSize = true;
            this.checkShoulder.Location = new System.Drawing.Point(99, 57);
            this.checkShoulder.Name = "checkShoulder";
            this.checkShoulder.Size = new System.Drawing.Size(68, 17);
            this.checkShoulder.TabIndex = 4;
            this.checkShoulder.Text = "Shoulder";
            this.checkShoulder.UseVisualStyleBackColor = true;
            // 
            // checkHead
            // 
            this.checkHead.AutoSize = true;
            this.checkHead.Location = new System.Drawing.Point(11, 57);
            this.checkHead.Name = "checkHead";
            this.checkHead.Size = new System.Drawing.Size(52, 17);
            this.checkHead.TabIndex = 4;
            this.checkHead.Text = "Head";
            this.checkHead.UseVisualStyleBackColor = true;
            // 
            // groupWeapons
            // 
            this.groupWeapons.Controls.Add(this.checkAxe);
            this.groupWeapons.Controls.Add(this.checkHarp);
            this.groupWeapons.Controls.Add(this.checkDagger);
            this.groupWeapons.Controls.Add(this.checkXBow);
            this.groupWeapons.Controls.Add(this.checkWRod);
            this.groupWeapons.Controls.Add(this.checkCRod);
            this.groupWeapons.Controls.Add(this.check2HSword);
            this.groupWeapons.Controls.Add(this.check1HSword);
            this.groupWeapons.Controls.Add(this.checkStaff);
            this.groupWeapons.Controls.Add(this.checkBow);
            this.groupWeapons.Controls.Add(this.checkSpear);
            this.groupWeapons.Controls.Add(this.checkGlave);
            this.groupWeapons.Controls.Add(this.checkSword);
            this.groupWeapons.Controls.Add(this.checkBlade);
            this.groupWeapons.Location = new System.Drawing.Point(12, 121);
            this.groupWeapons.Name = "groupWeapons";
            this.groupWeapons.Size = new System.Drawing.Size(236, 197);
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
            // btnReload
            // 
            this.btnReload.Depth = 0;
            this.btnReload.Icon = null;
            this.btnReload.Location = new System.Drawing.Point(91, 675);
            this.btnReload.MouseState = Theme.IMatMouseState.HOVER;
            this.btnReload.Name = "btnReload";
            this.btnReload.Primary = true;
            this.btnReload.Raised = true;
            this.btnReload.SingleColor = System.Drawing.Color.Empty;
            this.btnReload.Size = new System.Drawing.Size(157, 23);
            this.btnReload.TabIndex = 39;
            this.btnReload.Text = "Reload";
            this.btnReload.UseVisualStyleBackColor = true;
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
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
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(734, 429);
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
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
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
            this.tabSellFilter.PerformLayout();
            this.contextSellList.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.groupGender.ResumeLayout(false);
            this.groupGender.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDegreeFrom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDegreeTo)).EndInit();
            this.groupAccessories.ResumeLayout(false);
            this.groupAccessories.PerformLayout();
            this.groupOthers.ResumeLayout(false);
            this.groupOthers.PerformLayout();
            this.groupEquipment.ResumeLayout(false);
            this.groupEquipment.PerformLayout();
            this.groupWeapons.ResumeLayout(false);
            this.groupWeapons.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ComboBox comboStore;
        private Theme.Controls.ListView listShoppingList;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colAmount;
        private Theme.Controls.ListView listAvailableProducts;
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
        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabBuyFilter;
        private System.Windows.Forms.TabPage tabSellFilter;
        private System.Windows.Forms.TextBox txtShopSearch;
        private Theme.Controls.ListView listSellFilter;
        private System.Windows.Forms.ColumnHeader colItemName;
        private System.Windows.Forms.ColumnHeader colItemLevel;
        private System.Windows.Forms.ColumnHeader colSell;
        private System.Windows.Forms.ColumnHeader collStore;
        private System.Windows.Forms.TextBox txtSellSearch;
        private System.Windows.Forms.ColumnHeader colGender;
        private System.Windows.Forms.ContextMenuStrip contextSellList;
        private System.Windows.Forms.ToolStripMenuItem btnAddToSell;
        private System.Windows.Forms.ToolStripMenuItem btnAddToStore;
        private Theme.Material.Button btnSearch;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem btnDontSell;
        private System.Windows.Forms.ToolStripMenuItem btnDontStore;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.GroupBox groupOthers;
        private System.Windows.Forms.CheckBox checkAlchemy;
        private System.Windows.Forms.CheckBox checkOthers;
        private System.Windows.Forms.GroupBox groupEquipment;
        private System.Windows.Forms.GroupBox groupWeapons;
        private Theme.Material.Button btnReload;
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
        private System.Windows.Forms.CheckBox checkChinese;
        private System.Windows.Forms.CheckBox checkEuropean;
        private System.Windows.Forms.CheckBox checkMale;
        private System.Windows.Forms.CheckBox checkFemale;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numDegreeFrom;
        private System.Windows.Forms.NumericUpDown numDegreeTo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkProtector;
        private System.Windows.Forms.CheckBox checkGarment;
        private System.Windows.Forms.CheckBox checkArmor;
        private System.Windows.Forms.CheckBox checkAxe;
        private System.Windows.Forms.CheckBox checkLegs;
        private System.Windows.Forms.CheckBox checkHand;
        private System.Windows.Forms.ToolStripMenuItem btnPickup;
        private System.Windows.Forms.ToolStripMenuItem btnDontPickup;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.CheckBox checkAll;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.CheckBox checkPickupGold;
        private System.Windows.Forms.ColumnHeader colPickup;
        private System.Windows.Forms.CheckBox checkPickupRare;
        private System.Windows.Forms.CheckBox checkEnableAbilityPet;
        private Theme.Material.Button btnResetFilter;
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
    }
}
