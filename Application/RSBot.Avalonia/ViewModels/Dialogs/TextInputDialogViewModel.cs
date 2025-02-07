using Avalonia.Controls;
using ReactiveUI;
using System.Windows.Input;

namespace RSBot.ViewModels.Dialogs;

/// <summary>
/// View model for the text input dialog
/// </summary>
public class TextInputDialogViewModel : ReactiveObject
{
    private readonly Window _owner;
    private string _input;

    public TextInputDialogViewModel(Window owner, string title, string message)
    {
        _owner = owner;
        Title = title;
        Message = message;

        OkCommand = ReactiveCommand.Create(ExecuteOk);
        CancelCommand = ReactiveCommand.Create(ExecuteCancel);
    }

    public string Title { get; }
    public string Message { get; }

    public string Input
    {
        get => _input;
        set => this.RaiseAndSetIfChanged(ref _input, value);
    }

    public ICommand OkCommand { get; }
    public ICommand CancelCommand { get; }

    private void ExecuteOk()
    {
        if (!string.IsNullOrWhiteSpace(Input))
            _owner.Close(Input);
    }

    private void ExecuteCancel()
    {
        _owner.Close(null);
    }
} 