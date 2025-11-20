using System.Collections.Generic;
using RSBot.Core.Network;

namespace RSBot.Core.Objects.Quests;

public class QuestLog
{
    public Dictionary<uint, ActiveQuest> ActiveQuests;
    public uint[] CompletedQuests;

    public static QuestLog FromPacket(Packet packet)
    {
        var result = new QuestLog();
        result.ParseCompletedQuests(packet);
        result.ParseActiveQuests(packet);

        return result;
    }

    public void ParseCompletedQuests(Packet packet)
    {
        var count = packet.ReadUShort();
        CompletedQuests = new uint[count];

        for (var i = 0; i < count; i++)
            CompletedQuests[i] = packet.ReadUInt();
    }

    public void ParseActiveQuests(Packet packet)
    {
        var count = packet.ReadByte();
        ActiveQuests = new Dictionary<uint, ActiveQuest>(count);

        for (var i = 0; i < count; i++)
        {
            var questId = packet.ReadUInt();
            var activeQuest = ParseActiveQuest(packet, questId);

            ActiveQuests.TryAdd(activeQuest.Id, activeQuest);
        }
    }

    public void AbandonQuest(uint questId)
    {
        if (!ActiveQuests.ContainsKey(questId))
            return;

        var packet = new Packet(0x70D9);
        packet.WriteUInt(questId);

        var callback = new AwaitCallback(null, 0xB0D9);
        PacketManager.SendPacket(packet, PacketDestination.Server, callback);

        callback.AwaitResponse();
    }

    public static ActiveQuest ParseActiveQuest(Packet packet, uint questId)
    {
        var activeQuest = new ActiveQuest { Id = questId };

        if (Game.ClientType == GameClientType.Vietnam274)
        {
            activeQuest.AchievementAmount = packet.ReadUShort();
            activeQuest.RequiredShareParty = packet.ReadUShort();
        }
        else
        {
            activeQuest.AchievementAmount = packet.ReadByte();
            activeQuest.RequiredShareParty = packet.ReadByte();
        }

        if (Game.ClientType >= GameClientType.Chinese)
        {
            activeQuest.Unknown1 = packet.ReadByte();
            activeQuest.Unknown2 = packet.ReadByte();
        }

        activeQuest.Type = (QuestType)packet.ReadByte();

        if ((activeQuest.Type & QuestType.Time) == QuestType.Time)
            activeQuest.RemainingTime = packet.ReadInt();

        if ((activeQuest.Type & QuestType.Status) == QuestType.Status)
            activeQuest.Status = (QuestStatus)packet.ReadByte();

        if ((activeQuest.Type & QuestType.Objective) == QuestType.Objective)
        {
            var objectiveCount = packet.ReadByte();
            activeQuest.Objectives = new QuestObjective[objectiveCount];

            for (var i = 0; i < objectiveCount; i++)
            {
                var objective = new QuestObjective
                {
                    Id = packet.ReadByte(),
                    InProgress = packet.ReadBool(),
                    NameStrId = packet.ReadString(),
                    Tasks = packet.ReadUIntArray(packet.ReadByte()),
                };

                activeQuest.Objectives[i] = objective;
            }
        }

        if ((activeQuest.Type & QuestType.RefObjects) == QuestType.RefObjects)
            activeQuest.Npcs = packet.ReadUIntArray(packet.ReadByte());

        //var typeFlags = (byte)activeQuest.Type;

        //if (typeFlags == 28 || typeFlags == 92)
        //    activeQuest.RemainingTime = packet.ReadInt();

        //activeQuest.Status = (QuestStatus)packet.ReadByte();

        //if (typeFlags != 8)
        //{
        //    var objectiveAmount = packet.ReadByte();
        //    activeQuest.Objectives = new QuestObjective[objectiveAmount];
        //    for (int j = 0; j < objectiveAmount; j++)
        //    {
        //        QuestObjective objective;
        //        objective.Id = packet.ReadByte();
        //        objective.InProgress = packet.ReadBool();
        //        objective.NameStrId = packet.ReadString();

        //        var taskCount = packet.ReadByte();
        //        objective.Tasks = packet.ReadUIntArray(taskCount);

        //        activeQuest.Objectives[j] = objective;
        //    }
        //}

        //if (typeFlags is 88 or 92)
        //{
        //    var npcAmount = packet.ReadByte();
        //    activeQuest.Npcs = packet.ReadUIntArray(npcAmount);
        //}

        return activeQuest;
    }
}
