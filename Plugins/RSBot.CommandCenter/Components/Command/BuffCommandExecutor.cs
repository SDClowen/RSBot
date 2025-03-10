using RSBot.Core;
using RSBot.Core.Components;
using RSBot.Core.Components.Command;
using RSBot.Core.Objects;

namespace RSBot.CommandCenter.Avalonia.Components.Command;

/// <summary>
/// Executes the buff command to toggle buff mode
/// </summary>
internal class BuffCommandExecutor : ICommandExecutor
{
    /// <summary>
    /// Gets the name of the command
    /// </summary>
    public string CommandName => "buff";

    /// <summary>
    /// Gets the description of the command
    /// </summary>
    public string CommandDescription => "Toggle buff mode";

    /// <summary>
    /// Executes the buff command
    /// </summary>
    public bool Execute(bool silent = false)
    {
        if (!silent)
            Game.ShowNotification("[RSBot] Casting all buffs");

        var buffs = SkillManager.Buffs.FindAll(p => !Game.Player.State.HasActiveBuff(p, out _) && p.CanBeCasted);
        if (buffs.Count == 0)
            return true;

        Log.Status("Buffing");

        foreach (var buff in buffs)
        {
            if (Game.Player.State.LifeState != LifeState.Alive || Game.Player.HasActiveVehicle ||
                Game.Player.Untouchable)
                break;

            Log.Debug($"[ActionMapper] Casting buff {buff} ({buff.Record.Basic_Code})");

            buff.Cast(buff: true);
        }

        return true;
    }
} 