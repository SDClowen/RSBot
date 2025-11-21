using System;
using System.IO;
using System.Windows.Forms;
using RSBot.Core.Components;
using SDUI;
using SDUI.Controls;

namespace RSBot.Views.Dialog;

public partial class ProfileSelectionDialog : UIWindowBase
{
    public ProfileSelectionDialog()
    {
        InitializeComponent();

        LoadProfiles();
        checkSaveSelection.Checked = !ProfileManager.ShowProfileDialog;
        BackColor = ColorScheme.BackColor;
    }

    /// <summary>
    ///     Gets the selected profile.
    /// </summary>
    /// <value>
    ///     The selected profile.
    /// </value>
    public string SelectedProfile { get; private set; }

    #region Methods

    private void LoadProfiles()
    {
        comboProfiles.Items.Clear();
        if (!ProfileManager.Any())
            ProfileManager.Add("Default");

        comboProfiles.Items.AddRange(ProfileManager.Profiles);
        comboProfiles.SelectedItem = ProfileManager.SelectedProfile;
    }

    private string CreateNewProfile()
    {
        var inputDialog = new InputDialog("New profile", "New profile", "Please enter a profile name");
        if (inputDialog.ShowDialog() != DialogResult.OK)
            return string.Empty;

        var profile = (string)inputDialog.Value;

        if (profile.LastIndexOfAny(Path.GetInvalidFileNameChars(), 0) != -1)
        {
            MessageBox.Show(
                "The profile name contains invalid characters!",
                "Invalid name",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            );

            return string.Empty;
        }

        if (ProfileManager.ProfileExists(profile))
        {
            MessageBox.Show(
                $"The profile name '{profile}' already exists!",
                "Invalid name",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            );

            return string.Empty;
        }

        ProfileManager.Add(profile, true);

        return profile;
    }

    #endregion Methods

    #region Events

    private void comboProfiles_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (comboProfiles.SelectedItem == null)
            return;

        SelectedProfile = (string)comboProfiles.SelectedItem;
    }

    private void checkSaveSelection_CheckedChanged(object sender, EventArgs e)
    {
        ProfileManager.ShowProfileDialog = !checkSaveSelection.Checked;
    }

    private void buttonDeleteProfile_Click(object sender, EventArgs e)
    {
        if (comboProfiles.SelectedIndex == 0) //Default
        {
            MessageBox.Show(
                "You can not delete the default profile!",
                "Default profile",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            );

            return;
        }

        if (ProfileManager.SelectedProfile == (string)comboProfiles.SelectedItem) //Active profile?
        {
            MessageBox.Show(
                "You can not delete the active profile!",
                "Profile active",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            );

            return;
        }

        if (
            MessageBox.Show(
                $"Do you want to delete the profile {comboProfiles.SelectedItem} from the list?\nThis will not delete the user data.",
                "Delete profile?",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question
            ) != DialogResult.OK
        )
            return;

        ProfileManager.Remove((string)comboProfiles.SelectedItem);

        LoadProfiles();
    }

    private void buttonCreateProfile_Click(object sender, EventArgs e)
    {
        SelectedProfile = CreateNewProfile();

        LoadProfiles();
    }

    #endregion Events
}
