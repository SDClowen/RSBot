using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using RSBot.Core;
using RSBot.Core.Extensions;

namespace RSBot.CommandCenter.Components;

internal static class Emoticons
{
    public static List<EmoticonItem> Items =>
        new()
        {
            new EmoticonItem("emoticon.hi", "Hi", "icon\\action\\emot_act_greeting.ddj", EmoticonType.Hi),
            new EmoticonItem("emoticon.smile", "Smile", "icon\\action\\emot_act_laugh.ddj", EmoticonType.Smile),
            new EmoticonItem(
                "emoticon.greeting",
                "Greeting",
                "icon\\action\\emot_act_pokun.ddj",
                EmoticonType.Greeting
            ),
            new EmoticonItem("emoticon.yes", "Yes", "icon\\action\\emot_act_yes.ddj", EmoticonType.Yes),
            new EmoticonItem("emoticon.rush", "Rush", "icon\\action\\emot_act_rush.ddj", EmoticonType.Rush),
            new EmoticonItem("emoticon.joy", "Joy", "icon\\action\\emot_act_joy.ddj", EmoticonType.Joy),
            new EmoticonItem("emoticon.no", "No", "icon\\action\\emot_act_no.ddj", EmoticonType.No),
        };

    public static string GetEmoticonDefaultCommand(string emoticonName)
    {
        return emoticonName switch
        {
            "emoticon.yes" => "start",
            "emoticon.no" => "stop",
            "emoticon.rush" => "area",
            "emoticon.greeting" => "area",
            "emoticon.smile" => "show",
            _ => "none",
        };
    }

    public static EmoticonItem GetEmoticonItemByType(EmoticonType type)
    {
        return Items.FirstOrDefault(e => e.Type == type);
    }
}

internal enum EmoticonType : byte
{
    Hi = 0,
    Greeting = 1,
    Rush = 2,
    Joy = 3,
    No = 4,
    Yes = 5,
    Smile = 6,
}

internal record EmoticonItem(string Name, string Label, string Icon, EmoticonType Type)
{
    public Image GetIconImage()
    {
        if (!Game.MediaPk2.TryGetFile(Icon, out var iconFile))
            return new Bitmap(32, 32);

        return iconFile.ToImage();
    }

    public override string ToString()
    {
        return Label;
    }
}
