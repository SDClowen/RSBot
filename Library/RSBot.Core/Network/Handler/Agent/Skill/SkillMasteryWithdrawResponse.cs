using RSBot.Core.Event;

namespace RSBot.Core.Network.Handler.Agent.Skill;

internal class SkillMasteryWithdrawResponse : IPacketHandler
{
    /// <summary>
    ///     Gets or sets the opcode.
    /// </summary>
    /// <value>
    ///     The opcode.
    /// </value>
    public ushort Opcode => 0xB203;

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
        if (packet.ReadByte() != 0x01)
            return;

        var masteryId = packet.ReadUInt();
        var level = packet.ReadByte();

        Game.Player.Skills.UpdateMasteryLevel(masteryId, level);
        Log.Notify(
            $"The mastery [{Game.Player.Skills.GetMasteryInfoById(masteryId).Record.Name}] was withdrawn to [lv.{level}]"
        );
        EventManager.FireEvent("OnWithdrawMastery", masteryId, level);
    }
}
