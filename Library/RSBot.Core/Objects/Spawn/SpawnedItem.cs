using RSBot.Core.Client.ReferenceObjects;
using RSBot.Core.Network;

namespace RSBot.Core.Objects.Spawn;

public class SpawnedItem : SpawnedEntity
{
    /// <summary>
    ///     Gets or sets the amount.
    /// </summary>
    /// <value>
    ///     The amount.
    /// </value>
    public uint Amount;

    /// <summary>
    ///     Gets or sets a value indicating whether this instance has owner.
    /// </summary>
    /// <value>
    ///     <c>true</c> if this instance has owner; otherwise, <c>false</c>.
    /// </value>
    public bool HasOwner;

    /// <summary>
    ///     Gets or sets the opt level.
    /// </summary>
    /// <value>
    ///     The opt level.
    /// </value>
    public byte OptLevel;

    /// <summary>
    ///     Gets or sets the owner identifier.
    /// </summary>
    /// <value>
    ///     The owner identifier.
    /// </value>
    public uint OwnerJID;

    /// <summary>
    ///     Gets or sets the name of the owner.
    /// </summary>
    /// <value>
    ///     The name of the owner.
    /// </value>
    public string OwnerName;

    /// <summary>
    ///     Gets or sets the rarity.
    /// </summary>
    /// <value>
    ///     The rarity.
    /// </value>
    public ObjectRarity Rarity;

    /// <summary>
    ///     Gets the record.
    /// </summary>
    /// <value>
    ///     The record.
    /// </value>
    public new RefObjItem Record => Game.ReferenceManager.GetRefItem(Id);

    /// <summary>
    ///     Froms the packet.
    /// </summary>
    /// <param name="packet">The packet.</param>
    /// <param name="itemId">The item identifier.</param>
    /// <returns></returns>
    internal static SpawnedItem FromPacket(Packet packet, uint itemId)
    {
        var result = new SpawnedItem { Id = itemId };

        if (result.Record.IsEquip)
            result.OptLevel = packet.ReadByte();
        else if (result.Record.IsGold)
            result.Amount = packet.ReadUInt();
        else if (result.Record.IsQuest || result.Record.IsTrading)
            result.OwnerName = packet.ReadString();

        result.UniqueId = packet.ReadUInt();
        result.Movement.Source = Position.FromPacket(packet);
        result.HasOwner = packet.ReadBool();

        if (result.HasOwner)
            result.OwnerJID = packet.ReadUInt();

        result.Rarity = (ObjectRarity)packet.ReadByte();

        return result;
    }

    /// <summary>
    ///     Pickups the specified item unique identifier.
    /// </summary>
    /// <param name="itemUniqueId">The item unique identifier.</param>
    /// F
    public bool Pickup()
    {
        if (IsBehindObstacle)
            return false;

        if (Game.Player.InAction)
            return false;

        var packet = new Packet(0x7074);
        packet.WriteByte(ActionCommandType.Execute);
        packet.WriteByte(ActionType.Pickup);
        packet.WriteByte(ActionTarget.Entity);
        packet.WriteUInt(UniqueId);

        var asyncResult = new AwaitCallback(
            response =>
            {
                var actionState = (ActionState)response.ReadByte();
                var repeatAction = response.ReadBool();

                Log.Debug($"Picked up item response: State={actionState} Repeat={repeatAction}");

                return actionState is ActionState.Begin or ActionState.End
                    ? AwaitCallbackResult.Success
                    : AwaitCallbackResult.ConditionFailed;
            },
            0xB074
        );

        Log.Status("Picking up...");
        PacketManager.SendPacket(packet, PacketDestination.Server, asyncResult);
        asyncResult.AwaitResponse(500);
        Log.StatusLang("Ready");

        return asyncResult.IsCompleted;
    }
}
