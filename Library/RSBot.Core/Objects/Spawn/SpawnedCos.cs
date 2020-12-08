using RSBot.Core.Network;

namespace RSBot.Core.Objects.Spawn
{
    public class SpawnedCos
    {
        /// <summary>
        /// Gets or sets the character.
        /// </summary>
        /// <value>
        /// The character.
        /// </value>
        public SpawnedNpc Character { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the name of the guild.
        /// </summary>
        /// <value>
        /// The name of the guild.
        /// </value>
        public string GuildName { get; set; }

        /// <summary>
        /// Gets or sets the name of the owner.
        /// </summary>
        /// <value>
        /// The name of the owner.
        /// </value>
        public string OwnerName { get; set; }

        /// <summary>
        /// Gets or sets the owner unique identifier.
        /// </summary>
        /// <value>
        /// The owner unique identifier.
        /// </value>
        public uint OwnerUniqueId { get; set; }

        /// <summary>
        /// Gets or sets from packet.
        /// </summary>
        /// <value>
        /// From packet.
        /// </value>
        internal static SpawnedCos FromPacket(Packet packet, SpawnedNpc character)
        {
            var result = new SpawnedCos { Character = character };

            if (character.Bionic.Record.TypeID4 == 2 //NPC_COS_TRASNPORT
                || character.Bionic.Record.TypeID4 == 3 //NPC_COS_P_GROWTH
                || character.Bionic.Record.TypeID4 == 4 //NPC_COS_P_ABILITY
                || character.Bionic.Record.TypeID4 == 5 //NPC_COS_GUILD
                || character.Bionic.Record.TypeID4 == 6 //NPC_COS_CAPTURED
                || character.Bionic.Record.TypeID4 == 7 //NPC_COS_QUEST
                || character.Bionic.Record.TypeID4 == 8) //NPC_COS_QUEST
            {
                if (character.Bionic.Record.TypeID4 == 3 // NPC_COS_P_GROWTH
                    || character.Bionic.Record.TypeID4 == 4) //NPC_COS_P_ABILITY
                    result.Name = packet.ReadString();
                else if (character.Bionic.Record.TypeID4 == 5) //NPC_COS_GUILD
                    result.GuildName = packet.ReadString();

                if (character.Bionic.Record.TypeID4 == 2 //NPC_COS_TRASNPORT
                    || character.Bionic.Record.TypeID4 == 3 //NPC_COS_P_GROWTH
                    || character.Bionic.Record.TypeID4 == 4 //NPC_COS_P_ABILITY
                    || character.Bionic.Record.TypeID4 == 5 //NPC_COS_GUILD
                    || character.Bionic.Record.TypeID4 == 6) //NPC_COS_CAPTURED
                {
                    result.OwnerName = packet.ReadString();

                    if (character.Bionic.Record.TypeID4 == 2 //NPC_COS_TRASNPORT
                        || character.Bionic.Record.TypeID4 == 3 //NPC_COS_P_GROWTH
                        || character.Bionic.Record.TypeID4 == 4 //NPC_COS_ABILITY
                        || character.Bionic.Record.TypeID4 == 5) //NPC_COS_GUILD
                    {
                        packet.ReadByte(); //Owner job type

                        if (character.Bionic.Record.TypeID4 == 2 //NPC_COS_TRASNPORT
                            || character.Bionic.Record.TypeID4 == 3 //NPC_COS_P_GROWTH
                            || character.Bionic.Record.TypeID4 == 5) //NPC_COS_GUILD
                        {
                            packet.ReadByte(); //Owner PVP state

                            if (character.Bionic.Record.TypeID4 == 5) //NPC_COS_GUILD
                            {
                                packet.ReadUInt(); //OwnerRefID guild foo
                            }
                        }
                    }
                }

                result.OwnerUniqueId = packet.ReadUInt();
            }

            return result;
        }
    }
}