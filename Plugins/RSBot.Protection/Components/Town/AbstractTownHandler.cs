using System.Linq;
using RSBot.Core;

namespace RSBot.Protection.Components.Town;

public abstract class AbstractTownHandler
{
    private static readonly ushort[] TownSpawnRegionIds =
    {
        22106,
        22617,
        22618,
        22874,
        23087,
        23088,
        23345,
        23346,
        23602,
        23603,
        23687,
        25000,
        26265,
        26959,
        27243,
        27244,
        27499,
        27500,
    };

    public static bool PlayerInTownScriptRegion()
    {
        var regionId = Game.Player.Position.Region;

        return TownSpawnRegionIds.Contains(regionId);
    }
}
