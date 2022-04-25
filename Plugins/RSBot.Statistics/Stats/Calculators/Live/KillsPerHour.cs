﻿using RSBot.Core;
using RSBot.Core.Event;
using System.Linq;

namespace RSBot.Statistics.Stats.Calculators.Live
{
    internal class KillsPerHour : IStatisticCalculator
    {
        /// <summary>
        /// The initial value
        /// </summary>
        private int _lastTickValue;

        /// <summary>
        /// The values
        /// </summary>
        private int[] _values;

        /// <summary>
        /// The current tick index
        /// </summary>
        private int _currentTickIndex = -1;

        /// <summary>
        /// The kill count
        /// </summary>
        private int _killCount;

        /// <inheritdoc />
        public string Name => "KillsPerHour";

        /// <inheritdoc />
        public string Label => LanguageManager.GetLang("Calculators.KillsPerHour.Label");

        /// <inheritdoc />
        public StatisticsGroup Group => StatisticsGroup.Enemy;

        /// <inheritdoc />
        public string ValueFormat => "{0}";

        /// <inheritdoc />
        public UpdateType UpdateType => UpdateType.Live;

        /// <inheritdoc />
        public double GetValue()
        {
            if (!Game.Ready)
                return 0;

            if (++_currentTickIndex >= _values.Length)
                _currentTickIndex = 0;

            _values[_currentTickIndex] = _killCount - _lastTickValue;
            _lastTickValue = _killCount;

            var sum = _values.Sum(val => val);
            var result = (double)sum / (double)_values.Length * 3600;

            return result;
        }

        /// <inheritdoc />
        public void Reset()
        {
            _lastTickValue = 0;
            _killCount = 0;
            _values = new int[60];
        }

        /// <inheritdoc />
        public void Initialize()
        {
            _values = new int[60];

            EventManager.SubscribeEvent("OnKillSelectedEnemy", OnKillEnemy);
        }

        private void OnKillEnemy()
        {
            _killCount++;
        }
    }
}