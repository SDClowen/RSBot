using RSBot.Core.Client.ReferenceObjects;
using RSBot.Core.Network;
using RSBot.Core.Objects.Spawn;
using System;
using System.Linq;
using System.Threading;

namespace RSBot.Core.Objects
{
    public class Vehicle : SpawnedEntity
    {
        /// <summary>
        /// Gets or sets the current health.
        /// </summary>
        /// <value>
        /// The current health.
        /// </value>
        public uint Health { get; set; }

        /// <summary>
        /// Gets or sets the bad effect.
        /// </summary>
        /// <value>
        /// The bad effect.
        /// </value>
        public BadEffect BadEffect { get; set; }

        /// <summary>
        /// Froms the packet.
        /// </summary>
        /// <param name="packet">The packet.</param>
        /// <param name="uniqueId">The unique identifier.</param>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        internal static Vehicle FromPacket(Packet packet, uint uniqueId, uint id)
        {
            return new Vehicle
            {
                UniqueId = uniqueId,
                Id = id,
                Health = packet.ReadUInt()
            };
        }

        /// <summary>
        /// Uses the health potion.
        /// </summary>
        /// <returns></returns>
        public bool UseHealthPotion()
        {
            var typeIdFilter = new TypeIdFilter(3, 3, 1, 4);
            var usingItem = (from item in Game.Player.Inventory.Items where typeIdFilter.EqualsRefItem(item.Record) select item).FirstOrDefault();
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
            packet.Lock();

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

            packet.Lock();

            var awaitCallback = new AwaitCallback(response =>
            {
                return response.ReadUInt() == UniqueId 
                ? AwaitCallbackResult.Received : AwaitCallbackResult.None;
            }, 0xB021);

            PacketManager.SendPacket(packet, PacketDestination.Server, awaitCallback);
            awaitCallback.AwaitResponse();
            var distance = Game.Player.Movement.Source.DistanceTo(destination);
            //Wait to finish the step
            Thread.Sleep(Convert.ToInt32((distance / Game.Player.ActualSpeed) * 10000));
        }
    }
}