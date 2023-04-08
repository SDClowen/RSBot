using System;
using System.Linq;
using RSBot.Core;
using RSBot.Core.Components;
using RSBot.Core.Event;
using RSBot.Core.Objects.Spawn;
using RSBot.Trade.Components;

namespace RSBot.Trade.Bundle
{
    internal class TransportBundle
    {
        public bool WaitingForTransport { get; private set; }

        public bool TransportStuck { get; private set; }

        public bool TransportUnderAttack { get; private set; }

        public void Initialize()
        {
            SubscribeEvents();
        }

        public void Start()
        {
            CheckVehicleDistance();
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
            Log.Debug("[Trade] Your transport is stuck! Go back to your transport and try to unstuck it.");
            Game.ShowNotification("[Trade] Your transport is stuck! Go back to your transport and try to unstuck it.");
            TransportStuck = true;
        }


        public void Tick()
        {
            //Summon new transport?
            if (Game.Player.JobTransport == null)
            {
                if (Game.Player.InCombat)
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

            if (Game.Player.HasActiveVehicle)
                Game.Player.Vehicle.Dismount();

            //Wait for the transport?
            CheckVehicleDistance();
            CheckVehicleUnderAttack();

            if (Game.Player.Vehicle != null)
                Game.Player.Vehicle.Dismount();
        }

        /// <summary>
        /// Checks the vehicle distance to the player.
        /// </summary>s
        private void CheckVehicleDistance()
        {
            if (Game.Player.JobTransport == null)
            {
                WaitingForTransport = true;

                Log.Debug("[Trade] Waiting for job transport to spawn.");

                return;
            }

            var dest = Game.Player.Movement.HasDestination
                ? Game.Player.Movement.Destination
                : Game.Player.Movement.Source;

            if (TransportStuck && !Game.Player.Movement.HasDestination && Game.Player.JobTransport.IsBehindObstacle)
            {
                Game.Player.MoveTo(Game.Player.JobTransport.Position);

                return;
            }

            if (dest.DistanceTo(Game.Player.JobTransport.Position) > 10 
                && Game.Player.JobTransport.Movement.HasDestination //only if transport is currently moving
                && !Game.Player.JobTransport.IsBehindObstacle)
            {
                Log.Debug("[Trade] Waiting for job transport to come closer to player.");

                ScriptManager.Pause();
                WaitingForTransport = true;

                return;
            }

            TransportStuck = CollisionManager.HasCollisionBetween(dest, Game.Player.JobTransport.Position);
            WaitingForTransport = false;

            if (ScriptManager.IsPaused)
                ScriptManager.RunScript();
        }

        /// <summary>
        /// Checks if the vehicle is under attack
        /// </summary>
        public void CheckVehicleUnderAttack()
        {
            if (Game.Player.JobTransport == null)
                return;

            var bionic = SpawnManager.GetEntity<SpawnedBionic>(Game.Player.JobTransport.UniqueId);
            if (bionic == null)
                return;
            
            var attackers = bionic.GetAttackers();

            if (attackers.Count == 0)
                return;

            if (!TradeConfig.ProtectTransport)
                return;
            
            if (!ScriptManager.IsPaused)
                ScriptManager.Pause();
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
