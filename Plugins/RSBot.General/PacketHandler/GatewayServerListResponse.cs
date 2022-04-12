using RSBot.Core;
using RSBot.Core.Network;
using RSBot.General.Components;
using System.Collections.Generic;
using Server = RSBot.General.Models.Server;

namespace RSBot.General.PacketHandler
{
    internal class GatewayServerListResponse : IPacketHandler
    {
        /// <summary>
        /// Gets or sets the opcode.
        /// </summary>
        /// <value>
        /// The opcode.
        /// </value>
        public ushort Opcode => 0xA101;

        /// <summary>
        /// Gets or sets the destination.
        /// </summary>
        /// <value>
        /// The destination.
        /// </value>
        public PacketDestination Destination => PacketDestination.Client;

        /// <summary>
        /// Handles the packet.
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
                var serverName = packet.ReadString();

                ushort currentCapacity = 0,
                       maxCapacity = 0;
                bool status;

                if (Game.ClientType < GameClientType.Global)
                {
                    currentCapacity = packet.ReadUShort();
                    maxCapacity = packet.ReadUShort();
                    status = packet.ReadBool();
                }
                else
                /*
                 for global:
                    0 FULL
                    1 Crowded
                    2 Populate
                    3 Easy
                    4 Check
                 */
                {
                    status = packet.ReadByte() != 4;
                    packet.ReadByte();
                }

                // fix server names
                if (Game.ClientType == GameClientType.Global)
                {
                    serverName = serverName.Remove(0, 1);
                    if (serverName.StartsWith("Palmyra"))
                        serverName = serverName.Remove(7, 3);

                    if (serverName.EndsWith("Xian"))
                        serverName = serverName.Remove(0, 3);
                }

                Serverlist.Servers.Add(new Server
                {
                    Id = id,
                    Name = serverName,
                    CurrentCapacity = currentCapacity,
                    MaxCapacity = maxCapacity,
                    Status = status
                });

                if (Game.ClientType == GameClientType.Vietnam)
                    packet.ReadByte(); // FarmId

                Log.Debug($"Found server: {serverName} ({currentCapacity}/{maxCapacity})");
            }

            BotWindow.SetStatusTextLang("WaitingUser");

            AutoLogin.Handle();
        }
    }
}