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
        /// The tick timer
        /// </summary>
        private static Timer _tickTimer;

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

                ClientProcess = Process.GetProcessById(_clientProcessId);

                if (ClientProcess == null || _clientProcessId == 0) return;

                EventManager.FireEvent("OnStartClient");
                Task.Run(ObserveClientProcess);
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

            //Global application tick
            _tickTimer = new Timer(500) { AutoReset = true };
            _tickTimer.Elapsed += TickTimer_Elapsed;
            _tickTimer.Start();
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
        /// Handles the Elapsed event of the TickTimer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Timers.ElapsedEventArgs"/> instance containing the event data.</param>
        private static void TickTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (Game.Ready)
                EventManager.FireEvent("OnTick");
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
            var crashPacket = new Packet(0x300A);
            crashPacket.Lock();

            PacketManager.SendPacket(crashPacket, PacketDestination.Client);
        }

        /// <summary>
        /// Observes the process.
        /// </summary>
        private static void ObserveClientProcess()
        {
            while (ClientProcess != null && ClientProcess.Id != 0)
            {
                if (ClientProcess.HasExited)
                {
                    Log.Warn("Client process exited!");
                    EventManager.FireEvent("OnExitClient");
                    ClientProcessId = 0;
                }

                Thread.Sleep(50);
            }
        }
    }
}