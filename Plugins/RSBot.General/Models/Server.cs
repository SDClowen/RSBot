namespace RSBot.General.Models;

/// <summary>
/// Represents a game server with its status and capacity information
/// </summary>
public class Server
{
    /// <summary>
    /// Gets or sets the server identifier
    /// </summary>
    public ushort Id { get; set; }

    /// <summary>
    /// Gets or sets the server name
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the current number of players
    /// </summary>
    public ushort CurrentCapacity { get; set; }

    /// <summary>
    /// Gets or sets the maximum number of players allowed
    /// </summary>
    public ushort MaxCapacity { get; set; }

    /// <summary>
    /// Gets or sets whether the server is online
    /// </summary>
    public bool Status { get; set; }

    /// <summary>
    /// Gets or sets the server capacity state description
    /// </summary>
    public string State { get; set; }
}