using RSBot.Core.Network;

namespace RSBot.Core.Objects.Quests;

public class Quest
{
    public uint[] CompletedQuests;
    public ActiveQuest[] ActiveQuests;

    public static Quest FromPacket(Packet packet)
    {
        var result = new Quest();
        result.ParseCompletedQuests(packet);
        result.ParseActiveQuests(packet);

        return result;
    }


    public void ParseCompletedQuests(Packet packet)
    {
        var count = packet.ReadUShort();
        CompletedQuests = new uint[count];

        for (int i = 0; i < count; i++)
            CompletedQuests[i] = packet.ReadUInt();
    }

    public void ParseActiveQuests(Packet packet)
    {
        var count = packet.ReadByte();
        ActiveQuests = new ActiveQuest[count];

        for (int i = 0; i < count; i++)
        {
            var activeQuest = new ActiveQuest();
            activeQuest.QuestId = packet.ReadInt();

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

            if (Game.ClientType > GameClientType.Chinese)
            {
                activeQuest.Unknown1 = packet.ReadByte();
                activeQuest.Unknown2 = packet.ReadByte();
            }

            activeQuest.Type = packet.ReadByte();

            if (activeQuest.Type == 28 || activeQuest.Type == 92)
                activeQuest.RemainingTime = packet.ReadInt();

            activeQuest.State = packet.ReadByte();

            if (activeQuest.Type != 8)
            {
                var objectiveAmount = packet.ReadByte();
                activeQuest.Objectives = new QuestObjective[objectiveAmount];
                for (int j = 0; j < objectiveAmount; j++)
                {
                    QuestObjective objective;
                    objective.Id = packet.ReadByte();
                    objective.State = packet.ReadByte();
                    objective.CharacterName = packet.ReadString();

                    var taskCount = packet.ReadByte();
                    objective.Tasks = packet.ReadUIntArray(taskCount);

                    activeQuest.Objectives[j] = objective;
                }
            }

            if (activeQuest.Type == 88 || activeQuest.Type == 92)
            {
                var npcAmount = packet.ReadByte();
                activeQuest.Npcs = packet.ReadUIntArray(npcAmount);
            }

            ActiveQuests[i] = activeQuest;
        }
    }
}