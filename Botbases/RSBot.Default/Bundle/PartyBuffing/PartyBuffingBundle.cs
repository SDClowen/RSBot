using RSBot.Core;
using RSBot.Core.Components;
using RSBot.Core.Event;
using RSBot.Core.Objects.Party;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RSBot.Default.Bundle.PartyBuffing
{
    internal class PartyBuffingBundle : IBundle
    {
        /// <summary>
        /// The buffing party members
        /// </summary>
        private List<BuffingPartyMember> BuffingPartyMembers;

        /// <summary>
        /// <c>true</c> if refreshing this bundle; otherwise <c>false</c>
        /// </summary>
        private bool _refreshing;

        /// <summary>
        /// Initialize the instance of <seealso cref="PartyBuffingBundle"/>
        /// </summary>
        public PartyBuffingBundle()
        {
            EventManager.SubscribeEvent("OnPartyBuffSettingsChanged", OnPartyBuffSettingsChanged);
        }

        /// <summary>
        /// Update the <see cref="BuffingPartyMembers"/> list when settings changed from another plugins
        /// </summary>
        private void OnPartyBuffSettingsChanged()
        {
            Refresh();
        }

        /// <summary>
        /// Invoke the bundle
        /// </summary>
        public void Invoke()
        {
            if (_refreshing)
                return;

            if (Game.Party == null ||
                Game.Party.Members == null || 
                Game.Player.HasActiveVehicle)
                return;

            var selectedGroup = PlayerConfig.Get("RSBot.Party.Buffing.SelectedGroup", "Default");

            var members = Game.Party.Members
                .Where(p => BuffingPartyMembers.Any(s => s.Group == selectedGroup && s.Name == p.Name));
            foreach (var member in members)
            {
                if (member.Player == null)
                    continue;

                var buffingMember = BuffingPartyMembers.Find(p => p.Name == member.Name);
                if (buffingMember == null)
                    continue;

                if (buffingMember.Buffs.Count == 0)
                    continue;

                var activeBuffs = member.Player.State.ActiveBuffs;

                var neededBuffs = buffingMember.Buffs
                    .Where(skillId => !activeBuffs.Any(p => p.Id == skillId ||
                    (Game.ReferenceManager.SkillData.TryGetValue(skillId, out var refSkill) && refSkill.Action_Overlap == p.Record.Action_Overlap)));

                foreach (var castingBuffId in neededBuffs)
                {
                    var skill = Game.Player.Skills.GetSkillInfoById(castingBuffId);
                    if (skill == null || skill.HasCooldown)
                        continue;

                    SkillManager.CastBuff(skill, member.Player.UniqueId);
                }
            }
        }

        /// <summary>
        /// Refresh the bundle
        /// </summary>
        public void Refresh()
        {
            _refreshing = true;

            // Don't need to use clear, because gc will handle the unnecessary objects
            BuffingPartyMembers = new List<BuffingPartyMember>();

            var settings = PlayerConfig.Get<string>("RSBot.Party.Buffing", string.Empty);
            var collection = settings.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var item in collection)
                BuffingPartyMembers.Add(new BuffingPartyMember(item));

            _refreshing = false;
        }

        public void Stop()
        {
            //Nothing to do here
        }
    }
}