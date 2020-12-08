using RSBot.Core;
using RSBot.Core.Event;
using RSBot.Core.Network;
using RSBot.Core.Objects;
using System.Timers;

namespace RSBot.Protection.Components.Town
{
    public class DeadHandler
    {
        #region Member

        private static Timer _timer;

        #endregion Member

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
        private static void OnEntityLifeStateChanged(uint uniqueId)
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
            Log.Notify($"Resurrect at the specified point in {timeOut} seconds");

            _timer = new Timer(timeOut * 1000);
            _timer.AutoReset = false;
            _timer.Elapsed += _timer_Elapsed;
            _timer.Start();
        }

        /// <summary>
        /// Handles the Elapsed event of the _timer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ElapsedEventArgs"/> instance containing the event data.</param>
        private static void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (Game.Player.State.LifeState != LifeState.Dead) return;

            var packet = new Packet(0x3053);
            packet.WriteByte(1);
            packet.Lock();
            PacketManager.SendPacket(packet, PacketDestination.Server);
        }
    }
}