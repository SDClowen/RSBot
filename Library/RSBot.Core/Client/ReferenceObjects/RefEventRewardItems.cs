namespace RSBot.Core.Client.ReferenceObjects;

public class RefEventRewardItems : IReference
{
    public bool Load(ReferenceParser parser)
    {
        parser.TryParse(0, out EventId);
        parser.TryParse(1, out EventCodeName);
        parser.TryParse(2, out ItemCodeName);
        parser.TryParse(3, out ItemAmount);
        parser.TryParse(7, out MinRequiredLevel);
        parser.TryParse(8, out MaxRequiredLevel);

        return true;
    }

    #region Fields

    public uint EventId;
    public string EventCodeName;
    public string ItemCodeName;
    public ushort ItemAmount;
    public ushort MinRequiredLevel;
    public ushort MaxRequiredLevel;

    public RefObjItem Item => ItemCodeName == "xxx" ? null : Game.ReferenceManager.GetRefItem(ItemCodeName);

    #endregion Fields
}
