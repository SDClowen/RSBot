using System.Linq;
using RSBot.Core;
using RSBot.Core.Components;
using RSBot.Core.Event;
using RSBot.Core.Objects;
using RSBot.Core.Objects.Spawn;
using RSBot.Trade.Components;

namespace RSBot.Trade.Bundle;

internal class AttackBundle
{
    /// <summary>
    ///     A value indicating if the bundle is busy attacking the selected target.
    /// </summary>
    public bool IsAttacking { get; private set; }

    /// <summary>
    ///     A value indicating if the bundle is busy and the execution of further commands should be paused.
    /// </summary>
    public bool Busy => IsAttacking;

    /// <summary>
    ///     Initializes the bundle
    /// </summary>
    public void Initialize()
    {
        IsAttacking = false;
    }

    /// <summary>
    ///     Starts the bundle
    /// </summary>
    public void Start()
    {
        IsAttacking = false;
    }

    /// <summary>
    ///     Ticks this bundle.
    ///     It will fire events to attack the selected enemy (if selected) or automatically select a new target according to
    ///     the settings.
    /// </summary>
    public void Tick()
    {
        if (!TradeBotbase.IsActive || Game.Player.HasActiveVehicle || Bundles.RouteBundle.TownscriptRunning)
        {
            IsAttacking = false;

            return;
        }

        if (TradeConfig.CastBuffs)
            EventManager.FireEvent("Bundle.Buff.Invoke");

        var target = Game.SelectedEntity;
        if (target is { IsMob: true, State.LifeState: LifeState.Alive } || (target is SpawnedPlayer
            {
                WearsJobSuite: true, Job: JobType.Thief, State.LifeState: LifeState.Alive
            } && TradeConfig.AttackThiefPlayers))
        {
            IsAttacking = true;

            EventManager.FireEvent("Bundle.Attack.Invoke");

            return;
        }

        if (target == null)
            IsAttacking = SelectNextTarget();
    }

    /// <summary>
    ///     Selects the next possible target
    /// </summary>
    /// <returns></returns>
    private bool SelectNextTarget()
    {
        //Is selected entity dead or behind obstacle? -> Deselect it
        if (Game.SelectedEntity is { State.LifeState: LifeState.Dead } or { IsBehindObstacle: true })
        {
            Game.SelectedEntity.TryDeselect();

            return false;
        }

        var target = Game.SelectedEntity;

        if (target != null && (target.IsMob || (target is SpawnedPlayer
            {
                WearsJobSuite: true, Job: JobType.Thief, State.LifeState: LifeState.Alive
            } && TradeConfig.AttackThiefPlayers)))
            return true;

        //Priority 1: Protect transport?
        if (TradeConfig.ProtectTransport
            && Game.Player.JobTransport != null)
            if (SpawnManager.TryGetEntity<SpawnedBionic>(Game.Player.JobTransport.UniqueId, out var bionic))
            {
                var attacker = bionic.GetAttackers()
                    .FirstOrDefault(a => a.IsBehindObstacle == false && a.State.LifeState == LifeState.Alive);

                if (attacker != null)
                    return attacker.TrySelect();
            }

        //Priority 2: Fight back
        if (TradeConfig.CounterAttack)
        {
            var attacker = Game.Player.GetAttackers()
                .FirstOrDefault(a => a.IsBehindObstacle == false && a.State.LifeState == LifeState.Alive);

            if (attacker != null)
                return attacker.TrySelect();
        }

        //Priority 4: Thief players
        if (TradeConfig.AttackThiefPlayers)
            if (SpawnManager.TryGetEntity<SpawnedPlayer>(
                    p => p.WearsJobSuite && p.Job == JobType.Thief && !p.IsBehindObstacle &&
                         p.State.LifeState == LifeState.Alive,
                    out var nearbyThiefPlayer))
                return nearbyThiefPlayer.TrySelect();

        //Priority 3: Thief NPCs
        if (TradeConfig.AttackThiefNpcs)
            if (SpawnManager.TryGetEntity<SpawnedMonster>(
                    m => m.IsMob && m.Record.TypeID4 == 2 && !m.IsBehindObstacle &&
                         m.State.LifeState == LifeState.Alive,
                    out var thiefMob))
                return thiefMob.TrySelect();

        return false;
    }

    /// <summary>
    ///     Stops the bundle.
    /// </summary>
    public void Stop()
    {
        IsAttacking = false;
    }
}