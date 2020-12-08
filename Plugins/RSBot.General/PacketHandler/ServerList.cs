using RSBot.Core;
using RSBot.Core.Network;
using RSBot.General.Components;
using System.Collections.Generic;
using Server = RSBot.General.Models.Server;

namespace RSBot.General.PacketHandler
{
    internal class ServerList : IPacketHandler
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

            //Shard managers? - Dont need that
            while (packet.ReadByte() != 0)
            {
                packet.ReadByte();
                packet.ReadString();
            }

            while (packet.ReadByte() == 1)
            {
                var id = packet.ReadUShort(); //server identifier
                var serverName = packet.ReadString();
                var currentCapacity = packet.ReadUShort();
                var maxCapacity = packet.ReadUShort();
                var status = packet.ReadByte(); //server status

                Serverlist.Servers.Add(new Server
                {
                    Id = id,
                    Name = serverName,
                    CurrentCapacity = currentCapacity,
                    MaxCapacity = maxCapacity,
                    Status = status
                });

                Log.Notify($"Found server: {serverName} ({currentCapacity}/{maxCapacity})");
            }
            BotWindow.SetStatusText("Waiting for the user to login...");

            AutoLogin.DoAutoLogin();
        }
    }
}