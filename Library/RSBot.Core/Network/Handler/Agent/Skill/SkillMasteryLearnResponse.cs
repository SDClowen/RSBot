using RSBot.Core.Event;

namespace RSBot.Core.Network.Handler.Agent.Skill;

internal class SkillMasteryLearnResponse : IPacketHandler
{
    /// <summary>
    ///     Gets or sets the opcode.
    /// </summary>
    /// <value>
    ///     The opcode.
    /// </value>
    public ushort Opcode => 0xB0A2;

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
        var result = packet.ReadByte();

        if (result != 1)
            return;

        var masteryId = packet.ReadUInt();
        var level = packet.ReadByte();

        Game.Player.Skills.UpdateMasteryLevel(masteryId, level);
        EventManager.FireEvent("OnLearnSkillMastery", Game.Player.Skills.GetMasteryInfoById(masteryId));
    }
}
