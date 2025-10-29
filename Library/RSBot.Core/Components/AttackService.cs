using RSBot.Core.Objects;

namespace RSBot.Core.Components;

/// <summary>
/// Oyun içi saldırı mantığını merkezileştiren ve yöneten servis.
/// Bu sınıf, farklı bot türleri arasında tekrar eden saldırı kodunu ortadan kaldırmak için tasarlanmıştır.
/// </summary>
public static class AttackService
{
    /// <summary>
    /// Mevcut hedefe yönelik saldırı döngüsünü yürütür.
    /// Bu metot, hedefin geçerliliğini kontrol eder, büyüleri (imbue) uygular,
    /// teleport yeteneklerini kullanır ve en uygun saldırı yeteneğini seçip uygular.
    /// </summary>
    public static void Execute()
    {
        // Hedef yoksa veya oyuncu saldıramaz durumdaysa işlem yapma.
        if (Game.SelectedEntity == null || !Game.Player.CanAttack)
            return;

        // Hedef bir engelin arkasındaysa, hedefi bırak ve işlemi sonlandır.
        if (Game.SelectedEntity.IsBehindObstacle)
        {
            if (Game.Player.InAction)
                SkillManager.CancelAction();

            Game.SelectedEntity?.TryDeselect();
            Game.SelectedEntity = null;
            return;
        }

        // Büyü (Imbue) yeteneği ayarlanmışsa ve aktif değilse, kullan.
        if (SkillManager.ImbueSkill != null &&
            !Game.Player.State.HasActiveBuff(SkillManager.ImbueSkill, out _) &&
            SkillManager.ImbueSkill.CanBeCasted)
        {
            SkillManager.ImbueSkill.Cast(buff: true);
        }

        // Oyuncu meşgul değilse bir sonraki saldırı adımına geç.
        if (Game.Player.InAction) return;

        // Ayarlanmışsa ve mümkünse hedefe ışınlanma yeteneğini kullan.
        if (PlayerConfig.Get("RSBot.Skills.checkUseTeleportSkill", false) && CastTeleportation())
            return;

        // Bir sonraki en uygun saldırı yeteneğini al.
        var skill = SkillManager.GetNextSkill();

        // Yetenek yoksa ve normal saldırı ayarı açıksa, normal saldırı yap.
        if (skill == null)
        {
            if (PlayerConfig.Get("RSBot.Skills.checkUseDefaultAttack", true))
                SkillManager.CastAutoAttack();

            return;
        }

        // Hedefin kimliğine (ID) yeteneği kullan.
        var uniqueId = Game.SelectedEntity?.UniqueId;
        if (uniqueId != null)
        {
            skill.Cast(uniqueId.Value);
            Log.Status("Attacking");
        }
    }

    /// <summary>
    /// Ayarlanmışsa ve mesafesi uygunsa hedefe doğru ışınlanma yeteneğini kullanır.
    /// </summary>
    /// <returns>Işınlanma yeteneği kullanıldıysa true, aksi takdirde false.</returns>
    private static bool CastTeleportation()
    {
        if (SkillManager.TeleportSkill?.CanBeCasted != true || Game.SelectedEntity?.State.LifeState != LifeState.Alive)
            return false;

        var distanceToMonster = Game.SelectedEntity?.DistanceToPlayer ?? 0;
        var availableDistance = SkillManager.TeleportSkill.Record.Params[3] / 10;

        if (availableDistance <= 0) return false;

        var distanceAfterCasting = distanceToMonster - availableDistance;
        if (distanceAfterCasting < 0)
            distanceAfterCasting *= -1;

        if (distanceAfterCasting < distanceToMonster)
        {
            SkillManager.TeleportSkill.CastAt(Game.SelectedEntity.Position);
            return true;
        }

        return false;
    }
}
