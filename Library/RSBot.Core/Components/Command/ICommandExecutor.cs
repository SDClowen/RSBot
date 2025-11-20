namespace RSBot.Core.Components.Command;

public interface ICommandExecutor
{
    public string CommandName { get; }

    public string CommandDescription { get; }

    public bool Execute(bool silent = false);
}
