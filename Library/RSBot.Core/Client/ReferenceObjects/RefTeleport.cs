using RSBot.Core.Objects;
using System.Collections.Generic;
using System.Linq;

namespace RSBot.Core.Client.ReferenceObjects
{
    public class RefTeleport : IReference<uint>
    {
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

        /// <summary>
        /// Gets the links.
        /// </summary>
        /// <returns></returns>
        public List<RefTeleportLink> GetLinks()
        {
            return Game.ReferenceManager.TeleportLinks.Where(tl => tl.OwnerTeleport == ID).ToList();
        }

        /// <summary>
        /// Gets the position of the teleporter.
        /// </summary>
        /// <returns></returns>
        public Position GetPosition()
        {
            return new Position
            {
                XSector = Position.GetXSector(GenRegionID),
                YSector = Position.GetYSector(GenRegionID),
                XOffset = GenPos_X,
                YOffset = GenPos_Z,
                ZOffset = GenPos_Y,
            };
        }

        public bool Load(ReferenceParser parser)
        {
            //Skip disabled
            if (!parser.TryParseByte(0, out Service) || Service == 0)
                return false;

            //Skip invalid ID (PK)
            if (!parser.TryParseUInt(1, out ID))
                return false;

            //Skip invalid CodeName
            if (!parser.TryParseString(2, out CodeName))
                return false;

            parser.TryParseUInt(3, out AssocRefObjId);
            parser.TryParseString(4, out ZoneName128);
            parser.TryParseUShort(5, out GenRegionID);
            parser.TryParseShort(6, out GenPos_X);
            parser.TryParseShort(7, out GenPos_Y);
            parser.TryParseShort(8, out GenPos_Z);
            parser.TryParseShort(9, out GenAreaRadius);
            parser.TryParseByte(10, out CanBeResurrectPos);
            parser.TryParseByte(11, out CanGotoResurrectPos);

            return true;
        }
    }
}

//Service int
//ID  int
//CodeName128 varchar(129)
//AssocRefObjCodeName128 varchar(129)
//AssocRefObjID int
//ZoneName128 varchar(129)
//GenRegionID smallint
//GenPos_X smallint
//GenPos_Y smallint
//GenPos_Z smallint
//GenAreaRadius smallint
//CanBeResurrectPos tinyint
//CanGotoResurrectPos tinyint
//GenWorldID smallint
//BindInteractionMask tinyint
//FixedService tinyint