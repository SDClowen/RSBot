using System.Diagnostics;

namespace RSBot.Core.Client.ReferenceObjects
{
    [DebuggerDisplay("ID = {ID}; Code = {CodeName}; Name = {ObjName}")]
    public abstract class RefObjCommon : IReference<uint>
    {
        #region IReference

        public uint PrimaryKey => ID;

        #endregion IReference

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
        /// Gets the item Tid.
        /// </summary>
        public int Tid 
        { 
            get
            {
                if(Game.ClientType > GameClientType.Vietnam)
                    return CashItem | Bionic | TypeID1 << 4 | TypeID2 << 10 | (TypeID3 << 16) | (TypeID4 << 24);

                return CashItem | Bionic | TypeID1 << 2 | TypeID2 << 5 | TypeID3 << 7 | TypeID4 << 11;
            }
        }


        //public int DecayTime; //time in milliseconds until object despawns
        public ObjectCountry Country; //Indicates where object is from

        public ObjectRarity Rarity;

        //public byte CanTrade; //bool
        //public byte CanSell; //bool
        //public byte CanBuy; //bool
        //public ObjectBorrowType CanBorrow; //link to ObjectBorrowType
        //public ObjectDropType CanDrop; //link to ObjectDropType
        //public byte CanPick; //bool
        //public byte CanRepair; //bool
        //public byte CanRevive; //bool
        //public ObjectUseType CanUse; //link to ObjectUseType
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

        public virtual string GetRealName(bool displayRarity = false)
        {
            return Game.ReferenceManager.GetTranslation(NameStrID);
        }

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
            //CanDrop = (ObjectDropType)byte.Parse(data[20]);
            //CanPick = byte.Parse(data[21]);
            //CanRepair = byte.Parse(data[22]);
            //CanRevive = byte.Parse(data[23]);
            //CanUse = (ObjectUseType)byte.Parse(data[24]);
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
    }
}

//Service	                1
//ID	                    1934
//CodeName128               MOB_CH_BIGEYEGHOST_CLON
//ObjName128                소안귀
//OrgObjCodeName128         MOB_CH_BIGEYEGHOST
//NameStrID128          	SN_MOB_CH_BIGEYEGHOST_CLON
//DescStrID128          	xxx
//CashItem	                0
//Bionic	                1
//TypeID1	                1
//TypeID2	                2
//TypeID3	                1
//TypeID4	                1
//DecayTime	                5000
//Country	                0
//Rarity	                0
//CanTrade	                0
//CanSell	                0
//CanBuy	                0
//CanBorrow	                0
//CanDrop	                0
//CanPick	                0
//CanRepair	                0
//CanRevive	                0
//CanUse	                0
//CanThrow	                0
//Price                 	0
//CostRepair	            0
//CostRevive	            0
//CostBorrow	            0
//KeepingFee	            0
//SellPrice	                0
//ReqLevelType1         	-1
//ReqLevel1	                0
//ReqLevelType2         	-1
//ReqLevel2	                0
//ReqLevelType3	            -1
//ReqLevel3	                0
//ReqLevelType4	            -1
//ReqLevel4             	0
//MaxContain            	4
//RegionID	                0
//Dir	                    0
//OffsetX	                0
//OffsetY	                0
//OffsetZ	                0
//Speed1	                14
//Speed2	                55
//Scale                 	100
//BCHeight	                0
//BCRadius	                6
//EventID	                0
//AssocFileObj128	        xxx
//AssocFileDrop128	        xxx
//AssocFileIcon128	        xxx
//AssocFile1_128	        xxx
//AssocFile2_128	        xxx

//_RefObjCommon:
//Service	                int
//ID	                    int
//CodeName128               varchar(129)
//ObjName128                varchar(129)
//OrgObjCodeName128         varchar(129)
//NameStrID128          	varchar(129)
//DescStrID128          	varchar(129)
//CashItem	                tinyint
//Bionic	                tinyint
//TypeID1	                tinyint
//TypeID2	                tinyint
//TypeID3	                tinyint
//TypeID4	                tinyint
//DecayTime	                int
//Country	                tinyint
//Rarity	                tinyint
//CanTrade	                tinyint
//CanSell	                tinyint
//CanBuy	                tinyint
//CanBorrow	                tinyint
//CanDrop	                tinyint
//CanPick	                tinyint
//CanRepair	                tinyint
//CanRevive	                tinyint
//CanUse	                tinyint
//CanThrow	                tinyint
//Price                 	int
//CostRepair	            int
//CostRevive	            int
//CostBorrow	            int
//KeepingFee	            int
//SellPrice	                int
//ReqLevelType1         	int
//ReqLevel1	                tinyint
//ReqLevelType2         	int
//ReqLevel2	                tinyint
//ReqLevelType3	            int
//ReqLevel3	                tinyint
//ReqLevelType4	            int
//ReqLevel4             	tinyint
//MaxContain            	int
//RegionID	                smallint
//Dir	                    smallint
//OffsetX	                smallint
//OffsetY	                smallint
//OffsetZ	                smallint
//Speed1	                smallint
//Speed2	                smallint
//Scale                 	int
//BCHeight	                smallint
//BCRadius	                smallint
//EventID	                int
//AssocFileObj128	        varchar(129)
//AssocFileDrop128	        varchar(129)
//AssocFileIcon128	        varchar(129)
//AssocFile1_128	        varchar(129)
//AssocFile2_128	        varchar(129)
//Link	                    int