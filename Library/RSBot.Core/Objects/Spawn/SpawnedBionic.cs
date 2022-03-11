using RSBot.Core.Network;
using System.Timers;

namespace RSBot.Core.Objects.Spawn
{
    public class SpawnedBionic : SpawnedEntity
    {
        /// <summary>
        /// Gets a value indicating whether [attacking player].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [attacking player]; otherwise, <c>false</c>.
        /// </value>
        public bool AttackingPlayer { get; private set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance has health.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance has health; otherwise, <c>false</c>.
        /// </value>
        public bool HasHealth => Health > 0;

        /// <summary>
        /// Gets or sets the health.
        /// </summary>
        /// <value>
        /// The health.
        /// </value>
        public uint Health { get; set; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="objId">The ref obj id</param>
        public SpawnedBionic(uint objId)
        {
            Id = objId;
        }

        /// <summary>
        /// Parse the bionic details
        /// </summary>
        /// <param name="packet">The packet</param>
        internal void ParseBionicDetails(Packet packet)
        {
            UniqueId = packet.ReadUInt();

            var movement = Movement.FromPacket(packet);
            State.Deserialize(packet);
            SetMovement(movement);
        }

        /// <summary>
        /// Starts the attacking timer.
        /// </summary>
        /// <param name="duration">The duration.</param>
        public void StartAttackingTimer(int duration = 10000)
        {
            //Log.Debug("Attacking timer has started.");

            AttackingPlayer = true;
            /*
            var timer = new Timer();
            timer.AutoReset = false;
            timer.Elapsed += Timer_Elapsed;*/
        }

        /// <summary>
        /// Handles the Elapsed event of the Timer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ElapsedEventArgs"/> instance containing the event data.</param>
        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Log.Debug("Attacking timer has elapsed.");
            AttackingPlayer = false;
        }

        /// <summary>
        /// Selects the entity.
        /// </summary>
        /// <param name="uniqueId">The unique identifier.</param>
        /// <returns></returns>
        public bool TrySelect()
        {
            var packet = new Packet(0x7045);
            packet.WriteUInt(UniqueId);
            packet.Lock();

            var awaitCallback = new AwaitCallback(response =>
            {
                var result = response.ReadByte() == 0x01;
                if (!result)
                    Log.Error("Could not select entity 0x" + (Game.ClientType < GameClientType.Vietnam ? response.ReadByte() : response.ReadUShort()));

                return result
                    ? AwaitCallbackResult.Received : AwaitCallbackResult.Failed;
            }, 0xB045);
            PacketManager.SendPacket(packet, PacketDestination.Server, awaitCallback);
            awaitCallback.AwaitResponse();

            return awaitCallback.IsCompleted;
        }

        /// <summary>
        /// Deselects the entity.
        /// </summary>
        /// <returns></returns>
        public bool TryDeselect()
        {
            var packet = new Packet(0x704B);
            packet.WriteUInt(UniqueId);
            packet.Lock();

            var awaitResult = new AwaitCallback(null, 0xB04B);
            PacketManager.SendPacket(packet, PacketDestination.Server, awaitResult);
            awaitResult.AwaitResponse();

            return awaitResult.IsCompleted;
        }
    }
}