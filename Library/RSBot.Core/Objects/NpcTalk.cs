using RSBot.Core.Network;

namespace RSBot.Core.Objects;

public class NpcTalk
{
    /// <summary>
    ///     Gets or sets the talk flag.
    /// </summary>
    /// <value>
    ///     The talk flag.
    /// </value>
    public byte Flag { get; set; }

    /// <summary>
    ///     Gets or sets the talk options.
    /// </summary>
    /// <value>
    ///     The talk options.
    /// </value>
    public byte[] Options { get; set; }

    /// <summary>
    ///     Deserialize from the packet
    /// </summary>
    /// <param name="packet">The packet</param>
    public void Deserialize(Packet packet)
    {
        Flag = packet.ReadByte();

        if ((Flag & 2) > 0)
        {
            var count = 4;
            if (Game.ClientType > GameClientType.Thailand)
                count = packet.ReadByte();

            if (
                Game.ClientType == GameClientType.Global
                || Game.ClientType == GameClientType.Turkey
                || Game.ClientType == GameClientType.VTC_Game
                || Game.ClientType == GameClientType.RuSro
                || Game.ClientType == GameClientType.Korean
                || Game.ClientType == GameClientType.Japanese
                || Game.ClientType == GameClientType.Taiwan
            )
                count = 7;

            Options = packet.ReadBytes(count);
        }

        // pandora box, after spawned mobs
        if (Flag == 6)
            if (packet.ReadByte() == 1) // maybe
                packet.ReadUInt();
    }
}
