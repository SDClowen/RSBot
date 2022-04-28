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
        public short Range;
        public int Param1;
        public int Param2;
        public int Param3;
        public int Param4;
        public string Desc1;
        public string Desc2;
        public string Desc3;
        public string Desc4;

        /// <summary>
        /// Is item wearable:<c>true</c> otherwise:<c>false</c>
        /// </summary>
        public bool IsEquip => TypeID2 == 1;

        /// <summary>
        /// Is item wearable for jobbing:<c>true</c> otherwise:<c>false</c>
        /// </summary>
        public bool IsJobEquip => TypeID2 == 1 && TypeID3 == 7;

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
        /// Is item type quest:<c>true</c> otherwise:<c>false</c>
        /// </summary>
        public bool IsSkillItem => IsStackable && TypeID3 == 13 && TypeID4 == 1;

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
            parser.TryParseShort(94, out Range);
            parser.TryParseInt(118, out Param1);
            parser.TryParseString(119, out Desc1);
            parser.TryParseInt(120, out Param2);
            parser.TryParseString(121, out Desc2);
            parser.TryParseInt(122, out Param3);
            parser.TryParseString(123, out Desc3);
            parser.TryParseInt(124, out Param4);
            parser.TryParseString(125, out Desc4);

            return true;
        }

        /// <summary>
        /// Get item sox name
        /// </summary>
        /// <returns></returns>
        public string GetRarityName()
        {
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

            return param;
        }

        public override string GetRealName(bool displayRarity = false)
        {
            var baseName = base.GetRealName(displayRarity);

            if (!displayRarity || Rarity < ObjectRarity.ClassC)
                return baseName;

            

            return $"{baseName} ({GetRarityName()})";
        }

        /// <summary>
        /// Gets the icon.
        /// </summary>
        /// <returns></returns>
        public Image GetIcon()
        {
            Image bitmap = null;

            try
            {
                var file = Game.MediaPk2.GetFile(Path.Combine("icon", this.AssocFileIcon), true);
                if (file.IsValid)
                    bitmap = file.ToImage();
                else
                    bitmap = Game.MediaPk2.GetFile("icon\\icon_default.ddj").ToImage();
            }
            catch { }
            finally
            {
                if (bitmap == null)
                    bitmap = new Bitmap(24, 24);
            }

            return bitmap;
        }

        public override string ToString()
        {
            return $"{CodeName} TID1:{TypeID1} TID2:{TypeID2} TID3:{TypeID3} TID4:{TypeID4}";
        }
    }
}