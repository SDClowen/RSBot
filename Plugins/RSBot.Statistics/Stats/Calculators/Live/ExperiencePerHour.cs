using RSBot.Core;
using System;
using System.Linq;

namespace RSBot.Statistics.Stats.Calculators.Live
{
    internal class ExperiencePerHour : IStatisticCalculator
    {
        /// <summary>
        /// The initial value
        /// </summary>
        private double _lastTickValue;

        /// <summary>
        /// The values
        /// </summary>
        private double[] _values;

        /// <summary>
        /// The current tick index
        /// </summary>
        private int _currentTickIndex = -1;

        /// <inheritdoc />
        public string Name => "EXPPerHour";

        /// <inheritdoc />
        public string Label => LanguageManager.GetLang("Calculators.ExperiencePerHour.Label");

        /// <inheritdoc />
        public StatisticsGroup Group => StatisticsGroup.Player;

        /// <inheritdoc />
        public string ValueFormat => "{0} %";

        /// <inheritdoc />
        public UpdateType UpdateType => UpdateType.Live;

        /// <inheritdoc />
        public object GetValue()
        {
            if (!Game.Ready)
                return 0;

            var currentPercent = ((double)Game.Player.Experience /
                                     (double)Game.ReferenceManager.GetRefLevel(Game.Player.Level).Exp_C) * 100;

            if (++_currentTickIndex >= _values.Length)
                _currentTickIndex = 0;

            _values[_currentTickIndex] = currentPercent - _lastTickValue;
            _lastTickValue = currentPercent;

            return Math.Round(_values.Sum(val => val) / _values.Length * 3600, 2);
        }

        /// <inheritdoc />
        public void Reset()
        {
            _lastTickValue = ((double)Game.Player.Experience /
                              (double)Game.ReferenceManager.GetRefLevel(Game.Player.Level).Exp_C) * 100;

            _values = new double[60];
        }

        /// <inheritdoc />
        public void Initialize()
        {
            _values = new double[60];
        }
    }
}