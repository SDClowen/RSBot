using RSBot.Core.Event;

namespace RSBot.Core.Network.Handler.Agent.Quest;

internal class QuestAbandonResponse : IPacketHandler
{
    /// <summary>
    ///     Gets or sets the opcode.
    /// </summary>
    /// <value>
    ///     The opcode.
    /// </value>
    public ushort Opcode => 0xB0D9;

    /// <summary>
    ///     Gets or sets the destination.
    /// </summary>
    /// <value>
    ///     The destination.
    /// </value>
    public PacketDestination Destination => PacketDestination.Client;

    /// <summary>
    ///     Handles the packet.
    /// </summary>
    /// <param name="packet">The packet.</param>
    public void Invoke(Packet packet)
    {
        if (packet.ReadByte() == 0x01)
        {
            var questId = packet.ReadUInt();

            if (!Game.Player.QuestLog.ActiveQuests.TryGetValue(questId, out var playerQuest))
                return;

            Game.Player.QuestLog.ActiveQuests.Remove(questId);

            Log.Notify($"Abandoned quest [{playerQuest.Quest.GetTranslatedName()}]");
        }

        EventManager.FireEvent("OnUpdateQuests");
    }
}
