using System.Collections.Generic;
using RSBot.Core;
using RSBot.Core.Network;
using RSBot.General.Components;
using Server = RSBot.General.Models.Server;

namespace RSBot.General.PacketHandler;

internal class GatewayServerListResponse : IPacketHandler
{
    /// <summary>
    ///     Gets or sets the opcode.
    /// </summary>
    /// <value>
    ///     The opcode.
    /// </value>
    public ushort Opcode => 0xA101;

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
        Serverlist.Servers = new List<Server>();

        while (packet.ReadByte() != 0)
        {
            packet.ReadByte();
            packet.ReadString();
        }

        while (packet.ReadByte() == 1)
        {
            var id = packet.ReadUShort();
            var serverName =
                Game.ClientType == GameClientType.Turkey
                || Game.ClientType == GameClientType.Global
                || Game.ClientType == GameClientType.VTC_Game
                || Game.ClientType == GameClientType.RuSro
                || Game.ClientType == GameClientType.Korean
                || Game.ClientType == GameClientType.Japanese
                || Game.ClientType == GameClientType.Taiwan
                    ? packet.ReadUnicode()
                    : packet.ReadString();

            ushort currentCapacity = 0,
                maxCapacity = 0;

            byte status;

            if (Game.ClientType < GameClientType.Global)
            {
                currentCapacity = packet.ReadUShort();
                maxCapacity = packet.ReadUShort();
                status = packet.ReadByte();
            }
            else
            {
                status = packet.ReadByte();
                packet.ReadByte();
            }

            // fix server names
            if (Game.ClientType == GameClientType.Global)
                serverName = serverName.Remove(0, 1);

            if (Game.ClientType == GameClientType.VTC_Game)
                if (serverName.EndsWith("Thien_Kim"))
                    serverName = serverName.Remove(0, 3);

            var state =
                Game.ClientType >= GameClientType.Chinese
                    ? $"{(ServerStatusModern)status}"
                    : $"{currentCapacity}/{maxCapacity}";

            Serverlist.Servers.Add(
                new Server
                {
                    Id = id,
                    Name = serverName,
                    CurrentCapacity = currentCapacity,
                    MaxCapacity = maxCapacity,
                    Status = Game.ClientType >= GameClientType.Chinese ? status != 4 : status == 1,
                    State = state,
                }
            );

            if (Game.ClientType == GameClientType.Vietnam)
                packet.ReadByte(); // FarmId

            Log.Notify($"Found server: {serverName} ({state})");
        }

        AutoLogin.Handle();
    }

    private enum ServerStatusModern
    {
        Full,
        Crowded,
        Populate,
        Easy,
        Check,
    }
}
