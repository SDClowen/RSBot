using RSBot.Core;
using RSBot.Core.Client.ReferenceObjects;
using RSBot.Core.Components;
using RSBot.Core.Event;
using RSBot.Core.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RSBot.Shopping.Views
{
    [System.ComponentModel.ToolboxItem(false)]
    public partial class Main : UserControl
    {
        private List<RefShopGroup> _potionTrader;
        private List<RefShopGroup> _weaponTrader;
        private List<RefShopGroup> _protectorTrader;
        private List<RefShopGroup> _accessoryTrader;
        private List<RefShopGroup> _stableKeeper;

        /// <summary>
        /// Initializes a new instance of the <see cref="Main"/> class.
        /// </summary>
        public Main()
        {
            InitializeComponent();
            SubscribeEvents();
        }

        /// <summary>
        /// Subscribes the events.
        /// </summary>
        private void SubscribeEvents()
        {
            EventManager.SubscribeEvent("OnLoadGameData", OnLoadGameData);
            EventManager.SubscribeEvent("OnEnterGame", OnEnterGame);
        }

        /// <summary>
        /// Loads the npcs
        /// </summary>
        private void LoadGroups()
        {
            _accessoryTrader = new List<RefShopGroup>();
            _potionTrader = new List<RefShopGroup>();
            _protectorTrader = new List<RefShopGroup>();
            _weaponTrader = new List<RefShopGroup>();
            _stableKeeper = new List<RefShopGroup>();

            foreach (var group in Game.ReferenceManager.ShopGroups)
            {
                if (group.Value.CodeName.Contains("SMITH") && !group.Value.CodeName.Contains("MALL_"))
                    _weaponTrader.Add(group.Value);

                if (group.Value.CodeName.Contains("POTION") && !group.Value.CodeName.Contains("MALL_"))
                    _potionTrader.Add(group.Value);

                if (group.Value.CodeName.Contains("ARMOR") && !group.Value.CodeName.Contains("MALL_"))
                    _protectorTrader.Add(group.Value);

                if (group.Value.CodeName.Contains("ACCESSORY") && !group.Value.CodeName.Contains("MALL_"))
                    _accessoryTrader.Add(group.Value);

                if (group.Value.CodeName.Contains("STABLE") && !group.Value.CodeName.Contains("MALL_"))
                    _stableKeeper.Add(group.Value);
            }
        }

        /// <summary>
        /// Populates the product list.
        /// </summary>
        private void PopulateProductList(int index, string filter = "")
        {
            if (index < 0)
                return;

            listAvailableProducts.BeginUpdate();
            listAvailableProducts.Items.Clear();
            imgShoppingListNPC.Images.Clear();

            List<RefShopGroup> groups;
            switch (index)
            {
                case 0:
                    groups = _potionTrader;
                    break;

                case 1:
                    groups = _stableKeeper;
                    break;

                case 2:
                    groups = _protectorTrader;
                    break;

                case 3:
                    groups = _weaponTrader;
                    break;

                case 4:
                    groups = _accessoryTrader;
                    break;

                default:
                    return;
            }

            foreach (var group in groups)
            {
                var goods = Game.ReferenceManager.GetRefShopGoods(group);

                if (goods == null) continue;

                foreach (var good in goods)
                {
                    var tabName = Game.ReferenceManager.GetTranslation(Game.ReferenceManager.GetTab(good.RefTabCodeName).StrID128_Tab);

                    var lvGroup = new ListViewGroup(tabName) { Name = tabName };
                    if (!listAvailableProducts.Groups.Contains(lvGroup))
                        listAvailableProducts.Groups.Add(lvGroup);

                    var refPackageItem = Game.ReferenceManager.GetRefPackageItem(good.RefPackageItemCodeName);
                    var item = Game.ReferenceManager.GetRefItem(refPackageItem.RefItemCodeName);

                    if (!checkShowEquipment.Checked && item.TypeID2 == 1)
                        continue;

                    var realItemName = item.GetRealName();

                    //Apply filters
                    if (refPackageItem.RefItemCodeName.Contains("_MALL_")) continue;
                    if (filter != "" && !realItemName.Contains(filter)) continue;

                    var listItem = new ListViewItem(realItemName) { Tag = good, Name = item.CodeName, Group = listAvailableProducts.Groups[tabName] };

                    if (!listAvailableProducts.Items.ContainsKey(item.CodeName))
                        listAvailableProducts.Items.Add(listItem);
                }
            }

            listAvailableProducts.EndUpdate();

            Task.Run(() => LoadProductListImages());
        }

        /// <summary>
        /// Loads the product list images.
        /// </summary>
        private void LoadProductListImages()
        {
            try
            {
                foreach (ListViewItem item in listAvailableProducts.Items)
                {
                    var good = (RefShopGood)item.Tag;

                    var refPackageItem = Game.ReferenceManager.GetRefPackageItem(good.RefPackageItemCodeName);
                    var refItem = Game.ReferenceManager.GetRefItem(refPackageItem.RefItemCodeName);

                    if (!imgShoppingListNPC.Images.ContainsKey(refItem.ID.ToString()))
                        imgShoppingListNPC.Images.Add(refItem.ID.ToString(), refItem.GetIcon());

                    item.ImageKey = refItem.ID.ToString();
                }
            }
            catch
            {
                Log.Debug("Could not load shopping list images: Unknown error occurred.");
            }
        }

        /// <summary>
        /// Saves the shopping list.
        /// </summary>
        private void SaveShoppingList()
        {
            ShoppingManager.ShoppingList.Clear();
            foreach (ListViewGroup grp in listShoppingList.Groups)
            {
                var values = new string[grp.Items.Count];
                var i = 0;
                foreach (ListViewItem item in grp.Items)
                {
                    if (!(item.Tag is RefShopGood packageItem)) continue;

                    if (ShoppingManager.ShoppingList.ContainsKey(packageItem))
                        continue;

                    var amount = ushort.Parse(item.SubItems[1].Text.Substring(1, item.SubItems[1].Text.Length - 1));

                    ShoppingManager.ShoppingList.Add(packageItem, amount);
                    values[i] = packageItem.RefPackageItemCodeName + "|" + amount;

                    i++;
                }

                PlayerConfig.SetArray("RSBot.Shopping." + grp.Name, values);
            }
        }

        /// <summary>
        /// Loads the shopping list.
        /// </summary>
        private void LoadShoppingList()
        {
            listShoppingList.BeginUpdate();
            listShoppingList.Items.Clear();

            foreach (ListViewGroup group in listShoppingList.Groups)
            {
                var values = PlayerConfig.GetArray<string>("RSBot.Shopping." + group.Name);

                foreach (var value in values)
                {
                    var packageCodeName = value.Split('|')[0];
                    var amount = value.Split('|')[1];
                    var good = Game.ReferenceManager.GetRefShopGood(packageCodeName);

                    if (good == null) continue;
                    var refPackageItem = Game.ReferenceManager.GetRefPackageItem(good.RefPackageItemCodeName);
                    var item = Game.ReferenceManager.GetRefItem(refPackageItem.RefItemCodeName);

                    var listItem = new ListViewItem(item.GetRealName()) { Tag = good };
                    listItem.SubItems.Add("x" + amount);
                    listItem.Group = group;
                    listShoppingList.Items.Add(listItem);

                    if (!imgShoppingList.Images.ContainsKey(item.ID.ToString()))
                        imgShoppingList.Images.Add(item.ID.ToString(), item.GetIcon());
                    listItem.ImageKey = item.ID.ToString();
                }
            }

            listShoppingList.EndUpdate();

            SaveShoppingList(); //Apply loaded data to core component
        }

        /// <summary>
        /// Saves the sell list.
        /// </summary>
        private void SaveSellList()
        {
            PlayerConfig.SetArray("RSBot.Shopping.Sell", ShoppingManager.SellFilter.Filters);
            PlayerConfig.SetArray("RSBot.Shopping.Store", ShoppingManager.StoreFilter.Filters);
            PlayerConfig.SetArray("RSBot.Shopping.Pickup", PickupManager.PickupFilter.Filters);
        }

        /// <summary>
        /// Loads the sell list.
        /// </summary>
        private void LoadSellList()
        {
            var configSell = PlayerConfig.GetArray<string>("RSBot.Shopping.Sell");
            var configStore = PlayerConfig.GetArray<string>("RSBot.Shopping.Store");
            var configPickup = PlayerConfig.GetArray<string>("RSBot.Shopping.Pickup");

            foreach (var item in configSell)
                ShoppingManager.SellFilter.AddItem(item);

            foreach (var item in configStore)
                ShoppingManager.StoreFilter.AddItem(item);

            foreach (var item in configPickup)
                PickupManager.PickupFilter.AddItem(item);
        }

        /// <summary>
        /// Queries the sell items.
        /// </summary>
        private void QuerySellItems()
        {
            listFilter.Visible = false;
            listFilter.Items.Clear();

            var filters = new List<TypeIdFilter>();

            if (checkAll.Checked)
            {
                filters.Add(new TypeIdFilter { CompareByTypeID1 = true, TypeID1 = 3 });

                var allItems = Game.ReferenceManager.GetFilteredItems(filters);

                PopulateSellList(allItems);

                return;
            }

            #region Weapons

            if (checkSword.Checked)
                filters.Add(new TypeIdFilter(3, 1, 6, 2));

            if (checkBlade.Checked)
                filters.Add(new TypeIdFilter(3, 1, 6, 3));

            if (checkSpear.Checked)
                filters.Add(new TypeIdFilter(3, 1, 6, 4));

            if (checkGlave.Checked)
                filters.Add(new TypeIdFilter(3, 1, 6, 5));

            if (checkBow.Checked)
                filters.Add(new TypeIdFilter(3, 1, 6, 6));

            if (check1HSword.Checked)
                filters.Add(new TypeIdFilter(3, 1, 6, 7));

            if (check2HSword.Checked)
                filters.Add(new TypeIdFilter(3, 1, 6, 8));

            if (checkAxe.Checked)
                filters.Add(new TypeIdFilter(3, 1, 6, 9));

            if (checkWRod.Checked)
                filters.Add(new TypeIdFilter(3, 1, 6, 10));

            if (checkStaff.Checked)
                filters.Add(new TypeIdFilter(3, 1, 6, 11));

            if (checkXBow.Checked)
                filters.Add(new TypeIdFilter(3, 1, 6, 12));

            if (checkDagger.Checked)
                filters.Add(new TypeIdFilter(3, 1, 6, 13));

            if (checkHarp.Checked)
                filters.Add(new TypeIdFilter(3, 1, 6, 14));

            if (checkCRod.Checked)
                filters.Add(new TypeIdFilter(3, 1, 6, 15));

            #endregion Weapons

            #region Equipment

            if(checkEuropean.Checked || checkChinese.Checked)
            {
                var clothTypes = new byte[3];

                if (checkClothes.Checked)
                {
                    if (checkEuropean.Checked)
                        clothTypes[0] = 9;
                    else
                        clothTypes[0] = 1;
                }

                if (checkLight.Checked)
                {
                    if (checkEuropean.Checked)
                        clothTypes[1] = 10;
                    else
                        clothTypes[1] = 2;
                }

                if (checkHeavy.Checked)
                {
                    if (checkEuropean.Checked)
                        clothTypes[2] = 11;
                    else
                        clothTypes[2] = 3;
                }

                for (int i = 0; i < 3; i++)
                {
                    var cloth = clothTypes[i];
                    if (cloth == 0)
                        continue;

                    if (checkHead.Checked)
                        filters.Add(new TypeIdFilter(3, 1, cloth, 1));

                    if (checkShoulder.Checked)
                        filters.Add(new TypeIdFilter(3, 1, cloth, 2));

                    if (checkChest.Checked)
                        filters.Add(new TypeIdFilter(3, 1, cloth, 3));

                    if (checkLegs.Checked)
                        filters.Add(new TypeIdFilter(3, 1, cloth, 4));

                    if (checkHand.Checked)
                        filters.Add(new TypeIdFilter(3, 1, cloth, 5));

                    if (checkBoot.Checked)
                        filters.Add(new TypeIdFilter(3, 1, cloth, 6));
                }

                #region Accessory

                var acc = (byte)(checkEuropean.Checked ? 12 : 5);
                if (checkRing.Checked)
                    filters.Add(new TypeIdFilter(3, 1, acc, 3));

                if (checkNecklace.Checked)
                    filters.Add(new TypeIdFilter(3, 1, acc, 2));

                if (checkEarring.Checked)
                    filters.Add(new TypeIdFilter(3, 1, acc, 1));

                #endregion Accessory

                if (checkShield.Checked)
                    filters.Add(new TypeIdFilter(3, 1, 4, (byte)(checkChinese.Checked ? 1 : 2)));
            }

            #endregion Equipment

            if (checkAlchemy.Checked)
                filters.AddRange(GetAlchemyFilters());

            if (checkStackable.Checked)
            {
                filters.Add(new TypeIdFilter
                {
                    CompareByTypeID2 = true,
                    TypeID2 = 3
                });
            }

            var gender = ObjectGender.Neutral;
            if (checkMale.Checked)
                gender = ObjectGender.Male;
            else if (checkFemale.Checked)
                gender = ObjectGender.Female;

            var items = Game.ReferenceManager.GetFilteredItems(filters, Convert.ToByte(numDegreeFrom.Value), Convert.ToByte(numDegreeTo.Value), gender, checkBoxRareItems.Checked, txtSellSearch.Text);
            if(items.Count == 0)
            {
                listFilter.Visible = true;
                MessageBox.Show(this, "No results were found. Please detail your search and try again.", "Warning");
                return;
            }

            PopulateSellList(items);
            labelResult.Text = $"Result: {items.Count}";
        }

        /// <summary>
        /// Populates the sell list.
        /// </summary>
        /// <param name="items">The items.</param>
        private void PopulateSellList(List<RefObjItem> items)
        {
            foreach (var item in items)
            {
                listFilter.Items.Add(new ListViewItem
                {
                    Text = item.GetRealName(true),
                    Tag = item.CodeName,
                    SubItems =
                    {
                        $"{item.ReqLevel1} (Dg.{item.Degree})",
                        ((ObjectGender)item.ReqGender).ToString(),
                        ShoppingManager.SellFilter.Invoke(item.CodeName).ToString(),
                        ShoppingManager.StoreFilter.Invoke(item.CodeName).ToString(),
                        PickupManager.PickupFilter.Invoke(item.CodeName).ToString()
                    }
                });
            }

            listFilter.Visible = true;
        }

        /// <summary>
        /// Gets the chinese gear filters.
        /// </summary>
        /// <returns></returns>
        private List<TypeIdFilter> GetAlchemyFilters()
        {
            var result = new List<TypeIdFilter>();

            for (byte i = 1; i <= 3; i++)
                result.Add(new TypeIdFilter { TypeID1 = 3, TypeID2 = 3, TypeID3 = 10, TypeID4 = i });

            for (byte i = 1; i <= 10; i++)
                result.Add(new TypeIdFilter { TypeID1 = 3, TypeID2 = 3, TypeID3 = 11, TypeID4 = i });

            return result;
        }

        /// <summary>
        /// Fired when the core finished to load the game data
        /// </summary>
        private void OnLoadGameData()
        {
            LoadGroups();

            comboStore.SelectedIndex = 0;
        }

        /// <summary>
        /// Fired when the player enters the game
        /// </summary>
        private void OnEnterGame()
        {
            checkEnable.Checked = PlayerConfig.Get("RSBot.Shopping.Enabled", true);
            checkRepairGear.Checked = PlayerConfig.Get("RSBot.Shopping.RepairGear", true);
            checkSellItemsFromPet.Checked = PlayerConfig.Get("RSBot.Shopping.SellPetItems", true);
            checkPickupGold.Checked = PlayerConfig.Get("RSBot.Items.Pickup.Gold", true);
            checkPickupRare.Checked = PlayerConfig.Get("RSBot.Items.Pickup.Rare", true);
            checkEnableAbilityPet.Checked = PlayerConfig.Get("RSBot.Items.Pickup.EnableAbilityPet", true);
            checkSellItemsFromPet.Checked = PlayerConfig.Get("RSBot.Shopping.SellPetItems", true);
            checkDontPickupInBerzerk.Checked = PlayerConfig.Get("RSBot.Items.Pickup.DontPickupInBerzerk", true);
            cbJustpickmyitems.Checked = PlayerConfig.Get("RSBot.Items.Pickup.JustPickMyItems", true);
            cbDontPickupWhileBotting.Checked = PlayerConfig.Get<bool>("RSBot.Items.Pickup.DontPickupWhileBotting");

            ShoppingManager.Enabled = checkEnable.Checked;
            ShoppingManager.RepairGear = checkRepairGear.Checked;
            ShoppingManager.SellPetItems = checkSellItemsFromPet.Checked;

            LoadShoppingList();
            LoadSellList();
        }

        #region Shopping manager

        /// <summary>
        /// Handles the CheckedChanged event of the checkSellItemsFromPet control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void checkSellItemsFromPet_CheckedChanged(object sender, EventArgs e)
        {
            PlayerConfig.Set("RSBot.Shopping.SellPetItems", checkSellItemsFromPet.Checked);
            ShoppingManager.SellPetItems = checkSellItemsFromPet.Checked;
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the comboStore control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void comboStore_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            PopulateProductList(comboStore.SelectedIndex);
        }

        /// <summary>
        /// Handles the Click event of the menuAddToShoppingList control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void menuAddToShoppingList_Click(object sender, System.EventArgs e)
        {
            foreach (ListViewItem listItem in listAvailableProducts.SelectedItems)
            {
                var newListItem = new ListViewItem(listItem.Text) { Tag = listItem.Tag };

                var amtDiag = new AmountDialog(listItem.Text);
                if (amtDiag.ShowDialog() == DialogResult.Cancel)
                    return;

                newListItem.Group = listShoppingList.Groups[comboStore.SelectedIndex];

                newListItem.SubItems.Add("x" + amtDiag.SelectedValue);
                listShoppingList.Items.Add(newListItem);

                SaveShoppingList();
            }

            LoadShoppingList();
        }

        /// <summary>
        /// Handles the Click event of the menuRemoveItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void menuRemoveItem_Click(object sender, System.EventArgs e)
        {
            foreach (ListViewItem item in listShoppingList.SelectedItems)
                listShoppingList.Items.Remove(item);

            SaveShoppingList();
        }

        /// <summary>
        /// Handles the Click event of the menuChangeAmount control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
        private void menuChangeAmount_Click(object sender, System.EventArgs e)
        {
            foreach (ListViewItem item in listShoppingList.SelectedItems)
            {
                var defaultValue = int.Parse(item.SubItems[1].Text.Substring(1, item.SubItems[1].Text.Length - 1));
                var amtDiag = new AmountDialog(item.Text, defaultValue);
                if (amtDiag.ShowDialog() == DialogResult.Cancel) return;

                item.SubItems[1].Text = "x" + amtDiag.SelectedValue;
            }

            SaveShoppingList();
        }

        /// <summary>
        /// Handles the CheckedChanged event of the checkEnable control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void checkEnable_CheckedChanged(object sender, EventArgs e)
        {
            ShoppingManager.Enabled = checkEnable.Checked;
            PlayerConfig.Set("RSBot.Shopping.Enabled", checkEnable.Checked);
        }

        /// <summary>
        /// Handles the CheckedChanged event of the checkRepairGear control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void checkRepairGear_CheckedChanged(object sender, EventArgs e)
        {
            ShoppingManager.RepairGear = checkRepairGear.Checked;
            PlayerConfig.Set("RSBot.Shopping.RepairGear", checkRepairGear.Checked);
        }

        /// <summary>
        /// Handles the TextChanged event of the txtShopSearch control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void txtShopSearch_TextChanged(object sender, EventArgs e)
        {
            PopulateProductList(comboStore.SelectedIndex, txtShopSearch.Text);
        }

        #endregion Shopping manager

        #region SellFilter

        /// <summary>
        /// Handles the Click event of the btnSearch control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            Task.Run(() => QuerySellItems());
        }

        /// <summary>
        /// Handles the Click event of the btnAddToSell control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnAddToSell_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listFilter.SelectedItems)
            {
                item.SubItems[4].Text = "True";
                ShoppingManager.SellFilter.AddItem((string)item.Tag);
            }

            SaveSellList();
        }

        /// <summary>
        /// Handles the Click event of the btnReload control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnReload_Click(object sender, EventArgs e)
        {
            btnSearch_Click(sender, e);
        }

        /// <summary>
        /// Handles the Click event of the btnAddToStore control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnAddToStore_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listFilter.SelectedItems)
            {
                item.SubItems[5].Text = "True";
                ShoppingManager.StoreFilter.AddItem((string)item.Tag);
            }

            SaveSellList();
        }

        /// <summary>
        /// Handles the Click event of the btnDontSell control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnDontSell_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listFilter.SelectedItems)
            {
                item.SubItems[4].Text = "False";
                ShoppingManager.SellFilter.RemoveItem((string)item.Tag);
            }

            SaveSellList();
        }

        /// <summary>
        /// Handles the Click event of the btnDontStore control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnDontStore_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listFilter.SelectedItems)
            {
                item.SubItems[5].Text = "False";
                ShoppingManager.StoreFilter.RemoveItem((string)item.Tag);
            }

            SaveSellList();
        }

        /// <summary>
        /// Handles the Click event of the btnPickup control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnPickup_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listFilter.SelectedItems)
            {
                item.SubItems[3].Text = "True";
                PickupManager.PickupFilter.AddItem((string)item.Tag);
            }

            SaveSellList();
        }

        /// <summary>
        /// Handles the Click event of the btnDontPickup control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnDontPickup_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listFilter.SelectedItems)
            {
                item.SubItems[3].Text = "False";
                PickupManager.PickupFilter.RemoveItem((string)item.Tag);
            }

            SaveSellList();
        }

        /// <summary>
        /// Handles the Click event of the btnResetFilter control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnResetFilter_Click(object sender, EventArgs e)
        {
            foreach (var group in filterPanel.Controls.OfType<GroupBox>())
                foreach (var checkBox in group.Controls.OfType<CheckBox>())
                    checkBox.Checked = false;

            listFilter.Items.Clear();
            numDegreeFrom.Value = 1;
            numDegreeTo.Value = 16;
            labelResult.Text = string.Empty;
        }

        #endregion SellFilter

        #region Pickup

        /// <summary>
        /// Handles the CheckedChanged event of the checkPickupGold control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void checkPickupGold_CheckedChanged(object sender, EventArgs e)
        {
            PlayerConfig.Set("RSBot.Items.Pickup.Gold", checkPickupGold.Checked);
        }

        /// <summary>
        /// Handles the CheckedChanged event of the checkPickupRare control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void checkPickupRare_CheckedChanged(object sender, EventArgs e)
        {
            PlayerConfig.Set("RSBot.Items.Pickup.Rare", checkPickupRare.Checked);
        }

        /// <summary>
        /// Handles the CheckedChanged event of the checkEnableAbilityPet control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void checkEnableAbilityPet_CheckedChanged(object sender, EventArgs e)
        {
            PlayerConfig.Set("RSBot.Items.Pickup.EnableAbilityPet", checkEnableAbilityPet.Checked);
        }

        /// <summary>
        /// Handles the CheckedChanged event of the checkShowEquipment control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void checkShowEquipment_CheckedChanged(object sender, EventArgs e)
        {
            PopulateProductList(comboStore.SelectedIndex, txtShopSearch.Text);
        }

        /// <summary>
        /// Handles the CheckedChanged event of the checkDontPickupInBerzerk control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void checkDontPickupInBerzerk_CheckedChanged(object sender, EventArgs e)
        {
            PlayerConfig.Set("RSBot.Items.Pickup.DontPickupInBerzerk", checkDontPickupInBerzerk.Checked);
        }

        private void cbJustpickmyitems_CheckedChanged(object sender, EventArgs e)
        {
            PlayerConfig.Set("RSBot.Items.Pickup.JustPickMyItems", cbJustpickmyitems.Checked);
        }

        private void cbDontPickupWhileAttacking_CheckedChanged(object sender, EventArgs e)
        {
            PlayerConfig.Set("RSBot.Items.Pickup.DontPickupWhileAttacking", cbDontPickupWhileBotting.Checked);
        }

        private void cbDontPickupWhileBotting_CheckedChanged(object sender, EventArgs e)
        {
            PlayerConfig.Set("RSBot.Items.Pickup.DontPickupWhileBotting", cbDontPickupWhileBotting.Checked);
        }

        #endregion Pickup

        private void txtSellSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnSearch_Click(sender, null);
        }
    }
}