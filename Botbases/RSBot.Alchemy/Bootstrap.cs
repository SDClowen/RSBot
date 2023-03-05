using RSBot.Alchemy.Subscriber;
using RSBot.Core;
using RSBot.Core.Components;
using RSBot.Core.Objects;
using RSBot.Core.Plugins;
using System.Windows.Forms;

namespace RSBot.Alchemy
{
    public class Bootstrap : IBotbase
    {
        private static string _name = "RSBot.Alchemy";

        public string Name => _name;

        public string DisplayName => "Alchemy";

        public string TabText => DisplayName;

        public Area Area => new();

        public static bool IsActive => Kernel.Bot.Running && Kernel.Bot.Botbase.Name == _name;

        public Control View => Globals.View;

        public void Initialize()
        {
            AlchemyEventsSubscriber.Subscribe();
            Globals.Botbase = new();

            Log.AppendFormat(LogLevel.Notify, "[Alchemy] Initialized botbase");
        }

        public void Start()
        {
            Globals.Botbase?.Start();

            Log.AppendFormat(LogLevel.Debug, "[Alchemy] Starting automated alchemy...");
        }

        public void Stop()
        {
            if (Globals.Botbase != null)
                Globals.Botbase.Stop();

            Log.AppendFormat(LogLevel.Debug, "[Alchemy] Stopped automated alchemy");
        }

        public void Register()
        {
            Initialize();

            Log.Debug("[Alchemy] Botbase registered to the kernel!");
        }

        public void Tick()
        {
            if (!Globals.View.IsRefreshing && !AlchemyManager.IsFusing)
                Globals.Botbase.Tick();
        }

        public void Translate()
        {
            LanguageManager.Translate(View, Kernel.Language);
        }
    }
}