using RSBot.Core.Event;
using RSBot.Core.Objects.Skill;

namespace RSBot.Core.Network.Handler.Agent.Skill;

internal class SkillLearnResponse : IPacketHandler
{
    /// <summary>
    ///     Gets or sets the opcode.
    /// </summary>
    /// <value>
    ///     The opcode.
    /// </value>
    public ushort Opcode => 0xB0A1;

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

        var skillId = packet.ReadUInt();
        var skill = Game.ReferenceManager.GetRefSkill(skillId);

        var existingSkill = Game.Player.Skills.GetSkillRecordByName(skill.GetRealName());
        if (existingSkill == null)
        {
            var skillInfo = new SkillInfo(skillId, true);

            Game.Player.Skills.KnownSkills.Add(skillInfo);
            EventManager.FireEvent("OnSkillLearned", skillInfo);
        }
        else
        {
            var oldSkill = new SkillInfo(existingSkill.Id, false);
            existingSkill.Id = skillId;
            EventManager.FireEvent("OnSkillUpgraded", oldSkill, existingSkill);
        }
    }
}
