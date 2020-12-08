using RSBot.Core;
using RSBot.Core.Network;
using RSBot.General.Components;
using System;

namespace RSBot.General.PacketHandler
{
    internal class AgentLoginRequestHook : IPacketHook
    {
        /// <summary>
        /// Gets the opcode.
        /// </summary>
        /// <value>
        /// The opcode.
        /// </value>
        public ushort Opcode => 0x6103;

        /// <summary>
        /// Gets the destination.
        /// </summary>
        /// <value>
        /// The destination.
        /// </value>
        public PacketDestination Destination => PacketDestination.Server;

        /// <summary>
        /// Replaces the packet and returns a new packet.
        /// </summary>
        /// <param name="packet"></param>
        /// <returns></returns>
        public Packet ReplacePacket(Packet packet)
        {
            if (!GlobalConfig.Get<bool>("RSBot.General.EnableAutomatedLogin"))
                return packet;
            if (Accounts.SavedAccounts.Count <= GlobalConfig.Get<int>("RSBot.General.AccountIndex"))
                return packet;

            var selectedAccount = Accounts.SavedAccounts[GlobalConfig.Get<int>("RSBot.General.AccountIndex")];
            if (selectedAccount == null)
                return packet;

            if (Game.Clientless) return packet;

            packet = new Packet(0x6103, true);
            packet.WriteUInt(Kernel.Proxy.Token);

            packet.WriteString(selectedAccount.Username);
            packet.WriteString(selectedAccount.Password);
            packet.WriteByte(Game.ReferenceManager.DivisionInfo.Locale);

            var rnd = new Random();
            var buffer = new byte[6];
            rnd.NextBytes(buffer);
            packet.WriteByteArray(buffer);
            packet.Lock();

            return packet;
        }
    }
}