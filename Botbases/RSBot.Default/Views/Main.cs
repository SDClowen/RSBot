using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using RSBot.Core;
using RSBot.Core.Event;
using RSBot.Core.Objects;
using RSBot.Default.Views.Dialogs;

using CheckBox = System.Windows.Forms.CheckBox;

namespace RSBot.Default.Views;

[ToolboxItem(false)]
public partial class Main : UserControl
{
    private const int ScriptRecorderOwnerId = 2000;

    #region Fields

    private bool _settingsLoaded;

    #endregion Fields

    /// <summary>
    ///     Initializes a new instance of the <see cref="Main" /> class.
    /// </summary>
    public Main()
    {
        InitializeComponent();
        SubscribeEvents();

        lvAvoidance.Items[0].Tag = MonsterRarity.General;
        lvAvoidance.Items[1].Tag = MonsterRarity.Champion;
        lvAvoidance.Items[2].Tag = MonsterRarity.Giant;
        lvAvoidance.Items[3].Tag = MonsterRarity.GeneralParty;
        lvAvoidance.Items[4].Tag = MonsterRarity.ChampionParty;
        lvAvoidance.Items[5].Tag = MonsterRarity.GiantParty;
        lvAvoidance.Items[6].Tag = MonsterRarity.Unique | MonsterRarity.Unique2;
        lvAvoidance.Items[7].Tag = MonsterRarity.EliteStrong;
        lvAvoidance.Items[8].Tag = MonsterRarity.Elite;
        lvAvoidance.Items[9].Tag = MonsterRarity.Event;
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

        foreach (var checkbox in groupBoxAdvanced.Controls.OfType<CheckBox>())
            checkbox.Checked = PlayerConfig.Get(key + checkbox.Name, checkbox.Checked);

        foreach (var checkbox in groupBoxBerserk.Controls.OfType<CheckBox>())
            checkbox.Checked = PlayerConfig.Get(key + checkbox.Name, checkbox.Checked);

        foreach (var num in groupBoxBerserk.Controls.OfType<System.Windows.Forms.NumericUpDown>())
            num.Value = PlayerConfig.Get(key + num.Name, num.Value);

        foreach (var checkbox in groupBoxWalkback.Controls.OfType<CheckBox>())
            checkbox.Checked = PlayerConfig.Get(key + checkbox.Name, checkbox.Checked);

        radioCenter.Checked = PlayerConfig.Get(key + radioCenter.Name, false);
        radioWalkAround.Checked = PlayerConfig.Get(key + radioWalkAround.Name, true);

        LoadAvoidance();
    }

    /// <summary>
    ///     Saves the settings.
    /// </summary>
    private void ApplySettings()
    {
        const string key = "RSBot.Training.";

        foreach (var checkbox in groupBoxAdvanced.Controls.OfType<CheckBox>())
            PlayerConfig.Set(key + checkbox.Name, checkbox.Checked);

        foreach (var checkbox in groupBoxBerserk.Controls.OfType<CheckBox>())
            PlayerConfig.Set(key + checkbox.Name, checkbox.Checked);

        foreach (var num in groupBoxBerserk.Controls.OfType<System.Windows.Forms.NumericUpDown>())
            PlayerConfig.Set(key + num.Name, num.Value);

        foreach (var checkbox in groupBoxWalkback.Controls.OfType<CheckBox>())
            PlayerConfig.Set(key + checkbox.Name, checkbox.Checked);

        PlayerConfig.Set(key + radioCenter.Name, radioCenter.Checked);
        PlayerConfig.Set(key + radioWalkAround.Name, radioWalkAround.Checked);
    }

    /// <summary>
    ///     Handles the CheckedChanged event of the settings control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    private void settings_CheckedChanged(object sender, EventArgs e)
    {
        if (_settingsLoaded)
            ApplySettings();
    }

    /// <summary>
    ///     Handles the ValueChanged event of the numSettings control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    private void numSettings_ValueChanged(object sender, EventArgs e)
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
        if (IsDisposed || Disposing)
            return;

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
        if (IsDisposed || Disposing)
            return;

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
        foreach (ListViewItem item in lvAvoidance.Items)
            if (item.Group == lvAvoidance.Groups["grpAvoid"])
                avoid.Add((MonsterRarity)item.Tag);
            else if (item.Group == lvAvoidance.Groups["grpPrefer"])
                prefer.Add((MonsterRarity)item.Tag);
            else if (item.Group == lvAvoidance.Groups["grpBerserk"])
                berserk.Add((MonsterRarity)item.Tag);

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
            var listViewItem = lvAvoidance.Items.Cast<ListViewItem>()
                .FirstOrDefault(p => ((MonsterRarity)p.Tag & item) == item);
            if (listViewItem == null)
                continue;

            listViewItem.Group = lvAvoidance.Groups[$"grp{group.Key}"];
        }
    }

    /// <summary>
    ///     Handles the Click event of the btnGetCurrent control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    private void btnGetCurrent_Click(object sender, EventArgs e)
    {
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
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    private void txtXCoord_TextChanged(object sender, EventArgs e)
    {
        if (!float.TryParse(txtXCoord.Text, out var result))
            return;
    }

    /// <summary>
    ///     Handles the TextChanged event of the txtYCoord control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    private void txtYCoord_TextChanged(object sender, EventArgs e)
    {
        if (!float.TryParse(txtYCoord.Text, out var result))
            return;
    }

    /// <summary>
    ///     Handles the TextChanged event of the txtRadius control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    private void txtRadius_TextChanged(object sender, EventArgs e)
    {
        if (!int.TryParse(txtRadius.Text, out var result))
            return;

        PlayerConfig.Set("RSBot.Area.Radius", result);
    }

    /// <summary>
    ///     Handles the Click event of the btnBrowse control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    private void btnBrowse_Click(object sender, EventArgs e)
    {
        var diag = new OpenFileDialog
        {
            Filter = @"RSBot Bot script (*.rbs)|*.rbs",
            Title = @"Browse for a walkback script"
        };

        if (diag.ShowDialog() != DialogResult.OK) return;

        txtWalkscript.Text = diag.FileName;
        PlayerConfig.Set("RSBot.Walkback.File", txtWalkscript.Text);
    }

    /// <summary>
    ///     Handles the Click event of the btnAvoid control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    private void btnAvoid_Click(object sender, EventArgs e)
    {
        if (lvAvoidance.SelectedItems.Count <= 0)
            return;

        foreach (ListViewItem item in lvAvoidance.SelectedItems)
            item.Group = lvAvoidance.Groups["grpAvoid"];

        SaveAvoidance();
    }

    /// <summary>
    ///     Handles the Click event of the btnPrefer control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    private void btnPrefer_Click(object sender, EventArgs e)
    {
        if (lvAvoidance.SelectedItems.Count <= 0) return;
        foreach (ListViewItem item in lvAvoidance.SelectedItems)
            item.Group = lvAvoidance.Groups["grpPrefer"];

        SaveAvoidance();
    }

    /// <summary>
    ///     Handles the Click event of the btnBerserk control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    private void btnBerserk_Click(object sender, EventArgs e)
    {
        if (lvAvoidance.SelectedItems.Count <= 0) return;
        foreach (ListViewItem item in lvAvoidance.SelectedItems)
            item.Group = lvAvoidance.Groups["grpBerserk"];

        SaveAvoidance();
    }

    /// <summary>
    ///     Handles the Click event of the btnNoCustomBehavior control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    private void btnNoCustomBehavior_Click(object sender, EventArgs e)
    {
        if (lvAvoidance.SelectedItems.Count <= 0) return;
        foreach (ListViewItem item in lvAvoidance.SelectedItems)
            item.Group = lvAvoidance.Groups["grpNone"];

        SaveAvoidance();
    }

    /// <summary>
    /// </summary>
    private void OnLoadCharacter()
    {
        if (IsDisposed || Disposing)
            return;

        var area = Kernel.Bot.Botbase.Area;
        //Training Area
        txtXCoord.Text = area.Position.X.ToString("0.0");
        txtYCoord.Text = area.Position.Y.ToString("0.0");
        txtRadius.Text = area.Radius.ToString();
        //Walkback
        txtWalkscript.Text = PlayerConfig.Get<string>("RSBot.Walkback.File");
    }

    private void buttonSelectTrainingArea_Click(object sender, EventArgs e)
    {
        var trainingArea = new TrainingAreasDialog();
        if (trainingArea.ShowDialog(this) == DialogResult.OK)
            EventManager.FireEvent("OnSetTrainingArea");
    }

    private void linkAttackWeakerMobsHelp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
        MessageBox.Show(
            "If the player is under attack by a monster that is set to be avoided the bot will counter attack weaker mobs that are currently attacking the player first before targeting the avoided monster again. The bot will only kill weaker monsters that are attacking the player and won't start to pull new mobs to the battle.",
            "Attack weaker mobs first", MessageBoxButtons.OK, MessageBoxIcon.Question);
    }

    private void linkRecord_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
        EventManager.FireEvent("OnShowScriptRecorder", ScriptRecorderOwnerId, true);
    }

    private void Main_Load(object sender, EventArgs e)
    {
        _settingsLoaded = false;
        LoadSettings();
        _settingsLoaded = true;
    }
}