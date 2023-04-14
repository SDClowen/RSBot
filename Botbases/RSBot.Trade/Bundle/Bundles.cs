using System;
using Microsoft.VisualBasic.Logging;
using RSBot.Core.Event;
using Log = RSBot.Core.Log;

namespace RSBot.Trade.Bundle
{
    internal static class Bundles
    {
        public static TransportBundle TransportBundle { get; } = new ();
        public static RouteBundle RouteBundle { get; } = new ();
        public static AttackBundle AttackBundle { get; } = new ();

        public static void Tick()
        {
            try
            {
                TransportBundle.Tick();
                AttackBundle.Tick();
                RouteBundle.Tick();
            }
            catch (Exception e)
            {
                Log.Warn($"[Trade] Error while bot loop: {e.Message}\n{e.StackTrace}");
            }
        }

        public static void Stop()
        {
            TransportBundle.Stop();
            AttackBundle.Stop();
            RouteBundle.Stop();
        }

        public static void Initialize()
        {
            TransportBundle.Initialize();
            RouteBundle.Initialize();
            AttackBundle.Initialize();
        }

        public static void Start()
        {
            TransportBundle.Start();
            AttackBundle.Start(); 
            RouteBundle.Start();
        }
    }
}
