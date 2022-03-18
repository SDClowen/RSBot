using RSBot.Core.Event;
using System.Timers;

namespace RSBot.Core.Network.Handler.Agent.Game
{
    internal class GameReadyRequest : IPacketHandler
    {
        /// <summary>
        /// Gets or sets the opcode.
        /// </summary>
        /// <value>
        /// The opcode.
        /// </value>
        public ushort Opcode => 0x3077;

        /// <summary>
        /// Gets or sets the destination.
        /// </summary>
        /// <value>
        /// The destination.
        /// </value>
        public PacketDestination Destination => PacketDestination.Client;

        /// <summary>
        /// Handles the packet.
        /// </summary>
        /// <param name="packet">The packet.</param>
        public void Invoke(Packet packet)
        {
            Core.Game.Player.Teleportation = null;

            Log.Debug("The player is untouchable for 5s");
            var untouchableTimer = new Timer(5000) { AutoReset = false };
            untouchableTimer.Elapsed += UntouchableTimer_Elapsed;
            untouchableTimer.Start();
            Log.Debug("Teleportation complete");
            EventManager.FireEvent("OnTeleportComplete");

            Core.Game.Ready = true;
        }

        /// <summary>
        /// Handles the Elapsed event of the UntouchableTimer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ElapsedEventArgs"/> instance containing the event data.</param>
        private void UntouchableTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Log.Debug("The player is no longer untouchable");
            Core.Game.Player.Untouchable = false;
        }
    }
}