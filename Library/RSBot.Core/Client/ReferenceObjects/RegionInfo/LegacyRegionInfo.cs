using RSBot.Core.Objects;
using RSBot.NavMeshApi.Mathematics;

namespace RSBot.Core.Client.ReferenceObjects.RegionInfo;

public class LegacyRegionInfo : IReference
{
    public byte XSector;
    public byte YSector;
    public string RegionType = "ALL";
    public RectangleF Bounds;
    public Region Region => new(XSector, YSector);

    public bool Load(ReferenceParser parser)
    {
        parser.TryParse(0, out XSector);
        parser.TryParse(1, out YSector);
        parser.TryParse(2, out RegionType);

        parser.TryParse(3, out float minX);
        parser.TryParse(4, out float minY);
        parser.TryParse(5, out float maxX);
        parser.TryParse(6, out float maxY);

        Bounds = new RectangleF(minX, minY, maxX, maxY);

        return true;
    }
}
