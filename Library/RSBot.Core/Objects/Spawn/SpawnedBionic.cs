using RSBot.Core.Components;
using RSBot.Core.Network;
using System.Collections.Generic;
using System.Linq;
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
        /// Gets or sets the target identifier.
        /// </summary>
        /// <value>
        /// The target identifier.
        /// </value>
        public uint TargetId { get; set; }

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
        /// Selects the entity.
        /// </summary>
        /// <param name="uniqueId">The unique identifier.</param>
        /// <returns></returns>
        public bool TrySelect()
        {
            if (Game.SelectedEntity?.UniqueId == UniqueId)
                return true;

            Log.Debug($"Trying to select the entity: {UniqueId} State: {State.LifeState} Health: {Health} HasHealth: {HasHealth} Dst: {System.Math.Round(DistanceToPlayer, 1)}");

            var packet = new Packet(0x7045);
            packet.WriteUInt(UniqueId);

            var awaitCallback = new AwaitCallback(response =>
            {
                var result = response.ReadByte() == 0x01;
                if (result)
                    return response.ReadUInt() == UniqueId ? AwaitCallbackResult.Success : AwaitCallbackResult.ConditionFailed;

                return AwaitCallbackResult.Fail;
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
            Log.Debug($"Entity deselected: {UniqueId}");

            var packet = new Packet(0x704B);
            packet.WriteUInt(UniqueId);

            var awaitResult = new AwaitCallback(response => response.ReadByte() == 1 ?
                AwaitCallbackResult.Success : AwaitCallbackResult.ConditionFailed, 0xB04B);

            PacketManager.SendPacket(packet, PacketDestination.Server, awaitResult);
            awaitResult.AwaitResponse();

            return awaitResult.IsCompleted;
        }

        /// <summary>
        /// Gets a list of spawned bionics that are attacking this entity.
        /// </summary>
        /// <returns></returns>
        public List<SpawnedBionic> GetAttackers()
        {
            return !SpawnManager.TryGetEntities<SpawnedBionic>(out var attackers, e => e.TargetId == UniqueId) ? null : attackers.ToList();
        }
    }
}