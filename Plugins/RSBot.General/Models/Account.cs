using System.Collections.Generic;

namespace RSBot.General.Models;

/// <summary>
/// Represents a user account with login credentials and character information
/// </summary>
public class Account
{
    /// <summary>
    /// Gets or sets the username
    /// </summary>
    public string Username { get; set; }

    /// <summary>
    /// Gets or sets the password
    /// </summary>
    public string Password { get; set; }

    /// <summary>
    /// Gets or sets the secondary password
    /// </summary>
    public string SecondaryPassword { get; set; }

    /// <summary>
    /// Gets or sets the channel number (defaults to 1)
    /// </summary>
    public byte Channel { get; set; } = 1;

    /// <summary>
    /// Gets or sets the server name
    /// </summary>
    public string Servername { get; set; }

    /// <summary>
    /// Gets or sets the selected character name
    /// </summary>
    public string SelectedCharacter { get; set; }

    /// <summary>
    /// Gets or sets the list of characters associated with this account
    /// </summary>
    public List<string> Characters { get; set; }

    /// <summary>
    /// Returns the username as the string representation of the account
    /// </summary>
    public override string ToString()
    {
        return Username;
    }
}