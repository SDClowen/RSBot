using RSBot.Core.Client.ReferenceObjects;
using RSBot.Core.Network;

namespace RSBot.Core.Objects.Item;

public class MagicOptionInfo
{
    /// <summary>
    ///     Gets or sets the identifier.
    /// </summary>
    /// <value>
    ///     The identifier.
    /// </value>
    public uint Id { get; set; }

    /// <summary>
    ///     Gets or sets the value.
    /// </summary>
    /// <value>
    ///     The value.
    /// </value>
    public uint Value { get; set; }

    /// <summary>
    ///     Gets the record.
    /// </summary>
    /// <value>
    ///     The record.
    /// </value>
    public RefMagicOpt Record => Game.ReferenceManager.GetMagicOption(Id);

    /// <summary>
    ///     Creates a new MagicOptionInfo object from the given packet
    /// </summary>
    /// <param name="packet">The packet.</param>
    /// <returns></returns>
    internal static MagicOptionInfo FromPacket(Packet packet)
    {
        return new MagicOptionInfo { Id = packet.ReadUInt(), Value = packet.ReadUInt() };
    }
}
