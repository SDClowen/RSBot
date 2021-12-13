using RSBot.Core.Client.ReferenceObjects;
using RSBot.Core.Components;
using RSBot.Core.Network;
using System.Timers;

namespace RSBot.Core.Objects.Spawn
{
    public class SpawnedBionic : SpawnedEntity
    {
        /// <summary>
        /// Gets the record.
        /// </summary>
        /// <value>
        /// The record.
        /// </value>
        public RefObjChar Record => Game.ReferenceManager.GetRefObjChar(Id);

        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        /// <value>
        /// The state.
        /// </value>
        public State State { get; set; }

        /// <summary>
        /// Gets a value indicating whether [attacking player].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [attacking player]; otherwise, <c>false</c>.
        /// </value>
        public bool AttackingPlayer { get; private set; }

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
            State = State.FromPacket(packet);

            Tracker = new PositionTracker(movement);
            Tracker.SetSpeed(State.WalkSpeed, State.RunSpeed);
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
    }
}