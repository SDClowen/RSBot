using System;

namespace RSBot.Core.Objects.Item;

[Flags]
public enum ItemUpdateFlag : byte
{
    RefObjID = 1,
    OptLevel = 2,
    Unknown = 3, // ???
    Variance = 4,
    Quanity = 8,
    Durability = 16,
    MagParams = 32,
    State = 64,
}
