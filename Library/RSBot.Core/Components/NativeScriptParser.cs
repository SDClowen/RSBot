using RSBot.Core.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSBot.Core.Components
{
    public class NativeScriptParser : IScriptParser
    {
        public ScriptCommand[] ParseCommands(string[] commands)
        {
            List<ScriptCommand> result = new List<ScriptCommand>();
            foreach (var command in commands)
            {
                result.Add(ParseCommand(command));
            }
            return result.ToArray();
        }

        private ScriptCommand ParseCommand(string command)
        {
            if (string.IsNullOrWhiteSpace(command))
            {
                return new ScriptCommand { Type = ScriptCommandType.Unknown };
            }

            var cmdTrimmed = command.Trim();

            var arguments = cmdTrimmed.Split(' ');

            switch (arguments[0].ToLower())
            {
                case "move":
                    try
                    {
                        var pos = new Position
                        {
                            XSector = byte.Parse(arguments[4]),
                            YSector = byte.Parse(arguments[5]),
                            XOffset = float.Parse(arguments[1]),
                            YOffset = float.Parse(arguments[2]),
                            ZOffset = float.Parse(arguments[3])
                        };
                        object[] args = { pos };
                        return new ScriptCommand { Type = ScriptCommandType.Move, arguments = args };
                    }
                    catch
                    {
                        Log.Notify($"Invalid script command [{command}]");
                        return new ScriptCommand { Type = ScriptCommandType.Unknown };
                    }
                case "teleport":
                    try
                    {
                        object[] args = { arguments[1], arguments[2] };
                        return new ScriptCommand { Type = ScriptCommandType.TeleportByCode, arguments = args };
                    }
                    catch
                    {
                        Log.Notify($"Invalid script command [{command}]");
                        return new ScriptCommand { Type = ScriptCommandType.Unknown };
                    }
                case "wait":
                    try
                    {
                        object[] args = { int.Parse(arguments[1]) };
                        return new ScriptCommand { Type = ScriptCommandType.Wait, arguments = args };
                    }
                    catch
                    {
                        Log.Notify($"Invalid script command [{command}]");
                        return new ScriptCommand { Type = ScriptCommandType.Unknown };
                    }
                case "buy":
                    try
                    {
                        object[] args = { arguments[1] };
                        return new ScriptCommand { Type = ScriptCommandType.Buy, arguments = args };
                    }
                    catch
                    {
                        Log.Notify($"Invalid script command [{command}]");
                        return new ScriptCommand { Type = ScriptCommandType.Unknown };
                    }
                case "repair":
                    try
                    {
                        object[] args = { arguments[1] };
                        return new ScriptCommand { Type = ScriptCommandType.Repair, arguments = args };
                    }
                    catch
                    {
                        Log.Notify($"Invalid script command [{command}]");
                        return new ScriptCommand { Type = ScriptCommandType.Unknown };
                    }
                case "store":
                    try
                    {
                        object[] args = { arguments[1] };
                        return new ScriptCommand { Type = ScriptCommandType.Store, arguments = args };
                    }
                    catch
                    {
                        Log.Notify($"Invalid script command [{command}]");
                        return new ScriptCommand { Type = ScriptCommandType.Unknown };
                    }
                case "dismount":
                    return new ScriptCommand { Type = ScriptCommandType.Dismount };
                default:
                    Log.Notify($"Unknown script command [{arguments[0]}]");
                    return new ScriptCommand { Type = ScriptCommandType.Unknown };
            }

            
        }
    }
}
