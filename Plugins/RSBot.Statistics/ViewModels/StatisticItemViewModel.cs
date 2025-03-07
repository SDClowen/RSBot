using ReactiveUI;
using RSBot.Statistics.Stats;
using RSBot.Statistics.Stats.Calculators;

namespace RSBot.Statistics.ViewModels;

/// <summary>
/// ViewModel for a single statistic item that displays calculator value and group information
/// </summary>
public class StatisticItemViewModel : ReactiveObject
{
    private string _value;

    public StatisticItemViewModel(IStatisticCalculator calculator)
    {
        Calculator = calculator;
        UpdateValue();
    }

    public IStatisticCalculator Calculator { get; }
    public string Label => Calculator.Label;
    public StatisticsGroup Group => Calculator.Group;

    public string Value
    {
        get => _value;
        private set => this.RaiseAndSetIfChanged(ref _value, value);
    }

    public void UpdateValue()
    {
        Value = string.Format(Calculator.ValueFormat, Calculator.GetValue());
    }
} 