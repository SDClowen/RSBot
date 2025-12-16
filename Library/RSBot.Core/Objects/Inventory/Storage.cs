using RSBot.Core.Network;
using RSBot.Core.Objects.Spawn;
using System.Collections.Generic;
using System.Linq;

namespace RSBot.Core.Objects.Inventory;

public class Storage : InventoryItemCollection
{
    /// <summary>
    ///     Gets a value indicating whether this instance is sorting.
    /// </summary>
    /// <value>
    ///     <c>true</c> if this instance is sorting; otherwise, <c>false</c>.
    /// </value>
    public bool IsSorting { get; private set; }

    /// <summary>
    ///     The gold amount in the storage
    /// </summary>
    public ulong Gold;

    /// <summary>
    ///     Create instance of the <seealso cref="Storage" />
    /// </summary>
    /// <param name="size">The standart 150(5 page)</param>
    public Storage(byte size = 150)
        : base(size) { }

    /// <summary>
    ///     Moves the item inside Character's Inventory.
    /// </summary>
    /// <param name="sourceSlot">The source slot.</param>
    /// <param name="destinationSlot">The destination slot.</param>
    /// <param name="amount">The amount.</param>
    /// <param name="npcId">Id of selected storage NPC.</param>
    /// <returns><c>true</c> if successfully moved; otherwise, <c>false</c>.</returns>
    public bool MoveItem(byte sourceSlot, byte destinationSlot, ushort amount = 0, SpawnedBionic npc = null)
    {
        var itemAtSource = GetItemAt(sourceSlot);
        if (itemAtSource == null)
            return false;

        if (npc.UniqueId == 0)
            return false;

        if (amount == 0)
            amount = itemAtSource.Amount;

        var packet = new Packet(0x7034);
        packet.WriteByte(npc.Record.CodeName.Contains("WAREHOUSE") ? 0x01 : 0x1D); //Move Item Flag (01 - warehouse; 1D - guild)
        packet.WriteByte(sourceSlot);
        packet.WriteByte(destinationSlot);
        packet.WriteUShort(amount);
        packet.WriteUInt(npc.UniqueId);

        var asyncResult = new AwaitCallback(
            response =>
            {
                var result = response.ReadByte();
                if (result == 0x01)
                {
                    var operation = response.ReadByte();
                    if (operation != 0x01 && operation != 0x1D)
                        return AwaitCallbackResult.ConditionFailed;

                    var source = response.ReadByte();
                    var destination = response.ReadByte();
                    var amountMoved = response.ReadUShort();
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

    public void Sort(SpawnedBionic npc)
    {
        if (IsSorting || Game.Player.InAction)
            return;

        IsSorting = true;
        Log.Debug("Sorting the storage...");

        //Use iterations to avoid deadlocks!
        const int maxIterations = 10;
        var iterations = 0;

        //Ignore items which move operations failed in the next iteration
        var blacklistedItems = new List<uint>(4);

        for (var iIteration = 0; iIteration < maxIterations; iIteration++)
        {
            iterations++;

            var itemsToStackGroups = this.Where(i =>
                    //i.Slot > 12 &&
                    i.Record.IsStackable
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

            if (!MoveItem(source.Slot, destination.Slot, (ushort)actualAmount, npc))
                blacklistedItems.Add(source.ItemId);
        }

        IsSorting = false;
        Log.Debug($"Sorting finished after {iterations}/{maxIterations}");
    }
}
