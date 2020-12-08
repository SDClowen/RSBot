using RSBot.Core.Components;
using RSBot.Core.Event;
using RSBot.Core.Plugins;

namespace RSBot.Core
{
    public class Bot
    {
        /// <summary>
        /// Gets the base.
        /// </summary>
        /// <value>
        /// The base.
        /// </value>
        public IBotbase Botbase { get; private set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Bot"/> is running.
        /// </summary>
        /// <value>
        ///   <c>true</c> if running; otherwise, <c>false</c>.
        /// </value>
        public bool Running { get; private set; }

        /// <summary>
        /// Gets a value indicating whether this instance is starting.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is starting; otherwise, <c>false</c>.
        /// </value>
        public bool IsStarting { get; private set; }

        /// <summary>
        /// Gets a value indicating whether this instance is stopping.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is stopping; otherwise, <c>false</c>.
        /// </value>
        public bool IsStopping { get; private set; }

        /// <summary>
        /// Sets the botbase.
        /// </summary>
        /// <param name="botBase">The bot base.</param>
        public void SetBotbase(IBotbase botBase)
        {
            Botbase = botBase;
            Botbase.Initialize();

            EventManager.FireEvent("OnSetBotbase");
        }

        /// <summary>
        /// Starts this instance.
        /// </summary>
        public void Start()
        {
            if (Running || Botbase == null) return;

            Log.Notify($"Starting bot {Botbase.Info.Name}");

            IsStarting = true;

            Running = true;
            Botbase.Start();

            IsStarting = false;

            EventManager.FireEvent("OnStartBot");

            while (Running)
                Botbase.Tick();
        }

        /// <summary>
        /// Stops this instance.
        /// </summary>
        public void Stop()
        {
            if (!Running || Botbase == null) return;

            EventManager.FireEvent("OnStopBot");
            Log.Notify($"Stopping bot {Botbase.Info.Name}");

            IsStopping = true;

            ScriptManager.Stop();
            ShoppingManager.Stop();
            PickupManager.Stop();

            Botbase.Stop();

            Running = false;
            IsStopping = false;
        }
    }
}