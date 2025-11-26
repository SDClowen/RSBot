using RSBot.Core;
using RSBot.Core.Client.ReferenceObjects;

namespace RSBot.Alchemy.Client.ReferenceObjects;

internal static class RefMagicOptExtension
{
    #region Methods

    /// <summary>
    ///     Returns the translation of the group
    /// </summary>
    /// <returns></returns>
    public static string GetGroupTranslation(this RefMagicOpt magicOption)
    {
        var translationGroup = magicOption.Group?.Replace("MATTR", "PARAM").Replace("AVATAR_", "") ?? $"Error, ";

        switch (translationGroup)
        {
            case "PARAM_RESIST_FROSTBITE":
                translationGroup = "PARAM_COLD_RESIST";
                break;

            case "PARAM_RESIST_ZOMBIE":
                translationGroup = "PARAM_ZOMBI_RESIST";
                break;

            case "PARAM_RESIST_BURN":
                translationGroup = "PARAM_BURN_RESIST";
                break;

            case "PARAM_RESIST_ESHOCK":
                translationGroup = "PARAM_ESHOCK_RESIST";
                break;

            case "PARAM_RESIST_POISON":
                translationGroup = "PARAM_POISON_RESIST";
                break;

            case "PARAM_EVADE_BLOCK":
                translationGroup = "PARAM_IGNORE_BLOCKING";
                break;
        }

        return Game.ReferenceManager.GetTranslation(translationGroup);
    }

    /// <summary>
    ///     Returns the translation used when the fusion succeeded
    /// </summary>
    /// <param name="value">The value used in the formatted string</param>
    /// <returns>The translated string</returns>
    public static string GetFusingTranslation(this RefMagicOpt magicOption, uint value)
    {
        //TODO: Use and extend GetGroupTranslation instead of hard coding this
        switch (magicOption?.Group)
        {
            case "MATTR_INT":
            case "MATTR_AVATAR_INT":
            case "MATTR_INT_AVATAR":
                return $"Int {value} Increase";

            case "MATTR_STR":
            case "MATTR_STR_AVATAR":
            case "MATTR_AVATAR_STR":
                return $"Str {value} Increase";

            case "MATTR_DUR":
            case "MATTR_AVATAR_DRUA":
                return $"Durability {value}% Increase";

            case "MATTR_EVADE_BLOCK":
                return $"Blocking rate {value}";

            case "MATTR_AVATAR_DARA":
                return $"Damage Absorption {value}% Increase";

            case "MATTR_AVATAR_ER":
            case "MATTR_ER":
                return $"Parry rate {value}% Increase";

            case "MATTR_HR":
            case "MATTR_AVATAR_HR":
                return $"Attack rate {value}% Increase";

            case "MATTR_RESIST_FROSTBITE":
                return $"Freezing,FrostbiteHour {value}% Reduce";

            case "MATTR_RESIST_ESHOCK":
                return $"Electrict shockHour {value}% Reduce";

            case "MATTR_RESIST_BURN":
                return $"BurnHour {value}% Reduce";

            case "MATTR_RESIST_POISON":
                return $"PoisoningHour {value}% Reduce";

            case "MATTR_LUCK":
                return $"Lucky({value}Time/times)";

            case "MATTR_SOLID":
                return $"Steady({value}Time/times)";
                ;
            case "MATTR_ASTRAL":
                return $"Astral({value}Time/times)";

            case "MATTR_ATHANASIA":
                return $"Immortal({value}Time/times)";

            case "MATTR_AVATAR_MDIA":
            case "MATTR_AVATAR_MDIA_2":
            case "MATTR_AVATAR_MDIA_3":
            case "MATTR_AVATAR_MDIA_4":
                return $"Ignore Monster Defense {value}% Probability";

            case "MATTR_HP":
            case "MATTR_AVATAR_HP":
                return $"HP {value} Increase";

            case "MATTR_MP":
            case "MATTR_AVATAR_MP":
                return $"MP {value} Increase";

            case "MATTR_CRITICAL":
            case "MATTR_EVADE_CRITICAL":
                return $"Critical {value}";

            case "MATTR_NOT_REPARABLE":
                return "Not repairable";

            case "MATTR_REGENHPMP":
                return $"HP recovery/MP recovery {value}% Increase";

            case "MATTR_RESIST_ZOMBIE":
                return $"ZombieHour {value}% Reduce";

            case "MATTR_RESIST_CSMP":
                return $"CombustionProbability {value}% Reduce";

            case "MATTR_RESIST_SLEEP":
                return $"SleepProbability {value}% Reduce";

            case "MATTR_RESIST_STUN":
                return $"StunProbability {value}% Reduce";

            case "MATTR_RESIST_FEAR":
                return $"FearProbability {value}% Reduce";

            case "MATTR_RESIST_DISEASE":
                return $"DiseaseProbability {value}% Reduce";

            case "MATTR_DEC_MAXDUR":
                return $"Maximum durability {value}% Reduce";
        }

        return magicOption?.Group ?? $"Error. Mag. opt. value: {value}";
    }

    #endregion Methods
}
