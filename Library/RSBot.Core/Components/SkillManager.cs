using RSBot.Core.Client.ReferenceObjects;
using RSBot.Core.Event;
using RSBot.Core.Network;
using RSBot.Core.Objects;
using RSBot.Core.Objects.Skill;
using RSBot.Core.Objects.Spawn;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace RSBot.Core.Components
{
    public static class SkillManager
    {
        /// <summary>
        /// Get the skill using index
        /// </summary>
        private static int _lastIndex = 0;

        /// <summary>
        /// Gets or sets the skills organized by their mob priority.
        /// </summary>
        /// <value>
        /// The skills.
        /// </value>
        public static Dictionary<MonsterRarity, List<SkillInfo>> Skills { get; set; }

        /// <summary>
        /// Gets or sets the resurrection skill.
        /// </summary>
        /// <value>
        /// The resurrection skill.
        /// </value>
        public static SkillInfo ResurrectionSkill { get; set; }

        /// <summary>
        /// Gets or sets the imbue skill.
        /// </summary>
        /// <value>
        /// The imbue skill.
        /// </value>
        public static SkillInfo ImbueSkill { get; set; }

        /// <summary>
        /// Gets or sets the buffs.
        /// </summary>
        /// <value>
        /// The buffs.
        /// </value>
        public static List<SkillInfo> Buffs { get; set; }

        /// <summary>
        /// The last casted skill id
        /// </summary>
        public static uint LastCastedSkillId;

        /// <summary>
        /// Is the last action basic skill (Auto attack) <c>true</c>; otherwise <c>false</c>
        /// </summary>
        public static bool IsLastCastedBasic => _baseSkills.Contains(LastCastedSkillId);

        /// <summary>
        /// Basic skills
        /// </summary>
        private static uint[] _baseSkills = new uint[]
        {
            70,40,2,8421,9354,
            9355,11162,9944,8419,
            8420,11526,10625
        };

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        internal static void Initialize()
        {
            Skills = Enum.GetValues(typeof(MonsterRarity)).Cast<MonsterRarity>().ToDictionary(v => v, v => new List<SkillInfo>());
            Buffs = new List<SkillInfo>();

            EventManager.SubscribeEvent("OnCastSkill", new Action<uint>(OnCastSkill));

            Log.Debug($"Initialized [SkillManager] for [{Skills.Count}] different mob rarities!");
        }

        /// <summary>
        /// Call after casted skill
        /// </summary>
        /// <param name="skillId">The casted skill id</param>
        private static void OnCastSkill(uint skillId)
        {
            LastCastedSkillId = skillId;
        }

        /// <summary>
        /// Sets the skills.
        /// </summary>
        /// <param name="monsterRarity">The monster rarity.</param>
        /// <param name="skills">The skills.</param>
        public static void SetSkills(MonsterRarity monsterRarity, List<SkillInfo> skills)
        {
            if (Skills == null || !Skills.ContainsKey(monsterRarity)) return;

            Skills[monsterRarity] = skills;
        }

        /// <summary>
        /// Gets the next skill.
        /// </summary>
        /// <returns></returns>
        public static SkillInfo? GetNextSkill()
        {
            var entity = Game.SelectedEntity;
            if (entity == null)
                return null;

            var rarity = MonsterRarity.General;

            if (entity is SpawnedMonster monster)
            {
                if (Skills[monster.Rarity].Count > 0)
                    rarity = monster.Rarity;
            }

            var distance = Game.Player.Movement.Source.DistanceTo(entity.Movement.Source);

            var minDifference = int.MaxValue;
            //var weaponRange = 0;
            var closestSkill = default(SkillInfo);

            if (entity.State.HitState == ActionHitStateFlag.KnockDown)
            {
                // try to get attack skill for only knockdown states
                closestSkill = Skills[rarity].Find(p => p.Record.Params.Contains(25697));
            }
            else if (distance < 10)
            {
                var counter = -1;
                var skillCount = Skills[rarity].Count;
                while (skillCount > 0 && counter < skillCount)
                {
                    counter++;
                    _lastIndex++;

                    if (_lastIndex > Skills[rarity].Count - 1)
                        _lastIndex = 0;

                    var selectedSkill = Skills[rarity][_lastIndex];
                    if (!selectedSkill.CanBeCasted)
                        continue;

                    closestSkill = selectedSkill;
                    break;
                }

                //Debug.WriteLine($"while loop: {stopwatch.ElapsedMilliseconds}");
            }
            else
            {
                /*var weapon = Game.Player.Inventory.GetItemAt(6);
                if (weapon != null)
                    weaponRange = weapon.Record.Range / 10;
                */
                
                for (int i = 0; i < Skills[rarity].Count; i++)
                {
                    var s = Skills[rarity][i];
                    if (!s.CanBeCasted)
                        continue;

                    var difference = Math.Abs((s.Record.Action_Range / 10) - distance/* + weaponRange*/);
                    if (minDifference > difference)
                    {
                        minDifference = (short)difference;
                        closestSkill = s;
                    }
                }
                //Debug.WriteLine($"for loop: {stopwatch.ElapsedMilliseconds}");
            }

            return closestSkill;
        }

        /// <summary>
        /// Check required of the using skill
        /// </summary>
        /// <param name="skill">The using skill</param>
        public static bool CheckSkillRequired(RefSkill skill)
        {
            if (skill.ReqCommon_Mastery1 == 1)
                return true;

            InventoryItem requiredItem = null;
            TypeIdFilter filter = null;

            var currentWeapon = Game.Player.Inventory.GetItemAt(6);
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

                filter = list.FirstOrDefault(p => p.TypeID3 == currentWeapon?.Record.TypeID3 && p.TypeID4 == currentWeapon?.Record.TypeID4);
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

            requiredItem = Game.Player.Inventory.GetItemBest(filter);
            if (requiredItem == null)
                return false;

            var movingSlot = (byte)(requiredItem.Record.TypeID3 == 6 ? 6 : 7);
            if (requiredItem.Slot == movingSlot)
                return true;

            var result = requiredItem.Equip(movingSlot);

            if (movingSlot == 6 && requiredItem.Record.TwoHanded == 0)
            {
                // find and equip the shield item automatically
                filter = new TypeIdFilter(3, 1, 4, (byte)(Game.Player.Race == ObjectCountry.Chinese ? 1 : 2));
                var shieldItem = Game.Player.Inventory.GetItemBest(filter);
                if (shieldItem != null && shieldItem.Slot != 7)
                    shieldItem.Equip(7);
            }

            return result;
        }

        public static bool CastSkill(SkillInfo skill, uint targetId = 0)
        {
            if (!Game.Player.Skills.HasSkill(skill.Id))
                return false;

            if (!SpawnManager.TryGetEntity<SpawnedBionic>(targetId, out var entity))
                return false;

            if (entity.State.LifeState == LifeState.Dead)
                return false;
            
            if (!CheckSkillRequired(skill.Record))
                return false;

            var packet = new Packet(0x7074);
            packet.WriteByte(1); //Execute
            packet.WriteByte(4); //Use Skill
            packet.WriteUInt(skill.Id);
            packet.WriteByte(ActionTarget.Entity);

            // unknown byte
            if (Game.ClientType < GameClientType.Thailand)
                packet.WriteByte(1);

            packet.WriteUInt(targetId);

            Log.Debug($"Skill Attacking to: {targetId} State: {entity.State.LifeState} Health: {entity.Health} HasHealth: {entity.HasHealth} Dst: {System.Math.Round(entity.DistanceToPlayer, 1)}");

            PacketManager.SendPacket(packet, PacketDestination.Server);

            return true;
        }

        /// <summary>
        /// Cast player skill
        /// </summary>
        /// <param name="skillId">The skill identifier.</param>
        /// <param name="targetId">The target unique identifier.</param>
        /// <returns> <c>true</c> if this successfully used the selected skill; otherwise, <c>false</c>.</returns>
        public static bool CastSkillOld(SkillInfo skill, uint targetId = 0)
        {
            if (!Game.Player.Skills.HasSkill(skill.Id))
                return false;

            if (!SpawnManager.TryGetEntity<SpawnedBionic>(targetId, out var entity))
                return false;

            if (entity.State.LifeState == LifeState.Dead)
                return false;

            var weapon = Game.Player.Inventory.GetItemAt(6);

            if (!CheckSkillRequired(skill.Record))
                return false;

            var distance = entity.DistanceToPlayer;
            var speed = Game.Player.ActualSpeed;
            var movingSleep = 0d;

            // tel3 warrior sprint teleport
            var tel3Index = skill.Record.Params.FindIndex(p => p == 1952803891);
            if (tel3Index != -1)
            {
                var tel3speed = skill.Record.Params[++tel3Index];
                var tel3meter = skill.Record.Params[++tel3Index] / 10;

                if (distance < tel3meter)
                    movingSleep = distance / tel3speed;
                else
                    movingSleep = ((distance - tel3meter) / speed) + (tel3meter / tel3speed);
            }
            else
            {
                var range = skill.Record.Action_Range / 10;
                if (distance - 3 > range)
                    movingSleep = (distance - range) / speed;
            }

            if (movingSleep < 0)
                movingSleep = 0;
            else
                movingSleep *= 10000.0;

            var duration = (int)movingSleep;/* +
                         skill.Record.Action_CastingTime; +
                         skill.Record.Action_ActionDuration +
                         skill.Record.Action_PreparingTime;*/

            var packet = new Packet(0x7074);
            packet.WriteByte(1); //Execute
            packet.WriteByte(4); //Use Skill
            packet.WriteUInt(skill.Id);
            packet.WriteByte(ActionTarget.Entity);
            packet.WriteUInt(targetId);

            var callback = new AwaitCallback(response => response.ReadByte() == 0x02 && response.ReadByte() == 0x00
                ? AwaitCallbackResult.Success : AwaitCallbackResult.ConditionFailed, 0xB074);

            var altSkill = skill.Record;
            while (altSkill != null)
            {
                duration += altSkill.Action_CastingTime +
                            altSkill.Action_ActionDuration +
                            altSkill.Action_PreparingTime;

                if (altSkill.Basic_ChainCode != 0)
                    altSkill = Game.ReferenceManager.GetRefSkill(altSkill.Basic_ChainCode);
                else
                    break;
            }

            if (duration < 100)
                duration = 1000;

            Log.Debug($"Skill Attacking to: {targetId} State: {entity.State.LifeState} Health: {entity.Health} HasHealth: {entity.HasHealth} Dst: {System.Math.Round(entity.DistanceToPlayer, 1)}");

            PacketManager.SendPacket(packet, PacketDestination.Server, callback);
            Thread.Sleep(duration);

            if (skill.Record.Basic_Activity != 1)
            {
                callback.AwaitResponse(duration);
                return callback.IsCompleted;
            }

            return true;
        }

        /// <summary>
        /// Casts the buff skill.
        /// </summary>
        /// <param name="skillId">The skill identifier.</param>
        public static void CastBuff(SkillInfo skill, uint target = 0)
        {
            /*
            if (!Game.Player.Skills.HasSkill(skill.Id))
                return;
            */
            if (!CheckSkillRequired(skill.Record))
                return;

            Log.Notify($"Casting skill (self-buff) [{skill.Record.GetRealName()}]");

            var packet = new Packet(0x7074);
            packet.WriteByte(1); //Execute
            packet.WriteByte(4); //Use Skill
            packet.WriteUInt(skill.Id);

            if (skill.Record.TargetGroup_Self ||
               skill.Record.TargetGroup_Party)
            {
                packet.WriteByte(ActionTarget.Entity);
                packet.WriteUInt(target == 0 ? Game.Player.UniqueId : target);
            }
            else
                packet.WriteByte(ActionTarget.None);

            var asyncCallback = new AwaitCallback(response =>
            {
                var targetId = response.ReadUInt();
                var castedSkillId = response.ReadUInt();

                if (targetId == (target == 0 ? Game.Player.UniqueId : target) &&
                    castedSkillId == skill.Id)
                    return AwaitCallbackResult.Success;

                return AwaitCallbackResult.ConditionFailed;

            }, 0xB0BD);

            var callback = new AwaitCallback(response =>
            {
                return response.ReadByte() == 0x02 && response.ReadByte() == 0x00
                    ? AwaitCallbackResult.Success : AwaitCallbackResult.ConditionFailed;
            }, 0xB074);

            PacketManager.SendPacket(packet, PacketDestination.Server, asyncCallback, callback);

            asyncCallback.AwaitResponse(skill.Record.Action_CastingTime +
                                        skill.Record.Action_ActionDuration +
                                        skill.Record.Action_PreparingTime + 1500);

            if (skill.Record.Basic_Activity != 1)
                callback.AwaitResponse();
        }

        /// <summary>
        /// Casts the skill. Does not check any weapon requirement.
        /// </summary>
        /// <param name="skill"></param>
        /// <param name="targetId"></param>
        /// <returns></returns>
        public static bool CastAutoAttack()
        {
            var entity = Game.SelectedEntity;
            if (entity == null)
                return false;

            if (entity.State.LifeState == LifeState.Dead)
                return false;

            var packet = new Packet(0x7074);
            packet.WriteByte(1); //Execute
            packet.WriteByte(1); //Use Skill
            packet.WriteByte(ActionTarget.Entity);

            // unknown byte
            if (Game.ClientType < GameClientType.Thailand)
                packet.WriteByte(1);

            packet.WriteUInt(entity.UniqueId);

            Log.Debug($"Normal Attacking to: {entity.UniqueId} State: {entity.State.LifeState} Health: {entity.Health} HasHealth: {entity.HasHealth} Dst: {System.Math.Round(entity.DistanceToPlayer, 1)}");

            PacketManager.SendPacket(packet, PacketDestination.Server);

            return true;
        }

        /// <summary>
        /// Casts the skill at.
        /// </summary>
        /// <param name="skillId">The skill identifier.</param>
        /// <param name="position">The position.</param>
        public static void CastSkillAt(uint skillId, Position position)
        {
            if (!Game.Player.Skills.HasSkill(skillId)) return;

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

            PacketManager.SendPacket(packet, PacketDestination.Server);
        }

        /// <summary>
        /// Cancels the buff.
        /// </summary>
        /// <param name="skillId">The skill identifier.</param>
        public static void CancelBuff(uint skillId)
        {
            if (!Game.Player.Skills.HasSkill(skillId)) return;

            var packet = new Packet(0x7074);
            packet.WriteByte(1); //Execute
            packet.WriteByte(5); //Cancel Buff
            packet.WriteUInt(skillId);
            packet.WriteByte(ActionTarget.None);

            PacketManager.SendPacket(packet, PacketDestination.Server);
        }

        /// <summary>
        /// Cancels the action.
        /// </summary>
        /// <returns></returns>
        public static bool CancelAction()
        {
            var packet = new Packet(0x7074);
            packet.WriteByte(0x02); //Cancel

            var callback = new AwaitCallback(response =>
            {
                return response.ReadByte() == 0x02 && response.ReadByte() == 0x00
                ? AwaitCallbackResult.Success : AwaitCallbackResult.ConditionFailed;
            }, 0xB074);

            PacketManager.SendPacket(packet, PacketDestination.Server, callback);
            callback.AwaitResponse();

            return callback.IsCompleted;
        }
    }
}