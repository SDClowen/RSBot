using System;
using RSBot.Core.Objects;

namespace RSBot.Core.Extensions;

public static class AttributesInfoExtension
{
    /// <summary>
    ///     Gets the translation that is being displayed in game for the specified attribute.
    /// </summary>
    /// <param name="group">The group to be translated.</param>
    /// <returns></returns>
    public static string GetTranslation(this ItemAttributeGroup group)
    {
        return Game.ReferenceManager.GetTranslation(GetAttributeTranslationName(group));
    }

    /// <summary>
    ///     Gets the name of the attribute translation.
    /// </summary>
    /// <param name="group">The group.</param>
    /// <returns></returns>
    /// <exception cref="System.ArgumentOutOfRangeException">group - The specified attribute group is unavailable</exception>
    private static string GetAttributeTranslationName(ItemAttributeGroup group)
    {
        return group switch
        {
            ItemAttributeGroup.Durability => "PARAM_DUR",
            ItemAttributeGroup.PhysicalSpecialize => "PARAM_PHYSICAL_SPECIALIZE",
            ItemAttributeGroup.MagicalSpecialize => "PARAM_MAGICAL_SPECIALIZE",
            ItemAttributeGroup.HitRatio => "PARAM_HR",
            ItemAttributeGroup.PhysicalDamage => "PARAM_PA",
            ItemAttributeGroup.MagicalDamage => "PARAM_MA",
            ItemAttributeGroup.Critical => "PARAM_CRITICAL",
            ItemAttributeGroup.BlockRatio => "PARAM_BLOCKING",
            ItemAttributeGroup.EvasionRatio => "PARAM_ER",
            ItemAttributeGroup.PhysicalDefense => "PARAM_PD",
            ItemAttributeGroup.MagicalDefense => "PARAM_MD",
            ItemAttributeGroup.PhysicalAbsorbRatio => "PARAM_PR",
            ItemAttributeGroup.MagicalAbsorbRatio => "PARAM_MR",
            _ => throw new ArgumentOutOfRangeException(
                nameof(group),
                group,
                "The specified attribute group is unavailable"
            ),
        };
    }
}
