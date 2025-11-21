using RSBot.Core;
using RSBot.Core.Components;
using RSBot.Core.Event;

namespace RSBot.Statistics.Stats.Calculators.Static;

internal class Deaths : IStatisticCalculator
{
    private int _deathsCounter;
    public string Name => "Deaths";
    public string Label => LanguageManager.GetLang("Calculators.Deaths.Label");
    public StatisticsGroup Group => StatisticsGroup.Player;
    public string ValueFormat => "{0}";
    public UpdateType UpdateType => UpdateType.Static;

    public object GetValue()
    {
        return _deathsCounter;
    }

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
