using RSBot.Core;
using RSBot.Core.Components;

namespace RSBot.Statistics.Stats.Calculators.Static;

internal class LevelUps : IStatisticCalculator
{
    /// <summary>
    ///     The initial value
    /// </summary>
    private uint _initialValue;

    /// <inheritdoc />
    public string Name => "LevelUps";

    /// <inheritdoc />
    public string Label => LanguageManager.GetLang("Calculators.LevelUps.Label");

    /// <inheritdoc />
    public StatisticsGroup Group => StatisticsGroup.Player;

    /// <inheritdoc />
    public string ValueFormat => "{0}";

    /// <inheritdoc />
    public UpdateType UpdateType => UpdateType.Static;

    /// <inheritdoc />
    public object GetValue()
    {
        if (!Game.Ready)
            return 0;

        return Game.Player.Level - (double)_initialValue;
    }

    /// <inheritdoc />
    public void Reset()
    {
        if (!Game.Ready)
            return;

        _initialValue = Game.Player.Level;
    }

    /// <inheritdoc />
    public void Initialize() { }
}
