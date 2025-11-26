using System;
using System.Linq;
using RSBot.Core;
using RSBot.Core.Components;

namespace RSBot.Statistics.Stats.Calculators.Live;

internal class SkillPointsPerHour : IStatisticCalculator
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
    ///     The values
    /// </summary>
    private int[] _values;

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
    public object GetValue()
    {
        if (!Game.Ready)
            return 0;

        if (++_currentTickIndex >= _values.Length)
            _currentTickIndex = 0;

        _values[_currentTickIndex] = Convert.ToInt32(Game.Player.SkillPoints) - _lastTickValue;
        _lastTickValue = Convert.ToInt32(Game.Player.SkillPoints);

        return _values.Sum(val => val) / _values.Length * 3600;
    }

    /// <inheritdoc />
    public void Reset()
    {
        if (!Game.Ready)
            return;

        _lastTickValue = Convert.ToInt32(Game.Player.SkillPoints);
        _values = new int[60];
    }

    /// <inheritdoc />
    public void Initialize()
    {
        _values = new int[60];
    }
}
