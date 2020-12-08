using RSBot.Core.Event;
using RSBot.Core.Network;
using System.Threading;
using System.Threading.Tasks;

namespace RSBot.Core.Components
{
    public class ClientlessManager
    {
        /// <summary>
        /// Subscribes the events.
        /// </summary>
        internal static void Initialize()
        {
            EventManager.SubscribeEvent("OnGatewayServerConntected", RequestServerList);
            EventManager.SubscribeEvent("OnAgentServerDisconnected", OnAgentServerDisconnected);
            EventManager.SubscribeEvent("OnAgentServerConnected", OnAgentServerConnected);
        }

        /// <summary>
        /// Kills the client.
        /// </summary>
        public static void GoClientless()
        {
            if (Kernel.Proxy.Client != null)
                Kernel.Proxy.Client.Shutdown();

            Game.Clientless = true;

            Task.Run(() => PingServer());
        }

        /// <summary>
        /// Requests the server list.
        /// </summary>
        private static void RequestServerList()
        {
            if (!Kernel.Proxy.IsConnectedToGatewayserver || !Game.Clientless)
                return;

            var packet = new Packet(0x6101, true);
            packet.Lock();

            var callback = new AwaitCallback(null, 0xA101);

            PacketManager.SendPacket(packet, PacketDestination.Server, callback);
            callback.AwaitResponse();
        }

        /// <summary>
        /// Called when [agent server disconnected].
        /// </summary>
        private static void OnAgentServerDisconnected()
        {
            if (!Game.Clientless)
                return;

            Log.Warn("Disconnected from game server! - Attempting relogin in 10 seconds.");
            Thread.Sleep(10000);

            Kernel.Bot.Stop();
            Game.Start();
        }

        /// <summary>
        /// Called when [agent server connected].
        /// </summary>
        private static void OnAgentServerConnected()
        {
            if (!Game.Clientless)
                return;

            Thread.Sleep(5000);
            PingServer();
        }

        /// <summary>
        /// Pings the server.
        /// </summary>
        private static void PingServer()
        {
            while (Kernel.Proxy.IsConnectedToAgentserver)
            {
                var pingPacket = new Packet(0x2002);
                pingPacket.Lock();

                PacketManager.SendPacket(pingPacket, PacketDestination.Server);
                Thread.Sleep(10000);
            }
        }
    }
}