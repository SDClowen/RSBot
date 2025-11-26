using System.Windows.Forms;
using RSBot.Core;
using RSBot.Core.Components;
using RSBot.Core.Network;
using View = RSBot.Chat.Views.View;

namespace RSBot.Chat.Network;

internal class AgentNotifyResponse : IPacketHandler
{
    /// <summary>
    ///     Gets or sets the opcode.
    /// </summary>
    /// <value>
    ///     The opcode.
    /// </value>
    public ushort Opcode => 0x300C;

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
        var noticeType = packet.ReadByte();
        if (Game.ClientType > GameClientType.Thailand)
            packet.ReadByte();

        switch (noticeType)
        {
            //[%s] has appeared
            case 0x5:
                var refObjId = packet.ReadUInt();
                if (!Game.ReferenceManager.CharacterData.TryGetValue(refObjId, out var obj))
                    return;

                string realName = obj.GetRealName();

                View.Instance.UniqueText.Write(LanguageManager.GetLang("UniqueAppeared", realName));

                // Play sound.
                Game.Player.NotificationSounds.PlayUniqueAppeared(realName);

                break;

            //[%s] has disappeared or killed
            case 0x6:

                refObjId = packet.ReadUInt();
                if (!Game.ReferenceManager.CharacterData.TryGetValue(refObjId, out obj))
                    return;

                var characterName = packet.ReadString();

                // If name equals "???" then "[%s] has disappeared." is displayed.
                if (characterName == "???")
                {
                    View.Instance.UniqueText.Write($"{obj.GetRealName()} has disappeared.");
                    return;
                }

                View.Instance.UniqueText.Write(
                    LanguageManager.GetLang("UniqueKilled", characterName, obj.GetRealName())
                );

                break;
        }
    }
}
