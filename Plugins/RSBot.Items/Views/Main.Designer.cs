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
            components = new Container();
            ListViewGroup listViewGroup6 = new ListViewGroup("Potion trader", HorizontalAlignment.Left);
            ListViewGroup listViewGroup7 = new ListViewGroup("Stable keeper", HorizontalAlignment.Left);
            ListViewGroup listViewGroup8 = new ListViewGroup("Protector trader", HorizontalAlignment.Left);
            ListViewGroup listViewGroup9 = new ListViewGroup("Weapon trader", HorizontalAlignment.Left);
            ListViewGroup listViewGroup10 = new ListViewGroup("Accessory trader", HorizontalAlignment.Left);
            contextShoppingList = new SDUI.Controls.ContextMenuStrip();
            menuChangeAmount = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            menuRemoveItem = new ToolStripMenuItem();
            contextAvailableProducts = new SDUI.Controls.ContextMenuStrip();
            menuAddToShoppingList = new ToolStripMenuItem();
            tabMain = new SDUI.Controls.TabControl();
            tabBuyFilter = new TabPage();
            splitContainer = new SplitContainer();
            listAvailableProducts = new SDUI.Controls.ListView();
            colAvailableName = new ColumnHeader();
            panel1 = new SDUI.Controls.Panel();
            label6 = new SDUI.Controls.Label();
            checkShowEquipment = new SDUI.Controls.CheckBox();
            txtShopSearch = new SDUI.Controls.TextBox();
            comboStore = new SDUI.Controls.ComboBox();
            label1 = new SDUI.Controls.Label();
            listShoppingList = new SDUI.Controls.ListView();
            colName = new ColumnHeader();
            colAmount = new ColumnHeader();
            panel2 = new SDUI.Controls.Panel();
            separator5 = new SDUI.Controls.Separator();
            groupBox1 = new SDUI.Controls.GroupBox();
            checkSellItemsFromPet = new SDUI.Controls.CheckBox();
            checkStoreItemsFromPet = new SDUI.Controls.CheckBox();
            checkRepairGear = new SDUI.Controls.CheckBox();
            checkEnable = new SDUI.Controls.CheckBox();
            tabSellFilter = new TabPage();
            listFilter = new SDUI.Controls.ListView();
            colItemName = new ColumnHeader();
            colItemLevel = new ColumnHeader();
            colGender = new ColumnHeader();
            colPickup = new ColumnHeader();
            colSell = new ColumnHeader();
            collStore = new ColumnHeader();
            contextList = new SDUI.Controls.ContextMenuStrip();
            btnAddToSell = new ToolStripMenuItem();
            btnAddToStore = new ToolStripMenuItem();
            btnPickup = new ToolStripMenuItem();
            btnPickOnlyCharacter = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            btnDontSell = new ToolStripMenuItem();
            btnDontStore = new ToolStripMenuItem();
            btnDontPickup = new ToolStripMenuItem();
            searchImageList = new ImageList(components);
            filterPanel = new SDUI.Controls.Panel();
            groupOthers = new SDUI.Controls.GroupBox();
            checkAlchemy = new SDUI.Controls.CheckBox();
            checkQuest = new SDUI.Controls.CheckBox();
            checkAmmo = new SDUI.Controls.CheckBox();
            checkCoin = new SDUI.Controls.CheckBox();
            checkOther = new SDUI.Controls.CheckBox();
            separator1 = new SDUI.Controls.Separator();
            groupWeapons = new SDUI.Controls.GroupBox();
            checkAxe = new SDUI.Controls.CheckBox();
            checkHarp = new SDUI.Controls.CheckBox();
            checkDagger = new SDUI.Controls.CheckBox();
            checkXBow = new SDUI.Controls.CheckBox();
            checkWRod = new SDUI.Controls.CheckBox();
            checkShield = new SDUI.Controls.CheckBox();
            checkCRod = new SDUI.Controls.CheckBox();
            check2HSword = new SDUI.Controls.CheckBox();
            check1HSword = new SDUI.Controls.CheckBox();
            checkStaff = new SDUI.Controls.CheckBox();
            checkBow = new SDUI.Controls.CheckBox();
            checkSpear = new SDUI.Controls.CheckBox();
            checkGlave = new SDUI.Controls.CheckBox();
            checkSword = new SDUI.Controls.CheckBox();
            checkBlade = new SDUI.Controls.CheckBox();
            separator2 = new SDUI.Controls.Separator();
            groupAccessories = new SDUI.Controls.GroupBox();
            checkNecklace = new SDUI.Controls.CheckBox();
            checkEarring = new SDUI.Controls.CheckBox();
            checkRing = new SDUI.Controls.CheckBox();
            separator3 = new SDUI.Controls.Separator();
            groupClothes = new SDUI.Controls.GroupBox();
            checkHand = new SDUI.Controls.CheckBox();
            checkLegs = new SDUI.Controls.CheckBox();
            checkHeavy = new SDUI.Controls.CheckBox();
            checkLight = new SDUI.Controls.CheckBox();
            checkClothes = new SDUI.Controls.CheckBox();
            checkBoot = new SDUI.Controls.CheckBox();
            checkChest = new SDUI.Controls.CheckBox();
            checkShoulder = new SDUI.Controls.CheckBox();
            checkHead = new SDUI.Controls.CheckBox();
            separator4 = new SDUI.Controls.Separator();
            groupGender = new SDUI.Controls.GroupBox();
            checkEuropean = new SDUI.Controls.CheckBox();
            checkChinese = new SDUI.Controls.CheckBox();
            checkFemale = new SDUI.Controls.CheckBox();
            checkBoxRareItems = new SDUI.Controls.CheckBox();
            checkMale = new SDUI.Controls.CheckBox();
            label3 = new SDUI.Controls.Label();
            numDegreeFrom = new SDUI.Controls.NumUpDown();
            numDegreeTo = new SDUI.Controls.NumUpDown();
            label4 = new SDUI.Controls.Label();
            panel3 = new SDUI.Controls.Panel();
            panel7 = new SDUI.Controls.Panel();
            labelResult = new SDUI.Controls.Label();
            btnResetFilter = new SDUI.Controls.Button();
            btnSearch = new SDUI.Controls.Button();
            btnReload = new SDUI.Controls.Button();
            txtSellSearch = new SDUI.Controls.TextBox();
            pictureBox1 = new PictureBox();
            tabPage1 = new TabPage();
            groupBoxOptions = new SDUI.Controls.GroupBox();
            checkPickupGold = new SDUI.Controls.CheckBox();
            checkAllEquips = new SDUI.Controls.CheckBox();
            checkEverything = new SDUI.Controls.CheckBox();
            checkPickupRare = new SDUI.Controls.CheckBox();
            checkQuestItems = new SDUI.Controls.CheckBox();
            checkPickupBlue = new SDUI.Controls.CheckBox();
            groupBoxGeneral = new SDUI.Controls.GroupBox();
            cbDontPickupWhileBotting = new SDUI.Controls.CheckBox();
            cbJustpickmyitems = new SDUI.Controls.CheckBox();
            checkDontPickupInBerzerk = new SDUI.Controls.CheckBox();
            checkEnableAbilityPet = new SDUI.Controls.CheckBox();
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
            contextShoppingList.Items.AddRange(new ToolStripItem[] { menuChangeAmount, toolStripSeparator1, menuRemoveItem });
            contextShoppingList.Name = "contextShoppingList";
            contextShoppingList.ShowImageMargin = false;
            contextShoppingList.Size = new Size(136, 54);
            // 
            // menuChangeAmount
            // 
            menuChangeAmount.ForeColor = Color.FromArgb(0, 0, 0);
            menuChangeAmount.Name = "menuChangeAmount";
            menuChangeAmount.Size = new Size(135, 22);
            menuChangeAmount.Text = "Change amount";
            menuChangeAmount.Click += menuChangeAmount_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(132, 6);
            // 
            // menuRemoveItem
            // 
            menuRemoveItem.ForeColor = Color.FromArgb(0, 0, 0);
            menuRemoveItem.Name = "menuRemoveItem";
            menuRemoveItem.Size = new Size(135, 22);
            menuRemoveItem.Text = "Remove";
            menuRemoveItem.Click += menuRemoveItem_Click;
            // 
            // contextAvailableProducts
            // 
            contextAvailableProducts.Items.AddRange(new ToolStripItem[] { menuAddToShoppingList });
            contextAvailableProducts.Name = "contextAvailableProducts";
            contextAvailableProducts.ShowImageMargin = false;
            contextAvailableProducts.Size = new Size(157, 26);
            // 
            // menuAddToShoppingList
            // 
            menuAddToShoppingList.ForeColor = Color.FromArgb(0, 0, 0);
            menuAddToShoppingList.Name = "menuAddToShoppingList";
            menuAddToShoppingList.Size = new Size(156, 22);
            menuAddToShoppingList.Text = "Add to shopping list";
            menuAddToShoppingList.Click += menuAddToShoppingList_Click;
            // 
            // tabMain
            // 
            tabMain.Border = new Padding(0, 1, 0, 0);
            tabMain.Controls.Add(tabBuyFilter);
            tabMain.Controls.Add(tabSellFilter);
            tabMain.Controls.Add(tabPage1);
            tabMain.Dock = DockStyle.Fill;
            tabMain.HideTabArea = false;
            tabMain.Location = new Point(0, 0);
            tabMain.Name = "tabMain";
            tabMain.SelectedIndex = 0;
            tabMain.Size = new Size(754, 473);
            tabMain.TabIndex = 7;
            // 
            // tabBuyFilter
            // 
            tabBuyFilter.BackColor = Color.White;
            tabBuyFilter.Controls.Add(splitContainer);
            tabBuyFilter.Controls.Add(separator5);
            tabBuyFilter.Controls.Add(groupBox1);
            tabBuyFilter.Location = new Point(4, 24);
            tabBuyFilter.Name = "tabBuyFilter";
            tabBuyFilter.Padding = new Padding(8);
            tabBuyFilter.Size = new Size(746, 445);
            tabBuyFilter.TabIndex = 0;
            tabBuyFilter.Text = "Shopping";
            // 
            // splitContainer
            // 
            splitContainer.Dock = DockStyle.Fill;
            splitContainer.Location = new Point(8, 8);
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
            splitContainer.Size = new Size(730, 359);
            splitContainer.SplitterDistance = 336;
            splitContainer.SplitterWidth = 1;
            splitContainer.TabIndex = 6;
            // 
            // listAvailableProducts
            // 
            listAvailableProducts.BackColor = Color.White;
            listAvailableProducts.BorderStyle = BorderStyle.None;
            listAvailableProducts.Columns.AddRange(new ColumnHeader[] { colAvailableName });
            listAvailableProducts.ContextMenuStrip = contextAvailableProducts;
            listAvailableProducts.Dock = DockStyle.Fill;
            listAvailableProducts.ForeColor = Color.FromArgb(0, 0, 0);
            listAvailableProducts.FullRowSelect = true;
            listAvailableProducts.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            listAvailableProducts.Location = new Point(0, 57);
            listAvailableProducts.Name = "listAvailableProducts";
            listAvailableProducts.Size = new Size(336, 302);
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
            panel1.BackColor = Color.Transparent;
            panel1.Border = new Padding(0, 0, 0, 1);
            panel1.BorderColor = Color.Transparent;
            panel1.Controls.Add(label6);
            panel1.Controls.Add(checkShowEquipment);
            panel1.Controls.Add(txtShopSearch);
            panel1.Controls.Add(comboStore);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Radius = 0;
            panel1.ShadowDepth = 4F;
            panel1.Size = new Size(336, 57);
            panel1.TabIndex = 6;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.ForeColor = Color.FromArgb(0, 0, 0);
            label6.Location = new Point(5, 32);
            label6.Name = "label6";
            label6.Size = new Size(45, 15);
            label6.TabIndex = 10;
            label6.Text = "Search:";
            // 
            // checkShowEquipment
            // 
            checkShowEquipment.AutoSize = true;
            checkShowEquipment.BackColor = Color.Transparent;
            checkShowEquipment.Location = new Point(211, 21);
            checkShowEquipment.Name = "checkShowEquipment";
            checkShowEquipment.ShadowDepth = 1;
            checkShowEquipment.Size = new Size(113, 15);
            checkShowEquipment.TabIndex = 9;
            checkShowEquipment.Text = "Show equipment";
            checkShowEquipment.UseVisualStyleBackColor = false;
            checkShowEquipment.CheckedChanged += checkShowEquipment_CheckedChanged;
            // 
            // txtShopSearch
            // 
            txtShopSearch.Location = new Point(61, 29);
            txtShopSearch.MaxLength = 32767;
            txtShopSearch.MultiLine = false;
            txtShopSearch.Name = "txtShopSearch";
            txtShopSearch.Radius = 2;
            txtShopSearch.Size = new Size(144, 21);
            txtShopSearch.TabIndex = 8;
            txtShopSearch.TextAlignment = HorizontalAlignment.Left;
            txtShopSearch.UseSystemPasswordChar = false;
            txtShopSearch.TextChanged += txtShopSearch_TextChanged;
            // 
            // comboStore
            // 
            comboStore.DrawMode = DrawMode.OwnerDrawFixed;
            comboStore.DropDownHeight = 100;
            comboStore.DropDownStyle = ComboBoxStyle.DropDownList;
            comboStore.FormattingEnabled = true;
            comboStore.IntegralHeight = false;
            comboStore.ItemHeight = 17;
            comboStore.Items.AddRange(new object[] { "Potion trader", "Stable keeper", "Protector trader", "Weapon trader", "Accessory trader" });
            comboStore.Location = new Point(61, 4);
            comboStore.Name = "comboStore";
            comboStore.Radius = 5;
            comboStore.ShadowDepth = 4F;
            comboStore.Size = new Size(144, 23);
            comboStore.TabIndex = 2;
            comboStore.SelectedIndexChanged += comboStore_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.FromArgb(0, 0, 0);
            label1.Location = new Point(12, 7);
            label1.Name = "label1";
            label1.Size = new Size(41, 15);
            label1.TabIndex = 5;
            label1.Text = "Store:";
            // 
            // listShoppingList
            // 
            listShoppingList.BackColor = Color.White;
            listShoppingList.BorderStyle = BorderStyle.None;
            listShoppingList.Columns.AddRange(new ColumnHeader[] { colName, colAmount });
            listShoppingList.ContextMenuStrip = contextShoppingList;
            listShoppingList.Dock = DockStyle.Fill;
            listShoppingList.ForeColor = Color.FromArgb(0, 0, 0);
            listShoppingList.FullRowSelect = true;
            listViewGroup6.Header = "Potion trader";
            listViewGroup6.Name = "groupPotion";
            listViewGroup7.Header = "Stable keeper";
            listViewGroup7.Name = "groupStable";
            listViewGroup8.Header = "Protector trader";
            listViewGroup8.Name = "groupProtector";
            listViewGroup9.Header = "Weapon trader";
            listViewGroup9.Name = "groupWeapon";
            listViewGroup10.Header = "Accessory trader";
            listViewGroup10.Name = "groupAccessory";
            listShoppingList.Groups.AddRange(new ListViewGroup[] { listViewGroup6, listViewGroup7, listViewGroup8, listViewGroup9, listViewGroup10 });
            listShoppingList.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            listShoppingList.Location = new Point(0, 57);
            listShoppingList.Name = "listShoppingList";
            listShoppingList.Size = new Size(393, 302);
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
            panel2.BackColor = Color.Transparent;
            panel2.Border = new Padding(0, 0, 0, 1);
            panel2.BorderColor = Color.Transparent;
            panel2.Dock = DockStyle.Top;
            panel2.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Radius = 0;
            panel2.ShadowDepth = 4F;
            panel2.Size = new Size(393, 57);
            panel2.TabIndex = 7;
            // 
            // separator5
            // 
            separator5.Dock = DockStyle.Bottom;
            separator5.IsVertical = false;
            separator5.Location = new Point(8, 367);
            separator5.Name = "separator5";
            separator5.Size = new Size(730, 10);
            separator5.TabIndex = 9;
            separator5.Text = "separator5";
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.Transparent;
            groupBox1.Controls.Add(checkSellItemsFromPet);
            groupBox1.Controls.Add(checkStoreItemsFromPet);
            groupBox1.Controls.Add(checkRepairGear);
            groupBox1.Controls.Add(checkEnable);
            groupBox1.Dock = DockStyle.Bottom;
            groupBox1.Location = new Point(8, 377);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 10, 3, 3);
            groupBox1.Radius = 10;
            groupBox1.ShadowDepth = 4;
            groupBox1.Size = new Size(730, 60);
            groupBox1.TabIndex = 8;
            groupBox1.TabStop = false;
            groupBox1.Text = "General setup";
            // 
            // checkSellItemsFromPet
            // 
            checkSellItemsFromPet.AutoSize = true;
            checkSellItemsFromPet.BackColor = Color.Transparent;
            checkSellItemsFromPet.Checked = true;
            checkSellItemsFromPet.CheckState = CheckState.Checked;
            checkSellItemsFromPet.Location = new Point(425, 33);
            checkSellItemsFromPet.Name = "checkSellItemsFromPet";
            checkSellItemsFromPet.ShadowDepth = 1;
            checkSellItemsFromPet.Size = new Size(122, 15);
            checkSellItemsFromPet.TabIndex = 3;
            checkSellItemsFromPet.Text = "Sell items from pet";
            checkSellItemsFromPet.UseVisualStyleBackColor = false;
            checkSellItemsFromPet.CheckedChanged += checkSellItemsFromPet_CheckedChanged;
            // 
            // checkStoreItemsFromPet
            // 
            checkStoreItemsFromPet.AutoSize = true;
            checkStoreItemsFromPet.BackColor = Color.Transparent;
            checkStoreItemsFromPet.Checked = true;
            checkStoreItemsFromPet.CheckState = CheckState.Checked;
            checkStoreItemsFromPet.Location = new Point(567, 33);
            checkStoreItemsFromPet.Name = "checkStoreItemsFromPet";
            checkStoreItemsFromPet.ShadowDepth = 1;
            checkStoreItemsFromPet.Size = new Size(131, 15);
            checkStoreItemsFromPet.TabIndex = 4;
            checkStoreItemsFromPet.Text = "Store items from pet";
            checkStoreItemsFromPet.UseVisualStyleBackColor = false;
            checkStoreItemsFromPet.CheckedChanged += checkStoreItemsFromPet_CheckedChanged;
            // 
            // checkRepairGear
            // 
            checkRepairGear.AutoSize = true;
            checkRepairGear.BackColor = Color.Transparent;
            checkRepairGear.Checked = true;
            checkRepairGear.CheckState = CheckState.Checked;
            checkRepairGear.Location = new Point(231, 33);
            checkRepairGear.Name = "checkRepairGear";
            checkRepairGear.ShadowDepth = 1;
            checkRepairGear.Size = new Size(168, 15);
            checkRepairGear.TabIndex = 1;
            checkRepairGear.Text = "Automaticaly repair all gear";
            checkRepairGear.UseVisualStyleBackColor = false;
            checkRepairGear.CheckedChanged += checkRepairGear_CheckedChanged;
            // 
            // checkEnable
            // 
            checkEnable.AutoSize = true;
            checkEnable.BackColor = Color.Transparent;
            checkEnable.Checked = true;
            checkEnable.CheckState = CheckState.Checked;
            checkEnable.Location = new Point(13, 33);
            checkEnable.Name = "checkEnable";
            checkEnable.ShadowDepth = 1;
            checkEnable.Size = new Size(190, 15);
            checkEnable.TabIndex = 0;
            checkEnable.Text = "Automaticaly run when in town";
            checkEnable.UseVisualStyleBackColor = false;
            checkEnable.CheckedChanged += checkEnable_CheckedChanged;
            // 
            // tabSellFilter
            // 
            tabSellFilter.BackColor = Color.White;
            tabSellFilter.Controls.Add(listFilter);
            tabSellFilter.Controls.Add(filterPanel);
            tabSellFilter.Controls.Add(panel3);
            tabSellFilter.Controls.Add(pictureBox1);
            tabSellFilter.Location = new Point(4, 25);
            tabSellFilter.Name = "tabSellFilter";
            tabSellFilter.Size = new Size(746, 444);
            tabSellFilter.TabIndex = 1;
            tabSellFilter.Text = "Item filter";
            // 
            // listFilter
            // 
            listFilter.BackColor = Color.White;
            listFilter.BorderStyle = BorderStyle.None;
            listFilter.Columns.AddRange(new ColumnHeader[] { colItemName, colItemLevel, colGender, colPickup, colSell, collStore });
            listFilter.ContextMenuStrip = contextList;
            listFilter.Dock = DockStyle.Fill;
            listFilter.ForeColor = Color.FromArgb(0, 0, 0);
            listFilter.FullRowSelect = true;
            listFilter.Location = new Point(265, 0);
            listFilter.Name = "listFilter";
            listFilter.Size = new Size(481, 408);
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
            contextList.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            contextList.ImageScalingSize = new Size(24, 24);
            contextList.Items.AddRange(new ToolStripItem[] { btnAddToSell, btnAddToStore, btnPickup, btnPickOnlyCharacter, toolStripSeparator2, btnDontSell, btnDontStore, btnDontPickup });
            contextList.Name = "contextSellList";
            contextList.ShowCheckMargin = true;
            contextList.ShowImageMargin = false;
            contextList.Size = new Size(207, 164);
            contextList.Opening += contextList_Opening;
            // 
            // btnAddToSell
            // 
            btnAddToSell.ForeColor = Color.FromArgb(0, 0, 0);
            btnAddToSell.Name = "btnAddToSell";
            btnAddToSell.Size = new Size(206, 22);
            btnAddToSell.Text = "Sell";
            btnAddToSell.Click += btnAddToSell_Click;
            // 
            // btnAddToStore
            // 
            btnAddToStore.ForeColor = Color.FromArgb(0, 0, 0);
            btnAddToStore.Name = "btnAddToStore";
            btnAddToStore.Size = new Size(206, 22);
            btnAddToStore.Text = "Store";
            btnAddToStore.Click += btnAddToStore_Click;
            // 
            // btnPickup
            // 
            btnPickup.ForeColor = Color.FromArgb(0, 0, 0);
            btnPickup.Name = "btnPickup";
            btnPickup.Size = new Size(206, 22);
            btnPickup.Text = "Pickup";
            btnPickup.Click += btnPickup_Click;
            // 
            // btnPickOnlyCharacter
            // 
            btnPickOnlyCharacter.ForeColor = Color.FromArgb(0, 0, 0);
            btnPickOnlyCharacter.Name = "btnPickOnlyCharacter";
            btnPickOnlyCharacter.Size = new Size(206, 22);
            btnPickOnlyCharacter.Text = "Pickup only character";
            btnPickOnlyCharacter.Click += btnPickOnlyCharacter_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(203, 6);
            // 
            // btnDontSell
            // 
            btnDontSell.ForeColor = Color.FromArgb(0, 0, 0);
            btnDontSell.Name = "btnDontSell";
            btnDontSell.Size = new Size(206, 22);
            btnDontSell.Text = "Don't sell";
            btnDontSell.Click += btnDontSell_Click;
            // 
            // btnDontStore
            // 
            btnDontStore.ForeColor = Color.FromArgb(0, 0, 0);
            btnDontStore.Name = "btnDontStore";
            btnDontStore.Size = new Size(206, 22);
            btnDontStore.Text = "Don't store";
            btnDontStore.Click += btnDontStore_Click;
            // 
            // btnDontPickup
            // 
            btnDontPickup.ForeColor = Color.FromArgb(0, 0, 0);
            btnDontPickup.Name = "btnDontPickup";
            btnDontPickup.Size = new Size(206, 22);
            btnDontPickup.Text = "Don't pickup";
            btnDontPickup.Click += btnDontPickup_Click;
            // 
            // searchImageList
            // 
            searchImageList.ColorDepth = ColorDepth.Depth8Bit;
            searchImageList.ImageSize = new Size(16, 16);
            searchImageList.TransparentColor = Color.Transparent;
            // 
            // filterPanel
            // 
            filterPanel.AutoScroll = true;
            filterPanel.AutoScrollMargin = new Size(0, 10);
            filterPanel.AutoScrollMinSize = new Size(0, 720);
            filterPanel.BackColor = Color.Transparent;
            filterPanel.Border = new Padding(0, 0, 1, 0);
            filterPanel.BorderColor = Color.Transparent;
            filterPanel.Controls.Add(groupOthers);
            filterPanel.Controls.Add(separator1);
            filterPanel.Controls.Add(groupWeapons);
            filterPanel.Controls.Add(separator2);
            filterPanel.Controls.Add(groupAccessories);
            filterPanel.Controls.Add(separator3);
            filterPanel.Controls.Add(groupClothes);
            filterPanel.Controls.Add(separator4);
            filterPanel.Controls.Add(groupGender);
            filterPanel.Dock = DockStyle.Left;
            filterPanel.Location = new Point(0, 0);
            filterPanel.Name = "filterPanel";
            filterPanel.Padding = new Padding(12);
            filterPanel.Radius = 0;
            filterPanel.ShadowDepth = 4F;
            filterPanel.Size = new Size(265, 408);
            filterPanel.TabIndex = 20;
            // 
            // groupOthers
            // 
            groupOthers.BackColor = Color.Transparent;
            groupOthers.Controls.Add(checkAlchemy);
            groupOthers.Controls.Add(checkQuest);
            groupOthers.Controls.Add(checkAmmo);
            groupOthers.Controls.Add(checkCoin);
            groupOthers.Controls.Add(checkOther);
            groupOthers.Dock = DockStyle.Top;
            groupOthers.Location = new Point(12, 590);
            groupOthers.Name = "groupOthers";
            groupOthers.Padding = new Padding(3, 10, 3, 3);
            groupOthers.Radius = 10;
            groupOthers.ShadowDepth = 4;
            groupOthers.Size = new Size(224, 106);
            groupOthers.TabIndex = 42;
            groupOthers.TabStop = false;
            groupOthers.Text = "Others";
            // 
            // checkAlchemy
            // 
            checkAlchemy.AutoSize = true;
            checkAlchemy.BackColor = Color.Transparent;
            checkAlchemy.Location = new Point(99, 56);
            checkAlchemy.Name = "checkAlchemy";
            checkAlchemy.ShadowDepth = 1;
            checkAlchemy.Size = new Size(70, 15);
            checkAlchemy.TabIndex = 19;
            checkAlchemy.Text = "Alchemy";
            checkAlchemy.UseVisualStyleBackColor = false;
            // 
            // checkQuest
            // 
            checkQuest.AutoSize = true;
            checkQuest.BackColor = Color.Transparent;
            checkQuest.Location = new Point(11, 33);
            checkQuest.Name = "checkQuest";
            checkQuest.ShadowDepth = 1;
            checkQuest.Size = new Size(54, 15);
            checkQuest.TabIndex = 19;
            checkQuest.Text = "Quest";
            checkQuest.UseVisualStyleBackColor = false;
            // 
            // checkAmmo
            // 
            checkAmmo.AutoSize = true;
            checkAmmo.BackColor = Color.Transparent;
            checkAmmo.Location = new Point(11, 56);
            checkAmmo.Name = "checkAmmo";
            checkAmmo.ShadowDepth = 1;
            checkAmmo.Size = new Size(60, 15);
            checkAmmo.TabIndex = 19;
            checkAmmo.Text = "Ammo";
            checkAmmo.UseVisualStyleBackColor = false;
            // 
            // checkCoin
            // 
            checkCoin.AutoSize = true;
            checkCoin.BackColor = Color.Transparent;
            checkCoin.Location = new Point(99, 33);
            checkCoin.Name = "checkCoin";
            checkCoin.ShadowDepth = 1;
            checkCoin.Size = new Size(48, 15);
            checkCoin.TabIndex = 19;
            checkCoin.Text = "Coin";
            checkCoin.UseVisualStyleBackColor = false;
            // 
            // checkOther
            // 
            checkOther.AutoSize = true;
            checkOther.BackColor = Color.Transparent;
            checkOther.Location = new Point(11, 79);
            checkOther.Name = "checkOther";
            checkOther.ShadowDepth = 1;
            checkOther.Size = new Size(53, 15);
            checkOther.TabIndex = 19;
            checkOther.Text = "Other";
            checkOther.UseVisualStyleBackColor = false;
            // 
            // separator1
            // 
            separator1.Dock = DockStyle.Top;
            separator1.IsVertical = false;
            separator1.Location = new Point(12, 580);
            separator1.Name = "separator1";
            separator1.Size = new Size(224, 10);
            separator1.TabIndex = 5;
            separator1.Text = "separator1";
            // 
            // groupWeapons
            // 
            groupWeapons.BackColor = Color.Transparent;
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
            groupWeapons.Location = new Point(12, 373);
            groupWeapons.Margin = new Padding(6);
            groupWeapons.Name = "groupWeapons";
            groupWeapons.Padding = new Padding(3, 10, 3, 3);
            groupWeapons.Radius = 10;
            groupWeapons.ShadowDepth = 4;
            groupWeapons.Size = new Size(224, 207);
            groupWeapons.TabIndex = 40;
            groupWeapons.TabStop = false;
            groupWeapons.Text = "Weapons";
            // 
            // checkAxe
            // 
            checkAxe.AutoSize = true;
            checkAxe.BackColor = Color.Transparent;
            checkAxe.Location = new Point(99, 180);
            checkAxe.Name = "checkAxe";
            checkAxe.ShadowDepth = 1;
            checkAxe.Size = new Size(43, 15);
            checkAxe.TabIndex = 10;
            checkAxe.Text = "Axe";
            checkAxe.UseVisualStyleBackColor = false;
            // 
            // checkHarp
            // 
            checkHarp.AutoSize = true;
            checkHarp.BackColor = Color.Transparent;
            checkHarp.Location = new Point(11, 180);
            checkHarp.Name = "checkHarp";
            checkHarp.ShadowDepth = 1;
            checkHarp.Size = new Size(49, 15);
            checkHarp.TabIndex = 10;
            checkHarp.Text = "Harp";
            checkHarp.UseVisualStyleBackColor = false;
            // 
            // checkDagger
            // 
            checkDagger.AutoSize = true;
            checkDagger.BackColor = Color.Transparent;
            checkDagger.Location = new Point(99, 155);
            checkDagger.Name = "checkDagger";
            checkDagger.ShadowDepth = 1;
            checkDagger.Size = new Size(61, 15);
            checkDagger.TabIndex = 9;
            checkDagger.Text = "Dagger";
            checkDagger.UseVisualStyleBackColor = false;
            // 
            // checkXBow
            // 
            checkXBow.AutoSize = true;
            checkXBow.BackColor = Color.Transparent;
            checkXBow.Location = new Point(11, 155);
            checkXBow.Name = "checkXBow";
            checkXBow.ShadowDepth = 1;
            checkXBow.Size = new Size(58, 15);
            checkXBow.TabIndex = 9;
            checkXBow.Text = "X-Bow";
            checkXBow.UseVisualStyleBackColor = false;
            // 
            // checkWRod
            // 
            checkWRod.AutoSize = true;
            checkWRod.BackColor = Color.Transparent;
            checkWRod.Location = new Point(99, 130);
            checkWRod.Name = "checkWRod";
            checkWRod.ShadowDepth = 1;
            checkWRod.Size = new Size(60, 15);
            checkWRod.TabIndex = 8;
            checkWRod.Text = "W-Rod";
            checkWRod.UseVisualStyleBackColor = false;
            // 
            // checkShield
            // 
            checkShield.AutoSize = true;
            checkShield.BackColor = Color.Transparent;
            checkShield.Location = new Point(161, 180);
            checkShield.Name = "checkShield";
            checkShield.ShadowDepth = 1;
            checkShield.Size = new Size(55, 15);
            checkShield.TabIndex = 5;
            checkShield.Text = "Shield";
            checkShield.UseVisualStyleBackColor = false;
            // 
            // checkCRod
            // 
            checkCRod.AutoSize = true;
            checkCRod.BackColor = Color.Transparent;
            checkCRod.Location = new Point(11, 130);
            checkCRod.Name = "checkCRod";
            checkCRod.ShadowDepth = 1;
            checkCRod.Size = new Size(57, 15);
            checkCRod.TabIndex = 7;
            checkCRod.Text = "C-Rod";
            checkCRod.UseVisualStyleBackColor = false;
            // 
            // check2HSword
            // 
            check2HSword.AutoSize = true;
            check2HSword.BackColor = Color.Transparent;
            check2HSword.Location = new Point(99, 105);
            check2HSword.Name = "check2HSword";
            check2HSword.ShadowDepth = 1;
            check2HSword.Size = new Size(74, 15);
            check2HSword.TabIndex = 6;
            check2HSword.Text = "2H Sword";
            check2HSword.UseVisualStyleBackColor = false;
            // 
            // check1HSword
            // 
            check1HSword.AutoSize = true;
            check1HSword.BackColor = Color.Transparent;
            check1HSword.Location = new Point(11, 105);
            check1HSword.Name = "check1HSword";
            check1HSword.ShadowDepth = 1;
            check1HSword.Size = new Size(74, 15);
            check1HSword.TabIndex = 5;
            check1HSword.Text = "1H Sword";
            check1HSword.UseVisualStyleBackColor = false;
            // 
            // checkStaff
            // 
            checkStaff.AutoSize = true;
            checkStaff.BackColor = Color.Transparent;
            checkStaff.Location = new Point(99, 80);
            checkStaff.Name = "checkStaff";
            checkStaff.ShadowDepth = 1;
            checkStaff.Size = new Size(47, 15);
            checkStaff.TabIndex = 5;
            checkStaff.Text = "Staff";
            checkStaff.UseVisualStyleBackColor = false;
            // 
            // checkBow
            // 
            checkBow.AutoSize = true;
            checkBow.BackColor = Color.Transparent;
            checkBow.Location = new Point(11, 80);
            checkBow.Name = "checkBow";
            checkBow.ShadowDepth = 1;
            checkBow.Size = new Size(46, 15);
            checkBow.TabIndex = 4;
            checkBow.Text = "Bow";
            checkBow.UseVisualStyleBackColor = false;
            // 
            // checkSpear
            // 
            checkSpear.AutoSize = true;
            checkSpear.BackColor = Color.Transparent;
            checkSpear.Location = new Point(99, 55);
            checkSpear.Name = "checkSpear";
            checkSpear.ShadowDepth = 1;
            checkSpear.Size = new Size(52, 15);
            checkSpear.TabIndex = 3;
            checkSpear.Text = "Spear";
            checkSpear.UseVisualStyleBackColor = false;
            // 
            // checkGlave
            // 
            checkGlave.AutoSize = true;
            checkGlave.BackColor = Color.Transparent;
            checkGlave.Location = new Point(11, 55);
            checkGlave.Name = "checkGlave";
            checkGlave.ShadowDepth = 1;
            checkGlave.Size = new Size(52, 15);
            checkGlave.TabIndex = 2;
            checkGlave.Text = "Glave";
            checkGlave.UseVisualStyleBackColor = false;
            // 
            // checkSword
            // 
            checkSword.AutoSize = true;
            checkSword.BackColor = Color.Transparent;
            checkSword.Location = new Point(99, 30);
            checkSword.Name = "checkSword";
            checkSword.ShadowDepth = 1;
            checkSword.Size = new Size(56, 15);
            checkSword.TabIndex = 1;
            checkSword.Text = "Sword";
            checkSword.UseVisualStyleBackColor = false;
            // 
            // checkBlade
            // 
            checkBlade.AutoSize = true;
            checkBlade.BackColor = Color.Transparent;
            checkBlade.Location = new Point(11, 30);
            checkBlade.Name = "checkBlade";
            checkBlade.ShadowDepth = 1;
            checkBlade.Size = new Size(52, 15);
            checkBlade.TabIndex = 0;
            checkBlade.Text = "Blade";
            checkBlade.UseVisualStyleBackColor = false;
            // 
            // separator2
            // 
            separator2.Dock = DockStyle.Top;
            separator2.IsVertical = false;
            separator2.Location = new Point(12, 363);
            separator2.Name = "separator2";
            separator2.Size = new Size(224, 10);
            separator2.TabIndex = 45;
            separator2.Text = "separator2";
            // 
            // groupAccessories
            // 
            groupAccessories.BackColor = Color.Transparent;
            groupAccessories.Controls.Add(checkNecklace);
            groupAccessories.Controls.Add(checkEarring);
            groupAccessories.Controls.Add(checkRing);
            groupAccessories.Dock = DockStyle.Top;
            groupAccessories.Location = new Point(12, 305);
            groupAccessories.Name = "groupAccessories";
            groupAccessories.Padding = new Padding(3, 10, 3, 3);
            groupAccessories.Radius = 10;
            groupAccessories.ShadowDepth = 4;
            groupAccessories.Size = new Size(224, 58);
            groupAccessories.TabIndex = 44;
            groupAccessories.TabStop = false;
            groupAccessories.Text = "Accessories";
            // 
            // checkNecklace
            // 
            checkNecklace.AutoSize = true;
            checkNecklace.BackColor = Color.Transparent;
            checkNecklace.Location = new Point(71, 30);
            checkNecklace.Name = "checkNecklace";
            checkNecklace.ShadowDepth = 1;
            checkNecklace.Size = new Size(71, 15);
            checkNecklace.TabIndex = 4;
            checkNecklace.Text = "Necklace";
            checkNecklace.UseVisualStyleBackColor = false;
            // 
            // checkEarring
            // 
            checkEarring.AutoSize = true;
            checkEarring.BackColor = Color.Transparent;
            checkEarring.Location = new Point(157, 30);
            checkEarring.Name = "checkEarring";
            checkEarring.ShadowDepth = 1;
            checkEarring.Size = new Size(60, 15);
            checkEarring.TabIndex = 3;
            checkEarring.Text = "Earring";
            checkEarring.UseVisualStyleBackColor = false;
            // 
            // checkRing
            // 
            checkRing.AutoSize = true;
            checkRing.BackColor = Color.Transparent;
            checkRing.Location = new Point(11, 30);
            checkRing.Name = "checkRing";
            checkRing.ShadowDepth = 1;
            checkRing.Size = new Size(47, 15);
            checkRing.TabIndex = 2;
            checkRing.Text = "Ring";
            checkRing.UseVisualStyleBackColor = false;
            // 
            // separator3
            // 
            separator3.Dock = DockStyle.Top;
            separator3.IsVertical = false;
            separator3.Location = new Point(12, 295);
            separator3.Name = "separator3";
            separator3.Size = new Size(224, 10);
            separator3.TabIndex = 46;
            separator3.Text = "separator3";
            // 
            // groupClothes
            // 
            groupClothes.BackColor = Color.Transparent;
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
            groupClothes.Location = new Point(12, 160);
            groupClothes.Name = "groupClothes";
            groupClothes.Padding = new Padding(3, 10, 3, 3);
            groupClothes.Radius = 10;
            groupClothes.ShadowDepth = 4;
            groupClothes.Size = new Size(224, 135);
            groupClothes.TabIndex = 41;
            groupClothes.TabStop = false;
            groupClothes.Text = "Clothes";
            // 
            // checkHand
            // 
            checkHand.AutoSize = true;
            checkHand.BackColor = Color.Transparent;
            checkHand.Location = new Point(99, 108);
            checkHand.Name = "checkHand";
            checkHand.ShadowDepth = 1;
            checkHand.Size = new Size(52, 15);
            checkHand.TabIndex = 8;
            checkHand.Text = "Hand";
            checkHand.UseVisualStyleBackColor = false;
            // 
            // checkLegs
            // 
            checkLegs.AutoSize = true;
            checkLegs.BackColor = Color.Transparent;
            checkLegs.Location = new Point(11, 108);
            checkLegs.Name = "checkLegs";
            checkLegs.ShadowDepth = 1;
            checkLegs.Size = new Size(42, 15);
            checkLegs.TabIndex = 7;
            checkLegs.Text = "Leg";
            checkLegs.UseVisualStyleBackColor = false;
            // 
            // checkHeavy
            // 
            checkHeavy.AutoSize = true;
            checkHeavy.BackColor = Color.Transparent;
            checkHeavy.Location = new Point(164, 30);
            checkHeavy.Name = "checkHeavy";
            checkHeavy.ShadowDepth = 1;
            checkHeavy.Size = new Size(56, 15);
            checkHeavy.TabIndex = 6;
            checkHeavy.Text = "Heavy";
            checkHeavy.UseVisualStyleBackColor = false;
            // 
            // checkLight
            // 
            checkLight.AutoSize = true;
            checkLight.BackColor = Color.Transparent;
            checkLight.Location = new Point(99, 30);
            checkLight.Name = "checkLight";
            checkLight.ShadowDepth = 1;
            checkLight.Size = new Size(50, 15);
            checkLight.TabIndex = 6;
            checkLight.Text = "Light";
            checkLight.UseVisualStyleBackColor = false;
            // 
            // checkClothes
            // 
            checkClothes.AutoSize = true;
            checkClothes.BackColor = Color.Transparent;
            checkClothes.Location = new Point(11, 30);
            checkClothes.Name = "checkClothes";
            checkClothes.ShadowDepth = 1;
            checkClothes.Size = new Size(63, 15);
            checkClothes.TabIndex = 6;
            checkClothes.Text = "Clothes";
            checkClothes.UseVisualStyleBackColor = false;
            // 
            // checkBoot
            // 
            checkBoot.AutoSize = true;
            checkBoot.BackColor = Color.Transparent;
            checkBoot.Location = new Point(99, 83);
            checkBoot.Name = "checkBoot";
            checkBoot.ShadowDepth = 1;
            checkBoot.Size = new Size(48, 15);
            checkBoot.TabIndex = 4;
            checkBoot.Text = "Boot";
            checkBoot.UseVisualStyleBackColor = false;
            // 
            // checkChest
            // 
            checkChest.AutoSize = true;
            checkChest.BackColor = Color.Transparent;
            checkChest.Location = new Point(11, 83);
            checkChest.Name = "checkChest";
            checkChest.ShadowDepth = 1;
            checkChest.Size = new Size(53, 15);
            checkChest.TabIndex = 4;
            checkChest.Text = "Chest";
            checkChest.UseVisualStyleBackColor = false;
            // 
            // checkShoulder
            // 
            checkShoulder.AutoSize = true;
            checkShoulder.BackColor = Color.Transparent;
            checkShoulder.Location = new Point(99, 58);
            checkShoulder.Name = "checkShoulder";
            checkShoulder.ShadowDepth = 1;
            checkShoulder.Size = new Size(70, 15);
            checkShoulder.TabIndex = 4;
            checkShoulder.Text = "Shoulder";
            checkShoulder.UseVisualStyleBackColor = false;
            // 
            // checkHead
            // 
            checkHead.AutoSize = true;
            checkHead.BackColor = Color.Transparent;
            checkHead.Location = new Point(11, 58);
            checkHead.Name = "checkHead";
            checkHead.ShadowDepth = 1;
            checkHead.Size = new Size(51, 15);
            checkHead.TabIndex = 4;
            checkHead.Text = "Head";
            checkHead.UseVisualStyleBackColor = false;
            // 
            // separator4
            // 
            separator4.Dock = DockStyle.Top;
            separator4.IsVertical = false;
            separator4.Location = new Point(12, 150);
            separator4.Name = "separator4";
            separator4.Size = new Size(224, 10);
            separator4.TabIndex = 47;
            separator4.Text = "separator4";
            // 
            // groupGender
            // 
            groupGender.BackColor = Color.Transparent;
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
            groupGender.Location = new Point(12, 12);
            groupGender.Margin = new Padding(6);
            groupGender.Name = "groupGender";
            groupGender.Padding = new Padding(3, 10, 3, 3);
            groupGender.Radius = 10;
            groupGender.ShadowDepth = 4;
            groupGender.Size = new Size(224, 138);
            groupGender.TabIndex = 44;
            groupGender.TabStop = false;
            groupGender.Text = "Gender and Degree";
            // 
            // checkEuropean
            // 
            checkEuropean.AutoSize = true;
            checkEuropean.BackColor = Color.Transparent;
            checkEuropean.Location = new Point(99, 53);
            checkEuropean.Name = "checkEuropean";
            checkEuropean.ShadowDepth = 1;
            checkEuropean.Size = new Size(73, 15);
            checkEuropean.TabIndex = 9;
            checkEuropean.Text = "European";
            checkEuropean.UseVisualStyleBackColor = false;
            // 
            // checkChinese
            // 
            checkChinese.AutoSize = true;
            checkChinese.BackColor = Color.Transparent;
            checkChinese.Location = new Point(16, 53);
            checkChinese.Name = "checkChinese";
            checkChinese.ShadowDepth = 1;
            checkChinese.Size = new Size(65, 15);
            checkChinese.TabIndex = 9;
            checkChinese.Text = "Chinese";
            checkChinese.UseVisualStyleBackColor = false;
            // 
            // checkFemale
            // 
            checkFemale.AutoSize = true;
            checkFemale.BackColor = Color.Transparent;
            checkFemale.Location = new Point(99, 30);
            checkFemale.Name = "checkFemale";
            checkFemale.ShadowDepth = 1;
            checkFemale.Size = new Size(61, 15);
            checkFemale.TabIndex = 9;
            checkFemale.Text = "Female";
            checkFemale.UseVisualStyleBackColor = false;
            // 
            // checkBoxRareItems
            // 
            checkBoxRareItems.AutoSize = true;
            checkBoxRareItems.BackColor = Color.Transparent;
            checkBoxRareItems.Location = new Point(16, 76);
            checkBoxRareItems.Name = "checkBoxRareItems";
            checkBoxRareItems.ShadowDepth = 1;
            checkBoxRareItems.Size = new Size(76, 15);
            checkBoxRareItems.TabIndex = 40;
            checkBoxRareItems.Text = "Rare (Sox)";
            checkBoxRareItems.UseVisualStyleBackColor = false;
            // 
            // checkMale
            // 
            checkMale.AutoSize = true;
            checkMale.BackColor = Color.Transparent;
            checkMale.Location = new Point(16, 30);
            checkMale.Name = "checkMale";
            checkMale.ShadowDepth = 1;
            checkMale.Size = new Size(49, 15);
            checkMale.TabIndex = 9;
            checkMale.Text = "Male";
            checkMale.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = Color.FromArgb(0, 0, 0);
            label3.Location = new Point(16, 104);
            label3.Name = "label3";
            label3.Size = new Size(47, 15);
            label3.TabIndex = 31;
            label3.Text = "Degree:";
            // 
            // numDegreeFrom
            // 
            numDegreeFrom.BackColor = Color.FromArgb(238, 238, 238);
            numDegreeFrom.BorderStyle = BorderStyle.FixedSingle;
            numDegreeFrom.ForeColor = Color.FromArgb(0, 0, 0);
            numDegreeFrom.Location = new Point(72, 101);
            numDegreeFrom.Name = "numDegreeFrom";
            numDegreeFrom.Size = new Size(39, 23);
            numDegreeFrom.TabIndex = 32;
            // 
            // numDegreeTo
            // 
            numDegreeTo.BackColor = Color.FromArgb(238, 238, 238);
            numDegreeTo.BorderStyle = BorderStyle.FixedSingle;
            numDegreeTo.ForeColor = Color.FromArgb(0, 0, 0);
            numDegreeTo.Location = new Point(140, 101);
            numDegreeTo.Name = "numDegreeTo";
            numDegreeTo.Size = new Size(39, 23);
            numDegreeTo.TabIndex = 34;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label4.ForeColor = Color.FromArgb(0, 0, 0);
            label4.Location = new Point(116, 101);
            label4.Name = "label4";
            label4.Size = new Size(18, 19);
            label4.TabIndex = 33;
            label4.Text = "~";
            // 
            // panel3
            // 
            panel3.BackColor = Color.Transparent;
            panel3.Border = new Padding(0, 0, 0, 0);
            panel3.BorderColor = Color.Transparent;
            panel3.Controls.Add(panel7);
            panel3.Controls.Add(labelResult);
            panel3.Controls.Add(btnResetFilter);
            panel3.Controls.Add(btnSearch);
            panel3.Controls.Add(btnReload);
            panel3.Controls.Add(txtSellSearch);
            panel3.Dock = DockStyle.Bottom;
            panel3.Location = new Point(0, 408);
            panel3.Margin = new Padding(0);
            panel3.Name = "panel3";
            panel3.Radius = 0;
            panel3.ShadowDepth = 4F;
            panel3.Size = new Size(746, 36);
            panel3.TabIndex = 40;
            // 
            // panel7
            // 
            panel7.BackColor = Color.Transparent;
            panel7.Border = new Padding(0, 0, 0, 0);
            panel7.BorderColor = Color.Transparent;
            panel7.Dock = DockStyle.Top;
            panel7.Location = new Point(0, 0);
            panel7.Margin = new Padding(0);
            panel7.Name = "panel7";
            panel7.Radius = 1;
            panel7.ShadowDepth = 4F;
            panel7.Size = new Size(746, 1);
            panel7.TabIndex = 41;
            // 
            // labelResult
            // 
            labelResult.AutoSize = true;
            labelResult.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            labelResult.Location = new Point(280, 11);
            labelResult.Name = "labelResult";
            labelResult.Size = new Size(0, 15);
            labelResult.TabIndex = 40;
            // 
            // btnResetFilter
            // 
            btnResetFilter.Color = Color.Transparent;
            btnResetFilter.Location = new Point(12, 7);
            btnResetFilter.Name = "btnResetFilter";
            btnResetFilter.Radius = 6;
            btnResetFilter.ShadowDepth = 4F;
            btnResetFilter.Size = new Size(96, 23);
            btnResetFilter.TabIndex = 39;
            btnResetFilter.Text = "Reset";
            btnResetFilter.UseVisualStyleBackColor = true;
            btnResetFilter.Click += btnResetFilter_Click;
            // 
            // btnSearch
            // 
            btnSearch.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSearch.Color = Color.DodgerBlue;
            btnSearch.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnSearch.ForeColor = Color.White;
            btnSearch.Location = new Point(667, 6);
            btnSearch.Name = "btnSearch";
            btnSearch.Radius = 6;
            btnSearch.ShadowDepth = 4F;
            btnSearch.Size = new Size(75, 23);
            btnSearch.TabIndex = 21;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnApply_Click;
            // 
            // btnReload
            // 
            btnReload.Color = Color.Transparent;
            btnReload.Location = new Point(112, 7);
            btnReload.Name = "btnReload";
            btnReload.Radius = 6;
            btnReload.ShadowDepth = 4F;
            btnReload.Size = new Size(137, 23);
            btnReload.TabIndex = 39;
            btnReload.Text = "Apply";
            btnReload.UseVisualStyleBackColor = true;
            btnReload.Click += btnApply_Click;
            // 
            // txtSellSearch
            // 
            txtSellSearch.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            txtSellSearch.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txtSellSearch.Location = new Point(442, 7);
            txtSellSearch.MaxLength = 32767;
            txtSellSearch.MultiLine = false;
            txtSellSearch.Name = "txtSellSearch";
            txtSellSearch.Radius = 2;
            txtSellSearch.Size = new Size(221, 21);
            txtSellSearch.TabIndex = 20;
            txtSellSearch.TextAlignment = HorizontalAlignment.Left;
            txtSellSearch.UseSystemPasswordChar = false;
            txtSellSearch.KeyDown += txtSellSearch_KeyDown;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Resources.loading;
            pictureBox1.Location = new Point(465, 149);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(121, 69);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 22;
            pictureBox1.TabStop = false;
            // 
            // tabPage1
            // 
            tabPage1.BackColor = Color.White;
            tabPage1.Controls.Add(groupBoxOptions);
            tabPage1.Controls.Add(groupBoxGeneral);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(746, 445);
            tabPage1.TabIndex = 2;
            tabPage1.Text = "Pickup settings";
            // 
            // groupBoxOptions
            // 
            groupBoxOptions.BackColor = Color.Transparent;
            groupBoxOptions.Controls.Add(checkPickupGold);
            groupBoxOptions.Controls.Add(checkAllEquips);
            groupBoxOptions.Controls.Add(checkEverything);
            groupBoxOptions.Controls.Add(checkPickupRare);
            groupBoxOptions.Controls.Add(checkQuestItems);
            groupBoxOptions.Controls.Add(checkPickupBlue);
            groupBoxOptions.Location = new Point(6, 117);
            groupBoxOptions.Name = "groupBoxOptions";
            groupBoxOptions.Padding = new Padding(3, 8, 3, 3);
            groupBoxOptions.Radius = 10;
            groupBoxOptions.ShadowDepth = 4;
            groupBoxOptions.Size = new Size(734, 100);
            groupBoxOptions.TabIndex = 6;
            groupBoxOptions.TabStop = false;
            groupBoxOptions.Text = "Options";
            // 
            // checkPickupGold
            // 
            checkPickupGold.AutoSize = true;
            checkPickupGold.BackColor = Color.Transparent;
            checkPickupGold.Location = new Point(15, 41);
            checkPickupGold.Name = "checkPickupGold";
            checkPickupGold.ShadowDepth = 1;
            checkPickupGold.Size = new Size(86, 15);
            checkPickupGold.TabIndex = 0;
            checkPickupGold.Text = "Pickup gold";
            checkPickupGold.UseVisualStyleBackColor = false;
            checkPickupGold.CheckedChanged += checkPickupGold_CheckedChanged;
            // 
            // checkAllEquips
            // 
            checkAllEquips.AutoSize = true;
            checkAllEquips.BackColor = Color.Transparent;
            checkAllEquips.Location = new Point(272, 65);
            checkAllEquips.Name = "checkAllEquips";
            checkAllEquips.ShadowDepth = 1;
            checkAllEquips.Size = new Size(139, 15);
            checkAllEquips.TabIndex = 5;
            checkAllEquips.Text = "Pickup all equip items";
            checkAllEquips.UseVisualStyleBackColor = false;
            checkAllEquips.CheckedChanged += checkAllEquips_CheckedChanged;
            // 
            // checkEverything
            // 
            checkEverything.AutoSize = true;
            checkEverything.BackColor = Color.Transparent;
            checkEverything.Location = new Point(506, 65);
            checkEverything.Name = "checkEverything";
            checkEverything.ShadowDepth = 1;
            checkEverything.Size = new Size(118, 15);
            checkEverything.TabIndex = 4;
            checkEverything.Text = "Pickup everything";
            checkEverything.UseVisualStyleBackColor = false;
            checkEverything.CheckedChanged += checkEverything_CheckedChanged;
            // 
            // checkPickupRare
            // 
            checkPickupRare.AutoSize = true;
            checkPickupRare.BackColor = Color.Transparent;
            checkPickupRare.Location = new Point(15, 65);
            checkPickupRare.Name = "checkPickupRare";
            checkPickupRare.ShadowDepth = 1;
            checkPickupRare.Size = new Size(154, 15);
            checkPickupRare.TabIndex = 1;
            checkPickupRare.Text = "Always pickup rare items";
            checkPickupRare.UseVisualStyleBackColor = false;
            checkPickupRare.CheckedChanged += checkPickupRare_CheckedChanged;
            // 
            // checkQuestItems
            // 
            checkQuestItems.AutoSize = true;
            checkQuestItems.BackColor = Color.Transparent;
            checkQuestItems.Location = new Point(506, 41);
            checkQuestItems.Name = "checkQuestItems";
            checkQuestItems.ShadowDepth = 1;
            checkQuestItems.Size = new Size(123, 15);
            checkQuestItems.TabIndex = 4;
            checkQuestItems.Text = "Pickup quest items";
            checkQuestItems.UseVisualStyleBackColor = false;
            checkQuestItems.CheckedChanged += checkQuestItems_CheckedChanged;
            // 
            // checkPickupBlue
            // 
            checkPickupBlue.AutoSize = true;
            checkPickupBlue.BackColor = Color.Transparent;
            checkPickupBlue.Location = new Point(272, 41);
            checkPickupBlue.Name = "checkPickupBlue";
            checkPickupBlue.ShadowDepth = 1;
            checkPickupBlue.Size = new Size(157, 15);
            checkPickupBlue.TabIndex = 1;
            checkPickupBlue.Text = "Always pickup blue items";
            checkPickupBlue.UseVisualStyleBackColor = false;
            checkPickupBlue.CheckedChanged += checkPickupBlue_CheckedChanged;
            // 
            // groupBoxGeneral
            // 
            groupBoxGeneral.BackColor = Color.Transparent;
            groupBoxGeneral.Controls.Add(cbDontPickupWhileBotting);
            groupBoxGeneral.Controls.Add(cbJustpickmyitems);
            groupBoxGeneral.Controls.Add(checkDontPickupInBerzerk);
            groupBoxGeneral.Controls.Add(checkEnableAbilityPet);
            groupBoxGeneral.Location = new Point(6, 6);
            groupBoxGeneral.Name = "groupBoxGeneral";
            groupBoxGeneral.Padding = new Padding(3, 10, 3, 3);
            groupBoxGeneral.Radius = 10;
            groupBoxGeneral.ShadowDepth = 4;
            groupBoxGeneral.Size = new Size(734, 95);
            groupBoxGeneral.TabIndex = 0;
            groupBoxGeneral.TabStop = false;
            groupBoxGeneral.Text = "General";
            // 
            // cbDontPickupWhileBotting
            // 
            cbDontPickupWhileBotting.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cbDontPickupWhileBotting.AutoSize = true;
            cbDontPickupWhileBotting.BackColor = Color.Transparent;
            cbDontPickupWhileBotting.Location = new Point(506, 38);
            cbDontPickupWhileBotting.Name = "cbDontPickupWhileBotting";
            cbDontPickupWhileBotting.ShadowDepth = 1;
            cbDontPickupWhileBotting.Size = new Size(196, 15);
            cbDontPickupWhileBotting.TabIndex = 3;
            cbDontPickupWhileBotting.Text = "Don't pickup items while botting";
            cbDontPickupWhileBotting.UseVisualStyleBackColor = false;
            cbDontPickupWhileBotting.CheckedChanged += cbDontPickupWhileBotting_CheckedChanged;
            // 
            // cbJustpickmyitems
            // 
            cbJustpickmyitems.AutoSize = true;
            cbJustpickmyitems.BackColor = Color.Transparent;
            cbJustpickmyitems.Location = new Point(272, 38);
            cbJustpickmyitems.Name = "cbJustpickmyitems";
            cbJustpickmyitems.ShadowDepth = 1;
            cbJustpickmyitems.Size = new Size(120, 15);
            cbJustpickmyitems.TabIndex = 1;
            cbJustpickmyitems.Text = "Just pick my items";
            cbJustpickmyitems.UseVisualStyleBackColor = false;
            cbJustpickmyitems.CheckedChanged += cbJustpickmyitems_CheckedChanged;
            // 
            // checkDontPickupInBerzerk
            // 
            checkDontPickupInBerzerk.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            checkDontPickupInBerzerk.AutoSize = true;
            checkDontPickupInBerzerk.BackColor = Color.Transparent;
            checkDontPickupInBerzerk.Location = new Point(15, 64);
            checkDontPickupInBerzerk.Name = "checkDontPickupInBerzerk";
            checkDontPickupInBerzerk.ShadowDepth = 1;
            checkDontPickupInBerzerk.Size = new Size(211, 15);
            checkDontPickupInBerzerk.TabIndex = 2;
            checkDontPickupInBerzerk.Text = "Don't pickup items in berzerk mode";
            checkDontPickupInBerzerk.UseVisualStyleBackColor = false;
            checkDontPickupInBerzerk.CheckedChanged += checkDontPickupInBerzerk_CheckedChanged;
            // 
            // checkEnableAbilityPet
            // 
            checkEnableAbilityPet.AutoSize = true;
            checkEnableAbilityPet.BackColor = Color.Transparent;
            checkEnableAbilityPet.Location = new Point(15, 38);
            checkEnableAbilityPet.Name = "checkEnableAbilityPet";
            checkEnableAbilityPet.ShadowDepth = 1;
            checkEnableAbilityPet.Size = new Size(185, 15);
            checkEnableAbilityPet.TabIndex = 1;
            checkEnableAbilityPet.Text = "Use ability pet to pickup items ";
            checkEnableAbilityPet.UseVisualStyleBackColor = false;
            checkEnableAbilityPet.CheckedChanged += checkEnableAbilityPet_CheckedChanged;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            Controls.Add(tabMain);
            DoubleBuffered = true;
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            Name = "Main";
            Size = new Size(754, 473);
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
        private SDUI.Controls.GroupBox groupBoxGeneral;
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
        private System.Windows.Forms.ToolStripMenuItem btnPickOnlyCharacter;
        private SDUI.Controls.CheckBox checkQuestItems;
        private SDUI.Controls.CheckBox checkAllEquips;
        private SDUI.Controls.CheckBox checkEverything;
        private SDUI.Controls.GroupBox groupBoxOptions;
    }
}
