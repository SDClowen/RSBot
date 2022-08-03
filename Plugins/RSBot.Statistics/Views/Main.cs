using RSBot.Core;
using RSBot.Core.Event;
using RSBot.Statistics.Stats;
using RSBot.Statistics.Stats.Calculators;
using System;
using System.Drawing;
using System.Linq;
using System.Timers;
using System.Windows.Forms;

namespace RSBot.Statistics.Views
{
    [System.ComponentModel.ToolboxItem(false)]
    public partial class Main : UserControl
    {
        /// <summary>
        /// The initial reset
        /// </summary>
        private bool _initialReset = true;

        /// <summary>
        /// Initializes a new instance of the <see cref="Main"/> class.
        /// </summary>
        public Main()
        {
            InitializeComponent();
            SubscribeEvents();
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
            foreach (var check in panelLiveFilters.Controls.OfType<SDUI.Controls.CheckBox>())
                check.Checked = PlayerConfig.Get($"RSBot.Statistics.{check.Name}", true);
            foreach (var check in panelStaticFilters.Controls.OfType<SDUI.Controls.CheckBox>())
                check.Checked = PlayerConfig.Get($"RSBot.Statistics.{check.Name}", true);
        }

        /// <summary>
        /// Saves the settings.
        /// </summary>
        private void SaveSettings()
        {
            if (_initialReset)
                return;

            foreach (SDUI.Controls.CheckBox check in panelLiveFilters.Controls)
                PlayerConfig.Set($"RSBot.Statistics.{check.Name}", check.Checked);
            foreach (SDUI.Controls.CheckBox check in panelStaticFilters.Controls)
                PlayerConfig.Set($"RSBot.Statistics.{check.Name}", check.Checked);
        }

        /// <summary>
        /// Populates the filter list.
        /// </summary>
        private void PopulateFilterList()
        {
            var calculators = CalculatorRegistry.Calculators;
            calculators.Reverse();

            this.Invoke(new Action(() =>
            {
                foreach (var calculator in calculators)
                {
                    var checkBox = new SDUI.Controls.CheckBox
                    {
                        Dock = DockStyle.Top,
                        Text = calculator.Label,
                        Name = calculator.Name,
                        Size = new Size(75, 25),
                        AutoSize = false
                    };

                    checkBox.CheckedChanged += Filter_CheckedChanged;

                    if (calculator.UpdateType == UpdateType.Live)
                        panelLiveFilters.Controls.Add(checkBox);
                    else
                        panelStaticFilters.Controls.Add(checkBox);
                }
            }));
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
                    case StatisticsGroup.Bot:
                        lvItem.Group = lvStatistics.Groups["grpBot"];
                        break;
                }

                lvStatistics.Items.Add(lvItem);
            }

            lvStatistics.EndUpdate();
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
                ? ((SDUI.Controls.CheckBox)panelLiveFilters.Controls[name]).Checked
                : ((SDUI.Controls.CheckBox)panelStaticFilters.Controls[name]).Checked;
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
        private void RefreshTimer_Elapsed(object sender, EventArgs e)
        {
            try
            {
                UpdateStatistics();
            }
            catch
            {
            }
        }

        /// <summary>
        /// Handles the Click event of the btnReset control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnReset_Click(object sender, EventArgs e)
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
            if (!_initialReset)
                return;

            PopulateFilterList();

            LoadSettings();

            foreach (var calculator in CalculatorRegistry.Calculators)
                calculator.Reset();

            PopulateStatisticsList();
            _initialReset = false;
        }
    }
}