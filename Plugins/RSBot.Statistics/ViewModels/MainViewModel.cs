using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using System.Reactive.Disposables;
using System.Windows.Input;
using DynamicData.Binding;
using ReactiveUI;
using RSBot.Core;
using RSBot.Core.Event;
using RSBot.Statistics.Stats;
using RSBot.Statistics.Stats.Calculators;
using Splat;

namespace RSBot.Statistics.ViewModels;

/// <summary>
/// ViewModel for the statistics main view that handles statistics calculations and filtering
/// </summary>
public class MainViewModel : ReactiveObject, IActivatableViewModel
{
    private bool _initialReset = true;
    private ObservableCollection<StatisticItemViewModel> _statistics;
    private ObservableCollection<StatisticFilterViewModel> _liveFilters;
    private ObservableCollection<StatisticFilterViewModel> _staticFilters;

    public MainViewModel()
    {
        Statistics = [];
        LiveFilters = [];
        StaticFilters = [];

        ResetCommand = ReactiveCommand.Create(ExecuteReset);
        ResetSelectedCommand = ReactiveCommand.Create<StatisticItemViewModel>(ExecuteResetSelected);

        EventManager.SubscribeEvent("OnInitialized", () =>
        {
            PopulateFilterList();
            LoadSettings();

            ExecuteReset();

            PopulateStatisticsList();

            _initialReset = true;

            // Start the timer for live updates
            var timer = new System.Timers.Timer(1000);
            timer.Elapsed += (s, e) => UpdateStatistics();
            timer.Start();
        });
    }

    public ObservableCollection<StatisticItemViewModel> Statistics
    {
        get => _statistics;
        private set => this.RaiseAndSetIfChanged(ref _statistics, value);
    }

    public ObservableCollection<StatisticFilterViewModel> LiveFilters
    {
        get => _liveFilters;
        private set => this.RaiseAndSetIfChanged(ref _liveFilters, value);
    }

    public ObservableCollection<StatisticFilterViewModel> StaticFilters
    {
        get => _staticFilters;
        private set => this.RaiseAndSetIfChanged(ref _staticFilters, value);
    }

    public ICommand ResetCommand { get; }
    public ICommand ResetSelectedCommand { get; }

    public ViewModelActivator Activator => new();

    private void LoadSettings()
    {
        if (_initialReset)
            return;

        foreach (var filter in LiveFilters.Concat(StaticFilters))
            PlayerConfig.Set($"RSBot.Statistics.{filter.Name}", filter.IsChecked);
    }

    private void PopulateFilterList()
    {
        var calculators = CalculatorRegistry.Calculators.ToList();
        calculators.Reverse();

        foreach (var calculator in calculators)
        {
            var filter = new StatisticFilterViewModel(calculator.Name, calculator.Label)
            {
                IsChecked = PlayerConfig.Get($"RSBot.Statistics.{calculator.Name}", true)
            };
            filter.WhenAnyValue(x => x.IsChecked).Subscribe(_ => 
            {
                LoadSettings();
                PopulateStatisticsList();
            });

            if (calculator.UpdateType == UpdateType.Live)
                LiveFilters.Add(filter);
            else
                StaticFilters.Add(filter);
        }
    }

    private void PopulateStatisticsList()
    {
        Statistics.Clear();

        foreach (var calculator in CalculatorRegistry.Calculators)
        {
            if (!IsStatisticActive(calculator.Name))
                continue;

            var statistic = new StatisticItemViewModel(calculator);
            Statistics.Add(statistic);
        }
    }

    private void UpdateStatistics()
    {
        foreach (var statistic in Statistics)
        {
            statistic.UpdateValue();
        }
    }

    private bool IsStatisticActive(string name)
    {
        var filter = LiveFilters.Concat(StaticFilters)
            .FirstOrDefault(x => x.Name == name);
        return filter?.IsChecked ?? false;
    }

    private void ExecuteReset()
    {
        foreach (var calculator in CalculatorRegistry.Calculators)
            calculator.Reset();
    }

    private void ExecuteResetSelected(StatisticItemViewModel statistic)
    {
        statistic.Calculator.Reset();
    }
} 