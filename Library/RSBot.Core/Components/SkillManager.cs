using RSBot.Core.Objects;
using RSBot.Core.Objects.Skill;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RSBot.Core.Components
{
    public static class SkillManager
    {
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
        /// Gets or sets the party members buffs
        /// </summary>
        public static List<(string Member, List<SkillInfo> Buffs)> PartyMemberBuffs { get; set; }

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        internal static void Initialize()
        {
            PartyMemberBuffs = new List<(string Member, List<SkillInfo> Buffs)>();
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
            if (Game.SelectedEntity == null || Game.SelectedEntity.Monster == null) 
                return null;

            var rarity = MonsterRarity.General;
            if (Skills[Game.SelectedEntity.Monster.Rarity].Count > 0)
                rarity = Game.SelectedEntity.Monster.Rarity;

            return Skills[rarity].Find(s => Game.Player.Skills.GetSkillInfoById(s.Id).CanBeCasted);
        }
    }
}