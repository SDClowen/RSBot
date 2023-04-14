using System;
using System.Linq;
using RSBot.Core;
using RSBot.Core.Components;
using RSBot.Core.Event;
using RSBot.Core.Objects;
using RSBot.Core.Objects.Spawn;
using RSBot.Trade.Components;

namespace RSBot.Trade.Bundle
{
    internal class TransportBundle
    {
        public bool WaitingForTransport { get; private set; }

        public bool TransportStuck { get; private set; }

        public bool WaitingForHunter { get; private set; }

        public bool BlockProgression => WaitingForTransport || TransportStuck || WaitingForHunter;

        public void Initialize()
        {
            SubscribeEvents();
        }

        public void Start()
        {
            CheckVehicleDistance();
            CheckHunterNearby();
            CheckVehicleUnderAttack();
        }

        private void SubscribeEvents()
        {
            EventManager.SubscribeEvent("OnJobCosStuck", new Action<byte>(OnJobCosStuck));
        }

        private void OnJobCosStuck(byte reason)
        {
            if (TransportStuck)
                return;

            //ToDO: Better unstack mechanic for trade transports.
            Log.Warn("[Trade] Your transport is stuck! Go back to your transport and try to unstuck it.");
            Game.ShowNotification("[RSBot] Your transport is stuck! Go back to your transport and try to unstuck it.");
            TransportStuck = true;
        }

        public void Tick()
        {
            //Summon new transport?
            if (Game.Player.JobTransport == null)
            {
                if (Game.Player.GetAttackers().Count > 0)
                    return;

                var jobTransportItem = Game.Player.Inventory.GetNormalPartItems(i => i.Record.CodeName.Contains("COS_T_") && i.Record.Tid == 4588)
                    .FirstOrDefault();

                if (jobTransportItem != null)
                {
                    Log.Notify($"[Trade] Summoning transport [{jobTransportItem.Record.GetRealName()}]");
                    jobTransportItem.Use();

                    return;
                }

                Log.Warn("[Trade] Can not summon transport: No transport scroll in player inventory.");

                Kernel.Bot.Stop();

                return;
            }
            
            //Wait for the transport?
            if (!CheckVehicleDistance() || !CheckHunterNearby() || !CheckVehicleUnderAttack())
                return;

            if (TradeConfig.MountTransport && !Game.Player.HasActiveVehicle && Game.Player.GetAttackers().Count == 0)
            {
                if (Game.Player.JobTransport.IsBehindObstacle ||
                    Game.Player.JobTransport.Position.DistanceToPlayer() > 5)
                {

                    Game.Player.MoveTo(Game.Player.JobTransport.Position);
                    WaitingForTransport = true;

                    return;
                }

                Log.Notify("[Trade] Mounting transport");

                Game.Player.JobTransport.Mount();
            } else if (!TradeConfig.MountTransport && Game.Player.HasActiveVehicle &&
                       Game.Player.Vehicle.UniqueId == Game.Player.JobTransport.UniqueId)
                Game.Player.JobTransport.Dismount();
        }

        /// <summary>
        /// Returns a value indicating if a hunter is nearby.
        /// </summary>
        /// <returns></returns>
        private bool CheckHunterNearby()
        {
            var hunterNearby =  !TradeConfig.WaitForHunter || SpawnManager.TryGetEntity<SpawnedPlayer>(
                p => p.WearsJobSuite && p.Job == JobType.Hunter,
                out var _);

            WaitingForHunter = !hunterNearby;

            return hunterNearby;
        }

        /// <summary>
        /// Checks the vehicle distance to the player.
        /// </summary>s
        private bool CheckVehicleDistance()
        {
            if (Game.Player.JobTransport == null)
            {
                WaitingForTransport = true;

                Log.Debug("[Trade] Waiting for job transport to spawn.");

                return false;
            }

            //Player is mounted 
            if (Game.Player.HasActiveVehicle && Game.Player.Vehicle.UniqueId == Game.Player.JobTransport.UniqueId)
            {
                WaitingForTransport = false;
                TransportStuck = false;

                return true;
            }

            TransportStuck = Game.Player.JobTransport.IsBehindObstacle;
            
            var dest = Game.Player.Movement.HasDestination
                ? Game.Player.Movement.Destination
                : Game.Player.Movement.Source;

            if (TransportStuck && !Game.Player.Movement.HasDestination)
            {
                Game.Player.MoveTo(Game.Player.JobTransport.Position);
                
                return false;
            }

            if (Game.Player.Position.DistanceTo(Game.Player.JobTransport.Position) > TradeConfig.MaxTransportDistance 
                && Game.Player.JobTransport.Movement.HasDestination //only if transport is currently moving
                && !Game.Player.JobTransport.IsBehindObstacle)
            {
                Log.Debug("[Trade] Waiting for job transport to come closer to player.");
                
                WaitingForTransport = true;

                return false;
            }

            TransportStuck = CollisionManager.HasCollisionBetween(dest, Game.Player.JobTransport.Position);
            WaitingForTransport = false;

            return true;
        }

        /// <summary>
        /// Checks if the vehicle is under attack
        /// </summary>
        public bool CheckVehicleUnderAttack()
        {
            if (!TradeConfig.ProtectTransport)
                return true;

            if (Game.Player.JobTransport == null)
                return true;

            if(!SpawnManager.TryGetEntity<SpawnedBionic>(Game.Player.JobTransport.UniqueId, out var bionic))
               return true;
 
            return bionic.GetAttackers().Count == 0;
        }

        /// <summary>
        /// Stops this instance.
        /// </summary>
        public void Stop()
        {
            WaitingForTransport = false;
        }
    }
}
