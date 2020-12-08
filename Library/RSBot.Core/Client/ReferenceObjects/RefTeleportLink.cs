namespace RSBot.Core.Client.ReferenceObjects
{
    public class RefTeleportLink : IReference
    {
        #region Fields

        public byte Service;
        public int OwnerTeleport;
        public int TargetTeleport;
        public int Fee;
        public byte RestrictBindMethod;
        public byte CheckResult;
        public int Restrict1;
        public int Data1_1;
        public int Data1_2;
        public int Restrict2;
        public int Data2_1;
        public int Data2_2;
        public int Restrict3;
        public int Data3_1;
        public int Data3_2;
        public int Restrict4;
        public int Data4_1;
        public int Data4_2;
        public int Restrict5;
        public int Data5_1;
        public int Data5_2;

        #endregion Fields

        public RefTeleport Owner => Game.ReferenceManager.TeleportData.Find(t => t.ID == OwnerTeleport);
        public RefTeleport Target => Game.ReferenceManager.TeleportData.Find(t => t.ID == TargetTeleport);

        #region IReference

        public bool Load(ReferenceParser reader)
        {
            //Skip disabled
            if (!reader.TryParseByte(0, out Service) || Service == 0)
                return false;

            reader.TryParseInt(1, out OwnerTeleport);
            reader.TryParseInt(2, out TargetTeleport);
            reader.TryParseInt(3, out Fee);
            reader.TryParseByte(4, out RestrictBindMethod);
            reader.TryParseByte(5, out CheckResult);

            reader.TryParseInt(6, out Restrict1);
            reader.TryParseInt(7, out Data1_1);
            reader.TryParseInt(8, out Data1_2);

            reader.TryParseInt(9, out Restrict2);
            reader.TryParseInt(10, out Data2_1);
            reader.TryParseInt(11, out Data2_2);

            reader.TryParseInt(12, out Restrict3);
            reader.TryParseInt(13, out Data3_1);
            reader.TryParseInt(14, out Data3_2);

            reader.TryParseInt(15, out Restrict4);
            reader.TryParseInt(16, out Data4_1);
            reader.TryParseInt(17, out Data4_2);

            reader.TryParseInt(18, out Restrict5);
            reader.TryParseInt(19, out Data5_1);
            reader.TryParseInt(20, out Data5_2);

            return true;
        }

        #endregion IReference
    }
}

//Service int
//OwnerTeleport   int
//TargetTeleport  int
//Fee int
//RestrictBindMethod  tinyint
//RunTimeTeleportMethod   tinyint
//CheckResult tinyint
//Restrict1   int
//Data1_1 int
//Data1_2 int
//Restrict2   int
//Data2_1 int
//Data2_2 int
//Restrict3   int
//Data3_1 int
//Data3_2 int
//Restrict4   int
//Data4_1 int
//Data4_2 int
//Restrict5   int
//Data5_1 int
//Data5_2 int