using RSBot.Core.Objects;
using System;
using System.Diagnostics;
using System.Timers;

namespace RSBot.Core.Components
{
    public class PositionTracker
    {
        /// <summary>
        /// Synchroniztion object.
        /// </summary>
        protected object _lock { get; } = new object();

        /// <summary>
        /// The Update timer.
        /// </summary>
        protected Timer _timer { get; }

        /// <summary>
        /// The Stopwatch.
        /// </summary>
        private Stopwatch _stopwatch { get; } = new Stopwatch();

        /// <summary>
        /// The Movement
        /// </summary>
        private Movement _movement;

        /// <summary>
        /// The source
        /// </summary>
        public Position Position => _movement.Source;

        /// <summary>
        /// The Destination
        /// </summary>
        public Position Destination => _movement.Destination;

        /// <summary>
        /// The angle
        /// </summary>
        public double Angle => _movement.Angle;

        /// <summary>
        /// The Movement State
        /// </summary>
        public MovementState MovementState => _movement.StateType;

        //// <summary>
        /// The motion state
        /// </summary>
        public MotionState State;

        /// <summary>
        /// The character run speed
        /// </summary>
        private float RunSpeed;

        /// <summary>
        /// The character walk speed
        /// </summary>
        private float WalkSpeed;

        /// <summary>
        /// Get character current speed from MotionState
        /// </summary>
        public double ActualSpeed => State == MotionState.Walking ? WalkSpeed : RunSpeed;

        public PositionTracker(Movement movement)
        {
            _timer = new Timer();
            _timer.Elapsed += CurrentTimer_Elapsed;
            _movement = movement;
            SetAngle(movement.Angle);
            //_Movement.Angle = (short)(movement.Angle) * Math.PI / Int16.MaxValue;

            if (movement.HasDestination)
                Move(movement.Destination);
        }

        public PositionTracker(Position position)
        {
            _timer = new Timer();
            _timer.Elapsed += CurrentTimer_Elapsed;
            _movement.Source = position;
            SetAngle(position.Angle);
        }

        private void CurrentTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            lock (_lock)
            {
                if (State == MotionState.Sitting)
                {
                    StopMoving();
                    return;
                }

                _stopwatch.Stop();
                double? left = null;

                if (_movement.HasDestination)
                    left = Math.Sqrt(Math.Pow(_movement.Destination.RXOffset - _movement.Source.RXOffset, 2) + Math.Pow(_movement.Destination.RYOffset - _movement.Source.RYOffset, 2));

                var finish = false;
                var totalChange = ActualSpeed / 1000 * _stopwatch.ElapsedMilliseconds;
                if (left != null && totalChange > left)
                {
                    totalChange = left.Value;
                    finish = true;
                }

                _movement.Source.RXOffset += (float)(Math.Cos(_movement.Angle) * totalChange);
                _movement.Source.RYOffset += (float)(Math.Sin(_movement.Angle) * totalChange);

                if (finish)
                    StopMoving();

                _stopwatch.Restart();
            }
        }

        public void Move(ushort angle)
        {
            lock (_lock)
            {
                _movement.HasDestination = false;
                SetAngle(angle);

                _stopwatch.Restart();

                if (_movement.StateType == MovementState.Standing)
                    _timer.Start();

                _movement.StateType = MovementState.Moving;
            }
        }

        public void Move(Position destination)
        {
            lock (_lock)
            {
                _movement.HasDestination = true;
                _movement.Destination = destination;

                var xDelta = _movement.Destination.RXOffset - _movement.Source.RXOffset;
                var yDelta = _movement.Destination.RYOffset - _movement.Source.RYOffset;

                _movement.Angle = Math.Atan2(yDelta, xDelta);
                _stopwatch.Restart();

                if (_movement.StateType == MovementState.Standing)
                    _timer.Start();

                _movement.StateType = MovementState.Moving;
            }
        }

        public void SetSpeed(float walk, float run)
        {
            WalkSpeed = walk;
            RunSpeed = run;
            _timer.Interval = 1000 / ActualSpeed; // (1000 / ActualSpeed) * Math.PI;
        }

        public void SetSource(Position source)
        {
            _movement.Source = source;
            SetAngle(source.Angle);

            if (_movement.StateType == MovementState.Moving)
                _stopwatch.Restart();
        }

        internal void SetAngle(double angle)
        {
            lock (_lock)
                //_movement.Angle = angle / 180;
                _movement.Angle = ((short)angle) * Math.PI / short.MaxValue;
        }

        public void StopMoving()
        {
            _timer.Stop();
            _stopwatch.Stop();
            _movement.StateType = MovementState.Standing;
            _movement.HasDestination = false;
        }

        public void StopMoving(Position pos)
        {
            StopMoving();
            lock (_lock)
            {
                _movement.Source = pos;
                SetAngle(pos.Angle);
            }
        }
    }
}