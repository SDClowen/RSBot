using RSBot.Core.Event;
using RSBot.Core.Objects;

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
            if (packet.ReadByte() != 0x01) return;

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
                var hitResult = packet.ReadByte();

                if (Core.Game.SelectedEntity != null && Core.Game.SelectedEntity.Bionic != null)
                {
                    if (entityUniqueId == Core.Game.SelectedEntity.UniqueId && hitResult == 0x80)
                    {
                        Core.Game.SelectedEntity.Bionic.State.LifeState = LifeState.Dead;
                        EventManager.FireEvent("OnKillEnemy");
                        EventManager.FireEvent("OnKillSelectedEnemy");
                    }
                    else if (entityUniqueId != Core.Game.SelectedEntity.UniqueId && hitResult == 0x80)
                        EventManager.FireEvent("OnKillEnemy");
                }
            }
        }
    }
}