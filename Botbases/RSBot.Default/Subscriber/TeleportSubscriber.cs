using System.Threading.Tasks;
using RSBot.Core;
using RSBot.Core.Components;
using RSBot.Core.Event;
using RSBot.Training.Bundle;

namespace RSBot.Training.Subscriber
{
    internal class TeleportSubscriber
    {
        /// <summary>
        /// Subscribes the events.
        /// </summary>
        public static void SubscribeEvents()
        {
            EventManager.SubscribeEvent("OnTeleportComplete", OnTeleportComplete);
        }

        #region Event listeners

        /// <summary>
        /// Will be triggered when an ingame teleportation was complete
        /// </summary>
        private static void OnTeleportComplete()
        {
            if (!Kernel.Bot.Running) 
                return;

            if (!ScriptManager.Running)
                Task.Run(() => Bundles.Loop.Start());
        }

        #endregion Event listeners
    }
}