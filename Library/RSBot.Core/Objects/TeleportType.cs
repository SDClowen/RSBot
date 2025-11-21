namespace RSBot.Core.Objects;

public enum TeleportType : byte
{
    Return = 1,
    Destination = 2,
    RUNTIME_PORTAL = 3, //CREATE_RUNTIME_PORTAL (Trigger)
    Guide = 5,
}
