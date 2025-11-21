namespace RSBot.Core.Objects.Item;

public struct InventoryItemCosInfo
{
    /// <summary>
    ///     Model Id
    /// </summary>
    public uint Id;

    /// <summary>
    ///     The name
    /// </summary>
    public string Name;

    private byte _level;

    /// <summary>
    ///     The level (Do not use lower then chinese clients!)
    /// </summary>
    public byte Level
    {
        get
        {
            if (Game.ClientType >= GameClientType.Chinese_Old)
                return _level;

            var record = Game.ReferenceManager.GetRefObjChar(Id);
            if (record != null)
                return record.Level;

            return 1;
        }
        set => _level = value;
    }

    /// <summary>
    ///     The rental
    /// </summary>
    public RentInfo Rental;
}
