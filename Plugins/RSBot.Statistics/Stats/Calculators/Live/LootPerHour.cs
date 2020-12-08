using RSBot.Core;
using RSBot.Core.Event;
using RSBot.Core.Objects;
using System;
using System.Linq;

namespace RSBot.Statistics.Stats.Calculators.Live
{
    internal class LootPerHour : IStatisticCalculator
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

        /// <summary>
        /// The kill count
        /// </summary>
        private int _pickedItemCount;

        /// <inheritdoc />
        public string Name => "ItemsPerHour";

        /// <inheritdoc />
        public string Label => "Items / hour";

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

            _values[_currentTickIndex] = _pickedItemCount - _lastTickValue;
            _currentTickIndex = _currentTickIndex == 59 ? 0 : _currentTickIndex + 1;
            _lastTickValue = _pickedItemCount;

            var sum = _values.Sum(val => val);
            var result = (double)sum / (double)_values.Length * 3600;

            return result;
        }

        /// <inheritdoc />
        public void Reset()
        {
            _lastTickValue = 0;
            _pickedItemCount = 0;
            _values = new int[60];
        }

        /// <inheritdoc />
        public void Initialize()
        {
            _values = new int[60];

            EventManager.SubscribeEvent("OnPickupItem", new Action<InventoryItem>(OnPickupItem));
            EventManager.SubscribeEvent("OnPartyPickItem", new Action<InventoryItem>(OnPickupItem));
        }

        private void OnPickupItem(InventoryItem item)
        {
            _pickedItemCount++;
        }
    }
}