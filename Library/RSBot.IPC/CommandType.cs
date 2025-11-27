namespace RSBot.IPC
{
    public enum CommandType
    {
        RegisterBot, // Added for bot registration
        Stop,
        Start,
        GetInfo,
        SetVisibility,
        GoClientless,
        LaunchClient,
        KillClient,
        SetOptions,
        CreateAutologin,
        SelectAutologin,
        CopyProfile,
        Move,
        SpecifyTrainingArea,
        SelectBotbase,
        ReturnToTown
    }
}
