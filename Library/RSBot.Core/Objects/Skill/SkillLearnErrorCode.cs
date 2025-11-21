namespace RSBot.Core.Objects.Skill;

public enum SkillLearnErrorCode : ushort
{
    /// <summary>
    ///     Cannot learn the skill due to insufficient strength.
    /// </summary>
    UIIT_STT_SKILL_LEARN_STR_INSUFFICIENCY = 0x0334,

    /// <summary>
    ///     [Not displayed]
    /// </summary>
    UIIT_STT_SKILL_LEARN_ALREADY_EXISTS = 0x0634,

    /// <summary>
    ///     Cannot learn the skill due to insufficient intelligence.
    /// </summary>
    UIIT_STT_SKILL_LEARN_INT_INSUFFICIENCY = 0x0434,

    /// <summary>
    ///     You can't learn the current skill due to insufficient skill points.
    /// </summary>
    UIIT_STT_SKILL_POINT_INSUFFICIENCY = 0x0A34,
}
