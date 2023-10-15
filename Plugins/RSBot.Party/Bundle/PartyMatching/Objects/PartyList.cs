using System.Collections.Generic;
using RSBot.Core.Network;

namespace RSBot.Party.Bundle.PartyMatching.Objects;

internal class PartyList
{
    /// <summary>
    ///     Gets or sets the page count.
    /// </summary>
    /// <value>
    ///     The page count.
    /// </value>
    public byte PageCount { get; set; }

    /// <summary>
    ///     Gets or sets the page.
    /// </summary>
    /// <value>
    ///     The page.
    /// </value>
    public byte Page { get; set; }

    /// <summary>
    ///     Gets or sets the party count.
    /// </summary>
    /// <value>
    ///     The party count.
    /// </value>
    public byte PartyCount { get; set; }

    /// <summary>
    ///     Gets or sets the parties.
    /// </summary>
    /// <value>
    ///     The parties.
    /// </value>
    public List<PartyEntry> Parties { get; set; }

    /// <summary>
    ///     Froms the packet.
    /// </summary>
    /// <param name="packet">The packet.</param>
    /// <returns></returns>
    public static PartyList FromPacket(Packet packet)
    {
        if (packet == null || packet.ReadByte() != 1)
            return new PartyList { Parties = new List<PartyEntry>() };

        var result = new PartyList
        {
            Parties = new List<PartyEntry>(),
            PageCount = packet.ReadByte(),
            Page = packet.ReadByte(),
            PartyCount = packet.ReadByte()
        };

        for (var i = 0; i < result.PartyCount; i++)
            result.Parties.Add(PartyEntry.FromPacket(packet));

        return result;
    }
}