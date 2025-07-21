using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Threading;
using RSBot.Core;
using RSBot.Statistics.Stats;
using RSBot.Statistics.Stats.Calculators;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading;

namespace RSBot.Statistics.Views
{
    public partial class Main2 : UserControl
    {
        /// <summary>
        ///     The initial reset
        /// </summary>
        private bool _initialReset = true;

        /// <summary>
        ///     Timer for updating statistics
        /// </summary>
        private Timer _timer;

        /// <summary>
        ///     Observable collection for statistics items
        /// </summary>
        public ObservableCollection<StatisticItem> StatisticsItems { get; } = new();

        /// <summary>
        ///     Initializes a new instance of the <see cref="Main" /> class.
        /// </summary>
        public Main()
        {
            InitializeComponent();

            // Initialize timer
            _timer = new Timer(RefreshTimer_Elapsed, null, 1000, 1000);

            // Set DataContext for data binding
            DataContext = this;

            // Bind the collection to the ListBox
            var lvStatistics = this.FindControl<ListBox>("lvStatistics");
            if (lvStatistics != null)
            {
                lvStatistics.ItemsSource = StatisticsItems;
            }
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        protected override void OnLoaded(RoutedEventArgs e)
        {
            base.OnLoaded(e);
            Main_Load(this, e);
        }

        /// <summary>
        ///     Loads the settings.
        /// </summary>
        private void LoadSettings()
        {
            var panelLiveFilters = this.FindControl<StackPanel>("panelLiveFilters");
            var panelStaticFilters = this.FindControl<StackPanel>("panelStaticFilters");

            if (panelLiveFilters != null)
            {
                foreach (var check in panelLiveFilters.Children.OfType<CheckBox>())
                    check.IsChecked = PlayerConfig.Get($"RSBot.Statistics.{check.Name}", true);
            }

            if (panelStaticFilters != null)
            {
                foreach (var check in panelStaticFilters.Children.OfType<CheckBox>())
                    check.IsChecked = PlayerConfig.Get($"RSBot.Statistics.{check.Name}", true);
            }
        }

        /// <summary>
        ///     Saves the settings.
        /// </summary>
        private void SaveSettings()
        {
            if (_initialReset)
                return;

            var panelLiveFilters = this.FindControl<StackPanel>("panelLiveFilters");
            var panelStaticFilters = this.FindControl<StackPanel>("panelStaticFilters");

            if (panelLiveFilters != null)
            {
                foreach (CheckBox check in panelLiveFilters.Children.OfType<CheckBox>())
                    PlayerConfig.Set($"RSBot.Statistics.{check.Name}", check.IsChecked ?? false);
            }

            if (panelStaticFilters != null)
            {
                foreach (CheckBox check in panelStaticFilters.Children.OfType<CheckBox>())
                    PlayerConfig.Set($"RSBot.Statistics.{check.Name}", check.IsChecked ?? false);
            }
        }

        /// <summary>
        ///     Populates the filter list.
        /// </summary>
        private void PopulateFilterList()
        {
            var calculators = CalculatorRegistry.Calculators;
            calculators.Reverse();

            var panelLiveFilters = this.FindControl<StackPanel>("panelLiveFilters");
            var panelStaticFilters = this.FindControl<StackPanel>("panelStaticFilters");

            Dispatcher.UIThread.Post(() =>
            {
                foreach (var calculator in calculators)
                {
                    var checkBox = new CheckBox
                    {
                        Content = calculator.Label,
                        Name = calculator.Name,
                        Margin = new Thickness(0, 2)
                    };

                    checkBox.Click += Filter_CheckedChanged;

                    if (calculator.UpdateType == UpdateType.Live)
                        panelLiveFilters?.Children.Add(checkBox);
                    else
                        panelStaticFilters?.Children.Add(checkBox);
                }
            });
        }

        /// <summary>
        ///     Populates the statistics list.
        /// </summary>
        private void PopulateStatisticsList()
        {
            Dispatcher.UIThread.Post(() =>
            {
                StatisticsItems.Clear();

                foreach (var calculator in CalculatorRegistry.Calculators)
                {
                    if (!StatisticActive(calculator.Name))
                        continue;

                    var item = new StatisticItem
                    {
                        Name = calculator.Label,
                        Value = "0",
                        Calculator = calculator,
                        Group = calculator.Group
                    };

                    StatisticsItems.Add(item);
                }
            });
        }

        /// <summary>
        ///     Updates the statistics.
        /// </summary>
        private void UpdateStatistics()
        {
            Dispatcher.UIThread.Post(() =>
            {
                foreach (var item in StatisticsItems)
                {
                    if (item.Calculator != null)
                    {
                        item.Value = string.Format(item.Calculator.ValueFormat, item.Calculator.GetValue());
                    }
                }
            });
        }

        /// <summary>
        ///     Returns a value indicating if a specified statistic is active.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        private bool StatisticActive(string name)
        {
            var panelLiveFilters = this.FindControl<StackPanel>("panelLiveFilters");
            var panelStaticFilters = this.FindControl<StackPanel>("panelStaticFilters");

            var liveCheckBox = panelLiveFilters?.Children.OfType<CheckBox>()
                .FirstOrDefault(c => c.Name == name);
            if (liveCheckBox != null)
                return liveCheckBox.IsChecked ?? false;

            var staticCheckBox = panelStaticFilters?.Children.OfType<CheckBox>()
                .FirstOrDefault(c => c.Name == name);
            if (staticCheckBox != null)
                return staticCheckBox.IsChecked ?? false;

            return false;
        }

        /// <summary>
        ///     Handles the CheckedChanged event of the Filter control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
        private void Filter_CheckedChanged(object sender, RoutedEventArgs e)
        {
            SaveSettings();
            PopulateStatisticsList();
        }

        /// <summary>
        ///     Handles the Elapsed event of the RefreshTimer control.
        /// </summary>
        /// <param name="state">The state object.</param>
        private void RefreshTimer_Elapsed(object state)
        {
            try
            {
                UpdateStatistics();
            }
            catch
            {
                // Ignore exceptions
            }
        }

        /// <summary>
        ///     Handles the Click event of the btnReset control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            foreach (var calculator in CalculatorRegistry.Calculators)
                calculator.Reset();
        }

        private void resetToolStripMenuItem_Click(object sender, RoutedEventArgs e)
        {
            var lvStatistics = this.FindControl<ListBox>("lvStatistics");
            if (lvStatistics?.SelectedItems != null)
            {
                foreach (StatisticItem item in lvStatistics.SelectedItems)
                {
                    item.Calculator?.Reset();
                }
            }
        }

        /// <summary>
        ///     Occurs when Main form is loaded.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Main_Load(object sender, RoutedEventArgs e)
        {
            // Don't reset after teleportation or something equal
            if (!_initialReset)
                return;

            PopulateFilterList();
            LoadSettings();

            foreach (var calculator in CalculatorRegistry.Calculators)
                calculator.Reset();

            PopulateStatisticsList();
            _initialReset = false;
        }

        /// <summary>
        /// Dispose resources when the control is unloaded
        /// </summary>
        protected override void OnUnloaded(RoutedEventArgs e)
        {
            _timer?.Dispose();
            base.OnUnloaded(e);
        }
    }

    /// <summary>
    /// Represents a statistic item for data binding
    /// </summary>
    public class StatisticItem : INotifyPropertyChanged
    {
        private string _name;
        private string _value;

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public string Value
        {
            get => _value;
            set
            {
                _value = value;
                OnPropertyChanged(nameof(Value));
            }
        }

        internal IStatisticCalculator Calculator { get; set; }
        internal StatisticsGroup Group { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}