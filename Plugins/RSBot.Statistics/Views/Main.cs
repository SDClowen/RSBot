using RSBot.Core;
using RSBot.Core.Event;
using RSBot.Statistics.Stats;
using RSBot.Statistics.Stats.Calculators;
using System.Drawing;
using System.Timers;
using System.Windows.Forms;

namespace RSBot.Statistics.Views
{
    public partial class Main : UserControl
    {
        #region Fields

        /// <summary>
        /// The refresh timer
        /// </summary>
        private System.Timers.Timer _refreshTimer;

        /// <summary>
        /// The initial reset
        /// </summary>
        private bool _initialReset = true;

        #endregion Fields

        /// <summary>
        /// Initializes a new instance of the <see cref="Main"/> class.
        /// </summary>
        public Main()
        {
            InitializeComponent();

            PopulateFilterList();
            SubscribeEvents();

            _refreshTimer = new System.Timers.Timer(1000) { AutoReset = true };
            _refreshTimer.Elapsed += RefreshTimer_Elapsed;
        }

        /// <summary>
        /// Subscribes the core events.
        /// </summary>
        private void SubscribeEvents()
        {
            EventManager.SubscribeEvent("OnLoadCharacter", OnLoadCharacter);
        }

        /// <summary>
        /// Loads the settings.
        /// </summary>
        private void LoadSettings()
        {
            foreach (CheckBox check in panelLiveFilters.Controls)
                check.Checked = PlayerConfig.Get($"RSBot.Statistics.{check.Name}", true);
            foreach (CheckBox check in panelStaticFilters.Controls)
                check.Checked = PlayerConfig.Get($"RSBot.Statistics.{check.Name}", true);
        }

        /// <summary>
        /// Saves the settings.
        /// </summary>
        private void SaveSettings()
        {
            if (_initialReset)
                return;

            foreach (CheckBox check in panelLiveFilters.Controls)
                PlayerConfig.Set($"RSBot.Statistics.{check.Name}", check.Checked);
            foreach (CheckBox check in panelStaticFilters.Controls)
                PlayerConfig.Set($"RSBot.Statistics.{check.Name}", check.Checked);
        }

        /// <summary>
        /// Populates the filter list.
        /// </summary>
        private void PopulateFilterList()
        {
            var locationX = 8;
            var locationY1 = 0;
            var locationY2 = 0;

            foreach (var calculator in CalculatorRegistry.Calculators)
            {
                var checkBox = new CheckBox
                {
                    Location = new Point(locationX, calculator.UpdateType == UpdateType.Live ? locationY1 : locationY2),
                    Width = 300,
                    Text = calculator.Label,
                    Name = calculator.Name,
                };

                checkBox.CheckedChanged += Filter_CheckedChanged;

                if (calculator.UpdateType == UpdateType.Live)
                {
                    panelLiveFilters.Controls.Add(checkBox);
                    locationY1 += 23;
                }
                else
                {
                    panelStaticFilters.Controls.Add(checkBox);
                    locationY2 += 23;
                }
            }
        }

        /// <summary>
        /// Populates the statistics list.
        /// </summary>
        private void PopulateStatisticsList()
        {
            lvStatistics.BeginUpdate();
            lvStatistics.Items.Clear();

            foreach (var calculator in CalculatorRegistry.Calculators)
            {
                if (!StatatisticActive(calculator.Name))
                    continue;

                var lvItem = new ListViewItem(calculator.Label) { Tag = calculator };
                lvItem.SubItems.Add("0");

                switch (calculator.Group)
                {
                    case StatisticsGroup.Player:
                        lvItem.Group = lvStatistics.Groups["grpPlayer"];
                        break;

                    case StatisticsGroup.Loot:
                        lvItem.Group = lvStatistics.Groups["grpLoot"];
                        break;

                    case StatisticsGroup.Enemy:
                        lvItem.Group = lvStatistics.Groups["grpEnemy"];
                        break;
                }

                lvStatistics.Items.Add(lvItem);
            }

            lvStatistics.EndUpdate();

            UpdateStatistics();
        }

        /// <summary>
        /// Updates the statistics.
        /// </summary>
        private void UpdateStatistics()
        {
            foreach (ListViewItem item in lvStatistics.Items)
            {
                var calculator = (IStatisticCalculator)item.Tag;
                item.SubItems[1].Text = string.Format(calculator.ValueFormat, calculator.GetValue());
            }
        }

        /// <summary>
        /// Returns a value indicating if a specified statistic is active.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        private bool StatatisticActive(string name)
        {
            return panelLiveFilters.Controls.ContainsKey(name)
                ? ((CheckBox)panelLiveFilters.Controls[name]).Checked
                : ((CheckBox)panelStaticFilters.Controls[name]).Checked;
        }

        /// <summary>
        /// Handles the CheckedChanged event of the Filter control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        private void Filter_CheckedChanged(object sender, System.EventArgs e)
        {
            SaveSettings();
            PopulateStatisticsList();
        }

        /// <summary>
        /// Handles the Elapsed event of the RefreshTimer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ElapsedEventArgs"/> instance containing the event data.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        private void RefreshTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            UpdateStatistics();
        }

        /// <summary>
        /// Handles the Click event of the btnReset control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnReset_Click(object sender, System.EventArgs e)
        {
            foreach (var calculator in CalculatorRegistry.Calculators)
                calculator.Reset();
        }

        /// <summary>
        /// Called when [enter game].
        /// </summary>
        private void OnLoadCharacter()
        {
            //Don't reset after teleportation or something equal
            if (!_initialReset) return;

            LoadSettings();

            foreach (var calculator in CalculatorRegistry.Calculators)
                calculator.Reset();

            PopulateStatisticsList();
            _initialReset = false;

            _refreshTimer.Start();
        }
    }
}