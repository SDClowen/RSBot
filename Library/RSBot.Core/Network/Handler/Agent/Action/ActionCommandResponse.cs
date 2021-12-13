using RSBot.Core.Components;
using RSBot.Core.Objects;
using RSBot.Core.Objects.Spawn;

namespace RSBot.Core.Network.Handler.Agent.Action
{
    internal class ActionCommandResponse : IPacketHandler
    {
        #region Properites

        /// <summary>
        /// Gets or sets the opcode.
        /// </summary>
        /// <value>
        /// The opcode.
        /// </value>
        public ushort Opcode => 0xB071;

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
            if (packet.ReadByte() != 0x01) 
                return;

            packet.ReadUInt(); //ActionId
            packet.ReadUInt(); //originalTargetId

            var actionFlag = packet.ReadByte();

            if (actionFlag != 0x01)
                return;

            packet.ReadByte(); //Unknown, always 1
            var hitCounter = packet.ReadByte(); //The number of targets that were hit

            for (var i = 0; i < hitCounter; i++)
            {
                var entityUniqueId = packet.ReadUInt();
                var state = (ActionHitStateFlag)packet.ReadByte();

                if (!SpawnManager.TryGetEntity<SpawnedBionic>(entityUniqueId, out var entity))
                    continue;

                entity.State.HitState = state;

                /*
                  GS sending life state update after entity dead. I think dont need, but i didn't delete the commented codeblock maybe we need later
                  if(Core.Game.SelectedEntity != null && 
                   entityUniqueId == Core.Game.SelectedEntity.UniqueId &&
                   (state & ActionHitStateFlag.ATTACK_STATE_DEAD) > 0)
                    EventManager.FireEvent("OnKillSelectedEnemy");*/
            }
        }
    }
}