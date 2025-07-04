using Avalonia.Controls;
using Avalonia.Interactivity;
using RSBot.Core;
using RSBot.Core.Objects;
using RSBot.Core.UI;
using RSBot.Default.Views.Models;
using System.Collections.ObjectModel;

namespace RSBot.Default.Views.Dialogs;

public partial class TrainingAreasDialog : Window
{
    public DialogResult Result { get; private set; } = DialogResult.None;

    public ObservableCollection<AreaViewModel> Areas { get; }

    private const string DIALOG_AREA_NAME = "Enter area name";
    private const string DIALOG_AREA_DESC = "Example: For my custom party at jangan";

    public TrainingAreasDialog()
    {
        InitializeComponent();
        DataContext = this;
        Areas = [];
        listView.ItemsSource = Areas;
    }

    private async void buttonAccept_Click(object sender, RoutedEventArgs e)
    {
        if (listView.SelectedItems.Count <= 0)
        {
            await MessageBox.Show("Please select a training area!", "Warning", MessageBoxButtons.Ok);
            e.Handled = false;
            return;
        }

        var selectedItem = listView.SelectedItems[0];
        PlayerConfig.Set("RSBot.Training.Index", listView.SelectedIndex);

        if (selectedItem is not Area trainingArea)
        {
            e.Handled = false;
            return;
        }

        PlayerConfig.Set("RSBot.Area.Region", trainingArea.Position.Region);
        PlayerConfig.Set("RSBot.Area.X", trainingArea.Position.XOffset);
        PlayerConfig.Set("RSBot.Area.Y", trainingArea.Position.YOffset);
        PlayerConfig.Set("RSBot.Area.Z", trainingArea.Position.ZOffset);
        PlayerConfig.Set("RSBot.Area.Radius", trainingArea.Radius);
        Result = DialogResult.Ok;
    }

    private void TrainingAreas_Load(object sender, EventArgs e)
    {
        var selectedIndex = PlayerConfig.Get("RSBot.Training.Index", 0);

        var areas = PlayerConfig.GetArray<string>("RSBot.Training.Areas");
        foreach (var area in areas)
        {
            var split = area.Split("|", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
            if (split.Length <= 0)
                continue;

            if (!Area.TryParse(split, out var trainingArea))
                continue;
            
            var regionName = Game.ReferenceManager.GetTranslation(trainingArea.Position.Region.ToString());

            var areaViewModel = new AreaViewModel
            {
                Name = trainingArea.Name,
                Region = regionName,
                X = trainingArea.Position.X,
                Y = trainingArea.Position.Y,
                Radius = trainingArea.Radius,
                IsSelected = listView.SelectedIndex == selectedIndex
            };

            Areas.Add(areaViewModel);
        }
    }

    private void TrainingAreas_FormClosing(object sender, WindowClosingEventArgs e)
    {
        if (Result == DialogResult.Retry)
            e.Cancel = true;
    }

    private async void Create_Click(object sender, RoutedEventArgs e)
    {
        var dialog = new CreateTrainingAreaDialog();
        await dialog.ShowDialog(this);
        if (dialog.Result == DialogResult.Ok)
        {
            var position = Game.Player.Position;

            var trainingArea = new Area
            {
                Name = dialog.TrainingName.Text,
                Position = position,
                Radius = (int)dialog.Radius.Value
            };

            var regionName = Game.ReferenceManager.GetTranslation(trainingArea.Position.Region.ToString());

            var area = new AreaViewModel
            {
                Name = trainingArea.Name,
                Region = regionName,
                X = trainingArea.Position.X,
                Y = trainingArea.Position.Y,
                Radius = trainingArea.Radius,
                IsSelected = false
            };

            Areas.Add(area);

            var areas = PlayerConfig.GetArray<string>("RSBot.Training.Areas").ToList();
            areas.Add(
                $"{trainingArea.Name}|{trainingArea.Position.Region:0.0}|{trainingArea.Position.XOffset:0.0}|{trainingArea.Position.YOffset:0.0}|{trainingArea.Position.ZOffset:0.0}|{trainingArea.Radius}");
            PlayerConfig.SetArray("RSBot.Training.Areas", areas);
        }
    }

    private void RemoveSelected_Click(object sender, RoutedEventArgs e)
    {
        if (listView.SelectedItems.Count <= 0)
            return;

        var areas = PlayerConfig.GetArray<string>("RSBot.Training.Areas").ToList();
        areas.RemoveAt(listView.SelectedIndex);

        Areas.RemoveAt(listView.SelectedIndex);

        PlayerConfig.SetArray("RSBot.Training.Areas", areas.ToArray());
    }

    private void CancelButton_Click(object sender, RoutedEventArgs e)
    {
        Result = DialogResult.Cancel;
        this.Close(DialogResult.Cancel);
    }
}
