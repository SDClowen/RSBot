using RSBot.Core.Client.ReferenceObjects;
using RSBot.Core.Components;
using RSBot.Core.Event;
using RSBot.Core.Network;
using RSBot.Core.Objects.Spawn;
using System.Linq;
using System.Timers;

namespace RSBot.Core.Objects
{
    public class AttackPet
    {
        #region Fields

        private Timer _hungerTimer;

        #endregion Fields

        /// <summary>
        /// Gets or sets the unique identifier.
        /// </summary>
        /// <value>
        /// The unique identifier.
        /// </value>
        public uint UniqueId { get; set; }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public uint Id { get; set; }

        /// <summary>
        /// Gets the record.
        /// </summary>
        /// <value>
        /// The record.
        /// </value>
        public RefObjChar Record => Game.ReferenceManager.GetRefObjChar(Id);

        /// <summary>
        /// Gets or sets the current hp.
        /// </summary>
        /// <value>
        /// The current hp.
        /// </value>
        public uint Health { get; set; }

        /// <summary>
        /// Gets or sets the experience.
        /// </summary>
        /// <value>
        /// The experience.
        /// </value>
        public ulong Experience { get; set; }

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
        public uint MaxHealth { get; set; }

        /// <summary>
        /// Gets or sets the bionic.
        /// </summary>
        /// <value>
        /// The bionic.
        /// </value>
        public SpawnedBionic Bionic => SpawnManager.GetEntity<SpawnedBionic>(UniqueId);

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
        internal static AttackPet FromPacket(Packet packet, uint uniqueId, uint id)
        {
            var result = new AttackPet
            {
                UniqueId = uniqueId,
                Id = id,
                Health = packet.ReadUInt()
            };

            var maxHealth = packet.ReadUInt(); //UNKNOWN
            result.MaxHealth = maxHealth != 0 ? maxHealth : result.Health;

            result.Experience = packet.ReadULong();
            result.Level = packet.ReadByte();
            result.CurrentHungerPoints = packet.ReadUShort();
            packet.ReadInt(); //UNKNOWN (maybe control?)
            result.Name = packet.ReadString();

            result.StartHungerTimer();
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
        /// Starts the hunger timer.
        /// </summary>
        private void StartHungerTimer()
        {
            _hungerTimer = new Timer(3000);
            _hungerTimer.Elapsed += HungerTimer_Elapsed;
            _hungerTimer.Start();
        }

        /// <summary>
        /// Handles the Elapsed event of the HungerTimer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ElapsedEventArgs"/> instance containing the event data.</param>
        private void HungerTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            CurrentHungerPoints--;
            EventManager.FireEvent("OnAttackPetHungerUpdate");
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
    }
}