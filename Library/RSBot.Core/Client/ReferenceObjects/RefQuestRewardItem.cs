namespace RSBot.Core.Client.ReferenceObjects;

public class RefQuestRewardItem : IReference
{
    public bool Load(ReferenceParser parser)
    {
        parser.TryParse(0, out QuestId);
        parser.TryParse(1, out QuestCodeName);
        parser.TryParse(2, out RewardType);
        parser.TryParse(3, out ItemCodeName);
        parser.TryParse(4, out OptionalItemCode);
        parser.TryParse(5, out OptionalItemCount);
        parser.TryParse(6, out AchieveQuantity);
        parser.TryParse(7, out RentItemCodeName);

        return true;
    }

    #region Fields

    public uint QuestId;
    public string QuestCodeName;
    public byte RewardType;
    public string ItemCodeName;
    public string OptionalItemCode;
    public int OptionalItemCount;
    public int AchieveQuantity;
    public string RentItemCodeName;

    public RefObjItem Item => ItemCodeName == "xxx" ? null : Game.ReferenceManager.GetRefItem(ItemCodeName);

    public RefObjItem OptionalItem =>
        OptionalItemCode == "xxx" ? null : Game.ReferenceManager.GetRefItem(OptionalItemCode);

    public RefObjItem RentItem => OptionalItemCode == "xxx" ? null : Game.ReferenceManager.GetRefItem(RentItemCodeName);

    #endregion Fields
}
