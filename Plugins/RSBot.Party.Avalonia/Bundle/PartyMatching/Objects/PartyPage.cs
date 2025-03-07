using System.Collections.Generic;

namespace RSBot.Party.Bundle.PartyMatching.Objects;

/// <summary>
/// Represents a page of party entries in the party matching system
/// </summary>
public class PartyPage
{
    /// <summary>
    /// Gets or sets the current page number
    /// </summary>
    public byte Page { get; set; }

    /// <summary>
    /// Gets or sets the total number of pages
    /// </summary>
    public byte PageCount { get; set; }

    /// <summary>
    /// Gets or sets the list of party entries on this page
    /// </summary>
    public List<PartyEntry> Parties { get; set; }

    /// <summary>
    /// Initializes a new instance of the PartyPage class
    /// </summary>
    public PartyPage()
    {
        Parties = new List<PartyEntry>();
    }
} 