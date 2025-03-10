using ReactiveUI;
using RSBot.Chat.Models;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace RSBot.Chat.ViewModels;

/// <summary>
/// Base view model for chat tabs that handles message display and management
/// </summary>
public class ChatTabViewModel : ReactiveObject
{
    private const int MAX_MESSAGES = 100; // Maximum number of messages to keep in memory
    
    private string _displayText;
    private string _sendText;

    /// <summary>
    /// Gets the collection of messages in this chat tab
    /// </summary>
    protected ObservableCollection<ChatMessage> Messages { get; }

    /// <summary>
    /// Gets or sets the display text shown in the chat window
    /// </summary>
    public string DisplayText
    {
        get => _displayText;
        set => this.RaiseAndSetIfChanged(ref _displayText, value);
    }

    /// <summary>
    /// Gets or sets the text to be sent
    /// </summary>
    public string SendText
    {
        get => _sendText;
        set => this.RaiseAndSetIfChanged(ref _sendText, value);
    }

    /// <summary>
    /// Initializes a new instance of the ChatTabViewModel class
    /// </summary>
    public ChatTabViewModel()
    {
        Messages = new ObservableCollection<ChatMessage>();
    }

    /// <summary>
    /// Adds a new message to the chat tab
    /// </summary>
    /// <param name="content">The message content</param>
    /// <param name="sender">The message sender</param>
    public void AddMessage(string content, string sender = null)
    {
        var message = new ChatMessage
        {
            Content = content,
            Sender = sender,
            Timestamp = DateTime.Now
        };

        Messages.Add(message);

        // Remove old messages if we exceed the limit
        while (Messages.Count > MAX_MESSAGES)
        {
            Messages.RemoveAt(0);
        }

        // Update display text
        UpdateDisplayText();
    }

    /// <summary>
    /// Updates the display text based on the current messages
    /// </summary>
    protected virtual void UpdateDisplayText()
    {
        DisplayText = string.Join(Environment.NewLine, Messages.Select(m => 
            string.IsNullOrEmpty(m.Sender) ? m.Content : $"[{m.Sender}]: {m.Content}"));
    }

    /// <summary>
    /// Clears all messages from the chat tab
    /// </summary>
    public void Clear()
    {
        Messages.Clear();
        UpdateDisplayText();
    }
} 