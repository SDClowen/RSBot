using RSBot.Core;
using RSBot.Core.Client.ReferenceObjects;
using RSBot.Core.Objects;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RSBot.Inventory.Views
{
    [System.ComponentModel.ToolboxItem(false)]
    public partial class Main : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Main"/> class.
        /// </summary>
        public Main()
        {
            InitializeComponent();
            comboInventoryType.SelectedIndex = 0;
        }

        /// <summary>
        /// Updates the inventory list.
        /// </summary>
        public void UpdateInventoryList()
        {
            if (Game.Player == null) return;

            listViewMain.BeginUpdate();
            listViewMain.Items.Clear();
            switch (comboInventoryType.SelectedIndex)
            {
                case 0:
                    foreach (var item in Game.Player.Inventory.Items.Where(item => item.Slot >= 13).OrderBy(p => p.Slot))
                        AddItem(item);

                    lblFreeSlots.Text = (Game.Player.Inventory.Size - Game.Player.Inventory.Items.Count) + "/" + Game.Player.Inventory.Size;
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

                    lblFreeSlots.Text = (Game.Player.AbilityPet.Slots - Game.Player.AbilityPet.Items.Count) + "/" + Game.Player.AbilityPet.Slots;
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
            var lvItem = new ListViewItem { Text = item.Slot.ToString(), Tag = item.Record };

            if (item.OptLevel > 0)
                lvItem.SubItems.Add(item.Record.GetRealName(true) + " (+" + item.OptLevel + ")");
            else
                lvItem.SubItems.Add(item.Record.GetRealName(true));

            lvItem.SubItems.Add(item.Amount.ToString());

            listViewMain.Items.Add(lvItem);
        }

        /// <summary>
        /// Loads the items images into the ImageList of the listViewMain control.
        /// </summary>
        private void LoadItemImages()
        {
            foreach (ListViewItem item in listViewMain.Items)
            {
                var itemInfo = (RefObjItem)item.Tag;

                //No need to reload the image from the PK2
                if (imgItems.Images.ContainsKey(itemInfo.ID.ToString()))
                {
                    item.ImageKey = itemInfo.ID.ToString();

                    continue;
                }

                imgItems.Images.Add(itemInfo.ID.ToString(), itemInfo.GetIcon());

                //Renders the image
                item.ImageKey = itemInfo.ID.ToString();
            }
        }

        /// <summary>
        /// Handles the Click event of the btnReload control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnReload_Click(object sender, System.EventArgs e)
        {
            UpdateInventoryList();
        }
    }
}