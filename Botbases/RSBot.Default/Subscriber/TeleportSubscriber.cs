using RSBot.Core;
using RSBot.Core.Event;
using RSBot.Default.Bundle;

namespace RSBot.Default.Subscriber;

internal class TeleportSubscriber
{
    /// <summary>
    ///     Subscribes the events.
    /// </summary>
    public static void SubscribeEvents()
    {
        EventManager.SubscribeEvent("OnTeleportComplete", OnTeleportComplete);
    }

    #region Event listeners

    /// <summary>
    ///     Will be triggered when an ingame teleportation was complete
    /// </summary>
    private static void OnTeleportComplete()
    {
        if (!Kernel.Bot.Running)
            return;

        if (Bundles.Loop.Running)
            Bundles.Loop.Stop();
    }

    #endregion Event listeners
}