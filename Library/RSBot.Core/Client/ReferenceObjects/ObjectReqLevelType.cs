namespace RSBot.Core.Client.ReferenceObjects;

public enum ObjectReqLevelType
{
    None = -1,
    Character = 1, //캐릭터
    MasteryTrader = 2, //상인마스터리
    MasteryTief = 3, //도적마스터리
    MasteryHunter = 4, //헌터마스터리

    Pet2System = 5,

    GuildLevel = 10,

    //European clothing limitation
    MasteryWarrior = 513, //워리어201
    MasteryRogue = 515, //로그203
    MasteryWizard = 514, //위저드202
    MasteryWarlock = 516, //워락204
    MasteryBard = 517, //바드205
    MasteryCleric = 518, //클레릭206
}
