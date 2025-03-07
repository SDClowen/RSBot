namespace RSBot.Party.Bundle.Commands;

/// <summary>
/// Configuration settings for party commands
/// </summary>
public class CommandConfig
{
    /// <summary>
    /// Gets or sets whether commands are enabled
    /// </summary>
    public bool EnableCommands { get; set; }

    /// <summary>
    /// Gets or sets whether whisper commands are enabled
    /// </summary>
    public bool EnableWhisperCommands { get; set; }

    /// <summary>
    /// Gets or sets whether party commands are enabled
    /// </summary>
    public bool EnablePartyCommands { get; set; }

    /// <summary>
    /// Gets or sets the list of allowed players
    /// </summary>
    public string[] AllowedPlayers { get; set; }

    /// <summary>
    /// Gets or sets the list of allowed party commands
    /// </summary>
    public string[] AllowedPartyCommands { get; set; }

    /// <summary>
    /// Gets or sets the list of allowed whisper commands
    /// </summary>
    public string[] AllowedWhisperCommands { get; set; }
} 