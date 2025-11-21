using RSBot.Core.Network;

namespace RSBot.Core.Objects.Spawn;

internal class SpawnPacketInfo
{
    /// <summary>
    ///     Gets or sets the type.
    /// </summary>
    /// <value>
    ///     The type.
    /// </value>
    public byte Type { get; set; }

    /// <summary>
    ///     Gets or sets the amount.
    /// </summary>
    /// <value>
    ///     The amount.
    /// </value>
    public ushort Amount { get; set; }

    /// <summary>
    ///     Gets or sets the packet.
    /// </summary>
    /// <value>
    ///     The packet.
    /// </value>
    public Packet Packet { get; set; }
}
