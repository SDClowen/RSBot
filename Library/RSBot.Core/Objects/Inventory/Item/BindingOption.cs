using RSBot.Core.Network;

namespace RSBot.Core.Objects.Item;

public class BindingOption
{
    /// <summary>
    ///     Gets or sets the type.
    /// </summary>
    public BindingOptionType Type { get; set; }

    /// <summary>
    ///     Gets or sets the slot.
    /// </summary>
    /// <value>
    ///     The slot.
    /// </value>
    public byte Slot { get; set; }

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
    ///     Creates a new BindingOption object from the given packet and type
    /// </summary>
    /// <param name="packet">The packet.</param>
    /// <param name="type">The type.</param>
    /// <returns></returns>
    internal static BindingOption FromPacket(Packet packet, BindingOptionType type)
    {
        return new BindingOption
        {
            Type = type,
            Slot = packet.ReadByte(),
            Id = packet.ReadUInt(),
            Value = packet.ReadUInt(),
        };
    }
}

public enum BindingOptionType : byte
{
    Socket = 1,
    AdvancedElixir = 2,
}
