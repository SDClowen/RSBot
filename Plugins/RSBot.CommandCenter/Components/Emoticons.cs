using System.Collections.Generic;
using System.Linq;
using Avalonia;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using RSBot.Core;
using RSBot.Core.Extensions;

namespace RSBot.CommandCenter.Components;

/// <summary>
/// Manages emoticon items and their default commands
/// </summary>
internal static class Emoticons
{
    /// <summary>
    /// Gets the list of available emoticons
    /// </summary>
    public static List<EmoticonItem> Items => new()
    {
        new EmoticonItem("emoticon.hi", "Hi", "icon\\action\\emot_act_greeting.ddj", EmoticonType.Hi),
        new EmoticonItem("emoticon.smile", "Smile", "icon\\action\\emot_act_laugh.ddj", EmoticonType.Smile),
        new EmoticonItem("emoticon.greeting", "Greeting", "icon\\action\\emot_act_pokun.ddj", EmoticonType.Greeting),
        new EmoticonItem("emoticon.yes", "Yes", "icon\\action\\emot_act_yes.ddj", EmoticonType.Yes),
        new EmoticonItem("emoticon.rush", "Rush", "icon\\action\\emot_act_rush.ddj", EmoticonType.Rush),
        new EmoticonItem("emoticon.joy", "Joy", "icon\\action\\emot_act_joy.ddj", EmoticonType.Joy),
        new EmoticonItem("emoticon.no", "No", "icon\\action\\emot_act_no.ddj", EmoticonType.No)
    };

    /// <summary>
    /// Gets the default command for the specified emoticon
    /// </summary>
    /// <param name="emoticonName">The name of the emoticon</param>
    public static string GetEmoticonDefaultCommand(string emoticonName)
    {
        return emoticonName switch
        {
            "emoticon.yes" => "start",
            "emoticon.no" => "stop",
            "emoticon.rush" => "area",
            "emoticon.greeting" => "area",
            "emoticon.smile" => "show",
            _ => "none"
        };
    }

    /// <summary>
    /// Gets an emoticon item by its type
    /// </summary>
    /// <param name="type">The type of emoticon</param>
    public static EmoticonItem GetEmoticonItemByType(EmoticonType type)
    {
        return Items.FirstOrDefault(e => e.Type == type);
    }
}

/// <summary>
/// Represents the type of emoticon
/// </summary>
public enum EmoticonType : byte
{
    Hi = 0,
    Greeting = 1,
    Rush = 2,
    Joy = 3,
    No = 4,
    Yes = 5,
    Smile = 6
}

/// <summary>
/// Represents an emoticon item with its properties
/// </summary>
public record EmoticonItem(string Name, string Label, string Icon, EmoticonType Type)
{
    /// <summary>
    /// Gets the icon image for the emoticon
    /// </summary>
    public Bitmap GetIconImage()
    {
        if (!Game.MediaPk2.TryGetFile(Icon, out var iconFile))
            return new WriteableBitmap(new PixelSize(256, 256), new Vector(96, 96), PixelFormat.Bgra8888, AlphaFormat.Premul);

        return iconFile.ToImage();
    }

    public override string ToString()
    {
        return Label;
    }
} 