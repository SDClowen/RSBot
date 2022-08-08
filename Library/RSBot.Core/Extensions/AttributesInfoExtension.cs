using RSBot.Core.Objects.Inventory.Item;
using System;

namespace RSBot.Core.Extensions
{
    public static class AttributesInfoExtension
    {
        /// <summary>
        /// Gets the translation that is being displayed in game for the specified attribute.
        /// </summary>
        /// <param name="group">The group to be translated.</param>
        /// <returns></returns>
        public static string GetTranslation(this AttributesGroup group)
        {
            return Game.ReferenceManager.GetTranslation(GetAttributeTranslationName(group));
        }

        /// <summary>
        /// Gets the name of the attribute translation.
        /// </summary>
        /// <param name="group">The group.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentOutOfRangeException">group - The specified attribute group is unavailable</exception>
        private static string GetAttributeTranslationName(AttributesGroup group)
        {
            return group switch
            {
                AttributesGroup.Durability => "PARAM_DUR",
                AttributesGroup.PhysicalSpecialize => "PARAM_PHYSICAL_SPECIALIZE",
                AttributesGroup.MagicalSpecialize => "PARAM_MAGICAL_SPECIALIZE",
                AttributesGroup.HitRatio => "PARAM_HR",
                AttributesGroup.PhysicalDamage => "PARAM_PA",
                AttributesGroup.MagicalDamage => "PARAM_MA",
                AttributesGroup.Critical => "PARAM_CRITICAL",
                AttributesGroup.BlockRatio => "PARAM_BLOCKING",
                AttributesGroup.EvasionRatio => "PARAM_ER",
                AttributesGroup.PhysicalDefense => "PARAM_PD",
                AttributesGroup.MagicalDefense => "PARAM_MD",
                AttributesGroup.PhysicalAbsorbRatio => "PARAM_PR",
                AttributesGroup.MagicalAbsorbRatio => "PARAM_MR",
                _ => throw new ArgumentOutOfRangeException(nameof(group), group,
                    "The specified attribute group is unavailable")
            };
        }
    }
}