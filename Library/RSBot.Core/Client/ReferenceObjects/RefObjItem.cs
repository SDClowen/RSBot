using RSBot.Core.Extensions;
using System.Drawing;
using System.IO;

namespace RSBot.Core.Client.ReferenceObjects
{
    public class RefObjItem : RefObjCommon
    {
        public int MaxStack;
        public byte ReqGender;
        public int ReqStr;
        public int ReqInt;
        public byte ItemClass;
        public byte Quivered; //Consumes ammo
        public byte SpeedClass;
        public byte TwoHanded;
        public byte Range;
        public int Param1;
        public string Desc1;

        /// <summary>
        /// Is item wearable:<c>true</c> otherwise:<c>false</c>
        /// </summary>
        public bool IsWear => TypeID2 == 1;

        /// <summary>
        /// Is item type stackable:<c>true</c> otherwise:<c>false</c>
        /// </summary>
        public bool IsStackable => TypeID2 == 3;

        /// <summary>
        /// Is item type gold:<c>true</c> otherwise:<c>false</c>
        /// </summary>
        public bool IsGold => IsStackable && TypeID3 == 5 && TypeID4 == 0;

        /// <summary>
        /// Is item type trading(job trading items):<c>true</c> otherwise:<c>false</c>
        /// </summary>
        public bool IsTrading => IsStackable && TypeID3 == 8;

        /// <summary>
        /// Is item type quest:<c>true</c> otherwise:<c>false</c>
        /// </summary>
        public bool IsQuest => IsStackable && TypeID3 == 9;

        /// <summary>
        /// Gets the degree of the item
        /// </summary>
        public int Degree => (ItemClass - 1) / 3 + 1;

        /// <summary>
        /// Gets the degree offset.
        /// </summary>
        public int DegreeOffset => ItemClass - 3 * ((ItemClass - 1) / 3) - 1; //sro_client.sub_8BA6E0

        public override bool Load(ReferenceParser parser)
        {
            if (!base.Load(parser))
                return false;

            parser.TryParseInt(57, out MaxStack);
            parser.TryParseByte(58, out ReqGender);
            parser.TryParseInt(59, out ReqStr);
            parser.TryParseInt(60, out ReqInt);
            parser.TryParseByte(61, out ItemClass);
            parser.TryParseByte(86, out Quivered);
            parser.TryParseByte(92, out SpeedClass);
            parser.TryParseByte(93, out TwoHanded);
            parser.TryParseByte(94, out Range);

            parser.TryParseInt(118, out Param1);
            parser.TryParseString(119, out Desc1);
            return true;
        }

        public override string GetRealName(bool displayRarity = false)
        {
            var baseName = base.GetRealName(displayRarity);

            if (!displayRarity || Rarity < ObjectRarity.ClassC)
                return baseName;

            string param = null;
            if (ItemClass < 31 || ItemClass > 34)
            {
                //Seal of Star, Seal of Moon, Seal of Sun
                switch (this.DegreeOffset)
                {
                    case 0:
                        param = Game.ReferenceManager.GetTranslation("PARAM_RARE_FIRST");
                        break;

                    case 1:
                        param = Game.ReferenceManager.GetTranslation("PARAM_RARE_SECOND");
                        break;

                    case 2:
                        param = Game.ReferenceManager.GetTranslation("PARAM_RARE_THIRD");
                        break;
                }
            }
            else
            {
                //Seal of Nova
                param = Game.ReferenceManager.GetTranslation("PARAM_RARE_FIRST2");
            }

            return $"{baseName} ({param})";
        }

        /// <summary>
        /// Gets the icon.
        /// </summary>
        /// <returns></returns>
        public Image GetIcon()
        {
            try
            {
                return Game.MediaPk2.FileExists(Path.GetFileName(this.AssocFileIcon))
                    ? Game.MediaPk2.GetFile(Path.GetFileName(this.AssocFileIcon)).ToImage()
                    : new Bitmap(16, 16);
            }
            catch //DDS convert failed
            {
                return new Bitmap(16, 16);
            }
        }

        public override string ToString()
        {
            return $"{CodeName} TID1:{TypeID1} TID2:{TypeID2} TID3:{TypeID3} TID4:{TypeID4}";
        }
    }
}