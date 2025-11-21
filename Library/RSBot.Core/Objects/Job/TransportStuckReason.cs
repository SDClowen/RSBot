namespace RSBot.Core.Objects.Job;

public enum TransportStuckReason : byte
{
    //UIIT_MSG_COSERR_TOO_FAR_FROM_TRADECART
    TransportDistance = 1,

    //UIIT_MSG_QUEST_ERR_TOO_FAR_FROM_MONSTER
    CapturedDistance = 2,
}
