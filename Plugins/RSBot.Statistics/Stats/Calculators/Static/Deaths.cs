using RSBot.Core;
using RSBot.Core.Event;

namespace RSBot.Statistics.Stats.Calculators.Static;

internal class Deaths : IStatisticCalculator
{
    public string Name => "Deaths";
    public string Label => "Deaths";
    public StatisticsGroup Group => StatisticsGroup.Player;
    public string ValueFormat => "{0}";
    public UpdateType UpdateType => UpdateType.Static;

    private int _deathsCounter;

    public object GetValue() => _deathsCounter;

    public void Reset()
    {
        _deathsCounter = 0;
    }

    public void Initialize()
    {
        SubscribeEvents();
    }

    private void SubscribeEvents()
    {
        EventManager.SubscribeEvent("OnPlayerDied", OnPlayerDead);
    }

    private void OnPlayerDead()
    {
        if (Kernel.Bot.Running)
            _deathsCounter++;
    }
}