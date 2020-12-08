namespace RSBot.Core.Client.ReferenceObjects
{
    public class RefObjChar : RefObjCommon
    {
        #region Fields

        public byte Level;
        public byte CharGender;
        public int MaxHealth;
        public int MaxMP;
        public byte InventorySize;
        public byte CanStore_TID1;
        public byte CanStore_TID2;
        public byte CanStore_TID3;
        public byte CanStore_TID4;
        public byte CanBeVehicle;
        public byte CanControl;
        public byte DamagePortion;
        public short MaxPassenger;

        #endregion Fields

        public override bool Load(ReferenceParser parser)
        {
            if (!base.Load(parser))
                return false;

            parser.TryParseByte(57, out Level);
            parser.TryParseByte(58, out CharGender);
            parser.TryParseInt(59, out MaxHealth);
            parser.TryParseInt(60, out MaxMP);

            parser.TryParseByte(61, out InventorySize);

            parser.TryParseByte(62, out CanStore_TID1);
            parser.TryParseByte(63, out CanStore_TID2);
            parser.TryParseByte(64, out CanStore_TID3);
            parser.TryParseByte(65, out CanStore_TID4);
            parser.TryParseByte(66, out CanBeVehicle);
            parser.TryParseByte(67, out CanControl);
            parser.TryParseByte(68, out DamagePortion);
            parser.TryParseShort(69, out MaxPassenger);

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
//Lvl                       2
//CharGender                2
//MaxHealth                     55
//MaxMP                     0
//Size             0
//CanStore_TID1             0
//CanStore_TID2             0
//CanStore_TID3             0
//CanStore_TID4             0
//CanBeVehicle              0
//CanControl                0
//DamagePortion             0
//MaxPassenger              0
//AssocTactics              0
//PD                        9
//MD                        14
//PAR                       2
//MAR                       2
//ER                        29
//BR                        0
//HR                        29
//CHR                       2
//ExpToGive                 47
//CreepType                 1684300900
//Knockdown                 3
//KO_RecoverTime            3000
//DefaultSkill_1            162
//DefaultSkill_2            0
//DefaultSkill_3            0
//DefaultSkill_4            0
//DefaultSkill_5            0
//DefaultSkill_6            0
//DefaultSkill_7            0
//DefaultSkill_8            0
//DefaultSkill_9            0
//DefaultSkill_10           0
//TextureType               1
//Except_1                  0
//Except_2                  0
//Except_3                  0
//Except_4                  0
//Except_5                  0
//Except_6                  0
//Except_7                  0
//Except_8                  0
//Except_9                  0
//Except_10                 0

//--------------------------------------------------

//_RefObjChar:
//ID                        int
//Lvl                       tinyint
//CharGender                tinyint
//MaxHealth                     int
//MaxMP                     int
//ResistFrozen              int
//ResistFrostbite           int
//ResistBurn                int
//ResistEShock              int
//ResistPoison              int
//ResistZombie              int
//ResistSleep               int
//ResistRoot                int
//ResistSlow                int
//ResistFear                int
//ResistMyopia              int
//ResistBlood               int
//ResistStone               int
//ResistDark                int
//ResistStun                int
//ResistDisea               int
//ResistChaos               int
//ResistCsePD               int
//ResistCseMD               int
//ResistCseSTR              int
//ResistCseINT              int
//ResistCseHP               int
//ResistCseMP               int
//Resist24                  int
//ResistBomb                int
//Resist26                  int
//Resist27                  int
//Resist28                  int
//Resist29                  int
//Resist30                  int
//Resist31                  int
//Resist32                  int
//Size             tinyint
//CanStore_TID1             tinyint
//CanStore_TID2             tinyint
//CanStore_TID3             tinyint
//CanStore_TID4             tinyint
//CanBeVehicle              tinyint
//CanControl                tinyint
//DamagePortion             tinyint
//MaxPassenger              smallint
//AssocTactics              int
//PD                        int
//MD                        int
//PAR                       int
//MAR                       int
//ER                        int
//BR                        int
//HR                        int
//CHR                       int
//ExpToGive                 int
//CreepType                 int
//Knockdown                 tinyint
//KO_RecoverTime            int
//DefaultSkill_1            int
//DefaultSkill_2            int
//DefaultSkill_3            int
//DefaultSkill_4            int
//DefaultSkill_5            int
//DefaultSkill_6            int
//DefaultSkill_7            int
//DefaultSkill_8            int
//DefaultSkill_9            int
//DefaultSkill_10           int
//TextureType               tinyint
//Except_1                  int
//Except_2                  int
//Except_3                  int
//Except_4                  int
//Except_5                  int
//Except_6                  int
//Except_7                  int
//Except_8                  int
//Except_9                  int
//Except_10                 int
//Link                      int