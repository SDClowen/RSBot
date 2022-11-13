using RSBot.Core;
using RSBot.Core.Components;
using RSBot.Core.Objects.Spawn;
using RSBot.Lure.Components;

namespace RSBot.Lure.Bundle;

internal class TargetBundle
{
    public static void Tick()
    {
        if (!LureConfig.UseAttackingSkills && !LureConfig.UseNormalAttack)
            return;

        SpawnManager.TryGetEntity<SpawnedMonster>(
            f => f.AttackingPlayer == false
                 && Game.SelectedEntity?.UniqueId != f.UniqueId
                 && f.Position.DistanceTo(LureConfig.Area.Position) > 15
                 && f.Position.DistanceTo(LureConfig.Area.Position) <= LureConfig.Area.Radius,
            out var mob);

        if (Game.Player.InAction)
            SkillManager.CancelAction();

        mob?.TrySelect();
    }
}