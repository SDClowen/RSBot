using System;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using RSBot.Core;
using RSBot.Core.Event;
using RSBot.Core.Objects.Skill;
using RSBot.Protection.Components.Player;

using CheckBox = System.Windows.Forms.CheckBox;

namespace RSBot.Protection.Views;

[ToolboxItem(false)]
public partial class Main : UserControl
{
    public Main()
    {
        InitializeComponent();
        SubscribeEvents();
    }

    /// <summary>
    ///     Subscribes the events.
    /// </summary>
    private void SubscribeEvents()
    {
        EventManager.SubscribeEvent("OnLoadCharacter", OnLoadCharacter);

        EventManager.SubscribeEvent("OnSkillLearned", new Action<SkillInfo>(OnSkillLearned));
        EventManager.SubscribeEvent("OnSkillUpgraded", new Action<SkillInfo, SkillInfo>(OnSkillUpgraded));

        EventManager.SubscribeEvent("OnIncreaseStrength", OnIncreaseStat);
        EventManager.SubscribeEvent("OnIncreaseIntelligence", OnIncreaseStat);
    }

    /// <summary>
    ///     Loads the settings.
    /// </summary>
    private void LoadSettings()
    {
        const string key = "RSBot.Protection.";

        foreach (var checkbox in groupHPMP.Controls.OfType<CheckBox>())
            checkbox.Checked = PlayerConfig.Get(key + checkbox.Name, checkbox.Checked);

        foreach (var num in groupHPMP.Controls.OfType<System.Windows.Forms.NumericUpDown>())
            num.Value = PlayerConfig.Get(key + num.Name, num.Value);

        foreach (var checkbox in groupBadStatus.Controls.OfType<CheckBox>())
            checkbox.Checked = PlayerConfig.Get(key + checkbox.Name, checkbox.Checked);

        foreach (var checkbox in groupPet.Controls.OfType<CheckBox>())
            checkbox.Checked = PlayerConfig.Get(key + checkbox.Name, checkbox.Checked);

        foreach (var num in groupPet.Controls.OfType<System.Windows.Forms.NumericUpDown>())
            num.Value = PlayerConfig.Get(key + num.Name, num.Value);

        foreach (var checkbox in groupBackTown.Controls.OfType<CheckBox>())
            checkbox.Checked = PlayerConfig.Get(key + checkbox.Name, checkbox.Checked);

        foreach (var num in groupBackTown.Controls.OfType<System.Windows.Forms.NumericUpDown>())
            num.Value = PlayerConfig.Get(key + num.Name, num.Value);

        foreach (var checkbox in groupStatPoints.Controls.OfType<CheckBox>())
            checkbox.Checked = PlayerConfig.Get(key + checkbox.Name, checkbox.Checked);

        foreach (var num in groupStatPoints.Controls.OfType<System.Windows.Forms.NumericUpDown>())
            num.Value = PlayerConfig.Get(key + num.Name, num.Value);
    }

    /// <summary>
    ///     Saves the settings.
    /// </summary>
    private void ApplySettings()
    {
        const string key = "RSBot.Protection.";
        foreach (var checkbox in groupHPMP.Controls.OfType<CheckBox>())
            PlayerConfig.Set(key + checkbox.Name, checkbox.Checked);

        foreach (var num in groupHPMP.Controls.OfType<System.Windows.Forms.NumericUpDown>())
            PlayerConfig.Set(key + num.Name, num.Value);

        foreach (var checkbox in groupBadStatus.Controls.OfType<CheckBox>())
            PlayerConfig.Set(key + checkbox.Name, checkbox.Checked);

        foreach (var checkbox in groupPet.Controls.OfType<CheckBox>())
            PlayerConfig.Set(key + checkbox.Name, checkbox.Checked);

        foreach (var num in groupPet.Controls.OfType<System.Windows.Forms.NumericUpDown>())
            PlayerConfig.Set(key + num.Name, num.Value);

        foreach (var checkbox in groupBackTown.Controls.OfType<CheckBox>())
            PlayerConfig.Set(key + checkbox.Name, checkbox.Checked);

        foreach (var num in groupBackTown.Controls.OfType<System.Windows.Forms.NumericUpDown>())
            PlayerConfig.Set(key + num.Name, num.Value);

        foreach (var checkbox in groupStatPoints.Controls.OfType<CheckBox>())
            PlayerConfig.Set(key + checkbox.Name, checkbox.Checked);

        foreach (var num in groupStatPoints.Controls.OfType<System.Windows.Forms.NumericUpDown>())
            PlayerConfig.Set(key + num.Name, num.Value);

        SkillInfo skill = null;

        skill = comboSkillPlayerHP.SelectedItem as SkillInfo;
        PlayerConfig.Set(key + "HpSkill", skill?.Id);

        skill = comboSkillPlayerMP.SelectedItem as SkillInfo;
        PlayerConfig.Set(key + "MpSkill", skill?.Id);

        skill = comboSkillBadStatus.SelectedItem as SkillInfo;
        PlayerConfig.Set(key + "BadStatusSkill", skill?.Id);

        skill = null;
    }

    /// <summary>
    ///     Refreshes the skills.
    /// </summary>
    private void RefreshSkills()
    {
        _skillSettingsLoaded = false;

        comboSkillBadStatus.Items.Clear();
        comboSkillPlayerHP.Items.Clear();
        comboSkillPlayerMP.Items.Clear();

        foreach (var skill in Game.Player.Skills.KnownSkills)
        {
            if (!skill.Enabled)
                continue;

            if (skill.IsPassive)
                continue;

            if (skill.Record.Target_Required && !skill.Record.TargetGroup_Self)
                continue;

            // TODO: Check is the cure skill?
            var index = comboSkillBadStatus.Items.Add(skill);
            var skillId = PlayerConfig.Get<uint>("RSBot.Protection.BadStatusSkill");
            if (skillId == skill.Id)
                comboSkillBadStatus.SelectedIndex = index;

            // TODO: Check is the hp skill?
            index = comboSkillPlayerHP.Items.Add(skill);
            skillId = PlayerConfig.Get<uint>("RSBot.Protection.HpSkill");
            if (skillId == skill.Id)
                comboSkillPlayerHP.SelectedIndex = index;

            // TODO: Check is the mp skill?
            index = comboSkillPlayerMP.Items.Add(skill);
            skillId = PlayerConfig.Get<uint>("RSBot.Protection.MpSkill");
            if (skillId == skill.Id)
                comboSkillPlayerMP.SelectedIndex = index;
        }

        _skillSettingsLoaded = true;
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
    ///     Handles the SelectedIndexChanged event of the comboSkill control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    private void comboSkill_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (_skillSettingsLoaded)
            ApplySettings();
    }

    /// <summary>
    ///     Call after skill learned
    /// </summary>
    /// <param name="skill">The learned skill.</param>
    private void OnSkillLearned(SkillInfo skill)
    {
        RefreshSkills();
    }

    /// <summary>
    ///     Call after skill learned
    /// </summary>
    /// <param name="skill">The learned skill.</param>
    private void OnSkillUpgraded(SkillInfo oldSkill, SkillInfo newSkill)
    {
        // TODO: Update old skill ids in config
    }

    /// <summary>
    /// </summary>
    private void OnLoadCharacter()
    {
        RefreshSkills();
    }

    /// <summary>
    ///     Re-calculates the max points of the Str numeric
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void numIncInt_ValueChanged(object sender, EventArgs e)
    {
        numIncStr.Maximum = 3 - numIncInt.Value;

        PlayerConfig.Set("RSBot.Protection.numIncInt", numIncInt.Value);
    }

    /// <summary>
    ///     Re-calculates the max points of the Int numeric
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void numIncStr_ValueChanged(object sender, EventArgs e)
    {
        numIncInt.Maximum = 3 - numIncStr.Value;

        PlayerConfig.Set("RSBot.Protection.numIncStr", numIncStr.Value);
    }

    private void OnIncreaseStat()
    {
        if (Game.Player.StatPoints < numIncInt.Value + numIncStr.Value)
        {
            buttonRun.Text = "Run";

            _statIncreaseRunning = false;
        }
    }

    private void buttonRun_Click(object sender, EventArgs e)
    {
        if (_statIncreaseRunning)
        {
            buttonRun.Text = "Run";

            _statIncreaseRunning = false;

            StatPointsHandler.CancellationRequested = true;

            return;
        }

        StatPointsHandler.CancellationRequested = false;
        var stepSize = numIncInt.Value + numIncStr.Value;

        if (stepSize == 0) return;
        //Only run if at least 3 stat points can be increased
        if (Game.Player.StatPoints < stepSize)
            return;

        var availableSteps = Math.Floor(Game.Player.StatPoints / stepSize);

        if (Game.Player.StatPoints == stepSize)
            availableSteps = 1;

        if (availableSteps == 0) return;

        Task.Run(() => StatPointsHandler.IncreaseStatPoints((int)availableSteps));

        _statIncreaseRunning = true;

        buttonRun.Text = "Cancel";
    }

    /// <summary>
    ///     Occurs before Main form is displayed.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Main_Load(object sender, EventArgs e)
    {
        _settingsLoaded = false;
        LoadSettings();
        _settingsLoaded = true;
    }

    #region Fields

    private bool _settingsLoaded;
    private bool _skillSettingsLoaded;
    private bool _statIncreaseRunning;

    #endregion Fields
}