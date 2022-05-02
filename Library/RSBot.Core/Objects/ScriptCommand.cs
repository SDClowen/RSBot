using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSBot.Core.Objects
{
    public class ScriptCommand
    {
        public ScriptCommandType Type { get; set; }
        public object[] arguments { get; set; }
    }
}
