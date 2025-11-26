using RSBot.Core.Event;

namespace RSBot.Core.Network.Handler.Agent.Exchange;

internal class ExchangeApprovedResponse : IPacketHandler
{
    /// <inheritdoc />
    public ushort Opcode => 0x3087;

    /// <inheritdoc />
    public PacketDestination Destination => PacketDestination.Client;

    /// <inheritdoc />
    public void Invoke(Packet packet)
    {
        Game.Player.Exchange.Complete();
        Game.Player.Exchange = null;

        Log.Notify("Exchange completed.");

        EventManager.FireEvent("OnApproveExchange");
    }
}
