using System;

namespace RSBot.Core.Client.ReferenceObjects;

[Flags]
public enum ObjectDropType : byte
{
    No = 0, //000000 0 0 -> Can't drop
    Death = 1, //000000 0 1 -> Can drop upon death
    Player = 2, //000000 1 0 -> Can drop manually
}
