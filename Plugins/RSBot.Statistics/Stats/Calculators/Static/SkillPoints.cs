using RSBot.Core;
using RSBot.Core.Components;

namespace RSBot.Statistics.Stats.Calculators.Static;

internal class SkillPoints : IStatisticCalculator
{
    /// <summary>
    /// The initial value
    /// </summary>
    private long _initialValue;

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
    public object GetValue()
    {
        if (!Game.Ready)
            return 0;
            
        return ((long)Game.Player.SkillPoints) - _initialValue;
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