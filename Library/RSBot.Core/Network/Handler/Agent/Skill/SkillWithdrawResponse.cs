using RSBot.Core.Event;
using RSBot.Core.Objects.Skill;

namespace RSBot.Core.Network.Handler.Agent.Skill;

internal class SkillWithdrawResponse : IPacketHandler
{
    /// <summary>
    ///     Gets or sets the opcode.
    /// </summary>
    /// <value>
    ///     The opcode.
    /// </value>
    public ushort Opcode => 0xB202;

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
        if (packet.ReadByte() != 1)
        {
            Game.Player.Skills.PendingWithdrawSkill = 0;
            return;
        }

        var skillId = packet.ReadUInt(); //the new skill's id

        var oldSkill = Game.Player.Skills.GetSkillInfoById(Game.Player.Skills.PendingWithdrawSkill);
        if (oldSkill == null)
            return;

        var newSkill = new SkillInfo(skillId, true);

        Game.Player.Skills.RemoveSkillById(oldSkill.Id);

        if (skillId != oldSkill.Id)
            Game.Player.Skills.KnownSkills.Add(newSkill);

        Game.Player.Skills.PendingWithdrawSkill = 0;
        EventManager.FireEvent("OnWithdrawSkill", oldSkill, newSkill);
    }
}
