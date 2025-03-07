using System;
using System.Collections.Generic;
using System.Linq;
using RSBot.Core;
using RSBot.Core.Components;
using RSBot.Core.Event;
using RSBot.Core.Objects.Party;
using RSBot.Party.Bundle.PartyMatching.Objects;

namespace RSBot.Party.Bundle.PartyMatching;

/// <summary>
/// Manages party matching functionality including listing, creating, and joining parties
/// </summary>
internal class PartyMatchingBundle
{
    private int _lastTick;
    private readonly List<PartyEntry> _entries;

    /// <summary>
    /// Gets or sets the configuration for party matching
    /// </summary>
    public PartyMatchingConfig Config { get; set; }

    /// <summary>
    /// Gets the list of party entries
    /// </summary>
    public IReadOnlyList<PartyEntry> Entries => _entries;

    /// <summary>
    /// Initializes a new instance of the PartyMatchingBundle class
    /// </summary>
    public PartyMatchingBundle()
    {
        _entries = new List<PartyEntry>();
        EventManager.SubscribeEvent("OnTick", OnTick);
    }

    /// <summary>
    /// Refreshes the configuration from settings
    /// </summary>
    public void Refresh()
    {
        Config = new PartyMatchingConfig
        {
            Title = PlayerConfig.Get("RSBot.Party.Matching.Title", "Looking for members!"),
            LevelFrom = PlayerConfig.Get("RSBot.Party.Matching.LevelFrom", (byte)1),
            LevelTo = PlayerConfig.Get("RSBot.Party.Matching.LevelTo", (byte)255),
            Purpose = (PartyPurpose)PlayerConfig.Get("RSBot.Party.Matching.Purpose", (int)PartyPurpose.Hunting),
            AutoReform = PlayerConfig.Get("RSBot.Party.Matching.AutoReform", false),
            AutoAccept = PlayerConfig.Get("RSBot.Party.Matching.AutoAccept", false),
            AutoRefresh = PlayerConfig.Get("RSBot.Party.Matching.AutoRefresh", true),
            RefreshInterval = PlayerConfig.Get("RSBot.Party.Matching.RefreshInterval", 60000),
            AutoJoin = PlayerConfig.Get("RSBot.Party.Matching.AutoJoin", false),
            JoinByTitle = PlayerConfig.Get("RSBot.Party.Matching.JoinByTitle", false),
            JoinTitlePattern = PlayerConfig.Get("RSBot.Party.Matching.JoinTitlePattern", string.Empty)
        };
    }

    /// <summary>
    /// Handles the tick event for party matching functionality
    /// </summary>
    private void OnTick()
    {
        if (!Config.AutoRefresh)
            return;

        var elapsed = Kernel.TickCount - _lastTick;
        if (elapsed < Config.RefreshInterval)
            return;

        RequestList();
        _lastTick = Kernel.TickCount;
    }

    /// <summary>
    /// Creates a new party with the current configuration
    /// </summary>
    public void Create()
    {
        try
        {
            Game.Party.Create(Config.Title, Config.Purpose, Config.LevelFrom, Config.LevelTo);
            Log.Debug($"[Party] Created party: {Config.Title}");
        }
        catch (Exception ex)
        {
            Log.Error($"[Party] Failed to create party: {ex.Message}");
        }
    }

    /// <summary>
    /// Joins a party with the specified ID
    /// </summary>
    public bool Join(uint partyId)
    {
        try
        {
            Game.Party.Join(partyId);
            Log.Debug($"[Party] Joined party with ID: {partyId}");
            return true;
        }
        catch (Exception ex)
        {
            Log.Error($"[Party] Failed to join party: {ex.Message}");
            return false;
        }
    }

    /// <summary>
    /// Requests the party list from the server
    /// </summary>
    public void RequestList()
    {
        try
        {
            Game.Party.RequestList();
            Log.Debug("[Party] Requested party list");
        }
        catch (Exception ex)
        {
            Log.Error($"[Party] Failed to request party list: {ex.Message}");
        }
    }

    /// <summary>
    /// Requests a specific page of the party list
    /// </summary>
    public PartyPage RequestPartyList(byte page)
    {
        var result = new PartyPage { Page = page };

        try
        {
            Game.Party.RequestList(page);
            result.Parties.AddRange(_entries.Skip(page * 10).Take(10));
            result.PageCount = (byte)Math.Ceiling(_entries.Count / 10.0);
        }
        catch (Exception ex)
        {
            Log.Error($"[Party] Failed to request party list page {page}: {ex.Message}");
        }

        return result;
    }

    /// <summary>
    /// Updates the party list with new entries
    /// </summary>
    public void UpdateList(List<PartyEntry> entries)
    {
        _entries.Clear();
        _entries.AddRange(entries);

        if (Config.AutoJoin && !Game.Party.IsInParty)
        {
            var partyToJoin = _entries.FirstOrDefault(p =>
                (!Config.JoinByTitle || p.Title.Contains(Config.JoinTitlePattern, StringComparison.OrdinalIgnoreCase)) &&
                p.Members < p.MaxMembers &&
                Game.Player.Level >= p.LevelFrom &&
                Game.Player.Level <= p.LevelTo);

            if (partyToJoin != null)
                Join(partyToJoin.Id);
        }
    }
} 