using RSBot.Core.Event;
using RSBot.Core.Objects;
using RSBot.Core.Objects.Spawn;

namespace RSBot.Core.Network.Handler.Agent.Action
{
    internal class ActionSkillCastResponse : IPacketHandler
    {
        /// <summary>
        /// Gets or sets the destination.
        /// </summary>
        /// <value>
        /// The destination.
        /// </value>
        public PacketDestination Destination => PacketDestination.Client;

        /// <summary>
        /// Gets or sets the opcode.
        /// </summary>
        /// <value>
        /// The opcode.
        /// </value>
        public ushort Opcode => 0xB070;

        public void Invoke(Packet packet)
        {
            var result = packet.ReadByte();

            if (result != 0x01) return;

            if (Core.Game.ClientType > GameClientType.Thailand)
                packet.ReadUShort(); //Error .. always 00 30

            var action = Objects.Action.DeserializeBegin(packet);

            if (action.PlayerIsExecutor)
            {
                Core.Game.Player.Tracker.StopMoving();

                var skill = Core.Game.Player.Skills.GetSkillInfoById(action.SkillId);
                skill?.Update();

                EventManager.FireEvent("OnCastSkill", action.SkillId);

                return;
            }

            var executor = action.GetExecutor<SpawnedBionic>();
            if (executor == null)
                return;

            executor.Tracker?.StopMoving();

            if (!action.PlayerIsTarget)
                return;

            EventManager.FireEvent("OnEnemySkillOnPlayer");

            executor.StartAttackingTimer();
        }
    }
}