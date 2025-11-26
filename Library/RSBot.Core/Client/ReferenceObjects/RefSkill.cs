using System.Collections.Generic;
using System.Drawing;
using RSBot.Core.Extensions;
using RSBot.Core.Objects;

namespace RSBot.Core.Client.ReferenceObjects;

public class RefSkill : IReference<uint>
{
    private const int PARAM_COUNT = 50;

    private const int EFFECT_TRANSFER = 1701213281; //efta
    private const int DURATION = 1685418593; //dura

    /// <summary>
    ///     Gets the ingame name of the spell
    /// </summary>
    /// <returns></returns>
    public string GetRealName()
    {
        return Game.ReferenceManager.GetTranslation(UI_SkillName);
    }

    /// <summary>
    ///     Gets the icon.
    /// </summary>
    /// <returns></returns>
    public Image GetIcon()
    {
        Image bitmap = null;

        try
        {
            var path = $"icon\\{UI_IconFile}";
            if (!Game.MediaPk2.TryGetFile(path, out var file))
                bitmap = Game.MediaPk2.GetFile("icon\\icon_default.ddj").ToImage();

            bitmap = file.ToImage();
        }
        catch { }
        finally
        {
            if (bitmap == null)
                bitmap = new Bitmap(24, 24);
        }

        return bitmap;
    }

    public override string ToString()
    {
        return $"{GetRealName()} lv.{Basic_Level}";
    }

    #region Fields

    public byte Service;
    public uint ID;
    public int GroupID;
    public string Basic_Code;
    public string Basic_Name;
    public string Basic_Group;
    public int Basic_Original;
    public byte Basic_Level;
    public byte Basic_Activity;

    public uint Basic_ChainCode;

    //public int Basic_RecycleCost;
    public int Action_PreparingTime;
    public int Action_CastingTime;

    public int Action_ActionDuration;
    public int Action_ReuseDelay;

    //public int Action_CoolTime;
    //public int Action_FlyingSpeed;
    //public byte Action_Interruptable;
    public int Action_Overlap;

    public int Action_AutoAttackType;

    //public int Action_InTown;
    public short Action_Range;
    public bool Target_Required;

    public bool TargetType_Animal;

    //public bool TargetType_Land;
    //public bool TargetType_Building;
    public bool TargetGroup_Self;
    public bool TargetGroup_Ally;
    public bool TargetGroup_Party;
    public bool TargetGroup_Enemy_M;

    public bool TargetGroup_Enemy_P;

    //public bool TargetGroup_Neutral;
    //public bool TargetGroup_DontCare;
    public bool TargetEtc_SelectDeadBody;
    public int ReqCommon_Mastery1;
    public int ReqCommon_Mastery2;
    public byte ReqCommon_MasteryLevel1;

    public byte ReqCommon_MasteryLevel2;

    //public short ReqCommon_Str;
    //public short ReqCommon_Int;

    //public int ReqLearn_Skill1;
    //public int ReqLearn_Skill2;
    //public int ReqLearn_Skill3;
    //public byte ReqLearn_SkillLevel1;
    //public byte ReqLearn_SkillLevel2;
    //public byte ReqLearn_SkillLevel3;
    //public int ReqLearn_SP;

    public byte ReqLearn_Race;

    //public byte Req_Restriction1;
    //public byte Req_Restriction2;
    public WeaponType ReqCast_Weapon1;
    public WeaponType ReqCast_Weapon2;

    //public short Consume_HP;
    public short Consume_MP;

    //public short Consume_HPRatio;
    //public short Consume_MPRatio;
    //public byte Consume_HWAN;
    //public byte UI_SkillTab;
    //public byte UI_SkillPage;
    //public byte UI_SkillColumn;
    //public byte UI_SkillRow;
    public string UI_IconFile;

    public string UI_SkillName;

    //public string UI_SkillToolTip;
    //public string UI_SkillToolTip_Desc;
    //public string UI_SkillStudy_Desc;
    //public short AI_AttackChance;
    //public byte AI_SkillType;
    public List<int> Params = new(50);

    public PrimarySkillParam Type => (PrimarySkillParam)Params[0];

    #endregion Fields

    #region IReference

    public uint PrimaryKey => ID;

    public bool Load(ReferenceParser parser)
    {
        //Skip disabled
        if (!parser.TryParse(0, out Service) || Service == 0)
            return false;

        //Skip invalid ID (PK)
        if (!parser.TryParse(1, out ID))
            return false;

        //Skip invalid group (MSKILL, HSKILL, TSKILL, GSKILL, PSKILL, P2SKILL) to save memory
        if (
            !parser.TryParse(2, out GroupID) /*|| GroupID == 0*/
        )
            return false;

        parser.TryParse(3, out Basic_Code);
        //parser.TryParseString(4, out Basic_Name);
        parser.TryParse(5, out Basic_Group);
        //parser.TryParseInt(6, out Basic_Original);
        parser.TryParse(7, out Basic_Level);
        parser.TryParse(8, out Basic_Activity);
        parser.TryParse(9, out Basic_ChainCode);
        //Basic_RecycleCost = int.Parse(data[10]);

        parser.TryParse(11, out Action_PreparingTime);
        parser.TryParse(12, out Action_CastingTime);
        parser.TryParse(13, out Action_ActionDuration);
        parser.TryParse(14, out Action_ReuseDelay);
        //Action_CoolTime = int.Parse(data[15]);
        //Action_FlyingSpeed = int.Parse(data[16]);
        //Action_Interruptable = byte.Parse(data[17]);
        parser.TryParse(18, out Action_Overlap);
        parser.TryParse(19, out Action_AutoAttackType);
        //Action_InTown = int.Parse(data[20]);
        parser.TryParse(21, out Action_Range);
        parser.TryParse(22, out Target_Required);
        parser.TryParse(23, out TargetType_Animal);
        //parser.TryParseBool(24, out TargetType_Land);
        //parser.TryParseBool(25, out TargetType_Building);
        parser.TryParse(26, out TargetGroup_Self);
        parser.TryParse(27, out TargetGroup_Ally);
        parser.TryParse(28, out TargetGroup_Party);
        parser.TryParse(29, out TargetGroup_Enemy_M);
        parser.TryParse(30, out TargetGroup_Enemy_P);
        //parser.TryParseBool(31, out TargetGroup_Neutral);
        //parser.TryParseBool(32, out TargetGroup_DontCare);
        parser.TryParse(33, out TargetEtc_SelectDeadBody);

        parser.TryParse(34, out ReqCommon_Mastery1);
        parser.TryParse(35, out ReqCommon_Mastery2);

        parser.TryParse(36, out ReqCommon_MasteryLevel1);
        parser.TryParse(37, out ReqCommon_MasteryLevel2);

        //parser.TryParseShort(38, out ReqCommon_Str);
        //parser.TryParseShort(39, out ReqCommon_Int);
        //ReqLearn_Skill1 = int.Parse(data[40]);
        //ReqLearn_Skill2 = int.Parse(data[41]);
        //ReqLearn_Skill3 = int.Parse(data[42]);
        //ReqLearn_SkillLevel1 = byte.Parse(data[43]);
        //ReqLearn_SkillLevel2 = byte.Parse(data[44]);
        //ReqLearn_SkillLevel3 = byte.Parse(data[45]);
        //parser.TryParseInt(46, out ReqLearn_SP);
        parser.TryParse(47, out ReqLearn_Race);
        //Req_Restriction1 = byte.Parse(data[48]);
        //Req_Restriction2 = byte.Parse(data[49]);
        parser.TryParse(50, out ReqCast_Weapon1);
        parser.TryParse(51, out ReqCast_Weapon2);

        //Consume_HP = short.Parse(data[52]);
        parser.TryParse(53, out Consume_MP);
        //Consume_HPRatio = short.Parse(data[54]);
        //Consume_MPRatio = short.Parse(data[55]);
        //Consume_HWAN = byte.Parse(data[56]);

        //UI_SkillTab = byte.Parse(data[57]);
        //UI_SkillPage = byte.Parse(data[58]);
        //UI_SkillColumn = byte.Parse(data[59]);
        //UI_SkillRow = byte.Parse(data[60]);

        parser.TryParse(61, out UI_IconFile);
        parser.TryParse(62, out UI_SkillName);
        //UI_SkillToolTip = data[63];
        //UI_SkillToolTip_Desc = data[64];
        //UI_SkillStudy_Desc = data[65];

        //AI_AttackChance = short.Parse(data[66]);
        //AI_SkillType = byte.Parse(data[67]);
        for (var i = 0; i < PARAM_COUNT; i++)
            if (parser.TryParse(68 + i, out int paramValue))
                Params.Add(paramValue);

        return true;
    }

    #endregion IReference
}

//Params:
//6386804 = att
//  Param1: Type
//          Types:
//             5 = Phy. atk. pwr.
//             6 =
//  Param2: Physical percentage
//  Param3: Min
//  Param4: Max
//  Param5: Magical percentage?

//1734702198 = getv -> "getVariable"
//  Param1: Name

//1936028790 = setv -> "setVariable"
//  Param1: Name
//  Param2: Value
//  Param3: Value2

//Variables:
//1296122196 = MAAT -> ""
//1160860481 = E1SA -> ""
//1380992085 = RPDU -> "Rouge poison damage up"
//1380996181 = RPTU -> "Rouge poison time up
//to be continued...
