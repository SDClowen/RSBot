using System;
using System.Linq;
using System.Windows.Forms;
using RSBot.Core;
using RSBot.Core.Objects;
using SDUI.Controls;

namespace RSBot.Training.Views.Dialogs;

public partial class TrainingAreasDialog : UIWindowBase
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

        if (selectedItem.Tag is not Area trainingArea)
        {
            DialogResult = DialogResult.Retry;
            return;
        }

        PlayerConfig.Set("RSBot.Area.Region", trainingArea.Position.Region);
        PlayerConfig.Set("RSBot.Area.X", trainingArea.Position.XOffset);
        PlayerConfig.Set("RSBot.Area.Y", trainingArea.Position.YOffset);
        PlayerConfig.Set("RSBot.Area.Z", trainingArea.Position.ZOffset);
        PlayerConfig.Set("RSBot.Area.Radius", trainingArea.Radius);
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
            if (split.Length <= 0)
                continue;

            if (!Area.TryParse(split, out var trainingArea))
                continue;

            var regionName = Game.ReferenceManager.GetTranslation(trainingArea.Position.Region.ToString());

            var listViewItem = listView.Items.Add(new ListViewItem { Tag = trainingArea });
            listViewItem.Text = (listViewItem.Index + 1).ToString();

            listViewItem.SubItems.AddRange(
                new[]
                {
                    trainingArea.Name,
                    regionName,
                    trainingArea.Position.X.ToString("0.0"),
                    trainingArea.Position.Y.ToString("0.0"),
                    trainingArea.Radius.ToString(),
                    listViewItem.Index == selectedIndex ? "Yes" : "No",
                }
            );

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

        if (dialog.ShowDialog() == DialogResult.OK)
        {
            var position = Game.Player.Position;

            var trainingArea = new Area
            {
                Name = dialog.TrainingName.Text,
                Position = position,
                Radius = (int)dialog.Radius.Value,
            };

            var regionName = Game.ReferenceManager.GetTranslation(trainingArea.Position.Region.ToString());

            var listViewItem = listView.Items.Add(new ListViewItem { Tag = trainingArea });
            listViewItem.Text = (listViewItem.Index + 1).ToString();
            listViewItem.SubItems.AddRange(
                new[]
                {
                    trainingArea.Name,
                    regionName,
                    trainingArea.Position.X.ToString("0.0"),
                    trainingArea.Position.Y.ToString("0.0"),
                    trainingArea.Radius.ToString(),
                    "No",
                }
            );

            var areas = PlayerConfig.GetArray<string>("RSBot.Training.Areas").ToList();
            areas.Add(
                $"{trainingArea.Name}|{trainingArea.Position.Region:0.0}|{trainingArea.Position.XOffset:0.0}|{trainingArea.Position.YOffset:0.0}|{trainingArea.Position.ZOffset:0.0}|{trainingArea.Radius}"
            );
            PlayerConfig.SetArray("RSBot.Training.Areas", areas);
        }
    }

    private void removeSelectedAreaToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (listView.SelectedItems.Count <= 0)
            return;

        var selectedIndex = listView.SelectedIndices[0];
        var areas = PlayerConfig.GetArray<string>("RSBot.Training.Areas").ToList();
        areas.RemoveAt(selectedIndex);

        listView.Items.RemoveAt(selectedIndex);

        PlayerConfig.SetArray("RSBot.Training.Areas", areas.ToArray());
    }
}
