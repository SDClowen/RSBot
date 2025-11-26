using RSBot.Core.Event;

namespace RSBot.Core.Network.Handler.Agent.Inventory;

internal class InventoryItemRepairRequest : IPacketHandler
{
    #region Methods

    /// <summary>
    ///     Handles the packet.
    /// </summary>
    /// <param name="packet">The packet.</param>
    public void Invoke(Packet packet)
    {
        var entityId = packet.ReadUInt();
        var repairType = packet.ReadByte();
        byte slot = 0;

        if (repairType == 1)
        {
            slot = packet.ReadByte();

            Log.Notify($"Repairing item {Game.Player.Inventory.GetItemAt(slot).Record.GetRealName()}");
        }
        else
        {
            Log.Notify("Repairing all items...");
        }

        EventManager.FireEvent("OnNpcRepairRequest", entityId, repairType, slot);
    }

    #endregion Methods

    #region Properties

    /// <summary>
    ///     Gets or sets the opcode.
    /// </summary>
    /// <value>
    ///     The opcode.
    /// </value>
    public ushort Opcode => 0x703E;

    /// <summary>
    ///     Gets or sets the destination.
    /// </summary>
    /// <value>
    ///     The destination.
    /// </value>
    public PacketDestination Destination => PacketDestination.Server;

    #endregion Properties
}
