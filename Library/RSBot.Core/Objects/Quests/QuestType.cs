using System;

namespace RSBot.Core.Objects.Quests;

[Flags]
public enum QuestType : byte
{
    UnkBit0 = 0x1,
    UnkBit1 = 0x2, //NPC.UniqueID in MARK
    Time = 0x4,
    Status = 0x8,
    Objective = 0x10,
    UnkBit5 = 0x20,
    RefObjects = 0x40,
    UnkBit7 = 0x80, //MARK
}
