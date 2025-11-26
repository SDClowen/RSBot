using RSBot.Core;
using RSBot.Core.Cryptography;
using RSBot.Core.Network;
using RSBot.General.Components;

namespace RSBot.General.PacketHandler;

internal class AgentLoginRequestHook : IPacketHook
{
    /// <summary>
    ///     Gets the opcode.
    /// </summary>
    /// <value>
    ///     The opcode.
    /// </value>
    public ushort Opcode => 0x6103;

    /// <summary>
    ///     Gets the destination.
    /// </summary>
    /// <value>
    ///     The destination.
    /// </value>
    public PacketDestination Destination => PacketDestination.Server;

    /// <summary>
    ///     Replaces the packet and returns a new packet.
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

        packet = new Packet(packet.Opcode, packet.Encrypted);
        packet.WriteUInt(Kernel.Proxy.Token);

        if (Game.ClientType == GameClientType.RuSro)
        {
            packet.WriteString(GlobalConfig.Get<string>("RSBot.RuSro.login"));
            packet.WriteString(Sha256.ComputeHash(GlobalConfig.Get<string>("RSBot.RuSro.password")));
        }
        else if (Game.ClientType == GameClientType.Japanese)
        {
            packet.WriteString(GlobalConfig.Get<string>("RSBot.JSRO.login"));
            packet.WriteString(Sha256.ComputeHash(GlobalConfig.Get<string>("RSBot.JSRO.token")));
        }
        else
        {
            if (Game.ClientType == GameClientType.Global && selectedAccount.Channel == 0x02)
                packet.WriteString(GlobalConfig.Get<string>("RSBot.JCPlanet.login"));
            else
                packet.WriteString(selectedAccount.Username);

            if (
                Game.ClientType == GameClientType.Turkey
                || Game.ClientType == GameClientType.VTC_Game
                || Game.ClientType == GameClientType.Global
                || Game.ClientType == GameClientType.Korean
                || Game.ClientType == GameClientType.Taiwan
            )
                packet.WriteString(Sha256.ComputeHash(selectedAccount.Password));
            else
                packet.WriteString(selectedAccount.Password);
        }

        packet.WriteByte(Game.ReferenceManager.DivisionInfo.Locale);
        packet.WriteBytes(Game.MacAddress);
        packet.Lock();

        return packet;
    }
}
