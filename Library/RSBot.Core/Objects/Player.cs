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
        public long Experience { get; set; }

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
        /// Gets or sets the last hp potion item tick count
        /// </summary>
        public int _lastHpPotionTick { get; private set; }

        /// <summary>
        /// Gets or sets the last mp potion item tick count
        /// </summary>
        public int _lastMpPotionTick { get; private set; }

        /// <summary>
        /// Gets or sets the last vigor potion item tick count
        /// </summary>
        public int _lastVigorPotionTick { get; private set; }

        /// <summary>
        /// Gets or sets the last universal pill potion item tick count
        /// </summary>
        public int _lastUniversalPillTick { get; private set; }

        /// <summary>
        /// Gets or sets the last purification pill potion item tick count
        /// </summary>
        public int _lastPurificationPillTick { get; private set; }

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
                
                // Stop the bot for now! NEED IDEA!
                Kernel.Bot.Stop();

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
        /// Uses the health potion.
        /// </summary>
        public bool UseHealthPotion()
        {
            if (State.LifeState == LifeState.Dead)
                return false;

            var elapsed = Environment.TickCount - _lastHpPotionTick;
            if (Race == ObjectCountry.Chinese && elapsed < 1000)
                return false;

            if (Race == ObjectCountry.Europe && elapsed < 15000)
                return false;

            var typeIdFilter = new TypeIdFilter(3, 3, 1, 1);
            var potionItem = Inventory.GetItem(typeIdFilter);
            if (potionItem == null)
                return false;

            var result = potionItem.Use();

            //if(result)
                _lastHpPotionTick = Environment.TickCount;

            return result;
        }

        /// <summary>
        /// Uses the health potion.
        /// </summary>
        public bool UseManaPotion()
        {
            if (State.LifeState == LifeState.Dead)
                return false;

            var elapsed = Environment.TickCount - _lastMpPotionTick;
            if (Race == ObjectCountry.Chinese && elapsed < 1000)
                return false;

            if (Race == ObjectCountry.Europe && elapsed < 15000)
                return false;

            var typeIdFilter = new TypeIdFilter(3, 3, 1, 2);
            var potionItem = Inventory.GetItem(typeIdFilter);
            if (potionItem == null)
                return false;

            var result = potionItem.Use();

            //if(result)
                _lastMpPotionTick = Environment.TickCount;

            return result;
        }

        /// <summary>
        /// Uses the vigor potion.
        /// </summary>
        /// <returns></returns>
        public bool UseVigorPotion()
        {
            if (State.LifeState == LifeState.Dead)
                return false;

            var typeIdFilter = new TypeIdFilter(3, 3, 1, 3);
            var item = Inventory.GetItem(typeIdFilter);
            if (item == null)
                return false;

            var elapsed = Environment.TickCount - _lastVigorPotionTick;

            var normalPotion = item.Record.CodeName.Contains("_POTION_");
            if (Race == ObjectCountry.Chinese && elapsed < (normalPotion ? 1000 : 4000))
                return false;

            if (Race == ObjectCountry.Europe && elapsed < (normalPotion ? 15000 : 4000))
                return false;

            _lastVigorPotionTick = Environment.TickCount;

            return item.Use();
        }

        /// <summary>
        /// Uses the universal pill.
        /// </summary>
        /// <returns></returns>
        public bool UseUniversalPill()
        {
            if (State.LifeState == LifeState.Dead)
                return false;

            var elapsed = Environment.TickCount - _lastUniversalPillTick;
            if (elapsed < 1000)
                return false;

            var typeIdFilter = new TypeIdFilter(3, 3, 2, 6);
            var slotItem = Inventory.GetItem(typeIdFilter);
            if (slotItem == null)
                return false;

            var result = slotItem.Use();
            if (result)
                _lastUniversalPillTick = Environment.TickCount;

            return result;
        }

        /// <summary>
        /// Uses the purification pill.
        /// </summary>
        /// <returns></returns>
        public bool UsePurificationPill()
        {
            if (State.LifeState == LifeState.Dead)
                return false;

            var elapsed = Environment.TickCount - _lastPurificationPillTick;
            if (elapsed < 20000)
                return false;

            var typeIdFilter = new TypeIdFilter(3, 3, 2, 1);
            var slotItem = Inventory.GetItem(typeIdFilter);
            if (slotItem == null)
                return false;

            var result = slotItem.Use();
            if (result)
                _lastPurificationPillTick = Environment.TickCount;

            return result;
        }

        /// <summary>
        /// Summons the ability pet.
        /// </summary>
        /// <returns></returns>
        public bool SummonAbilityPet()
        {
            if (AbilityPet != null) return false;

            var typeIdFilter = new TypeIdFilter(3, 2, 1, 2);
            var slotItem = (from item in Inventory.Items where typeIdFilter.EqualsRefItem(item.Record) select item).FirstOrDefault();
            if (slotItem == null) 
                return false;

            return slotItem.Use();
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
            if (vehicleItem == null) 
                return false;

            return vehicleItem.Use();
        }

        /// <summary>
        /// Uses the return scroll.
        /// </summary>
        /// <returns></returns>
        public bool UseReturnScroll()
        {
            var typeIdFilter = new TypeIdFilter(3, 3, 3, 1);
            var slotItem = (from item in Inventory.Items where typeIdFilter.EqualsRefItem(item.Record) && item.Record.ReqLevel1 <= Game.Player.Level select item).FirstOrDefault();
            if (slotItem == null)
                return false;

            return slotItem.Use();
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

            if (rescueItem == null) 
                return false;

            typeIdFilter = new TypeIdFilter(3, 2, 1, 1);
            var petItem = Inventory.GetItem(typeIdFilter);

            if (petItem == null) 
                return false;

            rescueItem.UseTo(petItem.Slot);
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

            return petItem.Use();
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
        /// Check required of the using skill
        /// </summary>
        /// <param name="skill">The using skill</param>
        public bool CheckSkillRequired(RefSkill skill)
        {
            InventoryItem requiredItem = null;
            TypeIdFilter filter = null;

            var currentWeapon = Inventory.GetItemAt(6);
            if (skill.ReqCast_Weapon1 == WeaponType.Any)
            {
                var list = new List<TypeIdFilter>(8);

                for (int i = 0; i < skill.Params.Count; i++)
                {
                    var param = skill.Params[i];
                    if (param != 1919250793)
                        continue;

                    var paramTypeId3 = (byte)skill.Params[++i];
                    var paramTypeId4 = (byte)skill.Params[++i];
                    list.Add(new TypeIdFilter(3, 1, paramTypeId3, paramTypeId4));
                }

                if (list.Count == 0)
                    return true;

                filter = list.FirstOrDefault(p => p.TypeID3 == currentWeapon.Record.TypeID3 && p.TypeID4 == currentWeapon.Record.TypeID4);
                if (filter != null)
                    return true;
                
                filter = list.FirstOrDefault();
            }
            else
            {
                filter = new TypeIdFilter(p =>
                    p.TypeID2 == 1 && p.TypeID3 == 6 && (
                    p.TypeID4 == (byte)skill.ReqCast_Weapon1 ||
                    ((byte)skill.ReqCast_Weapon2 != 0xFF && p.TypeID4 == (byte)skill.ReqCast_Weapon2)
                ));
            }

            requiredItem = Inventory.GetItemBest(filter);
            if (requiredItem == null)
                return false;

            var movingSlot = (byte)(requiredItem.Record.TypeID3 == 6 ? 6 : 7);
            if (requiredItem.Slot == movingSlot)
                return true;

            if(movingSlot == 6 && requiredItem.Record.TwoHanded == 0)
            {
                // find and wear the shield item automaticaly
                filter = new TypeIdFilter(3, 1, 4, (byte)(Game.Player.Race == ObjectCountry.Chinese ? 1 : 2));
                var shieldItem = Inventory.GetItemBest(filter);
                if (shieldItem != null && shieldItem.Slot != 7)
                    Inventory.MoveItem(shieldItem.Slot, 7);
            }

            return Inventory.MoveItem(requiredItem.Slot, movingSlot);
        }

        /// <summary>
        /// Casts the skill.
        /// </summary>
        /// <param name="skillId">The skill identifier.</param>
        /// <param name="targetUniqueId">The target unique identifier.</param>
        public bool CastSkill(uint skillId, uint targetId)
        {
            if (!Skills.HasSkill(skillId))
                return false;

            var skill = Skills.GetSkillInfoById(skillId);
            if (!CheckSkillRequired(skill.Record))
                return false;

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
                
                if (result == 2)
                {
                    switch (code)
                    {
                        case 0x300E:
                            EquipAmmunation();
                            break;

                        case 0x3006: // invalid target
                        case 0x3010: // obstacle
                            break;
                        default:
                            Log.Error($"Invalid skill error code: 0x{code:X2}");
                            break;
                    }

                    return false;
                }

                var action = Action.FromPacket(response);

                return action.SkillId == skill.Id && action.PlayerIsExecutor;
            }, 0xB070);

            var callback = new AwaitCallback(response =>
            {
                return response.ReadByte() == 0x02 && response.ReadByte() == 0x00;
            }, 0xB074);

            PacketManager.SendPacket(packet, PacketDestination.Server, awaitCallBack, callback);
            awaitCallBack.AwaitResponse(skill.Record.Action_CastingTime + skill.Record.Action_ActionDuration + skill.Record.Action_PreparingTime);
            callback.AwaitResponse();

            return !awaitCallBack.Timeout;
        }

        /// <summary>
        /// Casts the buff skill.
        /// </summary>
        /// <param name="skillId">The skill identifier.</param>
        public void CastBuff(uint skillId, uint target = 0)
        {
            if (!Skills.HasSkill(skillId))
                return;

            var skill = Skills.GetSkillInfoById(skillId);
            if (!CheckSkillRequired(skill.Record))
                return;

            Log.Notify($"Casting skill (self-buff) [{skill.Record.GetRealName()}]");

            var packet = new Packet(0x7074);
            packet.WriteByte(1); //Execute
            packet.WriteByte(4); //Use Skill
            packet.WriteUInt(skill.Id);

            if(skill.Record.TargetGroup_Self || 
               skill.Record.TargetGroup_Party)
            {
                packet.WriteByte(ActionTarget.Entity);
                packet.WriteUInt(target == 0 ? UniqueId : target);
            }
            else
                packet.WriteByte(ActionTarget.None);

            packet.Lock();

            var asyncCallback = new AwaitCallback(response =>
            {
                var targetId = response.ReadUInt();
                var castedSkillId = response.ReadUInt();

                if (targetId == Game.Player.UniqueId && castedSkillId == skillId)
                    return true;

                return false;

            }, 0xB0BD);

            var callback = new AwaitCallback(response =>
            {
                return response.ReadByte() == 0x02 && response.ReadByte() == 0x00;
            }, 0xB074);

            PacketManager.SendPacket(packet, PacketDestination.Server, asyncCallback, callback);

            asyncCallback.AwaitResponse(skill.Record.Action_CastingTime +
                                        skill.Record.Action_ActionDuration +
                                        skill.Record.Action_PreparingTime + 1500);
            
            if(skill.Record.Basic_Activity != 1)
                callback.AwaitResponse();
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
                    switch (code)
                    {
                        case 0x300E:
                            EquipAmmunation();
                            break;

                        case 0x3006: // invalid target
                        case 0x3010: // obstacle
                            break;
                        default:
                            Log.Error($"Invalid skill error code: 0x{code:X2}");
                            break;
                    }
                }

                return false;
            }, 0xB070);

            PacketManager.SendPacket(packet, PacketDestination.Server, awaitCallBack);
            awaitCallBack.AwaitResponse(2000);

            return !awaitCallBack.Timeout;
        }
    }
}