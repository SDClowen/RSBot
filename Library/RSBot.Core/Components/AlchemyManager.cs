using System.Collections.Generic;
using System.Timers;
using RSBot.Core.Client.ReferenceObjects;
using RSBot.Core.Network;
using RSBot.Core.Network.Handler.Agent.Alchemy;
using RSBot.Core.Objects;

namespace RSBot.Core.Components;

/// <summary>
///     @ToDo: Currently completely unsupported operations are:
///     * Socket alchemy
///     * Dismantle/Disjoint
///     * Manufacture
/// </summary>
public class AlchemyManager
{
    #region Members

    private static Timer _fusingTimer;

    #endregion Members

    #region Properties

    /// <summary>
    ///     Gets or sets a list of inventory items currently used in an alchemy operation.
    ///     Attention! This object is only set during alchemy operations and will be set to NULL if any ACK response has been
    ///     received!
    /// </summary>
    public static List<InventoryItem>? ActiveAlchemyItems { get; internal set; }

    /// <summary>
    ///     Gets a value indicating whether this instance is fusing.
    /// </summary>
    /// <value>
    ///     <c>true</c> if this instance is fusing; otherwise, <c>false</c>.
    /// </value>
    public static bool IsFusing { get; internal set; }

    #endregion Properties

    #region Methods

    /// <summary>
    ///     Cancels the pending alchemy operation.
    /// </summary>
    public static void CancelPending()
    {
        var packet = new Packet(0x7150);
        packet.WriteByte(0x01);

        packet.Lock();
        Kernel.Proxy.Server.Send(packet);
    }

    /// <summary>
    ///     Fuses the elixir with the specified item using the given lucky powder ingredient.
    /// </summary>
    /// <param name="item">The item.</param>
    /// <param name="elixir">The elixir.</param>
    /// <param name="powder">The powder.</param>
    public static bool TryFuseElixir(InventoryItem item, InventoryItem elixir, InventoryItem? powder)
    {
        var itemInInventory = Game.Player.Inventory.GetItemAt(item.Slot);
        var elixirInInventory = Game.Player.Inventory.GetItemAt(elixir.Slot);
        var powderInInventory = Game.Player.Inventory.GetItemAt(powder.Slot);
        var isProofItem =
            powderInInventory != null ? new TypeIdFilter(3, 3, 10, 8).EqualsRefItem(powderInInventory!.Record) : false;
        var alchemyType = isProofItem ? AlchemyType.EnhancerElixir : AlchemyType.Elixir;

        if (
            itemInInventory?.ItemId != item.ItemId
            || elixirInInventory?.ItemId != elixir.ItemId
            || (powderInInventory != null && powderInInventory.ItemId != powder.ItemId)
        )
        {
            Log.Warn("[Alchemy] Requested to fuse an item that does not match the current item at the specified slot.");

            return false;
        }

        Log.Notify(
            powder == null
                ? $"[Alchemy] Fusing elixir {elixir.Record.GetRealName()} to {item.Record.GetRealName()}"
                : $"[Alchemy] Fusing elixir {elixir.Record.GetRealName()} to {item.Record.GetRealName()} using powder {powder.Record.GetRealName()}"
        );

        var packet = new Packet(0x7150);
        packet.WriteByte(AlchemyAction.Fuse); //fuse
        packet.WriteByte(alchemyType); // type
        packet.WriteByte(powder != null ? (byte)3 : (byte)2); //Slot count
        packet.WriteByte(item.Slot);
        packet.WriteByte(elixir.Slot);

        if (powder != null)
            packet.WriteByte(powder.Slot);

        packet.Lock();

        Kernel.Proxy.Server.Send(packet);

        GenericAlchemyRequestHandler.Invoke(packet);

        return true;
    }

    /// <summary>
    ///     Fuses the magic stone with the specified item.
    /// </summary>
    /// <param name="item">The item.</param>
    /// <param name="magicStone">The elixir.</param>
    public static bool TryFuseMagicStone(InventoryItem item, InventoryItem magicStone)
    {
        var itemInInventory = Game.Player.Inventory.GetItemAt(item.Slot);
        var stoneInInventory = Game.Player.Inventory.GetItemAt(magicStone.Slot);

        if (itemInInventory?.ItemId != item.ItemId || stoneInInventory?.ItemId != magicStone.ItemId)
        {
            Log.Debug(
                "[Alchemy] Requested to fuse an item that does not match the current item at the specified slot."
            );

            return false;
        }

        Log.Notify(
            $"[Alchemy] Fusing magic stone {magicStone.Record.GetRealName()} to item {item.Record.GetRealName()}"
        );

        var packet = new Packet(0x7151);

        packet.WriteByte(AlchemyAction.Fuse); //Fuse
        packet.WriteByte(AlchemyType.MagicStone); //MagicStone
        packet.WriteByte(2); //Slot count

        packet.WriteByte(item.Slot);
        packet.WriteByte(magicStone.Slot);

        packet.Lock();

        Kernel.Proxy.Server.Send(packet);

        GenericAlchemyRequestHandler.Invoke(packet);

        return true;
    }

    /// <summary>
    ///     Fuses the attribute stone with the specified item.
    /// </summary>
    /// <param name="item">The item.</param>
    /// <param name="attributeStone">The attribute stone.</param>
    public static bool TryFuseAttributeStone(InventoryItem item, InventoryItem attributeStone)
    {
        var itemInInventory = Game.Player.Inventory.GetItemAt(item.Slot);
        var stoneInInventory = Game.Player.Inventory.GetItemAt(attributeStone.Slot);

        if (itemInInventory?.ItemId != item.ItemId || stoneInInventory?.ItemId != attributeStone.ItemId)
        {
            Log.Warn("[Alchemy] Requested to fuse an item that does not match the current item at the specified slot.");

            return false;
        }

        Log.Notify(
            $"[Alchemy] Fusing attribute stone {attributeStone.Record.GetRealName()} to item {item.Record.GetRealName()}"
        );

        var packet = new Packet(0x7151);

        packet.WriteByte(AlchemyAction.Fuse); //Fuse
        packet.WriteByte(AlchemyType.AttributeStone); //MagicStone
        packet.WriteByte(2); //Slot count

        packet.WriteByte(item.Slot);
        packet.WriteByte(attributeStone.Slot);

        packet.Lock();
        Kernel.Proxy.Server.Send(packet);

        GenericAlchemyRequestHandler.Invoke(packet);

        return true;
    }

    /// <summary>
    ///     Starts the alchemy timer.
    /// </summary>
    internal static void StartTimer()
    {
        IsFusing = true;

        //An alchemy operation should not take longer than 10s
        _fusingTimer = new Timer(10_000) { AutoReset = false, Enabled = false };

        _fusingTimer.Elapsed += FusingActionFusingTimerElapsed;
        _fusingTimer.Start();
    }

    /// <summary>
    ///     Stops the alchemy timer.
    /// </summary>
    internal static void StopTimer()
    {
        IsFusing = false;

        _fusingTimer?.Dispose();
        _fusingTimer = null;
    }

    /// <summary>
    ///     Triggered when the alchemy timer elapses. Stops the timer.
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The <see cref="ElapsedEventArgs" /> instance containing the event data.</param>
    private static void FusingActionFusingTimerElapsed(object? sender, ElapsedEventArgs e)
    {
        StopTimer();
    }

    #endregion Methods
}
