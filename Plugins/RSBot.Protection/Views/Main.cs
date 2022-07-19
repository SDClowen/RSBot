using RSBot.Core;
using RSBot.Core.Event;
using RSBot.Core.Objects.Skill;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using RSBot.Protection.Components.Player;

namespace RSBot.Protection.Views
{
    [System.ComponentModel.ToolboxItem(false)]
    public partial class Main : UserControl
    {
        #region Fields

        private bool _settingsLoaded;
        private bool _skillSettingsLoaded;
        private bool _statIncreaseRunning;
        #endregion Fields

        public Main()
        {
            InitializeComponent();
            SubscribeEvents();
        }

        /// <summary>
        /// Subscribes the events.
        /// </summary>
        private void SubscribeEvents()
        {
            EventManager.SubscribeEvent("OnEnterGame", OnEnterGame);
            EventManager.SubscribeEvent("OnLoadCharacter", OnLoadCharacter);

            EventManager.SubscribeEvent("OnSkillLearned", new Action<SkillInfo>(OnSkillLearned));
            EventManager.SubscribeEvent("OnSkillUpgraded", new Action<SkillInfo, SkillInfo>(OnSkillUpgraded));

            EventManager.SubscribeEvent("OnIncreaseStrength", OnIncreaseStat);
            EventManager.SubscribeEvent("OnIncreaseIntelligence", OnIncreaseStat);
        }

        /// <summary>
        /// Loads the settings.
        /// </summary>
        private void LoadSettings()
        {
            const string key = "RSBot.Protection.";

            foreach (var checkbox in groupHPMP.Controls.OfType<SDUI.Controls.CheckBox>())
                checkbox.Checked = PlayerConfig.Get<bool>(key + checkbox.Name);

            foreach (var num in groupHPMP.Controls.OfType<NumericUpDown>())
                num.Value = PlayerConfig.Get<int>(key + num.Name, 50);

            foreach (var checkbox in groupBadStatus.Controls.OfType<SDUI.Controls.CheckBox>())
                checkbox.Checked = PlayerConfig.Get<bool>(key + checkbox.Name);

            foreach (var checkbox in groupPet.Controls.OfType<SDUI.Controls.CheckBox>())
                checkbox.Checked = PlayerConfig.Get<bool>(key + checkbox.Name);

            foreach (var num in groupPet.Controls.OfType<NumericUpDown>())
                num.Value = PlayerConfig.Get<int>(key + num.Name, 50);

            foreach (var checkbox in groupBackTown.Controls.OfType<SDUI.Controls.CheckBox>())
                checkbox.Checked = PlayerConfig.Get<bool>(key + checkbox.Name);

            foreach (var num in groupBackTown.Controls.OfType<NumericUpDown>())
                num.Value = PlayerConfig.Get<int>(key + num.Name, 50);

            foreach (var checkbox in groupStatPoints.Controls.OfType<SDUI.Controls.CheckBox>())
                checkbox.Checked = PlayerConfig.Get<bool>(key + checkbox.Name);

            foreach (var num in groupStatPoints.Controls.OfType<NumericUpDown>())
                num.Value = PlayerConfig.Get<int>(key + num.Name, 0);
        }

        /// <summary>
        /// Saves the settings.
        /// </summary>
        private void ApplySettings()
        {
            const string key = "RSBot.Protection.";
            foreach (var checkbox in groupHPMP.Controls.OfType<SDUI.Controls.CheckBox>())
                PlayerConfig.Set(key + checkbox.Name, checkbox.Checked);

            foreach (var num in groupHPMP.Controls.OfType<NumericUpDown>())
                PlayerConfig.Set(key + num.Name, num.Value);

            foreach (var checkbox in groupBadStatus.Controls.OfType<SDUI.Controls.CheckBox>())
                PlayerConfig.Set(key + checkbox.Name, checkbox.Checked);

            foreach (var checkbox in groupPet.Controls.OfType<SDUI.Controls.CheckBox>())
                PlayerConfig.Set(key + checkbox.Name, checkbox.Checked);

            foreach (var num in groupPet.Controls.OfType<NumericUpDown>())
                PlayerConfig.Set(key + num.Name, num.Value);

            foreach (var checkbox in groupBackTown.Controls.OfType<SDUI.Controls.CheckBox>())
                PlayerConfig.Set(key + checkbox.Name, checkbox.Checked);

            foreach (var num in groupBackTown.Controls.OfType<NumericUpDown>())
                PlayerConfig.Set(key + num.Name, num.Value);

            foreach (var checkbox in groupStatPoints.Controls.OfType<SDUI.Controls.CheckBox>())
                PlayerConfig.Set(key + checkbox.Name, checkbox.Checked);

            foreach (var num in groupStatPoints.Controls.OfType<NumericUpDown>())
                PlayerConfig.Set(key + num.Name, num.Value);

            SkillInfo skill = null;
            if (comboSkillPlayerHP.SelectedIndex > 0)
                skill = comboSkillPlayerHP.SelectedItem as SkillInfo;

            PlayerConfig.Set(key + "HpSkill", skill == null ? 0 : skill.Id);

            if (comboSkillPlayerMP.SelectedIndex > 0)
                skill = comboSkillPlayerMP.SelectedItem as SkillInfo;

            PlayerConfig.Set(key + "MpSkill", skill == null ? 0 : skill.Id);

            if (comboSkillBadStatus.SelectedIndex > 0)
                skill = comboSkillBadStatus.SelectedItem as SkillInfo;

            PlayerConfig.Set(key + "BadStatusSkill", skill == null ? 0 : skill.Id);
        }

        /// <summary>
        /// Refreshes the skills.
        /// </summary>
        private void RefreshSkills()
        {
            _skillSettingsLoaded = false;

            comboSkillBadStatus.Items.Clear();
            comboSkillPlayerHP.Items.Clear();
            comboSkillPlayerMP.Items.Clear();

            comboSkillBadStatus.SelectedIndex = comboSkillBadStatus.Items.Add("None");
            comboSkillPlayerHP.SelectedIndex = comboSkillPlayerHP.Items.Add("None");
            comboSkillPlayerMP.SelectedIndex = comboSkillPlayerMP.Items.Add("None");

            foreach (var skill in Game.Player.Skills.KnownSkills)
            {
                if (!skill.Enabled)
                    continue;

                if (skill.IsPassive)
                    continue;

                if (skill.Record.Target_Required && !skill.Record.TargetGroup_Self)
                    continue;

                // TODO: Check is the cure skill?
                var badStatusIndex = comboSkillBadStatus.Items.Add(skill);
                var badStatusSkillId = PlayerConfig.Get<uint>("RSBot.Protection.BadStatusSkill");
                if (badStatusSkillId == skill.Id)
                    comboSkillBadStatus.SelectedIndex = badStatusIndex;

                // TODO: Check is the hp skill?
                var hpIndex = comboSkillPlayerHP.Items.Add(skill);
                var hpSkillId = PlayerConfig.Get<uint>("RSBot.Protection.HpSkill");
                if (hpSkillId == skill.Id)
                    comboSkillPlayerHP.SelectedIndex = hpIndex;

                // TODO: Check is the mp skill?
                var mpIndex = comboSkillPlayerMP.Items.Add(skill);
                var mpSkillId = PlayerConfig.Get<uint>("RSBot.Protection.MpSkill");
                if (mpSkillId == skill.Id)
                    comboSkillPlayerMP.SelectedIndex = mpIndex;
            }

            _skillSettingsLoaded = true;
        }

        /// <summary>
        /// Handles the CheckedChanged event of the settings control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void settings_CheckedChanged(object sender, EventArgs e)
        {
            if (_settingsLoaded)
                ApplySettings();
        }

        /// <summary>
        /// Handles the ValueChanged event of the numSettings control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void numSettings_ValueChanged(object sender, EventArgs e)
        {
            if (_settingsLoaded)
                ApplySettings();
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the comboSkill control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void comboSkill_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_skillSettingsLoaded)
                ApplySettings();
        }

        /// <summary>
        /// Fired when the player enters the game
        /// </summary>
        private void OnEnterGame()
        {
            _settingsLoaded = false;
            LoadSettings();
            _settingsLoaded = true;
        }

        /// <summary>
        /// Call after skill learned
        /// </summary>
        /// <param name="skill">The learned skill.</param>
        private void OnSkillLearned(SkillInfo skill)
        {
            RefreshSkills();
        }

        /// <summary>
        /// Call after skill learned
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
        /// Re-calculates the max points of the Str numeric
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numIncInt_ValueChanged(object sender, EventArgs e)
        {
            numIncStr.Maximum = 3 - numIncInt.Value;

            PlayerConfig.Set("RSBot.Protection.numIncInt", numIncInt.Value);
        }

        /// <summary>
        /// Re-calculates the max points of the Int numeric
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

            Task.Run(() => StatPointsHandler.IncreaseStatPoints((int) availableSteps));
            
            _statIncreaseRunning = true;

            buttonRun.Text = "Cancel";
        }
    }
}