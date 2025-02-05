using RSBot.Items.Properties;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace RSBot.Items.Views
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            components = new Container();
            ListViewGroup listViewGroup1 = new ListViewGroup("Potion trader", HorizontalAlignment.Left);
            ListViewGroup listViewGroup2 = new ListViewGroup("Stable keeper", HorizontalAlignment.Left);
            ListViewGroup listViewGroup3 = new ListViewGroup("Protector trader", HorizontalAlignment.Left);
            ListViewGroup listViewGroup4 = new ListViewGroup("Weapon trader", HorizontalAlignment.Left);
            ListViewGroup listViewGroup5 = new ListViewGroup("Accessory trader", HorizontalAlignment.Left);
            contextShoppingList = new ContextMenuStrip(components);
            menuChangeAmount = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            menuRemoveItem = new ToolStripMenuItem();
            contextAvailableProducts = new ContextMenuStrip(components);
            menuAddToShoppingList = new ToolStripMenuItem();
            tabMain = new TabControl();
            tabBuyFilter = new TabPage();
            splitContainer = new SplitContainer();
            listAvailableProducts = new ListView();
            colAvailableName = new ColumnHeader();
            panel1 = new Panel();
            label6 = new Label();
            checkShowEquipment = new CheckBox();
            txtShopSearch = new TextBox();
            comboStore = new ComboBox();
            label1 = new Label();
            listShoppingList = new ListView();
            colName = new ColumnHeader();
            colAmount = new ColumnHeader();
            panel2 = new Panel();
            groupBox1 = new GroupBox();
            checkSellItemsFromPet = new CheckBox();
            checkStoreItemsFromPet = new CheckBox();
            checkRepairGear = new CheckBox();
            checkEnable = new CheckBox();
            tabSellFilter = new TabPage();
            listFilter = new ListView();
            colItemName = new ColumnHeader();
            colItemLevel = new ColumnHeader();
            colGender = new ColumnHeader();
            colPickup = new ColumnHeader();
            colSell = new ColumnHeader();
            collStore = new ColumnHeader();
            contextList = new ContextMenuStrip(components);
            btnAddToSell = new ToolStripMenuItem();
            btnAddToStore = new ToolStripMenuItem();
            btnPickup = new ToolStripMenuItem();
            btnPickOnlyCharacter = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            btnDontSell = new ToolStripMenuItem();
            btnDontStore = new ToolStripMenuItem();
            btnDontPickup = new ToolStripMenuItem();
            searchImageList = new ImageList(components);
            filterPanel = new Panel();
            groupOthers = new GroupBox();
            checkAlchemy = new CheckBox();
            checkQuest = new CheckBox();
            checkAmmo = new CheckBox();
            checkCoin = new CheckBox();
            checkOther = new CheckBox();
            groupWeapons = new GroupBox();
            checkAxe = new CheckBox();
            checkHarp = new CheckBox();
            checkDagger = new CheckBox();
            checkXBow = new CheckBox();
            checkWRod = new CheckBox();
            checkShield = new CheckBox();
            checkCRod = new CheckBox();
            check2HSword = new CheckBox();
            check1HSword = new CheckBox();
            checkStaff = new CheckBox();
            checkBow = new CheckBox();
            checkSpear = new CheckBox();
            checkGlave = new CheckBox();
            checkSword = new CheckBox();
            checkBlade = new CheckBox();
            groupAccessories = new GroupBox();
            checkNecklace = new CheckBox();
            checkEarring = new CheckBox();
            checkRing = new CheckBox();
            groupClothes = new GroupBox();
            checkHand = new CheckBox();
            checkLegs = new CheckBox();
            checkHeavy = new CheckBox();
            checkLight = new CheckBox();
            checkClothes = new CheckBox();
            checkBoot = new CheckBox();
            checkChest = new CheckBox();
            checkShoulder = new CheckBox();
            checkHead = new CheckBox();
            groupGender = new GroupBox();
            checkEuropean = new CheckBox();
            checkChinese = new CheckBox();
            checkFemale = new CheckBox();
            checkBoxRareItems = new CheckBox();
            checkMale = new CheckBox();
            label3 = new Label();
            numDegreeFrom = new NumericUpDown();
            numDegreeTo = new NumericUpDown();
            label4 = new Label();
            panel3 = new Panel();
            panel7 = new Panel();
            labelResult = new Label();
            btnResetFilter = new Button();
            btnSearch = new Button();
            btnReload = new Button();
            txtSellSearch = new TextBox();
            pictureBox1 = new PictureBox();
            tabPage1 = new TabPage();
            groupBoxOptions = new GroupBox();
            checkPickupGold = new CheckBox();
            checkAllEquips = new CheckBox();
            checkEverything = new CheckBox();
            checkPickupRare = new CheckBox();
            checkQuestItems = new CheckBox();
            checkPickupBlue = new CheckBox();
            groupBoxGeneral = new GroupBox();
            cbDontPickupWhileBotting = new CheckBox();
            cbJustpickmyitems = new CheckBox();
            checkDontPickupInBerzerk = new CheckBox();
            checkEnableAbilityPet = new CheckBox();
            contextShoppingList.SuspendLayout();
            contextAvailableProducts.SuspendLayout();
            tabMain.SuspendLayout();
            tabBuyFilter.SuspendLayout();
            ((ISupportInitialize)splitContainer).BeginInit();
            splitContainer.Panel1.SuspendLayout();
            splitContainer.Panel2.SuspendLayout();
            splitContainer.SuspendLayout();
            panel1.SuspendLayout();
            groupBox1.SuspendLayout();
            tabSellFilter.SuspendLayout();
            contextList.SuspendLayout();
            filterPanel.SuspendLayout();
            groupOthers.SuspendLayout();
            groupWeapons.SuspendLayout();
            groupAccessories.SuspendLayout();
            groupClothes.SuspendLayout();
            groupGender.SuspendLayout();
            ((ISupportInitialize)numDegreeFrom).BeginInit();
            ((ISupportInitialize)numDegreeTo).BeginInit();
            panel3.SuspendLayout();
            ((ISupportInitialize)pictureBox1).BeginInit();
            tabPage1.SuspendLayout();
            groupBoxOptions.SuspendLayout();
            groupBoxGeneral.SuspendLayout();
            SuspendLayout();
            // 
            // contextShoppingList
            // 
            contextShoppingList.ImageScalingSize = new Size(20, 20);
            contextShoppingList.Items.AddRange(new ToolStripItem[] { menuChangeAmount, toolStripSeparator1, menuRemoveItem });
            contextShoppingList.Name = "contextShoppingList";
            contextShoppingList.ShowImageMargin = false;
            contextShoppingList.Size = new Size(159, 58);
            // 
            // menuChangeAmount
            // 
            menuChangeAmount.Name = "menuChangeAmount";
            menuChangeAmount.Size = new Size(158, 24);
            menuChangeAmount.Text = "Change amount";
            menuChangeAmount.Click += menuChangeAmount_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(155, 6);
            // 
            // menuRemoveItem
            // 
            menuRemoveItem.Name = "menuRemoveItem";
            menuRemoveItem.Size = new Size(158, 24);
            menuRemoveItem.Text = "Remove";
            menuRemoveItem.Click += menuRemoveItem_Click;
            // 
            // contextAvailableProducts
            // 
            contextAvailableProducts.ImageScalingSize = new Size(20, 20);
            contextAvailableProducts.Items.AddRange(new ToolStripItem[] { menuAddToShoppingList });
            contextAvailableProducts.Name = "contextAvailableProducts";
            contextAvailableProducts.ShowImageMargin = false;
            contextAvailableProducts.Size = new Size(189, 28);
            // 
            // menuAddToShoppingList
            // 
            menuAddToShoppingList.Name = "menuAddToShoppingList";
            menuAddToShoppingList.Size = new Size(188, 24);
            menuAddToShoppingList.Text = "Add to shopping list";
            menuAddToShoppingList.Click += menuAddToShoppingList_Click;
            // 
            // tabMain
            // 
            tabMain.Controls.Add(tabBuyFilter);
            tabMain.Controls.Add(tabSellFilter);
            tabMain.Controls.Add(tabPage1);
            tabMain.Dock = DockStyle.Fill;
            tabMain.ItemSize = new Size(80, 24);
            tabMain.Location = new Point(5, 5);
            tabMain.Margin = new Padding(4);
            tabMain.Name = "tabMain";
            tabMain.SelectedIndex = 0;
            tabMain.Size = new Size(932, 581);
            tabMain.TabIndex = 7;
            // 
            // tabBuyFilter
            // 
            tabBuyFilter.Controls.Add(splitContainer);
            tabBuyFilter.Controls.Add(groupBox1);
            tabBuyFilter.Location = new Point(4, 28);
            tabBuyFilter.Margin = new Padding(4);
            tabBuyFilter.Name = "tabBuyFilter";
            tabBuyFilter.Padding = new Padding(10);
            tabBuyFilter.Size = new Size(924, 549);
            tabBuyFilter.TabIndex = 0;
            tabBuyFilter.Text = "Shopping";
            // 
            // splitContainer
            // 
            splitContainer.Dock = DockStyle.Fill;
            splitContainer.Location = new Point(10, 10);
            splitContainer.Margin = new Padding(4);
            splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            splitContainer.Panel1.Controls.Add(listAvailableProducts);
            splitContainer.Panel1.Controls.Add(panel1);
            // 
            // splitContainer.Panel2
            // 
            splitContainer.Panel2.Controls.Add(listShoppingList);
            splitContainer.Panel2.Controls.Add(panel2);
            splitContainer.Size = new Size(904, 454);
            splitContainer.SplitterDistance = 420;
            splitContainer.SplitterWidth = 1;
            splitContainer.TabIndex = 6;
            // 
            // listAvailableProducts
            // 
            listAvailableProducts.BorderStyle = BorderStyle.None;
            listAvailableProducts.Columns.AddRange(new ColumnHeader[] { colAvailableName });
            listAvailableProducts.ContextMenuStrip = contextAvailableProducts;
            listAvailableProducts.Dock = DockStyle.Fill;
            listAvailableProducts.FullRowSelect = true;
            listAvailableProducts.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            listAvailableProducts.Location = new Point(0, 71);
            listAvailableProducts.Margin = new Padding(4);
            listAvailableProducts.Name = "listAvailableProducts";
            listAvailableProducts.Size = new Size(420, 383);
            listAvailableProducts.TabIndex = 4;
            listAvailableProducts.UseCompatibleStateImageBehavior = false;
            listAvailableProducts.View = System.Windows.Forms.View.Details;
            // 
            // colAvailableName
            // 
            colAvailableName.Text = "Name";
            colAvailableName.Width = 261;
            // 
            // panel1
            // 
            panel1.Controls.Add(label6);
            panel1.Controls.Add(checkShowEquipment);
            panel1.Controls.Add(txtShopSearch);
            panel1.Controls.Add(comboStore);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(4);
            panel1.Name = "panel1";
            panel1.Size = new Size(420, 71);
            panel1.TabIndex = 6;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(12, 39);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(56, 20);
            label6.TabIndex = 10;
            label6.Text = "Search:";
            // 
            // checkShowEquipment
            // 
            checkShowEquipment.AutoSize = true;
            checkShowEquipment.Location = new Point(265, 26);
            checkShowEquipment.Margin = new Padding(0);
            checkShowEquipment.Name = "checkShowEquipment";
            checkShowEquipment.Size = new Size(143, 24);
            checkShowEquipment.TabIndex = 9;
            checkShowEquipment.Text = "Show equipment";
            checkShowEquipment.UseVisualStyleBackColor = false;
            checkShowEquipment.CheckedChanged += checkShowEquipment_CheckedChanged;
            // 
            // txtShopSearch
            // 
            txtShopSearch.Location = new Point(76, 36);
            txtShopSearch.Margin = new Padding(4);
            txtShopSearch.Name = "txtShopSearch";
            txtShopSearch.Size = new Size(180, 27);
            txtShopSearch.TabIndex = 8;
            txtShopSearch.TextChanged += txtShopSearch_TextChanged;
            // 
            // comboStore
            // 
            comboStore.DropDownHeight = 100;
            comboStore.DropDownStyle = ComboBoxStyle.DropDownList;
            comboStore.FormattingEnabled = true;
            comboStore.IntegralHeight = false;
            comboStore.ItemHeight = 20;
            comboStore.Items.AddRange(new object[] { "Potion trader", "Stable keeper", "Protector trader", "Weapon trader", "Accessory trader" });
            comboStore.Location = new Point(76, 5);
            comboStore.Margin = new Padding(4);
            comboStore.Name = "comboStore";
            comboStore.Size = new Size(179, 28);
            comboStore.TabIndex = 2;
            comboStore.SelectedIndexChanged += comboStore_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(21, 8);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(47, 20);
            label1.TabIndex = 5;
            label1.Text = "Store:";
            // 
            // listShoppingList
            // 
            listShoppingList.BorderStyle = BorderStyle.None;
            listShoppingList.Columns.AddRange(new ColumnHeader[] { colName, colAmount });
            listShoppingList.ContextMenuStrip = contextShoppingList;
            listShoppingList.Dock = DockStyle.Fill;
            listShoppingList.FullRowSelect = true;
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
            listShoppingList.Groups.AddRange(new ListViewGroup[] { listViewGroup1, listViewGroup2, listViewGroup3, listViewGroup4, listViewGroup5 });
            listShoppingList.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            listShoppingList.Location = new Point(0, 71);
            listShoppingList.Margin = new Padding(4);
            listShoppingList.Name = "listShoppingList";
            listShoppingList.Size = new Size(483, 383);
            listShoppingList.TabIndex = 3;
            listShoppingList.UseCompatibleStateImageBehavior = false;
            listShoppingList.View = System.Windows.Forms.View.Details;
            // 
            // colName
            // 
            colName.Text = "Name";
            colName.Width = 273;
            // 
            // colAmount
            // 
            colAmount.Text = "Amount";
            colAmount.Width = 95;
            // 
            // panel2
            // 
            panel2.Dock = DockStyle.Top;
            panel2.Font = new Font("Segoe UI", 8.25F);
            panel2.Location = new Point(0, 0);
            panel2.Margin = new Padding(4);
            panel2.Name = "panel2";
            panel2.Size = new Size(483, 71);
            panel2.TabIndex = 7;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(checkSellItemsFromPet);
            groupBox1.Controls.Add(checkStoreItemsFromPet);
            groupBox1.Controls.Add(checkRepairGear);
            groupBox1.Controls.Add(checkEnable);
            groupBox1.Dock = DockStyle.Bottom;
            groupBox1.Location = new Point(10, 464);
            groupBox1.Margin = new Padding(4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(4, 12, 4, 4);
            groupBox1.Size = new Size(904, 75);
            groupBox1.TabIndex = 8;
            groupBox1.TabStop = false;
            groupBox1.Text = "General setup";
            // 
            // checkSellItemsFromPet
            // 
            checkSellItemsFromPet.AutoSize = true;
            checkSellItemsFromPet.Checked = true;
            checkSellItemsFromPet.CheckState = CheckState.Checked;
            checkSellItemsFromPet.Location = new Point(531, 34);
            checkSellItemsFromPet.Margin = new Padding(0);
            checkSellItemsFromPet.Name = "checkSellItemsFromPet";
            checkSellItemsFromPet.Size = new Size(157, 24);
            checkSellItemsFromPet.TabIndex = 3;
            checkSellItemsFromPet.Text = "Sell items from pet";
            checkSellItemsFromPet.UseVisualStyleBackColor = false;
            checkSellItemsFromPet.CheckedChanged += checkShoppingSetting_CheckedChanged;
            // 
            // checkStoreItemsFromPet
            // 
            checkStoreItemsFromPet.AutoSize = true;
            checkStoreItemsFromPet.Checked = true;
            checkStoreItemsFromPet.CheckState = CheckState.Checked;
            checkStoreItemsFromPet.Location = new Point(709, 34);
            checkStoreItemsFromPet.Margin = new Padding(0);
            checkStoreItemsFromPet.Name = "checkStoreItemsFromPet";
            checkStoreItemsFromPet.Size = new Size(168, 24);
            checkStoreItemsFromPet.TabIndex = 4;
            checkStoreItemsFromPet.Text = "Store items from pet";
            checkStoreItemsFromPet.UseVisualStyleBackColor = false;
            checkStoreItemsFromPet.CheckedChanged += checkShoppingSetting_CheckedChanged;
            // 
            // checkRepairGear
            // 
            checkRepairGear.AutoSize = true;
            checkRepairGear.Checked = true;
            checkRepairGear.CheckState = CheckState.Checked;
            checkRepairGear.Location = new Point(289, 34);
            checkRepairGear.Margin = new Padding(0);
            checkRepairGear.Name = "checkRepairGear";
            checkRepairGear.Size = new Size(216, 24);
            checkRepairGear.TabIndex = 1;
            checkRepairGear.Text = "Automaticaly repair all gear";
            checkRepairGear.UseVisualStyleBackColor = false;
            checkRepairGear.CheckedChanged += checkShoppingSetting_CheckedChanged;
            // 
            // checkEnable
            // 
            checkEnable.AutoSize = true;
            checkEnable.Checked = true;
            checkEnable.CheckState = CheckState.Checked;
            checkEnable.Location = new Point(16, 34);
            checkEnable.Margin = new Padding(0);
            checkEnable.Name = "checkEnable";
            checkEnable.Size = new Size(236, 24);
            checkEnable.TabIndex = 0;
            checkEnable.Text = "Automaticaly run when in town";
            checkEnable.UseVisualStyleBackColor = false;
            checkEnable.CheckedChanged += checkShoppingSetting_CheckedChanged;
            // 
            // tabSellFilter
            // 
            tabSellFilter.Controls.Add(listFilter);
            tabSellFilter.Controls.Add(filterPanel);
            tabSellFilter.Controls.Add(panel3);
            tabSellFilter.Controls.Add(pictureBox1);
            tabSellFilter.Location = new Point(4, 28);
            tabSellFilter.Margin = new Padding(4);
            tabSellFilter.Name = "tabSellFilter";
            tabSellFilter.Size = new Size(934, 559);
            tabSellFilter.TabIndex = 1;
            tabSellFilter.Text = "Item filter";
            // 
            // listFilter
            // 
            listFilter.BorderStyle = BorderStyle.None;
            listFilter.Columns.AddRange(new ColumnHeader[] { colItemName, colItemLevel, colGender, colPickup, colSell, collStore });
            listFilter.ContextMenuStrip = contextList;
            listFilter.Dock = DockStyle.Fill;
            listFilter.FullRowSelect = true;
            listFilter.Location = new Point(331, 0);
            listFilter.Margin = new Padding(4);
            listFilter.Name = "listFilter";
            listFilter.Size = new Size(603, 514);
            listFilter.SmallImageList = searchImageList;
            listFilter.TabIndex = 5;
            listFilter.UseCompatibleStateImageBehavior = false;
            listFilter.View = System.Windows.Forms.View.Details;
            listFilter.VirtualListSize = 15000;
            // 
            // colItemName
            // 
            colItemName.Text = "Name";
            colItemName.Width = 150;
            // 
            // colItemLevel
            // 
            colItemLevel.Text = "Level";
            colItemLevel.Width = 59;
            // 
            // colGender
            // 
            colGender.Text = "Gender";
            colGender.Width = 73;
            // 
            // colPickup
            // 
            colPickup.Text = "Pickup";
            // 
            // colSell
            // 
            colSell.Text = "Sell";
            // 
            // collStore
            // 
            collStore.Text = "Store";
            // 
            // contextList
            // 
            contextList.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 162);
            contextList.ImageScalingSize = new Size(24, 24);
            contextList.Items.AddRange(new ToolStripItem[] { btnAddToSell, btnAddToStore, btnPickup, btnPickOnlyCharacter, toolStripSeparator2, btnDontSell, btnDontStore, btnDontPickup });
            contextList.Name = "contextSellList";
            contextList.ShowCheckMargin = true;
            contextList.ShowImageMargin = false;
            contextList.Size = new Size(244, 206);
            contextList.Opening += contextList_Opening;
            // 
            // btnAddToSell
            // 
            btnAddToSell.Name = "btnAddToSell";
            btnAddToSell.Size = new Size(243, 28);
            btnAddToSell.Text = "Sell";
            btnAddToSell.Click += btnAddToSell_Click;
            // 
            // btnAddToStore
            // 
            btnAddToStore.Name = "btnAddToStore";
            btnAddToStore.Size = new Size(243, 28);
            btnAddToStore.Text = "Store";
            btnAddToStore.Click += btnAddToStore_Click;
            // 
            // btnPickup
            // 
            btnPickup.Name = "btnPickup";
            btnPickup.Size = new Size(243, 28);
            btnPickup.Text = "Pickup";
            btnPickup.Click += btnPickup_Click;
            // 
            // btnPickOnlyCharacter
            // 
            btnPickOnlyCharacter.Name = "btnPickOnlyCharacter";
            btnPickOnlyCharacter.Size = new Size(243, 28);
            btnPickOnlyCharacter.Text = "Pickup only character";
            btnPickOnlyCharacter.Click += btnPickOnlyCharacter_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(240, 6);
            // 
            // btnDontSell
            // 
            btnDontSell.Name = "btnDontSell";
            btnDontSell.Size = new Size(243, 28);
            btnDontSell.Text = "Don't sell";
            btnDontSell.Click += btnDontSell_Click;
            // 
            // btnDontStore
            // 
            btnDontStore.Name = "btnDontStore";
            btnDontStore.Size = new Size(243, 28);
            btnDontStore.Text = "Don't store";
            btnDontStore.Click += btnDontStore_Click;
            // 
            // btnDontPickup
            // 
            btnDontPickup.Name = "btnDontPickup";
            btnDontPickup.Size = new Size(243, 28);
            btnDontPickup.Text = "Don't pickup";
            btnDontPickup.Click += btnDontPickup_Click;
            // 
            // searchImageList
            // 
            searchImageList.ColorDepth = ColorDepth.Depth8Bit;
            searchImageList.ImageSize = new Size(16, 16);
            searchImageList.TransparentColor = SystemColors.Control;
            // 
            // filterPanel
            // 
            filterPanel.AutoScroll = true;
            filterPanel.AutoScrollMargin = new Size(0, 10);
            filterPanel.AutoScrollMinSize = new Size(0, 720);
            filterPanel.Controls.Add(groupOthers);
            filterPanel.Controls.Add(groupWeapons);
            filterPanel.Controls.Add(groupAccessories);
            filterPanel.Controls.Add(groupClothes);
            filterPanel.Controls.Add(groupGender);
            filterPanel.Dock = DockStyle.Left;
            filterPanel.Location = new Point(0, 0);
            filterPanel.Margin = new Padding(4);
            filterPanel.Name = "filterPanel";
            filterPanel.Padding = new Padding(15);
            filterPanel.Size = new Size(331, 514);
            filterPanel.TabIndex = 20;
            // 
            // groupOthers
            // 
            groupOthers.Controls.Add(checkAlchemy);
            groupOthers.Controls.Add(checkQuest);
            groupOthers.Controls.Add(checkAmmo);
            groupOthers.Controls.Add(checkCoin);
            groupOthers.Controls.Add(checkOther);
            groupOthers.Dock = DockStyle.Top;
            groupOthers.Location = new Point(15, 713);
            groupOthers.Margin = new Padding(4);
            groupOthers.Name = "groupOthers";
            groupOthers.Padding = new Padding(4, 12, 4, 4);
            groupOthers.Size = new Size(280, 139);
            groupOthers.TabIndex = 42;
            groupOthers.TabStop = false;
            groupOthers.Text = "Others";
            // 
            // checkAlchemy
            // 
            checkAlchemy.AutoSize = true;
            checkAlchemy.Location = new Point(121, 66);
            checkAlchemy.Margin = new Padding(0);
            checkAlchemy.Name = "checkAlchemy";
            checkAlchemy.Size = new Size(88, 24);
            checkAlchemy.TabIndex = 19;
            checkAlchemy.Text = "Alchemy";
            checkAlchemy.UseVisualStyleBackColor = false;
            // 
            // checkQuest
            // 
            checkQuest.AutoSize = true;
            checkQuest.Location = new Point(11, 36);
            checkQuest.Margin = new Padding(0);
            checkQuest.Name = "checkQuest";
            checkQuest.Size = new Size(69, 24);
            checkQuest.TabIndex = 19;
            checkQuest.Text = "Quest";
            checkQuest.UseVisualStyleBackColor = false;
            // 
            // checkAmmo
            // 
            checkAmmo.AutoSize = true;
            checkAmmo.Location = new Point(11, 66);
            checkAmmo.Margin = new Padding(0);
            checkAmmo.Name = "checkAmmo";
            checkAmmo.Size = new Size(76, 24);
            checkAmmo.TabIndex = 19;
            checkAmmo.Text = "Ammo";
            checkAmmo.UseVisualStyleBackColor = false;
            // 
            // checkCoin
            // 
            checkCoin.AutoSize = true;
            checkCoin.Location = new Point(121, 36);
            checkCoin.Margin = new Padding(0);
            checkCoin.Name = "checkCoin";
            checkCoin.Size = new Size(61, 24);
            checkCoin.TabIndex = 19;
            checkCoin.Text = "Coin";
            checkCoin.UseVisualStyleBackColor = false;
            // 
            // checkOther
            // 
            checkOther.AutoSize = true;
            checkOther.Location = new Point(11, 98);
            checkOther.Margin = new Padding(0);
            checkOther.Name = "checkOther";
            checkOther.Size = new Size(68, 24);
            checkOther.TabIndex = 19;
            checkOther.Text = "Other";
            checkOther.UseVisualStyleBackColor = false;
            // 
            // groupWeapons
            // 
            groupWeapons.Controls.Add(checkAxe);
            groupWeapons.Controls.Add(checkHarp);
            groupWeapons.Controls.Add(checkDagger);
            groupWeapons.Controls.Add(checkXBow);
            groupWeapons.Controls.Add(checkWRod);
            groupWeapons.Controls.Add(checkShield);
            groupWeapons.Controls.Add(checkCRod);
            groupWeapons.Controls.Add(check2HSword);
            groupWeapons.Controls.Add(check1HSword);
            groupWeapons.Controls.Add(checkStaff);
            groupWeapons.Controls.Add(checkBow);
            groupWeapons.Controls.Add(checkSpear);
            groupWeapons.Controls.Add(checkGlave);
            groupWeapons.Controls.Add(checkSword);
            groupWeapons.Controls.Add(checkBlade);
            groupWeapons.Dock = DockStyle.Top;
            groupWeapons.Location = new Point(15, 442);
            groupWeapons.Margin = new Padding(8);
            groupWeapons.Name = "groupWeapons";
            groupWeapons.Padding = new Padding(4, 12, 4, 4);
            groupWeapons.Size = new Size(280, 271);
            groupWeapons.TabIndex = 40;
            groupWeapons.TabStop = false;
            groupWeapons.Text = "Weapons";
            // 
            // checkAxe
            // 
            checkAxe.AutoSize = true;
            checkAxe.Location = new Point(124, 225);
            checkAxe.Margin = new Padding(0);
            checkAxe.Name = "checkAxe";
            checkAxe.Size = new Size(56, 24);
            checkAxe.TabIndex = 10;
            checkAxe.Text = "Axe";
            checkAxe.UseVisualStyleBackColor = false;
            // 
            // checkHarp
            // 
            checkHarp.AutoSize = true;
            checkHarp.Location = new Point(9, 225);
            checkHarp.Margin = new Padding(0);
            checkHarp.Name = "checkHarp";
            checkHarp.Size = new Size(64, 24);
            checkHarp.TabIndex = 10;
            checkHarp.Text = "Harp";
            checkHarp.UseVisualStyleBackColor = false;
            // 
            // checkDagger
            // 
            checkDagger.AutoSize = true;
            checkDagger.Location = new Point(124, 194);
            checkDagger.Margin = new Padding(0);
            checkDagger.Name = "checkDagger";
            checkDagger.Size = new Size(81, 24);
            checkDagger.TabIndex = 9;
            checkDagger.Text = "Dagger";
            checkDagger.UseVisualStyleBackColor = false;
            // 
            // checkXBow
            // 
            checkXBow.AutoSize = true;
            checkXBow.Location = new Point(9, 194);
            checkXBow.Margin = new Padding(0);
            checkXBow.Name = "checkXBow";
            checkXBow.Size = new Size(75, 24);
            checkXBow.TabIndex = 9;
            checkXBow.Text = "X-Bow";
            checkXBow.UseVisualStyleBackColor = false;
            // 
            // checkWRod
            // 
            checkWRod.AutoSize = true;
            checkWRod.Location = new Point(124, 162);
            checkWRod.Margin = new Padding(0);
            checkWRod.Name = "checkWRod";
            checkWRod.Size = new Size(78, 24);
            checkWRod.TabIndex = 8;
            checkWRod.Text = "W-Rod";
            checkWRod.UseVisualStyleBackColor = false;
            // 
            // checkShield
            // 
            checkShield.AutoSize = true;
            checkShield.Location = new Point(201, 225);
            checkShield.Margin = new Padding(0);
            checkShield.Name = "checkShield";
            checkShield.Size = new Size(72, 24);
            checkShield.TabIndex = 5;
            checkShield.Text = "Shield";
            checkShield.UseVisualStyleBackColor = false;
            // 
            // checkCRod
            // 
            checkCRod.AutoSize = true;
            checkCRod.Location = new Point(9, 162);
            checkCRod.Margin = new Padding(0);
            checkCRod.Name = "checkCRod";
            checkCRod.Size = new Size(73, 24);
            checkCRod.TabIndex = 7;
            checkCRod.Text = "C-Rod";
            checkCRod.UseVisualStyleBackColor = false;
            // 
            // check2HSword
            // 
            check2HSword.AutoSize = true;
            check2HSword.Location = new Point(124, 131);
            check2HSword.Margin = new Padding(0);
            check2HSword.Name = "check2HSword";
            check2HSword.Size = new Size(96, 24);
            check2HSword.TabIndex = 6;
            check2HSword.Text = "2H Sword";
            check2HSword.UseVisualStyleBackColor = false;
            // 
            // check1HSword
            // 
            check1HSword.AutoSize = true;
            check1HSword.Location = new Point(9, 131);
            check1HSword.Margin = new Padding(0);
            check1HSword.Name = "check1HSword";
            check1HSword.Size = new Size(96, 24);
            check1HSword.TabIndex = 5;
            check1HSword.Text = "1H Sword";
            check1HSword.UseVisualStyleBackColor = false;
            // 
            // checkStaff
            // 
            checkStaff.AutoSize = true;
            checkStaff.Location = new Point(124, 100);
            checkStaff.Margin = new Padding(0);
            checkStaff.Name = "checkStaff";
            checkStaff.Size = new Size(62, 24);
            checkStaff.TabIndex = 5;
            checkStaff.Text = "Staff";
            checkStaff.UseVisualStyleBackColor = false;
            // 
            // checkBow
            // 
            checkBow.AutoSize = true;
            checkBow.Location = new Point(9, 100);
            checkBow.Margin = new Padding(0);
            checkBow.Name = "checkBow";
            checkBow.Size = new Size(60, 24);
            checkBow.TabIndex = 4;
            checkBow.Text = "Bow";
            checkBow.UseVisualStyleBackColor = false;
            // 
            // checkSpear
            // 
            checkSpear.AutoSize = true;
            checkSpear.Location = new Point(124, 69);
            checkSpear.Margin = new Padding(0);
            checkSpear.Name = "checkSpear";
            checkSpear.Size = new Size(69, 24);
            checkSpear.TabIndex = 3;
            checkSpear.Text = "Spear";
            checkSpear.UseVisualStyleBackColor = false;
            // 
            // checkGlave
            // 
            checkGlave.AutoSize = true;
            checkGlave.Location = new Point(9, 69);
            checkGlave.Margin = new Padding(0);
            checkGlave.Name = "checkGlave";
            checkGlave.Size = new Size(68, 24);
            checkGlave.TabIndex = 2;
            checkGlave.Text = "Glave";
            checkGlave.UseVisualStyleBackColor = false;
            // 
            // checkSword
            // 
            checkSword.AutoSize = true;
            checkSword.Location = new Point(124, 38);
            checkSword.Margin = new Padding(0);
            checkSword.Name = "checkSword";
            checkSword.Size = new Size(73, 24);
            checkSword.TabIndex = 1;
            checkSword.Text = "Sword";
            checkSword.UseVisualStyleBackColor = false;
            // 
            // checkBlade
            // 
            checkBlade.AutoSize = true;
            checkBlade.Location = new Point(9, 38);
            checkBlade.Margin = new Padding(0);
            checkBlade.Name = "checkBlade";
            checkBlade.Size = new Size(69, 24);
            checkBlade.TabIndex = 0;
            checkBlade.Text = "Blade";
            checkBlade.UseVisualStyleBackColor = false;
            // 
            // groupAccessories
            // 
            groupAccessories.Controls.Add(checkNecklace);
            groupAccessories.Controls.Add(checkEarring);
            groupAccessories.Controls.Add(checkRing);
            groupAccessories.Dock = DockStyle.Top;
            groupAccessories.Location = new Point(15, 370);
            groupAccessories.Margin = new Padding(4);
            groupAccessories.Name = "groupAccessories";
            groupAccessories.Padding = new Padding(4, 12, 4, 4);
            groupAccessories.Size = new Size(280, 72);
            groupAccessories.TabIndex = 44;
            groupAccessories.TabStop = false;
            groupAccessories.Text = "Accessories";
            // 
            // checkNecklace
            // 
            checkNecklace.AutoSize = true;
            checkNecklace.Location = new Point(81, 32);
            checkNecklace.Margin = new Padding(0);
            checkNecklace.Name = "checkNecklace";
            checkNecklace.Size = new Size(91, 24);
            checkNecklace.TabIndex = 4;
            checkNecklace.Text = "Necklace";
            checkNecklace.UseVisualStyleBackColor = false;
            // 
            // checkEarring
            // 
            checkEarring.AutoSize = true;
            checkEarring.Location = new Point(189, 32);
            checkEarring.Margin = new Padding(0);
            checkEarring.Name = "checkEarring";
            checkEarring.Size = new Size(78, 24);
            checkEarring.TabIndex = 3;
            checkEarring.Text = "Earring";
            checkEarring.UseVisualStyleBackColor = false;
            // 
            // checkRing
            // 
            checkRing.AutoSize = true;
            checkRing.Location = new Point(6, 32);
            checkRing.Margin = new Padding(0);
            checkRing.Name = "checkRing";
            checkRing.Size = new Size(61, 24);
            checkRing.TabIndex = 2;
            checkRing.Text = "Ring";
            checkRing.UseVisualStyleBackColor = false;
            // 
            // groupClothes
            // 
            groupClothes.Controls.Add(checkHand);
            groupClothes.Controls.Add(checkLegs);
            groupClothes.Controls.Add(checkHeavy);
            groupClothes.Controls.Add(checkLight);
            groupClothes.Controls.Add(checkClothes);
            groupClothes.Controls.Add(checkBoot);
            groupClothes.Controls.Add(checkChest);
            groupClothes.Controls.Add(checkShoulder);
            groupClothes.Controls.Add(checkHead);
            groupClothes.Dock = DockStyle.Top;
            groupClothes.Location = new Point(15, 189);
            groupClothes.Margin = new Padding(4);
            groupClothes.Name = "groupClothes";
            groupClothes.Padding = new Padding(4, 12, 4, 4);
            groupClothes.Size = new Size(280, 181);
            groupClothes.TabIndex = 41;
            groupClothes.TabStop = false;
            groupClothes.Text = "Clothes";
            // 
            // checkHand
            // 
            checkHand.AutoSize = true;
            checkHand.Location = new Point(116, 132);
            checkHand.Margin = new Padding(0);
            checkHand.Name = "checkHand";
            checkHand.Size = new Size(67, 24);
            checkHand.TabIndex = 8;
            checkHand.Text = "Hand";
            checkHand.UseVisualStyleBackColor = false;
            // 
            // checkLegs
            // 
            checkLegs.AutoSize = true;
            checkLegs.Location = new Point(6, 132);
            checkLegs.Margin = new Padding(0);
            checkLegs.Name = "checkLegs";
            checkLegs.Size = new Size(55, 24);
            checkLegs.TabIndex = 7;
            checkLegs.Text = "Leg";
            checkLegs.UseVisualStyleBackColor = false;
            // 
            // checkHeavy
            // 
            checkHeavy.AutoSize = true;
            checkHeavy.Location = new Point(198, 35);
            checkHeavy.Margin = new Padding(0);
            checkHeavy.Name = "checkHeavy";
            checkHeavy.Size = new Size(72, 24);
            checkHeavy.TabIndex = 6;
            checkHeavy.Text = "Heavy";
            checkHeavy.UseVisualStyleBackColor = false;
            // 
            // checkLight
            // 
            checkLight.AutoSize = true;
            checkLight.Location = new Point(116, 35);
            checkLight.Margin = new Padding(0);
            checkLight.Name = "checkLight";
            checkLight.Size = new Size(64, 24);
            checkLight.TabIndex = 6;
            checkLight.Text = "Light";
            checkLight.UseVisualStyleBackColor = false;
            // 
            // checkClothes
            // 
            checkClothes.AutoSize = true;
            checkClothes.Location = new Point(6, 35);
            checkClothes.Margin = new Padding(0);
            checkClothes.Name = "checkClothes";
            checkClothes.Size = new Size(80, 24);
            checkClothes.TabIndex = 6;
            checkClothes.Text = "Clothes";
            checkClothes.UseVisualStyleBackColor = false;
            // 
            // checkBoot
            // 
            checkBoot.AutoSize = true;
            checkBoot.Location = new Point(116, 101);
            checkBoot.Margin = new Padding(0);
            checkBoot.Name = "checkBoot";
            checkBoot.Size = new Size(63, 24);
            checkBoot.TabIndex = 4;
            checkBoot.Text = "Boot";
            checkBoot.UseVisualStyleBackColor = false;
            // 
            // checkChest
            // 
            checkChest.AutoSize = true;
            checkChest.Location = new Point(6, 101);
            checkChest.Margin = new Padding(0);
            checkChest.Name = "checkChest";
            checkChest.Size = new Size(67, 24);
            checkChest.TabIndex = 4;
            checkChest.Text = "Chest";
            checkChest.UseVisualStyleBackColor = false;
            // 
            // checkShoulder
            // 
            checkShoulder.AutoSize = true;
            checkShoulder.Location = new Point(116, 70);
            checkShoulder.Margin = new Padding(0);
            checkShoulder.Name = "checkShoulder";
            checkShoulder.Size = new Size(90, 24);
            checkShoulder.TabIndex = 4;
            checkShoulder.Text = "Shoulder";
            checkShoulder.UseVisualStyleBackColor = false;
            // 
            // checkHead
            // 
            checkHead.AutoSize = true;
            checkHead.Location = new Point(6, 70);
            checkHead.Margin = new Padding(0);
            checkHead.Name = "checkHead";
            checkHead.Size = new Size(67, 24);
            checkHead.TabIndex = 4;
            checkHead.Text = "Head";
            checkHead.UseVisualStyleBackColor = false;
            // 
            // groupGender
            // 
            groupGender.Controls.Add(checkEuropean);
            groupGender.Controls.Add(checkChinese);
            groupGender.Controls.Add(checkFemale);
            groupGender.Controls.Add(checkBoxRareItems);
            groupGender.Controls.Add(checkMale);
            groupGender.Controls.Add(label3);
            groupGender.Controls.Add(numDegreeFrom);
            groupGender.Controls.Add(numDegreeTo);
            groupGender.Controls.Add(label4);
            groupGender.Dock = DockStyle.Top;
            groupGender.Location = new Point(15, 15);
            groupGender.Margin = new Padding(8);
            groupGender.Name = "groupGender";
            groupGender.Padding = new Padding(4, 12, 4, 4);
            groupGender.Size = new Size(280, 174);
            groupGender.TabIndex = 44;
            groupGender.TabStop = false;
            groupGender.Text = "Gender and Degree";
            // 
            // checkEuropean
            // 
            checkEuropean.AutoSize = true;
            checkEuropean.Location = new Point(124, 66);
            checkEuropean.Margin = new Padding(0);
            checkEuropean.Name = "checkEuropean";
            checkEuropean.Size = new Size(94, 24);
            checkEuropean.TabIndex = 9;
            checkEuropean.Text = "European";
            checkEuropean.UseVisualStyleBackColor = false;
            // 
            // checkChinese
            // 
            checkChinese.AutoSize = true;
            checkChinese.Location = new Point(20, 66);
            checkChinese.Margin = new Padding(0);
            checkChinese.Name = "checkChinese";
            checkChinese.Size = new Size(82, 24);
            checkChinese.TabIndex = 9;
            checkChinese.Text = "Chinese";
            checkChinese.UseVisualStyleBackColor = false;
            // 
            // checkFemale
            // 
            checkFemale.AutoSize = true;
            checkFemale.Location = new Point(124, 38);
            checkFemale.Margin = new Padding(0);
            checkFemale.Name = "checkFemale";
            checkFemale.Size = new Size(79, 24);
            checkFemale.TabIndex = 9;
            checkFemale.Text = "Female";
            checkFemale.UseVisualStyleBackColor = false;
            // 
            // checkBoxRareItems
            // 
            checkBoxRareItems.AutoSize = true;
            checkBoxRareItems.Location = new Point(20, 95);
            checkBoxRareItems.Margin = new Padding(0);
            checkBoxRareItems.Name = "checkBoxRareItems";
            checkBoxRareItems.Size = new Size(99, 24);
            checkBoxRareItems.TabIndex = 40;
            checkBoxRareItems.Text = "Rare (Sox)";
            checkBoxRareItems.UseVisualStyleBackColor = false;
            // 
            // checkMale
            // 
            checkMale.AutoSize = true;
            checkMale.Location = new Point(20, 38);
            checkMale.Margin = new Padding(0);
            checkMale.Name = "checkMale";
            checkMale.Size = new Size(64, 24);
            checkMale.TabIndex = 9;
            checkMale.Text = "Male";
            checkMale.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 141);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(61, 20);
            label3.TabIndex = 31;
            label3.Text = "Degree:";
            // 
            // numDegreeFrom
            // 
            numDegreeFrom.Font = new Font("Segoe UI", 9.25F);
            numDegreeFrom.Location = new Point(72, 136);
            numDegreeFrom.Margin = new Padding(4);
            numDegreeFrom.Name = "numDegreeFrom";
            numDegreeFrom.Size = new Size(95, 28);
            numDegreeFrom.TabIndex = 32;
            // 
            // numDegreeTo
            // 
            numDegreeTo.Font = new Font("Segoe UI", 9.25F);
            numDegreeTo.Location = new Point(175, 136);
            numDegreeTo.Margin = new Padding(4);
            numDegreeTo.Name = "numDegreeTo";
            numDegreeTo.Size = new Size(92, 28);
            numDegreeTo.TabIndex = 34;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Arial", 12F, FontStyle.Bold);
            label4.Location = new Point(145, 136);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(22, 24);
            label4.TabIndex = 33;
            label4.Text = "~";
            // 
            // panel3
            // 
            panel3.Controls.Add(panel7);
            panel3.Controls.Add(labelResult);
            panel3.Controls.Add(btnResetFilter);
            panel3.Controls.Add(btnSearch);
            panel3.Controls.Add(btnReload);
            panel3.Controls.Add(txtSellSearch);
            panel3.Dock = DockStyle.Bottom;
            panel3.Location = new Point(0, 514);
            panel3.Margin = new Padding(0);
            panel3.Name = "panel3";
            panel3.Size = new Size(934, 45);
            panel3.TabIndex = 40;
            // 
            // panel7
            // 
            panel7.Dock = DockStyle.Top;
            panel7.Location = new Point(0, 0);
            panel7.Margin = new Padding(0);
            panel7.Name = "panel7";
            panel7.Size = new Size(934, 1);
            panel7.TabIndex = 41;
            // 
            // labelResult
            // 
            labelResult.AutoSize = true;
            labelResult.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            labelResult.Location = new Point(350, 14);
            labelResult.Margin = new Padding(4, 0, 4, 0);
            labelResult.Name = "labelResult";
            labelResult.Size = new Size(0, 20);
            labelResult.TabIndex = 40;
            // 
            // btnResetFilter
            // 
            btnResetFilter.Location = new Point(15, 9);
            btnResetFilter.Margin = new Padding(4);
            btnResetFilter.Name = "btnResetFilter";
            btnResetFilter.Size = new Size(120, 29);
            btnResetFilter.TabIndex = 39;
            btnResetFilter.Text = "Reset";
            btnResetFilter.UseVisualStyleBackColor = true;
            btnResetFilter.Click += btnResetFilter_Click;
            // 
            // btnSearch
            // 
            btnSearch.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSearch.AutoSize = true;
            btnSearch.Font = new Font("Segoe UI", 9F);
            btnSearch.Location = new Point(836, 7);
            btnSearch.Margin = new Padding(4);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(94, 30);
            btnSearch.TabIndex = 21;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnApply_Click;
            // 
            // btnReload
            // 
            btnReload.Location = new Point(140, 9);
            btnReload.Margin = new Padding(4);
            btnReload.Name = "btnReload";
            btnReload.Size = new Size(171, 29);
            btnReload.TabIndex = 39;
            btnReload.Text = "Apply";
            btnReload.UseVisualStyleBackColor = true;
            btnReload.Click += btnApply_Click;
            // 
            // txtSellSearch
            // 
            txtSellSearch.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            txtSellSearch.Font = new Font("Segoe UI", 9F);
            txtSellSearch.Location = new Point(554, 9);
            txtSellSearch.Margin = new Padding(4);
            txtSellSearch.Name = "txtSellSearch";
            txtSellSearch.Size = new Size(276, 27);
            txtSellSearch.TabIndex = 20;
            txtSellSearch.KeyDown += txtSellSearch_KeyDown;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Resources.loading;
            pictureBox1.Location = new Point(581, 186);
            pictureBox1.Margin = new Padding(4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(151, 86);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 22;
            pictureBox1.TabStop = false;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(groupBoxOptions);
            tabPage1.Controls.Add(groupBoxGeneral);
            tabPage1.Location = new Point(4, 28);
            tabPage1.Margin = new Padding(4);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(4);
            tabPage1.Size = new Size(934, 559);
            tabPage1.TabIndex = 2;
            tabPage1.Text = "Pickup settings";
            // 
            // groupBoxOptions
            // 
            groupBoxOptions.Controls.Add(checkPickupGold);
            groupBoxOptions.Controls.Add(checkAllEquips);
            groupBoxOptions.Controls.Add(checkEverything);
            groupBoxOptions.Controls.Add(checkPickupRare);
            groupBoxOptions.Controls.Add(checkQuestItems);
            groupBoxOptions.Controls.Add(checkPickupBlue);
            groupBoxOptions.Location = new Point(8, 126);
            groupBoxOptions.Margin = new Padding(4);
            groupBoxOptions.Name = "groupBoxOptions";
            groupBoxOptions.Padding = new Padding(4, 10, 4, 4);
            groupBoxOptions.Size = new Size(918, 125);
            groupBoxOptions.TabIndex = 0;
            groupBoxOptions.TabStop = false;
            groupBoxOptions.Text = "Options";
            // 
            // checkPickupGold
            // 
            checkPickupGold.AutoSize = true;
            checkPickupGold.Checked = true;
            checkPickupGold.CheckState = CheckState.Checked;
            checkPickupGold.Location = new Point(19, 40);
            checkPickupGold.Margin = new Padding(0);
            checkPickupGold.Name = "checkPickupGold";
            checkPickupGold.Size = new Size(109, 24);
            checkPickupGold.TabIndex = 0;
            checkPickupGold.Text = "Pickup gold";
            checkPickupGold.UseVisualStyleBackColor = false;
            checkPickupGold.CheckedChanged += checkPickupSettings_CheckedChanged;
            // 
            // checkAllEquips
            // 
            checkAllEquips.AutoSize = true;
            checkAllEquips.Location = new Point(340, 76);
            checkAllEquips.Margin = new Padding(0);
            checkAllEquips.Name = "checkAllEquips";
            checkAllEquips.Size = new Size(176, 24);
            checkAllEquips.TabIndex = 4;
            checkAllEquips.Text = "Pickup all equip items";
            checkAllEquips.UseVisualStyleBackColor = false;
            checkAllEquips.CheckedChanged += checkPickupSettings_CheckedChanged;
            // 
            // checkEverything
            // 
            checkEverything.AutoSize = true;
            checkEverything.Location = new Point(632, 76);
            checkEverything.Margin = new Padding(0);
            checkEverything.Name = "checkEverything";
            checkEverything.Size = new Size(147, 24);
            checkEverything.TabIndex = 5;
            checkEverything.Text = "Pickup everything";
            checkEverything.UseVisualStyleBackColor = false;
            checkEverything.CheckedChanged += checkPickupSettings_CheckedChanged;
            // 
            // checkPickupRare
            // 
            checkPickupRare.AutoSize = true;
            checkPickupRare.Checked = true;
            checkPickupRare.CheckState = CheckState.Checked;
            checkPickupRare.Location = new Point(19, 76);
            checkPickupRare.Margin = new Padding(0);
            checkPickupRare.Name = "checkPickupRare";
            checkPickupRare.Size = new Size(195, 24);
            checkPickupRare.TabIndex = 3;
            checkPickupRare.Text = "Always pickup rare items";
            checkPickupRare.UseVisualStyleBackColor = false;
            checkPickupRare.CheckedChanged += checkPickupSettings_CheckedChanged;
            // 
            // checkQuestItems
            // 
            checkQuestItems.AutoSize = true;
            checkQuestItems.Location = new Point(632, 40);
            checkQuestItems.Margin = new Padding(0);
            checkQuestItems.Name = "checkQuestItems";
            checkQuestItems.Size = new Size(154, 24);
            checkQuestItems.TabIndex = 2;
            checkQuestItems.Text = "Pickup quest items";
            checkQuestItems.UseVisualStyleBackColor = false;
            checkQuestItems.CheckedChanged += checkPickupSettings_CheckedChanged;
            // 
            // checkPickupBlue
            // 
            checkPickupBlue.AutoSize = true;
            checkPickupBlue.Location = new Point(340, 40);
            checkPickupBlue.Margin = new Padding(0);
            checkPickupBlue.Name = "checkPickupBlue";
            checkPickupBlue.Size = new Size(198, 24);
            checkPickupBlue.TabIndex = 1;
            checkPickupBlue.Text = "Always pickup blue items";
            checkPickupBlue.UseVisualStyleBackColor = false;
            checkPickupBlue.CheckedChanged += checkPickupSettings_CheckedChanged;
            // 
            // groupBoxGeneral
            // 
            groupBoxGeneral.Controls.Add(cbDontPickupWhileBotting);
            groupBoxGeneral.Controls.Add(cbJustpickmyitems);
            groupBoxGeneral.Controls.Add(checkDontPickupInBerzerk);
            groupBoxGeneral.Controls.Add(checkEnableAbilityPet);
            groupBoxGeneral.Location = new Point(8, 8);
            groupBoxGeneral.Margin = new Padding(4);
            groupBoxGeneral.Name = "groupBoxGeneral";
            groupBoxGeneral.Padding = new Padding(4, 12, 4, 4);
            groupBoxGeneral.Size = new Size(918, 110);
            groupBoxGeneral.TabIndex = 0;
            groupBoxGeneral.TabStop = false;
            groupBoxGeneral.Text = "General";
            // 
            // cbDontPickupWhileBotting
            // 
            cbDontPickupWhileBotting.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cbDontPickupWhileBotting.AutoSize = true;
            cbDontPickupWhileBotting.Location = new Point(363, 68);
            cbDontPickupWhileBotting.Margin = new Padding(0);
            cbDontPickupWhileBotting.Name = "cbDontPickupWhileBotting";
            cbDontPickupWhileBotting.Size = new Size(247, 24);
            cbDontPickupWhileBotting.TabIndex = 3;
            cbDontPickupWhileBotting.Text = "Don't pickup items while botting";
            cbDontPickupWhileBotting.UseVisualStyleBackColor = false;
            cbDontPickupWhileBotting.CheckedChanged += checkPickupSettings_CheckedChanged;
            // 
            // cbJustpickmyitems
            // 
            cbJustpickmyitems.AutoSize = true;
            cbJustpickmyitems.Location = new Point(363, 32);
            cbJustpickmyitems.Margin = new Padding(0);
            cbJustpickmyitems.Name = "cbJustpickmyitems";
            cbJustpickmyitems.Size = new Size(150, 24);
            cbJustpickmyitems.TabIndex = 1;
            cbJustpickmyitems.Text = "Just pick my items";
            cbJustpickmyitems.UseVisualStyleBackColor = false;
            cbJustpickmyitems.CheckedChanged += checkPickupSettings_CheckedChanged;
            // 
            // checkDontPickupInBerzerk
            // 
            checkDontPickupInBerzerk.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            checkDontPickupInBerzerk.AutoSize = true;
            checkDontPickupInBerzerk.Location = new Point(19, 68);
            checkDontPickupInBerzerk.Margin = new Padding(0);
            checkDontPickupInBerzerk.Name = "checkDontPickupInBerzerk";
            checkDontPickupInBerzerk.Size = new Size(267, 24);
            checkDontPickupInBerzerk.TabIndex = 2;
            checkDontPickupInBerzerk.Text = "Don't pickup items in berzerk mode";
            checkDontPickupInBerzerk.UseVisualStyleBackColor = false;
            checkDontPickupInBerzerk.CheckedChanged += checkPickupSettings_CheckedChanged;
            // 
            // checkEnableAbilityPet
            // 
            checkEnableAbilityPet.AutoSize = true;
            checkEnableAbilityPet.Checked = true;
            checkEnableAbilityPet.CheckState = CheckState.Checked;
            checkEnableAbilityPet.Location = new Point(19, 32);
            checkEnableAbilityPet.Margin = new Padding(0);
            checkEnableAbilityPet.Name = "checkEnableAbilityPet";
            checkEnableAbilityPet.Size = new Size(236, 24);
            checkEnableAbilityPet.TabIndex = 0;
            checkEnableAbilityPet.Text = "Use ability pet to pickup items ";
            checkEnableAbilityPet.UseVisualStyleBackColor = false;
            checkEnableAbilityPet.CheckedChanged += checkPickupSettings_CheckedChanged;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            Controls.Add(tabMain);
            DoubleBuffered = true;
            Margin = new Padding(4);
            Name = "Main";
            Padding = new Padding(5);
            Size = new Size(942, 591);
            contextShoppingList.ResumeLayout(false);
            contextAvailableProducts.ResumeLayout(false);
            tabMain.ResumeLayout(false);
            tabBuyFilter.ResumeLayout(false);
            splitContainer.Panel1.ResumeLayout(false);
            splitContainer.Panel2.ResumeLayout(false);
            ((ISupportInitialize)splitContainer).EndInit();
            splitContainer.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            tabSellFilter.ResumeLayout(false);
            contextList.ResumeLayout(false);
            filterPanel.ResumeLayout(false);
            groupOthers.ResumeLayout(false);
            groupOthers.PerformLayout();
            groupWeapons.ResumeLayout(false);
            groupWeapons.PerformLayout();
            groupAccessories.ResumeLayout(false);
            groupAccessories.PerformLayout();
            groupClothes.ResumeLayout(false);
            groupClothes.PerformLayout();
            groupGender.ResumeLayout(false);
            groupGender.PerformLayout();
            ((ISupportInitialize)numDegreeFrom).EndInit();
            ((ISupportInitialize)numDegreeTo).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((ISupportInitialize)pictureBox1).EndInit();
            tabPage1.ResumeLayout(false);
            groupBoxOptions.ResumeLayout(false);
            groupBoxOptions.PerformLayout();
            groupBoxGeneral.ResumeLayout(false);
            groupBoxGeneral.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip contextAvailableProducts;
        private ToolStripMenuItem menuAddToShoppingList;
        private System.Windows.Forms.ContextMenuStrip contextShoppingList;
        private ToolStripMenuItem menuChangeAmount;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem menuRemoveItem;
        private System.Windows.Forms.TabControl tabMain;
        private TabPage tabSellFilter;
        private System.Windows.Forms.ListView listFilter;
        private ColumnHeader colItemName;
        private ColumnHeader colItemLevel;
        private ColumnHeader colSell;
        private ColumnHeader collStore;
        private System.Windows.Forms.TextBox txtSellSearch;
        private ColumnHeader colGender;
        private System.Windows.Forms.ContextMenuStrip contextList;
        private ToolStripMenuItem btnAddToSell;
        private ToolStripMenuItem btnAddToStore;
        private System.Windows.Forms.Button btnSearch;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem btnDontSell;
        private ToolStripMenuItem btnDontStore;
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
        private ToolStripMenuItem btnPickup;
        private ToolStripMenuItem btnDontPickup;
        private PictureBox pictureBox1;
        private TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBoxGeneral;
        private System.Windows.Forms.CheckBox checkPickupGold;
        private ColumnHeader colPickup;
        private System.Windows.Forms.CheckBox checkPickupRare;
        private System.Windows.Forms.CheckBox checkEnableAbilityPet;
        private System.Windows.Forms.Button btnResetFilter;
        private System.Windows.Forms.CheckBox checkDontPickupInBerzerk;
        private System.Windows.Forms.CheckBox cbJustpickmyitems;
        private System.Windows.Forms.CheckBox cbDontPickupWhileBotting;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label labelResult;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.CheckBox checkBoxRareItems;
        private ImageList searchImageList;
        private System.Windows.Forms.CheckBox checkEuropean;
        private System.Windows.Forms.CheckBox checkChinese;
        private System.Windows.Forms.CheckBox checkFemale;
        private System.Windows.Forms.CheckBox checkMale;
        private System.Windows.Forms.CheckBox checkQuest;
        private System.Windows.Forms.CheckBox checkCoin;
        private System.Windows.Forms.CheckBox checkAmmo;
        private TabPage tabBuyFilter;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkSellItemsFromPet;
        private System.Windows.Forms.CheckBox checkRepairGear;
        private System.Windows.Forms.CheckBox checkEnable;
        private SplitContainer splitContainer;
        private System.Windows.Forms.ListView listAvailableProducts;
        private ColumnHeader colAvailableName;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox checkShowEquipment;
        private System.Windows.Forms.TextBox txtShopSearch;
        private System.Windows.Forms.ComboBox comboStore;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView listShoppingList;
        private ColumnHeader colName;
        private ColumnHeader colAmount;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox checkStoreItemsFromPet;
        private System.Windows.Forms.CheckBox checkPickupBlue;
        private ToolStripMenuItem btnPickOnlyCharacter;
        private System.Windows.Forms.CheckBox checkQuestItems;
        private System.Windows.Forms.CheckBox checkAllEquips;
        private System.Windows.Forms.CheckBox checkEverything;
        private System.Windows.Forms.GroupBox groupBoxOptions;
    }
}
