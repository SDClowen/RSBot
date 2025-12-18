using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using RSBot.Core;
using RSBot.Core.Client.ReferenceObjects;
using RSBot.Core.Event;
using RSBot.Core.Extensions;
using RSBot.Core.Network;
using RSBot.Core.Objects;
using RSBot.Core.Objects.Inventory;
using SDUI;
using SDUI.Controls;
using Button = SDUI.Controls.Button;
using ListViewExtensions = RSBot.Core.Extensions.ListViewExtensions;

namespace RSBot.Inventory.Views;

[ToolboxItem(false)]
public partial class Main : DoubleBufferedControl
{
    /// <summary>
    ///     <inheritdoc />
    /// </summary>
    private readonly object _lock;

    /// <summary>
    ///     <inheritdoc />
    /// </summary>
    private int _selectedIndex;

    /// <summary>
    ///     Initializes a new instance of the <see cref="Main" /> class.
    /// </summary>
    public Main()
    {
        _lock = new object();
        InitializeComponent();
        SubscribeEvents();

        listViewMain.SmallImageList = ListViewExtensions.StaticItemsImageList;

        var backColor = ColorScheme.BorderColor.Determine().Alpha(85);
        buttonInventory.ForeColor = backColor.Determine();
        buttonInventory.Color = backColor;
    }

    /// <summary>
    ///     Subscribes the events.
    /// </summary>
    private void SubscribeEvents()
    {
        EventManager.SubscribeEvent("OnLoadCharacter", OnLoadCharacter);
        EventManager.SubscribeEvent("OnUpdateInventoryItem", new Action<byte>(OnUpdateInventoryItem));
        EventManager.SubscribeEvent("OnUseItem", new Action<byte>(OnUpdateInventoryItem));
        EventManager.SubscribeEvent("OnInventoryUpdate", UpdateInventoryList);
    }

    private void OnLoadCharacter()
    {
        UpdateInventoryList();
    }

    /// <summary>
    ///     Calling when update inventory item
    /// </summary>
    /// <param name="slot"></param>
    private void OnUpdateInventoryItem(byte slot)
    {
        var key = slot.ToString();
        if (!listViewMain.Items.ContainsKey(key))
            return;

        lock (_lock)
        {
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
    }

    /// <summary>
    ///     Updates the inventory list.
    /// </summary>
    public void UpdateInventoryList()
    {
        if (!Visible)
            return;

        if (Game.Player == null)
            return;

        lock (_lock)
        {
            listViewMain.BeginUpdate();
            listViewMain.Items.Clear();

            switch (_selectedIndex)
            {
                case 0:
                    var itemsPlayer = Game.Player.Inventory.GetNormalPartItems();
                    foreach (var item in itemsPlayer)
                        AddItem(item);

                    lblFreeSlots.Text = Game.Player.Inventory.FreeSlots + "/" + Game.Player.Inventory.NormalPartSize;
                    pbInventoryStatus.Value = Game.Player.Inventory.FreeSlots;
                    pbInventoryStatus.Maximum = Game.Player.Inventory.NormalPartSize;
                    break;

                case 1:

                    var items = Game.Player.Inventory.GetEquippedPartItems();
                    foreach (var item in items)
                        AddItem(item);

                    int maxSlots =
                        (
                            Game.ClientType == GameClientType.Global
                            || Game.ClientType == GameClientType.Korean
                            || Game.ClientType == GameClientType.VTC_Game
                            || Game.ClientType == GameClientType.RuSro
                            || Game.ClientType == GameClientType.Turkey
                            || Game.ClientType == GameClientType.Taiwan
                            || Game.ClientType == GameClientType.Japanese
                        )
                            ? 17
                            : 13; //4 slots for relics

                    lblFreeSlots.Text = (maxSlots - items.Count) + " / " + maxSlots;

                    pbInventoryStatus.Value = (maxSlots - items.Count);
                    pbInventoryStatus.Maximum = maxSlots;

                    break;

                case 2:

                    foreach (var item in Game.Player.Avatars)
                        AddItem(item);

                    lblFreeSlots.Text = Game.Player.Avatars.FreeSlots + " / " + Game.Player.Avatars.Capacity;

                    pbInventoryStatus.Value = Game.Player.Avatars.FreeSlots;
                    pbInventoryStatus.Maximum = Game.Player.Avatars.Capacity;

                    break;

                case 3:

                    if (!Game.Player.HasActiveAbilityPet)
                    {
                        listViewMain.EndUpdate();
                        return;
                    }

                    foreach (var item in Game.Player.AbilityPet.Inventory)
                        AddItem(item);

                    lblFreeSlots.Text =
                        Game.Player.AbilityPet.Inventory.FreeSlots + "/" + Game.Player.AbilityPet.Inventory.Capacity;

                    pbInventoryStatus.Value = Game.Player.AbilityPet.Inventory.FreeSlots;
                    pbInventoryStatus.Maximum = Game.Player.AbilityPet.Inventory.Capacity;

                    break;

                case 4:

                    if (Game.Player.Storage == null)
                    {
                        listViewMain.EndUpdate();
                        return;
                    }

                    foreach (var item in Game.Player.Storage)
                        AddItem(item);

                    lblFreeSlots.Text = Game.Player.Storage.FreeSlots + "/" + Game.Player.Storage.Capacity;

                    pbInventoryStatus.Value = Game.Player.Storage.FreeSlots;
                    pbInventoryStatus.Maximum = Game.Player.Storage.Capacity;

                    break;

                case 5:

                    if (Game.Player.GuildStorage == null)
                    {
                        listViewMain.EndUpdate();
                        return;
                    }

                    foreach (var item in Game.Player.GuildStorage)
                        AddItem(item);

                    lblFreeSlots.Text = Game.Player.GuildStorage.FreeSlots + "/" + Game.Player.GuildStorage.Capacity;

                    pbInventoryStatus.Value = Game.Player.GuildStorage.FreeSlots;
                    pbInventoryStatus.Maximum = Game.Player.GuildStorage.Capacity;

                    break;

                case 6:

                    if (Game.Player.JobTransport == null)
                    {
                        listViewMain.EndUpdate();
                        return;
                    }

                    foreach (var item in Game.Player.JobTransport.Inventory)
                        AddItem(item);

                    lblFreeSlots.Text =
                        Game.Player.JobTransport.Inventory.FreeSlots
                        + "/"
                        + Game.Player.JobTransport.Inventory.Capacity;

                    pbInventoryStatus.Value = Game.Player.JobTransport.Inventory.FreeSlots;
                    pbInventoryStatus.Maximum = Game.Player.JobTransport.Inventory.Capacity;

                    break;

                case 7:

                    if (Game.Player.Job2SpecialtyBag == null)
                    {
                        listViewMain.EndUpdate();
                        return;
                    }

                    foreach (var item in Game.Player.Job2SpecialtyBag)
                        AddItem(item);

                    lblFreeSlots.Text =
                        Game.Player.Job2SpecialtyBag.FreeSlots + "/" + Game.Player.Job2SpecialtyBag.Capacity;

                    pbInventoryStatus.Value = Game.Player.Job2SpecialtyBag.FreeSlots;
                    pbInventoryStatus.Maximum = Game.Player.Job2SpecialtyBag.Capacity;

                    break;

                case 8:

                    if (Game.Player.Job2 == null)
                    {
                        listViewMain.EndUpdate();
                        return;
                    }

                    foreach (var item in Game.Player.Job2)
                        AddItem(item);

                    lblFreeSlots.Text = Game.Player.Job2.FreeSlots + "/" + Game.Player.Job2.Capacity;

                    pbInventoryStatus.Value = Game.Player.Job2.FreeSlots;
                    pbInventoryStatus.Maximum = Game.Player.Job2.Capacity;

                    break;

                case 9:

                    if (!Game.Player.HasActiveFellowPet)
                    {
                        listViewMain.EndUpdate();
                        return;
                    }

                    foreach (var item in Game.Player.Fellow.Inventory)
                        AddItem(item);

                    lblFreeSlots.Text =
                        Game.Player.Fellow.Inventory.FreeSlots + "/" + Game.Player.Fellow.Inventory.Capacity;

                    pbInventoryStatus.Value = Game.Player.Fellow.Inventory.FreeSlots;
                    pbInventoryStatus.Maximum = Game.Player.Fellow.Inventory.Capacity;

                    break;
            }

            listViewMain.EndUpdate();
        }
    }

    /// <summary>
    ///     Adds the item.
    /// </summary>
    /// <param name="item">The item.</param>
    private void AddItem(InventoryItem item)
    {
        if (item == null)
            return;

        var name = item.Record?.GetRealName() ?? "";
        if (item.OptLevel > 0)
            name += " (+" + item.OptLevel + ")";

        var lvItem = listViewMain.Items.Add(item.Slot.ToString(), name, 0);
        lvItem.Tag = item;
        lvItem.SubItems.Add(item.Amount.ToString());

        if (item.Record.IsEquip)
            lvItem.SubItems.Add(item.Record.GetRarityName());

        if (_selectedIndex == 0)
        {
            var useItemsAtTrainingPlace = PlayerConfig.GetArray<string>("RSBot.Inventory.ItemsAtTrainplace");

            if (useItemsAtTrainingPlace.Contains(item.Record.CodeName))
                lvItem.Font = new Font(lvItem.Font, FontStyle.Bold);
        }

        lvItem.LoadItemImageAsync(item.Record);
    }

    /// <summary>
    ///     Handles the visible changed event of the parent.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    private void Main_VisibleChanged(object sender, EventArgs e)
    {
        UpdateInventoryList();
    }

    /// <summary>
    ///     Handles the Click event of the btnReload control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    private void buttonUseItem_Click(object sender, EventArgs e)
    {
        if (listViewMain.SelectedIndices.Count != 1)
            return;

        var listViewItem = listViewMain.SelectedItems[0];
        var inventoryItem = listViewItem.Tag as InventoryItem;
        inventoryItem?.Use();
    }

    /// <summary>
    ///     Handles the mouse double click event of the listviewmain control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    private void listViewMain_MouseDoubleClick(object sender, MouseEventArgs e)
    {
        if (listViewMain.SelectedItems.Count <= 0)
            return;

        if (!Kernel.Debug)
            return;

        var itemForm = new ItemProperties(listViewMain.SelectedItems[0].Tag as InventoryItem);
        itemForm.Show();
    }

    /// <summary>
    ///     Handles the selected index changed event of the button's control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    private void ButtonSwitcher(object sender, EventArgs e)
    {
        var button = sender as Button;
        if (_selectedIndex == button.TabIndex)
            return;

        _selectedIndex = button.TabIndex;

        //Only character inventory, storage and guild storage sorting is supported for now!
        btnSort.Visible = _selectedIndex == 0;
        checkAutoSort.Visible = _selectedIndex is 0 or 4 or 5;

        foreach (var control in topPanel.Controls.OfType<Button>())
        {
            if (control.TabIndex > 9)
                continue;

            control.Color = Color.Transparent;

            if (control == button)
            {
                var backColor = ColorScheme.BorderColor.Determine().Alpha(85);
                control.ForeColor = backColor.Determine();
                control.Color = backColor;
            }

            control.Invalidate();
        }

        UpdateInventoryList();
    }

    private void dropToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (listViewMain.SelectedIndices.Count != 1)
            return;

        var listViewItem = listViewMain.SelectedItems[0];
        var inventoryItem = listViewItem.Tag as InventoryItem;
        if (inventoryItem == null)
            return;

        var cos = _selectedIndex == 3;
        inventoryItem?.Drop(cos, Game.Player.AbilityPet?.UniqueId);
    }

    private void contextMenuStrip_Opening(object sender, CancelEventArgs e)
    {
        if (listViewMain.SelectedIndices.Count != 1)
        {
            e.Cancel = true;
            return;
        }

        var listViewItem = listViewMain.SelectedItems[0];
        if (listViewItem.Tag is not InventoryItem inventoryItem)
            return;

        if (_selectedIndex != 0)
        {
            useToolStripMenuItem.Visible = false;
            moveToLastDeathPositionToolStripMenuItem.Visible = false;
            moveToLastRecallPositionToolStripMenuItem.Visible = false;
            moveToPetToolStripMenuItem.Visible = false;
            moveToPlayerToolStripMenuItem.Visible = _selectedIndex == 3;
            selectMapLocationToolStripMenuItem.Visible = false;
            return;
        }

        var canUse = (inventoryItem.Record.CanUse & ObjectUseType.Yes) != 0;
        if (canUse)
        {
            var useItems = PlayerConfig.GetArray<string>("RSBot.Inventory.ItemsAtTrainplace");
            useItemAtTrainingPlaceMenuItem.Checked = useItems.Contains(inventoryItem.Record.CodeName);
            useItemAtTrainingPlaceMenuItem.Enabled = true;

            var purposiveItems = PlayerConfig.GetArray<string>("RSBot.Inventory.AutoUseAccordingToPurpose");
            autoUseAccordingToPurposeToolStripMenuItem.Checked = purposiveItems.Contains(inventoryItem.Record.CodeName);
            autoUseAccordingToPurposeToolStripMenuItem.Enabled = true;
        }
        else
        {
            useItemAtTrainingPlaceMenuItem.Checked = false;
            useItemAtTrainingPlaceMenuItem.Enabled = false;

            autoUseAccordingToPurposeToolStripMenuItem.Checked = false;
            autoUseAccordingToPurposeToolStripMenuItem.Enabled = false;
        }

        var isReverseScroll = inventoryItem.Equals(new TypeIdFilter(3, 3, 3, 3));
        useToolStripMenuItem.Visible = !isReverseScroll;
        useToolStripMenuItem.Enabled = inventoryItem.Record.CanUse != ObjectUseType.No;
        moveToLastDeathPositionToolStripMenuItem.Visible = isReverseScroll;
        moveToLastRecallPositionToolStripMenuItem.Visible = isReverseScroll;
        selectMapLocationToolStripMenuItem.Visible = isReverseScroll;
        dropToolStripMenuItem.Visible = inventoryItem.Record.CanDrop != ObjectDropType.No;

        moveToPetToolStripMenuItem.Visible = Game.Player.AbilityPet != null && _selectedIndex != 3;
        moveToPlayerToolStripMenuItem.Visible = _selectedIndex == 3;

        if (isReverseScroll)
        {
            var tagItem = selectMapLocationToolStripMenuItem.Tag as InventoryItem;
            if (tagItem != inventoryItem)
            {
                selectMapLocationToolStripMenuItem.Tag = inventoryItem;
                selectMapLocationToolStripMenuItem.DropDownItems.Clear();

                foreach (var item in Game.ReferenceManager.OptionalTeleports)
                {
                    var mapName = Game.ReferenceManager.GetTranslation(item.Value.Region.ToString());

                    var menuItem = new ToolStripMenuItem { Text = mapName };

                    menuItem.Click += (itemSender, itemEvent) =>
                    {
                        inventoryItem.UseTo(7, item.Value.ID);
                    };

                    selectMapLocationToolStripMenuItem.DropDownItems.Add(menuItem);
                }
            }
        }
    }

    private void moveToLastRecallPositionToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (listViewMain.SelectedIndices.Count != 1)
            return;

        var listViewItem = listViewMain.SelectedItems[0];
        var inventoryItem = listViewItem.Tag as InventoryItem;
        if (inventoryItem == null)
            return;

        inventoryItem.UseTo(2);
    }

    private void moveToLastDeathPositionToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (listViewMain.SelectedIndices.Count != 1)
            return;

        var listViewItem = listViewMain.SelectedItems[0];
        var inventoryItem = listViewItem.Tag as InventoryItem;
        if (inventoryItem == null)
            return;

        inventoryItem.UseTo(3);
    }

    private void moveToPetToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (listViewMain.SelectedIndices.Count != 1)
            return;

        var listViewItem = listViewMain.SelectedItems[0];
        var inventoryItem = listViewItem.Tag as InventoryItem;
        if (inventoryItem == null)
            return;

        if (Game.Player.AbilityPet != null)
            return;

        var freeSlot = Game.Player.AbilityPet.Inventory.GetFreeSlot();
        if (freeSlot == 0xFF)
            return;

        var packet = new Packet(0x7034);
        packet.WriteByte(InventoryOperation.SP_MOVE_ITEM_PC_PET);
        packet.WriteUInt(Game.Player.AbilityPet.UniqueId);
        packet.WriteByte(inventoryItem.Slot);
        packet.WriteByte(freeSlot);
        PacketManager.SendPacket(packet, PacketDestination.Server);
    }

    private void moveToPlayerToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (listViewMain.SelectedIndices.Count != 1)
            return;

        var listViewItem = listViewMain.SelectedItems[0];
        var inventoryItem = listViewItem.Tag as InventoryItem;
        if (inventoryItem == null)
            return;

        if (Game.Player.AbilityPet == null)
            return;

        var freeSlot = Game.Player.Inventory.GetFreeSlot();
        if (freeSlot == 0xFF)
            return;

        var packet = new Packet(0x7034);
        packet.WriteByte(InventoryOperation.SP_MOVE_ITEM_PET_PC);
        packet.WriteUInt(Game.Player.AbilityPet.UniqueId);
        packet.WriteByte(inventoryItem.Slot);
        packet.WriteByte(freeSlot);
        PacketManager.SendPacket(packet, PacketDestination.Server);
    }

    private void btnSort_Click(object sender, EventArgs e)
    {
        Task.Run(() => Game.Player?.Inventory?.Sort());
    }

    private void checkAutoSort_CheckedChanged(object sender, EventArgs e)
    {
        PlayerConfig.Set("RSBot.Inventory.AutoSort", checkAutoSort.Checked);
    }

    private void useItemAtTrainingPlaceMenuItem_Click(object sender, EventArgs e)
    {
        if (listViewMain.SelectedItems.Count == 0)
            return;

        var lvItem = listViewMain.SelectedItems[0];
        var itemsToUse = PlayerConfig.GetArray<string>("RSBot.Inventory.ItemsAtTrainplace").ToList();
        var selectedItem = (InventoryItem)lvItem.Tag;
        if (selectedItem == null)
            return;

        var useSelectedItem = itemsToUse.Contains(selectedItem.Record.CodeName);

        if (useSelectedItem)
        {
            lvItem.Font = Font;
            itemsToUse.Remove(selectedItem.Record.CodeName);
        }
        else
        {
            lvItem.Font = new Font(lvItem.Font, FontStyle.Bold);
            itemsToUse.Add(selectedItem.Record.CodeName);
        }

        useItemAtTrainingPlaceMenuItem.Checked = !useItemAtTrainingPlaceMenuItem.Checked;
        PlayerConfig.SetArray("RSBot.Inventory.ItemsAtTrainplace", itemsToUse);
    }

    private void autoUseAccordingToPurposeToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (listViewMain.SelectedItems.Count == 0)
            return;

        var lvItem = listViewMain.SelectedItems[0];

        var itemsToUse = PlayerConfig.GetArray<string>("RSBot.Inventory.AutoUseAccordingToPurpose").ToList();
        var selectedItem = (InventoryItem)lvItem.Tag;
        if (selectedItem == null)
            return;

        var useSelectedItem = itemsToUse.Contains(selectedItem.Record.CodeName);

        if (useSelectedItem)
        {
            lvItem.Font = Font;
            itemsToUse.Remove(selectedItem.Record.CodeName);
        }
        else
        {
            lvItem.Font = new Font(lvItem.Font, FontStyle.Bold);
            itemsToUse.Add(selectedItem.Record.CodeName);
        }

        useItemAtTrainingPlaceMenuItem.Checked = !useItemAtTrainingPlaceMenuItem.Checked;
        PlayerConfig.SetArray("RSBot.Inventory.AutoUseAccordingToPurpose", itemsToUse);
    }

    /// <summary>
    ///     Occurs before Main form is displayed.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Main_Load(object sender, EventArgs e)
    {
        checkAutoSort.Checked = PlayerConfig.Get("RSBot.Inventory.AutoSort", false);
    }
}
