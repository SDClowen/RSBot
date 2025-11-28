namespace RSBot.IPC
{
    public enum CommandType
    {
        RegisterBot,
        Stop,
        Start,
        GetInfo,
        SetVisibility,
        GoClientless,
        SetClientVisibility,
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
