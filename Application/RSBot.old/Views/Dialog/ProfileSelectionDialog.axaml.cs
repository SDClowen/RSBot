using System;
using System.IO;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using RSBot.Core;
using RSBot.Core.Components;

namespace RSBot.Views.Dialog;

/// <summary>
/// Dialog for selecting and managing bot profiles
/// </summary>
public partial class ProfileSelectionDialog : Window
{
    private readonly ListBox _listProfiles;
    private readonly CheckBox _checkShowDialog;
    private bool _dialogResult;

    /// <summary>
    /// Gets the selected profile name
    /// </summary>
    public string SelectedProfile => _listProfiles.SelectedItem?.ToString();

    /// <summary>
    /// Initializes a new instance of the <see cref="ProfileSelectionDialog"/> class.
    /// </summary>
    public ProfileSelectionDialog()
    {
        InitializeComponent();

        _listProfiles = this.FindControl<ListBox>("listProfiles");
        _checkShowDialog = this.FindControl<CheckBox>("checkShowDialog");

        var btnNew = this.FindControl<Button>("btnNew");
        var btnDelete = this.FindControl<Button>("btnDelete");
        var btnOK = this.FindControl<Button>("btnOK");
        var btnCancel = this.FindControl<Button>("btnCancel");

        btnNew.Click += BtnNew_Click;
        btnDelete.Click += BtnDelete_Click;
        btnOK.Click += BtnOK_Click;
        btnCancel.Click += BtnCancel_Click;

        LoadProfiles();
        _checkShowDialog.IsChecked = ProfileManager.ShowProfileDialog;
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }

    /// <summary>
    /// Shows the dialog and returns true if OK was clicked, false otherwise
    /// </summary>
    public new bool ShowDialog(Window owner)
    {
        base.ShowDialog(owner);
        return _dialogResult;
    }

    private void LoadProfiles()
    {
        _listProfiles.Items = ProfileManager.GetProfiles();
        if (_listProfiles.Items.Cast<object>().Any())
            _listProfiles.SelectedIndex = 0;
    }

    private async void BtnNew_Click(object sender, RoutedEventArgs e)
    {
        var dialog = new TextInputDialog("New Profile", "Enter profile name:");
        if (await dialog.ShowDialog<bool>(this))
        {
            var profileName = dialog.Value;
            if (string.IsNullOrWhiteSpace(profileName))
            {
                await MessageBox.Show(this, "Please enter a valid profile name!", "Error");
                return;
            }

            if (ProfileManager.ProfileExists(profileName))
            {
                await MessageBox.Show(this, "A profile with this name already exists!", "Error");
                return;
            }

            File.Create(ProfileManager.GetProfileFile(profileName)).Close();
            LoadProfiles();
            _listProfiles.SelectedItem = profileName;
        }
    }

    private async void BtnDelete_Click(object sender, RoutedEventArgs e)
    {
        var selectedProfile = SelectedProfile;
        if (string.IsNullOrEmpty(selectedProfile))
        {
            await MessageBox.Show(this, "Please select a profile to delete!", "Error");
            return;
        }

        if (selectedProfile.Equals("Default", StringComparison.OrdinalIgnoreCase))
        {
            await MessageBox.Show(this, "Cannot delete the default profile!", "Error");
            return;
        }

        if (await MessageBox.Show(this, 
            $"Are you sure you want to delete the profile '{selectedProfile}'?", 
            "Confirm Delete",
            MessageBox.MessageBoxButtons.YesNo) == MessageBox.MessageBoxResult.Yes)
        {
            File.Delete(ProfileManager.GetProfileFile(selectedProfile));
            LoadProfiles();
        }
    }

    private void BtnOK_Click(object sender, RoutedEventArgs e)
    {
        if (string.IsNullOrEmpty(SelectedProfile))
        {
            MessageBox.Show(this, "Please select a profile!", "Error");
            return;
        }

        ProfileManager.ShowProfileDialog = _checkShowDialog.IsChecked ?? true;
        _dialogResult = true;
        Close();
    }

    private void BtnCancel_Click(object sender, RoutedEventArgs e)
    {
        _dialogResult = false;
        Close();
    }
} 