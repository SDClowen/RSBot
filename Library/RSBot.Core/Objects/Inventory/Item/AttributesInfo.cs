using RSBot.Core.Client.ReferenceObjects;
using RSBot.Core.Extensions;
using System;
using System.Collections.Generic;

namespace RSBot.Core.Objects.Inventory.Item
{
    /// <summary>
    /// This enumeration defines the different attributes an item may have.
    /// Even though items may share attributes of the same group, it's not guaranteed, that
    /// the attribute does have the exact same name. You can check the actual group names in constants defined in.
    /// <see cref="AttributesInfo"/>
    ///
    /// Use the static method of AttributeInfo to identify the actual name of attributes by its group.
    /// </summary>
    public enum AttributesGroup
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
        MagicalAbsorbRatio
    }

    public struct AttributesInfo : IEquatable<AttributesInfo>
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

        public AttributesInfo(ulong value)
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
                var mask = (1ul << SlotSize) - 1ul << offset;

                return (byte)((Variance & mask) >> offset);
            }
            set
            {
                var offset = slot * SlotSize;
                var mask = (1ul << SlotSize) - 1ul << offset;

                Variance = (Variance & ~mask) | ((ulong)(value << offset) & mask);
            }
        }

        public override bool Equals(object obj) => obj is AttributesInfo variance && Equals(variance);

        public bool Equals(AttributesInfo other) => Variance == other.Variance;

        public override int GetHashCode() => Variance.GetHashCode();

        public static explicit operator AttributesInfo(ulong value) => new(value);

        public static implicit operator ulong(AttributesInfo variance) => variance.Variance;

        public static bool operator ==(AttributesInfo left, AttributesInfo right) => left.Equals(right);

        public static bool operator !=(AttributesInfo left, AttributesInfo right) => !(left == right);

        public byte GetPercentage(byte slot)
        {
            if (slot > 6)
                return 0;

            var value = Math.Floor(this[slot] / 31f * 100f);

            return (byte)value;
        }

        public static IEnumerable<AttributesGroup>? GetAvailableAttributeGroupsForItem(RefObjItem item)
        {
            if (item.IsArmor)
            {
                return new[]
                {
                    AttributesGroup.Durability, AttributesGroup.PhysicalSpecialize, AttributesGroup.MagicalSpecialize,
                    AttributesGroup.PhysicalDefense, AttributesGroup.MagicalDefense, AttributesGroup.EvasionRatio
                };
            }

            if (item.IsWeapon)
            {
                return new[]
                {
                    AttributesGroup.Durability, AttributesGroup.PhysicalSpecialize, AttributesGroup.MagicalSpecialize,
                    AttributesGroup.HitRatio, AttributesGroup.PhysicalDamage, AttributesGroup.MagicalDamage,
                    AttributesGroup.Critical
                };
            }

            if (item.IsShield)
            {
                return new[]
                {
                    AttributesGroup.Durability, AttributesGroup.PhysicalSpecialize, AttributesGroup.MagicalSpecialize,
                    AttributesGroup.BlockRatio, AttributesGroup.PhysicalDefense, AttributesGroup.MagicalDefense
                };
            }

            if (item.IsAccessory)
            {
                return new[]
                {
                    AttributesGroup.PhysicalAbsorbRatio, AttributesGroup.MagicalAbsorbRatio
                };
            }

            return null;
        }

        public static string? GetActualAttributeGroupNameForItem(RefObjItem item, AttributesGroup group)
        {
            //Weapon attributes
            if (item.IsWeapon && group == AttributesGroup.Durability)
                return WeaponDurabilityGroup;

            if (item.IsWeapon && group == AttributesGroup.Critical)
                return WeaponCriticalHitRatioGroup;

            if (item.IsWeapon && group == AttributesGroup.HitRatio)
                return WeaponHitRatioGroup;

            if (item.IsWeapon && group == AttributesGroup.PhysicalDamage)
                return WeaponPhyDmgGroup;

            if (item.IsWeapon && group == AttributesGroup.MagicalDamage)
                return WeaponMagDmgGroup;

            if (item.IsWeapon && group == AttributesGroup.PhysicalSpecialize)
                return WeaponPhySpecializeGroup;

            if (item.IsWeapon && group == AttributesGroup.MagicalSpecialize)
                return WeaponMagSpecializeGroup;

            //Accessory attributes
            if (item.IsAccessory && group == AttributesGroup.MagicalAbsorbRatio)
                return AccessoryMagAbsorbRatioGroup;

            if (item.IsAccessory && group == AttributesGroup.PhysicalAbsorbRatio)
                return AccessoryPhyAbsorbRatioGroup;

            //Shield
            if (item.IsShield && group == AttributesGroup.Durability)
                return ShieldDurabilityGroup;

            if (item.IsShield && group == AttributesGroup.PhysicalSpecialize)
                return ShieldPhySpecializeGroup;

            if (item.IsShield && group == AttributesGroup.MagicalSpecialize)
                return ShieldMagSpecializeGroup;

            if (item.IsShield && group == AttributesGroup.BlockRatio)
                return ShieldBlockRatioGroup;

            if (item.IsShield && group == AttributesGroup.MagicalDefense)
                return ShieldMagDefenseGroup;

            if (item.IsShield && group == AttributesGroup.PhysicalDefense)
                return ShieldPhyDefenseGroup;

            //Armor
            if (item.IsArmor && group == AttributesGroup.Durability)
                return ArmorDurabilityGroup;

            if (item.IsArmor && group == AttributesGroup.PhysicalSpecialize)
                return ArmorPhySpecializeGroup;

            if (item.IsArmor && group == AttributesGroup.MagicalSpecialize)
                return ArmorMagSpecializeGroup;

            if (item.IsArmor && group == AttributesGroup.MagicalDefense)
                return ArmorMagDefenseGroup;

            if (item.IsArmor && group == AttributesGroup.PhysicalDefense)
                return ArmorPhyDefenseGroup;

            if (item.IsArmor && group == AttributesGroup.EvasionRatio)
                return ArmorEvasionRatioGroup;

            return null;
        }

        public static byte GetAttributeSlotForItem(AttributesGroup group, RefObjItem item)

        {
            //Weapon attributes
            if (item.IsWeapon && group == AttributesGroup.Durability)
                return WeaponDurability;

            if (item.IsWeapon && group == AttributesGroup.Critical)
                return WeaponCriticalHitRatio;

            if (item.IsWeapon && group == AttributesGroup.HitRatio)
                return WeaponHitRatio;

            if (item.IsWeapon && group == AttributesGroup.PhysicalDamage)
                return WeaponPhyDmg;

            if (item.IsWeapon && group == AttributesGroup.MagicalDamage)
                return WeaponMagDmg;

            if (item.IsWeapon && group == AttributesGroup.PhysicalSpecialize)
                return WeaponPhySpecialize;

            if (item.IsWeapon && group == AttributesGroup.MagicalSpecialize)
                return WeaponMagSpecialize;

            //Accessory attributes
            if (item.IsAccessory && group == AttributesGroup.MagicalAbsorbRatio)
                return AccessoryMagAbsorbRatio;

            if (item.IsAccessory && group == AttributesGroup.PhysicalAbsorbRatio)
                return AccessoryPhyAbsorbRatio;

            //Shield
            if (item.IsShield && group == AttributesGroup.Durability)
                return ShieldDurability;

            if (item.IsShield && group == AttributesGroup.PhysicalSpecialize)
                return ShieldPhySpecialize;

            if (item.IsShield && group == AttributesGroup.MagicalSpecialize)
                return ShieldMagSpecialize;

            if (item.IsShield && group == AttributesGroup.BlockRatio)
                return ShieldBlockRatio;

            if (item.IsShield && group == AttributesGroup.MagicalDefense)
                return ShieldMagDefense;

            if (item.IsShield && group == AttributesGroup.PhysicalDefense)
                return ShieldPhyDefense;

            //Armor
            if (item.IsArmor && group == AttributesGroup.Durability)
                return ArmorDurability;

            if (item.IsArmor && group == AttributesGroup.PhysicalSpecialize)
                return ArmorPhySpecialize;

            if (item.IsArmor && group == AttributesGroup.MagicalSpecialize)
                return ArmorMagSpecialize;

            if (item.IsArmor && group == AttributesGroup.MagicalDefense)
                return ArmorMagDefense;

            if (item.IsArmor && group == AttributesGroup.PhysicalDefense)
                return ArmorPhyDefense;

            if (item.IsArmor && group == AttributesGroup.EvasionRatio)
                return ArmorEvasionRatio;

            throw new ArgumentException(
                $"Could not identify slot for the attribute {group.GetTranslation()} [ItemId = {item.ID}]");
        }

        #endregion Methods
    }
}