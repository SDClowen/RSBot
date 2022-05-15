using RSBot.Core;
using RSBot.Core.Event;
using RSBot.Core.Extensions;
using RSBot.Core.Objects.Inventory;
using System.Windows.Forms;

namespace RSBot.Inventory.Views
{
    [System.ComponentModel.ToolboxItem(false)]
    public partial class Main : UserControl
    {
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        private object _lock;

        /// <summary>
        /// Initializes a new instance of the <see cref="Main"/> class.
        /// </summary>
        public Main()
        {
            _lock = new object();
            InitializeComponent();
            comboInventoryType.SelectedIndex = 0;
            SubscribeEvents();

            listViewMain.SmallImageList = Core.Extensions.ListViewExtensions.StaticItemsImageList;
        }

        /// <summary>
        /// Subscribes the events.
        /// </summary>
        private void SubscribeEvents()
        {
            EventManager.SubscribeEvent("OnLoadCharacter", () => {
                if (Visible)
                    UpdateInventoryList();
            });

            //EventManager.SubscribeEvent("OnUpdateInventoryItem", new Action<byte>(OnUpdateInventoryItem));
            //EventManager.SubscribeEvent("OnUseItem", new Action<byte>(OnUpdateInventoryItem));
            EventManager.SubscribeEvent("OnInventoryUpdate", UpdateInventoryList);
        }

        /// <summary>
        /// Calling when update inventory item
        /// </summary>
        /// <param name="slot"></param>
        private void OnUpdateInventoryItem(byte slot)
        {
            var key = slot.ToString();
            if (!listViewMain.Items.ContainsKey(key))
                return;

            var inventoryItem = Game.Player.Inventory.GetItemAt(slot);
            if (inventoryItem == null)
                return;

            var listViewItem = listViewMain.Items[key];

            var name = inventoryItem.Record.GetRealName();
            if (inventoryItem.OptLevel > 0)
                name += " (+" + inventoryItem.OptLevel + ")";

            listViewItem.SubItems[0].Text = name;
            listViewItem.SubItems[1].Text = inventoryItem.Amount.ToString();

            if (inventoryItem.Record.IsEquip)
                listViewItem.SubItems[2].Text = inventoryItem.Record.GetRarityName();

            listViewItem.LoadItemImageAsync(inventoryItem.Record);
        }

        /// <summary>
        /// Updates the inventory list.
        /// </summary>
        public void UpdateInventoryList()
        {
            if (Parent == null)
                return;

            if (!Parent.Visible)
                return;

            if (Game.Player == null) 
                return;

            listViewMain.BeginUpdate();
            listViewMain.Items.Clear();

            switch (comboInventoryType.SelectedIndex)
            {
                case 0:

                    var itemsPlayer = Game.Player.Inventory.GetNormalPartItems();
                    foreach (var item in itemsPlayer)
                        AddItem(item);

                    lblFreeSlots.Text = Game.Player.Inventory.Count + "/" + Game.Player.Inventory.Capacity;

                    break;

                case 1:

                    foreach (var item in Game.Player.Inventory.GetEquippedPartItems())
                        AddItem(item);

                    lblFreeSlots.Text = "0";

                    break;

                case 2:

                    foreach (var item in Game.Player.Avatars)
                        AddItem(item);

                    lblFreeSlots.Text = "0";

                    break;

                case 3:

                    if (!Game.Player.HasActiveAbilityPet)
                    {
                        listViewMain.EndUpdate();
                        return;
                    }

                    foreach (var item in Game.Player.AbilityPet.Inventory)
                        AddItem(item);

                    lblFreeSlots.Text = Game.Player.AbilityPet.Inventory.Count + "/" + Game.Player.AbilityPet.Inventory.Capacity;

                    break;

                case 4:

                    if (Game.Player.Storage == null)
                    {
                        listViewMain.EndUpdate();
                        return;
                    }

                    foreach (var item in Game.Player.Storage)
                        AddItem(item);

                    lblFreeSlots.Text = Game.Player.Storage.Count + "/" + Game.Player.Storage.Capacity;

                    break;

                case 5:

                    if (Game.Player.GuildStorage == null)
                    {
                        listViewMain.EndUpdate();
                        return;
                    }

                    foreach (var item in Game.Player.GuildStorage)
                        AddItem(item);

                    lblFreeSlots.Text = Game.Player.GuildStorage.Count + "/" + Game.Player.GuildStorage.Capacity;

                    break;
            }

            listViewMain.EndUpdate();
        }

        /// <summary>
        /// Adds the item.
        /// </summary>
        /// <param name="item">The item.</param>
        private void AddItem(InventoryItem item)
        {
            var name = item.Record.GetRealName();
            if (item.OptLevel > 0)
                name += " (+" + item.OptLevel + ")";

            var lvItem = listViewMain.Items.Add(item.Slot.ToString(), name, 0);
            lvItem.Tag = item;
            lvItem.SubItems.Add(item.Amount.ToString());
            
            if(item.Record.IsEquip)
                lvItem.SubItems.Add(item.Record.GetRarityName());

            lvItem.LoadItemImageAsync(item.Record);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void Main_Load(object sender, System.EventArgs e)
        {
            var tab = Parent as TabPage;
            tab.VisibleChanged += Parent_VisibleChanged;
        }

        /// <summary>
        /// Handles the visible changed event of the parent.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void Parent_VisibleChanged(object sender, System.EventArgs e)
        {
            if(!Visible)
                listViewMain.Items.Clear();
            else
                UpdateInventoryList();
        }

        /// <summary>
        /// Handles the selected index changed event of the comboInventoryType control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void comboInventoryType_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            UpdateInventoryList();
        }

        /// <summary>
        /// Handles the selected index changed event of the listViewMain control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void listViewMain_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (listViewMain.SelectedIndices.Count != 1)
                return;

            /*var listViewItem = listViewMain.SelectedItems[0];
            var inventoryItem = listViewItem.Tag as InventoryItem;
            buttonUseItem.Enabled = inventoryItem.Record.IsSkillItem;*/
        }

        /// <summary>
        /// Handles the Click event of the btnReload control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void buttonUseItem_Click(object sender, System.EventArgs e)
        {
            if (listViewMain.SelectedIndices.Count != 1)
                return;

            var listViewItem = listViewMain.SelectedItems[0];
            var inventoryItem = listViewItem.Tag as InventoryItem;
            inventoryItem.Use();

            /*var dialog = new UseItemDialog();
            if(dialog.ShowDialog(this) == DialogResult.OK)
            {

                return;
            }*/
        }

        private void listViewMain_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listViewMain.SelectedItems.Count <= 0)
                return;

#if !DEBUG
            if(GlobalConfig.Get<bool>("RSBot.DebugEnvironment") == false)
                return;
#endif

            var itemForm = new ItemProperties(listViewMain.SelectedItems[0].Tag as InventoryItem);
            itemForm.Show();
        }
    }
}