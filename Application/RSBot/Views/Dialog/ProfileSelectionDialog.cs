using RSBot.Core;
using SDUI.Controls;
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using RSBot.Helper;

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

        #region Methods

        private void LoadProfiles()
        {
            comboProfiles.Items.Clear();

            var profileFilePath = ProfilePathHelper.GetProfileConfigFileName();

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
                comboProfiles.Items.Add(profile);

            comboProfiles.Items.Add("New..."); //The last item is ALWAYS new
            
            comboProfiles.SelectedItem = _profileConfig.Get("RSBot.SelectedProfile", "Default");

            if (comboProfiles.SelectedItem == null)
                comboProfiles.SelectedItem = "Default";
        }

        #endregion Methods

        #region Events

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

                return string.Empty;
            }

            existingProfiles.Add($"{profileName}");

            var newProfileDirectory = ProfilePathHelper.GetProfileDirectory(profileName);
            Directory.CreateDirectory(newProfileDirectory);

            _profileConfig.SetArray("RSBot.Profiles", existingProfiles, "|");
            _profileConfig.Set("RSBot.SelectedProfile", profileName);
            _profileConfig.Save();

            CopyOldProfileData(profileName);

            return profileName;
        }

        /// <summary>
        /// Copies the old profile data to the new profile.
        /// </summary>
        /// <param name="profileName">Name of the profile.</param>
        private static void CopyOldProfileData(string profileName)
        {
            //Copy the old profile to use it as the base
            if (profileName == Kernel.Profile)
                return;

            try
            {
                var oldProfileFilePath = ProfilePathHelper.GetProfileFile(Kernel.Profile);
                var newProfileFilePath = ProfilePathHelper.GetProfileFile(profileName);
                var oldAutoLoginFile = Path.Combine(ProfilePathHelper.GetProfileDirectory(Kernel.Profile), "autologin.data");
                var newAutoLoginFile = Path.Combine(ProfilePathHelper.GetProfileDirectory(profileName), "autologin.data");

                if (File.Exists(oldProfileFilePath))
                    File.Copy(oldProfileFilePath, newProfileFilePath);

                if (File.Exists(oldAutoLoginFile))
                    File.Copy(oldAutoLoginFile, newAutoLoginFile);
            }
            catch (Exception ex)
            {
                Log.Warn($"Could not copy old profile data to the new profile: {ex.Message}");
            }
        }

        #endregion Events

        private void checkSaveSelection_CheckedChanged(object sender, EventArgs e)
        {
            _profileConfig.Set("RSBot.ShowProfileDialog", !checkSaveSelection.Checked);
            _profileConfig.Save();
        }

        private void linkDeleteProfile_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (comboProfiles.SelectedIndex == comboProfiles.Items.Count - 1) //New...
                return;

            if (comboProfiles.SelectedIndex == 0) //Default
            {
                MessageBox.Show("You can not delete the default profile!", "Default profile",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            if (Kernel.Profile == (string) comboProfiles.SelectedItem) //Active profile?
            {
                MessageBox.Show("You can not delete the active profile!", "Profile active",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                return;
            }

            if (MessageBox.Show(
                    $"Do you want to delete the profile {comboProfiles.SelectedItem} from the list?\nThis will not delete the user data.",
                    "Delete profile?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                return;

            var profiles = _profileConfig.GetArray<string>("RSBot.Profiles", '|').ToList();
            profiles.Remove((string) comboProfiles.SelectedItem);

            _profileConfig.SetArray("RSBot.Profiles", profiles, "|");
            _profileConfig.Save();

            LoadProfiles();
        }
    }
}