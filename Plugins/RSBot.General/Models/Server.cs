namespace RSBot.General.Models;

public class Server
{
    /// <summary>
    ///     Gets or sets the identifier.
    /// </summary>
    /// <value>
    ///     The identifier.
    /// </value>
    public ushort Id { get; set; }

    /// <summary>
    ///     Gets or sets the name.
    /// </summary>
    /// <value>
    ///     The name.
    /// </value>
    public string Name { get; set; }

    /// <summary>
    ///     Gets or sets the current capacity.
    /// </summary>
    /// <value>
    ///     The current capacity.
    /// </value>
    public ushort CurrentCapacity { get; set; }

    /// <summary>
    ///     Gets or sets the maximum capacity.
    /// </summary>
    /// <value>
    ///     The maximum capacity.
    /// </value>
    public ushort MaxCapacity { get; set; }

    /// <summary>
    ///     Gets or sets the status.
    /// </summary>
    /// <value>
    ///     The status.
    /// </value>
    public bool Status { get; set; }

    /// <summary>
    ///     Gets or sets the server capacity state.
    /// </summary>
    /// <value>
    ///     The status.
    /// </value>
    public string State { get; set; }
}
