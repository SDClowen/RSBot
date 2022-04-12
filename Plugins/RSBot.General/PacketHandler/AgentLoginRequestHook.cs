using RSBot.Core;
using RSBot.Core.Network;
using RSBot.General.Components;

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

            var username = GlobalConfig.Get<string>("RSBot.General.AutoLoginAccountUsername");

            var selectedAccount = Accounts.SavedAccounts.Find(p => p.Username == username);
            if (selectedAccount == null)
                return packet;

            if (Game.Clientless) 
                return packet;

            packet = new Packet(Opcode, packet.Encrypted);
            packet.WriteUInt(Kernel.Proxy.Token);
            packet.WriteString(selectedAccount.Username);
            packet.WriteString(selectedAccount.Password);
            packet.WriteByte(Game.ReferenceManager.DivisionInfo.Locale);
            packet.WriteByteArray(new byte[6]);
            packet.Lock();

            return packet;
        }
    }
}