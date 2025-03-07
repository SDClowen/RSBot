using RSBot.General.Models;

namespace RSBot.General.Components;

/// <summary>
/// Manages the list of available game servers and tracks the currently joining server
/// </summary>
public static class Serverlist
{
    /// <summary>
    /// Gets or sets the list of available servers
    /// </summary>
    public static List<Server> Servers { get; set; }

    /// <summary>
    /// Gets or sets the server that the player is currently joining
    /// </summary>
    public static Server Joining { get; set; }

    /// <summary>
    /// Gets a server by its name (case-insensitive)
    /// </summary>
    /// <param name="name">The server name to search for</param>
    /// <returns>The matching server or null if not found</returns>
    public static Server GetServerByName(string name)
    {
        return Servers?.FirstOrDefault(s => s.Name.Equals(name, StringComparison.CurrentCultureIgnoreCase));
    }

    /// <summary>
    /// Sets the joining server based on its shard ID
    /// </summary>
    /// <param name="shardId">The shard ID of the server</param>
    internal static void SetJoining(ushort shardId)
    {
        Joining = Servers?.FirstOrDefault(p => p.Id == shardId);
    }
}