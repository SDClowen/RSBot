using RSBot.Core;
using RSBot.Core.Components;
using RSBot.Core.Objects;

namespace RSBot.Training.Bundle.Attack;

internal class AttackBundle : IBundle
{
    /// <summary>
    ///     The last tick count for checking func call
    /// </summary>
    private int _lastTick = Kernel.TickCount;

    /// <summary>
    ///     Invokes this instance.
    /// </summary>
    public void Invoke()
    {
        if (Game.SelectedEntity == null || !Game.Player.CanAttack)
            return;

        if (Game.SelectedEntity.IsBehindObstacle)
        {
            Log.Debug("Deselecting entity because it moved behind an obstacle!");

            if (Game.Player.InAction)
                SkillManager.CancelAction();

            Game.SelectedEntity?.TryDeselect();
            Game.SelectedEntity = null;

            return;
        }

        var dontFollowMobs = PlayerConfig.Get<bool>("RSBot.Training.checkBoxDontFollowMobs");
        if (dontFollowMobs && !Kernel.Bot.Botbase.Area.IsInSight(Game.SelectedEntity))
        {
            Log.Debug("Deselecting entity because it moved far away from training area!");

            if (Game.Player.InAction)
                SkillManager.CancelAction();

            Game.SelectedEntity?.TryDeselect();
            Game.SelectedEntity = null;

            return;
        }

        if (
            SkillManager.ImbueSkill != null
            && !Game.Player.State.HasActiveBuff(SkillManager.ImbueSkill, out _)
            && SkillManager.ImbueSkill.CanBeCasted
        )
            SkillManager.ImbueSkill.Cast(buff: true);

        if (Kernel.TickCount - _lastTick < 500)
            return;

        _lastTick = Kernel.TickCount;

        //if (Game.Player.InAction && !SkillManager.IsLastCastedBasic)
        //  return;

        var useTeleportSkill = PlayerConfig.Get("RSBot.Skills.checkUseTeleportSkill", false);
        if (useTeleportSkill && CastTeleportation())
            return;

        //var stopwatch = System.Diagnostics.Stopwatch.StartNew();

        var skill = SkillManager.GetNextSkill();

        //Log.Debug($"Getnextskill: {stopwatch.ElapsedMilliseconds} Action:{Game.Player.InAction} Entity:{Game.SelectedEntity != null} LA:{SkillManager.IsLastCastedBasic} Skill:{skill}");

        if (!Game.Player.InAction)
            Log.Status("Attacking");

        if (skill == null)
        {
            if (Game.Player.InAction)
                return;

            if (PlayerConfig.Get("RSBot.Skills.checkUseDefaultAttack", true))
                SkillManager.CastAutoAttack();

            return;
        }

        if (Game.Player.InAction && SkillManager.IsLastCastedBasic)
            SkillManager.CancelAction();

        var uniqueId = Game.SelectedEntity?.UniqueId;
        if (uniqueId == null)
            return;

        skill?.Cast(uniqueId.Value);
    }

    /// <summary>
    ///     Refreshes this instance.
    /// </summary>
    public void Refresh()
    {
        //Nothing to do here
    }

    public void Stop()
    {
        //Nothing to do
    }

    /// <summary>
    ///     Casts the teleportation skill if it's set up.
    /// </summary>
    /// <returns></returns>
    private bool CastTeleportation()
    {
        if (SkillManager.TeleportSkill?.CanBeCasted != true || Game.SelectedEntity?.State.LifeState != LifeState.Alive)
            return false;

        var distanceToMonster = Game.SelectedEntity?.DistanceToPlayer;
        var availableDistance = SkillManager.TeleportSkill.Record.Params[3] / 10;

        if (availableDistance <= 0)
        {
            Log.Warn("The selected teleportation skill does not have a distance. Is this really a teleport skill?");
        }
        else
        {
            var distanceAfterCasting = distanceToMonster - availableDistance;
            if (distanceAfterCasting < 0)
                distanceAfterCasting *= -1;

            if (distanceAfterCasting < distanceToMonster)
            {
                SkillManager.TeleportSkill.CastAt(Game.SelectedEntity.Position);

                Log.Debug(
                    $"Used teleportation skill [{SkillManager.TeleportSkill.Record.GetRealName()}] (before: {distanceToMonster}m, after: {distanceAfterCasting}m, traveled: {availableDistance}m)"
                );

                return true;
            }
        }

        return false;
    }
}
