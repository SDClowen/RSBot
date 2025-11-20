using System;
using RSBot.Core;
using RSBot.Core.Components;
using RSBot.Core.Event;

namespace RSBot.Statistics.Stats.Calculators.Static;

internal class Experience : IStatisticCalculator
{
    /// <summary>
    ///     The initial level
    /// </summary>
    private byte _initialLevel;

    /// <summary>
    ///     The initial offset
    /// </summary>
    private double _initialOffset;

    /// <summary>
    ///     The initial value
    /// </summary>
    private double _initialValue;

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

        var levelDifference = Game.Player.Level - _initialLevel;

        double gainedExpPercent = 0;
        var offset = _initialOffset;
        if (levelDifference >= 1)
            for (var i = levelDifference; i > 0; i--)
            {
                gainedExpPercent += 100 - offset;
                offset = 0;
            }

        gainedExpPercent +=
            Game.Player.Experience / (double)Game.ReferenceManager.GetRefLevel(Game.Player.Level).Exp_C * 100 - offset;

        return Math.Round(gainedExpPercent, 2);
    }

    /// <inheritdoc />
    public void Reset()
    {
        if (!Game.Ready)
            return;

        //EXP Percent
        _initialValue =
            Game.Player.Experience / (double)Game.ReferenceManager.GetRefLevel(Game.Player.Level).Exp_C * 100;

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
        _initialValue =
            Game.Player.Experience / (double)Game.ReferenceManager.GetRefLevel(Game.Player.Level).Exp_C * 100;
    }
}
