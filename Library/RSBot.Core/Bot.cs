﻿using RSBot.Core.Components;
using RSBot.Core.Event;
using RSBot.Core.Plugins;
using System.Threading;
using System.Threading.Tasks;

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
        public volatile bool Running;

        /// <summary>
        /// Gets or sets to the <see cref="CancellationToken"/>
        /// </summary>
        public CancellationTokenSource TokenSource;

        /// <summary>
        /// Sets the botbase.
        /// </summary>
        /// <param name="botBase">The bot base.</param>
        public void SetBotbase(IBotbase botBase)
        {
            Botbase = botBase;
            Botbase.Initialize();

            EventManager.FireEvent("OnSetBotbase", botBase);
        }

        /// <summary>
        /// Starts this instance.
        /// </summary>
        public void Start()
        {
            if (Running || Botbase == null) 
                return;

            TokenSource = new CancellationTokenSource();

            Task.Factory.StartNew(async (e) => 
            {
                Running = true;

                EventManager.FireEvent("OnStartBot");
                Botbase.Start();

                while (!TokenSource.IsCancellationRequested)
                {
                    Botbase.Tick();
                    
                    await Task.Delay(100);
                }
            },
            TokenSource.Token, TaskCreationOptions.LongRunning);
        }

        /// <summary>
        /// Stops this instance.
        /// </summary>
        public void Stop()
        {
            if (Botbase == null)
                return;

            if (!Running)
                return;

            if (!TokenSource.IsCancellationRequested)
                TokenSource.Cancel();

            EventManager.FireEvent("OnStopBot");
            Log.Notify($"Stopping bot {Botbase.Name}");

            Game.SelectedEntity = null;
            ScriptManager.Stop();
            ShoppingManager.Stop();
            PickupManager.Stop();
            Botbase.Stop();

            Running = false;

            Log.Notify($"Stoped bot {Botbase.Name}");
        }
    }
}