using RSBot.Core.Network;

namespace RSBot.Core.Objects.Spawn
{
    public class SpawnedFortressStructure
    {
        /// <summary>
        /// Gets or sets the bionic.
        /// </summary>
        /// <value>
        /// The bionic.
        /// </value>
        public SpawnedBionic Bionic { get; set; }

        /// <summary>
        /// </summary>
        /// <value>
        /// The hp.
        /// </value>
        public uint HP { get; set; }

        /// <summary>
        /// Gets or sets the reference event structure identifier.
        /// </summary>
        /// <value>
        /// The reference event structure identifier.
        /// </value>
        public uint RefEventStructID { get; set; }

        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        /// <value>
        /// The state.
        /// </value>
        public ushort State { get; set; }

        /// <summary>
        /// Froms the packet.
        /// </summary>
        /// <param name="packet">The packet.</param>
        /// <param name="bionic">The bionic.</param>
        /// <returns></returns>
        internal static SpawnedFortressStructure FromPacket(Packet packet, SpawnedBionic bionic)
        {
            return new SpawnedFortressStructure
            {
                Bionic = bionic,
                HP = packet.ReadUInt(),
                RefEventStructID = packet.ReadUInt(),
                State = packet.ReadUShort()
            };
        }
    }
}