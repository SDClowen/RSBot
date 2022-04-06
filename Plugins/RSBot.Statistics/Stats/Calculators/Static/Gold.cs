﻿using RSBot.Core;

namespace RSBot.Statistics.Stats.Calculators.Static
{
    internal class Gold : IStatisticCalculator
    {
        /// <summary>
        /// The initial value
        /// </summary>
        private ulong _initialValue;

        /// <inheritdoc />
        public string Name => "GoldGained";

        /// <inheritdoc />
        public string Label => LanguageManager.GetLang("Calculators.Gold.Label");

        /// <inheritdoc />
        public StatisticsGroup Group => StatisticsGroup.Loot;

        /// <inheritdoc />
        public string ValueFormat => "{0}";

        /// <inheritdoc />
        public UpdateType UpdateType => UpdateType.Static;

        /// <inheritdoc />
        public double GetValue()
        {
            if (!Game.Ready)
                return 0;

            return (double)Game.Player.Gold - (double)_initialValue;
        }

        /// <inheritdoc />
        public void Reset()
        {
            _initialValue = Game.Player.Gold;
        }

        /// <inheritdoc />
        public void Initialize()
        {
            //Nothing to do here!
        }
    }
}