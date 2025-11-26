using RSBot.Core.Objects;

namespace RSBot.Core.Client.ReferenceObjects;

public class RefOptionalTeleport : IReference<int>
{
    /// <summary>
    ///     Offset: 1
    ///     The ID
    /// </summary>
    public int ID;

    /// <summary>
    ///     Offset: 12
    ///     The LevelMax
    /// </summary>
    public ushort LevelMax;

    /// <summary>
    ///     Offset: 11
    ///     The LevelMin
    /// </summary>
    public ushort LevelMin;

    /// <summary>
    ///     Offset: 10
    ///     The MapPoint
    /// </summary>
    public byte MapPoint;

    /// <summary>
    ///     Offset: 13
    ///     The Param1
    /// </summary>
    public int Param1;

    /// <summary>
    ///     Offset: 14
    ///     The Param1_Desc_128
    /// </summary>
    public string Param1_Desc_128;

    /// <summary>
    ///     Offset: 15
    ///     The Param2
    /// </summary>
    public int Param2;

    /// <summary>
    ///     Offset: 16
    ///     The Param2_Desc_128
    /// </summary>
    public string Param2_Desc_128;

    /// <summary>
    ///     Offset: 17
    ///     The Param3
    /// </summary>
    public int Param3;

    /// <summary>
    ///     Offset: 18
    ///     The Param3_Desc_128
    /// </summary>
    public string Param3_Desc_128;

    /// <summary>
    ///     Offset: 5
    ///     The Pos_X
    /// </summary>
    public float Pos_X;

    /// <summary>
    ///     Offset: 6
    ///     The Pos_Y
    /// </summary>
    public float Pos_Y;

    /// <summary>
    ///     Offset: 7
    ///     The Pos_Z
    /// </summary>
    public float Pos_Z;

    /// <summary>
    ///     Offset: 4
    ///     The RegionID
    /// </summary>
    public Region Region;

    /// <summary>
    ///     Offset: 9
    ///     The RegionIDGroup
    /// </summary>
    public int RegionIDGroup;

    /// <summary>
    ///     Offset: 0
    ///     The Service
    /// </summary>
    public byte Service;

    /// <summary>
    ///     Offset: 8
    ///     The WorldID
    /// </summary>
    public ushort WorldID;

    /// <summary>
    /// Offset: 2
    /// The ObjName128
    /// </summary>
    //public string ObjName128;

    /// <summary>
    ///     Offset: 3
    ///     The ZoneName128
    /// </summary>
    public string ZoneName128;

    public int PrimaryKey => ID;

    /// <summary>
    ///     Fills the fields from the tabs array.
    /// </summary>
    public bool Load(ReferenceParser parser)
    {
        if (!parser.TryParse(0, out Service) || Service == 0)
            return false;

        parser.TryParse(1, out ID);
        //parser.TryParse(2, out ObjName128);
        //parser.TryParse(3, out ZoneName128);
        parser.TryParse(4, out Region);

        /*parser.TryParse(5, out Pos_X);
        parser.TryParse(6, out Pos_Z);
        parser.TryParse(7, out Pos_Y);
        parser.TryParse(8, out WorldID);
        parser.TryParse(9, out RegionIDGroup);
        parser.TryParse(10, out MapPoint);
        parser.TryParse(11, out LevelMin);
        parser.TryParse(12, out LevelMax);
        parser.TryParse(13, out Param1);
        parser.TryParse(14, out Param1_Desc_128);
        parser.TryParse(15, out Param2);
        parser.TryParse(16, out Param2_Desc_128);
        parser.TryParse(17, out Param3);
        parser.TryParse(18, out Param3_Desc_128);

        Pos_X = (XSec - 135) * 192 + Pos_X / 10;
        Pos_Y = (YSec - 92) * 192 + Pos_Y / 10;*/

        return true;
    }
}
