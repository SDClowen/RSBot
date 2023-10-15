﻿using RSBot.Core;
using RSBot.Core.Cryptography;
using RSBot.Core.Network;
using RSBot.General.Components;

namespace RSBot.General.PacketHandler;

internal class GlobalIdentificationRequest : IPacketHandler
{
    /// <summary>
    ///     Gets or sets the opcode.
    /// </summary>
    /// <value>
    ///     The opcode.
    /// </value>
    public ushort Opcode => 0x2001;

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
        if (!Game.Clientless)
            return;

        var serviceName = packet.ReadString();

        if (serviceName == "GatewayServer")
        {
            var response = new Packet(0x6100);
            response.WriteByte(Game.ReferenceManager.DivisionInfo.Locale);
            response.WriteString("SR_Client");
            response.WriteUInt(Game.ReferenceManager.VersionInfo.Version);

            PacketManager.SendPacket(response, PacketDestination.Server);
        }
        else if (serviceName == "AgentServer")
        {
            var selectedAccount = Accounts.SavedAccounts.Find(p =>
                p.Username == GlobalConfig.Get<string>("RSBot.General.AutoLoginAccountUsername"));
            if (selectedAccount == null)
            {
                Log.WarnLang("RSBot.General", "AgentServerConnectingError");
                return;
            }

            Log.NotifyLang("RSBot.General", "AuthAgentCertify");

            var opcode = (ushort)(Game.ClientType == GameClientType.Rigid ? 0x6118 : 0x6103);
            var response = new Packet(opcode, true);
            response.WriteUInt(Kernel.Proxy.Token);
            response.WriteString(selectedAccount.Username);

            if (Game.ClientType == GameClientType.Turkey ||
                Game.ClientType == GameClientType.VTC_Game)
                response.WriteString(Sha256.ComputeHash(selectedAccount.Password));
            else
                response.WriteString(selectedAccount.Password);

            response.WriteByte(Game.ReferenceManager.DivisionInfo.Locale);
            response.WriteByteArray(new byte[6]);
            PacketManager.SendPacket(response, PacketDestination.Server);
        }
    }
}