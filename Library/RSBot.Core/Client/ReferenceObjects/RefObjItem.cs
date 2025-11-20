namespace RSBot.Core.Client.ReferenceObjects;

public class RefObjItem : RefObjCommon
{
    public string Desc1;
    public string Desc2;
    public string Desc3;
    public string Desc4;
    public byte ItemClass;
    public int MaxStack;
    public int Param1;
    public int Param2;
    public int Param3;
    public int Param4;
    public byte Quivered; //Consumes ammo
    public short Range;
    public byte ReqGender;
    public int ReqInt;
    public int ReqStr;
    public byte SpeedClass;
    public byte TwoHanded;

    //public float Dur_L;
    //public float Dur_U;

    //public float PD_L;
    //public float PD_U;
    //public float PDInc;

    //public float ER_L;
    //public float ER_U;
    //public float ERInc;

    //public float PAR_L;
    //public float PAR_U;
    //public float PARInc;

    //public float BR_L;
    //public float BR_U;

    //public float MD_L;
    //public float MD_U;
    //public float MDInc;

    //public float MAR_L;
    //public float MAR_U;
    //public float MARInc;

    //public float PDStr_L;
    //public float PDStr_U;

    //public float MDInt_L;
    //public float MDInt_U;

    //public float PAttackMin_L;
    //public float PAttackMin_U;
    //public float PAttackMax_L;
    //public float PAttackMax_U;
    //public float PAttackInc;
    //public float MAttackMin_L;
    //public float MAttackMin_U;
    //public float MAttackMax_L;
    //public float MAttackMax_U;
    //public float MAttackInc;
    //public float PAStrMin_L;
    //public float PAStrMin_U;
    //public float PAStrMax_L;
    //public float PAStrMax_U;
    //public float MAInt_Min_L;
    //public float MAInt_Min_U;
    //public float MAInt_Max_L;
    //public float MAInt_Max_U;
    //public float HR_L;
    //public float HR_U;
    //public float HRInc;
    //public float CHR_L;
    //public float CHR_U;

    /// <summary>
    ///     A value indicating if the item is of type gold
    /// </summary>
    public bool IsGold => IsStackable && TypeID3 == 5 && TypeID4 == 0;

    /// <summary>
    ///     A value indicating if the item is of type wearable
    /// </summary>
    public bool IsEquip => TypeID2 == 1;

    /// <summary>
    ///     Gets a value indicating whether this instance is an avatar or a devil spirit.
    /// </summary>
    /// <value>
    ///     <c>true</c> if this instance is avatar; otherwise, <c>false</c>.
    /// </value>
    public bool IsAvatar => IsEquip && TypeID3 is 13 or 14;

    /// <summary>
    ///     A value indicating if the item is of type wearable for job2 (job2 part items)
    /// </summary>
    public bool IsJobEquip => TypeID2 == 4;

    /// <summary>
    ///     A value indicating if the item is of type weareable for fellow pet
    /// </summary>
    public bool IsFellowEquip => TypeID2 == 5;

    /// <summary>
    ///     A value indicating if the item is of type wearable for job
    /// </summary>
    public bool IsJobOutfit => IsEquip && TypeID3 == 7 && TypeID4 is not 4 or 5;

    /// <summary>
    ///     A value indicating if the item is of type stackable
    /// </summary>
    public bool IsStackable => TypeID2 == 3;

    /// <summary>
    ///     A value indicating if the item is of type trading(job trading items)
    /// </summary>
    public bool IsTrading => IsStackable && TypeID3 == 8;

    /// <summary>
    ///     A value indicating if the item is of type specialty good box
    /// </summary>
    public bool IsSpecialtyGoodBox => IsTrading && TypeID4 == 3;

    /// <summary>
    ///     A value indicating if the item is of type trans quest
    /// </summary>
    public bool IsQuest => IsStackable && TypeID3 == 9;

    /// <summary>
    ///     A value indicating if the item is of type ammunition
    /// </summary>
    public bool IsAmmunition => IsStackable && TypeID3 == 4;

    /// <summary>
    ///     A value indicating if the item is of type cos
    /// </summary>
    public bool IsPet => TypeID2 == 2 && TypeID3 == 1;

    /// <summary>
    ///     A value indicating if the item is of type cos
    /// </summary>
    public bool IsGrowthPet => IsPet && TypeID4 == 1;

    /// <summary>
    ///     A value indicating if the item is of type cos
    /// </summary>
    public bool IsGrabPet => IsPet && TypeID4 == 2;

    /// <summary>
    ///     A value indicating if the item is of type cos
    /// </summary>
    public bool IsFellowPet => IsPet && TypeID4 == 3;

    /// <summary>
    ///     A value indicating if the item is of type trans monster
    /// </summary>
    public bool IsTransmonster => TypeID2 == 2 && TypeID3 == 2;

    /// <summary>
    ///     A value indicating if the item is of type ammunition
    /// </summary>
    public bool IsMagicCube => TypeID2 == 2 && TypeID3 == 3;

    /// <summary>
    ///     A value indicating if the item is of type skill item
    /// </summary>
    public bool IsSkill => IsStackable && TypeID3 == 13 && TypeID4 == 1;

    /// <summary>
    ///     A value indicating if the item is of type potion
    /// </summary>
    public bool IsPotion => IsStackable && TypeID3 == 1;

    /// <summary>
    ///     A value indicating if the item is of type hp potion
    /// </summary>
    public bool IsHpPotion => IsPotion && TypeID4 == 1;

    /// <summary>
    ///     A value indicating if the item is of type mp potion
    /// </summary>
    public bool IsMpPotion => IsPotion && TypeID4 == 2;

    /// <summary>
    ///     A value indicating if the item is of type all potion(vigor)
    /// </summary>
    public bool IsAllPotion => IsPotion && TypeID4 == 3;

    /// <summary>
    ///     A value indicating if the item is of type Universal Pill
    /// </summary>
    public bool IsUniversalPill => IsStackable && TypeID3 == 2 && TypeID4 == 6;

    /// <summary>
    ///     A value indicating if the item is of type Purification Pill
    /// </summary>
    public bool IsPurificationPill => IsStackable && TypeID3 == 2 && TypeID4 == 1;

    /// <summary>
    ///     A value indicating if the item is of type abnormal potion
    /// </summary>
    public bool IsAbnormalPotion => IsStackable && TypeID3 == 2 && TypeID4 == 9;

    /// <summary>
    ///     A value indicating if the item is of type cos hp potion
    /// </summary>
    public bool IsCosHpPotion => IsPotion && TypeID4 == 4 && Param2 == 0;

    /// <summary>
    ///     A value indicating if the item is of type cos hp potion
    /// </summary>
    public bool IsFellowHpPotion => IsPotion && TypeID4 == 4 && Param2 != 0;

    /// <summary>
    ///     A value indicating if the item is of type cos revival
    /// </summary>
    public bool IsCosRevivalPotion => IsPotion && TypeID4 == 6;

    /// <summary>
    ///     A value indicating if the item is of type hwan potion
    /// </summary>
    public bool IsHwanPotion => IsPotion && TypeID4 == 8;

    /// <summary>
    ///     A value indicating if the item is of type hgp potion
    /// </summary>
    public bool IsHgpPotion => IsPotion && TypeID4 == 9 && Param1 == 10;

    /// <summary>
    ///     A value indicating if the item is of type pet2 satiety potion
    /// </summary>
    public bool IsPet2SatietyPotion => IsPotion && TypeID4 == 9 && Param1 > 10;

    /// <summary>
    ///     A value indicating if the item is of type repair kit
    /// </summary>
    public bool IsRepairKit => IsPotion && TypeID4 == 10;

    /// <summary>
    ///     Gets a value indicating whether this instance is armor.
    /// </summary>
    /// <value>
    ///     <c>true</c> if this instance is armor; otherwise, <c>false</c>.
    /// </value>
    public bool IsArmor => (IsEquip && TypeID3 == 1) || TypeID3 is 2 or 3 or 9 or 10 or 11;

    /// <summary>
    ///     Gets a value indicating whether this instance is a shield.
    /// </summary>
    /// <value>
    ///     <c>true</c> if this instance is shield; otherwise, <c>false</c>.
    /// </value>
    public bool IsShield => IsEquip && TypeID3 == 4;

    /// <summary>
    ///     Gets a value indicating whether this instance is an accessory.
    /// </summary>
    /// <value>
    ///     <c>true</c> if this instance is accessory; otherwise, <c>false</c>.
    /// </value>
    public bool IsAccessory => (IsEquip && TypeID3 == 5) || TypeID3 == 12;

    /// <summary>
    ///     Gets a value indicating whether this instance is a weapon.
    /// </summary>
    /// <value>
    ///     <c>true</c> if this instance is weapon; otherwise, <c>false</c>.
    /// </value>
    public bool IsWeapon => IsEquip && TypeID3 == 6;

    /// <summary>
    ///     Gets the degree of the item
    /// </summary>
    public int Degree => (ItemClass - 1) / 3 + 1;

    /// <summary>
    ///     Gets the degree offset.
    /// </summary>
    public int DegreeOffset => ItemClass - 3 * ((ItemClass - 1) / 3) - 1; //sro_client.sub_8BA6E0

    public override bool Load(ReferenceParser parser)
    {
        if (!base.Load(parser))
            return false;

        if (ID == 11161)
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
        }

        //parser.TryParse(63, out Dur_L);
        //parser.TryParse(64, out Dur_U);
        //parser.TryParse(65, out PD_L);
        //parser.TryParse(66, out PD_U);
        //parser.TryParse(67, out PDInc);
        //parser.TryParse(68, out ER_L);
        //parser.TryParse(69, out ER_U);
        //parser.TryParse(70, out ERInc);
        //parser.TryParse(71, out PAR_L);
        //parser.TryParse(72, out PAR_U);
        //parser.TryParse(73, out PARInc);
        //parser.TryParse(74, out BR_L);
        //parser.TryParse(75, out BR_U);
        //parser.TryParse(76, out MD_L);
        //parser.TryParse(77, out MD_U);
        //parser.TryParse(78, out MDInc);
        //parser.TryParse(79, out MAR_L);
        //parser.TryParse(80, out MAR_U);
        //parser.TryParse(81, out MARInc);
        //parser.TryParse(82, out PDStr_L);
        //parser.TryParse(83, out PDStr_U);
        //parser.TryParse(84, out MDInt_L);
        //parser.TryParse(85, out MDInt_U);

        //parser.TryParse(95, out PAttackMin_L);
        //parser.TryParse(96, out PAttackMin_U);
        //parser.TryParse(97, out PAttackMax_L);
        //parser.TryParse(98, out PAttackMax_U);
        //parser.TryParse(99, out PAttackInc);
        //parser.TryParse(100, out MAttackMin_L);
        //parser.TryParse(101, out MAttackMin_U);
        //parser.TryParse(102, out MAttackMax_L);
        //parser.TryParse(103, out MAttackMax_U);
        //parser.TryParse(104, out MAttackInc);
        //parser.TryParse(105, out PAStrMin_L);
        //parser.TryParse(106, out PAStrMin_U);
        //parser.TryParse(107, out PAStrMax_L);
        //parser.TryParse(108, out PAStrMax_U);
        //parser.TryParse(109, out MAInt_Min_L);
        //parser.TryParse(110, out MAInt_Min_U);
        //parser.TryParse(111, out MAInt_Max_L);
        //parser.TryParse(112, out MAInt_Max_U);
        //parser.TryParse(113, out HR_L);
        //parser.TryParse(114, out HR_U);
        //parser.TryParse(115, out HRInc);
        //parser.TryParse(116, out CHR_L); //critical hit rate
        //parser.TryParse(117, out CHR_U);

        parser.TryParse(57, out MaxStack);
        parser.TryParse(58, out ReqGender);
        parser.TryParse(59, out ReqStr);
        parser.TryParse(60, out ReqInt);
        parser.TryParse(61, out ItemClass);
        parser.TryParse(86, out Quivered);
        parser.TryParse(92, out SpeedClass);
        parser.TryParse(93, out TwoHanded);
        parser.TryParse(94, out Range);
        parser.TryParse(118, out Param1);
        parser.TryParse(119, out Desc1);
        parser.TryParse(120, out Param2);
        parser.TryParse(121, out Desc2);
        parser.TryParse(122, out Param3);
        parser.TryParse(123, out Desc3);
        parser.TryParse(124, out Param4);
        parser.TryParse(125, out Desc4);

        return true;
    }

    /// <summary>
    ///     Get item sox name
    /// </summary>
    /// <returns></returns>
    public string GetRarityName()
    {
        if (Rarity < ObjectRarity.ClassC)
            return string.Empty;

        string param = null;
        if (ItemClass < 31 || ItemClass > 34)
            //Seal of Star, Seal of Moon, Seal of Sun
            switch (DegreeOffset)
            {
                case 0:
                    param = Game.ReferenceManager.GetTranslation("PARAM_RARE_FIRST");
                    break;

                case 1:
                    param = Game.ReferenceManager.GetTranslation("PARAM_RARE_SECOND");
                    break;

                case 2:
                    param = Game.ReferenceManager.GetTranslation("PARAM_RARE_THIRD");
                    break;
            }
        else
            //Seal of Nova
            param = Game.ReferenceManager.GetTranslation("PARAM_RARE_FIRST2");

        return param;
    }

    public override string GetRealName(bool displayRarity = false)
    {
        var baseName = base.GetRealName(displayRarity);

        if (!displayRarity)
            return baseName;

        var rarityName = GetRarityName();
        if (string.IsNullOrWhiteSpace(rarityName))
            return baseName;

        return $"{baseName} ({rarityName})";
    }

    public override string ToString()
    {
        return $"{CodeName} TID1:{TypeID1} TID2:{TypeID2} TID3:{TypeID3} TID4:{TypeID4}";
    }
}
