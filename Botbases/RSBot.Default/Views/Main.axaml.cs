using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Platform.Storage;
using Avalonia.VisualTree;
using DynamicData;
using RSBot.Core;
using RSBot.Core.Event;
using RSBot.Core.Objects;
using RSBot.Core.UI;
using RSBot.Default.Views.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace RSBot.Default.Views;

public partial class Main : UserControl
{
    private const int ScriptRecorderOwnerId = 2000;

    private bool _settingsLoaded;

    /// <summary>
    /// Initializes a new instance of the <see cref="Main" /> class.
    /// </summary>
    public Main()
    {
        InitializeComponent();
        DataContext = this;

        SubscribeEvents();

        lvAvoidance.Items.Add(MonsterRarity.General);
        lvAvoidance.Items.Add(MonsterRarity.Champion);
        lvAvoidance.Items.Add(MonsterRarity.Giant);
        lvAvoidance.Items.Add(MonsterRarity.GeneralParty);
        lvAvoidance.Items.Add(MonsterRarity.ChampionParty);
        lvAvoidance.Items.Add(MonsterRarity.GiantParty);
        lvAvoidance.Items.Add(MonsterRarity.Unique | MonsterRarity.Unique2);
        lvAvoidance.Items.Add(MonsterRarity.EliteStrong);
        lvAvoidance.Items.Add(MonsterRarity.Elite);
        lvAvoidance.Items.Add(MonsterRarity.Event);
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


        //foreach (var checkbox in groupBoxAdvanced.Controls.OfType<CheckBox>())
        //    checkbox.Checked = PlayerConfig.Get(key + checkbox.Name, checkbox.Checked);

        //foreach (var checkbox in groupBoxBerserk.Controls.OfType<CheckBox>())
        //    checkbox.Checked = PlayerConfig.Get(key + checkbox.Name, checkbox.Checked);

        //foreach (var num in groupBoxBerserk.Controls.OfType<System.Windows.Forms.NumericUpDown>())
        //    num.Value = PlayerConfig.Get(key + num.Name, num.Value);

        //foreach (var checkbox in groupBoxWalkback.Controls.OfType<CheckBox>())
        //    checkbox.Checked = PlayerConfig.Get(key + checkbox.Name, checkbox.Checked);

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

        //foreach (var checkbox in groupBoxAdvanced.Controls.OfType<CheckBox>())
        //    PlayerConfig.Set(key + checkbox.Name, checkbox.Checked);

        //foreach (var checkbox in groupBoxBerserk.Controls.OfType<CheckBox>())
        //    PlayerConfig.Set(key + checkbox.Name, checkbox.Checked);

        //foreach (var num in groupBoxBerserk.Controls.OfType<System.Windows.Forms.NumericUpDown>())
        //    PlayerConfig.Set(key + num.Name, num.Value);

        //foreach (var checkbox in groupBoxWalkback.Controls.OfType<CheckBox>())
        //    PlayerConfig.Set(key + checkbox.Name, checkbox.Checked);

        PlayerConfig.Set(key + radioCenter.Name, radioCenter.IsChecked);
        PlayerConfig.Set(key + radioWalkAround.Name, radioWalkAround.IsChecked);
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
        var avoid = new List<MonsterRarity>();
        var prefer = new List<MonsterRarity>();
        var berserk = new List<MonsterRarity>();
        //foreach (Monst item in lvAvoidance.Items)
        //    if (item.Group == lvAvoidance.Groups["grpAvoid"])
        //        avoid.Add((MonsterRarity)item.Tag);
        //    else if (item.Group == lvAvoidance.Groups["grpPrefer"])
        //        prefer.Add((MonsterRarity)item.Tag);
        //    else if (item.Group == lvAvoidance.Groups["grpBerserk"])
        //        berserk.Add((MonsterRarity)item.Tag);

        PlayerConfig.SetArray("RSBot.Avoidance.Avoid", avoid);
        PlayerConfig.SetArray("RSBot.Avoidance.Prefer", prefer);
        PlayerConfig.SetArray("RSBot.Avoidance.Berserk", berserk);
    }

    /// <summary>
    ///     Loads the avoidance.
    /// </summary>
    private void LoadAvoidance()
    {
        var prefer = PlayerConfig.GetEnums<MonsterRarity>("RSBot.Avoidance.Prefer").ToLookup(p => "Prefer", p => p);
        var avoid = PlayerConfig.GetEnums<MonsterRarity>("RSBot.Avoidance.Avoid").ToLookup(p => "Avoid", p => p);
        var berserk = PlayerConfig.GetEnums<MonsterRarity>("RSBot.Avoidance.Berserk").ToLookup(p => "Berserk", p => p);

        foreach (var group in avoid.Union(prefer).Union(berserk))
            foreach (var item in group)
            {
                var listViewItem = lvAvoidance.Items.Cast<MonsterRarity>()
                    .FirstOrDefault(p => (p & item) == item);
                if (listViewItem == null)
                    continue;

                //listViewItem.Group = lvAvoidance..Groups[$"grp{group.Key}"];
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
    ///     Handles the TextChanged event of the txtYCoord control.
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
    ///     Handles the Click event of the btnAvoid control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.RoutedEventArgs" /> instance containing the event data.</param>
    private void btnAvoid_Click(object sender, RoutedEventArgs e)
    {
        if (lvAvoidance.SelectedItems.Count <= 0)
            return;

        //foreach (ListViewItem item in lvAvoidance.SelectedItems)
        //    item.Group = lvAvoidance.Groups["grpAvoid"];

        SaveAvoidance();
    }

    /// <summary>
    ///     Handles the Click event of the btnPrefer control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
    private void btnPrefer_Click(object sender, RoutedEventArgs e)
    {
        //if (lvAvoidance.SelectedItems.Count <= 0) return;
        //foreach (ListViewItem item in lvAvoidance.SelectedItems)
        //    item.Group = lvAvoidance.Groups["grpPrefer"];

        SaveAvoidance();
    }

    /// <summary>
    ///     Handles the Click event of the btnBerserk control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
    private void btnBerserk_Click(object sender, RoutedEventArgs e)
    {
        //if (lvAvoidance.SelectedItems.Count <= 0) return;
        //foreach (ListViewItem item in lvAvoidance.SelectedItems)
        //    item.Group = lvAvoidance.Groups["grpBerserk"];

        SaveAvoidance();
    }

    /// <summary>
    /// Handles the Click event of the btnNoCustomBehavior control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
    private void btnNoCustomBehavior_Click(object sender, RoutedEventArgs e)
    {
        //if (lvAvoidance.SelectedItems.Count <= 0) return;
        //foreach (ListViewItem item in lvAvoidance.SelectedItems)
        //    item.Group = lvAvoidance.Groups["grpNone"];

        SaveAvoidance();
    }

    /// <summary>
    /// </summary>
    private void OnLoadCharacter()
    {
        var area = Kernel.Bot.Botbase.Area;
        //Training Area
        txtXCoord.Text = area.Position.X.ToString("0.0");
        txtYCoord.Text = area.Position.Y.ToString("0.0");
        txtRadius.Text = area.Radius.ToString();
        //Walkback
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