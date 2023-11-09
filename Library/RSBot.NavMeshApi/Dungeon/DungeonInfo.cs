using RSBot.NavMeshApi.Mathematics;

using System.Text.RegularExpressions;

namespace RSBot.NavMeshApi.Dungeon;

public class DungeonInfo
{
    private readonly Dictionary<RID, string> _dungeons = new Dictionary<RID, string>();

    public void Load(Stream stream)
    {
        _dungeons.Clear();

        using (var reader = new StreamReader(stream))
        {
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                if (line.StartsWith("//"))
                    continue;

                var match = Regex.Match(line, "(?<service>0|1)\\t(?<id>\\d*)\t\"(?<path>.*)\"");

                var data = line.Split('\t');
                if (!int.TryParse(match.Groups["service"].Value, out int service))
                    throw new Exception($"Failed to load dungeon info: malformed service on {line}");

                if (!short.TryParse(match.Groups["id"].Value, out short dungeonId))
                    throw new Exception($"Failed to load dungeon info: malformed id on {line}");

                var dungeonPath = match.Groups["path"].Value;
                if (string.IsNullOrEmpty(dungeonPath))
                    throw new Exception($"Failed to load dungeon info: malformed path on {line}");

                if (service == 0)
                    continue;

                _dungeons.Add(new RID(dungeonId) { IsDungeon = true }, dungeonPath);
            }
        }
    }

    public string this[RID region]
    {
        get
        {
            if (_dungeons.TryGetValue(region, out string value))
                return value;

            return null;
        }
    }
}