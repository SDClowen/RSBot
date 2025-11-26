using RSBot.Core;

namespace RSBot.Training.Bundle.Protection;

internal class HealthRecovery
{
    public static bool Active => PlayerConfig.Get<bool>("RSBot.Protection.checkUseSkillHP");
    public static int Value => PlayerConfig.Get("RSBot.Protection.numPlayerSkillHPMin", 50);
    public static uint SkillId => PlayerConfig.Get<uint>("RSBot.Protection.HpSkill");
    public static double Current => 100.0 * Game.Player.Health / Game.Player.MaximumHealth;
}
