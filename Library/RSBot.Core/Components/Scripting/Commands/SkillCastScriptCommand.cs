using System.Collections.Generic;

namespace RSBot.Core.Components.Scripting.Commands;

internal class SkillCastScriptCommand : IScriptCommand
{
    public bool Execute(string[] arguments = null)
    {
        if (arguments == null || arguments.Length != Arguments.Count)
            return false;

        try
        {
            IsBusy = true;

            if (Game.Player.HasActiveVehicle)
            {
                Log.Warn("[Script] Cast skill command failed: Player is on a vehicle.");

                return false;
            }

            var skillCodeName = arguments[0];
            var skill = Game.Player.Skills.GetSkillByCodeName(skillCodeName);

            if (skill == null)
            {
                Log.Warn("[Script] Cast skill command failed: Skill not known.");

                return false;
            }

            SkillManager.CastBuff(skill);
        }
        finally
        {
            IsBusy = false;
        }

        return true;
    }

    public void Stop()
    {
        IsBusy = false;
    }

    #region Properties

    public string Name => "cast";

    public bool IsBusy { get; private set; }

    public Dictionary<string, string> Arguments => new() { { "SkillId", "The Id of the skill to be cast" } };

    #endregion Properties
}
