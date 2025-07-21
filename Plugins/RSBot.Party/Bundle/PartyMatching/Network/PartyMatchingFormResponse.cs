using RSBot.Core;
using RSBot.Core.Event;
using RSBot.Core.Extensions;
using RSBot.Core.Network;
using RSBot.Core.Objects.Party;
using System.Threading;

namespace RSBot.Party.Bundle.PartyMatching.Network;

internal class PartyMatchingFormResponse : IPacketHandler
{
    /// <summary>
    ///     Gets or sets the opcode.
    /// </summary>
    /// <value>The opcode.</value>
    public ushort Opcode => 0xB069;

    /// <summary>
    ///     Gets or sets the destination.
    /// </summary>
    /// <value>The destination.</value>
    /// <exception cref="System.NotImplementedException"></exception>
    public PacketDestination Destination => PacketDestination.Client;

    /// <summary>
    ///     Handles the packet.
    /// </summary>
    /// <param name="packet">The packet.</param>
    public void Invoke(Packet packet)
    {
        if (packet.ReadByte() != 0x01) return;

        if (Container.PartyMatching != null)
            Container.PartyMatching.HasMatchingEntry = true;

        Container.PartyMatching.Id = packet.ReadUInt();
        packet.ReadUInt();

        Game.Party.Settings = PartySettings.FromType(packet.ReadByte());
        Container.PartyMatching.Config.Purpose = (PartyPurpose)packet.ReadByte();
        Container.PartyMatching.Config.LevelFrom = packet.ReadByte();
        Container.PartyMatching.Config.LevelTo = packet.ReadByte();
        Container.PartyMatching.Config.Title = packet.ReadConditonalString();

        Container.PartyMatching.CancelScheduledDeletion();

        Container.PartyMatching.DeletionCts = new CancellationTokenSource();
        _ = Container.PartyMatching.ScheduleDeletion(Container.PartyMatching.DeletionCts.Token);

        EventManager.FireEvent("OnCreatePartyEntry");
    }
}