using System;
using RSBot.Core;
using RSBot.Core.Components;

namespace RSBot.Statistics.Stats.Calculators.Static;

internal class BottingTime : IStatisticCalculator
{
    #region Properties

    public string Name => "BottingTime";

    public string Label => LanguageManager.GetLang("Calculators.TimeBotting.Label");

    public StatisticsGroup Group => StatisticsGroup.Bot;

    public string ValueFormat => "{0}";

    public UpdateType UpdateType => UpdateType.Static;

    #endregion Properties

    #region Members

    private long _totalTicks;

    private long _lastTick;

    private long _currentTick;

    #endregion Members

    #region Methods

    public object GetValue()
    {
        _currentTick = DateTime.Now.Ticks;

        if (_lastTick == 0)
            _lastTick = DateTime.Now.Ticks;

        if (Kernel.Bot.Running)
            _totalTicks += _currentTick - _lastTick;

        _lastTick = _currentTick;

        var span = new TimeSpan(_totalTicks);

        return $"{span.Hours:D2}:{span.Minutes:D2}:{span.Seconds:D2}";
    }

    public void Reset()
    {
        _totalTicks = 0;
        _lastTick = 0;
        _currentTick = 0;
    }

    public void Initialize()
    {
        _totalTicks = 0;
        _lastTick = DateTime.Now.Ticks;
        _currentTick = DateTime.Now.Ticks;
    }

    #endregion Methods
}
