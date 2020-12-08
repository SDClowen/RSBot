using RSBot.Core.Client.ReferenceObjects;
using RSBot.Core.Network;

namespace RSBot.Core.Objects.Spawn
{
    public class SpawnedSpellArea
    {
        /// <summary>
        /// The UniqueId
        /// </summary>
        public uint CasterUniqueId;

        /// <summary>
        /// Gets or sets the skill identifier.
        /// </summary>
        public uint SkillId;

        /// <summary>
        /// Gets or sets the record.
        /// </summary>
        /// <value>
        /// The record.
        /// </value>
        public RefSkill Record => Game.ReferenceManager.GetRefSkill(SkillId);

        /// <summary>
        /// The position
        /// </summary>
        public Position Position;

        /// <summary>
        /// Froms the packet.
        /// </summary>
        /// <param name="packet">The packet.</param>
        /// <returns></returns>
        internal static SpawnedSpellArea FromPacket(Packet packet)
        {
            packet.ReadUShort(); //UNK0
            var spellArea = new SpawnedSpellArea
            {
                SkillId = packet.ReadUInt(),
                CasterUniqueId = packet.ReadUInt(),
                Position = Position.FromPacket(packet)
            };
            return spellArea;
        }
    }
}