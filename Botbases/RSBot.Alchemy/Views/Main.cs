using RSBot.Alchemy.Bot;
using RSBot.Alchemy.Client.ReferenceObjects;
using RSBot.Alchemy.Views.Settings;
using RSBot.Core;
using RSBot.Core.Client.ReferenceObjects;
using RSBot.Core.Event;
using RSBot.Core.Extensions;
using RSBot.Core.Objects;
using System;
using System.Linq;
using System.Windows.Forms;

namespace RSBot.Alchemy.Views
{
    [System.ComponentModel.ToolboxItem(false)]
    public partial class Main : UserControl
    {
        internal class InventoryItemComboboxItem
        {
            /// <summary>
            /// The inventory item linked to this combobox item
            /// </summary>
            public InventoryItem InventoryItem { get; set; }

            /// <param name="inventoryItem">The inventory item linked to this combobox item</param>
            public InventoryItemComboboxItem(InventoryItem inventoryItem)
            {
                InventoryItem = inventoryItem;
            }

            public override string ToString() => $"[{InventoryItem?.Slot}] {InventoryItem?.Record?.GetRealName()} (+{InventoryItem?.OptLevel})";
        }

        #region Properties

        public bool IsRefreshing { get; private set; }

        #endregion Properties

        #region Delegates

        /// <param name="item">The item that has been selected</param>
        internal delegate void SelectedItemChanged(InventoryItem item);

        /// <summary>
        /// Will be triggered if the inventory item changes
        /// </summary>
        internal event SelectedItemChanged ItemChanged;

        /// <summary>
        /// Will be triggered when the user selects a different engine
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="alchemyEngine">The alchemy engine.</param>
        internal delegate void SelectedEngineChanged(InventoryItem item, AlchemyEngine alchemyEngine);

        /// <summary>
        /// Will be triggered when the user selects a different engine
        /// </summary>
        internal event SelectedEngineChanged EngineChanged;

        #endregion Delegates

        /// <summary>
        /// The selected inventory item
        /// </summary>
        public InventoryItem SelectedItem { get; set; }

        #region Members

        private readonly EnhanceSettingsView _enhanceSettingsView;
        private readonly MagicOptionsSettingsView _magicOptionsSettingsView;
        private readonly AttributesSettingsView _attributeSettingsView;

        #endregion Members

        #region Constructor

        /// <summary>
        /// Subscribes to several events and adds the user controls to the settings panel
        /// </summary>
        public Main()
        {
            CheckForIllegalCrossThreadCalls = false;

            InitializeComponent();
            SetStyle(
                ControlStyles.UserPaint |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer,
                true);

            EventManager.SubscribeEvent("OnLoadCharacter", () =>
            {
                if (IsDisposed || Disposing)
                    return;

                ReloadItemList();
            });

            EventManager.SubscribeEvent("OnAlchemy", new Action<AlchemyType>(OnAlchemy));

            _enhanceSettingsView = new EnhanceSettingsView { Visible = true, Dock = DockStyle.Fill };
            _magicOptionsSettingsView = new MagicOptionsSettingsView { Visible = false, Dock = DockStyle.Fill };
            _attributeSettingsView = new AttributesSettingsView { Visible = false, Dock = DockStyle.Fill };

            panelSettings.Controls.Add(_enhanceSettingsView);
            panelSettings.Controls.Add(_magicOptionsSettingsView);
            panelSettings.Controls.Add(_attributeSettingsView);
        }

        #endregion Constructor

        #region Methods
        
        private void OnAlchemy(AlchemyType type)
        {
            if (IsDisposed || Disposing)
                return;

            ReloadItemList();
        }

        /// <summary>
        /// Reloads the list of inventory items that can be used for alchemy actions.
        /// </summary>
        private void ReloadItemList()
        {
            IsRefreshing = true;

            comboItem.Items.Clear();

            var items = Game.Player.Inventory.Where(i => i.Record.IsEquip && !i.Record.IsAvatar && !i.Record.IsJobOutfit).ToList();

            try
            {
                foreach (var item in items)
                {
                    var newComboItem = new InventoryItemComboboxItem(item);

                    if (item.Slot > 12)
                        comboItem.Items.Add(newComboItem);

                    if (SelectedItem != null && item.Slot == SelectedItem.Slot)
                        comboItem.SelectedItem = newComboItem;
                }
            }
            catch (Exception e)
            {
                Log.Debug($"[Alchemy] Unknown error while reloading item list: {e.Message}");
            }
            finally
            {
                IsRefreshing = false;
            }

            if (comboItem.SelectedItem == null)
                SelectedItem = null;
        }

        /// <summary>
        /// Populates the attributes list.
        /// </summary>
        /// <param name="item">The item.</param>
        private void PopulateAttributes(InventoryItem item)
        {
            listAttributes.Items.Clear();

            if (item.Attributes == 0) return;

            var availableAttributes = ItemAttributesInfo.GetAvailableAttributeGroupsForItem(item.Record);

            if (availableAttributes == null)
                return;

            foreach (var attribute in availableAttributes)
            {
                var slot = ItemAttributesInfo.GetAttributeSlotForItem(attribute, item.Record);
                var translation = attribute.GetTranslation();

                listAttributes.Items.Add($"{translation} +{item.Attributes.GetPercentage(slot)}%");
            }
        }

        /// <summary>
        /// Populates the list of magic options of the selected item
        /// </summary>
        /// <param name="item">The selected item</param>
        private void PopulateMagicOptions(InventoryItem item)
        {
            listMagicOptions.Items.Clear();

            if (item.MagicOptions == null) return;

            foreach (var magicOption in item.MagicOptions)
            {
                var option = Game.ReferenceManager.GetMagicOption(magicOption.Id);

                if (option != null)
                    listMagicOptions.Items.Add(option.GetFusingTranslation(magicOption.Value));
            }
        }

        /// <summary>
        /// Adds a new log message to the alchemy log listview
        /// </summary>
        /// <param name="itemName"></param>
        /// <param name="message"></param>
        public void AddLog(string itemName, string message)
        {
            var item = new ListViewItem(itemName);

            item.SubItems.Add(message);

            lvLog.Items.Add(item);

            //Scroll to bottom of the list
            lvLog.Items[lvLog.Items.Count - 1].EnsureVisible();

            Log.Notify($"[Alchemy] [{itemName}]: {message}");
        }

        #endregion Methods

        #region Events

        /// <summary>
        /// Will be triggered when the user clicks the refresh link
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linkRefreshItemList_Click(object sender, EventArgs e)
        {
            Invoke(ReloadItemList);
        }

        /// <summary>
        /// Will be triggered when the user selects a new item or if an item was destroyed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            IsRefreshing = true;

            if (comboItem.SelectedIndex < 0) return;
            var selectedItem = (InventoryItemComboboxItem)comboItem.Items[comboItem.SelectedIndex];
            SelectedItem = selectedItem.InventoryItem;

            if (SelectedItem == null) return;

            Invoke(() => PopulateAttributes(SelectedItem));
            Invoke(() => PopulateMagicOptions(SelectedItem));

            lblDegree.Text = SelectedItem.Record.Degree.ToString();
            lblOptLevel.Text = $"+{SelectedItem.OptLevel}";
            ItemChanged?.Invoke(SelectedItem);

            IsRefreshing = false;
        }

        /// <summary>
        /// Will be triggered when the user click on the radio button to change the settings view
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioEngine_CheckedChanged(object sender, EventArgs e)
        {
            if (radioEnhance.Checked)
                LoadEngineSettings(AlchemyEngine.Enhance);

            if (radioMagicOptions.Checked)
                LoadEngineSettings(AlchemyEngine.Magic);

            if (radioAttributes.Checked)
                LoadEngineSettings(AlchemyEngine.Attribute);
        }

        /// <summary>
        /// Reloads the engine settings depending on the selected engine
        /// </summary>
        /// <param name="alchemyEngine">The engine to load the settings for</param>
        private void LoadEngineSettings(AlchemyEngine alchemyEngine)
        {
            IsRefreshing = true;

            if (_enhanceSettingsView == null || _magicOptionsSettingsView == null || _attributeSettingsView == null)
                return;

            if (Globals.Botbase != null && !Kernel.Bot.Running)
                Globals.Botbase.AlchemyEngine = alchemyEngine;

            if (alchemyEngine == AlchemyEngine.Enhance)
            {
                _enhanceSettingsView.Show();
                _magicOptionsSettingsView.Hide();
                _attributeSettingsView.Hide();
            }

            if (alchemyEngine == AlchemyEngine.Magic)
            {
                _enhanceSettingsView.Hide();
                _magicOptionsSettingsView.Show();
                _attributeSettingsView.Hide();
            }

            if (alchemyEngine == AlchemyEngine.Attribute)
            {
                _enhanceSettingsView.Hide();
                _magicOptionsSettingsView.Hide();
                _attributeSettingsView.Show();
            }

            EngineChanged?.Invoke(SelectedItem, alchemyEngine);

            IsRefreshing = false;
        }

        #endregion Events
    }
}