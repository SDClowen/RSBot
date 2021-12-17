using RSBot.Core.Client.ReferenceObjects;
using RSBot.Core.Network;
using RSBot.Core.Objects;
using RSBot.Core.Objects.Skill;
using RSBot.Core.Objects.Spawn;
using System;
using System.Collections.Generic;
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
        /// Initializes this instance.
        /// </summary>
        internal static void Initialize()
        {
            Skills = Enum.GetValues(typeof(MonsterRarity)).Cast<MonsterRarity>().ToDictionary(v => v, v => new List<SkillInfo>());
            Buffs = new List<SkillInfo>();

            Log.Debug($"Initialized [SkillManager] for [{Skills.Count}] different mob rarities!");
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
        public static SkillInfo GetNextSkill()
        {
            var entity = Game.SelectedEntity.Entity;
            if (!(entity is SpawnedBionic bionic))
                return null;

            var rarity = MonsterRarity.General;

            if (entity is SpawnedMonster monster)
            {
                if (Skills[monster.Rarity].Count > 0)
                    rarity = monster.Rarity;
            }

            var distance = Game.Player.Tracker.Position.DistanceTo(bionic.Tracker.Position);

            var minDifference = int.MaxValue;
            //var weaponRange = 0;
            var closestSkill = default(SkillInfo);

            if (bionic.State.HitState == ActionHitStateFlag.KnockDown)
            {
                // try to get attack skill for only knockdown states
                closestSkill = Skills[rarity].Find(p => p.Record.Params.Contains(25697));
            }
            else if(distance < 10)
            {
                while (true)
                {
                    _lastIndex++;
                    if (_lastIndex > Skills[rarity].Count - 1)
                        _lastIndex = 0;

                    var selectedSkill = Skills[rarity][_lastIndex];
                    if (!selectedSkill.CanBeCasted)
                        continue;

                    closestSkill = selectedSkill;
                    break;
                }
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
            }

            return closestSkill;
        }

        /// <summary>
        /// Check required of the using skill
        /// </summary>
        /// <param name="skill">The using skill</param>
        public static bool CheckSkillRequired(RefSkill skill)
        {
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
                // find and equip the shield item automaticaly
                filter = new TypeIdFilter(3, 1, 4, (byte)(Game.Player.Race == ObjectCountry.Chinese ? 1 : 2));
                var shieldItem = Game.Player.Inventory.GetItemBest(filter);
                if (shieldItem != null && shieldItem.Slot != 7)
                    shieldItem.Equip(7);
            }

            return result;
        }

        /// <summary>
        /// Cast player skill
        /// </summary>
        /// <param name="skillId">The skill identifier.</param>
        /// <param name="targetId">The target unique identifier.</param>
        /// <returns> <c>true</c> if this successfully used the selected skill; otherwise, <c>false</c>.</returns>
        public static bool CastSkill(SkillInfo skill, uint targetId = 0)
        {
            if (!Game.Player.Skills.HasSkill(skill.Id))
                return false;

            if (!SpawnManager.TryGetEntity<SpawnedBionic>(targetId, out var entity))
                return false;

            var weapon = Game.Player.Inventory.GetItemAt(6);

            if (!CheckSkillRequired(skill.Record))
                return false;

            var distance = Game.Player.Tracker.Position.DistanceTo(entity.Tracker.Position);
            var speed = Game.Player.Tracker.ActualSpeed;
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

            packet.Lock();

            var awaitCallBack = new AwaitCallback(response =>
            {
                var result = response.ReadByte();

                ushort code = 0;
                if (Core.Game.ClientType > GameClientType.Thailand)
                    code = response.ReadUShort();

                if (result == 2)
                {
                    if (Core.Game.ClientType < GameClientType.Vietnam)
                        code = response.ReadByte();

                    switch (code)
                    {
                        case 0x0E: // thailand, jsro, ecsro
                        case 0x300E:
                            Game.Player.EquipAmmunation();
                            break;

                        case 0x06: // thailand, jsro, ecsro invalid target
                        case 0x10: // thailand, jsro, ecsro invalid target
                        case 0x3006: // invalid target
                        case 0x3010: // obstacle
                            break;
                        default:
                            Log.Error($"Invalid skill error code: 0x{code:X2}");
                            break;
                    }

                    return AwaitCallbackResult.Failed;
                }

                var action = Objects.Action.DeserializeBegin(response);

                return action.SkillId == skill.Id && action.PlayerIsExecutor 
                            ? AwaitCallbackResult.Received : AwaitCallbackResult.None;
            }, 0xB070);

            var callback = new AwaitCallback(response =>
            {
                return response.ReadByte() == 0x02 && response.ReadByte() == 0x00
                            ? AwaitCallbackResult.Received : AwaitCallbackResult.None;
            }, 0xB074);

            
            RefSkill altSkill = skill.Record;
            while (altSkill != null)
            {
                duration += altSkill.Action_CastingTime;/* +
                            altSkill.Action_ActionDuration +
                            altSkill.Action_PreparingTime;*/

                if (altSkill.Basic_ChainCode != 0)
                    altSkill = Game.ReferenceManager.GetRefSkill(altSkill.Basic_ChainCode);
                else
                    break;
            }
            
            if (duration < 100)
                duration = 1000;

            PacketManager.SendPacket(packet, PacketDestination.Server, awaitCallBack, callback);
            Thread.Sleep(duration);
            /*
            awaitCallBack.AwaitResponse(duration);

            if (skill.Record.Basic_Activity != 1)
                callback.AwaitResponse();
            */

            //return awaitCallBack.IsCompleted;

            return true;
        }


        /// <summary>
        /// Casts the buff skill.
        /// </summary>
        /// <param name="skillId">The skill identifier.</param>
        public static void CastBuff(SkillInfo skill, uint target = 0)
        {
            if (!Game.Player.Skills.HasSkill(skill.Id))
                return;

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

            packet.Lock();

            var asyncCallback = new AwaitCallback(response =>
            {
                var targetId = response.ReadUInt();
                var castedSkillId = response.ReadUInt();

                if (targetId == (target == 0 ? Game.Player.UniqueId : target) && 
                    castedSkillId == skill.Id)
                    return AwaitCallbackResult.Received;

                return AwaitCallbackResult.None;

            }, 0xB0BD);

            var callback = new AwaitCallback(response =>
            {
                return response.ReadByte() == 0x02 && response.ReadByte() == 0x00
                    ? AwaitCallbackResult.Received : AwaitCallbackResult.None;
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
        public static bool CastAutoAttack(uint targetId)
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
                
                if (result == 0x01)
                    return Objects.Action.DeserializeBegin(response).PlayerIsExecutor
                        ? AwaitCallbackResult.Received : AwaitCallbackResult.None;

                var code = 0;
                if (Game.ClientType < GameClientType.Vietnam)
                    code = response.ReadByte();
                else
                    code = response.ReadUShort();

                switch (code)
                {
                    case 0x0E:
                    case 0x300E:
                        Game.Player.EquipAmmunation();
                        break;

                    case 0x06: // invalid target < vietnam
                    case 0x3006: // invalid target
                    case 0x10: // obstacle < vietnam
                    case 0x3010: // obstacle
                        break;
                    default:
                        Log.Error($"Invalid skill error code: 0x{code:X2}");
                        break;
                }

                return AwaitCallbackResult.Failed;
            }, 0xB070);

            PacketManager.SendPacket(packet, PacketDestination.Server, awaitCallBack);
            awaitCallBack.AwaitResponse();

            return awaitCallBack.IsCompleted;
        }
    }
}