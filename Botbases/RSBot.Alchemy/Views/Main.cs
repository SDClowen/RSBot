using RSBot.Alchemy.Client.ReferenceObjects;
using RSBot.Core;
using RSBot.Core.Client.ReferenceObjects;
using RSBot.Core.Event;
using RSBot.Core.Objects;
using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using RSBot.Alchemy.Helper;
using RSBot.Alchemy.Bot;
using RSBot.Core.Objects.Inventory.Item;

namespace RSBot.Alchemy.Views
{
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

            public override string ToString() => $"[{InventoryItem.Slot}] {InventoryItem.Record.GetRealName()} (+{InventoryItem.OptLevel})";
        }

        #region Delegates

        /// <param name="item">The item that has been selected</param>
        internal delegate void SelectedItemChanged(InventoryItem item);

        /// <summary>
        /// Will be triggered if the inventory item changes
        /// </summary>
        internal event SelectedItemChanged ItemChanged;

        internal delegate void SelectedEngineChanged(InventoryItem item, Engine engine);

        internal event SelectedEngineChanged EngineChanged;

        #endregion Delegates

        /// <summary>
        /// The selected inventory item
        /// </summary>
        public InventoryItem SelectedItem { get; set; }

        #region Members

        private readonly Settings.EnhanceSettingsView _enhanceSettingsView;
        private readonly Settings.MagicOptionsSettingsView _magicOptionsSettingsView;

        #endregion Members

        #region Constructor

        /// <summary>
        /// Subscribes to several events and adds the user controls to the settings panel
        /// </summary>
        public Main()
        {
            InitializeComponent();
            
            EventManager.SubscribeEvent("OnLoadCharacter", ReloadItemList);
            EventManager.SubscribeEvent("OnAlchemy", new Action<AlchemyType>(OnAlchemy));

            _enhanceSettingsView = new Settings.EnhanceSettingsView { Visible = true, Dock = DockStyle.Fill };
            _magicOptionsSettingsView = new Settings.MagicOptionsSettingsView { Visible = false, Dock = DockStyle.Fill };

            panelSettings.Controls.Add(_enhanceSettingsView);
            panelSettings.Controls.Add(_magicOptionsSettingsView);
        }

        #endregion Constructor

        #region Methods

        private void OnAlchemy(AlchemyType type)
        {
            ReloadItemList();
        }

        /// <summary>
        /// Reloads the list of inventory items that can be used for alchemy actions.
        /// </summary>
        private void ReloadItemList()
        {
            comboItem.Items.Clear();

            var items = Game.Player.Inventory.Where(i => i.Record.IsEquip).ToList();

            items.ForEach((item) =>
            {
                var newComboItem = new InventoryItemComboboxItem(item);

                if (item.Slot > 12)
                    comboItem.Items.Add(newComboItem);

                if (SelectedItem != null && item.Slot == SelectedItem.Slot)
                    comboItem.SelectedItem = newComboItem;
            });
        }

        /*
         * Unfinished logic. Need to find out how to get the % increase values for the params correctly.
         */
        private void PopulateAttributes(InventoryItem item)
        {
            listAttributes.Items.Clear();

            if (item.Attributes == 0) return;

            if (item.Record.IsArmor())
            {
                listAttributes.Items.Add($"{GetTranslation("PARAM_DUR")} +{item.Attributes.GetPercentage(AttributesInfo.ArmorDurability)}%");
                listAttributes.Items.Add($"{GetTranslation("PARAM_PHYSICAL_SPECIALIZE")} +{item.Attributes.GetPercentage(AttributesInfo.ArmorPhySpecialize)}%");
                listAttributes.Items.Add($"{GetTranslation("PARAM_MAGICAL_SPECIALIZE")} +{item.Attributes.GetPercentage(AttributesInfo.ArmorMagSpecialize)}%");
                listAttributes.Items.Add($"{GetTranslation("PARAM_PD")} +{item.Attributes.GetPercentage(AttributesInfo.ArmorPhyDefense)}%");
                listAttributes.Items.Add($"{GetTranslation("PARAM_MD")} +{item.Attributes.GetPercentage(AttributesInfo.ArmorMagDefense)}%");
                listAttributes.Items.Add($"{GetTranslation("PARAM_ER")} +{item.Attributes.GetPercentage(AttributesInfo.ArmorEvasionRatio)}%");
            }

            if (item.Record.IsShield())
            {
                listAttributes.Items.Add($"{GetTranslation("PARAM_DUR")} +{item.Attributes.GetPercentage(AttributesInfo.ShieldDurability)}%");
                listAttributes.Items.Add($"{GetTranslation("PARAM_PHYSICAL_SPECIALIZE")} +{item.Attributes.GetPercentage(AttributesInfo.ShieldPhySpecialize)}%");
                listAttributes.Items.Add($"{GetTranslation("PARAM_MAGICAL_SPECIALIZE")} +{item.Attributes.GetPercentage(AttributesInfo.ShieldMagSpecialize)}%");
                listAttributes.Items.Add($"{GetTranslation("PARAM_PD")} +{item.Attributes.GetPercentage(AttributesInfo.ShieldPhyDefense)}%");
                listAttributes.Items.Add($"{GetTranslation("PARAM_MD")} +{item.Attributes.GetPercentage(AttributesInfo.ShieldMagDefense)}%");
                listAttributes.Items.Add($"{GetTranslation("PARAM_BLOCKING")} +{item.Attributes.GetPercentage(AttributesInfo.ShieldBlockRatio)}%");
            }

            if (item.Record.IsWeapon())
            {
                listAttributes.Items.Add($"{GetTranslation("PARAM_DUR")} +{item.Attributes.GetPercentage(AttributesInfo.WeaponDurability)}%");
                listAttributes.Items.Add($"{GetTranslation("PARAM_PHYSICAL_SPECIALIZE")} +{item.Attributes.GetPercentage(AttributesInfo.WeaponPhySpecialize)}%");
                listAttributes.Items.Add($"{GetTranslation("PARAM_MAGICAL_SPECIALIZE")} +{item.Attributes.GetPercentage(AttributesInfo.WeaponMagSpecialize)}%");
                listAttributes.Items.Add($"{GetTranslation("PARAM_HR")} +{item.Attributes.GetPercentage(AttributesInfo.WeaponHitRatio)}%");
                listAttributes.Items.Add($"{GetTranslation("PARAM_PA")} +{item.Attributes.GetPercentage(AttributesInfo.WeaponPhyDmg)}%");
                listAttributes.Items.Add($"{GetTranslation("PARAM_MA")} +{item.Attributes.GetPercentage(AttributesInfo.WeaponMagDmg)}%");
                listAttributes.Items.Add($"{GetTranslation("PARAM_CRITICAL")} +{item.Attributes.GetPercentage(AttributesInfo.WeaponCriticalHitRatio)}%");
            }

            if (item.Record.IsAccessory())
            {
                listAttributes.Items.Add($"{GetTranslation("PARAM_PR")} +{item.Attributes.GetPercentage(AttributesInfo.AccessoryPhyAbsorbRatio)}%");
                listAttributes.Items.Add($"{GetTranslation("PARAM_MR")} +{item.Attributes.GetPercentage(AttributesInfo.AccessoryMagAbsorbRatio)}%");
            }
        }

        /// <summary>
        /// Just a shorthand for Game.ReferenceManager.GetTranslation(name);
        /// </summary>
        /// <param name = "name" > Name of the translation</param>
        /// <returns></returns>
        private string GetTranslation(string name)
        {
            return Game.ReferenceManager.GetTranslation(name);
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
        /// <param name="success"></param>
        /// <param name="message"></param>
        public void AddLog(string itemName, bool success, string message)
        {
            var item = new ListViewItem(itemName);

            item.SubItems.Add(success ? "Success" : "Fail");
            item.SubItems.Add(message);

            lvLog.Items.Add(item);

            //Scroll to bottom of the list
            lvLog.Items[lvLog.Items.Count - 1].EnsureVisible();
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
            ReloadItemList();
        }

        /// <summary>
        /// Will be triggered when the user selects a new item or if an item was destroyed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboItem.SelectedIndex < 0) return;
            var selectedItem = (InventoryItemComboboxItem)comboItem.Items[comboItem.SelectedIndex];
            SelectedItem = selectedItem.InventoryItem;

            if (SelectedItem == null) return;

            PopulateAttributes(SelectedItem);
            PopulateMagicOptions(SelectedItem);

            lblDegree.Text = SelectedItem.Record.Degree.ToString();
            lblOptLevel.Text = $"+{SelectedItem.OptLevel}";
            ItemChanged?.Invoke(SelectedItem);
        }

        /// <summary>
        /// Will be triggered when the user click on the radio button to change the settings view
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioEngine_CheckedChanged(object sender, EventArgs e)
        {
            if (radioEnhance.Checked)
                LoadEngineSettings(Engine.Enhancement);

            if (radioMagicOptions.Checked)
                LoadEngineSettings(Engine.Magic);
        }

        /// <summary>
        /// Reloads the engine settings depending on the selected engine
        /// </summary>
        /// <param name="engine">The engine to load the settings for</param>
        private void LoadEngineSettings(Engine engine)
        {
            if (_enhanceSettingsView == null || _magicOptionsSettingsView == null)
                return;

            EngineChanged?.Invoke(SelectedItem, engine);

            if (Globals.Botbase != null && !Kernel.Bot.Running)
                Globals.Botbase.Engine = engine;

            if (engine == Engine.Enhancement)
            {
                _enhanceSettingsView.Show();
                _magicOptionsSettingsView.Hide();
            }

            if (engine == Engine.Magic)
            {
                _enhanceSettingsView.Hide();
                _magicOptionsSettingsView.Show();
            }
        }

        #endregion Events
    }
}