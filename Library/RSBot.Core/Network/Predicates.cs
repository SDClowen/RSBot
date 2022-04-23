using RSBot.Core.Network.Handler.Agent.Action;

namespace RSBot.Core.Network
{
    /// <summary>
    /// Predicates for <see cref="AwaitCallback"/> of <see cref="Operations"/>.
    /// </summary>
    public static class Predicates
    {
        /// <summary>
        /// Predicate for <see cref="AwaitCallback"/> of <see cref="Operations.SelectEntity(uint, int)"/>.<br/>
        /// Server respone handler is <see cref="ActionSelectResponse"/>.
        /// </summary>
        /// <param name="response">The response <see cref="Packet"/></param>
        /// <param name="uniqueId">UniqueId of the entity</param>
        /// <returns><see cref="AwaitCallbackResult"/></returns>
        public static AwaitCallbackResult SelectEntity(Packet response, uint uniqueId)
        {
            if (response.ReaderLength < Packet.GetLengthNumericTypes(PacketNumericType.Byte, PacketNumericType.UInt))
                return AwaitCallbackResult.Failed;

            if (response.ReadByte() == 1)
                return response.ReadUInt() == uniqueId ? AwaitCallbackResult.Successed : AwaitCallbackResult.ConditionFailed;

            return AwaitCallbackResult.Failed;
        }

        /// <summary>
        /// Predicate for <see cref="AwaitCallback"/> of <see cref="Operations.DeselectEntity(uint, int)"/>.<br/>
        /// Server respone handler is <see cref="ActionDeselectResponse"/>.
        /// </summary>
        /// <param name="response">The response <see cref="Packet"/></param>
        /// <param name="uniqueId">UniqueId of the entity</param>
        /// <returns><see cref="AwaitCallbackResult"/></returns>
        public static AwaitCallbackResult DeselectEntity(Packet response)
        {
            if (response.ReaderLength != Packet.GetLengthNumericTypes(PacketNumericType.Byte))
                return AwaitCallbackResult.Failed;

            return response.ReadByte() == 1 ? AwaitCallbackResult.Successed : AwaitCallbackResult.ConditionFailed;
        }
    }
}