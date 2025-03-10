using System.ComponentModel;
using System.Runtime.CompilerServices;
using RSBot.Core.Client.ReferenceObjects;
using RSBot.Core.Objects;

namespace RSBot.Inventory.Avalonia.ViewModels;

/// <summary>
/// View model for the ItemProperties window
/// </summary>
public class ItemPropertiesViewModel : INotifyPropertyChanged
{
    private readonly InventoryItem _inventoryItem;
    private ItemDebugInformation _itemDebugInfo;

    /// <summary>
    /// Initializes a new instance of the ItemPropertiesViewModel class
    /// </summary>
    /// <param name="inventoryItem">The inventory item to display properties for</param>
    public ItemPropertiesViewModel(InventoryItem inventoryItem)
    {
        _inventoryItem = inventoryItem;
        _itemDebugInfo = new ItemDebugInformation(inventoryItem);
        WindowTitle = $"Item properties - {_inventoryItem.Record.GetRealName()} [Id: {_inventoryItem.Record.ID}, TID2: {_inventoryItem.Record.TypeID2}, TID3: {_inventoryItem.Record.TypeID3}, TID4: {_inventoryItem.Record.TypeID4}]";
    }

    /// <summary>
    /// Gets the window title
    /// </summary>
    public string WindowTitle { get; }

    /// <summary>
    /// Gets the item debug information
    /// </summary>
    public ItemDebugInformation ItemDebugInfo
    {
        get => _itemDebugInfo;
        set
        {
            _itemDebugInfo = value;
            OnPropertyChanged();
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}

/// <summary>
/// Contains debug information about an inventory item
/// </summary>
public class ItemDebugInformation
{
    /// <summary>
    /// Initializes a new instance of the ItemDebugInformation class
    /// </summary>
    /// <param name="item">The inventory item</param>
    public ItemDebugInformation(InventoryItem item)
    {
        MaxStack = item.Record.MaxStack;
        ReqGender = item.Record.ReqGender;
        ReqStr = item.Record.ReqStr;
        ReqInt = item.Record.ReqInt;
        ItemClass = item.Record.ItemClass;
        Quivered = item.Record.Quivered;
        SpeedClass = item.Record.SpeedClass;
        TwoHanded = item.Record.TwoHanded;
        Range = item.Record.Range;
        Param1 = item.Record.Param1;
        Param2 = item.Record.Param2;
        Param3 = item.Record.Param3;
        Param4 = item.Record.Param4;
        Desc1 = item.Record.Desc1;
        Desc2 = item.Record.Desc2;
        Desc3 = item.Record.Desc3;
        Desc4 = item.Record.Desc4;
        OptLevel = item.OptLevel;
        Variance = item.Attributes.Variance;
        Durability = item.Durability;
        MagicOptions = item.MagicOptions;
        BindingOptions = item.BindingOptions;
        Amount = item.Amount;
        State = item.State;
        TypeID1 = item.Record.TypeID1;
        TypeID2 = item.Record.TypeID2;
        TypeID3 = item.Record.TypeID3;
        TypeID4 = item.Record.TypeID4;
        Service = item.Record.Service;
        Id = item.Record.ID;
        CodeName = item.Record.CodeName;
        ObjName = item.Record.ObjName;
        NameStrID = item.Record.NameStrID;
        CashItem = item.Record.CashItem;
        Bionic = item.Record.Bionic;
        Country = item.Record.Country;
        Rarity = item.Record.Rarity;
        ReqLevelType1 = item.Record.ReqLevelType1;
        ReqLevel1 = item.Record.ReqLevel1;
        ReqLevelType2 = item.Record.ReqLevelType2;
        ReqLevel2 = item.Record.ReqLevel2;
        ReqLevelType3 = item.Record.ReqLevelType3;
        ReqLevel3 = item.Record.ReqLevel3;
        ReqLevelType4 = item.Record.ReqLevelType4;
        ReqLevel4 = item.Record.ReqLevel4;
        Speed1 = item.Record.Speed1;
        Speed2 = item.Record.Speed2;
        AssocFileIcon = item.Record.AssocFileIcon;
        ItemSkillInUse = item.ItemSkillInUse;

        if (item.Rental == null)
            return;

        Type = item.Rental.Type;
        CanDelete = item.Rental.CanDelete;
        PeriodBeginTime = item.Rental.PeriodBeginTime;
        PeriodEndTime = item.Rental.PeriodEndTime;
        CanRecharge = item.Rental.CanRecharge;
        MeterRateTime = item.Rental.MeterRateTime;
        PackingTime = item.Rental.PackingTime;
    }

    [Category("RefObjItem")] public int MaxStack { get; }
    [Category("RefObjItem")] public byte ReqGender { get; }
    [Category("RefObjItem")] public int ReqStr { get; }
    [Category("RefObjItem")] public int ReqInt { get; }
    [Category("RefObjItem")] public byte ItemClass { get; }
    [Category("RefObjItem")] public byte Quivered { get; }
    [Category("RefObjItem")] public byte SpeedClass { get; }
    [Category("RefObjItem")] public byte TwoHanded { get; }
    [Category("RefObjItem")] public short Range { get; }
    [Category("RefObjItem")] public int Param1 { get; }
    [Category("RefObjItem")] public int Param2 { get; }
    [Category("RefObjItem")] public int Param3 { get; }
    [Category("RefObjItem")] public int Param4 { get; }
    [Category("RefObjItem")] public string Desc1 { get; }
    [Category("RefObjItem")] public string Desc2 { get; }
    [Category("RefObjItem")] public string Desc3 { get; }
    [Category("RefObjItem")] public string Desc4 { get; }
    [Category("Item")] public byte OptLevel { get; }
    [Category("Item")] public ulong Variance { get; }
    [Category("Item")] public uint Durability { get; }
    [Category("Item")] public object MagicOptions { get; }
    [Category("Item")] public object BindingOptions { get; }
    [Category("Item")] public ushort Amount { get; }
    [Category("Item")] public InventoryItemState State { get; }
    [Category("RefObjCommon")] public byte TypeID1 { get; }
    [Category("RefObjCommon")] public byte TypeID2 { get; }
    [Category("RefObjCommon")] public byte TypeID3 { get; }
    [Category("RefObjCommon")] public byte TypeID4 { get; }
    [Category("RefObjCommon")] public byte Service { get; }
    [Category("RefObjCommon")] public uint Id { get; }
    [Category("RefObjCommon")] public string CodeName { get; }
    [Category("RefObjCommon")] public string ObjName { get; }
    [Category("RefObjCommon")] public string NameStrID { get; }
    [Category("RefObjCommon")] public byte CashItem { get; }
    [Category("RefObjCommon")] public byte Bionic { get; }
    [Category("RefObjCommon")] public ObjectCountry Country { get; }
    [Category("RefObjCommon")] public ObjectRarity Rarity { get; }
    [Category("RefObjCommon")] public ObjectReqLevelType ReqLevelType1 { get; }
    [Category("RefObjCommon")] public byte ReqLevel1 { get; }
    [Category("RefObjCommon")] public ObjectReqLevelType ReqLevelType2 { get; }
    [Category("RefObjCommon")] public byte ReqLevel2 { get; }
    [Category("RefObjCommon")] public ObjectReqLevelType ReqLevelType3 { get; }
    [Category("RefObjCommon")] public byte ReqLevel3 { get; }
    [Category("RefObjCommon")] public ObjectReqLevelType ReqLevelType4 { get; }
    [Category("RefObjCommon")] public byte ReqLevel4 { get; }
    [Category("RefObjCommon")] public float Speed1 { get; }
    [Category("RefObjCommon")] public float Speed2 { get; }
    [Category("RefObjCommon")] public string AssocFileIcon { get; }
    [Category("Item")] public bool ItemSkillInUse { get; }
    [Category("Rental")] public uint? Type { get; }
    [Category("Rental")] public ushort? CanDelete { get; }
    [Category("Rental")] public ulong? PeriodBeginTime { get; }
    [Category("Rental")] public ulong? PeriodEndTime { get; }
    [Category("Rental")] public ushort? CanRecharge { get; }
    [Category("Rental")] public ulong? MeterRateTime { get; }
    [Category("Rental")] public ulong? PackingTime { get; }
} 