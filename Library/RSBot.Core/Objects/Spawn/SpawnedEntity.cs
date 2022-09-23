﻿using System;
using System.Diagnostics;
using System.Timers;
using RSBot.Core.Client.ReferenceObjects;
using RSBot.Core.Components;

namespace RSBot.Core.Objects.Spawn
{
    public class SpawnedEntity
    {
        /// <summary>
        /// Synchroniztion object.
        /// </summary>
        protected object _lock { get; } = new object();

        /// <summary>
        /// Gets or sets the unique identifier.
        /// </summary>
        /// <value>
        /// The unique identifier.
        /// </value>
        public uint UniqueId { get; set; }

        /// <summary>
        /// Gets or sets the model identifier.
        /// </summary>
        /// <value>
        /// The model identifier.
        /// </value>
        public uint Id { get; set; }

        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        /// <value>
        /// The state.
        /// </value>
        public State State { get; } = new();

        /// <summary>
        /// Gets the record.
        /// </summary>
        /// <value>
        /// The record.
        /// </value>
        public RefObjChar Record => Game.ReferenceManager.GetRefObjChar(Id);

        /// <summary>
        /// Gets the race.
        /// </summary>
        /// <value>
        /// The race.
        /// </value>
        public ObjectCountry Race => Record?.Country ?? ObjectCountry.Unassigned;

        /// <summary>
        /// Gets the gender.
        /// </summary>
        /// <value>
        /// The gender.
        /// </value>
        public ObjectGender Gender => Record?.CharGender ?? ObjectGender.Neutral;

        /// <summary>
        /// The Movement
        /// </summary>
        public Movement Movement;

        /// <summary>
        /// Gets the position.
        /// </summary>
        /// <value>
        /// The position.
        /// </value>
        public Position Position => Movement.Source;

        /// <summary>
        /// Gets a value indicating whether [in cave].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [in cave]; otherwise, <c>false</c>.
        /// </value>
        public bool IsInDungeon => Movement.Source.IsInDungeon;

        /// <summary>
        /// Gets or sets a value indicating whether this instance is behind obstacle.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is behind obstacle; otherwise, <c>false</c>.
        /// </value>
        public bool IsBehindObstacle => CollisionManager.HasCollisionBetween(Game.Player.Position, Position);

        /// <summary>
        /// Entity current speed
        /// </summary>
        public float ActualSpeed => Movement.Type == MovementType.Walking ? State.WalkSpeed : State.RunSpeed;

        public void SetMovement(Movement movement)
        {
            Movement = movement;
            SetAngle(movement.Angle);

            if (movement.HasDestination)
                Move(movement.Destination);
        }

        public void Move(float angle)
        {
            lock (_lock)
            {
                Movement.HasDestination = false;
                SetAngle(angle);

                Movement.Moving = true;
            }
        }

        public void Move(Position destination)
        {
            lock (_lock)
            {
                Movement.HasDestination = true;
                Movement.Destination = destination;

                var xDelta = Movement.Destination.XCoordinate - Movement.Source.XCoordinate;
                var yDelta = Movement.Destination.YCoordinate - Movement.Source.YCoordinate;

                Movement.Angle = MathF.Atan2(yDelta, xDelta);

                CalculateMovingConditional();

                Movement.Moving = true;
            }
        }

        public void SetSpeed(float walk, float run)
        {
            State.WalkSpeed = walk;
            State.RunSpeed = run;
        }

        public void SetSource(Position source)
        {
            Movement.Source = source;
            //SetAngle(source.Angle);

            if (Movement.Moving)
                CalculateMovingConditional();
        }

        internal void SetAngle(float angle)
        {
            Movement.Angle = angle * MathF.PI / short.MaxValue;
        }

        public void StopMoving()
        {
            Movement.RemainingTime = TimeSpan.Zero;
            Movement.Moving = false;
            Movement.HasDestination = false;
        }

        public void StopMoving(Position pos)
        {
            StopMoving();
            lock (_lock)
            {
                Movement.Source = pos;
            }
        }

        private void CalculateMovingConditional()
        {
            try
            {
                var position = this.Movement.Source;
                var diffX = Movement.Destination?.XCoordinate - position.XCoordinate;
                var diffY = Movement.Destination?.YCoordinate - position.YCoordinate;
                var distance = Movement.Destination?.DistanceTo(position);

                if (distance == null || diffX == null || diffY == null)
                    return;

                var speed = ActualSpeed * 0.1f;

                // Don't move if too close to destination
                if (distance <= 1)
                    return;

                // Calculate movement and move time
                var remaining = TimeSpan.FromSeconds((double) distance / speed);
                Movement.MovingX = (float)diffX / remaining.TotalSeconds;
                Movement.MovingY = (float)diffY / remaining.TotalSeconds;
                Movement.RemainingTime = remaining;
            }
            catch (NullReferenceException) //can happen if the entity has reached its destination but the core didn't handle it yet
            {
                Log.Debug($"SpawnedEntity::CalculateMovingConditional->Ignored Null reference exception");
            }
        }

        private void CheckMovement(int delta)
        {
            if (!Movement.Moving)
                return;

            if (Movement.HasDestination)
            {
                var elapsed = TimeSpan.FromMilliseconds(delta);

                if ((Movement.RemainingTime -= elapsed) <= TimeSpan.Zero)
                {
                    StopMoving(Movement.Destination);
                    Movement.RemainingTime = TimeSpan.Zero;
                }
                // If there's still move time left, update the current position.
                else
                {
                    Movement.Source.XOffset += (float)(Movement.MovingX * 10 * elapsed.TotalSeconds);
                    Movement.Source.YOffset += (float)(Movement.MovingY * 10 * elapsed.TotalSeconds);
                }

                return;
            }

            float remaning = -1f;

            var finish = false;
            var totalChange = ActualSpeed / 1000.0f * delta;
            if (remaning != -1 && totalChange > remaning)
            {
                totalChange = remaning;
                finish = true;
            }

            var dir = MathF.SinCos(Movement.Angle);

            Movement.Source.XOffset += dir.Cos * totalChange;
            Movement.Source.YOffset += dir.Sin * totalChange;

            if (finish)
                StopMoving(Movement.Destination);
        }

        /// <summary>
        /// Update the instance
        /// </summary>
        /// <returns></returns>
        public virtual bool Update(int delta)
        {
            CheckMovement(delta);

            return true;
        }

        /// <summary>
        /// Dispose the instance
        /// </summary>
        public virtual bool Dispose()
        {
            // TODO:!!!!!!
            return true;
        }
    }
}
