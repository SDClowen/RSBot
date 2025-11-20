using RSBot.Core.Event;
using RSBot.Training.Bundle;

namespace RSBot.Training.Subscriber;

internal class ConfigSubscriber
{
    /// <summary>
    ///     Subscribes the events.
    /// </summary>
    public static void SubscribeEvents()
    {
        EventManager.SubscribeEvent("OnEnterGame", ReloadSettings);
        EventManager.SubscribeEvent("OnSavePlayerConfig", ReloadSettings);
    }

    /// <summary>
    ///     Configurations the subscriber on save player settings.
    /// </summary>
    private static void ReloadSettings()
    {
        if (Container.Lock == null || Container.Bot == null)
            return;

        lock (Container.Lock)
        {
            //Reload the botbase config
            Container.Bot.Reload();

            //Reload all bundles to apply the new configuration
            Bundles.Reload();
        }
    }
}
