using RSBot.Core.Network;
using System.Timers;

namespace RSBot.Core.Objects.Spawn
{
    public class SpawnedBionic : SpawnedEntity
    {
        /// <summary>
        /// Gets the distance to player.
        /// </summary>
        /// <value>
        /// The distance to player.
        /// </value>
        public double DistanceToPlayer => Game.Player.Movement.Source.DistanceTo(Movement.Source);

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
        public int Health { get; set; }

        /// <summary>
        /// Gets or sets the bad effect.
        /// </summary>
        /// <value>
        /// The bad effect.
        /// </value>
        public BadEffect BadEffect { get; set; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="objId">The ref obj id</param>
        public SpawnedBionic(uint objId)
        {
            Id = objId;

            if (Record != null)
                Health = Record.MaxHealth;
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
        /// Selects the entity by its UniqueId.
        /// </summary>
        /// <returns><c>true</c> if succesfully selected; otherwise <c>false</c>.</returns>
        public bool TrySelect()
        {
            var isSelectedAnotherEntity = Game.SelectedEntity != null;
            if (isSelectedAnotherEntity && Game.SelectedEntity.UniqueId == UniqueId)
                return true;

            var msgTheEntity = $"the entity(UniqueId: {UniqueId} State: {State.LifeState} Health: {Health} HasHealth: {HasHealth} Distance: {System.Math.Round(DistanceToPlayer, 1)})";
            
            Log.Debug($"Trying to select {msgTheEntity}");
            if (isSelectedAnotherEntity) isSelectedAnotherEntity = !Game.SelectedEntity.TryDeselect($", it's called from TrySelect(UniqueId: {UniqueId})");
            var result = Operations.SelectEntity(UniqueId);

            if (result)
                Log.Debug($"Selected {msgTheEntity}");
            else
            {
                var msgFailReason = string.Empty;
                if (isSelectedAnotherEntity)
                    msgFailReason = $", because of another entity is selected, and could not deselect it";

                Log.Debug($"Could not select {msgTheEntity}{msgFailReason}");
            }

            return result;
        }

        /// <summary>
        /// Deselects this entity by its UniqueId.
        /// </summary>
        /// <param name="msgCaller">Caller message text to the end of log</param>
        /// <returns><c>true</c> if succesfully deselected; otherwise <c>false</c>.</returns>
        public bool TryDeselect(string msgCaller = "")
        {
            if (Game.SelectedEntity == null || Game.SelectedEntity.UniqueId != UniqueId)
                return true;

            var msgEnd = $"the entity(UniqueId: {UniqueId}){msgCaller}";
            
            Log.Debug($"Trying to deselect {msgEnd}");
            var result = Operations.DeselectEntity(UniqueId);
            
            if (result)
                Log.Debug($"Deselected {msgEnd}");
            else
                Log.Debug($"Could not deselect {msgEnd}");

            return result;
        }
    }
}