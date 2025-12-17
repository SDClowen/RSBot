using Python.Runtime;
using RSBot.Core;
using RSBot.Core.Components;
using RSBot.Core.Extensions;
using RSBot.Core.Objects;
using RSBot.Core.Objects.Skill;
using RSBot.Core.Objects.Spawn;
using RSBot.General.Components;
using RSBot.Python.Components.API.Interface;
using RSBot.Python.Views;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace RSBot.Python.Components.API.Core.Entity
{
    public class EntityAPI : IPythonPlugin
    {
        private Main _main;

        /// <summary>
        /// Unique module name of the plugin.
        /// </summary>
        public string ModuleName => "entity";

        /// <summary>
        /// Called once at startup to provide the main form to the plugin.
        /// </summary>
        /// <param name="main">Main form</param>
        public void Init(Main main)
        {
            _main = main;
        }
        private PyList BuildMonsterList(IEnumerable<SpawnedMonster> monster)
        {
            var list = new PyList();

            foreach (var entry in monster)
            {
                if (entry == null)
                    continue;

                var pyItem = new PyDict();
                pyItem.SetItem(new PyString("uid"), new PyInt(entry.UniqueId));
                pyItem.SetItem(new PyString("model"), new PyInt(entry.Id));
                pyItem.SetItem(new PyString("servername"), new PyString(entry.Record.CodeName));
                pyItem.SetItem(new PyString("name"), new PyString(entry.Record.GetRealName()));
                pyItem.SetItem(new PyString("type"), new PyString(entry.Rarity.GetName()));
                pyItem.SetItem(new PyString("x"), new PyString(entry.Position.X.ToString()));
                pyItem.SetItem(new PyString("y"), new PyString(entry.Position.Y.ToString()));
                pyItem.SetItem(new PyString("z"), new PyString(entry.Position.ZOffset.ToString()));
                pyItem.SetItem(new PyString("region"), new PyString(entry.Position.Region.ToString()));
                pyItem.SetItem(new PyString("region_name"), new PyString(Game.ReferenceManager.GetTranslation(entry.Position.Region.ToString())));
                pyItem.SetItem(new PyString("distance"), new PyString(entry.DistanceToPlayer.ToString()));
                pyItem.SetItem(new PyString("hp"), new PyString(entry.Health.ToString()));
                pyItem.SetItem(new PyString("max_hp"), new PyString(entry.MaxHealth.ToString()));
                list.Append(pyItem);
            }

            return list;
        }
        private PyList BuildNPCList(IEnumerable<SpawnedNpc> npc)
        {
            var list = new PyList();

            foreach (var entry in npc)
            {
                if (entry == null)
                    continue;

                var pyItem = new PyDict();
                pyItem.SetItem(new PyString("uid"), new PyInt(entry.UniqueId));
                pyItem.SetItem(new PyString("model"), new PyInt(entry.Id));
                pyItem.SetItem(new PyString("servername"), new PyString(entry.Record.CodeName));
                pyItem.SetItem(new PyString("name"), new PyString(entry.Record.GetRealName()));
                pyItem.SetItem(new PyString("x"), new PyString(entry.Position.X.ToString()));
                pyItem.SetItem(new PyString("y"), new PyString(entry.Position.Y.ToString()));
                pyItem.SetItem(new PyString("z"), new PyString(entry.Position.ZOffset.ToString()));
                pyItem.SetItem(new PyString("region"), new PyString(entry.Position.Region.ToString()));
                pyItem.SetItem(new PyString("region_name"), new PyString(Game.ReferenceManager.GetTranslation(entry.Position.Region.ToString())));
                pyItem.SetItem(new PyString("distance"), new PyString(entry.DistanceToPlayer.ToString()));
                list.Append(pyItem);
            }

            return list;
        }
        private PyList GetMonsters()
        {
            using (Py.GIL())
            {
                var result = new PyList();
                if (Game.Player == null)
                {
                    return result;
                }
                if (SpawnManager.TryGetEntities<SpawnedMonster>(out var monsters))
                {

                    result = BuildMonsterList(monsters);
                }
                return result;
            }
        }
        private PyList GetNPCs()
        {
            using (Py.GIL())
            {
                var result = new PyList();
                if (Game.Player == null)
                {
                    return result;
                }
                if (SpawnManager.TryGetEntities<SpawnedNpc>(out var npc))
                {
                    result = BuildNPCList(npc);
                }
                return result;
            }
        }
        private PyDict GetCharacter()
        {
            using (Py.GIL())
            {
                var result = new PyDict();
                if (Game.Player == null)
                {
                    return result;
                }
                result.SetItem(new PyString("name"), new PyString(Game.Player.Name));
                result.SetItem(new PyString("server"), new PyString(Serverlist.Joining.Name));
                result.SetItem(new PyString("uid"), new PyInt(Game.Player.UniqueId));
                result.SetItem(new PyString("model"), new PyInt(Game.Player.Id));
                result.SetItem(new PyString("x"), new PyFloat(Game.Player.Position.X));
                result.SetItem(new PyString("y"), new PyFloat(Game.Player.Position.Y));
                result.SetItem(new PyString("z"), new PyString(Game.Player.Position.ZOffset.ToString()));
                result.SetItem(new PyString("region"), new PyString(Game.Player.Position.Region.ToString()));
                result.SetItem(new PyString("region_name"), new PyString(Game.ReferenceManager.GetTranslation(Game.Player.Position.Region.ToString())));
                result.SetItem(new PyString("hp"), new PyInt(Game.Player.Health));
                result.SetItem(new PyString("mp"), new PyInt(Game.Player.Mana));
                result.SetItem(new PyString("max_hp"), new PyInt(Game.Player.MaximumHealth));
                result.SetItem(new PyString("max_mp"), new PyInt(Game.Player.MaximumMana));
                result.SetItem(new PyString("exp"), new PyInt(Game.Player.Experience));
                result.SetItem(new PyString("max_exp"), new PyInt(Game.ReferenceManager.GetRefLevel(Game.Player.Level).Exp_C));
                result.SetItem(new PyString("sp"), new PyInt(Game.Player.SkillPoints));
                result.SetItem(new PyString("level"), new PyInt(Game.Player.Level));
                result.SetItem(new PyString("berserker"), new PyInt(Game.Player.BerzerkPoints));
                return result;
            }
        }
        private PyDict GetPositionTuple()
        {
            using (Py.GIL())
            {
                var result = new PyDict();
                if (Game.Player == null)
                {
                    return result;
                }

                Position position = Game.Player.Position;

                result.SetItem("x", new PyFloat(position.X));
                result.SetItem("y", new PyFloat(position.Y));
                result.SetItem("z", new PyFloat(position.ZOffset));
                result.SetItem("region", new PyString(position.Region.ToString()));

                return result;
            }
        }
        private PyList GetActiveSkills()
        {
            using (Py.GIL())
            {
                var result = new PyList();
                if (Game.Player == null)
                {
                    return result;
                }
                foreach (var skill in Game.Player.State.ActiveBuffs)
                {
                    var pySkill = new PyDict();

                    pySkill.SetItem(new PyString("id"), new PyInt(skill.Id));
                    pySkill.SetItem(new PyString("name"), new PyString(skill.Record.GetRealName()));
                    pySkill.SetItem(new PyString("servername"), new PyString(skill.Record.UI_SkillName));
                    pySkill.SetItem(new PyString("can_cast"), new PyString(skill.CanBeCasted.ToString()));
                    pySkill.SetItem(new PyString("cooldown"), new PyString(skill.HasCooldown.ToString()));
                    result.Append(pySkill);
                }
                return result;
            }
        }
        private PyList GetSkills()
        {
            using (Py.GIL())
            {
                var result = new PyList();
                if (Game.Player == null)
                {
                    return result;
                }
                foreach (SkillInfo skill in Game.Player.Skills.KnownSkills)
                {
                    var pySkill = new PyDict();
                    pySkill.SetItem(new PyString("name"), new PyString(skill.Record.GetRealName()));
                    pySkill.SetItem(new PyString("id"), new PyInt(skill.Id));
                    pySkill.SetItem(new PyString("servername"), new PyString(skill.Record.UI_SkillName));
                    pySkill.SetItem(new PyString("can_cast"), new PyString(skill.CanBeCasted.ToString()));
                    pySkill.SetItem(new PyString("on_cooldown"), new PyString(skill.HasCooldown.ToString()));
                    pySkill.SetItem(new PyString("reuse_time"), new PyInt(skill.Record.Action_ReuseDelay));
                    pySkill.SetItem(new PyString("duration"), new PyString(skill.Record.Action_ActionDuration.ToString()));
                    pySkill.SetItem(new PyString("mastery"), new PyString(Game.ReferenceManager.GetRefSkillMastery(Convert.ToUInt32(skill.Record.ReqCommon_Mastery1)).Name));
                    pySkill.SetItem(new PyString("mastery_id"), new PyInt(skill.Record.ReqCommon_Mastery1));
                    pySkill.SetItem(new PyString("group"), new PyString(skill.Record.Basic_Group));
                    pySkill.SetItem(new PyString("level"), new PyString(skill.Record.Basic_Level.ToString()));
                    pySkill.SetItem(new PyString("type"), new PyString( skill.IsAttack ? "Attack" :
                                                                        skill.IsDot ? "Dot" :
                                                                        skill.IsImbue ? "Imbue" :
                                                                        skill.IsPassive ? "Passive" :""));
                    
                    result.Append(pySkill);
                }
                return result;
            }
        }
        private PyList GetMastery()
        {
            using (Py.GIL())
            {
                var result = new PyList();
                if (Game.Player == null)
                {
                    return result;
                }
                foreach (MasteryInfo mastery in Game.Player.Skills.Masteries)
                {
                    var pySkill = new PyDict();
                    pySkill.SetItem(new PyString("name"), new PyString(Game.ReferenceManager.GetRefSkillMastery(Convert.ToUInt32(mastery.Id)).Name));
                    pySkill.SetItem(new PyString("id"), new PyInt(mastery.Id));
                    pySkill.SetItem(new PyString("level"), new PyInt(mastery.Level));

                    result.Append(pySkill);
                }
                return result;
            }
        }
        public PyList get_monsters()
        {
            return GetMonsters();
        }
        public PyList get_npcs()
        {
            return GetNPCs();
        }
        public PyDict get_character()
        {
            return GetCharacter();
        }
        public PyDict get_position()
        {
            return GetPositionTuple();
        }
        public PyList get_active_skills()
        {
            return GetActiveSkills();
        }
        public PyList get_skills()
        {
            return GetSkills();
        }
        public PyList get_mastery()
        {
            return GetMastery();
        }
    }
}
