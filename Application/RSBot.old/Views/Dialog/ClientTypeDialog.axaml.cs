using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using RSBot.Core.Client;

namespace RSBot.Views.Dialog;

/// <summary>
/// Dialog for selecting the client type when initializing the bot
/// </summary>
public partial class ClientTypeDialog : Window
{
    private readonly ComboBox _comboClientType;
    private bool _dialogResult;

    /// <summary>
    /// Gets the selected client type from the dialog
    /// </summary>
    public string SelectedClientType => _comboClientType.SelectedItem?.ToString();

    /// <summary>
    /// Initializes a new instance of the <see cref="ClientTypeDialog"/> class.
    /// </summary>
    public ClientTypeDialog()
    {
        InitializeComponent();

        _comboClientType = this.FindControl<ComboBox>("comboClientType");
        _comboClientType.Items = Enum.GetNames(typeof(GameClientType));
        _comboClientType.SelectedIndex = 2; // Default to Vietnam
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

    private void OkButton_Click(object sender, RoutedEventArgs e)
    {
        _dialogResult = true;
        Close();
    }

    private void CancelButton_Click(object sender, RoutedEventArgs e)
    {
        _dialogResult = false;
        Close();
    }
} 