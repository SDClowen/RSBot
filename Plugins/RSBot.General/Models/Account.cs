using System.Collections.Generic;

namespace RSBot.General.Models;

internal class Account
{
    /// <summary>
    ///     Gets or sets the username.
    /// </summary>
    /// <value>
    ///     The username.
    /// </value>
    public string Username { get; set; }

    /// <summary>
    ///     Gets or sets the password.
    /// </summary>
    /// <value>
    ///     The password.
    /// </value>
    public string Password { get; set; }

    /// <summary>
    ///     Gets or sets the password.
    /// </summary>
    /// <value>
    ///     The password.
    /// </value>
    public string SecondaryPassword { get; set; }

    /// <summary>
    ///     Gets or sets the channel.
    /// </summary>
    /// <value>
    ///     The channel.
    /// </value>
    public byte Channel { get; set; } = 1;

    /// <summary>
    ///     Gets or sets the servername.
    /// </summary>
    /// <value>
    ///     The servername.
    /// </value>
    public string Servername { get; set; }

    /// <summary>
    ///     Gets or sets the selected character.
    /// </summary>
    /// <value>
    ///     The selected character.
    /// </value>
    public string SelectedCharacter { get; set; }

    /// <summary>
    ///     Gets or sets the characters.
    /// </summary>
    /// <value>
    ///     The characters.
    /// </value>
    public List<string> Characters { get; set; }

    /// <summary>
    ///     Return the username instead of the type name
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        return Username;
    }
}
