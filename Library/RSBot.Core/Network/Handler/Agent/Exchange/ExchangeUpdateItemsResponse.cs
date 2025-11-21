using RSBot.Core.Event;

namespace RSBot.Core.Network.Handler.Agent.Exchange;

internal class ExchangeUpdateItemsResponse : IPacketHandler
{
    /// <inheritdoc />
    public ushort Opcode => 0x308C;

    /// <inheritdoc />
    public PacketDestination Destination => PacketDestination.Client;

    /// <inheritdoc />
    public void Invoke(Packet packet)
    {
        Game.Player.Exchange?.UpdateItems(packet);

        EventManager.FireEvent("OnUpdateExchangeItems");
    }
}
