using RSBot.CommandCenter.Components;
using RSBot.Core;
using RSBot.Core.Components;
using RSBot.Core.Extensions;
using RSBot.Core.Network;
using RSBot.Core.Objects;

namespace RSBot.CommandCenter.Network.Hook;

internal class ChatRequestHook : IPacketHook
{
    public ushort Opcode => 0x7025;

    public PacketDestination Destination => PacketDestination.Server;

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

        if (Game.ClientType >= GameClientType.Chinese_Old)
            packet.ReadByte();

        var message = packet.ReadConditonalString();
        if (!message.StartsWith("\\"))
            return packet;

        var commandName = message.Split('\\')[1];

        CommandManager.Execute(commandName);

        return null;
    }
}
