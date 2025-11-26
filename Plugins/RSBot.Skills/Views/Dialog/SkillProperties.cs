using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using RSBot.Core.Client.ReferenceObjects;
using RSBot.Core.Objects;
using SDUI.Controls;

namespace RSBot.Skills.Views;

public partial class SkillProperties : UIWindowBase
{
    #region Constructor

    public SkillProperties(RefSkill skill)
    {
        InitializeComponent();

        Skill = skill;
        Text = $"Skill properties - {Skill.GetRealName()} [Id: {Skill.ID}, GroupId: {Skill.GroupID}]";
        Size = new Size(620, 800);

        try
        {
            var iconImage = Skill.GetIcon();
            var iconBitmap = new Bitmap(iconImage);
            var iconHandle = iconBitmap.GetHicon();

            Icon = Icon.FromHandle(iconHandle);
        }
        catch
        {
            ShowIcon = false;
        }

        propItem.SelectedObject = new SkillDebugInformation(Skill);
    }

    #endregion Constructor

    #region Properties

    public RefSkill Skill { get; }

    #endregion Properties
}

internal class SkillDebugInformation
{
    public SkillDebugInformation(RefSkill skill)
    {
        Service = skill.Service;
        ID = skill.ID;
        GroupID = skill.GroupID;
        Basic_Code = skill.Basic_Code;
        Basic_Name = skill.Basic_Name;
        Basic_Group = skill.Basic_Group;
        Basic_Level = skill.Basic_Level;
        Basic_Activity = skill.Basic_Activity;
        Basic_ChainCode = skill.Basic_ChainCode;
        Action_PrepairingTime = skill.Action_PreparingTime;
        Action_CastingTime = skill.Action_CastingTime;
        Action_ActionDuration = skill.Action_ActionDuration;
        Action_ReuseDelay = skill.Action_ReuseDelay;
        Action_Overlap = skill.Action_Overlap;
        Action_AutoAttackType = skill.Action_AutoAttackType;
        Action_Range = skill.Action_Range;
        Target_Required = skill.Target_Required;
        TargetType_Animal = skill.TargetType_Animal;
        TargetGroup_Self = skill.TargetGroup_Self;
        TargetGroup_Ally = skill.TargetGroup_Ally;
        TargetGroup_Party = skill.TargetGroup_Party;
        TargetGroup_Enemy_M = skill.TargetGroup_Enemy_M;
        TargetGroup_Enemy_P = skill.TargetGroup_Enemy_P;
        TargetEtc_SelectDeadBody = skill.TargetEtc_SelectDeadBody;
        ReqCommon_Mastery1 = skill.ReqCommon_Mastery1;
        ReqCommon_Mastery2 = skill.ReqCommon_Mastery2;
        ReqCommon_MasteryLevel1 = skill.ReqCommon_MasteryLevel1;
        ReqCommon_MasteryLevel2 = skill.ReqCommon_MasteryLevel2;
        ReqCast_Weapon1 = skill.ReqCast_Weapon1;
        ReqCast_Weapon2 = skill.ReqCast_Weapon2;
        Consume_MP = skill.Consume_MP;
        UI_IconFile = skill.UI_IconFile;
        UI_SkillName = skill.UI_SkillName;
        Params = skill.Params;
    }

    [Category("RefSkill")]
    public uint ID { get; }

    [Category("RefSkill")]
    public byte Service { get; }

    [Category("RefSkill")]
    public int GroupID { get; }

    [Category("RefSkill")]
    public string Basic_Code { get; }

    [Category("RefSkill")]
    public string Basic_Name { get; }

    [Category("RefSkill")]
    public string Basic_Group { get; }

    [Category("RefSkill")]
    public byte Basic_Level { get; }

    [Category("RefSkill")]
    public byte Basic_Activity { get; }

    [Category("RefSkill")]
    public uint Basic_ChainCode { get; }

    [Category("RefSkill")]
    public int Action_PrepairingTime { get; }

    [Category("RefSkill")]
    public int Action_CastingTime { get; }

    [Category("RefSkill")]
    public int Action_ActionDuration { get; }

    [Category("RefSkill")]
    public int Action_ReuseDelay { get; }

    [Category("RefSkill")]
    public int Action_Overlap { get; }

    [Category("RefSkill")]
    public int Action_AutoAttackType { get; }

    [Category("RefSkill")]
    public short Action_Range { get; }

    [Category("RefSkill")]
    public bool Target_Required { get; }

    [Category("RefSkill")]
    public bool TargetType_Animal { get; }

    [Category("RefSkill")]
    public bool TargetGroup_Self { get; }

    [Category("RefSkill")]
    public bool TargetGroup_Ally { get; }

    [Category("RefSkill")]
    public bool TargetGroup_Party { get; }

    [Category("RefSkill")]
    public bool TargetGroup_Enemy_M { get; }

    [Category("RefSkill")]
    public bool TargetGroup_Enemy_P { get; }

    [Category("RefSkill")]
    public bool TargetEtc_SelectDeadBody { get; }

    [Category("RefSkill")]
    public int ReqCommon_Mastery1 { get; }

    [Category("RefSkill")]
    public int ReqCommon_Mastery2 { get; }

    [Category("RefSkill")]
    public int ReqCommon_MasteryLevel1 { get; }

    [Category("RefSkill")]
    public int ReqCommon_MasteryLevel2 { get; }

    [Category("RefSkill")]
    public WeaponType ReqCast_Weapon1 { get; }

    [Category("RefSkill")]
    public WeaponType ReqCast_Weapon2 { get; }

    [Category("RefSkill")]
    public short Consume_MP { get; }

    [Category("RefSkill")]
    public string UI_IconFile { get; }

    [Category("RefSkill")]
    public string UI_SkillName { get; }

    [Category("RefSkill")]
    public List<int> Params { get; }
}
