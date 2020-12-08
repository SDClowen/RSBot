using RSBot.Bot.Default.Bundle;
using RSBot.Core;
using RSBot.Core.Components;
using RSBot.Core.Event;
using System.Threading.Tasks;

namespace RSBot.Bot.Default.Subscriber
{
    internal class TeleportSubscriber
    {
        #region Delegates

        public delegate void OnTeleportCompleteEventHandler();

        private static event OnTeleportCompleteEventHandler OnTeleportComplete;

        #endregion Delegates

        /// <summary>
        /// Subscribes the events.
        /// </summary>
        public static void SubscribeEvents()
        {
            OnTeleportComplete += TeleportSubscriber_OnTeleportComplete;
            EventManager.SubscribeEvent("OnTeleportComplete", OnTeleportComplete);
        }

        #region Event listeners

        /// <summary>
        /// Will be triggered when an ingame teleportation was complete
        /// </summary>
        private static void TeleportSubscriber_OnTeleportComplete()
        {
            if (!Kernel.Bot.Running) return;
            if (!ScriptManager.Running)
                Task.Run(() => Bundles.Loop.Start());
        }

        #endregion Event listeners
    }
}