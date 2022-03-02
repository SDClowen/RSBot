using RSBot.Core.Network;

namespace RSBot.Core.Objects.Spawn
{
    public sealed class SpawnedMonster : SpawnedNpc
    {
        /// <summary>
        /// Gets or sets the rarity.
        /// </summary>
        /// <value>
        /// The rarity.
        /// </value>
        public MonsterRarity Rarity { get; set; }

        /// <summary>
        /// Gets the distance to player.
        /// </summary>
        /// <value>
        /// The distance to player.
        /// </value>
        public double DistanceToPlayer => Game.Player.Movement.Source.DistanceTo(Movement.Source);

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="objId">The ref obj id</param>
        public SpawnedMonster(uint objId) :
            base(objId) { }

        /// <summary>
        /// Deserialize from packet
        /// </summary>
        /// <param name="packet">The packet</param>
        internal override void Deserialize(Packet packet)
        {
            ParseBionicDetails(packet);

            base.Deserialize(packet);

            Rarity = (MonsterRarity)packet.ReadByte();

            if (Game.ClientType >= GameClientType.Global)
                packet.ReadUInt();

            if (Record.TypeID4 == 2 || Record.TypeID4 == 3) //NPC_MOB_TIEF, NPC_MOB_HUNTER
                packet.ReadByte(); //Appeareance
        }
    }
}