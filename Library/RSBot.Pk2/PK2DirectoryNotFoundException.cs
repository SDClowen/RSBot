using System;

namespace RSBot.Pk2;

public class PK2DirectoryNotFoundException : Exception
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="PK2DirectoryNotFoundException" /> class.
    /// </summary>
    /// <param name="name">The name.</param>
    public PK2DirectoryNotFoundException(string name)
    {
        Name = name;
    }

    /// <summary>
    ///     Ruft eine Meldung ab, die die aktuelle Ausnahme beschreibt.
    /// </summary>
    public override string Message => "The requested directory does not exist in the current context.";

    /// <summary>
    ///     Gets the name.
    /// </summary>
    /// <value>
    ///     The name.
    /// </value>
    public string Name { get; }
}