using System;
using System.Linq;
using RSBot.Core;
using RSBot.Core.Components;
using RSBot.Core.Event;

namespace RSBot.Trade.Bundle
{
    internal class TransportBundle
    {
        public bool WaitingForTransport { get; private set; }

        public bool TransportStuck { get; private set; }

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
            //ToDO: Better unstack mechanic for trade transports.
            Log.Debug("[Trade] Your transport is stuck! Go back to your transport and try to unstuck it.");
            Game.ShowNotification("[Trade] Your transport is stuck! Go back to your transport and try to unstuck it.");
            TransportStuck = true;
        }

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

            if (dest.DistanceTo(Game.Player.JobTransport.Position) > 30 && !TransportStuck)
            {
                Log.Debug("[Trade] Waiting for job transport to come closer to player.");

                WaitingForTransport = true;

                return;
            }

            TransportStuck = CollisionManager.HasCollisionBetween(dest, Game.Player.JobTransport.Position);
            WaitingForTransport = false;
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
            
            //Wait for the transport?
            CheckVehicleDistance();
        }

        public void Stop()
        {
            WaitingForTransport = false;
        }
    }
}
