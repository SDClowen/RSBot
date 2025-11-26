using RSBot.Core;
using RSBot.Core.Components;
using RSBot.Core.Components.Command;
using RSBot.Core.Objects;

namespace RSBot.CommandCenter.Components.Command;

internal class BuffCommandExecutor : ICommandExecutor
{
    public string CommandName => "buff";

    public string CommandDescription => "Cast all buffs";

    public bool Execute(bool silent)
    {
        if (!silent)
            Game.ShowNotification("[RSBot] Casting all buffs");

        var buffs = SkillManager.Buffs.FindAll(p => !Game.Player.State.HasActiveBuff(p, out _) && p.CanBeCasted);
        if (buffs.Count == 0)
            return true;

        Log.Status("Buffing");

        foreach (var buff in buffs)
        {
            if (
                Game.Player.State.LifeState != LifeState.Alive
                || Game.Player.HasActiveVehicle
                || Game.Player.Untouchable
            )
                break;

            Log.Debug($"[ActionMapper] Casting buff {buff} ({buff.Record.Basic_Code})");

            buff.Cast(buff: true);
        }

        return true;
    }
}
