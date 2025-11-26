namespace RSBot.Core.Client.ReferenceObjects;

public class RefSkillByItemOptLevel : IReference
{
    public int Link;
    public uint SkillId;

    public bool Load(ReferenceParser parser)
    {
        parser.TryParse(0, out Link);
        parser.TryParse(1, out SkillId);

        return true;
    }
}
