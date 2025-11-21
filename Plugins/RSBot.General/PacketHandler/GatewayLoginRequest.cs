using RSBot.Core;
using RSBot.Core.Network;
using RSBot.General.Components;

namespace RSBot.General.PacketHandler;

internal class GatewayLoginRequest : IPacketHandler
{
    /// <summary>
    ///     Gets the opcode.
    /// </summary>
    /// <value>
    ///     The opcode.
    /// </value>
    public ushort Opcode => 0x6102;

    /// <summary>
    ///     Gets the destination.
    /// </summary>
    /// <value>
    ///     The destination.
    /// </value>
    public PacketDestination Destination => PacketDestination.Server;

    /// <summary>
    ///     Replaces the packet and returns a new packet.
    /// </summary>
    /// <param name="packet"></param>
    /// <returns></returns>
    public void Invoke(Packet packet)
    {
        packet.ReadByte(); // locale
        packet.ReadString(); //username
        packet.ReadString(); //password

        if (
            (packet.Opcode == 0x610A && Game.ClientType == GameClientType.Turkey)
            || Game.ClientType == GameClientType.VTC_Game
            || Game.ClientType == GameClientType.RuSro
            || Game.ClientType == GameClientType.Japanese
            || Game.ClientType == GameClientType.Taiwan
        )
            Game.MacAddress = packet.ReadBytes(6); //reassigned in case of manual login when auto is enabled

        var shardId = packet.ReadUShort();

        if (Game.ClientType >= GameClientType.Chinese)
            packet.ReadByte(); // channel

        Serverlist.SetJoining(shardId);
    }
}
