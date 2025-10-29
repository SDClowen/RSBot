using RSBot.Core;
using RSBot.Core.Components;
using RSBot.Core.Components.Command;

namespace RSBot.CommandCenter.Components.Command;

internal class BuffCommandExecutor : ICommandExecutor
{
    public string CommandName => "buff";

    public string CommandDescription => "Cast all buffs";

    public bool Execute(bool silent)
    {
        if (!silent)
            Game.ShowNotification("[RSBot] Casting all buffs");

        // Merkezi buff basma metodunu çağır.
        SkillManager.CastAvailableBuffs();

        return true;
    }
}
