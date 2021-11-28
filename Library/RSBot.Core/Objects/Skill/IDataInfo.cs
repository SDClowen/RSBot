using RSBot.Core.Client.ReferenceObjects;

namespace RSBot.Core.Objects.Skill
{
    public interface ISkillDataInfo
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        uint Id { get; set; }

        /// <summary>
        /// Gets the record.
        /// </summary>
        RefSkill Record { get; }
    }
}
