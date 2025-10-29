using RSBot.Core.Components;

namespace RSBot.Default.Bundle.Buff;

internal class BuffBundle : IBundle
{
    private bool _buffBetweenAttacks;

    /// <summary>
    /// Merkezi Skill Yöneticisi'ni çağırarak eksik buff'ları tamamlar.
    /// </summary>
    public void Invoke()
    {
        // Ayarlara göre, saldırı arasında buff basma koşullarını kontrol et.
        if ((Game.Player.Untouchable || Game.Player.InAction) && !_buffBetweenAttacks)
            return;
        if ((Game.Player.Untouchable || Game.Player.Berzerking) && _buffBetweenAttacks)
            return;

        SkillManager.CastAvailableBuffs();
    }

    /// <summary>
    /// Ayarları yeniler.
    /// </summary>
    public void Refresh()
    {
        _buffBetweenAttacks = PlayerConfig.Get<bool>("RSBot.Skills.checkCastBuffsBetweenAttacks", false);
    }

    public void Stop()
    {
        // Durdurulduğunda yapılacak özel bir işlem yok.
    }
}
