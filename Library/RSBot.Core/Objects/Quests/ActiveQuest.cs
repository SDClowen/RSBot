using RSBot.Core.Client.ReferenceObjects;

namespace RSBot.Core.Objects.Quests;

public struct ActiveQuest
{
    public uint Id;
    public int AchievementAmount;
    public int RequiredShareParty;

    public byte Unknown1;
    public byte Unknown2;

    public QuestType Type;
    public int RemainingTime;
    public QuestStatus Status;
    public QuestObjective[] Objectives;
    public uint[] Npcs;
    public RefQuest Quest => Game.ReferenceManager.GetRefQuest(Id);
}
