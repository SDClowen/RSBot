using RSBot.Core.Event;
using RSBot.Core.Objects.Skill;

namespace RSBot.Core.Network.Handler.Agent.Skill
{
    internal class SkillWithdrawResponse : IPacketHandler
    {
        /// <summary>
        /// Gets or sets the opcode.
        /// </summary>
        /// <value>
        /// The opcode.
        /// </value>
        public ushort Opcode => 0xB202;

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
            if (packet.ReadByte() != 1)
            {
                Core.Game.Player.Skills.PendingWithdrawSkill = 0;
                return;
            }

            var skillId = packet.ReadUInt(); //the new skill's id

            var oldSkill = Core.Game.Player.Skills.GetSkillInfoById(Core.Game.Player.Skills.PendingWithdrawSkill);

            if (oldSkill == null) return; //Should not happen! (Player unlearned an unknown skill!)

            Core.Game.Player.Skills.RemoveSkillById(oldSkill.Id);

            if (skillId != oldSkill.Id)
                Core.Game.Player.Skills.KnownSkills.Add(new SkillInfo(skillId, true));

            Core.Game.Player.Skills.PendingWithdrawSkill = 0;
            EventManager.FireEvent("OnWithdrawSkill", oldSkill);
        }
    }
}