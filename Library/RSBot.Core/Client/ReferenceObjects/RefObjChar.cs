namespace RSBot.Core.Client.ReferenceObjects;

public class RefObjChar : RefObjCommon
{
    public bool IsDimensionPillar => NameStrID == "SN_MOB_GOD_PILLAR";
    public bool IsSummonFlower => CodeName.StartsWith("STRUCTURE_SUMMON_FLOWER_");
    public bool IsEventMob => CodeName.StartsWith("MOB_EV");
    public bool IsPandora => TypeID2 == 2 && TypeID3 == 1 && TypeID4 == 5;

    public override bool Load(ReferenceParser parser)
    {
        if (!base.Load(parser))
            return false;

        parser.TryParse(57, out Level);
        parser.TryParse(58, out CharGender);
        parser.TryParse(59, out MaxHealth);
        parser.TryParse(60, out MaxMP);

        parser.TryParse(61, out InventorySize);

        parser.TryParse(62, out CanStore_TID1);
        parser.TryParse(63, out CanStore_TID2);
        parser.TryParse(64, out CanStore_TID3);
        parser.TryParse(65, out CanStore_TID4);
        parser.TryParse(66, out CanBeVehicle);
        parser.TryParse(67, out CanControl);
        parser.TryParse(68, out DamagePortion);
        parser.TryParse(69, out MaxPassenger);

        return true;
    }

    #region Fields

    public byte Level;
    public ObjectGender CharGender;
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
}
