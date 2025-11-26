using RSBot.Core.Components;
using RSBot.Core.Event;
using RSBot.Core.Objects;

namespace RSBot.Core.Network.Handler.Agent.Action;

internal class ActionItemPerkAddResponse : IPacketHandler
{
    /// <summary>
    ///     Invokes the specified packet.
    /// </summary>
    /// <param name="packet">The packet.</param>
    public void Invoke(Packet packet)
    {
        var targetId = packet.ReadUInt();
        var refObjItemId = packet.ReadUInt();
        var token = packet.ReadUInt();
        var value = packet.ReadUInt();
        var remainingTime = packet.ReadUInt();

        if (!SpawnManager.TryGetEntityIncludingMe(targetId, out var target))
            return;

        if (target.State.ActiveItemPerks.ContainsKey(token))
        {
            target.State.ActiveItemPerks[token].Value = value;
            target.State.ActiveItemPerks[token].RemainingTime = remainingTime;

            EventManager.FireEvent("OnUpdateItemPerk", targetId, token);
        }
        else
        {
            target.State.ActiveItemPerks.Add(
                token,
                new ItemPerk
                {
                    ItemId = refObjItemId,
                    RemainingTime = remainingTime,
                    Value = value,
                }
            );

            EventManager.FireEvent("OnAddItemPerk", targetId, token);
        }
    }

    #region Properites

    /// <summary>
    ///     Gets or sets the opcode.
    /// </summary>
    /// <value>
    ///     The opcode.
    /// </value>
    public ushort Opcode => 0x325F;

    /// <summary>
    ///     Gets or sets the destination.
    /// </summary>
    /// <value>
    ///     The destination.
    /// </value>
    public PacketDestination Destination => PacketDestination.Client;

    #endregion Properites
}
