using RSBot.Core.Event;
using RSBot.Core.Objects;

namespace RSBot.Core.Network.Handler.Agent.Cos
{
    internal class CosDataResponse : IPacketHandler
    {
        /// <summary>
        /// Gets or sets the opcode.
        /// </summary>
        /// <value>
        /// The opcode.
        /// </value>
        public ushort Opcode => 0x30C8;

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
            var uniqueId = packet.ReadUInt();
            var objectId = packet.ReadUInt();

            var objChar = Game.ReferenceManager.GetRefObjChar(objectId);

            if (objChar.TypeID2 == 2 && objChar.TypeID3 == 3 && (objChar.TypeID4 == 3 || objChar.TypeID4 == 9))
            {
                //Attackpet
                Game.Player.AttackPet = AttackPet.FromPacket(packet, uniqueId, objectId);
                EventManager.FireEvent("OnSummonAttackPet");
                Log.Debug("Summoned attack pet");
            }
            else if (objChar.TypeID2 == 2 && objChar.TypeID3 == 3 && objChar.TypeID4 == 1)
            {
                var health = packet.ReadInt();

                Game.Player.Vehicle = new Vehicle(objectId, uniqueId, health);
                EventManager.FireEvent("OnSummonVehicle");
                Log.Debug("Mount vehicle");

                Game.Player.StopMoving();
                Game.Player.SetSpeed(objChar.Speed1, objChar.Speed2);
            }
            else if (objChar.TypeID2 == 2 && objChar.TypeID3 == 3 && objChar.TypeID4 == 4)
            {
                Game.Player.AbilityPet = AbilityPet.FromPacket(packet, uniqueId, objectId);
                EventManager.FireEvent("OnSummonAbilityPet");
                Log.Debug("Summoned ability pet");
            }
        }
    }
}