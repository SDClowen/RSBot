namespace RSBot.Core.Objects.Quests
{
    public struct ActiveQuest
    {
        public int QuestId;
        public int AchievementAmount;
        public int RequiredShareParty;

        public byte Unknown1;
        public byte Unknown2;

        public byte Type;
        public int RemainingTime;
        public byte State;
        public QuestObjective[] Objectives;
        public uint[] Npcs;
    }
}
