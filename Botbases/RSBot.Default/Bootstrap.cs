﻿using RSBot.Core;
using RSBot.Core.Components;
using RSBot.Core.Objects;
using RSBot.Core.Plugins;
using RSBot.Default.Bundle;
using RSBot.Default.Components;
using System;
using System.Windows.Forms;

namespace RSBot.Default
{
    public class Bootstrap : IBotbase
    {
        public string Name => "RSBot.Default";

        public string DisplayName => "Training";

        public string TabText => DisplayName;

        public Area Area => Container.Bot.Area;

        /// <summary>
        /// Ticks this instance. It's the botbase main-loop
        /// </summary>
        public void Tick()
        {
            if (!Kernel.Bot.Running)
                return;

            if (Game.Player.Exchanging)
                return;

            if (Game.Player.Untouchable)
                return;

            if (Game.Player.State.LifeState == LifeState.Dead)
                return;

            //Begin the loopback if needed
            if (Container.Bot.Area.Position.DistanceToPlayer() > 80)
                Bundles.Loop.Start();

            if (Bundles.Loop.Running)
                return;

            //Nothing if in scroll state!
            if (Game.Player.State.ScrollState == ScrollState.NormalScroll ||
                Game.Player.State.ScrollState == ScrollState.ThiefScroll)
                return;
            
            try
            {
                Container.Bot.Tick();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex);
            }
        }

        /// <summary>
        /// Gets the view.
        /// </summary>
        /// <returns></returns>
        public Control View => Container.View;

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        /// <exception cref="System.NotImplementedException"></exception>
        public void Initialize()
        {
            Container.Lock = new();
            Container.Bot = new();

            Bundles.Reload();
            Container.Bot.Reload();

            Subscriber.BundleSubscriber.SubscribeEvents();
            Subscriber.ConfigSubscriber.SubscribeEvents();
            Subscriber.TeleportSubscriber.SubscribeEvents();

            ScriptManager.CommandHandlers.Add(new TrainingAreaScriptCommand());
        }

        /// <summary>
        /// Starts this instance.
        /// </summary>
        public void Start()
        {
            var x = PlayerConfig.Get<float>("RSBot.Area.X", 0);
            var y = PlayerConfig.Get<float>("RSBot.Area.Y", 0);
            if (x == 0 && y == 0)
            {
                Log.WarnLang("ConfigureTrainingAreaBeforeStartBot");
                Kernel.Bot.Stop();

                return;
            }

            Bundles.Reload();
            Container.Bot.Reload();
        }

        /// <summary>
        /// Stops this instance.
        /// </summary>
        public void Stop()
        {
            lock (Container.Lock)
            {
                if (Game.Player.InAction)
                    SkillManager.CancelAction();

                Bundles.Stop();
            }
        }

        /// <summary>
        /// Always initialize the botbase so other botbases can make use of its otherwise internal features.
        /// </summary>
        public void Register()
        {
            Initialize();

            Log.Debug("[Training] Botbase registered to the kernel!");
        }

        /// <summary>
        /// Translate the botbase plugin
        /// </summary>
        /// <param name="language">The language</param>
        public void Translate()
        {
            LanguageManager.Translate(View, Kernel.Language);
        }
    }
}