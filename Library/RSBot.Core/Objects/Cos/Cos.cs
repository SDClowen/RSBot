using System;
using System.Threading;
using System.Threading.Tasks;
using RSBot.Core.Components;
using RSBot.Core.Network;
using RSBot.Core.Objects.Inventory;
using RSBot.Core.Objects.Spawn;

namespace RSBot.Core.Objects.Cos;

public class Cos : SpawnedEntity
{
    /// <summary>
    ///     Gets or sets the owner unique identifier.
    /// </summary>
    /// <value>
    ///     The owner unique identifier.
    /// </value>
    public uint OwnerUniqueId { get; set; }

    /// <summary>
    ///     Gets or sets the name.
    /// </summary>
    /// <value>
    ///     The name.
    /// </value>
    public string Name { get; set; }

    /// <summary>
    ///     Gets or sets the level.
    /// </summary>
    /// <value>
    ///     The level.
    /// </value>
    public byte Level { get; set; } = 1;

    /// <summary>
    ///     Gets or sets the health.
    /// </summary>
    /// <value>
    ///     The health.
    /// </value>
    public int Health { get; set; }

    /// <summary>
    ///     Gets or sets the maximum health.
    /// </summary>
    /// <value>
    ///     The maximum health.
    /// </value>
    public int MaxHealth { get; set; }

    /// <summary>
    ///     Gets or sets the settings.
    /// </summary>
    /// <value>
    ///     The settings.
    /// </value>
    public int Settings { get; set; }

    /// <summary>
    ///     Gets or sets a value indicating whether this instance has health.
    /// </summary>
    /// <value>
    ///     <c>true</c> if this instance has health; otherwise, <c>false</c>.
    /// </value>
    public bool HasHealth => Health > 0;

    /// <summary>
    ///     Gets or sets the experience.
    /// </summary>
    /// <value>
    ///     The experience.
    /// </value>
    public long Experience { get; set; }

    /// <summary>
    ///     Gets the maximum experience.
    /// </summary>
    /// <value>
    ///     The maximum experience.
    /// </value>
    public virtual long MaxExperience => Game.ReferenceManager.GetRefLevel(Level).Exp_C;

    /// <summary>
    ///     Gets or sets the bad effect.
    /// </summary>
    /// <value>
    ///     The bad effect.
    /// </value>
    public BadEffect BadEffect { get; set; }

    /// <summary>
    ///     Gets or sets the AbilityPet's Inventory.
    /// </summary>
    /// <value>
    ///     The AbilityPet's Inventory.
    /// </value>
    public InventoryItemCollection Inventory { get; set; }

    /// <summary>
    ///     Gets or sets the bionic.
    /// </summary>
    /// <value>
    ///     The bionic.
    /// </value>
    public SpawnedBionic Bionic => SpawnManager.GetEntity<SpawnedBionic>(UniqueId);

    /// <summary>
    ///     Uses the health potion.
    /// </summary>
    /// <returns></returns>
    public virtual bool UseHealthPotion()
    {
        var usingItem = Game.Player.Inventory.GetItem(p => p.Record.IsCosHpPotion);
        if (usingItem == null)
            return false;

        usingItem.UseFor(UniqueId);

        return true;
    }

    /// <summary>
    ///     Uses the bad status potion.
    /// </summary>
    /// <returns></returns>
    public virtual bool UseBadStatusPotion()
    {
        var typeIdFilter = new TypeIdFilter(3, 3, 2, 7);
        var item = Game.Player.Inventory.GetItem(typeIdFilter);
        if (item == null)
            return false;

        item.UseFor(UniqueId);

        return true;
    }

    public virtual bool Mount()
    {
        var packet = new Packet(0x70CB);
        packet.WriteByte(1);
        packet.WriteInt(UniqueId);
        PacketManager.SendPacket(packet, PacketDestination.Server);

        return true;
    }

    public virtual bool Dismount()
    {
        var packet = new Packet(0x70CB);
        packet.WriteByte(0);
        packet.WriteInt(UniqueId);

        var awaitCallback = new AwaitCallback(
            response =>
            {
                var result = response.ReadByte();

                return result == 1 ? AwaitCallbackResult.Success : AwaitCallbackResult.Fail;
            },
            0xB0CB
        );

        PacketManager.SendPacket(packet, PacketDestination.Server, awaitCallback);
        awaitCallback.AwaitResponse();

        return true;
    }

    public virtual bool Terminate()
    {
        var packet = new Packet(0x70C6);
        packet.WriteInt(UniqueId);

        var awaitCallback = new AwaitCallback(
            response =>
            {
                return response.ReadByte() == 1 ? AwaitCallbackResult.Success : AwaitCallbackResult.ConditionFailed;
            },
            0xB0C6
        );

        PacketManager.SendPacket(packet, PacketDestination.Server, awaitCallback);
        awaitCallback.AwaitResponse();

        return awaitCallback.IsCompleted;
    }

    /// <summary>
    ///     Pickups the specified item unique identifier.
    /// </summary>
    /// <param name="itemUniqueId">The item unique identifier.</param>
    /// <returns>true if item is grabbed by pet.</returns>
    public virtual async Task<bool> PickupAsync(uint itemUniqueId)
    {
        var packet = new Packet(0x70C5);
        packet.WriteUInt(UniqueId);
        packet.WriteByte(CosCommand.Pickup);
        packet.WriteUInt(itemUniqueId);

        var predicate = new AwaitCallbackPredicate(response =>
        {
            var result = response.ReadByte();

            if (response.Opcode == 0xB034)
            {
                var type = (InventoryOperation)response.ReadByte();
                if (type != InventoryOperation.SP_PICK_ITEM_BY_OTHER)
                    return AwaitCallbackResult.ConditionFailed;

                return response.ReadUInt() == UniqueId
                    ? AwaitCallbackResult.Success
                    : AwaitCallbackResult.ConditionFailed;
            }

            if (response.Opcode == 0xB0C5)
            {
                var command = (CosCommand)response.ReadByte();
                if (command == CosCommand.Pickup)
                {
                    switch (result)
                    {
                        case 1:
                            if (response.ReadUInt() == UniqueId && response.ReadUInt() == itemUniqueId)
                                return AwaitCallbackResult.Success;
                            break;

                        case 2:
                            ushort errorCode = response.ReadUShort();
                            if (errorCode == 3) // 3 - stolen or disappeared; 6297 - stuck
                                return AwaitCallbackResult.Success;
                            break;
                    }
                }
                return AwaitCallbackResult.ConditionFailed;
            }

            return AwaitCallbackResult.Fail;
        });

        var callbackItemGrabbed = new AwaitCallback(predicate, 0xB034);
        var callbackItemStolen = new AwaitCallback(predicate, 0xB0C5);

        PacketManager.SendPacket(packet, PacketDestination.Server, callbackItemGrabbed, callbackItemStolen);

        using var cts = new CancellationTokenSource();

        var task1 = callbackItemGrabbed.AwaitResponseAsync(cancellationToken: cts.Token);
        var task2 = callbackItemStolen.AwaitResponseAsync(cancellationToken: cts.Token);

        await Task.WhenAny(task1, task2);

        cts.Cancel();

        return callbackItemGrabbed.IsCompleted || callbackItemStolen.IsCompleted;
    }

    /// <summary>
    ///     Moves this instance.
    /// </summary>
    public void MoveTo(Position destination, bool sleep = true)
    {
        var packet = new Packet(0x70C5);
        packet.WriteUInt(UniqueId);
        packet.WriteByte(CosCommand.Move); //Move
        packet.WriteByte(1); //To point
        packet.WriteUShort(destination.Region);

        //Normal world
        if (!destination.Region.IsDungeon)
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

        var awaitCallback = new AwaitCallback(
            response =>
                response.ReadUInt() == UniqueId ? AwaitCallbackResult.Success : AwaitCallbackResult.ConditionFailed,
            0xB021
        );

        PacketManager.SendPacket(packet, PacketDestination.Server, awaitCallback);
        awaitCallback.AwaitResponse();
        var distance = Game.Player.Movement.Source.DistanceTo(destination);
        //Wait to finish the step
        if (sleep)
        {
            var vehicle = Game.Player.Vehicle;
            if (vehicle != null && SpawnManager.TryGetEntity<SpawnedCos>(vehicle.UniqueId, out SpawnedCos spawnedCos))
            {
                Thread.Sleep(Convert.ToInt32(distance / spawnedCos.ActualSpeed * 10000));
            }
            else
            {
                Thread.Sleep(Convert.ToInt32(distance / Game.Player.ActualSpeed * 10000));
            }
        }
    }

    /// <summary>
    ///     Casts a skill on the player
    /// </summary>
    /// <param name="codeName">Skill code name</param>
    public void CastSkill(string codeName)
    {
        var packet = new Packet(0x70C5);
        packet.WriteUInt(UniqueId);
        packet.WriteByte(CosCommand.Cast);
        packet.WriteUInt(Game.ReferenceManager.GetRefSkill(codeName).ID);
        packet.WriteUInt(Game.Player.UniqueId);

        PacketManager.SendPacket(packet, PacketDestination.Server);
    }

    /// <summary>
    ///     Purchases the item.
    /// </summary>
    /// <param name="tab">The tab.</param>
    /// <param name="slot">The slot.</param>
    /// <param name="amount">The amount.</param>
    public bool PurchaseItemFromNpc(int tab, int slot, ushort amount)
    {
        var npc = Game.SelectedEntity;
        if (npc == null)
        {
            Log.Debug("Cannot buy items for cos, because no shop is selected!");
            return false;
        }

        var packet = new Packet(0x7034);
        packet.WriteByte(InventoryOperation.SP_BUY_ITEM_COS); //Buy item flag
        packet.WriteUInt(UniqueId);
        packet.WriteByte(tab);
        packet.WriteByte(slot);
        packet.WriteUShort(amount);
        packet.WriteUInt(npc.UniqueId);

        var awaitResult = new AwaitCallback(
            packet => packet.ReadByte() == 1 ? AwaitCallbackResult.Success : AwaitCallbackResult.Fail,
            0xB034
        );
        PacketManager.SendPacket(packet, PacketDestination.Server, awaitResult);

        awaitResult.AwaitResponse();

        return awaitResult.IsCompleted;
    }

    /// <summary>
    ///     Sells the item from pet.
    /// </summary>
    /// <param name="item">The item.</param>
    public bool SellItemToNpc(byte slot)
    {
        var item = Inventory.GetItemAt(slot);
        if (item == null)
            return false;

        var entity = Game.SelectedEntity;
        if (entity == null)
            return false;

        var packet = new Packet(0x7034);
        packet.WriteByte(InventoryOperation.SP_SELL_ITEM_COS);
        packet.WriteInt(UniqueId);
        packet.WriteByte(item.Slot);
        packet.WriteUShort(item.Amount);
        packet.WriteUInt(entity.UniqueId);

        var awaitResult = new AwaitCallback(
            packet =>
            {
                return packet.ReadByte() == 1 ? AwaitCallbackResult.Success : AwaitCallbackResult.Fail;
            },
            0xB034
        );
        PacketManager.SendPacket(packet, PacketDestination.Server, awaitResult);
        awaitResult.AwaitResponse();

        Log.Debug("Sold item (pet): " + item.Record.GetRealName());

        return awaitResult.IsCompleted;
    }

    public virtual void Deserialize(Packet packet) { }

    public override bool Update(int delta)
    {
        base.Update(delta);

        if (Bionic == null)
            return false;

        Movement = Bionic.Movement;

        return true;
    }
}
