using RSBot.CommandCenter.Avalonia.Components;
using RSBot.Core;
using RSBot.Core.Components;
using RSBot.Core.Extensions;
using RSBot.Core.Network;
using RSBot.Core.Objects;

namespace RSBot.CommandCenter.Avalonia.Network.Hook;

/// <summary>
/// Hooks chat request packets to handle commands
/// </summary>
internal class ChatRequestHook : IPacketHook
{
    /// <summary>
    /// Gets the opcode for this packet hook
    /// </summary>
    public ushort Opcode => 0x7025;

    /// <summary>
    /// Gets the destination for this packet hook
    /// </summary>
    public PacketDestination Destination => PacketDestination.Server;

    /// <summary>
    /// Processes and potentially replaces the chat request packet
    /// </summary>
    /// <param name="packet">The packet to process</param>
    /// <returns>The modified packet or null if the packet should be ignored</returns>
    public Packet ReplacePacket(Packet packet)
    {
        if (!PluginConfig.Enabled)
            return packet;

        var type = (ChatType)packet.ReadByte();
        if (type == ChatType.Private)
            return packet;

        packet.ReadByte(); // chatIndex

        if (Game.ClientType > GameClientType.Vietnam)
            packet.ReadByte(); // has linking

        if (Game.ClientType >= GameClientType.Chinese)
            packet.ReadByte();

        var message = packet.ReadConditonalString();
        if (!message.StartsWith("\\"))
            return packet;

        var commandName = message.Split('\\')[1];

        CommandManager.Execute(commandName);

        return null;
    }
} 