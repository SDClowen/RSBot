namespace RSBot.Core.Network.Handler.Agent.Alchemy;

internal class StoneFuseRequestHandler : IPacketHandler
{
    public ushort Opcode => 0x7151;

    public PacketDestination Destination => PacketDestination.Server;

    public void Invoke(Packet packet)
    {
        GenericAlchemyRequestHandler.Invoke(packet);
    }
}
