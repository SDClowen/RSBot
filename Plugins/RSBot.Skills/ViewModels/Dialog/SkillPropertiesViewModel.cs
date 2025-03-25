using System.Collections.ObjectModel;
using ReactiveUI;
using RSBot.Core.Client.ReferenceObjects;

namespace RSBot.Skills.ViewModels.Dialog;

/// <summary>
/// View model for the skill properties dialog
/// </summary>
public class SkillPropertiesViewModel : ReactiveObject
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
    /// Initializes a new instance of the <see cref="SkillPropertiesViewModel"/> class
    /// </summary>
    /// <param name="skill">The skill to display properties for</param>
    public SkillPropertiesViewModel(RefSkill skill)
    {
        WindowTitle = $"Skill properties - {skill.GetRealName()} [Id: {skill.ID}, GroupId: {skill.GroupID}]";

        Properties.Add(new PropertyItem("Service", skill.Service.ToString()));
        Properties.Add(new PropertyItem("ID", skill.ID.ToString()));
        Properties.Add(new PropertyItem("GroupID", skill.GroupID.ToString()));
        Properties.Add(new PropertyItem("Basic_Code", skill.Basic_Code));
        Properties.Add(new PropertyItem("Basic_Name", skill.Basic_Name));
        Properties.Add(new PropertyItem("Basic_Group", skill.Basic_Group));
        Properties.Add(new PropertyItem("Basic_Level", skill.Basic_Level.ToString()));
        Properties.Add(new PropertyItem("Basic_Activity", skill.Basic_Activity.ToString()));
        Properties.Add(new PropertyItem("Basic_ChainCode", skill.Basic_ChainCode.ToString()));
        Properties.Add(new PropertyItem("Action_PrepairingTime", skill.Action_PreparingTime.ToString()));
        Properties.Add(new PropertyItem("Action_CastingTime", skill.Action_CastingTime.ToString()));
        Properties.Add(new PropertyItem("Action_ActionDuration", skill.Action_ActionDuration.ToString()));
        Properties.Add(new PropertyItem("Action_ReuseDelay", skill.Action_ReuseDelay.ToString()));
        Properties.Add(new PropertyItem("Action_Overlap", skill.Action_Overlap.ToString()));
        Properties.Add(new PropertyItem("Action_AutoAttackType", skill.Action_AutoAttackType.ToString()));
        Properties.Add(new PropertyItem("Action_Range", skill.Action_Range.ToString()));
        Properties.Add(new PropertyItem("Target_Required", skill.Target_Required.ToString()));
        Properties.Add(new PropertyItem("TargetType_Animal", skill.TargetType_Animal.ToString()));
        Properties.Add(new PropertyItem("TargetGroup_Self", skill.TargetGroup_Self.ToString()));
        Properties.Add(new PropertyItem("TargetGroup_Ally", skill.TargetGroup_Ally.ToString()));
        Properties.Add(new PropertyItem("TargetGroup_Party", skill.TargetGroup_Party.ToString()));
        Properties.Add(new PropertyItem("TargetGroup_Enemy_M", skill.TargetGroup_Enemy_M.ToString()));
        Properties.Add(new PropertyItem("TargetGroup_Enemy_P", skill.TargetGroup_Enemy_P.ToString()));
        Properties.Add(new PropertyItem("TargetEtc_SelectDeadBody", skill.TargetEtc_SelectDeadBody.ToString()));
        Properties.Add(new PropertyItem("ReqCommon_Mastery1", skill.ReqCommon_Mastery1.ToString()));
        Properties.Add(new PropertyItem("ReqCommon_Mastery2", skill.ReqCommon_Mastery2.ToString()));
        Properties.Add(new PropertyItem("ReqCommon_MasteryLevel1", skill.ReqCommon_MasteryLevel1.ToString()));
        Properties.Add(new PropertyItem("ReqCommon_MasteryLevel2", skill.ReqCommon_MasteryLevel2.ToString()));
        Properties.Add(new PropertyItem("ReqCast_Weapon1", skill.ReqCast_Weapon1.ToString()));
        Properties.Add(new PropertyItem("ReqCast_Weapon2", skill.ReqCast_Weapon2.ToString()));
        Properties.Add(new PropertyItem("Consume_MP", skill.Consume_MP.ToString()));
        Properties.Add(new PropertyItem("UI_IconFile", skill.UI_IconFile));
        Properties.Add(new PropertyItem("UI_SkillName", skill.UI_SkillName));
        Properties.Add(new PropertyItem("Params", string.Join(", ", skill.Params)));
    }


    /// <summary>
    /// Represents a property item in the properties list
    /// </summary>
    public class PropertyItem
    {
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
        /// <param name="name">The name of the property</param>
        /// <param name="value">The value of the property</param>
        public PropertyItem(string name, string value)
        {
            Name = name;
            Value = value;
        }
    }
}
