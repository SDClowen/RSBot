using System;

namespace RSBot.Core.Client.ReferenceObjects;

[Flags]
public enum ObjectBorrowType : byte
{
    //GuildStorage works only when Storage is set.
    //PetInventory only works if GuildStorage is set.?

    //Bit 7: Storage
    //Bit 6: GuildStorage
    //Bit 5: PetInventory
    //Bit 4-0: Exchange, might contain sub

    No = 0,
    Storage = 128,
    GuildStorage = 64,
    PetInventory = 32,
    Exchange = Bit4 & Bit3 & Bit2 & Bit1 & Bit0,
    Bit4 = 16,
    Bit3 = 8,
    Bit2 = 4,
    Bit1 = 2,
    Bit0 = 1,
}
