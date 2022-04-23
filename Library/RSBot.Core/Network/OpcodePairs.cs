namespace RSBot.Core.Network
{
    /// <summary>
    /// Operation code pair of Request-Response protocol.
    /// </summary>
    public struct OpcodePair
    {
        /// <summary>
        /// Opcode of Client's request to Server.
        /// </summary>
        public readonly ushort Request;
        /// <summary>
        /// Opcode of Server's response to Client.
        /// </summary>
        public readonly ushort Response;

        /// <summary>
        /// <see cref="OpcodePair"/> constuctor, this is the only one.
        /// </summary>
        /// <param name="request">The opcode of request</param>
        /// <param name="response">The opcode of response</param>
        public OpcodePair(ushort request, ushort response)
        {
            Request = request;
            Response = response;
        }
    }
    
    /// <summary>
    /// <see cref="OpcodePair"/> definitions for <see cref="Operations"/>.
    /// </summary>
    public static class OpcodePairs
    {
        /// <summary>
        /// <see cref = "OpcodePair"/> for <see cref="Operations.SelectEntity(uint, int)"/>.<br/>
        /// </summary>
        public static readonly OpcodePair SelectEntity = new OpcodePair(0x7045, 0xB045);
        /// <summary>
        /// <see cref = "OpcodePair"/> for <see cref="Operations.DeselectEntity(uint, int)"/>.<br/>
        /// </summary>
        public static readonly OpcodePair DeselectEntity = new OpcodePair(0x704B, 0xB04B);
    }
}
