using RSBot.Core.Client.ReferenceObjects;

namespace RSBot.Core.Objects;

public class Teleportation
{
    /// <summary>
    ///     Gets or sets a value indicating whether this instance is teleporting.
    /// </summary>
    /// <value>
    ///     <c>true</c> if this instance is teleporting; otherwise, <c>false</c>.
    /// </value>
    public bool IsTeleporting { get; set; }

    /// <summary>
    ///     Gets or sets the teleport destination.
    /// </summary>
    /// <value>
    ///     The teleport destination.
    /// </value>
    public RefTeleport Destination { get; set; }
}
