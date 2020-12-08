using RSBot.Core.Event;
using RSBot.Core.Objects.Skill;

namespace RSBot.Core.Network.Handler.Agent.Skill
{
    internal class SkillLearnResponse : IPacketHandler
    {
        /// <summary>
        /// Gets or sets the opcode.
        /// </summary>
        /// <value>
        /// The opcode.
        /// </value>
        public ushort Opcode => 0xB0A1;

        /// <summary>
        /// Gets or sets the destination.
        /// </summary>
        /// <value>
        /// The destination.
        /// </value>
        public PacketDestination Destination => PacketDestination.Client;

        /// <summary>
        /// Handles the packet.
        /// </summary>
        /// <param name="packet">The packet.</param>
        public void Invoke(Packet packet)
        {
            var result = packet.ReadByte();

            if (result != 1) return;

            var skillId = packet.ReadUInt();

            var skill = Core.Game.ReferenceManager.GetRefSkill(skillId);
            var existingSkill = Core.Game.Player.Skills.GetSkillRecordByName(skill.GetRealName());

            if (existingSkill == null) //New skill learned
                Core.Game.Player.Skills.KnownSkills.Add(new SkillInfo(skill.ID, true));
            else //Skill leveled up
                Core.Game.Player.Skills.GetSkillInfoById(existingSkill.ID).Id = skill.ID;

            EventManager.FireEvent("OnLearnSkill", Core.Game.Player.Skills.GetSkillInfoById(skill.ID), existingSkill != null);
        }
    }
}