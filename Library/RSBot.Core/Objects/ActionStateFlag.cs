using System;

namespace RSBot.Core.Objects;

[Flags]
public enum ActionStateFlag : byte
{
    None = 0,
    Attack = 1,
    Teleport = 8,
}
