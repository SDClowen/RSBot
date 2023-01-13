using RSBot.Core.Components;
using RSBot.Core.Event;
using RSBot.Core.Network;
using RSBot.Core.Plugins;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RSBot.Core
{
    public static class Kernel
    {
        /// <summary>
        /// The updater token source
        /// </summary>
        private static CancellationTokenSource _updaterTokenSource;

        /// <summary>
        /// Gets or sets the botbase manager.
        /// </summary>
        /// <value>
        /// The botbase manager.
        /// </value>
        public static BotbaseManager BotbaseManager { get; private set; }

        /// <summary>
        /// Gets the plugin manager.
        /// </summary>
        /// <value>
        /// The plugin manager.
        /// </value>
        public static PluginManager PluginManager { get; private set; }

        /// <summary>
        /// Gets the proxy.
        /// </summary>
        /// <value>
        /// The proxy.
        /// </value>
        public static Proxy Proxy { get; set; }

        /// <summary>
        /// Gets or sets the bot.
        /// </summary>
        /// <value>
        /// The bot.
        /// </value>
        public static Bot Bot { get; set; }

        /// <summary>
        /// The application language
        /// </summary>
        public static string Language { get; set; }

        /// <summary>
        /// Get environment fixed tick count
        /// </summary>
        public static int TickCount => (Environment.TickCount & int.MaxValue);

        /// <summary>
        /// Get environment base directory
        /// </summary>
        public static string BasePath => AppDomain.CurrentDomain.BaseDirectory;

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        public static void Initialize()
        {
            Bot = new Bot();
            BotbaseManager = new BotbaseManager();
            PluginManager = new PluginManager();

            //Network handlers/hooks
            RegisterNetworkHandlers();
            RegisterNetworkHooks();

            _updaterTokenSource = new CancellationTokenSource();

            Task.Factory.StartNew(ComponentUpdaterAsync, _updaterTokenSource.Token, TaskCreationOptions.LongRunning, TaskScheduler.Current);
        }

        private static async Task ComponentUpdaterAsync()
        {
            var lastTick = TickCount;
            var lastClockTick = TickCount;

            while (!_updaterTokenSource.IsCancellationRequested)
            {
                await Task.Delay(10);

                if (TickCount - lastClockTick >= 1000)
                {
                    lastClockTick = TickCount;
                    EventManager.FireEvent("OnClock");
                }

                if (!Game.Ready)
                {
                    lastTick = TickCount;
                    continue;
                }

                try
                {
                    var elapsed = TickCount - lastTick;

                    Game.Player.Update(elapsed);
                    Game.Player.Transport?.Update(elapsed);
                    Game.Player.JobTransport?.Update(elapsed);
                    Game.Player.AbilityPet?.Update(elapsed);
                    Game.Player.Growth?.Update(elapsed);
                    Game.Player.Fellow?.Update(elapsed);

                    SpawnManager.Update(elapsed);
                    
                    CollisionManager.Update(Game.Player.Position.Region);

                    EventManager.FireEvent("OnTick");

                    lastTick = TickCount;
                }
                catch (Exception e)
                {
                    Log.Fatal(e);
                }
            }
        }

        /// <summary>
        /// Registers the network handler.
        /// </summary>
        private static void RegisterNetworkHandlers()
        {
            var type = typeof(IPacketHandler);
            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => type.IsAssignableFrom(p) && !p.IsInterface).ToArray();

            foreach (var handler in types)
            {
                var instance = (IPacketHandler)Activator.CreateInstance(handler);

                PacketManager.RegisterHandler(instance);
            }
        }

        /// <summary>
        /// Registers the network hooks.
        /// </summary>
        private static void RegisterNetworkHooks()
        {
            var type = typeof(IPacketHook);
            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => type.IsAssignableFrom(p) && !p.IsInterface).ToArray();

            foreach (var handler in types)
            {
                var instance = (IPacketHook)Activator.CreateInstance(handler);

                PacketManager.RegisterHook(instance);
            }
        }
    }
}