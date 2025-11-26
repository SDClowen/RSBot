using RSBot.Core;

namespace RSBot.Training.Bundle.Protection;

internal class ManaRecovery
{
    public static bool Active => PlayerConfig.Get<bool>("RSBot.Protection.checkUseSkillMP");
    public static int Value => PlayerConfig.Get("RSBot.Protection.numPlayerSkillMPMin", 50);
    public static uint SkillId => PlayerConfig.Get<uint>("RSBot.Protection.MpSkill");
    public static double Current => 100.0 * Game.Player.Mana / Game.Player.MaximumMana;
}
