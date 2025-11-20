using System;
using System.Collections.Generic;
using System.Linq;

namespace RSBot.Core.Client.ReferenceObjects;

public class RefMagicOpt : IReference
{
    #region Constants

    public const string MaterialLuck = "MATTR_LUCK";
    public const string MaterialStr = "MATTR_STR";
    public const string MaterialInt = "MATTR_INT";
    public const string MaterialSteady = "MATTR_SOLID";
    public const string MaterialHP = "MATTR_HP";
    public const string MaterialMP = "MATTR_MP";
    public const string MaterialAstral = "MATTR_ASTRAL";
    public const string MaterialImmortal = "MATTR_ATHANASIA";
    public const string MaterialDurability = "MATTR_DUR";
    public const string MaterialBlockRate = "MATTR_BLOCKRATE";
    public const string MaterialCritical = "MATTR_CRITICAL";
    public const string MaterialParryRate = "MATTR_ER"; //evasion rate
    public const string MaterialAttackRate = "MATTR_HR"; //hit rate
    public const string MaterialResistStun = "MATTR_RESIST_STUN";
    public const string MaterialResistZombie = "MATTR_RESIST_ZOMBIE";
    public const string MaterialResistPoison = "MATTR_RESIST_POISON";
    public const string MaterialResistBurn = "MATTR_RESIST_BURN";
    public const string MaterialResistElectroShock = "MATTR_RESIST_ESHOCK";
    public const string MaterialResistFrostbite = "MATTR_RESIST_FROSTBYTE";
    public const string MaterialResistDisease = "MATTR_RESIST_DISEASE";
    public const string MaterialResistSleep = "MATTR_RESIST_SLEEP";
    public const string MaterialResistFear = "MATTR_RESIST_FEAR";
    public const string MaterialResistCombustion = "MATTR_RESIST_CSMP";

    #endregion Constants

    #region Fields

    public string Group;
    public uint Id;
    public bool Active;
    public string AvailabilityGroup1;
    public string AvailabilityGroup2;
    public string AvailabilityGroup3;
    public string AvailabilityGroup4;

    public List<ushort> AvailableValues;

    public byte Level;

    #endregion Fields

    #region Methods

    public bool Load(ReferenceParser parser)
    {
        if (parser == null)
            return false;

        AvailableValues = new List<ushort>(8);
        parser.TryParse(0, out Active);
        parser.TryParse(1, out Id);
        parser.TryParse(2, out Group);
        parser.TryParse(4, out Level);

        //param1 = name of the attribute
        /*
        *
        * 		var x = 1635018849;
                var buffer = BitConverter.GetBytes(x);
                var name = System.Text.Encoding.ASCII.GetString(buffer.Reverse().ToArray());
                Console.WriteLine(name); //atha

         */

        for (var i = 8; i < 11; i++)
        {
            parser.TryParse(i, out uint paramVal);
            var param = GetAvailableValues(paramVal);

            AvailableValues.Add(param.Item1);
            AvailableValues.Add(param.Item2);
        }

        parser.TryParse(28, out AvailabilityGroup1);
        parser.TryParse(30, out AvailabilityGroup2);
        parser.TryParse(32, out AvailabilityGroup3);
        parser.TryParse(34, out AvailabilityGroup4);

        return true;
    }

    /// <summary>
    ///     Returns the maximum possible value for this magic attribute
    /// </summary>
    /// <returns>The maximum value</returns>
    public ushort GetMaxValue()
    {
        if (AvailableValues == null)
            return 0;

        return AvailableValues.Max();
    }

    /// <summary>
    ///     Returns all available values this magic attribute can possibly have
    /// </summary>
    /// <param name="value"></param>
    /// <returns>The from and to value</returns>
    private Tuple<ushort, ushort> GetAvailableValues(uint value)
    {
        var toValue = (ushort)(value >> 16);
        var fromValue = (ushort)(value & 0xffff);

        return new Tuple<ushort, ushort>(fromValue, toValue);
    }

    #endregion Methods
}
