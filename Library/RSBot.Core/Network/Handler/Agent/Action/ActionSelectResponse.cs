using RSBot.Core.Components;
using RSBot.Core.Event;
using RSBot.Core.Objects.Spawn;

namespace RSBot.Core.Network.Handler.Agent.Action
{
    internal class ActionSelectResponse : IPacketHandler
    {
        /// <summary>
        /// Gets or sets the opcode.
        /// </summary>
        /// <value>
        /// The opcode.
        /// </value>
        public ushort Opcode => 0xB045;

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
            if (packet.ReadByte() != 0x01) 
                return;

            var uniqueId = packet.ReadUInt();
            if (!SpawnManager.TryGetEntity<SpawnedBionic>(uniqueId, out var entity))
            {
                Log.Warn("Selected entity could not found in the spawned list!");
                return;
            }

            Game.SelectedEntity = entity;

            if (entity is SpawnedMonster)
            {
                var hasHealth = packet.ReadBool();
                if (hasHealth)
                    entity.Health = packet.ReadInt();
                
                /*if (Game.ClientType >= GameClientType.Global)
                    packet.ReadUInt(); // ??*/

                //entity.Talk.Deserialize(packet);
            }
            else if (entity is SpawnedNpcNpc)
            {
                var hasHealth = packet.ReadBool();
                if (hasHealth)
                    entity.Health = packet.ReadInt();

                //entity.Talk.Deserialize(packet);
                //packet.ReadByte(); // ??
            }
            /*else if (entity is SpawnedPlayer)
            {
                entity.Talk.Deserialize(packet);
            }
            else if (entity is SpawnedPortal)
            {
                entity.Talk.Deserialize(packet);
            }
            */

            EventManager.FireEvent("OnSelectEntity", entity);
        }
    }
}