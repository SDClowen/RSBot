using RSBot.Core.Network;

namespace RSBot.Core.Objects.Exchange;

public struct ExchangeItem
{
    #region Fields

    /// <summary>
    ///     The source slot
    /// </summary>
    public byte SourceSlot;

    /// <summary>
    ///     The exchange slot
    /// </summary>
    public byte ExchangeSlot;

    /// <summary>
    ///     The item
    /// </summary>
    public InventoryItem Item;

    #endregion Fields

    /// <summary>
    ///     Returns an exchange item from the provided packet
    /// </summary>
    /// <param name="packet">The packet.</param>
    /// <param name="hasSource">if set to <c>true</c> [has source].</param>
    /// <returns></returns>
    public static ExchangeItem FromPacket(Packet packet, bool hasSource = false)
    {
        return new ExchangeItem
        {
            SourceSlot = hasSource ? packet.ReadByte() : (byte)0,
            ExchangeSlot = packet.ReadByte(),
            Item = InventoryItem.FromPacket(packet, 0xFF),
        };
    }
}
