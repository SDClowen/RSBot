namespace RSBot.Core.Network.Handler.Agent.Alchemy;

internal class ElixirFuseRequestHandler : IPacketHandler
{
    public ushort Opcode => 0x7150;

    public PacketDestination Destination => PacketDestination.Server;

    public void Invoke(Packet packet)
    {
        GenericAlchemyRequestHandler.Invoke(packet);
    }
}
