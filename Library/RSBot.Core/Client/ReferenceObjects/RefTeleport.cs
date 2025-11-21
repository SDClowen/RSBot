using System.Collections.Generic;
using System.Linq;
using RSBot.Core.Objects;

namespace RSBot.Core.Client.ReferenceObjects;

public class RefTeleport : IReference<uint>
{
    public bool Load(ReferenceParser parser)
    {
        //Skip disabled
        if (!parser.TryParse(0, out Service) || Service == 0)
            return false;

        //Skip invalid ID (PK)
        if (!parser.TryParse(1, out ID))
            return false;

        //Skip invalid CodeName
        if (!parser.TryParse(2, out CodeName))
            return false;

        parser.TryParse(3, out AssocRefObjId);
        parser.TryParse(4, out ZoneName128);
        parser.TryParse(5, out GenRegionID);
        parser.TryParse(6, out GenPos_X);
        parser.TryParse(7, out GenPos_Z);
        parser.TryParse(8, out GenPos_Y);
        parser.TryParse(9, out GenAreaRadius);
        parser.TryParse(10, out CanBeResurrectPos);
        parser.TryParse(11, out CanGotoResurrectPos);

        return true;
    }

    /// <summary>
    ///     Gets the links.
    /// </summary>
    /// <returns></returns>
    public List<RefTeleportLink> GetLinks()
    {
        return Game.ReferenceManager.TeleportLinks.Where(tl => tl.OwnerTeleport == ID).ToList();
    }

    /// <summary>
    ///     Gets the position of the teleporter.
    /// </summary>
    /// <returns></returns>
    public Position GetPosition()
    {
        return new Position(GenRegionID, GenPos_X, GenPos_Y, GenPos_Z);
    }

    #region Fields

    public byte Service;
    public uint ID;
    public string CodeName;
    public string AssocRefObjCodeName;
    public uint AssocRefObjId;
    public string ZoneName128;
    public ushort GenRegionID;
    public short GenPos_X;
    public short GenPos_Y;
    public short GenPos_Z;
    public short GenAreaRadius;
    public byte CanBeResurrectPos;
    public byte CanGotoResurrectPos;
    public string ZoneName => Game.ReferenceManager.GetTranslation(ZoneName128);
    public RefObjChar Character => Game.ReferenceManager.GetRefObjChar(AssocRefObjId);

    public uint PrimaryKey => ID;

    #endregion Fields
}
