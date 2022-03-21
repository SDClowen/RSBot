using RSBot.Core.Event;

namespace RSBot.Core.Network.Handler.Agent.Character
{
    internal class CharacterUpdateStatsResponse : IPacketHandler
    {
        /// <summary>
        /// Gets or sets the opcode.
        /// </summary>
        /// <value>
        /// The opcode.
        /// </value>
        public ushort Opcode => 0x303D;

        /// <summary>
        /// Gets or sets the destination.
        /// </summary>
        /// <value>
        /// The destination.
        /// </value>
        public PacketDestination Destination => PacketDestination.Client;

        /// <summary>
        /// Handles the packet.
        /// </summary>
        /// <param name="packet">The packet.</param>
        public void Invoke(Packet packet)
        {
            Core.Game.Player.PhysicalAttackMin = packet.ReadUInt();
            Core.Game.Player.PhysicalAttackMax = packet.ReadUInt();
            Core.Game.Player.MagicalAttackMin = packet.ReadUInt();
            Core.Game.Player.MagicalAttackMax = packet.ReadUInt();

            Core.Game.Player.PhysicalDefence = packet.ReadUShort();
            Core.Game.Player.MagicalDefence = packet.ReadUShort();

            Core.Game.Player.HitRate = packet.ReadUShort();
            Core.Game.Player.ParryRate = packet.ReadUShort();

            Core.Game.Player.MaximumHealth = packet.ReadInt();
            Core.Game.Player.MaximumMana = packet.ReadInt();

            Core.Game.Player.Strength = packet.ReadUShort();
            Core.Game.Player.Intelligence = packet.ReadUShort();
            
            EventManager.FireEvent("OnLoadCharacterStats");
        }
    }
}