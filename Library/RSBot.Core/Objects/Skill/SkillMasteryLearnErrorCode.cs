namespace RSBot.Core.Objects.Skill;

public enum SkillMasteryLearnErrorCodes : ushort
{
    /// <summary>
    ///     [Not displayed] You can't learn mastery due to invalid conditions.
    /// </summary>
    UIIT_STT_SKILL_LEARN_MASTERY_INVALID = 0x0138,

    /// <summary>
    ///     You can't learn mastery due to insufficient skill points.
    /// </summary>
    UIIT_STT_SKILL_POINT_INSUFFICIENCY_MASTERY = 0x0238,

    /// <summary>
    ///     Cannot learn it any longer due to mastery limit.
    /// </summary>
    UIIT_STT_SKILL_LEARN_MASTERY_LIMIT = 0x0438,

    /// <summary>
    ///     Cannot learn due to total mastery limit.
    /// </summary>
    UIIT_STT_SKILL_LEARN_MASTERY_TOTAL_LIMIT = 0x0538,
}
