using RSBot.Core.Event;

namespace RSBot.Core.Network.Handler.Agent.Entity
{
    internal class EntityUpdateExperienceResponse : IPacketHandler
    {
        /// <summary>
        /// Gets or sets the opcode.
        /// </summary>
        /// <value>
        /// The opcode.
        /// </value>
        public ushort Opcode => 0x3056;

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
            packet.ReadUInt(); //Mobs unique ID!

            long experienceAmount = 0;
            
            if (Core.Game.ClientType >= GameClientType.Thailand)
                packet.ReadLong();
            else
                packet.ReadUInt();

            Core.Game.Player.Experience += experienceAmount;

            var iLevel = Core.Game.Player.Level;
            while (Core.Game.Player.Experience > Core.Game.ReferenceManager.GetRefLevel(iLevel).Exp_C)
            {
                Core.Game.Player.Experience -= Core.Game.ReferenceManager.GetRefLevel(iLevel).Exp_C;
                iLevel++;
            }

            if (Core.Game.Player.Level < iLevel)
                Core.Game.Player.Level = iLevel;

            EventManager.FireEvent("OnExpSpUpdate");

            if (Core.Game.Player.AttackPet == null) return;
        }
    }
}