using RSBot.Core.Components;
using RSBot.Core.Event;
using RSBot.Core.Extensions;
using RSBot.Core.Network;
using RSBot.Core.Plugins;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Timer = System.Timers.Timer;

namespace RSBot.Core
{
    public static class Kernel
    {
        /// <summary>
        /// The client process identifier
        /// </summary>
        private static int _clientProcessId;

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
        public static Proxy Proxy { get; internal set; }

        /// <summary>
        /// Gets or sets the bot.
        /// </summary>
        /// <value>
        /// The bot.
        /// </value>
        public static Bot Bot { get; set; }

        /// <summary>
        /// Gets or sets the client process identifier.
        /// </summary>
        /// <value>
        /// The client process identifier.
        /// </value>
        public static int ClientProcessId
        {
            get => _clientProcessId;
            set
            {
                _clientProcessId = value;

                if (_clientProcessId == 0)
                    return;

                var process = Process.GetProcessById(_clientProcessId);
                if (process == null) 
                    return;

                process.EnableRaisingEvents = true;
                process.Exited += ClientProcess_Exited;
                ClientProcess = process;

                EventManager.FireEvent("OnStartClient");
            }
        }

        /// <summary>
        /// Gets or sets the client process.
        /// </summary>
        /// <value>
        /// The client process.
        /// </value>
        public static Process ClientProcess { get; internal set; }

        /// <summary>
        /// Get, has client exited <c>true</c> otherwise; <c>false</c>
        /// </summary>
        public static bool HasClientExited => ClientProcess == null || ClientProcessId == 0;

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        public static void Initialize()
        {
            Bot = new Bot();

            //External Libraries
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
            while (!_updaterTokenSource.IsCancellationRequested)
            {
                if (Game.Ready)
                {
                    Game.Player.Update();
                    SpawnManager.Update();
                    EventManager.FireEvent("OnTick");
                }

                await Task.Delay(100);
            }
        }

        /// <summary>
        /// Change client process title
        /// </summary>
        /// <param name="title">The new title</param>
        public static void ChangeClientProcessTitle(string title)
        {
            if (ClientProcess == null)
                return;

            NativeExtensions.SetWindowText(ClientProcess.MainWindowHandle, title);
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

        /// <summary>
        /// Kills the client.
        /// </summary>
        public static void KillClient()
        {
            if (HasClientExited)
                return;

            try
            {
                ClientProcess.Kill();
            }
            catch
            {
            }
        }

        /// <summary>
        /// Observes the process.
        /// </summary>
        private static void ClientProcess_Exited(object sender, EventArgs e)
        {
            Log.Warn("Client process exited!");
            EventManager.FireEvent("OnExitClient");
            ClientProcessId = 0;
        }
    }
}