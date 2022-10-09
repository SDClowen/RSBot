using RSBot.Core;
using System.Linq;

namespace RSBot.Protection.Components.Town;

public abstract class AbstractTownHandler
{
    private static ushort[] TownSpawnRegionIds = {
        22106,
        22617,
        22618,
        22874,
        23088,
        23603,
        23687,
        25000,
        26265,
        26959,
        27244
    };

    public static bool PlayerInTownScriptRegion()
    {
        var regionId = Game.Player.Position.RegionId;

        return TownSpawnRegionIds.Contains(regionId);
    }
}