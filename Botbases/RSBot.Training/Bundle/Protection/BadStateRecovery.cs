using RSBot.Core;
using RSBot.Core.Objects;

namespace RSBot.Training.Bundle.Protection;

internal class BadStateRecovery
{
    public static bool Active => PlayerConfig.Get<bool>("RSBot.Protection.checkUseBadStatusSkill");
    public static uint SkillId => PlayerConfig.Get<uint>("RSBot.Protection.BadStatusSkill");
    public static uint SkillIdForUniversall => PlayerConfig.Get<uint>("RSBot.Protection.BadStatusSkill");
    public static uint SkillIdForPurification => PlayerConfig.Get<uint>("RSBot.Protection.BadStatusSkill");
    public static bool IsInBadStatus => IsUniversall || IsPurification;

    public static bool IsUniversall => (Game.Player.BadEffect & BadEffectAll.UniversallPillEffects) != 0;
    public static bool IsPurification => (Game.Player.BadEffect & BadEffectAll.PurificationPillEffects) != 0;
}
