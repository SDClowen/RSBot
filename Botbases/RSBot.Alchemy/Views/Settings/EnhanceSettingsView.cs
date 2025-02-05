using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using RSBot.Alchemy.Bot;
using RSBot.Alchemy.Bundle.Enhance;
using RSBot.Alchemy.Helper;
using RSBot.Core.Event;
using RSBot.Core.Objects;


namespace RSBot.Alchemy.Views.Settings;

[ToolboxItem(false)]
public partial class EnhanceSettingsView : UserControl
{
    #region Member

    private InventoryItem _selectedItem;

    #endregion Member

    #region Constructor

    /// <summary>
    ///     Subscribes several events
    /// </summary>
    public EnhanceSettingsView()
    {
        CheckForIllegalCrossThreadCalls = false;
        InitializeComponent();
        SetStyle(
            ControlStyles.UserPaint |
            ControlStyles.AllPaintingInWmPaint |
            ControlStyles.OptimizedDoubleBuffer,
            true);

        EventManager.SubscribeEvent("OnEnterGame", SubscribeMainFormEvents);
    }

    #endregion Constructor

    internal class ElixirComboboxItem
    {
        public ElixirComboboxItem(IEnumerable<InventoryItem> items)
        {
            Items = items;
        }

        /// <summary>
        ///     Gets or sets the inventory item
        /// </summary>
        public IEnumerable<InventoryItem> Items { get; set; }

        public override string ToString()
        {
            if (!Items.Any())
                return string.Empty;

            return $"{Items.Sum(i => i.Amount)}x {Items.First().Record.GetRealName()}";
        }
    }

    #region Methods

    /// <summary>
    ///     Subscribes the ItemChanged event
    /// </summary>
    private void SubscribeMainFormEvents()
    {
        if (Globals.View == null) return;

        Globals.View.EngineChanged += View_EngineChanged;
        Globals.View.ItemChanged += View_ItemChanged;
    }

    /// <summary>
    ///     General UI update logic
    /// </summary>
    private void PopulateView()
    {
        if (Globals.View == null || Globals.View.SelectedItem == null)
        {
            Enabled = false;

            return;
        }

        _selectedItem = Globals.View.SelectedItem;

        lblCurrentOptLevel.Text = _selectedItem == null ? "+0" : $"+{Globals.View.SelectedItem.OptLevel}";

        var type = AlchemyItemHelper.ElixirType.Unspecified;

        var accessorryTypeId3 = new byte[] { 5, 12 };
        var armorTypeId3 = new byte[] { 1, 2, 3, 9, 10, 11 };

        if (_selectedItem.Record.TypeID3 == 4 && _selectedItem.Record.TypeID2 == 1)
            type = AlchemyItemHelper.ElixirType.Shield;

        if (_selectedItem.Record.TypeID3 == 6 && _selectedItem.Record.TypeID2 == 1)
            type = AlchemyItemHelper.ElixirType.Weapon;

        if (accessorryTypeId3.Contains(_selectedItem.Record.TypeID3) && _selectedItem.Record.TypeID2 == 1)
            type = AlchemyItemHelper.ElixirType.Accessory;

        if (armorTypeId3.Contains(_selectedItem.Record.TypeID3) && _selectedItem.Record.TypeID2 == 1)
            type = AlchemyItemHelper.ElixirType.Protector;

        var matchingElixirs = AlchemyItemHelper.GetElixirItems(type);

        comboElixir.Items.Clear();

        var index = 0;
        foreach (var items in matchingElixirs.GroupBy(i => i.ItemId))
        {
            comboElixir.Items.Add(new ElixirComboboxItem(items));

            if (items.Key == Globals.Botbase.EnhanceBundleConfig?.Elixirs?.FirstOrDefault()?.ItemId)
                comboElixir.SelectedIndex = index;

            index++;
        }

        if (comboElixir.Items.Count > 0 && comboElixir.SelectedItem == null)
            comboElixir.SelectedIndex = 0;

        var luckyPowders = AlchemyItemHelper.GetLuckyPowders(_selectedItem);
        lblLuckyPowderCount.Text = $"x{luckyPowders.Sum(i => i.Amount)}";

        var luckyStones = AlchemyItemHelper.GetLuckyStone(_selectedItem);
        checkUseLuckyStones.Enabled = luckyStones != null && luckyStones.Amount > 0;

        if (luckyStones == null)
            checkUseLuckyStones.Checked = false;
        lblLuckyCount.Text = luckyStones == null ? "x0" : $"x{luckyStones.Amount}";

        var astralStones = AlchemyItemHelper.GetAstralStone(_selectedItem);
        if (astralStones == null)
            checkUseAstralStones.Checked = false;
        checkUseAstralStones.Enabled = astralStones != null && astralStones.Amount > 0;
        lblAstralCount.Text = astralStones == null ? "x0" : $"x{astralStones.Amount}";

        var immortalStones = AlchemyItemHelper.GetImmortalStone(_selectedItem);
        if (immortalStones == null)
            checkUseAstralStones.Checked = false;
        checkUseImmortalStones.Enabled = immortalStones != null && immortalStones.Amount > 0;

        lblImmortalCount.Text = immortalStones == null ? "x0" : $"x{immortalStones.Amount}";

        var steadyStones = AlchemyItemHelper.GetSteadyStone(_selectedItem);
        checkUseSteadyStones.Enabled = steadyStones != null && steadyStones.Amount > 0;
        lblSteadyStonesCount.Text = steadyStones == null ? "x0" : $"x{steadyStones.Amount}";

        Enabled = true;
    }

    #endregion Methods

    #region Events

    private void View_EngineChanged(InventoryItem item, AlchemyEngine alchemyEngine)
    {
        PopulateView();
    }

    /// <summary>
    ///     Will be triggered when the user click on the refresh link
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void linkRefreshItemList_Click(object sender, EventArgs e)
    {
        PopulateView();
    }

    /// <summary>
    ///     Will be triggered when the selected item changed
    /// </summary>
    /// <param name="item">The new item</param>
    private void View_ItemChanged(InventoryItem item)
    {
        PopulateView();
    }

    /// <summary>
    ///     Will be triggered when the user changed a setting
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void config_CheckedChange(object sender, EventArgs e)
    {
        if (Globals.Botbase == null || Globals.Botbase.AlchemyEngine != AlchemyEngine.Enhance)
            return;

        Globals.Botbase.EnhanceBundleConfig = new EnhanceBundleConfig
        {
            Item = Globals.View.SelectedItem,
            UseAstralStones = checkUseAstralStones.Checked,
            UseLuckyStones = checkUseLuckyStones.Checked,
            UseImmortalStones = checkUseImmortalStones.Checked,
            UseSteadyStones = checkUseSteadyStones.Checked,
            Elixirs = (comboElixir.SelectedItem as ElixirComboboxItem)?.Items,
            MaxOptLevel = (byte)numMaxEnhancement.Value,
            StopIfLuckyPowderEmpty = checkStopLuckyPowder.Checked
        };
    }

    #endregion Events
}