using RSBot.Core.Event;

namespace RSBot.Core.Network.Handler.Agent.Inventory;

internal class InventoryUpdateSizeResponse : IPacketHandler
{
    /// <summary>
    ///     Gets or sets the opcode.
    /// </summary>
    /// <value>
    ///     The opcode.
    /// </value>
    public ushort Opcode => 0x3092;

    /// <summary>
    ///     Gets or sets the destination.
    /// </summary>
    /// <value>
    ///     The destination.
    /// </value>
    public PacketDestination Destination => PacketDestination.Client;

    /// <summary>
    ///     Handles the packet.
    /// </summary>
    /// <param name="packet">The packet.</param>
    public void Invoke(Packet packet)
    {
        var type = packet.ReadByte();
        var size = packet.ReadByte();

        switch (type)
        {
            case 1:
                Game.Player.Inventory.Capacity = size;
                Log.Debug($"Inventory size has been updated to [{size}] slots");
                EventManager.FireEvent("OnUpdateInventorySize");
                break;

            case 2:
                if (Game.Player.Storage != null)
                    Game.Player.Storage.Capacity = size;
                Log.Debug($"Storage size has been updated to [{size}] slots");
                EventManager.FireEvent("OnUpdateStorageSize");
                break;

            default:
                Log.Debug($"InventorySizeUpdateResponse: Unknown update type [{type}] ({size})");
                break;
        }
    }
}
