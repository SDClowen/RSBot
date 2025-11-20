using System.Text.RegularExpressions;
using RSBot.NavMeshApi.Mathematics;

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
                continue;

            var match = Regex.Match(line, @"^(?:(?<service>0|1)\t)?(?<id>\d+)\t""(?<path>.+)""$");

            if (!match.Success)
                throw new Exception($"Failed to load dungeon info: invalid format on {line}");

            if (int.TryParse(match.Groups["service"].Value, out int service) && service == 0)
                continue;

            if (!short.TryParse(match.Groups["id"].Value, out short dungeonId))
                throw new Exception($"Failed to load dungeon info: malformed id on {line}");

            var dungeonPath = match.Groups["path"].Value;
            if (string.IsNullOrEmpty(dungeonPath))
                throw new Exception($"Failed to load dungeon info: malformed path on {line}");

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
