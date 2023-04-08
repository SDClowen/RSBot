using System.IO.Compression;
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

        public void Initialize()
        {
        }

        public void Start()
        {

        }
        
        public void Tick()
        {
            if(TradeConfig.CastBuffs)
                EventManager.FireEvent("Bundle.Buff.Invoke");

            var target = Game.SelectedEntity;

            if (target == null)
            {
                IsAttacking = false;
                SelectNextTarget();

                return;
            }
            
            IsAttacking = true;
            EventManager.FireEvent("Bundle.Attack.Invoke");

            EventManager.FireEvent("Bundle.Loot.Invoke");
        }

        private void SelectNextTarget()
        {
            var target = Game.SelectedEntity;

            if (target is { IsAttackable: true })
                return;

            //Protect transport?
            if (TradeConfig.ProtectTransport 
                && Game.Player.JobTransport != null)
            {
                var bionic = SpawnManager.GetEntity<SpawnedBionic>(Game.Player.JobTransport.UniqueId);
                if (bionic != null)
                {
                    var attackers = bionic.GetAttackers();

                    var newTarget = attackers
                        .FirstOrDefault(m => m.IsAttackable);

                    if (newTarget != null)
                    {
                        newTarget.TrySelect();

                        return;
                    }
                }
            }

            //Fight back
            if (TradeConfig.CounterAttack)
            {
                var newTarget = Game.Player.GetAttackers().FirstOrDefault(m => m.IsAttackable);

                if (newTarget != null)
                {
                    newTarget.TrySelect();

                    return;
                }
            }
 
            //Thief NPCs
            if (TradeConfig.AttackThiefNpcs)
            {
                SpawnManager.TryGetEntities<SpawnedMonster>(m => m.Record.TypeID3 == 1 && m.Record.TypeID4 == 2,
                    out var thieves);

                if (thieves != null && thieves.Any())
                {
                    thieves.FirstOrDefault().TrySelect();

                    return;
                }

            }


            //Thief players
            if (TradeConfig.AttackThiefPlayers)
            {
                var nearbyPlayer =
                    SpawnManager.GetEntity<SpawnedPlayer>(p => p.WearsJobSuite && p.Job == JobType.Thief);

                if (nearbyPlayer != null)
                {
                    nearbyPlayer.TrySelect();
                 
                    return;
                }

            }

            
        }

        public void Stop()
        {
            IsAttacking = false;
        }
    }
}
