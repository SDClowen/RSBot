using RSBot.Core.Network;

namespace RSBot.Core.Objects.Spawn;

public sealed class SpawnedMonster : SpawnedNpc
{
    /// <summary>
    ///     <inheritdoc />
    /// </summary>
    /// <param name="objId">The ref obj id</param>
    public SpawnedMonster(uint objId)
        : base(objId) { }

    /// <summary>
    ///     Gets or sets the rarity.
    /// </summary>
    /// <value>
    ///     The rarity.
    /// </value>
    public MonsterRarity Rarity { get; set; }

    /// <summary>
    ///     Gets the maximum health.
    /// </summary>
    /// <value>
    ///     The maximum health.
    /// </value>
    public int MaxHealth
    {
        get
        {
            var baseHealth = Record.MaxHealth;
            switch (Rarity)
            {
                case MonsterRarity.Champion:
                    return baseHealth * 2;

                case MonsterRarity.ChampionParty:
                    return baseHealth * 20;

                case MonsterRarity.GeneralParty:
                    return baseHealth * 10;

                case MonsterRarity.Elite:
                    return baseHealth * 30;

                case MonsterRarity.EliteParty:
                    return baseHealth * 300;

                case MonsterRarity.Giant:
                    return baseHealth * 20;

                case MonsterRarity.GiantParty:
                    return baseHealth * 200;

                default:
                    return baseHealth;
            }
        }
    }

    /// <summary>
    ///     Deserialize from packet
    /// </summary>
    /// <param name="packet">The packet</param>
    internal override void Deserialize(Packet packet)
    {
        ParseBionicDetails(packet);

        base.Deserialize(packet);

        Rarity = (MonsterRarity)packet.ReadByte();

        if (Record.IsEventMob)
            Rarity = MonsterRarity.Event;

        if (Game.ClientType > GameClientType.Chinese && Game.ClientType != GameClientType.Japanese)
            packet.ReadUInt();

        if (Record.TypeID4 == 2 || Record.TypeID4 == 3) //NPC_MOB_TIEF, NPC_MOB_HUNTER
            packet.ReadByte(); //Appeareance
    }
}
