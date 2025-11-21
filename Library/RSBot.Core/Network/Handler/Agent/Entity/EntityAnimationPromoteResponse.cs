using RSBot.Core.Event;

namespace RSBot.Core.Network.Handler.Agent.Entity;

internal class EntityAnimationPromoteResponse : IPacketHandler
{
    /// <summary>
    ///     Gets or sets the opcode.
    /// </summary>
    /// <value>
    ///     The opcode.
    /// </value>
    public ushort Opcode => 0x3054;

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
        var uniqueId = packet.ReadUInt();

        if (Game.Player.HasActiveAttackPet && uniqueId == Game.Player.Growth.UniqueId)
            EventManager.FireEvent("OnGrowthLevelUp");
        else if (Game.Player.HasActiveFellowPet && uniqueId == Game.Player.Fellow.UniqueId)
            EventManager.FireEvent("OnFellowLevelUp");
    }
}
