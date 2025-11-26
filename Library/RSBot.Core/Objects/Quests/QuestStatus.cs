namespace RSBot.Core.Objects.Quests;

//1 = Initialized
//2 = Complete, but not supplied
//3 = Completed
//4 = Completed X times
//5 = Unavailable
//6 = Canceled
//7 = Started by User
//8 = Completed by User, but not supplied
public enum QuestStatus : byte
{
    Initialized = 0x01,
    CompletedButNotSupplied = 0x02,
    Completed = 0x03,
    CompletedXTimes = 0x04,
    Unavailable = 0x05,
    Cancelled = 0x06,
    StartedByUser = 0x07,
    CompletedByUserButNotSupplied = 0x08,
}
