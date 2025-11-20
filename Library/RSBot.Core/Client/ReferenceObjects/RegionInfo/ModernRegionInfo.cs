using RSBot.NavMeshApi.Mathematics;

namespace RSBot.Core.Client.ReferenceObjects.RegionInfo;

public class ModernRegionInfo : LegacyRegionInfo, IReference
{
    public string Type;
    public string Name;

    public bool Load(ReferenceParser parser)
    {
        parser.TryParse(0, out Type);
        parser.TryParse(1, out Name);
        parser.TryParse(2, out XSector);
        parser.TryParse(3, out YSector);
        parser.TryParse(4, out RegionType);

        parser.TryParse(5, out float minX);
        parser.TryParse(6, out float minY);
        parser.TryParse(7, out float maxX);
        parser.TryParse(8, out float maxY);

        Bounds = new RectangleF(minX, minY, maxX, maxY);

        return true;
    }
}
