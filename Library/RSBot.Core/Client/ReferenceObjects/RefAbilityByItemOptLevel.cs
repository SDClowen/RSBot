using System.Collections.Generic;
using System.Linq;

namespace RSBot.Core.Client.ReferenceObjects;

public class RefAbilityByItemOptLevel : IReference<int>
{
    public int Id;
    public uint ItemId;
    public byte OptLevel;

    public int PrimaryKey => Id;

    public bool Load(ReferenceParser parser)
    {
        if (!parser.TryParse(0, out int service) || service == 0)
            return false;

        if (!parser.TryParse(1, out Id))
            return false;

        parser.TryParse(2, out ItemId);
        parser.TryParse(3, out OptLevel);

        return true;
    }

    /// <summary>
    ///     Gets the links.
    /// </summary>
    /// <returns></returns>
    public IEnumerable<uint> GetLinks()
    {
        return Game.ReferenceManager.SkillByItemOptLevels.Where(tl => tl.Link == Id).Select(p => p.SkillId);
    }
}
