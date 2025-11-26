using RSBot.Core.Client.ReferenceObjects;
using RSBot.Core.Components;
using RSBot.Core.Network;

namespace RSBot.Core.Objects.Cos;

public class Fellow : Cos
{
    /// <summary>
    ///     Gets or sets the strength.
    /// </summary>
    /// <value>
    ///     The strength.
    /// </value>
    public ushort Strength { get; set; }

    /// <summary>
    ///     Gets or sets the intelligence.
    /// </summary>
    /// <value>
    ///     The intelligence.
    /// </value>
    public ushort Intelligence { get; set; }

    /// <summary>
    ///     Gets or sets the physical attack minimum.
    /// </summary>
    /// <value>
    ///     The physical attack minimum.
    /// </value>
    public uint PhysicalAttackMin { get; set; }

    /// <summary>
    ///     Gets or sets the physical attack maximum.
    /// </summary>
    /// <value>
    ///     The physical attack maximum.
    /// </value>
    public uint PhysicalAttackMax { get; set; }

    /// <summary>
    ///     Gets or sets the magical attack minimum.
    /// </summary>
    /// <value>
    ///     The magical attack minimum.
    /// </value>
    public uint MagicalAttackMin { get; set; }

    /// <summary>
    ///     Gets or sets the magical attack maximum.
    /// </summary>
    /// <value>
    ///     The magical attack maximum.
    /// </value>
    public uint MagicalAttackMax { get; set; }

    /// <summary>
    ///     Gets or sets the physical defence.
    /// </summary>
    /// <value>
    ///     The physical defence.
    /// </value>
    public ushort PhysicalDefence { get; set; }

    /// <summary>
    ///     Gets or sets the magical defence.
    /// </summary>
    /// <value>
    ///     The magical defence.
    /// </value>
    public ushort MagicalDefence { get; set; }

    /// <summary>
    ///     Gets or sets the hit rate.
    /// </summary>
    /// <value>
    ///     The hit rate.
    /// </value>
    public ushort HitRate { get; set; }

    /// <summary>
    ///     Gets or sets the satiety.
    /// </summary>
    /// <value>
    ///     The satiety.
    /// </value>
    public int Satiety { get; set; }

    /// <summary>
    ///     Gets or sets the stored sp.
    /// </summary>
    /// <value>
    ///     The stored sp.
    /// </value>
    public int StoredSp { get; set; }

    /// <summary>
    ///     Gets or sets a value indicating whether this cos is offensive
    /// </summary>
    /// <value>
    ///     <c>true</c> if this cos is offensive; otherwise, <c>false</c>.
    /// </value>
    public bool IsCounterAttackOn => (Settings & 0x10) == 0x10;

    /// <summary>
    ///     Gets the maximum experience.
    /// </summary>
    /// <value>
    ///     The maximum experience.
    /// </value>
    public override long MaxExperience => Game.ReferenceManager.GetRefLevel(Level).Exp_C_Pet2;

    /// <summary>
    ///     Gets the maximum stored sp.
    /// </summary>
    /// <value>
    ///     The maximum stored sp.
    /// </value>
    public int MaxStoredSp => Game.ReferenceManager.GetRefLevel(Level).StoredSp_Pet2;

    public override bool UseHealthPotion()
    {
        var usingItem = Game.Player.Inventory.GetItem(p => p.Record.IsFellowHpPotion);
        if (usingItem == null)
            return false;

        usingItem.UseFor(UniqueId);

        return true;
    }

    /// <summary>
    ///     Uses the hunger potion.
    /// </summary>
    /// <returns></returns>
    public bool UseSatietyPotion()
    {
        var item = Game.Player.Inventory.GetItem(p =>
            p.Record.IsPet2SatietyPotion
            && (
                p.Record.ReqLevelType1 == ObjectReqLevelType.None
                || (Level >= p.Record.ReqLevel1 && Level <= p.Record.ReqLevel2)
            )
        );
        if (item == null)
            return false;

        item.UseFor(UniqueId);

        return true;
    }

    //public override bool UseBadStatusPotion()
    //{
    //    return false;
    //}

    public override void Deserialize(Packet packet)
    {
        Experience = packet.ReadLong();
        Level = packet.ReadByte();
        Satiety = packet.ReadInt();
        var unknown1 = packet.ReadUShort();
        StoredSp = packet.ReadInt();
        var unknown2 = packet.ReadInt();
        Settings = packet.ReadInt();
        Name = packet.ReadString();
        Inventory = new InventoryItemCollection(packet);

        if (string.IsNullOrWhiteSpace(Name))
            Name = LanguageManager.GetLangBySpecificKey("RSBot", "LabelPetName");
    }
}
