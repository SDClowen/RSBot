using System;
using System.Linq;
using RSBot.Core;
using RSBot.Core.Components;
using RSBot.Core.Event;
using RSBot.Core.Objects;

namespace RSBot.Statistics.Stats.Calculators.Live;

internal class LootPerHour : IStatisticCalculator
{
    /// <summary>
    ///     The current tick index
    /// </summary>
    private int _currentTickIndex = -1;

    /// <summary>
    ///     The initial value
    /// </summary>
    private int _lastTickValue;

    /// <summary>
    ///     The kill count
    /// </summary>
    private int _pickedItemCount;

    /// <summary>
    ///     The values
    /// </summary>
    private int[] _values;

    /// <inheritdoc />
    public string Name => "ItemsPerHour";

    /// <inheritdoc />
    public string Label => LanguageManager.GetLang("Calculators.LootPerHour.Label");

    /// <inheritdoc />
    public StatisticsGroup Group => StatisticsGroup.Loot;

    /// <inheritdoc />
    public string ValueFormat => "{0}";

    /// <inheritdoc />
    public UpdateType UpdateType => UpdateType.Live;

    /// <inheritdoc />
    public object GetValue()
    {
        if (!Game.Ready)
            return 0;

        if (++_currentTickIndex >= _values.Length)
            _currentTickIndex = 0;

        _values[_currentTickIndex] = _pickedItemCount - _lastTickValue;
        _lastTickValue = _pickedItemCount;

        var sum = _values.Sum(val => val);
        var result = sum / (double)_values.Length * 3600;

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
