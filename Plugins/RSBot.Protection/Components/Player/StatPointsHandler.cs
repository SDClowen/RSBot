using RSBot.Core;
using RSBot.Core.Event;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace RSBot.Protection.Components.Player
{
    public class StatPointsHandler
    {
        public static bool CancellationRequested;

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        public static void Initialize()
        {
            SubscribeEvents();
        }

        /// <summary>
        /// Subscribes the events.
        /// </summary>
        private static void SubscribeEvents()
        {
            EventManager.SubscribeEvent("OnLevelUp", new Action<byte>(OnPlayerLevelUp));
        }

        /// <summary>
        /// Cores the on player level up.
        /// </summary>
        private static void OnPlayerLevelUp(byte oldLevel)
        {
            var enabledIfBotIsStopped = PlayerConfig.Get<bool>("RSBot.Protection.checkIncBotStopped");
            if (!Kernel.Bot.Running && !enabledIfBotIsStopped)
                return;

            var levelUps = Game.Player.Level - oldLevel;

            Task.Run(() => IncreaseStatPoints(levelUps));
        }

        public static void IncreaseStatPoints(int stepCount)
        {
            var incStr = PlayerConfig.Get<bool>("RSBot.Protection.checkIncStr");
            var incInt = PlayerConfig.Get<bool>("RSBot.Protection.checkIncInt");

            var numStr = PlayerConfig.Get<int>("RSBot.Protection.numIncStr", 0);
            var numInt = PlayerConfig.Get<int>("RSBot.Protection.numIncInt", 0);

            for (var iLevelUp = 0; iLevelUp < stepCount; iLevelUp++)
            {
                if (CancellationRequested) return;
                if (incStr && numStr > 0)
                {
                    for (var i = 0; i < numStr; i++)
                    {
                        if (CancellationRequested) return;

                        Log.Notify($"Auto. increasing stat STR to {Game.Player.Strength + 1}");

                        Game.Player.IncreaseStr();

                        //Make sure the user has time to cancel, otherwise it's just too fast (but would still work due to the callback await)
                        Thread.Sleep(500);
                    }
                }

                if (incInt && numInt > 0)
                {
                    for (var i = 0; i < numInt; i++)
                    {
                        if (CancellationRequested) return;

                        Log.Notify($"Auto. increasing stat INT to {Game.Player.Intelligence + 1}");

                        Game.Player.IncreaseInt();

                        Thread.Sleep(500);
                    }
                }
            }
        }
    }
}