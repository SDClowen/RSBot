using RSBot.Core.Network;

namespace RSBot.Core.Objects.Spawn
{
    public class SpawnedNpc
    {
        /// <summary>
        /// Gets or sets the bionic.
        /// </summary>
        /// <value>
        /// The bionic.
        /// </value>
        public SpawnedBionic Bionic { get; set; }

        /// <summary>
        /// Gets or sets the talk flag.
        /// </summary>
        /// <value>
        /// The talk flag.
        /// </value>
        public byte TalkFlag { get; set; }

        /// <summary>
        /// Gets or sets the talk options.
        /// </summary>
        /// <value>
        /// The talk options.
        /// </value>
        public byte[] TalkOptions { get; set; }

        /// <summary>
        /// Froms the packet.
        /// </summary>
        /// <param name="packet">The packet.</param>
        /// <param name="bionic">The bionic.</param>
        /// <returns></returns>
        internal static SpawnedNpc FromPacket(Packet packet, SpawnedBionic bionic)
        {
            var result = new SpawnedNpc
            {
                Bionic = bionic,
                TalkFlag = packet.ReadByte()
            };

            if (result.TalkFlag == 2)
                result.TalkOptions = packet.ReadByteArray(packet.ReadByte());

            return result;
        }
    }
}