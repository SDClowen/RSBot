using System.Collections.Generic;
using System.Linq;
using RSBot.General.Models;

namespace RSBot.General.Components;

public static class Serverlist
{
    /// <summary>
    ///     Gets or sets the servers.
    /// </summary>
    /// <value>
    ///     The servers.
    /// </value>
    public static List<Server> Servers { get; set; }

    // <summary>
    /// Gets or sets the joining server.
    /// </summary>
    /// <value>
    ///     The server.
    /// </value>
    public static Server Joining { get; set; }

    /// <summary>
    ///     Gets the server by its name
    /// </summary>
    /// <param name="name">The name.</param>
    /// <returns></returns>
    public static Server GetServerByName(string name)
    {
        return Servers.FirstOrDefault(s => s.Name.ToLower() == name.ToLower());
    }

    /// <summary>
    ///     Set joining the server by shard id
    /// </summary>
    /// <param name="shardId">The shard id</param>
    internal static void SetJoining(ushort shardId)
    {
        Joining = Servers.FirstOrDefault(p => p.Id == shardId);
    }
}
