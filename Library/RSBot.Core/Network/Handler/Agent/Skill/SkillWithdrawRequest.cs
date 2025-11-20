using RSBot.Core.Event;

namespace RSBot.Core.Network.Handler.Agent.Skill;

internal class SkillWithdrawRequest : IPacketHandler
{
    /// <summary>
    ///     Gets or sets the opcode.
    /// </summary>
    /// <value>
    ///     The opcode.
    /// </value>
    public ushort Opcode => 0x7202;

    /// <summary>
    ///     Gets or sets the destination.
    /// </summary>
    /// <value>
    ///     The destination.
    /// </value>
    public PacketDestination Destination => PacketDestination.Server;

    /// <summary>
    ///     Handles the packet.
    /// </summary>
    /// <param name="packet">The packet.</param>
    public void Invoke(Packet packet)
    {
        packet.ReadUInt(); //withdrawingItemId
        var skillId = packet.ReadUInt();
        var level = packet.ReadByte();

        Game.Player.Skills.PendingWithdrawSkill = skillId;
        EventManager.FireEvent("OnWithdrawSkillRequest", skillId, level);
    }
}
