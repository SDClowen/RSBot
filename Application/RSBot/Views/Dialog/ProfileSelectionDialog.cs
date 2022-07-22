using RSBot.Core;
using SDUI.Controls;
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace RSBot.Views.Dialog
{
    public partial class ProfileSelectionDialog : CleanForm
    {
        /// <summary>
        /// Gets the selected profile.
        /// </summary>
        /// <value>
        /// The selected profile.
        /// </value>
        public string SelectedProfile { get; private set; }

        private Config _profileConfig;

        public ProfileSelectionDialog()
        {
            InitializeComponent();

            LoadProfiles();
        }

        private void LoadProfiles()
        {
            comboProfiles.Items.Clear();
            var profileFilePath = Path.Combine(Environment.CurrentDirectory, "User", "Profiles.rs");

            _profileConfig = new Config(profileFilePath);

            var profiles = _profileConfig.GetArray<string>("RSBot.Profiles", '|').ToList(); //Using ':' instead of comma, because : is not available inside file paths.

            //Add the default profile if no profiles have been saved by the user
            if (profiles.Count == 0)
            {
                profiles.Add("Default"); //Always points to Data\Default.rs

                _profileConfig.SetArray("RSBot.Profiles", profiles); //Save default to profiles
                _profileConfig.Save();
            }

            foreach (var profile in profiles)
            {
                comboProfiles.Items.Add(profile);
            }

            comboProfiles.Items.Add("New..."); //The last item is ALWAYS new

            comboProfiles.SelectedItem = _profileConfig.Get("RSBot.SelectedProfile", "Default");
        }

        private void comboProfiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboProfiles.SelectedItem == null)
                return;

            if (comboProfiles.SelectedIndex != comboProfiles.Items.Count - 1) //New...?
            {
                SelectedProfile = (string)comboProfiles.SelectedItem;

                _profileConfig.Set("RSBot.SelectedProfile", SelectedProfile);

                _profileConfig.Save();
            }
            else //New profile...
            {
                SelectedProfile = CreateNewProfile();

                LoadProfiles();
            }
        }

        private string CreateNewProfile()
        {
            var inputDialog = new InputDialog("New profile", "New profile", "Please enter a profile name");

            if (inputDialog.ShowDialog() != DialogResult.OK)
                return string.Empty;

            var profileName = (string)inputDialog.Value;

            if (profileName.LastIndexOfAny(Path.GetInvalidFileNameChars(), 0) != -1)
            {
                MessageBox.Show("The profile name contains invalid characters!", "Invalid name", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return string.Empty;
            }

            var existingProfiles = _profileConfig.GetArray<string>("RSBot.Profiles", '|').ToList();

            if (existingProfiles.Contains(profileName))
            {
                MessageBox.Show($"The profile name '{profileName}' already exists!", "Invalid name", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            existingProfiles.Add($"{profileName}");

            _profileConfig.SetArray("RSBot.Profiles", existingProfiles, "|");
            _profileConfig.Set("RSBot.SelectedProfile", profileName);
            _profileConfig.Save();

            return profileName;
        }

        private void checkSaveSelection_CheckedChanged(object sender, EventArgs e)
        {
            _profileConfig.Set("RSBot.ShowProfileDialog", !checkSaveSelection.Checked);
            _profileConfig.Save();
        }
    }
}