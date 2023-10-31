using System;
using System.Linq;
using RSBot.Core;
using RSBot.Core.Network;
using RSBot.Core.Objects.Spawn;

namespace RSBot.Party.Bundle.Commands;

internal class CommandsBundle
{
    /// <summary>
    ///     Gets or sets the configuration.
    /// </summary>
    /// <value>
    ///     The configuration.
    /// </value>
    public CommandsConfig Config { get; set; }

    /// <summary>
    ///     Handle the bundle
    /// </summary>
    public void Handle(SpawnedPlayer player, string message)
    {
        if (StringComparer.InvariantCultureIgnoreCase.Equals(message, "traceme"))
        {
            if (Config.ListenFromList && Config.PlayerList.Contains(player.Name))
                SendTraceRequest(player.UniqueId);

            if (Config.ListenOnlyMaster && Game.Party.IsInParty)
                SendTraceRequest(player.UniqueId);
        }

        if (StringComparer.InvariantCultureIgnoreCase.Equals(message, "sitdown"))
        {
            if (Config.ListenFromList && Config.PlayerList.Contains(player.Name))
                SendSitdownRequest();

            if (Config.ListenOnlyMaster && Game.Party.IsInParty)
                SendSitdownRequest();
        }
    }

    /// <summary>
    ///     Send trace request by speficied uniqueId
    /// </summary>
    /// <param name="uniqueId">The unique id</param>
    private void SendTraceRequest(uint uniqueId)
    {
        var packet = new Packet(0x7074);
        packet.WriteByte(1);
        packet.WriteByte(3);
        packet.WriteByte(1);
        packet.WriteUInt(uniqueId);

        PacketManager.SendPacket(packet, PacketDestination.Server);
    }

    /// <summary>
    ///     Send trace request by speficied uniqueId
    /// </summary>
    private void SendSitdownRequest()
    {
        var packet = new Packet(0x704F);
        packet.WriteByte(4);
        //packet.WriteUInt();

        PacketManager.SendPacket(packet, PacketDestination.Server);
    }

    /// <summary>
    ///     Refreshes this instance.
    /// </summary>
    public void Refresh()
    {
        Config = new CommandsConfig
        {
            PlayerList = PlayerConfig.GetArray<string>("RSBot.Party.Commands.PlayersList"),
            ListenFromList = PlayerConfig.Get<bool>("RSBot.Party.Commands.ListenOnlyList"),
            ListenOnlyMaster = PlayerConfig.Get<bool>("RSBot.Party.Commands.ListenFromMaster")
        };
    }
}