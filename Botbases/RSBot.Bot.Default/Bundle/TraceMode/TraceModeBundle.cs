using System;
using System.Linq;
using RSBot.Core;
using RSBot.Core.Components;
using RSBot.Core.Objects;
using RSBot.Core.Objects.Spawn;

namespace RSBot.Bot.Default.Bundle.TraceMode
{
    public class TraceModeBundle : IBundle
    {
        public TraceModeConfig Config { get; set; }

        private SpawnedPlayer _toTracePlayer;
        private bool _tracing;

        public void Invoke()
        {
            
            if (!Config.Enabled)
                return;
            

            if (_toTracePlayer == null)
            {
                Refresh();
                FindTracePlayer();
                TracePlayer(_toTracePlayer.UniqueId);
                _tracing = true;
            }

            if (_tracing == false)
            {
                TracePlayer(_toTracePlayer.UniqueId);
            }
            
            if (Game.SelectedEntity != null)
                return;
            
            double distanceToPlayer;

            SpawnedMonster monster = GetNeareastEnemyToTracePlayer();

            switch (Config.TargetSameMob)
            {
                case  true:
                    if (!Game.Player.TargetSupport(_toTracePlayer.UniqueId))
                    {
                        Invoke();
                        _tracing = false;
                        return;
                    }

                    switch (Game.SelectedEntity)
                    {
                        case null:
                            Invoke();
                            _tracing = false;
                            break;
                        default:
                            if (Game.SelectedEntity.Entity.Record.TypeID3 == 1
                                && Game.SelectedEntity.Entity.State.LifeState != LifeState.Dead)
                            {
                                if (!IsInRadius(monster.Tracker.Position))
                                    return;


                                distanceToPlayer = monster.Tracker.Position.DistanceTo(Game.Player.Tracker.Position);
                                if (distanceToPlayer >= 80)
                                {
                                    Game.Player.Move(monster.Tracker.Position);
                                }

                                SpawnManager.TryGetEntities<SpawnedMonster>(out var monsters);
                                monster = monsters.First(mon => mon.UniqueId == Game.SelectedEntity.UniqueId);
                                Game.Player.SelectEntity(monster.UniqueId);
                                _tracing = false;
                                return;
                            }

                            Invoke();
                            break;
                    }    
                    break;
                
                case false:
                    
                    if (!IsInRadius(monster.Tracker.Position))
                        return;
                    
                    distanceToPlayer = monster.Tracker.Position.DistanceTo(Game.Player.Tracker.Position); 
                    if (distanceToPlayer >= 80)
                    {
                        Game.Player.Move(monster.Tracker.Position);
                    } 
                    
                    var selectedEntity = Game.Player.SelectEntity(monster.UniqueId); 
                    _tracing = false; 
                    if (!selectedEntity) 
                    {
                        _tracing = false; 
                        Invoke(); 
                    }
                    break;
            }
        }
        

    public void Refresh()
        {
            Config = new TraceModeConfig
            {
                Enabled = PlayerConfig.Get<bool>("RSBot.TraceMode.Enabled"),
                TargetSameMob = PlayerConfig.Get<bool>("RSBot.TraceMode.TargetSameMob"),
                Radius = PlayerConfig.Get<int>("RSBot.TraceMode.Radius"),
                TracePlayerName = PlayerConfig.Get<String>("RSBot.TraceMode.Playername")
            };

            _tracing = false;

        }

    private void FindTracePlayer()
        {
            if (!SpawnManager.TryGetEntities<SpawnedPlayer>(out var players,
                p => p.Name == Config.TracePlayerName))
                return ;

            _toTracePlayer = players.First(player => player.Name == Config.TracePlayerName);
        }

    private bool TracePlayer(uint uniqueId)
        {
            Log.Notify("[Trace Mode] Tracing Player");
            _tracing = Game.Player.StartTrace(uniqueId);
            return _tracing;
        }

    private SpawnedMonster GetNeareastEnemyToTracePlayer()
        {
            if (!SpawnManager.TryGetEntities<SpawnedMonster>(out var entities, 
                m => m.State.LifeState != LifeState.Dead 
                     && m.IsBehindObstacle == false &&
                !Bundles.Avoidance.AvoidMonster(m.Rarity)))
                return default(SpawnedMonster);

            return entities.OrderBy(m => m.Tracker?.Position.DistanceTo(_toTracePlayer.Tracker.Position))
                .OrderByDescending(m => m.AttackingPlayer)
                .OrderByDescending(m => Bundles.Avoidance.PreferMonster(m.Rarity))
                .FirstOrDefault();
        }

    private bool IsInRadius(Position mobPostion)
        {
            var distanceToTracePlayer = _toTracePlayer.Tracker.Position.DistanceTo(mobPostion);
            if (distanceToTracePlayer > Config.Radius)
                return false;
            return true;
        }
        
    }
}