using RSBot.Core.Components;
using RSBot.Core.Event;

namespace RSBot.Core.Network.Handler.Agent.Action;

internal class ActionItemPerkRemoveResponse : IPacketHandler
{
    /// <summary>
    ///     Invokes the specified packet.
    /// </summary>
    /// <param name="packet">The packet.</param>
    public void Invoke(Packet packet)
    {
        var targetId = packet.ReadUInt();
        packet.ReadUInt(); //refObjItem.Id
        var token = packet.ReadUInt();

        if (!SpawnManager.TryGetEntityIncludingMe(targetId, out var target))
            return;

        var perk = target.State.ActiveItemPerks[token];
        target.State.ActiveItemPerks.Remove(token);

        EventManager.FireEvent("OnRemoveItemPerk", targetId, perk);
    }

    #region Properites

    /// <summary>
    ///     Gets or sets the opcode.
    /// </summary>
    /// <value>
    ///     The opcode.
    /// </value>
    public ushort Opcode => 0x3261;

    /// <summary>
    ///     Gets or sets the destination.
    /// </summary>
    /// <value>
    ///     The destination.
    /// </value>
    public PacketDestination Destination => PacketDestination.Client;

    #endregion Properites
}
