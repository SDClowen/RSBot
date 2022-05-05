using RSBot.Core.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RSBot.Core.Components
{
    internal class MbotScriptParser : IScriptParser
    {
        public ScriptCommand[] ParseCommands(string[] commands)
        {
            List<ScriptCommand> result = new List<ScriptCommand>();
            foreach(var command in commands)
            {
                result.Add(ParseCommand(command));
            }
            return result.ToArray();
        }

        private ScriptCommand ParseCommand(string command)
        {
            if (string.IsNullOrWhiteSpace(command))
            {
                Log.Notify($"Empty script command");
                return new ScriptCommand { Type = ScriptCommandType.Unknown };
            }

            var cmdTrimmed = command.Trim().ToLower();
            if(cmdTrimmed.StartsWith("go"))
            {
                var dungeonRegex = new Regex(@"\D(-*\d+),(-*\d+),(-*\d+)[\s\S]*");
                var dungeonMatch = dungeonRegex.Match(cmdTrimmed);
                if (dungeonMatch.Success)
                {
                    if(float.TryParse(dungeonMatch.Groups[1].Value, out float x) &&
                        float.TryParse(dungeonMatch.Groups[2].Value, out float y) &&
                        byte.TryParse(dungeonMatch.Groups[3].Value, out byte xSector))
                    {
                        object[] args = { Position.FromCoordinates(x, y, xSector) };
                        return new ScriptCommand { Type = ScriptCommandType.Move, arguments = args };
                    }
                }
                else
                {
                    var regex = new Regex(@"\D(-*\d+),(-*\d+)[\s\S]*");
                    var match = regex.Match(cmdTrimmed);
                    if (match.Success)
                    {
                        if (float.TryParse(match.Groups[1].Value, out float x) &&
                            float.TryParse(match.Groups[2].Value, out float y))
                        {
                            byte? xSector = null;
                            if (x <= -20000) xSector = 1; // dungeon coords but no x sector, assuming dw cave
                            object[] args = { Position.FromCoordinates(x, y, xSector) };
                            return new ScriptCommand { Type = ScriptCommandType.Move, arguments = args };
                        }
                    }
                }
            }
            if (cmdTrimmed.StartsWith("teleport"))
            {
                var regex = new Regex(@"\D(-*\d+),(-*\d+)[\s\S]*");
                var match = regex.Match(cmdTrimmed);
                if (match.Success)
                {
                    if (uint.TryParse(match.Groups[1].Value, out uint npcId) &&
                        uint.TryParse(match.Groups[2].Value, out uint destination))
                    {
                        object[] args = { npcId, destination };
                        return new ScriptCommand { Type = ScriptCommandType.TeleportById, arguments = args };
                    }
                }
            }
            if (cmdTrimmed.StartsWith("wait"))
            {
                object[] args = { 5000 };
                return new ScriptCommand { Type = ScriptCommandType.Wait, arguments = args };
            }

            Log.Notify($"Unknown / invalid script command [{command}]");
            return new ScriptCommand { Type = ScriptCommandType.Unknown };
        }
    }
}
