using RSBot.Core.Client.ReferenceObjects;

namespace RSBot.Core.Network.Handler.Agent.Alchemy;

internal class ElixirAckResponseHandler : IPacketHandler
{
    public void Invoke(Packet packet)
    {
        GenericAlchemyAckResponse.Invoke(packet, AlchemyType.Elixir);
    }

    #region Properties

    public ushort Opcode => 0xB150;

    public PacketDestination Destination => PacketDestination.Client;

    #endregion Properties
}
