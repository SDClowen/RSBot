using RSBot.Core;
using System;
using System.Linq;

namespace RSBot.Statistics.Stats.Calculators.Live
{
    internal class GoldPerHour : IStatisticCalculator
    {
        /// <summary>
        /// The initial value
        /// </summary>
        private long _lastTickValue;

        /// <summary>
        /// The values
        /// </summary>
        private long[] _values;

        /// <summary>
        /// The current tick index
        /// </summary>
        private int _currentTickIndex;

        /// <inheritdoc />
        public string Name => "GoldPerHour";

        /// <inheritdoc />
        public string Label => "Gold / hour";

        /// <inheritdoc />
        public StatisticsGroup Group => StatisticsGroup.Loot;

        /// <inheritdoc />
        public string ValueFormat => "{0}";

        /// <inheritdoc />
        public UpdateType UpdateType => UpdateType.Live;

        /// <inheritdoc />
        public double GetValue()
        {
            if (!Game.Ready)
                return 0;

            _values[_currentTickIndex] = Convert.ToInt64(Game.Player.Gold) - _lastTickValue;
            _currentTickIndex = _currentTickIndex == 59 ? 0 : _currentTickIndex + 1;
            _lastTickValue = Convert.ToInt64(Game.Player.Gold);

            return _values.Sum(val => val) / _values.Length * 3600;
        }

        /// <inheritdoc />
        public void Reset()
        {
            _lastTickValue = Convert.ToInt64(Game.Player.Gold);
            _values = new long[60];
        }

        /// <inheritdoc />
        public void Initialize()
        {
            _values = new long[60];
        }
    }
}