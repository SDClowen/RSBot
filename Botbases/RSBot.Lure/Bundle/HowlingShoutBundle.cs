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
            Game.Player.Skills.KnownSkills.FirstOrDefault(s =>
                s.Record.GroupID == 537); //SKILL_EU_WARRIOR_FRENZYA_TOUNT_AREA_A_04
        if (howlingShout == null || howlingShout.CanNotBeCasted)
            return;

        SkillManager.CastBuff(howlingShout, awaitBuffResponse: false);
    }
}