﻿using RSBot.Core.Client.ReferenceObjects;
using RSBot.Core.Components;
using RSBot.Core.Network;
using RSBot.Core.Objects.Skill;
using RSBot.Core.Objects.Spawn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace RSBot.Core.Objects
{
    public class Player : SpawnedBionic
    {
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
        public int _lastHpPotionTick;

        /// <summary>
        /// Gets or sets the last mp potion item tick count
        /// </summary>
        private int _lastMpPotionTick;

        /// <summary>
        /// Gets or sets the last vigor potion item tick count
        /// </summary>
        private int _lastVigorPotionTick;

        /// <summary>
        /// Gets or sets the last universal pill potion item tick count
        /// </summary>
        private int _lastUniversalPillTick;

        /// <summary>
        /// Gets or sets the last purification pill potion item tick count
        /// </summary>
        private int _lastPurificationPillTick;
        
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="objId"></param>
        public Player(uint objId) : base(objId)
        {

        }

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
        public bool MoveTo(Position destination, bool sleep = true)
        {
            var distance = Game.Player.Movement.Source.DistanceTo(destination);
            if (distance > 150)
            {
                Log.Warn("Player.Move: Target position too far away!");

                // Stop the bot for now! NEED IDEA!
                Kernel.Bot.Stop();

                return false;
            }

            if (HasActiveVehicle)
            {
                Vehicle.MoveTo(destination);
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
                return uniqueId == Game.Player.UniqueId ? AwaitCallbackResult.Received : AwaitCallbackResult.None;
            }, 0xB021);

            PacketManager.SendPacket(packet, PacketDestination.Server, awaitCallback);
            awaitCallback.AwaitResponse();

            if (awaitCallback.IsCompleted)
            {
                if (!sleep) return true;

                //Wait to finish the step
                Thread.Sleep(Convert.ToInt32(distance / Game.Player.ActualSpeed * 10000));

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
            if (State.ScrollState != ScrollState.Cancel)
                return false;

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
                return response.ReadByte() == 0x02 && response.ReadByte() == 0x00
                ? AwaitCallbackResult.Received : AwaitCallbackResult.None;
            }, 0xB074);

            PacketManager.SendPacket(packet, PacketDestination.Server, callback);
            callback.AwaitResponse();

            return callback.IsCompleted;
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
    }
}