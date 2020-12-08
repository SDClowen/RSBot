using RSBot.Core.Client.ReferenceObjects;

namespace RSBot.Core.Objects.Skill
{
    public class BuffInfo
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public uint Id { get; set; }

        /// <summary>
        /// Gets or sets the duration.
        /// </summary>
        /// <value>
        /// The duration.
        /// </value>
        public uint Duration { get; set; }

        /// <summary>
        /// Gets the record.
        /// </summary>
        /// <value>
        /// The record.
        /// </value>
        public RefSkill Record => Game.ReferenceManager.GetRefSkill(Id);

        /// <summary>
        /// Gets or sets the token.
        /// </summary>
        /// <value>
        /// The token.
        /// </value>
        public uint Token { get; set; }
    }
}