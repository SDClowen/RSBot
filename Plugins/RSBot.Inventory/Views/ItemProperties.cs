using RSBot.Core;
using RSBot.Core.Client.ReferenceObjects;
using RSBot.Core.Objects;
using RSBot.Core.Objects.Item;
using SDUI.Controls;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

namespace RSBot.Inventory.Views
{
    public partial class ItemProperties : CleanForm
    {
        #region Properties

        public InventoryItem InventoryItem { get; }

        #endregion Properties

        #region Constructor

        public ItemProperties(InventoryItem inventoryItem)
        {
            InitializeComponent();

            InventoryItem = inventoryItem;
            Text = $"Item properties - {InventoryItem.Record.GetRealName()} [Id: {InventoryItem.Record.ID}, TID2: {InventoryItem.Record.TypeID2}, TID3: {InventoryItem.Record.TypeID3}, TID4: {InventoryItem.Record.TypeID4}]";
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
    }

    internal class ItemDebugInformation
    {
        [Category("RefObjItem")]
        public int MaxStack { get; private set; }

        [Category("RefObjItem")]
        public byte ReqGender { get; private set; }

        [Category("RefObjItem")]
        public int ReqStr { get; private set; }

        [Category("RefObjItem")]
        public int ReqInt { get; private set; }

        [Category("RefObjItem")]
        public byte ItemClass { get; private set; }

        [Category("RefObjItem")]
        public byte Quivered { get; private set; }

        [Category("RefObjItem")]
        public byte SpeedClass { get; private set; }

        [Category("RefObjItem")]
        public byte TwoHanded { get; private set; }

        [Category("RefObjItem")]
        public short Range { get; private set; }

        [Category("RefObjItem")]
        public int Param1 { get; private set; }

        [Category("RefObjItem")]
        public int Param2 { get; private set; }

        [Category("RefObjItem")]
        public int Param3 { get; private set; }

        [Category("RefObjItem")]
        public int Param4 { get; private set; }

        [Category("RefObjItem")]
        public string Desc1 { get; private set; }

        [Category("RefObjItem")]
        public string Desc2 { get; private set; }

        [Category("RefObjItem")]
        public string Desc3 { get; private set; }

        [Category("RefObjItem")]
        public string Desc4 { get; private set; }

        [Category("RefObjCommon")]
        public byte TypeID1 { get; private set; }

        [Category("RefObjCommon")]
        public byte TypeID2 { get; private set; }

        [Category("RefObjCommon")]
        public byte TypeID3 { get; private set; }

        [Category("RefObjCommon")]
        public byte TypeID4 { get; private set; }

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
        public byte OptLevel { get; private set; }

        [Category("InventoryItem")]
        public ulong Variance { get; private set; }

        [Category("InventoryItem")]
        public uint Durability { get; private set; }

        [Category("InventoryItem")]
        public List<MagicOptionInfo> MagicOptions { get; private set; }

        [Category("InventoryItem")]
        public List<BindingOption> BindingOptions { get; private set; }

        [Category("InventoryItem")]
        public ushort Amount { get; private set; }

        [Category("InventoryItem")]
        public InventoryItemState State { get; private set; }

        [Category("RefObjCommon")]
        public byte Service { get; private set; }

        [Category("RefObjCommon")]
        public uint Id { get; private set; }

        [Category("RefObjCommon")]
        public string CodeName { get; private set; }

        [Category("RefObjCommon")]
        public string ObjName { get; private set; } //Korean -> Localize by NameStrID

        [Category("RefObjCommon")]
        public string NameStrID { get; private set; } //reference for ObjName localization (SN_CODENAME)

        [Category("RefObjCommon")]
        public byte CashItem { get; private set; }

        [Category("RefObjCommon")]
        public byte Bionic { get; private set; }

        [Category("RefObjCommon")]
        public int Tid
        {
            get
            {
                if (Game.ClientType > GameClientType.Vietnam)
                    return CashItem | Bionic | TypeID1 << 4 | TypeID2 << 10 | (TypeID3 << 16) | (TypeID4 << 24);

                return CashItem | Bionic | TypeID1 << 2 | TypeID2 << 5 | TypeID3 << 7 | TypeID4 << 11;
            }
        }

        [Category("RefObjCommon")]
        public ObjectCountry Country { get; private set; }

        [Category("RefObjCommon")]
        public ObjectRarity Rarity { get; private set; }

        [Category("RefObjCommon")]
        public ObjectReqLevelType ReqLevelType1 { get; private set; }

        [Category("RefObjCommon")]
        public byte ReqLevel1 { get; private set; }

        [Category("RefObjCommon")]
        public ObjectReqLevelType ReqLevelType2 { get; private set; }

        [Category("RefObjCommon")]
        public byte ReqLevel2 { get; private set; }

        [Category("RefObjCommon")]
        public ObjectReqLevelType ReqLevelType3 { get; private set; }

        [Category("RefObjCommon")]
        public byte ReqLevel3 { get; private set; }

        [Category("RefObjCommon")]
        public ObjectReqLevelType ReqLevelType4 { get; private set; }

        [Category("RefObjCommon")]
        public byte ReqLevel4 { get; private set; }

        [Category("RefObjCommon")]
        public short Speed1 { get; private set; } //WalkSpeed

        [Category("RefObjCommon")]
        public short Speed2 { get; private set; } //RunSpeed

        [Category("RefObjCommon")]
        public string AssocFileIcon { get; private set; } //Icon

        [Category("RefObjCommon")]
        public Image Icon { get; private set; }

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
            Variance = item.Variance;
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
        }
    }
}