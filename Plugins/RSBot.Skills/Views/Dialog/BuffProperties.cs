using System.ComponentModel;
using System.Drawing;
using RSBot.Core.Client.ReferenceObjects;
using RSBot.Core.Objects;
using RSBot.Core.Objects.Skill;
using SDUI.Controls;

namespace RSBot.Skills.Views;

public partial class BuffProperties : UIWindowBase
{
    public BuffProperties(SkillInfo skillInfo)
    {
        InitializeComponent();

        propItem.SelectedObject = new BuffDebugInformation(skillInfo);
    }

    public BuffProperties(ItemPerk itemPerk)
    {
        InitializeComponent();

        propItem.SelectedObject = new PerkDebugInformation(itemPerk);
    }

    internal class BuffDebugInformation : SkillDebugInformation
    {
        public BuffDebugInformation(SkillInfo skillInfo)
            : base(skillInfo.Record)
        {
            Id = skillInfo.Id;
            Enabled = skillInfo.Enabled;
            Token = skillInfo.Token;
            HasCooldown = skillInfo.HasCooldown;
            IsPassive = skillInfo.IsPassive;
            IsAttack = skillInfo.IsAttack;
            IsDot = skillInfo.IsDot;
            IsImbue = skillInfo.IsImbue;
            CanBeCasted = skillInfo.CanBeCasted;
        }

        [Category("SkillInfo")]
        public uint Id { get; }

        [Category("SkillInfo")]
        public bool Enabled { get; }

        [Category("SkillInfo")]
        public bool IsPassive { get; }

        [Category("SkillInfo")]
        public bool IsAttack { get; }

        [Category("SkillInfo")]
        public bool IsDot { get; }

        [Category("SkillInfo")]
        public bool IsImbue { get; }

        [Category("SkillInfo")]
        public uint Token { get; }

        [Category("SkillInfo")]
        public bool HasCooldown { get; }

        [Category("SkillInfo")]
        public bool CanBeCasted { get; }
    }

    internal class PerkDebugInformation
    {
        public PerkDebugInformation(ItemPerk perk)
        {
            ItemId = perk.ItemId;
            Token = perk.Token;
            Value = perk.Value;
            RemainingTime = perk.RemainingTime;

            if (perk.Item == null)
                return;

            Tid = perk.Item.Tid;
            IsEquip = perk.Item.IsEquip;
            IsJobEquip = perk.Item.IsJobEquip;
            IsStackable = perk.Item.IsStackable;
            IsTrading = perk.Item.IsTrading;
            IsQuest = perk.Item.IsQuest;
            IsSkillItem = perk.Item.IsSkill;
            Degree = perk.Item.Degree;
            DegreeOffset = perk.Item.DegreeOffset;
            IsGold = perk.Item.IsGold;
            MaxStack = perk.Item.MaxStack;
            ReqGender = perk.Item.ReqGender;
            ReqStr = perk.Item.ReqStr;
            ReqInt = perk.Item.ReqInt;
            ItemClass = perk.Item.ItemClass;
            Quivered = perk.Item.Quivered;
            SpeedClass = perk.Item.SpeedClass;
            TwoHanded = perk.Item.TwoHanded;
            Range = perk.Item.Range;
            Param1 = perk.Item.Param1;
            Param2 = perk.Item.Param2;
            Param3 = perk.Item.Param3;
            Param4 = perk.Item.Param4;
            Desc1 = perk.Item.Desc1;
            Desc2 = perk.Item.Desc2;
            Desc3 = perk.Item.Desc3;
            Desc4 = perk.Item.Desc4;
            TypeID1 = perk.Item.TypeID1;
            TypeID2 = perk.Item.TypeID2;
            TypeID3 = perk.Item.TypeID3;
            TypeID4 = perk.Item.TypeID4;
            Service = perk.Item.Service;
            Id = perk.Item.ID;
            CodeName = perk.Item.CodeName;
            ObjName = perk.Item.ObjName;
            NameStrID = perk.Item.NameStrID;
            CashItem = perk.Item.CashItem;
            Bionic = perk.Item.Bionic;
            Country = perk.Item.Country;
            Rarity = perk.Item.Rarity;
            ReqLevelType1 = perk.Item.ReqLevelType1;
            ReqLevel1 = perk.Item.ReqLevel1;
            ReqLevelType2 = perk.Item.ReqLevelType2;
            ReqLevel2 = perk.Item.ReqLevel2;
            ReqLevelType3 = perk.Item.ReqLevelType3;
            ReqLevel3 = perk.Item.ReqLevel3;
            ReqLevelType4 = perk.Item.ReqLevelType4;
            ReqLevel4 = perk.Item.ReqLevel4;
            Speed1 = perk.Item.Speed1;
            Speed2 = perk.Item.Speed2;
            AssocFileIcon = perk.Item.AssocFileIcon;
            Icon = perk.Item.GetIcon();
        }

        [Category("ItemPerk")]
        public uint ItemId { get; }

        [Category("ItemPerk")]
        public uint Token { get; }

        [Category("ItemPerk")]
        public uint Value { get; }

        [Category("ItemPerk")]
        public uint RemainingTime { get; }

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
        public bool IsEquip { get; }

        [Category("RefObjItem")]
        public bool IsJobEquip { get; }

        [Category("RefObjItem")]
        public bool IsStackable { get; }

        [Category("RefObjItem")]
        public bool IsGold { get; }

        [Category("RefObjItem")]
        public bool IsTrading { get; }

        [Category("RefObjItem")]
        public bool IsQuest { get; }

        [Category("RefObjItem")]
        public bool IsSkillItem { get; }

        [Category("RefObjItem")]
        public int Degree { get; }

        [Category("RefObjItem")]
        public int DegreeOffset { get; }

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
        public int Tid { get; }

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
    }
}
