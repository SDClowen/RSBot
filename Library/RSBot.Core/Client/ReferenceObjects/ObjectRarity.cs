using System;

namespace RSBot.Core.Client.ReferenceObjects;

[Flags]
public enum ObjectRarity : byte
{
    ClassA = 0, //ITEM=White         MOB=General
    ClassB = 1, //ITEM=Blue          MOB=Champion
    ClassC = 2, //ITEM=SOX           MOB=unused
    ClassD = 3, //ITEM=SET           MOB=Unique
    ClassE = 4, //                   MOB=Giant
    ClassF = 5, //                   MOB=Titan
    ClassG = 6, //ITEM=ROC,SET_11_B  MOB=Elite
    ClassH = 7, //ITEM=LEGEND        MOB=Elite (Strong)
    ClassI = 8, //                    MOB=Unique (TQ, GOD, SD)

    //Party = 10
    //For ITEM_: see above, this rarity is also used in SERVER_AGENT_OBJECT_SPAWN when OBJECT equals ITEM...
    //For COS_T / TRADE_COS: it might be used for TIEF/HUNTER AI target priority since behemoth and lvl60+ cos are higher than normal ones
    //For MOB_: it could affect on spawn chance unless its a unique?
}
