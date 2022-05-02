using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSBot.Core.Objects
{
    public enum ScriptCommandType
    {
        Move,
        Buy,
        Repair,
        Store,
        TeleportByCode,
        TeleportById,
        Dismount,
        Wait,
        Unknown
    }
}
