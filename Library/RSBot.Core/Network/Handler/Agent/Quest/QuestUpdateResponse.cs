using RSBot.Core.Event;
using RSBot.Core.Objects.Quests;

namespace RSBot.Core.Network.Handler.Agent.Quest;

internal class QuestUpdateResponse : IPacketHandler
{
    /// <summary>
    ///     Gets or sets the opcode.
    /// </summary>
    /// <value>
    ///     The opcode.
    /// </value>
    public ushort Opcode => 0x30D5;

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
        var type = (QuestUpdateType)packet.ReadByte();
        var questId = packet.ReadUInt();

        var quest = Game.ReferenceManager.GetRefQuest(questId);
        if (quest == null)
        {
            Log.Warn($"QuestLog with id {questId} not found!");

            return;
        }

        if (type == QuestUpdateType.Abandon)
        {
            Log.Notify($"Abandon quest [{quest.GetTranslatedName()}]");

            if (!Game.Player.QuestLog.ActiveQuests.TryGetValue(questId, out var playerQuest))
                return;

            playerQuest.Status = QuestStatus.Cancelled;
        }

        if (type == QuestUpdateType.Remove)
        {
            Log.Notify($"Remove quest [{quest.GetTranslatedName()}");

            Game.Player.QuestLog.ActiveQuests.Remove(questId);
        }

        if (type == QuestUpdateType.Add)
        {
            var activeQuest = QuestLog.ParseActiveQuest(packet, questId);
            Game.Player.QuestLog.ActiveQuests.TryAdd(questId, activeQuest);

            Log.Notify($"Added quest [{activeQuest.Quest.GetTranslatedName()}");
        }

        if (type == QuestUpdateType.Update)
        {
            var activeQuest = QuestLog.ParseActiveQuest(packet, questId);

            Game.Player.QuestLog.ActiveQuests[questId] = activeQuest;

            Log.Debug($"Updated quest [{activeQuest.Quest.GetTranslatedName()}");
        }

        EventManager.FireEvent("OnUpdateQuests");
    }
}
