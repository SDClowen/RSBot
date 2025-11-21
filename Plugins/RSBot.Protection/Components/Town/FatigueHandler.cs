using System;
using System.Threading;
using RSBot.Core;
using RSBot.Core.Event;

namespace RSBot.Protection.Components.Town;

public class FatigueHandler : AbstractTownHandler
{
    public static int ShardFatigueFullExpSeconds { get; set; }

    private static Timer _disconnectTimer;

    /// <summary>
    ///     Initializes this instance.
    /// </summary>
    public static void Initialize()
    {
        EventManager.SubscribeEvent("OnFatigueTimeUpdate", OnFatigueTimeUpdate);
        EventManager.SubscribeEvent("OnAgentServerDisconnected", OnAgentServerDisconnected);
    }

    private static void OnFatigueTimeUpdate()
    {
        _disconnectTimer?.Dispose();
        _disconnectTimer = null;

        int shardFatigueSecondsToDC = PlayerConfig.Get<int>("RSBot.Protection.numShardFatigueMinToDC") * 60;

        int secondsToDC = ShardFatigueFullExpSeconds - shardFatigueSecondsToDC;

        if (secondsToDC <= 0)
        {
            Log.WarnLang("FatigueTimeExceeded");
            return;
        }

        if (Kernel.Bot.Running && PlayerConfig.Get<bool>("RSBot.Protection.checkShardFatigue"))
        {
            TimeSpan remaining = TimeSpan.FromSeconds(secondsToDC);
            Log.Debug(
                $"You will be teleported and disconnected after {remaining.Hours}hr {remaining.Minutes}min {remaining.Seconds}s"
            );
        }

        _disconnectTimer = new Timer(
            _ =>
            {
                ReturnToTown();
            },
            null,
            secondsToDC * 1000,
            Timeout.Infinite
        );
    }

    private static void ReturnToTown()
    {
        if (!Kernel.Bot.Running)
        {
            Log.WarnLang("FatigueBotIsNotRunning");
            return;
        }

        if (!PlayerConfig.Get<bool>("RSBot.Protection.checkShardFatigue"))
            return;

        Kernel.Bot.Stop();
        Game.Player.UseReturnScroll();
        Log.WarnLang("ReturnToTownAndDC");

        Thread.Sleep(40000); // for slowest return scrolls and teleportation lag
        Kernel.Proxy?.Shutdown();
    }

    private static void OnAgentServerDisconnected()
    {
        _disconnectTimer?.Dispose();
        _disconnectTimer = null;
    }
}
