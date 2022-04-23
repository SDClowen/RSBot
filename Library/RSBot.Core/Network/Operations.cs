namespace RSBot.Core.Network
{
    /// <summary>
    /// Request-Response protocol operations.
    /// </summary>
    public static class Operations
    {
        /// <summary>
        /// Select the entity by its UniqueId.
        /// </summary>
        /// <param name="uniqueId">UniqueId of the entity</param>
        /// <param name="timeout">The timeout in milliseconds, default value is <see cref="AwaitCallback.TIMEOUT_DEFAULT"/></param>
        /// <returns><c>true</c> if succesfully selected the entity; otherwise, <c>false</c>.</returns>
        public static bool SelectEntity(uint uniqueId, int timeout = AwaitCallback.TIMEOUT_DEFAULT)
        {
            var packet = new Packet(OpcodePairs.SelectEntity.Request);
            packet.WriteUInt(uniqueId);
            packet.Lock();
            
            var callback = new AwaitCallback(p => Predicates.SelectEntity(p, uniqueId), OpcodePairs.SelectEntity.Response);

            PacketManager.SendPacket(packet, PacketDestination.Server, callback);
            callback.AwaitResponse(timeout);

            return callback.IsCompleted;
        }

        /// <summary>
        /// Deselect the entity by its UniqueId.
        /// </summary>
        /// <param name="uniqueId">UniqueId of the entity</param>
        /// <param name="timeout">The timeout in milliseconds, default value is <see cref="AwaitCallback.TIMEOUT_DEFAULT"/></param>
        /// <returns><c>true</c> if succesfully deselected the entity; otherwise, <c>false</c>.</returns>
        public static bool DeselectEntity(uint uniqueId, int timeout = AwaitCallback.TIMEOUT_DEFAULT)
        {
            var packet = new Packet(OpcodePairs.DeselectEntity.Request);
            packet.WriteUInt(uniqueId);
            packet.Lock();
            
            var callback = new AwaitCallback(p => Predicates.DeselectEntity(p), OpcodePairs.DeselectEntity.Response);

            PacketManager.SendPacket(packet, PacketDestination.Server, callback);
            callback.AwaitResponse(timeout);

            return callback.IsCompleted;
        }
    }
}
