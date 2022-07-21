namespace RSBot.Core.Client.ReferenceObjects
{
    public class RefExtraAbilityByEquipItemOptLevel : IReference
    {
        public uint ItemId;
        public byte OptLevel;
        public uint SkillId;

        public bool Load(ReferenceParser parser)
        {
            if (!parser.TryParse(0, out int service) || service == 0)
                return false;

            if (!parser.TryParse(20, out SkillId) || SkillId == 0)
                return false;

            parser.TryParse(1, out ItemId);
            parser.TryParse(2, out OptLevel);

            return true;
        }
    }
}
