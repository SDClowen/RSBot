using RSBot.Core.Components;
using RSBot.Core.Event;
using RSBot.Core.Objects.Spawn;

namespace RSBot.Core.Network.Handler.Agent.Action
{
    internal class ActionBuffRemoveResponse : IPacketHandler
    {
        #region Properites

        /// <summary>
        /// Gets or sets the opcode.
        /// </summary>
        /// <value>
        /// The opcode.
        /// </value>
        public ushort Opcode => 0xB072;

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
            var buffTokensCount = packet.ReadByte();

            for (var i = 0; i < buffTokensCount; i++)
            {
                var token = packet.ReadUInt();
                if (token == 0)
                    continue;

                if (Game.Player.State.TryRemoveActiveBuff(token, out var buff))
                {
                    Log.Notify($"The buff [{buff.Record?.GetRealName()}] expired");

                    EventManager.FireEvent("OnRemoveBuff", buff);

                    var playerSkill = Game.Player.Skills.GetSkillInfoById(buff.Id);
                    playerSkill?.Reset();

                    return;
                }

                if (!SpawnManager.TryGetEntity<SpawnedBionic>(p => p.State.TryGetActiveBuff(token, out _), out var bionic))
                    return;

                bionic.State.TryRemoveActiveBuff(token, out _);
            }
        }
    }
}