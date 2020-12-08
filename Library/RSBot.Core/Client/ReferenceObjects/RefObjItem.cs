using RSBot.Core.Extensions;
using System.Drawing;
using System.IO;

namespace RSBot.Core.Client.ReferenceObjects
{
    public class RefObjItem : RefObjCommon
    {
        #region Fields

        public int MaxStack;
        public byte ReqGender;
        public int ReqStr;
        public int ReqInt;
        public byte ItemClass;
        public byte Quivered; //Consumes ammo
        public byte SpeedClass;
        public byte TwoHanded;
        public byte Range;

        /// <summary>
        /// Gets the degree of the item
        /// </summary>
        /// <value>
        /// The degree.
        /// </value>
        public int Degree => (ItemClass - 1) / 3 + 1;

        /// <summary>
        /// Gets the degree offset.
        /// </summary>
        /// <value>
        /// The degree offset.
        /// </value>
        public int DegreeOffset => ItemClass - 3 * ((ItemClass - 1) / 3) - 1; //sro_client.sub_8BA6E0

        #endregion Fields

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
    }
}

//ID                  int
//MaxStack            50 [57]
//ReqGender           2  [58]
//ReqStr              0  [59]
//ReqInt              0
//ItemClass           1
//SetID               0
//Dur_L               0.0
//Dur_U               0.0
//PD_L                0.0
//PD_U                0.0
//PDInc               0.0
//ER_L                0.0
//ER_U                0.0
//ERInc               0.0 [70]
//PAR_L               0.0
//PAR_U               0.0
//PARInc              0.0
//BR_L                0.0
//BR_U                0.0
//MD_L                0.0
//MD_U                0.0
//MDInc               0.0
//MAR_L               0.0
//MAR_U               0.0 [80]
//MARInc              0.0
//PDStr_L             0.0
//PDStr_U             0.0
//MDInt_L             0.0
//MDInt_U             0.0 [85]
//Quivered            0
//Ammo1_TID4          0
//Ammo2_TID4          0
//Ammo3_TID4          0
//Ammo4_TID4          0 [90]
//Ammo5_TID4          0
//SpeedClass          0
//TwoHanded           0
//Range               0
//PAttackMin_L        0.0
//PAttackMin_U        0.0
//PAttackMax_L        0.0
//PAttackMax_U        0.0
//PAttackInc          0.0
//MAttackMin_L        0.0
//MAttackMin_U        0.0
//MAttackMax_L        0.0
//MAttackMax_U        0.0
//MAttackInc          0.0
//PAStrMin_L          0.0
//PAStrMin_U          0.0
//PAStrMax_L          0.0
//PAStrMax_U          0.0
//MAInt_Min_L         0.0
//MAInt_Min_U         0.0
//MAInt_Max_L         0.0
//MAInt_Max_U         0.0
//HR_L                0.0
//HR_U                0.0
//HRInc               0.0
//CHR_L               0.0
//CHR_U               0.0
//Param1              120
//Desc1_128           HP회복양
//Param2              0
//Desc2_128           HP회복양(%)
//Param3              0
//Desc3_128           MP회복양
//Param4              0
//Desc4_128           MP회복양(%)
//Param5              -1
//Desc5_128           xxx
//Param6              -1
//Desc6_128           xxx
//Param7              -1
//Desc7_128           xxx
//Param8              -1
//Desc8_128           xxx
//Param9              -1
//Desc9_128           xxx
//Param10             -1
//Desc10_128          xxx
//Param11             -1
//Desc11_128          xxx
//Param12             -1
//Desc12_128          xxx
//Param13             -1
//Desc13_128          xxx
//Param14             -1
//Desc14_128          xxx
//Param15             -1
//Desc15_128          xxx
//Param16             -1
//Desc16_128          xxx
//Param17             -1
//Desc17_128          xxx
//Param18             -1
//Desc18_128          xxx
//Param19             -1
//Desc19_128          xxx
//Param20             -1
//Desc20_128          xxx
//MaxMagicOptCount    0
//ChildItemCount      0