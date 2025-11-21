using RSBot.Core.Components;
using RSBot.Core.Event;
using RSBot.Core.Objects.Spawn;

namespace RSBot.Core.Network.Handler.Agent.Entity;

internal class EntityRemoveOwnershipResponse : IPacketHandler
{
    /// <summary>
    ///     Invokes the specified packet.
    /// </summary>
    /// <param name="packet">The packet.</param>
    public void Invoke(Packet packet)
    {
        var itemUniqueId = packet.ReadUInt();
        if (!SpawnManager.TryGetEntity<SpawnedItem>(itemUniqueId, out var entity))
            return;

        entity.HasOwner = false;
        //entity.OwnerJID = 0;

        EventManager.FireEvent("OnRemoveItemOwnership", itemUniqueId);
    }

    #region Properites

    /// <summary>
    ///     Gets or sets the opcode.
    /// </summary>
    /// <value>
    ///     The opcode.
    /// </value>
    public ushort Opcode => 0x304D;

    /// <summary>
    ///     Gets or sets the destination.
    /// </summary>
    /// <value>
    ///     The destination.
    /// </value>
    public PacketDestination Destination => PacketDestination.Client;

    #endregion Properites
}
