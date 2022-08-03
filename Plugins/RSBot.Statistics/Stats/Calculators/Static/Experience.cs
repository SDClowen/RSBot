using RSBot.Core;
using RSBot.Core.Event;
using System;

namespace RSBot.Statistics.Stats.Calculators.Static
{
    internal class Experience : IStatisticCalculator
    {
        /// <summary>
        /// The initial value
        /// </summary>
        private double _initialValue;

        /// <summary>
        /// The initial level
        /// </summary>
        private byte _initialLevel;

        /// <summary>
        /// The initial offset
        /// </summary>
        private double _initialOffset;

        /// <inheritdoc />
        public string Name => "EXPGained";

        /// <inheritdoc />
        public string Label => LanguageManager.GetLang("Calculators.Experience.Label");

        /// <inheritdoc />
        public StatisticsGroup Group => StatisticsGroup.Player;

        /// <inheritdoc />
        public string ValueFormat => "{0} %";

        /// <inheritdoc />
        public UpdateType UpdateType => UpdateType.Static;

        /// <inheritdoc />
        public object GetValue()
        {
            if (!Game.Ready)
                return 0;

            var currentPercent = ((double)Game.Player.Experience /
                                  (double)Game.ReferenceManager.GetRefLevel(Game.Player.Level).Exp_C) * 100;

            var difference = (double)Math.Round(currentPercent - _initialValue, 2);
            var levelDifference = Game.Player.Level - _initialLevel;

            double result;
            if (levelDifference == 0)
                result = difference;
            else if (levelDifference == 1)
                result = _initialOffset + difference;
            else
                result = (_initialOffset + difference) + (levelDifference - 1) * 100;

            return Math.Round(result, 2);
        }

        /// <inheritdoc />
        public void Reset()
        {
            //EXP Percent
            _initialValue = ((double)Game.Player.Experience /
                             (double)Game.ReferenceManager.GetRefLevel(Game.Player.Level).Exp_C) * 100;

            _initialOffset = _initialValue;

            _initialLevel = Game.Player.Level;
        }

        /// <inheritdoc />
        public void Initialize()
        {
            EventManager.SubscribeEvent("OnLevelUp", OnLevelUp);
        }

        private void OnLevelUp()
        {
            //EXP Percent
            _initialValue = ((double)Game.Player.Experience /
                             (double)Game.ReferenceManager.GetRefLevel(Game.Player.Level).Exp_C) * 100;
        }
    }
}