using RSBot.Core;
using RSBot.Core.Event;
using RSBot.Core.Network;

namespace RSBot.Party.Bundle.PartyMatching.Network;

public class PartyMatchingDeleteResponse : IPacketHandler
{
    /// <summary>
    ///     Gets or sets the destination.
    /// </summary>
    /// <value>The destination.</value>
    public PacketDestination Destination => PacketDestination.Client;

    /// <summary>
    ///     Gets or sets the opcode.
    /// </summary>
    /// <value>The opcode.</value>
    public ushort Opcode => 0xB06B;

    /// <summary>
    ///     Handles the packet.
    /// </summary>
    /// <param name="packet">The packet.</param>
    public void Invoke(Packet packet)
    {
        if (packet.ReadByte() != 0x01)
            return;

        Log.NotifyLang("PartyEntryRemoved");

        if (Container.PartyMatching != null)
        {
            Container.PartyMatching.CancelScheduledDeletion();
            Container.PartyMatching.HasMatchingEntry = false;
        }

        EventManager.FireEvent("OnDeletePartyEntry");
    }
}