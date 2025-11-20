using RSBot.Core.Event;
using RSBot.Core.Objects.Job;

namespace RSBot.Core.Network.Handler.Agent.Job;

internal class JobUpdateTradeScaleResponse : IPacketHandler
{
    /// <summary>
    ///     Gets or sets the opcode.
    /// </summary>
    /// <value>
    ///     The opcode.
    /// </value>
    public ushort Opcode => 0x30E8;

    /// <summary>
    ///     Gets or sets the destination.
    /// </summary>
    /// <value>
    ///     The destination.
    /// </value>
    public PacketDestination Destination => PacketDestination.Client;

    /// <summary>
    ///     Handles the packet.
    /// </summary>
    /// <param name="packet">The packet.</param>
    public void Invoke(Packet packet)
    {
        if (Game.Player.TradeInfo == null)
            Game.Player.TradeInfo = new TradeInfo();

        Game.Player.TradeInfo.Scale = packet.ReadByte();

        Log.Notify($"[Job] Difficulty set to level {Game.Player.TradeInfo.Scale}");

        EventManager.FireEvent("OnJobScaleUpdate");
    }
}
