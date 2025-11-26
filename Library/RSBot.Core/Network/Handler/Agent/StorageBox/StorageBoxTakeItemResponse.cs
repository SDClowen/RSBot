using RSBot.Core.Event;
using RSBot.Core.Objects;

namespace RSBot.Core.Network.Handler.Agent.StorageBox;

public class StorageBoxTakeItemResponse : IPacketHandler
{
    /// <summary>
    ///     <inheritdoc />
    /// </summary>
    public ushort Opcode => 0xB558;

    /// <summary>
    ///     <inheritdoc />
    /// </summary>
    public PacketDestination Destination => PacketDestination.Client;

    /// <summary>
    ///     <inheritdoc />
    /// </summary>
    /// <param name="packet"></param>
    public void Invoke(Packet packet)
    {
        var result = packet.ReadBool();
        if (!result)
            return;

        var count = packet.ReadInt();
        for (var i = 0; i < count; i++)
        {
            var item = InventoryItem.FromPacket(packet);
            if (item == null)
                continue;

            Game.Player.Inventory.Add(item);
        }

        EventManager.FireEvent("OnInventoryUpdate");
    }
}
