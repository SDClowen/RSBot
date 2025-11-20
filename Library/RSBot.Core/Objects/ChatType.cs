namespace RSBot.Core.Objects;

public enum ChatType
{
    All = 1,
    Private = 2,
    AllGM = 3,
    Party = 4,
    Guild = 5,
    Global = 6,
    Notice = 7,
    Stall = 9,
    Union = 11,
    Npc = 13, //taken from Cerberus (able to talk SN_TALK_QNO_EU_EASTEU_21_14 stuff)
    Academy = 16,
}
