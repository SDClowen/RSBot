using ReactiveUI;
using RSBot.Statistics.Stats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSBot.Statistics.ViewModels;
public class StatisticItemViewModel : ReactiveObject
{
    public IStatisticCalculator Calculator { get; }
    public string Name { get; }
    public StatisticsGroup Group { get; }

    private string _value = "0";
    public string Value
    {
        get => _value;
        set => this.RaiseAndSetIfChanged(ref _value, value);
    }

    public StatisticItemViewModel(IStatisticCalculator calculator)
    {
        Calculator = calculator;
        Name = calculator.Label;
        Group = calculator.Group;
    }

    public void UpdateValue()
    {
        try
        {
            Value = string.Format(Calculator.ValueFormat, Calculator.GetValue());
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"Error updating value for {Name}: {ex.Message}");
            Value = "Error";
        }
    }
}