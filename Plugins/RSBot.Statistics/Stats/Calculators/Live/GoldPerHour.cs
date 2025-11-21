using System;
using System.Linq;
using RSBot.Core;
using RSBot.Core.Components;

namespace RSBot.Statistics.Stats.Calculators.Live;

internal class GoldPerHour : IStatisticCalculator
{
    /// <summary>
    ///     The current tick index
    /// </summary>
    private int _currentTickIndex = -1;

    /// <summary>
    ///     The initial value
    /// </summary>
    private long _lastTickValue;

    /// <summary>
    ///     The values
    /// </summary>
    private long[] _values;

    /// <inheritdoc />
    public string Name => "GoldPerHour";

    /// <inheritdoc />
    public string Label => LanguageManager.GetLang("Calculators.GoldPerHour.Label");

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

        _values[_currentTickIndex] = Convert.ToInt64(Game.Player.Gold) - _lastTickValue;
        _lastTickValue = Convert.ToInt64(Game.Player.Gold);

        return _values.Sum(val => val) / _values.Length * 3600;
    }

    /// <inheritdoc />
    public void Reset()
    {
        if (!Game.Ready)
            return;

        _lastTickValue = Convert.ToInt64(Game.Player.Gold);
        _values = new long[60];
    }

    /// <inheritdoc />
    public void Initialize()
    {
        _values = new long[60];
    }
}
