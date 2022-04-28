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

            KeepAlivePacketWorker();
        }

        /// <summary>
        /// Requests the server list.
        /// </summary>
        public static void RequestServerList()
        {
            if (!Kernel.Proxy.IsConnectedToGatewayserver)
                return;

            PacketManager.SendPacket(new Packet(0x6101, true), PacketDestination.Server);
        }

        /// <summary>
        /// Called when [agent server disconnected].
        /// </summary>
        private static async void OnAgentServerDisconnected()
        {
            if (!Game.Clientless)
                return;

            Log.Warn("Attempting relogin in 10 seconds...");
            await Task.Delay(10000);

            Game.Start();
        }

        /// <summary>
        /// Called when [agent server connected].
        /// </summary>
        private static void OnAgentServerConnected()
        {
            if (!Game.Clientless)
                return;

            KeepAlivePacketWorker();
        }

        /// <summary>
        /// Pings the server.
        /// </summary>
        private async static void KeepAlivePacketWorker()
        {
            while (Kernel.Proxy.IsConnectedToAgentserver)
            {
                await Task.Delay(10000);

                PacketManager.SendPacket(new Packet(0x2002), PacketDestination.Server);
            }
        }
    }
}