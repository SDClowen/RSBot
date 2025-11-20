using RSBot.Core;
using RSBot.Core.Event;
using RSBot.Training.Bundle;

namespace RSBot.Training.Subscriber;

internal class TeleportSubscriber
{
    /// <summary>
    ///     Subscribes the events.
    /// </summary>
    public static void SubscribeEvents()
    {
        EventManager.SubscribeEvent("OnTeleportStart", OnTeleportStart);
        EventManager.SubscribeEvent("OnTeleportComplete", OnTeleportComplete);
    }

    #region Event listeners

    /// <summary>
    ///     Will be triggered when an ingame teleportation was started
    /// </summary>
    private static void OnTeleportStart()
    {
        if (!Kernel.Bot.Running)
            return;

        if (Bundles.Loop.Running)
            Bundles.Loop.Stop();
    }

    /// <summary>
    ///     Will be triggered when an ingame teleportation was complete
    /// </summary>
    private static void OnTeleportComplete()
    {
        if (!Kernel.Bot.Running)
            return;
    }

    #endregion Event listeners
}
