using RSBot.Core.Network;

namespace RSBot.Core.Objects.Spawn
{
    public class SpawnedMonster
    {
        /// <summary>
        /// Gets or sets the rarity.
        /// </summary>
        /// <value>
        /// The rarity.
        /// </value>
        public MonsterRarity Rarity { get; set; }

        /// <summary>
        /// Gets or sets the character.
        /// </summary>
        /// <value>
        /// The character.
        /// </value>
        public SpawnedNpc Character { get; set; }

        /// <summary>
        /// Gets the distance to player.
        /// </summary>
        /// <value>
        /// The distance to player.
        /// </value>
        public double DistanceToPlayer =>
            (Character.Bionic == null) ? 999 :
            Game.Player.Tracker.Position.DistanceTo(Character.Bionic.Tracker.Position);

        /// <summary>
        /// Froms the packet.
        /// </summary>
        /// <param name="packet">The packet.</param>
        /// <param name="character">The character.</param>
        /// <returns></returns>
        internal static SpawnedMonster FromPacket(Packet packet, SpawnedNpc character)
        {
            var result = new SpawnedMonster
            {
                Character = character,
                Rarity = (MonsterRarity)packet.ReadByte()
            };

            if (character.Bionic.Record.TypeID4 == 2 || character.Bionic.Record.TypeID4 == 3) //NPC_MOB_TIEF, NPC_MOB_HUNTER
                packet.ReadByte(); //Appeareance

            return result;
        }
    }
}