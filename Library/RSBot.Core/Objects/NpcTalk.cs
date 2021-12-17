using RSBot.Core.Network;

namespace RSBot.Core.Objects
{
    public class NpcTalk
    {
        /// <summary>
        /// Gets or sets the talk flag.
        /// </summary>
        /// <value>
        /// The talk flag.
        /// </value>
        public byte Flag { get; set; }

        /// <summary>
        /// Gets or sets the talk options.
        /// </summary>
        /// <value>
        /// The talk options.
        /// </value>
        public byte[] Options { get; set; }

        /// <summary>
        /// Deserialize from the packet
        /// </summary>
        /// <param name="packet">The packet</param>
        public void Deserialize(Packet packet)
        {
            Flag = packet.ReadByte();

            if (Flag == 2)
            {
                var count = 4;
                if (Game.ClientType > GameClientType.Thailand)
                    count = packet.ReadByte();

                Options = packet.ReadByteArray(count);
            }
        }
    }
}
