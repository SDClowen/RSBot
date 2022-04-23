using RSBot.Core.Client.ReferenceObjects;

namespace RSBot.Core.Network.Handler.Agent.Alchemy
{
    internal class StoneAckResponseHandler : IPacketHandler
    {
        #region Properties

        public ushort Opcode => 0xB151;

        public PacketDestination Destination => PacketDestination.Client;

        #endregion Properties

        #region Methods

        public void Invoke(Packet packet)
        {
            GenericAlchemyAckResponse.Invoke(packet, AlchemyType.MagicStone);
        }

        #endregion Methods
    }
}