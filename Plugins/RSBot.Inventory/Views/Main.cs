using RSBot.Core;
using RSBot.Core.Event;
using RSBot.Core.Objects;
using System;
using System.Linq;
using System.Threading.Tasks;
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

            LoadItemImage(listViewItem);
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
                    foreach (var item in Game.Player.Inventory.Items.Where(item => item.Slot >= 13).OrderBy(p => p.Slot))
                        AddItem(item);

                    lblFreeSlots.Text = Game.Player.Inventory.Items.Count + "/" + Game.Player.Inventory.Size;
                    break;

                case 1:
                    foreach (var item in Game.Player.Inventory.Items.Where(item => item.Slot < 13).OrderBy(p => p.Slot))
                        AddItem(item);

                    lblFreeSlots.Text = "not calculated";
                    break;

                case 2:
                    foreach (var item in Game.Player.Inventory.Avatars.OrderBy(p => p.Slot))
                        AddItem(item);
                    lblFreeSlots.Text = "not calculated";
                    break;

                case 3:
                    if (!Game.Player.HasActiveAbilityPet)
                    {
                        listViewMain.EndUpdate();
                        return;
                    }
                    foreach (var item in Game.Player.AbilityPet.Items.OrderBy(p => p.Slot))
                        AddItem(item);

                    lblFreeSlots.Text = Game.Player.AbilityPet.Items.Count + "/" + Game.Player.AbilityPet.Slots;
                    break;

                case 4:
                    if (Game.Player.Storage == null)
                    {
                        listViewMain.EndUpdate();
                        return;
                    }
                    foreach (var item in Game.Player.Storage.Items.OrderBy(p => p.Slot))
                        AddItem(item);

                    break;
            }

            // Load the item icons
            Task.Run(() => { LoadItemImages(); });

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
        }

        /// <summary>
        /// Load the item image into the ListViewItem
        /// </summary>
        private void LoadItemImage(ListViewItem item)
        {
            lock (_lock)
            {
                var itemInfo = (InventoryItem)item.Tag;

                //No need to reload the image from the PK2
                if (imgItems.Images.ContainsKey(itemInfo.ItemId.ToString()))
                {
                    item.ImageKey = itemInfo.ItemId.ToString();

                    return;
                }

                imgItems.Images.Add(itemInfo.ItemId.ToString(), itemInfo.Record.GetIcon());

                //Renders the image
                item.ImageKey = itemInfo.ItemId.ToString();
            }
        }

        /// <summary>
        /// Loads the items images into the ImageList of the listViewMain control.
        /// </summary>
        private void LoadItemImages()
        {
            foreach (ListViewItem item in listViewMain.Items)
                LoadItemImage(item);
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
    }
}