using System.Diagnostics;
using System.Drawing;
using RSBot.Core.Extensions;

namespace RSBot.Core.Client.ReferenceObjects;

[DebuggerDisplay("ID = {ID}; Code = {CodeName}; Name = {ObjName}")]
public abstract class RefObjCommon : IReference<uint>
{
    #region IReference

    public uint PrimaryKey => ID;

    #endregion IReference

    public virtual bool Load(ReferenceParser parser)
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

        parser.TryParse(3, out ObjName);

        //OrgObjCodeName = data[4];
        parser.TryParse(5, out NameStrID);
        //DescStrID = data[6];

        parser.TryParse(7, out CashItem);
        parser.TryParse(8, out Bionic);
        parser.TryParse(9, out TypeID1);
        parser.TryParse(10, out TypeID2);
        parser.TryParse(11, out TypeID3);
        parser.TryParse(12, out TypeID4);

        //DecayTime = int.Parse(data[13]);
        parser.TryParse(14, out Country);
        parser.TryParse(15, out Rarity);

        //CanTrade = byte.Parse(data[16]);
        //CanSell = byte.Parse(data[17]);
        //CanBuy = byte.Parse(data[18]);
        //CanBorrow = (ObjectBorrowType)byte.Parse(data[19]);

        parser.TryParse(20, out CanDrop);

        //CanPick = byte.Parse(data[21]);
        //CanRepair = byte.Parse(data[22]);
        //CanRevive = byte.Parse(data[23]);
        parser.TryParse(24, out CanUse);
        //CanThrow = byte.Parse(data[25]);

        //Pricing
        //Price = int.Parse(data[26]);
        //CostRepair = int.Parse(data[27]);
        //CostRevive = int.Parse(data[28]);
        //CostBorrow = int.Parse(data[29]);
        //KeepingFee = int.Parse(data[30]);
        //SellPrice = int.Parse(data[31]);

        //Requirements
        parser.TryParse(32, out ReqLevelType1);
        parser.TryParse(33, out ReqLevel1);
        parser.TryParse(34, out ReqLevelType2);
        parser.TryParse(35, out ReqLevel2);
        parser.TryParse(36, out ReqLevelType3);
        parser.TryParse(37, out ReqLevel3);
        parser.TryParse(38, out ReqLevelType4);
        parser.TryParse(39, out ReqLevel4);

        //MaxContain = int.Parse(data[40]);

        //RegionID = short.Parse(data[41]);
        //Dir = short.Parse(data[42]);
        //OffsetZ = short.Parse(data[43]);
        //OffsetX = short.Parse(data[44]);
        //OffsetY = short.Parse(data[45]);

        parser.TryParse(46, out Speed1);
        parser.TryParse(47, out Speed2);

        //Scale = int.Parse(data[48]);

        //BCHeight = short.Parse(data[49]);
        //BCRadius = short.Parse(data[50]);
        //EventID = int.Parse(data[51]);
        //AssocFileObj = data[52];
        //AssocFileDrop = data[53];
        parser.TryParse(54, out AssocFileIcon);
        //AssocFile1 = data[55];
        //AssocFile2 = data[56];

        return true;
    }

    public virtual string GetRealName(bool displayRarity = false)
    {
        return Game.ReferenceManager.GetTranslation(NameStrID);
    }

    /// <summary>
    ///     Gets the icon.
    /// </summary>
    /// <returns></returns>
    public Image GetIcon()
    {
        Image bitmap = null;
        try
        {
            var path = $"icon\\{AssocFileIcon}";

            if (!Game.MediaPk2.TryGetFile(path, out var file))
                file = Game.MediaPk2.GetFile("icon\\icon_default.ddj");

            bitmap = file.ToImage();
        }
        catch { }
        finally
        {
            if (bitmap == null)
                bitmap = new Bitmap(24, 24);
        }

        return bitmap;
    }

    #region Fields

    public byte Service; //bool -> Indicates whether object is used or not.
    public uint ID; //in packet reference described as RefObjID
    public string CodeName;
    public string ObjName; //Korean -> Localize by NameStrID

    //public string OrgObjCodeName; //reference codeName to original object used by clones
    public string NameStrID; //reference for ObjName localization (SN_CODENAME)

    //public string DescStrID; //references for Description localization (CODENAME_TT_DESC)
    public byte CashItem; //bool -> Indicates whether object belongs to Item Mall or not

    public byte Bionic; //bool
    public byte TypeID1;
    public byte TypeID2;
    public byte TypeID3;
    public byte TypeID4;

    /// <summary>
    ///     Gets the item Tid.
    /// </summary>
    public int Tid
    {
        get
        {
            if (Game.ClientType > GameClientType.Vietnam)
                return CashItem | Bionic | (TypeID1 << 4) | (TypeID2 << 10) | (TypeID3 << 16) | (TypeID4 << 24);

            return CashItem | Bionic | (TypeID1 << 2) | (TypeID2 << 5) | (TypeID3 << 7) | (TypeID4 << 11);
        }
    }

    //public int DecayTime; //time in milliseconds until object despawns
    public ObjectCountry Country; //Indicates where object is from

    public ObjectRarity Rarity;

    //public byte CanTrade; //bool
    //public byte CanSell; //bool
    //public byte CanBuy; //bool
    //public ObjectBorrowType CanBorrow; //link to ObjectBorrowType
    public ObjectDropType CanDrop;

    //public byte CanPick; //bool
    //public byte CanRepair; //bool
    //public byte CanRevive; //bool
    public ObjectUseType CanUse; //link to ObjectUseType

    //public byte CanThrow; //bool -> only ITEM_FORT_SHOCK_BOMB

    //public int Price;
    //public int CostRepair;
    //public int CostRevive;
    //public int CostBorrow;
    //public int KeepingFee; //Storage cost
    //public int SellPrice;

    public ObjectReqLevelType ReqLevelType1;
    public byte ReqLevel1;
    public ObjectReqLevelType ReqLevelType2;
    public byte ReqLevel2;
    public ObjectReqLevelType ReqLevelType3;
    public byte ReqLevel3;
    public ObjectReqLevelType ReqLevelType4;
    public byte ReqLevel4;

    //public int MaxContain;
    //public short RegionID; //for "STORE_" objects
    //public short Dir; //unused
    //public short OffsetZ; //for "STORE_" objects
    //public short OffsetX; //for "STORE_" objects
    //public short OffsetY; //for "STORE_" objects

    public short Speed1; //WalkSpeed
    public short Speed2; //RunSpeed

    //public int Scale;

    //public short BCHeight; //for object selection
    //public short BCRadius; //for object selection

    //public int EventID;

    //public string AssocFileObj;  //
    //public string AssocFileDrop; //DropModel
    public string AssocFileIcon; //Icon

    //public string AssocFile1; //
    //public string AssocFile2;

    #endregion Fields
}
