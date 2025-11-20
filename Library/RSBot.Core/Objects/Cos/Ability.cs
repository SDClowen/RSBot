using RSBot.Core.Components;
using RSBot.Core.Network;

namespace RSBot.Core.Objects.Cos;

public class Ability : Cos
{
    /// <summary>
    ///     Deserialize the packet.
    /// </summary>
    /// <param name="packet">The packet.</param>
    public override void Deserialize(Packet packet)
    {
        Settings = packet.ReadInt();
        Name = packet.ReadString();

        Inventory = new InventoryItemCollection(packet);
        OwnerUniqueId = packet.ReadUInt();
        packet.ReadByte(); // inventorySlot

        if (string.IsNullOrWhiteSpace(Name))
            Name = LanguageManager.GetLangBySpecificKey("RSBot", "LabelPetName");
    }

    public override bool Terminate()
    {
        var packet = new Packet(0x7116);
        packet.WriteInt(UniqueId);
        PacketManager.SendPacket(packet, PacketDestination.Server);

        return true;
    }

    /// <summary>
    ///     Moves the item to player.
    /// </summary>
    /// <param name="slot">The slot.</param>
    public byte MoveItemToPlayer(byte slot)
    {
        if (Game.Player.Inventory.Full)
            return 0xFF;

        var destinationSlot = Game.Player.Inventory.GetFreeSlot();

        var packet = new Packet(0x7034);
        packet.WriteByte(0x1A);
        packet.WriteUInt(UniqueId);
        packet.WriteByte(slot);
        packet.WriteByte(destinationSlot);

        var callback = new AwaitCallback(null, 0xB034);
        PacketManager.SendPacket(packet, PacketDestination.Server, callback);
        callback.AwaitResponse();

        if (callback.IsCompleted)
            return destinationSlot;

        return 0xFF;
    }
}
