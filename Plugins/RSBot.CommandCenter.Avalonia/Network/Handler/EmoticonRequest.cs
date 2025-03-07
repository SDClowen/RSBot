using System.Threading.Tasks;
using RSBot.CommandCenter.Avalonia.Components;
using RSBot.Core;
using RSBot.Core.Components;
using RSBot.Core.Network;

namespace RSBot.CommandCenter.Avalonia.Network.Handler;

/// <summary>
/// Handles emoticon request packets from the server
/// </summary>
internal class EmoticonRequest : IPacketHandler
{
    /// <summary>
    /// Gets the opcode for this packet handler
    /// </summary>
    public ushort Opcode => 0x3091;

    /// <summary>
    /// Gets the destination for this packet
    /// </summary>
    public PacketDestination Destination => PacketDestination.Server;

    /// <summary>
    /// Handles the emoticon request packet
    /// </summary>
    /// <param name="packet">The packet to handle</param>
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
                    $"[Command center] Command execution of the command [{assignedCommand}] for emoticon [{emoticon.Name}] failed.");
        });
    }
} 