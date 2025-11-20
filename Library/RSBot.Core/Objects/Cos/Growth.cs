using RSBot.Core.Components;
using RSBot.Core.Event;
using RSBot.Core.Network;

namespace RSBot.Core.Objects.Cos;

public class Growth : Cos
{
    /// <summary>
    ///     Hunger last tick
    /// </summary>
    private int _lastHungerTick;

    /// <summary>
    ///     Gets or sets the current hunger points.
    /// </summary>
    /// <value>
    ///     The current hunger points.
    /// </value>
    public ushort CurrentHungerPoints { get; set; }

    /// <summary>
    ///     Gets the maximum hunger points.
    /// </summary>
    /// <value>
    ///     The maximum hunger points.
    /// </value>
    public ushort MaxHungerPoints => 10000;

    /// <summary>
    ///     Gets or sets a value indicating whether this cos is offensive
    /// </summary>
    /// <value>
    ///     <c>true</c> if this cos is offensive; otherwise, <c>false</c>.
    /// </value>
    public bool IsOffensive => (Settings & 1) == 1;

    /// <summary>
    ///     Deserialize the packet.
    /// </summary>
    /// <param name="packet">The packet.</param>
    /// <returns></returns>
    public override void Deserialize(Packet packet)
    {
        Experience = packet.ReadLong();
        Level = packet.ReadByte();
        CurrentHungerPoints = packet.ReadUShort();
        Settings = packet.ReadInt();
        Name = packet.ReadString();

        packet.ReadByte(); // ??
        OwnerUniqueId = packet.ReadUInt();
        packet.ReadByte(); // inventorySlot

        if (string.IsNullOrWhiteSpace(Name))
            Name = LanguageManager.GetLangBySpecificKey("RSBot", "LabelPetName");
    }

    /// <summary>
    ///     Uses the hunger potion.
    /// </summary>
    /// <returns></returns>
    public bool UseHungerPotion()
    {
        var item = Game.Player.Inventory.GetItem(p => p.Record.IsHgpPotion);
        if (item == null)
            return false;

        item.UseFor(UniqueId);

        return true;
    }

    public override bool Terminate()
    {
        var packet = new Packet(0x7116);
        packet.WriteInt(UniqueId);
        PacketManager.SendPacket(packet, PacketDestination.Server);

        return true;
    }

    /// <summary>
    ///     Update the entity
    /// </summary>
    public override bool Update(int delta)
    {
        if (Kernel.TickCount - _lastHungerTick > 3000)
        {
            CurrentHungerPoints--;
            _lastHungerTick = Kernel.TickCount;
            EventManager.FireEvent("OnGrowthHungerUpdate");
        }

        return base.Update(delta);
    }
}
