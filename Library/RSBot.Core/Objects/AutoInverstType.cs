using System;

namespace RSBot.Core.Objects;

[Flags]
public enum AutoInverstType : byte
{
    None = 0,
    Beginner = 1,
    Helpful = 2,
}
