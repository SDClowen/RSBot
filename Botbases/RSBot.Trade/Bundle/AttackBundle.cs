using System.Linq;
using RSBot.Core;
using RSBot.Core.Components;
using RSBot.Core.Event;
using RSBot.Core.Objects;
using RSBot.Core.Objects.Spawn;
using RSBot.Trade.Components;

namespace RSBot.Trade.Bundle
{
    internal class AttackBundle
    {
        public bool IsAttacking { get; private set; }

        public bool BlockProgression => IsAttacking;

        public void Initialize()
        {
            IsAttacking = false;
        }

        public void Start()
        {
            
        }
        
        public void Tick()
        {
            if (!TradeBotbase.IsActive || Game.Player.HasActiveVehicle || Bundles.RouteBundle.TownscriptRunning)
            {
                IsAttacking = false;

                return;
            }
            
            IsAttacking = true;

            if (TradeConfig.CastBuffs)
                EventManager.FireEvent("Bundle.Buff.Invoke");
            
            var target = Game.SelectedEntity;
            if (target is { IsMob: true } or { AttackingPlayer: true})
            {
                EventManager.FireEvent("Bundle.Attack.Invoke");

                return;
            }

            if (target == null)
                IsAttacking = SelectNextTarget();
        }

        private bool SelectNextTarget()
        {
            var target = Game.SelectedEntity;

            if (target != null && (target.IsMob || target is SpawnedPlayer {WearsJobSuite: true, Job: JobType.Thief} && TradeConfig.AttackThiefPlayers))
                return true;

            //Priority 1: Protect transport?
            if (TradeConfig.ProtectTransport 
                && Game.Player.JobTransport != null)
            {
                if (SpawnManager.TryGetEntity<SpawnedBionic>(Game.Player.JobTransport.UniqueId, out var bionic))
                {
                    var attacker = bionic.GetAttackers().FirstOrDefault();

                    if (attacker != null)
                        return attacker.TrySelect();
                }
            }

            //Priority 2: Fight back
            if (TradeConfig.CounterAttack)
            {
                var attacker = Game.Player.GetAttackers().FirstOrDefault();

                if (attacker != null)
                    return attacker.TrySelect();
            }
 
            //Priority 3: Thief NPCs
            if (TradeConfig.AttackThiefNpcs)
            {
                if (!SpawnManager.TryGetEntity<SpawnedMonster>(m => m.IsMob && m.Record.TypeID4 == 2,
                        out var thiefMob))
                    return false;

                return thiefMob.TrySelect();
            }

            //Priority 4: Thief players
            if (TradeConfig.AttackThiefPlayers)
            {
                if (!SpawnManager.TryGetEntity<SpawnedPlayer>(p => p.WearsJobSuite && p.Job == JobType.Thief,
                        out var nearbyThiefPlayer))
                    return false;

                return nearbyThiefPlayer.TrySelect();
            }

            return false;
        }

        public void Stop()
        {
            IsAttacking = false;
        }
    }
}
