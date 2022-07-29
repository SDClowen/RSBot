using RSBot.Core;
using RSBot.Core.Event;
using RSBot.Core.Network;
using RSBot.Core.Objects;
using System.Threading.Tasks;

namespace RSBot.Protection.Components.Town
{
    public class DeadHandler
    {
        /// <summary>
        /// Initializes this instance.
        /// </summary>
        public static void Initialize()
        {
            SubscribeEvents();
        }

        /// <summary>
        /// Subscribes the events.
        /// </summary>
        private static void SubscribeEvents()
        {
            EventManager.SubscribeEvent("OnUpdateEntityLifeState", new System.Action<uint>(OnEntityLifeStateChanged));
        }

        /// <summary>
        /// Cores the entity life state changed.
        /// </summary>
        /// <param name="uniqueId">The unique identifier.</param>
        private static async void OnEntityLifeStateChanged(uint uniqueId)
        {
            if (!Kernel.Bot.Running)
                return;

            if (uniqueId != Game.Player.UniqueId)
                return;

            if (!PlayerConfig.Get<bool>("RSBot.Protection.checkDead"))
                return;

            if (Game.Player.State.LifeState != LifeState.Dead)
                return;

            var timeOut = PlayerConfig.Get("RSBot.Protection.numDeadTimeout", 30);

            Log.WarnLang("ResurrectSPointSeconds", timeOut);

            await Task.Delay(timeOut * 1000);

            if (Game.Player.State.LifeState != LifeState.Dead)
                return;

            var packet = new Packet(0x3053);
            packet.WriteByte(1);
            PacketManager.SendPacket(packet, PacketDestination.Server);
        }
    }
}