using System.Collections.Generic;
using RSBot.Core;

namespace RSBot.CommandCenter.Avalonia.Components;

/// <summary>
/// Manages plugin configuration and settings
/// </summary>
internal static class PluginConfig
{
    /// <summary>
    /// Gets whether the plugin is enabled
    /// </summary>
    public static bool Enabled => PlayerConfig.Get("RSBot.CommandCenter.Enabled", true);

    /// <summary>
    /// Gets the mapping of emoticons to commands
    /// </summary>
    public static Dictionary<string, string> GetEmoteToCommandMapping()
    {
        var result = new Dictionary<string, string>(16);

        foreach (var emoticon in Emoticons.Items)
        {
            var actionName = PlayerConfig.Get(
                $"RSBot.CommandCenter.MappedEmotes.{emoticon.Name}",
                Emoticons.GetEmoticonDefaultCommand(emoticon.Name));

            result.Add(emoticon.Name, actionName);
        }

        return result;
    }

    /// <summary>
    /// Gets the assigned command for the specified emoticon
    /// </summary>
    /// <param name="emoteName">The name of the emoticon</param>
    public static string GetAssignedEmoteCommand(string emoteName)
    {
        var mapping = GetEmoteToCommandMapping();
        return mapping.ContainsKey(emoteName) 
            ? mapping[emoteName] 
            : Emoticons.GetEmoticonDefaultCommand(emoteName);
    }
} 