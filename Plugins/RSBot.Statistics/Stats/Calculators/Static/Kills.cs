using RSBot.Core;
using RSBot.Core.Components;
using RSBot.Core.Event;

namespace RSBot.Statistics.Stats.Calculators.Static;

internal class Kills : IStatisticCalculator
{
    /// <summary>
    ///     The initial value
    /// </summary>
    private int _lastTickValue;

    /// <inheritdoc />
    public string Name => "Kills";

    /// <inheritdoc />
    public string Label => LanguageManager.GetLang("Calculators.Kills.Label");

    /// <inheritdoc />
    public StatisticsGroup Group => StatisticsGroup.Enemy;

    /// <inheritdoc />
    public string ValueFormat => "{0}";

    /// <inheritdoc />
    public UpdateType UpdateType => UpdateType.Static;

    /// <inheritdoc />
    public object GetValue()
    {
        return !Game.Ready ? 0 : _lastTickValue;
    }

    /// <inheritdoc />
    public void Reset()
    {
        _lastTickValue = 0;
    }

    /// <inheritdoc />
    public void Initialize()
    {
        EventManager.SubscribeEvent("OnKillEnemy", OnKillEnemy);
    }

    private void OnKillEnemy()
    {
        _lastTickValue++;
    }
}
