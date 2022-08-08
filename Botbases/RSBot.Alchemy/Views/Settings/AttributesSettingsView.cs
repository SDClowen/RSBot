using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using RSBot.Alchemy.Helper;
using RSBot.Core;
using RSBot.Core.Event;
using RSBot.Core.Objects;
using RSBot.Core.Objects.Inventory.Item;

namespace RSBot.Alchemy.Views.Settings
{
    public partial class AttributesSettingsView : UserControl
    {
        private List<AttributeInfoPanel> _attributePanels;

        public AttributesSettingsView()
        {
            InitializeComponent();

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

            var availableItemAttributes = AttributesInfo.GetAvailableAttributeGroupsForItem(selectedItem.Record);

            if (availableItemAttributes == null)
            {
                Log.Error($"[Alchemy] Could not identify the selected item's attribute information. [ItemId = {selectedItem.ItemId}]");
                
                return;
            }

            foreach (var attributeGroup in availableItemAttributes)
            {
                var matchingStones = AlchemyItemHelper.GetAttributeStones(selectedItem, attributeGroup);


                var panel = new AttributeInfoPanel(attributeGroup, matchingStones, selectedItem) {Dock = DockStyle.Top};
                panelAttributes.Controls.Add(panel);
            }

            panelAttributes.Show();
        }

        private void View_EngineChanged(InventoryItem item, Bot.Engine engine)
        {
            PopulateView();
        }

        /// <summary>
        /// Will be triggered when the selected item changed
        /// </summary>
        /// <param name="item"></param>
        private void View_ItemChanged(InventoryItem item)
        {
            PopulateView();
        }
    }
}
