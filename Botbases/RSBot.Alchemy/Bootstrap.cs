using Accessibility;
using RSBot.Alchemy.Bot;
using RSBot.Alchemy.Subscriber;
using RSBot.Alchemy.Views;
using RSBot.Core;
using RSBot.Core.Components;
using RSBot.Core.Plugins;
using System;
using System.Windows.Forms;

namespace RSBot.Alchemy
{
    public class Bootstrap : IBotbase
    {
        #region Properties

        private static string _name = "RSBot.Alchemy";
        public static bool IsActive => Kernel.Bot.Running && Kernel.Bot.Botbase.Info.Name == _name;

        public BotbaseInfo Info => new()
        {
            Name = _name,
            DisplayName = "Alchemy",
            TabText = "Alchemy"
        };

        #endregion Properties

        #region Methods

        public Control GetView()
        {
            return Globals.View ?? (Globals.View = new Main());
        }

        public void Initialize()
        {
            AlchemyEventsSubscriber.Subscribe();
            Globals.Botbase = new Botbase();

            Log.AppendFormat(LogLevel.Notify, "[Alchemy] Initialized botbase");
        }

        public void Start()
        {
            if (Globals.Botbase != null)
                Globals.Botbase.Start();

            Log.AppendFormat(LogLevel.Debug, "[Alchemy] Starting automated alchemy...");
        }

        public void Stop()
        {
            if (Globals.Botbase != null)
                Globals.Botbase.Stop();

            Log.AppendFormat(LogLevel.Debug, "[Alchemy] Stopped automated alchemy");
        }

        public void Tick()
        {
            if (!Globals.View.IsRefreshing && !AlchemyManager.IsFusing)
                Globals.Botbase.Tick();
        }

        public void Translate()
        {
            LanguageManager.Translate(GetView(), Kernel.Language);
        }

        #endregion Methods
    }
}