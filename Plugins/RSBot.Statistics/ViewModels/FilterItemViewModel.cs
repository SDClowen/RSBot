using ReactiveUI;
using RSBot.Statistics.Stats;

namespace RSBot.Statistics.ViewModels;

public class FilterItemViewModel : ReactiveObject
{
    private readonly IStatisticCalculator _calculator;

    public string Name => _calculator.Name;
    public string Label => _calculator.Label;

    private bool _isEnabled;
    public bool IsEnabled
    {
        get => _isEnabled;
        set => this.RaiseAndSetIfChanged(ref _isEnabled, value);
    }

    public FilterItemViewModel(IStatisticCalculator calculator)
    {
        _calculator = calculator;
    }
}
