using RSBot.Core;
using System;
using System.Linq;

namespace RSBot.Statistics.Stats.Calculators.Live
{
    internal class SkillPointsPerHour : IStatisticCalculator
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
        private int _currentTickIndex;

        /// <inheritdoc />
        public string Name => "SPPerHour";

        /// <inheritdoc />
        public string Label => LanguageManager.GetLang("Calculators.SkillPointsPerHour.Label");

        /// <inheritdoc />
        public StatisticsGroup Group => StatisticsGroup.Player;

        /// <inheritdoc />
        public string ValueFormat => "{0}";

        /// <inheritdoc />
        public UpdateType UpdateType => UpdateType.Live;

        /// <inheritdoc />
        public double GetValue()
        {
            if (!Game.Ready)
                return 0;

            _values[_currentTickIndex] = Convert.ToInt32(Game.Player.SkillPoints) - _lastTickValue;
            _currentTickIndex = _currentTickIndex == 59 ? 0 : _currentTickIndex + 1;
            _lastTickValue = Convert.ToInt32(Game.Player.SkillPoints);

            return _values.Sum(val => val) / _values.Length * 3600;
        }

        /// <inheritdoc />
        public void Reset()
        {
            _lastTickValue = Convert.ToInt32(Game.Player.SkillPoints);
            _values = new int[60];
        }

        /// <inheritdoc />
        public void Initialize()
        {
            _values = new int[60];
        }
    }
}