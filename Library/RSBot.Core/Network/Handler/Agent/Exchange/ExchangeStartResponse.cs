using RSBot.Core.Event;
using RSBot.Core.Objects.Exchange;

namespace RSBot.Core.Network.Handler.Agent.Exchange;

internal class ExchangeStartResponse : IPacketHandler
{
    /// <inheritdoc />
    public ushort Opcode => 0xB081;

    /// <inheritdoc />
    public PacketDestination Destination => PacketDestination.Client;

    /// <inheritdoc />
    public void Invoke(Packet packet)
    {
        if (packet.ReadByte() != 1)
            return;

        var playerUniqueId = packet.ReadUInt();
        Game.Player.Exchange = new ExchangeInstance(playerUniqueId);

        Log.Notify($"Started exchanging with the player {Game.Player.Exchange.ExchangePlayer.Name}");

        EventManager.FireEvent("OnStartExchange");
    }
}
