using RSBot.Core.Event;

namespace RSBot.Core.Network.Handler.Agent.Exchange
{
    internal class ExchangeCanceledResponse : IPacketHandler
    {
        /// <inheritdoc />
        public ushort Opcode => 0x3088;

        /// <inheritdoc />
        public PacketDestination Destination => PacketDestination.Client;

        /// <inheritdoc />
        public void Invoke(Packet packet)
        {
            Core.Game.Player.Exchange = null;

            Log.Notify("Exchange has been canceled.");

            EventManager.FireEvent("OnCancelExchange");
        }
    }
}