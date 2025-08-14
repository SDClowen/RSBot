using System.Linq;
using RSBot.Core;
using RSBot.Core.Client.ReferenceObjects;
using RSBot.Core.Components;
using RSBot.Lure.Components;

namespace RSBot.Lure.Bundle;

internal static class HowlingShoutBundle
{
    public static void Tick()
    {
        if (Game.Player.Race != ObjectCountry.Europe)
            return;

        if (LureConfig.NoHowlingAtCenter && LureConfig.Area.Position.DistanceToPlayer() < 15)
            return;

        var howlingShout =
            Game.Player.Skills.KnownSkills.Where(s =>
                s.Record.Basic_Group == "SKILL_EU_WARRIOR_FRENZYA_TOUNT_AREA_B" ||
                s.Record.Basic_Group == "SKILL_EU_WARRIOR_FRENZYA_TOUNT_AREA_A" ||
                s.Record.Basic_Group == "SKILL_EU_WARRIOR_FRENZYA_TOUNT_A")
            .MaxBy(s => s.Record.ID);
        if (howlingShout == null || howlingShout.CanNotBeCasted || howlingShout.HasCooldown)
            return;

        SkillManager.CastBuff(howlingShout);
    }
}