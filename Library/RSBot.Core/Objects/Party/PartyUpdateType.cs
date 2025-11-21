namespace RSBot.Core.Objects.Party;

internal enum PartyUpdateType
{
    Dismissed = 1,
    Joined = 2,
    Leave = 3,
    Member = 6,
    Leader = 7, // 0x09 ??
    LeaderChange = 9,
}
