using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSBot.Core.Objects.Cos;

public enum CosCommand : byte
{
    Move = 1,
    Attack = 2,
    Pickup = 8,
    Follow = 9,
    Charm = 11,
}