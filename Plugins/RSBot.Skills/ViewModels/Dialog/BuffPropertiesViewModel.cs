using System.Collections.ObjectModel;
using ReactiveUI;
using RSBot.Core.Objects;
using RSBot.Core.Objects.Skill;

namespace RSBot.Skills.ViewModels.Dialog;

/// <summary>
/// View model for the buff properties dialog
/// </summary>
public class BuffPropertiesViewModel : ReactiveObject
{
    private string _windowTitle;

    /// <summary>
    /// Gets the window title
    /// </summary>
    public string WindowTitle
    {
        get => _windowTitle;
        private set => this.RaiseAndSetIfChanged(ref _windowTitle, value);
    }

    /// <summary>
    /// Gets the collection of properties to display
    /// </summary>
    public ObservableCollection<PropertyItem> Properties { get; } = new();

    /// <summary>
    /// Initializes a new instance of the <see cref="BuffPropertiesViewModel"/> class for a skill buff
    /// </summary>
    /// <param name="skillInfo">The skill buff to display properties for</param>
    public BuffPropertiesViewModel(SkillInfo skillInfo)
    {
        WindowTitle = $"Buff properties - {skillInfo.Record.GetRealName()} [Id: {skillInfo.Id}, Token: {skillInfo.Token}]";

        // Skill Info properties
        Properties.Add(new PropertyItem("SkillInfo", "Id", skillInfo.Id.ToString()));
        Properties.Add(new PropertyItem("SkillInfo", "Enabled", skillInfo.Enabled.ToString()));
        Properties.Add(new PropertyItem("SkillInfo", "IsPassive", skillInfo.IsPassive.ToString()));
        Properties.Add(new PropertyItem("SkillInfo", "IsAttack", skillInfo.IsAttack.ToString()));
        Properties.Add(new PropertyItem("SkillInfo", "IsDot", skillInfo.IsDot.ToString()));
        Properties.Add(new PropertyItem("SkillInfo", "IsImbue", skillInfo.IsImbue.ToString()));
        Properties.Add(new PropertyItem("SkillInfo", "Token", skillInfo.Token.ToString()));
        Properties.Add(new PropertyItem("SkillInfo", "HasCooldown", skillInfo.HasCooldown.ToString()));
        Properties.Add(new PropertyItem("SkillInfo", "CanBeCasted", skillInfo.CanBeCasted.ToString()));

        // RefSkill properties
        var skill = skillInfo.Record;
        Properties.Add(new PropertyItem("RefSkill", "Service", skill.Service.ToString()));
        Properties.Add(new PropertyItem("RefSkill", "ID", skill.ID.ToString()));
        Properties.Add(new PropertyItem("RefSkill", "GroupID", skill.GroupID.ToString()));
        Properties.Add(new PropertyItem("RefSkill", "Basic_Code", skill.Basic_Code));
        Properties.Add(new PropertyItem("RefSkill", "Basic_Name", skill.Basic_Name));
        Properties.Add(new PropertyItem("RefSkill", "Basic_Group", skill.Basic_Group));
        Properties.Add(new PropertyItem("RefSkill", "Basic_Level", skill.Basic_Level.ToString()));
        Properties.Add(new PropertyItem("RefSkill", "Basic_Activity", skill.Basic_Activity.ToString()));
        Properties.Add(new PropertyItem("RefSkill", "Basic_ChainCode", skill.Basic_ChainCode.ToString()));
        Properties.Add(new PropertyItem("RefSkill", "Action_PrepairingTime", skill.Action_PreparingTime.ToString()));
        Properties.Add(new PropertyItem("RefSkill", "Action_CastingTime", skill.Action_CastingTime.ToString()));
        Properties.Add(new PropertyItem("RefSkill", "Action_ActionDuration", skill.Action_ActionDuration.ToString()));
        Properties.Add(new PropertyItem("RefSkill", "Action_ReuseDelay", skill.Action_ReuseDelay.ToString()));
        Properties.Add(new PropertyItem("RefSkill", "Action_Overlap", skill.Action_Overlap.ToString()));
        Properties.Add(new PropertyItem("RefSkill", "Action_AutoAttackType", skill.Action_AutoAttackType.ToString()));
        Properties.Add(new PropertyItem("RefSkill", "Action_Range", skill.Action_Range.ToString()));
        Properties.Add(new PropertyItem("RefSkill", "Target_Required", skill.Target_Required.ToString()));
        Properties.Add(new PropertyItem("RefSkill", "TargetType_Animal", skill.TargetType_Animal.ToString()));
        Properties.Add(new PropertyItem("RefSkill", "TargetGroup_Self", skill.TargetGroup_Self.ToString()));
        Properties.Add(new PropertyItem("RefSkill", "TargetGroup_Ally", skill.TargetGroup_Ally.ToString()));
        Properties.Add(new PropertyItem("RefSkill", "TargetGroup_Party", skill.TargetGroup_Party.ToString()));
        Properties.Add(new PropertyItem("RefSkill", "TargetGroup_Enemy_M", skill.TargetGroup_Enemy_M.ToString()));
        Properties.Add(new PropertyItem("RefSkill", "TargetGroup_Enemy_P", skill.TargetGroup_Enemy_P.ToString()));
        Properties.Add(new PropertyItem("RefSkill", "TargetEtc_SelectDeadBody", skill.TargetEtc_SelectDeadBody.ToString()));
        Properties.Add(new PropertyItem("RefSkill", "ReqCommon_Mastery1", skill.ReqCommon_Mastery1.ToString()));
        Properties.Add(new PropertyItem("RefSkill", "ReqCommon_Mastery2", skill.ReqCommon_Mastery2.ToString()));
        Properties.Add(new PropertyItem("RefSkill", "ReqCommon_MasteryLevel1", skill.ReqCommon_MasteryLevel1.ToString()));
        Properties.Add(new PropertyItem("RefSkill", "ReqCommon_MasteryLevel2", skill.ReqCommon_MasteryLevel2.ToString()));
        Properties.Add(new PropertyItem("RefSkill", "ReqCast_Weapon1", skill.ReqCast_Weapon1.ToString()));
        Properties.Add(new PropertyItem("RefSkill", "ReqCast_Weapon2", skill.ReqCast_Weapon2.ToString()));
        Properties.Add(new PropertyItem("RefSkill", "Consume_MP", skill.Consume_MP.ToString()));
        Properties.Add(new PropertyItem("RefSkill", "UI_IconFile", skill.UI_IconFile));
        Properties.Add(new PropertyItem("RefSkill", "UI_SkillName", skill.UI_SkillName));
        Properties.Add(new PropertyItem("RefSkill", "Params", string.Join(", ", skill.Params)));
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="BuffPropertiesViewModel"/> class for an item perk
    /// </summary>
    /// <param name="itemPerk">The item perk to display properties for</param>
    public BuffPropertiesViewModel(ItemPerk itemPerk)
    {
        WindowTitle = $"Item Perk properties - {itemPerk.Item?.GetRealName()} [Id: {itemPerk.ItemId}, Token: {itemPerk.Token}]";

        // ItemPerk properties
        Properties.Add(new PropertyItem("ItemPerk", "ItemId", itemPerk.ItemId.ToString()));
        Properties.Add(new PropertyItem("ItemPerk", "Token", itemPerk.Token.ToString()));
        Properties.Add(new PropertyItem("ItemPerk", "Value", itemPerk.Value.ToString()));
        Properties.Add(new PropertyItem("ItemPerk", "RemainingTime", itemPerk.RemainingTime.ToString()));

        if (itemPerk.Item == null)
            return;

        // RefObjItem properties
        Properties.Add(new PropertyItem("RefObjItem", "MaxStack", itemPerk.Item.MaxStack.ToString()));
        Properties.Add(new PropertyItem("RefObjItem", "ReqGender", itemPerk.Item.ReqGender.ToString()));
        Properties.Add(new PropertyItem("RefObjItem", "ReqStr", itemPerk.Item.ReqStr.ToString()));
        Properties.Add(new PropertyItem("RefObjItem", "ReqInt", itemPerk.Item.ReqInt.ToString()));
        Properties.Add(new PropertyItem("RefObjItem", "ItemClass", itemPerk.Item.ItemClass.ToString()));
        Properties.Add(new PropertyItem("RefObjItem", "Quivered", itemPerk.Item.Quivered.ToString()));
        Properties.Add(new PropertyItem("RefObjItem", "SpeedClass", itemPerk.Item.SpeedClass.ToString()));
        Properties.Add(new PropertyItem("RefObjItem", "TwoHanded", itemPerk.Item.TwoHanded.ToString()));
        Properties.Add(new PropertyItem("RefObjItem", "Range", itemPerk.Item.Range.ToString()));
        Properties.Add(new PropertyItem("RefObjItem", "Param1", itemPerk.Item.Param1.ToString()));
        Properties.Add(new PropertyItem("RefObjItem", "Param2", itemPerk.Item.Param2.ToString()));
        Properties.Add(new PropertyItem("RefObjItem", "Param3", itemPerk.Item.Param3.ToString()));
        Properties.Add(new PropertyItem("RefObjItem", "Param4", itemPerk.Item.Param4.ToString()));
        Properties.Add(new PropertyItem("RefObjItem", "Desc1", itemPerk.Item.Desc1));
        Properties.Add(new PropertyItem("RefObjItem", "Desc2", itemPerk.Item.Desc2));
        Properties.Add(new PropertyItem("RefObjItem", "Desc3", itemPerk.Item.Desc3));
        Properties.Add(new PropertyItem("RefObjItem", "Desc4", itemPerk.Item.Desc4));
        Properties.Add(new PropertyItem("RefObjItem", "IsEquip", itemPerk.Item.IsEquip.ToString()));
        Properties.Add(new PropertyItem("RefObjItem", "IsJobEquip", itemPerk.Item.IsJobEquip.ToString()));
        Properties.Add(new PropertyItem("RefObjItem", "IsStackable", itemPerk.Item.IsStackable.ToString()));
        Properties.Add(new PropertyItem("RefObjItem", "IsGold", itemPerk.Item.IsGold.ToString()));
        Properties.Add(new PropertyItem("RefObjItem", "IsTrading", itemPerk.Item.IsTrading.ToString()));
        Properties.Add(new PropertyItem("RefObjItem", "IsQuest", itemPerk.Item.IsQuest.ToString()));
        Properties.Add(new PropertyItem("RefObjItem", "IsSkillItem", itemPerk.Item.IsSkill.ToString()));
        Properties.Add(new PropertyItem("RefObjItem", "Degree", itemPerk.Item.Degree.ToString()));
        Properties.Add(new PropertyItem("RefObjItem", "DegreeOffset", itemPerk.Item.DegreeOffset.ToString()));

        // RefObjCommon properties
        Properties.Add(new PropertyItem("RefObjCommon", "TypeID1", itemPerk.Item.TypeID1.ToString()));
        Properties.Add(new PropertyItem("RefObjCommon", "TypeID2", itemPerk.Item.TypeID2.ToString()));
        Properties.Add(new PropertyItem("RefObjCommon", "TypeID3", itemPerk.Item.TypeID3.ToString()));
        Properties.Add(new PropertyItem("RefObjCommon", "TypeID4", itemPerk.Item.TypeID4.ToString()));
        Properties.Add(new PropertyItem("RefObjCommon", "Service", itemPerk.Item.Service.ToString()));
        Properties.Add(new PropertyItem("RefObjCommon", "Id", itemPerk.Item.ID.ToString()));
        Properties.Add(new PropertyItem("RefObjCommon", "CodeName", itemPerk.Item.CodeName));
        Properties.Add(new PropertyItem("RefObjCommon", "ObjName", itemPerk.Item.ObjName));
        Properties.Add(new PropertyItem("RefObjCommon", "NameStrID", itemPerk.Item.NameStrID));
        Properties.Add(new PropertyItem("RefObjCommon", "CashItem", itemPerk.Item.CashItem.ToString()));
        Properties.Add(new PropertyItem("RefObjCommon", "Bionic", itemPerk.Item.Bionic.ToString()));
        Properties.Add(new PropertyItem("RefObjCommon", "Tid", itemPerk.Item.Tid.ToString()));
        Properties.Add(new PropertyItem("RefObjCommon", "Country", itemPerk.Item.Country.ToString()));
        Properties.Add(new PropertyItem("RefObjCommon", "Rarity", itemPerk.Item.Rarity.ToString()));
        Properties.Add(new PropertyItem("RefObjCommon", "ReqLevelType1", itemPerk.Item.ReqLevelType1.ToString()));
        Properties.Add(new PropertyItem("RefObjCommon", "ReqLevel1", itemPerk.Item.ReqLevel1.ToString()));
        Properties.Add(new PropertyItem("RefObjCommon", "ReqLevelType2", itemPerk.Item.ReqLevelType2.ToString()));
        Properties.Add(new PropertyItem("RefObjCommon", "ReqLevel2", itemPerk.Item.ReqLevel2.ToString()));
        Properties.Add(new PropertyItem("RefObjCommon", "ReqLevelType3", itemPerk.Item.ReqLevelType3.ToString()));
        Properties.Add(new PropertyItem("RefObjCommon", "ReqLevel3", itemPerk.Item.ReqLevel3.ToString()));
        Properties.Add(new PropertyItem("RefObjCommon", "ReqLevelType4", itemPerk.Item.ReqLevelType4.ToString()));
        Properties.Add(new PropertyItem("RefObjCommon", "ReqLevel4", itemPerk.Item.ReqLevel4.ToString()));
        Properties.Add(new PropertyItem("RefObjCommon", "Speed1", itemPerk.Item.Speed1.ToString()));
        Properties.Add(new PropertyItem("RefObjCommon", "Speed2", itemPerk.Item.Speed2.ToString()));
        Properties.Add(new PropertyItem("RefObjCommon", "AssocFileIcon", itemPerk.Item.AssocFileIcon));
    }


    /// <summary>
    /// Represents a property item in the properties list
    /// </summary>
    public class PropertyItem
    {
        /// <summary>
        /// Gets the category of the property
        /// </summary>
        public string Category { get; }

        /// <summary>
        /// Gets the name of the property
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the value of the property
        /// </summary>
        public string Value { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PropertyItem"/> class
        /// </summary>
        /// <param name="category">The category of the property</param>
        /// <param name="name">The name of the property</param>
        /// <param name="value">The value of the property</param>
        public PropertyItem(string category, string name, string value)
        {
            Category = category;
            Name = name;
            Value = value;
        }
    }
}
