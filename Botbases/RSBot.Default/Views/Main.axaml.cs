using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Platform.Storage;
using Avalonia.VisualTree;
using DynamicData;
using RSBot.Core;
using RSBot.Core.Event;
using RSBot.Core.Extensions;
using RSBot.Core.Objects;
using RSBot.Core.UI;
using RSBot.Default.Views.Dialogs;
using RSBot.Default.Views.Models;

namespace RSBot.Default.Views;

public partial class Main : UserControl
{
    private MainViewModel _viewModel = new();
    private const int ScriptRecorderOwnerId = 2000;

    private bool _settingsLoaded;

    /// <summary>
    /// Initializes a new instance of the <see cref="Main" /> class.
    /// </summary>
    public Main()
    {
        InitializeComponent();
        DataContext = _viewModel;

        SubscribeEvents();
    }

    /// <summary>
    ///     Subscribes the events.
    /// </summary>
    private void SubscribeEvents()
    {
        EventManager.SubscribeEvent("OnLoadCharacter", OnLoadCharacter);
        EventManager.SubscribeEvent("OnSetTrainingArea", OnSetTrainingArea);
        EventManager.SubscribeEvent("OnSaveScript", new Action<int, string>(OnSaveScript));
    }

    /// <summary>
    ///     Loads the settings.
    /// </summary>
    private void LoadSettings()
    {
        const string key = "RSBot.Training.";

        checkUseMount.IsChecked = PlayerConfig.Get(key + checkUseMount.Name, true);
        checkCastBuffs.IsChecked = PlayerConfig.Get(key + checkCastBuffs.Name, true);
        checkUseSpeedDrug.IsChecked = PlayerConfig.Get(key + checkUseSpeedDrug.Name, true);
        checkBoxUseReverse.IsChecked = PlayerConfig.Get(key + checkBoxUseReverse.Name, true);


        checkBerzerkWhenFull.IsChecked = PlayerConfig.Get(key + checkBerzerkWhenFull.Name, true);
        checkBerzerkMonsterAmount.IsChecked = PlayerConfig.Get(key + checkBerzerkMonsterAmount.Name, true);
        checkBerzerkAvoidance.IsChecked = PlayerConfig.Get(key + checkBerzerkAvoidance.Name, true);
        checkBerserkOnMonsterRarity.IsChecked = PlayerConfig.Get(key + checkBerserkOnMonsterRarity.Name, true);

        numBerzerkMonsterAmount.Value = PlayerConfig.Get(key + numBerzerkMonsterAmount.Name, numBerzerkMonsterAmount.Value);

        checkBoxDimensionPillar.IsChecked = PlayerConfig.Get(key + checkBoxDimensionPillar.Name, true);
        checkAttackWeakerFirst.IsChecked = PlayerConfig.Get(key + checkAttackWeakerFirst.Name, true);

        radioCenter.IsChecked = PlayerConfig.Get(key + radioCenter.Name, false);
        radioWalkAround.IsChecked = PlayerConfig.Get(key + radioWalkAround.Name, true);

        LoadAvoidance();
    }

    /// <summary>
    ///     Saves the settings.
    /// </summary>
    private void ApplySettings()
    {
        const string key = "RSBot.Training.";

        PlayerConfig.Set(key + checkUseMount.Name, checkUseMount.IsChecked ?? false);
        PlayerConfig.Set(key + checkCastBuffs.Name, checkCastBuffs.IsChecked ?? false);
        PlayerConfig.Set(key + checkUseSpeedDrug.Name, checkUseSpeedDrug.IsChecked ?? false);
        PlayerConfig.Set(key + checkBoxUseReverse.Name, checkBoxUseReverse.IsChecked ?? false);

        PlayerConfig.Set(key + checkBerzerkWhenFull.Name, checkBerzerkWhenFull.IsChecked ?? false);
        PlayerConfig.Set(key + checkBerzerkMonsterAmount.Name, checkBerzerkMonsterAmount.IsChecked ?? false);
        PlayerConfig.Set(key + checkBerzerkAvoidance.Name, checkBerzerkAvoidance.IsChecked ?? false);
        PlayerConfig.Set(key + checkBerserkOnMonsterRarity.Name, checkBerserkOnMonsterRarity.IsChecked ?? false);

        PlayerConfig.Set(key + numBerzerkMonsterAmount.Name, numBerzerkMonsterAmount.Value);

        PlayerConfig.Set(key + checkBoxDimensionPillar.Name, checkBoxDimensionPillar.IsChecked ?? false);
        PlayerConfig.Set(key + checkAttackWeakerFirst.Name, checkAttackWeakerFirst.IsChecked ?? false);

        PlayerConfig.Set(key + radioCenter.Name, radioCenter.IsChecked ?? false);
        PlayerConfig.Set(key + radioWalkAround.Name, radioWalkAround.IsChecked ?? false);
    }

    /// <summary>
    ///     Handles the CheckedChanged event of the settings control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
    private void settings_CheckedChanged(object sender, RoutedEventArgs e)
    {
        if (_settingsLoaded)
            ApplySettings();
    }

    /// <summary>
    ///     Handles the ValueChanged event of the numSettings control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
    private void numSettings_ValueChanged(object sender, RoutedEventArgs e)
    {
        if (_settingsLoaded)
            ApplySettings();
    }


    /// <summary>
    ///     Called when the script recorder saves a script.
    /// </summary>
    /// <param name="ownerId"></param>
    /// <param name="path"></param>
    private void OnSaveScript(int ownerId, string path)
    {
        if (ownerId != ScriptRecorderOwnerId)
            return;

        txtWalkscript.Text = path;
        PlayerConfig.Set("RSBot.Walkback.File", txtWalkscript.Text);
    }

    /// <summary>
    ///     Called when the training area has been set to a certain location. Will append a new script command "area" and
    ///     update the UI.
    /// </summary>
    private void OnSetTrainingArea()
    {
        var area = Kernel.Bot.Botbase.Area;

        txtXCoord.Text = area.Position.X.ToString("0.0");
        txtYCoord.Text = area.Position.Y.ToString("0.0");
        txtRadius.Text = area.Radius.ToString();

        EventManager.FireEvent("AppendScriptCommand", area.GetScriptLine());
    }

    /// <summary>
    ///     Saves the avoidance.
    /// </summary>
    private void SaveAvoidance()
    {
        var avoid = _viewModel.Groups
            .Where(g => g.Header == "Avoid")
            .SelectMany(g => g.Children)
            .OfType<MonsterRarity>();


        var prefer = _viewModel.Groups
            .Where(g => g.Header == "Avoid")
            .SelectMany(g => g.Children)
            .OfType<MonsterRarity>();


        var berserk = _viewModel.Groups
            .Where(g => g.Header == "Avoid")
            .SelectMany(g => g.Children)
            .OfType<MonsterRarity>();

        PlayerConfig.SetArray("RSBot.Avoidance.Avoid", avoid);
        PlayerConfig.SetArray("RSBot.Avoidance.Prefer", prefer);
        PlayerConfig.SetArray("RSBot.Avoidance.Berserk", berserk);
    }

    /// <summary>
    ///     Loads the avoidance.
    /// </summary>
    private void LoadAvoidance()
    {
        var avoid = PlayerConfig.GetEnums<MonsterRarity>("RSBot.Avoidance.Avoid");
        var prefer = PlayerConfig.GetEnums<MonsterRarity>("RSBot.Avoidance.Prefer");
        var berserk = PlayerConfig.GetEnums<MonsterRarity>("RSBot.Avoidance.Berserk");

        foreach (var item in avoid)
        {
            _viewModel.Groups[0].Children.Add(new Core.UI.TreeViewItem
            {
                Parent = _viewModel.Groups[0],
                Name = item.GetName(),
                Tag = item
            });

            _viewModel.Groups[3].Children.Remove(item);
        }

        foreach (var item in prefer)
        {
            _viewModel.Groups[1].Children.Add(new Core.UI.TreeViewItem
            {
                Parent = _viewModel.Groups[1],
                Name = item.GetName(),
                Tag = item
            });

            _viewModel.Groups[3].Children.Remove(item);
        }

        foreach (var item in berserk)
        {
            _viewModel.Groups[2].Children.Add(new Core.UI.TreeViewItem
            {
                Parent = _viewModel.Groups[2],
                Name = item.GetName(),
                Tag = item
            });

            _viewModel.Groups[3].Children.Remove(item);
        }
    }

    /// <summary>
    ///     Handles the Click event of the btnGetCurrent control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
    private void btnGetCurrent_Click(object sender, RoutedEventArgs e)
    {
        if (!Game.Ready)
            return;

        var pos = Game.Player.Position;

        PlayerConfig.Set("RSBot.Area.Region", pos.Region);
        PlayerConfig.Set("RSBot.Area.X", pos.XOffset);
        PlayerConfig.Set("RSBot.Area.Y", pos.YOffset);
        PlayerConfig.Set("RSBot.Area.Z", pos.ZOffset);

        EventManager.FireEvent("OnSetTrainingArea");
    }

    /// <summary>
    ///     Handles the TextChanged event of the txtXCoord control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
    private void txtXCoord_TextChanged(object sender, RoutedEventArgs e)
    {
        if (!float.TryParse(txtXCoord.Text, out var result))
            return;
    }

    /// <summary>
    /// Handles the TextChanged event of the txtYCoord control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
    private void txtYCoord_TextChanged(object sender, RoutedEventArgs e)
    {
        if (!float.TryParse(txtYCoord.Text, out var result))
            return;
    }

    /// <summary>
    ///     Handles the TextChanged event of the txtRadius control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
    private void txtRadius_TextChanged(object sender, RoutedEventArgs e)
    {
        if (!int.TryParse(txtRadius.Text, out var result))
            return;

        PlayerConfig.Set("RSBot.Area.Radius", result);
    }

    /// <summary>
    ///     Handles the Click event of the btnBrowse control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
    private async void btnBrowse_Click(object sender, RoutedEventArgs e)
    {
        var topLevel = TopLevel.GetTopLevel(this);
        if (topLevel == null)
            return;

        var files = await topLevel.StorageProvider.OpenFilePickerAsync(new FilePickerOpenOptions
        {
            Title = @"Browse for a walkback script",
            AllowMultiple = false,
            FileTypeFilter = new List<FilePickerFileType>
            {
                new("RSBot Bot script")
                {
                    Patterns = ["*.rbs"]
                }
            },
        });

        if (files.Count == 0)
            return;

        txtWalkscript.Text = files[0].TryGetLocalPath();
        PlayerConfig.Set("RSBot.Walkback.File", txtWalkscript.Text);
    }

    /// <summary>
    /// Handles the Click event of the avodiance controls.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.RoutedEventArgs" /> instance containing the event data.</param>
    private void OnAvoidance_Click(object sender, RoutedEventArgs e)
    {
        var groupIndex = Convert.ToInt32((sender as MenuItem).Tag);

        if (lvAvoidance.SelectedItems.Count <= 0)
            return;

        for (var i = lvAvoidance.SelectedItems.Count - 1; i >= 0; i--)
        {
            if (lvAvoidance.SelectedItems[i] is not Core.UI.TreeViewItem item)
                continue;

            var index = Enum.GetNames(typeof(MonsterRarity)).IndexOf(item.Tag.ToString());
            _viewModel.Groups.Where(g => g.Children.Contains(item))
                .ToList()
                .ForEach(g => g.Children.Remove(item));

            if(_viewModel.Groups[groupIndex].Children.Count - 1 >= index)
                _viewModel.Groups[groupIndex].Children.Insert(index, item);
            else
                _viewModel.Groups[groupIndex].Children.Add(item);
        }

        SaveAvoidance();
    }

    /// <summary>
    /// </summary>
    private void OnLoadCharacter()
    {
        var area = Kernel.Bot.Botbase.Area;

        txtXCoord.Text = area.Position.X.ToString("0.0");
        txtYCoord.Text = area.Position.Y.ToString("0.0");
        txtRadius.Text = area.Radius.ToString();

        txtWalkscript.Text = PlayerConfig.Get<string>("RSBot.Walkback.File");
    }

    private async void buttonSelectTrainingArea_Click(object sender, RoutedEventArgs e)
    {
        var trainingArea = new TrainingAreasDialog();
        await trainingArea.ShowDialog(this.FindAncestorOfType<Window>());
        if (trainingArea.Result == DialogResult.Ok)
            EventManager.FireEvent("OnSetTrainingArea");
    }

    private async void linkAttackWeakerMobsHelp_LinkClicked(object sender, RoutedEventArgs e)
    {
        await MessageBox.Show(
             "If the player is under attack by a monster that is set to be avoided the bot will counter attack weaker mobs that are currently attacking the player first before targeting the avoided monster again. The bot will only kill weaker monsters that are attacking the player and won't start to pull new mobs to the battle.",
             "Attack weaker mobs first", MessageBoxButtons.Ok);
    }

    private void linkRecord_LinkClicked(object sender, RoutedEventArgs e)
    {
        EventManager.FireEvent("OnShowScriptRecorder", ScriptRecorderOwnerId, true);
    }

    private void Main_Load(object sender, RoutedEventArgs e)
    {
        _settingsLoaded = false;
        LoadSettings();
        _settingsLoaded = true;
    }
}