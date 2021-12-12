using RSBot.Core.Event;
using RSBot.Core.Objects.Skill;

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

            var buffInfo = new BuffInfo
            {
                Id = skillId,
                Token = token
            };

            if(targetId == Core.Game.Player.UniqueId)
            {
                Core.Game.Player.Buffs.Add(buffInfo);
                EventManager.FireEvent("OnAddBuff", buffInfo);
                Log.Notify($"Buff [{buffInfo.Record.GetRealName()}] added.");

                return;
            }

            var bionic = Core.Game.Spawns.GetBionic(targetId);
            if(bionic != null)
                bionic.State.ActiveBuffs.Add(buffInfo);
        }
    }
}