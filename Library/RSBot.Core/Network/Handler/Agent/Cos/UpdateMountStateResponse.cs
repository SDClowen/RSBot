using RSBot.Core.Components;
using RSBot.Core.Event;
using RSBot.Core.Objects.Spawn;

namespace RSBot.Core.Network.Handler.Agent.Cos
{
    internal class UpdateMountStateResponse : IPacketHandler
    {
        #region Properties

        /// <summary>
        /// Gets or sets the opcode.
        /// </summary>
        /// <value>
        /// The opcode.
        /// </value>
        public ushort Opcode => 0xB0CB;

        /// <summary>
        /// Gets or sets the destination.
        /// </summary>
        /// <value>
        /// The destination.
        /// </value>
        public PacketDestination Destination => PacketDestination.Client;

        #endregion Properties

        #region Methods

        public void Invoke(Packet packet)
        {
            if (packet.ReadByte() != 0x01)
                return;

            var ownerUId = packet.ReadUInt();
            var isMounted = packet.ReadBool();
            var cosUid = packet.ReadUInt();

            //Assertion: only player's are supported to have active vehicles. Think it's the same in the client.
            var owner = SpawnManager.GetEntity<SpawnedPlayer>(e => e.UniqueId == ownerUId);
            if (owner == null)
                return;

            var cos = SpawnManager.GetEntity<SpawnedCos>(e => e.UniqueId == cosUid);
            if (cos == null)
                return;

            owner.OnTransport = isMounted;
            owner.TransportUniqueId = cosUid;

            EventManager.FireEvent("OnEntityMountTransport", owner, cos, isMounted);
        }

        #endregion Methods
    }
}