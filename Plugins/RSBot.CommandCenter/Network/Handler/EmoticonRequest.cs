using System.Threading.Tasks;
using RSBot.CommandCenter.Components;
using RSBot.Core;
using RSBot.Core.Components;
using RSBot.Core.Network;

namespace RSBot.CommandCenter.Network.Handler;

internal class EmoticonRequest : IPacketHandler
{
    public ushort Opcode => 0x3091;

    public PacketDestination Destination => PacketDestination.Server;

    public void Invoke(Packet packet)
    {
        if (!PluginConfig.Enabled)
            return;

        var type = (EmoticonType)packet.ReadByte();
        var emoticon = Emoticons.GetEmoticonItemByType(type);
        var assignedCommand = PluginConfig.GetAssignedEmoteCommand(emoticon.Name);

        Task.Run(() =>
        {
            if (!CommandManager.Execute(assignedCommand))
                Log.Debug(
                    $"[Command center] Command execution of the command [{assignedCommand}] for emoticon [{emoticon.Name}] failed."
                );
        });
    }
}
