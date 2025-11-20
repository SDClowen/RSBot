using System;

namespace RSBot.Core.Client.ReferenceObjects;

[Flags]
public enum ObjectUseType : byte
{
    //Bit 0: Yes
    //Bit 1-6
    //Bit 7: AskFlag

    No = 0,
    Yes = 1,
    Unknown = 126, //in CanUse:255 (ITEM_MALL_DUNGEON_FREE_TICKET_FORGOTTEN_WORLD)
    Ask = 128,
}
