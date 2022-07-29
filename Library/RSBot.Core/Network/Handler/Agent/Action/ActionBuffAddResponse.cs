using RSBot.Core.Components;
using RSBot.Core.Event;
using RSBot.Core.Objects.Skill;
using RSBot.Core.Objects.Spawn;

namespace RSBot.Core.Network.Handler.Agent.Action
{
    internal class ActionBuffAddResponse : IPacketHandler
    {
        #region Properites

        /// <summary>
        /// Gets or sets the opcode.
        /// </summary>
        /// <value>
        /// The opcode.
        /// </value>
        public ushort Opcode => 0xB0BD;

        /// <summary>
        /// Gets or sets the destination.
        /// </summary>
        /// <value>
        /// The destination.
        /// </value>
        public PacketDestination Destination => PacketDestination.Client;

        #endregion Properites

        /// <summary>
        /// Invokes the specified packet.
        /// </summary>
        /// <param name="packet">The packet.</param>
        public void Invoke(Packet packet)
        {
            var targetId = packet.ReadUInt();
            var skillId = packet.ReadUInt();
            var token = packet.ReadUInt(); 
            if (token == 0)
                return;


            var buffInfo = new SkillInfo(skillId, token);
            if (targetId == Game.Player.UniqueId)
            {
                Game.Player.State.ActiveBuffs.Add(buffInfo);
                EventManager.FireEvent("OnAddBuff", buffInfo);

                Log.Notify($"Buff [{buffInfo.Record.GetRealName()}] added.");

                return;
            }

            if (SpawnManager.TryGetEntity<SpawnedBionic>(targetId, out var entity))
                entity.State.ActiveBuffs.Add(buffInfo);
        }
    }
}