using RSBot.Core.Client.ReferenceObjects;
using RSBot.Core.Components;
using RSBot.Core.Event;
using RSBot.Core.Network;
using RSBot.Core.Objects.Spawn;
using System;
using System.Linq;
using System.Timers;

namespace RSBot.Core.Objects
{
    public class AttackPet : SpawnedBionic
    {
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="objId"></param>
        public AttackPet(uint objId) : base(objId) {}

        /// <summary>
        /// Gets or sets the experience.
        /// </summary>
        /// <value>
        /// The experience.
        /// </value>
        public long Experience { get; set; }

        /// <summary>
        /// Gets or sets the level.
        /// </summary>
        /// <value>
        /// The level.
        /// </value>
        public byte Level { get; set; }

        /// <summary>
        /// Gets or sets the current hunger points.
        /// </summary>
        /// <value>
        /// The current hunger points.
        /// </value>
        public ushort CurrentHungerPoints { get; set; }

        /// <summary>
        /// Gets the maximum hunger points.
        /// </summary>
        /// <value>
        /// The maximum hunger points.
        /// </value>
        public ushort MaxHungerPoints => 10000;

        /// <summary>
        /// Gets the maximum experience.
        /// </summary>
        /// <value>
        /// The maximum experience.
        /// </value>
        public long MaxExperience => Game.ReferenceManager.GetRefLevel(Level).Exp_C;

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the maximum health.
        /// </summary>
        /// <value>
        /// The maximum health.
        /// </value>
        public int MaxHealth { get; set; }

        /// <summary>
        /// Gets or sets the bionic.
        /// </summary>
        /// <value>
        /// The bionic.
        /// </value>
        public SpawnedBionic Bionic => SpawnManager.GetEntity<SpawnedBionic>(UniqueId);

        /// <summary>
        /// Hunger last tick
        /// </summary>
        private int _lastHungerTick;

        /// <summary>
        /// Froms the packet.
        /// </summary>
        /// <param name="packet">The packet.</param>
        /// <param name="uniqueId">The unique identifier.</param>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        internal static AttackPet FromPacket(Packet packet, uint uniqueId, uint id)
        {
            var result = new AttackPet(id)
            {
                UniqueId = uniqueId,
                Id = id,
                Health = packet.ReadInt()
            };

            var maxHealth = packet.ReadInt(); //UNKNOWN
            result.MaxHealth = maxHealth != 0 ? maxHealth : result.Health;

            result.Experience = packet.ReadLong();
            result.Level = packet.ReadByte();
            result.CurrentHungerPoints = packet.ReadUShort();
            packet.ReadInt(); //UNKNOWN (maybe control?)
            result.Name = packet.ReadString();

            return result;
        }

        /// <summary>
        /// Releases this instance.
        /// </summary>
        public void Terminate()
        {
            var packet = new Packet(0x70C6);
            packet.WriteUInt(UniqueId);
            packet.Lock();

            PacketManager.SendPacket(packet, PacketDestination.Server);
        }

        /// <summary>
        /// Uses the health potion.
        /// </summary>
        /// <returns></returns>
        public bool UseHealthPotion()
        {
            var typeIdFilter = new TypeIdFilter(3, 3, 1, 4);
            var slot = (from item in Game.Player.Inventory.Items where typeIdFilter.EqualsRefItem(item.Record) select item.Slot).FirstOrDefault();

            if (slot == 0) return false;

            var packet = new Packet(0x704C);
            packet.WriteByte(slot);
            packet.WriteUShort(0x20EC);
            packet.WriteInt(UniqueId);

            packet.Lock();
            PacketManager.SendPacket(packet, PacketDestination.Server);

            return true;
        }

        /// <summary>
        /// Uses the bad status potion.
        /// </summary>
        /// <returns></returns>
        public bool UseBadStatusPotion()
        {
            var typeIdFilter = new TypeIdFilter(3, 3, 2, 7);
            var slot = (from item in Game.Player.Inventory.Items where typeIdFilter.EqualsRefItem(item.Record) select item.Slot).FirstOrDefault();

            if (slot == 0) return false;

            var packet = new Packet(0x704C);
            packet.WriteByte(slot);
            packet.WriteUShort(0x396C);
            packet.WriteInt(UniqueId);

            packet.Lock();
            PacketManager.SendPacket(packet, PacketDestination.Server);

            return true;
        }

        /// <summary>
        /// Uses the hunger potion.
        /// </summary>
        /// <returns></returns>
        public bool UseHungerPotion()
        {
            var typeIdFilter = new TypeIdFilter(3, 3, 1, 9);
            var slot = (from item in Game.Player.Inventory.Items where typeIdFilter.EqualsRefItem(item.Record) select item.Slot).FirstOrDefault();

            if (slot == 0) return false;

            var packet = new Packet(0x704C);
            packet.WriteByte(slot);
            packet.WriteUShort(0x48EC);
            packet.WriteInt(UniqueId);

            packet.Lock();
            PacketManager.SendPacket(packet, PacketDestination.Server);

            return true;
        }

        /// <summary>
        /// Update the entity
        /// </summary>
        public override bool Update()
        {
            if(Environment.TickCount - _lastHungerTick > 3000)
            {
                CurrentHungerPoints--;
                _lastHungerTick = Environment.TickCount;
                EventManager.FireEvent("OnAttackPetHungerUpdate");
            }

            return base.Update();
        }
    }
}