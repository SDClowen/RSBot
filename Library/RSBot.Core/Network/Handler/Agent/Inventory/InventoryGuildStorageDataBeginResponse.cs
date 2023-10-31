﻿using RSBot.Core.Objects.Inventory;

namespace RSBot.Core.Network.Handler.Agent.Inventory;

internal class InventoryGuildStorageDataBeginResponse : IPacketHandler
{
    /// <summary>
    ///     Gets or sets the opcode.
    /// </summary>
    /// <value>
    ///     The opcode.
    /// </value>
    public ushort Opcode => 0x3253;

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
        Game.ChunkedPacket = new Packet(0);
        Game.Player.GuildStorage = Game.Player.GuildStorage ?? new Storage();
        Game.Player.GuildStorage.Gold = packet.ReadULong();
    }
}