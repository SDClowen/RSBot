using System;

namespace RSBot.Chat.Models;

/// <summary>
/// Represents a single chat message in the chat system
/// </summary>
public class ChatMessage
{
    /// <summary>
    /// Gets or sets the content of the message
    /// </summary>
    public string Content { get; set; }

    /// <summary>
    /// Gets or sets the sender of the message
    /// </summary>
    public string Sender { get; set; }

    /// <summary>
    /// Gets or sets the timestamp when the message was received
    /// </summary>
    public DateTime Timestamp { get; set; }
} 