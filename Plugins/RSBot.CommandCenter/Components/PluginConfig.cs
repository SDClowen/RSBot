using System.Collections.Generic;
using RSBot.Core;

namespace RSBot.CommandCenter.Components;

internal class PluginConfig
{
    public static bool Enabled => PlayerConfig.Get("RSBot.CommandCenter.Enabled", true);

    public static Dictionary<string, string> GetEmoteToCommandMapping()
    {
        var result = new Dictionary<string, string>(16);

        foreach (var emoticon in Emoticons.Items)
        {
            var actionName = PlayerConfig.Get(
                $"RSBot.CommandCenter.MappedEmotes.{emoticon.Name}",
                Emoticons.GetEmoticonDefaultCommand(emoticon.Name)
            );

            result.Add(emoticon.Name, actionName);
        }

        return result;
    }

    public static string GetAssignedEmoteCommand(string emoteName)
    {
        var mapping = GetEmoteToCommandMapping();

        return mapping.ContainsKey(emoteName) ? mapping[emoteName] : Emoticons.GetEmoticonDefaultCommand(emoteName);
    }
}
