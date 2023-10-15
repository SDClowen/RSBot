using System;

namespace RSBot.Pk2;

public class PK2NotLoadedException : Exception
{
    /// <summary>
    /// Gets a message that describes the exception
    /// </summary>
    public override string Message => "The PK2 archive has not been loaded, therefore it is impossible to interact with the archive.";
}