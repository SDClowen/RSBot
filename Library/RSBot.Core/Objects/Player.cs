using RSBot.Core.Client.ReferenceObjects;
using RSBot.Core.Components;
using RSBot.Core.Network;
using RSBot.Core.Objects.Skill;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace RSBot.Core.Objects
{
    public class Player
    {
        /// <summary>
        /// Gets or sets the tracker.
        /// </summary>
        /// <value>
        /// The tracker.
        /// </value>
        public PositionTracker Tracker { get; set; }

        /// <summary>
        /// Gets or sets the model identifier.
        /// </summary>
        /// <value>
        /// The model identifier.
        /// </value>
        public uint ModelId { get; set; }

        /// <summary>
        /// Gets or sets the scale.
        /// </summary>
        /// <value>
        /// The scale.
        /// </value>
        public byte Scale { get; set; }

        /// <summary>
        /// Gets or sets the level.
        /// </summary>
        /// <value>
        /// The level.
        /// </value>
        public byte Level { get; set; }

        /// <summary>
        /// Gets or sets the maximum level.
        /// </summary>
        /// <value>
        /// The maximum level.
        /// </value>
        public byte MaxLevel { get; set; }

        /// <summary>
        /// Gets or sets the experience offset.
        /// </summary>
        /// <value>
        /// The experience offset.
        /// </value>
        public ulong Experience { get; set; }

        /// <summary>
        /// Gets or sets the skill experience.
        /// </summary>
        /// <value>
        /// The skill experience.
        /// </value>
        public uint SkillExperience { get; set; }

        /// <summary>
        /// Gets or sets the gold.
        /// </summary>
        /// <value>
        /// The gold.
        /// </value>
        public ulong Gold { get; set; }

        /// <summary>
        /// Gets or sets the skill points.
        /// </summary>
        /// <value>
        /// The skill points.
        /// </value>
        public uint SkillPoints { get; set; }

        /// <summary>
        /// Gets or sets the stat points.
        /// </summary>
        /// <value>
        /// The stat points.
        /// </value>
        public ushort StatPoints { get; set; }

        /// <summary>
        /// Gets or sets the berzerk points.
        /// </summary>
        /// <value>
        /// The berzerk points.
        /// </value>
        public byte BerzerkPoints { get; set; }

        /// <summary>
        /// Gets a value indicating whether this instance can use berzerk.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance can use berzerk; otherwise, <c>false</c>.
        /// </value>
        public bool CanEnterBerzerk => BerzerkPoints == 5 && State.BodyState != BodyState.Hwan;

        /// <summary>
        /// Gets or sets the experience.
        /// </summary>
        /// <value>
        /// The experience.
        /// </value>
        public uint ExperienceChunk { get; set; }

        /// <summary>
        /// Gets or sets the health.
        /// </summary>
        /// <value>
        /// The health.
        /// </value>
        public uint Health { get; set; }

        /// <summary>
        /// Gets or sets the mana.
        /// </summary>
        /// <value>
        /// The mana.
        /// </value>
        public uint Mana { get; set; }

        /// <summary>
        /// Gets or sets the automatic inverst experience.
        /// </summary>
        /// <value>
        /// The automatic inverst experience.
        /// </value>
        public AutoInverstType AutoInverstExperience { get; set; }

        /// <summary>
        /// Gets or sets the daily pk.
        /// </summary>
        /// <value>
        /// The daily pk.
        /// </value>
        public byte DailyPK { get; set; }

        /// <summary>
        /// Gets or sets the total pk.
        /// </summary>
        /// <value>
        /// The total pk.
        /// </value>
        public ushort TotalPK { get; set; }

        /// <summary>
        /// Gets or sets the pk penalty point.
        /// </summary>
        /// <value>
        /// The pk penalty point.
        /// </value>
        public uint PKPenaltyPoint { get; set; }

        /// <summary>
        /// Gets or sets the berzerk level.
        /// </summary>
        /// <value>
        /// The berzerk level.
        /// </value>
        public byte BerzerkLevel { get; set; }

        /// <summary>
        /// Gets or sets the PVP flag.
        /// </summary>
        /// <value>
        /// The PVP flag.
        /// </value>
        public PvpFlag PvpFlag { get; set; }

        /// <summary>
        /// Gets or sets the inventory.
        /// </summary>
        /// <value>
        /// The inventory.
        /// </value>
        public Inventory Inventory { get; set; }

        /// <summary>
        /// Gets or sets the skills.
        /// </summary>
        /// <value>
        /// The skills.
        /// </value>
        public Skills Skills { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier.
        /// </summary>
        /// <value>
        /// The unique identifier.
        /// </value>
        public uint UniqueId { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>
        /// The status.
        /// </value>
        public State State { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the in combat.
        /// </summary>
        /// <value>
        /// The in combat.
        /// </value>
        public bool InCombat { get; set; }

        /// <summary>
        /// Gets or sets the physical attack minimum.
        /// </summary>
        /// <value>
        /// The physical attack minimum.
        /// </value>
        public uint PhysicalAttackMin { get; set; }

        /// <summary>
        /// Gets or sets the physical attack maximum.
        /// </summary>
        /// <value>
        /// The physical attack maximum.
        /// </value>
        public uint PhysicalAttackMax { get; set; }

        /// <summary>
        /// Gets or sets the magical attack minimum.
        /// </summary>
        /// <value>
        /// The magical attack minimum.
        /// </value>
        public uint MagicalAttackMin { get; set; }

        /// <summary>
        /// Gets or sets the magical attack maximum.
        /// </summary>
        /// <value>
        /// The magical attack maximum.
        /// </value>
        public uint MagicalAttackMax { get; set; }

        /// <summary>
        /// Gets or sets the physical defence.
        /// </summary>
        /// <value>
        /// The physical defence.
        /// </value>
        public ushort PhysicalDefence { get; set; }

        /// <summary>
        /// Gets or sets the magical defence.
        /// </summary>
        /// <value>
        /// The magical defence.
        /// </value>
        public ushort MagicalDefence { get; set; }

        /// <summary>
        /// Gets or sets the hit rate.
        /// </summary>
        /// <value>
        /// The hit rate.
        /// </value>
        public ushort HitRate { get; set; }

        /// <summary>
        /// Gets or sets the parry rate.
        /// </summary>
        /// <value>
        /// The parry rate.
        /// </value>
        public ushort ParryRate { get; set; }

        /// <summary>
        /// Gets or sets the maximum health.
        /// </summary>
        /// <value>
        /// The maximum health.
        /// </value>
        public uint MaximumHealth { get; set; }

        /// <summary>
        /// Gets or sets the maximum mana.
        /// </summary>
        /// <value>
        /// The maximum mana.
        /// </value>
        public uint MaximumMana { get; set; }

        /// <summary>
        /// Gets or sets the strength.
        /// </summary>
        /// <value>
        /// The strength.
        /// </value>
        public ushort Strength { get; set; }

        /// <summary>
        /// Gets or sets the intelligence.
        /// </summary>
        /// <value>
        /// The intelligence.
        /// </value>
        public ushort Intelligence { get; set; }

        /// <summary>
        /// Gets or sets the storage.
        /// </summary>
        /// <value>
        /// The storage.
        /// </value>
        public Storage Storage { get; set; }

        /// <summary>
        /// Gets or sets the guild storage.
        /// </summary>
        /// <value>
        /// The guild storage.
        /// </value>
        public Storage GuildStorage { get; set; }

        /// <summary>
        /// Gets or sets the job information.
        /// </summary>
        /// <value>
        /// The job information.
        /// </value>
        public JobInfo JobInformation { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [on transport].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [on transport]; otherwise, <c>false</c>.
        /// </value>
        public bool OnTransport { get; set; }

        /// <summary>
        /// Gets or sets the transport unique identifier.
        /// </summary>
        /// <value>
        /// The transport unique identifier.
        /// </value>
        public uint TransportUniqueId { get; set; }

        /// <summary>
        /// Gets or sets the account identifier.
        /// </summary>
        /// <value>
        /// The account identifier.
        /// </value>
        public uint JID { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is gm.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is gm; otherwise, <c>false</c>.
        /// </value>
        public bool IsGameMaster { get; set; }

        /// <summary>
        /// Gets a value indicating whether this instance has active attack pet.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance has active attack pet; otherwise, <c>false</c>.
        /// </value>
        public bool HasActiveAttackPet => AttackPet != null;

        /// <summary>
        /// Gets a value indicating whether this instance has active ability pet.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance has active ability pet; otherwise, <c>false</c>.
        /// </value>
        public bool HasActiveAbilityPet => AbilityPet != null;

        /// <summary>
        /// Gets a value indicating whether this instance has active vehicle.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance has active vehicle; otherwise, <c>false</c>.
        /// </value>
        public bool HasActiveVehicle => Vehicle != null;

        /// <summary>
        /// Gets or sets the attack pet.
        /// </summary>
        /// <value>
        /// The attack pet.
        /// </value>
        public AttackPet AttackPet { get; set; }

        /// <summary>
        /// Gets or sets the vehicle.
        /// </summary>
        /// <value>
        /// The vehicle.
        /// </value>
        public Vehicle Vehicle { get; set; }

        /// <summary>
        /// Gets or sets the ability pet.
        /// </summary>
        /// <value>
        /// The ability pet.
        /// </value>
        public AbilityPet AbilityPet { get; set; }

        /// <summary>
        /// Gets or sets the teleportation.
        /// </summary>
        /// <value>
        /// The teleportation.
        /// </value>
        public Teleportation Teleportation { get; set; }

        /// <summary>
        /// Gets the race.
        /// </summary>
        /// <value>
        /// The race.
        /// </value>
        public ObjectCountry Race
        {
            get
            {
                var refChar = Game.ReferenceManager.GetRefObjChar(ModelId);

                return refChar?.Country ?? ObjectCountry.Unassigned;
            }
        }

        /// <summary>
        /// Gets the gender.
        /// </summary>
        /// <value>
        /// The gender.
        /// </value>
        public ObjectGender Gender
        {
            get
            {
                var refChar = Game.ReferenceManager.GetRefObjChar(ModelId);

                if (refChar == null)
                    return ObjectGender.Neutral;

                return (ObjectGender)refChar.CharGender;
            }
        }

        /// <summary>
        /// Gets the potion refresh interval.
        /// </summary>
        /// <value>
        /// The potion refresh interval.
        /// </value>
        public byte PotionRefreshInterval => Race == ObjectCountry.Chinese ? (byte)1 : (byte)15;

        /// <summary>
        /// Gets or sets the buffs.
        /// </summary>
        /// <value>
        /// The buffs.
        /// </value>
        public List<BuffInfo> Buffs => State?.ActiveBuffs;

        /// <summary>
        /// Gets or sets a value indicating whether [in action].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [in action]; otherwise, <c>false</c>.
        /// </value>
        public bool InAction { get; set; }

        /// <summary>
        /// Gets or sets the bad effect.
        /// </summary>
        /// <value>
        /// The bad effect.
        /// </value>
        public BadEffect BadEffect { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Player"/> is untouchable.
        /// Will be set automatically after telportation.
        /// </summary>
        /// <value>
        ///   <c>true</c> if untouchable; otherwise, <c>false</c>.
        /// </value>
        public bool Untouchable { get; set; }

        /// <summary>
        /// Gets a value indicating whether [in cave].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [in cave]; otherwise, <c>false</c>.
        /// </value>
        public bool IsInDungeon => Tracker.Position.IsInDungeon;

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Player"/> is exchanging.
        /// </summary>
        /// <value>
        ///   <c>true</c> if exchanging; otherwise, <c>false</c>.
        /// </value>
        public bool Exchanging => Exchange != null;

        /// <summary>
        /// The exchange
        /// </summary>
        public Exchange.ExchangeInstance Exchange { get; internal set; }

        /// <summary>
        /// Gets a value indicating whether this <see cref="Player"/> is berzerking.
        /// </summary>
        /// <value>
        ///   <c>true</c> if berzerking; otherwise, <c>false</c>.
        /// </value>
        public bool Berzerking => State.BodyState == BodyState.Hwan || State.BodyState == BodyState.Berzerk;

        /// <summary>
        /// Gets the weapon.
        /// </summary>
        /// <value>
        /// The weapon.
        /// </value>
        public InventoryItem Weapon => Inventory.GetItemAt(6);

        /// <summary>
        /// Gets the ammo amount.
        /// </summary>
        /// <returns></returns>
        public short GetAmmunationAmount(bool fullInventory = false)
        {
            if (!fullInventory)
            {
                var itemAtSlot = Inventory.GetItemAt(7);
                if (itemAtSlot != null && itemAtSlot.Record.TypeID2 == 3 && (itemAtSlot.Record.TypeID3 == 4))
                    return (short)itemAtSlot.Amount;

                if (itemAtSlot == null)
                    return 0;
            }
            else
            {
                var typeIdFilter = new TypeIdFilter
                {
                    TypeID1 = 3,
                    TypeID2 = 3,
                    TypeID3 = 4
                };

                if (GetCurrentAmmunationType() == AmmunitionType.Arrow)
                    typeIdFilter.TypeID4 = 1;
                else if (GetCurrentAmmunationType() == AmmunitionType.Bolt)
                    typeIdFilter.TypeID4 = 2;

                var items = (from item in Inventory.Items where typeIdFilter.EqualsRefItem(item.Record) select item).ToList();
                return (short)items.Aggregate(0, (current, item) => current + item.Amount);
            }

            return -1;
        }

        /// <summary>
        /// Gets the type of the current ammunation.
        /// </summary>
        /// <returns></returns>
        public AmmunitionType GetCurrentAmmunationType()
        {
            var itemAtSlot = Inventory.GetItemAt(7);
            if (itemAtSlot == null || itemAtSlot.Record.TypeID2 != 3 || itemAtSlot.Record.TypeID3 != 4)
                return AmmunitionType.None;

            switch (itemAtSlot.Record.TypeID4)
            {
                case 1:
                    return AmmunitionType.Arrow;

                case 2:
                    return AmmunitionType.Bolt;

                default: //Unknown ammo type
                    return AmmunitionType.None;
            }
        }

        /// <summary>
        /// Moves the specified destination.
        /// </summary>
        /// <param name="destination">The destination.</param>
        /// <param name="sleep">if set to <c>true</c> [sleep].</param>
        /// <returns></returns>
        public bool Move(Position destination, bool sleep = true)
        {
            var distance = Game.Player.Tracker.Position.DistanceTo(destination);
            if (distance > 100)
            {
                Log.Warn("Player.Move: Target position too far away!");
                return false;
            }

            if (HasActiveVehicle)
            {
                Vehicle.Move(destination);
                return true;
            }

            var packet = new Packet(0x7021);
            packet.WriteByte(1);
            packet.WriteUShort(destination.RegionID);

            if (!destination.IsInDungeon)
            {
                packet.WriteShort(destination.XOffset);
                packet.WriteShort(destination.ZOffset);
                packet.WriteShort(destination.YOffset);
            }
            else
            {
                packet.WriteInt(destination.XOffset);
                packet.WriteInt(destination.ZOffset);
                packet.WriteInt(destination.YOffset);
            }

            packet.Lock();

            var awaitCallback = new AwaitCallback(response =>
            {
                var uniqueId = response.ReadUInt();
                return uniqueId == Game.Player.UniqueId;
            }, 0xB021);

            PacketManager.SendPacket(packet, PacketDestination.Server, awaitCallback);
            awaitCallback.AwaitResponse();

            if (!awaitCallback.Timeout)
            {
                if (!sleep) return true;

                //Wait to finish the step
                Thread.Sleep(Convert.ToInt32(distance / Game.Player.Tracker.ActualSpeed * 10000));

                return true;
            }

            return false;
        }

        /// <summary>
        /// Uses the item.
        /// </summary>
        /// <param name="slot">The slot.</param>
        /// <param name="bitMask">The bit mask.</param>
        public bool UseItem(byte slot, ushort bitMask)
        {
            var packet = new Packet(0x704C);
            packet.WriteByte(slot);
            packet.WriteUShort(bitMask);

            packet.Lock();

            var result = false;
            var asyncCallback = new AwaitCallback(response => result = response.ReadByte() == 0x01, 0xB04C);

            PacketManager.SendPacket(packet, PacketDestination.Server, asyncCallback);
            asyncCallback.AwaitResponse(500);

            return result;
        }

        /// <summary>
        /// Uses the item.
        /// </summary>
        /// <param name="sourceSlot">The source slot.</param>
        /// <param name="bitMask">The bit mask.</param>
        /// <param name="destintationSlot">The destintation slot.</param>
        public void UseItem(byte sourceSlot, ushort bitMask, byte destintationSlot)
        {
            var packet = new Packet(0x704C);
            packet.WriteByte(sourceSlot);
            packet.WriteUShort(0x30EC);
            packet.WriteByte(destintationSlot);
            packet.Lock();

            PacketManager.SendPacket(packet, PacketDestination.Server);
        }

        /// <summary>
        /// Uses the health potion.
        /// </summary>
        public bool UseHealthPotion()
        {
            var typeIdFilter = new TypeIdFilter(3, 3, 1, 1);
            var potionItem = (from item in Inventory.Items where typeIdFilter.EqualsRefItem(item.Record) select item).FirstOrDefault();

            if (potionItem == null) return false;

            if (potionItem.Record.CashItem == 1)
                return UseItem(potionItem.Slot, 0x08ED);
            else
                return UseItem(potionItem.Slot, 0x08EC);
        }

        /// <summary>
        /// Uses the health potion.
        /// </summary>
        public bool UseManaPotion()
        {
            var typeIdFilter = new TypeIdFilter(3, 3, 1, 2);
            var potionItem = (from item in Inventory.Items where typeIdFilter.EqualsRefItem(item.Record) select item).FirstOrDefault();

            if (potionItem == null) return false;

            if (potionItem.Record.CashItem == 1)
                return UseItem(potionItem.Slot, 0x10ED);
            else
                return UseItem(potionItem.Slot, 0x10EC);
        }

        /// <summary>
        /// Uses the vigor potion.
        /// </summary>
        /// <returns></returns>
        public bool UseVigorPotion()
        {
            var typeIdFilter = new TypeIdFilter(3, 3, 1, 3);
            var slot = (from item in Inventory.Items where typeIdFilter.EqualsRefItem(item.Record) select item.Slot).FirstOrDefault();

            if (slot == 0) return false;

            return UseItem(slot, 0x18EC);
        }

        /// <summary>
        /// Uses the universal pill.
        /// </summary>
        /// <returns></returns>
        public bool UseUniversalPill()
        {
            var typeIdFilter = new TypeIdFilter(3, 3, 2, 6);
            var slot = (from item in Inventory.Items where typeIdFilter.EqualsRefItem(item.Record) select item.Slot).FirstOrDefault();

            if (slot == 0) return false;

            return UseItem(slot, 0x316C);
        }

        /// <summary>
        /// Summons the ability pet.
        /// </summary>
        /// <returns></returns>
        public bool SummonAbilityPet()
        {
            if (AbilityPet != null) return false;

            var typeIdFilter = new TypeIdFilter(3, 2, 1, 2);
            var slot = (from item in Inventory.Items where typeIdFilter.EqualsRefItem(item.Record) select item.Slot).FirstOrDefault();

            if (slot == 0) return false;

            return UseItem(slot, 0x10CD);
        }

        /// <summary>
        /// Summons the vehicle.
        /// </summary>
        /// <returns></returns>
        public bool SummonVehicle()
        {
            if (HasActiveVehicle) return false;

            var typeIdFilter = new TypeIdFilter(3, 3, 3, 2);
            var vehicleItem = (from item in Inventory.Items where typeIdFilter.EqualsRefItem(item.Record) && item.Record.ReqLevel1 <= Game.Player.Level select item).FirstOrDefault();

            if (vehicleItem == null) return false;

            if (vehicleItem.Record.CashItem == 0x01)
                return UseItem(vehicleItem.Slot, 0x11ED);
            else
                return UseItem(vehicleItem.Slot, 0x11EC);
        }

        /// <summary>
        /// Uses the return scroll.
        /// </summary>
        /// <returns></returns>
        public bool UseReturnScroll()
        {
            var typeIdFilter = new TypeIdFilter(3, 3, 3, 1);
            var slot = (from item in Inventory.Items where typeIdFilter.EqualsRefItem(item.Record) && item.Record.ReqLevel1 <= Game.Player.Level select item.Slot).FirstOrDefault();

            if (slot == 0) return false;

            return UseItem(slot, 0x09EC);
        }

        /// <summary>
        /// Cancels the action.
        /// </summary>
        /// <returns></returns>
        public bool CancelAction()
        {
            var packet = new Packet(0x7074);
            packet.WriteByte(0x02); //Cancel
            packet.Lock();

            var callback = new AwaitCallback(response =>
            {
                return response.ReadByte() == 0x02 && response.ReadByte() == 0x00;
            }, 0xB074);

            PacketManager.SendPacket(packet, PacketDestination.Server, callback);
            callback.AwaitResponse();

            return !callback.Timeout;
        }

        /// <summary>
        /// Casts the self skill.
        /// </summary>
        /// <param name="skillId">The skill identifier.</param>
        public void CastBuff(uint skillId)
        {
            if (!Skills.HasSkill(skillId)) 
                return;

            var skillInfo = Skills.GetSkillInfoById(skillId);

            if (Game.Player.Mana < skillInfo.Record.Consume_MP)
                return;

            var currentWeapon = Inventory.GetItemAt(6);

            //Case 1: This skill can be casted by any weapon
            if (currentWeapon != null && skillInfo.Record.ReqCast_Weapon1 == WeaponType.Any)
            {
                CastBuff(skillInfo);

                return;
            }

            //Case 2: No weapon is equipped and the skill does not require any
            if (currentWeapon == null && skillInfo.Record.ReqCast_Weapon1 == WeaponType.None ||
                currentWeapon == null && skillInfo.Record.ReqCast_Weapon2 == WeaponType.None)
            {
                CastBuff(skillInfo);

                return;
            }

            //Case 3: No current weapon is equiped OR the current weapon does not match the skill requirement
            if (currentWeapon == null ||
                (byte)skillInfo.Record.ReqCast_Weapon1 != currentWeapon.Record.TypeID1 && (byte)skillInfo.Record.ReqCast_Weapon2 != currentWeapon.Record.TypeID4)
            {
                //Try to equip the first weapon type
                if (!EquipWeapon(skillInfo.Record.ReqCast_Weapon1))
                    //That did not work - try to equip the second weapon type
                    if (!EquipWeapon(skillInfo.Record.ReqCast_Weapon2))
                    {
                        Log.Notify($"Can not auto switch weapon for skill {skillInfo.Record.GetRealName()}: No matching weapon found in the player's inventory!");

                        return;
                    }

                CastBuff(skillInfo);

                return;
            }

            //Case 4: This skill can be casted by the current weapon
            if ((byte)skillInfo.Record.ReqCast_Weapon1 == currentWeapon.Record.TypeID4 ||
                (byte)skillInfo.Record.ReqCast_Weapon2 == currentWeapon.Record.TypeID4)
            {
                CastBuff(skillInfo);
            }
        }

        /// <summary>
        /// Casts the skill.
        /// </summary>
        /// <param name="skillId">The skill identifier.</param>
        /// <param name="targetUniqueId">The target unique identifier.</param>
        public bool CastSkill(uint skillId, uint targetUniqueId)
        {
            if (!Skills.HasSkill(skillId))
                return false;

            var skillInfo = Skills.GetSkillInfoById(skillId);

            if (Game.Player.Mana < skillInfo.Record.Consume_MP)
                return false;

            var currentWeapon = Inventory.GetItemAt(6);

            //Case 1: This skill can be casted by any weapon
            if (currentWeapon != null && skillInfo.Record.ReqCast_Weapon1 == WeaponType.Any)
                return CastSkill(skillInfo, targetUniqueId);

            //Case 2: No weapon is equipped and the skill does not require any
            if (currentWeapon == null && skillInfo.Record.ReqCast_Weapon1 == WeaponType.None
                ||
                currentWeapon == null && skillInfo.Record.ReqCast_Weapon2 == WeaponType.None)
                return CastSkill(skillInfo, targetUniqueId);

            //Case 3: No current weapon is equiped OR the current weapon does not match the skill requirement
            if (currentWeapon == null ||
                (byte)skillInfo.Record.ReqCast_Weapon1 != currentWeapon.Record.TypeID4 && (byte)skillInfo.Record.ReqCast_Weapon2 != currentWeapon.Record.TypeID4)
            {
                //Try to equip the first weapon type
                if (EquipWeapon(skillInfo.Record.ReqCast_Weapon1))
                    return CastSkill(skillInfo, targetUniqueId);

                //Try to equip the second weapon type
                if (EquipWeapon(skillInfo.Record.ReqCast_Weapon2))
                    return CastSkill(skillInfo, targetUniqueId);

                Log.Notify($"Can not auto switch weapon for skill {skillInfo.Record.GetRealName()}: No matching weapon found in the player's inventory!");

                return false;
            }

            //Case 4: This skill can be casted by the current weapon
            if ((byte)skillInfo.Record.ReqCast_Weapon1 == currentWeapon.Record.TypeID4 ||
                (byte)skillInfo.Record.ReqCast_Weapon2 == currentWeapon.Record.TypeID4)

                return CastSkill(skillInfo, targetUniqueId);

            return false;
        }

        /// <summary>
        /// Equips the ammunation.
        /// </summary>
        public void EquipAmmunation()
        {
            var currentWeapon = Inventory.GetItemAt(6);
            var currentAmmunation = Inventory.GetItemAt(7);

            if (currentWeapon == null || currentAmmunation != null) return;

            if (currentWeapon.Record.TypeID4 == 6) //Bow
            {
                var ammunation = Inventory.GetItem(new TypeIdFilter(3, 3, 4, 1));
                if (ammunation != null)
                    Inventory.MoveItem(ammunation.Slot, 7);
                else
                    Log.Notify("Could not auto-equip ammunation: No correct ammunation type was found in the player's inventory");
            }
            else if (currentWeapon.Record.TypeID4 == 12) //Crossbow
            {
                var ammunation = Inventory.GetItem(new TypeIdFilter(3, 3, 4, 2));
                if (ammunation != null)
                    Inventory.MoveItem(ammunation.Slot, 7);
                else
                    Log.Notify("Could not auto-equip ammunation: No correct ammunation type was found in the player's inventory");
            }
        }

        /// <summary>
        /// Casts the skill at.
        /// </summary>
        /// <param name="skillId">The skill identifier.</param>
        /// <param name="position">The position.</param>
        public void CastSkillAt(uint skillId, Position position)
        {
            if (!Skills.HasSkill(skillId)) return;

            var packet = new Packet(0x7074);
            packet.WriteByte(1); //Execute
            packet.WriteByte(4); //Use Skill
            packet.WriteUInt(skillId);
            packet.WriteByte(ActionTarget.Area);
            packet.WriteByte(position.XSector);
            packet.WriteByte(position.YSector);
            packet.WriteFloat(position.XOffset);
            packet.WriteFloat(position.ZOffset);
            packet.WriteFloat(position.YOffset);
            packet.Lock();

            PacketManager.SendPacket(packet, PacketDestination.Server);
        }

        /// <summary>
        /// Cancels the buff.
        /// </summary>
        /// <param name="skillId">The skill identifier.</param>
        public void CancelBuff(uint skillId)
        {
            if (!Skills.HasSkill(skillId)) return;

            var packet = new Packet(0x7074);
            packet.WriteByte(1); //Execute
            packet.WriteByte(5); //Cancel Buff
            packet.WriteUInt(skillId);
            packet.WriteByte(ActionTarget.None);

            packet.Lock();
            PacketManager.SendPacket(packet, PacketDestination.Server);
        }

        /// <summary>
        /// Pickups the specified item unique identifier.
        /// </summary>
        /// <param name="itemUniqueId">The item unique identifier.</param>
        public void Pickup(uint itemUniqueId)
        {
            var item = Game.Spawns.GetItem(itemUniqueId);

            if (item == null) return;

            if (CollisionManager.HasCollisionBetween(item.Position, Tracker.Position))
                return;

            var packet = new Packet(0x7074);
            packet.WriteByte(1); //Execute
            packet.WriteByte(2); //Use Skill
            packet.WriteByte(ActionTarget.Entity);
            packet.WriteUInt(itemUniqueId);

            packet.Lock();

            var distance = Game.Player.Tracker.Position.DistanceTo(item.Position);
            if (distance > 1000)
                Log.Warn("Item too far away @" + distance);

            var asyncResult = new AwaitCallback(response =>
            {
                return response.ReadByte() == 2 && response.ReadByte() == 0;
            }, 0xB074);
            PacketManager.SendPacket(packet, PacketDestination.Server, asyncResult);
            asyncResult.AwaitResponse();
        }

        /// <summary>
        /// Revives the attack pet.
        /// </summary>
        /// <returns></returns>
        public bool ReviveAttackPet()
        {
            var typeIdFilter = new TypeIdFilter(3, 3, 1, 6);
            var rescueItem = Inventory.GetItem(typeIdFilter);

            if (rescueItem == null) return false;

            typeIdFilter = new TypeIdFilter(3, 2, 1, 1);
            var petItem = Inventory.GetItem(typeIdFilter);

            if (petItem == null) return false;

            UseItem(rescueItem.Slot, 0x30EC, petItem.Slot);

            return true;
        }

        /// <summary>
        /// Summons the attack pet.
        /// </summary>
        /// <returns></returns>
        public bool SummonAttackPet()
        {
            if (AttackPet != null)
                return false;

            var typeIdFilter = new TypeIdFilter(3, 2, 1, 1);
            var petItem = Inventory.GetItem(typeIdFilter);

            if (petItem == null)
                return false;

            if (petItem.State == InventoryItemState.Summoned || petItem.State == InventoryItemState.Dead)
                return false;

            Log.Notify("Summoning attack pet");

            if (petItem.Record.CashItem == 0x01)
                return UseItem(petItem.Slot, 0x08CD);
            else
                return UseItem(petItem.Slot, 0x08CC);
        }

        /// <summary>
        /// Equips the weapons.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="fallback">The fallback.</param>
        /// <returns></returns>
        public bool EquipWeapon(WeaponType type)
        {
            var typeIdFilter = new TypeIdFilter(3, 1, 6, (byte)type);
            var items = Inventory.GetItems(typeIdFilter);

            if (items == null)
                return false;

            if (InAction)
            {
                Log.Debug("Player is in action, canceling it now.");

                for (var i = 1; i < 5; i++)
                    if (CancelAction())
                        break;
            }

            if (Inventory.GetItem(typeIdFilter)?.Slot == 6)
                return true; // already equiped

            // find high level item
            InventoryItem nearestItem = null;
            foreach (var item in items)
            {
                if (nearestItem == null)
                    nearestItem = item;
                else
                {
                    if (nearestItem.Record.ReqLevel1 > nearestItem.Record.ReqLevel1 && nearestItem.OptLevel > item.OptLevel)
                        nearestItem = item;
                }
            }

            return nearestItem != null && Inventory.MoveItem(nearestItem.Slot, 6);
        }

        /// <summary>
        /// Selects the entity.
        /// </summary>
        /// <param name="uniqueId">The unique identifier.</param>
        /// <returns></returns>
        public bool SelectEntity(uint uniqueId)
        {
            var packet = new Packet(0x7045);
            packet.WriteUInt(uniqueId);
            packet.Lock();

            var awaitCallback = new AwaitCallback(response =>
            {
                var result = response.ReadByte() == 0x01;

                if (!result)
                    Log.Error("Could not select entity 0x" + response.ReadUShort());

                return result;
            }, 0xB045);
            PacketManager.SendPacket(packet, PacketDestination.Server, awaitCallback);
            awaitCallback.AwaitResponse();

            return !awaitCallback.Timeout;
        }

        /// <summary>
        /// Deselects the entity.
        /// </summary>
        /// <returns></returns>
        public bool DeselectEntity()
        {
            if (Game.SelectedEntity == null || Game.SelectedEntity.Bionic == null) return true;

            var packet = new Packet(0x704B);
            packet.WriteUInt(Game.SelectedEntity.Bionic.UniqueId);
            packet.Lock();

            var awaitResult = new AwaitCallback(null, 0xB04B);
            PacketManager.SendPacket(packet, PacketDestination.Server, awaitResult);
            awaitResult.AwaitResponse();

            return !awaitResult.Timeout;
        }

        /// <summary>
        /// Enters the berzerk mode.
        /// </summary>
        public void EnterBerzerkMode()
        {
            if (!CanEnterBerzerk) return;

            var packet = new Packet(0x70A7);
            packet.WriteByte(0x1); //Enter HWAN
            packet.Lock();

            var callback = new AwaitCallback(null, 0xB0A7);
            PacketManager.SendPacket(packet, PacketDestination.Server, callback);
            callback.AwaitResponse(500);
        }

        /// <summary>
        /// Casts the skill. Does not check any weapon requirement.
        /// </summary>
        /// <param name="skill"></param>
        /// <param name="targetId"></param>
        /// <returns></returns>
        private bool CastSkill(SkillInfo skill, uint targetId)
        {
            var packet = new Packet(0x7074);
            packet.WriteByte(1); //Execute
            packet.WriteByte(4); //Use Skill
            packet.WriteUInt(skill.Id);
            packet.WriteByte(ActionTarget.Entity);
            packet.WriteUInt(targetId);

            packet.Lock();

            var awaitCallBack = new AwaitCallback(response =>
            {
                var result = response.ReadByte();
                var code = response.ReadUShort();
                if (result == 0x2)
                {
                    Log.Error($"Skill error code: 0x{code:X2}");
                }

                return result == 0x01 && Action.FromPacket(response).PlayerIsExecutor;
            }, 0xB070);

            PacketManager.SendPacket(packet, PacketDestination.Server, awaitCallBack);
            awaitCallBack.AwaitResponse(skill.Record.Action_CastingTime + skill.Record.Action_ActionDuration + 1000);

            return !awaitCallBack.Timeout;
        }

        /// <summary>
        /// Casts the skill. Does not check any weapon requirement.
        /// </summary>
        /// <param name="skill"></param>
        /// <param name="targetId"></param>
        /// <returns></returns>
        public bool CastAutoAttack(uint targetId)
        {
            var packet = new Packet(0x7074);
            packet.WriteByte(1); //Execute
            packet.WriteByte(1); //Use Skill
            packet.WriteByte(ActionTarget.Entity);
            packet.WriteUInt(targetId);
            packet.Lock();

            var awaitCallBack = new AwaitCallback(response =>
            {
                var result = response.ReadByte();
                var code = response.ReadUShort();

                if (result == 0x01)
                    return Action.FromPacket(response).PlayerIsExecutor;
                else if (result == 0x02)
                {
                    if (code != 1025) return true;
                    //Insufficient ammunation, try to equip it
                    EquipAmmunation();
                }

                return false;
            }, 0xB070);

            PacketManager.SendPacket(packet, PacketDestination.Server, awaitCallBack);
            awaitCallBack.AwaitResponse(2000);

            return !awaitCallBack.Timeout;
        }

        /// <summary>
        /// Casts the skill. Does not check any weapon requirements.
        /// </summary>
        /// <param name="skillInfo"></param>
        private void CastBuff(SkillInfo skillInfo)
        {
            Log.Notify($"Casting skill (self-buff) [{skillInfo.Record.GetRealName()}]");

            var packet = new Packet(0x7074);
            packet.WriteByte(1); //Execute
            packet.WriteByte(4); //Use Skill
            packet.WriteUInt(skillInfo.Id);
            packet.WriteByte(ActionTarget.None);

            packet.Lock();

            var asyncCallback = new AwaitCallback(response => 
            {
                var targetId = response.ReadUInt();
                var skillId = response.ReadUInt();

                if (targetId == Game.Player.UniqueId && skillId == skillInfo.Id)
                    return true;

                return false;

            }, 0xB0BD);

            PacketManager.SendPacket(packet, PacketDestination.Server, asyncCallback);
            asyncCallback.AwaitResponse(skillInfo.Record.Action_CastingTime + skillInfo.Record.Action_ActionDuration + 1500);
        }
    }
}