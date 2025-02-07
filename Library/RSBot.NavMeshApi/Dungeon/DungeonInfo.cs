using RSBot.NavMeshApi.Mathematics;
using System.Text.RegularExpressions;

namespace RSBot.NavMeshApi.Dungeon;

public class DungeonInfo
{
    private readonly Dictionary<RID, string> _dungeons = new Dictionary<RID, string>();

    public void Load(Stream stream)
    {
        _dungeons.Clear();

        using var reader = new StreamReader(stream);

        while (!reader.EndOfStream)
        {
            var line = reader.ReadLine();

            if (string.IsNullOrEmpty(line) || line.StartsWith("//"))
            {
                continue;
            }

            // We are reading values from the end, because the structure of Data.pk2\Dungeon\dungeoninfo.txt is different for VSRO and BlackRogue for example
            // VSRO: service    id  path
            // BlackRogue:   id  path
            var stack = new Stack<string>(line.Split('\t'));

            var dungeonPath = Regex.Match(stack.Pop(), "\"(?<path>.*)\"").Groups["path"].Value;

            if (string.IsNullOrEmpty(dungeonPath))
            {
                throw new Exception($"Failed to load dungeon info: malformed path on {line}");
            }

            if (!short.TryParse(stack.Pop(), out short dungeonId))
            {
                throw new Exception($"Failed to load dungeon info: malformed id on {line}");
            }

            if (stack.Count > 0 && int.TryParse(stack.Pop(), out int service) && service == 0)
            {
                continue;
            }

            _dungeons.Add(new RID(dungeonId) { IsDungeon = true }, dungeonPath);
        }
    }

    public string? this[RID region]
    {
        get
        {
            if (_dungeons.TryGetValue(region, out string? value))
                return value;

            return null;
        }
    }
}