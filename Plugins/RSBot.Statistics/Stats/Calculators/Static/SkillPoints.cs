﻿using RSBot.Core;

namespace RSBot.Statistics.Stats.Calculators.Static
{
    internal class SkillPoints : IStatisticCalculator
    {
        /// <summary>
        /// The initial value
        /// </summary>
        private uint _initialValue;

        /// <inheritdoc />
        public string Name => "SPGained";

        /// <inheritdoc />
        public string Label => LanguageManager.GetLang("Calculators.SkillPoints.Label");

        /// <inheritdoc />
        public StatisticsGroup Group => StatisticsGroup.Player;

        /// <inheritdoc />
        public string ValueFormat => "{0}";

        /// <inheritdoc />
        public UpdateType UpdateType => UpdateType.Static;

        /// <inheritdoc />
        public double GetValue()
        {
            if (!Game.Ready)
                return 0;

            return (double)Game.Player.SkillPoints - (double)_initialValue;
        }

        /// <inheritdoc />
        public void Reset()
        {
            _initialValue = Game.Player.SkillPoints;
        }

        /// <inheritdoc />
        public void Initialize()
        {
            //Nothing to do here!
        }
    }
}