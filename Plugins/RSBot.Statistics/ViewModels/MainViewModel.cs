using ReactiveUI;
using RSBot.Core;
using RSBot.Statistics.Stats;
using RSBot.Statistics.Stats.Calculators;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Threading.Tasks;

namespace RSBot.Statistics.ViewModels
{
    public class MainViewModel : ReactiveObject, IActivatableViewModel
    {
        private readonly CompositeDisposable _disposables = new();
        private bool _initialReset = true;

        public ViewModelActivator Activator { get; } = new();

        #region Properties

        public ReactiveCommand<Unit, Unit> ResetAllCommand { get; }
        public ReactiveCommand<Unit, Unit> ResetSelectedCommand { get; }

        private ObservableCollection<FilterItemViewModel> _liveFilters = new();
        public ObservableCollection<FilterItemViewModel> LiveFilters
        {
            get => _liveFilters;
            set => this.RaiseAndSetIfChanged(ref _liveFilters, value);
        }

        private ObservableCollection<FilterItemViewModel> _staticFilters = new();
        public ObservableCollection<FilterItemViewModel> StaticFilters
        {
            get => _staticFilters;
            set => this.RaiseAndSetIfChanged(ref _staticFilters, value);
        }

        private ObservableCollection<StatisticItemViewModel> _statistics = new();
        public ObservableCollection<StatisticItemViewModel> Statistics
        {
            get => _statistics;
            set => this.RaiseAndSetIfChanged(ref _statistics, value);
        }

        private StatisticItemViewModel _selectedStatistic;
        public StatisticItemViewModel SelectedStatistic
        {
            get => _selectedStatistic;
            set => this.RaiseAndSetIfChanged(ref _selectedStatistic, value);
        }

        #endregion

        public MainViewModel()
        {
            // Commands
            ResetAllCommand = ReactiveCommand.CreateFromTask(ResetAllAsync);
            ResetSelectedCommand = ReactiveCommand.CreateFromTask(ResetSelectedAsync);

            // Setup activation
            this.WhenActivated(disposables =>
            {
                InitializeAsync().Subscribe().DisposeWith(disposables);

                // Setup timer for statistics updates
                Observable
                    .Interval(TimeSpan.FromSeconds(1))
                    .ObserveOn(RxApp.MainThreadScheduler)
                    .Subscribe(_ => UpdateStatistics())
                    .DisposeWith(disposables);

                // Watch for filter changes - Bu kısım InitializeAsync tamamlandıktan sonra çalışmalı
                Observable.Timer(TimeSpan.FromSeconds(1))
                    .Subscribe(_ => SetupFilterWatchers().DisposeWith(disposables))
                    .DisposeWith(disposables);
            });
        }

        #region Initialization

        private IObservable<Unit> InitializeAsync()
        {
            return Observable.FromAsync(async () =>
            {
                if (!_initialReset)
                    return;

                await Task.Run(() =>
                {
                    // Debug: Calculator sayısını kontrol et
                    System.Diagnostics.Debug.WriteLine($"Calculator count: {CalculatorRegistry.Calculators.Count()}");

                    PopulateFilterList();
                    LoadSettings();

                    foreach (var calculator in CalculatorRegistry.Calculators)
                        calculator.Reset();
                });

                // LoadSettings içinde PopulateStatisticsList çağrılacak, burada çağırmaya gerek yok

                _initialReset = false;
            });
        }

        private void PopulateFilterList()
        {
            var calculators = CalculatorRegistry.Calculators.ToList();
            System.Diagnostics.Debug.WriteLine($"PopulateFilterList: {calculators.Count} calculators found");

            calculators.Reverse();

            var liveFilters = new ObservableCollection<FilterItemViewModel>();
            var staticFilters = new ObservableCollection<FilterItemViewModel>();

            foreach (var calculator in calculators)
            {
                var filterItem = new FilterItemViewModel(calculator);

                if (calculator.UpdateType == UpdateType.Live)
                    liveFilters.Add(filterItem);
                else
                    staticFilters.Add(filterItem);
            }

            RxApp.MainThreadScheduler.Schedule(() =>
            {
                LiveFilters = liveFilters;
                StaticFilters = staticFilters;
                System.Diagnostics.Debug.WriteLine($"LiveFilters: {LiveFilters.Count}, StaticFilters: {StaticFilters.Count}");
            });
        }

        private void LoadSettings()
        {
            // Ana thread'de çalışacak şekilde değiştirildi
            RxApp.MainThreadScheduler.Schedule(() =>
            {
                // Önce mevcut filtreleri bekle
                Observable.Timer(TimeSpan.FromMilliseconds(100))
                    .Subscribe(_ =>
                    {
                        foreach (var filter in LiveFilters)
                        {
                            filter.IsEnabled = PlayerConfig.Get($"RSBot.Statistics.{filter.Name}", true);
                            System.Diagnostics.Debug.WriteLine($"LiveFilter {filter.Name}: {filter.IsEnabled}");
                        }

                        foreach (var filter in StaticFilters)
                        {
                            filter.IsEnabled = PlayerConfig.Get($"RSBot.Statistics.{filter.Name}", true);
                            System.Diagnostics.Debug.WriteLine($"StaticFilter {filter.Name}: {filter.IsEnabled}");
                        }

                        // Settings yüklendikten sonra statistics listesini populate et
                        PopulateStatisticsList();
                    });
            });
        }

        private void SaveSettings()
        {
            if (_initialReset)
                return;

            Task.Run(() =>
            {
                foreach (var filter in LiveFilters)
                {
                    PlayerConfig.Set($"RSBot.Statistics.{filter.Name}", filter.IsEnabled);
                }

                foreach (var filter in StaticFilters)
                {
                    PlayerConfig.Set($"RSBot.Statistics.{filter.Name}", filter.IsEnabled);
                }
            });
        }

        #endregion

        #region Filter Management

        private IDisposable SetupFilterWatchers()
        {
            var disposables = new CompositeDisposable();

            // Watch live filters
            foreach (var filter in LiveFilters)
            {
                filter.WhenAnyValue(x => x.IsEnabled)
                    .Skip(1) // Skip initial value
                    .Subscribe(_ => OnFilterChanged())
                    .DisposeWith(disposables);
            }

            // Watch static filters
            foreach (var filter in StaticFilters)
            {
                filter.WhenAnyValue(x => x.IsEnabled)
                    .Skip(1) // Skip initial value
                    .Subscribe(_ => OnFilterChanged())
                    .DisposeWith(disposables);
            }

            return disposables;
        }

        private void OnFilterChanged()
        {
            SaveSettings();
            RxApp.MainThreadScheduler.Schedule(() => PopulateStatisticsList());
        }

        private bool IsStatisticActive(string name)
        {
            // Önce Live filters'da ara
            var liveFilter = LiveFilters.FirstOrDefault(f => string.Equals(f.Name, name, StringComparison.OrdinalIgnoreCase));
            if (liveFilter != null)
            {
                System.Diagnostics.Debug.WriteLine($"LiveFilter {name} is {(liveFilter.IsEnabled ? "enabled" : "disabled")}");
                return liveFilter.IsEnabled;
            }

            // Sonra Static filters'da ara
            var staticFilter = StaticFilters.FirstOrDefault(f => string.Equals(f.Name, name, StringComparison.OrdinalIgnoreCase));
            if (staticFilter != null)
            {
                System.Diagnostics.Debug.WriteLine($"StaticFilter {name} is {(staticFilter.IsEnabled ? "enabled" : "disabled")}");
                return staticFilter.IsEnabled;
            }

            // Hiçbir filtre bulunamazsa varsayılan olarak true döndür (ilk seferde gösterilsin)
            System.Diagnostics.Debug.WriteLine($"No filter found for {name}, returning true as default");
            return true;
        }

        #endregion

        #region Statistics Management

        private void PopulateStatisticsList()
        {
            var statisticItems = new ObservableCollection<StatisticItemViewModel>();

            System.Diagnostics.Debug.WriteLine($"PopulateStatisticsList: Processing {CalculatorRegistry.Calculators.Count()} calculators");

            foreach (var calculator in CalculatorRegistry.Calculators)
            {
                bool isActive = IsStatisticActive(calculator.Name);
                System.Diagnostics.Debug.WriteLine($"Calculator {calculator.Name}: Active = {isActive}");

                if (!isActive)
                    continue;

                var item = new StatisticItemViewModel(calculator);
                statisticItems.Add(item);
            }

            System.Diagnostics.Debug.WriteLine($"Adding {statisticItems.Count} statistic items");
            Statistics = statisticItems;
        }

        private void UpdateStatistics()
        {
            try
            {
                foreach (var item in Statistics)
                {
                    item.UpdateValue();
                }
            }
            catch (Exception ex)
            {
                // Log exception if needed
                System.Diagnostics.Debug.WriteLine($"Error updating statistics: {ex.Message}");
            }
        }

        #endregion

        #region Commands

        private async Task ResetAllAsync()
        {
            await Task.Run(() =>
            {
                foreach (var calculator in CalculatorRegistry.Calculators)
                {
                    calculator.Reset();
                }
            });
        }

        private async Task ResetSelectedAsync()
        {
            if (SelectedStatistic?.Calculator != null)
            {
                await Task.Run(() =>
                {
                    SelectedStatistic.Calculator.Reset();
                });
            }
        }

        #endregion
    }
}