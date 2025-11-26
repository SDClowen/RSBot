using RSBot.Core.Network;

namespace RSBot.Core.Objects.Spawn;

public sealed class SpawnedCos : SpawnedNpc
{
    /// <summary>
    ///     <inheritdoc />
    /// </summary>
    /// <param name="objId">The ref obj id</param>
    public SpawnedCos(uint objId)
        : base(objId) { }

    /// <summary>
    ///     Gets or sets the name.
    /// </summary>
    /// <value>
    ///     The name.
    /// </value>
    public string Name { get; set; }

    /// <summary>
    ///     Gets or sets the name of the guild.
    /// </summary>
    /// <value>
    ///     The name of the guild.
    /// </value>
    public string GuildName { get; set; }

    /// <summary>
    ///     Gets or sets the name of the owner.
    /// </summary>
    /// <value>
    ///     The name of the owner.
    /// </value>
    public string OwnerName { get; set; }

    /// <summary>
    ///     Gets or sets the owner unique identifier.
    /// </summary>
    /// <value>
    ///     The owner unique identifier.
    /// </value>
    public uint OwnerUniqueId { get; set; }

    internal override void Deserialize(Packet packet)
    {
        ParseBionicDetails(packet);
        base.Deserialize(packet);

        var refObj = Record;

        if (
            refObj.TypeID4 == 2 //NPC_COS_TRANSPORT
            || refObj.TypeID4 == 3 //NPC_COS_P_GROWTH
            || refObj.TypeID4 == 4 //NPC_COS_P_ABILITY
            || refObj.TypeID4 == 5 //NPC_COS_GUILD
            || refObj.TypeID4 == 6 //NPC_COS_CAPTURED
            || refObj.TypeID4 == 7 //NPC_COS_QUEST
            || refObj.TypeID4 == 8 //NPC_COS_QUEST
            || refObj.TypeID4 == 9
        ) // COS_PET2
        {
            if (
                refObj.TypeID4 == 3
                || // NPC_COS_P_GROWTH
                refObj.TypeID4 == 4
                || //NPC_COS_P_ABILITY
                refObj.TypeID4 == 9
            ) // COS_PET2
                Name = packet.ReadString();
            else if (refObj.TypeID4 == 5) //NPC_COS_GUILD
                GuildName = packet.ReadString();

            if (
                refObj.TypeID4 == 2 //NPC_COS_TRASNPORT
                || refObj.TypeID4 == 3 //NPC_COS_P_GROWTH
                || refObj.TypeID4 == 4 //NPC_COS_P_ABILITY
                || refObj.TypeID4 == 5 //NPC_COS_GUILD
                || refObj.TypeID4 == 6 //NPC_COS_CAPTURED
                || refObj.TypeID4 == 9
            ) //COS_PET2
            {
                OwnerName = packet.ReadString();

                if (
                    refObj.TypeID4 == 2 //NPC_COS_TRASNPORT
                    || refObj.TypeID4 == 3 //NPC_COS_P_GROWTH
                    || refObj.TypeID4 == 4 //NPC_COS_ABILITY
                    || refObj.TypeID4 == 5 //NPC_COS_GUILD
                    || refObj.TypeID4 == 9
                ) //COS_PET2
                {
                    packet.ReadByte(); //Owner job type

                    if (
                        refObj.TypeID4 == 2 //NPC_COS_TRASNPORT
                        || refObj.TypeID4 == 3 //NPC_COS_P_GROWTH
                        || refObj.TypeID4 == 5 //NPC_COS_GUILD
                        || refObj.TypeID4 == 9
                    ) //COS_PET2
                    {
                        packet.ReadByte(); //Owner PVP state

                        if (refObj.TypeID4 == 5) //NPC_COS_GUILD
                            packet.ReadUInt(); //OwnerRefID guild foo
                    }
                }
            }

            OwnerUniqueId = packet.ReadUInt();
            if (refObj.TypeID4 == 9)
                packet.ReadByte(); //???
        }
    }
}
