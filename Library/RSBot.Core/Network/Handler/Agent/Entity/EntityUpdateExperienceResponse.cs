using System;
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
            
            long experienceAmount;
            
            if (Core.Game.ClientType >= GameClientType.Thailand)
               experienceAmount = packet.ReadLong();
            else
               experienceAmount = packet.ReadUInt();

            Core.Game.Player.Experience += experienceAmount;

            var iLevel = Core.Game.Player.Level;
            var oldLevel = Core.Game.Player.Level;

            while (Core.Game.Player.Experience > Core.Game.ReferenceManager.GetRefLevel(iLevel).Exp_C)
            {
                Core.Game.Player.Experience -= Core.Game.ReferenceManager.GetRefLevel(iLevel).Exp_C;
                iLevel++;
            }

            if (Core.Game.Player.Level < iLevel)
            {
                Core.Game.Player.StatPoints += Convert.ToUInt16((iLevel - oldLevel) * 3);
                Core.Game.Player.Level = iLevel;

                Log.Notify($"Congratulations, your level has increased to lv.{Core.Game.Player.Level}");

                EventManager.FireEvent("OnLevelUp", oldLevel);
            }

            EventManager.FireEvent("OnExpSpUpdate");
        }
    }
}