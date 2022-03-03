namespace RSBot.Core.Client.ReferenceObjects
{
    public class RefObjChar : RefObjCommon
    {
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

        public override bool Load(ReferenceParser parser)
        {
            if (!base.Load(parser))
                return false;

            parser.TryParseByte(57, out Level);
            parser.TryParseEnum(58, out CharGender);
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