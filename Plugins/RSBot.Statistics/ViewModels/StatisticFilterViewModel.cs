using ReactiveUI;

namespace RSBot.Statistics.ViewModels;

/// <summary>
/// ViewModel for a statistic filter that controls visibility of statistics
/// </summary>
public class StatisticFilterViewModel : ReactiveObject
{
    private bool _isChecked;

    public StatisticFilterViewModel(string name, string label)
    {
        Name = name;
        Label = label;
    }

    public string Name { get; }
    public string Label { get; }

    public bool IsChecked
    {
        get => _isChecked;
        set => this.RaiseAndSetIfChanged(ref _isChecked, value);
    }
} 