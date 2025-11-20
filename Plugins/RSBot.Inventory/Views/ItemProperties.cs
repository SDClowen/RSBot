using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using RSBot.Core;
using RSBot.Core.Client.ReferenceObjects;
using RSBot.Core.Objects;
using RSBot.Core.Objects.Item;
using SDUI.Controls;

namespace RSBot.Inventory.Views;

public partial class ItemProperties : UIWindowBase
{
    #region Constructor

    public ItemProperties(InventoryItem inventoryItem)
    {
        InitializeComponent();

        InventoryItem = inventoryItem;
        Text =
            $"Item properties - {InventoryItem.Record.GetRealName()} [Id: {InventoryItem.Record.ID}, TID2: {InventoryItem.Record.TypeID2}, TID3: {InventoryItem.Record.TypeID3}, TID4: {InventoryItem.Record.TypeID4}]";
        Size = new Size(620, 800);

        try
        {
            var iconImage = InventoryItem.Record.GetIcon();
            var iconBitmap = new Bitmap(iconImage);
            var iconHandle = iconBitmap.GetHicon();

            Icon = Icon.FromHandle(iconHandle);
        }
        catch
        {
            ShowIcon = false;
        }

        propItem.SelectedObject = new ItemDebugInformation(InventoryItem);
    }

    #endregion Constructor

    #region Properties

    public InventoryItem InventoryItem { get; }

    #endregion Properties
}

internal class ItemDebugInformation
{
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
        Icon = item.Record.GetIcon();
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

    [Category("RefObjItem")]
    public int MaxStack { get; }

    [Category("RefObjItem")]
    public byte ReqGender { get; }

    [Category("RefObjItem")]
    public int ReqStr { get; }

    [Category("RefObjItem")]
    public int ReqInt { get; }

    [Category("RefObjItem")]
    public byte ItemClass { get; }

    [Category("RefObjItem")]
    public byte Quivered { get; }

    [Category("RefObjItem")]
    public byte SpeedClass { get; }

    [Category("RefObjItem")]
    public byte TwoHanded { get; }

    [Category("RefObjItem")]
    public short Range { get; }

    [Category("RefObjItem")]
    public int Param1 { get; }

    [Category("RefObjItem")]
    public int Param2 { get; }

    [Category("RefObjItem")]
    public int Param3 { get; }

    [Category("RefObjItem")]
    public int Param4 { get; }

    [Category("RefObjItem")]
    public string Desc1 { get; }

    [Category("RefObjItem")]
    public string Desc2 { get; }

    [Category("RefObjItem")]
    public string Desc3 { get; }

    [Category("RefObjItem")]
    public string Desc4 { get; }

    [Category("RefObjCommon")]
    public byte TypeID1 { get; }

    [Category("RefObjCommon")]
    public byte TypeID2 { get; }

    [Category("RefObjCommon")]
    public byte TypeID3 { get; }

    [Category("RefObjCommon")]
    public byte TypeID4 { get; }

    [Category("RefObjItem")]
    public bool IsEquip => TypeID2 == 1;

    [Category("RefObjItem")]
    public bool IsJobEquip => TypeID2 == 1 && TypeID3 == 7;

    [Category("RefObjItem")]
    public bool IsStackable => TypeID2 == 3;

    [Category("RefObjItem")]
    public bool IsGold => IsStackable && TypeID3 == 5 && TypeID4 == 0;

    [Category("RefObjItem")]
    public bool IsTrading => IsStackable && TypeID3 == 8;

    [Category("RefObjItem")]
    public bool IsQuest => IsStackable && TypeID3 == 9;

    [Category("RefObjItem")]
    public bool IsSkillItem => IsStackable && TypeID3 == 13 && TypeID4 == 1;

    [Category("RefObjItem")]
    public int Degree => (ItemClass - 1) / 3 + 1;

    [Category("RefObjItem")]
    public int DegreeOffset => ItemClass - 3 * ((ItemClass - 1) / 3) - 1; //sro_client.sub_8BA6E0

    [Category("InventoryItem")]
    public byte OptLevel { get; }

    [Category("InventoryItem")]
    public ulong Variance { get; }

    [Category("InventoryItem")]
    public uint Durability { get; }

    [Category("InventoryItem")]
    public List<MagicOptionInfo> MagicOptions { get; }

    [Category("InventoryItem")]
    public List<BindingOption> BindingOptions { get; }

    [Category("InventoryItem")]
    public ushort Amount { get; }

    [Category("InventoryItem")]
    public InventoryItemState State { get; }

    [Category("RefObjCommon")]
    public byte Service { get; }

    [Category("RefObjCommon")]
    public uint Id { get; }

    [Category("RefObjCommon")]
    public string CodeName { get; }

    [Category("RefObjCommon")]
    public string ObjName { get; } //Korean -> Localize by NameStrID

    [Category("RefObjCommon")]
    public string NameStrID { get; } //reference for ObjName localization (SN_CODENAME)

    [Category("RefObjCommon")]
    public byte CashItem { get; }

    [Category("RefObjCommon")]
    public byte Bionic { get; }

    [Category("RefObjCommon")]
    public int Tid
    {
        get
        {
            if (Game.ClientType > GameClientType.Vietnam)
                return CashItem | Bionic | (TypeID1 << 4) | (TypeID2 << 10) | (TypeID3 << 16) | (TypeID4 << 24);

            return CashItem | Bionic | (TypeID1 << 2) | (TypeID2 << 5) | (TypeID3 << 7) | (TypeID4 << 11);
        }
    }

    [Category("RefObjCommon")]
    public ObjectCountry Country { get; }

    [Category("RefObjCommon")]
    public ObjectRarity Rarity { get; }

    [Category("RefObjCommon")]
    public ObjectReqLevelType ReqLevelType1 { get; }

    [Category("RefObjCommon")]
    public byte ReqLevel1 { get; }

    [Category("RefObjCommon")]
    public ObjectReqLevelType ReqLevelType2 { get; }

    [Category("RefObjCommon")]
    public byte ReqLevel2 { get; }

    [Category("RefObjCommon")]
    public ObjectReqLevelType ReqLevelType3 { get; }

    [Category("RefObjCommon")]
    public byte ReqLevel3 { get; }

    [Category("RefObjCommon")]
    public ObjectReqLevelType ReqLevelType4 { get; }

    [Category("RefObjCommon")]
    public byte ReqLevel4 { get; }

    [Category("RefObjCommon")]
    public short Speed1 { get; } //WalkSpeed

    [Category("RefObjCommon")]
    public short Speed2 { get; } //RunSpeed

    [Category("RefObjCommon")]
    public string AssocFileIcon { get; } //Icon

    [Category("RefObjCommon")]
    public Image Icon { get; }

    [Category("RentalInfo")]
    public uint Type { get; }

    [Category("RentalInfo")]
    public ushort CanDelete { get; }

    [Category("RentalInfo")]
    public ulong PeriodBeginTime { get; }

    [Category("RentalInfo")]
    public ulong PeriodEndTime { get; }

    [Category("RentalInfo")]
    public ushort CanRecharge { get; }

    [Category("RentalInfo")]
    public ulong MeterRateTime { get; }

    [Category("RentalInfo")]
    public ulong PackingTime { get; }

    [Category("InventoryItem")]
    public bool ItemSkillInUse { get; }
}
