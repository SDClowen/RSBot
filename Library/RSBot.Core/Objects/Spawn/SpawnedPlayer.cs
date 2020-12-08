using RSBot.Core.Client.ReferenceObjects;
using RSBot.Core.Network;
using RSBot.Core.Objects.Item;
using System.Collections.Generic;

namespace RSBot.Core.Objects.Spawn
{
    public class SpawnedPlayer
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the job.
        /// </summary>
        /// <value>
        /// The job.
        /// </value>
        public JobType Job { get; set; }

        /// <summary>
        /// Gets or sets the job level.
        /// </summary>
        /// <value>
        /// The job level.
        /// </value>
        public byte JobLevel { get; set; }

        /// <summary>
        /// Gets or sets the scroll mode.
        /// </summary>
        /// <value>
        /// The scroll mode.
        /// </value>
        public ScrollMode ScrollMode { get; set; }

        /// <summary>
        /// Gets or sets the state of the PVP.
        /// </summary>
        /// <value>
        /// The state of the PVP.
        /// </value>
        public PvpState PvpState { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [in combat].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [in combat]; otherwise, <c>false</c>.
        /// </value>
        public bool InCombat { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [on transport].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [on transport]; otherwise, <c>false</c>.
        /// </value>
        public bool OnTransport { get; set; }

        /// <summary>
        /// Gets or sets the transport identifier.
        /// </summary>
        /// <value>
        /// The transport identifier.
        /// </value>
        public uint TransportUniqueId { get; set; }

        /// <summary>
        /// Gets or sets the pk flag.
        /// </summary>
        /// <value>
        /// The pk flag.
        /// </value>
        public byte PKFlag { get; set; }

        /// <summary>
        /// Gets or sets the bionic.
        /// </summary>
        /// <value>
        /// The bionic.
        /// </value>
        public SpawnedBionic Bionic { get; set; }

        /// <summary>
        /// Gets or sets the interact mode.
        /// </summary>
        /// <value>
        /// The interact mode.
        /// </value>
        public InteractMode InteractMode { get; set; }

        /// <summary>
        /// Gets or sets the scale.
        /// </summary>
        /// <value>
        /// The scale.
        /// </value>
        public byte Scale { get; set; }

        /// <summary>
        /// Gets or sets the hwan level.
        /// </summary>
        /// <value>
        /// The hwan level.
        /// </value>
        public byte HwanLevel { get; set; }

        /// <summary>
        /// Gets or sets the PVP cape.
        /// </summary>
        /// <value>
        /// The PVP cape.
        /// </value>
        public PvpCapeType PvpCape { get; set; }

        /// <summary>
        /// Gets or sets the automatic inverst exp.
        ///
        /// Beginner Icon, 2 = Helpful, 3 = Beginner & Helpful
        /// </summary>
        /// <value>
        /// The automatic inverst exp.
        /// </value>
        public AutoInverstType AutoInverstExp { get; set; }

        /// <summary>
        /// Gets or sets the size of the inventory.
        /// </summary>
        /// <value>
        /// The size of the inventory.
        /// </value>
        public byte InventorySize { get; set; }

        /// <summary>
        /// Gets or sets the inventory.
        ///
        /// Key = Item record
        /// Value = item plus
        ///
        /// #Too lazy to create an own object...
        /// </summary>
        /// <value>
        /// The inventory.
        /// </value>
        public Dictionary<RefObjItem, byte> Inventory { get; set; }

        /// <summary>
        /// Gets or sets the size of the inventory.
        /// </summary>
        /// <value>
        /// The size of the inventory.
        /// </value>
        public byte AvatarInventorySize { get; set; }

        /// <summary>
        /// Gets or sets the avatars.
        ///
        /// Key = Item record
        /// Value = item plus
        ///
        /// #Too lazy to create an own object...
        /// </summary>
        /// <value>
        /// The inventory.
        /// </value>
        public Dictionary<RefObjItem, byte> Avatars { get; set; }

        /// <summary>
        /// Gets or sets the stall.
        /// </summary>
        /// <value>
        /// The stall.
        /// </value>
        public SpawnedPlayerStall Stall { get; set; }

        /// <summary>
        /// Gets or sets the guild.
        /// </summary>
        /// <value>
        /// The guild.
        /// </value>
        public SpawnedPlayerGuild Guild { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [wears job suite].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [wears job suite]; otherwise, <c>false</c>.
        /// </value>
        public bool WearsJobSuite { get; set; }

        /// <summary>
        /// Froms the packet.
        /// </summary>
        /// <param name="packet">The packet.</param>
        /// <param name="bionic">The bionic.</param>
        /// <returns></returns>
        internal static SpawnedPlayer FromPacket(Packet packet, SpawnedBionic bionic)
        {
            var result = new SpawnedPlayer
            {
                Bionic = bionic,
                Scale = packet.ReadByte(),
                HwanLevel = packet.ReadByte(),
                PvpCape = (PvpCapeType)packet.ReadByte(),
                AutoInverstExp = (AutoInverstType)packet.ReadByte(),
                InventorySize = packet.ReadByte()
            };

            #region Regular equipment

            //Read inventory
            var itemCount = packet.ReadByte();

            if (itemCount > 0)
                result.Inventory = new Dictionary<RefObjItem, byte>();

            for (var i = 0; i < itemCount; i++)
            {
                var itemId = packet.ReadUInt();
                var itemObj = Game.ReferenceManager.GetRefItem(itemId);

                if (itemObj == null)
                {
                    packet.ReadByte();
                    Log.Debug($"unknown item [{itemId}]");
                    continue;
                }

                //Check if the player wears a job-suit
                if (itemObj.TypeID1 == 3 && itemObj.TypeID2 == 1 && itemObj.TypeID3 == 7)
                    result.WearsJobSuite = true;

                if (itemObj.TypeID1 == 3 && itemObj.TypeID2 == 1)
                    result.Inventory.Add(itemObj, packet.ReadByte()); //Item object and the "+" value as value
            }

            #endregion Regular equipment

            #region Avatar equipment

            //Read avatars
            result.AvatarInventorySize = packet.ReadByte();
            itemCount = packet.ReadByte();

            if (itemCount > 0)
                result.Avatars = new Dictionary<RefObjItem, byte>();

            for (var i = 0; i < itemCount; i++)
            {
                var itemId = packet.ReadUInt();
                var itemObj = Game.ReferenceManager.GetRefItem(itemId);
                if (itemObj == null)
                {
                    packet.ReadByte();
                    Log.Debug($"Unknown item [{itemId}]");
                    continue;
                }

                if (itemObj.TypeID1 == 3 && itemObj.TypeID2 == 1)
                    result.Avatars.Add(itemObj, packet.ReadByte()); //Item object and the "+" value as value
            }

            #endregion Avatar equipment

            var hasMask = packet.ReadBool();

            if (!hasMask)
                return result;

            var maskId = packet.ReadUInt();
            var maskObj = Game.ReferenceManager.GetRefObjCommon(maskId);

            if (maskObj == null)
            {
                Log.Debug("Unknown mask item [" + maskId + "]");
                return result;
            }

            if (maskObj.TypeID1 != bionic.Record.TypeID1 || maskObj.TypeID2 != bionic.Record.TypeID2) return result;

            //duplicated player!
            packet.ReadByte(); //the mask scale
            itemCount = packet.ReadByte();
            for (var i = 0; i < itemCount; i++)
                packet.ReadUInt(); //item id

            return result;
        }

        /// <summary>
        /// Parses the details.
        /// </summary>
        /// <param name="packet">The packet.</param>
        internal void ParseDetails(Packet packet)
        {
            Name = packet.ReadString();
            Job = (JobType)packet.ReadByte();
            JobLevel = packet.ReadByte();
            PvpState = (PvpState)packet.ReadByte();
            OnTransport = packet.ReadBool();
            InCombat = packet.ReadBool();

            if (OnTransport)
                TransportUniqueId = packet.ReadUInt();

            ScrollMode = (ScrollMode)packet.ReadByte();
            InteractMode = (InteractMode)packet.ReadByte();

            packet.ReadByte(); //unkByte4
            var guildName = packet.ReadString();

            //Check if the player is wearing job suite, if not the GUILD object has to be parsed!
            if (!WearsJobSuite)
            {
                Guild = SpawnedPlayerGuild.FromPacket(packet);
                Guild.Name = guildName;
            }
            else
                Guild = new SpawnedPlayerGuild { Name = guildName };

            if (InteractMode == InteractMode.P2N_TALK) //Stall mode!
                Stall = SpawnedPlayerStall.FromPacket(packet);

            packet.ReadByte(); //Equipment Cooldown
            PKFlag = packet.ReadByte(); //PKFlag
        }
    }
}