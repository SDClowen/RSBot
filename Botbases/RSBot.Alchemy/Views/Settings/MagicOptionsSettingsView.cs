using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using RSBot.Alchemy.Bot;
using RSBot.Alchemy.Bundle.Magic;
using RSBot.Alchemy.Client.ReferenceObjects;
using RSBot.Alchemy.Helper;
using RSBot.Core;
using RSBot.Core.Client.ReferenceObjects;
using RSBot.Core.Event;
using RSBot.Core.Objects;
using RSBot.Core.Objects.Item;
using SDUI.Controls;

namespace RSBot.Alchemy.Views.Settings;

[ToolboxItem(false)]
public partial class MagicOptionsSettingsView : DoubleBufferedControl
{
    #region Members

    private bool _reloadConfig;

    #endregion Members

    #region Constructor

    /// <summary>
    ///     Subscribes several events
    /// </summary>
    public MagicOptionsSettingsView()
    {
        CheckForIllegalCrossThreadCalls = false;

        InitializeComponent();

        EventManager.SubscribeEvent("OnEnterGame", SubscribeMainFormEvents);
    }

    #endregion Constructor

    private class MagicStoneListViewItemTag
    {
        public InventoryItem? Item { get; set; }
        public RefMagicOpt? MagicOption { get; set; }

        public MagicOptionInfo? MagicOptionInfo { get; set; }
    }

    #region Events

    /// <summary>
    ///     Subscribes to the ItemChanged event
    /// </summary>
    private void SubscribeMainFormEvents()
    {
        if (Globals.View != null)
        {
            Globals.View.ItemChanged += View_ItemChanged;
            Globals.View.EngineChanged += View_EngineChanged;
        }
    }

    private void View_EngineChanged(InventoryItem item, AlchemyEngine alchemyEngine)
    {
        PopulateListView();
    }

    /// <summary>
    ///     Will be triggered when the selected item changed
    /// </summary>
    /// <param name="item"></param>
    private void View_ItemChanged(InventoryItem item)
    {
        PopulateListView();
    }

    /// <summary>
    ///     Will be triggered when a list view item was selected
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void lvMagicOptions_ItemChecked(object sender, ItemCheckedEventArgs e)
    {
        var tag = e.Item.Tag as MagicStoneListViewItemTag;

        if (
            (tag.MagicOptionInfo != null && tag?.MagicOptionInfo?.Value >= tag?.MagicOptionInfo?.Record?.GetMaxValue())
            || tag.Item == null
        )
        {
            e.Item.Checked = false;

            return;
        }

        ReloadConfig();
    }

    #endregion Events

    #region Methods

    /// <summary>
    ///     Populate the list view of available magic options for the selected item
    /// </summary>
    public void PopulateListView()
    {
        if (Globals.View.SelectedItem == null)
            return;

        try
        {
            lvMagicOptions.BeginUpdate();
            lvMagicOptions.Items.Clear();
            _reloadConfig = false;

            var selectedItem = Globals.View.SelectedItem;
            if (selectedItem == null)
            {
                lvMagicOptions.EndUpdate();
                return;
            }

            var assignments = Game.ReferenceManager.GetAssignments(
                selectedItem.Record.TypeID3,
                selectedItem.Record.TypeID4
            );
            foreach (var assignment in assignments)
            {
                if (assignment == null)
                    continue;

                var matchingMagicStones = AlchemyItemHelper.GetStonesByGroup(selectedItem, assignment.Group);

                MagicOptionInfo currentMagicOptionInfo = null;
                if (selectedItem.MagicOptions != null)
                    foreach (var magicOption in selectedItem.MagicOptions)
                    {
                        ;
                        if (magicOption.Record?.Group != assignment.Group)
                            continue;

                        if (magicOption.Record.Level != selectedItem.Record.Degree)
                        {
                            //Fix in case the server sends a lower magic option id than expected (dunno why this happens)
                            var actualMagicOption = Game.ReferenceManager.GetMagicOption(
                                assignment.Group,
                                (byte)selectedItem.Record.Degree
                            );

                            matchingMagicStones = AlchemyItemHelper.GetStonesByGroup(
                                magicOption.Record.Level,
                                assignment.Group
                            );

                            currentMagicOptionInfo = new MagicOptionInfo
                            {
                                Id = actualMagicOption.Id,
                                Value = magicOption.Value,
                            };
                        }
                        else
                        {
                            currentMagicOptionInfo = magicOption;
                        }

                        break;
                    }

                var canBeIncreased = !!matchingMagicStones.Any();

                //Max option
                if (
                    currentMagicOptionInfo != null
                    && currentMagicOptionInfo.Value >= currentMagicOptionInfo.Record.GetMaxValue()
                )
                    canBeIncreased = false;

                var refMagicOption = Game.ReferenceManager.GetMagicOption(
                    assignment.Group,
                    (byte)selectedItem.Record.Degree
                );
                if (refMagicOption == null)
                    continue;

                var item = new ListViewItem(assignment.GetGroupTranslation())
                {
                    Tag = new MagicStoneListViewItemTag
                    {
                        Item = matchingMagicStones.FirstOrDefault(),
                        MagicOption = assignment,
                        MagicOptionInfo = currentMagicOptionInfo,
                    },
                    ForeColor = canBeIncreased ? Color.Green : Color.Red,
                };

                item.SubItems.Add(currentMagicOptionInfo == null ? "0" : currentMagicOptionInfo.Value.ToString());
                item.SubItems.Add(refMagicOption.GetMaxValue().ToString());
                item.SubItems.Add(!matchingMagicStones.Any() ? "x0" : $"x{matchingMagicStones.Sum(i => i.Amount)}");

                if (
                    Globals.Botbase.MagicBundleConfig != null
                    && Globals.Botbase.MagicBundleConfig.MagicStones.Keys.FirstOrDefault(i =>
                        i.Record.ID == matchingMagicStones.FirstOrDefault()?.ItemId
                    ) != null
                    && canBeIncreased
                )
                    item.Checked = true;
                else
                    item.Checked = false;

                item.Font = new Font(Font, FontStyle.Bold);

                lvMagicOptions.Items.Add(item);
            }

            lvMagicOptions.EndUpdate();
            _reloadConfig = true;

            ReloadConfig();
        }
        catch (Exception ex)
        {
            Log.Debug($"[Alchemy] Unknown error while populating magic options settings list: {ex.Message}");
        }
    }

    /// <summary>
    ///     Reloads the configuration with the new selection of magic options
    /// </summary>
    private void ReloadConfig()
    {
        if (!_reloadConfig)
            return;

        Globals.Botbase.MagicBundleConfig = new MagicBundleConfig
        {
            Item = Globals.View.SelectedItem,
            MagicStones = new Dictionary<InventoryItem, RefMagicOpt>(),
        };

        try
        {
            foreach (ListViewItem item in lvMagicOptions.CheckedItems)
            {
                var invItem = (MagicStoneListViewItemTag)item.Tag;

                if (invItem.Item != null)
                    Globals.Botbase.MagicBundleConfig.MagicStones.Add(invItem.Item, invItem.MagicOption);
            }
        }
        catch (Exception e)
        {
            Log.Warn($"[Alchemy] Unhandled exception while reloading magic options configuration: {e.Message}");
        }
    }

    #endregion Methods
}
