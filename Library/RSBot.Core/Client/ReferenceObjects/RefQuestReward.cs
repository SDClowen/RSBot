namespace RSBot.Core.Client.ReferenceObjects;

public class RefQuestReward : IReference<uint>
{
    public uint PrimaryKey => QuestId;

    public bool Load(ReferenceParser parser)
    {
        parser.TryParse(0, out QuestId);
        parser.TryParse(1, out QuestCodeName);
        parser.TryParse(2, out IsView);
        parser.TryParse(3, out IsBasicReward);
        parser.TryParse(4, out IsItemReward);
        parser.TryParse(5, out IsCheckCondition);
        parser.TryParse(6, out IsCheckCountry);
        parser.TryParse(7, out IsCheckClass);
        parser.TryParse(8, out IsCheckGender);

        //9?!

        parser.TryParse(10, out Gold);
        parser.TryParse(11, out Exp);
        parser.TryParse(12, out SPExp);
        parser.TryParse(13, out SP);
        parser.TryParse(14, out AP);
        parser.TryParse(15, out APType);
        parser.TryParse(16, out Hwan);
        parser.TryParse(17, out InventorySlots);
        parser.TryParse(18, out ItemRewardType);
        parser.TryParse(19, out SelectionCount);

        return true;
    }

    #region Fields

    public uint QuestId;
    public string QuestCodeName;
    public bool IsView;
    public bool IsBasicReward;
    public bool IsItemReward;
    public bool IsCheckCondition;
    public bool IsCheckCountry;
    public bool IsCheckClass;
    public bool IsCheckGender;
    public int Gold;
    public int Exp;
    public int SPExp;
    public int SP;
    public int AP;
    public string APType;
    public byte Hwan;
    public byte InventorySlots;
    public byte ItemRewardType;
    public byte SelectionCount;

    #endregion Fields
}
