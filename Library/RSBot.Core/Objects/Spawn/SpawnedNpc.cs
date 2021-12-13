using RSBot.Core.Network;

namespace RSBot.Core.Objects.Spawn
{
    public class SpawnedNpc : SpawnedBionic
    {
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
        /// <inheritdoc/>
        /// </summary>
        /// <param name="objId">The ref obj id</param>
        public SpawnedNpc(uint objId) 
            : base(objId) { }

        /// <summary>
        /// Froms the packet.
        /// </summary>
        /// <param name="packet">The packet.</param>
        /// <param name="bionic">The bionic.</param>
        /// <returns></returns>
        internal virtual void Deserialize(Packet packet)
        {
            TalkFlag = packet.ReadByte();

            if (TalkFlag == 2)
                TalkOptions = packet.ReadByteArray(packet.ReadByte());
        }
    }
}