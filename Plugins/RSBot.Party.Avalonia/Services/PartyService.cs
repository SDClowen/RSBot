using System.Threading.Tasks;
using RSBot.Core;
using RSBot.Core.Event;
using RSBot.Core.Objects;
using RSBot.Core.Objects.Party;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RSBot.Party.Services;

/// <summary>
/// Provides party management functionality including member tracking, invitations, and party settings
/// </summary>
public interface IPartyService
{
    /// <summary>
    /// Gets the current party members
    /// </summary>
    IEnumerable<PartyMember> GetPartyMembers();

    /// <summary>
    /// Sends a party invitation to the specified player
    /// </summary>
    Task InvitePlayerAsync(string playerName);

    /// <summary>
    /// Accepts a party invitation
    /// </summary>
    Task AcceptInvitationAsync();

    /// <summary>
    /// Declines a party invitation
    /// </summary>
    Task DeclineInvitationAsync();

    /// <summary>
    /// Leaves the current party
    /// </summary>
    Task LeavePartyAsync();

    /// <summary>
    /// Kicks the specified player from the party
    /// </summary>
    Task KickPlayerAsync(string playerName);

    /// <summary>
    /// Creates a new party
    /// </summary>
    Task CreatePartyAsync(string title, int minLevel, int maxLevel, PartyPurpose purpose, bool autoReform, bool autoAccept);

    /// <summary>
    /// Joins a party with the specified ID
    /// </summary>
    Task JoinPartyAsync(int partyId);

    /// <summary>
    /// Requests the party list from the server
    /// </summary>
    Task RequestPartyListAsync();
}

/// <summary>
/// Implementation of the party service that manages party-related operations
/// </summary>
public class PartyService : IPartyService
{
    /// <summary>
    /// Requests the party list from the server
    /// </summary>
    public void RequestPartyList()
    {
        Bundle.Container.PartyMatching.RequestList();
    }

    /// <summary>
    /// Joins a party with the specified ID
    /// </summary>
    /// <param name="partyId">The ID of the party to join</param>
    /// <returns>True if joining was successful, false otherwise</returns>
    public async Task<bool> JoinParty(uint partyId)
    {
        return await Task.Run(() => Bundle.Container.PartyMatching.Join(partyId));
    }

    public IEnumerable<PartyMember> GetPartyMembers()
    {
        return Game.Party?.Members ?? Enumerable.Empty<PartyMember>();
    }

    public async Task InvitePlayerAsync(string playerName)
    {
        if (string.IsNullOrEmpty(playerName))
            return;

        await Task.Run(() => 
        {
            var player = Game.Players.FirstOrDefault(p => p.Name.Equals(playerName, StringComparison.OrdinalIgnoreCase));
            if (player != null)
                Game.Party?.Invite(player);
        });
    }

    public async Task AcceptInvitationAsync()
    {
        await Task.Run(() => Game.Party?.Accept());
    }

    public async Task DeclineInvitationAsync()
    {
        await Task.Run(() => Game.Party?.Decline());
    }

    public async Task LeavePartyAsync()
    {
        await Task.Run(() => Game.Party?.Leave());
    }

    public async Task KickPlayerAsync(string playerName)
    {
        if (string.IsNullOrEmpty(playerName))
            return;

        await Task.Run(() =>
        {
            var member = Game.Party?.Members.FirstOrDefault(m => m.Name.Equals(playerName, StringComparison.OrdinalIgnoreCase));
            if (member != null)
                Game.Party?.Kick(member);
        });
    }

    public async Task CreatePartyAsync(string title, int minLevel, int maxLevel, PartyPurpose purpose, bool autoReform, bool autoAccept)
    {
        await Task.Run(() =>
        {
            try
            {
                Bundle.Container.PartyMatching.Config.Title = title;
                Bundle.Container.PartyMatching.Config.LevelFrom = (byte)minLevel;
                Bundle.Container.PartyMatching.Config.LevelTo = (byte)maxLevel;
                Bundle.Container.PartyMatching.Config.Purpose = purpose;
                Bundle.Container.PartyMatching.Config.AutoReform = autoReform;
                Bundle.Container.PartyMatching.Config.AutoAccept = autoAccept;

                Bundle.Container.PartyMatching.Create();
                Log.Debug("[Party] Party created successfully!");
            }
            catch (Exception ex)
            {
                Log.Error($"[Party] Failed to create party: {ex.Message}");
                throw;
            }
        });
    }

    public async Task JoinPartyAsync(int partyId)
    {
        if (Game.Party?.InParty == true)
        {
            Log.Notify("[Party] You are already in a party!");
            return;
        }

        await Task.Run(() =>
        {
            try
            {
                Bundle.Container.PartyMatching.Join(partyId);
                Log.Debug($"[Party] Joined party with ID: {partyId}");
            }
            catch (Exception ex)
            {
                Log.Error($"[Party] Failed to join party: {ex.Message}");
                throw;
            }
        });
    }

    public async Task RequestPartyListAsync()
    {
        await Task.Run(() =>
        {
            try
            {
                Bundle.Container.PartyMatching.RequestList();
                Log.Debug("[Party] Party list requested");
            }
            catch (Exception ex)
            {
                Log.Error($"[Party] Failed to request party list: {ex.Message}");
                throw;
            }
        });
    }
} 