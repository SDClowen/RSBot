using System;

namespace RSBot.Core.Network.Protocol;

public class HandshakeSecurityException : Exception
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="HandshakeSecurityException" /> class.
    /// </summary>
    /// <param name="message">Die Meldung, in der der Fehler beschrieben wird.</param>
    public HandshakeSecurityException(string message)
    {
        Message = message;
    }

    /// <summary>
    ///     Gets the exception message
    /// </summary>
    public override string Message { get; }
}
