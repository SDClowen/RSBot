using Avalonia.Controls;
using ReactiveUI;
using RSBot.Views.Dialogs;
using System.Windows.Input;

namespace RSBot.ViewModels.Dialogs;

/// <summary>
/// View model for the MessageBox dialog that handles button visibility and commands.
/// Provides reactive properties and commands for the message box UI.
/// </summary>
public class MessageBoxViewModel : ReactiveObject
{
    private readonly Window _dialog;
    private readonly MessageBoxButtons _buttons;

    /// <summary>
    /// Initializes a new instance of the MessageBoxViewModel class
    /// </summary>
    /// <param name="dialog">The message box window instance</param>
    /// <param name="title">The title of the message box</param>
    /// <param name="message">The message to display</param>
    /// <param name="buttons">The buttons to show in the message box</param>
    public MessageBoxViewModel(Window dialog, string title, string message, MessageBoxButtons buttons)
    {
        _dialog = dialog;
        _buttons = buttons;
        Title = title;
        Message = message;

        OkCommand = ReactiveCommand.Create(ExecuteOk);
        YesCommand = ReactiveCommand.Create(ExecuteYes);
        NoCommand = ReactiveCommand.Create(ExecuteNo);
        CancelCommand = ReactiveCommand.Create(ExecuteCancel);
    }

    /// <summary>
    /// Gets the title of the message box
    /// </summary>
    public string Title { get; }

    /// <summary>
    /// Gets the message to display
    /// </summary>
    public string Message { get; }

    /// <summary>
    /// Gets whether the OK button should be visible
    /// </summary>
    public bool ShowOk => _buttons == MessageBoxButtons.Ok || _buttons == MessageBoxButtons.OkCancel;

    /// <summary>
    /// Gets whether the Yes and No buttons should be visible
    /// </summary>
    public bool ShowYesNo => _buttons == MessageBoxButtons.YesNo || _buttons == MessageBoxButtons.YesNoCancel;

    /// <summary>
    /// Gets whether the Cancel button should be visible
    /// </summary>
    public bool ShowCancel => _buttons == MessageBoxButtons.OkCancel || _buttons == MessageBoxButtons.YesNoCancel;

    /// <summary>
    /// Gets the command that executes when the OK button is clicked
    /// </summary>
    public ICommand OkCommand { get; }

    /// <summary>
    /// Gets the command that executes when the Yes button is clicked
    /// </summary>
    public ICommand YesCommand { get; }

    /// <summary>
    /// Gets the command that executes when the No button is clicked
    /// </summary>
    public ICommand NoCommand { get; }

    /// <summary>
    /// Gets the command that executes when the Cancel button is clicked
    /// </summary>
    public ICommand CancelCommand { get; }

    /// <summary>
    /// Handles the OK button click
    /// </summary>
    private void ExecuteOk()
    {
        _dialog.Close(MessageBoxResult.Ok);
    }

    /// <summary>
    /// Handles the Yes button click
    /// </summary>
    private void ExecuteYes()
    {
        _dialog.Close(MessageBoxResult.Yes);
    }

    /// <summary>
    /// Handles the No button click
    /// </summary>
    private void ExecuteNo()
    {
        _dialog.Close(MessageBoxResult.No);
    }

    /// <summary>
    /// Handles the Cancel button click
    /// </summary>
    private void ExecuteCancel()
    {
        _dialog.Close(MessageBoxResult.Cancel);
    }
} 