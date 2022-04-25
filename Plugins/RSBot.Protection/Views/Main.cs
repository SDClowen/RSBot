using RSBot.Core;
using RSBot.Core.Event;
using RSBot.Core.Objects.Skill;
using System;
using System.Linq;
using System.Windows.Forms;

namespace RSBot.Protection.Views
{
    [System.ComponentModel.ToolboxItem(false)]
    public partial class Main : UserControl
    {
        #region Fields

        private bool _settingsLoaded;
        private bool _skillSettingsLoaded;

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
            EventManager.SubscribeEvent("OnLearnSkill", new Action<SkillInfo, bool>(OnLearnSkill));
        }

        /// <summary>
        /// Loads the settings.
        /// </summary>
        private void LoadSettings()
        {
            const string key = "RSBot.Protection.";

            foreach (var checkbox in groupHPMP.Controls.OfType<CheckBox>().Select(control => control))
                checkbox.Checked = PlayerConfig.Get<bool>(key + checkbox.Name);

            foreach (var num in groupHPMP.Controls.OfType<NumericUpDown>().Select(control => control))
                num.Value = PlayerConfig.Get<int>(key + num.Name, 50);

            foreach (var checkbox in groupBadStatus.Controls.OfType<CheckBox>().Select(control => control))
                checkbox.Checked = PlayerConfig.Get<bool>(key + checkbox.Name);

            foreach (var checkbox in groupPet.Controls.OfType<CheckBox>().Select(control => control))
                checkbox.Checked = PlayerConfig.Get<bool>(key + checkbox.Name);

            foreach (var num in groupPet.Controls.OfType<NumericUpDown>().Select(control => control))
                num.Value = PlayerConfig.Get<int>(key + num.Name, 50);

            foreach (var checkbox in groupBackTown.Controls.OfType<CheckBox>().Select(control => control))
                checkbox.Checked = PlayerConfig.Get<bool>(key + checkbox.Name);

            foreach (var num in groupBackTown.Controls.OfType<NumericUpDown>().Select(control => control))
                num.Value = PlayerConfig.Get<int>(key + num.Name, 50);
        }

        /// <summary>
        /// Saves the settings.
        /// </summary>
        private void ApplySettings()
        {
            const string key = "RSBot.Protection.";
            foreach (var checkbox in groupHPMP.Controls.OfType<CheckBox>().Select(control => control))
                PlayerConfig.Set(key + checkbox.Name, checkbox.Checked);

            foreach (var num in groupHPMP.Controls.OfType<NumericUpDown>().Select(control => control))
                PlayerConfig.Set(key + num.Name, num.Value);

            foreach (var checkbox in groupBadStatus.Controls.OfType<CheckBox>().Select(control => control))
                PlayerConfig.Set(key + checkbox.Name, checkbox.Checked);

            foreach (var checkbox in groupPet.Controls.OfType<CheckBox>().Select(control => control))
                PlayerConfig.Set(key + checkbox.Name, checkbox.Checked);

            foreach (var num in groupPet.Controls.OfType<NumericUpDown>().Select(control => control))
                PlayerConfig.Set(key + num.Name, num.Value);

            foreach (var checkbox in groupBackTown.Controls.OfType<CheckBox>().Select(control => control))
                PlayerConfig.Set(key + checkbox.Name, checkbox.Checked);

            foreach (var num in groupBackTown.Controls.OfType<NumericUpDown>().Select(control => control))
                PlayerConfig.Set(key + num.Name, num.Value);

            SkillInfo skillPlayerHp = null;
            if (comboSkillPlayerHP.SelectedIndex > 0)
                skillPlayerHp = comboSkillPlayerHP.SelectedItem as SkillInfo;

            PlayerConfig.Set(key + "HpSkill", skillPlayerHp == null ? 0 : skillPlayerHp.Id);

            SkillInfo skillPlayerMp = null;
            if (comboSkillPlayerMP.SelectedIndex > 0)
                skillPlayerHp = comboSkillPlayerMP.SelectedItem as SkillInfo;

            PlayerConfig.Set(key + "MpSkill", skillPlayerMp == null ? 0 : skillPlayerMp.Id);

            SkillInfo skillPlayerBadStatus = null;
            if (comboSkillBadStatus.SelectedIndex > 0)
                skillPlayerHp = comboSkillBadStatus.SelectedItem as SkillInfo;

            PlayerConfig.Set(key + "BadStatusSkill", skillPlayerBadStatus == null ? 0 : skillPlayerBadStatus.Id);
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
                if(badStatusSkillId == skill.Id)
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
        /// </summary>
        /// <param name="skill">The skill.</param>
        /// <param name="update">if set to <c>true</c> [update].</param>
        private void OnLearnSkill(SkillInfo skill, bool update)
        {
            RefreshSkills();
        }

        /// <summary>
        /// </summary>
        private void OnLoadCharacter()
        {
            RefreshSkills();
        }
    }
}