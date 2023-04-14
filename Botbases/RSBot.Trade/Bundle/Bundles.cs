using System;
using RSBot.Core;
using RSBot.Core.Event;

namespace RSBot.Trade.Bundle;

internal static class Bundles
{
    public static TransportBundle TransportBundle { get; } = new();

    public static RouteBundle RouteBundle { get; } = new();

    public static AttackBundle AttackBundle { get; } = new();

    public static void Stop()
    {
        TransportBundle.Stop();
        AttackBundle.Stop();
        RouteBundle.Stop();

        EventManager.FireEvent("Bundle.Buff.Stop");
        EventManager.FireEvent("Bundle.Attack.Stop");
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

    public static void Tick()
    {
        try
        {
            AttackBundle.Tick();
            TransportBundle.Tick();
            RouteBundle.Tick();
        }
        catch (Exception e)
        {
            Log.Error($"[Trade] Error in bot loop: {e.Message}\n{e.StackTrace}");
        }
    }
}