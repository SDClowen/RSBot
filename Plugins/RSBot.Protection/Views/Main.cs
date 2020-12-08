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

            PlayerConfig.Set(key + "skillPlayerHP", comboSkillPlayerHP.SelectedItem);
            PlayerConfig.Set(key + "skillPlayerMP", comboSkillPlayerMP.SelectedItem);
            PlayerConfig.Set(key + "skillBadStatus", comboSkillBadStatus.SelectedItem);
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

            foreach (var skill in Game.Player.Skills.KnownSkills)
            {
                if (!skill.Enabled) continue;
                if (skill.Record.Target_Required == 1 || skill.IsPassive) continue;

                comboSkillBadStatus.Items.Add(skill.Record.GetRealName());
                comboSkillPlayerHP.Items.Add(skill.Record.GetRealName());
                comboSkillPlayerMP.Items.Add(skill.Record.GetRealName());
            }

            comboSkillPlayerHP.SelectedItem = PlayerConfig.Get<string>("RSBot.Protection.skillPlayerHP");
            comboSkillPlayerMP.SelectedItem = PlayerConfig.Get<string>("RSBot.Protection.skillPlayerMP");
            comboSkillBadStatus.SelectedItem = PlayerConfig.Get<string>("RSBot.Protection.skillBadStatus");

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