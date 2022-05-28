using System;
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
        public State State { get; } = new State();

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
        public bool IsBehindObstacle => CollisionManager.HasCollisionBetween(Movement.Source, Game.Player.Movement.Source);

        /// <summary>
        /// Entity current speed
        /// </summary>
        public float ActualSpeed => Movement.Type == MovementType.Walking ? State.WalkSpeed : State.RunSpeed;

        /// <summary>
        /// The Update timer.
        /// </summary>
        private Timer _timer;

        /// <summary>
        /// The Stopwatch.
        /// </summary>
        private Stopwatch _stopwatch { get; } = new Stopwatch();

        public void SetMovement(Movement movement)
        {
            _timer = new Timer();
            _timer.Elapsed += CurrentTimer_Elapsed;
            Movement = movement;
            SetAngle(movement.Angle);

            if (movement.HasDestination)
                Move(movement.Destination);
        }

        private void CurrentTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            lock (_lock)
            {
                _stopwatch.Stop();
                double? remaining = null;

                if (Movement.HasDestination)
                    remaining = Math.Sqrt(Math.Pow(Movement.Destination.WorldXOffset - Movement.Source.WorldXOffset, 2) + Math.Pow(Movement.Destination.WorldYOffset - Movement.Source.WorldYOffset, 2));

                var speed = ActualSpeed;

                var finish = false;
                var totalChange = speed / 1000.0 * _stopwatch.ElapsedMilliseconds;
                if (remaining != null && totalChange > remaining)
                {
                    totalChange = remaining.Value;
                    finish = true;
                }

                Movement.Source.WorldXOffset += (float)(Math.Cos(Movement.Angle) * totalChange);
                Movement.Source.WorldYOffset += (float)(Math.Sin(Movement.Angle) * totalChange);

                if (finish)
                    StopMoving();

                _stopwatch.Restart();
            }
        }

        public void Move(double angle)
        {
            lock (_lock)
            {
                Movement.HasDestination = false;
                SetAngle(angle);

                _stopwatch.Restart();

                if (Movement.Moving == false)
                    _timer.Start();

                Movement.Moving = true;
            }
        }

        public void Move(Position destination)
        {
            lock (_lock)
            {
                Movement.HasDestination = true;
                Movement.Destination = destination;

                var xDelta = Movement.Destination.WorldXOffset - Movement.Source.WorldXOffset;
                var yDelta = Movement.Destination.WorldYOffset - Movement.Source.WorldYOffset;

                Movement.Angle = Math.Atan2(yDelta, xDelta);
                _stopwatch.Restart();

                if (Movement.Moving == false)
                    _timer.Start();

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
            {
                _stopwatch.Reset();
                _stopwatch.Start();
            }
        }

        internal void SetAngle(double angle)
        {
            Movement.Angle = angle * Math.PI / short.MaxValue;
        }

        public void StopTimer()
        {
            _timer.Stop();
        }

        public void StopMoving()
        {
            StopTimer();
            _stopwatch.Stop();
            Movement.Moving = false;
            Movement.HasDestination = false;
        }

        public void StopMoving(Position pos)
        {
            StopMoving();
            lock (_lock)
            {
                Movement.Source = pos;
                SetAngle(pos.Angle);
            }
        }

        /// <summary>
        /// Update the instance
        /// </summary>
        /// <returns></returns>
        public virtual bool Update()
        {
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
