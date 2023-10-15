using System;

namespace RSBot.Pk2.Security;

public class BlowfishSecurityException : Exception
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="BlowfishSecurityException" /> class.
    /// </summary>
    /// <param name="key"></param>
    public BlowfishSecurityException(string key)
    {
        Key = key;
    }

    /// <summary>
    ///     Gets a message that describes the exception.
    /// </summary>
    public override string Message =>
        "An exception was thrown while initializing the blowfish on this archive. The most common reason is that a wrong key has been provided.";

    /// <summary>
    ///     Gets the key that was used as the passphrase in the current PK2 archive
    /// </summary>
    /// <value>
    ///     The key.
    /// </value>
    public string Key { get; }
}