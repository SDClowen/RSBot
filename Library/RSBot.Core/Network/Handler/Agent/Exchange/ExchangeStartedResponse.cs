using RSBot.Core.Event;
using RSBot.Core.Objects.Exchange;

namespace RSBot.Core.Network.Handler.Agent.Exchange;

internal class ExchangeStartedResponse : IPacketHandler
{
    /// <inheritdoc />
    public ushort Opcode => 0x3085;

    /// <inheritdoc />
    public PacketDestination Destination => PacketDestination.Client;

    /// <inheritdoc />
    public void Invoke(Packet packet)
    {
        var playerUniqueId = packet.ReadUInt();
        Game.Player.Exchange = new ExchangeInstance(playerUniqueId);

        Log.Notify($"Started exchanging with the player {Game.Player.Exchange.ExchangePlayer.Name}");

        EventManager.FireEvent("OnStartExchange");
    }
}
