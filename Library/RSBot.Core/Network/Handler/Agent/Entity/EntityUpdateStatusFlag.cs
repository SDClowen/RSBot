using System;

namespace RSBot.Core.Network.Handler.Agent.Entity;

[Flags]
internal enum EntityUpdateStatusFlag : byte
{
    None = 0,
    HP = 1,
    MP = 2,
    HPMP = HP | MP,
    BadEffect = 4,
    Fellow = 13,
}
