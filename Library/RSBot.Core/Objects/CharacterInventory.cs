using System;
using System.Collections.Generic;
using System.Linq;
using RSBot.Core.Network;

namespace RSBot.Core.Objects;

/// <summary>
///     The Character's Invetory with EquippedPart and NormalPart.
/// </summary>
public class CharacterInventory : InventoryItemCollection
{
    /// <summary>
    ///     Minimum slot of NormalPart.
    /// </summary>
    public static byte NORMAL_PART_MIN_SLOT
    {
        get
        {
            return (
                Game.ClientType == GameClientType.Global
                || Game.ClientType == GameClientType.Korean
                || Game.ClientType == GameClientType.VTC_Game
                || Game.ClientType == GameClientType.RuSro
                || Game.ClientType == GameClientType.Turkey
                || Game.ClientType == GameClientType.Taiwan
                || Game.ClientType == GameClientType.Japanese
            )
                ? (byte)17 //4 slots for relics
                : (byte)13;
        }
    }

    /// <summary>
    ///     The constructor.
    /// </summary>
    /// <param name="size">The size.</param>
    public CharacterInventory(Packet packet)
        : base(packet) { }

    /// <summary>
    ///     Gets the size of NormalPart.
    /// </summary>
    public byte NormalPartSize => (byte)(Capacity - NORMAL_PART_MIN_SLOT);

    /// <summary>
    ///     Gets a value indicating whether the NormalPart is full.
    /// </summary>
    /// <value>
    ///     <c>true</c> if the NormalPart is full; otherwise, <c>false</c>.
    /// </value>
    public override bool Full => GetNormalPartItems().Count >= NormalPartSize;

    /// <summary>
    ///     Gets a value indicating whether this instance is sorting.
    /// </summary>
    /// <value>
    ///     <c>true</c> if this instance is sorting; otherwise, <c>false</c>.
    /// </value>
    public bool IsSorting { get; private set; }

    /// <summary>
    ///     Gets the number of free slots in NormalPart inventory.
    /// </summary>
    public new byte FreeSlots => (byte)(NormalPartSize - GetNormalPartItems().Count);

    /// <summary>
    ///     Gets the first free slot number inside NormalPart.
    /// </summary>
    /// <returns>if found: the first free slot number; otherwise: 0</returns>
    public override byte GetFreeSlot()
    {
        for (var slot = NORMAL_PART_MIN_SLOT; slot < Capacity; slot++)
            if (GetItemAt(slot) == null)
                return slot;

        return 0;
    }

    /// <summary>
    ///     Gets items of EquippedPart, ordered by slot.
    /// </summary>
    /// <returns>If found: list of item(s), ordered by slot; otherwise empty list</returns>
    public ICollection<InventoryItem> GetEquippedPartItems()
    {
        return GetItems(item => item.Slot < NORMAL_PART_MIN_SLOT);
    }

    /// <summary>
    ///     Gets items of NormalPart, ordered by slot.
    /// </summary>
    /// <returns>If found: list of item(s), ordered by slot; otherwise empty list</returns>
    public ICollection<InventoryItem> GetNormalPartItems()
    {
        return GetItems(item => item.Slot >= NORMAL_PART_MIN_SLOT);
    }

    /// <summary>
    ///     Gets items of NormalPart, ordered by slot.
    /// </summary>
    /// <returns>If found: list of item(s), ordered by slot; otherwise empty list</returns>
    public ICollection<InventoryItem> GetNormalPartItems(Predicate<InventoryItem> predicate)
    {
        return GetItems(item => item.Slot >= NORMAL_PART_MIN_SLOT && predicate(item));
    }

    /// <summary>
    ///     Gets items of NormalPart by ItemId, ordered by slot.
    /// </summary>
    /// <param name="itemId">The identifier of item.</param>
    /// <returns>If found: list of item(s), ordered by slot; otherwise empty list</returns>
    public ICollection<InventoryItem> GetNormalPartItems(uint itemId)
    {
        return GetItems(item => item.Slot >= NORMAL_PART_MIN_SLOT && item.ItemId == itemId);
    }

    /// <summary>
    ///     Moves the item inside Character's Inventory.
    /// </summary>
    /// <param name="sourceSlot">The source slot.</param>
    /// <param name="destinationSlot">The destination slot.</param>
    /// <param name="amount">The amount.</param>
    /// <returns><c>true</c> if successfully moved; otherwise, <c>false</c>.</returns>
    public bool MoveItem(byte sourceSlot, byte destinationSlot, ushort amount = 0)
    {
        var itemAtSource = GetItemAt(sourceSlot);
        if (itemAtSource == null)
            return false;

        if (amount == 0)
            amount = itemAtSource.Amount;

        var packet = new Packet(0x7034);
        packet.WriteByte(0); //kinda flag
        packet.WriteByte(sourceSlot);
        packet.WriteByte(destinationSlot);
        packet.WriteUShort(amount);

        var asyncResult = new AwaitCallback(
            response =>
            {
                var result = response.ReadByte();
                if (result == 0x01)
                {
                    var operation = response.ReadByte();
                    if (operation != 0)
                        return AwaitCallbackResult.ConditionFailed;

                    var source = response.ReadByte();
                    var destination = response.ReadByte();
                    if (source == sourceSlot && destination == destinationSlot)
                        return AwaitCallbackResult.Success;
                }

                return AwaitCallbackResult.Fail;
            },
            0xB034
        );

        PacketManager.SendPacket(packet, PacketDestination.Server, asyncResult);
        asyncResult.AwaitResponse(500);

        return asyncResult.IsCompleted;
    }

    public void Sort()
    {
        if (IsSorting || Game.Player.InAction)
            return;

        IsSorting = true;
        Log.Debug("Sorting the character inventory...");

        //Use iterations to avoid deadlocks!
        const int maxIterations = 10;
        var iterations = 0;

        //Ignore items which move operations failed in the next iteration
        var blacklistedItems = new List<uint>(4);

        int firstSlot = 13;
        if (Game.ClientType == GameClientType.Global
            || Game.ClientType == GameClientType.Korean
            || Game.ClientType == GameClientType.VTC_Game
            || Game.ClientType == GameClientType.RuSro
            || Game.ClientType == GameClientType.Turkey
            || Game.ClientType == GameClientType.Taiwan
            || Game.ClientType == GameClientType.Japanese)
            firstSlot = 17; //4 slots for relics

        for (var iIteration = 0; iIteration < maxIterations; iIteration++)
        {
            iterations++;

            var itemsToStackGroups = this.Where(i =>
                    i.Slot >= firstSlot
                    && i.Record.IsStackable
                    && i.Record.MaxStack > i.Amount
                    && !blacklistedItems.Contains(i.ItemId)
                )
                .GroupBy(i => i.ItemId);

            if (!itemsToStackGroups.Any())
                break;

            var itemsToStack = itemsToStackGroups.FirstOrDefault(g => g.Count() >= 2)?.OrderBy(i => i.Slot).ToList();

            if (itemsToStack == null)
                break;

            var source = itemsToStack.FirstOrDefault();
            if (source == null)
                continue;

            var destination = itemsToStack.FirstOrDefault(i => i.Record.ID == source.ItemId && i.Slot != source.Slot);
            if (destination == null)
                continue;

            var amount = destination.Record.MaxStack - destination.Amount;
            var actualAmount = source.Amount > amount ? amount : source.Amount;

            if (!MoveItem(source.Slot, destination.Slot, (ushort)actualAmount))
                blacklistedItems.Add(source.ItemId);
        }

        IsSorting = false;
        Log.Debug($"Sorting finished after {iterations}/{maxIterations}");
    }
}
