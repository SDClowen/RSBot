using System;

namespace RSBot.Core.Objects;

[Flags]
public enum BadEffect : uint
{
    None = 0,
    Frozen = 1u << 0,
    Frostbitten = 1u << 1,
    Shocked = 1u << 2,
    Burnt = 1u << 3,
    Poisoned = 1u << 4,

    #region EffectLevel

    Zombie = 1u << 5,
    Sleep = 1u << 6,
    Bind = 1u << 7,
    Dull = 1u << 8,
    Fear = 1u << 9,
    ShortSighted = 1u << 10,
    Bleed = 1u << 11,
    Petrify = 1u << 12,
    Darkness = 1u << 13,
    Stunned = 1u << 14,
    Disease = 1u << 15,
    Confusion = 1u << 16,
    Decay = 1u << 17,
    Weak = 1u << 18,
    Impotent = 1u << 19,
    Division = 1u << 20,
    Panic = 1u << 21,
    Combustion = 1u << 22,
    Bit23 = 1u << 23,
    Hidden = 1u << 24,
    Bit25 = 1u << 25,
    Bit26 = 1u << 26,
    Bit27 = 1u << 27,
    Bit28 = 1u << 28,
    Bit29 = 1u << 29,
    Bit30 = 1u << 30,
    Bit31 = 1u << 31,

    #endregion EffectLevel
}

public struct BadEffectAll
{
    /// <summary>
    ///     Bad effects curable by universal pills.
    /// </summary>
    public static BadEffect UniversallPillEffects =
        BadEffect.Frozen
        | BadEffect.Frostbitten
        | BadEffect.Shocked
        | BadEffect.Burnt
        | BadEffect.Poisoned
        | BadEffect.Zombie;

    /// <summary>
    ///     Bad effects curable by purification pills.
    /// </summary>
    public static BadEffect PurificationPillEffects =
        BadEffect.Sleep
        | BadEffect.Bind
        | BadEffect.Dull
        | BadEffect.Fear
        | BadEffect.ShortSighted
        | BadEffect.Bleed
        | BadEffect.Darkness
        | BadEffect.Disease
        | BadEffect.Decay
        | BadEffect.Weak
        | BadEffect.Impotent
        | BadEffect.Division
        | BadEffect.Panic
        | BadEffect.Hidden;
}
