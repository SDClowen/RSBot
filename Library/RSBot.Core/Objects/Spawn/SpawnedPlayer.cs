using System.Collections.Generic;
using RSBot.Core.Client.ReferenceObjects;
using RSBot.Core.Network;
using RSBot.Core.Objects.Item;

namespace RSBot.Core.Objects.Spawn;

public sealed class SpawnedPlayer : SpawnedBionic
{
    /// <summary>
    ///     <inheritdoc />
    /// </summary>
    /// <param name="objId">The obj id</param>
    public SpawnedPlayer(uint objId)
        : base(objId) { }

    /// <summary>
    ///     Gets or sets the name.
    /// </summary>
    /// <value>
    ///     The name.
    /// </value>
    public string Name { get; set; }

    /// <summary>
    ///     Gets or sets the job.
    /// </summary>
    /// <value>
    ///     The job.
    /// </value>
    public JobType Job { get; set; }

    /// <summary>
    ///     Gets or sets the job level.
    /// </summary>
    /// <value>
    ///     The job level.
    /// </value>
    public byte JobLevel { get; set; }

    /// <summary>
    ///     Gets or sets the scroll mode.
    /// </summary>
    /// <value>
    ///     The scroll mode.
    /// </value>
    public ScrollMode ScrollMode { get; set; }

    /// <summary>
    ///     Gets or sets the state of the PVP.
    /// </summary>
    /// <value>
    ///     The state of the PVP.
    /// </value>
    public PvpState PvpState { get; set; }

    /// <summary>
    ///     Gets or sets a value indicating whether [in combat].
    /// </summary>
    /// <value>
    ///     <c>true</c> if [in combat]; otherwise, <c>false</c>.
    /// </value>
    public bool InCombat { get; set; }

    /// <summary>
    ///     Gets or sets a value indicating whether [on transport].
    /// </summary>
    /// <value>
    ///     <c>true</c> if [on transport]; otherwise, <c>false</c>.
    /// </value>
    public bool OnTransport { get; set; }

    /// <summary>
    ///     Gets or sets the transport identifier.
    /// </summary>
    /// <value>
    ///     The transport identifier.
    /// </value>
    public uint TransportUniqueId { get; set; }

    /// <summary>
    ///     Gets or sets the pk flag.
    /// </summary>
    /// <value>
    ///     The pk flag.
    /// </value>
    public byte PKFlag { get; set; }

    /// <summary>
    ///     Gets or sets the interact mode.
    /// </summary>
    /// <value>
    ///     The interact mode.
    /// </value>
    public InteractMode InteractMode { get; set; }

    /// <summary>
    ///     Gets or sets the scale.
    /// </summary>
    /// <value>
    ///     The scale.
    /// </value>
    public byte Scale { get; set; }

    /// <summary>
    ///     Gets or sets the hwan level.
    /// </summary>
    /// <value>
    ///     The hwan level.
    /// </value>
    public byte HwanLevel { get; set; }

    /// <summary>
    ///     Gets or sets the PVP cape.
    /// </summary>
    /// <value>
    ///     The PVP cape.
    /// </value>
    public PvpCapeType PvpCape { get; set; }

    /// <summary>
    ///     Gets or sets the automatic inverst exp.
    ///     Beginner Icon, 2 = Helpful, 3 = Beginner & Helpful
    /// </summary>
    /// <value>
    ///     The automatic inverst exp.
    /// </value>
    public AutoInverstType AutoInverstExp { get; set; }

    /// <summary>
    ///     Gets or sets the size of the inventory.
    /// </summary>
    /// <value>
    ///     The size of the inventory.
    /// </value>
    public byte InventorySize { get; set; }

    /// <summary>
    ///     Gets or sets the inventory.
    ///     Key = Item record
    ///     Value = item plus
    ///     #Too lazy to create an own object...
    /// </summary>
    /// <value>
    ///     The inventory.
    /// </value>
    public Dictionary<RefObjItem, byte> Inventory { get; set; }

    /// <summary>
    ///     Gets or sets the size of the inventory.
    /// </summary>
    /// <value>
    ///     The size of the inventory.
    /// </value>
    public byte AvatarInventorySize { get; set; }

    /// <summary>
    ///     Gets or sets the avatars.
    ///     Key = Item record
    ///     Value = item plus
    ///     #Too lazy to create an own object...
    /// </summary>
    /// <value>
    ///     The inventory.
    /// </value>
    public Dictionary<RefObjItem, byte> Avatars { get; set; }

    /// <summary>
    ///     Gets or sets the stall.
    /// </summary>
    /// <value>
    ///     The stall.
    /// </value>
    public SpawnedPlayerStall Stall { get; set; }

    /// <summary>
    ///     Gets or sets the guild.
    /// </summary>
    /// <value>
    ///     The guild.
    /// </value>
    public SpawnedPlayerGuild Guild { get; set; }

    /// <summary>
    ///     Gets or sets a value indicating whether [wears job suite].
    /// </summary>
    /// <value>
    ///     <c>true</c> if [wears job suite]; otherwise, <c>false</c>.
    /// </value>
    public bool WearsJobSuite { get; set; }

    /// <summary>
    ///     Froms the packet.
    /// </summary>
    /// <param name="packet">The packet.</param>
    /// <param name="bionic">The bionic.</param>
    /// <returns></returns>
    internal void Deserialize(Packet packet)
    {
        Scale = packet.ReadByte();

        if (Game.ClientType > GameClientType.Japanese_Old)
            HwanLevel = packet.ReadByte();

        if (Game.ClientType > GameClientType.Thailand)
            PvpCape = (PvpCapeType)packet.ReadByte();

        AutoInverstExp = (AutoInverstType)packet.ReadByte();

        if (Game.ClientType > GameClientType.Chinese)
            packet.ReadByte(); // Archievement Title

        if (Game.ClientType == GameClientType.Taiwan)
            packet.ReadUInt();

        InventorySize = packet.ReadByte();

        var itemCount = packet.ReadByte();
        Inventory = new Dictionary<RefObjItem, byte>();

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
            if (itemObj.IsJobOutfit)
                WearsJobSuite = true;

            if (itemObj.IsEquip)
                Inventory.Add(itemObj, packet.ReadByte()); //Item object and the "+" value as value
        }

        Avatars = new Dictionary<RefObjItem, byte>();
        if (Game.ClientType >= GameClientType.Thailand)
        {
            AvatarInventorySize = packet.ReadByte();
            itemCount = packet.ReadByte();

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

                Avatars.Add(itemObj, packet.ReadByte()); //Item object and the "+" value as value
            }
        }

        var hasMask = packet.ReadBool();
        if (hasMask)
        {
            var maskId = packet.ReadUInt();
            var maskObj = Game.ReferenceManager.GetRefObjCommon(maskId);
            if (maskObj == null)
            {
                Log.Debug("Unknown mask item [" + maskId + "]");
                return;
            }

            if (maskObj.TypeID1 == Record.TypeID1 || maskObj.TypeID2 == Record.TypeID2)
            {
                //duplicated player!
                var scale = packet.ReadByte();
                itemCount = packet.ReadByte();
                for (var i = 0; i < itemCount; i++)
                    packet.ReadUInt(); //item id
            }
        }

        ParseBionicDetails(packet);

        Name = packet.ReadString();
        Job = (JobType)packet.ReadByte();

        if (Game.ClientType >= GameClientType.Chinese_Old && WearsJobSuite)
            if (WearsJobSuite)
            {
                packet.ReadByte(); // JobRank
                JobLevel = packet.ReadByte();
                packet.ReadByte(); // ??
            }

        if (Game.ClientType < GameClientType.Chinese_Old)
        {
            JobLevel = packet.ReadByte();
            PvpState = (PvpState)packet.ReadByte();
        }

        OnTransport = packet.ReadBool();
        InCombat = packet.ReadBool();

        if (OnTransport)
            TransportUniqueId = packet.ReadUInt();

        ScrollMode = (ScrollMode)packet.ReadByte();
        InteractMode = (InteractMode)packet.ReadByte();

        if (Game.ClientType < GameClientType.Chinese_Old)
            packet.ReadByte(); //unkByte4

        var guildName = packet.ReadString();

        //Check if the player is wearing job suite, if not the GUILD object has to be parsed!
        if (!WearsJobSuite)
        {
            Guild = SpawnedPlayerGuild.FromPacket(packet);
            Guild.Name = guildName;
        }
        else
        {
            Guild = new SpawnedPlayerGuild { Name = guildName };
        }

        if (Game.ClientType >= GameClientType.Chinese && InteractMode == InteractMode.P2N_TALK2)
            Stall = SpawnedPlayerStall.FromPacket(packet);
        else if (Game.ClientType < GameClientType.Chinese && InteractMode == InteractMode.P2N_TALK)
            Stall = SpawnedPlayerStall.FromPacket(packet);

        if (Game.ClientType >= GameClientType.Chinese)
            packet.ReadBytes(9);

        packet.ReadByte(); //Equipment Cooldown

        PKFlag = packet.ReadByte(); //PKFlag

        if (Game.ClientType >= GameClientType.Chinese && Game.ClientType < GameClientType.Rigid)
            packet.ReadByte(); // 0xFF what flag?
    }
}
