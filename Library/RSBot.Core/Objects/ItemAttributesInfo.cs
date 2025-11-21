using System;
using System.Collections.Generic;
using RSBot.Core.Client.ReferenceObjects;
using RSBot.Core.Extensions;

namespace RSBot.Core.Objects;

/// <summary>
///     This enumeration defines the different attributes an item may have.
///     Even though items may share attributes of the same group, it's not guaranteed, that
///     the attribute does have the exact same name. You can check the actual group names in constants defined in.
///     <see cref="ItemAttributesInfo" />
///     Use the static method of AttributeInfo to identify the actual name of attributes by its group.
/// </summary>
public enum ItemAttributeGroup
{
    Durability,
    PhysicalSpecialize,
    MagicalSpecialize,
    HitRatio,
    PhysicalDamage,
    MagicalDamage,
    Critical,
    BlockRatio,
    EvasionRatio,
    PhysicalDefense,
    MagicalDefense,
    PhysicalAbsorbRatio,
    MagicalAbsorbRatio,
}

public struct ItemAttributesInfo : IEquatable<ItemAttributesInfo>
{
    #region Properties

    public ulong Variance { get; private set; }

    #endregion Properties

    #region Constants

    public const int WeaponDurability = 0;
    public const int WeaponPhySpecialize = 1;
    public const int WeaponMagSpecialize = 2;
    public const int WeaponHitRatio = 3;
    public const int WeaponPhyDmg = 4;
    public const int WeaponMagDmg = 5;
    public const int WeaponCriticalHitRatio = 6;

    public const int ArmorDurability = 0;
    public const int ArmorPhySpecialize = 1;
    public const int ArmorMagSpecialize = 2;
    public const int ArmorPhyDefense = 3;
    public const int ArmorMagDefense = 4;
    public const int ArmorEvasionRatio = 5;

    public const int ShieldDurability = 0;
    public const int ShieldPhySpecialize = 1;
    public const int ShieldMagSpecialize = 2;
    public const int ShieldBlockRatio = 3;
    public const int ShieldPhyDefense = 4;
    public const int ShieldMagDefense = 5;

    public const int AccessoryPhyAbsorbRatio = 0;
    public const int AccessoryMagAbsorbRatio = 1;

    private const byte SlotSize = 5;

    public const string WeaponDurabilityGroup = "NATTR_DUR";
    public const string WeaponPhySpecializeGroup = "NATTR_PASTR";
    public const string WeaponMagSpecializeGroup = "NATTR_MAINT";
    public const string WeaponHitRatioGroup = "NATTR_HR";
    public const string WeaponPhyDmgGroup = "NATTR_PA";
    public const string WeaponMagDmgGroup = "NATTR_MA";
    public const string WeaponCriticalHitRatioGroup = "NATTR_CRITICAL";

    public const string ArmorDurabilityGroup = "NATTR_DUR";
    public const string ArmorPhySpecializeGroup = "NATTR_PDSTR";
    public const string ArmorMagSpecializeGroup = "NATTR_MDINT";
    public const string ArmorPhyDefenseGroup = "NATTR_PD";
    public const string ArmorMagDefenseGroup = "NATTR_MD";
    public const string ArmorEvasionRatioGroup = "NATTR_ER";

    public const string ShieldDurabilityGroup = "NATTR_DUR";
    public const string ShieldPhySpecializeGroup = "NATTR_PDSTR";
    public const string ShieldMagSpecializeGroup = "NATTR_MDINT";
    public const string ShieldBlockRatioGroup = "NATTR_BR";
    public const string ShieldPhyDefenseGroup = "NATTR_PD";
    public const string ShieldMagDefenseGroup = "NATTR_MD";

    public const string AccessoryPhyAbsorbRatioGroup = "NATTR_PAR";
    public const string AccessoryMagAbsorbRatioGroup = "NATTR_MAR";

    #endregion Constants

    #region Constructor

    public ItemAttributesInfo(ulong value)
    {
        Variance = value;
    }

    #endregion Constructor

    #region Methods

    public byte this[byte slot]
    {
        get
        {
            var offset = slot * SlotSize;
            var mask = ((1ul << SlotSize) - 1ul) << offset;

            return (byte)((Variance & mask) >> offset);
        }
        set
        {
            var offset = slot * SlotSize;
            var mask = ((1ul << SlotSize) - 1ul) << offset;

            Variance = (Variance & ~mask) | ((ulong)(value << offset) & mask);
        }
    }

    public override bool Equals(object obj)
    {
        return obj is ItemAttributesInfo variance && Equals(variance);
    }

    public bool Equals(ItemAttributesInfo other)
    {
        return Variance == other.Variance;
    }

    public override int GetHashCode()
    {
        return Variance.GetHashCode();
    }

    /// <summary>
    ///     Compares the slots and return those which are different.
    /// </summary>
    /// <param name="info">The information.</param>
    /// <returns></returns>
    public IEnumerable<byte> CompareSlots(ItemAttributesInfo info)
    {
        var result = new List<byte>(6);

        for (byte i = 0; i < 6; i++)
            if (info[i] != this[i])
                result.Add(i);

        return result;
    }

    public static explicit operator ItemAttributesInfo(ulong value)
    {
        return new ItemAttributesInfo(value);
    }

    public static implicit operator ulong(ItemAttributesInfo variance)
    {
        return variance.Variance;
    }

    public static bool operator ==(ItemAttributesInfo left, ItemAttributesInfo right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(ItemAttributesInfo left, ItemAttributesInfo right)
    {
        return !(left == right);
    }

    public byte GetPercentage(byte slot)
    {
        if (slot > 6)
            return 0;

        var value = Math.Floor(this[slot] / 31f * 100f);

        return (byte)value;
    }

    public static IEnumerable<ItemAttributeGroup>? GetAvailableAttributeGroupsForItem(RefObjItem item)
    {
        if (item.IsArmor)
            return new[]
            {
                ItemAttributeGroup.Durability,
                ItemAttributeGroup.PhysicalSpecialize,
                ItemAttributeGroup.MagicalSpecialize,
                ItemAttributeGroup.PhysicalDefense,
                ItemAttributeGroup.MagicalDefense,
                ItemAttributeGroup.EvasionRatio,
            };

        if (item.IsWeapon)
            return new[]
            {
                ItemAttributeGroup.Durability,
                ItemAttributeGroup.PhysicalSpecialize,
                ItemAttributeGroup.MagicalSpecialize,
                ItemAttributeGroup.HitRatio,
                ItemAttributeGroup.PhysicalDamage,
                ItemAttributeGroup.MagicalDamage,
                ItemAttributeGroup.Critical,
            };

        if (item.IsShield)
            return new[]
            {
                ItemAttributeGroup.Durability,
                ItemAttributeGroup.PhysicalSpecialize,
                ItemAttributeGroup.MagicalSpecialize,
                ItemAttributeGroup.BlockRatio,
                ItemAttributeGroup.PhysicalDefense,
                ItemAttributeGroup.MagicalDefense,
            };

        if (item.IsAccessory)
            return new[] { ItemAttributeGroup.PhysicalAbsorbRatio, ItemAttributeGroup.MagicalAbsorbRatio };

        return null;
    }

    public static ItemAttributeGroup GetAttributeGroupBySlot(RefObjItem item, byte slot)
    {
        if ((item.IsWeapon || item.IsShield || item.IsArmor) && slot == 0)
            return ItemAttributeGroup.Durability;

        if ((item.IsWeapon || item.IsShield || item.IsArmor) && slot == 1)
            return ItemAttributeGroup.PhysicalSpecialize;

        if ((item.IsWeapon || item.IsShield || item.IsArmor) && slot == 2)
            return ItemAttributeGroup.MagicalSpecialize;

        //Weapon
        if (item.IsWeapon && slot == 3)
            return ItemAttributeGroup.HitRatio;

        if (item.IsWeapon && slot == 4)
            return ItemAttributeGroup.PhysicalDamage;

        if (item.IsWeapon && slot == 5)
            return ItemAttributeGroup.MagicalDamage;

        if (item.IsWeapon && slot == 6)
            return ItemAttributeGroup.Critical;

        //Armor
        if (item.IsArmor && slot == 3)
            return ItemAttributeGroup.PhysicalDefense;

        if (item.IsArmor && slot == 4)
            return ItemAttributeGroup.MagicalDefense;

        if (item.IsArmor && slot == 5)
            return ItemAttributeGroup.EvasionRatio;

        //Shield
        if (item.IsShield && slot == 3)
            return ItemAttributeGroup.BlockRatio;

        if (item.IsShield && slot == 4)
            return ItemAttributeGroup.PhysicalDefense;

        if (item.IsShield && slot == 5)
            return ItemAttributeGroup.MagicalDefense;

        //Accessory
        if (item.IsAccessory && slot == 0)
            return ItemAttributeGroup.PhysicalAbsorbRatio;

        if (item.IsAccessory && slot == 1)
            return ItemAttributeGroup.MagicalAbsorbRatio;

        throw new Exception($"Unknown attribute type requested! [slot={slot}]");
    }

    public static string? GetActualAttributeGroupNameForItem(RefObjItem item, ItemAttributeGroup group)
    {
        //Weapon attributes
        if (item.IsWeapon && group == ItemAttributeGroup.Durability)
            return WeaponDurabilityGroup;

        if (item.IsWeapon && group == ItemAttributeGroup.Critical)
            return WeaponCriticalHitRatioGroup;

        if (item.IsWeapon && group == ItemAttributeGroup.HitRatio)
            return WeaponHitRatioGroup;

        if (item.IsWeapon && group == ItemAttributeGroup.PhysicalDamage)
            return WeaponPhyDmgGroup;

        if (item.IsWeapon && group == ItemAttributeGroup.MagicalDamage)
            return WeaponMagDmgGroup;

        if (item.IsWeapon && group == ItemAttributeGroup.PhysicalSpecialize)
            return WeaponPhySpecializeGroup;

        if (item.IsWeapon && group == ItemAttributeGroup.MagicalSpecialize)
            return WeaponMagSpecializeGroup;

        //Accessory attributes
        if (item.IsAccessory && group == ItemAttributeGroup.MagicalAbsorbRatio)
            return AccessoryMagAbsorbRatioGroup;

        if (item.IsAccessory && group == ItemAttributeGroup.PhysicalAbsorbRatio)
            return AccessoryPhyAbsorbRatioGroup;

        //Shield
        if (item.IsShield && group == ItemAttributeGroup.Durability)
            return ShieldDurabilityGroup;

        if (item.IsShield && group == ItemAttributeGroup.PhysicalSpecialize)
            return ShieldPhySpecializeGroup;

        if (item.IsShield && group == ItemAttributeGroup.MagicalSpecialize)
            return ShieldMagSpecializeGroup;

        if (item.IsShield && group == ItemAttributeGroup.BlockRatio)
            return ShieldBlockRatioGroup;

        if (item.IsShield && group == ItemAttributeGroup.MagicalDefense)
            return ShieldMagDefenseGroup;

        if (item.IsShield && group == ItemAttributeGroup.PhysicalDefense)
            return ShieldPhyDefenseGroup;

        //Armor
        if (item.IsArmor && group == ItemAttributeGroup.Durability)
            return ArmorDurabilityGroup;

        if (item.IsArmor && group == ItemAttributeGroup.PhysicalSpecialize)
            return ArmorPhySpecializeGroup;

        if (item.IsArmor && group == ItemAttributeGroup.MagicalSpecialize)
            return ArmorMagSpecializeGroup;

        if (item.IsArmor && group == ItemAttributeGroup.MagicalDefense)
            return ArmorMagDefenseGroup;

        if (item.IsArmor && group == ItemAttributeGroup.PhysicalDefense)
            return ArmorPhyDefenseGroup;

        if (item.IsArmor && group == ItemAttributeGroup.EvasionRatio)
            return ArmorEvasionRatioGroup;

        return null;
    }

    public static byte GetAttributeSlotForItem(ItemAttributeGroup group, RefObjItem item)
    {
        //Weapon attributes
        if (item.IsWeapon && group == ItemAttributeGroup.Durability)
            return WeaponDurability;

        if (item.IsWeapon && group == ItemAttributeGroup.Critical)
            return WeaponCriticalHitRatio;

        if (item.IsWeapon && group == ItemAttributeGroup.HitRatio)
            return WeaponHitRatio;

        if (item.IsWeapon && group == ItemAttributeGroup.PhysicalDamage)
            return WeaponPhyDmg;

        if (item.IsWeapon && group == ItemAttributeGroup.MagicalDamage)
            return WeaponMagDmg;

        if (item.IsWeapon && group == ItemAttributeGroup.PhysicalSpecialize)
            return WeaponPhySpecialize;

        if (item.IsWeapon && group == ItemAttributeGroup.MagicalSpecialize)
            return WeaponMagSpecialize;

        //Accessory attributes
        if (item.IsAccessory && group == ItemAttributeGroup.MagicalAbsorbRatio)
            return AccessoryMagAbsorbRatio;

        if (item.IsAccessory && group == ItemAttributeGroup.PhysicalAbsorbRatio)
            return AccessoryPhyAbsorbRatio;

        //Shield
        if (item.IsShield && group == ItemAttributeGroup.Durability)
            return ShieldDurability;

        if (item.IsShield && group == ItemAttributeGroup.PhysicalSpecialize)
            return ShieldPhySpecialize;

        if (item.IsShield && group == ItemAttributeGroup.MagicalSpecialize)
            return ShieldMagSpecialize;

        if (item.IsShield && group == ItemAttributeGroup.BlockRatio)
            return ShieldBlockRatio;

        if (item.IsShield && group == ItemAttributeGroup.MagicalDefense)
            return ShieldMagDefense;

        if (item.IsShield && group == ItemAttributeGroup.PhysicalDefense)
            return ShieldPhyDefense;

        //Armor
        if (item.IsArmor && group == ItemAttributeGroup.Durability)
            return ArmorDurability;

        if (item.IsArmor && group == ItemAttributeGroup.PhysicalSpecialize)
            return ArmorPhySpecialize;

        if (item.IsArmor && group == ItemAttributeGroup.MagicalSpecialize)
            return ArmorMagSpecialize;

        if (item.IsArmor && group == ItemAttributeGroup.MagicalDefense)
            return ArmorMagDefense;

        if (item.IsArmor && group == ItemAttributeGroup.PhysicalDefense)
            return ArmorPhyDefense;

        if (item.IsArmor && group == ItemAttributeGroup.EvasionRatio)
            return ArmorEvasionRatio;

        throw new ArgumentException(
            $"Could not identify slot for the attribute {group.GetTranslation()} [ItemId = {item.ID}]"
        );
    }

    #endregion Methods
}
