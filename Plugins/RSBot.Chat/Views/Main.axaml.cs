using Avalonia.Controls;
using Avalonia.Input;
using RSBot.Chat.ViewModels;
using RSBot.Core.Objects;
using System;

namespace RSBot.Chat.Views;

/// <summary>
/// Main view for the chat window
/// </summary>
public partial class Main : UserControl
{
    private MainViewModel ViewModel => DataContext as MainViewModel;

    /// <summary>
    /// Initializes a new instance of the Main class
    /// </summary>
    public Main()
    {
        InitializeComponent();

        DataContext = new MainViewModel();
    }

    /// <summary>
    /// Appends a message to the appropriate chat area
    /// </summary>
    /// <param name="message">The message content</param>
    /// <param name="sender">The message sender</param>
    /// <param name="type">The type of chat message</param>
    public void AppendMessage(string message, string sender, ChatType type)
    {
        var formattedMessage = $"[{sender}]: {message}";
        ViewModel?.OnChatMessage(formattedMessage, type);
    }

    /// <summary>
    /// Appends a message to the unique monsters area
    /// </summary>
    /// <param name="message">The message content</param>
    public void AppendUniqueMessage(string message)
    {
        ViewModel?.OnChatMessage(message + Environment.NewLine, ChatType.Unique);
    }

    private void OnSendAllKeyDown(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.Enter)
            ViewModel?.SendAllCommand.Execute().Subscribe();
    }

    private void OnSendPrivateKeyDown(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.Enter)
            ViewModel?.SendPrivateCommand.Execute().Subscribe();
    }

    private void OnSendPartyKeyDown(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.Enter)
            ViewModel?.SendPartyCommand.Execute().Subscribe();
    }

    private void OnSendGuildKeyDown(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.Enter)
            ViewModel?.SendGuildCommand.Execute().Subscribe();
    }

    private void OnSendUnionKeyDown(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.Enter)
            ViewModel?.SendUnionCommand.Execute().Subscribe();
    }

    private void OnSendAcademyKeyDown(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.Enter)
            ViewModel?.SendAcademyCommand.Execute().Subscribe();
    }
} 