using System.Collections.Generic;

namespace RSBot.Core.Client.ReferenceObjects;

public class Division
{
    #region Fields

    /// <summary>
    ///     Gets or sets the name.
    /// </summary>
    /// <value>
    ///     The name.
    /// </value>
    public string Name;

    /// <summary>
    ///     Gets or sets the login servers.
    /// </summary>
    /// <value>
    ///     The login servers.
    /// </value>
    public List<string> GatewayServers;

    #endregion Fields
}
