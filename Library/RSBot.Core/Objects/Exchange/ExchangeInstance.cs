using System.Collections.Generic;
using RSBot.Core.Components;
using RSBot.Core.Network;
using RSBot.Core.Objects.Spawn;

namespace RSBot.Core.Objects.Exchange;

public class ExchangeInstance
{
    #region Fields

    private readonly uint _exchangePlayerUniqueId;

    #endregion Fields

    /// <summary>
    ///     Initializes a new instance of the <see cref="ExchangeInstance" /> class.
    /// </summary>
    /// <param name="exchangePlayerUniqueId">The exchange player unique identifier.</param>
    public ExchangeInstance(uint exchangePlayerUniqueId)
    {
        _exchangePlayerUniqueId = exchangePlayerUniqueId;
    }

    /// <summary>
    ///     Gets the receiving items.
    /// </summary>
    /// <value>
    ///     The receiving items.
    /// </value>
    public List<ExchangeItem> ReceivingItems { get; private set; }

    /// <summary>
    ///     Gets the sending items.
    /// </summary>
    /// <value>
    ///     The sending items.
    /// </value>
    public List<ExchangeItem> SendingItems { get; private set; }

    /// <summary>
    ///     Gets the exchange player.
    /// </summary>
    /// <value>
    ///     The exchange player.
    /// </value>
    public SpawnedPlayer ExchangePlayer => SpawnManager.GetEntity<SpawnedPlayer>(_exchangePlayerUniqueId);

    /// <summary>
    ///     Updates the items.
    /// </summary>
    /// <param name="packet">The packet.</param>
    public void UpdateItems(Packet packet)
    {
        var ownerUniqueId = packet.ReadUInt();
        var playerIsSender = ownerUniqueId == Game.Player.UniqueId;

        if (playerIsSender)
            SendingItems = new List<ExchangeItem>(12);
        else
            ReceivingItems = new List<ExchangeItem>(12);

        var itemCount = packet.ReadByte();
        for (var i = 0; i < itemCount; i++)
        {
            var item = ExchangeItem.FromPacket(packet, playerIsSender);

            if (item.Item == null)
            {
                Log.Debug($"Could not detect item at exchange slot #{item.ExchangeSlot}");
                continue;
            }

            if (playerIsSender)
                SendingItems.Add(item);
            else
                ReceivingItems.Add(item);
        }
    }

    /// <summary>
    ///     Completes the exchange request. It updates the inventory item by the temporary stored information.
    /// </summary>
    public void Complete()
    {
        if (ReceivingItems == null)
            return;

        foreach (var item in ReceivingItems)
        {
            item.Item.Slot = Game.Player.Inventory.GetFreeSlot();
            Game.Player.Inventory.Add(item.Item);
        }

        if (SendingItems != null)
            foreach (var item in SendingItems)
                Game.Player.Inventory.RemoveAt(item.SourceSlot);
    }
}
