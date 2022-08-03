namespace RSBot.Core.Client.ReferenceObjects
{
    public class RefObjItem : RefObjCommon
    {
        public int MaxStack;
        public byte ReqGender;
        public int ReqStr;
        public int ReqInt;
        public byte ItemClass;
        public byte Quivered; //Consumes ammo
        public byte SpeedClass;
        public byte TwoHanded;
        public short Range;
        public int Param1;
        public int Param2;
        public int Param3;
        public int Param4;
        public string Desc1;
        public string Desc2;
        public string Desc3;
        public string Desc4;

        /// <summary>
        /// A value indicating if the item is of type gold
        /// </summary>
        public bool IsGold => IsStackable && TypeID3 == 5 && TypeID4 == 0;

        /// <summary>
        /// A value indicating if the item is of type wearable
        /// </summary>
        public bool IsEquip => TypeID2 == 1;

        /// <summary>
        /// A value indicating if the item is of type wearable for job2 (job2 part items)
        /// </summary>
        public bool IsJobEquip => TypeID2 == 4;

        /// <summary>
        /// A value indicating if the item is of type weareable for fellow pet
        /// </summary>
        public bool IsFellowEquip => TypeID2 == 5;

        /// <summary>
        /// A value indicating if the item is of type wearable for job
        /// </summary>
        public bool IsJobOutfit => TypeID2 == 1 && TypeID3 == 7;

        /// <summary>
        /// A value indicating if the item is of type stackable
        /// </summary>
        public bool IsStackable => TypeID2 == 3;

        /// <summary>
        /// A value indicating if the item is of type trading(job trading items)
        /// </summary>
        public bool IsTrading => IsStackable && TypeID3 == 8;

        /// <summary>
        /// A value indicating if the item is of type specialty good box
        /// </summary>
        public bool IsSpecialtyGoodBox => IsTrading && TypeID4 == 3;

        /// <summary>
        /// A value indicating if the item is of type trans quest
        /// </summary>
        public bool IsQuest => IsStackable && TypeID3 == 9;

        /// <summary>
        /// A value indicating if the item is of type ammunition
        /// </summary>
        public bool IsAmmunition => IsStackable && TypeID3 == 4;

        /// <summary>
        /// A value indicating if the item is of type cos
        /// </summary>
        public bool IsPet => TypeID2 == 2 && TypeID3 == 1;

        /// <summary>
        /// A value indicating if the item is of type cos
        /// </summary>
        public bool IsGrowthPet => IsPet && TypeID4 == 1;

        /// <summary>
        /// A value indicating if the item is of type cos
        /// </summary>
        public bool IsGrabPet => IsPet && TypeID4 == 2;

        /// <summary>
        /// A value indicating if the item is of type cos
        /// </summary>
        public bool IsFellowPet => IsPet && TypeID4 == 3;

        /// <summary>
        /// A value indicating if the item is of type trans monster
        /// </summary>
        public bool IsTransmonster => TypeID2 == 2 && TypeID3 == 2;

        /// <summary>
        /// A value indicating if the item is of type ammunition
        /// </summary>
        public bool IsMagicCube => TypeID2 == 2 && TypeID3 == 3;

        /// <summary>
        /// A value indicating if the item is of type skill item
        /// </summary>
        public bool IsSkill => IsStackable && TypeID3 == 13 && TypeID4 == 1;

        /// <summary>
        /// A value indicating if the item is of type potion
        /// </summary>
        public bool IsPotion => IsStackable && TypeID3 == 1;

        /// <summary>
        /// A value indicating if the item is of type hp potion
        /// </summary>
        public bool IsHpPotion => IsPotion && TypeID4 == 1;

        /// <summary>
        /// A value indicating if the item is of type mp potion
        /// </summary>
        public bool IsMpPotion => IsPotion && TypeID4 == 2;

        /// <summary>
        /// A value indicating if the item is of type all potion(vigor)
        /// </summary>
        public bool IsAllPotion => IsPotion && TypeID4 == 3;

        /// <summary>
        /// A value indicating if the item is of type cos hp potion
        /// </summary>
        public bool IsCosHpPotion => IsPotion && TypeID4 == 4 && Param2 == 0;

        /// <summary>
        /// A value indicating if the item is of type cos hp potion
        /// </summary>
        public bool IsFellowHpPotion => IsPotion && TypeID4 == 4 && Param2 != 0;

        /// <summary>
        /// A value indicating if the item is of type cos revival
        /// </summary>
        public bool IsCosRevivalPotion => IsPotion && TypeID4 == 6;

        /// <summary>
        /// A value indicating if the item is of type hwan potion
        /// </summary>
        public bool IsHwanPotion => IsPotion && TypeID4 == 8;

        /// <summary>
        /// A value indicating if the item is of type hgp potion
        /// </summary>
        public bool IsHgpPotion => IsPotion && TypeID4 == 9 && Param1 == 10;

        /// <summary>
        /// A value indicating if the item is of type pet2 satiety potion
        /// </summary>
        public bool IsPet2SatietyPotion => IsPotion && TypeID4 == 9 && Param1 > 10;

        /// <summary>
        /// A value indicating if the item is of type repair kit
        /// </summary>
        public bool IsRepairKit => IsPotion && TypeID4 == 10;

        /// <summary>
        /// Gets the degree of the item
        /// </summary>
        public int Degree => (ItemClass - 1) / 3 + 1;

        /// <summary>
        /// Gets the degree offset.
        /// </summary>
        public int DegreeOffset => ItemClass - 3 * ((ItemClass - 1) / 3) - 1; //sro_client.sub_8BA6E0

        public override bool Load(ReferenceParser parser)
        {
            if (!base.Load(parser))
                return false;

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
        /// Get item sox name
        /// </summary>
        /// <returns></returns>
        public string GetRarityName()
        {
            if (Rarity < ObjectRarity.ClassC)
                return string.Empty;

            string param = null;
            if (ItemClass < 31 || ItemClass > 34)
            {
                //Seal of Star, Seal of Moon, Seal of Sun
                switch (this.DegreeOffset)
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
            }
            else
            {
                //Seal of Nova
                param = Game.ReferenceManager.GetTranslation("PARAM_RARE_FIRST2");
            }

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
}