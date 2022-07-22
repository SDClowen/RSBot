using RSBot.Alchemy.Client.ReferenceObjects;
using RSBot.Core;
using RSBot.Core.Client.ReferenceObjects;
using RSBot.Core.Event;
using RSBot.Core.Objects;
using RSBot.Core.Objects.Item;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace RSBot.Alchemy.Views.Settings
{
    public partial class MagicOptionsSettingsView : UserControl
    {
        private class MagicStoneListViewItemTag
        {
            public InventoryItem Item { get; set; }
            public RefMagicOpt MagicOption { get; set; }

            public MagicOptionInfo MagicOptionInfo { get; set; }
        }

        #region Members

        private bool _reloadConfig;

        #endregion Members

        #region Constructor

        /// <summary>
        /// Subscribes several events
        /// </summary>
        public MagicOptionsSettingsView()
        {
            InitializeComponent();

            EventManager.SubscribeEvent("OnEnterGame", SubscribeMainFormEvents);
        }

        #endregion Constructor

        #region Events

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

        private void View_EngineChanged(InventoryItem item, Bot.Engine engine)
        {
            PopulateListView();
        }

        /// <summary>
        /// Will be triggered when the selected item changed
        /// </summary>
        /// <param name="item"></param>
        private void View_ItemChanged(InventoryItem item)
        {
            PopulateListView();
        }

        /// <summary>
        /// Will be triggered when a list view item was selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lvMagicOptions_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            ReloadConfig();
        }

        #endregion Events

        #region Methods

        /// <summary>
        /// Populate the list view of available magic options for the selected item
        /// </summary>
        public void PopulateListView()
        {
            if (Globals.View.SelectedItem == null) return;

            lvMagicOptions.BeginUpdate();
            lvMagicOptions.Items.Clear();
            _reloadConfig = false;

            var selectedItem = Globals.View.SelectedItem;
            var assignments = Game.ReferenceManager.GetAssignments(selectedItem.Record.TypeID3, selectedItem.Record.TypeID4);
            foreach (var assignment in assignments)
            {
                if (assignment == null) continue;

                var matchingItem = Helper.AlchemyItemHelper.GetStoneByGroup(selectedItem, assignment.Group);
                if (matchingItem == null) continue;

                MagicOptionInfo current = null;
                RefMagicOpt currentRecord = null;
                if (selectedItem.MagicOptions != null)
                    foreach (var magicOption in selectedItem.MagicOptions)
                    {
                        var record = Game.ReferenceManager.GetMagicOption(magicOption.Id);
                        if (record == null || record.Group != assignment.Group) continue;

                        current = magicOption;
                        currentRecord = record;
                        break;
                    }

                var hasMax = currentRecord != null && currentRecord.GetMaxValue() <= current.Value;
                if (hasMax) continue;

                var item = new ListViewItem(assignment.GetGroupTranslation())
                {
                    Tag = new MagicStoneListViewItemTag { Item = matchingItem, MagicOption = assignment, MagicOptionInfo = current }
                };

                item.SubItems.Add(current == null ? "0" : current.Value.ToString());
                item.SubItems.Add(Game.ReferenceManager.GetMagicOption(assignment.Group, (byte)selectedItem.Record.Degree)?.GetMaxValue().ToString());
                item.SubItems.Add($"{matchingItem?.Amount}");

                if (Globals.Botbase.MagicOptionsConfig != null && Globals.Botbase.MagicOptionsConfig.MagicStones.Keys.Contains(matchingItem))
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

        /// <summary>
        /// Reloads the configuration with the new selection of magic options
        /// </summary>
        private void ReloadConfig()
        {
            if (!_reloadConfig) return;

            Globals.Botbase.MagicOptionsConfig = new Bot.MagicOptionsConfig
            {
                Item = Globals.View.SelectedItem,
                MagicStones = new System.Collections.Generic.Dictionary<InventoryItem, RefMagicOpt>()
            };

            foreach (ListViewItem item in lvMagicOptions.CheckedItems)
            {
                var invItem = (MagicStoneListViewItemTag)item.Tag;

                if (invItem != null)
                    Globals.Botbase.MagicOptionsConfig.MagicStones.Add(invItem.Item, invItem.MagicOption);
            }
        }

        #endregion Methods
    }
}