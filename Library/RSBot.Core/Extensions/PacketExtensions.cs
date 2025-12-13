using RSBot.Core.Network;

namespace RSBot.Core.Extensions;

public static class PacketExtensions
{
    /// <summary>
    ///     It is a function for text reading differences between different client types.
    ///     Not used in similar places such as character name reading
    /// </summary>
    /// <param name="packet">The packet</param>
    public static string ReadConditonalString(this Packet packet)
    {
        switch (Game.ClientType)
        {
            case GameClientType.Thailand:
            //case GameClientType.Global:
            //case GameClientType.Turkey:
            case GameClientType.Korean:
            case GameClientType.Rigid:
            //case GameClientType.VTC_Game:
            case GameClientType.RuSro:
            case GameClientType.Chinese:
            case GameClientType.Japanese:
            case GameClientType.Taiwan:
                return packet.ReadUnicode();

            default:
                return packet.ReadString();
        }
    }

    /// <summary>
    ///     It is a function for text reading differences between different client types.
    ///     Note: Not used in similar places such as character name writing
    /// </summary>
    /// <param name="packet">The packet</param>
    public static void WriteConditonalString(this Packet packet, string str)
    {
        switch (Game.ClientType)
        {
            case GameClientType.Thailand:
            //case GameClientType.Global:
            //case GameClientType.Turkey:
            case GameClientType.Korean:
            case GameClientType.Rigid:
            case GameClientType.RuSro:
            case GameClientType.Chinese:
            case GameClientType.Japanese:
            case GameClientType.Taiwan:
                packet.WriteUnicode(str);
                break;

            default:
                packet.WriteString(str);
                break;
        }
    }
}
