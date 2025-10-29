using RSBot.Core.Components;

namespace RSBot.Lure.Bundle;

internal static class AttackBundle
{
    /// <summary>
    /// Merkezi Saldırı Servisi'ni çağırarak saldırı mantığını yürütür.
    /// </summary>
    public static void Tick()
    {
        // Lure botunun kendine özgü saldırı koşulları burada kontrol edilebilir.
        // Örneğin, sadece belirli ayarlar aktifken saldırı servisini çağır.
        if (Components.LureConfig.UseAttackingSkills || Components.LureConfig.UseNormalAttack)
        {
            AttackService.Execute();
        }
    }
}
