using System.Collections.Generic;
using System.IO;
using RSBot.Core.Objects;

namespace RSBot.Core.Client.ReferenceObjects.RegionInfo;

public class LegacyRegionInfoGroup : IReference
{
    public string Type;
    public string Name;
    public string DungeonName = string.Empty;

    public Dictionary<Region, LegacyRegionInfo> Regions = new(2048);

    public bool Load(ReferenceParser parser)
    {
        parser.TryParse(0, out Type);
        parser.TryParse(1, out Name);
        parser.TryParse(2, out DungeonName);

        return true;
    }

    public string ParseEntries(StreamReader reader)
    {
        var line = reader.ReadLine();
        while (line != null && !line.StartsWith('#'))
        {
            if (!string.IsNullOrWhiteSpace(line))
            {
                var entry = new LegacyRegionInfo();
                entry.Load(new ReferenceParser(line));

                Regions.TryAdd(entry.Region, entry);
            }

            line = reader.ReadLine();
        }

        //Return next group
        return line;
    }

    public LegacyRegionInfo GetRegionInfo(Region region)
    {
        if (!Regions.TryGetValue(region, out var info))
            return null;

        return info;
    }
}
