﻿using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using RSBot.Alchemy.Bot;
using RSBot.Alchemy.Helper;
using RSBot.Core;
using RSBot.Core.Event;
using RSBot.Core.Objects;

namespace RSBot.Alchemy.Views.Settings
{
    public partial class AttributesSettingsView : UserControl
    {
        internal AttributesConfig Config
        {
            get
            {
                var result = new AttributesConfig{Item = SelectedItem};

                var attributes = new List<AttributesConfig.AttributesConfigItem>(10);

                foreach (var attributePanel in _attributePanels)
                {
                    if (!attributePanel.Checked)
                        continue;

                    if (attributePanel.Stones != null && attributePanel.Stones.Any())
                        attributes.Add(new() {Group = attributePanel.AttributeGroup, MaxValue = attributePanel.MaxValue, Stone = attributePanel.Stones.First() });
                }

                result.Attributes = attributes;

                return result;
            }
        }

        private List<AttributeInfoPanel> _attributePanels;

        private InventoryItem? SelectedItem { get; set; }

        public AttributesSettingsView()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;

            EventManager.SubscribeEvent("OnEnterGame", SubscribeMainFormEvents);
        }

        /// <summary>
        /// Subscribes to the ItemChanged event
        /// </summary>
        private void SubscribeMainFormEvents()
        {
            if (Globals.View != null)
            {
                Globals.View.ItemChanged += View_ItemChanged;
                Globals.View.EngineChanged += View_EngineChanged;
            }
        }

        public void PopulateView()
        {
            panelAttributes.Hide();
            panelAttributes.Controls.Clear();

            _attributePanels = new List<AttributeInfoPanel>(6);
            var selectedItem = Globals.View.SelectedItem;

            if (selectedItem == null)
                return;

            var availableItemAttributes = ItemAttributesInfo.GetAvailableAttributeGroupsForItem(selectedItem.Record);

            if (availableItemAttributes == null)
            {
                Log.Error($"[Alchemy] Could not identify the selected item's attribute information. [ItemId = {selectedItem.ItemId}]");
                
                return;
            }

            if (Globals.Botbase.AttributesConfig == null)
                Globals.Botbase.AttributesConfig = Config;

            foreach (var attributeGroup in availableItemAttributes)
            {
                var matchingStones = AlchemyItemHelper.GetAttributeStones(selectedItem, attributeGroup);

                var config = Globals.Botbase.AttributesConfig.Attributes.FirstOrDefault(x => x.Group == attributeGroup);

                var panel = new AttributeInfoPanel(attributeGroup, matchingStones, selectedItem, config == null ? 0 : config.MaxValue) {Dock = DockStyle.Top};
                _attributePanels.Add(panel);

                if (config == null || !matchingStones.Any())
                {
                    panel.OnChange += PanelOnChange;

                    continue;
                }

                panel.Checked = true;

                panel.OnChange += PanelOnChange;
            }

            panelAttributes.Controls.AddRange(_attributePanels.ToArray());
            Globals.Botbase.AttributesConfig = Config;

            panelAttributes.Show();
        }

        private void PanelOnChange(bool @checked, int maxValue)
        {
            Globals.Botbase.AttributesConfig = Config;
        }

        private void View_EngineChanged(InventoryItem item, Engine engine)
        {
            PopulateView();
        }

        /// <summary>
        /// Will be triggered when the selected item changed
        /// </summary>
        /// <param name="item"></param>
        private void View_ItemChanged(InventoryItem item)
        {
            SelectedItem = item;

            PopulateView();
        }
    }
}
