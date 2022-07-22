using System;

namespace RSBot.Core.Objects.Inventory.Item
{
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

        public static explicit operator AttributesInfo(ulong value) => new (value);

        public static implicit operator ulong(AttributesInfo variance) => variance.Variance;

        public static bool operator ==(AttributesInfo left, AttributesInfo right) => left.Equals(right);

        public static bool operator !=(AttributesInfo left, AttributesInfo right) => !(left == right);

        public byte GetPercentage(byte slot)
        {

            ////F = Fixed, ? = To be calculated
            //Min: 46 F
            //Max: 68 F
            //Cur: 65 ?
            //    Val : 27 F
            //Per: 87 % ?


            //Durability:
            //    Different min / max: 22
            //27 % von 68 = 18.36
            //27 % von 46 = 12.42
            //27 * 100 / 31 = 87

            //How to get percentage value:
            //1. 27 % von 46

            //var percentDurability = Val / 100 * Min;   // (27 / 100 * 46) = 12.42

            //2. 46 + Result 1.
            //    var percentDurabilityAbsolute = Min + percentDurability;

            //How to get current value
            //var differenceMinMax = Max - Min;
            //var durabilityDifferencePercent = percentageDurabilityAbsolute / 100 * differenceMinMax; //= 19,41
            //var durabilityValue = Min + durabilityOffsetPercent; //= 65,14
            var value = Math.Floor(this[slot] / 31f * 100f);

            return (byte) value;
        }
        #endregion Methods
    }
}