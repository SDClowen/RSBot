using RSBot.Core;
using RSBot.Core.Components;
using RSBot.Core.Extensions;
using RSBot.Core.Network;
using RSBot.Core.Objects;
using RSBot.Core.Objects.Spawn;
using RSBot.Party.Bundle;

namespace RSBot.Chat.Network;

internal class ChatResponse : IPacketHandler
{
    /// <summary>
    ///     Gets or sets the opcode.
    /// </summary>
    /// <value>
    ///     The opcode.
    /// </value>
    public ushort Opcode => 0x3026;

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
        var type = (ChatType)packet.ReadByte();

        var message = string.Empty;
        SpawnedPlayer player = null;

        switch (type)
        {
            case ChatType.All:
            case ChatType.AllGM:
                var senderId = packet.ReadUInt();
                message = packet.ReadConditonalString();

                if (senderId == Game.Player.UniqueId)
                    return;

                if (!SpawnManager.TryGetEntity(senderId, out player))
                    return;

                Container.Commands.Handle(player, message.Trim());

                break;

            // in party
            case ChatType.Private:
            case ChatType.Party:
                var sender = packet.ReadString();
                message = packet.ReadConditonalString();

                if (!SpawnManager.TryGetEntity(p => p.Name == sender, out player))
                    return;

                Container.Commands.Handle(player, message.Trim());

                break;
        }
    }
}