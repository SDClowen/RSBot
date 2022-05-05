using RSBot.Core.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSBot.Core.Components
{
    internal interface IScriptParser
    {
        ScriptCommand[] ParseCommands(string[] commands);
    }
}
