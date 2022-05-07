using RSBot.Core.Network;
using RSBot.Core.Objects.Spawn;
using System;
using System.Linq;
using System.Threading;

namespace RSBot.Core.Objects
{
    public class Vehicle : SpawnedBionic
    {
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="objId">The entity model id</param>
        /// <param name="uniqueId">The entity unique id</param>
        /// <param name="health">The current health</param>
        public Vehicle(uint objId, uint uniqueId, int health) 
            : base(objId)
        {
            UniqueId = uniqueId;
            Health = health;
        }

        /// <summary>
        /// Uses the health potion.
        /// </summary>
        /// <returns></returns>
        public bool UseHealthPotion()
        {
            var typeIdFilter = new TypeIdFilter(3, 3, 1, 4);
            var usingItem = Game.Player.Inventory.GetItem_ByTypeIdFilter(typeIdFilter);
            usingItem.UseFor(UniqueId);
            return true;
        }

        /// <summary>
        /// Dismounts this instance.
        /// </summary>
        public void Dismount()
        {
            var packet = new Packet(0x70CB);
            packet.WriteByte(0);
            packet.WriteUInt(UniqueId);

            PacketManager.SendPacket(packet, PacketDestination.Server);
        }

        /// <summary>
        /// Moves this instance.
        /// </summary>
        public void MoveTo(Position destination)
        {
            var packet = new Packet(0x70C5);
            packet.WriteUInt(UniqueId);
            packet.WriteByte(1); //Move
            packet.WriteByte(1); //To point
            packet.WriteUShort(destination.RegionID);

            //Normal world
            if (!destination.IsInDungeon)
            {
                packet.WriteShort(destination.XOffset);
                packet.WriteShort(destination.ZOffset);
                packet.WriteShort(destination.YOffset);
            }
            else
            {
                packet.WriteInt(destination.XOffset);
                packet.WriteInt(destination.ZOffset);
                packet.WriteInt(destination.YOffset);
            }

            var awaitCallback = new AwaitCallback(response =>
            {
                return response.ReadUInt() == UniqueId 
                ? AwaitCallbackResult.Successed : AwaitCallbackResult.ConditionFailed;
            }, 0xB021);

            PacketManager.SendPacket(packet, PacketDestination.Server, awaitCallback);
            awaitCallback.AwaitResponse();
            var distance = Game.Player.Movement.Source.DistanceTo(destination);
            //Wait to finish the step
            Thread.Sleep(Convert.ToInt32((distance / Game.Player.ActualSpeed) * 10000));
        }
    }
}