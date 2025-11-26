using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using RSBot.Core;
using RSBot.Core.Client.ReferenceObjects;
using RSBot.Core.Components;
using RSBot.Core.Event;
using RSBot.Core.Extensions;
using RSBot.Core.Objects;
using SDUI.Controls;
using CheckBox = SDUI.Controls.CheckBox;
using GroupBox = SDUI.Controls.GroupBox;
using ListViewExtensions = RSBot.Core.Extensions.ListViewExtensions;

namespace RSBot.Items.Views;

[ToolboxItem(false)]
public partial class Main : DoubleBufferedControl
{
    private List<RefShopGroup> _accessoryTrader;
    private List<RefShopGroup> _potionTrader;
    private List<RefShopGroup> _protectorTrader;
    private List<RefShopGroup> _stableKeeper;
    private List<RefShopGroup> _weaponTrader;
    private bool _loadingSettings;

    /// <summary>
    ///     Initializes a new instance of the <see cref="Main" /> class.
    /// </summary>
    public Main()
    {
        CheckForIllegalCrossThreadCalls = false;

        InitializeComponent();
        SubscribeEvents();

        listShoppingList.SmallImageList = ListViewExtensions.StaticItemsImageList;
        listAvailableProducts.SmallImageList = ListViewExtensions.StaticItemsImageList;
    }

    /// <summary>
    ///     Subscribes the events.
    /// </summary>
    private void SubscribeEvents()
    {
        EventManager.SubscribeEvent("OnLoadGameData", OnLoadGameData);
        EventManager.SubscribeEvent("OnEnterGame", LoadSettings);
    }

    /// <summary>
    ///     Loads the npcs
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
    ///     Populates the product list.
    /// </summary>
    private void PopulateProductList(int index, string filter = "")
    {
        if (index < 0)
            return;

        listAvailableProducts.BeginUpdate();
        listAvailableProducts.Items.Clear();

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

            if (goods == null)
                continue;

            foreach (var good in goods)
            {
                var tabName = Game.ReferenceManager.GetTranslation(
                    Game.ReferenceManager.GetTab(good.RefTabCodeName).StrID128_Tab
                );

                var lvGroup = new ListViewGroup(tabName) { Name = tabName };
                if (!listAvailableProducts.Groups.Contains(lvGroup))
                    listAvailableProducts.Groups.Add(lvGroup);

                var refPackageItem = Game.ReferenceManager.GetRefPackageItem(good.RefPackageItemCodeName);
                var item = Game.ReferenceManager.GetRefItem(refPackageItem.RefItemCodeName);

                if (item == null)
                    continue;

                if (!checkShowEquipment.Checked && item.TypeID2 == 1)
                    continue;

                var realItemName = item.GetRealName();

                //Apply filters
                if (refPackageItem.RefItemCodeName.Contains("_MALL_"))
                    continue;
                if (filter != "" && !realItemName.Contains(filter))
                    continue;

                var listItem = new ListViewItem(realItemName)
                {
                    Tag = good,
                    Name = item.CodeName,
                    Group = listAvailableProducts.Groups[tabName],
                };
                listItem.LoadItemImageAsync(good);

                if (!listAvailableProducts.Items.ContainsKey(item.CodeName))
                    listAvailableProducts.Items.Add(listItem);
            }
        }

        listAvailableProducts.EndUpdate();
    }

    /// <summary>
    ///     Loads the search result item image.
    /// </summary>
    private async void LoadSearchResultItemImagesAsync()
    {
        listFilter.BeginUpdate();

        foreach (ListViewItem item in listFilter.Items)
        {
            var refItem = (RefObjItem)item.Tag;

            if (!searchImageList.Images.ContainsKey(refItem.CodeName))
                searchImageList.Images.Add(refItem.CodeName, refItem.GetIcon());

            item.ImageKey = refItem.CodeName;
        }

        listFilter.EndUpdate();

        await Task.Yield();
    }

    /// <summary>
    ///     Saves the shopping list.
    /// </summary>
    private void SaveShoppingList()
    {
        ShoppingManager.ShoppingList.Clear();
        foreach (ListViewGroup grp in listShoppingList.Groups)
        {
            var values = new List<string>(grp.Items.Count);

            foreach (ListViewItem item in grp.Items)
            {
                if (!(item.Tag is RefShopGood packageItem))
                    continue;

                if (ShoppingManager.ShoppingList.ContainsKey(packageItem))
                    continue;

                if (!int.TryParse(item.SubItems[1].Text.Substring(1), out var amount))
                    continue;

                ShoppingManager.ShoppingList.Add(packageItem, amount);

                values.Add(packageItem.RefPackageItemCodeName + "|" + amount);
            }

            PlayerConfig.SetArray("RSBot.Shopping." + grp.Name, values);
        }
    }

    /// <summary>
    ///     Loads the shopping list.
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

                if (good == null)
                    continue;

                var refPackageItem = Game.ReferenceManager.GetRefPackageItem(good.RefPackageItemCodeName);
                var item = Game.ReferenceManager.GetRefItem(refPackageItem.RefItemCodeName);

                var listItem = new ListViewItem(item.GetRealName()) { Name = item.CodeName, Tag = good };
                listItem.SubItems.Add("x" + amount);
                listItem.Group = group;
                listShoppingList.Items.Add(listItem);

                listItem.LoadItemImageAsync(good);

                if (!ShoppingManager.ShoppingList.ContainsKey(good))
                    ShoppingManager.ShoppingList.Add(good, int.Parse(amount));
            }
        }

        listShoppingList.EndUpdate();
    }

    /// <summary>
    ///     Queries the sell items.
    /// </summary>
    private async Task QuerySellItemsAsync()
    {
        await Task.Delay(1).ConfigureAwait(false);

        listFilter.Visible = false;
        listFilter.BeginUpdate();
        listFilter.Items.Clear();
        listFilter.EndUpdate();

        var filters = new List<TypeIdFilter>();

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

        var clothTypes = new byte[3, 2];

        if (checkClothes.Checked)
        {
            if (checkEuropean.Checked)
                clothTypes[0, 0] = 9;

            if (checkChinese.Checked)
                clothTypes[0, 1] = 1;
        }

        if (checkLight.Checked)
        {
            if (checkEuropean.Checked)
                clothTypes[1, 0] = 10;

            if (checkChinese.Checked)
                clothTypes[1, 1] = 2;
        }

        if (checkHeavy.Checked)
        {
            if (checkEuropean.Checked)
                clothTypes[2, 0] = 11;

            if (checkChinese.Checked)
                clothTypes[2, 1] = 3;
        }

        for (var x = 0; x < 3; x++)
        for (var z = 0; z < 2; z++)
        {
            var cloth = clothTypes[x, z];
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

        if (checkRing.Checked && checkEuropean.Checked)
            filters.Add(new TypeIdFilter(3, 1, 12, 3));

        if (checkRing.Checked && checkChinese.Checked)
            filters.Add(new TypeIdFilter(3, 1, 5, 3));

        if (checkRing.Checked && !checkEuropean.Checked && !checkChinese.Checked)
        {
            filters.Add(new TypeIdFilter(3, 1, 5, 3));
            filters.Add(new TypeIdFilter(3, 1, 12, 3));
        }

        if (checkNecklace.Checked && checkEuropean.Checked)
            filters.Add(new TypeIdFilter(3, 1, 12, 2));

        if (checkNecklace.Checked && checkChinese.Checked)
            filters.Add(new TypeIdFilter(3, 1, 5, 2));

        if (checkNecklace.Checked && !checkEuropean.Checked && !checkChinese.Checked)
        {
            filters.Add(new TypeIdFilter(3, 1, 5, 2));
            filters.Add(new TypeIdFilter(3, 1, 12, 2));
        }

        if (checkEarring.Checked && checkEuropean.Checked)
            filters.Add(new TypeIdFilter(3, 1, 12, 1));

        if (checkEarring.Checked && checkChinese.Checked)
            filters.Add(new TypeIdFilter(3, 1, 5, 1));

        if (checkEarring.Checked && !checkEuropean.Checked && !checkChinese.Checked)
        {
            filters.Add(new TypeIdFilter(3, 1, 5, 1));
            filters.Add(new TypeIdFilter(3, 1, 12, 1));
        }

        #endregion Accessory

        #region Shields

        if (checkShield.Checked && checkChinese.Checked)
            filters.Add(new TypeIdFilter(3, 1, 4, 1));

        if (checkShield.Checked && checkEuropean.Checked)
            filters.Add(new TypeIdFilter(3, 1, 4, 2));

        if (checkShield.Checked && !checkEuropean.Checked && !checkChinese.Checked)
        {
            filters.Add(new TypeIdFilter(3, 1, 4, 1));
            filters.Add(new TypeIdFilter(3, 1, 4, 2));
        }

        #endregion Shields

        #endregion Equipment

        if (checkAlchemy.Checked)
            filters.AddRange(GetAlchemyFilters());

        if (checkQuest.Checked)
            filters.Add(new TypeIdFilter(p => (p as RefObjItem).IsQuest));

        if (checkAmmo.Checked)
        {
            filters.Add(new TypeIdFilter(3, 3, 4, 1));
            filters.Add(new TypeIdFilter(3, 3, 4, 2));
        }

        if (checkCoin.Checked)
            filters.Add(new TypeIdFilter(3, 3, 5, 1));

        if (checkOther.Checked)
            filters.Add(new TypeIdFilter { CompareByTypeID2 = true, TypeID2 = 3 });

        if (filters.Count == 0)
            filters.Add(new TypeIdFilter { CompareByTypeID1 = true, TypeID1 = 3 });

        var gender = ObjectGender.Neutral;

        if (checkMale.Checked && checkFemale.Checked)
        {
            /* nothing do anything, already neutral */
        }
        else if (checkMale.Checked)
        {
            gender = ObjectGender.Male;
        }
        else if (checkFemale.Checked)
        {
            gender = ObjectGender.Female;
        }

        var items = Game.ReferenceManager.GetFilteredItems(
            filters,
            Convert.ToByte(numDegreeFrom.Value),
            Convert.ToByte(numDegreeTo.Value),
            gender,
            checkBoxRareItems.Checked,
            txtSellSearch.Text
        );
        if (items.Count == 0)
        {
            listFilter.Visible = true;
            MessageBox.Show(this, LanguageManager.GetLang("NoResultsFound"), "Warning");
            return;
        }

        await PopulateSellListAsync(items);
        labelResult.Text = $"{items.Count}";
    }

    /// <summary>
    ///     Populates the sell list.
    /// </summary>
    /// <param name="items">The items.</param>
    private async Task PopulateSellListAsync(List<RefObjItem> items)
    {
        listFilter.BeginUpdate();

        string getSubItemString(RefObjItem item)
        {
            var filter = PickupManager.PickupFilter.Find(p => p.CodeName == item.CodeName);
            if (string.IsNullOrWhiteSpace(filter.CodeName))
                return "•";

            if (filter.PickOnlyChar)
                return "√ (C)";

            return "√";
        }

        var listViewItems = new ListViewItem[items.Count];
        for (var i = 0; i < items.Count; i++)
        {
            var item = items[i];

            var listViewItem = new ListViewItem
            {
                Text = item.GetRealName(true),
                Tag = item.CodeName,
                SubItems =
                {
                    $"{item.ReqLevel1} (Dg.{item.Degree})",
                    ((ObjectGender)item.ReqGender).ToString(),
                    getSubItemString(item),
                    ShoppingManager.SellFilter.Contains(item.CodeName) ? "√" : "•",
                    ShoppingManager.StoreFilter.Contains(item.CodeName) ? "√" : "•",
                },
            };

            listViewItems[i] = listViewItem;
        }

        listFilter.Items.AddRange(listViewItems);
        listFilter.EndUpdate();

        //LoadSearchResultItemImagesAsync();

        listFilter.Visible = true;

        await Task.Delay(1).ConfigureAwait(false);
    }

    /// <summary>
    ///     Gets the chinese gear filters.
    /// </summary>
    /// <returns></returns>
    private List<TypeIdFilter> GetAlchemyFilters()
    {
        var result = new List<TypeIdFilter>();

        for (byte i = 1; i <= 3; i++)
            result.Add(
                new TypeIdFilter
                {
                    TypeID1 = 3,
                    TypeID2 = 3,
                    TypeID3 = 10,
                    TypeID4 = i,
                }
            );

        for (byte i = 1; i <= 10; i++)
            result.Add(
                new TypeIdFilter
                {
                    TypeID1 = 3,
                    TypeID2 = 3,
                    TypeID3 = 11,
                    TypeID4 = i,
                }
            );

        return result;
    }

    /// <summary>
    ///     Fired when the core finished to load the game data
    /// </summary>
    private void OnLoadGameData()
    {
        LoadGroups();
    }

    /// <summary>
    ///     Loads the settings.
    /// </summary>
    private void LoadSettings()
    {
        _loadingSettings = true;

        Invoke(() =>
        {
            checkEnable.Checked = PlayerConfig.Get("RSBot.Shopping.Enabled", true);
            checkRepairGear.Checked = PlayerConfig.Get("RSBot.Shopping.RepairGear", true);
            checkSellItemsFromPet.Checked = PlayerConfig.Get("RSBot.Shopping.SellPetItems", true);
            checkPickupGold.Checked = PlayerConfig.Get("RSBot.Items.Pickup.Gold", true);
            checkPickupRare.Checked = PlayerConfig.Get("RSBot.Items.Pickup.Rare", true);
            checkPickupBlue.Checked = PlayerConfig.Get("RSBot.Items.Pickup.Blue", true);
            checkEnableAbilityPet.Checked = PlayerConfig.Get("RSBot.Items.Pickup.EnableAbilityPet", true);
            checkStoreItemsFromPet.Checked = PlayerConfig.Get("RSBot.Shopping.StorePetItems", true);
            checkDontPickupInBerzerk.Checked = PlayerConfig.Get("RSBot.Items.Pickup.DontPickupInBerzerk", true);
            cbJustpickmyitems.Checked = PlayerConfig.Get("RSBot.Items.Pickup.JustPickMyItems", false);
            cbDontPickupWhileBotting.Checked = PlayerConfig.Get<bool>("RSBot.Items.Pickup.DontPickupWhileBotting");

            checkQuestItems.Checked = PlayerConfig.Get<bool>("RSBot.Items.Pickup.Quest", true);
            checkAllEquips.Checked = PlayerConfig.Get<bool>("RSBot.Items.Pickup.AnyEquips");
            checkEverything.Checked = PlayerConfig.Get<bool>("RSBot.Items.Pickup.Everything");

            ShoppingManager.Enabled = checkEnable.Checked;
            ShoppingManager.RepairGear = checkRepairGear.Checked;
            ShoppingManager.SellPetItems = checkSellItemsFromPet.Checked;
            ShoppingManager.StorePetItems = checkStoreItemsFromPet.Checked;

            LoadShoppingList();

            ShoppingManager.LoadFilters();
            PickupManager.LoadFilter();
        });

        _loadingSettings = false;
    }

    private async void txtSellSearch_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
            await QuerySellItemsAsync();
    }

    private void contextList_Opening(object sender, CancelEventArgs e)
    {
        if (listFilter.SelectedItems.Count != 1)
        {
            btnAddToSell.Checked = false;
            btnAddToStore.Checked = false;
            btnPickup.Checked = false;
            btnPickOnlyCharacter.Checked = false;
            return;
        }

        var item = listFilter.SelectedItems[0];
        var codeName = (string)item.Tag;

        btnAddToSell.Checked = ShoppingManager.SellFilter.Contains(codeName);
        btnAddToStore.Checked = ShoppingManager.StoreFilter.Contains(codeName);
        btnPickup.Checked = PickupManager.PickupFilter.Any(p => p.CodeName == codeName && !p.PickOnlyChar);
        btnPickOnlyCharacter.Checked = PickupManager.PickupFilter.Any(p => p.CodeName == codeName && p.PickOnlyChar);
    }

    #region Shopping manager

    /// <summary>
    ///     Handles the SelectedIndexChanged event of the comboStore control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    private void comboStore_SelectedIndexChanged(object sender, EventArgs e)
    {
        PopulateProductList(comboStore.SelectedIndex);
    }

    /// <summary>
    ///     Handles the Click event of the menuAddToShoppingList control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    private void menuAddToShoppingList_Click(object sender, EventArgs e)
    {
        foreach (ListViewItem listItem in listAvailableProducts.SelectedItems)
        {
            var refItem = Game.ReferenceManager.GetRefItem(listItem.Name);
            var title = LanguageManager.GetLang("InputDialogTitle");
            var content = LanguageManager.GetLang("InputDialogContent");
            var itemNameTrans = LanguageManager.GetLang("InputDialogItemName", refItem.GetRealName(), refItem.MaxStack);
            var dialog = new InputDialog(title, itemNameTrans, content, InputDialog.InputType.Numeric);
            if (dialog.ShowDialog(this) == DialogResult.Cancel)
                return;

            if (listShoppingList.Items.ContainsKey(listItem.Name))
            {
                var item = listShoppingList.Items[listItem.Name];
                if (!int.TryParse(item.SubItems[1].Text.Substring(1), out var amount))
                    continue;

                item.SubItems[1].Text = $"x{Convert.ToInt32(dialog.Value) + amount}";
                continue;
            }

            //var newListItem = (ListViewItem)listItem.Clone();
            //newListItem.Group = listShoppingList.Groups[comboStore.SelectedIndex];
            var newListItem = new ListViewItem(listItem.Text) { Tag = listItem.Tag };
            newListItem.Group = listShoppingList.Groups[comboStore.SelectedIndex];
            newListItem.SubItems.Add("x" + dialog.Value);

            //newListItem.SubItems.Add("x" + dialog.Value);
            listShoppingList.Items.Add(newListItem);
        }

        SaveShoppingList();
    }

    /// <summary>
    ///     Handles the Click event of the menuRemoveItem control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    private void menuRemoveItem_Click(object sender, EventArgs e)
    {
        foreach (ListViewItem item in listShoppingList.SelectedItems)
            listShoppingList.Items.Remove(item);

        SaveShoppingList();
    }

    /// <summary>
    ///     Handles the Click event of the menuChangeAmount control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    private void menuChangeAmount_Click(object sender, EventArgs e)
    {
        foreach (ListViewItem item in listShoppingList.SelectedItems)
        {
            var defaultValue = int.Parse(item.SubItems[1].Text.Substring(1, item.SubItems[1].Text.Length - 1));

            var title = LanguageManager.GetLang("InputDialogTitle");
            var content = LanguageManager.GetLang("InputDialogContent");
            var dialog = new InputDialog(title, item.Text, content, InputDialog.InputType.Numeric);
            dialog.Numeric.Value = defaultValue;

            if (dialog.ShowDialog(this) == DialogResult.Cancel)
                return;

            item.SubItems[1].Text = "x" + dialog.Value;
        }

        SaveShoppingList();
    }

    private void checkShoppingSetting_CheckedChanged(object sender, EventArgs e)
    {
        if (_loadingSettings)
            return;

        ShoppingManager.RepairGear = checkRepairGear.Checked;
        PlayerConfig.Set("RSBot.Shopping.RepairGear", checkRepairGear.Checked);

        ShoppingManager.Enabled = checkEnable.Checked;
        PlayerConfig.Set("RSBot.Shopping.Enabled", checkEnable.Checked);

        PlayerConfig.Set("RSBot.Shopping.StorePetItems", checkSellItemsFromPet.Checked);
        ShoppingManager.StorePetItems = checkStoreItemsFromPet.Checked;

        PlayerConfig.Set("RSBot.Shopping.SellPetItems", checkSellItemsFromPet.Checked);
        ShoppingManager.SellPetItems = checkSellItemsFromPet.Checked;
    }

    /// <summary>
    ///     Handles the TextChanged event of the txtShopSearch control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    private void txtShopSearch_TextChanged(object sender, EventArgs e)
    {
        PopulateProductList(comboStore.SelectedIndex, txtShopSearch.Text);
    }

    #endregion Shopping manager

    #region SellFilter

    /// <summary>
    ///     Handles the Click event of the btnReload control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    private async void btnApply_Click(object sender, EventArgs e)
    {
        await QuerySellItemsAsync();
    }

    /// <summary>
    ///     Handles the Click event of the btnAddToSell control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    private void btnAddToSell_Click(object sender, EventArgs e)
    {
        foreach (ListViewItem item in listFilter.SelectedItems)
        {
            item.SubItems[4].Text = "√";

            ShoppingManager.SellFilter.Remove((string)item.Tag);
            ShoppingManager.SellFilter.Add((string)item.Tag);
        }

        ShoppingManager.SaveFilters();
    }

    /// <summary>
    ///     Handles the Click event of the btnPickup control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    private void btnPickup_Click(object sender, EventArgs e)
    {
        foreach (ListViewItem item in listFilter.SelectedItems)
        {
            item.SubItems[3].Text = "√";

            PickupManager.RemoveFilter((string)item.Tag);
            PickupManager.AddFilter((string)item.Tag);
        }
    }

    /// <summary>
    ///     Handles the Click event of the btnPickOnlyCharacter control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    private void btnPickOnlyCharacter_Click(object sender, EventArgs e)
    {
        foreach (ListViewItem item in listFilter.SelectedItems)
        {
            item.SubItems[3].Text = "√ (C)";
            PickupManager.RemoveFilter((string)item.Tag);
            PickupManager.AddFilter((string)item.Tag, true);
        }
    }

    /// <summary>
    ///     Handles the Click event of the btnAddToStore control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    private void btnAddToStore_Click(object sender, EventArgs e)
    {
        foreach (ListViewItem item in listFilter.SelectedItems)
        {
            item.SubItems[5].Text = "√";

            ShoppingManager.StoreFilter.Remove((string)item.Tag);
            ShoppingManager.StoreFilter.Add((string)item.Tag);
        }

        ShoppingManager.SaveFilters();
    }

    /// <summary>
    ///     Handles the Click event of the btnDontSell control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    private void btnDontSell_Click(object sender, EventArgs e)
    {
        foreach (ListViewItem item in listFilter.SelectedItems)
        {
            item.SubItems[4].Text = "•";
            ShoppingManager.SellFilter.Remove((string)item.Tag);
        }

        ShoppingManager.SaveFilters();
    }

    /// <summary>
    ///     Handles the Click event of the btnDontStore control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    private void btnDontStore_Click(object sender, EventArgs e)
    {
        foreach (ListViewItem item in listFilter.SelectedItems)
        {
            item.SubItems[5].Text = "•";
            ShoppingManager.StoreFilter.Remove((string)item.Tag);
        }

        ShoppingManager.SaveFilters();
    }

    /// <summary>
    ///     Handles the Click event of the btnDontPickup control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    private void btnDontPickup_Click(object sender, EventArgs e)
    {
        foreach (ListViewItem item in listFilter.SelectedItems)
        {
            item.SubItems[3].Text = "•";
            PickupManager.RemoveFilter((string)item.Tag);
        }

        ShoppingManager.SaveFilters();
    }

    /// <summary>
    ///     Handles the Click event of the btnResetFilter control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    private void btnResetFilter_Click(object sender, EventArgs e)
    {
        foreach (var group in filterPanel.Controls.OfType<GroupBox>())
        foreach (var checkBox in group.Controls.OfType<CheckBox>())
            checkBox.Checked = false;

        listFilter.Items.Clear();
        numDegreeFrom.Value = 0;
        numDegreeTo.Value = 0;
        labelResult.Text = string.Empty;
    }

    #endregion SellFilter

    #region Pickup

    /// <summary>
    ///     Handles the CheckedChanged event of the checkShowEquipment control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    private void checkShowEquipment_CheckedChanged(object sender, EventArgs e)
    {
        PopulateProductList(comboStore.SelectedIndex, txtShopSearch.Text);
    }

    private void checkPickupSettings_CheckedChanged(object sender, EventArgs e)
    {
        if (_loadingSettings)
            return;

        PlayerConfig.Set("RSBot.Items.Pickup.Everything", checkEverything.Checked);
        PlayerConfig.Set("RSBot.Items.Pickup.AnyEquips", checkAllEquips.Checked);
        PlayerConfig.Set("RSBot.Items.Pickup.Quest", checkQuestItems.Checked);
        PlayerConfig.Set("RSBot.Items.Pickup.DontPickupWhileAttacking", cbDontPickupWhileBotting.Checked);
        PlayerConfig.Set("RSBot.Items.Pickup.DontPickupWhileBotting", cbDontPickupWhileBotting.Checked);
        PlayerConfig.Set("RSBot.Items.Pickup.JustPickMyItems", cbJustpickmyitems.Checked);
        PlayerConfig.Set("RSBot.Items.Pickup.DontPickupInBerzerk", checkDontPickupInBerzerk.Checked);
        PlayerConfig.Set("RSBot.Items.Pickup.EnableAbilityPet", checkEnableAbilityPet.Checked);
        PlayerConfig.Set("RSBot.Items.Pickup.Blue", checkPickupBlue.Checked);
        PlayerConfig.Set("RSBot.Items.Pickup.Rare", checkPickupRare.Checked);
        PlayerConfig.Set("RSBot.Items.Pickup.Gold", checkPickupGold.Checked);
    }
    #endregion Pickup
}
