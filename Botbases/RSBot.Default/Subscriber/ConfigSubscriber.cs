using RSBot.Default.Bundle;
using RSBot.Core.Event;

namespace RSBot.Default.Subscriber
{
    internal class ConfigSubscriber
    {
        /// <summary>
        /// Subscribes the events.
        /// </summary>
        public static void SubscribeEvents()
        {
            EventManager.SubscribeEvent("OnSavePlayerConfig", OnSavePlayerSettings);
        }

        /// <summary>
        /// Configurations the subscriber on save player settings.
        /// </summary>
        private static void OnSavePlayerSettings()
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
}