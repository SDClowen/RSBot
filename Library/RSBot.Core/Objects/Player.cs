using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using RSBot.Core.Client.ReferenceObjects;
using RSBot.Core.Event;
using RSBot.Core.Network;
using RSBot.Core.Objects.Cos;
using RSBot.Core.Objects.Exchange;
using RSBot.Core.Objects.Inventory;
using RSBot.Core.Objects.Job;
using RSBot.Core.Objects.Quests;
using RSBot.Core.Objects.Skill;
using RSBot.Core.Objects.Spawn;

namespace RSBot.Core.Objects;

public class Player : SpawnedBionic
{
    /// <summary>
    ///     Gets or sets the last hp potion item duration
    /// </summary>
    private int _lastHPDuration;

    /// <summary>
    ///     Gets or sets the last hp potion item tick count
    /// </summary>
    public int _lastHpPotionTick;

    /// <summary>
    ///     Gets or sets the last mp potion item duration
    /// </summary>
    private int _lastMPDuration;

    /// <summary>
    ///     Gets or sets the last mp potion item tick count
    /// </summary>
    private int _lastMpPotionTick;

    /// <summary>
    ///     Gets or sets the last purification pill potion item tick count
    /// </summary>
    private int _lastPurificationPillTick;

    /// <summary>
    ///     Gets or sets the last universal pill potion item tick count
    /// </summary>
    private int _lastUniversalPillTick;

    /// <summary>
    ///     Gets or sets the last vigor potion item duration
    /// </summary>
    private int _lastVigorDuration;

    /// <summary>
    ///     Gets or sets the last vigor potion item tick count
    /// </summary>
    private int _lastVigorPotionTick;

    /// <summary>
    ///     <inheritdoc />
    /// </summary>
    /// <param name="objId"></param>
    public Player(uint objId)
        : base(objId) { }

    /// <summary>
    ///     Gets or sets the scale.
    /// </summary>
    /// <value>
    ///     The scale.
    /// </value>
    public byte Scale { get; set; }

    /// <summary>
    ///     Gets or sets the level.
    /// </summary>
    /// <value>
    ///     The level.
    /// </value>
    public byte Level { get; set; }

    /// <summary>
    ///     Gets or sets the maximum level.
    /// </summary>
    /// <value>
    ///     The maximum level.
    /// </value>
    public byte MaxLevel { get; set; }

    /// <summary>
    ///     Gets or sets the experience offset.
    /// </summary>
    /// <value>
    ///     The experience offset.
    /// </value>
    public long Experience { get; set; }

    /// <summary>
    ///     Gets or sets the skill experience.
    /// </summary>
    /// <value>
    ///     The skill experience.
    /// </value>
    public uint SkillExperience { get; set; }

    /// <summary>
    ///     Gets or sets the gold.
    /// </summary>
    /// <value>
    ///     The gold.
    /// </value>
    public ulong Gold { get; set; }

    /// <summary>
    ///     Gets or sets the skill points.
    /// </summary>
    /// <value>
    ///     The skill points.
    /// </value>
    public uint SkillPoints { get; set; }

    /// <summary>
    ///     Gets or sets the stat points.
    /// </summary>
    /// <value>
    ///     The stat points.
    /// </value>
    public ushort StatPoints { get; set; }

    /// <summary>
    ///     Gets or sets the berzerk points.
    /// </summary>
    /// <value>
    ///     The berzerk points.
    /// </value>
    public byte BerzerkPoints { get; set; }

    /// <summary>
    ///     Gets a value indicating whether this instance can use berzerk.
    /// </summary>
    /// <value>
    ///     <c>true</c> if this instance can use berzerk; otherwise, <c>false</c>.
    /// </value>
    public bool CanEnterBerzerk => BerzerkPoints == 5 && State.BodyState != BodyState.Hwan;

    /// <summary>
    ///     Gets or sets the experience.
    /// </summary>
    /// <value>
    ///     The experience.
    /// </value>
    public uint ExperienceChunk { get; set; }

    /// <summary>
    ///     Gets or sets the mana.
    /// </summary>
    /// <value>
    ///     The mana.
    /// </value>
    public int Mana { get; set; }

    /// <summary>
    ///     Gets or sets the automatic inverst experience.
    /// </summary>
    /// <value>
    ///     The automatic inverst experience.
    /// </value>
    public AutoInverstType AutoInverstExperience { get; set; }

    /// <summary>
    ///     Gets or sets the daily pk.
    /// </summary>
    /// <value>
    ///     The daily pk.
    /// </value>
    public byte DailyPK { get; set; }

    /// <summary>
    ///     Gets or sets the total pk.
    /// </summary>
    /// <value>
    ///     The total pk.
    /// </value>
    public ushort TotalPK { get; set; }

    /// <summary>
    ///     Gets or sets the pk penalty point.
    /// </summary>
    /// <value>
    ///     The pk penalty point.
    /// </value>
    public uint PKPenaltyPoint { get; set; }

    /// <summary>
    ///     Gets or sets the berzerk level.
    /// </summary>
    /// <value>
    ///     The berzerk level.
    /// </value>
    public byte BerzerkLevel { get; set; }

    /// <summary>
    ///     Gets or sets the PVP flag.
    /// </summary>
    /// <value>
    ///     The PVP flag.
    /// </value>
    public PvpFlag PvpFlag { get; set; }

    /// <summary>
    ///     Gets or sets the skills.
    /// </summary>
    /// <value>
    ///     The skills.
    /// </value>
    public Skills Skills { get; set; }

    /// <summary>
    ///     Gets or sets the skills.
    /// </summary>
    /// <value>
    ///     The skills.
    /// </value>
    public QuestLog QuestLog { get; set; }

    /// <summary>
    ///     Gets or sets the name.
    /// </summary>
    /// <value>
    ///     The name.
    /// </value>
    public string Name { get; set; }

    /// <summary>
    ///     Gets or sets the in combat.
    /// </summary>
    /// <value>
    ///     The in combat.
    /// </value>
    public bool InCombat { get; set; }

    /// <summary>
    ///     Gets or sets the physical attack minimum.
    /// </summary>
    /// <value>
    ///     The physical attack minimum.
    /// </value>
    public uint PhysicalAttackMin { get; set; }

    /// <summary>
    ///     Gets or sets the physical attack maximum.
    /// </summary>
    /// <value>
    ///     The physical attack maximum.
    /// </value>
    public uint PhysicalAttackMax { get; set; }

    /// <summary>
    ///     Gets or sets the magical attack minimum.
    /// </summary>
    /// <value>
    ///     The magical attack minimum.
    /// </value>
    public uint MagicalAttackMin { get; set; }

    /// <summary>
    ///     Gets or sets the magical attack maximum.
    /// </summary>
    /// <value>
    ///     The magical attack maximum.
    /// </value>
    public uint MagicalAttackMax { get; set; }

    /// <summary>
    ///     Gets or sets the physical defence.
    /// </summary>
    /// <value>
    ///     The physical defence.
    /// </value>
    public ushort PhysicalDefence { get; set; }

    /// <summary>
    ///     Gets or sets the magical defence.
    /// </summary>
    /// <value>
    ///     The magical defence.
    /// </value>
    public ushort MagicalDefence { get; set; }

    /// <summary>
    ///     Gets or sets the hit rate.
    /// </summary>
    /// <value>
    ///     The hit rate.
    /// </value>
    public ushort HitRate { get; set; }

    /// <summary>
    ///     Gets or sets the parry rate.
    /// </summary>
    /// <value>
    ///     The parry rate.
    /// </value>
    public ushort ParryRate { get; set; }

    /// <summary>
    ///     Gets or sets the maximum health.
    /// </summary>
    /// <value>
    ///     The maximum health.
    /// </value>
    public int MaximumHealth { get; set; }

    /// <summary>
    ///     Gets or sets the maximum mana.
    /// </summary>
    /// <value>
    ///     The maximum mana.
    /// </value>
    public int MaximumMana { get; set; }

    /// <summary>
    ///     Gets or sets the strength.
    /// </summary>
    /// <value>
    ///     The strength.
    /// </value>
    public ushort Strength { get; set; }

    /// <summary>
    ///     Gets or sets the intelligence.
    /// </summary>
    /// <value>
    ///     The intelligence.
    /// </value>
    public ushort Intelligence { get; set; }

    /// <summary>
    ///     Gets or sets the job information.
    /// </summary>
    /// <value>
    ///     The job information.
    /// </value>
    public JobInfo JobInformation { get; set; }

    /// <summary>
    ///     Gets or sets a value indicating whether [on transport].
    /// </summary>
    /// <value>
    ///     <c>true</c> if [on transport]; otherwise, <c>false</c>.
    /// </value>
    public bool OnTransport { get; set; }

    /// <summary>
    ///     Gets or sets the transport unique identifier.
    /// </summary>
    /// <value>
    ///     The transport unique identifier.
    /// </value>
    public uint TransportUniqueId { get; set; }

    /// <summary>
    ///     Gets or sets the account identifier.
    /// </summary>
    /// <value>
    ///     The account identifier.
    /// </value>
    public uint JID { get; set; }

    /// <summary>
    ///     Gets or sets a value indicating whether this instance is gm.
    /// </summary>
    /// <value>
    ///     <c>true</c> if this instance is gm; otherwise, <c>false</c>.
    /// </value>
    public bool IsGameMaster { get; set; }

    /// <summary>
    ///     Gets a value indicating whether this instance has active attack pet.
    /// </summary>
    /// <value>
    ///     <c>true</c> if this instance has active attack pet; otherwise, <c>false</c>.
    /// </value>
    public bool HasActiveAttackPet => Growth != null;

    /// <summary>
    ///     Gets a value indicating whether this instance has active fellow pet.
    /// </summary>
    /// <value>
    ///     <c>true</c> if this instance has active fellow pet; otherwise, <c>false</c>.
    /// </value>
    public bool HasActiveFellowPet => Fellow != null;

    /// <summary>
    ///     Gets a value indicating whether this instance has active ability pet.
    /// </summary>
    /// <value>
    ///     <c>true</c> if this instance has active ability pet; otherwise, <c>false</c>.
    /// </value>
    public bool HasActiveAbilityPet => AbilityPet != null;

    /// <summary>
    ///     Gets a value indicating whether this instance has active vehicle.
    /// </summary>
    /// <value>
    ///     <c>true</c> if this instance has active vehicle; otherwise, <c>false</c>.
    /// </value>
    public bool HasActiveVehicle => Vehicle != null;

    /// <summary>
    ///     Gets or sets the attack pet.
    /// </summary>
    /// <value>
    ///     The attack pet.
    /// </value>
    public Growth Growth { get; set; }

    /// <summary>
    ///     Gets or sets the attack pet.
    /// </summary>
    /// <value>
    ///     The attack pet.
    /// </value>
    public Fellow Fellow { get; set; }

    /// <summary>
    ///     Gets or sets the vehicle.
    /// </summary>
    /// <value>
    ///     The vehicle.
    /// </value>
    public Transport Transport { get; set; }

    /// <summary>
    ///     Gets or sets the vehicle.
    /// </summary>
    /// <value>
    ///     The vehicle.
    /// </value>
    public JobTransport JobTransport { get; set; }

    /// <summary>
    ///     Gets or sets the ability pet.
    /// </summary>
    /// <value>
    ///     The ability pet.
    /// </value>
    public Ability AbilityPet { get; set; }

    /// <summary>
    ///     Gets or sets the mounted pet.
    /// </summary>
    /// <value>
    ///     The mounted pet.
    /// </value>
    public Cos.Cos Vehicle { get; set; }

    /// <summary>
    ///     Gets or sets the teleportation.
    /// </summary>
    /// <value>
    ///     The teleportation.
    /// </value>
    public Teleportation Teleportation { get; set; }

    /// <summary>
    ///     Gets or sets the Character's Inventory.
    /// </summary>
    /// <value>
    ///     The Character's Inventory.
    /// </value>
    public CharacterInventory Inventory { get; set; }

    /// <summary>
    ///     Gets or sets the Avatar Inventory.
    /// </summary>
    /// <value>
    ///     The Avatar Inventory.
    /// </value>
    public InventoryItemCollection Avatars { get; set; }

    /// <summary>
    ///     Gets or sets the Job2 Inventory.
    /// </summary>
    /// <value>
    ///     The Job2 Inventory.
    /// </value>
    public InventoryItemCollection Job2 { get; set; }

    /// <summary>
    ///     Gets or sets the Specialty Good Box Inventory.
    /// </summary>
    /// <value>
    ///     The Job2 Specialty Good Box Inventory.
    /// </value>
    public InventoryItemCollection Job2SpecialtyBag { get; set; }

    /// <summary>
    ///     Gets or sets the Storage.
    /// </summary>
    /// <value>
    ///     The Storage.
    /// </value>
    public Storage Storage { get; set; }

    /// <summary>
    ///     Gets or sets the GuildStorage.
    /// </summary>
    /// <value>
    ///     The GuildStorage.
    /// </value>
    public Storage GuildStorage { get; set; }

    /// <summary>
    ///     Gets or sets a value indicating whether [in action].
    /// </summary>
    /// <value>
    ///     <c>true</c> if [in action]; otherwise, <c>false</c>.
    /// </value>
    public bool InAction { get; set; }

    /// <summary>
    ///     Gets or sets a value indicating whether this <see cref="Player" /> is untouchable.
    ///     Will be set automatically after telportation.
    /// </summary>
    /// <value>
    ///     <c>true</c> if untouchable; otherwise, <c>false</c>.
    /// </value>
    public bool Untouchable => State.BodyState == BodyState.Untouchable;

    /// <summary>
    ///     Gets or sets a value indicating whether this <see cref="Player" /> is exchanging.
    /// </summary>
    /// <value>
    ///     <c>true</c> if exchanging; otherwise, <c>false</c>.
    /// </value>
    public bool Exchanging => Exchange != null;

    /// <summary>
    ///     The exchange
    /// </summary>
    public ExchangeInstance Exchange { get; internal set; }

    /// <summary>
    ///     Gets a value indicating whether this <see cref="Player" /> is berzerking.
    /// </summary>
    /// <value>
    ///     <c>true</c> if berzerking; otherwise, <c>false</c>.
    /// </value>
    public bool Berzerking => State.BodyState == BodyState.Hwan || State.BodyState == BodyState.Berzerk;

    /// <summary>
    ///     Gets the weapon.
    /// </summary>
    /// <value>
    ///     The weapon.
    /// </value>
    public InventoryItem Weapon => Inventory.GetItemAt(6);

    /// <summary>
    ///     Gets information about the current trade job.
    /// </summary>
    public TradeInfo TradeInfo { get; internal set; } = null;

    /// <summary>
    ///     Notification sounds
    /// </summary>
    public NotificationSounds NotificationSounds { get; private set; } = new();

    /// <summary>
    ///     Gets a value indicating whether this player is able to attack.
    /// </summary>
    /// <value>
    ///     <c>true</c> if this instance can attack; otherwise, <c>false</c>.
    /// </value>
    public bool CanAttack
    {
        get
        {
            //Status
            if (State.LifeState == LifeState.Dead)
                return false;

            if (State.ScrollState == ScrollState.NormalScroll)
                return false;

            if (State.BodyState == BodyState.Untouchable)
                return false;

            if (State.HitState == ActionHitStateFlag.KnockDown)
                return false;

            if (HasActiveVehicle)
                return false;

            if (State.MotionState == MotionState.Sitting)
                return false;

            //Bad effects - probably there are more
            if ((BadEffect & BadEffect.Fear) != 0)
                return false;

            if ((BadEffect & BadEffect.Sleep) != 0)
                return false;

            if ((BadEffect & BadEffect.Frozen) != 0)
                return false;

            if ((BadEffect & BadEffect.Stunned) != 0)
                return false;

            return true;
        }
    }

    /// <summary>
    ///     The update method
    /// </summary>
    /// <param name="delta">Time between previous and current run</param>
    public override bool Update(int delta)
    {
        base.Update(delta);

        if (HasActiveVehicle)
            Movement = Vehicle.Movement;

        return true;
    }

    /// <summary>
    ///     Gets the ammunition amount.
    /// </summary>
    /// <returns></returns>
    public int GetAmmunitionAmount(bool fullInventory = false)
    {
        if (!fullInventory)
        {
            var itemAtSlot = Inventory.GetItemAt(7);
            if (itemAtSlot?.Record.TypeID2 == 3 && itemAtSlot?.Record.TypeID3 == 4)
                return (short)itemAtSlot.Amount;
        }
        else
        {
            var typeIdFilter = new TypeIdFilter
            {
                TypeID1 = 3,
                TypeID2 = 3,
                TypeID3 = 4,
                TypeID4 = (byte)GetCurrentAmmunitionType(),
            };

            return Inventory.GetSumAmount(typeIdFilter);
        }

        return -1;
    }

    /// <summary>
    ///     Gets the type of the current ammunition.
    /// </summary>
    /// <returns></returns>
    public AmmunitionType GetCurrentAmmunitionType()
    {
        return Game.Player.Race switch
        {
            ObjectCountry.Europe => AmmunitionType.Bolt,
            ObjectCountry.Chinese => AmmunitionType.Arrow,
            _ => AmmunitionType.None,
        };
    }

    /// <summary>
    ///     Moves the specified destination.
    /// </summary>
    /// <param name="destination">The destination.</param>
    /// <param name="sleep">if set to <c>true</c> [sleep].</param>
    /// <returns></returns>
    public bool MoveTo(Position destination, bool sleep = true)
    {
        var distance = Game.Player.Movement.Source.DistanceTo(destination);
        if (distance > 150)
        {
            Log.Debug($"Player.Move: Target position too far away! Target distance: {Math.Round(distance, 2)}");

            return false;
        }

        if (HasActiveVehicle)
        {
            Vehicle.MoveTo(destination, sleep);
            return true;
        }

        var packet = new Packet(0x7021);
        packet.WriteByte(1);

        if (!Game.Player.IsInDungeon)
        {
            destination.Region.Serialize(packet);
            packet.WriteShort(destination.XOffset);
            packet.WriteShort(destination.ZOffset);
            packet.WriteShort(destination.YOffset);
        }
        else
        {
            Game.Player.Position.Region.Serialize(packet);
            packet.WriteInt(destination.XOffset);
            packet.WriteInt(destination.ZOffset);
            packet.WriteInt(destination.YOffset);
        }

        var awaitCallback = new AwaitCallback(
            response =>
            {
                var uniqueId = response.ReadUInt();
                return uniqueId == Game.Player.UniqueId
                    ? AwaitCallbackResult.Success
                    : AwaitCallbackResult.ConditionFailed;
            },
            0xB021
        );

        PacketManager.SendPacket(packet, PacketDestination.Server, awaitCallback);
        awaitCallback.AwaitResponse();

        if (awaitCallback.IsCompleted)
        {
            if (!sleep)
                return true;

            //Wait to finish the step
            Thread.Sleep(Convert.ToInt32(distance / Game.Player.ActualSpeed * 10000));

            return true;
        }

        return false;
    }

    private bool UsePotion(TypeIdFilter filter, ref int tick, ref int duration)
    {
        lock (_lock)
        {
            if (State.LifeState == LifeState.Dead)
                return false;

            if (Game.SelectedEntity is SpawnedNpcNpc)
                return false;

            var potionItem = Inventory.GetItem(filter);
            if (potionItem == null)
                return false;

            if (duration == 0)
            {
                var record = potionItem.Record;
                // potion
                if (record.Param1 > 0 || record.Param3 > 0)
                {
                    if (Race == ObjectCountry.Chinese)
                        duration = 1050;
                    else
                        duration = 15050;
                }
                // grain
                else if (record.Param2 > 0 || record.Param4 > 0)
                {
                    duration = 4050;
                }
                else
                {
                    Log.Debug($"Unknown poion type: {record}");
                }
            }

            var elapsed = Kernel.TickCount - tick;

            if (elapsed < duration)
                return false;

            var result = potionItem.Use();

            if (result)
            {
                tick = Kernel.TickCount;

                Log.Debug($"Potion [{potionItem.Record.GetRealName()}] used");
            }
            else
            {
                Log.Debug(
                    $"[ERROR] Potion [{potionItem.Record.GetRealName()}] used Elapsed:{elapsed} Duration:{duration} Condition:{elapsed < duration}"
                );
            }

            return result;
        }
    }

    /// <summary>
    ///     Uses the health potion.
    /// </summary>
    public bool UseHealthPotion()
    {
        return UsePotion(new TypeIdFilter(3, 3, 1, 1), ref _lastHpPotionTick, ref _lastHPDuration);
    }

    /// <summary>
    ///     Uses the health potion.
    /// </summary>
    public bool UseManaPotion()
    {
        return UsePotion(new TypeIdFilter(3, 3, 1, 2), ref _lastMpPotionTick, ref _lastMPDuration);
    }

    /// <summary>
    ///     Uses the vigor potion.
    /// </summary>
    /// <returns></returns>
    public bool UseVigorPotion()
    {
        return UsePotion(new TypeIdFilter(3, 3, 1, 3), ref _lastVigorPotionTick, ref _lastVigorDuration);
    }

    /// <summary>
    ///     Uses the universal pill.
    /// </summary>
    /// <returns></returns>
    public bool UseUniversalPill()
    {
        if (State.LifeState == LifeState.Dead)
            return false;

        var elapsed = Kernel.TickCount - _lastUniversalPillTick;
        if (elapsed < 1050)
            return false;

        var slotItem = Inventory.GetItem(p => p.Record.IsUniversalPill || p.Record.IsAbnormalPotion);
        if (slotItem == null)
            return false;

        var result = slotItem.Use();
        if (result)
            _lastUniversalPillTick = Kernel.TickCount;

        return result;
    }

    /// <summary>
    ///     Uses the purification pill.
    /// </summary>
    /// <returns></returns>
    public bool UsePurificationPill()
    {
        if (State.LifeState == LifeState.Dead)
            return false;

        var elapsed = Kernel.TickCount - _lastPurificationPillTick;
        if (elapsed < 20050)
            return false;

        var slotItem = Inventory.GetItem(p => p.Record.IsPurificationPill || p.Record.IsAbnormalPotion);
        if (slotItem == null)
            return false;

        var result = slotItem.Use();
        if (result)
            _lastPurificationPillTick = Kernel.TickCount;

        return result;
    }

    /// <summary>
    ///     Summons the ability pet.
    /// </summary>
    /// <returns></returns>
    public bool SummonAbilityPet()
    {
        if (AbilityPet != null)
            return false;

        var typeIdFilter = new TypeIdFilter(3, 2, 1, 2);
        var slotItem = Inventory.GetItem(typeIdFilter);
        if (slotItem == null)
            return false;

        return slotItem.Use();
    }

    /// <summary>
    ///     Summons the vehicle.
    /// </summary>
    /// <returns></returns>
    public bool SummonVehicle()
    {
        if (
            HasActiveVehicle
            || Game.Player.State.BattleState == BattleState.InBattle
            || Game.Player.JobTransport != null
        )
            return false;

        var typeIdFilter = new TypeIdFilter(3, 3, 3, 2);
        var vehicleItem = Inventory.GetItem(item =>
            typeIdFilter.EqualsRefItem(item.Record)
            && item.Record.ReqLevel1 <= Game.Player.Level
            && !item.Record.CodeName.Contains("COS_T")
        );
        if (vehicleItem == null)
            return false;

        return vehicleItem.Use();
    }

    /// <summary>
    ///     Uses the return scroll.
    /// </summary>
    /// <returns></returns>
    public bool UseReturnScroll()
    {
        if (State.ScrollState != ScrollState.Cancel)
            return false;

        var typeIdFilter = new TypeIdFilter(3, 3, 3, 1);
        var slotItem = Inventory.GetItem(item =>
            typeIdFilter.EqualsRefItem(item.Record) && item.Record.ReqLevel1 <= Game.Player.Level
        );
        if (slotItem == null)
            return false;

        return slotItem.Use();
    }

    /// <summary>
    ///     Equips the ammunition.
    /// </summary>
    public void EquipAmmunition()
    {
        if (!Kernel.Bot.Running)
            return;

        var currentWeapon = Inventory.GetItemAt(6);
        var currentAmmunation = Inventory.GetItemAt(7);

        if (currentWeapon == null || currentAmmunation != null)
            return;

        InventoryItem ammunition;

        if (currentWeapon.Record.TypeID4 == 6) //Bow
            ammunition = Inventory.GetItem(new TypeIdFilter(3, 3, 4, 1));
        else if (currentWeapon.Record.TypeID4 == 12) //Crossbow
            ammunition = Inventory.GetItem(new TypeIdFilter(3, 3, 4, 2));
        else
            return;

        if (ammunition != null)
        {
            Inventory.MoveItem(ammunition.Slot, 7);
            return;
        }

        if (!PlayerConfig.Get<bool>("RSBot.Protection.checkNoArrows"))
        {
            Kernel.Bot.Stop();
            return;
        }

        Log.Notify("Could not auto-equip ammunition: No correct ammunition type was found in the player's inventory");
        EventManager.FireEvent("OnUpdateAmmunition");
    }

    /// <summary>
    ///     Revives the growth pet.
    /// </summary>
    /// <returns></returns>
    public bool ReviveGrowth()
    {
        var petItem = Inventory.GetItem(p => p.Record.IsGrowthPet && p.State == InventoryItemState.Dead);
        if (petItem == null)
            return false;

        var rescueItem = Inventory.GetItem(p => p.Record.IsCosRevivalPotion);
        if (rescueItem == null)
            return false;

        rescueItem.UseTo(petItem.Slot);
        return true;
    }

    /// <summary>
    ///     Revives the fellow pet.
    /// </summary>
    /// <returns></returns>
    public bool ReviveFellow()
    {
        var petItem = Inventory.GetItem(p => p.Record.IsFellowPet && p.State == InventoryItemState.Dead);
        if (petItem == null)
            return false;

        var petLevel = petItem.Cos.Level;
        var rescueItem = Inventory.GetItem(p =>
            p.Record.IsCosRevivalPotion
            && p.Record.CodeName.StartsWith("ITEM_PET2_GOODS_REVIVAL_")
            && petLevel >= p.Record.ReqLevel1
            && petLevel <= p.Record.ReqLevel2
        );

        if (rescueItem == null)
            return false;

        rescueItem.UseTo(petItem.Slot);

        return true;
    }

    /// <summary>
    ///     Summons the attack pet.
    /// </summary>
    /// <returns></returns>
    public bool SummonGrowth()
    {
        if (Growth != null)
            return false;

        var typeIdFilter = new TypeIdFilter(3, 2, 1, 1);

        var petItem = Inventory.GetItem(typeIdFilter);
        if (petItem == null)
            return false;

        if (petItem.State == InventoryItemState.Summoned || petItem.State == InventoryItemState.Dead)
            return false;

        return petItem.Use();
    }

    /// <summary>
    ///     Summons the fellow pet.
    /// </summary>
    /// <returns></returns>
    public bool SummonFellow()
    {
        if (Fellow != null)
            return false;

        var typeIdFilter = new TypeIdFilter(3, 2, 1, 3);

        var petItem = Inventory.GetItem(typeIdFilter);
        if (petItem == null)
            return false;

        if (petItem.State == InventoryItemState.Summoned || petItem.State == InventoryItemState.Dead)
            return false;

        var usingItem = Game.Player.Inventory.GetItem(p => p.Record.IsFellowHpPotion);
        if (usingItem == null)
            return false;

        return petItem.Use();
    }

    /// <summary>
    ///     Enters the berzerk mode.
    /// </summary>
    public void EnterBerzerkMode()
    {
        if (!CanEnterBerzerk)
            return;

        var packet = new Packet(0x70A7);
        packet.WriteByte(0x1); //Enter HWAN

        var callback = new AwaitCallback(null, 0xB0A7);
        PacketManager.SendPacket(packet, PacketDestination.Server, callback);
        callback.AwaitResponse(500);
    }

    /// <summary>
    ///     Get ability skills
    /// </summary>
    /// <param name="abilitySkills">The ability skills</param>
    public bool TryGetAbilitySkills(out List<SkillInfo> abilitySkills)
    {
        var player = Game.Player;
        abilitySkills = new List<SkillInfo>();

        foreach (var item in player.Inventory.GetEquippedPartItems().Union(player.Avatars))
        {
            if (item.HasAbility(out var abilityItem))
                abilitySkills.AddRange(abilityItem.GetLinks().Select(skillId => new SkillInfo(skillId, true)));

            if (Game.ClientType >= GameClientType.Chinese_Old)
            {
                if (!item.HasExtraAbility(out var extraAbilityItems))
                    continue;

                abilitySkills.AddRange(
                    extraAbilityItems
                        .SelectMany(p => p.Skills)
                        .Where(p => p != 0)
                        .Select(skillId => new SkillInfo(skillId, true))
                );
            }
        }

        return abilitySkills.Any();
    }
}
