using System.Collections.Generic;
using System.Windows.Forms;
using RSBot.Alchemy.Helper;
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

            if (selectedItem.Record.IsAccessory())
            {
                _attributePanels.Add(new AttributeInfoPanel(AlchemyItemHelper.GetAttributeStones(selectedItem, AttributesGroup.Durability), selectedItem, "PARAM_PR", 0));
                _attributePanels.Add(new AttributeInfoPanel(null, selectedItem, "PARAM_MR", 1));
            }
            else if (selectedItem.Record.IsWeapon())
            {
                _attributePanels.Add(new AttributeInfoPanel(null, selectedItem, "PARAM_DUR", 0));
                _attributePanels.Add(new AttributeInfoPanel(null, selectedItem, "PARAM_PHYSICAL_SPECIALIZE", 1));
                _attributePanels.Add(new AttributeInfoPanel(null, selectedItem, "PARAM_MAGICAL_SPECIALIZE", 2));
                _attributePanels.Add(new AttributeInfoPanel(null, selectedItem, "PARAM_HR", 3));
                _attributePanels.Add(new AttributeInfoPanel(null, selectedItem, "PARAM_PA", 4));
                _attributePanels.Add(new AttributeInfoPanel(null, selectedItem, "PARAM_MA", 5));
                _attributePanels.Add(new AttributeInfoPanel(null, selectedItem, "PARAM_CRITICAL", 6));
            } 
            else if (selectedItem.Record.IsArmor())
            {
                _attributePanels.Add(new AttributeInfoPanel(null, selectedItem, "PARAM_DUR",0));
                _attributePanels.Add(new AttributeInfoPanel(null, selectedItem, "PARAM_PHYSICAL_SPECIALIZE", 1));
                _attributePanels.Add(new AttributeInfoPanel(null, selectedItem, "PARAM_MAGICAL_SPECIALIZE", 2));
                _attributePanels.Add(new AttributeInfoPanel(null, selectedItem, "PARAM_PD",3));
                _attributePanels.Add(new AttributeInfoPanel(null, selectedItem, "PARAM_MD",4));
                _attributePanels.Add(new AttributeInfoPanel(null, selectedItem, "PARAM_ER",5));
            }
            else if (selectedItem.Record.IsShield())
            {
                _attributePanels.Add(new AttributeInfoPanel(null, selectedItem, "PARAM_DUR",0));
                _attributePanels.Add(new AttributeInfoPanel(null, selectedItem, "PARAM_PHYSICAL_SPECIALIZE", 1));
                _attributePanels.Add(new AttributeInfoPanel(null, selectedItem, "PARAM_MAGICAL_SPECIALIZE", 2));
                _attributePanels.Add(new AttributeInfoPanel(null, selectedItem, "PARAM_PD", 3));
                _attributePanels.Add(new AttributeInfoPanel(null, selectedItem, "PARAM_MD", 4));
                _attributePanels.Add(new AttributeInfoPanel(null, selectedItem, "PARAM_BLOCKING", 5));
            }

            foreach (var panel in _attributePanels)
            {
                panel.Dock = DockStyle.Top;
            }

            panelAttributes.Controls.AddRange(_attributePanels.ToArray());
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
