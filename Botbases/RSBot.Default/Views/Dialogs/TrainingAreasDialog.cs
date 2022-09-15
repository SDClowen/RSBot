using RSBot.Core;
using RSBot.Default.Bot.Objects;
using SDUI.Controls;
using System;
using System.Linq;
using System.Windows.Forms;

namespace RSBot.Default.Views.Dialogs
{
    public partial class TrainingAreasDialog : CleanForm
    {
        private const string DIALOG_AREA_NAME = "Enter area name";
        private const string DIALOG_AREA_DESC = "Example: For my custom party at jangan";

        public TrainingAreasDialog()
        {
            InitializeComponent();
        }

        private void buttonAccept_Click(object sender, EventArgs e)
        {
            if (listView.SelectedIndices.Count <= 0)
            {
                MessageBox.Show("Please select a training area!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DialogResult = DialogResult.Retry;
                return;
            }

            var selectedItem = listView.SelectedItems[0];
            PlayerConfig.Set("RSBot.Training.Index", selectedItem.Index);

            var trainingArea = selectedItem.Tag as TrainingArea;
            if (trainingArea == null)
            {
                DialogResult = DialogResult.Retry;
                return;
            }

            PlayerConfig.Set<float>("RSBot.Area.X", trainingArea.CenterPosition.XCoordinate);
            PlayerConfig.Set<float>("RSBot.Area.Y", trainingArea.CenterPosition.YCoordinate);
            PlayerConfig.Set<int>("RSBot.Area.Radius", trainingArea.Radius);
        }

        private void TrainingAreas_Load(object sender, EventArgs e)
        {
            var selectedIndex = PlayerConfig.Get("RSBot.Training.Index", 0);

            listView.BeginUpdate();
            listView.Items.Clear();

            var areas = PlayerConfig.GetArray<string>("RSBot.Training.Areas");
            foreach (var area in areas)
            {
                var split = area.Split("|", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
                if(split.Length <= 0)
                    continue;

                var trainingArea = TrainingArea.FromSplit(split);
                if (trainingArea == null)
                    continue;

                var regionName = Game.ReferenceManager.GetTranslation(trainingArea.CenterPosition.RegionID.ToString());

                var listViewItem = listView.Items.Add(new ListViewItem
                {
                    Tag = trainingArea
                });
                listViewItem.Text = (listViewItem.Index + 1).ToString();

                listViewItem.SubItems.AddRange(new[]
                {
                    trainingArea.Name,
                    regionName,
                    trainingArea.CenterPosition.XCoordinate.ToString("0.0"),
                    trainingArea.CenterPosition.YCoordinate.ToString("0.0"),
                    trainingArea.Radius.ToString(),
                    listViewItem.Index ==  selectedIndex ? "Yes" : "No"
                });

                if (listViewItem.Index == selectedIndex)
                    listView.SetItemState(listViewItem.Index, 2, 2);
            }

            listView.EndUpdate();
        }

        private void TrainingAreas_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.Retry)
                e.Cancel = true;
        }

        private void createToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dialog = new CreateTrainingAreaDialog();

            if(dialog.ShowDialog() == DialogResult.OK)
            {
                var position = Game.Player.Movement.Source;

                var trainingArea = new TrainingArea
                {
                    Name = dialog.TrainingName.Text,
                    CenterPosition = position,
                    Radius = (int)dialog.Radius.Value
                };

                var regionName = Game.ReferenceManager.GetTranslation(trainingArea.CenterPosition.RegionID.ToString());

                var listViewItem = listView.Items.Add(new ListViewItem
                {
                    Tag = trainingArea
                });
                listViewItem.Text = (listViewItem.Index + 1).ToString();
                listViewItem.SubItems.AddRange(new[]
                {
                    trainingArea.Name,
                    regionName,
                    trainingArea.CenterPosition.XCoordinate.ToString("0.0"),
                    trainingArea.CenterPosition.YCoordinate.ToString("0.0"),
                    trainingArea.Radius.ToString(),
                    "No"
                });

                var areas = PlayerConfig.GetArray<string>("RSBot.Training.Areas").ToList();
                areas.Add($"{trainingArea.Name}|{trainingArea.CenterPosition.XCoordinate:0.0}|{trainingArea.CenterPosition.YCoordinate:0.0}|{trainingArea.Radius}");
                PlayerConfig.SetArray("RSBot.Training.Areas", areas);
            }
        }
    }
}
