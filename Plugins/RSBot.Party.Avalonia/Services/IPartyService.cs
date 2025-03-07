using System.Threading.Tasks;

namespace RSBot.Party.Services;

/// <summary>
/// Interface for party management service
/// </summary>
public interface IPartyService
{
    /// <summary>
    /// Requests the party list from the server
    /// </summary>
    void RequestPartyList();

    /// <summary>
    /// Joins a party with the specified ID
    /// </summary>
    /// <param name="partyId">The ID of the party to join</param>
    /// <returns>True if joining was successful, false otherwise</returns>
    Task<bool> JoinParty(uint partyId);
} 